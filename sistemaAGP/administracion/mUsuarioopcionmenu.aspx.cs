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
    public partial class mUsuarioopcionmenu : System.Web.UI.Page
    {
        private string cuenta_usuario;

     
        protected void Page_Load(object sender, EventArgs e)
        {
            string cuenta_usu;

            cuenta_usu = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"].ToString());

            cuenta_usuario = cuenta_usu;

            if (!IsPostBack)
            {
                getOpcionmenu();
                
            }
            
            CheckBox chk = (CheckBox)this.gr_dato.HeaderRow.FindControl("checkall");

            

        }
        private void getOpcionmenu()
        {
            List<OpcionMenu> lopcionmenu = new OpcionmenuBC().GetUsuarioopcionmenu(cuenta_usuario);

            this.gr_dato.DataSource = lopcionmenu;
            this.gr_dato.DataBind();
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_Usuarioopcionmenu();
            //FuncionGlobal.alerta("OPCIONES ACTUALIZADAS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("OPCIONES ACTUALIZADAS CON EXITO", this.Page, pnl);
            getOpcionmenu();
        }
        

        private void add_Usuarioopcionmenu()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string codigoopcionmenu = this.gr_dato.Rows[i].Cells[0].Text;

                if (chk.Checked == true)
                {

                    string add = new UsuarioBC().add_Usuarioopcionmenu(cuenta_usuario, codigoopcionmenu);

                }
                else
                {
                    string add = new UsuarioBC().del_Usuarioopcionmenu(cuenta_usuario, codigoopcionmenu);
                }

            }


        }
    }
}
