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
	public partial class reporteador : System.Web.UI.Page
	{

        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    int i;
        //    GridViewRow row;
        //    ImageButton but;
          
        //    for (i = 0; i < gr_dato.Rows.Count; i++)
        //    {
        //        row = gr_dato.Rows[i];

        //        string id_report = gr_dato.DataKeys[i].Values[0].ToString();

        //        Informe minforme = new InformeBC().getinformebyid(Convert.ToInt16(id_report));
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {

        //            but = (ImageButton)row.FindControl("ib_excel");
        //            but.Attributes.Add("onclick", "carga_excel(" + minforme.Sp_informe.Trim() + "," + minforme.Descripcion.Trim() + ");");
                    
        //        }
        //    }
        //}

        //protected void GridViewRowEventHandler(Object sender, GridViewRowEventArgs e)
        //{

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string id_report = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
        //        Informe minforme = new InformeBC().getinformebyid(Convert.ToInt16(id_report));
        //        //e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";

        //        if (minforme.Sp_informe != "" && minforme.Sp_informe != null && minforme.Sp_informe.ToString().Trim() != "sp_r_nomina_general"
        //            && minforme.Sp_informe.ToString().Trim() != "sp_r_solicituddespachoescrituras" && minforme.Sp_informe.ToString().Trim() != "sp_r_infform28scotiabank")
        //        {
        //            carga_excel(minforme.Sp_informe.Trim(), minforme.Descripcion.Trim());
        //        }
        //    }

        //}

        protected void ContactsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excel")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gr_dato.Rows[index];

                int Id = Convert.ToInt16(this.gr_dato.DataKeys[index]["id_informe"]);

                Informe minforme = new InformeBC().getinformebyid(Convert.ToInt16(Id));
                if (minforme.Sp_informe != "" && minforme.Sp_informe != null && minforme.Sp_informe.ToString().Trim() != "sp_r_nomina_general"
                    && minforme.Sp_informe.ToString().Trim() != "sp_r_solicituddespachoescrituras" && minforme.Sp_informe.ToString().Trim() != "sp_r_infform28scotiabank")
                {
                    carga_excel(minforme.Sp_informe.Trim(), minforme.Descripcion.Trim());
                }
            }
        }


        protected void carga_excel(string sp_informe,string titulo)
        {
            string desde = string.Format("{0:yyyyMMdd}",DateTime.Now);
            string hasta = string.Format("{0:yyyyMMdd}",DateTime.Now);
            if (this.txt_desde.Text.Trim() != "")
            {
                 desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
            }
            if (this.txt_hasta.Text.Trim() != "")
            {
                 hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
            }
            int sucursal = 0;
            int ciudad = 0;
            int id_solicitud = 0;
            int id_familia = 0;
            string id_codigo = "0";

            int id_cliente = 0;
            if (this.dl_sucursal.SelectedValue.ToString() != "")
                sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
            if (this.dl_ciudad.SelectedValue.ToString() != "")
                ciudad = Convert.ToInt16(this.dl_ciudad.SelectedValue);
            if (this.dl_cliente.SelectedValue.ToString() != "")
                id_cliente = Convert.ToInt32(this.dl_cliente.SelectedValue.ToString());

            if (this.txt_operacion.Text.Trim() != "")
                id_solicitud = Convert.ToInt32(this.txt_operacion.Text);

            if (this.dl_familia.SelectedValue.ToString() != "")
                id_familia = Convert.ToInt16(this.dl_familia.SelectedValue.ToString());

            if (this.dl_producto.SelectedValue.ToString() != "")
                id_codigo = this.dl_producto.SelectedValue.ToString();

            string add = "";
            add = new MatrizExcelBC().getmatrizinforme(desde, hasta, Session["usrname"].ToString(), sp_informe, this.dl_producto.SelectedValue, 0, sucursal, id_cliente,
                                                        id_solicitud, 0, 0, this.txt_cliente.Text.Trim(), this.txt_patente.Text.Trim(), 0, 0, 0, ciudad, id_familia,titulo);

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(Page,Page.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", strAlerta, true);


            return;
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
				List<Informe> lInforme = new InformeBC().getInformeByUsuario(musuario.Codigoperfil);

				this.gr_dato.DataSource = lInforme;
				this.gr_dato.DataBind();

				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combofamilia_producto(this.dl_familia);
				FuncionGlobal.comboregion(this.dl_region, "CH");
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
            

			string reporte;
			int fila;
			int sucursal = 0;
			int ciudad = 0;
			int id_solicitud = 0;
			int id_familia = 0;
			string id_codigo = "0";

			string id_cliente = "";
			if (this.dl_sucursal.SelectedValue.ToString() != "")
				sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			if (this.dl_ciudad.SelectedValue.ToString() != "")
				ciudad = Convert.ToInt16(this.dl_ciudad.SelectedValue);
            if(this.dl_cliente.SelectedValue.ToString() !="")
                id_cliente = this.dl_cliente.SelectedValue.ToString();

			if (this.txt_operacion.Text.Trim() != "")
				id_solicitud = Convert.ToInt32(this.txt_operacion.Text);
			fila = ((GridView)sender).SelectedRow.RowIndex;
			reporte = ((GridView)sender).DataKeys[fila].Values[1].ToString();

			if (this.dl_familia.SelectedValue.ToString() != "")
				id_familia = Convert.ToInt16(this.dl_familia.SelectedValue.ToString());

			if (this.dl_producto.SelectedValue.ToString() != "")
				id_codigo = this.dl_producto.SelectedValue.ToString();

		
			string id_report = ((GridView)sender).DataKeys[fila].Values[0].ToString();
			//if (id_report == "20" || id_report == "22" || id_report == "24")
			if (id_report == "20" || id_report == "22" )
            {
                string cadena = "";
                cadena += "?nombre_rpt=" + reporte;
                cadena += "&id_solicitud=" + id_solicitud.ToString();
                cadena += "&id_cliente=" + id_cliente.ToString();
                cadena += "&id=" + id_report;
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('view_report_transferencia.aspx" + cadena + "'); </script>");
   
            }
            else
            {
                
                string cadena = "";
                cadena += "?nombre_rpt=" + reporte;
                cadena += "&tipo_operacion=" + this.dl_producto.SelectedValue;
                cadena += "&id_modulo=0";
                cadena += "&id_sucursal=" + sucursal.ToString();
                cadena += "&id_cliente=" + this.dl_cliente.SelectedValue;
                cadena += "&id_solicitud=" + id_solicitud.ToString();
                cadena += "&rut_adquiriente=0";
                cadena += "&numero_factura=0";
                cadena += "&numero_cliente=" + this.txt_cliente.Text.Trim();
                cadena += "&patente=" + this.txt_patente.Text.Trim();
                cadena += "&desde=" + string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
                cadena += "&hasta=" + string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
                cadena += "&ultimo_estado=0";
                cadena += "&folio=0";
                cadena += "&id_nomina=0";
				cadena += "&id_ciudad=" + ciudad.ToString();
				cadena += "&id_familia=" + id_familia;

				ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "window.open('view_report_agp.aspx" + cadena + "');", true);

            }
		}



		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e) { }

		private void getestado(string tipo, DropDownList combo)
		{
			EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();

			mEstadotipooperacion.Codigo = "0";
			mEstadotipooperacion.Descripcion = "Seleccionar";

			List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionBC().getEstadoByTipooperacion(tipo);
			lEstadotipooperacion.Add(mEstadotipooperacion);

			combo.DataSource = lEstadotipooperacion;
			combo.DataValueField = "codigo_estado";
			combo.DataTextField = "descripcion";
			combo.DataBind();
			combo.SelectedValue = "0";
			return;
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_producto.SelectedValue != "0")
			{
				this.lbl_flujo.Visible = true;
				this.dpl_estado.Visible = true;
				getestado(this.dl_producto.SelectedValue, this.dpl_estado);
			}
			else
			{
				this.lbl_flujo.Visible = false;
				this.dpl_estado.Visible = false;
			}
		}

		protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void dl_Region_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(dl_region.SelectedValue.ToString()));
		}

        //protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string reporte;
        //    int fila;
        //    int sucursal = 0;
        //    int ciudad = 0;
        //    int id_solicitud = 0;
        //    if (this.dl_sucursal.SelectedValue.ToString() != "")
        //        sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
        //    if (this.dl_ciudad.SelectedValue.ToString() != "")
        //        ciudad = Convert.ToInt16(this.dl_ciudad.SelectedValue);
        //    if (this.txt_operacion.Text.Trim() != "")
        //        id_solicitud = Convert.ToInt32(this.txt_operacion.Text);
        //    fila = ((GridView)sender).SelectedRow.RowIndex;
        //    reporte = ((GridView)sender).DataKeys[fila].Values[1].ToString();

        //    string cadena = "";
        //    cadena += "?nombre_rpt=" + e.CommandArgument;
        //    cadena += "&tipo_operacion=" + this.dl_producto.SelectedValue;
        //    cadena += "&id_modulo=0";
        //    cadena += "&id_sucursal=" + sucursal.ToString();
        //    cadena += "&id_cliente=" + this.dl_cliente.SelectedValue;
        //    cadena += "&id_solicitud=0";
        //    cadena += "&rut_adquiriente=0";
        //    cadena += "&numero_factura=0";
        //    cadena += "&numero_cliente=" + this.txt_cliente.Text.Trim();
        //    cadena += "&patente=" + this.txt_patente.Text.Trim();
        //    cadena += "&desde=" + string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
        //    cadena += "&hasta=" + string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
        //    cadena += "&ultimo_estado=0";
        //    cadena += "&folio=0";
        //    cadena += "&id_nomina=0";
        //    cadena += "&id_ciudad=" + ciudad.ToString();
        //    cadena += "&formato=" + e.CommandName;

        //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('view_report_agp.aspx" + cadena + "'); </script>");

        //}

        protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
        }
	}
}