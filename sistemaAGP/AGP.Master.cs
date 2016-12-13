using System;      
using System.Web.UI.WebControls; 
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;

namespace sistemaAGP
{
	public partial class AGP : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));
            if (Session["usrname"] == null || Session["usrname"].ToString().Trim() == "")
			{
				FuncionGlobal.alerta("Necesitamos que inicie Session, por favor", Page);
				Response.Redirect("~/login.aspx");
			}
		    if (IsPostBack) return;
		    try
		    {   
		        menu_usuario();
		        Perfilusuario();
		    }
		    catch (Exception)
		    {
		        FuncionGlobal.alerta("Necesitamos que inicie sesión", Page);
		        Response.Redirect("~/login.aspx");
		    }
		}

		private void Perfilusuario()
		{
			Usuario usr = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
			this.img_cliente.Height = 60;
			this.img_cliente.ImageUrl = usr.Cliente.Imagen;
			Session.Add("id_cliente", usr.Cliente.Id_cliente);
			this.lbl_datos.Text = usr.Nombre.ToUpper();    
		}

		private void menu_usuario()
		{
            tr_menu.Nodes.Clear();
            tr_menu.Nodes.Add(new TreeNode("FAVORITOS", "FAVORITOS"));
            tr_menu.Nodes.Add(new TreeNode("CONTABILIDAD / FINANZAS", "CONTABILIDAD / FINANZAS"));
            tr_menu.Nodes.Add(new TreeNode("DATOS / ESTADISTICAS", "DATOS / ESTADISTICAS"));
            tr_menu.Nodes.Add(new TreeNode("MANTENEDORES", "MANTENEDORES"));
            tr_menu.Nodes.Add(new TreeNode("OPERACIONAL", "OPERACIONAL"));

            var lOpcionmenuFavorito = new OpcionmenuBC().GetOpcionmenuFavoritoByusuario((string)(Session["usrname"]));
		    foreach (var opcionMenu in lOpcionmenuFavorito)
		    {
                tr_menu.Nodes[0].ChildNodes.Add(new TreeNode(opcionMenu.Descripcion, "FAVORITOS", "", opcionMenu.Url + "?D=" + FuncionGlobal.FuctionEncriptar(opcionMenu.Codigoopcionmenu), ""));
		    }

            var lOpcionmenu = new OpcionmenuBC().GetOpcionmenuByusuario((string)(Session["usrname"]));  
 
            foreach (OpcionMenu opcionmenu in lOpcionmenu)
            {
                switch (opcionmenu.Orden)
                {
                    case 1:
                        tr_menu.Nodes[3].ChildNodes.Add(new TreeNode(opcionmenu.Descripcion, "MANTENEDORES", "", opcionmenu.Url + "?D=" + FuncionGlobal.FuctionEncriptar(opcionmenu.Codigoopcionmenu), ""));
                        break;
                    case 2:
                        tr_menu.Nodes[4].ChildNodes.Add(new TreeNode(opcionmenu.Descripcion, "OPERACIONAL", "", opcionmenu.Url + "?D=" + FuncionGlobal.FuctionEncriptar(opcionmenu.Codigoopcionmenu), ""));
                        break;
                    case 3:
                        tr_menu.Nodes[2].ChildNodes.Add(new TreeNode(opcionmenu.Descripcion, "DATOS / ESTADISTICAS", "", opcionmenu.Url + "?D=" + FuncionGlobal.FuctionEncriptar(opcionmenu.Codigoopcionmenu), ""));
                        break;
                    case 4:
                        tr_menu.Nodes[1].ChildNodes.Add(new TreeNode(opcionmenu.Descripcion, "CONTABILIDAD / FINANZAS", "", opcionmenu.Url + "?D=" + FuncionGlobal.FuctionEncriptar(opcionmenu.Codigoopcionmenu), ""));
                        break;

                }
            }

            tr_menu.CollapseAll();
		}

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            Response.Redirect("~/Login.aspx", true);
        }
	}
}