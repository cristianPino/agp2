using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Movimiento_Cta_Cte
    {
        private Int32 id_movimiento;

        public Int32 Id_movimiento
        {
            get { return id_movimiento; }
            set { id_movimiento = value; }
        }
        private Int32 id_cta_cte;

        public Int32 Id_cta_cte
        {
            get { return id_cta_cte; }
            set { id_cta_cte = value; }
        }
        private Int32 monto;

        public Int32 Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private DateTime fecha_hora;

        public DateTime Fecha_hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }
        private string tipo_movimiento;

        public string Tipo_movimiento
        {
            get { return tipo_movimiento; }
            set { tipo_movimiento = value; }
        }
        private string usuario_movimiento;

        public string Usuario_movimiento
        {
            get { return usuario_movimiento; }
            set { usuario_movimiento = value; }
        }
        private Int32 carga;

        public Int32 Carga
        {
            get { return carga; }
            set { carga = value; }
        }
        private Int32 abono;

        public Int32 Abono
        {
            get { return abono; }
            set { abono = value; }
        }
        private Int32 saldo;

        public Int32 Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
    }
}
