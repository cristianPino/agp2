using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;
namespace CNEGOCIO
{
    public class FoliadorBC
    {
        public int getfolio ()
        {
            return new FoliadorDAC().getfolio();
        }

		
    }
}
