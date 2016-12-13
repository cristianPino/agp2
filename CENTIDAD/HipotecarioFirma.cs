using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class HipotecarioFirma : HipotecarioTituloFirma
    {
        public int IdHipotecarioFirma { get; set; }
        public int IdSolicitud { get; set; }
        public Usuario UsuarioFirma { get; set; }
        public DateTime FechaFirma { get; set; }
        public string Comentario { get; set; }
        public Usuario UsuarioBaja { get; set; }
        public DateTime FechaBaja { get; set; }
        public string ComentarioBaja { get; set; }
        public bool Estado { get; set; }
        public bool Existe { get; set; }
    }
}
