using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Capa_de_datos
{
    public class CD_Usuarios
    {
        private  readonly CD_Conexion con = new CD_Conexion();
        private readonly CE_Usuarios ce = new CE_Usuarios();

        //CRUD USUARIOS

        #region INSERTAR
        public void CD_Insertar(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_U_Insertar",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                com.Parameters.AddWithValue("@Nombres", Usuarios.Nombres);
                com.Parameters.AddWithValue("@Apellidos", Usuarios.Apellidos);
                com.Parameters.AddWithValue("@Telefono", Usuarios.Telefono);
                com.Parameters.AddWithValue("@Identificacion", Usuarios.Identificacion);
                com.Parameters.AddWithValue("@Correo", Usuarios.Correo);
                com.Parameters.AddWithValue("@Sector", Usuarios.Sector);
                com.Parameters.AddWithValue("@Privilegio", Usuarios.Privilegio);
                com.Parameters.AddWithValue("@img", Usuarios.Img);
                com.Parameters.AddWithValue("@Usuario", Usuarios.Usuario);
                com.Parameters.AddWithValue("@Contrasenia", Usuarios.Contrasenia);
                com.Parameters.AddWithValue("@Patron", Usuarios.Patron);
                com.ExecuteNonQuery();
                com.Parameters.Clear();
                con.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Complete cada uno de los campos (incluyendo imagen)");
            }
        }
        #endregion

        #region CONSULTAR
        public CE_Usuarios CD_Consulta (int IdUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_U_Consultar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Nombres = Convert.ToString(row[1]);
            ce.Apellidos = Convert.ToString(row[2]);
            ce.Telefono = (float)Convert.ToDouble(row[3]);
            ce.Identificacion = (float)Convert.ToDouble(row[4]);
            ce.Correo = Convert.ToString(row[5]);
            ce.Sector = Convert.ToString(row[6]);
            ce.Privilegio = Convert.ToInt32(row[7]);
            ce.Img = (byte[])row[8];
            ce.Usuario = Convert.ToString(row[9]);

            return ce;
        }
        #endregion

        #region ELIMINAR
        public void CD_Eliminar(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_U_Eliminar",
                CommandType = CommandType.StoredProcedure,
            };
            com.Parameters.AddWithValue("@IdUsuarios", Usuarios.IdUsuario);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region ACTUALIZAR DATOS
        public void CD_ActualizarDatos(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_U_ActualizarDatos",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdUsuario", Usuarios.IdUsuario);
            com.Parameters.AddWithValue("@Nombres", Usuarios.Nombres);
            com.Parameters.AddWithValue("@Apellidos", Usuarios.Apellidos);
            com.Parameters.AddWithValue("@Telefono", Usuarios.Telefono);
            com.Parameters.AddWithValue("@Identificacion", Usuarios.Identificacion);
            com.Parameters.AddWithValue("@Correo", Usuarios.Correo);
            com.Parameters.AddWithValue("@Sector", Usuarios.Sector);
            com.Parameters.AddWithValue("@Privilegio", Usuarios.Privilegio);
            com.Parameters.AddWithValue("@usuario", Usuarios.Usuario);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region ACTUALIZAR PASS
        public void CD_ActualizarPass(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_U_ActualizarPass",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdUsuario", Usuarios.IdUsuario);            
            com.Parameters.AddWithValue("@Contrasenia", Usuarios.Contrasenia);
            com.Parameters.AddWithValue("@patron", Usuarios.Patron);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region ACTUALIZAR IMG
        public void CD_ActualizarIMG(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_U_ActualizarIMG",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdUsuario", Usuarios.IdUsuario);
            com.Parameters.AddWithValue("@img", Usuarios.Img);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion


        //Vista Usuarios

        #region BUSCAR USUARIOS
        public DataTable Buscar(string buscar)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_U_Buscar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = buscar;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.CerrarConexion();
            return dt;
        }
        #endregion  
    }
}
