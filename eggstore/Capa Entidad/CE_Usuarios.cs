using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Usuarios
    {
        private int _IdUsuario;
        private string _Nombres;
        private string _Apellidos;
        private float _Telefono;
        private float _Identificacion;
        private string _Correo;
        private string _Sector;
        private int _Privilegio;
        private byte[] _img;
        private string _Usuario;
        private string _Contrasenia;
        private string _patron;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public float Telefono { get => _Telefono; set => _Telefono = value; }
        public float Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Sector { get => _Sector; set => _Sector = value; }
        public int Privilegio { get => _Privilegio; set => _Privilegio = value; }
        public byte[] Img { get => _img; set => _img = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contrasenia { get => _Contrasenia; set => _Contrasenia = value; }
        public string Patron { get => _patron; set => _patron = value; }
    }
}
