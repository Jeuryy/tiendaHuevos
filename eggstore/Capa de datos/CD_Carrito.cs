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
    public class CD_Carrito
    {
        CD_Conexion con = new CD_Conexion();
        CE_Carrito carrito = new CE_Carrito();

        #region BUSCAR
        public CE_Carrito Buscar(string buscar)
        {
            SqlDataAdapter da = new("SP_C_Buscar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = buscar;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                carrito.Nombre = Convert.ToString(row[1]);
                carrito.Precio = Convert.ToDecimal(row[4]);
                con.CerrarConexion();
                return carrito;
            }
            else
            {
                return carrito;
            }
        }
        #endregion

        #region AGREGAR
        public DataTable Agregar(string producto, decimal cantidad)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_C_Buscar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = producto;
            DataSet ds = new();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            var precio = dt.Rows[0][4];
            decimal Cantidad = cantidad;
            decimal ProductoTotal = Cantidad * Convert.ToDecimal(precio);

            dt.Columns.Add("ProductoTotal", typeof(decimal));

            foreach (DataRow row in dt.Rows)
            {
                row["Cantidad"] = cantidad;
                row["ProductoTotal"] = ProductoTotal;
            }

            con.CerrarConexion();
            return dt;
        }
        #endregion
    }

}
