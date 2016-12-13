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
    public partial class mPerfilopcionmenu : System.Web.UI.Page
    {
       
        private string id_perfil;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            id_perfil = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_perfil"].ToString());

            
            

            if (!IsPostBack)
            {
                this.lbl_perfil.Text = id_perfil;
                getOpcionmenu();
            }

            
            
        }

        private void getOpcionmenu()
        {
            List<OpcionMenu> lopcionmenu = new OpcionmenuBC().GetPerfilopcionmenu(id_perfil);

            this.gr_dato.DataSource = lopcionmenu;
            this.gr_dato.DataBind();
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_perfilopcionmenu();
            FuncionGlobal.alerta("PERFIL ACTUALIZADO CON EXITO", Page);
            getOpcionmenu();
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void add_perfilopcionmenu()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string codigoopcionmenu = this.gr_dato.Rows[i].Cells[0].Text;

                if (chk.Checked == true)
                {

                    string add = new PerfilBC().add_Perfilopcionmenu(id_perfil, codigoopcionmenu);

                }
                else
                {
                    string add = new PerfilBC().del_Perfilopcionmenu(id_perfil, codigoopcionmenu);
                }

            }


        }



    }
}
