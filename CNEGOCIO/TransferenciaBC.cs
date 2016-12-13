using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
   public class TransferenciaBC
    {

       public Transferencia GettransferenciabyIdSolicitud(Int32 id_solicitud)

       {
           Transferencia mtransferencia = new TransferenciaDAC().GetTransferenciaByIdSolicitud(id_solicitud);
           return mtransferencia;
       

       }

        public string add_Transferencia(Int32 id_solicitud,
                                        double rut_vendedor,
                                        double rut_comprador,
                                        double rut_compra_para,
                                        Int32 id_sucursal,
                                        string tag,
                                        string tipo_transferencia,
                                        string financiamiento = "0",
                                        string forma_pago = "0"
                                        )
                                   
        {

            Transferencia mtran = new Transferencia();



        
            mtran.Vendedor =  new PersonaDAC().getpersonabyrut(rut_vendedor);
            mtran.Comprador = new PersonaDAC().getpersonabyrut(rut_comprador);
            mtran.Compra_para = new PersonaDAC().getpersonabyrut(rut_compra_para);
            mtran.Id_sucursal = id_sucursal;
            mtran.Banco_financiera = new BancofinancieraBC().getBancofinanciera ( financiamiento);
            mtran.Forma_pago = forma_pago;
            mtran.Tag = tag;
            mtran.Tipo_Transferencia = tipo_transferencia;


            string add = new TransferenciaDAC().add_Transferencia(mtran, id_solicitud);

            return add;

        }


        public Transferencia ValidacionTransferencia(Int32 rut_comprador, String patente)

        {
            Transferencia mtransferencia = new TransferenciaDAC().ValidarTransferencia(rut_comprador, patente);
            return mtransferencia;


        }

    }
}
