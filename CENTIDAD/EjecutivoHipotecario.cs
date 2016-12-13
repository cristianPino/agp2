using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class EjecutivoHipotecario
    {
        public int IdEjecutivo { set; get; }
        public int IdCliente { set; get; }
        public int IdSucursal { set; get; }
        public string Nombre { set; get; }
        public string Apepat { set; get; }
        public string Apemat { set; get; }
        public string Mail { set; get; }
        public Cliente Cliente { set; get; }
        public SucursalCliente Sucursal { set; get; }
    }
}
