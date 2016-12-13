using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
  public  class ChecklistBC
    {
      public List<Checklist> GetCecklistbyTipo(int tipo)
      {
          return new ChecklistDAC().GetCecklistbyTipo(tipo);
      }
    }
}
