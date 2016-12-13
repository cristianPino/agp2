using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class ValorSeguroVehiculoBC
    {
        public string add_ValorSeguroVehiculo(string codigo_distribuidor, string codigo, Int32 valor,string id_seguro)
        {

            string add = new ValorSeguroVehiculoDAC().add_ValorSeguroVehiculo(codigo_distribuidor, codigo, valor,id_seguro);
            return add;

        }
        public string add_seguros(string codigo_distribuidor, string codigo, Int32 valor, Int32 periodo, DateTime fecha_inicio, DateTime fecha_final)
        {

            string add = new ValorSeguroVehiculoDAC().add_seguros(codigo_distribuidor, codigo, valor, periodo,fecha_inicio,fecha_final);
            return add;

        }
        public List<ValorSeguroVehiculo> getallvalosegurovehiculo(string codigo_distribuidor,Int32 periodo,Int32 anno)
        {
            List<ValorSeguroVehiculo> lvalorsegurovehiculo = new ValorSeguroVehiculoDAC().getallvalorsegurovehiculo(codigo_distribuidor,periodo,anno);
            return lvalorsegurovehiculo;
        }


        public ValorSeguroVehiculo getallvalosegurovehiculobycodigo(string codigo_distribuidor, string codigo)
        {

            ValorSeguroVehiculo add = new ValorSeguroVehiculoDAC().getallvalorsegurovehiculobycodigo(codigo_distribuidor, codigo);
            return add;

        }
    }
}
