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
    public partial class mTiponomina : System.Web.UI.Page
    {
		Int16 id_fam;
		

		protected void Page_Load(object sender, EventArgs e)
        {

			
			string id_fam_encrip;

			id_fam_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

			id_fam = Convert.ToInt16(id_fam_encrip);

			//griddrop(id_fam);
			



		    if (!IsPostBack)
		    {


				buscar();

		//        //List<TipoNomina> lTiponomina = new TipoNominaBC().getTipoNominaByIdFamilia(id_fam);

		//        //this.gr_dato.DataSource = lTiponomina;
		//        //this.gr_dato.DataBind();
		//    }
		//}


		//protected void Button1_Click(object sender, EventArgs e)
		//{

		//    //if (valida_ingreso())
		//    //{

		//    //    add_tiponomina();

		//    //    List<TipoNomina> lTiponomina = new TipoNominaBC().getTiponomina();

		//    //    this.gr_dato.DataSource = lTiponomina;
		//    //    this.gr_dato.DataBind();

		//    //    limpiar();


		}
        }

		private void buscar()
		{

			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("id_nomina"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("folio"));
			dt.Columns.Add(new DataColumn("reporte"));
			DataColumn col = new DataColumn("checked");
			col.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(new DataColumn("dl_estado"));
			dt.Columns.Add(new DataColumn("dl_gasto"));
			





			dt.Columns.Add(col);

			List<TipoNomina> lnominafamilia = new TipoNominaBC().getTipoNominaByIdFamiliacheck(id_fam);



			foreach (TipoNomina mnominafamilia in lnominafamilia)
			{
				DataRow dr = dt.NewRow();


				dr["id_nomina"] = mnominafamilia.Id_nomina;
				dr["descripcion"] = mnominafamilia.Descripcion;

				dr["folio"] = mnominafamilia.Folio;
				dr["checked"] = mnominafamilia.Chek;
				dr["dl_estado"] = mnominafamilia.Codigo_estado;
                dr["dl_gasto"] = mnominafamilia.Id_tipogasto;
				dr["reporte"] = mnominafamilia.Reporte;
				dt.Rows.Add(dr);
				

			}


			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

        private void add_tiponomina()
        {



		  //  string add = new TipoNominaBC().add_tiponomina(this.txt_nombre.Text, );

		  //  FuncionGlobal.alerta("DOCUMENTO INGRESADA CON EXITO", this.Page);
		  ////  limpiar();
		  //  return;

        }


        private void limpiar()
        {

            //this.txt_nombre.Text = " ";


        }

       


        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

		protected void Button2_Click(object sender, EventArgs e)
		{
			{
				GridViewRow row;



				string add_MU = "";

				for (int i = 0; i < gr_dato.Rows.Count; i++)
				{

					row = gr_dato.Rows[i];


					//TextBox id_nomina = (TextBox)gr_dato.Rows[i].FindControl("id_nomina");
					//TextBox descripcion = (TextBox)gr_dato.Rows[i].FindControl("descripcion");
					string id_nomina = gr_dato.Rows[i].Cells[0].Text;
					
					CheckBox chk_aviso = (CheckBox)gr_dato.Rows[i].FindControl("chk");



					TextBox folio = (TextBox)gr_dato.Rows[i].FindControl("folio");
					TextBox reporte = (TextBox)gr_dato.Rows[i].FindControl("reporte");
					DropDownList dl = (DropDownList)gr_dato.Rows[i].FindControl("dl_estado");
					DropDownList dl2 = (DropDownList)gr_dato.Rows[i].FindControl("dl_gasto");
					//string FOLIO = gr_dato.Rows[i].Cells[2].Text;
					string descripcion = gr_dato.Rows[i].Cells[1].Text;
				//	string chk;

					string folio1 = folio.Text.ToString();

					string estado = dl.SelectedValue.ToString();
					string gasto = dl2.SelectedValue.ToString();
					//string nomina = id_nomina.Text.ToString();
					string descrip = descripcion;
					string reporte_1 = reporte.Text.ToString();
				//	string valor = row.Cells[0].Text;

					
					//string folio_1 = folio.Text.ToString();
					
					
					
					//string check = chk_aviso.Checked.ToString();

					

					
						add_MU = new TipoNominaBC().actualiza_tiponomina(descrip, reporte_1,Convert.ToInt16(estado),Convert.ToInt16(gasto),chk_aviso.Checked.ToString(),id_fam,Convert.ToInt32(folio1),Convert.ToInt32(id_nomina));

						//





				}
				//this.getestadoall();
				buscar();
			}

		}


        

		protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string add_MU = "";
			string estado = estado_dl.SelectedValue;
			string gasto = gasto_dl.SelectedValue;
			
			string descripcion = this.TextBox2.Text;
			string folio = this.TextBox3.Text;
			string reporte = this.TextBox4.Text;
			string check = this.CheckBox1.Checked.ToString();
			add_MU = new TipoNominaBC().actualiza_tiponomina(descripcion, reporte, Convert.ToInt16(estado), Convert.ToInt16(gasto), check, id_fam,Convert.ToInt32(folio),0);

			buscar();


		}


		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{

				EstadoTipoOperacion mestado = new EstadoTipoOperacion();
				mestado.Codigo_estado = 0;
				mestado.Descripcion = "Seleccionar";

				List<EstadoTipoOperacion> lestado = new EstadotipooperacionBC().getEstadoByFamilia(id_fam);

				lestado.Add(mestado);


				DropDownList dl2 = (DropDownList)e.Row.FindControl("dl_estado");

				dl2.DataSource = lestado;
				dl2.DataValueField = "codigo_estado";
				dl2.DataTextField = "descripcion";
				dl2.DataBind();
				//dl2.SelectedValue = "0";
				


				GastosComunes gastos = new GastosComunes();
				gastos.Id_tipogasto = 0;
				gastos.Descripcion = "seleccionar";
				List<GastosComunes> lgastos = new GastosComunesBC().getallGastosComunes(id_fam);
				lgastos.Add(gastos);
				DropDownList dl = (DropDownList)e.Row.FindControl("dl_gasto");

				dl.DataSource = lgastos;
				dl.DataValueField = "id_tipogasto";
				dl.DataTextField = "descripcion";
				dl.DataBind();

				//dl.SelectedValue = "0";
				FuncionGlobal.comboEstadoByFamilia(estado_dl, id_fam);
				FuncionGlobal.Combogasto(gasto_dl, id_fam);

				dl.SelectedValue = gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString();
				dl2.SelectedValue = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();

			}

		}

		protected void gastodl_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void estadodl_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void TextBox2_TextChanged(object sender, EventArgs e)
		{

		}




    }
}
