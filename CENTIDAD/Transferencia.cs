using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Transferencia
    {
        private Boolean check;
        private Operacion operacion;
        private DateTime fechaSolicitud;
        private Usuario ejecutivo;
        private Persona vendedor;
        private string patente;
        private int precioVenta;
        private int kilometraje;
        private int tasacion;
        private string codigoSII;
        private Persona comprador;
        private Persona compra_para;
        private Int32 id_sucursal;
        private DateTime fecha_cesion;
        private string tag;
        private string tipo_operacion;
        private string tipo_transferencia;
        private string validacion;


        public string Tipo_Transferencia
        {
            get { return tipo_transferencia; }
            set { tipo_transferencia = value; }
        }


        public string Tipo_operacion
        {
            get { return tipo_operacion; }
            set { tipo_operacion = value; }
        }

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }
        public DateTime Fecha_cesion
        {
            get { return fecha_cesion; }
            set { fecha_cesion = value; }
        }

        public Int32 Id_sucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }

        public Operacion Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
       
        public DateTime FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }
       

        public Usuario Ejecutivo
        {
            get { return ejecutivo; }
            set { ejecutivo = value; }
        }
       

        public Persona Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
       

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }
       

        public int PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
       

        public int Kilometraje
        {
            get { return kilometraje; }
            set { kilometraje = value; }
        }
       

        public int Tasacion
        {
            get { return tasacion; }
            set { tasacion = value; }
        }
       

        public string CodigoSII
        {
            get { return codigoSII; }
            set { codigoSII = value; }
        }
       
        public Persona Comprador
        {
            get { return comprador; }
            set { comprador = value; }
        }
       

        public Persona Compra_para
        {
            get { return compra_para; }
            set { compra_para = value; }
        }

		private Boolean habilitada;

		public Boolean Habilitada
		{
			get { return habilitada; }
			set { habilitada = value; }
		}

        private BancoFinanciera banco_financiera;

        public BancoFinanciera Banco_financiera
        {
            get { return banco_financiera; }
            set { banco_financiera = value; }
        }
        private string forma_pago;
       
       
        public string Forma_pago
        {
            get { return forma_pago; }
            set { forma_pago = value; }
        }

        public string Validacion
        {
            get { return validacion; }
            set { validacion = value; }
        }
    }
}
