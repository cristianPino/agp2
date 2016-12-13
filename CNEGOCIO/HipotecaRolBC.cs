
using System.Collections.Generic;   
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class HipotecaRolBC
    {
        public string AddHipotecarioRol(int idSolicitud, string numeroRol, int idRol = 0)
        {
            return new HipotecaRolDAC().AddHipotecarioRol(idSolicitud, numeroRol, idRol);
        }
        public List<HipotecaRol> Get_hipoteca_roles(int idSolicitud)
        {
            return new HipotecaRolDAC().Get_hipoteca_roles(idSolicitud);
        }
        public void DelHipotecarioRol(int idRol)
        {
            new HipotecaRolDAC().DelHipotecarioRol(idRol);
        }
    }
}
