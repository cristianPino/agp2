using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAGP
{
	public class wucPersonaEventArgs : EventArgs
	{
		private readonly bool _activar;

		public bool Activar
		{
			get { return _activar; }
		}

		public wucPersonaEventArgs()
		{
			this._activar = false;
		}

		public wucPersonaEventArgs(bool activar)
		{
			this._activar = activar;
		}
	}
}