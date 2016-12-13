using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class wucVehiculo : System.Web.UI.UserControl
	{
        //public event wucVehiculoEventHandler OnActivarCAV;

        private bool _CAV = false;
       
        private DateTime fecha_factura;

        public DateTime Fecha_factura
        {
            get { return Convert.ToDateTime(ViewState["fecha_factura"] ?? fecha_factura); }
            set { fecha_factura = value; ViewState["fecha_factura"] = fecha_factura; }
        }
        private Int32 monto_factura;

        public Int32 Monto_factura
        {
            get { return Convert.ToInt32(ViewState["monto_factura"] ?? monto_factura); }
            set { monto_factura = value; ViewState["monto_factura"] = monto_factura; }
        }
      

        public bool HabilitarCAV
        {
            get { return _CAV; }
            set { _CAV = value; }
        }

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

        private CENTIDAD.OrdenTrabajo _ordenTrabajo;

        public CENTIDAD.OrdenTrabajo OrdenTrabajo
        {
            get { return _ordenTrabajo; }
            set { _ordenTrabajo = value; }
        }

       

	    public string GetChassis()
        {

            return this.txt_chasis.Text.Trim();  

        }
        public string Getpatente()
        {

            return this.txt_patente.Text.Trim();
        }
        public string GetPatente()
        {

            return this.txt_patente.Text.Trim();

        }


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                
                this.lbl_titulo.Text = this._titulo;
				FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
				FuncionGlobal.combomarcavehiculo(this.dl_marca_vehiculo);
				FuncionGlobal.comboparametro(this.dl_combustible, "COMB");
                FuncionGlobal.comboparametro(this.dl_Equipamiento_vehiculo, "EQUIPO");
                FuncionGlobal.comboparametro(this.dl_Transmision_vehiculo, "TRANS");


                this.cav.Visible = this._CAV;
                this.txt_PDF.Visible = this._CAV;

               
				Limpiar_Form();
				if (_vehiculo != null) Mostrar_Form(_vehiculo.Id_solicitud);
                if(_ordenTrabajo != null) MostrarFormOrdenTrabajo();
			}
		}

		protected void Limpiar_Form()
		{
			this.dl_tipo_vehiculo.SelectedValue = "0";
			this.dl_marca_vehiculo.SelectedValue = "0";
            //this.dl_modelo.SelectedValue = "0";
            this.txt_modelo.Text = "";
			this.txt_ano_vehiculo.Text = "";
			this.txt_cilindrada.Text = "";
			this.txt_puertas.Text = "";
			this.txt_asientos.Text = "";
			this.txt_peso_bruto.Text = "";
			this.txt_peso_carga.Text = "";
			this.dl_combustible.SelectedValue = "0";
			this.txt_color.Text = "";
			this.txt_motor.Text = "";
			this.txt_chasis.Text = "";
			this.txt_vin.Text = "";
			this.txt_serie.Text = "";
            this.txt_PDF.Text = "";
		}

		public bool Validar_Form()
		{
           
			UpdatePanel up = (UpdatePanel)this.Page.FindControl("UpdatePanel1");
			string mensaje = "";
            //if (this.txt_patente.Text.Trim() != "")
            //{
            //    if (!FuncionGlobal.formatoPatente(this.txt_patente.Text))
            //    {
            //        mensaje = "La patente del vehiculo no cumple con el formato LLNNNN o LLLLNN";
            //        if (up != null)
            //            FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
            //        else
            //            FuncionGlobal.alerta(mensaje, this.Page);
            //        this.txt_dv.Text = "";
            //        this.txt_patente.Focus();
            //        return false;
            //    }
            //}

          


            if (this.dl_tipo_vehiculo.SelectedValue == "0")
			{
				mensaje = "Ingrese el tipo de vehiculo";
				if (up != null)
					FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
				else
					FuncionGlobal.alerta(mensaje, this.Page);
				this.dl_tipo_vehiculo.Focus();
				return false;
			}
			if (this.dl_marca_vehiculo.SelectedValue == "0")
			{
				mensaje = "Ingrese la marca del vehiculo";
				if (up != null)
					FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
				else
					FuncionGlobal.alerta(mensaje, this.Page);
				this.dl_marca_vehiculo.Focus();
				return false;
			}
            //if (this.dl_modelo.SelectedValue.Trim() == "0")
            //{
            //    mensaje = "Ingrese el modelo del vehiculo";
            //    if (up != null)
            //        FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
            //    else
            //        FuncionGlobal.alerta(mensaje, this.Page);
            //    this.dl_modelo.Focus();
            //    return false;
            //}
            if (this.txt_modelo.Text.Trim() == "")
            {
                mensaje = "Ingrese el modelo del vehiculo";
                if (up != null)
                    FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
                else
                    FuncionGlobal.alerta(mensaje, this.Page);
                this.txt_modelo.Focus();
                return false;
            }
			if (this.txt_ano_vehiculo.Text.Trim() == "")
			{
				mensaje = "Ingrese el año del vehiculo";
				if (up != null)
					FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
				else
					FuncionGlobal.alerta(mensaje, this.Page);
				this.txt_ano_vehiculo.Focus();
				return false;
			}
			else if (Convert.ToInt32(this.txt_ano_vehiculo.Text) == 0)
			{
				mensaje = "Ingrese el año del vehiculo";
				if (up != null)
					FuncionGlobal.alerta_updatepanel(mensaje, this.Page, up);
				else
					FuncionGlobal.alerta(mensaje, this.Page);
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
            dl_marca_vehiculo.SelectedValue = _ordenTrabajo.VehiculoMarca.Trim();
            txt_modelo.Text = _ordenTrabajo.VehiculoModelo;
            txt_ano_vehiculo.Text = _ordenTrabajo.VehiculoAnio;
            txt_cilindrada.Text = _ordenTrabajo.VehiculoCilindrada;
            txt_puertas.Text = _ordenTrabajo.VehiculoPuertas.ToString(CultureInfo.InvariantCulture);
            txt_asientos.Text = _ordenTrabajo.VehiculoAsientos.ToString(CultureInfo.InvariantCulture);
            txt_peso_bruto.Text = _ordenTrabajo.VehiculoPesoBruto.ToString(CultureInfo.InvariantCulture);
            txt_peso_carga.Text = _ordenTrabajo.VehiculoCarga.ToString(CultureInfo.InvariantCulture);
            dl_combustible.SelectedValue = _ordenTrabajo.VehiculoCombustible.Trim();
            txt_color.Text = _ordenTrabajo.VehiculoColor;
            txt_motor.Text = _ordenTrabajo.VehiculoMotor;
            txt_vin.Text = _ordenTrabajo.VehiculoVin;
            txt_chasis.Text = _ordenTrabajo.VehiculoChasis.Trim();
         
        }

	    public void Mostrar_Form(int id_solicitud)
		{
			_vehiculo = new DatosvehiculoBC().getDatovehiculo(id_solicitud);
			if (_vehiculo != null)
			{
				txt_patente.Text = _vehiculo.Patente;
				txt_dv.Text = _vehiculo.Dv;
				if (this._vehiculo.Tipo_vehiculo != null)
					this.dl_tipo_vehiculo.SelectedValue = this._vehiculo.Tipo_vehiculo.Codigo;
				if (this._vehiculo.Marca != null)
				this.dl_marca_vehiculo.SelectedValue = Convert.ToString(this._vehiculo.Marca.Id_marca);
                //this.dl_modelo.SelectedItem.Text = this._vehiculo.Modelo;
                this.txt_modelo.Text = this._vehiculo.Modelo;
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
				this.txt_vin.Text = this._vehiculo.Vin;
				this.txt_serie.Text = this._vehiculo.Serie;
                //this.dl_Transmision_vehiculo.SelectedValue = this._vehiculo.Transmision.Trim();
                //this.dl_Equipamiento_vehiculo.SelectedValue = this._vehiculo.Equipamiento.Trim();
			}
		}

		public string Guardar_Form(int id_solicitud)
		{
			if (id_solicitud <= 0)
			{
				FuncionGlobal.alerta("Debe guardar la operación antes de continuar", Page);
				return "Debe guardar la operación antes de continuar";
			}
			if (!Validar_Form()) return "No se validaron todos los datos";
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
			string add_PDV = new DatosvehiculoBC().add_Datosvehiculo(
						id_solicitud,
						new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue)),
						new TipovehiculoBC().getTipoVehiculo(this.dl_tipo_vehiculo.SelectedValue),
						this.txt_patente.Text,
						this.txt_dv.Text,
                        //this.dl_modelo.SelectedItem.Text,
                        this.txt_modelo.Text,
						this.txt_chasis.Text,
						this.txt_motor.Text,
						this.txt_vin.Text,
						this.txt_serie.Text,
						Convert.ToInt32(this.txt_ano_vehiculo.Text),
						this.txt_cilindrada.Text,
						this.txt_color.Text,
						Convert.ToInt32(this.txt_peso_carga.Text),
						Convert.ToInt32(this.txt_peso_bruto.Text),
						this.dl_combustible.SelectedValue,
						Convert.ToInt32(this.txt_puertas.Text),
						Convert.ToInt32(this.txt_asientos.Text), 0, 0, "", 0, id_dato_vehiculo,
						Convert.ToDateTime("01/01/1900"), "", "false", "", rut_prenda,financiamiento_amicar,
                        this.dl_Transmision_vehiculo.SelectedValue.Trim(),this.dl_Equipamiento_vehiculo.SelectedValue.Trim(),"0"
                        );
			return add_PDV;
		}

		public void setTipoVehiculo(string value)
		{
			//FuncionGlobal.BuscarValueCombo(this.dl_tipo_vehiculo, value);
			FuncionGlobal.BuscarTextoCombo(this.dl_tipo_vehiculo, value);
		}

		public void setMarca(string value)
		{
			//FuncionGlobal.BuscarValueCombo(this.dl_marca_vehiculo, value);
			FuncionGlobal.BuscarTextoCombo(this.dl_marca_vehiculo, value);
		}

		public void setModelo(string value)
		{
            //this.dl_modelo.SelectedItem.Text = value;
            this.txt_modelo.Text = value;
		}
        public void setPatente(string value)
        {
            this.txt_patente.Text = value;
        }
		public void setAnio(string value)
		{
			this.txt_ano_vehiculo.Text = value;
		}

		public void setCilindrada(string value)
		{
			this.txt_cilindrada.Text = value;
		}

		public void setPuertas(string value)
		{
			this.txt_puertas.Text = value;
		}

		public void setAsientos(string value)
		{
			this.txt_asientos.Text = value;
		}

		public void setPesoBruto(string value)
		{
			this.txt_peso_bruto.Text = value;
		}

		public void setPesoCarga(string value)
		{
			this.txt_peso_carga.Text = value;
		}

		public void setCombustible(string value)
		{
			FuncionGlobal.BuscarTextoCombo(this.dl_combustible, value);
		}

		public void setColor(string value)
		{
			this.txt_color.Text = value;
		}

		public void setMotor(string value)
		{
			this.txt_motor.Text = value;
		}

		public void setChasis(string value)
		{
			this.txt_chasis.Text = value;
		}

		public void setVin(string value)
		{
			this.txt_vin.Text = value;
		}

		protected void txt_patente_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_patente.Text.Trim() != "")
			{
				if (FuncionGlobal.formatoPatente(this.txt_patente.Text))
				{
					this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);
					if (this.Busca_Patente(this.txt_patente.Text))
					{
						this.txt_patente.Enabled = false;
					}
				}
				else
				{
					this.txt_dv.Text = "";
				}
			}
		}

		protected bool Busca_Patente(string patente)
		{
			DatosVehiculo veh = new DatosvehiculoBC().getDatovehiculobypatente(patente);
			//veh = new DatosvehiculoBC().getDatovehiculobypatente(patente);
			if (veh != null)
			{
				this.txt_patente.Text = veh.Patente;
				this.txt_dv.Text = veh.Dv;
				if (veh.Tipo_vehiculo != null)
					this.dl_tipo_vehiculo.SelectedValue = veh.Tipo_vehiculo.Codigo;
				if (veh.Marca != null)
					this.dl_marca_vehiculo.SelectedValue = Convert.ToString(veh.Marca.Id_marca);
                //this.dl_modelo.SelectedItem.Text = veh.Modelo;
                this.txt_modelo.Text = veh.Modelo;
				this.txt_ano_vehiculo.Text = veh.Ano.ToString();
				this.txt_cilindrada.Text = veh.Cilindraje;
				this.txt_puertas.Text = veh.Npuerta.ToString();
				this.txt_asientos.Text = veh.Nasiento.ToString();
				this.txt_peso_bruto.Text = veh.Pesobruto.ToString();
				this.txt_peso_carga.Text = veh.Carga.ToString();
				this.dl_combustible.SelectedValue = veh.Combustible.Trim();
				this.txt_color.Text = veh.Color;
				this.txt_motor.Text = veh.Motor;
				this.txt_chasis.Text = veh.Chassis;
				this.txt_serie.Text = veh.Serie;
				return true;
			}
			else
			{
				return false;
			}
		}

        protected void txt_PDF_Leave(object sender, EventArgs e)
        {
            busca_dato(this.txt_patente, "Inscripción");
            busca_dato(this.txt_tipo, "Tipo Vehículo");
            busca_dato(this.txt_marca, "Marca");
            busca_dato(this.txt_ano_vehiculo, "Año");
            busca_dato(this.txt_vin, "Nro. Vin");
            busca_dato(this.txt_serie, "Nro. Serie");
            busca_dato(this.txt_chasis, "Nro. Chasis");
            busca_dato(this.txt_color, "Color");
            busca_dato(this.txt_motor, "Nro. Motor");
            busca_dato(this.txt_peso_bruto, "PBV");

            FuncionGlobal.BuscarTextoCombo(this.dl_marca_vehiculo, this.txt_marca.Text);
            //FuncionGlobal.BuscarTextoCombo(this.dl_modelo, this.txt_modelo.Text);
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

        //protected void dl_modelo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ModeloVehiculo mMode = new ModelovehiculoBC().getModeloImpuesto(Convert.ToInt32(this.dl_modelo.SelectedValue),Convert.ToDateTime(ViewState["fecha_factura"]),Convert.ToInt32(ViewState["monto_factura"]));
        //        this.txt_impuesto.Text = mMode.Impuesto.ToString();
        //}

        protected void dl_marca_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FuncionGlobal.comboModelovehiculo(this.dl_modelo,Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue));
        }

        protected void txt_motor_TextChanged(object sender, EventArgs e)
        {

        }

     
	}
}