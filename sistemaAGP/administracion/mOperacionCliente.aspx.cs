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
    public partial class mOperacionCliente : System.Web.UI.Page
    {
        private Int16 id_cliente;

		private Int16 id_familia;

		private string cuenta_usuario;

     
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_cli_encrip;


            id_cli_encrip =  FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

            id_cliente = Convert.ToInt16(id_cli_encrip);


            if (!IsPostBack)
            {
               // getallTipooperacion();

				if (!IsPostBack)
				{
				//	Cliente mcliente = new ClienteBC().getcliente(id_cliente);
					
					FuncionGlobal.combofamilia_producto(this.dl_familia);
					
					//	FuncionGlobal.comboTipoOperacionCliente(this.dl_producto, id_cliente);

				}
                
            }
            
           // CheckBox chk = (CheckBox)this.gr_dato.HeaderRow.FindControl("checkall");

            

        }
        private void getallTipooperacion()
        {



            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("operacion"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);



			List<TipoOperacion> ltipooperacion = new TipooperacionBC().getTipo_OperacionByClienteandfamilia(Convert.ToInt16(id_cliente),"todo",Convert.ToInt16(id_familia));


            foreach (TipoOperacion mtipo in ltipooperacion)
            {
				
			
				
				DataRow dr = dt.NewRow();

                dr["codigo"] = mtipo.Codigo;
                dr["operacion"] = mtipo.Operacion;
                dr["check"] = mtipo.Check;
                dt.Rows.Add(dr);
            
			}

			this.gr_dato.DataSource = dt;
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
            add_Tipooperacion();
            //FuncionGlobal.alerta("OPERACIONES ACTUALIZADAS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("OPERACIONES ACTUALIZADAS CON EXITO", this.Page, pnl);
            getallTipooperacion();
        }


        private void add_Tipooperacion()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string codigo = this.gr_dato.Rows[i].Cells[0].Text;



                if (chk.Checked == true)
                {
                    string add = new TipooperacionBC().add_tipo_operacion_cliente(codigo, id_cliente);
                }
                else

                {
                    string add = new TipooperacionBC().del_tipo_operacion_cliente(codigo, id_cliente);
                
                
                }
            
            }

                
        }

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			id_familia = Convert.ToInt16(this.dl_familia.SelectedValue); 
			getallTipooperacion();
		}
    }
}
