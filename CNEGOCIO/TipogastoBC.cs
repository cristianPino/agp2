using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class TipogastoBC
    {
		public Tipogasto Gettipogasto(Int16 id_tipogasto)
        {
            Tipogasto mtipo = new TipogastoDAC().getTipogasto(id_tipogasto);
            return mtipo;

        
        }

        public string add_tipogasto(Int16 id_tipogasto, double valor, string descripcion,
                                    Int16 id_cliente, string tipo_operacion, string cargo_contable,string transferencia, string habil, string cuenta, string cuentafac)

        {

            string add = new TipogastoDAC().add_Tipogasto(id_tipogasto,
                                                        valor,
                                                        descripcion,
                                                        id_cliente,
                                                        tipo_operacion,
                                                        cargo_contable,
                                                        transferencia,habil,cuenta, cuentafac);

            return add;
            
        }

        public List<Tipogasto> getalltipogasto(Int16 id_cliente, string tipo_operacion)

        {

            List<Tipogasto> ltipogasto = new TipogastoDAC().getallTipogasto(id_cliente, tipo_operacion);

            return ltipogasto;

        }

        public List<Tipogasto> getTipoGastoMovimientocuenta(Int32 id_solicitud, string tipo_movimiento)
        {

            List<Tipogasto> ltipogasto = new TipogastoDAC().getTipoGastoMovimientocuenta(id_solicitud, tipo_movimiento);

            return ltipogasto;

        }

    }
}
