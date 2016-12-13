using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
   public  class HipotecaInsertoBC
    {
       public HipotecaInserto GetInserto(int idInsertoTitulo, int idSolicitud)
       {
           return new HipotecaInsertoDAC().GetInserto(idInsertoTitulo,idSolicitud);
       }
       public List<HipotecaInserto> GetAllInserto(int idSolicitud)
       {
           return new HipotecaInsertoDAC().GetAllInserto(idSolicitud);
       }
       public void DelInserto(int idInsertoTitulo)
       {
           new HipotecaInsertoDAC().DelInserto(idInsertoTitulo);
       }

       public void AddInserto(HipotecaInserto inserto)
       {
           new HipotecaInsertoDAC().AddInserto(inserto);
       }
    }
}
