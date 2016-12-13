using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class Familia_productoBC
	{

		public List<Familia_Producto> getallFamilia_producto()
		{
			return new Familia_productoDAC().getallfamilia_producto();
		}

        public List<Familia_Producto> getallFamilia_cliente(Int16 id_cliente)
        {
            return new Familia_productoDAC().getallfamilia_cliente(id_cliente);
        }

		public Familia_Producto getfamiliabycodigo(string codigo)
		{
			return new Familia_productoDAC().getFamilia(codigo);
		}

        public Familia_Producto getFamiliabyidFamilia(Int32 id_familia)
        {

            return new Familia_productoDAC().getFamiliabyidFamilia(id_familia);  
        }

		public List<Familia_Producto> getFamiliaProductoByUsuario(string cuenta_usuario)
		{
			return new Familia_productoDAC().getFamiliaProductoByUsuario(cuenta_usuario);
		}

		public List<Familia_Producto> getproductobyfamilia(Int16 id_familia)
		{
			return new Familia_productoDAC().getProductoByfamilia(id_familia);
		}

		public List<Familia_Producto> getFamilia_by_cliente_usuario(Int16 id_cliente, string cuenta_usuario)
		{
			return new Familia_productoDAC().getFamilia_by_cliente_usuario(id_cliente, cuenta_usuario);
		}
	}
}