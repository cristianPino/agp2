using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class MovimientocuentaBC
    {



        public MovimientoCuenta getMovimientocuentabyGasto(Int32 id_solicitud, 
                                                            string tipo_movimiento,
                                                            Int16 id_tipogasto)
        {

            
            MovimientoCuenta mcuenta = new MovimientocuentaDAC().getMovimientocuentabyGasto (id_solicitud, 
                                                            tipo_movimiento,
                                                            id_tipogasto);
            return mcuenta;
        
        
        }

        public List<MovimientoCuenta> getMovimientocuenta(Int32 id_solicitud, string tipo_movimiento)
        {

            
            List<MovimientoCuenta> lcuenta = new MovimientocuentaDAC().getMovimientocuenta(id_solicitud, tipo_movimiento);
            return lcuenta;
        
        
        }


        public string add_movimiento_cuenta(Int32 id_solicitud,
                                               Int16 id_cuenta_banco,
                                                Int16 id_tipo_gasto,
                                                string cuenta_usuario,
                                                string numero_documento,
                                                string tipo_movimiento,
                                                string tipo_operacion,
                                                string documento_especial,
                                                Int32 monto,
                                                string chkgc)
        {
            
            
            string add = new MovimientocuentaDAC().add_Movimientocuenta(0, id_solicitud,
                                                                        id_cuenta_banco,
                                                                        id_tipo_gasto,
                                                                        numero_documento,
                                                                        tipo_movimiento,
                                                                        tipo_operacion,
                                                                        documento_especial,
                                                                        cuenta_usuario,
                                                                        monto,
                                                                        chkgc);
            return add;
        }


        public string add_movimiento_cuentaPagoCompleto(Int32 id_solicitud,
                                               Int16 id_cuenta_banco,
                                                string cuenta_usuario,
                                                string numero_documento,
                                                string tipo_operacion,
                                                string documento_especial)
                                                
        {


            string add = new MovimientocuentaDAC().add_MovimientocuentaPagoCompleto(id_solicitud,
                                                                        id_cuenta_banco,
                                                                        numero_documento,
                                                                        tipo_operacion,
                                                                        documento_especial,
                                                                        cuenta_usuario);
            return add;
        }



        public string del_movimiento_cuenta(Int32 id_movimiento_cuenta, string chkgc)
                                              
        {


            string add = new MovimientocuentaDAC().del_Movimientocuenta(id_movimiento_cuenta,chkgc);
            
            return add;
        }


        public string add_rebajar_factura( Int16 id_cuenta_banco,
                                                string cuenta_usuario,
                                                string numero_documento,
                                                string tipo_operacion,
                                                string documento_especial,
                                                Int32 n_factura)
        {


            string add = new MovimientocuentaDAC().add_Rebajar_factura(id_cuenta_banco,
                                                                        numero_documento,
                                                                        tipo_operacion,
                                                                        documento_especial,
                                                                        cuenta_usuario,
                                                                        n_factura);
            return add;
        }

    }
}
