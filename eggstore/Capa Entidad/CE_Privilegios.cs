using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Privilegios
    {
        private int _IdPrivilegio;
        private string _NombrePrivilegio;

        public int IdPrivilegio { get => _IdPrivilegio; set => _IdPrivilegio = value; }
        public string NombrePrivilegio { get => _NombrePrivilegio; set => _NombrePrivilegio = value; }
    }
}
