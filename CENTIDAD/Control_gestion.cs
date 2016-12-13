using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Control_gestion
    {
        private Operacion id_solicitud;

        public Operacion Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }


        private Persona rut;

        public Persona Rut
        {
            get { return rut; }
            set { rut = value; }
        }


        private ProdCliente id_producto_cliente;

        public ProdCliente Id_producto_cliente
        {
            get { return id_producto_cliente; }
            set { id_producto_cliente = value; }
        }

      
        private Int32 total_gestion;

        public Int32 Total_gestion
        {
            get { return total_gestion; }
            set { total_gestion = value; }
        }
        private DateTime fecha_gestion;

        public DateTime Fecha_gestion
        {
            get { return fecha_gestion; }
            set { fecha_gestion = value; }
        }
        private Int32 numero_cuotas;

        public Int32 Numero_cuotas
        {
            get { return numero_cuotas; }
            set { numero_cuotas = value; }
        }
        private string numero_operacion;

        public string Numero_operacion
        {
            get { return numero_operacion; }
            set { numero_operacion = value; }
        }

        private SucursalCliente id_sucursal;

        public SucursalCliente Id_sucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }

        private string programacion;

        public string Programacion
        {
            get { return programacion; }
            set { programacion = value; }
        }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        private FormaPago id_forma_pago;

        public FormaPago Id_forma_pago
        {
            get { return id_forma_pago; }
            set { id_forma_pago = value; }
        }

        private Persona rut_vendedor;

        public Persona Rut_vendedor
        {
            get { return rut_vendedor; }
            set { rut_vendedor = value; }
        }

        private Int32 cuenta_regresiva;

        public Int32 Cuenta_regresiva
        {
            get { return cuenta_regresiva; }
            set { cuenta_regresiva = value; }
        }

        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }
        private Int32 monto_final;

        public Int32 Monto_final
        {
            get { return monto_final; }
            set { monto_final = value; }
        }
    }
}
