using System;
using System.Data;
using System.Data.SqlClient;
using Capa_de_datos;
using Capa_Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios();

        //CRUD USUARIOS

        #region CONSULTAR
        public CE_Usuarios Consultar(int IdUsuario)
        {
            return objDatos.CD_Consulta(IdUsuario);
        }
        #endregion

        #region INSERTAR
        public void Insertar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Insertar(Usuarios);
        }
        #endregion

        #region ELIMINAR
        public void Eliminar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Eliminar(Usuarios);
        }
        #endregion

        #region ACTUALIZAR DATOS
        public void ActualizarDatos(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarDatos(Usuarios);
        }
        #endregion

        #region ACTUALIZAR PASS
        public void ActualizarPass(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarPass(Usuarios);
        }
        #endregion

        #region ACTUALIZAR IMAGEN
        public void ActualizarIMG(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarIMG(Usuarios);
        }
        #endregion

        //VISTA USUARIOS

        #region BUSCAR USUARIOS
        public DataTable Buscar(string buscar)
        {
            return objDatos.Buscar(buscar);
        }
        #endregion

    }
}
