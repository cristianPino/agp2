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
    public partial class mOperacionUsuario : System.Web.UI.Page
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
            //CheckBox chk = (CheckBox)this.gr_dato.HeaderRow.FindControl("checkall");

        }

        protected void getallTipooperacion()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("operacion"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);

            DataColumn coll = new DataColumn("check_ingresa");
            coll.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(coll);




            List<TipoOperacion> ltipooperacion = new TipooperacionBC().getTipo_OperacionByUsuarioandfamilia(Convert.ToInt16(this.dl_cliente.SelectedValue), cuenta_usuario, "todo",Convert.ToInt16(this.dl_familia.SelectedValue),"TODO");


            foreach (TipoOperacion mtipo in ltipooperacion)
            {
                DataRow dr = dt.NewRow();

                dr["codigo"] = mtipo.Codigo;
                dr["operacion"] = mtipo.Operacion;
                dr["check"] = mtipo.Check;
                dr["check_ingresa"] = mtipo.Check_ingresa;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }


      
        protected void Button1_Click(object sender, EventArgs e)
        {
            add_usuario_tipo_operacion();
            FuncionGlobal.alerta("OPERACIONES ACTUALIZADAS CON EXITO", Page);
            getallTipooperacion();
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {

            FuncionGlobal.marca_check(gr_dato);


        }


        private void add_usuario_tipo_operacion()
        {
          
            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                
                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
                CheckBox chk2 = (CheckBox)gr_dato.Rows[i].FindControl("chk2");

                 string codigo = this.gr_dato.Rows[i].Cells[0].Text;

                if (chk.Checked == true)
                {
                   
                    string add = new TipooperacionBC().add_usuario_tipo_operacion(cuenta_usuario,codigo,Convert.ToInt16(this.dl_cliente.SelectedValue),chk2.Checked.ToString());

                }
                else
                {
                    string del = new TipooperacionBC().del_tipo_operacion_usuario(cuenta_usuario, codigo,Convert.ToInt16(this.dl_cliente.SelectedValue));
                }

            }

        
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

			FuncionGlobal.combofamilia_cliente(this.dl_familia, Convert.ToInt16(this.dl_cliente.SelectedValue ) );
            //FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), cuenta_usuario, dl_familia);
            
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (this.dl_familia.SelectedValue != "0")
			{
				this.getallTipooperacion();

			}

		}

          

    }
}
