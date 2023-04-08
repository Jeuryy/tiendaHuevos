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
    }
}
