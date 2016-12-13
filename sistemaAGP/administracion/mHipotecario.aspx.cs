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
    public partial class mHipotecario : System.Web.UI.Page
    {

        private Int32 id_solicitud;
        private Int16 id_cliente;
        private string tipo_operacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Datoscomprador.OnActivarCompraPara += new wucPersonaEventHandler(agpdatoscomprador_OnActivarCompraPara);

            this.Datosvendedor.OnClickDireccion += new wucBotonEventHandler(Datosvendedor_OnClickDireccion);
            this.Datosvendedor.OnClickTelefono += new wucBotonEventHandler(Datosvendedor_OnClickTelefono);
            this.Datosvendedor.OnClickCorreo += new wucBotonEventHandler(Datosvendedor_OnClickCorreo);
            this.Datosvendedor.OnClickParticipante += new wucBotonEventHandler(Datosvendedor_OnClickParticipante);

            this.Datoscomprador.OnClickDireccion += new wucBotonEventHandler(Datoscomprador_OnClickDireccion);
            this.Datoscomprador.OnClickTelefono += new wucBotonEventHandler(Datoscomprador_OnClickTelefono);
            this.Datoscomprador.OnClickCorreo += new wucBotonEventHandler(Datoscomprador_OnClickCorreo);
            this.Datoscomprador.OnClickParticipante += new wucBotonEventHandler(Datoscomprador_OnClickParticipante);

            this.agpCompraPara.OnClickDireccion += new wucBotonEventHandler(agpCompraPara_OnClickDireccion);
            this.agpCompraPara.OnClickTelefono += new wucBotonEventHandler(agpCompraPara_OnClickTelefono);
            this.agpCompraPara.OnClickCorreo += new wucBotonEventHandler(agpCompraPara_OnClickCorreo);
            this.agpCompraPara.OnClickParticipante += new wucBotonEventHandler(agpCompraPara_OnClickParticipante);

            id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString()));
            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString()));
            tipo_operacion = Request.QueryString["tipo_operacion"].ToString();
       

            if (!IsPostBack)
            {
      
              
                this.lbl_numero.Text = "0";
              
              
                FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(id_cliente), (string)(Session["usrname"]));               
                if (id_solicitud != 0)
                { busca_operacion(); }
                FuncionGlobal.comboparametro(this.dl_estado_inmueble, "estain");
                FuncionGlobal.comboparametro(this.dl_tipo_inmueble, "tipoin");
                FuncionGlobal.combobanco(this.dl_banco,id_cliente);
                FuncionGlobal.combopais(this.dl_pais);

            }

        }
        protected void agpdatoscomprador_OnActivarCompraPara(object sender, wucPersonaEventArgs e)
        {
            this.agpCompraPara.Visible = e.Activar;
        }
   
        protected void Datoscomprador_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void agpCompraPara_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
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

        protected void Datoscomprador_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void Datoscomprador_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void Datoscomprador_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }

        protected void agpCompraPara_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void agpCompraPara_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void agpCompraPara_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }

        private void busca_operacion()

        {
            Hipotecario mhipotecaria= new HipotecarioBC().gethipotecario(id_solicitud);

            

            if (mhipotecaria != null && id_solicitud !=2)

            {
                
                    this.lbl_operacion.Visible = true;
                    this.lbl_numero.Visible = true;
                    this.lbl_operacion.Text = "Operación de Transferencia Numero:";
                    this.lbl_numero.Text = Convert.ToString(mhipotecaria.Operacion.Id_solicitud);
                  

                //    this.dl_banco.SelectedValue= mhipotecaria.Banco_alzante;
                //    this.txt_fecha_subsidio.Text = mhipotecaria.Fecha_subsidio.ToString();
                //    this.txt_monto.Text = mhipotecaria.Monto_credito.ToString();
                //    this.txt_n_operacion.Text = mhipotecaria.N_operacion.ToString();
                //    this.txt_plazo.Text = mhipotecaria.Plazo.ToString();
                //    this.txt_rol.Text = mhipotecaria.Rol.ToString();
                //    this.txt_tasacion.Text = mhipotecaria.Tasacion.ToString();
                //    this.txt_tasa.Text = mhipotecaria.Tasa.ToString();
                //    this.dl_estado_inmueble.SelectedValue = mhipotecaria.Estado_inmueble;
                //    this.dl_tipo_inmueble.SelectedValue = mhipotecaria.Tipo_inmueble;


                //    if (mhipotecaria.Rut_vendedor != null)
                //    {

                //        this.Datosvendedor.Mostrar_Form(mhipotecaria.Rut_vendedor.Rut);
                //    }

                //    if (mhipotecaria.Rut_comprador != null)
                //    {
                //        this.Datoscomprador.Mostrar_Form(mhipotecaria.Rut_comprador.Rut);

                //    }
                //    if (mhipotecaria.Rut_compra_para != null)
                //{
                //    this.Datoscomprador.setCompraPara(true);
                //    this.agpCompraPara.Visible = true;
                    //this.agpCompraPara.Mostrar_Form(mhipotecaria.Rut_compra_para.Rut);

                //}
                    
            
            }
        
        }




        private void add()
        {
            string rutcomp="0";
            string rutvend="0";
            string rutcompp="0";
           

            if (this.Datoscomprador.Guardar_Form())
            {
                if (this.Datoscomprador.InfoPersona != null)
                {
                    rutcomp = this.Datoscomprador.InfoPersona.Rut.ToString();
                }
            }
            
            if (this.Datosvendedor.Guardar_Form())
            {
                if (this.Datosvendedor.InfoPersona != null)
                {
                    rutvend = this.Datosvendedor.InfoPersona.Rut.ToString();
                }
            }

            if (this.agpCompraPara.Guardar_Form())
            {
                if (this.agpCompraPara.InfoPersona != null)
                {
                    rutcompp = this.agpCompraPara.InfoPersona.Rut.ToString();
                }
            }




            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(id_cliente), tipo_operacion, (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),0);
        
            if (add != 0)
            {
                string fecha = this.txt_fecha_subsidio.Text;
                if (this.txt_fecha_subsidio.Text == "")
                {
                    fecha = "1900/01/01";
                }
                //string add_HP = new HipotecarioBC().add_hipotecario(add,
                //                                                        Convert.ToInt32(rutvend),
                //                                                         Convert.ToInt32(rutcomp),
                //                                                         Convert.ToInt32(rutcompp),this.txt_n_operacion.Text,
                //                                                         this.dl_banco.SelectedValue,Convert.ToDateTime(fecha),
                //                                                         this.dl_estado_inmueble.SelectedValue,this.dl_tipo_inmueble.SelectedValue,
                //                                                         this.txt_rol.Text,this.txt_direccion.Text,Convert.ToInt32(this.dl_comuna.SelectedValue),
                //                                                         Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_tasacion.Text)),
                //                                                         this.txt_tasa.Text,Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_monto.Text)),
                //                                                         Convert.ToInt32(this.txt_plazo.Text),Convert.ToInt32(this.dl_sucursal_origen.SelectedValue));



                //if (add_HP == "")
                //{
                //    string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));
                //}

            }



            this.lbl_operacion.Visible = true;
            this.lbl_numero.Visible = true;
            this.lbl_operacion.Text = "Operación de Hipotecaria Numero:";
            this.lbl_numero.Text = Convert.ToString(add);
            FuncionGlobal.alerta("OPERACION DE HIPOTECARIA, INGRESADA CON EXITO", Page);
        }


       
       
        protected void bt_salir_OnClick(object sender, EventArgs e)
        {

        }


        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            if (validar() == true)
            {
                add();
            }
             
        }
        public Boolean validar()
        {
            if (this.txt_direccion.Text == "" || this.txt_monto.Text == "" || this.txt_n_operacion.Text == "" ||
                this.txt_plazo.Text == "" || this.txt_rol.Text == "" || this.txt_tasa.Text == "" || this.txt_tasacion.Text == "" ||
                this.dl_sucursal_origen.SelectedValue=="0"||this.dl_tipo_inmueble.SelectedValue == "0"||
                this.dl_estado_inmueble.SelectedValue=="0")
            {
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                FuncionGlobal.alerta_updatepanel("FALTAS DATOS POR INGRESAR", Page, up);
                return false;
            }
            else
            {
               return true;
            }
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.lbl_numero.Text = "0";
            this.lbl_operacion.Text = "";
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>self.close();</script>");
        }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
        }

        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        }

        protected void txt_direccion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_n_operacion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_banco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_rol_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_tasacion_TextChanged(object sender, EventArgs e)
        {
            this.txt_tasacion.Text = FuncionGlobal.NumeroConFormato(this.txt_tasacion.Text);
        }

        protected void txt_fecha_subsidio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_estado_inmueble_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_inmueble_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_monto_TextChanged(object sender, EventArgs e)
        {
            this.txt_monto.Text = FuncionGlobal.NumeroConFormato(this.txt_monto.Text);
        }

        protected void txt_tasa_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_plazo_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dl_sucursal_origen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
    }
}