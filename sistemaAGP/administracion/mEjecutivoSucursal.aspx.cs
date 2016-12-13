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
    public partial class mEjecutivoSucursal : System.Web.UI.Page
    {
        private Int16 id_cliente;
		private Int16 id_familia;
		private string codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
			string id_usuario = ((string)(Session["usrname"]));
			if (!IsPostBack)
			{
				Usuario muser = new UsuarioBC().GetUsuario(id_usuario);

				int id_clientef = Convert.ToInt32(muser.Cliente.Id_cliente);

				FuncionGlobal.comboFinancieraClientefinanciera2(this.dl_cliente, id_clientef);
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			getallsucursales();
			


		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			add_usuariocliente();
		}

		private void add_usuariocliente()
		{

			GridViewRow row;

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

				string id_cliente = this.gr_dato.Rows[i].Cells[0].Text;

				if (chk.Checked == true)
				{

					string add = new FinancieraClienteFinancieraBC().add_bancofinancieracliente(Convert.ToInt16(id_cliente),this.dl_cliente.SelectedValue.ToString());

				}
				else
				{
					string add = new FinancieraClienteFinancieraBC().del_bancofinancieracliente(Convert.ToInt16(id_cliente), this.dl_cliente.SelectedValue.ToString());
				}

			}


		}


		public void getallsucursales()
		{
			DataTable dt2 = new DataTable();
			dt2.Columns.Add(new DataColumn("id_cliente"));

			dt2.Columns.Add(new DataColumn("nombre"));

			DataColumn col = new DataColumn("check");
			col.DataType = System.Type.GetType("System.Boolean");

			dt2.Columns.Add(col);

		

			
			List<ClienteFinanciera> lcliente = new ClienteBC().getclientesfinan();



			foreach (ClienteFinanciera mcliente in lcliente)
			{
				DataRow dr2 = dt2.NewRow();

				dr2["id_cliente"] = mcliente.Id_cliente;
				dr2["nombre"] = mcliente.Financiera;
				dr2["check"] = mcliente.Check;
				

				//dr2["check"] = mcliente. .Check;


				dt2.Rows.Add(dr2);
			}

			this.gr_dato.DataSource = dt2;
			this.gr_dato.DataBind();
			this.Button3.Visible = true;
		}
		protected void Button2_Click(object sender, EventArgs e)
		{

		}

		protected void bt_editar_Click(object sender, EventArgs e)
		{

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
		{
			this.gr_dato.EditIndex = e.NewEditIndex;
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
		}

		protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
		{

		}



        }

		
       
}
