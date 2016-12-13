using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.preinscripcion
{
    public partial class TransYFacturaCompl : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["tipo_operacion"] = Request.QueryString["tipo_operacion"].ToString();

				this.Cambiar_Titulo();

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = ViewState["id_cliente"].ToString();
				this.dl_cliente.Enabled = false;
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

                FuncionGlobal.comboparametro(this.dl_forma_pago, "FOPA");
                FuncionGlobal.combobanco(this.dl_financiera, Convert.ToInt32(ViewState["id_cliente"].ToString()));
				if (this.dl_sucursal.Items.Count == 2)
				{
					this.dl_sucursal.SelectedIndex = 1;
				}

				this.Busca_Operacion();
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

	

		protected void Add_Operacion()
		{
			if (!this.agp_adquirente.Guardar_Form())
			{
				ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_adquirente", string.Format("alert('{0}');", this.agp_adquirente.MensajeError), true);
				return;
			}

            int add = new OperacionBC().add_operacion(Convert.ToInt32(ViewState["id_solicitud"]), Convert.ToInt16(ViewState["id_cliente"]), ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),Convert.ToInt32(this.txt_factura.Text));

            if (!this.agp_vehiculo.Guardar_Form(add))
            {
                ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_vehiculo", string.Format("alert('{0}');", this.agp_vehiculo.MensajeError), true);
                return;
            }
            Int32 factura = 0;
            if (this.txt_factura.Text != "")
            {
                factura =Convert.ToInt32(this.txt_factura.Text);
            }

			ViewState["id_solicitud"] = add.ToString();

			if (add != 0)
			{
                //string output = new PreinscripcionBC().add_preinscripcion(add, Convert.ToDouble(factura), "", "", "", "", "", "",
                //                                                    Convert.ToDouble(this.agp_adquirente.Rut), this.dl_financiera.SelectedValue, "SP", Convert.ToDouble(0),this.dl_forma_pago.SelectedValue , Convert.ToDouble(this.txt_neto.Text), "",
                //                                                    0, Convert.ToInt16(this.dl_sucursal.SelectedValue), Convert.ToInt16(this.dl_sucursal.SelectedValue),
                //                                                    Convert.ToDouble(0),Convert.ToDouble(0));

                string output = new TransferenciaBC().add_Transferencia(add, Convert.ToDouble(this.agp_adquirente.Rut), Convert.ToDouble(0),
                        Convert.ToDouble(0), Convert.ToInt32(this.dl_sucursal.SelectedValue), "", this.dl_financiera.SelectedValue, this.dl_forma_pago.SelectedValue);

				//Si hay un error guardando la operación
				if (output != "")
				{
					ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_add_PermySeg", string.Format("alert('{0}');", output), true);
					return;
				}

				string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "", (string)(Session["usrname"]));

				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;
				this.lbl_numero.Text = add.ToString("N0");
                this.ib_comgasto.Visible = true;
                this.ib_gasto.Visible = true;
                this.ib_poliza.Visible = true;
			}
		}

		protected void Busca_Operacion()
		{
			Preinscripcion solicitud = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(Convert.ToInt32(ViewState["id_solicitud"].ToString()));
			if (solicitud != null)
			{
				this.Carga_Operacion(solicitud.Operacion.Id_solicitud);
			}
            
		}

		protected void Busca_Operacion_Por_Patente()
		{
			DatosVehiculo solicitud = new DatosvehiculoBC().getDatovehiculobypatente(this.agp_vehiculo.Vehiculo.Patente);
			if (solicitud != null)
			{
				this.Carga_Operacion(solicitud.Id_solicitud);
			}
		}

		protected void Cambiar_Titulo()
		{
			this.lbl_titulo.Text = new TipooperacionBC().getTipooperacion(ViewState["tipo_operacion"].ToString()).Operacion;
		}

		protected void Carga_Operacion(Int32 solicitud)
		{
            Transferencia minscripcion = new TransferenciaBC().GettransferenciabyIdSolicitud(solicitud);
            DatosVehiculo mvehiculo = new DatosvehiculoBC().getDatovehiculo(solicitud);
			this.dl_sucursal.SelectedValue = minscripcion.Id_sucursal.ToString();
            this.txt_factura.Text = minscripcion.Operacion.Numero_factura.ToString();

			this.lbl_operacion.Visible = true;
			this.lbl_numero.Visible = true;
            //this.txt_neto.Text = minscripcion.Neto_factura.ToString();
			this.lbl_numero.Text = minscripcion.Operacion.Id_solicitud.ToString("N0");
            this.dl_financiera.SelectedValue = minscripcion.Banco_financiera.Codigo.Trim();
            this.dl_forma_pago.SelectedValue = minscripcion.Forma_pago.Trim();
            //this.agp_vehiculo.Vehiculo.Patente = mvehiculo.Patente;
            this.agp_vehiculo.Mostrar_Form(solicitud);

			this.agp_adquirente.Rut = minscripcion.Comprador.Rut;
			this.agp_adquirente.Mostrar_Form(minscripcion.Comprador.Rut);

            Familia_Producto mfamilia = new Familia_productoBC().getfamiliabycodigo(ViewState["tipo_operacion"].ToString());
            this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            this.ib_poliza.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mPoliza.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(ViewState["id_cliente"].ToString()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");
            this.ib_comgasto.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");

            this.ib_comgasto.Visible = true;
            this.ib_gasto.Visible = true;
            this.ib_poliza.Visible = true;

		}

        protected void txt_factura_TextChanged(object sender, EventArgs e)
        {
            Preinscripcion add = new PreinscripcionBC().Getpreinscripcionbyfactura(Convert.ToInt16(this.dl_cliente.SelectedValue), Convert.ToDouble(this.txt_factura.Text.Trim()));

            if (add!= null)
            {
                this.Carga_Operacion_factura(add.Operacion.Id_solicitud);
            }
        }

        protected void txt_neto_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void Carga_Operacion_factura(Int32 solicitud)
        {
            Preinscripcion minscripcion = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(solicitud);
            DatosVehiculo mvehiculo = new DatosvehiculoBC().getDatovehiculo(solicitud);
            this.dl_sucursal.SelectedValue = minscripcion.Sucursal_origen.Id_sucursal.ToString();
            this.txt_factura.Text = minscripcion.N_factura.ToString();

            this.agp_vehiculo.Mostrar_Form(solicitud);

            this.agp_adquirente.Rut = minscripcion.Adquiriente.Rut;
            this.agp_adquirente.Mostrar_Form(minscripcion.Adquiriente.Rut);

        }
        protected void ib_comgasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_gasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_poliza_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dl_forma_pago.SelectedValue == "1")
            {
                this.dl_financiera.SelectedValue = "CON";
            }
        }

        protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}