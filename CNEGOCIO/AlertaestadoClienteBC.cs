using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class AlertaestadoClienteBC
    {

		public string add_Alerta_estado_cliente(int id_alerta, int codigo_estado, int id_cliente, string listacorreo, string envia_adquiriente, int dias_primer_a, int dias_ultimo_a, int caducidad_estado, int contador_estado, int id_documento, string habilitado)
		{
			string add = new AlertaestadoClienteDAC().add_Alerta_estado_cliente(id_alerta, codigo_estado, id_cliente, listacorreo, envia_adquiriente, dias_primer_a, dias_ultimo_a, caducidad_estado, contador_estado, id_documento, habilitado);
			return add;
		}


        public List<AlertaestadoCliente> getReglaFamiliaCliente(Int16 id_familia, Int16 id_alerta, Int16 codigo_estado)
        {

            return new AlertaestadoClienteDAC().getReglaFamiliaCliente(id_familia, id_alerta, codigo_estado);
        }

        public List<AlertaestadoCliente> getEstadoAlertaFamiliaCliente(int id_familia, int id_cliente)
		{
            return new AlertaestadoClienteDAC().getEstadoAlertaFamiliaCliente(id_familia, Convert.ToInt16(id_cliente));
		}



		public string add_regla_estado_cliente(Int16 id_alerta, Int16 codigo_estado)
		{
			string add = new AlertaestadoClienteDAC().add_regla_estado_cliente(id_alerta,codigo_estado);
			return add;
		}

		

		public string del_regla_estado_cliente(Int16 id_alerta,Int16 codigo_estado)
		{
			string add = new AlertaestadoClienteDAC().del_regla_estado_cliente(id_alerta,codigo_estado);
			return add;
		}

		

    }
}
