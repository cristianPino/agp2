using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class CiudadBC
    {


        public string add_ciudad(Int16 id_region, string nombre)
        {

            Ciudad mciudad = new Ciudad();

            mciudad.Nombre = nombre;
            mciudad.Region = new RegionDAC().getregion(id_region);

            string ciudad = new CiudadDAC().add_Ciudad(mciudad);



            return ciudad;

        }



        public List<Ciudad> getCiudadbyregion(Int16 id_region)
        {

            List<Ciudad> lCiudad = new CiudadDAC().getciudadbyregion(id_region);

            return lCiudad;

        }
        public Ciudad getciudad(Int16 id_ciudad)
        {
            return new CiudadDAC().getciudad(id_ciudad);
        }

    }
}
