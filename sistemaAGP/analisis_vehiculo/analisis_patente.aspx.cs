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
    public partial class analisis_patente : System.Web.UI.Page
    {
        private string patente;
        private string id_solicitud;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            patente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["patente"].ToString());
            id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());

           
            this.lbl_patente.Text = patente;

            if (!IsPostBack)
            {
				FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
				FuncionGlobal.combomarcavehiculo(this.dl_marca);
				FuncionGlobal.BuscarTextoCombo(this.dl_marca, this.txt_marca.Text);
				FuncionGlobal.BuscarTextoCombo(this.dl_tipo_vehiculo, this.txt_tipo.Text);
				FuncionGlobal.comboparametro(this.dl_estado_vehiculo, "ESVEH");
				
				getDatosvehiculo(id_solicitud);
				this.lbl_patente.Text = patente.ToString();
				
            }
        }

        protected void txt_PDF_Leave(object sender, EventArgs e)
        {
            //busca_dato(this.txt_patente, "INSCRIPCIÓN");
            busca_dato(this.txt_tipo, "Tipo Vehículo");
            busca_dato(this.txt_marca, "Marca");
            busca_dato(this.txt_ano, "Año");
            busca_dato(this.txt_vin, "Nro. Vin");
            busca_dato(this.txt_serie, "Nro. Serie");
            busca_dato(this.txt_chasis, "Nro. Chasis");
            busca_dato(this.txt_color, "Color");
            busca_dato(this.txt_modelo, "Modelo");
            busca_dato(this.txt_motor, "Nro. Motor");

            FuncionGlobal.BuscarTextoCombo(this.dl_marca, this.txt_marca.Text);
            FuncionGlobal.BuscarTextoCombo(this.dl_tipo_vehiculo, this.txt_tipo.Text);
        }

        private void busca_dato( TextBox txt_palabra, string palabra)

        {
            string resultado;
            string resul;

            resultado = "";
            string[] lienas = { };
            if (this.txt_PDF.Text.IndexOf(Environment.NewLine) > 0)
                lienas = this.txt_PDF.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            else if (this.txt_PDF.Text.IndexOf("\n") > 0)
                lienas = this.txt_PDF.Text.Split(new string[] { "\n" }, StringSplitOptions.None);

            int contador = 1;
            foreach (string linea in lienas)
            {
                if (linea.Trim().Length >= palabra.Trim().Length  )
                {

                    if (palabra == "Año" && contador == 3)
                    {
                        resul = linea;
                        int id = linea.IndexOf("Año", 0);
                        resul = linea.Remove(0, id);
                        resul = resul.Substring(0, palabra.Length);
                    }
                    else
                    {
                        resul = linea.Substring(0, palabra.Length);
                    }
                    if (resul == palabra)
                    {
                        if(resul=="Año")
                        {
                            resul = linea;
                            int id = linea.IndexOf("Año", 0);
                            resul = linea.Remove(0, id);
                            resul = resul.Substring(palabra.Length);
                            resultado = resul.Replace(":","").Trim();
                        }
                        else
                        {
                            resultado = linea.Replace(palabra, "").ToString().Trim();
                            resultado = resultado.Replace(":", "").ToString().Trim();
                            if (palabra == "Tipo Vehículo")
                            {
                                int ind = resultado.IndexOf("Año",0);
                                resultado = resultado.Remove(ind).Trim();
                          
                            }
                        }
                        txt_palabra.Text = resultado;
                        return;
                    }

                }                
                contador++;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_datosvehiculo();
        }

        private void add_datosvehiculo()
        {
            
            string dv = FuncionGlobal.digitoVerificadorPatente(patente);

            Marcavehiculo marca = new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(this.dl_marca.SelectedValue));
            Tipovehiculo vehi = new TipovehiculoBC().getTipoVehiculo(this.dl_tipo_vehiculo.SelectedValue);
			DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculobyPatente_id_solicitud(this.patente, Convert.ToInt32(id_solicitud));



            string add = new DatosvehiculoBC().add_Datosvehiculo(Convert.ToInt32(this.id_solicitud),marca,
                                                                    vehi,this.patente,dv,this.txt_modelo.Text,
                                                                    this.txt_chasis.Text,this.txt_motor.Text,this.txt_vin.Text,
                                                                    this.txt_serie.Text,Convert.ToInt32(this.txt_ano.Text),"",this.txt_color.Text,
                                                                    0,0,"",0,0,mdato.Kilometraje,mdato.Tasacion,mdato.Codigo_SII,mdato.Precio,mdato.Id_dato_vehiculo,mdato.Fecha_contrato,mdato.Forma_pago,
                                                                    mdato.Prenda,this.dl_estado_vehiculo.SelectedValue.ToString(),mdato.Rut_prenda,mdato.Financiamiento_amicar,mdato.Transmision,mdato.Equipamiento );







            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("DATOS DEL VEHICULO INGRESADA CON EXITO", this.Page, up);
			this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CloseWnd", "<script type=\"text/javascript\">window.close();</script>");
            return;
        }

        private void getDatosvehiculo(string id_solicitud)
        {
            List<DatosVehiculo> lDatosvehiculo = new DatosvehiculoBC().getDatosvehiculo(Convert.ToInt32(id_solicitud));

            if (lDatosvehiculo.Count != 0)
            {

                this.txt_color.Text = lDatosvehiculo.ElementAt(0).Color;
                this.txt_marca.Text = lDatosvehiculo.ElementAt(0).Marca.Nombre;
                this.txt_modelo.Text = lDatosvehiculo.ElementAt(0).Modelo;
                this.txt_chasis.Text = lDatosvehiculo.ElementAt(0).Chassis;
                this.txt_motor.Text = lDatosvehiculo.ElementAt(0).Motor;
                this.txt_serie.Text = lDatosvehiculo.ElementAt(0).Serie;
                this.txt_tipo.Text = lDatosvehiculo.ElementAt(0).Tipo_vehiculo.Nombre;
                this.txt_vin.Text = lDatosvehiculo.ElementAt(0).Vin;
                this.txt_ano.Text = lDatosvehiculo.ElementAt(0).Ano.ToString();
                if (lDatosvehiculo.ElementAt(0).Estado_vehiculo.ToString() != "Seleccionar"&&lDatosvehiculo.ElementAt(0).Estado_vehiculo.ToString() !="")
                {
                    this.dl_estado_vehiculo.SelectedValue = lDatosvehiculo.ElementAt(0).Estado_vehiculo.ToString();

                }
                else
                {
                    this.dl_estado_vehiculo.SelectedValue = "0";
                }
            }
            return;
          
        }

        protected void dl_tipo_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_marca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_estado_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
