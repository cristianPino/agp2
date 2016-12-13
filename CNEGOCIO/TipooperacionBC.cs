using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class TipooperacionBC
    {

        public List<TipoOperacion> GetProductosByFamiliaClienteUsuario(Int16 idCliente, string cuentaUsuario, Int32 idFamilia)
        {
            return new TipooperacionDAC().GetProductosByFamiliaClienteUsuario(idCliente, cuentaUsuario, idFamilia);
        }

        public List<TipoOperacion> getallTipooperacion()
        {

            List<TipoOperacion> ltipooperacion = new TipooperacionDAC().getallTipooperacion();
            return ltipooperacion;
        
        }

        public TipoOperacion getTipooperacion(string codigo)
        {

            TipoOperacion mTipooperacion = new TipooperacionDAC().getTipooperacion(codigo);
            return mTipooperacion;

        }


        public List<TipoOperacion> getTipo_OperacionByCliente(Int16 id_cliente,string all)
        {

            List<TipoOperacion> ltipooperacion = new TipooperacionDAC().getTipo_OperacionByCliente(id_cliente,all);
            return ltipooperacion;

        }
		public List<TipoOperacion> getTipo_OperacionByClienteandfamilia(Int16 id_cliente, string all,Int16 id_familia)
		{

			List<TipoOperacion> ltipooperacion = new TipooperacionDAC().getTipo_OperacionByClienteandfamilia(id_cliente, all,id_familia);
			return ltipooperacion;

		}


        public List<TipoOperacion> getTipo_OperacionByUsuario(Int16 id_cliente,string cuenta_usuario, string all)
        {

            List<TipoOperacion> ltipooperacion = new TipooperacionDAC().getTipo_OperacionByUsuario(id_cliente,cuenta_usuario, all);
            return ltipooperacion;

        }
        public List<TipoOperacion> getTipo_OperacionByUsuarioandfamilia(Int16 id_cliente, string cuenta_usuario, string all,Int32 id_familia, string ingresa)
        {

            List<TipoOperacion> ltipooperacion = new TipooperacionDAC().getTipo_OperacionByUsuarioandfamilia(id_cliente, cuenta_usuario, all,id_familia, ingresa);
            return ltipooperacion;

        }


        public string add_Tipooperacion(string codigo, string operacion, string imagen, string url_operacion,string tamano)
        {
            

            string add = new TipooperacionDAC().add_Tipooperacion(codigo,operacion,imagen,url_operacion,tamano);
            return add;


        }
        public string act_Tipooperacion(string codigo, string tamano, string operacion)
        {


            string add = new TipooperacionDAC().act_Tipooperacion(codigo,  tamano, operacion);
            return add;


        }
        public string add_tipo_operacion_cliente(string codigo, Int16 id_cliente)
        {


            string add = new TipooperacionDAC().add_tipo_operacion_cliente(codigo, id_cliente);
            return add;


        }
        public string add_usuario_tipo_operacion(string cuenta_usuario, string codigo, Int16 id_cliente,string check_ingresa)
        {


            string add = new TipooperacionDAC().add_usuario_tipo_operacion(cuenta_usuario, codigo, id_cliente, check_ingresa);
            return add;


        }
        public string del_tipo_operacion_cliente(string codigo, Int16 id_cliente)
        {


            string add = new TipooperacionDAC().del_tipo_operacion_cliente(codigo, id_cliente);
            return add;


        }
        public string del_tipo_operacion_usuario(string cuenta_usuario, string codigo, Int16 id_cliente)
        {


            string add = new TipooperacionDAC().del_tipo_operacion_usuario(cuenta_usuario, codigo, id_cliente);
            return add;


        }

        public TipoOperacion getcomprobantebyoperacion(Int32 id_solicitud)
        {

            TipoOperacion mTipooperacion = new TipooperacionDAC().getcomprobantebyoperacion(id_solicitud);
            return mTipooperacion;

        }

        public TipoOperacion getcomprobantegastos(Int32 id_solicitud)
        {

            TipoOperacion mTipooperacion = new TipooperacionDAC().getcomprobantegastos(id_solicitud);
            return mTipooperacion;

        }
    
    }
}
