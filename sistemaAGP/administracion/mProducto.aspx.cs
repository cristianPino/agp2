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
    public partial class mProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getproducto();
            }

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
			//DataTable dt = new DataTable();
			
			
			
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_tipooperacion();
                getproducto();

                limpiar();


            }
        }
        private void add_tipooperacion()
        {

          
            string add = new TipooperacionBC().add_Tipooperacion(this.txt_codigo.Text,this.txt_operacion.Text,this.txt_imagen.Text,this.txt_url_operacion.Text,this.txt_tamano.Text);

            FuncionGlobal.alerta("OPERACION INGRESADA CON EXITO", this.Page);
            limpiar();
            return;

        }


        private void limpiar()
        {
            this.txt_codigo.Text = "";
            this.txt_operacion.Text = "";
            this.txt_imagen.Text = "";
            this.txt_url_operacion.Text = "";


        }

        private Boolean valida_ingreso()
        {

            if (this.txt_codigo.Text == "" | this.txt_operacion.Text == "" | this.txt_imagen.Text == "" |  this.txt_url_operacion.Text == "" )
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return false;
            }
            return true;

        }
        public  void getproducto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("tamanoVen"));
			dt.Columns.Add(new DataColumn("url_documento"));
			dt.Columns.Add(new DataColumn("url_solicitud"));
          

            List<TipoOperacion> lTipooperacion = new TipooperacionBC().getallTipooperacion();
            foreach (TipoOperacion mtipooperacion in lTipooperacion)
            {
                DataRow dr = dt.NewRow();

                dr["codigo"] = mtipooperacion.Codigo;
                dr["operacion"] = mtipooperacion.Operacion;
                dr["tamanoVen"] = mtipooperacion.Tamano;
				dr["url_documento"] = "mdocumentosproducto.aspx?codigo=" + FuncionGlobal.FuctionEncriptar(mtipooperacion.Codigo);
				dr["url_solicitud"] = "mSolicitudRCProducto.aspx?codigo=" + FuncionGlobal.FuctionEncriptar(mtipooperacion.Codigo);

                
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }

       

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //estableciendo la propiedad EditIndex hacemos que esa fila se
            //ponga en edición
            gr_dato.EditIndex = e.NewEditIndex;
            //EnlazarDatos();
        }

        protected void txt_tamanoVen_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void editar_Click(object sender, EventArgs e)
        {
            int i;
            GridViewRow row;
         
            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string codigo= this.gr_dato.Rows[i].Cells[0].Text;

                    TextBox tamanoVen = (TextBox)gr_dato.Rows[i].FindControl("txt_tamanoVen");
					TextBox operacion = (TextBox)gr_dato.Rows[i].FindControl("txt_operacion");
                    string tamano = tamanoVen.Text.ToString();
					string descripcion = operacion.Text.ToString();
                 
                    string add = new TipooperacionBC().act_Tipooperacion(codigo,tamano,Convert.ToString(descripcion));

                }
            }

            getproducto();

        }
    }
}
