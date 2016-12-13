using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class HipotecaInsertoTituloBC
    {
        public HipotecaInsertoTitulo GetInsertoTitulo(int idInsertoTitulo)
        {
            return new HipotecaInsertoTituloDAC().GetInsertoTitulo(idInsertoTitulo);
        }

        public List<HipotecaInsertoTitulo> GetAllInsertoTitulo()
        {
            return new HipotecaInsertoTituloDAC().GetAllInsertoTitulo();
        }
    }
}
