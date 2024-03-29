﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Productos
    {
        readonly CD_Productos objProductos = new CD_Productos();

        //Vista productos
        #region BUSCAR
        public DataTable BuscarProducto(string buscarr)
        {
            return objProductos.Buscar(buscarr);
        }
        #endregion

        //Cista Crudprodutos

        #region C R U D

        #region CONSULTAR
        public CE_Productos Consulta(int IdArticulo)
        {
            return objProductos.Consultar(IdArticulo);
        }
        #endregion

        #region INSERTAR
        public void Insertar(CE_Productos productos)
        {
            objProductos.CD_Insertar(productos);
        }
        #endregion

        #region ELIMINAR
        public void Eliminar(CE_Productos cE_Productos)
        {
            objProductos.CD_Eliminar(cE_Productos);
        }
        #endregion

        #region ActualizarDatos
        public void ActualizarDatos(CE_Productos productos)
        {
            objProductos.CD_Actualizar(productos);
        }
        #endregion

        #region ActualizarIMG
        public void ActualizarIMG(CE_Productos productos)
        {
            objProductos.CD_ActualizarIMG(productos);
        }
        #endregion

        #endregion
    }
}
