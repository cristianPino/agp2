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
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;

namespace sistemaAGP
{
	public partial class mMarcavehiculo : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				List<Marcavehiculo> lMarcavehiculo = new MarcavehiculoBC().getallMarcavehiculo();
				this.gr_dato.DataSource = lMarcavehiculo;
				this.gr_dato.DataBind();
			}
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			int i;
			GridViewRow row;
			ImageButton but;
			for (i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				if (row.RowType == DataControlRowType.DataRow)
				{
					but = (ImageButton)row.FindControl("ib_modelo");
					if (but != null)
						but.Attributes.Add("onclick", "javascript:window.showModalDialog('mModelovehiculo.aspx?id_marca=" + FuncionGlobal.FuctionEncriptar(row.Cells[0].Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");
				}
			}
		}

		public void Button1_Click(object sender, EventArgs e)
		{
			if (valida_ingreso())
			{
				add_Marcavehiculo();
				List<Marcavehiculo> lMarcavehiculo = new MarcavehiculoBC().getallMarcavehiculo();
				this.gr_dato.DataSource = lMarcavehiculo;
				this.gr_dato.DataBind();
				limpiar();
			}
		}

		private void add_Marcavehiculo()
		{
			string add = new MarcavehiculoBC().add_Marcavehiculo(0, this.txt_nombre.Text);
			FuncionGlobal.alerta("MARCA DE VEHICULO INGRESADO CON EXITO", this.Page);
			limpiar();
			return;
		}

		private void limpiar()
		{
			this.txt_nombre.Text = "";
		}

		private Boolean valida_ingreso()
		{
			if (this.txt_nombre.Text == "")
			{
				FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
				return false;
			}
			return true;
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			limpiar();
		}
	}
}