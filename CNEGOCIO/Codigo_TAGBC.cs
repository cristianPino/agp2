using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class Codigo_TAGBC
    {
        public string add_Codigo_TAG(string codigo_tag)
        {
            string add = new Codigo_TAGDAC().add_Codigo_TAG(codigo_tag);
            return add;
        }
        public string add_Control_TAG(string patente,Int32 id_solicitud,string tipo,string cuenta_usuario)
        {
            string add = new Codigo_TAGDAC().add_Control_TAG(patente, id_solicitud, tipo, cuenta_usuario);
            return add;
        }

        public List<Codigo_TAG> GetCodigos()
        {
            List<Codigo_TAG> lcodigo = new Codigo_TAGDAC().GetCodigos();
            return lcodigo;
        }

        public List<Codigo_TAG> GetCodigosActivos(Int32 id_solicitud)
        {
            List<Codigo_TAG> lcodigo = new Codigo_TAGDAC().GetCodigosActivos(id_solicitud);
            return lcodigo;
        }


    }
}
