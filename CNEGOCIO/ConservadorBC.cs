using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class ConservadorBC
    {

        public Conservador getconservador(Int32 id_comuna)
        {
            return new ConservadorDAC().getconservador(id_comuna);
        }
        public List<Conservador> GetAllconservador()
        {
            return new ConservadorDAC().GetAllconservador();
        }
        public string AddConservador(int idConservador, string nombre)
        {
            return new ConservadorDAC().AddConservador(idConservador, nombre);
        }
        public List<ConservadorComuna> GetConservadorComunas(int idConservador)
        {
            return new ConservadorDAC().GetConservadorComunas(idConservador);
        }
        public void Edit_JuridiccionConservador(int idConservador, int idComuna, int tipo)
        {
            new ConservadorDAC().Edit_JuridiccionConservador(idConservador,idComuna,tipo);
        }
    }
}
