using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class MarcavehiculoBC
    {
        public List<Marcavehiculo> getallMarcavehiculo()
        {
            List<Marcavehiculo> ltipo = new MarcavehiculoDAC().getallMarcavehiculo();
            return ltipo;
        }
        public string add_Marcavehiculo(int id_marca, string nombre)
        {
            Marcavehiculo mTipo = new Marcavehiculo();
            mTipo.Id_marca = id_marca;
            mTipo.Nombre = nombre;

            string add = new MarcavehiculoDAC().add_Marcavehiculo(mTipo);
            return add;


        }

        public Marcavehiculo getmarcavehiculo(Int16 id_marca)
        {

            Marcavehiculo mmarca = new MarcavehiculoDAC().getMarcavehiculo(id_marca);
            return mmarca;
        
        }


    }
}
