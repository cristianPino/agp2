using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class ParametrotipoBC
    {

        public List<Parametrotipo> getallparametrotipo(string strcodigotipoparametro)
        {
            List<Parametrotipo> lParametrotipo = new ParametrotipoDAC().getallparametrotipo(strcodigotipoparametro);
            return lParametrotipo;

        }

        public string add_parametrotipo(string codigotipoparametro, string descripcion)
        {

            Parametrotipo mparametrotipo = new Parametrotipo();

            mparametrotipo.Codigotipoparametro = codigotipoparametro;
            mparametrotipo.Descripcion = descripcion;

            string parametrotipo = new ParametrotipoDAC().add_parametrotipo(mparametrotipo);



            return parametrotipo;

        }


    }
}

