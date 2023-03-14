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
        #region CRUD
        public int IdUsuario;
        #region CREATE

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
        #endregion
        #region READ
        public void Consultar()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from Usuarios inner join Privilegios on Usuarios.Privilegio=Privilegios.IdPrivilegio where IdUsuario="+IdUsuario, con);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            this.tbNombres.Text = rdr["Nombres"].ToString();
            this.tbApellidos.Text = rdr["Apellidos"].ToString();
            this.tbTelefono.Text = rdr["Telefono"].ToString();
            this.tbEmail.Text = rdr["Correo"].ToString();
            this.tbSector.Text = rdr["Sector"].ToString();
            this.tbIdentificacion.Text = rdr["Identificacion"].ToString();
            this.cbPrivilegio.SelectedItem = rdr["NombrePrivilegio"];
            this.tbUsuario.Text = rdr["usuario"].ToString();
            this.tbContrasenia.Text = "Eso no se puede decir ahora";
            rdr.Close();

            //IMAGEN
            DataSet ds = new DataSet();
            SqlDataAdapter sqda = new SqlDataAdapter("Select img from usuarios where IdUsuario='"+IdUsuario+"'",con);
            sqda.Fill(ds);
            byte[] data = (byte[])ds.Tables[0].Rows[0][0];
            MemoryStream strm = new MemoryStream();
            strm.Write(data,0,data.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            imagen.Source = bi;
            //IMAGEN
            con.Close();
        }
        #endregion
        #region UPDATE
        private void Modificar(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select IdPrivilegio from Privilegios where NombrePrivilegio='"+cbPrivilegio.Text+"'", con);
            object valor = com.ExecuteScalar();
            int privilegio = (int)valor;
            string patron = "eggstore";
            SqlCommand cmd = new SqlCommand("Update usuarios set Nombres='"+tbNombres.Text+"',Apellidos='"+tbApellidos.Text+"',Telefono='"+float.Parse(tbTelefono.Text)+"',Correo='"+tbEmail.Text+"',Identificacion='"+float.Parse(tbIdentificacion.Text)+"',Sector='"+tbSector.Text+"'Privilegio='"+privilegio+"', Usuario='"+tbUsuario.Text+"',Contrasenia=(EncryptByPassPhrase('"+patron+"','"+tbContrasenia.Text+"'))",con);
            if (imagensubida == true)
            {
                SqlCommand img = new SqlCommand("Update Usuarios set img=@img where IdUsuario='"+IdUsuario+"'",con);
                img.Parameters.AddWithValue("@img", SqlDbType.VarBinary).Value = data;
                img.ExecuteNonQuery();
            }
            cmd.ExecuteNonQuery();
            con.Close();
            Content = new Usuarios();
        }
        #endregion
        private void Eliminar(object sender, RoutedEventArgs e)
        {

        }
        #endregion
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
