using Capa_de_datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Carrito
    {
        readonly CD_Carrito objCarrito = new CD_Carrito();
        #region BUSCAR
        public CE_Carrito Buscar(string buscar)
        {
            return objCarrito.Buscar(buscar);
        }
        #endregion

        #region AGREGAR
        public DataTable Agregar(string producto, decimal cantidad)
        {
            return objCarrito.Agregar(producto, cantidad);
        }
        #endregion

        #region VENTA
        public void Venta (string factura, decimal total, DateTime fecha, int idusuario)
        {
            objCarrito.Venta(factura, total, fecha, idusuario);
        }
        #endregion

        #region VENTA DETALLE
        public void Venta_Detalle(string codigo, string factura, decimal cantidad, decimal totalarticulo)
        {
            objCarrito.Venta_Detalle(codigo, factura, cantidad, totalarticulo);
        }
        #endregion
    }
}
