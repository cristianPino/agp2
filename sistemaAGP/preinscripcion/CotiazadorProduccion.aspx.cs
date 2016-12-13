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
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;

namespace sistemaAGP.preinscripcion
{
    public partial class CotiazadorProduccion : System.Web.UI.Page
    {
        public Usuario Usuario;
        private string id_usuario;
        protected void Page_Load(object sender, EventArgs e)
        {


            List<Cotizacion> lBancofinanciera = new GastosComunesBC().getallCotiza((string)(Session["usrname"]));

            this.id_usuario= (string)(Session["usrname"]);
         
            this.gr_dato.DataSource = lBancofinanciera;
            this.gr_dato.DataBind();

            if (IsPostBack) return;
            FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
            Usuario usr = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            this.id_vendedor.Text = usr.Nombre;
            //FuncionGlobal.comboparametro(dlTipoDoc, "TIDOCINF"); 
          //  FuncionGlobal.combomarcavehiculo(dlmarca);


        }

        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    int i;
        //    GridViewRow row;
        //    ImageButton but;
        //    for (i = 0; i < gr_dato.Rows.Count; i++)
        //    {
        //        row = gr_dato.Rows[i];
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            but = (ImageButton)row.FindControl("ib_cuenta");
        //            but.Attributes.Add("onclick", "javascript:window.showModalDialog('ingreso.aspx?codigo_banco=" + FuncionGlobal.FuctionEncriptar(row.Cells[0].Text) + "','_blank','DialogHeight:355px,DialogWidth:500px, top:150,left:150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=no,copyhistory= false')");




        //        }
        //    }
        //}


        protected void dlmarca_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  FuncionGlobal.comboModelovehiculo(dlSucursal, Convert.ToInt16(dlmarca.SelectedValue));
            //FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), dlFamilia); 
            //  FuncionGlobal.CombofamiliabyusuarioInfocarCav((string)(Session["usrname"]), dlFamilia); 


        }

        protected void ibPedir_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox3.Text != "" && TextBox2.Text != "" && TextBox1.Text != "" && dl_cliente.SelectedIndex != 0) 
                
            {
                this.ibPedir0.Visible = true;

                add_oper();
            }
        }

        protected void ibPedir_Click2(object sender, ImageClickEventArgs e)
        {
           
            this.ibPedir0.Visible = false;
            
          //  add_oper();
        }


        protected void add_oper()
        {

        

            var fecha = Convert.ToDateTime(TextBox1.Text);
           

            this.ibPedir0.Attributes.Add("onclick", "javascript:window.open('../reportes/view_cotizacion.aspx?fecha=" +
                                                   fecha.ToShortDateString() + "&id_marca=" + this.TextBox3.Text
                                                   + "&monto=" + this.TextBox2.Text.ToString() +  "&Vendedor=" + this.id_vendedor.Text.ToString()+ "&Adquiriente=" + this.TextBox4.Text.ToString() + 
                                                   "&prod="+DropDownList1.SelectedValue.ToString() +

                                                   "&cuenta_usuario=" + this.id_usuario + "&Fechatramite=" + this.Tramitacion.Text.ToString() + "&id_cliente=" + this.dl_cliente.SelectedValue.ToString() +
                                                   "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
            



            string add = new GastosComunesBC().add_cotizacion(this.TextBox3.Text,fecha.ToShortDateString().ToString(), Convert.ToInt32(this.TextBox2.Text),this.id_vendedor.Text, this.TextBox4.Text);
           
        }

        public string AddVarias(string tipoOperacion)
        {
            //   var correctas = 0;
            //   var incorrectas = "Patentes Incorrectas por error de formato: - ";
            ////   var texto = txtVariasPatentes.Text.Trim();
            //   //texto = texto.Replace("-", "");
            //   //texto = texto.Replace(" ", "");
            //   char[] delimiterChars = { '\n' };
            // //  string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            //   if (words.Any())
            //   {
            //       foreach (var patente in words.Select(x => x.Substring(0, 6)))
            //       {
            //           if (FuncionGlobal.formatoPatente(patente))
            //           {
            //               var xx = new OperacionBC().add_operacion(0, Convert.ToInt16(dlmarca.SelectedValue),
            //                                                        tipoOperacion, (string)(Session["usrname"]), 0, "",
            //                                                        Convert.ToInt32(dlSucursal.SelectedValue),0);
            //               new InfoAutoBC().add_Datosvehiculo(xx, patente, 259);
            //               new EstadooperacionBC().add_estado_orden(xx, 1, tipoOperacion, "Solicitud ingresada",
            //                                                        (string)(Session["usrname"]));
            //               correctas++;
            //           }
            //           else
            //           {
            //               incorrectas = incorrectas + patente + "- ";
            //           }
            //       }


            //   }
            return "";
        }


        public void Button1_Click(object sender, EventArgs e)
        {



            List<Cotizacion> lBancofinanciera = new GastosComunesBC().getallCotiza((string)(Session["usrname"]));

                this.gr_dato.DataSource = lBancofinanciera;
                this.gr_dato.DataBind();


          
            

        }


        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje, Page, UpdatePanel1);
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  FuncionGlobal.ComboProductosByFamiliaClienteUsuario(dlTipoDoc, Convert.ToInt32(dlFamilia.SelectedValue), Convert.ToInt16(dlmarca.SelectedValue), Session["usrname"].ToString());
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


