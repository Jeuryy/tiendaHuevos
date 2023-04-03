using System;
using System.Collections.Generic;
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
using Capa_Negocio;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for CRUDProductos.xaml
    /// </summary>
    public partial class CRUDProductos : Page
    {
        public int IdProducto;
        CN_Grupos objeto_CN_Grupos = new CN_Grupos();
        CN_Productos objeto_CN_Productos = new CN_Productos();
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
            List<string> grupos = objeto_CN_Grupos.ListarGrupos();
            for(int i = 0;i < grupos.Count; i++)
            {
                cbGrupo.Items.Add(grupos[i]);
            }
        }

        #endregion

        #region C R U D

        #region CREATE
        private void Crear(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region READ
        public void Consultar()
        {
            var a = objeto_CN_Productos.Consulta(IdProducto);
            tbNombre.Text = a.Nombre.ToString();
            tbCodigo.Text = a.Codigo.ToString();
            tbPrecio.Text = a.Precio.ToString();
            tbActivo.IsChecked = a.Activo;
            tbCantidad.Text = a.Cantidad.ToString();
            tbUnidadMedida.Text = a.UnidadMedida.ToString();
            ImageSourceConverter imgs = new ImageSourceConverter();
            imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);
            tbDescripcion.Text = a.Descripcion.ToString();

            var b = objeto_CN_Grupos.Nombre(a.Grupo);
            cbGrupo.Text = b.Nombre;
        }
        #endregion

        #region DELETE
        private void Eliminar(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region UPDATE
        private void Modificar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #endregion

        #region SUBIR IMAGEN
        private void Subir(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
