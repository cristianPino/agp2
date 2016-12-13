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
	public partial class wucTelefonos : System.Web.UI.UserControl
	{
		private int _rut;

		public int Rut
		{
			get { return Convert.ToInt32(ViewState["rut"] ?? _rut); }
			set { _rut = value; ViewState["rut"] = _rut; this.FillGridView(); }
		}

		public event CambioTelefonoEventHandler CambioTelefono;
		public event GuardarTelefonoEventHandler GuardarTelefono;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.FillGridView();
			}
		}

		protected void FillGridView()
		{
			var query = from t in new TelefonoBC().gettelefonos(this.Rut)
						orderby t.Id_telefono ascending
						select new
						{
							id_telefono = t.Id_telefono,
							tipo = t.Tipo_telefono,
							numero = t.Numero.ToString(),
							prioridad = Convert.ToBoolean(t.Check)
						};
			this.gr_datos.DataSource = query;
			this.gr_datos.DataBind();

			this.pnl_grilla.Visible = true;
			this.pnl_nuevo.Visible = false;

			this.LimpiarForm();
		}

		protected void GuardarForm()
		{
			string output = new TelefonoBC().add_telefonos(this.Rut, this.dl_tipo_telefono.SelectedValue.Trim(), Convert.ToInt32(this.txt_numero.Text), Convert.ToInt32(this.hdn_id_telefono.Value));
			if (output != "")
			{
				ScriptManager.RegisterStartupScript(this.up_control, this.up_control.GetType(), "ErrorPersona", "alert('Ha ocurrido un error al guardar los datos del teléfono:\\n\\n" + output + "');", true);
				return;
			}
			this.Guardar_Telefono(new EventArgs());
		}

		protected void LimpiarForm()
		{
			FuncionGlobal.comboparametro(this.dl_tipo_telefono, "TTEL");
			this.hdn_id_telefono.Value = "0";
			this.txt_numero.Text = "";
		}

		protected void MostrarForm(int id)
		{
			this.LimpiarForm();
			Telefonos telefono = (from t in new TelefonoBC().gettelefonos(this.Rut)
								  where t.Id_telefono == id
								  select t).FirstOrDefault<Telefonos>();
			if (telefono != null)
			{
				this.hdn_id_telefono.Value = telefono.Id_telefono.ToString();
				this.txt_numero.Text = telefono.Numero.ToString();
				this.dl_tipo_telefono.SelectedValue = telefono.Tipo_telefono.Trim().ToUpper();
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
				int id_telefono = Convert.ToInt32(this.gr_datos.DataKeys[i].Values[0]);
				CheckBox chk = (CheckBox)this.gr_datos.Rows[i].FindControl("chk_prioridad");
				chk.Checked = (index == i) ? true : false;
				chk.Enabled = (index == i) ? false : true;
				string output = new TelefonoBC().act_checkTelefonos(id_telefono, chk.Checked.ToString());
			}
			this.Cambiar_Telefono(new EventArgs());
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

		protected virtual void Guardar_Telefono(EventArgs e)
		{
			if (GuardarTelefono != null)
			{
				GuardarTelefono(this, e);
			}
		}

		protected virtual void Cambiar_Telefono(EventArgs e)
		{
			if (CambioTelefono != null)
			{
				CambioTelefono(this, e);
			}
		}
	}
}