using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class ContratoClienteBC
    {
        public List<ContratoCliente> getContratoByCliente(Int16 id_cliente, string all)
        {

            List<ContratoCliente> lcontratocliente = new ContratoClienteDAC().getContratoByCliente(id_cliente, all);
            return lcontratocliente;

        }

        public List<ContratoCliente> getContratoByClienteProducto(Int16 id_cliente, string all,string producto)
        {

            List<ContratoCliente> lcontratocliente = new ContratoClienteDAC().getContratoByClienteProducto(id_cliente, all,producto);
            return lcontratocliente;

        }


        public string add_contrato_cliente(Int32 id_contrato, Int16 id_cliente,string codigo)
        {


            string add = new ContratoClienteDAC().add_Contrato_cliente(id_contrato, id_cliente, codigo);
            return add;


        }

        public string del_contrato_cliente(Int32 id_contrato, Int16 id_cliente,string codigo)
        {


            string add = new ContratoClienteDAC().del_contrato_cliente(id_contrato, id_cliente,codigo);
            return add;


        }
    }
}
