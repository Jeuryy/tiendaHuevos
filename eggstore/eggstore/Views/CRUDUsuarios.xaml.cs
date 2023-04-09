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
using Capa_Entidad;
using Capa_Negocio;
using System.Drawing;
using Image = System.Windows.Controls.Image;
using eggstore.src.Boxes;

namespace eggstore.Views
{
    /// <summary>
    /// Interaction logic for CRUDUsuarios.xaml
    /// </summary>
    public partial class CRUDUsuarios : Page
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        readonly CE_Usuarios objeto_CE_Usuarios = new CE_Usuarios();
        readonly CN_Privilegios objeto_CN_Privilegios = new CN_Privilegios();
        Error error;

        #region INICIAL
        public CRUDUsuarios()
        {
            InitializeComponent();
            CargarCB();
        }
        #endregion
        #region REGRESAR
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        #endregion
        #region CARGARPRIVILEGIOS
        void CargarCB()
        {
            try
            {
                List<string> privilegios = objeto_CN_Privilegios.ListarPrivilegios();
                for (int i = 0; i < privilegios.Count; i++)
                {
                    cbPrivilegio.Items.Add(privilegios[i]);
                }
            }
            catch(Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion
        #region VALIDARCAMPOSVACIOS
        public bool CamposLlenos()
        {
            if (tbNombres.Text == "" || tbApellidos.Text == "" || tbTelefono.Text == "" || tbIdentificacion.Text == "" || tbEmail.Text == "" || tbSector.Text == "" || tbUsuario.Text == "" || tbContrasenia.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region CRUD

        public int IdUsuario;
        public string Patron = "eggstore";

        #region CREATE
        private void Crear(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CamposLlenos()==true && tbContrasenia.Text != "")
                {

                    int privilegio = objeto_CN_Privilegios.IdPrivilegio(cbPrivilegio.Text);

                    objeto_CE_Usuarios.Nombres = tbNombres.Text;
                    objeto_CE_Usuarios.Apellidos = tbApellidos.Text;
                    objeto_CE_Usuarios.Telefono = tbTelefono.Text;
                    objeto_CE_Usuarios.Identificacion = tbIdentificacion.Text;
                    objeto_CE_Usuarios.Correo = tbEmail.Text;
                    objeto_CE_Usuarios.Sector = tbSector.Text;
                    objeto_CE_Usuarios.Privilegio = privilegio;
                    objeto_CE_Usuarios.Img = data;
                    objeto_CE_Usuarios.Usuario = tbUsuario.Text;
                    objeto_CE_Usuarios.Contrasenia = tbContrasenia.Text;
                    objeto_CE_Usuarios.Patron = Patron;

                    objeto_CN_Usuarios.Insertar(objeto_CE_Usuarios);

                    Content = new Usuarios();
                }
                else
                {
                    error = new Error();
                    error.lblerror.Text = "Asegúrese de agregar el tipo de dato correctamente (No texto en campo numérico...) y completar todos los campos";
                    error.ShowDialog();
                    //
                }
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
        public void Consultar()
        {
            try
            {
                var a = objeto_CN_Usuarios.Consultar(IdUsuario);
                tbNombres.Text = a.Nombres.ToString();
                tbApellidos.Text = a.Apellidos.ToString();
                tbTelefono.Text = a.Telefono.ToString();
                tbIdentificacion.Text = a.Identificacion.ToString();
                tbEmail.Text = a.Correo.ToString();
                tbSector.Text = a.Sector.ToString();


                var b = objeto_CN_Privilegios.NombrePrivilegio(a.Privilegio);
                cbPrivilegio.Text = b.NombrePrivilegio.ToString();

                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);
                tbUsuario.Text = a.Usuario.ToString();
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
        private void Modificar(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                try
                {
                    int privilegio = objeto_CN_Privilegios.IdPrivilegio(cbPrivilegio.Text);
                
                objeto_CE_Usuarios.IdUsuario = IdUsuario;
                objeto_CE_Usuarios.Nombres = tbNombres.Text;
                objeto_CE_Usuarios.Apellidos = tbApellidos.Text;
                objeto_CE_Usuarios.Telefono = tbTelefono.Text;
                objeto_CE_Usuarios.Identificacion = tbIdentificacion.Text;
                objeto_CE_Usuarios.Correo = tbEmail.Text;
                objeto_CE_Usuarios.Sector = tbSector.Text;
                objeto_CE_Usuarios.Privilegio = privilegio;
                objeto_CE_Usuarios.Usuario = tbUsuario.Text;

                objeto_CN_Usuarios.ActualizarDatos(objeto_CE_Usuarios);

                Content = new Usuarios();
                }
                catch (Exception ex)
                {
                    error = new Error();
                    error.lblerror.Text = ex.Message;
                    error.ShowDialog();
                }
            }
            else
            {
                error = new Error();
                error.lblerror.Text = "Asegúrese de agregar el tipo de dato correctamente (No texto en campo numérico...)";
                error.ShowDialog();
                error.lblerror.Text = "Los campos no pueden quedar vacíos";
                error.ShowDialog();
            }

            if(tbContrasenia.Text != "")
            {
                try
                {
                    objeto_CE_Usuarios.IdUsuario = IdUsuario;
                    objeto_CE_Usuarios.Contrasenia = tbContrasenia.Text;
                    objeto_CE_Usuarios.Patron = Patron;

                    objeto_CN_Usuarios.ActualizarPass(objeto_CE_Usuarios);
                    Content = new Usuarios();
                }
                catch (Exception ex)
                {
                    error = new Error();
                    error.lblerror.Text = ex.Message;
                    error.ShowDialog();
                }

            }

            if(imagensubida == true)
            {
                try
                {
                    objeto_CE_Usuarios.IdUsuario = IdUsuario;
                    objeto_CE_Usuarios.Img = data;

                    objeto_CN_Usuarios.ActualizarIMG(objeto_CE_Usuarios);
                    Content = new Usuarios();
                }

                catch (Exception ex)
                {
                    error = new Error();
                    error.lblerror.Text = ex.Message;
                    error.ShowDialog();
                }
            }
        }
        #endregion
        #region DELETE
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            try
            {
                objeto_CE_Usuarios.IdUsuario = IdUsuario;

                objeto_CN_Usuarios.Eliminar(objeto_CE_Usuarios);

                Content = new Usuarios();
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

        #region IMAGEN

        
        byte[] data;
        private bool imagensubida = false;
        private void Subir(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
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
            catch (Exception ex)
            {
                error = new Error();
                error.lblerror.Text = ex.Message;
                error.ShowDialog();
            }

        }
        #endregion
    }
}
