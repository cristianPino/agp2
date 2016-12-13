using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class CreditBca
    {
        private Int32 Id_Interno;
        public Int32 id_Interno
        {
            get { return Id_Interno; }
            set { Id_Interno = value; }
        }

        private Persona rutCliente;

        public Persona RutCliente
        {
            get { return rutCliente; }
            set { rutCliente = value; }
        }
       
        private Int32 Id_creditoBCA;
        public Int32 Id_CreditoBCA
        {
            get { return Id_creditoBCA; }
            set { Id_creditoBCA = value; }
        }

        private Int32 Id_referencia;

        public Int32 Id_Referencia
        {
            get { return Id_referencia; }
            set { Id_referencia = value; }
        }

        private EstadoTipoOperacion oper;

        public EstadoTipoOperacion Oper
        {
            get { return oper; }
            set { oper = value; }
        }


    }
}
