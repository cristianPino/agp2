using System;
using System.Collections.Generic;
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace sistemaAGP
{
    public partial class HipotecarioBasic : System.Web.UI.Page
    {
        private Int32 id_solicitud;
        private Int16 id_cliente;
        private string tipo_operacion;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Datosvendedor.OnClickDireccion += new wucBotonEventHandler(Datosvendedor_OnClickDireccion);
            this.Datosvendedor.OnClickTelefono += new wucBotonEventHandler(Datosvendedor_OnClickTelefono);
            this.Datosvendedor.OnClickCorreo += new wucBotonEventHandler(Datosvendedor_OnClickCorreo);
            this.Datosvendedor.OnClickParticipante += new wucBotonEventHandler(Datosvendedor_OnClickParticipante);


            id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString()));
            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString()));
            tipo_operacion = Request.QueryString["tipo_operacion"].ToString();

            if(!IsPostBack)
            {
                cambiar_titulo();
                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
                this.dl_cliente.SelectedValue = id_cliente.ToString();
                FuncionGlobal.combosucursalbyclienteandUsuarioShort(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));


                if (id_solicitud != 0)
                {
                    busca_operacion();
                }
            }

        }
        protected void cambiar_titulo()
        {
            TipoOperacion p = new TipooperacionBC().getTipooperacion(this.tipo_operacion);
            this.Title = p.Operacion;
            this.lbl_titulo.Text = p.Operacion;
            p = null;
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

        protected void busca_operacion()
        {

            Operacion moperacion = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

           
            this.lbl_operacion.Text = "Operación Numero:";
            this.lbl_numero.Text = Convert.ToString(moperacion.Id_solicitud);
    
            if (moperacion.Numero_cliente == null)
            {
                this.txt_interno.Text = "";
            }
            else
            {
                this.txt_interno.Text = moperacion.Numero_cliente.ToString();
                this.dl_sucursal_origen.SelectedValue = moperacion.Sucursal.Id_sucursal.ToString();
                this.lbl_operacion.Visible = true;
                this.lbl_numero.Visible = true;
               
            }

           

            ParticipeOperacion mvende = new ParticipeOperacionBC().getparticipebytipo(Convert.ToInt32(id_solicitud), "COMPR");
            if (mvende.Participe != null)
            {
                this.Datosvendedor.Mostrar_Form(mvende.Participe.Rut);
            }
        }

        protected void cmdLink_Click1(object sender, EventArgs e)
        {
            agpDatosGrabar.ID = "0";
            agpDatosGrabar.Id_solicitud = 0;
            this.id_solicitud = 0;
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (valida_ingreso())
            {     
                add_operacion(); 
            }    
        }
   
        protected void txt_interno_TextChanged(object sender, EventArgs e)
        {
            if(txt_interno.Text.Trim()=="")
            {
                return;
            }
            Cargar();
        }

        public void Cargar()
        {
            var hip = new HipotecarioBC().GetDatoOperaciones(txt_interno.Text, Convert.ToInt32(dl_cliente.SelectedValue));
            if (hip == null) return;
            dl_sucursal_origen.SelectedValue = hip.Sucursal.Id_sucursal.ToString().Trim();
            Datosvendedor.Mostrar_Form(Convert.ToDouble(hip.RutComprador));
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {
                add_operacion();
            }

           
        }

        protected void add_operacion()
        {

            string rutvend = "0";
            int operacion = 0;

            if (this.Datosvendedor.Guardar_Form())
            {
                if (this.Datosvendedor.InfoPersona != null)
                {
                    rutvend = this.Datosvendedor.InfoPersona.Rut.ToString();
                }
            }
            if (this.lbl_numero.Text != "")
            {
                operacion = Convert.ToInt32(this.lbl_numero.Text);
            }
            Int32 factura = 0; //siempre 0 por defecto
           
            Int32 add = new OperacionBC().add_operacion(operacion, Convert.ToInt16(this.dl_cliente.SelectedValue),
                                                        tipo_operacion, (string)(Session["usrname"]),0, this.txt_interno.Text.Trim(),
                                                        Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),factura, "");

            this.agpDatosGrabar.Id_solicitud = add;
            this.agpDatosGrabar.Carga_vent = Convert.ToInt32("1");

            string addparven = new ParticipeOperacionBC().add_participe(Convert.ToInt32(add), Convert.ToInt32(this.Datosvendedor.InfoPersona.Rut), "COMPR");

           
            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));


            this.lbl_operacion.Visible = true;
            this.lbl_numero.Visible = true;
            this.lbl_operacion.Text = "Operación Numero:";
            this.lbl_numero.Text = Convert.ToString(add);
            FuncionGlobal.alerta(this.lbl_titulo.Text + ", INGRESADO CON EXITO", Page); 
        }

        protected Boolean valida_ingreso()
        {   
            if (this.dl_sucursal_origen.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese la Sucursal de Origen", Page,Udp);
                this.dl_sucursal_origen.Focus();
                return false;
            }
            if (new HipotecarioBC().ValidaGestoria(txt_interno.Text.Trim(), Convert.ToInt16(this.dl_cliente.SelectedValue))==1)
            {
                FuncionGlobal.alerta_updatepanel("Ya existe una gestoría para esta operación", Page, Udp);
                return false;
            }

            return true;

        }


        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void txt_factura_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    this.txt_ano.Text = "";
        //    this.txt_dv_patente.Text = "";
        //    this.txt_kilometraje.Text = "";
        //    this.txt_patente.Text = "";
        //}

    }
}