using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Cuenta_Corriente
    {
        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private string banco;

        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }
        private string tipo_cuenta;

        public string Tipo_cuenta
        {
            get { return tipo_cuenta; }
            set { tipo_cuenta = value; }
        }
        private string cuenta_usuario;

        public string Cuenta_usuario
        {
            get { return cuenta_usuario; }
            set { cuenta_usuario = value; }
        }
        private Int32 id_cta_cte;

        public Int32 Id_cta_cte
        {
            get { return id_cta_cte; }
            set { id_cta_cte = value; }
        }
        private string cuenta;

        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }
    }  
}
