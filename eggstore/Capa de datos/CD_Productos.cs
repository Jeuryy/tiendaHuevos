using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class CD_Productos
    {
        CD_Conexion con = new CD_Conexion();
        CE_Productos productos = new CE_Productos();

        //Vista productos

        #region BUSCAR
        public DataTable Buscar(string buscar)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_A_Buscar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = buscar;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            con.CerrarConexion();

            return dt;
        }
        #endregion

        //Vista CRUD PRODUCTOS

        #region C R U D
        #region CONSULTAR
        public CE_Productos Consultar(int IdProducto)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_A_Consultar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdArticulo", SqlDbType.Int).Value = IdProducto;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            productos.Nombre = Convert.ToString(row[1]);
            productos.Grupo = Convert.ToInt32(row[2]);
            productos.Codigo = Convert.ToString(row[3]);
            productos.Precio = Convert.ToDouble(row[4]);
            productos.Activo = Convert.ToBoolean(row[5]);
            productos.Cantidad = Convert.ToDouble(row[6]);
            productos.UnidadMedida = Convert.ToString(row[7]);
            productos.Img = (byte[])row[8];
            productos.Descripcion = Convert.ToString(row[9]);

            return productos;
        }
        #endregion


        #endregion
    }
}
