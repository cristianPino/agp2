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
    public partial class Control_TAG : System.Web.UI.Page
    {
        Usuario usu = new Usuario();
        
		protected void Page_Load(object sender, EventArgs e)
		{
            usu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            
			if (!IsPostBack)

			{
                 FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), dl_cliente);
                 FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.cal_desde.FirstDayOfWeek = FirstDayOfWeek.Monday;
				this.cal_hasta.FirstDayOfWeek = FirstDayOfWeek.Monday;

                FuncionGlobal.comboCodigo_TAGactivos(this.dl_tag_disponibles, 0);
                FuncionGlobal.comboCodigo_TAG(this.dl_Codigo_TAG);
                string count = "0";

                //count = this.dl_tag_disponibles.DataTextField.Count();
                //count = this.dl_tag_disponibles.DataMember.Count();
                count = this.dl_tag_disponibles.Items.Count.ToString();

                this.lbl_stock_tag.Text = count;

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
            Int16 id_cliente = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
		

			if (this.txt_rut.Text.Trim() != "") rut = Convert.ToInt32(this.txt_rut.Text);
            if (this.dl_Codigo_TAG.SelectedValue != "0") numero_cliente = Convert.ToInt32(this.dl_Codigo_TAG.SelectedValue);
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
            if (this.dl_cliente.SelectedValue != "") id_cliente = Convert.ToInt16(this.dl_cliente.SelectedValue);
			
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
            loperacion = new OperacionBC().getOperacionesTAG(dl_sucursal, noperacion, rut, desde, hasta, (string)(Session["usrname"]), numero_cliente, id_cliente);
            
//Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue), "TODO",0);

            
			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Id_cliente;
				dr["nombre_cliente"] = moperacion.Nom_cliente;
                dr["Nº_AGP_Origen"] = moperacion.Total_gasto;
                dr["usuario_solicitud"] = moperacion.Usuario.Nombre;
                dr["fecha_solicitud"] = moperacion.Fecha_solicitud;

                dr["patente"] = moperacion.Patente;
			
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
				dr["tipo_operacion"] = moperacion.Codigo_operacion.Trim();
				dr["operacion"] = moperacion.Producto.ToString();
                dr["sucursal"] = moperacion.Nom_sucursal;
                dr["Serie_Tag"] = moperacion.Numero_cliente;
                dr["estado"] = moperacion.Estado;
                dr["url_comgastos"] = "../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar("24");
                dr["url_cargar"] = "../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=" + moperacion.Codigo_operacion.Trim();
				dr["url_digital"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&origen=pc";
                 
                
                if (usu.Cliente.Id_cliente == 1)
                {
                    dr["url_estado"] = "mOperacion_estado.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(moperacion.Codigo_operacion.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&nombre_estado=" + moperacion.Producto.ToString();
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
            dt.Columns.Add(new DataColumn("Nº_AGP_Origen"));
            dt.Columns.Add(new DataColumn("usuario_solicitud"));
            dt.Columns.Add(new DataColumn("fecha_solicitud"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("estado"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("Serie_Tag"));
            dt.Columns.Add(new DataColumn("url_estado"));
            dt.Columns.Add(new DataColumn("url_comgastos"));
            dt.Columns.Add(new DataColumn("url_cargar"));
            dt.Columns.Add(new DataColumn("url_digital"));


			
			ViewState["dt"] = dt;
		}


        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int cliente;
                string tipo = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string patente = this.gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();
                Int16 id_cliente = Convert.ToInt16(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());

                HyperLink but = (HyperLink)e.Row.Cells[0].Controls[0];
                TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

               
                if(usu.Cliente.Id_cliente == 1)
                {
                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&patente=" + patente + "&ventatipo=&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar("0") + "','_blank','" + op.Tamano + "')");
                    //but.Attributes.Add("onclick", "javascript:window.opener.location.reload()");
                    //but.Attributes.Add("onclick", "javascript:window.close()");
                }
            }
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

        protected void btn_carga_tag_Click(object sender, EventArgs e)
        {
            if (this.txt_solicitud.Text != "" && this.txt_patente.Text != "")
            {
                string add = new Codigo_TAGBC().add_Control_TAG(this.txt_patente.Text, Convert.ToInt32(this.txt_solicitud.Text), "1", (string)(Session["usrname"]));

                if (add.Trim() != "OK" && add.Trim() != "")
                {
                    FuncionGlobal.alerta_updatepanel(add, Page, up_grilla);
                    return;
                }
                else
                {
                    FuncionGlobal.alerta_updatepanel("Control de TAG cargado con exito", this.Page, this.up_grilla);
                }
            }
            else
            {
                FuncionGlobal.alerta_updatepanel("Falta colocar Nº Op. AGP y Patente", this.Page, this.up_grilla);
            }
            
        }

        protected void btn_baja_tag_Click(object sender, EventArgs e)
        {
            if (this.txt_solicitud.Text != "" && this.txt_patente.Text != "")
            {
                string add = new Codigo_TAGBC().add_Control_TAG(this.txt_patente.Text, Convert.ToInt32(this.txt_solicitud.Text), "0",(string)(Session["usrname"]));

                if (add != "OK")
                {
                    FuncionGlobal.alerta_updatepanel(add, Page, up_grilla);
                    return;
                }

                else
                {
                    FuncionGlobal.alerta_updatepanel("Devolucion de TAG cargado con exito", this.Page, this.up_grilla);
                }

               
            }

            if (this.txt_solicitud.Text == "" && this.txt_patente.Text != "")
            {
                TipoOperacion tip = new TipooperacionBC().getTipooperacion("DTAG");
             

                this.btn_baja_tag.Attributes.Add("onclick", "javascript:window.showModalDialog('" + tip.Url_operacion + "fDded4a93u2d" + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(usu.Cliente.Id_cliente.ToString()) + "&ventatipo=" + "" + "&patente=" + this.txt_patente.Text + "','_blank','" + tip.Tamano + "')");
            }
           
        }

        protected void dl_Codigo_TAG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
        }

		
    }
}