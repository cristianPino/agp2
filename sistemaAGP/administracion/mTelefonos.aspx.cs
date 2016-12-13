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
    public partial class mTelefonos : System.Web.UI.Page
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
            string paremetro = "TTEL";
            if (!IsPostBack)
            {
                gettelefonos();
                FuncionGlobal.comboparametro(this.dl_tipo_telefono,paremetro);
                
            }
        }

        private void gettelefonos()
        {
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_telefono"));
            dt.Columns.Add(new DataColumn("tipo_telefono"));
            dt.Columns.Add(new DataColumn("numero"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");
            dt.Columns.Add(col);
            
            List<Telefonos> ltelefonos= new TelefonoBC().gettelefonos(Convert.ToInt32(rut));
            foreach (Telefonos mtelefonos in ltelefonos)
            {
                DataRow dr = dt.NewRow();

                dr["id_telefono"] = mtelefonos.Id_telefono;
                dr["tipo_telefono"] = mtelefonos.Tipo_telefono;
                dr["numero"] = mtelefonos.Numero;
                dr["check"] = mtelefonos.Check;

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.txt_numero.Text == "" | this.dl_tipo_telefono.SelectedValue == "0" )
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new TelefonoBC().add_telefonos(rut,this.dl_tipo_telefono.SelectedValue.ToString(),Convert.ToInt32(this.txt_numero.Text), 0);

            FuncionGlobal.alerta("TELEFONO INGRESADA CON EXITO", Page);
            this.txt_numero.Text = "";

            gettelefonos();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            actualizar();

        }

        public void actualizar()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string id_telefono = this.gr_dato.Rows[i].Cells[0].Text;


                string add = new TelefonoBC().act_checkTelefonos(Convert.ToInt32(id_telefono), chk.Checked.ToString());

                FuncionGlobal.alerta("PRIORIDAD ACTUALIZADA CON EXITO", Page);


            }
            gettelefonos();

        }
    }
}
