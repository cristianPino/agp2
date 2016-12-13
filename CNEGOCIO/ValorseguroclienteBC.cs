using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class ValorseguroclienteBC
    {
        public string add_ValorSegurocliente(string id_cliente, string codigo, Int32 valor, Int32 valorAGP,Int32 id_seguro_cliente)
        {

            string add = new ValorseguroclienteDAC().add_ValorSegurocliente(id_cliente, codigo, valor,valorAGP,id_seguro_cliente);
            return add;

        }
        public string add_seguro_cliente(string id_cliente, string codigo, Int32 valor, Int32 valorAGP, Int32 periodo,DateTime fecha_desde,DateTime fecha_hasta)
        {

            string add = new ValorseguroclienteDAC().add_seguros(id_cliente, codigo, valor, valorAGP, periodo,fecha_desde,fecha_hasta);
            return add;

        }
        public List<ValorSeguroCliente> getallvalosegurocliente(Int32 id_cliente, Int32 periodo, Int32 anno)
        {
            List<ValorSeguroCliente> lvalorsegurocliente = new ValorseguroclienteDAC().getallvalorsegurocliente(id_cliente,periodo,anno);
            return lvalorsegurocliente;
        }
        public ValorSeguroCliente getallvaloseguroclientebycodigo(Int32 id_cliente, string codigo)
        {

            ValorSeguroCliente add = new ValorseguroclienteDAC().getallvalorseguroclientebycodigo(id_cliente, codigo);
            return add;

        }


    }
}
