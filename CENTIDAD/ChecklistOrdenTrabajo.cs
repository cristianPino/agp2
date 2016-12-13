using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public  class ChecklistOrdenTrabajo
    {
       public int IdChecklistOrdenTrabajo { get; set; }
       public Checklist Checklist { get; set; }
       public string Fecha { get; set; }
       public string CuentaUsuario { get; set; }
       public string Url { get; set; }
       public int IdChecklist { get; set; }
       public int IdOrdenTrabajo { get; set; }
       public string Observacion { get; set; }
       public string DescripcionChecklist { get; set; }
    }
}
