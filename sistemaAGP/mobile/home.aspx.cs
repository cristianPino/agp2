using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.mobile
{
	public partial class home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Usuario usr = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
				Session.Add("id_cliente", usr.Cliente.Id_cliente);

				this.lbl_usuario.Text = usr.Nombre.ToUpper().Trim();

				this.ddl_menu.Items.Clear();
				this.ddl_menu.Items.Add(new ListItem("<<< Seleccione una opción >>>", "0"));
				this.ddl_menu.AppendDataBoundItems = true;
				this.ddl_menu.DataSource = from m in new OpcionmenuBC().GetOpcionmenuByusuario(usr.UserName)
											  orderby m.Orden, m.Descripcion
											  select m;
				this.ddl_menu.DataTextField = "Descripcion";
				this.ddl_menu.DataValueField = "Codigoopcionmenu";
				this.ddl_menu.DataBind();
			}
		}
	}
}