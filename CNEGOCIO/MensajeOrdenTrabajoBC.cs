using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class MensajeOrdenTrabajoBC
    {
        public int AddMensaje(MensajeOrdenTrabajo mensaje)
        {
          return  new MensajeOrdenTrabajoDAC().AddMensaje(mensaje);
        }

        public List<MensajeOrdenTrabajo> GetMensajes(int idOrdenTrabajo)
        {
            return new MensajeOrdenTrabajoDAC().GetMensajes(idOrdenTrabajo);
        }

        public List<MensajeOrdenTrabajo> GetContactos(string cuentaUsuario)
        {
            return new MensajeOrdenTrabajoDAC().GetContactos(cuentaUsuario);
        }

        public void AddMensajeaDestinatarios(int idMensaje, string usuarioDestino, string actualizaFecha)
        {
            new MensajeOrdenTrabajoDAC().AddMensajeaDestinatarios(idMensaje,usuarioDestino,actualizaFecha);
        }
    }
}
