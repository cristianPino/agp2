using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;
namespace CNEGOCIO
{
    public class GarantiaBC
    {
		public string add_Garantia(Int32 id_solicitud, double Adquiriente, short cliente, double compra_para, string creada, double compra_repre, double repertorio, double n_factura, string fecha_factura, short id_sucursal,
            double emisor, double monto, double n_cuotas, string fecha_primera, string fecha_ultima, string cta_corriente, string banco, string titular, string notario, string ciudad, string fecha_contrato, double n_cheques,
            double neto_factura, string tipo_pago_factura, double factura_intereses, string fecha_factura_intereses, double monto_factura_intereses, string fecha_protocolizacion, string n_protocolizacion, string n_RepertorioNotaria,
            string n_RepertorioRNP, string fecha_repertorio, string oficina_Registro, string ing_alza_PN_registro, string ing_alza_PH_registro, string n_solicitud_PN_registro, string n_solicitud_PH_registro, string nombreEstado,
			string fechaUltimoEstado, double valor_vehiculo, double monto_pie, double factura_gastos, string fecha_factura_gastos, double monto_factura_gastos, double nro_credito, string doc_fundante, string solicitante,
			string notaria_protocolizacion, string ciudad_notaria_protocolizacion, string fecha_repertorio_rnp, string estado_solicitud_rnp, string estado_prenda, string observaciones, bool cav_comprado, string nro_declaracion,
            string fecha_pagare,int valor_cuotas,int capital_pagare,string tasa, int dia)
        {
            Garantia mGA = new Garantia();
			mGA.Adquiriente = new PersonaDAC().getpersonabyrut(Adquiriente);
			mGA.Bancofinanciera = banco;
			mGA.Ciudad_notario = ciudad;
			mGA.Cliente = new ClienteDAC().Getcliente(cliente);
			mGA.Compra_para = new PersonaDAC().getpersonabyrut(compra_para);
			mGA.Compra_repre = new PersonaDAC().getpersonabyrut(compra_repre);
			mGA.Creada = creada;
			mGA.Cta_corriente = cta_corriente;
			mGA.Datos_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(id_solicitud);
			mGA.Emisor = new PersonaDAC().getpersonabyrut(emisor);
			mGA.Fecha_contrato = fecha_contrato;
			mGA.Fecha_primera = fecha_primera;
			mGA.Fecha_ultima = fecha_ultima;
			mGA.Fechafactura = fecha_factura;
            mGA.Monto = monto;
			mGA.N_cheques = n_cheques;
			mGA.N_cuotas = n_cuotas;
			mGA.N_factura = n_factura;
			mGA.Neto = neto_factura;
			mGA.Notario = notario;
			mGA.Operacion = new OperacionDAC().getOperacion(id_solicitud);
			mGA.Repertorio = repertorio;
			mGA.Sucursal_origen = new SucursalclienteDAC().getSucursal(id_sucursal);
			mGA.Titular = titular;
			mGA.Tipo_pago_factura = tipo_pago_factura;
			mGA.Factura_intereses = factura_intereses;
			mGA.Fecha_factura_intereses = fecha_factura_intereses;
			mGA.Monto_factura_intereses = monto_factura_intereses;
            mGA.Fecha_protocolizacion = fecha_protocolizacion;
            mGA.N_protocolizacion = n_protocolizacion;
            mGA.N_RepertorioNotaria = n_RepertorioNotaria;
            mGA.N_RepertorioRNP = n_RepertorioRNP;
            mGA.Fecha_repertorio = fecha_repertorio;
            mGA.Oficina_Registro = oficina_Registro;
            mGA.Ing_alza_PN_registro = ing_alza_PN_registro;
            mGA.Ing_alza_PH_registro = ing_alza_PH_registro;
            mGA.N_solicitud_PN_registro = n_solicitud_PN_registro;
            mGA.N_solicitud_PH_registro = n_solicitud_PH_registro;
            mGA.NombreEstado = nombreEstado;
            mGA.FechaUltimoEstado = fechaUltimoEstado;
			mGA.Valor_vehiculo = valor_vehiculo;
			mGA.Monto_pie = monto_pie;
			mGA.Factura_gastos = factura_gastos;
			mGA.Fecha_factura_gastos = fecha_factura_gastos;
			mGA.Monto_factura_gastos = monto_factura_gastos;
			mGA.Nro_credito = nro_credito;
			mGA.Doc_fundante = doc_fundante;
			mGA.Solicitante = solicitante;
			mGA.Notaria_protocolizacion = notaria_protocolizacion;
			mGA.Ciudad_notaria_protocolizacion = ciudad_notaria_protocolizacion;
			mGA.Fecha_repertorio_rnp = fecha_repertorio_rnp;
			mGA.Estado_solicitud_rnp = estado_solicitud_rnp;
			mGA.Estado_prenda = estado_prenda;
            mGA.Observaciones = observaciones;
			mGA.Cav_comprado = cav_comprado;
			mGA.Nro_declaracion = nro_declaracion;
            mGA.Dia = dia;
            mGA.Tasa = tasa;
            mGA.Fecha_pagare = fecha_pagare;
            mGA.Valor_Cuotas = valor_cuotas;
            mGA.Capital_pagare = capital_pagare;

			string add = new GarantiaDAC().add_garantia(mGA);
            return add;
        }

		public Garantia GetgarantiabyIdSolicitud(Int32 id_solicitud)
		{
			return new GarantiaDAC().GetgarantiabyIdSolicitud(id_solicitud);
		}

		public Garantia Getgarantiabyfactura(Int16 id_cliente, double rut_emisor, double factura)
		{
			return new GarantiaDAC().Getgarantiabyfactura(id_cliente, rut_emisor, factura);
		}

		public string AddAsociarGarantiaAlzamiento()
		{
			return "";
		}

		public List<Garantia> GetGarantiasAlzamiento(int id_cliente, int id_sucursal, int id_solicitud, string desde, string hasta, double rut, string patente)
		{
			return new GarantiaDAC().GetGarantiasAlzamiento(id_cliente, id_sucursal, id_solicitud, desde, hasta, rut, patente);
		}
    }
}