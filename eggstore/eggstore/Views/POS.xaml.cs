using Capa_Negocio;
using eggstore.src.Boxes;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for POS.xaml
    /// </summary>
    public partial class POS : UserControl
    {
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
                MessageBox.Show("Búsqueda vacía");
            }
            else
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
                    MessageBox.Show("No se encontró el producto.");
                    tbbuscar.Text = "";
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
            if(tbNombre.Text == string.Empty || tbCantidad.Text == string.Empty)
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

        //decimal can;
        /*public ref decimal Existe(string valor)
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
            }

            return ref can;
        }*/
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
            total = 0;
            for(int i=0; i<gridProductos.Items.Count; i++)
            {
                decimal precio;
                int j = 4;
                DataGridCell celda = Getcelda(i, j);
                TextBlock tb = celda.Content as TextBlock;
                precio = decimal.Parse(tb.Text);
                total += precio;
            }
            cambio = efectivo - total;

            lblcambio.Content = "Cambio: $"+ cambio.ToString();
            lblefectivo.Content = "Efectivo: $" + efectivo.ToString("###,###.00");
            lbltotal.Content = "Total: $" + total.ToString();

        }
        #endregion

        #region ELIMINAR PRODUCTO
        private void EliminarProducto(object sender, RoutedEventArgs e)
        {
            var seleccionado = gridProductos.SelectedItem;
            if(seleccionado != null)
            {
                gridProductos.Items.Remove(seleccionado);
                if (gridProductos.Items.Count < 1)
                {
                    efectivo = 0;
                }
            }
            precio();
        }
        #endregion

        #region CAMBIAR CANTIDAD
        private void CambiarCantidad(object sender, RoutedEventArgs e)
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
        #endregion

        #region INGRESAR EFECTIVO
        private void Efectivo(object sender, RoutedEventArgs e)
        {
            var ingresar = new Ingresar();
            ingresar.ShowDialog();

            if (ingresar.Efectivo > 0)
            {
                efectivo = ingresar.Efectivo;
                precio();
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

        private void Pagar(object sender, RoutedEventArgs e)
        {
            //restante
        }


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
