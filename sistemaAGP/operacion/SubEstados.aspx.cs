using System;
using System.Data;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;


namespace sistemaAGP
{
    public partial class SubEstados : System.Web.UI.Page
    {

        private Int32 id_estado;
        private Int32 id_solicitud ;
     

        protected void Page_Load(object sender, EventArgs e)
        {

            id_solicitud =Convert.ToInt32(Request.QueryString["id_solicitud"].ToString());
            id_estado =Convert.ToInt32(Request.QueryString["id_estado"].ToString());

            if (!IsPostBack)
            {
                this.lbl_estado.Text = "ID ESTADO :";
                this.lbl_id_estado.Text = id_estado.ToString();
                get_hitos();
            }
        }

        protected void get_hitos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("hito"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("tipo"));


            List<Hito> lhito = new HitoBC().gethito(id_estado);
            
			foreach (Hito mhito in lhito)
			{
				DataRow dr = dt.NewRow();
				dr["hito"] = mhito.Observacion;
                dr["fecha"] = mhito.Fecha;
                dr["tipo"] = mhito.Semaforo;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
            
        }

        protected void txt_observacion_TextChanged(object sender, EventArgs e)
        {

        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            var tipo = 0;
            if(rb_rojo.Checked)
            {
                tipo = 3;
            }
            else if(rb_amarillo.Checked)
            {
                tipo = 2;
            }
            else if(rb_verde.Checked)
            {
                tipo = 1;
            }

            if (txt_observacion.Text.Trim() != "")
            {
                string add = new HitoBC().add_hito(id_estado, this.txt_observacion.Text, DateTime.Now.ToShortDateString(),tipo);
                FuncionGlobal.alerta("SUBESTADO, INGRESADO CON EXITO", Page);
                get_hitos();
                this.txt_observacion.Text = "";
            }
            else
            {
                FuncionGlobal.alerta("FALTA INGRESAR LA OBSERVACION", Page);
            }
        }


    }
}
