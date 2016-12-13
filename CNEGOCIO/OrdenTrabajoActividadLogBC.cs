using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class OrdenTrabajoActividadLogBC
    {
        public OrdenTrabajoActividadLog GetOrdenTrabajoLogbyidOT(int id)
        {
            return new OrdenTrabajoActividadLogDAC().GetOrdenTrabajoLogbyidOT(id);
        }
        public List<OrdenTrabajoActividadLog> getCheckEjecutivo_by_idActividad(int idAct, int tipoChec)
        {
            return new OrdenTrabajoActividadLogDAC().getCheckEjecutivo_by_idActividad(idAct, tipoChec);
        }
        public void AddOrdenTrabajoLog(OrdenTrabajoActividadLog ot)
        {
            new OrdenTrabajoActividadLogDAC().AddOrdenTrabajoLog(ot);
        }

        public DataTable GetGrafico(string cuentaUsuario)
        {
            return new OrdenTrabajoActividadLogDAC().GetGrafico(cuentaUsuario);  
        }

        public List<OrdenTrabajoActividadLog> GetOrdenTrabajoLogbyUsuario(OrdenTrabajoActividadLog ot, string desde, string hasta, string usuarioBusqueda,
            string grupo, int idCliente)
        { 
            return new OrdenTrabajoActividadLogDAC().GetOrdenTrabajoLogbyUsuario(ot,desde,hasta, usuarioBusqueda,grupo,idCliente);
        }
        public List<OrdenTrabajoActividadLog> GetOrdenTrabajoLogbyUsuarioGrafico(OrdenTrabajoActividadLog ot)
        {
            return new OrdenTrabajoActividadLogDAC().GetOrdenTrabajoLogbyUsuarioGrafico(ot);
        }

        public OrdenTrabajoActividadLog GetOrdenTrabajoLogbyid(OrdenTrabajoActividadLog ot)
        {
            return new OrdenTrabajoActividadLogDAC().GetOrdenTrabajoLogbyid(ot);
        }

        public List<OrdenTrabajoActividadLog> GetCargTrabajoUsuariosByActividadOt(OrdenTrabajoActividadLog ot, string grupo,int all=0)
        {
            return new OrdenTrabajoActividadLogDAC().GetCargTrabajoUsuariosByActividadOt(ot,grupo,all);
        }

        public OrdenTrabajoActividadLog GetOrdenTrabajoAnterior(OrdenTrabajoActividadLog ot)
        {
            return new OrdenTrabajoActividadLogDAC().GetOrdenTrabajoAnterior(ot);
        }

        public List<OrdenTrabajoActividadLog> GetOrdenTrabajoFlujo(OrdenTrabajoActividadLog ot)
        {
            return new OrdenTrabajoActividadLogDAC().GetOrdenTrabajoFlujo(ot);
        }

        public OrdenTrabajoActividadLog GetLastOrdenTrabajoLogbyid(OrdenTrabajoActividadLog ot)
        {
            return new OrdenTrabajoActividadLogDAC().GetLastOrdenTrabajoLogbyid(ot);
        }

        public bool PuedeVerOrdenTrabajoOt(OrdenTrabajoActividadLog ot)
        {
            return new OrdenTrabajoActividadLogDAC().PuedeVerOrdenTrabajoOt(ot);
        }
    }
}
