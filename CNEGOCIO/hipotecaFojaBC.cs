using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class hipotecaFojaBC
    {
        public void AddFojas(hipotecaFoja h)
        {
            new hipotecaFojaDAC().AddFojas(h);
        }
        public void del_Fojas(hipotecaFoja h)
        {
            new hipotecaFojaDAC().del_Fojas(h);
        }
        public List<hipotecaFoja> GetFojas(hipotecaFoja h)
        {
            return new hipotecaFojaDAC().GetFojas(h);
        }
    }
}
