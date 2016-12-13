using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAGP
{
	public class wucBotonEventArgs : EventArgs
	{
		private readonly string _url;

		public string Url
		{
			get { return _url; }
		}

		public wucBotonEventArgs()
		{
			this._url = "";
		}

		public wucBotonEventArgs(string url)
		{
			this._url = url;
		}
	}
}