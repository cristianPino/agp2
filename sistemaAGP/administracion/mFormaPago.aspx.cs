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
    public partial class mFormaPago : System.Web.UI.Page
    {
        private Int16 id_cliente;
        protected void Page_Load(object sender, EventArgs e)
        {

            string id_cli_encrip;

            id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

            id_cliente = Convert.ToInt16(id_cli_encrip);

            Cliente mcliente = new ClienteBC().getcliente(id_cliente);
            this.lbl_cliente.Text = mcliente.Persona.Nombre;


            if (!IsPostBack)
            {
                getformapago();
            }
        }

        private void getformapago()
        {
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_forma_pago"));
            dt.Columns.Add(new DataColumn("descripcion"));

            List<FormaPago> lformapago= new FormaPagoBC().getformapagobycliente(Convert.ToInt32(id_cliente));
            foreach (FormaPago mformapago in lformapago)
            {
                DataRow dr = dt.NewRow();

                dr["id_forma_pago"] = mformapago.Id_forma_pago;
                dr["descripcion"] = mformapago.Descripcion;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.txt_nombre.Text == "" )
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new FormaPagoBC().add_forma_pago(Convert.ToInt32(id_cliente),this.txt_nombre.Text);

            FuncionGlobal.alerta("FORMA DE PAGO INGRESADA CON EXITO", Page);
            this.txt_nombre.Text = "";

            getformapago();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

    }
}
