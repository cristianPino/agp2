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
    public partial class mCta_Cte : System.Web.UI.Page
    {
        private string cuenta_usuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {

           
            string nombre;

            cuenta_usuario = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"].ToString());

           

            Usuario mpersona= new UsuarioBC().GetUsuario(cuenta_usuario);
            nombre = mpersona.Nombre;
            this.lbl_nombre.Text = nombre;
            this.lbl_rut.Text = cuenta_usuario;

            if (!IsPostBack)
            {
                getCta_Cte();
                FuncionGlobal.comboparametro(this.dl_tipo, "TCTACTE");
                
            }
        }

        private void getCta_Cte()
        {
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_cta_cte"));
            dt.Columns.Add(new DataColumn("tipo_cuenta"));
            dt.Columns.Add(new DataColumn("numero"));
            dt.Columns.Add(new DataColumn("banco"));
            
            
            List<Cuenta_Corriente> lcorreo= new Cta_CteBC().getCta_Cte(cuenta_usuario);
            foreach (Cuenta_Corriente mcorreo in lcorreo)
            {
               
                DataRow dr = dt.NewRow();
                

                dr["id_cta_cte"] = mcorreo.Id_cta_cte;
                dr["tipo_cuenta"] =   mcorreo.Tipo_cuenta;
                dr["numero"] = mcorreo.Numero;
                dr["banco"] = mcorreo.Banco;
               

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.txt_n_cuenta.Text == ""  || this.txt_banco.Text =="" || this.dl_tipo.SelectedValue=="")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new Cta_CteBC().add_Cta_Cte(cuenta_usuario,this.txt_n_cuenta.Text,this.txt_banco.Text,this.dl_tipo.SelectedValue);

            FuncionGlobal.alerta("CUENTA CORRIENTE INGRESADA CON EXITO", Page);
            this.txt_banco.Text = "";
            this.txt_n_cuenta.Text = "";
            getCta_Cte();

        }
       
   
        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
