using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class GrupoBC
    {
        public Grupo Getgrupo(Int32 id_grupo)
        {
            Grupo mgrupo = new GrupoDAC().getGrupo(id_grupo);
            return mgrupo;
        }

        public Grupo getEstadobycodigo(Int32 codigo_estado)
        {
            Grupo mgrupo = new GrupoDAC().getEstadobycodigo(codigo_estado);
            return mgrupo;
        }


        public string add_Grupo(Int32 id_grupo,string descripcion)
        {
            string add = new GrupoDAC().addgrupo(id_grupo, descripcion);

            return add;
        }

        public string add_Estadogrupo(Int32 id_grupo, Int32 codigo_estado)
        {
            string add = new GrupoDAC().addEstadogrupo(id_grupo, codigo_estado);

            return add;
        }

        public List<Grupo> getallgrupo()
        {
            List<Grupo> lgrupo = new GrupoDAC().getallGrupo();

            return lgrupo;
        }

        public string delete_GrupoEstado(Int32 codigo_estado)
        {
            string add = new GrupoDAC().deleteEstadogrupo(codigo_estado);

            return add;
        }
       
    }



        
}
