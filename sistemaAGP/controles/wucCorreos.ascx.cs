using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class wucCorreos : System.Web.UI.UserControl
	{
		private int _rut;

		public int Rut
		{
			get { return Convert.ToInt32(ViewState["rut"] ?? _rut); }
			set { _rut = value; ViewState["rut"] = _rut; this.FillGridView(); }
		}

		public event CambioCorreoEventHandler CambioCorreo;
		public event GuardarCorreoEventHandler GuardarCorreo;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.FillGridView();
			}
		}

		protected void FillGridView()
		{
			var query = from c in new CorreoBC().getcorreos(this.Rut)
						orderby c.Id_correo ascending
						select new
						{
							id_correo = c.Id_correo,
							correo = c.Correo1.Trim(),
							prioridad = Convert.ToBoolean(c.Check)
						};
			this.gr_datos.DataSource = query;
			this.gr_datos.DataBind();

			this.pnl_grilla.Visible = true;
			this.pnl_nuevo.Visible = false;

			this.LimpiarForm();
		}

		protected void GuardarForm()
		{
			string output = new CorreoBC().add_correos(this.Rut, this.txt_correo.Text.Trim(), Convert.ToInt32(this.hdn_id_correo.Value));
			if (output != "")
			{
				ScriptManager.RegisterStartupScript(this.up_control, this.up_control.GetType(), "ErrorPersona", "alert('Ha ocurrido un error al guardar los datos del correo:\\n\\n" + output + "');", true);
				return;
			}
			this.Guardar_Correo(new EventArgs());
		}

		protected void LimpiarForm()
		{
			this.hdn_id_correo.Value = "0";
			this.txt_correo.Text = "";
		}

		protected void MostrarForm(int id)
		{
			this.LimpiarForm();
			Correo correo = (from c in new CorreoBC().getcorreos(this.Rut)
									 where c.Id_correo == id
									 select c).FirstOrDefault<Correo>();
			if (correo != null)
			{
				this.hdn_id_correo.Value = correo.Id_correo.ToString();
				this.txt_correo.Text = correo.Correo1.Trim();
			}
		}

		protected void bt_agregar_Click(object sender, EventArgs e)
		{
			this.LimpiarForm();
			this.pnl_grilla.Visible = false;
			this.pnl_nuevo.Visible = true;
		}

		protected void chk_prioridad_CheckedChanged(object sender, EventArgs e)
		{
			int index = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;
			for (int i = 0; i < this.gr_datos.Rows.Count; i++)
			{
				int id_correo = Convert.ToInt32(this.gr_datos.DataKeys[i].Values[0]);
				CheckBox chk = (CheckBox)this.gr_datos.Rows[i].FindControl("chk_prioridad");
				chk.Checked = (index == i) ? true : false;
				chk.Enabled = (index == i) ? false : true;
				string output = new CorreoBC().actu_checkCorreo(id_correo, chk.Checked.ToString());
			}
			this.Cambiar_Correo(new EventArgs());
		}

		protected void gr_datos_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				CheckBox chk = (CheckBox)e.Row.FindControl("chk_prioridad");
				chk.Enabled = (!chk.Checked);

				ImageButton btn = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
				btn.CommandName = "Editar";
				btn.CommandArgument = this.gr_datos.DataKeys[e.Row.RowIndex].Values[0].ToString();
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.GuardarForm();
			this.FillGridView();
		}

		protected void bt_cancelar_Click(object sender, EventArgs e)
		{
			this.pnl_grilla.Visible = true;
			this.pnl_nuevo.Visible = false;
			this.LimpiarForm();
		}

		protected void gr_datos_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Editar")
			{
				this.pnl_grilla.Visible = false;
				this.pnl_nuevo.Visible = true;
				this.MostrarForm(Convert.ToInt32(e.CommandArgument));
			}
		}

		protected virtual void Guardar_Correo(EventArgs e)
		{
			if (GuardarCorreo != null)
			{
				GuardarCorreo(this, e);
			}
		}

		protected virtual void Cambiar_Correo(EventArgs e)
		{
			if (CambioCorreo != null)
			{
				CambioCorreo(this, e);
			}
		}
	}
}