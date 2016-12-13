using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CENTIDAD
{
    public class TasacionSII
    {
        private double id_vehiculo;
        private string codigosii;
        private string tipo_vehiculo;
        private string marca;
        private string modelo;
        private int puerta;
        private double cilindrada;
        private string combustible;
        private string transmision;
        private string equipo;
        private double tasacion;
        private double permiso;
        private int ano;
                
        public double Id_vehiculo
        {
            get { return id_vehiculo; }
            set { id_vehiculo = value; }
        }
        
        public string Codigosii
        {
            get { return codigosii; }
            set { codigosii = value; }
        }
       
        public string Tipo_vehiculo
        {
            get { return tipo_vehiculo; }
            set { tipo_vehiculo = value; }
        }
       

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
       

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
       
        public int Puerta
        {
            get { return puerta; }
            set { puerta = value; }
        }
       

        public double Cilindrada
        {
            get { return cilindrada; }
            set { cilindrada = value; }
        }
       

        public string Combustible
        {
            get { return combustible; }
            set { combustible = value; }
        }
        

        public string Transmision
        {
            get { return transmision; }
            set { transmision = value; }
        }
       

        public string Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }
        

        public double Tasacion
        {
            get { return tasacion; }
            set { tasacion = value; }
        }
        

        public double Permiso
        {
            get { return permiso; }
            set { permiso = value; }
        }
        

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
           



    }
}
