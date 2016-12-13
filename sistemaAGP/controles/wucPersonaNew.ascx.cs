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
	public partial class wucPersonaNew : System.Web.UI.UserControl
	{
		public event CambioCompraParaEventHandler CambioCompraPara;

		#region Propiedades
		public double Rut
		{
			get { return this.agp_persona.Rut; }
			set { this.agp_persona.Rut = value; }
		}

		public string DV
		{
			get { return this.agp_persona.DV; }
			set { this.agp_persona.DV = value; }
		}

		public string Nombre
		{
			get { return this.agp_persona.Nombre; }
			set { this.agp_persona.Nombre = value; }
		}

		public string Paterno
		{
			get { return this.agp_persona.Paterno; }
			set { this.agp_persona.Paterno = value; }
		}

		public string Materno
		{
			get { return this.agp_persona.Materno; }
			set { this.agp_persona.Materno = value; }
		}

		public string Sexo
		{
			get { return this.agp_persona.Sexo; }
			set { this.agp_persona.Sexo = value; }
		}

		public string EstadoCivil
		{
			get { return this.agp_persona.EstadoCivil; }
			set { this.agp_persona.EstadoCivil = value; }
		}

		public string Nacionalidad
		{
			get { return this.agp_persona.Nacionalidad; }
			set { this.agp_persona.Nacionalidad = value; }
		}

		public string Profesion
		{
			get { return this.agp_persona.Profesion; }
			set { this.agp_persona.Profesion = value; }
		}

		public bool CompraPara
		{
			get { return Convert.ToBoolean(ViewState["compra_para"] ?? false); }
			set { ViewState["compra_para"] = value; }
		}
		#endregion

		private Persona _persona;

		public Persona InfoPersona
		{
			get { return _persona; }
			set { _persona = value; }
		}

		public bool HabilitarCompraPara
		{
			get { return Convert.ToBoolean(ViewState["habilitarCompraPara"] ?? false); }
			set { ViewState["habilitarCompraPara"] = value; }
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

		public bool HabilitarOtrosDatos
		{
			get { return this.agp_persona.HabilitarOtrosDatos; }
			set { this.agp_persona.HabilitarOtrosDatos = value; }
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

		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
				this.Limpiar_Form();
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.lbl_titulo.Text = this.Titulo;
				this.chk_compra_para.Visible = this.HabilitarCompraPara;
				this.chk_compra_para.Checked = false;

				this.agp_persona.Titulo = this.Titulo;

				this.Limpiar_Form();
				if (_persona != null) Mostrar_Form(_persona.Rut);
				this.chk_compra_para.Checked = this.CompraPara;
			}
		}

		protected virtual void Cambio_CompraPara(CambioCompraParaEventArgs e) { if (CambioCompraPara != null) CambioCompraPara(this, e); }

		protected void agp_persona_CambioPersona(object sender, CambioPersonaEventArgs e)
		{
			if (e.Persona != null)
			{
				this.Busca_Correos(Convert.ToInt32(e.Persona.Rut));
				this.Busca_Direcciones(Convert.ToInt32(e.Persona.Rut));
				this.Busca_Telefonos(Convert.ToInt32(e.Persona.Rut));
				this.Busca_Representantes(Convert.ToInt32(e.Persona.Rut));
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

		protected void agp_representantes_CambioRepresentantes(object sender, EventArgs e)
		{
			this.Busca_Representantes(Convert.ToInt32(this.agp_persona.Rut));
		}

		protected void Busca_Direcciones(int rut)
		{
            //var query = (from d in new DireccionesBC().getdirecciones(rut)
            //             join p in new ParametroBC().GetParametroByTipoParametro("TDIR") on d.Tipo_direccion equals p.Codigoparametro
            //             where Convert.ToBoolean(d.Check) == true
            //             orderby d.Id_direccion ascending
            //             select new
            //             {
            //                 tipoDireccion = p.Valoralfanumerico.ToUpper().Trim(),
            //                 direccion = d.Direccion.ToUpper().Trim(),
            //                 numero = d.Numero.ToUpper().Trim(),
            //                 complemento = d.Complemento.ToUpper().Trim(),
            //                 ciudad = d.Comuna.Ciudad.Region.Capital.ToUpper().Trim(),
            //                 comuna = d.Comuna.Nombre.ToUpper().Trim()
            //             }).FirstOrDefault();

            Direcciones query = new DireccionesBC().getDireccionPorDefecto(rut);
            

			if (query != null)
			{
				if (this.lbl_tipo_direccion != null) this.lbl_tipo_direccion.Text = query.Tipo_direccion;
				if (this.lbl_direccion != null) this.lbl_direccion.Text = query.Direccion;
				if (this.lbl_numero != null) this.lbl_numero.Text = query.Numero;
				if (this.lbl_complemento != null) this.lbl_complemento.Text = query.Complemento;
                //if (this.lbl_ciudad != null) this.lbl_ciudad.Text = query.c;
                if (query.Comuna!=null)
                {
				if (this.lbl_comuna != null) this.lbl_comuna.Text = query.Comuna.Nombre.ToString();
                }
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

		protected void Busca_Representantes(int rut)
		{
			var query = from r in new ParticipanteBC().Getparticipante(Convert.ToDouble(rut))
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
			this.gr_representantes.DataSource = query;
			this.gr_representantes.DataBind();
		}

		public void Mostrar_Form(double rut)
		{
			this.agp_persona.Rut = rut;
		}

		protected void Limpiar_Form()
		{
			if (this._correo || this._direccion || this._telefono || this._participante) this.pnl_opciones.Visible = true;
			else this.pnl_opciones.Visible = false;

			this.tab_direcciones.Visible = this._direccion;
			if (this.lbl_tipo_direccion != null) this.lbl_tipo_direccion.Text = "";
			if (this.lbl_direccion != null) this.lbl_direccion.Text = "";
			if (this.lbl_numero != null) this.lbl_numero.Text = "";
			if (this.lbl_complemento != null) this.lbl_complemento.Text = "";
			if (this.lbl_ciudad != null) this.lbl_ciudad.Text = "";
			if (this.lbl_comuna != null) this.lbl_comuna.Text = "";

			this.tab_telefonos.Visible = this._telefono;
			if (this.lbl_tipo_telefono != null) this.lbl_tipo_telefono.Text = "";
			if (this.lbl_telefono != null) this.lbl_telefono.Text = "";

			this.tab_correos.Visible = this._correo;
			if (this.lbl_correo != null) this.lbl_correo.Text = "";

			this.tab_representantes.Visible = this._participante;
			if (this.gr_representantes != null)
			{
				this.gr_representantes.DataSource = null;
				this.gr_representantes.DataBind();
			}

			if (this.tab_direcciones.Visible) this.tab_opciones.ActiveTab = this.tab_direcciones;
			else if (this.tab_telefonos.Visible) this.tab_opciones.ActiveTab = this.tab_telefonos;
			else if (this.tab_correos.Visible) this.tab_opciones.ActiveTab = this.tab_correos;
			else if (this.tab_representantes.Visible) this.tab_opciones.ActiveTab = this.tab_representantes;
		}

		public bool Guardar_Form()
		{
			if (!this.agp_persona.Guardar_Form())
			{
				return false;
			}
			return true;
		}

		protected void chk_compra_para_CheckedChanged(object sender, EventArgs e)
		{
			ViewState["compra_para"] = this.chk_compra_para.Checked;
			this.Cambio_CompraPara(new CambioCompraParaEventArgs(this.chk_compra_para.Checked));
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

		protected void bt_editar_representantes_Click(object sender, EventArgs e)
		{
			if (this.agp_persona.Guardar_Form())
			{
				this.agp_representantes.Rut = Convert.ToInt32(this.agp_persona.Rut);
				this.mpe_editar_representantes.Show();
			}
		}
	}
}