using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class TasadorBC
    {
        public List<Tasador> getUsuarios_Tasador(Int32 id_cliente,string all)
        {
            List<Tasador> ltasador = new TasadorDAC().getUsuariosTasacion(id_cliente,all);
            return ltasador;
        }

        public string add_tasador(string cuenta_usuario, Int32 id_cliente)
        {
            string add = new TasadorDAC().add_tasador(cuenta_usuario, id_cliente);
            return add;
        }

        public string del_tasador(string cuenta_usuario, Int32 id_cliente)
        {
            string add = new TasadorDAC().del_tasador(cuenta_usuario, id_cliente);
            return add;
        }

        public Tasador tasadorbycuenta(string cuenta_usuario,Int32 id_cliente)
        {
            Tasador add = new TasadorDAC().gettasador(cuenta_usuario,id_cliente);
            return add;
        }
    }
}
