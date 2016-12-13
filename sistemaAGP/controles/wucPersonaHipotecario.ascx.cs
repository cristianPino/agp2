using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
    public partial class wucPersonaHipotecario : System.Web.UI.UserControl
	{
		public event wucPersonaEventHandler OnActivarCompraPara;
		public event wucBotonEventHandler OnClickDireccion;
		public event wucBotonEventHandler OnClickTelefono;
		public event wucBotonEventHandler OnClickCorreo;
        public event wucBotonEventHandler OnClickParticipante;

		private Persona _persona;

		public Persona InfoPersona
		{
			get { return _persona; }
			set { _persona = value; }
		}

		private bool _comprapara = false;

		public bool HabilitarCompraPara
		{
			get { return _comprapara; }
			set { _comprapara = value; }
		}

        private bool _participante = false;

        public bool HabilitarParticipante
        {
            get { return _participante; }
            set { _participante = value; }
        }

		private bool _direccion = true;

		public bool HabilitarDireccion
		{
			get { return _direccion; }
			set { _direccion = value; }
		}

		private bool _telefono = true;

		public bool HabilitarTelefono
		{
			get { return _telefono; }
			set { _telefono = value; }
		}

		private bool _correo = true;

		public bool HabilitarCorreo
		{
			get { return _correo; }
			set { _correo = value; }
		}

		private string _titulo;

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		private short _tabindex;

		public short TabIndex
		{
			get { return _tabindex; }
			set { _tabindex = value; }
		}

		private bool _otros = false;

		public bool HabilitarOtrosDatos
		{
			get { return _otros; }
			set { _otros = value; }
		}

        private string giro="";

		protected void Page_Load(object sender, EventArgs e)
		{
			//this.lbl_titulo.TabIndex = Convert.ToInt16(this._tabindex + 0);
			//this.txt_rut.TabIndex = Convert.ToInt16(this._tabindex + 1);
			//this.txt_dv.TabIndex = Convert.ToInt16(this._tabindex + 2);
			//this.bt_limpia_persona.TabIndex = Convert.ToInt16(this._tabindex + 3);
			//this.txt_nombre.TabIndex = Convert.ToInt16(this._tabindex + 4);
			//this.txt_paterno.TabIndex = Convert.ToInt16(this._tabindex + 5);
			//this.txt_materno.TabIndex = Convert.ToInt16(this._tabindex + 6);
			//this.ib_direccion.TabIndex = Convert.ToInt16(this._tabindex + 7);
			//this.ib_telefono.TabIndex = Convert.ToInt16(this._tabindex + 8);
			//this.ib_correo.TabIndex = Convert.ToInt16(this._tabindex + 9);
			//this.chk_compra_para.TabIndex = Convert.ToInt16(this._tabindex + 10);

			if (!IsPostBack)
			{
				this.lbl_titulo.Text = this.Titulo;
				this.chk_compra_para.Visible = this._comprapara;
				this.chk_compra_para.Checked = false;

				FuncionGlobal.comboparametro(this.dl_estado_civil, "ESCIVIL");
				FuncionGlobal.comboparametro(this.dl_sexo, "SEXO");

                this.ib_participante.Visible = this._participante;
				this.ib_correo.Visible = this._correo;
				this.ib_direccion.Visible = this._direccion;
				this.ib_telefono.Visible = this._telefono;

				if (this._comprapara || this._correo || this._direccion || this._telefono ||this._participante)
				{
					this.pnl_opciones.Visible = true;
				}
				else
				{
					this.pnl_opciones.Visible = false;
				}

                this.OtrosDatos.Visible = this._otros;
			    OtrosDatos2.Visible = _otros;

				Limpiar_Form();
				if (_persona != null) Mostrar_Form(_persona.Rut);
			}
		}

		protected virtual void Activar_CompraPara(wucPersonaEventArgs e) { if (OnActivarCompraPara != null) OnActivarCompraPara(this, e); }

        protected virtual void Activar_Participante(wucBotonEventArgs e) { if (OnClickParticipante != null) OnClickParticipante(this, e); }

		protected virtual void Activar_Direccion(wucBotonEventArgs e) { if (OnClickDireccion != null) OnClickDireccion(this, e); }

		protected virtual void Activar_Telefono(wucBotonEventArgs e) { if (OnClickTelefono != null) OnClickTelefono(this, e); }

		protected virtual void Activar_Correo(wucBotonEventArgs e) { if (OnClickCorreo != null) OnClickCorreo(this, e); }

		protected void txt_rut_Leave(object sender, EventArgs e)
		{
			this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);
			Busca_Persona(Convert.ToDouble(this.txt_rut.Text));
			//this.ib_adquiriente.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
			//this.ib_adquiriente.Visible = true;
			this.txt_nombre.Focus();
			Int32 rut = Convert.ToInt32(txt_rut.Text);
		}

		protected void bt_limpia_persona_Click(object sender, EventArgs e)
		{
			this.Limpiar_Form();
		}

		private void Busca_Persona(double rut)
		{
			this._persona = new PersonaBC().getpersonabyrut(rut);
			this._otros = true;
            if (rut >= 50000000)
            {
                this.txt_paterno.Enabled = false;
                this.txt_materno.Enabled = false;
				this._otros = false;
            }
            this.OtrosDatos.Visible = this._otros;
            OtrosDatos2.Visible = _otros;
			if (this._persona != null)
			{
				//this.ib_adquiriente.Visible = true;
				//this.ib_adquiriente.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/this._personaModal.aspx?idthis._persona=" + FuncionGlobal.FuctionEncriptar(this._persona.Rut.ToString()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
				this.txt_rut.Text = this._persona.Rut.ToString();
				this.txt_rut.Enabled = false;
				this.txt_dv.Enabled = false;
				this.txt_nombre.Text = this._persona.Nombre;
				this.txt_paterno.Text = this._persona.Apellido_paterno;
				this.txt_materno.Text = this._persona.Apellido_materno;
				this.txt_dv.Text = this._persona.Dv;
                this.giro = this._persona.Giro;

				this.txt_profesion.Text = this._persona.Profesion;
				this.txt_nacionalidad.Text = this._persona.Nacionalidad;
				FuncionGlobal.BuscarValueCombo(this.dl_sexo, this._persona.Sexo);
				FuncionGlobal.BuscarValueCombo(this.dl_estado_civil, this._persona.Estado_civil);
			}
			else
			{
				this.txt_dv.Focus();
			}
		}

		protected void chk_compra_para_CheckedChanged(object sender, EventArgs e)
		{
			this.Activar_CompraPara(new wucPersonaEventArgs(chk_compra_para.Checked));
		}

        protected void ib_participante_Click(object sender, ImageClickEventArgs e)
        {
            if (_persona == null)
                if (!Guardar_Form())
                    return;
			//string js = "<script type=\"text/javascript\">window.showModalDialog('../administracion/mParticipante.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim()) + "', '', 'status:false;dialogWidth:700px;dialogHeight:500px')</script>";
			//this.Activar_Participante(new wucBotonEventArgs(js));
			this.lnk_popup.Attributes["href"] = "../administracion/mParticipante.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim());
			this.lnk_popup.Attributes["title"] = "Participantes";
			ScriptManager.RegisterStartupScript(this, this.GetType(), "showParticipantes", "jQuery(document).ready(function() {$(\"#" + this.lnk_popup.ClientID.Trim() + "\").trigger('click');});", true);
        }

		protected void ib_direccion_Click(object sender, ImageClickEventArgs e)
		{
			if (_persona == null)
				if (!Guardar_Form())
					return;
			//string js = "<script type=\"text/javascript\">window.showModalDialog('../administracion/mDireccion.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim()) + "', '', 'status:false;dialogWidth:500px;dialogHeight:300px')</script>";
			//this.Activar_Direccion(new wucBotonEventArgs(js));
			this.lnk_popup.Attributes["href"] = "../administracion/mDireccion.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim());
			this.lnk_popup.Attributes["title"] = "Direcciones";
			ScriptManager.RegisterStartupScript(this, this.GetType(), "showDirecciones", "jQuery(document).ready(function() {$(\"#" + this.lnk_popup.ClientID.Trim() + "\").trigger('click');});", true);
		}

		protected void ib_telefono_Click(object sender, ImageClickEventArgs e)
		{
			if (_persona == null)
				if (!Guardar_Form())
					return;
			//string js = "<script type=\"text/javascript\">window.showModalDialog('../administracion/mTelefonos.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim()) + "', '', 'status:false;dialogWidth:400px;dialogHeight:300px')</script>";
			//this.Activar_Telefono(new wucBotonEventArgs(js));
			this.lnk_popup.Attributes["href"] = "../administracion/mTelefonos.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim());
			this.lnk_popup.Attributes["title"] = "Teléfonos";
			ScriptManager.RegisterStartupScript(this, this.GetType(), "showTelefonos", "jQuery(document).ready(function() {$(\"#" + this.lnk_popup.ClientID.Trim() + "\").trigger('click');});", true);
		}

		protected void ib_correo_Click(object sender, ImageClickEventArgs e)
		{
			if (_persona == null)
				if (!Guardar_Form())
					return;
			//string js = "<script type=\"text/javascript\">window.showModalDialog('../administracion/mCorreo.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim()) + "', '', 'status:false;dialogWidth:400px;dialogHeight:300px')</script>";
			//this.Activar_Correo(new wucBotonEventArgs(js));
			this.lnk_popup.Attributes["href"] = "../administracion/mCorreo.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim());
			this.lnk_popup.Attributes["title"] = "Correos";
			ScriptManager.RegisterStartupScript(this, this.GetType(), "showCorreos", "jQuery(document).ready(function() {$(\"#" + this.lnk_popup.ClientID.Trim() + "\").trigger('click');});", true);
		}

		public void Mostrar_Form(double rut)
		{
			Busca_Persona(rut);
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
			this.dl_estado_civil.SelectedValue="0";
			this.dl_sexo.SelectedValue="0";
			this.txt_rut.Focus();
		}

		protected bool Validar_Form()
		{
			if (this.txt_rut.Text == "")
			{
				FuncionGlobal.alerta("Debe ingresar el RUT de la persona", Page);
				this.txt_rut.Focus();
				return false;
			}
			else if (Convert.ToDouble(this.txt_rut.Text) == 0)
			{
				FuncionGlobal.alerta("Debe ingresar el RUT de la persona", Page);
				this.txt_rut.Focus();
				return false;
			}
			if (this.txt_nombre.Text.Trim() == "")
			{
				FuncionGlobal.alerta("Debe ingresar el nombre de la persona", Page);
				this.txt_nombre.Focus();
				return false;
			}
			return true;
		}

		public bool Guardar_Form()
		{
			if (!Validar_Form()) return false;
			string persona = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text), this.txt_dv.Text, 1, "", this.txt_nombre.Text, this.txt_paterno.Text, this.txt_materno.Text, this.dl_sexo.SelectedValue, "0", this.txt_nacionalidad.Text, this.txt_profesion.Text, this.dl_estado_civil.SelectedValue, "", "", "", "", "", "", "0",giro);
			this._persona = new PersonaBC().getpersonabyrut(Convert.ToDouble(this.txt_rut.Text));
			return true;
		}

		public void setRut(string value)
		{
			this.txt_rut.Text = value;
		}

		public void setDV(string value)
		{
			this.txt_dv.Text = value;
		}

		public void setNombre(string value)
		{
			this.txt_nombre.Text = value;
		}

		public void setPaterno(string value)
		{
			this.txt_paterno.Text = value;
		}

		public void setMaterno(string value)
		{
			this.txt_materno.Text = value;
		}

		public void setCompraPara(bool value)
		{
			this.chk_compra_para.Checked = value;
		}

		public double getRut()
		{
			double rut = 0;
			if (this.txt_rut.Text != "") rut = Convert.ToDouble(this.txt_rut.Text);
			return rut;
		}
	}
}