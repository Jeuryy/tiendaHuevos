using Capa_Negocio;
using eggstore.src.Boxes;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;
using System.IO;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for POS.xaml
    /// </summary>
    public partial class POS : UserControl
    {
        Error error;
        #region INICIO
        public POS()
        {
            InitializeComponent();
            precio();
            btnEliminar.IsEnabled = false;
            btnCantidad.IsEnabled = false;
            btnEfectivo.IsEnabled = false;
        }
        #endregion

        #region BUSCAR
        private void BuscarProducto(object sender, RoutedEventArgs e)
        {
            if (tbbuscar.Text == string.Empty)
            {
                error = new Error();
                error.lblerror.Text = "Búsqueda vacía";
                error.ShowDialog();
            }
            else
            {
                try
                {
                    CN_Carrito cc = new CN_Carrito();
                    var carrito = cc.Buscar(tbbuscar.Text);

                    if (carrito.Nombre != null)
                    {
                        tbNombre.Text = carrito.Nombre.ToString();
                        tbPrecio.Text = carrito.Precio.ToString();
                        tbCantidad.Focus();
                    }
                    else
                    {
                        error = new Error();
                        error.lblerror.Text = "Producto no encontrado";
                        error.ShowDialog();
                        tbbuscar.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    error = new Error();
                    error.lblerror.Text = ex.Message;
                    error.ShowDialog();
                }

            }
        }
        #endregion

        #region LIMPIAR
        void Limpiar()
        {
            tbbuscar.Text = "";
            tbNombre.Text = "";
            tbCantidad.Text = "";
            tbPrecio.Text = "";
            precio();
        }
        #endregion

        #region AGREGAR
        private void AgregarProducto(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNombre.Text == string.Empty || tbCantidad.Text == string.Empty)
                {
                    MessageBox.Show("Ningún producto ha sido seleccionado.");
                }
                else
                {
                    btnEliminar.IsEnabled = true;
                    btnCantidad.IsEnabled = true;
                    btnEfectivo.IsEnabled = true;
                    string producto = tbNombre.Text;
                    decimal cantidad = decimal.Parse(tbCantidad.Text);
                    Agregar(producto, cantidad);
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }

        decimal can = 0;
        public ref decimal Existe(string valor)
        {
            for (int i = 0; i < gridProductos.Items.Count; i++)
            {
                int j = 1;
                DataGridCell celda = Getcelda(i, j);
                TextBlock tb = celda.Content as TextBlock;

                int k = 3;
                DataGridCell celda2 = Getcelda(i, k);
                TextBlock tb2 = celda2.Content as TextBlock;
                can = decimal.Parse(tb2.Text);

                if(tb.Text == valor)
                {
                    gridProductos.Items.RemoveAt(i);
                    return ref can;
                }
                else
                {
                    can = 0;
                }
            }

            return ref can;
        }
        void Agregar(string producto, decimal cantidad)
        {
            CN_Carrito carrito = new CN_Carrito();
            DataTable dt;
            if (gridProductos.HasItems)
            {
                //cantidad += Existe(producto);
                dt = carrito.Agregar(producto, cantidad);
                gridProductos.Items.Add(dt);
            }
            else
            {
                dt = carrito.Agregar(producto, cantidad);
                gridProductos.Items.Add(dt);
            }
            precio();
        }
        #endregion

        #region PRECIO

        decimal efectivo, cambio, total;
        void precio()
        {
            try
            {
                total = 0;
                for (int i = 0; i < gridProductos.Items.Count; i++)
                {
                    decimal precio;
                    int j = 4;
                    DataGridCell celda = Getcelda(i, j);
                    TextBlock tb = celda.Content as TextBlock;
                    precio = decimal.Parse(tb.Text);
                    total += precio;
                }
                cambio = efectivo - total;

                lblcambio.Content = "Cambio: $" + cambio.ToString();
                lblefectivo.Content = "Efectivo: $" + efectivo.ToString("###,###.00");
                lbltotal.Content = "Total: $" + total.ToString();
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }


        }
        #endregion

        #region ELIMINAR PRODUCTO
        private void EliminarProducto(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = gridProductos.SelectedItem;
                if (seleccionado != null)
                {
                    gridProductos.Items.Remove(seleccionado);
                    if (gridProductos.Items.Count < 1)
                    {
                        efectivo = 0;
                    }
                }
                precio();
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion

        #region CAMBIAR CANTIDAD
        private void CambiarCantidad(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = gridProductos.SelectedItem;
                if (seleccionado != null)
                {
                    var celda = gridProductos.SelectedCells[0];
                    var codigo = (celda.Column.GetCellContent(celda.Item) as TextBlock).Text;

                    var ingresar = new Ingresar();
                    ingresar.ShowDialog();

                    if (ingresar.Total > 0)
                    {
                        gridProductos.Items.Remove(seleccionado);
                        Agregar(codigo, ingresar.Total);
                        precio();
                    }
                }
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion

        #region INGRESAR EFECTIVO
        private void Efectivo(object sender, RoutedEventArgs e)
        {
            try
            {
                var ingresar = new Ingresar();
                ingresar.ShowDialog();

                if (ingresar.Efectivo > 0)
                {
                    efectivo = ingresar.Efectivo;
                    precio();
                }
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion

        #region ANULAR ORDEN
        private void AnularOrden(object sender, RoutedEventArgs e)
        {
            efectivo = 0;
            gridProductos.Items.Clear();
            Limpiar();
        }
        #endregion

        #region PAGAR E IMPRIMIR
        private void Pagar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridProductos.Items.Count >= 1)
                {
                    venta();
                    efectivo = 0;
                    precio();
                }
                else
                {
                    error = new Error();
                    error.lblerror.Text = "No hay productos para procesar.";
                    error.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        CN_Carrito cN_Carrito;
        void venta()
        {
            try
            {
                string factura = "F- " + DateTime.Now.ToString("ddMMyyyyhhmmss") + "-" + Properties.Settings.Default.IdUsuario;
                int idusuario = Properties.Settings.Default.IdUsuario;
                DateTime fecha = DateTime.Now;
                cN_Carrito = new CN_Carrito();

                if (cambio >= 0)
                {
                    cN_Carrito.Venta(factura, total, fecha, idusuario);
                    venta_detalle(factura);
                    gridProductos.Items.Clear();
                }
                else
                {
                    error = new Error();
                    error.lblerror.Text = "Efectivo insuficiente";
                    error.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }

        void venta_detalle(string factura)
        {
            try
            {
                cN_Carrito = new CN_Carrito();
                for (int i = 0; i < gridProductos.Items.Count; i++)
                {
                    string codigo;
                    decimal totalarticulo, cantidad;

                    int j = 0;
                    DataGridCell cell = Getcelda(i, j);
                    TextBlock tb = cell.Content as TextBlock;
                    codigo = tb.Text;

                    int k = 3;
                    DataGridCell cell2 = Getcelda(i, k);
                    TextBlock tb2 = cell2.Content as TextBlock;
                    cantidad = Decimal.Parse(tb2.Text);

                    int l = 4;
                    DataGridCell cell3 = Getcelda(i, l);
                    TextBlock tb3 = cell3.Content as TextBlock;
                    totalarticulo = Decimal.Parse(tb3.Text);

                    cN_Carrito.Venta_Detalle(codigo, factura, cantidad, totalarticulo);
                }
                MessageBox.Show("Venta exitosa!");
                Imprimir(factura);
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }

        void Imprimir (string factura)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog savefile = new System.Windows.Forms.SaveFileDialog()
                {
                    FileName = factura + ".pdf"
                };
                string Pagina = Properties.Resources.Ticket.ToString();
                Pagina = Pagina.Replace("@Ticket", factura);
                Pagina = Pagina.Replace("@efectivo", efectivo.ToString("###,###.00"));
                Pagina = Pagina.Replace("@cambio", cambio.ToString());
                Pagina = Pagina.Replace("@Usuario", Properties.Settings.Default.IdUsuario.ToString());
                Pagina = Pagina.Replace("@Fecha", DateTime.Now.ToString("ddMMyyyymmss"));

                string filas = string.Empty;

                for (int i = 0; i < gridProductos.Items.Count; i++)
                {
                    string nombre, cantidad;
                    decimal preciounitario, totalarticulos;

                    int j = 1;
                    DataGridCell cell1 = Getcelda(i, j);
                    TextBlock tb1 = cell1.Content as TextBlock;
                    nombre = tb1.Text;

                    int k = 3;
                    DataGridCell cell2 = Getcelda(i, k);
                    TextBlock tb2 = cell2.Content as TextBlock;
                    cantidad = tb2.Text;

                    int l = 4;
                    DataGridCell cell3 = Getcelda(i, l);
                    TextBlock tb3 = cell3.Content as TextBlock;
                    totalarticulos = Decimal.Parse(tb3.Text);

                    int m = 2;
                    DataGridCell cell4 = Getcelda(i, m);
                    TextBlock tb4 = cell4.Content as TextBlock;
                    preciounitario = Decimal.Parse(tb4.Text);

                    filas += "<tr>";
                    filas += "<td align=\"center\">" + cantidad.ToString() + "</td>";
                    filas += "<td align=\"center\">" + nombre.ToString() + "</td>";
                    filas += "<td align=\"right\">" + preciounitario.ToString() + "</td>";
                    filas += "<td align=\"right\">" + totalarticulos.ToString() + "</td>";
                    filas += "</tr>";
                }
                int cant = gridProductos.Items.Count;
                Pagina = Pagina.Replace("@cant_articulos", cant.ToString());
                Pagina = Pagina.Replace("@grid", filas);
                Pagina = Pagina.Replace("@TOTAL", total.ToString());

                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                        {
                            int artfilas = gridProductos.Items.Count;
                            Rectangle pagesize = new Rectangle(298, 460 + (artfilas * 12));
                            Document pdfDoc = new Document(pagesize, 25, 25, 25, 25);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            using (StringReader sr = new StringReader(Pagina))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }
                            pdfDoc.Close();
                            stream.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        error = new Error();
                        error.lblerror.Text = ex.Message;
                        error.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion


        #region FILAS, COLUMNAS Y CELDAS
        public static T GetVisualChild<T>(Visual padre) where T : Visual
        {

            T hijo = default;
            int num = VisualTreeHelper.GetChildrenCount(padre);
            for(int i=0; i<num; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(padre, i);
                hijo = v as T;
                if (hijo == null)
                {
                    hijo = GetVisualChild<T>(v);
                }
                if (hijo != null)
                {
                    break;
                }
            }

            return hijo;
        }

        public DataGridRow Getfila (int index)
        {
            DataGridRow fila = (DataGridRow)gridProductos.ItemContainerGenerator.ContainerFromIndex(index);
            if(fila == null)
            {
                gridProductos.UpdateLayout();
                gridProductos.ScrollIntoView(gridProductos.Items[index]);
                fila = (DataGridRow)gridProductos.ItemContainerGenerator.ContainerFromIndex(index);
            }

            return fila;
        }

        public DataGridCell Getcelda(int fila, int columna)
        {
            DataGridRow filaCon = Getfila(fila);
            if (filaCon != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(filaCon);
                DataGridCell celda = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columna);

                if (celda == null)
                {
                    gridProductos.ScrollIntoView(filaCon, gridProductos.Columns[columna]);
                    celda = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columna);
                }
                return celda;
            }

            return null;
        }

        #endregion

    }
}
