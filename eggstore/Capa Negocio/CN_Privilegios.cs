using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_de_datos;
using Capa_Entidad;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Privilegios
    {
        CD_Privilegios CD_Privilegios = new CD_Privilegios();

        #region IDPRIVILEGIO
        public int IdPrivilegio(string NombrePrivilegio)
        {
            return CD_Privilegios.IdPrivilegio(NombrePrivilegio);
        }
        #endregion

        #region NOMBREPRIVILEGIO
        public CE_Privilegios NombrePrivilegio (int IdPrivilegio)
        {
            return CD_Privilegios.NombrePrivilegio(IdPrivilegio);
        }
        #endregion

        #region LISTA PRIVILEGIOS
        public List<string> ListarPrivilegios()
        {
            return CD_Privilegios.ObtenerPrivilegios();
        }
        #endregion
    }

}
