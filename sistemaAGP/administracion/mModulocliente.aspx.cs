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
    public partial class mModulocliente : System.Web.UI.Page
    {

        private Int16 id_cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_cli_encrip;

            id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

            id_cliente = Convert.ToInt16(id_cli_encrip);

            this.lbl_id.Text = id_cli_encrip;

            Cliente mcliente = new ClienteBC().getcliente(id_cliente);

            this.lbl_cliente.Text = mcliente.Persona.Nombre;

            getmodulos();
            
        }

        protected void getmodulos()
        {

            List<ModuloCliente> lModulo = new ModuloclienteBC().getmoduloclientebycliente(Convert.ToInt16(this.lbl_id.Text));

            this.gr_dato.DataSource = lModulo;
            this.gr_dato.DataBind();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.txt_nombre.Text == "")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return ;
            }
            string add = new ModuloclienteBC().add_modulo(Convert.ToInt16(this.lbl_id.Text), this.txt_nombre.Text);
            FuncionGlobal.alerta("MODULO INGRESADO CON EXITO", Page);
            this.txt_nombre.Text = "";
            getmodulos();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.txt_nombre.Text = "";
        }

        protected void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
