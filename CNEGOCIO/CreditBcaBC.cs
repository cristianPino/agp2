using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class CreditBcaBC
    {
        public string add_agendaBCA(Int32 operacion, Int32 NRef, Int32 rut_persona, Int32 n_interno)
        {
            string add = new CreditBcaDAC().add_agendaBCA(operacion,  NRef,  rut_persona,  n_interno);
            return add;
        }

        //public string del_agendaBCA(Int32 id_solicitud)
        //{
        //    string add = new AgendaDAC().del_agenda(id_solicitud);
        //    return add;
        //}

        public CreditBca getAgendaBCA(Int32 n_interno, Int32 rut_persona, string fecha_desde, string fecha_hasta)
        {
            CreditBca magenda = new CreditBcaDAC().getAgendaBCA(n_interno, rut_persona, fecha_desde, fecha_hasta);
            return magenda;
        }

        public List<CreditBca> getAgendasBCA(Int32 n_interno, Int32 rut_persona, string fecha_desde, string fecha_hasta)
        {
            List<CreditBca> lagenda = new CreditBcaDAC().getListAgendasBCA(n_interno, rut_persona, fecha_desde, fecha_hasta);
            return lagenda;
        }

    }
}
