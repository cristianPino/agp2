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
	public partial class mEjecutivo : System.Web.UI.Page
    {

        private Int16 id_cliente;
		private Int16 id_sucursal;
        string id_cliente_financiera;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_cli_encrip;
			string id_suc_encrip;
            

			id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cliente"].ToString());

			id_suc_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["sucursal"].ToString());

            id_cliente_financiera = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente_financiera"].ToString());

            id_cliente = Convert.ToInt16(id_cli_encrip);

			id_sucursal = Convert.ToInt16(id_suc_encrip);

            this.lbl_id.Text = id_cli_encrip;

            Cliente mcliente = new ClienteBC().getcliente(id_cliente);

            this.lbl_cliente.Text = mcliente.Persona.Nombre;

			

            getmodulos();
            
        }

        protected void getmodulos()
        {

            List<Ejecutivosucursal> lModulo = new EjecutivosucursalBC().getEjecutivoclientebycliente(id_cliente,id_sucursal);
		

			
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

			if (this.Label6.Text == "")
			{
				FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
				return;
			}
            string add = new EjecutivosucursalBC().add_EjecutivoSucursal(Convert.ToInt16(id_cliente), id_sucursal, this.txt_nombre.Text,this.txt_CORREO.Text,
                Convert.ToInt16(id_cliente_financiera));
            FuncionGlobal.alerta("MODULO INGRESADO CON EXITO", Page);
            this.txt_nombre.Text = "";
			this.txt_CORREO.Text = "";
            getmodulos();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.txt_nombre.Text = "";
        }

        protected void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

		protected void CustomersGridView_RowDeleting
		(Object sender, GridViewDeleteEventArgs e)
		{
			int cell = Convert.ToInt32(gr_dato.Rows[e.RowIndex].Cells[0].Text);

			string Del = new EjecutivosucursalBC().del_EjecutivoSucursal(Convert.ToInt16(cell));
			getmodulos();
		}  


    }
}
