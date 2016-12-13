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
	public partial class RetiroCarpeta : System.Web.UI.Page
    {
      
		private int id_cliente;
		private int id_solicitud;
		private string tipo_operacion;
		private string conces;
        private string habilitar;
        protected void Page_Load(object sender, EventArgs e)

        {
			tipo_operacion = Request.QueryString["tipo_operacion"].ToString();
            habilitar = Request.QueryString["ventatipo"].ToString();
			id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString()));
            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString()));
			
			if (!IsPostBack)
			{
				string id_usuario = ((string)(Session["usrname"]));
				FuncionGlobal.comboconcesionario(this.dl_concesionario,Convert.ToInt16(id_cliente));
				
                this.lbl_numero.Text = "0";
                busca_operacion();
                cambiar_titulo();
			}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			if (dl_sucursal.SelectedValue == "0" || txt_ejecutivo.Text == "" || dl_concesionario.SelectedValue == "0" )
            {
                FuncionGlobal.alerta("Ingrese Los datos requeridos", Page);
            }
            else
            {
                    addd();
            }            		
        }


        protected void cambiar_titulo()
        {
            TipoOperacion p = new TipooperacionBC().getTipooperacion(this.tipo_operacion);
            this.Title = p.Operacion;
            this.lbl_titulo.Text = p.Operacion;
            p = null;
        }

        private void addd()
        {

			

            double rut_adq = 0;
			Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(10), tipo_operacion, (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);


            if (this.DatosAdquiriente.Guardar_Form())
            {
                if (this.DatosAdquiriente.InfoPersona != null)
                {
                    rut_adq = this.DatosAdquiriente.InfoPersona.Rut;
                }
            }

            Int32 n_cliente = 0;
            if (this.txt_n_cliente.Text != "")
            {
                n_cliente = Convert.ToInt32(this.txt_n_cliente.Text);
            }

            string add2 = new Retiro_carpetaBC().add_retiro_carpeta(rut_adq.ToString(), n_cliente, this.txt_ejecutivo.Text, add, "0", this.dl_concesionario.SelectedItem.Text,"0","", this.txt_patente.Text,DateTime.Now.ToString());
			string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));



            this.lbl_operacion.Visible = true;
            this.lbl_numero.Visible = true;
            this.lbl_operacion.Text = "Operación de Retiro de Carpeta Numero:";
            this.lbl_numero.Text = Convert.ToString(add);
            FuncionGlobal.alerta("RETIRO DE CARPETA, INGRESADO CON EXITO", Page);

        }

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
            FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(10), (string)(Session["usrname"]));

		}

        protected void busca_operacion()
        {
            Retiro_Carpeta mretiro = new Retiro_carpetaBC().getretiro(id_solicitud);
            Operacion moper = new OperacionBC().getoperacion(id_solicitud);

            if (mretiro.Id_solicitud != 0)
            {
				string id_usuario = ((string)(Session["usrname"]));
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(10), id_usuario);

                switch (mretiro.Concesionario)
                {
                    case "DERCO S.A.":
                        conces = "DER"; break;
                    case "AMICAR":
                        conces = "AMI"; break;
                    case "AUTOMOTORES GILDEMEISTER":
                        conces = "AUT"; break;
                    case "DERCOMAQ (MAQUINAS, BUSES Y CAMIONES PESADOS)":
                        conces = "DCM"; break;
                    case "AG MAQUINAS, BUSES Y CAMIONES PESADOS":
                        conces = "AGM"; break;
                }
                this.dl_concesionario.SelectedValue = conces;

                this.DatosAdquiriente.Mostrar_Form(mretiro.Rut_adquiriente);
                this.txt_n_cliente.Text = mretiro.Num_credito.ToString();
                this.txt_ejecutivo.Text = mretiro.Ejecutivo;
                this.dl_sucursal.SelectedValue = moper.Sucursal.Id_sucursal.ToString();
                this.lbl_operacion.Visible = true;
                this.lbl_numero.Visible = true;
                this.lbl_operacion.Text = "Operación de Retiro de Carpeta Numero:";
                this.lbl_numero.Text = Convert.ToString(mretiro.Id_solicitud);
				this.txt_patente.Text = mretiro.Patente;

                this.dl_concesionario.Enabled = false;
                
                this.txt_ejecutivo.Enabled = false;
                Usuario user = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
              
                this.dl_sucursal.Enabled = false;

            }
        }
		protected void dl_sucursal_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

        protected void txt_entidad_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_concesionario_TextChanged(object sender, EventArgs e)
        {

        }

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}

	
		protected void dl_conseci_SelectedIndexChanged(object sender, EventArgs e)
		{
			string id_usuario = ((string)(Session["usrname"]));

            switch (this.dl_concesionario.SelectedItem.Text)
            {
                case "DERCO S.A.":
                    conces = "DER"; break;
                case "AMICAR":
                    conces = "AMI"; break;
                case "AUTOMOTORES GILDEMEISTER":
                    conces = "AUT"; break;
                case "DERCOMAQ (MAQUINAS, BUSES Y CAMIONES PESADOS)":
                    conces = "DCM"; break;
                case "AG MAQUINAS, BUSES Y CAMIONES PESADOS":
                    conces = "AGM"; break;
            }
           
			FuncionGlobal.combosucursalbyclienteandUsuarioconces(this.dl_sucursal, Convert.ToInt16(10), id_usuario, conces);
		}

        protected void txt_patente_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_n_cliente_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
