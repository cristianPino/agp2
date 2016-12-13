using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Repertorio
	{
		int Id_repertorio { get; set; }
		DateTime Fecha_repertorio { get; set; }
		Usuario Cuenta_usuario { get; set; }
	}
}