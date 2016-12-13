using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CACCESO {
	public abstract class BaseDAC {
		protected string strConn;

		public BaseDAC() {
			strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString;
		}


	}
}