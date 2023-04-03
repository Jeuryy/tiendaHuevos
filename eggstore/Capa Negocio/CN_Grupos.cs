using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Grupos
    {
        CD_Grupos cD_Grupos = new CD_Grupos();
        CE_Grupos cE_Grupos = new CE_Grupos();

        #region LISTAR GRUPOS
        public List <string> ListarGrupos()
        {
            return cD_Grupos.ListarGrupos();
        }
        #endregion

        #region NOMBRE GRUPO
        public CE_Grupos Nombre(int IdGrupo)
        {
            return cD_Grupos.Nombre(IdGrupo);
        }
        #endregion

    }
}
