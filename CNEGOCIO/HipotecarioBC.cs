using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class HipotecarioBC
    {

        public DataTable GetIdSolicitud(int rutComprador)
        {
            return new HipotecarioDAC().GetIdSolicitud(rutComprador);
        }

        public Hipotecario ValidarOperacion(int idSolicitud, string numeroBanco, int rut, int idCliente)
        {
            return new HipotecarioDAC().ValidarOperacion(idSolicitud, numeroBanco, rut, idCliente);
        }
        public bool ValidaExisteOperacion(string tipoOperacion, string numeroBanco, int idCliente)
        {
            return new HipotecarioDAC().ValidaExisteOperacion(tipoOperacion, numeroBanco, idCliente);
        }

        public int GetNominaByNombre(int idFamilia, string nombreNomina)
        {
            return new HipotecarioDAC().GetNominaByNombre(idFamilia, nombreNomina);
        }

        public List<Hipotecario> GetEstructuraExcel()
        {
            return new HipotecarioDAC().GetEstructuraExcel();
        }

        public List<Hipotecario> GetOperacionesHipotecario(string tipoOperacion, string semaforo, string cuentaUsuario, string rutComprador, string numeroCliente, int idCliente, string codigoEstado,
            int idSolicitud, int numeroFactura, DataTable data, DataTable dtrut, DataTable dtIdSolicitud, DataTable dtfactura)  
        {
            return new HipotecarioDAC().GetOperacionesHipotecario(tipoOperacion,semaforo, cuentaUsuario, rutComprador, numeroCliente, idCliente, codigoEstado, idSolicitud, numeroFactura, data, dtrut, dtIdSolicitud, dtfactura);
        }

        public int ValidaGestoria(string numeroCliente, int idCliente)
        {
            return new HipotecarioDAC().ValidaGestoria(numeroCliente, idCliente);
        }

        public Hipotecario GetDatoOperaciones(string numeroCliente, int idCliente)
        {
            return new HipotecarioDAC().GetDatoOperaciones(numeroCliente,idCliente);
        }

        public List<Hipotecario> GetUsuarioDashboard(string cuentaUsuario)
        {
            return new HipotecarioDAC().GetUsuarioDashboard(cuentaUsuario);
        }

        public List<Persona> GetBeneficiariosSubsidio(Int32 idSolicitud)
        {
            return new HipotecarioDAC().GetBeneficiariosSubsidio(idSolicitud);
        }

        public Hipoteca_FormaPago GetFormaPago(Int32 idSolicitud)
        {
            return new HipotecarioDAC().get_forma_pago(idSolicitud); 
        }

        public List<Hipoteca_Prohibicion> getProhibicion(Int32 id_solicitud)
        {
            return new HipotecarioDAC().get_Prohibicion(id_solicitud);

        }

        public Int32 add_prohibicion(Int32 id_solicitud, string fojas, string numero, Int32 ano, string descripcion, string comuna, string tipo,Int32 id_prohibicion, string aFavorDe,string comentario, string letra)
        {

            Int32 add = new HipotecarioDAC().add_prohibicion(id_solicitud, fojas, numero, ano, descripcion, comuna, tipo, id_prohibicion, aFavorDe,comentario, letra);

            return add;

        }

        public string del_prohibicion(int idProhibicion)
        {
            string add = new HipotecarioDAC().del_prohibicion(idProhibicion);
            return add;

        }


        public string add_forma_pago(Hipoteca_FormaPago forma)
        {  
            return  new HipotecarioDAC().add_forma_pago(forma);
        }

        public string del_forma_pago(Int32 id_solicitud)
        {

            string add = new HipotecarioDAC().del_forma_pago(id_solicitud);
            return add;

        }

        public HipotecaSubsidio GetSubsidio(Int32 idSolicitud)
        {
            return new HipotecarioDAC().GetSubsidio(idSolicitud);
        }

        public string add_escritura_pendiente_hipoteca(Int32 id_solicitud)
        {
            return new HipotecarioDAC().add_escritura_pendiente_hipoteca(id_solicitud);
        }

        public int AddSubsidio(HipotecaSubsidio hipo)
        {
          return  new HipotecarioDAC().AddSubsidio(hipo);
        }

        public string add_hipotecario(Int32 idSolicitud, Int32 rutAcreedor,
                                        string tipoPropiedad, Int32 precioVivienda,
                                        Int32 montoCredito, string fechaVencimiento,
                                        Int32 plazoAnos, Int16 sucursal, string numeroInterno, Int16 idComuna, string direccion,
                                        string numero, string complemento, string tipoCredito, Int32 tasacion, string ejecutivo,
                                        string finalCaratula, string finalConservador,
                                        Int32 mesesGracia, Int32 valorComercial,
                                        string descripcionDeslinde, string pie,
                                        string mesCarenciaUno, string mesCarenciaDos, byte codeudorConSeguro, string porcentajeSeguroCodeudor,
                                        byte dfl2, string tipoUbicacion, string subProductoTipoCredito,
                                        string numeroCredito, string tasa, byte viviendaSocial, string tipoTransferencia, string tipoHipoteca, string fechaMemo, byte segInvalidez, byte segCesantia)
        {
            return  new HipotecarioDAC().add_hipotecario(idSolicitud, rutAcreedor,
                                         tipoPropiedad,
                                         precioVivienda,
                                          montoCredito,
                                          fechaVencimiento,
                                         plazoAnos,
                                         sucursal, numeroInterno, idComuna, direccion,
                                         numero, complemento, tipoCredito, tasacion, ejecutivo,
                                         finalCaratula, finalConservador,
                                         mesesGracia, valorComercial,
                                         descripcionDeslinde, pie, mesCarenciaUno, mesCarenciaDos, codeudorConSeguro, porcentajeSeguroCodeudor, dfl2, tipoUbicacion, subProductoTipoCredito,
                                         numeroCredito, tasa, viviendaSocial,tipoTransferencia,tipoHipoteca,fechaMemo,segInvalidez,segCesantia);
            
        }

        public Hipotecario gethipotecario(Int32 id_solicitud)
        {
            return new HipotecarioDAC().getHipotecario(id_solicitud);
        }


        public List<Hipotecario> getOperaciones(string tipo_operacion,
                                              Int16 id_modulo,
                                              Int16 id_sucursal,
                                              Int16 id_cliente,
                                              Int32 numero_operacion,
                                              double rut_adquiriente,
                                              Int32 numero_factura,
                                              string numero_cliente,
                                              string patente,
                                              string desde,
                                              string hasta,
                                              Int32 ultimo_estado,
                                              string cuenta_usuario,
                                              Int32 id_familia,
                                              string estado_proceso,
          string rol, string nombre_deudor)
        {

            List<Hipotecario> loperacion = new HipotecarioDAC().getOperaciones(tipo_operacion,
                                               id_modulo,
                                               id_sucursal,
                                               id_cliente,
                                               numero_operacion,
                                               rut_adquiriente,
                                               numero_factura,
                                               numero_cliente,
                                               patente,
                                               desde,
                                               hasta,
                                               ultimo_estado,
                                               cuenta_usuario,
                                               id_familia,
                                               estado_proceso,
                                                rol,
                                                nombre_deudor);

            return loperacion;

        }

        public List<Hipotecario> GetAllOperaciones(Hipotecario h, int busqueda)
        {
            return busqueda == 0 ? new HipotecarioDAC().GetAllOperacionesSinSeleccionar(h) : new HipotecarioDAC().GetAllOperacionesSeleccionadas(h);
        }

    }
}
