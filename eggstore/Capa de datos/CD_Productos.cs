﻿using Capa_Entidad;
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
            productos.Precio = Convert.ToDecimal(row[4]);
            productos.Activo = Convert.ToBoolean(row[5]);
            productos.Cantidad = Convert.ToDecimal(row[6]);
            if (productos.Img == null)
            {
                productos.Img = (byte[])row[7];
            }
            productos.Descripcion = Convert.ToString(row[8]);

            return productos;
        }
        #endregion

        #region INSERTAR
        public void CD_Insertar(CE_Productos productos)
        {

        SqlCommand com = new SqlCommand()
        {
            Connection = con.AbrirConexion(),
            CommandText = "SP_A_Insertar",
            CommandType = CommandType.StoredProcedure
        };

            try 
                {
                com.Parameters.AddWithValue("@Nombre", productos.Nombre);
                com.Parameters.AddWithValue("@Grupo", productos.Grupo);
                com.Parameters.AddWithValue("@Codigo", productos.Codigo);
                com.Parameters.AddWithValue("@Precio", productos.Precio);
                com.Parameters.AddWithValue("@Cantidad", productos.Cantidad);
                com.Parameters.AddWithValue("@Activo", productos.Activo);
                com.Parameters.AddWithValue("@Img", productos.Img);
                com.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                com.ExecuteNonQuery();
                com.Parameters.Clear();
                con.CerrarConexion();
            } catch(Exception)
            {
                MessageBox.Show("Complete cada uno de los campos (incluyendo imagen)");
            }

        }
        #endregion
        
        #region ELIMINAR
        public void CD_Eliminar(CE_Productos productos)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_A_Eliminar",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdArticulo", productos.IdArticulo);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region ActualizarDatos
        public void CD_Actualizar(CE_Productos productos)
        {

            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_A_Actualizar",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdArticulo", productos.IdArticulo);
            com.Parameters.AddWithValue("@Nombre", productos.Nombre);
            com.Parameters.AddWithValue("@Grupo", productos.Grupo);
            com.Parameters.AddWithValue("@Codigo", productos.Codigo);
            com.Parameters.AddWithValue("@Precio", productos.Precio);
            com.Parameters.AddWithValue("@Cantidad", productos.Cantidad);
            com.Parameters.AddWithValue("@Activo", productos.Activo);
            com.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region ActualizarIMG
        public void CD_ActualizarIMG(CE_Productos productos)
        {

            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_A_ActualizarIMG",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdArticulo", productos.IdArticulo);
            com.Parameters.AddWithValue("@Img", productos.Img);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #endregion
    }
}
