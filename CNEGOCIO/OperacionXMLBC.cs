using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class OperacionXMLBC
	{
		public OperacionXML getOperacionXML(int rut, string patente)
		{
			return new OperacionXMLDAC().getOperacionXML(rut, patente);
		}

		public OperacionXML getOperacionXML_Por_Patente(string patente)
		{
			return new OperacionXMLDAC().getOperacionXML_Por_Patente(patente);
		}

		public OperacionXML getOperacionXML_Por_motor(string motor)
		{
			return new OperacionXMLDAC().getOperacionXML_Por_motor(motor);
		}

        public string act_patente_valor(string patente, Int32 monto)
        {
            string add = new OperacionXMLDAC().act_valor_patente(patente, monto);
            return add;

        }

        public string act_motor_valor(string motor, Int32 monto)
        {
            string add = new OperacionXMLDAC().act_valor_motor(motor, monto);
            return add;

        }

	}
}