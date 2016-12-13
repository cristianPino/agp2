using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Cotizacion
    {
        private int id_cotizacion;

        public int Id_cotizacion
        {
            get { return id_cotizacion; }
            set { id_cotizacion = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        private int monto;

        public int Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private string fechafac;

        public string Fechafac
        {
            get { return fechafac; }
            set { fechafac = value; }
        }
	
		

    }
}
