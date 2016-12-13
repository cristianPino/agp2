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
namespace sistemaAGP {
	public partial class mGestionControl : System.Web.UI.Page {

		private string id_solicitud;
		private string id_cliente;

		protected void Page_Load(object sender, EventArgs e) {
			if (this.lbl_numero.Text != "") {
                //carga_rpt(Convert.ToInt32(this.lbl_numero.Text));
			}

            this.Datosvendedor.OnClickDireccion += new wucBotonEventHandler(Datosvendedor_OnClickDireccion);
            this.Datosvendedor.OnClickTelefono += new wucBotonEventHandler(Datosvendedor_OnClickTelefono);
            this.Datosvendedor.OnClickCorreo += new wucBotonEventHandler(Datosvendedor_OnClickCorreo);
            this.Datosvendedor.OnClickParticipante += new wucBotonEventHandler(Datosvendedor_OnClickParticipante);

			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
            this.txt_total.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");
            this.txt_monto_final.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");

			if (!IsPostBack) {
                FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(id_cliente), (string)(Session["usrname"]));
               
				this.lbl_operacion.Visible = false;
				this.lbl_numero.Visible = false;

				this.lbl_numero.Text = "0";

				this.lbl_operacion.Text = "";

                combotipoproductocliente();
                comboformapago();
                getreferencia(id_solicitud);
				this.busca_operacion();
			}
		}



		private void busca_operacion() {
            Control_gestion mcontrolgestion = new ControlGestionBC().getcontrolgestionbysolicitud(Convert.ToInt32(id_solicitud));

            if (mcontrolgestion != null)
            {

				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;
                this.ib_mas.Enabled = true;
				this.lbl_operacion.Text = "Operación de Control y Gestion Numero:";
                this.lbl_numero.Text = Convert.ToString(mcontrolgestion.Id_solicitud.Id_solicitud);
                this.txt_total.Text = mcontrolgestion.Total_gestion.ToString();
                this.txt_ncuotas.Text = mcontrolgestion.Numero_cuotas.ToString();
                this.txt_noperacion.Text = mcontrolgestion.Numero_operacion.ToString();
                string fecha2 = string.Format("{0:dd/MM/yyyy}", mcontrolgestion.Fecha_gestion);
                if (fecha2 != "01/01/1900")
                {
                    this.txt_fecha_gestion.Text = fecha2;
                }
                else
                {
                    this.txt_fecha_gestion.Text = "";
                }
                this.dl_producto_Cliente.SelectedValue = mcontrolgestion.Id_producto_cliente.Id_producto_cliente.ToString();
                this.dl_sucursal_origen.SelectedValue = mcontrolgestion.Id_sucursal.Id_sucursal.ToString();
                this.txt_observacion.Text = mcontrolgestion.Observacion.ToString();
                this.dl_forma_pago.SelectedValue = mcontrolgestion.Id_forma_pago.Id_forma_pago.ToString();
                this.txt_patente.Text = mcontrolgestion.Patente;
                this.txt_monto_final.Text = mcontrolgestion.Monto_final.ToString();
                if (mcontrolgestion.Rut_vendedor != null)
                {
                    this.chk_vendedor.Checked = true;
                    this.Datosvendedor.Visible = true;
                    this.Datosvendedor.Mostrar_Form(mcontrolgestion.Rut_vendedor.Rut);
                 
                }
				//**adquiriente

                if (mcontrolgestion.Rut.Rut != 0)
                {
                    busca_persona(mcontrolgestion.Rut.Rut);
                    this.txt_rut_deudor.Text = mcontrolgestion.Rut.Rut.ToString();
				}
                mcontrolgestion = null;
                carga_link();
                this.ib_correo.Enabled = true;
                this.ib_direccion.Enabled = true;
                this.ib_telefono.Enabled = true;
                
			}
		}

		protected void txt_rut_deudor_Leave(object sender, EventArgs e) {
			this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut_deudor.Text);

			busca_persona(Convert.ToDouble(this.txt_rut_deudor.Text));

    		this.txt_nombre_deudor.Focus();
            carga_link();
            this.ib_correo.Enabled = true;
            this.ib_direccion.Enabled = true;
            this.ib_telefono.Enabled = true;
		}
        private void combotipoproductocliente()
        {

            ProdCliente mprocliente= new ProdCliente();

            mprocliente.Id_producto_cliente = 0;
            mprocliente.Nombre = "Seleccionar";

            List<ProdCliente> lprocliente= new ProdClienteBC().getprodcliente(Convert.ToInt32(id_cliente));

            lprocliente.Add(mprocliente);

            this.dl_producto_Cliente.DataSource = lprocliente;
            this.dl_producto_Cliente.DataValueField = "id_producto_cliente";
            this.dl_producto_Cliente.DataTextField = "nombre";
            this.dl_producto_Cliente.DataBind();
            this.dl_producto_Cliente.SelectedValue = "0";


        }
        protected void Datosvendedor_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }
        protected void Datosvendedor_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void Datosvendedor_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void Datosvendedor_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }
        private void comboformapago()
        {

            FormaPago mformapago= new FormaPago();

            mformapago.Id_forma_pago= 0;
            mformapago.Descripcion = "Seleccionar";

            List<FormaPago> lformapago= new FormaPagoBC().getformapagobycliente(Convert.ToInt32(id_cliente));

            lformapago.Add(mformapago);

            this.dl_forma_pago.DataSource = lformapago;
            this.dl_forma_pago.DataValueField = "id_forma_pago";
            this.dl_forma_pago.DataTextField = "descripcion";
            this.dl_forma_pago.DataBind();
            this.dl_forma_pago.SelectedValue = "0";


        }
	

	
		private void busca_persona(double rut) {

			Persona mpersona = new PersonaBC().getpersonabyrut(rut);

			if (mpersona != null) {

				this.txt_rut_deudor.Enabled = false;
				this.txt_dv.Enabled = false;

				this.txt_nombre_deudor.Text = mpersona.Nombre;
                this.txt_materno.Text = mpersona.Apellido_materno;
                this.txt_paterno.Text = mpersona.Apellido_paterno;
			    
				this.txt_dv.Text = mpersona.Dv;
		
			
			} else {
				this.txt_dv.Focus();
			}
            getreferencia(id_solicitud);
		}

		protected void bt_limpia_persona_Click(object sender, EventArgs e) {
			this.txt_rut_deudor.Enabled = true;
			this.txt_rut_deudor.Text = "";
			this.txt_dv.Text = "";
			this.txt_nombre_deudor.Text = "";
			
		
    		this.txt_rut_deudor.Focus();
		}

		
		protected void btnAceptar_Click(object sender, EventArgs e) {
			if (valida_ingreso() == true) {
				add_operacion();
			}
		}


       
        private void carga_link()
        {
            double rut_deudor = 0;
            if (this.txt_rut_deudor.Text == "") { rut_deudor = 0; }
            else
            {
                rut_deudor = Convert.ToDouble(this.txt_rut_deudor.Text);
                string persona = new PersonaBC().add_personaCG(Convert.ToDouble(this.txt_rut_deudor.Text),
                                                                 this.txt_dv.Text,
                                                                    1,
                                                                    "",
                                                                    this.txt_nombre_deudor.Text,
                                                                    this.txt_paterno.Text,
                                                                    this.txt_materno.Text,
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "0",
                                                                    "0",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "0");
            }
            this.ib_direccion.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mDireccion.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut_deudor.Text.Trim()) +  "','','status:false;dialogWidth:500px;dialogHeight:300px')");
            this.ib_telefono.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mTelefonos.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut_deudor.Text.Trim()) +  "','','status:false;dialogWidth:400px;dialogHeight:300px')");
            this.ib_correo.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mCorreo.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut_deudor.Text.Trim()) + "','','status:false;dialogWidth:400px;dialogHeight:300px')");

        }


        private void add_operacion()
        {
            double rut_deudor = 0;
            GridViewRow row;
            string rutvend = "0";
            Int32 monto_final = 0;
            DateTime fecha = Convert.ToDateTime("01/01/1900"); 
            if (this.Datosvendedor.Guardar_Form())
            {
                if (this.Datosvendedor.InfoPersona != null)
                {
                    rutvend = this.Datosvendedor.InfoPersona.Rut.ToString();
                }
            }

            if (this.txt_rut_deudor.Text == "") { rut_deudor = 0; }
            else
            {
                rut_deudor = Convert.ToDouble(this.txt_rut_deudor.Text);
                string persona = new PersonaBC().add_personaCG(Convert.ToDouble(this.txt_rut_deudor.Text),
                                                                 this.txt_dv.Text,
                                                                    1,
                                                                    "",
                                                                    this.txt_nombre_deudor.Text,
                                                                    this.txt_paterno.Text,
                                                                    this.txt_materno.Text,
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "0",
                                                                    "0",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "",
                                                                    "0");
            }



            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(id_cliente), "SGI", (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),0);
            if (this.txt_monto_final.Text != "")
            {
                monto_final = Convert.ToInt32(this.txt_monto_final.Text);
            }
            if (this.txt_fecha_gestion.Text != "")
            {
                fecha =Convert.ToDateTime(this.txt_fecha_gestion.Text);
            }
            string addI_CTG = new ControlGestionBC().add_controlgestion(add,
                                                                          Convert.ToInt32(this.txt_rut_deudor.Text),
                                                                          Convert.ToInt32(this.dl_producto_Cliente.SelectedValue),
                                                                          Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_total.Text)),
                                                                          fecha,
                                                                          Convert.ToInt32(this.txt_ncuotas.Text),
                                                                          this.txt_noperacion.Text, Convert.ToInt32(this.dl_sucursal_origen.SelectedValue.ToString()),
                                                                          this.txt_observacion.Text,
                                                                          Convert.ToInt32(this.dl_forma_pago.SelectedValue.ToString()),
                                                                          Convert.ToInt32(rutvend),this.txt_patente.Text,monto_final
                                                                          );



            string add_SGI = "";
            string del_SGI = "";
            if (add != 0)
            {
                del_SGI = new DatoContactoBC().del_DatoContacto(add);
                for (int i = 0; i < gr_dato.Rows.Count; i++)
                {

                    row = gr_dato.Rows[i];
                    TextBox txt_referencia = (TextBox)gr_dato.Rows[i].FindControl("txt_referencia");

                    add_SGI = new DatoContactoBC().add_DatoContacto(add,
                                                                    txt_referencia.Text
                                                                      );
                }

                if (add_SGI == "")
                {
                    string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, "SGI", "", (string)(Session["usrname"]));
                }



            }
                this.lbl_operacion.Visible = true;
                this.lbl_numero.Visible = true;
                this.ib_mas.Enabled = true;
                this.lbl_operacion.Text = "Operación de Gestion y Control Numero:";
                this.lbl_numero.Text = Convert.ToString(add);
                getreferencia(Convert.ToString(add));
                //carga_rpt(add);

            
        }

		protected void Button2_Click(object sender, EventArgs e) {
			this.lbl_numero.Text = "0";
			this.lbl_operacion.Text = "";
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

		private Boolean valida_ingreso() {
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            if (this.txt_rut_deudor.Text == "" || this.dl_producto_Cliente.SelectedValue.ToString() == "0" || this.dl_forma_pago.SelectedValue.ToString() == "0")
            {
                FuncionGlobal.alerta_updatepanel("INGRESE LOS DATOS CORRESPONDIENTES", Page, up);
				return false;
			}
			return true;
		}
        public void getreferencia(string solicitud)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("referencia"));
          
      


            List<DatoContacto> ldatocontacto= new DatoContactoBC().getdatocontactobysolicitud(Convert.ToInt32(solicitud));

            if (ldatocontacto.Count > 0)
            {
                this.bt_guardar.Visible = true;
            }

            foreach (DatoContacto mdatocontactoin in ldatocontacto)
            {
                DataRow dr = dt.NewRow();

                dr["referencia"] = mdatocontactoin.Referencia;
        
          

                dt.Rows.Add(dr);
            }


            DataRow draux = dt.NewRow();
            draux["referencia"] = "";

         

            dt.Rows.Add(draux);

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }



		protected void bt_guardar_Click(object sender, EventArgs e) {

		}


		protected void btnCancelar_Click(object sender, EventArgs e) {

		}

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void txt_direccion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_contacto1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ib_direccion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_telefono_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_correo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txt_rut_deudor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_producto_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ib_gasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bt_caratula_Click(object sender, EventArgs e)
        {

        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dl_sucursal_origen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
        protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("referencia"));

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                TextBox txt_referencia2 = (TextBox)gr_dato.Rows[i].FindControl("txt_referencia");
                dr["referencia"] = txt_referencia2.Text ;

                dt.Rows.Add(dr);
            }
          
            GridViewRow row;
          
                row = gr_dato.Rows[e.RowIndex];
                string str_mivariable;
                TextBox txt_referencia = (TextBox)row.FindControl("txt_referencia");
                str_mivariable = txt_referencia.Text;

                foreach (DataRow dr_Fila in dt.Rows)
                {
                    if (str_mivariable == dr_Fila["referencia"].ToString())
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
        protected void txt_referencia_Leave(object sender, EventArgs e)
        {

        }
        protected void txt_id_referencia_Leave(object sender, EventArgs e)
        {

        }
        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void ib_mas_Click(object sender, ImageClickEventArgs e)
        {
            


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("referencia"));

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                TextBox txt_referencia2 = (TextBox)gr_dato.Rows[i].FindControl("txt_referencia");
                dr["referencia"] = txt_referencia2.Text;

                dt.Rows.Add(dr);
            }

            DataRow draux = dt.NewRow();
            draux["referencia"] = "";

            dt.Rows.Add(draux);

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

            
        }

        protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_total_TextChanged(object sender, EventArgs e)
        {
            this.txt_total.Text = FuncionGlobal.NumeroConFormato(this.txt_total.Text);
        }

        protected void chk_vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_vendedor.Checked == true)
            {
                this.Datosvendedor.Visible = true;
            }
            else
                this.Datosvendedor.Visible = false;
        }

        protected void txt_patente_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_patente.Text.Trim() != "")
            {
                if (!FuncionGlobal.formatoPatente(this.txt_patente.Text))
                {
                    FuncionGlobal.alerta("La patente del vehiculo no cumple con el formato LLNNNN o LLLLNN", Page);
                    this.TextBox1.Text = "";
                    this.txt_patente.Focus();

                }
                else
                {
                    this.TextBox1.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);
                }
            }
        }

      


	}
}