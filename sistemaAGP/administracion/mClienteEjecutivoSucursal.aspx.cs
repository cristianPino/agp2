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
	public partial class mClienteEjecutivoSucursal : System.Web.UI.Page
    {
     
        private Int16 id_clientef;

        protected void Page_Load(object sender, EventArgs e)
        {
			string id_usuario = ((string)(Session["usrname"]));
			if (!IsPostBack)
			{
				Usuario muser = new UsuarioBC().GetUsuario(id_usuario);

				 id_clientef = Convert.ToInt16(muser.Cliente.Id_cliente);
				
				FuncionGlobal.comboFinancieraClientefinanciera(this.dl_cliente, id_clientef);
				Cliente mcliente = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
				//this.lbl_cliente.Text = mcliente.Persona.Nombre;
				
			}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add(); 
        }

        private void add()
        {


			GridViewRow row;

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
			//	CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("check");
				string codigo = this.gr_dato.Rows[i].Cells[0].Text;
			//	int id_cliente = id_cliente;

				//if (chk.Checked == true)
				//{

				//    string add = new ClienteOperacionTipogastoBC().add_cliente_operacion_tipogasto(id_cliente,Convert.ToInt32(dl_familia.SelectedValue.ToString()),this.dl_producto.SelectedValue.Trim(),Convert.ToInt32(codigo));

				//}

				//else
				//{

				//    string add = new ClienteOperacionTipogastoBC().del_cliente_operacion_tipogasto(id_cliente, Convert.ToInt32(dl_familia.SelectedValue.Trim().ToString()), this.dl_producto.SelectedValue.Trim(),Convert.ToInt32(codigo));

				//}


			}

                

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        
        }

        protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gr_dato.EditIndex = e.NewEditIndex;
        }

        public void getalltipogasto()
        {
			
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_sucursal"));
            dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("url_ejecutivo"));
            //DataColumn col = new DataColumn("check");
           // col.DataType = System.Type.GetType("System.Boolean");
       

           // dt.Columns.Add(col);


			List<SucursalCliente> lsucursalcliente = new SucursalclienteBC().getSucursalbycliente(Convert.ToInt16(this.dl_cliente.SelectedValue));



			foreach (SucursalCliente msucursalcliente in lsucursalcliente)
            {
                DataRow dr = dt.NewRow();

				dr["id_sucursal"] = msucursalcliente.Id_sucursal;
				dr["descripcion"] = msucursalcliente.Nombre;
                dr["url_ejecutivo"] = "mEjecutivo.aspx?cliente=" + FuncionGlobal.FuctionEncriptar(this.dl_cliente.SelectedValue.ToString().Trim()) + "&sucursal=" + FuncionGlobal.FuctionEncriptar(msucursalcliente.Id_sucursal.ToString().Trim()) + "&id_cliente_financiera=" + FuncionGlobal.FuctionEncriptar(id_clientef.ToString());
				

                //dr["check"] = mtipogasto.Check;
              

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
			this.Button1.Visible = true;
        }

        protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
			
        }



        protected void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_valor_gasto_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txt_nombre_gasto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bt_editar_Click(object sender, EventArgs e)
        {

            
           
            

        }

        protected void chk_gasto_CheckedChanged(object sender, EventArgs e)
        {

        }

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			getalltipogasto();
		}

    }
}
