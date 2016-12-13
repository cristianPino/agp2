using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.OrdenTrabajo;      
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP
{
    public partial class Master2 : System.Web.UI.MasterPage
    {
        public string Titulo = string.Empty;
        public string UrlManual = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));
            var menu = new OpcionmenuBC().GetOpcionmenuBycodigo(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["D"]));
            Titulo = menu.Descripcion;
            UrlManual = menu.UrlManual;

            if (Titulo != null)
            {
                lblTitulo.Text = Titulo;
                if (UrlManual.Trim() != string.Empty)
                {
                    lnkAyuda.Visible = true;   
                    lnkAyuda.HRef = UrlManual;
                }
                else
                {
                    lnkAyuda.Visible = false;                    
                }
            }
            if (Session["usrname"] == null || Session["usrname"].ToString().Trim() == "")
            {
                FuncionGlobal.alerta("Necesitamos que inicie sesion", Page);
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                menu_usuario();
                Usuario usuario =  Perfilusuario();
                Cliente cliente = new ClienteBC().getcliente(usuario.Cliente.Id_cliente);
                imgLogo.ImageUrl = cliente.Imagen;
            }
        }


        public Label LblInfo
        {
            get { return lblInfo; }
            set { lblInfo = value; }
        }
        public Label LblNombre
        {
            get { return lblNombre; }
            set { lblNombre = value; }
        }
        public Image ImeInfo
        {
            get { return imgInfo; }
            set { imgInfo = value; }
        }

        

        private void menu_usuario()
        {
            var lOpcionmenu = new OpcionmenuBC().GetOpcionmenuByusuario((string)(Session["usrname"]));
            ulMenu.Controls.Clear();
            var conteo = 0;  
            foreach (var mopcionmenu in lOpcionmenu)
            {
                ulMenu.InnerHtml += "<tr><td><a href=\"/" + mopcionmenu.Url +"?D=" +FuncionGlobal.FuctionEncriptar(mopcionmenu.Codigoopcionmenu)+ " \">" + mopcionmenu.Descripcion + "</a></td></tr>";
                conteo = conteo + 1;
            }  
           
        }

        private Usuario Perfilusuario()
        {
            var usr = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            Session.Add("id_cliente", usr.Cliente.Id_cliente);
            lblNombre.Text = usr.Nombre.ToUpper();
            return usr;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            Response.Redirect("~/Login.aspx", true);
        }

       



    }
}