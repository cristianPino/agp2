using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class ParametroBC
    {

        public List<Parametro> GetParametroByTipoParametro(string strTipo)
        {

            List<Parametro> lParametro = new ParametroDAC().GetParametroByTipoParametro(strTipo);


            return lParametro;
        
        
        }

        public Parametro getparametro(string tipo, string codigo)
        {
            return new ParametroDAC().getparametro(tipo.Trim(), codigo.Trim());


        }

    }
}
