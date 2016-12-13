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
using System.Collections.Generic;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP
{
	public partial class mFinancieraus : System.Web.UI.Page
	{
		private string cuenta_usuario;

		protected void Page_Load(object sender, EventArgs e)
		{
			string cuenta_usu;
			cuenta_usuario = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"].ToString());
			
			if (!IsPostBack)
			{
				getfinancieras();
				//FuncionGlobal.comboclientesbyusuario(cuenta_usuario, this.dl_cliente);
				//Usuario musuario = new UsuarioBC().GetUsuario(cuenta_usuario);
				//this.lbl_usuario.Text = musuario.Nombre;
			}
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void Button1_Click(object sender, EventArgs e)
		{
			add_usuario_financiera();
			////FuncionGlobal.alerta("financieraES ACTUALIZADAS CON EXITO", Page);
			//UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			//FuncionGlobal.alerta_updatepanel("financieraES ACTUALIZADAS CON EXITO", this.Page, pnl);
			getfinancieras();
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		{
			//getfinancieras();
		}

		private void getfinancieras()
		{
			List<BancoFinanciera> lfinanciera = new BancofinancieraBC().getFinancieraall(cuenta_usuario);
			this.gr_dato.DataSource = lfinanciera;
			this.gr_dato.DataBind();
		}

		private void add_usuario_financiera()
		{
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
          
				string financiera = this.gr_dato.Rows[i].Cells[0].Text;
				if (chk.Checked == true)
				{

					int add = new BancofinancieraBC().add_usuario_financiera(cuenta_usuario, financiera);
				}
				else
				{
					int del = new BancofinancieraBC().del_usuario_financiera(cuenta_usuario, financiera);
				}
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			//FuncionGlobal.combomodulobyusuario(this.dl_modulo, cuenta_usuario, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}
	}
}