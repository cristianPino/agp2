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
	public partial class mClienteTag : System.Web.UI.Page
    {

		string id_cli_encrip;
		Int16 id_cliente;
		string familia;
        protected void Page_Load(object sender, EventArgs e)
		{


			string id_cli_encrip;
			id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
			id_cliente = Convert.ToInt16(id_cli_encrip);

			//codigo = Request.QueryString["id_producto"];

			if (!IsPostBack)
			{

				FuncionGlobal.combofamilia_cliente(dl_familia, Convert.ToInt16(id_cliente));

			}





		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{

			ClienteTag mclientetag = new  ClienteTagBC().getclientetag(id_cliente, Convert.ToInt16(dl_familia.SelectedValue.ToString()));

			this.txt_tagcliente.Text = mclientetag.Monto;
			this.txtTag_agp.Text = mclientetag.Montotag;




		}

		protected void txt_nombre_TextChanged(object sender, EventArgs e)
		{

		}

		protected void txttag_agp_TextChanged(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string add_MU = new ClienteTagBC().addclientetag(id_cliente, Convert.ToInt16(this.txtTag_agp.Text), Convert.ToInt16(this.txt_tagcliente.Text), Convert.ToInt16(dl_familia.SelectedValue.ToString()));

		}

		
		}


	

}



		
			
		


		 



