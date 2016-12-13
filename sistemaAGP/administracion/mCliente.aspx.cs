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
	public partial class mCliente : System.Web.UI.Page
	{

		

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_rut.Focus();
				getcliente();
			}
		}
		
		private void getcliente()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_cliente"));
			dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("url_modulo"));
            dt.Columns.Add(new DataColumn("url_sucursal"));
            dt.Columns.Add(new DataColumn("url_personero"));
            dt.Columns.Add(new DataColumn("url_gasto"));
            dt.Columns.Add(new DataColumn("url_producto"));
            dt.Columns.Add(new DataColumn("url_soap"));
            dt.Columns.Add(new DataColumn("url_prod"));
            dt.Columns.Add(new DataColumn("url_forma_pago"));
            dt.Columns.Add(new DataColumn("url_contrato"));
            dt.Columns.Add(new DataColumn("url_alerta"));
            dt.Columns.Add(new DataColumn("url_financiera"));
            dt.Columns.Add(new DataColumn("url_oper_gasto"));
			dt.Columns.Add(new DataColumn("url_cliente_tag"));
			dt.Columns.Add(new DataColumn("dl_financiera"));
			
            List<Cliente> lCliente = new ClienteBC().getclientes();
			foreach (Cliente mcliente in lCliente)
			{
				DataRow dr = dt.NewRow();

				dr["id_cliente"] = mcliente.Id_cliente;
				dr["Nombre"] = mcliente.Persona.Nombre;
                dr["url_modulo"] = "mModulocliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_sucursal"] = "mSucursal.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_personero"] = "mParticipante.aspx?rut=" + FuncionGlobal.FuctionEncriptar(mcliente.Persona.Rut.ToString().Trim());
                dr["url_gasto"] = "mTipogasto.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_producto"] = "mOperacionCliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
				dr["url_soap"] = "mValorSegurocliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim()) + "&nombre=" +  mcliente.Persona.Nombre.ToString().Trim();
                dr["url_prod"] = "mProdCliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_forma_pago"] = "mFormaPago.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_contrato"] = "mContratoCliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_alerta"] = "mAlertaCliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_financiera"] = "mBancoCliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
                dr["url_oper_gasto"] = "mClienteTipooperciongasto.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
				dr["url_cliente_tag"] = "mClientetag.aspx?id=" + FuncionGlobal.FuctionEncriptar(mcliente.Id_cliente.ToString().Trim());
				dr["dl_financiera"] = mcliente.Financiera;
				dt.Rows.Add(dr);
			}
		
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void txt_rut_Leave(object sender, EventArgs e)
		{
			busca_persona(Convert.ToDouble(this.txt_rut.Text));
		}

		private void busca_persona(double rut)
		{
			Persona mpersona = new PersonaBC().getpersonabyrut(rut);
			if (mpersona.Rut == Convert.ToDouble(0))
			{
				FuncionGlobal.alerta("RUT NO EXISTE COMO PERSONA EN EL SISTEMA", this.Page);
				return;
			}
			this.lbl_nombre.Text = mpersona.Nombre;
		}
		
		private void add_cliente()
		{
			string add = new ClienteBC().add_cliente(Convert.ToInt32(this.txt_rut.Text));
			FuncionGlobal.alerta("NUEVO CLIENTE INGRESADO CON EXITO", this.Page);
			getcliente();
		}
		
		protected void Button1_Click(object sender, EventArgs e)
		{
			add_cliente();
		}

		protected void Button2_Click(object sender, EventArgs e) { }

		protected void txt_rut_TextChanged(object sender, EventArgs e) { }

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
		protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{

				BancoFinanciera mbfinan = new BancoFinanciera();
				mbfinan.Codigo = "0";
				mbfinan.Nombre = "Seleccionar";

				List<BancoFinanciera> lbancof = new BancofinancieraBC().getallbancoallfinanciera();

				lbancof.Add(mbfinan);


				DropDownList dl2 = (DropDownList)e.Row.FindControl("dl_financiera");

				dl2.DataSource = lbancof;
				dl2.DataValueField = "codigo";
				dl2.DataTextField = "nombre";
				dl2.DataBind();
				dl2.SelectedValue = "0";



				

				
				//dl2.SelectedValue = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();

			}

		}

		protected void Button21_Click(object sender, EventArgs e)
		{
		
			GridViewRow row;

			


			string add_MU = "";

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
				string id_cliente = gr_dato.Rows[i].Cells[0].Text;
				

				DropDownList dl3 = (DropDownList)gr_dato.Rows[i].FindControl("dl_financiera");

				string financiera = dl3.SelectedValue.ToString();
				

				

				add_MU = new ClienteBC().add_clientefinanciera(Convert.ToInt16(id_cliente), financiera);


		

		}
		}


	}
}