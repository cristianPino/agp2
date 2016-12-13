using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
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
	public partial class mExportaEjecutivoSucursal : System.Web.UI.Page
    {
        private Int16 id_cliente;
		private Int16 id_familia;
		private string codigo;
		private string id_usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
			 id_usuario = ((string)(Session["usrname"]));
			if (!IsPostBack)
			{
				Usuario muser = new UsuarioBC().GetUsuario(id_usuario);

				int id_clientef = Convert.ToInt32(muser.Cliente.Id_cliente);

			//	FuncionGlobal.comboFinancieraClientefinanciera2(this.dl_cliente, id_clientef);
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			getallsucursales();
			


		}

		protected void Button1_Click(object sender, EventArgs e)
		{

			List<ClienteFinanciera> lcliente = new ClienteBC().getclientesfinantxt(id_usuario, Convert.ToDateTime(this.txt_desde.Text.ToString()), Convert.ToDateTime(this.txt_hasta.Text.ToString()));
            StreamWriter sw = new StreamWriter("D:\\Sistema\\Credito\\" + id_usuario + ".txt");

			foreach (ClienteFinanciera mcli in lcliente)
			{
				sw.WriteLine(mcli.Rutcliente+";"+mcli.Nombrecliente+";"+mcli.Fechafel+";"+mcli.Financiera+";"+mcli.Cliente.Persona.Nombre+";"+mcli.Sucursal.Nombre+";"+mcli.Url_carpeta);
			}

			sw.Close();
			
			this.Button1.Visible = false;
            this.HyperLink1.NavigateUrl = "../Credito/" + id_usuario + ".txt";
            this.HyperLink1.Visible = true;

		}

		private void add_usuariocliente()
		{

			


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

			
			
		}
	

		protected void bt_editar_Click(object sender, EventArgs e)
		{

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
		{
			
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			
		}

		protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
		{

		}



        }

		
       
}
