using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
	public class ClienteTagBC
	{
		public string addclientetag(int id_cliente, int monto_agp, int monto_cliente, int id_familia)
		{
			return new ClienteTagDAC().add_clientetag(id_cliente,monto_agp,monto_cliente, id_familia);
		}

		public string addclientetagoperacion(int id_solicitud, int id_tipogasto, int montogasto)
		{
			return new ClienteTagDAC().add_clientetagoperacion(id_solicitud, id_tipogasto,montogasto);
		}

		public string delclientetagoperacion(int id_solicitud, int id_tipogasto)
		{
			return new ClienteTagDAC().del_clientetagoperacion(id_solicitud, id_tipogasto);
		}
		
		public  ClienteTag getclientetag(int id_cliente, int id_familia)
		{

			ClienteTag Mclientetag = new ClienteTagDAC().getclientetag(id_cliente, id_familia);

			return Mclientetag;
		}


		public List<ClienteTag> getclientetaglist(Int32 id_cliente, int id_familia , string tipo_operacion)
		{
			List<ClienteTag> lcliente = new ClienteTagDAC().getclientetaglist( id_cliente, id_familia,tipo_operacion);
			return lcliente;
		}

	}

}