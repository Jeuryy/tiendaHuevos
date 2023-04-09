using Capa_Negocio;
using eggstore.src.Boxes;
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
using System.Windows.Shapes;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            tbusuario.Focus();
        }
        Error error;
        private void Acceder(object sender, RoutedEventArgs e)
        {
            if (tbusuario.Text != "" && tbcontra.Text != "")
            {
                try
                {
                    LogIn(tbusuario.Text, tbcontra.Text);
                }
                catch(Exception ex)
                {
                    error = new Error();
                    error.lblerror.Text = ex.Message;
                    error.ShowDialog();
                }

            }
            else
            {
                error = new Error();
                error.lblerror.Text = "No puede dejar los campos vacíos.";
                error.ShowDialog();
            }
        }

        void LogIn (string usuario, string contra)
        {
            try
            {
                CN_Usuarios cn = new CN_Usuarios();
                var a = cn.Login(usuario, contra);

                if (a.IdUsuario > 0)
                {
                    Properties.Settings.Default.IdUsuario = a.IdUsuario;
                    Properties.Settings.Default.Privilegio = a.Privilegio;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    error = new Error();
                    error.lblerror.Text = "Usuario y/o contraseña incorrecta(s)";
                    error.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
