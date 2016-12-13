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
    public partial class mCorreo : System.Web.UI.Page
    {
        private Int32 rut;
        protected void Page_Load(object sender, EventArgs e)
        {

            string rut_encrip;
            string nombre;

            rut_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["rut"].ToString());
           
            rut = Convert.ToInt32(rut_encrip);

            Persona mpersona= new PersonaBC().getpersonabyrut(rut);
            nombre = mpersona.Nombre;
            this.lbl_nombre.Text = nombre;
            this.lbl_rut.Text = rut_encrip;

            if (!IsPostBack)
            {
                getcorreo();
             
                
            }
        }

        private void getcorreo()
        {
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_correo"));
            dt.Columns.Add(new DataColumn("correo"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");
            dt.Columns.Add(col);
            
            
            List<Correo> lcorreo= new CorreoBC().getcorreos(Convert.ToInt32(rut));
            foreach (Correo mcorreo in lcorreo)
            {
                DataRow dr = dt.NewRow();

                dr["id_correo"] = mcorreo.Id_correo;
                dr["correo"] = mcorreo.Correo1;
                dr["check"] = mcorreo.Check;
               

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.txt_correo.Text == ""  )
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new CorreoBC().add_correos(rut,this.txt_correo.Text, 0);

            FuncionGlobal.alerta("CORREO INGRESADA CON EXITO", Page);
            this.txt_correo.Text = "";

            getcorreo();

        }
        public void actualizar()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string id_correo = this.gr_dato.Rows[i].Cells[0].Text;


                string add = new CorreoBC().actu_checkCorreo(Convert.ToInt32(id_correo),chk.Checked.ToString());

                FuncionGlobal.alerta("PRIORIDAD ACTUALIZADA CON EXITO", Page);


            }
            getcorreo();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }


    }
}
