using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO {
	public class PreinscripcionBC {

		public string add_preinscripcion(Int32 id_solicitud, double nfactura, string npoliza, string tag, string legalizar, string tipo_tramite, string cargo_venta, string fecha_factura, double adquiriente, string codigobanco, string codigodistribuidor, double compra_para, string tipo_pago_factura, double neto_factura, string terminacion_especial, Int16 iva, Int16 sucursal_origen, Int16 sucursal_destino, double nota_venta, double rut_vendedor,string cit, string tieneImpuestoVerde)
		{
			Preinscripcion mPI = new Preinscripcion();
			mPI.N_factura = nfactura;
			mPI.N_poliza = npoliza;
			mPI.Tag = tag;
			mPI.Legalizar = legalizar;
			mPI.Tipo_tramite = tipo_tramite;
			mPI.Cargo_venta = cargo_venta;
            if (fecha_factura != "")
                mPI.Fechafactura = Convert.ToDateTime(fecha_factura);
            else
                mPI.Fechafactura = DateTime.Now;
			mPI.Adquiriente = new PersonaDAC().getpersonabyrut(adquiriente);
			mPI.Bancofinanciera = new BancofinancieraDAC().getBancofinanciera(codigobanco);
			mPI.Distribuidor_poliza = new DistribuidorpolizaDAC().getDistribuidorpoliza(codigodistribuidor);
			mPI.Compra_para = new PersonaDAC().getpersonabyrut(compra_para);
			mPI.Tipo_pago_factura = tipo_pago_factura;
			mPI.Neto_factura = neto_factura;
			mPI.Terminacion_especial = terminacion_especial;
			mPI.Iva = iva;
			mPI.Sucursal_origen = new SucursalclienteDAC().getSucursal(sucursal_origen);
			mPI.Sucursal_destino = new SucursalclienteDAC().getSucursal(sucursal_destino);
			mPI.Nota_venta = nota_venta;
			mPI.Rut_vendedor = rut_vendedor;
            mPI.Cit = cit;
		    mPI.TieneImpuestoVerde = tieneImpuestoVerde;
			string add = new PreinscripcionDAC().add_Preinscripcion(mPI, id_solicitud);
			return add;
		}


        public string ValidaOperacionExistente(Int32 id_cliente, Int32 numero_factura, string tipo_operacion,
                                                string chassis)
        {

            return new PreinscripcionDAC().ValidaOperacionExistente(id_cliente, numero_factura, tipo_operacion, chassis);    


        }
        
        public Preinscripcion Getpreinscripcionbyfactura(Int16 id_cliente, double factura) {
			Preinscripcion mpreinscripcion = new PreinscripcionDAC().Getpreinscripcionbyfactura(id_cliente, factura);
			return mpreinscripcion;
		}

		//public Preinscripcion GetpreinscripcionbyfacturayTipo(Int16 id_cliente, double factura, string tipo_operacion)
		public Preinscripcion GetpreinscripcionbyfacturayTipo(Int16 id_cliente, double rut_emisor, double factura, string tipo_operacion)
		{
			Preinscripcion mpreinscripcion = new PreinscripcionDAC().GetpreinscripcionbyfacturayTipo(id_cliente, rut_emisor, factura, tipo_operacion);
			return mpreinscripcion;
		}

		public Preinscripcion GetpreinscripcionbyIdSolicitud(Int32 id_solicitud) {
			Preinscripcion mpreinscripcion = new PreinscripcionDAC().GetpreinscripcionbyIdSolicitud(id_solicitud);
			return mpreinscripcion;
		}

		public List<Preinscripcion> getOperacionbyControl(Int16 id_cliente, Int16 id_modulo, Int16 id_sucursal, Int32 id_solicitud) {
			List<Preinscripcion> lpreinscripcion = new List<Preinscripcion>();
			lpreinscripcion = new PreinscripcionDAC().getOperacionbyControl(id_cliente, id_modulo, id_sucursal, id_solicitud);
			return lpreinscripcion;
		}
	}
}