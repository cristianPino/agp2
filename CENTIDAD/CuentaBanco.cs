using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class CuentaBanco
    {
        private Int16 id_cuenta_banco;

        public Int16 Id_cuenta_banco
        {
            get { return id_cuenta_banco; }
            set { id_cuenta_banco = value; }
        }
        private BancoFinanciera banco;

        public BancoFinanciera Banco
        {
            get { return banco; }
            set { banco = value; }
        }
        private string numero_cuenta;

        public string Numero_cuenta
        {
            get { return numero_cuenta; }
            set { numero_cuenta = value; }
        }


    }
}
