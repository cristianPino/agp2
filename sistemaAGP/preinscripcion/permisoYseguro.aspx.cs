using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.preinscripcion
{
    public partial class permisoYseguro : System.Web.UI.Page
	{
        public int IdOrdenTrabajo = 0;
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["tipo_operacion"] = Request.QueryString["tipo_operacion"].ToString();
                IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));
				this.Cambiar_Titulo();

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = ViewState["id_cliente"].ToString();
				this.dl_cliente.Enabled = false;
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

                //FuncionGlobal.comboparametro(this.dl_forma_pago, "FOPA");
                //FuncionGlobal.combobanco(this.dl_financiera, Convert.ToInt32(ViewState["id_cliente"].ToString()));
                FuncionGlobal.comboparametro(this.dl_cargo_venta, "CAVE");
				if (this.dl_sucursal.Items.Count == 2)
				{
					this.dl_sucursal.SelectedIndex = 1;
				}

				this.Busca_Operacion();
                hdIdOrdenTrabajo.Value = "0";
                if (IdOrdenTrabajo == 0) return;
                hdIdOrdenTrabajo.Value = IdOrdenTrabajo.ToString(CultureInfo.InvariantCulture);
                var otra = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);
                BuscaOrdenTrabajo(otra);
                agp_vehiculo.OrdenTrabajo = otra;
                agp_adquirente.Mostrar_Form(Convert.ToInt32(otra.RutAdquiriente));
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}

        protected void cmdLink_Click2(object sender, EventArgs e)
        {
            this.Add_Operacion();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Add_Operacion();
        }

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

	

		protected void Add_Operacion()
		{


            if (this.txt_fecha_factura.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Falta ingresar la fecha de Factura", this.Page, up_operacion);
                return;
            }
            if (this.dl_sucursal.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Falta ingresar la Sucursal", this.Page, up_operacion);
                return;
            }
            if (this.txt_neto.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Falta ingresar el Neto de la Factura", this.Page, up_operacion);
                return;
            }
            if (this.txt_factura.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Falta ingresar la Factura", this.Page, up_operacion);
                return;
            }


			if (!this.agp_adquirente.Guardar_Form())
			{
				ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_adquirente", string.Format("alert('{0}');", this.agp_adquirente.MensajeError), true);
				return;
			}

            int add = new OperacionBC().add_operacion(Convert.ToInt32(ViewState["id_solicitud"]), Convert.ToInt16(ViewState["id_cliente"]), ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);
            this.agpDatosGrabar.Id_solicitud = add;
            this.agpDatosGrabar.Carga_vent = Convert.ToInt32(this.dl_cargo_venta.SelectedValue.Trim());

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

            string neto = "0";

            if (this.txt_neto.Text != "")
            {
                neto = this.txt_neto.Text;
            }

			if (add != 0)
			{
                string output = new PreinscripcionBC().add_preinscripcion(add, Convert.ToDouble(factura), "", "", "", "",this.dl_cargo_venta.SelectedValue.ToString(),this.txt_fecha_factura.Text,
                                                                    Convert.ToDouble(this.agp_adquirente.Rut), "CON", "SP", Convert.ToDouble(0),"1" , Convert.ToDouble(neto), "",
                                                                    0, Convert.ToInt16(this.dl_sucursal.SelectedValue), Convert.ToInt16(this.dl_sucursal.SelectedValue),
                                                                    Convert.ToDouble(0),Convert.ToDouble(0),"","0");
				//Si hay un error guardando la operación
				if (output != "")
				{
					ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_add_PermySeg", string.Format("alert('{0}');", output), true);
					return;
				}

				string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "", (string)(Session["usrname"]));
                if (hdIdOrdenTrabajo.Value.Trim() != "0") { FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(ViewState["tipo_operacion"].ToString(), Convert.ToInt32(hdIdOrdenTrabajo.Value), add); }
			
			}
		}

        public void BuscaOrdenTrabajo(CENTIDAD.OrdenTrabajo otra)
        { 
            txt_factura.Text = otra.NumeroFactura.Trim();
            txt_fecha_factura.Text = Convert.ToDateTime(otra.FechaFactura.Trim()).ToShortDateString();
            txt_neto.Text = otra.FacturaNeto.Trim();
            dl_sucursal.SelectedValue = otra.IdSucursal.ToString(CultureInfo.InvariantCulture); 
            dl_cargo_venta.SelectedValue = otra.QuienPaga.Trim();   
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
            Preinscripcion minscripcion = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(solicitud);
            DatosVehiculo mvehiculo = new DatosvehiculoBC().getDatovehiculo(solicitud);
			this.dl_sucursal.SelectedValue = minscripcion.Sucursal_origen.Id_sucursal.ToString();
            this.txt_factura.Text = minscripcion.N_factura.ToString();
            this.dl_cargo_venta.SelectedValue = minscripcion.Cargo_venta;
            agpDatosGrabar.Id_solicitud = Convert.ToInt32(solicitud);
            this.agpDatosGrabar.mostrar_operacion(solicitud.ToString());

		
            this.txt_neto.Text = minscripcion.Neto_factura.ToString();
		
            //this.dl_financiera.SelectedValue = minscripcion.Bancofinanciera.Codigo.Trim();
            //this.dl_forma_pago.SelectedValue = minscripcion.Tipo_pago_factura.Trim();
            //this.agp_vehiculo.Vehiculo.Patente = mvehiculo.Patente;
            this.agp_vehiculo.Mostrar_Form(solicitud);
            this.txt_fecha_factura.Text = minscripcion.Fechafactura.ToString();
			this.agp_adquirente.Rut = minscripcion.Adquiriente.Rut;
			this.agp_adquirente.Mostrar_Form(minscripcion.Adquiriente.Rut);

            Familia_Producto mfamilia = new Familia_productoBC().getfamiliabycodigo(ViewState["tipo_operacion"].ToString());
           

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

        protected void dl_cargo_venta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.dl_forma_pago.SelectedValue == "1")
        //    {
        //        this.dl_financiera.SelectedValue = "CON";
        //    }
        //}

        //protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
	}
}