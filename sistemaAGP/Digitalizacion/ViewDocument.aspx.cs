using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP
{
	public partial class ViewDocument : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.if_doc.Attributes["src"] = Request.QueryString["url"] ?? "";
			}
		}
	}
}