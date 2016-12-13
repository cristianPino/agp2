using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Agenda
    {
        private Int32 id_solicitud;
        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }

        private DateTime fecha_firma;
        public DateTime Fecha_firma
        {
            get { return fecha_firma; }
            set { fecha_firma = value; }
        }
        
        private string hora_firma;
        public string Hora_firma
        {
            get { return hora_firma; }
            set { hora_firma = value; }
        }
        
        private Int32 n_intentos;
        public Int32 N_intentos
        {
            get { return n_intentos; }
            set { n_intentos = value; }
        }
        
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string cliente;
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string Comuna;
        public string comuna
        {
            get { return Comuna; }
            set { Comuna = value; }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        
        private Int32 rut_persona;
        public Int32 Rut_persona
        {
            get { return rut_persona; }
            set { rut_persona = value; }
        }

        private string ejecutivo;

        public string Ejecutivo
        {
            get { return ejecutivo; }
            set { ejecutivo = value; }
        }

        private string tipoagenda;

        public string Tipoagenda
        {
            get { return tipoagenda; }
            set { tipoagenda = value; }
        }

        
    
    }
}
