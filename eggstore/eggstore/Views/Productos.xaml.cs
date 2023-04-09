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
using eggstore.src.Boxes;

namespace eggstore.Views
{

    public partial class Productos : UserControl
    {
        #region INICIAL
        public Productos()
        {
            InitializeComponent();
            Buscar("");
        }
        #endregion

        readonly CN_Productos obj_CN_Productos = new CN_Productos();
        Error error;

        #region BUSCAR
        public void Buscar(string buscar)
        {
            try
            {
                gridDatos.ItemsSource = obj_CN_Productos.BuscarProducto(buscar).DefaultView;
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }
        }
        #endregion

        #region BUSCANDO
        private void Buscando(object sender, TextChangedEventArgs e)
        {
            Buscar(tbBuscar.Text);
        }

        #endregion

        #region C R U D

        #region CREATE
        private void Agregar_Producto(object sender, RoutedEventArgs e)
        {
            try
            {
                CRUDProductos ventana = new CRUDProductos();
                frameProductos.Content = ventana;
                Contenido.Visibility = Visibility.Hidden;
                ventana.btnCrear.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }
        }
        #endregion

        #region READ
        private void Consultar(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)((Button)sender).CommandParameter;
                CRUDProductos ventana = new CRUDProductos();
                frameProductos.Content = ventana;
                Contenido.Visibility = Visibility.Hidden;
                ventana.IdProducto = id;
                ventana.Consultar();
                ventana.Titulo.Text = "Consulta de Producto";
                ventana.tbNombre.IsEnabled = false;
                ventana.tbCodigo.IsEnabled = false;
                ventana.tbCantidad.IsEnabled = false;
                ventana.tbActivo.IsEnabled = false;
                ventana.tbPrecio.IsEnabled = false;
                ventana.cbGrupo.IsEnabled = false;
                ventana.tbDescripcion.IsEnabled = false;
                ventana.btnSubir.IsEnabled = false;
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
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)((Button)sender).CommandParameter;
                CRUDProductos ventana = new CRUDProductos();
                frameProductos.Content = ventana;
                Contenido.Visibility = Visibility.Hidden;
                ventana.IdProducto = id;
                ventana.Consultar();
                ventana.Titulo.Text = "Actualizar Producto";
                ventana.tbNombre.IsEnabled = true;
                ventana.tbCodigo.IsEnabled = true;
                ventana.tbCantidad.IsEnabled = true;
                ventana.tbActivo.IsEnabled = true;
                ventana.tbPrecio.IsEnabled = true;
                ventana.cbGrupo.IsEnabled = true;
                ventana.tbDescripcion.IsEnabled = true;
                ventana.btnSubir.IsEnabled = true;
                ventana.btnModificar.Visibility = Visibility.Visible;
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
                int id = (int)((Button)sender).CommandParameter;
                CRUDProductos ventana = new CRUDProductos();
                frameProductos.Content = ventana;
                Contenido.Visibility = Visibility.Visible;
                ventana.IdProducto = id;
                ventana.Consultar();
                ventana.Titulo.Text = "Eliminar Producto";
                ventana.tbNombre.IsEnabled = false;
                ventana.tbCodigo.IsEnabled = false;
                ventana.tbCantidad.IsEnabled = false;
                ventana.tbActivo.IsEnabled = false;
                ventana.tbPrecio.IsEnabled = false;
                ventana.cbGrupo.IsEnabled = false;
                ventana.tbDescripcion.IsEnabled = false;
                ventana.btnSubir.IsEnabled = false;
                ventana.btnEliminar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }
        }
        #endregion

        #endregion



    }
}
