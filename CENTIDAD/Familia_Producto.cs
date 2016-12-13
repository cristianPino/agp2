using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Familia_Producto
    {
        private Int32 id_familia;

        public Int32 Id_familia
        {
            get { return id_familia; }
            set { id_familia = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

		private string codigo;

		public string Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		private string operacion;

		public string Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}

        private string codigo_nav;

        public string Codigo_nav
        {
            get { return codigo_nav; }
            set { codigo_nav = value; }
        }


		//Prueba
    }
}
