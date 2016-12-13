using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class UsuarioEstado
    {
        public int IdUsuarioEstado { get; set; }
        public int CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
        public bool Pertenece { get; set; }
        public byte SoloLectura { get; set; }
    }
}
