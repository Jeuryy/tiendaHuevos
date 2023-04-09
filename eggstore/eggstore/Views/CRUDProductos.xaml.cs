using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Entidad;
using Capa_Negocio;
using eggstore.src.Boxes;
using Microsoft.Win32;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for CRUDProductos.xaml
    /// </summary>
    public partial class CRUDProductos : Page
    {
        public int IdProducto;
        public string Patron = "eggstore";
        CN_Grupos objeto_CN_Grupos = new CN_Grupos();
        CN_Productos objeto_CN_Productos = new CN_Productos();
        CE_Productos objeto_CE_Productos = new CE_Productos();
        Error error;

        #region INICIAL
        public CRUDProductos()
        {
            InitializeComponent();
            Cargar();
        }
        #endregion

        #region REGRESAR
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Productos();
        }
        #endregion

        #region LLENAR GRUPOS
        void Cargar()
        {
            try
            {
                List<string> grupos = objeto_CN_Grupos.ListarGrupos();
                for (int i = 0; i < grupos.Count; i++)
                {
                    cbGrupo.Items.Add(grupos[i]);
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

        #region VALIDAR GRUPOS
        public bool CamposLlenos()
        {
            if(tbNombre.Text=="" || tbCodigo.Text=="" || cbGrupo.Text=="" || tbPrecio.Text=="" || tbCantidad.Text=="" || tbDescripcion.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region C R U D

        #region CREATE
        private void Crear(object sender, RoutedEventArgs e)
        {
               if (CamposLlenos() == true)
                {
                try
                {
                    int idgrupo = objeto_CN_Grupos.IdGrupo(cbGrupo.Text);

                objeto_CE_Productos.Nombre = tbNombre.Text;
                objeto_CE_Productos.Codigo = tbCodigo.Text;
                objeto_CE_Productos.Precio = Decimal.Parse(tbPrecio.Text);
                objeto_CE_Productos.Cantidad = Decimal.Parse(tbCantidad.Text);
                objeto_CE_Productos.Activo = (bool)tbActivo.IsChecked;
                objeto_CE_Productos.Img = data;
                objeto_CE_Productos.Descripcion = tbDescripcion.Text;
                objeto_CE_Productos.Grupo = idgrupo;


                objeto_CN_Productos.Insertar(objeto_CE_Productos);

                Content = new Productos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //MessageBox.Show("Asegúrese de agregar el tipo de dato correctamente (No texto en campo numérico...)");
                }
            }
            else
            {
                MessageBox.Show("Los campos no pueden quedar vacíos.");
            }
        }

        #endregion

        #region READ
        public void Consultar()
        {
            try
            {
                var a = objeto_CN_Productos.Consulta(IdProducto);
                tbNombre.Text = a.Nombre.ToString();
                tbCodigo.Text = a.Codigo.ToString();
                tbPrecio.Text = a.Precio.ToString();
                tbActivo.IsChecked = a.Activo;
                tbCantidad.Text = a.Cantidad.ToString();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);

                tbDescripcion.Text = a.Descripcion.ToString();

                var b = objeto_CN_Grupos.Nombre(a.Grupo);
                cbGrupo.Text = b.Nombre;
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion

        #region DELETE
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            try
            {
                objeto_CE_Productos.IdArticulo = IdProducto;
                objeto_CN_Productos.Eliminar(objeto_CE_Productos);
                Content = new Productos();
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }

        #endregion

        #region UPDATE
        private void Modificar(object sender, RoutedEventArgs e)
        {

            if (CamposLlenos() == true)
            {
                try
                {
                    int idgrupo = objeto_CN_Grupos.IdGrupo(cbGrupo.Text);

                objeto_CE_Productos.IdArticulo = IdProducto;
                objeto_CE_Productos.Nombre = tbNombre.Text;
                objeto_CE_Productos.Codigo = tbCodigo.Text;
                objeto_CE_Productos.Precio = Decimal.Parse(tbPrecio.Text);
                objeto_CE_Productos.Cantidad = Decimal.Parse(tbCantidad.Text);
                objeto_CE_Productos.Activo = (bool)tbActivo.IsChecked;
                objeto_CE_Productos.Descripcion = tbDescripcion.Text;
                objeto_CE_Productos.Grupo = idgrupo;


                objeto_CN_Productos.ActualizarDatos(objeto_CE_Productos);

                Content = new Productos();
                }
                catch (Exception ex)
                {
                    error = new Error();
                    error.lblerror.Text = ex.Message;
                    error.ShowDialog();
                }
            }
            else
            {
                error = new Error();
                error.lblerror.Text = "Por favor complete todos los campos(incluyendo imagen)";
                error.ShowDialog();
            }

            if(imagensubida == true)
            {
                try
                {
                    objeto_CE_Productos.IdArticulo = IdProducto;
                    objeto_CE_Productos.Img = data;

                    objeto_CN_Productos.ActualizarIMG(objeto_CE_Productos);
                    Content = new Productos();
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

        #endregion

        #region SUBIR IMAGEN
        byte[] data;
        private bool imagensubida = false;
        private void Subir(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    data = new byte[fs.Length];
                    fs.Read(data, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    ImageSourceConverter imgs = new ImageSourceConverter();
                    imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
                }
                imagensubida = true;
            }
            catch(Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion
    }
}
