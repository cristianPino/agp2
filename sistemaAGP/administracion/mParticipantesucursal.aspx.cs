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
	public partial class mParticipantesucursal : System.Web.UI.Page
	{
		private string rut_participante;

		protected void Page_Load(object sender, EventArgs e)
		{
            string id;
			id = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
            rut_participante = id;
			if (!IsPostBack)
			{
                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
			}
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void Button1_Click(object sender, EventArgs e)
		{
            add_participante_sucursal();
			//FuncionGlobal.alerta("SUCURSALES ACTUALIZADAS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("SUCURSALES ACTUALIZADAS CON EXITO", this.Page, pnl);
			getsucursales();
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		{
			getsucursales();
		}

		private void getsucursales()
		{
			List<ParticipanteSucursal> lsucursal = new ParticipanteSucursalBC().getParticipanteSucursal(Convert.ToInt16(this.dl_modulo.SelectedValue), rut_participante);
			this.gr_dato.DataSource = lsucursal;
			this.gr_dato.DataBind();
		}

		private void add_participante_sucursal()
		{
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				Int32 id_sucursal = Convert.ToInt32(this.gr_dato.Rows[i].Cells[0].Text);
				if (chk.Checked == true)
				{
                    string add = new ParticipanteSucursalBC().add_participantebysucursal(id_sucursal, rut_participante);
				}
				else
				{
                    string del = new ParticipanteSucursalBC().del_participantebysucursal(rut_participante,id_sucursal);
				}
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulo(this.dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}
	}
}