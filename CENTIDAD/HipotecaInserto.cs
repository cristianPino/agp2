using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public class HipotecaInserto
    {
       public int IdInserto { get; set; }
       public int IdInsertoTitulo { get; set; }
       public int IdSolicitud { get; set; }
       public string Texto { get; set; }
       public string CuentaUsuario { get; set; }
       public DateTime Fecha { get; set; }
       public Usuario Usuario { get; set; }
       public HipotecaInsertoTitulo InsertoTitulo { get; set; }
    }
}
