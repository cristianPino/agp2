using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class PaisBC
    {

        public List<Pais> getallpais(string strcodigo)
        {
            List<Pais> lPais = new PaisDAC().getallpais(strcodigo);
            return lPais;

        }

        public string  add_pais(string codigo, string nombre)
        {

            Pais mpais = new Pais();

            mpais.Codigo = codigo;
            mpais.Nombre = nombre;

            string pais = new PaisDAC().add_pais(mpais);



            return pais;
        
        }


    }
}
