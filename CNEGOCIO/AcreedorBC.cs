using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;
using System.Data;
namespace CNEGOCIO
{
    public class AcreedorBC
    {
        public List<Acreedor> getacreedores(Int32 id_prohibicion)
        {
            return new AcreedorDAC().get_acreedores(id_prohibicion);
        }

        public string add_acreedor(Int32 id_prohibicion, Int32 rut_acreedor)
        {
            return new AcreedorDAC().add_prohibicion(id_prohibicion,rut_acreedor);
        }

        public string del_acreedor(Int32 id_prohibicion)
        {
            return new AcreedorDAC().del_prohibicion(id_prohibicion);
        }

       


    }
}
