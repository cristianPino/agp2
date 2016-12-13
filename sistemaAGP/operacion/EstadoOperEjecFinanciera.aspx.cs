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
    public partial class EstadoOperEjecFinanciera : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal, 10, (string)(Session["usrname"]));
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.cal_desde.FirstDayOfWeek = FirstDayOfWeek.Monday;
				this.cal_hasta.FirstDayOfWeek = FirstDayOfWeek.Monday;
				
				this.Crear_DataTable();
			}
		}

		

		protected void Limpiar_DataTable()
		{
			ViewState["dt"] = null;
			this.gr_dato.DataSource = null;
			this.gr_dato.DataBind();
		}

	
		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			this.Busca_Operacion();
		}

		protected void Busca_Operacion()
		{
			Int32 rut = 0;
			Int32 noperacion = 0;
            Int32 numero_cliente = 0;
			Int32 dl_sucursal = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
		

			if (this.txt_rut.Text.Trim() != "") rut = Convert.ToInt32(this.txt_rut.Text);
            if (this.txt_cliente.Text.Trim() != "") numero_cliente = Convert.ToInt32(this.txt_cliente.Text);
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			
			if (noperacion == 0 && this.chk_agrupar.Checked == true) return;

			this.txt_operacion.Focus();

			if (noperacion != 0 || numero_cliente != 0 )
			{
				desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
				hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			}
			if (noperacion == 0 && this.chk_agrupar.Checked == false)
			{
				ViewState["dt"] = null;
				this.Crear_DataTable();
			}

			if (ViewState["dt"] == null) this.Crear_DataTable();

			DataTable dt = (DataTable)ViewState["dt"];

			List<Operacion> loperacion = new List<Operacion>();
			loperacion = new OperacionBC().getOperacionescarpeta(dl_sucursal,noperacion,rut, desde, hasta, (string)(Session["usrname"]),numero_cliente);
            
//Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue), "TODO",0);


			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
				
				dr["numero_cliente"] = moperacion.Numero_cliente;
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
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo.Trim();
				dr["operacion"] = moperacion.Tipo_operacion.Operacion.ToString();
                dr["sucursal"] = moperacion.Sucursal.Nombre;
                dr["financiera"] = moperacion.Financiera;
				
				
				dr["url_digital"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&origen=eo";
                //dr["url_estado"] = "mWorkflow.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim());
				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void Crear_DataTable()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("nombre_cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("financiera"));
            dt.Columns.Add(new DataColumn("url_digital"));
            //dt.Columns.Add(new DataColumn("url_estado"));

			
			ViewState["dt"] = dt;
		}

		protected void txt_operacion_TextChanged(object sender, EventArgs e)
		{
			this.Busca_Operacion();
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txt_cliente_TextChanged(object sender, EventArgs e)
        {
            this.Busca_Operacion();
        }

		
    }
}