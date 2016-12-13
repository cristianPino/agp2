using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Usuario
    {
        private string contraseña;
        private string userName;
        private string nombre;
        private string codigoperfil;
        private string telefono;
        private int anexo;
        private string correo;
        private Cliente cliente;
        private Perfil perfil;
        private string nivel;
		private string usuanav;
        private bool permite_pagar;

        public bool Permite_pagar
        {
            get { return permite_pagar; }
            set { permite_pagar = value; }
        }
		
		private bool permite_eliminar;

		public bool Permite_eliminar
		{
			get { return permite_eliminar; }
			set { permite_eliminar = value; }
		}

        public string Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        private DateTime fechacreacion;

        public DateTime Fechacreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
        }
        private DateTime fechacaducacion;

        public DateTime Fechacaducacion
        {
            get { return fechacaducacion; }
            set { fechacaducacion = value; }
        }
        private int itentos;

        public int Itentos
        {
            get { return itentos; }
            set { itentos = value; }
        }
        private string bloqueado;

        public string Bloqueado
        {
            get { return bloqueado; }
            set { bloqueado = value; }
        }


        public Perfil Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }


        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public int Anexo
        {
            get { return anexo; }
            set { anexo = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Codigoperfil
        {
            get { return codigoperfil; }
            set { codigoperfil = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }


		public string Usuanav
		{
			get { return usuanav; }
			set { usuanav = value; }
		}
    }
}
