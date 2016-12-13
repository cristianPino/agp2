using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class BienesNumeroClienteBC
    {
        public string add_integracion_leasing(int id_solicitud, int dl_bien, int numero_emisor, string tipo_operacion)
        {
            string upt = new BienesNumeroClienteDAC().add_integracion_leasing(id_solicitud, dl_bien, numero_emisor, tipo_operacion);
            return upt;
        }


        public List<BienesNumeroCliente> GetBienesByNumeroCliente(string numero_cliente, string tipo_operacion)
        {
            List<BienesNumeroCliente> lBienes = new BienesNumeroClienteDAC().GetBienesByNnumeroCliente(numero_cliente, tipo_operacion);
            return lBienes;
        }


        public string act_datos_bien(int numeroOperacion,
                                     int factura,
                                     int id_bien,
                                     int id_solicitud,
                                     string patente,
                                     DateTime fecha_emision_factura,
                                     int instruccion_de_pago,
                                     int normaEuro)
        {
            string act_bien = new BienesNumeroClienteDAC().act_datos_bien(numeroOperacion,
                                                                          factura,
                                                                          id_bien,
                                                                          id_solicitud,
                                                                          patente,    
                                                                          fecha_emision_factura,  
                                                                          instruccion_de_pago,
                                                                          normaEuro);
            return act_bien;

        }


    }
}