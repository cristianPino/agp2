using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
  public class ActividadOrdenTrabajoBC
    {
      public ActividadDeOrdenTrabajo GetActividad(ActividadDeOrdenTrabajo ac)
      {
          return new ActividadOrdenTrabajoDAC().GetActividad(ac);
      }
      public ActividadDeOrdenTrabajo GetSiguienteActividad(ActividadDeOrdenTrabajo ac)
      {
          return new ActividadOrdenTrabajoDAC().GetSiguienteActividad(ac);
      }

      public List<ActividadDeOrdenTrabajo> GetActividadesOtByUsuario(string cuentaUsuario)
      {
          return new ActividadOrdenTrabajoDAC().GetActividadesOtByUsuario(cuentaUsuario);
      }
    }
}
