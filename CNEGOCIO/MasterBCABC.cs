using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class MasterBCABC
    {

        public string add_MasterBCA(Int32 operacion, string n_interno, Int32 id_credito)
        {
            string add = new MasterBCADAC().add_MasterBCA(operacion, n_interno, id_credito);
            return add;
        }

        public List<MasterBCA> getMAsterBCA(Int32 id_solicitud)
        {
            List<MasterBCA> lbca = new MasterBCADAC().getListMasterBCA(id_solicitud);
            return lbca;
        }

        public List<MasterBCA> getListMasterBCAall()
        {
            List<MasterBCA> lbca = new MasterBCADAC().getListMasterBCAall();
            return lbca;
        }
        

        public MasterBCA getMAsterBCAbyid(Int32 id_solicitud)
        {
            MasterBCA lbca = new MasterBCADAC().getListMasterBCAbyidhijo(id_solicitud);
            return lbca;
        }
    }
}
