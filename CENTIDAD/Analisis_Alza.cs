using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Analisis_Alza
    {
        private Int32 monto;

        public Int32 Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private string fecha_carta;

        public string Fecha_carta
        {
            get { return fecha_carta; }
            set { fecha_carta = value; }
        }
        private string fecha_termino;

        public string Fecha_termino
        {
            get { return fecha_termino; }
            set { fecha_termino = value; }
        }
        private string cod_financiera;

        public string Cod_financiera
        {
            get { return cod_financiera; }
            set { cod_financiera = value; }
        }

        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }

        private string fecha_otorgamiento;

        public string Fecha_otorgamiento
        {
            get { return fecha_otorgamiento; }
            set { fecha_otorgamiento = value; }
        }
    }
}
