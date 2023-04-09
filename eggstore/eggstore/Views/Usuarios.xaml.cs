using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Capa_Negocio;
using eggstore.src.Boxes;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        Error error;
        #region INICIAL
        public Usuarios()
        {
            InitializeComponent();
            Buscar("");
        }
        #endregion

        #region AGREGAR
        private void Agregar(object sender, RoutedEventArgs e)
        {
            try
            {
                CRUDUsuarios ventana = new CRUDUsuarios();
                frameUsuarios.Content = ventana;
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

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)((Button)sender).CommandParameter;
                CRUDUsuarios ventana = new CRUDUsuarios();
                ventana.IdUsuario = id;
                ventana.Consultar();
                frameUsuarios.Content = ventana;
                Contenido.Visibility = Visibility.Hidden;
                ventana.Titulo.Text = "Consulta de Usuaurio";
                ventana.tbNombres.IsEnabled = false;
                ventana.tbApellidos.IsEnabled = false;
                ventana.tbTelefono.IsEnabled = false;
                ventana.tbEmail.IsEnabled = false;
                ventana.tbSector.IsEnabled = false;
                ventana.tbIdentificacion.IsEnabled = false;
                ventana.cbPrivilegio.IsEnabled = false;
                ventana.tbUsuario.IsEnabled = false;
                ventana.tbContrasenia.IsEnabled = false;
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

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)((Button)sender).CommandParameter;
                CRUDUsuarios ventana = new CRUDUsuarios();
                ventana.IdUsuario = id;
                ventana.Consultar();
                frameUsuarios.Content = ventana;
                Contenido.Visibility = Visibility.Hidden;
                ventana.Titulo.Text = "Actualizar Usuaurio";
                ventana.tbNombres.IsEnabled = true;
                ventana.tbApellidos.IsEnabled = true;
                ventana.tbTelefono.IsEnabled = true;
                ventana.tbEmail.IsEnabled = true;
                ventana.tbSector.IsEnabled = true;
                ventana.tbIdentificacion.IsEnabled = true;
                ventana.cbPrivilegio.IsEnabled = true;
                ventana.tbUsuario.IsEnabled = true;
                ventana.tbContrasenia.IsEnabled = true;
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

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)((Button)sender).CommandParameter;
                CRUDUsuarios ventana = new CRUDUsuarios();
                ventana.IdUsuario = id;
                ventana.Consultar();
                frameUsuarios.Content = ventana;
                Contenido.Visibility = Visibility.Hidden;
                ventana.Titulo.Text = "Eliminar Usuaurio";
                ventana.tbNombres.IsEnabled = false;
                ventana.tbApellidos.IsEnabled = false;
                ventana.tbTelefono.IsEnabled = false;
                ventana.tbEmail.IsEnabled = false;
                ventana.tbSector.IsEnabled = false;
                ventana.tbIdentificacion.IsEnabled = false;
                ventana.cbPrivilegio.IsEnabled = false;
                ventana.tbUsuario.IsEnabled = false;
                ventana.tbContrasenia.IsEnabled = false;
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

        #region BUSCANDO

        public void Buscar(string buscar)
        {
            gridDatos.ItemsSource = objeto_CN_Usuarios.Buscar(buscar).DefaultView;
        }
        private void Buscando(object sender, TextChangedEventArgs e)
        {
            Buscar(tbBuscar.Text);
        }
        #endregion
    }
}
