using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class PersoneroBC
    {

        public string add_personero(Int16 id_cliente, Int16 id_modulo, string rut_representante,
                                    string nombre_representante, string descripcion, string tipo,
                                    string profesion)
        {

            string add = new PersoneroDAC().add_Personero(id_cliente, id_modulo, rut_representante,
                nombre_representante, descripcion, tipo, profesion);

            return add;

        
        }


        public List<Personero> getPersonerobycliente(Int16 id_cliente)
        {

            List<Personero> lpersonero = new PersoneroDAC().getPersonerobycliente(id_cliente);

            return lpersonero;
        
        }

    }
}
