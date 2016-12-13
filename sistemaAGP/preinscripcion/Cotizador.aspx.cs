using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP
{
	public partial class Cotizador : Page
    {
        public Usuario Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            //FuncionGlobal.comboparametro(dlTipoDoc, "TIDOCINF"); 
            FuncionGlobal.combomarcavehiculo(dlmarca);
           
        }  

        protected void dlmarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboModelovehiculo(dlSucursal, Convert.ToInt16(dlmarca.SelectedValue));
            //FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), dlFamilia); 
          //  FuncionGlobal.CombofamiliabyusuarioInfocarCav((string)(Session["usrname"]), dlFamilia); 


        }

        protected void ibPedir_Click(object sender, ImageClickEventArgs e)
        {
            add_oper();
        }

        protected void add_oper()
        {
		this.ibPedir.Attributes.Add("onclick", "javascript:window.open('../reportes/view_cotizacion.aspx?fecha=" +
				   this.TextBox1.Text + "&id_marca=" + this.dlSucursal.SelectedValue
				   + "&monto=" + this.TextBox2.Text.ToString() + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");


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

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje, Page, UpdatePanel1);
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {    
          //  FuncionGlobal.ComboProductosByFamiliaClienteUsuario(dlTipoDoc, Convert.ToInt32(dlFamilia.SelectedValue), Convert.ToInt16(dlmarca.SelectedValue), Session["usrname"].ToString());
        }

       
    }
}
