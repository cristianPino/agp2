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

namespace sistemaAGP
{
	public partial class mSucursal : System.Web.UI.Page
	{
		private Int16 id_cliente;
		protected void Page_Load(object sender, EventArgs e)
		{
			string id_cli_encrip;
			id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
			id_cliente = Convert.ToInt16(id_cli_encrip);
			Cliente mcliente = new ClienteBC().getcliente(id_cliente);
			this.lbl_cliente.Text = mcliente.Persona.Nombre;
			if (!IsPostBack)
			{
				getsucursal();
				FuncionGlobal.combopais(this.dl_pais);
				FuncionGlobal.combomodulo(this.dl_modulo, Convert.ToInt16(id_cliente));
			}
		}

		private void getsucursal()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_sucursal"));
			dt.Columns.Add(new DataColumn("nombre"));
			dt.Columns.Add(new DataColumn("modulo"));
			dt.Columns.Add(new DataColumn("comuna"));
			List<SucursalCliente> lSucursal = new SucursalclienteBC().getSucursalbycliente(Convert.ToInt16(id_cliente));
			foreach (SucursalCliente msucursal in lSucursal)
			{
				DataRow dr = dt.NewRow();

				dr["id_sucursal"] = msucursal.Id_sucursal;
				dr["nombre"] = msucursal.Nombre;
				dr["modulo"] = msucursal.Modulocliente.Nombre;
				dr["comuna"] = msucursal.Comuna.Nombre;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
		}

		protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
		}

		protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (this.txt_nombre.Text == "" | this.dl_comuna.SelectedValue == "0" | this.dl_modulo.SelectedValue == "0")
			{
				//FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
				UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel("INGRESE LOS DATOS CORRESPONDIENTES", this.Page, pnl);
				return;
			}

			string add = new SucursalclienteBC().add_sucursal(Convert.ToInt16(this.dl_comuna.SelectedValue), Convert.ToInt16(id_cliente), Convert.ToInt16(this.dl_modulo.SelectedValue), this.txt_nombre.Text, 0);

			//FuncionGlobal.alerta("SUCURSAL INGRESADA CON EXITO", Page);
			UpdatePanel upnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("SUCURSAL INGRESADA CON EXITO", this.Page, upnl);
			this.txt_nombre.Text = "";
			getsucursal();

		}

		protected void Button2_Click(object sender, EventArgs e) { }

	}
}