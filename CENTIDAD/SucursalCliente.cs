using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class SucursalCliente
    {
        private Int16 id_sucursal;
        private Comuna comuna;
        private Cliente cliente;
        private ModuloCliente modulocliente;
        private string nombre;
        private int ind_principal;
        private Boolean check_encargado;
		private Boolean check_supervisor;

        public Boolean Check_encargado
        {
            get { return check_encargado; }
            set { check_encargado = value; }
        }
		public Boolean Check_supervisor
		{
			get { return check_supervisor; }
			set { check_supervisor = value; }
		}

        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }

        public int Ind_principal
        {
            get { return ind_principal; }
            set { ind_principal = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
       


        public ModuloCliente Modulocliente
        {
            get { return modulocliente; }
            set { modulocliente = value; }
        }
        
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
       

        public Comuna Comuna
        {
            get { return comuna; }
            set { comuna = value; }
        }
        

        public Int16 Id_sucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }

        private string codnav;

        public string Codnav
        {
            get { return codnav; }
            set { codnav = value; }
        }

    }
}
