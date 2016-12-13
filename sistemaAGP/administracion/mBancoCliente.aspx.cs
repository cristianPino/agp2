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

	public partial class mBancoCliente : System.Web.UI.Page
	{

		Int16 cliente_bus;
		string id_cliente_str;
		string cliente_des;

		protected void Page_Load(object sender, EventArgs e)
		{

			id_cliente_str = Request.QueryString["id"].ToString();
			cliente_des = FuncionGlobal.FuctionDesEncriptar(id_cliente_str);
			cliente_bus = Convert.ToInt16(cliente_des);
			
			if (!IsPostBack)
			{

                getbancos();
			}

		}

		private void getbancos()
		{

			DataTable dt = new DataTable();
			dt.Columns.Add("codigo_banco");
			dt.Columns.Add("nombre");
		//	dt.Columns.Add("id_cliente");
		//	dt.Columns.Add("rut");
			
			DataColumn col = new DataColumn("check");
			col.DataType = System.Type.GetType("System.Boolean");
			
			dt.Columns.Add(col);

            List<BancoCliente> lbancocliente = new BancoClienteBC().getbancobycliente(cliente_bus.ToString());


			foreach (BancoCliente bancocliente in lbancocliente)
			{
				DataRow dr = dt.NewRow();

				dr["codigo_banco"] = bancocliente.Codigo_banco;
				dr["nombre"] = bancocliente.Nombre;
				dr["check"] = bancocliente.Check.ToString();

				dt.Rows.Add(dr);

			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
		protected void Button1_Click(object sender, EventArgs e)
		{

			GridViewRow row;

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("check");
				string codigo = this.gr_dato.Rows[i].Cells[0].Text;
				int id_cliente = cliente_bus;
				
				if (chk.Checked == true)
				{

					string add = new  BancoClienteBC().add_banco_cliente(codigo, id_cliente);

				}

				else
				{

					string add = new BancoClienteBC().del_banco_cliente(codigo, id_cliente);

				}
			}
		}

	}
}