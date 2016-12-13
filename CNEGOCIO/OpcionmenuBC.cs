using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class OpcionmenuBC

    {
        public List<OpcionMenu> GetOpcionmenuFavoritoByusuario(string cuentaUsuario)
        {
            return new OpcionmenuDAC().GetOpcionmenuFavoritoByusuario(cuentaUsuario);
        }

        public OpcionMenu GetOpcionmenuBycodigo(string codigo)
        {
            return new OpcionmenuDAC().GetOpcionmenuBycodigo(codigo);
        }



        public List<OpcionMenu> GetOpcionmenuByPerfil(string strPerfil)
        {
            List<OpcionMenu> lOpcionmenu = new OpcionmenuDAC().GetOpcionmenuByPerfil(strPerfil);
            return lOpcionmenu;
        }
        public List<OpcionMenu> GetOpcionmenuByusuario(string cuenta_usuario)
        {
            List<OpcionMenu> lOpcionmenu = new OpcionmenuDAC().GetOpcionmenuByusuario(cuenta_usuario);
            return lOpcionmenu;
        }

        public List<OpcionMenu> GetPerfilopcionmenu(string strPerfil)
        {
            List<OpcionMenu> lOpcionmenu = new OpcionmenuDAC().GetPerfilopcionmenu(strPerfil);
            return lOpcionmenu;
        }
        public List<OpcionMenu> GetUsuarioopcionmenu(string cuenta_usuario)
        {
            List<OpcionMenu> lOpcionmenu = new OpcionmenuDAC().GetUsuarioopcionmenu(cuenta_usuario);
            return lOpcionmenu;
        }
    }
}
