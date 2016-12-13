using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class EjecutivosucursalBC
    {

       

        public List<Ejecutivosucursal> getEjecutivoclientebycliente(int id_cliente,int id_sucursal)

    {

		List<Ejecutivosucursal> lmodulo = new EjecutivosucursalDAC().getEjecutivoclientebycliente(id_cliente, id_sucursal);

        return lmodulo;

    }

		public string add_EjecutivoSucursal( Int16 id_cliente, Int16 id_sucursal, string nombre, string correo,
            Int16 id_cliente_financiera)
		{
            string add = new EjecutivosucursalDAC().add_Ejecutivocliente(id_cliente, id_sucursal, nombre, correo, id_cliente_financiera);
			return add;
		}

		public string del_EjecutivoSucursal(Int16 id_cliente_sucursal)
		{
			string add = new EjecutivosucursalDAC().del_Ejecutivocliente(id_cliente_sucursal);
			return add;
		}
        

    }
}
