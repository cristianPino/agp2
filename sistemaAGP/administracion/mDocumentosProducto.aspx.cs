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
namespace sistemaAGP {
	public partial class mDocumentosProducto : System.Web.UI.Page {

		private string codigo;

		protected void Page_Load(object sender, EventArgs e) {
			codigo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo"].ToString());

			if (!IsPostBack) {
				List<Documentos> lDocumentos = new DocumentosBC().getDocumentosAsociadosProducto(codigo);

				this.gr_dato.DataSource = lDocumentos;
				this.gr_dato.DataBind();
			}
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) {

		}

		protected void Check_Clicked(Object sender, EventArgs e) {
			FuncionGlobal.marca_check(gr_dato);
		}

		public void add_documento_producto() {
			GridViewRow row;

			for (int i = 0; i < gr_dato.Rows.Count; i++) {
				row = gr_dato.Rows[i];
				Int32 id_documento = Convert.ToInt32(row.Cells[0].Text);

				CheckBox chk = (CheckBox)row.FindControl("chk");

				if (chk.Checked == true) {
					string add = new DocumentosBC().add_documento_check(codigo, id_documento);
					
				} else {
					string add = new DocumentosBC().del_documento_check(codigo, id_documento);
				}
			}
		}

		protected void Button1_Click(object sender, EventArgs e) {
			add_documento_producto();
            //FuncionGlobal.alerta("INFORME AGREGADO CON EXITO", Page);
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("DOCUMENTOS AGREGADOS CON EXITO", Page, up);
		}
	}
}

//public void add_informe_check(Int32 id_informe, string nivel)
//{
//    string add = new InformeBC().add_informe_check(nivel, id_informe);
//}

//public void del_informe_check(Int32 id_informe, string nivel)
//{
//    string del = new InformeBC().del_informe_check(nivel, id_informe);
//}

//protected void Button3_Click(object sender, EventArgs e)
//{
//    add_check();

//}

//private void add_check()
//{

//    GridViewRow row;
//    string ger = "GERE";
//    string ejec = "EJEC";
//    string supe = "SUPE";

//    for (int i = 0; i < gr_dato.Rows.Count; i++)
//    {

//        row = gr_dato.Rows[i];
//        CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
//        CheckBox chke = (CheckBox)gr_dato.Rows[i].FindControl("chke");
//        CheckBox chks = (CheckBox)gr_dato.Rows[i].FindControl("chks");

//        Int32 id_informe1 = Convert.ToInt32(this.gr_dato.Rows[i].Cells[0].Text);

//        if (chk.Checked == true)
//        { add_informe_check(id_informe1, ger); }
//        else
//        { del_informe_check(id_informe1, ger); }

//        if (chke.Checked == true)
//        { add_informe_check(id_informe1, ejec); }
//        else
//        { del_informe_check(id_informe1, ejec); }

//        if (chks.Checked == true)
//        { add_informe_check(id_informe1, supe); }
//        else
//        { del_informe_check(id_informe1, supe); }

//    }


//}