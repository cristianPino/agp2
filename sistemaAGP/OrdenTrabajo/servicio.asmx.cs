using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.OrdenTrabajo
{
    /// <summary>
    /// Descripción breve de NotificacionWS
    /// </summary>
    [System.Web.Script.Services.ScriptService()]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class servicio : System.Web.Services.WebService
    {

        [WebMethod]
        public OrdenTrabajoActividadLog GetOrdenTrabajoLog(string id)
        {
            return new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog{IdOrdenTrabajoActividadLog = Convert.ToInt32(id)});
        }


        [WebMethod]
        public ModeloVehiculo ValidaCit(string cit)
        {
            return new OrdenTrabajoBC().ValidaCit(cit.Trim());
        }

        [WebMethod]
        public OrdenTrabajoActividadLog GetUltimoOt(string idOt, string idUsuarioSession)
        {
            var log = new OrdenTrabajoActividadLog();
            log = new OrdenTrabajoActividadLogBC().GetLastOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    IdOrden = Convert.ToInt32(idOt)
                }

            });
            log.IdOtLogEncriptado = FuncionGlobal.FuctionEncriptar(log.IdOrdenTrabajoActividadLog.ToString());
            log.Avanza = new OrdenTrabajoActividadLogBC().GetOrdenTrabajoAnterior(new OrdenTrabajoActividadLog { OrdenTrabajo = new CENTIDAD.OrdenTrabajo { IdOrden = Convert.ToInt32(idOt) } }).Avanza;

            //var dd =
            //    new OrdenTrabajoRevisionBC().GetOrdenTrabajoRevision(new OrdenTrabajoRevision
            //        {IdOrdenTrabajo = Convert.ToInt32(idOt)});       

            var xx = new OrdenTrabajoActividadLogBC().PuedeVerOrdenTrabajoOt(new OrdenTrabajoActividadLog
                {
                    IdOrdenTrabajoActividadLog = log.IdOrdenTrabajoActividadLog,
                    Usuario = new UsuarioBC().GetUsuario(idUsuarioSession)
                });
            
            //if(dd.IntentosRevision<=0 && dd.IdOrdenTrabajo!=0)
            //{
            //    log.EstadoRevision = 1;
            //}
            //else
            //{
            //    log.EstadoRevision = 0;
            //}

            log.PuedeVerOt = xx ? "si" : "no";
            return log;
        }
    }
}
