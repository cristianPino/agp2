using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class ComprobanteCobroFamiliaBC
	{
		public List<ComprobanteCobroFamilia> getAllComprobantes()
		{
			return new ComprobanteCobroFamiliaDAC().getAllComprobantes();
		}

		public ComprobanteCobroFamilia getComprobante(int id_familia)
		{
			return new ComprobanteCobroFamiliaDAC().getComprobante(id_familia);
		}
	}
}