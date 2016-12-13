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
    public partial class estado_operacion_hipoteca : System.Web.UI.Page
    {
        private Int32 semaforo = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.cal_desde.FirstDayOfWeek = FirstDayOfWeek.Monday;
				this.cal_hasta.FirstDayOfWeek = FirstDayOfWeek.Monday;
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
                FuncionGlobal.combofamiliabyusuario((string)Session["usrname"], this.dl_familia);
                
				this.Crear_DataTable();
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
			

			this.Limpiar_DataTable();
		}

		protected void Limpiar_DataTable()
		{
			ViewState["dt"] = null;
			this.gr_dato.DataSource = null;
			this.gr_dato.DataBind();
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Convert.ToInt16(this.dl_modulo.SelectedValue) == 0)
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
			else
				FuncionGlobal.combosucursalbymodulo(this.dl_sucursal, Convert.ToInt16(this.dl_modulo.SelectedValue));
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_producto.SelectedValue == "0")
				this.pnl_flujo.Style.Add("display", "none");
			else
				this.pnl_flujo.Style.Add("display", "inline");

			FuncionGlobal.comboestado(this.dpl_estado, this.dl_producto.SelectedValue.Trim());

			this.Limpiar_DataTable();
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			this.Busca_Operacion();
		}

		protected void Busca_Operacion()
		{
			double rut = 0;
			Int32 factura = 0;
			Int32 noperacion = 0;
			Int32 estado_actual = 0;
			Int16 dl_modulo = 0;
			Int16 dl_sucursal = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
			

			if (this.txt_rut.Text.Trim() != "") rut = Convert.ToDouble(this.txt_rut.Text);
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.dpl_estado.SelectedValue != "") estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue);
			if (this.dl_modulo.SelectedValue != "") dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			
			if (noperacion == 0 && this.chk_agrupar.Checked == true) return;

			this.txt_operacion.Text = "";
			this.txt_operacion.Focus();

			if (noperacion != 0 || factura != 0 )
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

            if (this.rb_blanco.Checked == true)
            {
                semaforo = 0;
            }
            if (this.rb_verde.Checked == true)
            {
                semaforo = 1;
            }
            if (this.rb_amarillo.Checked == true)
            {
                semaforo = 2;
            }
            if (this.rb_rojo.Checked == true)
            {
                semaforo = 3;
            }


			DataTable dt = (DataTable)ViewState["dt"];

			List<Operacion> loperacion = new List<Operacion>();
			loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue, dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), "", desde, hasta, estado_actual, (string)(Session["usrname"]),Convert.ToInt16(this.dl_familia.SelectedValue), "TODO",semaforo,"","",0);
            Usuario musu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));

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
				//dr["total_gasto"] = moperacion.Total_gasto;
				//dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_gasto);
                dr["id_estado"] = moperacion.Id_estado;
				dr["ultimo_estado"] = moperacion.Estado;
				dr["factura_emitida"] = moperacion.Factura_emitida;
				dr["sucursal"] = moperacion.Sucursal.Nombre.ToUpper().Trim();

                dr["semaforo"] = moperacion.Semaforo.Trim();
                dr["contador"] = moperacion.Contador.ToString().Trim() +"/"+moperacion.Total_dias.ToString().Trim();
			    dr["urlEstados"] = "../operacion/SubEstados.aspx?id_solicitud=" + moperacion.Id_solicitud + "&id_estado=" +
			                       moperacion.Id_estado;
                Tasador mtasa = new TasadorBC().tasadorbycuenta((string)(Session["usrname"]), moperacion.Cliente.Id_cliente);
                if (mtasa.Usu_tasador != null)
                {
                    dr["url_cargar"] = "../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=" + moperacion.Tipo_operacion.Codigo.Trim();
                    dr["url_tasador"] = "../Operacion_Hipotecario/mTasador.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
                    dr["url_contratos"] = "../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
                }
                else
                {

                    if (musu.Cliente.Id_cliente == 1)
                    {
                        dr["url_cargar"] = "../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=" + moperacion.Tipo_operacion.Codigo.Trim();
                        dr["url_digital"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&origen=eo";
                        dr["url_estado"] = "mWorkflow.aspx?&id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&nombre_estado=" + moperacion.Tipo_operacion.Operacion.ToString();
                      //  dr["url_comgastos"] = "../reportes/view_comprobante_cobro_ppu.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar("5");
                        dr["url_contratos"] = "../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
                        dr["url_tasador"] = "../Operacion_Hipotecario/mTasador.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
                        dr["url_escritura"] = "http://192.168.1.135/write_doc.asp?id_solicitud=" + (moperacion.Id_solicitud.ToString()); 


                    }
                    else
                    {
                        dr["url_digital"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&origen=eo";
                        dr["url_contratos"] = "../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
                        dr["url_cargar"] = "../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=" + moperacion.Tipo_operacion.Codigo.Trim();
                    }
                }
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
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("saldo"));
            dt.Columns.Add(new DataColumn("id_estado"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));
            dt.Columns.Add(new DataColumn("contador"));
            dt.Columns.Add(new DataColumn("semaforo"));
			dt.Columns.Add(new DataColumn("factura_emitida"));
			dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("url_cargar"));
			dt.Columns.Add(new DataColumn("url_digital"));
            dt.Columns.Add(new DataColumn("url_tasador"));
			dt.Columns.Add(new DataColumn("url_estado"));
			dt.Columns.Add(new DataColumn("url_comgastos"));
			dt.Columns.Add(new DataColumn("url_contratos"));
            dt.Columns.Add(new DataColumn("url_escritura"));
            dt.Columns.Add(new DataColumn("urlEstados"));
			ViewState["dt"] = dt;
		}

		protected void txt_operacion_TextChanged(object sender, EventArgs e)
		{
			this.Busca_Operacion();
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboProductobyfamilia(this.dl_producto,Convert.ToInt16(this.dl_familia.SelectedValue));
            this.pnl_flujo.Visible = true;
            this.dpl_estado.Visible = true;
            this.pnl_flujo.Style.Add("display", "inline");
            FuncionGlobal.comboEstadoByFamilia(this.dpl_estado,Convert.ToInt16(this.dl_familia.SelectedValue.Trim()));

            //this.rb_semaforo.Items.FindByText("rojo").Attributes.CssStyle.Add("style:", "color: black;font-weight:bold;");
            //this.rb_semaforo.Items.FindByText("verde").Attributes.CssStyle.Add("style", "background: red;");
            //this.rb_semaforo.Items.FindByText("amarilo").Attributes.CssStyle.Add("style", "background: white;");

            //this.rb_semaforo.Items.FindByText("verde").Attributes.CssStyle.Add("style", "background: green;"); 
            //this.rb_semaforo.Items.FindByText("amarillo").Attributes.CssStyle.Add("style", "background: white;"); 
            

        }

        protected void rb_verdechangen(object sender, EventArgs e)
        {
            this.rb_amarillo.Checked = false;
            this.rb_rojo.Checked = false;
            this.rb_blanco.Checked = false;
        }

        protected void rb_amarrillochangen(object sender, EventArgs e)
        {
            this.rb_verde.Checked = false;
            this.rb_rojo.Checked = false;
            this.rb_blanco.Checked = false;
        }

        protected void rb_rojochangen(object sender, EventArgs e)
        {
            this.rb_verde.Checked = false;
            this.rb_amarillo.Checked = false;
            this.rb_blanco.Checked = false;
        }
        protected void rb_blancochangen(object sender, EventArgs e)
        {
            this.rb_verde.Checked = false;
            this.rb_amarillo.Checked = false;
            this.rb_rojo.Checked = false;
        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
        }

	
    }
}