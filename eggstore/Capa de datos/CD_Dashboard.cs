using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Schema;

namespace Capa_de_datos
{
    public class CD_Dashboard
    {
        CD_Conexion con = new CD_Conexion();
        #region CANTIDAD VENTAS
        public int CantidadVentas()
        {
                int total;
                SqlCommand da = new("SP_D_CantidadVentas", con.AbrirConexion());
                da.CommandType = System.Data.CommandType.StoredProcedure;
                total = (int)da.ExecuteScalar();
                con.CerrarConexion();

                return total;
           

        }
        #endregion

        #region ARTICULOS DISPONIBLES
        public decimal Articulos()
        {
            SqlCommand da = new("SP_D_Articulos", con.AbrirConexion());
            da.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rd = da.ExecuteReader();
            decimal total;
            rd.Read();
            total = (decimal)rd[0];
            rd.Close();
            con.CerrarConexion();

            return total;
        }
        #endregion

        #region GRAFICO
        public DataTable Grafico()
        {
            SqlDataAdapter da = new("SP_D_Grafico", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            con.CerrarConexion();

            return dt;
        }
        #endregion
    }
}
