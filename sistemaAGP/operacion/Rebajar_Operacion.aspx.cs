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
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;


namespace sistemaAGP
{
    public partial class Rebajar_Operacion : System.Web.UI.Page
	{
		private string n_factura;

		protected void Page_Load(object sender, EventArgs e)
		{
            n_factura = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["n_factura"].ToString());

			if (!IsPostBack)
			{
				FuncionGlobal.combobanco(dl_financiera,1);
				FuncionGlobal.comboparametro(this.dl_tipo_operacion, "FMO");
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			add_gastos();
			FuncionGlobal.alerta("Factura rebajada correctamente", Page);
			
		}
		private void add_gastos()
		{
            string mfactura = new MovimientocuentaBC().add_rebajar_factura(Convert.ToInt16(this.dl_cuenta.SelectedValue), (string)(Session["usrname"]), this.txt_numero_documento.Text, this.dl_tipo_operacion.SelectedValue, this.txt_especial.Text,Convert.ToInt32(lbl_n_factura.Text));
		}
		protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocuenta(this.dl_financiera.SelectedValue, this.dl_cuenta);
		}
	}
}
