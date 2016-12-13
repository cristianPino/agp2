using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public  class Leasing_transferencia
    {
        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        private DateTime fecha_contrato;

        public DateTime Fecha_contrato
        {
            get { return fecha_contrato; }
            set { fecha_contrato = value; }
        }
       private string patente;

       public string Patente
       {
           get { return patente; }
           set { patente = value; }
       }
       private Int32 n_contrato;

       public Int32 N_contrato
       {
           get { return n_contrato; }
           set { n_contrato = value; }
       }
       private Int32 valor_opcion;

       public Int32 Valor_opcion
       {
           get { return valor_opcion; }
           set { valor_opcion = value; }
       }
       private Int32 valor_cesion;

       public Int32 Valor_cesion
       {
           get { return valor_cesion; }
           set { valor_cesion = value; }
       }

       private Int32 n_vehiculos;

       public Int32 N_vehiculos
       {
           get { return n_vehiculos; }
           set { n_vehiculos = value; }
       }

    }
}
