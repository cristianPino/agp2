using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
	public class UsuarioBC
	{
        public void ReestablecerContrasenia(string userName, string clave)
        {
            new UsuarioDAC().ReestablecerContrasenia(userName,clave);
        }

	    public Boolean ValidarUsuario(string username, string clave)
		{
			Usuario usr = new UsuarioDAC().GetUsuarioBySesion(username, clave);
			if (usr.UserName == null)
			{ return false; }
			else
			{ return true; }
		}

		public Usuario GetUsuario(string username)
		{
			Usuario usr = new UsuarioDAC().GetusuariobyUsername(username);
			return usr;
		}

		public List<Usuario> GetUsuariobycliente(Int32 id_cliente)
		{
			List<Usuario> lusuario = new UsuarioDAC().Getusuariobycliente(id_cliente);
			return lusuario;
		}


		public int add_usuario(string username, string nombre, string clave, string telefono, int anexo, string correo, string nivel, int intentos, Int16 id_cliente, string id_perfil, bool permite_eliminar, string usuanav,bool permite_pagar)
		{
			Usuario usr = new Usuario();
			usr.UserName = username;
			usr.Nombre = nombre;
			usr.Contraseña = clave;
			usr.Telefono = telefono;
			usr.Anexo = anexo;
			usr.Correo = correo;
			usr.Nivel = nivel;
			usr.Itentos = intentos;
			usr.Cliente = new ClienteDAC().Getcliente(id_cliente);
			usr.Perfil = new PerfilDAC().GetPerfil(id_perfil);
			usr.Permite_eliminar = permite_eliminar;
			usr.Usuanav = usuanav;
            usr.Permite_pagar = permite_pagar;
			int add = new UsuarioDAC().add_usuario(usr);
			return add;
		}

		public int add_usuario_modulo(string cuenta_usuario, Int16 id_modulo)
		{
			int add = new UsuarioDAC().add_modulo_usuario(cuenta_usuario, id_modulo);
			return add;
		}

		public int del_usuario_modulo(string cuenta_usuario, Int16 id_modulo)
		{
			int del = new UsuarioDAC().del_modulo_usuario(cuenta_usuario, id_modulo);
			return del;
		}

        public int add_usuario_sucursal(string cuenta_usuario, Int16 id_sucursal, Boolean check_encargado, Boolean check_supervisor)
		{
            int add = new UsuarioDAC().add_sucursal_usuario(cuenta_usuario, id_sucursal, check_encargado,check_supervisor);
			return add;
		}

        public int del_usuario_sucursal(string cuenta_usuario, Int16 id_sucursal, Boolean check_encargado, Boolean check_supervisor)
		{
            int del = new UsuarioDAC().del_sucursal_usuario(cuenta_usuario, id_sucursal, check_encargado,check_supervisor);
			return del;
		}

		public string add_Usuarioopcionmenu(string cuenta_usuario, string codigoopcionmenu)
		{
			string add = new UsuarioDAC().add_Usuarioopcionmenu(cuenta_usuario, codigoopcionmenu);
			return add;
		}

		public string del_Usuarioopcionmenu(string cuenta_usuario, string codigoopcionmenu)
		{
			string del = new UsuarioDAC().del_Usuarioopcionmenu(cuenta_usuario, codigoopcionmenu);
			return del;
		}

        public List<Usuario> getusuariobyperfil(string codigo)
        {
            List<Usuario> lusuario = new UsuarioDAC().getusuariobyperfil(codigo);
            return lusuario;
        }


        public List<Usuario> getusuariobynivel(string codigo)
        {
            List<Usuario> lusuario = new UsuarioDAC().getusuariobynivel(codigo);
            return lusuario;
        }





	}
}