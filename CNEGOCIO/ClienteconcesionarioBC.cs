using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
	public class ClienteconcesionarioBC
	{
		
		


		public List<ClienteConce> getclienteconcesionario(int id_cliente)
		{

			List<ClienteConce> lclienteconce = new ClienteConcesionarioDAC().getclienteconcesionario(id_cliente);
			return lclienteconce;

		}
	}

}