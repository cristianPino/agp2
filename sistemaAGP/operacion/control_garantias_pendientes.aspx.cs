using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class control_garantias_pendientes : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			busca_operacion();
		}

		private void busca_operacion()
		{
			double rut = 0;
			Int32 factura = 0;
			Int32 noperacion = 0;
			Int16 dl_modulo = 0;
			Int16 dl_sucursal = 0;
			string desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
			string hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			string patente = this.txt_patente.Text.Trim();

			if (this.txt_rut.Text.Trim() != "") rut = Convert.ToDouble(this.txt_rut.Text);
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.txt_factura.Text.Trim() != "") factura = Convert.ToInt32(this.txt_factura.Text);
			if (this.dl_modulo.SelectedValue != "") dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("nombre_cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("p_completado"));

			List<Operacion> loperacion = new OperacionBC().getOperacionesGA_Pendientes("0", dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, (string)(Session["usrname"]));
			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
				dr["operacion"] = moperacion.Tipo_operacion.Operacion;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["rut_persona"] = string.Format("{0:N0}-{1}", moperacion.Adquiriente.Rut, moperacion.Adquiriente.Dv.ToUpper());
				dr["nombre_persona"] = (moperacion.Adquiriente.Nombre + ' ' + moperacion.Adquiriente.Apellido_paterno + ' ' + moperacion.Adquiriente.Apellido_materno).Trim().ToUpper();
				dr["p_completado"] = moperacion.P_completado;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				string sol = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
				string cli = gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString();
				string tipo = gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();
				string porcentaje = gr_dato.DataKeys[e.Row.RowIndex].Values[3].ToString();
				HyperLink but = (HyperLink)e.Row.Cells[0].Controls[0];
				TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);
				but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(sol) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(cli) + "','_blank','dialogheight=600px;dialogWidth=850px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')");

				ImageButton ibutton = (ImageButton)e.Row.FindControl("ib_cargar");
				ibutton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(sol) + "&tipo=" + tipo + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

				ibutton = (ImageButton)e.Row.FindControl("ib_cdigital");
				ibutton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(sol) + "&origen=pc','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");

				Image img = (Image)e.Row.FindControl("imgProgreso");
				img.ImageUrl = "../barra_progreso.aspx?porcentaje=" + porcentaje;
			}
			else if (e.Row.RowType == DataControlRowType.Header)
			{
				e.Row.Cells[5].ColumnSpan = 2;
				e.Row.Cells[6].Visible = false;
			}
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(this.gr_dato);
		}
	}
}