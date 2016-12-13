using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public  class HipotecaCorreo
    {
        public int IdHipotecaCorreo { get; set; }
        public int IdCliente { get; set; }
        public int IdCodigoEstado { get; set; }
        public bool CorreoEjecutivoHipotecario { get; set; }
        public bool CorreoVendedorHipotecario { get; set; }
        public bool CorreoCompradorHipotecario { get; set; }
        public bool CorreoUsuariosOperacion { get; set; }
        public bool CorreoListaCorreo { get; set; }
        public string Lista { get; set; }
        public string DescripcionEstado { get; set; }
        public int IdFormatoCorreo { get; set; }
    }
}
