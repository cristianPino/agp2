using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;
namespace CNEGOCIO
{
    public class UsuarioEstadoBC
    {
        public List<UsuarioEstado> get_all(string cuentaUsuario, int idFamilia)
        {
            return new UsuarioEstadoDAC().get_all(cuentaUsuario, idFamilia);
        }
        public void Upt(string cuentaUsuario, int codigoEstado, byte soloLectura)
        {
            new UsuarioEstadoDAC().Upt(cuentaUsuario, codigoEstado, soloLectura);
        }
        public void Del(string cuentaUsuario, int codigoEstado)
        {
            new UsuarioEstadoDAC().Del(cuentaUsuario,codigoEstado);
        }
    }
}
