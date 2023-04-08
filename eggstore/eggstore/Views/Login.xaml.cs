using Capa_Negocio;
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

        private void Acceder(object sender, RoutedEventArgs e)
        {
            if (tbusuario.Text != "" && tbcontra.Text != "")
            {
                LogIn(tbusuario.Text, tbcontra.Text);
            }
            else
            {
                MessageBox.Show("No puede dejar los campos vacíos.");
            }
        }

        void LogIn (string usuario, string contra)
        {
            CN_Usuarios cn = new CN_Usuarios();
            var a = cn.Login(usuario, contra);
        
        if(a.IdUsuario > 0)
            {
                Properties.Settings.Default.IdUsuario = a.IdUsuario;
                Properties.Settings.Default.Privilegio = a.Privilegio;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta(s).");
            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
