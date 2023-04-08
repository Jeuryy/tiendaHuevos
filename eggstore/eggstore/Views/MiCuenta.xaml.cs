using Capa_Negocio;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace eggstore.Views
{

    public partial class MiCuenta : Window
    {
        public MiCuenta()
        {
            InitializeComponent();
            Cargardatos();
        }
        void Cargardatos()
        {
            CN_Usuarios cn = new CN_Usuarios();
            var a = cn.Cargar(Properties.Settings.Default.IdUsuario);
            try
            {
                lblnombre.Text = "Nombres: " + a.Nombres;
                lblApellidos.Text = "Apellidos: " + a.Apellidos;
                lblCorreo.Text = "Correo: " + a.Correo;
                lblPrivilegio.Text = "Privilegio: Nivel " + a.Privilegio;

                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
