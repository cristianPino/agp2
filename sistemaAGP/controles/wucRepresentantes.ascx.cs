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
	public partial class wucRepresentantes : System.Web.UI.UserControl
	{
		private int _rut;

		public int Rut
		{
			get { return Convert.ToInt32(ViewState["rut"] ?? _rut); }
			set { _rut = value; ViewState["rut"] = _rut; this.FillGridView(); }
		}

		private string _titulo;

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		private string _error = "";

		public string MensajeError
		{
			get { return _error; }
		}

		public event CambioRepresentantesEventHandler CambioRepresentantes;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.agp_persona.Titulo = this.Titulo;
				this.FillGridView();				
			}
		}

		protected void FillGridView()
		{
			var query = from r in new ParticipanteBC().Getparticipante(Convert.ToDouble(this.Rut))
						join p in new ParametroBC().GetParametroByTipoParametro("TIPA") on r.Tipo.ToUpper().Trim() equals p.Codigoparametro.ToUpper().Trim()
						select new
						{
							rut = r.Participe.Rut,
							rut_dv = string.Format("{0:N0}-{1}", r.Participe.Rut, r.Participe.Dv),
							nombre = string.Format("{0} {1} {2}", r.Participe.Nombre, r.Participe.Apellido_paterno, r.Participe.Apellido_materno).Trim(),
							tipo = p.Valoralfanumerico.ToUpper().Trim(),
							firma = r.Firma,
							ciudad = r.Ciudad_notario,
							notario = r.Notario_publico,
							fecha = Convert.ToDateTime(r.Fecha_participante)
						};
			this.gr_datos.DataSource = query;
			this.gr_datos.DataBind();

			this.Limpiar_Form();
		}

		protected void agp_persona_CambioPersona(object sender, CambioPersonaEventArgs e)
		{
			if (e.Persona != null)
			{
				this.Busca_Correos(Convert.ToInt32(e.Persona.Rut));
				this.Busca_Direcciones(Convert.ToInt32(e.Persona.Rut));
				this.Busca_Telefonos(Convert.ToInt32(e.Persona.Rut));
			}
		}

		protected void agp_persona_LimpiarPersona(object sender, EventArgs e)
		{
			this.Limpiar_Form();
		}

		protected void agp_direcciones_CambioDireccion(object sender, EventArgs e)
		{
			this.Busca_Direcciones(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void agp_direcciones_GuardarDireccion(object sender, EventArgs e)
		{
			this.Busca_Direcciones(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void agp_telefonos_CambioTelefono(object sender, EventArgs e)
		{
			this.Busca_Telefonos(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void agp_telefonos_GuardarTelefono(object sender, EventArgs e)
		{
			this.Busca_Telefonos(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void agp_correos_CambioCorreo(object sender, EventArgs e)
		{
			this.Busca_Correos(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void agp_correos_GuardarCorreo(object sender, EventArgs e)
		{
			this.Busca_Correos(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void Busca_Direcciones(int rut)
		{
			var query = (from d in new DireccionesBC().getdirecciones(rut)
						 join p in new ParametroBC().GetParametroByTipoParametro("TDIR") on d.Tipo_direccion equals p.Codigoparametro
						 where Convert.ToBoolean(d.Check) == true
						 orderby d.Id_direccion ascending
						 select new
						 {
							 tipoDireccion = p.Valoralfanumerico.ToUpper().Trim(),
							 direccion = d.Direccion.ToUpper().Trim(),
							 numero = d.Numero.ToUpper().Trim(),
							 complemento = d.Complemento.ToUpper().Trim(),
							 ciudad = d.Comuna.Ciudad.Region.Capital.ToUpper().Trim(),
							 comuna = d.Comuna.Nombre.ToUpper().Trim()
						 }).FirstOrDefault();
			if (query != null)
			{
				if (this.lbl_tipo_direccion != null) this.lbl_tipo_direccion.Text = query.tipoDireccion;
				if (this.lbl_direccion != null) this.lbl_direccion.Text = query.direccion;
				if (this.lbl_numero != null) this.lbl_numero.Text = query.numero;
				if (this.lbl_complemento != null) this.lbl_complemento.Text = query.complemento;
				if (this.lbl_ciudad != null) this.lbl_ciudad.Text = query.ciudad;
				if (this.lbl_comuna != null) this.lbl_comuna.Text = query.comuna;
			}
		}

		protected void Busca_Telefonos(int rut)
		{
			var query = (from t in new TelefonoBC().gettelefonos(rut)
						 join p in new ParametroBC().GetParametroByTipoParametro("TTEL") on t.Tipo_telefono equals p.Codigoparametro
						 where Convert.ToBoolean(t.Check) == true
						 orderby t.Id_telefono ascending
						 select new
						 {
							 tipoTelefono = p.Valoralfanumerico.ToUpper().Trim(),
							 telefono = t.Numero.ToString()
						 }).FirstOrDefault();
			if (query != null)
			{
				this.lbl_tipo_telefono.Text = query.tipoTelefono;
				this.lbl_telefono.Text = query.telefono;
			}
		}

		protected void Busca_Correos(int rut)
		{
			var query = (from c in new CorreoBC().getcorreos(rut)
						 where Convert.ToBoolean(c.Check) == true
						 orderby c.Id_correo
						 select c.Correo1).FirstOrDefault();
			this.lbl_correo.Text = query ?? "";
		}

		public void Mostrar_Form(double rut)
		{
			this.agp_persona.Rut = rut;
			var query = (from r in new ParticipanteBC().Getparticipante(Convert.ToDouble(this.Rut))
						 where r.Participe.Rut == rut
						 select new
						 {
							 tipo = r.Tipo.ToUpper().Trim(),
							 ciudad = r.Ciudad_notario.ToUpper().Trim(),
							 notario = r.Notario_publico.ToUpper().Trim(),
							 firma = r.Firma,
							 fecha = r.Fecha_participante
						 }).FirstOrDefault();
			if (query != null)
			{
				this.dl_tipo.SelectedValue = query.tipo;
				this.txt_ciudad.Text = query.ciudad;
				this.txt_notario.Text = query.notario;
				DateTime fecha;
				if (DateTime.TryParse(query.fecha, out fecha))
					this.txt_fecha.Text = fecha.ToShortDateString();
				else
					this.txt_fecha.Text = "";
				this.chk_firma.Checked = query.firma;
			}
		}

		protected void Limpiar_Form()
		{
			FuncionGlobal.comboparametro(this.dl_tipo, "TIPA");

			this.pnl_grilla.Visible = true;
			this.pnl_nuevo.Visible = false;

			this.pnl_opciones.Visible = true;

			//this.agp_persona.Limpiar_Form();
			this.agp_persona.Rut = 0;
			this.agp_persona.Nombre = "";
			this.agp_persona.Paterno = "";
			this.agp_persona.Materno = "";
			this.agp_persona.Sexo = "0";
			this.agp_persona.EstadoCivil = "0";
			this.agp_persona.Nacionalidad = "";
			this.agp_persona.Profesion = "";

			this.dl_tipo.SelectedValue = "0";
			this.txt_fecha.Text = "";
			this.txt_ciudad.Text = "";
			this.txt_notario.Text = "";

			this.tab_direcciones.Visible = true;
			if (this.lbl_tipo_direccion != null) this.lbl_tipo_direccion.Text = "";
			if (this.lbl_direccion != null) this.lbl_direccion.Text = "";
			if (this.lbl_numero != null) this.lbl_numero.Text = "";
			if (this.lbl_complemento != null) this.lbl_complemento.Text = "";
			if (this.lbl_ciudad != null) this.lbl_ciudad.Text = "";
			if (this.lbl_comuna != null) this.lbl_comuna.Text = "";

			this.tab_telefonos.Visible = true;
			if (this.lbl_tipo_telefono != null) this.lbl_tipo_telefono.Text = "";
			if (this.lbl_telefono != null) this.lbl_telefono.Text = "";

			this.tab_correos.Visible = true;
			if (this.lbl_correo != null) this.lbl_correo.Text = "";

			if (this.tab_direcciones.Visible) this.tab_opciones.ActiveTab = this.tab_direcciones;
			else if (this.tab_telefonos.Visible) this.tab_opciones.ActiveTab = this.tab_telefonos;
			else if (this.tab_correos.Visible) this.tab_opciones.ActiveTab = this.tab_correos;
		}		

		private bool Guardar_Form()
		{
			string output = "";
			if (!this.agp_persona.Guardar_Form())
			{
				output = this.agp_persona.MensajeError;
				ScriptManager.RegisterStartupScript(this.up_control, this.up_control.GetType(), "ErrorPersona", "alert('Ha ocurrido un error al guardar los datos del representante:\\n\\n" + output + "');", true);
				return false;
			}

			output = new ParticipanteBC().add_participe(Convert.ToDouble(this.Rut), this.agp_persona.Rut, this.dl_tipo.SelectedValue, this.chk_firma.Checked, this.txt_ciudad.Text, this.txt_notario.Text, Convert.ToDateTime(this.txt_fecha.Text));
			if (output != "")
			{
				ScriptManager.RegisterStartupScript(this.up_control, this.up_control.GetType(), "ErrorPersona", "alert('Ha ocurrido un error al guardar los datos del representante:\\n\\n" + output + "');", true);
				return false;
			}
			this.On_Cambio_Representantes(new EventArgs());
			return true;
		}

		protected void bt_editar_direcciones_Click(object sender, EventArgs e)
		{
			if (this.agp_persona.Guardar_Form())
			{
				this.agp_direcciones.Rut = Convert.ToInt32(this.agp_persona.Rut);
				this.mpe_editar_direcciones.Show();
			}
		}

		protected void bt_editar_telefonos_Click(object sender, EventArgs e)
		{
			if (this.agp_persona.Guardar_Form())
			{
				this.agp_telefonos.Rut = Convert.ToInt32(this.agp_persona.Rut);
				this.mpe_editar_telefonos.Show();
			}
		}

		protected void bt_editar_correos_Click(object sender, EventArgs e)
		{
			if (this.agp_persona.Guardar_Form())
			{
				this.agp_correos.Rut = Convert.ToInt32(this.agp_persona.Rut);
				this.mpe_editar_correos.Show();
			}
		}

		protected void bt_agregar_Click(object sender, EventArgs e)
		{
			this.Limpiar_Form();
			this.pnl_grilla.Visible = false;
			this.pnl_nuevo.Visible = true;
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Guardar_Form();
			this.FillGridView();
		}

		protected void bt_cancelar_Click(object sender, EventArgs e)
		{
			this.pnl_grilla.Visible = true;
			this.pnl_nuevo.Visible = false;
			this.Limpiar_Form();
		}

		protected void gr_datos_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Editar")
			{
				this.pnl_grilla.Visible = false;
				this.pnl_nuevo.Visible = true;
				this.Mostrar_Form(Convert.ToInt32(e.CommandArgument));
			}
		}

		protected void gr_datos_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				ImageButton btn = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
				btn.CommandName = "Editar";
				btn.CommandArgument = this.gr_datos.DataKeys[e.Row.RowIndex].Values[0].ToString();
			}
		}

		protected virtual void On_Cambio_Representantes(EventArgs e)
		{
			if (CambioRepresentantes != null)
			{
				CambioRepresentantes(this, e);
			}
		}
	}
}