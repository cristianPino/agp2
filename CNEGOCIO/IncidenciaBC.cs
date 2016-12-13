using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using System.Data;

namespace CNEGOCIO
{
    public class IncidenciaBC
    {
       
        public DataTable GetDatosResumen(string codigoUsuario, string procedimiento)
        {
            return new IncidenciaDAC().GetDatosResumen(codigoUsuario, procedimiento);
        }
        public DataTable GetResumen(string codigoUsuario)
        {
            return new IncidenciaDAC().GetResumen(codigoUsuario);
        }
        public DataTable GetDocumentosIncidencia(int idIncidencia)
        {
            return new IncidenciaDAC().GetDocumentosIncidencia(idIncidencia);
        }

        public void AddDocumentoIncidencia(int id_incidencia, string titulo, int idEstadoActual, string url, string cuentaUsuario, string comentario)
        {
            new IncidenciaDAC().AddDocumentoIncidencia(id_incidencia, titulo, url, cuentaUsuario, comentario);
            string asunto = "Incidencia dada de baja";
            var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuario);

            string cuerpoCorreo = string.Format("Estimado cliente: Le informamos el usuario {0} subió un documento a su ticket con el titulo: {1}",
                                                usuario.Nombre.ToUpper().Trim(),
                                                titulo);

            new IncidenciaDAC().addComentarioIncidencia(id_incidencia, idEstadoActual, comentario, cuentaUsuario, asunto, cuerpoCorreo);
        }


        public DataTable GetIncidenciaFromNuevaSolicitud(int idSolicitud)
        {
            return new IncidenciaDAC().GetIncidenciaFromNuevaSolicitud(idSolicitud);
        }
        public DataTable GetComentariosByIncidencia(int idIncidencia)
        {
            return new IncidenciaDAC().GetComentariosByIncidencia(idIncidencia);
        }
        public DataTable GetIncidenciaByPatente(string patente)
        {
            return new IncidenciaDAC().GetIncidenciaByPatente(patente);
        }

        public DataTable GetIncidenciaByChasis(string chasis)
        {
            return new IncidenciaDAC().GetIncidenciaByChasis(chasis);
        }

        public DataTable GetIncidenciaByChasisORPatente(string dato, bool patente)
        {
            switch (patente)
            { 
                case true :
                    return  GetIncidenciaByPatente(dato);                   
                default:
                    return  GetIncidenciaByChasis(dato);                    
            }            
        }

        public DataTable GetIncidenciaById(int idIncidencia)
        {
            return new IncidenciaDAC().GetIncidenciaById(idIncidencia);
        }

        public DataTable GetIncidenciasUsuariosPorGrupo(bool jefe, string usuario)
        {
            return new IncidenciaDAC().GetIncidenciasUsuariosPorGrupo(jefe,usuario);
        }
        public DataTable GetIncidenciasPermisos(string usuario)
        {
            return new IncidenciaDAC().GetIncidenciasPermisos(usuario);
        }
        public DataTable GetTipoOperacionIncidencia(int idIncidencia)
        {
            return new IncidenciaDAC().GetTipoOperacionIncidencia(idIncidencia);
        }

        public DataTable GetIncidencias(string usuario, int idEstado, int idTicket, string patente, DataTable dtTickets, DataTable dtPatentes, DataTable dtChasis)
        {
            return new IncidenciaDAC().GetIncidencias(usuario, idEstado, idTicket, patente, dtTickets, dtPatentes, dtChasis);
        }
        public DataTable GetIncidenciasEstado()
        {
            return new IncidenciaDAC().GetIncidenciasEstado();
        }

        public bool DarBajaIncidencia(int idIncidencia, string cuentaUsuario, string comentario)
        {
            int estadoBaja = 10;
            int idNuevoEstado = new IncidenciaDAC().addEstadoIncidencia(idIncidencia, estadoBaja, cuentaUsuario, cuentaUsuario);
            if (idNuevoEstado != 0)
            {
                string asunto = "Incidencia dada de baja";
                var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuario);
                string cuerpoCorreo = "Estimado cliente: Le informamos que su ticket de incidencia fue dado de baja por el usuario " + usuario.Nombre.Trim().ToUpper()+" con el comentario detallado a continuación.";

                new IncidenciaDAC().addComentarioIncidencia(idIncidencia, idNuevoEstado, comentario, cuentaUsuario, asunto, cuerpoCorreo);

                return true;
            }
            else 
            {
                return false;
            }        
        }

        public bool AsignarUsuario(int idIncidencia, int idEstado, string cuentaUsuario,string cuentaUsuarioAsignado ,string comentario, string nombreSiguienteEstado)
        {
            int idNuevoEstado = new IncidenciaDAC().addEstadoIncidencia(idIncidencia, idEstado, cuentaUsuario, cuentaUsuarioAsignado);
            if (idNuevoEstado != 0)
            {
                string asunto = "Asignación de incidencia";
                var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuarioAsignado);

                string cuerpoCorreo = "Estimado cliente: Le informamos que su ticket a sido deribado al usuario " + usuario.Nombre.Trim().ToUpper() + " en el estado " + nombreSiguienteEstado.Trim().ToUpper() + " con el comentario detallado a continuación.";
                new IncidenciaDAC().addComentarioIncidencia(idIncidencia, idNuevoEstado, comentario, cuentaUsuario, asunto, cuerpoCorreo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addComentarioIncidenciaSinCorreo(int idIncidencia, int idSolicitud, int tipoCierre, bool cargoCliente)
        {
            new IncidenciaDAC().updIncidencia(idIncidencia, idSolicitud, tipoCierre, cargoCliente);
        }

        public bool CambioEstado(int idIncidencia, int idEstado, string cuentaUsuario, string cuentaUsuarioAsignado, string comentario, string nombreSiguienteEstado)
        {
            int idNuevoEstado = new IncidenciaDAC().addEstadoIncidencia(idIncidencia, idEstado, cuentaUsuario, cuentaUsuarioAsignado);
            if (idNuevoEstado != 0)
            {
                string asunto = "Cambio de estado de incidencia";
                var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuarioAsignado);

                string cuerpoCorreo = "Estimado cliente: Le informamos que su ticket a cambiado al estado " + nombreSiguienteEstado.Trim().ToUpper() + " a cargo del usuario " + usuario.Nombre.Trim().ToUpper() + " con el comentario detallado a continuación.";
                new IncidenciaDAC().addComentarioIncidencia(idIncidencia, idNuevoEstado, comentario, cuentaUsuario, asunto, cuerpoCorreo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ActualizaIncidencia(int idIncidencia, int idSolicitud,string comentario, 
                                        int tipoCierre, string tipoCierreTexto, bool cargoCliente, 
                                        string cuentaUsuario, string proximoUsuario)
        {
            new IncidenciaDAC().updIncidencia(idIncidencia, idSolicitud, tipoCierre, cargoCliente);
            var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuario);
            CambioEstado(idIncidencia, 
                                    4, 
                                    cuentaUsuario, 
                                    proximoUsuario, 
                                    comentario, 
                                    "DERIVADO POR SUPERVISOR");

            addComentarioIncidenciaSinCorreo(idIncidencia,
                                            string.Format(@"El usuario {0} ha actualizado correctamente los datos 
                                                    Id solicitud = {1}, Cargo cliente = {2}, tipoCierre={3}",
                                                                                                usuario.Nombre.Trim().ToUpper(),
                                                                                                idSolicitud,
                                                                                                cargoCliente ? "SI" : "NO",
                                                                                                tipoCierreTexto),
                                            cuentaUsuario);

        }

        public void AddComentario(int idIncidencia,int idIncidenciaEstado, string cuentaUsuario, string comentario)
        {            
            string asunto = "Nuevo Comentario Incidencia";
            var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuario);

            string cuerpoCorreo = "Estimado cliente: Le informamos que el usuario " + usuario.Nombre.Trim().ToUpper() + " agregó el siguiente comentario a su incidencia.";
            new IncidenciaDAC().addComentarioIncidencia(idIncidencia, idIncidenciaEstado, comentario, cuentaUsuario, asunto, cuerpoCorreo);              
           
        }
        public void addComentarioIncidenciaSinCorreo(int idIncidencia, string comentario, string cuentaUsuario)
        {
            new IncidenciaDAC().addComentarioIncidenciaSinCorreo(idIncidencia, comentario, cuentaUsuario); 
        }
        public DataTable GetOperacionesIncidencia(int idIncidencia)
        {
            return new IncidenciaDAC().GetOperacionesIncidencia(idIncidencia);
        }

        public int AddIncidencia(string cuentaUsuario, string tipo, string patente, string comentario,int idCliente,int idSucursal, string chasis)
        {
            int add = new IncidenciaDAC().AddIncidencia(cuentaUsuario, tipo, patente, comentario, idCliente,idSucursal,chasis);

            if (add != 0)
            {
                var jefeGrupo = new IncidenciaDAC().GetJefeGrupoInc(tipo);
                int idNuevoEstado = new IncidenciaDAC().addEstadoIncidencia(add, 1, cuentaUsuario, jefeGrupo.Rows[0]["cuenta_usuario"].ToString());
                addComentarioIncidenciaSinCorreo(add, comentario, cuentaUsuario);
            }
            return add;
        }
        public void CerrarIncidencia(string cuentaUsuario, string comentario, int idIncidenciaEstado, int idIncidencia)
        {      
                int idNuevoEstado = new IncidenciaDAC().addEstadoIncidencia(idIncidencia, 11, cuentaUsuario, cuentaUsuario);
                
                string asunto = "Informacion de Cierre de su caso de Incidencia";
                var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuario);

                string cuerpoCorreo = "Estimado cliente: Le informamos que el usuario " + usuario.Nombre.Trim().ToUpper() + " ha cerrado su incidencia con el siguiente comentario:";
                new IncidenciaDAC().addComentarioIncidencia(idIncidencia, idIncidenciaEstado, comentario, cuentaUsuario, asunto, cuerpoCorreo);                     
        }

        public void ActualizarIncidenciaANuevaOperacion(int idIncidencia, int idSolicitud, string cuentaUsuario)
        {
            new IncidenciaDAC().updIncidencia(idIncidencia, idSolicitud);

            int idNuevoEstado = new IncidenciaDAC().addEstadoIncidencia(idIncidencia, 7, cuentaUsuario, cuentaUsuario);
                        
            string asunto = "Incidencia crea nueva operación AGP";
            var usuario = new UsuarioDAC().GetusuariobyUsername(cuentaUsuario);

            string cuerpoCorreo = @"Estimado cliente: Le informamos que el usuario " + 
                                    usuario.Nombre.Trim().ToUpper() + 
                                    " creó una nueva operación derivada de su incidencia con el número "+ 
                                    idSolicitud;
            
            new IncidenciaDAC().addComentarioIncidencia(idIncidencia, 11, "Puede hacer seguimiento desde el panel de control o desde el panel de incidencias.", cuentaUsuario, asunto, cuerpoCorreo); 
           
                                           

        }

    }
}
