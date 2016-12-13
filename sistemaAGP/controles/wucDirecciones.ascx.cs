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
	public partial class wucDirecciones : System.Web.UI.UserControl
	{
		private int _rut;

		public int Rut
		{
			get { return Convert.ToInt32(ViewState["rut"] ?? _rut); }
			set { _rut = value; ViewState["rut"] = _rut; this.FillGridView(); }
		}

		public event CambioDireccionEventHandler CambioDireccion;
		public event GuardarDireccionEventHandler GuardarDireccion;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.FillGridView();
			}
		}

		protected void FillGridView()
		{
			var query = from d in new DireccionesBC().getdirecciones(this.Rut)
						orderby d.Id_direccion ascending
						select new
						{
							id_direccion = d.Id_direccion,
							tipo = d.Tipo_direccion,
							direccion = (string.Format("{0} {1}", d.Direccion, d.Numero).Trim() + ((d.Complemento.Trim() != "") ? ", " + d.Complemento.Trim() : "")).ToUpper(),
							comuna = d.Comuna.Nombre.Trim().ToUpper(),
							ciudad = d.Comuna.Ciudad.Region.Capital.Trim().ToUpper(),
							prioridad = Convert.ToBoolean(d.Check)
						};
			this.gr_datos.DataSource = query;
			this.gr_datos.DataBind();
			
			this.pnl_grilla.Visible = true;
			this.pnl_nuevo.Visible = false;

			this.LimpiarForm();
		}

		protected void GuardarForm()
		{
			string output = new DireccionesBC().add_direcciones(this.Rut, this.txt_direccion.Text.Trim().ToUpper(), this.dl_tipo_direccion.SelectedValue.Trim(), this.txt_numero.Text.Trim().ToUpper(), Convert.ToInt32(this.dl_comuna.SelectedValue), this.txt_complemento.Text.Trim().ToUpper(), Convert.ToInt32(this.hdn_id_direccion.Value));
			if (output != "")
			{
				ScriptManager.RegisterStartupScript(this.up_control, this.up_control.GetType(), "ErrorPersona", "alert('Ha ocurrido un error al guardar los datos de la dirección:\\n\\n" + output + "');", true);
				return;
			}
			this.Guardar_Direccion(new EventArgs());
		}

		protected void LimpiarForm()
		{
			FuncionGlobal.comboparametro(this.dl_tipo_direccion, "TDIR");
			FuncionGlobal.combocapitales(this.dl_ciudad);
			FuncionGlobal.combocomunabycapitales(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
			this.hdn_id_direccion.Value = "0";
			this.txt_direccion.Text = "";
			this.txt_numero.Text = "";
			this.txt_complemento.Text = "";
		}

		protected void MostrarForm(int id)
		{
			this.LimpiarForm();
			Direcciones direccion = (from d in new DireccionesBC().getdirecciones(this.Rut)
									 where d.Id_direccion == id
									 select d).FirstOrDefault<Direcciones>();
			if (direccion != null)
			{
				this.hdn_id_direccion.Value = direccion.Id_direccion.ToString();
				this.txt_direccion.Text = direccion.Direccion.Trim().ToUpper();
				this.txt_numero.Text = direccion.Numero.Trim().ToUpper();
				this.txt_complemento.Text = direccion.Complemento.Trim().ToUpper();
				this.dl_ciudad.SelectedValue = direccion.Comuna.Ciudad.Region.Id_region.ToString();
				FuncionGlobal.combocomunabycapitales(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
				this.dl_comuna.SelectedValue = direccion.Comuna.Id_Comuna.ToString();
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
				int id_direccion = Convert.ToInt32(this.gr_datos.DataKeys[i].Values[0]);
				CheckBox chk = (CheckBox)this.gr_datos.Rows[i].FindControl("chk_prioridad");
				chk.Checked = (index == i) ? true : false;
				chk.Enabled = (index == i) ? false : true;
				string output = new DireccionesBC().act_checkDireccion(id_direccion, chk.Checked.ToString());
			}
			this.Cambio_Direccion(new EventArgs());
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

		protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocomunabycapitales(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
		}

		protected virtual void Cambio_Direccion(EventArgs e)
		{
			if (CambioDireccion != null)
			{
				CambioDireccion(this, e);
			}
		}

		protected virtual void Guardar_Direccion(EventArgs e)
		{
			if (GuardarDireccion != null)
			{
				GuardarDireccion(this, e);
			}
		}
	}
}