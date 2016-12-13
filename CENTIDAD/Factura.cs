using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Factura
    {
        private Int32 n_factura_agp;

        public Int32 N_factura_agp
        {
            get { return n_factura_agp; }
            set { n_factura_agp = value; }
        }
        private DateTime fecha_factura_agp;

        public DateTime Fecha_factura_agp
        {
            get { return fecha_factura_agp; }
            set { fecha_factura_agp = value; }
        }

        private Int32 id_factura;

        public Int32 Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }
        private Int32 total_neto;

        public Int32 Total_neto
        {
            get { return total_neto; }
            set { total_neto = value; }
        }
        private string orden_compra;

        public string Orden_compra
        {
            get { return orden_compra; }
            set { orden_compra = value; }
        }
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        private string giro;

        public string Giro
        {
            get { return giro; }
            set { giro = value; }
        }
        private Int32 total_gasto;

        public Int32 Total_gasto
        {
            get { return total_gasto; }
            set { total_gasto = value; }
        }
        private Int32 cantidad_operaciones;

        public Int32 Cantidad_operaciones
        {
            get { return cantidad_operaciones; }
            set { cantidad_operaciones = value; }
        }

        private string tipo_operacion;

        public string Tipo_operacion
        {
            get { return tipo_operacion; }
            set { tipo_operacion = value; }
        }

        private Int32 saldo_pendiente;

        public Int32 Saldo_pendiente
        {
            get { return saldo_pendiente; }
            set { saldo_pendiente = value; }
        }

        private Int32 rut_tercero;

        public Int32 Rut_tercero
        {
            get { return rut_tercero; }
            set { rut_tercero = value; }
        }

        private Int32 folio;
        public Int32 Folio
        {
            get { return folio; }
            set { folio = value; }
        }

    }


}
