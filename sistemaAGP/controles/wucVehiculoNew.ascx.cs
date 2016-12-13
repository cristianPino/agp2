using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class wucVehiculoNew : System.Web.UI.UserControl
	{
        private bool _CAV = false;

        public bool HabilitarCAV
        {
            get { return _CAV; }
            set { _CAV = value; }
        }

	    public CENTIDAD.OrdenTrabajo OrdenTrabajo { get; set; }

	    private string _titulo = "DATOS VEHICULO";

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		private DatosVehiculo _vehiculo;

		public DatosVehiculo Vehiculo
		{
			get { return _vehiculo; }
		}

		private string _error;

		public string MensajeError
		{
			get { return _error; }
		}

		#region Propiedades
		public string TipoVehiculo
		{
			get { return this.dl_tipo_vehiculo.SelectedValue.Trim(); }
			set { FuncionGlobal.BuscarTextoCombo(this.dl_tipo_vehiculo, value); }
		}

		public string Marca
		{
			get { return this.dl_marca_vehiculo.SelectedValue.Trim(); }
			set { FuncionGlobal.BuscarTextoCombo(this.dl_marca_vehiculo, value); }
		}

		public string Modelo
		{
			get { return this.txt_modelo_vehiculo.Text.ToUpper().Trim(); }
			set { this.txt_modelo_vehiculo.Text = value.ToUpper().Trim(); }
		}

		public string Anio
		{
			get { return this.txt_ano_vehiculo.Text; }
			set { this.txt_ano_vehiculo.Text = value; }
		}
		

		public string Cilindrada
		{
			get { return this.txt_cilindrada.Text.Trim(); }
			set { this.txt_cilindrada.Text = value.Trim(); }
		}
		

		public string Puertas
		{
			get { return this.txt_puertas.Text; }
			set { this.txt_puertas.Text = value.Trim(); }
		}
		

		public string Asientos
		{
			get { return this.txt_asientos.Text.Trim(); }
			set { this.txt_asientos.Text = value.Trim(); }
		}
		

		public string PesoBruto
		{
			get { return this.txt_peso_bruto.Text.Trim(); }
			set { this.txt_peso_bruto.Text = value.Trim(); }
		}
		

		public string PesoCarga
		{
			get { return this.txt_peso_carga.Text.Trim(); }
			set { this.txt_peso_carga.Text = value.Trim(); }
		}
		

		public string Combustible
		{
			get { return this.dl_combustible.SelectedValue.Trim(); }
			set { FuncionGlobal.BuscarTextoCombo(this.dl_combustible, value); }
		}
		

		public string Color
		{
			get { return this.txt_color.Text.ToUpper().Trim(); }
			set { this.txt_color.Text = value.ToUpper().Trim(); }
		}
		

		public string Motor
		{
			get { return this.txt_motor.Text.Trim(); }
			set { this.txt_motor.Text = value.Trim(); }
		}
		

		public string Chasis
		{
			get { return this.txt_chasis.Text.Trim(); }
			set { this.txt_chasis.Text = value.Trim(); }
		}
		

		public string Serie
		{
			get { return this.txt_serie.Text.Trim(); }
			set { this.txt_serie.Text = value.Trim(); }
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.lbl_titulo.Text = this._titulo;
				FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
				FuncionGlobal.combomarcavehiculo(this.dl_marca_vehiculo);
				FuncionGlobal.comboparametro(this.dl_combustible, "COMB");
                FuncionGlobal.comboparametro(this.dl_equipamiento, "EQUIPO");
                FuncionGlobal.comboparametro(this.dl_transmision, "TRANS");

                this.cav.Visible = this._CAV;
                this.txt_PDF.Visible = this._CAV;

               
				Limpiar_Form();
				if (this._vehiculo != null) Mostrar_Form(this._vehiculo.Id_solicitud);
                if (OrdenTrabajo != null) Busca_Patente(OrdenTrabajo.Patente);

            }
		}

		protected void Limpiar_Form()
		{
			this.txt_patente.Text = "";
			this.txt_patente.Enabled = true;
			this.txt_dv.Text = "";
			this.dl_tipo_vehiculo.SelectedValue = "0";
			this.dl_marca_vehiculo.SelectedValue = "0";
			this.txt_modelo_vehiculo.Text = "";
			this.txt_ano_vehiculo.Text = "";
			this.txt_cilindrada.Text = "";
			this.txt_puertas.Text = "";
			this.txt_asientos.Text = "";
			this.txt_peso_bruto.Text = "";
			this.txt_peso_carga.Text = "";
			this.dl_combustible.SelectedValue = "0";
            this.dl_equipamiento.SelectedValue = "0";
            this.dl_transmision.SelectedValue = "0";
			this.txt_color.Text = "";
			this.txt_motor.Text = "";
			this.txt_chasis.Text = "";
			this.txt_serie.Text = "";
            this.txt_PDF.Text = "";
			this.txt_patente.Focus();
		}

		public bool Validar_Form()
		{
			if (this.txt_patente.Text.Trim() != "")
			{
				if (!FuncionGlobal.formatoPatente(this.txt_patente.Text))
				{
					FuncionGlobal.alerta("La patente del vehiculo no cumple con el formato LLNNNN o LLLLNN", Page);
					this.txt_dv.Text = "";
					this.txt_patente.Focus();
					return false;
				}
			}
			if (this.dl_tipo_vehiculo.SelectedValue == "0")
			{
				FuncionGlobal.alerta("Ingrese el tipo de vehiculo", Page);
				this.dl_tipo_vehiculo.Focus();
				return false;
			}
			if (this.dl_marca_vehiculo.SelectedValue == "0")
			{
				FuncionGlobal.alerta("Ingrese la marca del vehiculo", Page);
				this.dl_marca_vehiculo.Focus();
				return false;
			}
			if (this.txt_modelo_vehiculo.Text.Trim() == "")
			{
				FuncionGlobal.alerta("Ingrese el modelo del vehiculo", Page);
				this.txt_modelo_vehiculo.Focus();
				return false;
			}
			if (this.txt_ano_vehiculo.Text.Trim() == "")
			{
				FuncionGlobal.alerta("Ingrese el año del vehiculo", Page);
				this.txt_ano_vehiculo.Focus();
				return false;
			}
			else if (Convert.ToInt32(this.txt_ano_vehiculo.Text) == 0)
			{
				FuncionGlobal.alerta("Ingrese el año del vehiculo", Page);
				this.txt_ano_vehiculo.Focus();
				return false;
			}
			if (this.txt_puertas.Text.Trim() == "") this.txt_puertas.Text = "0";
			if (this.txt_asientos.Text.Trim() == "") this.txt_asientos.Text = "0";
			if (this.txt_peso_bruto.Text.Trim() == "") this.txt_peso_bruto.Text = "0";
			if (this.txt_peso_carga.Text.Trim() == "") this.txt_peso_carga.Text = "0";
			return true;
		}

        public void MostrarFormOrdenTrabajo()
        {
            //Metodo para llenar datos desde orden trabajo AG 
            //C.Pino 25/03/2015   
            dl_marca_vehiculo.SelectedValue = OrdenTrabajo.VehiculoMarca.Trim();
            txt_modelo_vehiculo.Text = OrdenTrabajo.VehiculoModelo;
            txt_ano_vehiculo.Text = OrdenTrabajo.VehiculoAnio;
            txt_cilindrada.Text = OrdenTrabajo.VehiculoCilindrada;
            txt_puertas.Text = OrdenTrabajo.VehiculoPuertas.ToString(CultureInfo.InvariantCulture);
            txt_asientos.Text = OrdenTrabajo.VehiculoAsientos.ToString(CultureInfo.InvariantCulture);
            txt_peso_bruto.Text = OrdenTrabajo.VehiculoPesoBruto.ToString(CultureInfo.InvariantCulture);
            txt_peso_carga.Text = OrdenTrabajo.VehiculoCarga.ToString(CultureInfo.InvariantCulture);
            dl_combustible.SelectedValue = OrdenTrabajo.VehiculoCombustible.Trim();
            txt_color.Text = OrdenTrabajo.VehiculoColor;
            txt_motor.Text = OrdenTrabajo.VehiculoMotor;
            txt_chasis.Text = OrdenTrabajo.VehiculoChasis.Trim();
            txt_patente.Text = OrdenTrabajo.Patente;

        }

		public void Mostrar_Form(int id_solicitud)
		{
			this._vehiculo = new DatosvehiculoBC().getDatovehiculo(id_solicitud);
			if (this._vehiculo != null)
			{
				this.txt_patente.Text = this._vehiculo.Patente;
				this.txt_dv.Text = this._vehiculo.Dv;
				if (this._vehiculo.Tipo_vehiculo != null)
					this.dl_tipo_vehiculo.SelectedValue = this._vehiculo.Tipo_vehiculo.Codigo;
				if (this._vehiculo.Marca != null)
				this.dl_marca_vehiculo.SelectedValue = Convert.ToString(this._vehiculo.Marca.Id_marca);
				this.txt_modelo_vehiculo.Text = this._vehiculo.Modelo;
				this.txt_ano_vehiculo.Text = this._vehiculo.Ano.ToString();
				this.txt_cilindrada.Text = this._vehiculo.Cilindraje;
				this.txt_puertas.Text = this._vehiculo.Npuerta.ToString();
				this.txt_asientos.Text = this._vehiculo.Nasiento.ToString();
				this.txt_peso_bruto.Text = this._vehiculo.Pesobruto.ToString();
				this.txt_peso_carga.Text = this._vehiculo.Carga.ToString();
				this.dl_combustible.SelectedValue = this._vehiculo.Combustible.Trim();
				this.txt_color.Text = this._vehiculo.Color;
				this.txt_motor.Text = this._vehiculo.Motor;
				this.txt_chasis.Text = this._vehiculo.Chassis;
				this.txt_serie.Text = this._vehiculo.Serie;
                this.dl_equipamiento.SelectedValue = this._vehiculo.Equipamiento.Trim();
                this.dl_transmision.SelectedValue = this._vehiculo.Transmision.Trim();
			}
		}

		public bool Guardar_Form(int id_solicitud)
		{
			if (id_solicitud <= 0)
			{
				FuncionGlobal.alerta("Debe guardar la operación antes de continuar", Page);
				return false;
			}
			if (!Validar_Form()) return false;
			Int32 id_dato_vehiculo = 0;
			Int32 rut_prenda = 0;
			string financiamiento_amicar = "0";
            DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(id_solicitud);
            if (mdato != null)
            {
                id_dato_vehiculo = mdato.Id_dato_vehiculo;
                rut_prenda = mdato.Rut_prenda;
				financiamiento_amicar = mdato.Financiamiento_amicar;
            }
            string output = new DatosvehiculoBC().add_Datosvehiculo(id_solicitud,
																	new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue)),
																	new TipovehiculoBC().getTipoVehiculo(this.dl_tipo_vehiculo.SelectedValue),
																	this.txt_patente.Text,
																	this.txt_dv.Text,
																	this.txt_modelo_vehiculo.Text,
																	this.txt_chasis.Text,
																	this.txt_motor.Text,
																	this.txt_chasis.Text,
																	this.txt_serie.Text,
																	Convert.ToInt32(this.txt_ano_vehiculo.Text),
																	this.txt_cilindrada.Text,
																	this.txt_color.Text,
																	Convert.ToInt32(this.txt_peso_carga.Text),
																	Convert.ToInt32(this.txt_peso_bruto.Text),
																	this.dl_combustible.SelectedValue,
																	Convert.ToInt32(this.txt_puertas.Text),
																	Convert.ToInt32(this.txt_asientos.Text),
																	0,
																	0,
																	"",
																	0,
																	id_dato_vehiculo,
																	Convert.ToDateTime("01/01/1900"),
																	"",
																	"false",
																	"",
																	rut_prenda,
																	financiamiento_amicar,this.dl_transmision.SelectedValue.Trim()
                                                                    ,this.dl_equipamiento.SelectedValue.Trim(),"0");
			if (output != "")
			{
				this._error = output;
				return false;
			}
			return true;
		}

		protected void txt_patente_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_patente.Text.Trim() != "")
			{
				if (FuncionGlobal.formatoPatente(this.txt_patente.Text))
				{
					this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);
					if(this.Busca_Patente(this.txt_patente.Text)){
						this.txt_patente.Enabled = false;
					}
					this.dl_tipo_vehiculo.Focus();
				}
				else
				{
					this.txt_dv.Text = "";
				}
			}
		}

        protected void txt_PDF_Leave(object sender, EventArgs e)
        {
            this.busca_dato(this.txt_patente, "Inscripción");
			this.busca_dato(this.txt_tipo, "Tipo Vehículo");
			this.busca_dato(this.txt_marca, "Marca");
			this.busca_dato(this.txt_ano_vehiculo, "Año");
			this.busca_dato(this.txt_chasis, "Nro. Vin");
			this.busca_dato(this.txt_serie, "Nro. Serie");
			this.busca_dato(this.txt_chasis, "Nro. Chasis");
			this.busca_dato(this.txt_color, "Color");
			this.busca_dato(this.txt_modelo_vehiculo, "Modelo");
			this.busca_dato(this.txt_motor, "Nro. Motor");
			this.busca_dato(this.txt_peso_bruto, "PBV");

            FuncionGlobal.BuscarTextoCombo(this.dl_marca_vehiculo, this.txt_marca.Text);
            FuncionGlobal.BuscarTextoCombo(this.dl_tipo_vehiculo, this.txt_tipo.Text);
        }

        private void busca_dato(TextBox txt_palabra, string palabra)
        {
            string resultado;
            string resul;

            resultado = "";
            string[] lienas = { };
            if (this.txt_PDF.Text.IndexOf(Environment.NewLine) > 0)
                lienas = this.txt_PDF.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            else if (this.txt_PDF.Text.IndexOf("\n") > 0)
                lienas = this.txt_PDF.Text.Split(new string[] { "\n" }, StringSplitOptions.None);

            int contador = 1;
            foreach (string linea in lienas)
            {
                if (linea.Trim().Length >= palabra.Trim().Length)
                {

                    if (palabra == "Año" && contador == 3)
                    {
                        resul = linea;
                        int id = linea.IndexOf("Año", 0);
                        resul = linea.Remove(0, id);
                        resul = resul.Substring(0, palabra.Length);
                    }
                    else
                    {
                        resul = linea.Substring(0, palabra.Length);
                    }
                    if (resul == palabra)
                    {
                        if (resul == "Año")
                        {
                            resul = linea;
                            int id = linea.IndexOf("Año", 0);
                            resul = linea.Remove(0, id);
                            resul = resul.Substring(palabra.Length);
                            resultado = resul.Replace(":", "").Trim();
                        }
                        else
                        {
                            if (palabra == "Inscripción")
                            {
                                resultado = linea.Replace(palabra, "").ToString().Trim();
                                resultado = resultado.Replace(":", "").ToString().Trim();
                                resultado = resultado.Replace(".", "").ToString().Trim();
                                resultado = resultado.Substring(0, 6).ToString().Trim();
                            }
                            else
                            {
                                if (palabra == "PBV")
                                {
                                    resultado = linea.Replace(palabra, "").ToString().Trim();
                                    resultado = resultado.Replace(".","").ToString().Trim();
                                    resultado = resultado.Replace(":", "").ToString().Trim();
                                    resultado = resultado.Substring(0, 4).ToString().Trim();
                                }
                                else
                                {
                                    resultado = linea.Replace(palabra, "").ToString().Trim();
                                    resultado = resultado.Replace(":", "").ToString().Trim();
                                }
                            }
                            if (palabra == "Tipo Vehículo")
                            {
                                int ind = resultado.IndexOf("Año", 0);
                                resultado = resultado.Remove(ind).Trim();

                            }
                          
                        }
                        txt_palabra.Text = resultado;
                        if (palabra == "Inscripción")
                        {
                            this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(resultado).ToString();
                        }
                        return;
                    }

                }
                contador++;

            }
        }

		protected bool Busca_Patente(string patente)
		{
			this._vehiculo = new DatosvehiculoBC().getDatovehiculobypatente(patente);
			if (this._vehiculo != null)
			{
				this.txt_patente.Text = this._vehiculo.Patente;
				this.txt_dv.Text = this._vehiculo.Dv;
				if (this._vehiculo.Tipo_vehiculo != null)
					this.dl_tipo_vehiculo.SelectedValue = this._vehiculo.Tipo_vehiculo.Codigo;
				if (this._vehiculo.Marca != null)
					this.dl_marca_vehiculo.SelectedValue = Convert.ToString(this._vehiculo.Marca.Id_marca);
				this.txt_modelo_vehiculo.Text = this._vehiculo.Modelo;
				this.txt_ano_vehiculo.Text = this._vehiculo.Ano.ToString();
				this.txt_cilindrada.Text = this._vehiculo.Cilindraje;
				this.txt_puertas.Text = this._vehiculo.Npuerta.ToString();
				this.txt_asientos.Text = this._vehiculo.Nasiento.ToString();
				this.txt_peso_bruto.Text = this._vehiculo.Pesobruto.ToString();
				this.txt_peso_carga.Text = this._vehiculo.Carga.ToString();
                this.dl_combustible.SelectedValue = this._vehiculo.Combustible.Trim().Contains("GASOLINA")?"GAS": this._vehiculo.Combustible.Trim();
				this.txt_color.Text = this._vehiculo.Color;
				this.txt_motor.Text = this._vehiculo.Motor;
				this.txt_chasis.Text = this._vehiculo.Chassis;
				this.txt_serie.Text = this._vehiculo.Serie;
				return true;
			}
			else
			{
				return false;
			}
		}

		protected void bt_limpia_vehiculo_Click(object sender, EventArgs e)
		{
			this.Limpiar_Form();
		}
	}
}