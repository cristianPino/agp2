using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class ModuloclienteBC
    {

        public string add_modulo(int id_cliente, string nombre)
        {

            string add = new ModuloclienteDAC().add_Modulocliente(id_cliente, nombre);
                return add;
        
        }

        public List<ModuloCliente> getmoduloclientebycliente(int id_cliente)

    {
        
        List<ModuloCliente> lmodulo = new ModuloclienteDAC().getModuloclientebycliente(id_cliente);

        return lmodulo;

    }

        public List<ModuloCliente> getmoduloclientebyusuario(string usuario, Int16 id_cliente)
        {

            List<ModuloCliente> lmodulo = new ModuloclienteDAC().getModuloclientebyusuario(usuario, id_cliente);

            return lmodulo;

        }

        public List<ModuloCliente> getUsuariomodulo(string usuario)
        {

            List<ModuloCliente> lmodulo = new ModuloclienteDAC().getUsuariomodulo(usuario);

            return lmodulo;

        }


    }
}
