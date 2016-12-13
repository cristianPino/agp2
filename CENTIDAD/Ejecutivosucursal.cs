using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Ejecutivosucursal
    {
		private string id_sucursal_cliente;

		public string Id_sucursal_cliente
		{
			get { return id_sucursal_cliente; }
			set { id_sucursal_cliente = value; }
		}
		private Int16 id_sucursal;
		private string nombre;
        private Cliente cliente;
		private string descripcion;
		private string correo;


		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}

		public Int16 Id_sucursal
		{
			get { return id_sucursal; }
			set { id_sucursal = value; }
		}


		

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}


        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



    }
}
