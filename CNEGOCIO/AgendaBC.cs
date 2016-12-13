using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class AgendaBC
    {
        public string add_agenda(Int32 operacion, DateTime fecha_firma, string hora_firma, Int32 rut_persona, string cuenta_usuario, string ejecutivo, string tipoagn, string useragp)
        {
            string add = new AgendaDAC().add_agenda(operacion, fecha_firma, hora_firma, rut_persona, cuenta_usuario, ejecutivo, tipoagn, useragp);
            return add;
        }

        public string del_agenda(Int32 id_solicitud)
        {
            string add = new AgendaDAC().del_agenda(id_solicitud);
            return add;
        }

        public Agenda getAgenda(Int32 id_solicitud)
        {
            Agenda magenda= new AgendaDAC().getAgenda(id_solicitud);
            return magenda;
        }

        public List<Agenda> getAgendas(string cuenta_usuario, string fecha)
        {
            List<Agenda> lagenda = new AgendaDAC().getAgendas(cuenta_usuario,fecha);
            return lagenda;
        }
       
        public List<Agenda> gethoras()
        {
            List<Agenda> lagenda = new AgendaDAC().getHoras();
            return lagenda;
        }

    }
}
