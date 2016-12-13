using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class ParticipeOperacionBC
    {
        public List<ParticipeOperacion> getparticipes(Int32 id_solicitud)
        {
            return new ParticipeOperacionDAC().getparticipe(id_solicitud);
        }

        public string add_participe(Int32 id_solicitud, int rut, string tipo)
        {
            return new ParticipeOperacionDAC().add_OperacionParticipe(id_solicitud, rut, tipo);
        }

        public ParticipeOperacion getparticipebytipo(Int32 id_solicitud,string tipo)
        {
            return new ParticipeOperacionDAC().getparticipebytipo(id_solicitud,tipo);
        }
        public void Delparticipebytipo(int idsolicitud, string tipo, int rut)
        {
            new ParticipeOperacionDAC().Delparticipebytipo(idsolicitud,tipo,rut);
        }


    }
}
