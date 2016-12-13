using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
using System.Data;

namespace CNEGOCIO
{
    public class InfoAutoBC
	{
        public DataTable GetPasosInfoauto()
        {
          return new InfoAutoDAC().GetPasosInfoauto();
        }

        public void ActualizarPasoInfocar(int idDicomVehiculoPaso, string estado)
        {
             new InfoAutoDAC().ActualizarPasoInfocar(idDicomVehiculoPaso, estado);
        }

        public void HabilitarContratoDv(int idSolicitud, string comentario)
        {
            new InfoAutoDAC().HabilitarContratoDv(idSolicitud, comentario);
        }

        public void SetIdSolicitudAsociado(int idSolicitudAsociado, int idSolicitud)
        {
            new InfoAutoDAC().SetIdSolicitudAsociado(idSolicitudAsociado,idSolicitud);
        }
        public DataTable GetInfocarBySolicitud(int idSolicitud)
        {
            return new InfoAutoDAC().GetInfocarBySolicitud(idSolicitud);
        }

        public DataTable ValidaExistenciaOperacion(int id_solicitud,string patente)
        {
            return new InfoAutoDAC().ValidaExistenciaOperacion(id_solicitud,patente);
        }
        public void AddMensajeAnalisis(string cuentaUsuario, string mensaje)
        {
            new InfoAutoDAC().AddMensajeAnalisis(cuentaUsuario, mensaje);
        }
        public void DesactivaMensajeAnalisis()
        {
            new InfoAutoDAC().DesactivaMensajeAnalisis();
        }

        public DataTable GetMensajeAnalisis()
        {
          return new InfoAutoDAC().GetMensajeAnalisis();
        }
        public void Up_DicomVehiculoAnalisisManual(int numeroSolicitud, string cuentaUsuario)
        {
            new InfoAutoDAC().Up_DicomVehiculoAnalisisManual(numeroSolicitud, cuentaUsuario); 
        }

        public DataTable GetdashboardCertificados(string cuentaUsuario)
        {
            return new InfoAutoDAC().GetdashboardCertificados(cuentaUsuario);
        }

        public void AddDatoGeneral(InfoAuto v)
        {
            new InfoAutoDAC().AddDatoGeneral(v);
        }

        public int CantidadCErtificados(string fechaDesde, string fechahasta, int idDocumento, int idCliente)
        {
            return new InfoAutoDAC().CantidadCErtificados(fechaDesde, fechahasta, idDocumento, idCliente);
        }

        public List<InfoAuto> GetChartTodosCertificado(string tipoOperacion, int idCliente)
        {
            return new InfoAutoDAC().GetChartTodosCertificado(tipoOperacion, idCliente);
        }


        public List<InfoAuto> GetInfoCarPublico(Int32 oc, string patente, int fecha)
        {
            return new InfoAutoDAC().GetInfoCarPublico(oc, patente, fecha);
        }

        public string ReiniciaCertificados(Int32 idSolicitud)
        {
            return new InfoAutoDAC().ReiniciaCertificados(idSolicitud);
        }

        public List<InfoAuto> Get_productoCertificadoByCliente(int idCliente)
        {
            return new InfoAutoDAC().Get_productoCertificadoByCliente(idCliente);
        }

        public List<InfoAuto> GetClienteCertificados()
        {
            return new InfoAutoDAC().GetClienteCertificados();
        }

        public List<InfoAuto> GetCertificados(string patente, int idCliente, string desde, string hasta)
        {
            return new InfoAutoDAC().GetCertificados(patente, idCliente, desde, hasta);
        }

        public List<InfoAuto> GetInfoAutoNew(string usuario,
                                           string idEstadoFamilia,
                                           string tipoOperacion,
                                           string fechaDesde,
                                           string fechaHasta,
                                           int idsucursal,
                                           DataTable dt)
        {
            return new InfoAutoDAC().GetInfoAutoNew(usuario, idEstadoFamilia, tipoOperacion, fechaDesde, fechaHasta, idsucursal, dt);
        }

        public List<InfoAuto> GetInfoAuto(Int32 idSolicitud, string patente, string usuario, int idEstadoFamilia, string tipoOperacion, string fechaDesde, string fechaHasta)
        {
            return new InfoAutoDAC().GetInfoAuto(idSolicitud, patente, usuario, idEstadoFamilia, tipoOperacion,fechaDesde,fechaHasta);
        }

        public string add_InfoAutoDetalle(string idDicomVehiculoDetalle, string idSolicitud, string parametro, string proveedor, string fechaHecho = "",
            string descripcion = "",string lugar = "", string fechaInformacion = "", string monto = "", string observacion = "",
            string nombre = "",string rut = "", string arancel = "", string tipoMoneda = "", string idMulta = "",string fechaIngresoMrnp = "")
        {
            return new InfoAutoDAC().add_InfoAutoDetalle(idDicomVehiculoDetalle, idSolicitud, parametro, proveedor, fechaHecho, descripcion,
                lugar, fechaInformacion, monto, observacion, nombre,
                rut, arancel, tipoMoneda, idMulta, fechaIngresoMrnp);
        }

        public InfoAuto getDatovehiculo(int idSolicitud)
		{
            return new InfoAutoDAC().getDatoVehiculo(idSolicitud);
		}

        public void Upt_solicitudDV(Int32 id_solicitud, string usuario)
        {
            new InfoAutoDAC().Upt_solicitudDV(id_solicitud,usuario);
        }

        public List<InfoAutoDetalle> Get_DicomVehiculoDetalle(int idSolicitud, string parametro)
        {
            return new InfoAutoDAC().Get_DicomVehiculoDetalle(idSolicitud, parametro);
        }

        public void Del_DicomVehiculoDetalle(int idDicomVehiculoDetalle)
        {
            new InfoAutoDAC().Del_DicomVehiculoDetalle(idDicomVehiculoDetalle);
        }

        public InfoAuto getexiste(string patente,Int16 id_cliente)
        {
            return new InfoAutoDAC().getexiste(patente,id_cliente);
        }

        public string add_Datosvehiculo(Int32 id_solicitud, string patente, Int32 estado_vehiculo, Int32 idSolicitudAsociada = 0)
		{
            string add = new InfoAutoDAC().add_Datosvehiculo(id_solicitud, patente, estado_vehiculo, idSolicitudAsociada);
			return add;
		}

        public void Reset_solicitudDVCancelar(int idSolicitud)
        {
            new InfoAutoDAC().Reset_solicitudDVCancelar(idSolicitud);
        }

        public void UpdateDicomVehiculoProcesos(int idSolicitud, int tipoActualizacion, int proceso)
        {
            new InfoAutoDAC().UpdateDicomVehiculoProcesos(idSolicitud,tipoActualizacion,proceso);
        }
        public int Get_ProcesoDicomVehiculoByPaso(int idSolicitud, int idPaso)
        {
            return new InfoAutoDAC().Get_ProcesoDicomVehiculoByPaso(idSolicitud, idPaso);
        }
        public bool Get_DicomVehiculoRevisados(int idSolicitud, string tipo)
        {
            return new InfoAutoDAC().Get_DicomVehiculoRevisados(idSolicitud, tipo);
        }



	}
}