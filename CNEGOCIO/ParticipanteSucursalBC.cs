using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;
namespace CNEGOCIO
{
    public class ParticipanteSucursalBC
    {
        public List<ParticipanteSucursal> getParticipanteSucursal(Int16 id_modulo, string rut_participante)
        {
            List<ParticipanteSucursal> lsucursal = new ParticipanteSucursalDAC().getParticipantesucursal(id_modulo, rut_participante);
            return lsucursal;
        }
        public string add_participantebysucursal(Int32 id_sucursal, string rut_participante)
        {
            string add = new ParticipanteSucursalDAC().add_ParticipanteSucursal(rut_participante, id_sucursal);
            return add;
        }
        public string del_participantebysucursal( string rut_participante,Int32 id_sucursal)
        {
            string add = new ParticipanteSucursalDAC().del_ParticipanteSucursal(rut_participante,id_sucursal);
            return add;
        }
    }
}
