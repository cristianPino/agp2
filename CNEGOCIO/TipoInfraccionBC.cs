using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class TipoInfraccionBC
    {
        public List<TipoInfraccion> getallTipoInfraccion()
        {
            List<TipoInfraccion> lTipoInfraccion = new TipoInfraccionDAC().getallInfraccion();
            return lTipoInfraccion;

        }

        public string add_tipoInfraccion(string codigo, string descripcion)
        {

            TipoInfraccion mInfraccion = new TipoInfraccion();

            mInfraccion.Codigo = codigo;
            mInfraccion.Descripcion= descripcion;
            

            string tipoinfraccion = new TipoInfraccionDAC().add_TipoInfraccion(codigo, descripcion);



            return tipoinfraccion;

        }


    }
}
