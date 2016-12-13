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
	public partial class Documentacion : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) mostrar_documentos();
		}

		protected void Button1_Click(object sender, EventArgs e) {
			if (valida_ingreso()) {
				add_documentos();
				mostrar_documentos();
				limpiar();
			}
		}

		private void add_documentos() {
			string add = new DocumentosBC().add_documentos(this.txt_nombre.Text);
			FuncionGlobal.alerta("DOCUMENTO INGRESADO CON EXITO", this.Page);
			limpiar();
			return;
		}
		
		private void limpiar() {
			this.txt_nombre.Text = " ";
		}

		private Boolean valida_ingreso() {
			if (this.txt_nombre.Text == "") {
				FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
				return false;
			}
			return true;
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void txt_nombre_TextChanged(object sender, EventArgs e) { }

		protected void Button2_Click(object sender, EventArgs e) {
			limpiar();
		}

		protected void btnGuardar_Click(object sender, EventArgs e) {
			upd_documento();
		}

		private void mostrar_documentos() {
            List<Documentos> lDocumentos = new DocumentosBC().getallDocumentos();
			this.gr_dato.DataSource = lDocumentos;
			this.gr_dato.DataBind();
		}

		private void upd_documento() {
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++) {
				row = gr_dato.Rows[i];
				Int32 id_documento = Convert.ToInt32(row.Cells[0].Text);

				CheckBox chk = (CheckBox)row.FindControl("chk");
				Boolean chkaux = Convert.ToBoolean(gr_dato.DataKeys[i].Values[0]);

				if (chk.Checked != chkaux) {
					string add = new DocumentosBC().upd_documento_publico(id_documento, chk.Checked);
				}
			}
			mostrar_documentos();
			//Page.RegisterClientScriptBlock("Aviso", "<script type=\"text/javascrip\">alert('Datos guardados satisfactoriamente');</script>");
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Aviso", "alert('Datos guardados satisfactoriamente');", true);
		}

		protected void Check_Clicked(Object sender, EventArgs e) {
			FuncionGlobal.marca_check(gr_dato);
		}
	}
}