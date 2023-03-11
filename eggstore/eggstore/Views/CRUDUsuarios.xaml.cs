using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for CRUDUsuarios.xaml
    /// </summary>
    public partial class CRUDUsuarios : Page
    {
        public CRUDUsuarios()
        {
            InitializeComponent();
            CargarCB();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        void CargarCB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select NombrePrivilegio from Privilegios", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbPrivilegio.Items.Add(dr["NombrePrivilegio"].ToString());
            }
            con.Close();
        }

        private void Crear(object sender, RoutedEventArgs e)
        {
            if (tbNombres.Text==""||tbApellidos.Text== ""||tbTelefono.Text==""||tbIdentificacion.Text==""||tbEmail.Text==""||tbSector.Text==""||tbUsuario.Text==""||tbContrasenia.Text==""||cbPrivilegio.Text=="")
            {
                MessageBox.Show("Los campos no pueden quedar vacíos");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select IdPrivilegio from privilegios where NombrePrivilegio='" + cbPrivilegio.Text+"'",con);
                object valor = cmd.ExecuteScalar();
                int privilegio = (int)valor;
                string patron = "eggstore";
                if(imagensubida == true)
                {
                    SqlCommand com = new SqlCommand("INSERT INTO usuarios (nombres, apellidos, telefono, identificacion, correo, sector, privilegio, img, usuario, contrasenia) values(@nombres, @apellidos, @telefono, @identificacion, @correo, @sector, @privilegio, @img, @usuario, (EncryptByPassPhrase('" + patron + "', '" + tbContrasenia.Text + "')))", con);
                    com.Parameters.Add("@nombres", SqlDbType.VarChar).Value = tbNombres.Text;
                    com.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = tbApellidos.Text;
                    com.Parameters.Add("@telefono", SqlDbType.Float).Value = tbTelefono.Text;
                    com.Parameters.Add("@identificacion", SqlDbType.Float).Value = tbIdentificacion.Text;
                    com.Parameters.Add("@correo", SqlDbType.VarChar).Value = tbEmail.Text;
                    com.Parameters.Add("@sector", SqlDbType.VarChar).Value = tbSector.Text;
                    com.Parameters.Add("@privilegio", SqlDbType.Int).Value = privilegio;
                    com.Parameters.Add("@usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                    com.Parameters.Add("@img", SqlDbType.VarBinary).Value = data;
                    com.ExecuteNonQuery();
                    Content = new Usuarios();
                }
                else
                {
                    MessageBox.Show("Inserte una foto de perfil para el usuario");
                }
                con.Close();
            }

        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {

        }

        private void Modificar(object sender, RoutedEventArgs e)
        {

        }
        byte[] data;
        private bool imagensubida = false;
        private void Subir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }
            imagensubida = true;
        }
    }
}
