using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Retiro_Carpeta
    {
        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        private Int32 id_sucursal;

        public Int32 Id_sucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }
        private Int32 num_credito;

        public Int32 Num_credito
        {
            get { return num_credito; }
            set { num_credito = value; }
        }
        private string ejecutivo;

        public string Ejecutivo
        {
            get { return ejecutivo; }
            set { ejecutivo = value; }
        }
        private Int32 rut_adquiriente;

        public Int32 Rut_adquiriente
        {
            get { return rut_adquiriente; }
            set { rut_adquiriente = value; }
        }

        private string financiera;

        public string Financiera
        {
            get { return financiera; }
            set { financiera = value; }
        }

        private string concesionario;

        public string Concesionario
        {
            get { return concesionario; }
            set { concesionario = value; }
        }

        private string prohibicion;

        public string Prohibicion
        {
            get { return prohibicion; }
            set { prohibicion = value; }
        }
        private string codigo_ot;

        public string Codigo_ot
        {
            get { return codigo_ot; }
            set { codigo_ot = value; }
        }

        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }

        private string fecha_adjudicacion;
        public string Fecha_adjudicacion
        {
            get
            {
                return fecha_adjudicacion;
            }

            set
            {
                fecha_adjudicacion = value;
            }
        }

       
    }
}
