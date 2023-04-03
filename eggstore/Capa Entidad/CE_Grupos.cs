using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Grupos
    {
        private int _IdGrupo;
        private string _Nombre;

        public int IdGrupo { get => _IdGrupo; set => _IdGrupo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
    }
}
