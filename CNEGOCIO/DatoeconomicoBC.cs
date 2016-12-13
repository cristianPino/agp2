using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class DatoeconomicoBC
    {


        public string add_Datoeconomico(string codigo, double valor)
        {

            DatoEconomico mDatoeconomico = new DatoEconomico();

            mDatoeconomico.Codigo = codigo;
            mDatoeconomico.Valor = valor;

            string Datoeconomico = new DatoeconomicoDAC().add_Datoeconomico(mDatoeconomico);

            return Datoeconomico;

        }

        public List<DatoEconomico> GetDatoeconomico()
        {
            List<DatoEconomico> lDatoeconomico = new DatoeconomicoDAC().GetDatoeconomico();

            return lDatoeconomico;

        }


        public DatoEconomico GetDatoeconomicobycodigo(string codigo)
        {
            DatoEconomico mDatoeconomico = new DatoeconomicoDAC().GetDatoeconomicobycodigo(codigo);

            return mDatoeconomico;

        }


    }
}
