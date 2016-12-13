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

namespace sistemaAGP.preinscripcion
{
    public partial class CargaTAG : System.Web.UI.Page
    {
        public Usuario Usuario;
        private string id_usuario;
        private string count;
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Codigo_TAG> lPais = new Codigo_TAGBC().GetCodigosActivos(0);

            this.lbl_stock.Text = "Stock TAG " + lPais.Count.ToString();

            this.gr_dato.DataSource = lPais;
            this.gr_dato.DataBind(); 

        }

        protected void txt_codigo_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_codigo.Text != "")
            {
                string add = new Codigo_TAGBC().add_Codigo_TAG(this.txt_codigo.Text.Trim());
            }
            List<Codigo_TAG> lPais = new Codigo_TAGBC().GetCodigosActivos(0);

            this.lbl_stock.Text = "Stock TAG " + lPais.Count.ToString();

            this.gr_dato.DataSource = lPais;
            this.gr_dato.DataBind(); 
        }

       

      
    }
}


