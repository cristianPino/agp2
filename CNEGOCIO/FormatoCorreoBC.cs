using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class FormatoCorreoBC
    {
        public List<FormatoCorreo> GetFortmatoCorreos()
        {
            return new FormatoCorreoDAC().GetFortmatoCorreos();
        }
    }
}
