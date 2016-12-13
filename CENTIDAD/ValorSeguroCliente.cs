using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ValorSeguroCliente
    {
        private int id_seguro_cliente;

        public int Id_seguro_cliente
        {
            get { return id_seguro_cliente; }
            set { id_seguro_cliente = value; }
        }

        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
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

        private Int32 valorAGP;

        public Int32 ValorAGP
        {
            get { return valorAGP; }
            set { valorAGP = value; }
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
