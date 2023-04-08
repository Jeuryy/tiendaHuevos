using eggstore.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace eggstore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          if (Properties.Settings.Default.Privilegio != 1)
            {
                /*lvproductos.Visibility = Visibility.Hidden;
                lvusuarios.Visibility = Visibility.Hidden;*/
            }
        }

        private void TBShow(object sender, RoutedEventArgs e)
        {
            gridContent.Opacity = 0.8;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            gridContent.Opacity = 1;
        }

        private void PreviewMouseLeftButtonDownBG(object sender, MouseButtonEventArgs e)
        {
            btnShowHide.IsChecked = false;
        }

        private void Minimizar(object sender, RoutedEventArgs e)
        {
            this.WindowState= WindowState.Minimized;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
           /* Login lg = new Login();
            lg.Show();*/
            this.Close();
        }

        private void Usuarios_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Usuarios();
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Productos();
        }

        private void Dashboard(object sender, RoutedEventArgs e)
        {
            DataContext = new Dashboard();
        }

        private void POS(object sender, RoutedEventArgs e)
        {
            DataContext = new POS();
        }

        private void MiCuenta(object sender, RoutedEventArgs e)
        {
            MiCuenta mc = new MiCuenta();
            mc.ShowDialog();
        }
        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            AcercaDe aC = new AcercaDe();
            aC.ShowDialog();
        }

        #region MOVER VENTANA
        private void Mover(Border header)
        {
            var restaurar = false;
            header.MouseLeftButtonDown += (s, e) =>
            {
                if (e.ClickCount == 2)
                {
                    if ((ResizeMode == ResizeMode.CanResize) || (ResizeMode == ResizeMode.CanResizeWithGrip))
                    {
                        CambiarEstado();
                    }
                }
                else
                {
                    if(WindowState == WindowState.Maximized)
                    {
                        restaurar = true;
                    }
                    DragMove();
                }
            };

            header.MouseLeftButtonUp += (s, e) =>
            {
                restaurar = false;
            };

            header.MouseMove += (s, e) =>
            {
                if (restaurar)
                {
                    try
                    {
                        restaurar = false;
                        var mouseX = e.GetPosition(this).X;
                        var width = RestoreBounds.Width;
                        var x = mouseX - width / 2;

                        if (x < 2)
                        {
                            x = 0;
                        }
                        else if (x + width > SystemParameters.PrimaryScreenWidth)
                        {
                            x = SystemParameters.PrimaryScreenWidth;
                        }

                        WindowState = WindowState.Normal;
                        Left = x;
                        Top = 0;
                        DragMove();
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            };
        }
        private void CambiarEstado()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        WindowState = WindowState.Normal;
                        break;
                    }
            }
        }
        private void RestaurarVentana(object sender, RoutedEventArgs e)
        {
            Mover(sender as Border);
        }
        #endregion

    }
}
