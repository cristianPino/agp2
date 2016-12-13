using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Predatovehiculo
    {
        private Operacion operacion;

        public Operacion Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        private ModeloVehiculo modelo;

        public ModeloVehiculo Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        private string chassis;

        public string Chassis
        {
            get { return chassis; }
            set { chassis = value; }
        }
        private int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        private string motor;

        public string Motor
        {
            get { return motor; }
            set { motor = value; }
        }
        private string cilindraje;

        public string Cilindraje
        {
            get { return cilindraje; }
            set { cilindraje = value; }
        }
        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private double carga;

        public double Carga
        {
            get { return carga; }
            set { carga = value; }
        }
        private double pesobruto;

        public double Pesobruto
        {
            get { return pesobruto; }
            set { pesobruto = value; }
        }
        private string combustible;

        public string Combustible
        {
            get { return combustible; }
            set { combustible = value; }
        }
        private int n_puerta;

        public int N_puerta
        {
            get { return n_puerta; }
            set { n_puerta = value; }
        }
        private int n_asiento;

        public int N_asiento
        {
            get { return n_asiento; }
            set { n_asiento = value; }
        }

        private string dv;

        public string Dv
        {
            get { return dv; }
            set { dv = value; }
        }



    }
}
