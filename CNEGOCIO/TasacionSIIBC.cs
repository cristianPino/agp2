using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class TasacionSIIBC
    {

        public string add_tasacionSII(Tipovehiculo tipo_vehiculo, Marcavehiculo marca, string modelo, int ano, string cilindraje, int npuerta, string combustible, string transmicion,
                                         string equipo, Int32 tasacion, Int32 permiso)
        {

            string val = new TasacionSIIDAC().add_tasacionSII(tipo_vehiculo, marca, modelo, ano, cilindraje, npuerta, combustible, transmicion,
                                          equipo, tasacion, permiso);
            return val;


        }

        public List<TasacionSII> GetTasacionbydatos(string codigo, string marca, string modelo, Int16 ano)
        {



            List<TasacionSII> lTasacion = new TasacionSIIDAC().GetTasacionbydatos(codigo, marca, modelo, ano);


            return lTasacion;

        }


    }
}
