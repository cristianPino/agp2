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
    public partial class Modulousuario : System.Web.UI.Page
    {

        private string cuenta_usuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            string cuenta_usu;

            cuenta_usu = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_usuario"].ToString());

            cuenta_usuario = cuenta_usu;

            if (!IsPostBack)
            {



                
                Usuario musuario = new UsuarioBC().GetUsuario(cuenta_usuario);

                this.lbl_usuario.Text = musuario.Nombre;

                FuncionGlobal.comboclientesbyusuario(cuenta_usuario, this.dl_cliente);

            }

            

        }

        

        protected void getmodulos()
        {

            List<ModuloCliente> lModulo = new ModuloclienteBC().getmoduloclientebyusuario(cuenta_usuario,
                                                                        Convert.ToInt16(this.dl_cliente.SelectedValue));

            this.gr_dato.DataSource = lModulo;
            this.gr_dato.DataBind();
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_usuario_modulo();
            //FuncionGlobal.alerta("MODULOS ACTUALIZADOS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("MODULOS ACTUALIZADOS CON EXITO", this.Page, pnl);
            getmodulos();
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {

            FuncionGlobal.marca_check(gr_dato);


        }


        private void add_usuario_modulo()
        {
          
            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                
                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                Int16 id_modulo = Convert.ToInt16(this.gr_dato.Rows[i].Cells[0].Text);

                if (chk.Checked == true)
                {
                   
                    int add = new UsuarioBC().add_usuario_modulo(cuenta_usuario, id_modulo);

                }
                else
                {
                    int del = new UsuarioBC().del_usuario_modulo(cuenta_usuario, id_modulo);
                }

            }

        
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.dl_cliente.SelectedValue != "0")
            {
                this.getmodulos();
            
            }
        }

          

    }
}
