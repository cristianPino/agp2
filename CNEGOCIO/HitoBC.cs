using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class HitoBC
    {

        public List<Hito> gethito(Int32 id_estado)
        {
            return new HitoDAC().getHitos(id_estado);
        }

        public string add_hito(Int32 id_estado, string observacion, string fecha,Int32 tipo)
        {
            return new HitoDAC().add_hito(id_estado,observacion,fecha,tipo);
        }

    }
}
