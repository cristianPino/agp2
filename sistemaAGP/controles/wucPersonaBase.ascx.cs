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
	public partial class wucPersonaBase : System.Web.UI.UserControl
	{
		#region Propiedades
		
		public double Rut
		{
			get { return Convert.ToDouble(ViewState["rut"] ?? 0); }
			set { ViewState["rut"] = value; this.Busca_Persona(Convert.ToDouble(ViewState["rut"])); }
		}

		public string DV
		{
			get { return this.txt_dv.Text.Trim(); }
			set { this.txt_dv.Text = value; }
		}

		public string Nombre
		{
			get { return this.txt_nombre.Text.Trim(); }
			set { this.txt_nombre.Text = value; }
		}

		public string Paterno
		{
			get { return this.txt_paterno.Text.Trim(); }
			set { this.txt_paterno.Text = value; }
		}

		public string Materno
		{
			get { return this.txt_materno.Text.Trim(); }
			set { this.txt_materno.Text = value; }
		}

		public string Sexo
		{
			get { return this.dl_sexo.SelectedValue.Trim(); }
			set { FuncionGlobal.BuscarValueCombo(this.dl_sexo, value); }
		}

		public string EstadoCivil
		{
			get { return this.dl_estado_civil.SelectedValue.Trim(); }
			set { FuncionGlobal.BuscarValueCombo(this.dl_estado_civil, value); }
		}

		public string Nacionalidad
		{
			get { return this.txt_nacionalidad.Text.Trim(); }
			set { this.txt_nacionalidad.Text = value; }
		}

		public string Profesion
		{
			get { return this.txt_profesion.Text.Trim(); }
			set { this.txt_profesion.Text = value; }
		}
		#endregion

		public bool HabilitarOtrosDatos
		{
			get { return Convert.ToBoolean(ViewState["otrosDatos"] ?? false); }
			set { ViewState["otrosDatos"] = value; }
		}

		public bool HabilitaLimpiar
		{
			get { return Convert.ToBoolean(ViewState["limpiar"] ?? true); }
			set { ViewState["limpiar"] = value; }
		}

		public string Titulo
		{
			get { return (ViewState["titulo"] ?? "").ToString(); }
			set { ViewState["titulo"] = value; }
		}

		public string MensajeError
		{
			get { return (ViewState["mensajeError"] ?? "").ToString(); }
		}

		public bool SoloPersonas
		{
			get { return Convert.ToBoolean(ViewState["solo_personas"] ?? false); }
			set { ViewState["solo_personas"] = value; }
		}

		public event CambioPersonaEventHandler CambioPersona;
		public event LimpiarPersonaEventHandler LimpiarPersona;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["solo_personas"] = Convert.ToBoolean(ViewState["solo_personas"] ?? this.SoloPersonas);
				FuncionGlobal.comboparametro(this.dl_estado_civil, "ESCIVIL");
				FuncionGlobal.comboparametro(this.dl_sexo, "SEXO");

				//this.txt_rut.Attributes.Add("onkeyup", "format(this)");
				//this.txt_rut.Attributes.Add("onchange", "format(this)");

				this.bt_limpia_persona.Visible = this.HabilitaLimpiar;

				this.Limpiar_Form();
				this.Busca_Persona(this.Rut);
			}
		}

		protected void txt_rut_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_rut.Text.Trim() != "")
			{
				//this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);
				this.Busca_Persona(Convert.ToDouble(this.txt_rut.Text.Replace(".", "")));
				//this.txt_rut.Text = Convert.ToInt32(this.txt_rut.Text).ToString("N0");
				//this.txt_nombre.Focus();
			}
		}

		protected void bt_limpia_persona_Click(object sender, EventArgs e)
		{
			this.Limpiar_Form();
		}

		private void Busca_Persona(double rut)
		{
			Persona persona = new PersonaBC().getpersonabyrut(rut);
			ViewState["rut"] = rut;
			ViewState["apellidos"] = true;
			if (rut >= 50000000)
			{
				ViewState["apellidos"] = false;
				ViewState["otrosDatos"] = false;
			}
			this.pnl_apellidos.Visible = Convert.ToBoolean(ViewState["apellidos"] ?? false);
			this.rfv_paterno.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
			this.rfv_paterno2.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
			this.rfv_materno.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
			this.rfv_materno2.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);

			if (Convert.ToBoolean(ViewState["apellidos"] ?? false))
			{
				this.lbl_rut.Text = "R.U.N.";
				this.lbl_nombre.Text = "Nombres";
			}
			else
			{
				this.lbl_rut.Text = "R.U.T.";
				this.lbl_nombre.Text = "Razón Social";
			}

			this.rfv_rut.ErrorMessage = string.Format("{0} ({1})", this.lbl_rut.Text, this.Titulo);
			this.rfv_nombre.ErrorMessage = string.Format("{0} ({1})", this.lbl_nombre.Text, this.Titulo);

			this.pnl_otros_datos.Visible = Convert.ToBoolean(ViewState["otrosDatos"]);
            //if (Convert.ToBoolean(ViewState["otrosDatos"]))
            //{
            //    this.rfv_estado_civil.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
            //    this.rfv_estado_civil2.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
            //    this.rfv_sexo.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
            //    this.rfv_sexo2.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
            //}

			if (persona != null && rut != 0)
			{
				this.txt_rut.Text = persona.Rut.ToString("N0");
				this.txt_rut.Enabled = false;
				this.txt_dv.Enabled = false;
				this.txt_nombre.Text = persona.Nombre;
				this.txt_paterno.Text = persona.Apellido_paterno;
				this.txt_materno.Text = persona.Apellido_materno;
				this.txt_dv.Text = persona.Dv;

				this.txt_profesion.Text = persona.Profesion;
				this.txt_nacionalidad.Text = persona.Nacionalidad;
				FuncionGlobal.BuscarValueCombo(dl_sexo, persona.Sexo);
				FuncionGlobal.BuscarValueCombo(this.dl_estado_civil, persona.Estado_civil);

				this.Cambio_Persona(new CambioPersonaEventArgs(persona));
			}
			else if (rut == 0)
			{
				this.txt_rut.Text = "";
				this.txt_dv.Text = "";
				this.txt_rut.Enabled = true;
				this.txt_dv.Enabled = false;
				this.txt_nombre.Focus();
			}
			else
			{
				this.txt_rut.Text = rut.ToString("N0");
				this.txt_dv.Text = FuncionGlobal.digitoVerificador(rut.ToString());
				this.txt_rut.Enabled = false;
				this.txt_dv.Enabled = false;
				this.txt_nombre.Focus();
			}
		}

		protected void Limpiar_Form()
		{
			this.txt_rut.Enabled = true;
			this.txt_rut.Text = "";
			this.txt_dv.Text = "";
			this.txt_nombre.Text = "";
			this.txt_paterno.Text = "";
			this.txt_materno.Text = "";
			this.txt_materno.Enabled = true;
			this.txt_paterno.Enabled = true;
			this.txt_nacionalidad.Text = "";
			this.txt_profesion.Text = "";
			this.dl_estado_civil.SelectedValue = "0";
			this.dl_sexo.SelectedValue = "0";

			this.pnl_apellidos.Visible = Convert.ToBoolean(ViewState["apellidos"] ?? false);
			this.rfv_paterno.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);
			this.rfv_materno.Enabled = Convert.ToBoolean(ViewState["apellidos"] ?? false);

			if (Convert.ToBoolean(ViewState["apellidos"] ?? false))
			{
				this.lbl_rut.Text = "R.U.N.";
				this.lbl_nombre.Text = "Nombres";
			}
			else
			{
				this.lbl_rut.Text = "R.U.T.";
				this.lbl_nombre.Text = "Razón Social";
			}

			this.rfv_rut.ErrorMessage = string.Format("{0} ({1})", this.lbl_rut.Text, this.Titulo);
			this.rfv_rut2.ErrorMessage = string.Format("{0} ({1})", this.lbl_rut.Text, this.Titulo);
			this.rv_rut.Enabled = Convert.ToBoolean(ViewState["solo_personas"]);
			this.rfv_nombre.ErrorMessage = string.Format("{0} ({1})", this.lbl_nombre.Text, this.Titulo);
			this.rfv_nombre2.ErrorMessage = string.Format("{0} ({1})", this.lbl_nombre.Text, this.Titulo);
			this.rfv_paterno.ErrorMessage = string.Format("{0} ({1})", "Apellido Paterno", this.Titulo);
			this.rfv_paterno2.ErrorMessage = string.Format("{0} ({1})", "Apellido Paterno", this.Titulo);
			this.rfv_materno.ErrorMessage = string.Format("{0} ({1})", "Apellido Materno", this.Titulo);
			this.rfv_materno2.ErrorMessage = string.Format("{0} ({1})", "Apellido Materno", this.Titulo);
            //this.rfv_estado_civil.ErrorMessage = string.Format("{0} ({1})", "Estado Civil", this.Titulo);
            //this.rfv_estado_civil2.ErrorMessage = string.Format("{0} ({1})", "Estado Civil", this.Titulo);
            //this.rfv_sexo.ErrorMessage = string.Format("{0} ({1})", "Sexo", this.Titulo);
            //this.rfv_sexo2.ErrorMessage = string.Format("{0} ({1})", "Sexo", this.Titulo);

			this.pnl_otros_datos.Visible = Convert.ToBoolean(ViewState["otrosDatos"]);

			this.Limpiar_Persona(new EventArgs());
		}

		protected bool Validar_Form()
		{
			if (this.txt_rut.Text == "")
			{
				ScriptManager.RegisterStartupScript(this.up_persona, this.up_persona.GetType(), "ErrorPersona", "alert('Debe ingresar el RUT de la persona');", true);
				this.txt_rut.Focus();
				return false;
			}
			else if (Convert.ToDouble(this.txt_rut.Text) == 0)
			{
				FuncionGlobal.alerta("Debe ingresar el RUT de la persona", Page);
				ScriptManager.RegisterStartupScript(this.up_persona, this.up_persona.GetType(), "ErrorPersona", "alert('Debe ingresar el RUT de la persona');", true);
				this.txt_rut.Focus();
				return false;
			}
			if (this.txt_nombre.Text.Trim() == "")
			{
				ScriptManager.RegisterStartupScript(this.up_persona, this.up_persona.GetType(), "ErrorPersona", "alert('Debe ingresar el nombre de la persona');", true);
				this.txt_nombre.Focus();
				return false;
			}
			return true;
		}

		public bool Guardar_Form()
		{
			if (!Validar_Form()) return false;

			string tipo_persona = (Convert.ToDouble(this.txt_rut.Text) > 50000000) ? "JUR" : "NAT";
			string output = "";

			//Guarda los datos de la persona
			output = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text), this.txt_dv.Text.ToUpper().Trim(), 1, "", this.txt_nombre.Text.ToUpper().Trim(), this.txt_paterno.Text.ToUpper().Trim(), this.txt_materno.Text.ToUpper().Trim(), this.dl_sexo.SelectedValue.Trim(), tipo_persona, this.txt_nacionalidad.Text.ToUpper().Trim(), this.txt_profesion.Text.ToUpper().Trim(), this.dl_estado_civil.SelectedValue.Trim(), "", "", "", "", "", "", "0","");
			if (output != "")
			{
				ViewState["mensajeError"] = output;
				ScriptManager.RegisterStartupScript(this.up_persona, this.up_persona.GetType(), "ErrorPersona", "alert('Ha ocurrido un error al guardar los datos de la persona:\\n\\n" + output + "');", true);
				return false;
			}

			this.Rut = Convert.ToDouble(this.txt_rut.Text.Replace(System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator, ""));

			return true;
		}

		protected virtual void Cambio_Persona(CambioPersonaEventArgs e)
		{
			if (CambioPersona != null) CambioPersona(this, e);
		}

		protected virtual void Limpiar_Persona(EventArgs e)
		{
			if (LimpiarPersona != null) LimpiarPersona(this, e);
		}
	}
}