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
using System.Text;
using Mail;

namespace sistemaAGP {

    public partial class Analisis_Alzamiento : System.Web.UI.Page
    {

		private string id_solicitud;
       
		protected void Page_Load(object sender, EventArgs e) {
           
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
            
			if (!IsPostBack) 
            {
                FuncionGlobal.combobanco(this.ddl_financiera,1);
                get_analisis_alzamiento();
			}
		}
		protected void bt_guardar_Click(object sender, EventArgs e)
        {
            if (validar() == true)
            {
                add();
            }
              
        }
        protected void add()
        {
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            string add = new Analisis_AlzaBC().add_analisis_alza(Convert.ToInt32(this.txt_monto.Text), this.ddl_financiera.SelectedValue, Convert.ToInt32(id_solicitud), this.txt_fecha_carta.Text, this.txt_fecha_termino.Text,this.txt_fecha_otorgamiento.Text);
            if (add == "0")
            {
                FuncionGlobal.alerta_updatepanel("Datos de la Operacion Guardados Correctamente", Page, up);
            }
            else
            {
                this.lbl_error.Text = add;
            } 
        }
        protected bool validar()
        {
            if (this.txt_monto.Text == "") return false;
            return true;
        }

        protected void get_analisis_alzamiento()
        {
            Analisis_Alza mAnalisis = new Analisis_AlzaBC().getAnalisis_Alza(Convert.ToInt32(id_solicitud));
            this.txt_monto.Text = mAnalisis.Monto.ToString();
            this.txt_fecha_carta.Text = mAnalisis.Fecha_carta;
            this.txt_fecha_termino.Text = mAnalisis.Fecha_termino;
            this.ddl_financiera.SelectedValue = mAnalisis.Cod_financiera;
            this.txt_fecha_otorgamiento.Text = mAnalisis.Fecha_otorgamiento;
        }
	}
}