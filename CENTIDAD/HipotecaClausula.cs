using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public  class HipotecaClausula
    {
       public int IdClausula { get; set; }
       public string Nombre { get; set; }
       public string Texto { get; set; }
       public int IdCliente { get; set; }
       public bool Pertenece { get; set; }
    }
}
