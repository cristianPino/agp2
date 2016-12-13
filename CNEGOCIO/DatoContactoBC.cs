using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class DatoContactoBC
    {
        public string add_DatoContacto(Int32 id_solicitud, string referencia)
        {

            string add = new DatoContactoDAC().add_datoContacto(id_solicitud,referencia);

            return add;

        }
        public string del_DatoContacto(Int32 id_solicitud)
        {

            string del = new DatoContactoDAC().del_datoContacto(id_solicitud);

            return del;

        }


        public List<DatoContacto> getdatocontactobysolicitud(Int32 id_solicitud)
        {

            List<DatoContacto> ldatocontacto = new DatoContactoDAC().getdatocontacto(id_solicitud);
            return ldatocontacto;


        }
    }
}
