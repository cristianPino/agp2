using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class ProdClienteBC
    {
        public string add_prodcliente( Int32 id_cliente, string nombre)
        {

            string add = new ProdClienteDAC().add_ProdCliente(id_cliente, nombre);

            return add;

        }


        public List<ProdCliente> getprodcliente(Int32 id_cliente)
        {

            List<ProdCliente> lprodcliente = new ProdClienteDAC().getProductobyCliente(id_cliente);
            return lprodcliente;

        }


    }
}
