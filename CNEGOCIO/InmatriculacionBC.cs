using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class InmatriculacionBC
	{
		public string AddInmatriculacion(Inmatriculacion inmatriculacion)
		{
			return new InmatriculacionDAC().AddInmatriculacion(inmatriculacion);
		}

		public Inmatriculacion GetInmatriculacion(int id_solicitud)
		{
			return new InmatriculacionDAC().GetInmatriculacion(id_solicitud);
		}

		public Inmatriculacion GetInmatriculacionByNotaPedido(Int16 id_cliente, string nota_venta)
		{
			return new InmatriculacionDAC().GetInmatriculacionByNotaPedido(id_cliente, nota_venta);
		}
	}
}