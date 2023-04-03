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

namespace eggstore.Views
{

    public partial class Productos : UserControl
    {
        public Productos()
        {
            InitializeComponent();
        }

        #region BUSCANDO
        private void Buscando(object sender, TextChangedEventArgs e)
        {

        }

        #endregion

        #region C R U D

        #region CREATE
        private void Agregar_Producto(object sender, RoutedEventArgs e)
        {
            CRUDProductos ventana = new CRUDProductos();
            frameProductos.Content = ventana;
            Contenido.Visibility = Visibility.Hidden;
            ventana.btnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region READ
        private void Consultar(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region UPDATE
        private void Actualizar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region DELETE
        private void Eliminar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #endregion



    }
}
