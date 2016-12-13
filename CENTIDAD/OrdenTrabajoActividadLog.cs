using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public  class OrdenTrabajoActividadLog
    {
        public int IdOrdenTrabajoActividadLog { get; set; }
        public string IdOtLogEncriptado{ get; set; }
        public Usuario Usuario { get; set; }
        public ActividadDeOrdenTrabajo ActividadDeOrdenTrabajo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public byte Estado { get; set; }
        public int IdOtOrigen { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
        public int Avanza { get; set; }
        public int HorasActividad { get; set; }
        public int Semaforo { get; set; }
        public int CargaTrabajo { get; set; }
        public string PuedeVerOt { get; set; }


        public string Codigo { get; set; }
        public string Operacion { get; set; }
        public int IdDocumento { get; set; }
        public string Nombre { get; set; }
        public int IdCheck { get; set; }
        public int IdActividad { get; set; }
        public int EstadoRevision { get; set; }
        public string UsuarioActualNombre { get; set; }
        public string UsuarioActualCuenta { get; set; }
        //public CheckListActividadOrdenTrabajo CheckListActividadOrdenTrabajo { get; set; }


    }
}
