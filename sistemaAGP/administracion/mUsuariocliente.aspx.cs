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
    public partial class mUsuariocliente : System.Web.UI.Page
    {
        private string cuenta_usuario;

     
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string cuenta_usu;

            cuenta_usu = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"].ToString());

            cuenta_usuario = cuenta_usu;


            this.lbl_Usuario.Text = cuenta_usuario;

            if (!IsPostBack)
            {

                Usuario musuario = new UsuarioBC().GetUsuario(cuenta_usuario);

                this.lbl_Usuario.Text= musuario.Nombre;

                
                getClientes();
                
            }
            
           // CheckBox chk = (CheckBox)this.gr_dato.HeaderRow.FindControl("checkall");

            

        }
        private void getClientes()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_cliente"));
            dt.Columns.Add(new DataColumn("nombre"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);
            
            
            
            List<Cliente> lcliente = new ClienteBC().getclientebyusuario(cuenta_usuario);


            foreach (Cliente mcliente in lcliente)
            {
                DataRow dr = dt.NewRow();

                dr["id_cliente"] = mcliente.Id_cliente;
                dr["nombre"] = mcliente.Persona.Nombre;
                dr["check"] = mcliente.Check;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

   

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_usuariocliente();
            //FuncionGlobal.alerta("CLIENTES ACTUALIZADOS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("CLIENTES ACTUALIZADOS CON EXITO", this.Page, pnl);
            getClientes();
        }
        

        private void add_usuariocliente()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string id_cliente = this.gr_dato.Rows[i].Cells[0].Text;

                if (chk.Checked == true)
                {

                    string add = new ClienteBC().add_usuario_cliente(Convert.ToInt16(id_cliente), cuenta_usuario);

                }
                else
                {
                    string add = new ClienteBC().del_usuario_cliente(Convert.ToInt16(id_cliente), cuenta_usuario);
                }

            }


        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
