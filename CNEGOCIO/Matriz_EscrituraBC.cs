using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class Matriz_EscrituraBC
    {
      
        public Matriz_Escritura getmatrizbycod(Int32 cod_matriz, Int32 id_cliente)
        {
            return new Matriz_EscrituraDAC().getMatrizbycodigo(cod_matriz,id_cliente);
        }
        public List<Matriz_Escritura> getmatriz(Int32 id_cliente, Int32 cod_notaria, string tipo_documento)
        {
            List<Matriz_Escritura> lCta_Cte = new Matriz_EscrituraDAC().getMatriz(id_cliente,cod_notaria,tipo_documento);
            return lCta_Cte;
        }
        public List<Matriz_Escritura> getmatrizescrituras(Int32 id_solicitud)
        {
            List<Matriz_Escritura> lCta_Cte = new Matriz_EscrituraDAC().getMatrizEscrituras(id_solicitud);
            return lCta_Cte;
        }
    }
}
