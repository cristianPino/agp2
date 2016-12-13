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
	public partial class carpeta_digital : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.txt_operacion.Focus();

			

			if (!IsPostBack)
			{
				crea_datatable();
			}

		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			busca_operacion();
		}

		public void crea_datatable()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("cod_tip_operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("cliente_nombre"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));
			dt.Columns.Add(new DataColumn("saldo"));
			dt.Columns.Add(new DataColumn("url_cargar"));

			if (Session["dt"] == null)
				Session.Add("dt", dt);
			else
				Session["dt"] = dt;
		}

		private void busca_operacion()
		{
			string operacion = "0";

			if (this.txt_operacion.Text != "")
			{
				operacion = this.txt_operacion.Text;
			}
			else
			{
				return;
			}

			List<Operacion> loperacion = new OperacionBC().getOperaciones("0",
																0,
																0,
																0,
																Convert.ToInt32(operacion),
																Convert.ToDouble(0),
																0,
																"0",
																"",
																"19910101",
																string.Format("{0:yyyyMMdd}", DateTime.Now),
																0,
																(string)(Session["usrname"]),
																0,
																"true",0,"","",0);
			if (Session["dt"] == null)
			{
				crea_datatable();
			}

			DataTable dt = (DataTable)Session["dt"];


			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();

				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["cliente_nombre"] = moperacion.Cliente.Persona.Nombre;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Operacion;
				dr["cod_tip_operacion"] = moperacion.Tipo_operacion.Codigo;
				dr["url_cargar"] = "../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=" + moperacion.Tipo_operacion.Codigo.Trim();
				if (moperacion.Adquiriente != null)
				{
					dr["rut_persona"] = moperacion.Adquiriente.Rut;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
				}
				else
				{
					dr["rut_persona"] = "0";
					dr["nombre_persona"] = "Sin Adquiriente";
				}

				dr["total_gasto"] = moperacion.Total_gasto;
				dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_egreso);
				dr["ultimo_estado"] = moperacion.Estado;
				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

			Carga_Link();
			this.txt_operacion.Text = "";
		}

		protected void Carga_Link()
		{
			int i;
			GridViewRow row;
			HyperLink but;
			ImageButton ibuton;
			string tipo;

			for (i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				int cont = gr_dato.DataKeys.Count;
				string cliente = gr_dato.DataKeys[i].Value.ToString();
				string cliente_id = gr_dato.DataKeys[i].Values[2].ToString();
				string tipo_operacion= gr_dato.DataKeys[i].Values[0].ToString();
				if (row.RowType == DataControlRowType.DataRow)
				{

					tipo = (string)row.Cells[2].Text;

					but = (HyperLink)row.Cells[0].Controls[0];



					string nombre_estado = (string)row.Cells[12].Text; ;






					ibuton = (ImageButton)row.FindControl("ib_cdigital");
					ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=eo','','status:false;dialogWidth:800px;dialogHeight:600px')");





				}
			}
		}



		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		//protected void Button3_Click(object sender, EventArgs e)
		//{
		//    if (Convert.ToInt32(this.dl_nomina.SelectedValue) > 0)
		//    {
		//        GridViewRow row;
		//        HyperLink but;

		//        Int32 folio = traerfolio(Convert.ToInt32(this.dl_nomina.SelectedValue));

		//        for (int i = 0; i < gr_dato.Rows.Count; i++)
		//        {
		//            row = gr_dato.Rows[i];

		//            but = (HyperLink)row.Cells[0].Controls[0];
		//            string id_solicitud = but.Text.Trim();

		//            string add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(id_solicitud), Convert.ToInt32(this.dl_nomina.SelectedValue), folio, Session["usrname"].ToString());

		//        }

		//        string upd = new TipoNominaBC().upd_FolioNomina(Convert.ToInt32(this.dl_nomina.SelectedValue));

		//        FuncionGlobal.alerta_updatepanel(string.Format("NOMINA Nº{0} GUARDADA CON EXITO", folio), this.Page, this.UpdatePanel4);

		//        this.Panel3.Visible = false;

		//    }
		//    else
		//    {
		//        FuncionGlobal.alerta_updatepanel("Debe selecionar un tipo de nomina", this.Page, this.UpdatePanel4);
		//    }

		//    return;

		//}

		//public Int32 traerfolio(Int32 id_nomina)
		//{
		//    TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(id_nomina);
		//    Int32 folio = Convert.ToInt32(lTiponomina.Folio);
		//    return folio;
		//}

		

		

		protected void Click_Gasto(Object sender, EventArgs e)
		{
			busca_operacion();
		}

		//protected void dl_nomina_SelectedIndexChanged(object sender, EventArgs e)
		//{

		//}

		//protected void ib_nomina_Click(object sender, ImageClickEventArgs e)
		//{
		//    if (this.Panel3.Visible == true)
		//    {
		//        this.Panel3.Visible = false;

		//    }
		//    else
		//    {

		//        this.Panel3.Visible = true;
		//    }
		//}

		protected void txt_operacion_TextChanged(object sender, EventArgs e)
		{

			busca_operacion();
		}

		protected void chk_proceso_CheckedChanged(object sender, EventArgs e)
		{

			limpiar_tabla();
		}

		private void limpiar_tabla()
		{
			Session["dt"] = null;
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("cod_tip_operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("cliente_nombre"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));
			dt.Columns.Add(new DataColumn("saldo"));

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}


		protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			DataTable dt = (DataTable)Session["dt"];

			int index = Convert.ToInt32(e.RowIndex);

			string str_mivariable;

			//str_mivariable = (string)row.Cells[1].Text;
			str_mivariable = gr_dato.DataKeys[index].Values[1].ToString();

			foreach (DataRow dr_Fila in dt.Rows)
			{
				string id = dr_Fila["id_solicitud"].ToString();

				if (str_mivariable == id)
				{
					dr_Fila.Delete();
					this.gr_dato.DataSource = dt;
					this.gr_dato.DataBind();
					break;

				}
			}

		}

		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
		{

			gr_dato.EditIndex = e.NewEditIndex;

		}


	}
}