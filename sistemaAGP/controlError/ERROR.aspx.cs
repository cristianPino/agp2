using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string codigo_error;

        protected void Page_Load(object sender, EventArgs e)
        {
           codigo_error = Request.QueryString["error_agp"].ToString();

        }
    }
}
