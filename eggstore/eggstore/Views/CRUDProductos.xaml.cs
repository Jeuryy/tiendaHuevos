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
    /// <summary>
    /// Interaction logic for CRUDProductos.xaml
    /// </summary>
    public partial class CRUDProductos : Page
    {
        public CRUDProductos()
        {
            InitializeComponent();
        }
        #region REGRESAR
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Productos();
        }
        #endregion

        #region C R U D

        #region CREATE
        private void Crear(object sender, RoutedEventArgs e)
        {

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
