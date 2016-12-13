using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ValorSeguroVehiculo
    {
        private int id_seguro;

        public int Id_seguro
        {
            get { return id_seguro; }
            set { id_seguro = value; }
        }

        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string codigo_distribuidor;

        public string Codigo_distribuidor
        {
            get { return codigo_distribuidor; }
            set { codigo_distribuidor = value; }
        }


        private Int32 valor;

        public Int32 Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private Tipovehiculo tipovehiculo;

        public Tipovehiculo Tipovehiculo
        {
            get { return tipovehiculo; }
            set { tipovehiculo = value; }
        }

        private DateTime fechaDesde;

        public DateTime FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        private DateTime fechaHasta;

        public DateTime FechaHasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }

        private Int32 periodo;

        public Int32 Periodo
        {
            get { return periodo; }
            set { periodo = value; }
        }
    }
}
