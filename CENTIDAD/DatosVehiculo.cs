using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class DatosVehiculo {

        private string estado_vehiculo;

        public string Estado_vehiculo
        {
            get { return estado_vehiculo; }
            set { estado_vehiculo = value; }
        }
        private string forma_pago;

        public string Forma_pago
        {
            get { return forma_pago; }
            set { forma_pago = value; }
        }
        private DateTime fecha_contrato;

        public DateTime Fecha_contrato
        {
            get { return fecha_contrato; }
            set { fecha_contrato = value; }
        }
        private string prenda;

        public string Prenda
        {
            get { return prenda; }
            set { prenda = value; }
        }

        private Int32 id_dato_vehiculo;

        public Int32 Id_dato_vehiculo
        {
            get { return id_dato_vehiculo; }
            set { id_dato_vehiculo = value; }
        }
		private int id_solicitud;

		public int Id_solicitud {
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		private Marcavehiculo marca;

		public Marcavehiculo Marca {
			get { return marca; }
			set { marca = value; }
		}

		private Tipovehiculo tipo_vehiculo;

		public Tipovehiculo Tipo_vehiculo {
			get { return tipo_vehiculo; }
			set { tipo_vehiculo = value; }
		}
		
		private string patente = "";

		public string Patente {
			get { return patente; }
			set { patente = value; }
		}
		
		private string dv = "";

		public string Dv {
			get { return dv; }
			set { dv = value; }
		}

		private string modelo = "";

		public string Modelo {
			get { return modelo; }
			set { modelo = value; }
		}

		private string chassis = "";

		public string Chassis {
			get { return chassis; }
			set { chassis = value; }
		}

		private string motor = "";

		public string Motor {
			get { return motor; }
			set { motor = value; }
		}

		private string vin = "";

		public string Vin {
			get { return vin; }
			set { vin = value; }
		}

		private string serie = "";

		public string Serie {
			get { return serie; }
			set { serie = value; }
		}

		private int ano = 0;

		public int Ano {
			get { return ano; }
			set { ano = value; }
		}

		private string cilindraje = "";

		public string Cilindraje {
			get { return cilindraje; }
			set { cilindraje = value; }
		}

		private string color = "";

		public string Color {
			get { return color; }
			set { color = value; }
		}

		private int carga = 0;

		public int Carga {
			get { return carga; }
			set { carga = value; }
		}

		private int pesobruto = 0;

		public int Pesobruto {
			get { return pesobruto; }
			set { pesobruto = value; }
		}

		private string combustible = "BEN";

		public string Combustible {
			get { return combustible; }
			set { combustible = value; }
		}

		private int npuerta = 0;

		public int Npuerta {
			get { return npuerta; }
			set { npuerta = value; }
		}

		private int nasiento = 0;

		public int Nasiento {
			get { return nasiento; }
			set { nasiento = value; }
		}
        private Int32 kilometraje;

        public Int32 Kilometraje
        {
            get { return kilometraje; }
            set { kilometraje = value; }
        }
        private Int32 precio;

        public Int32 Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private Int32 valor_cesion;

        public Int32 Valor_cesion
        {
            get { return valor_cesion; }
            set { valor_cesion = value; }
        }
        private Int32 tasacion;

        public Int32 Tasacion
        {
            get { return tasacion; }
            set { tasacion = value; }
        }
        private string codigo_SII;

        public string Codigo_SII
        {
            get { return codigo_SII; }
            set { codigo_SII = value; }
        }

        private Int32 rut_prenda;

        public Int32 Rut_prenda
        {
            get { return rut_prenda; }
            set { rut_prenda = value; }
        }

        private string transmision;

        public string Transmision
        {
            get { return transmision; }
            set { transmision = value; }
        }

        private string equipamiento;

        public string Equipamiento
        {
            get { return equipamiento; }
            set { equipamiento = value; }
        }

		//    private int id_solicitud;

		//    public int id_solicitud {
		//        get { return id_solicitud; }
		//        set { id_solicitud = value; }
		//    }
		//    private string patente;

		//    public string Patente {
		//        get { return patente; }
		//        set { patente = value; }
		//    }
		//    private string color;

		//    public string Color {
		//        get { return color; }
		//        set { color = value; }
		//    }
		//    private string chasis;

		//    public string Chasis {
		//        get { return chasis; }
		//        set { chasis = value; }
		//    }
		//    private string motor;

		//    public string Motor {
		//        get { return motor; }
		//        set { motor = value; }
		//    }
		//    private string vin;

		//    public string Vin {
		//        get { return vin; }
		//        set { vin = value; }
		//    }
		//    private string modelo;

		//    public string Modelo {
		//        get { return modelo; }
		//        set { modelo = value; }
		//    }
		//    private string serie;

		//    public string Serie {
		//        get { return serie; }
		//        set { serie = value; }
		//    }
		//    private string tipo;

		//    public string Tipo {
		//        get { return tipo; }
		//        set { tipo = value; }
		//    }
		//    private string marca;

		//    public string Marca {
		//        get { return marca; }
		//        set { marca = value; }
		//    }
		//    private string ano;

		//    public string Ano {
		//        get { return ano; }
		//        set { ano = value; }
		//    }

		private string financiamiento_amicar;

		public string Financiamiento_amicar
		{
			get { return financiamiento_amicar; }
			set { financiamiento_amicar = value; }
		}

       

	}
}