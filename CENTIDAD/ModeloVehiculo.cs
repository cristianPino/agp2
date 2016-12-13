using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ModeloVehiculo
    {
        private int id_Modelo;
        private Marcavehiculo marcavehiculo;
        private Tipovehiculo tipovehiculo;
        private string nombre;
        private Int32 valorNox;
        private Int32 impuesto;

        public Int32 Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }
        public Int32 ValorNox
        {
            get { return valorNox; }
            set { valorNox = value; }
        }
        private Int32 rendimiento;

        public Int32 Rendimiento
        {
            get { return rendimiento; }
            set { rendimiento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public Tipovehiculo Tipovehiculo
        {
            get { return tipovehiculo; }
            set { tipovehiculo = value; }
        }

        public int Id_Modelo
        {
            get { return id_Modelo; }
            set { id_Modelo = value; }
        }

        public Marcavehiculo Marcavehiculo
        {
            get { return marcavehiculo; }
            set { marcavehiculo = value; }
        }


    }
}
