using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class ChecklistOrdenTrabajoBC
    {
        public string AddChecklistOrdenTrabajo(ChecklistOrdenTrabajo check)
        {
            return new ChecklistOrdenTrabajoDAC().AddChecklistOrdenTrabajo(check);
        }

        public List<ChecklistOrdenTrabajo> GetCecklistOrdenTrabajo(int idOrdenTrabajo)
        {
            return new ChecklistOrdenTrabajoDAC().GetCecklistOrdenTrabajo(idOrdenTrabajo); 
        }

        public void DelCecklistOrdenTrabajo(int idChecklistOt)
        {
            new ChecklistOrdenTrabajoDAC().DelCecklistOrdenTrabajo(idChecklistOt);
        }
    }
}
