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
    public partial class mContratoCliente : System.Web.UI.Page
    {
        private Int16 id_cliente;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_cli_encrip;

            id_cli_encrip =  FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

            id_cliente = Convert.ToInt16(id_cli_encrip);
            

            if (!IsPostBack)
            {
                getproducto(id_cliente,this.dl_producto);

            }
            
        

            

        }
        private void gallcontrato()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_contrato"));
            dt.Columns.Add(new DataColumn("nombre"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);



            List<ContratoCliente> lcontratocliente = new ContratoClienteBC().getContratoByClienteProducto(id_cliente, "todo",this.dl_producto.SelectedValue.ToString());


            foreach (ContratoCliente mcontratocliente in lcontratocliente)
            {
                DataRow dr = dt.NewRow();

                dr["nombre"] = mcontratocliente.Nombre;
                dr["id_contrato"] = mcontratocliente.Id_contrato;
                dr["check"] = mcontratocliente.Check;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }
        private void getproducto(Int16 id_cliente, DropDownList combo)
        {
            TipoOperacion mEstadotipooperacion = new TipoOperacion();

            mEstadotipooperacion.Codigo = "0";
            mEstadotipooperacion.Operacion = "Seleccionar";

            List<TipoOperacion> lEstadotipooperacion = new TipooperacionBC().getTipo_OperacionByCliente(id_cliente,"todo");
            lEstadotipooperacion.Add(mEstadotipooperacion);

            combo.DataSource = lEstadotipooperacion;
            combo.DataValueField = "codigo";
            combo.DataTextField = "operacion";
            combo.DataBind();
            combo.SelectedValue = "0";
            return;
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_Tipooperacion();
            //FuncionGlobal.alerta("OPERACIONES ACTUALIZADAS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("CONTRATOS ACTUALIZADOS ACTUALIZADAS CON EXITO", this.Page, pnl);
            gallcontrato();
        }


        private void add_Tipooperacion()
        {

            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                Int32 id_contrato = Convert.ToInt32(this.gr_dato.Rows[i].Cells[0].Text);



                if (chk.Checked == true)
                {
                    string add = new ContratoClienteBC().add_contrato_cliente(id_contrato, id_cliente,this.dl_producto.SelectedValue.ToString());
                }
                else

                {
					string add = new ContratoClienteBC().del_contrato_cliente(id_contrato, id_cliente, this.dl_producto.SelectedValue.ToString());
                
                
                }
            
            }

                
        }

        protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            gallcontrato();
        }
    }
}
