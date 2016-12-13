using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class PerfilBC
    {
        
        public Perfil  GetPerfilByUsrName(string  usrName)
        {
            var perfil = new PerfilDAC().GetPerfilByUsrName(usrName);
            return perfil;
        }

        public List<Perfil> getperfiles()
        {

            List<Perfil> lperfil = new PerfilDAC().GetPerfiles();

            return lperfil;
        
        }
        public string add_Perfil(string codigoperfil, string nombre)
        {

            string add = new PerfilDAC().add_Perfil(codigoperfil, nombre);
            return add;

        }

        public string add_Perfilopcionmenu(string codigoperfil, string codigoopcionmenu)
        {
            string add = new PerfilDAC().add_Perfilopcionmenu(codigoperfil, codigoopcionmenu);
            return add;
        }

        public string del_Perfilopcionmenu(string codigoperfil, string codigoopcionmenu)
        {
            string del = new PerfilDAC().del_Perfilopcionmenu(codigoperfil, codigoopcionmenu);
            return del;
        }
      

    }
}
