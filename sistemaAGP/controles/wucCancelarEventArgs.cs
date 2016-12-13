using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAGP
{
	public class wucCancelarEventArgs : EventArgs
	{
		private readonly bool _cancelar;

		public bool Cancelar
		{
			get { return _cancelar; }
		}

		public wucCancelarEventArgs()
		{
			this._cancelar = true;
		}

		public wucCancelarEventArgs(bool cancelar)
		{
			this._cancelar = cancelar;
		}
	}
}