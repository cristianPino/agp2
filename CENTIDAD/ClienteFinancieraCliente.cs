﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ClienteFinancieraCliente
    {
        private string nombre;
		private string codigo;
        private string codigo_banco;

        public string Codigo_banco
        {
            get { return codigo_banco; }
            set { codigo_banco = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



    }
}
