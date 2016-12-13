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
    public partial class mPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getperfiles();
            }

        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            int i;
            GridViewRow row;
            ImageButton but;
            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    but = (ImageButton)row.FindControl("ib_opcionmenu");
                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('mPerfilopcionmenu.aspx?id_perfil=" + FuncionGlobal.FuctionEncriptar(row.Cells[0].Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");

                    but = (ImageButton)row.FindControl("ib_reportes");
                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('../reportes/mInformecliente.aspx?id_perfil=" + FuncionGlobal.FuctionEncriptar(row.Cells[0].Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");


                }
            }
        }


        protected void getperfiles()
        {

            List<Perfil> lPerfil = new PerfilBC().getperfiles();

            this.gr_dato.DataSource = lPerfil;
            this.gr_dato.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.txt_codigo.Text == "" || this.txt_nombre.Text == "")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }
            string add = new PerfilBC().add_Perfil(this.txt_codigo.Text, this.txt_nombre.Text);
            FuncionGlobal.alerta("PERFIL INGRESADO CON EXITO", Page);
            this.txt_nombre.Text = "";
           getperfiles();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
