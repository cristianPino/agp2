using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public class MensajeOrdenTrabajo
    {
       public int IdMensaje { get; set; }
       public int IdOrdenTrabajo { get; set; }
       public string Mensaje { get; set; }
       public string IdUsuario { get; set; }
       public string NombreUsuario { get; set; }
       public string Fecha { get; set; }
       //para tbl_mensaje_usuario_destinatarios
       public bool Favorito { get; set; }
    }
}
