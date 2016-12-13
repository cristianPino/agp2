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
    public partial class mMovimiento_Cta : System.Web.UI.Page
    {
        private string cuenta_usuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {

           
            string nombre;

            cuenta_usuario = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"].ToString());

            Usuario mpersona= new UsuarioBC().GetUsuario(cuenta_usuario);
            nombre = mpersona.Nombre;
            this.lbl_nombre.Text = nombre;
            this.lbl_rut.Text = cuenta_usuario;

            if (!IsPostBack)
            {
                getCta_Cte();
                
                FuncionGlobal.comboparametro(this.dl_tipo, "TMONT");
                combocuenta();
                Carga_Link();
            }
        }

        private void getCta_Cte()
        {
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("fecha_hora"));
            dt.Columns.Add(new DataColumn("abono"));
            dt.Columns.Add(new DataColumn("cargo"));
            dt.Columns.Add(new DataColumn("saldo"));

            List<Movimiento_Cta_Cte> lmovimiento = new Movimiento_Cta_CteBC().getCta_Cte(cuenta_usuario);
            foreach (Movimiento_Cta_Cte mmovimiento in lmovimiento)
            {
                DataRow dr = dt.NewRow();

                dr["fecha_hora"] = mmovimiento.Fecha_hora;
                dr["abono"] = mmovimiento.Abono;
                dr["cargo"] = mmovimiento.Carga;
                dr["saldo"] = mmovimiento.Abono - mmovimiento.Carga;

               

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.txt_fecha_movimiento.Text == ""  || this.txt_monto.Text =="" || this.dl_tipo.SelectedValue=="0"||this.dl_cuenta.SelectedValue=="0")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new Movimiento_Cta_CteBC().add_Cta_Cte(Convert.ToInt32(this.dl_cuenta.SelectedValue),
                                                            Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_monto.Text)),this.dl_tipo.SelectedValue,
                                                            Convert.ToDateTime(this.txt_fecha_movimiento.Text),
                                                            (string)Session["usrname"]);

            FuncionGlobal.alerta("MOVIMIENTO REALIZADO CON EXITO", Page);
            this.txt_monto.Text = "";
            this.txt_fecha_movimiento.Text = "";
            getCta_Cte();

        }
       
   
        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fecha_movimiento_TextChanged(object sender, EventArgs e)
        {

        }
        public void combocuenta()
        {
           
			Cuenta_Corriente mparametro = new Cuenta_Corriente();
			mparametro.Id_cta_cte = 0;
			mparametro.Cuenta = "Seleccionar";
			List<Cuenta_Corriente> lParametro = new Cta_CteBC().getCta_Cte(cuenta_usuario);
			lParametro.Add(mparametro);
			this.dl_cuenta.DataSource = lParametro;
			this.dl_cuenta.DataValueField = "id_cta_cte";
            this.dl_cuenta.DataTextField = "cuenta";
            this.dl_cuenta.DataBind();
            this.dl_cuenta.SelectedValue = "0";
			return;
		

        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txt_monto_TextChanged(object sender, EventArgs e)
        {
            this.txt_monto.Text = FuncionGlobal.NumeroConFormato(this.txt_monto.Text);
        }


        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
            ImageButton ibuton;
            
            string fecha;

            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    fecha = (string)row.Cells[0].Text;
                
                        ibuton = (ImageButton)row.FindControl("ib_opedia");
                        ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_Movimi_opera_dia.aspx?cuenta_usuario=" +this.lbl_rut.Text +"&fecha=" +fecha+ "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
                        
                        ibuton = (ImageButton)row.FindControl("ib_carga");
                        ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_Movimi_dia.aspx?cuenta_usuario=" + this.lbl_rut.Text +"&fecha="+fecha+ "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
                    
                }
            }
        }
    }
}
