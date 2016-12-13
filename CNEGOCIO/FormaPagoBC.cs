using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class FormaPagoBC
    {
        public string add_forma_pago( Int32 id_cliente, string descripcion)
        {

            string add = new FormaPagoDAC().add_formapago(id_cliente,descripcion);
            return add;

        }



        public List<FormaPago> getformapagobycliente(Int32 id_cliente)
        {

            List<FormaPago> lformapago= new FormaPagoDAC().getformapagobycliente(id_cliente);

            return lformapago;

        }
        public FormaPago getformapago(Int32 id_forma_pago)
        {
            FormaPago mformapago= new FormaPagoDAC().getformapago(id_forma_pago);

            return mformapago;

        }

    }
}
