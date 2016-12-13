using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;

namespace sistemaAGP
{
    public partial class mTasacionSII : System.Web.UI.Page
    {
       

        protected void bt_buscar_Click(object sender, EventArgs e)
        {
            List<TasacionSII> lTasacion = new TasacionSIIBC().GetTasacionbydatos(this.txt_codigo.Text, this.txt_marca.Text, this.txt_modelo.Text,Convert.ToInt16(this.txt_ano.Text));

            this.gr_sii.DataSource = lTasacion;
            this.gr_sii.DataBind(); 
        }

        protected void gr_sii_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
