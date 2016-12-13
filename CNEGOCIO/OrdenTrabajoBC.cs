using System;
using System.Collections.Generic;
using System.Data;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class OrdenTrabajoBC
    {
        public DataTable GetPermisosEspeciales(string cuentaUsuario)
        {
           return new OrdenTrabajoDAC().GetPermisosEspeciales(cuentaUsuario);
        }

        public void AddGrupoUsuario(string cuentaUsuario, int idGrupo, bool jefe, bool observador, bool activo)
        {
            new OrdenTrabajoDAC().AddGrupoUsuario(cuentaUsuario, idGrupo, jefe, observador, activo);
        }
        public void AddBusquedaUsuario(string cuentaUsuario, int idBusqueda, bool permisoEliminar, bool permisoAsignar, bool permisoGarantia, bool permisoPrimera)
        {
            new OrdenTrabajoDAC().AddBusquedaUsuario(cuentaUsuario, idBusqueda, permisoEliminar, permisoAsignar, permisoGarantia, permisoPrimera);
        }

        public void DelActividadUsuario(string cuentaUsuario, int idActividad)
        {
            new OrdenTrabajoDAC().DelActividadUsuario(cuentaUsuario, idActividad);
        }

        public void GuardarActividadUsuario(string cuentaUsuario, int idActividad, bool soloLectura)
        {
            new OrdenTrabajoDAC().GuardarActividadUsuario(cuentaUsuario, idActividad,soloLectura);
        }
        public void GuardarPorUsuario(string cuentaUsuario, string usuarioCopia)
        {
            new OrdenTrabajoDAC().GuardarPorUsuario(cuentaUsuario, usuarioCopia);
        }

        public void GuardarPorPerfil(string cuentaUsuario, string perfil)
        {
            new OrdenTrabajoDAC().GuardarPorPerfil(cuentaUsuario, perfil);
        }

        public DataTable GetGruposUsuario(string cuentaUsuario)
        {
            return new OrdenTrabajoDAC().GetGruposUsuario(cuentaUsuario);
        }
        public DataTable GetActividadesUsuario(string cuentaUsuario)
        {
            return new OrdenTrabajoDAC().GetActividadesUsuario(cuentaUsuario);
        }
        public DataTable GetUsuariosBySucursal(int idSucursal)
        {
            return new OrdenTrabajoDAC().GetUsuariosBySucursal(idSucursal);
        }
        public DataTable GetUsuariosByGrupos(string grupo)
        {
            return new OrdenTrabajoDAC().GetUsuariosByGrupos(grupo);
        }
        public DataTable ValidaGarantias(int rut, string patente)
        {
            return new OrdenTrabajoDAC().ValidaGarantias(rut, patente);
        }
        public DataTable GetUsuariosGrupos(bool jefe, bool todos, string grupo, string cuentaUsurario)
        {
            return new OrdenTrabajoDAC().GetUsuariosGrupos(jefe, todos, grupo, cuentaUsurario);
        }
        public DataTable GetGrupoByUsuario(string cuentaUsuario)
        {
            return new OrdenTrabajoDAC().GetGrupoByUsuario(cuentaUsuario);
        }
        public RespuestaAgp AddOrdenTrabajoWebservice(DatoFactura ot)
        {
            return new OrdenTrabajoDAC().AddOrdenTrabajoWebservice(ot);
        }
        public RespuestaAgp AddOrdenTrabajoPorche(DatoFactura ot)
        {
            return new OrdenTrabajoDAC().AddOrdenTrabajoPorche(ot);
        }

        public RespuestaAgp AddOrdenTrabajoBech(DatoFactura ot)
        {
            return new OrdenTrabajoDAC().AddOrdenTrabajoBech(ot);
        }

        public string GetCodigoSga(string descripcion, string tipo)
        {
            return new OrdenTrabajoDAC().GetCodigoSga(descripcion,tipo);
        }
        public DataTable PermisosOrdenTrabajo(string cuentaUsuario)
        {
            return new OrdenTrabajoDAC().PermisosOrdenTrabajo(cuentaUsuario);
        }

        public int AddOrdenTrabajoGarantia(OrdenTrabajo ot)
        {
            return new OrdenTrabajoDAC().AddOrdenTrabajoGarantia(ot);
        }
        public void DelServicio(int idOt)
        {
            new OrdenTrabajoDAC().DelServicio(idOt);
        }

        public int AddOrdenTrabajo(OrdenTrabajo ot)
        {
            return new OrdenTrabajoDAC().AddOrdenTrabajo(ot);
        }
        public void AddServicio(int idOt, string servicio)
        {
            new OrdenTrabajoDAC().AddServicio(idOt, servicio);
        }
        public void AddDocumento(int idOt, int doc)
        {
            new OrdenTrabajoDAC().AddDocumento(idOt, doc);
        }

        public OrdenTrabajo GetOrdenTrabajo(int idOt)
        {
            return new OrdenTrabajoDAC().GetOrdenTrabajo(idOt);
        }
        public ModeloVehiculo ValidaCit(string cit)
        {
            return new OrdenTrabajoDAC().ValidaCit(cit);
        }

        public RespuestaAgp AddOrdenTrabajoWebservice(OrdenTrabajo ot)
        {
            //metodo usado desde webserviceAG
              //inserta OrdenTrabajo
                var respuesta = new OrdenTrabajoDAC().AddOrdenTrabajoWebservice(ot);
                
                if (respuesta.IdRespuesta == -1|| respuesta.IdRespuesta ==-2 || respuesta.IdRespuesta == -3)
                {
                    return respuesta;
                }
                //var siguienteActividad = 1;
                var lista = new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 2 } },"1");//1 = grupo primera
                var siguienteUsuario = "";
                foreach (var usu in lista)
                {
                    siguienteUsuario = usu.Usuario.UserName;
                }
                //var logExiste =
                //    new OrdenTrabajoActividadLogBC().GetLastOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog { OrdenTrabajo = new OrdenTrabajo { IdOrden = Convert.ToInt32(id) } });

                //if (logExiste.IdOrdenTrabajoActividadLog != 0)
                //{
                //    siguienteActividad = siguienteActividad + 1;
                //}
                //else
                //{
                //    siguienteUsuario = "wsag";
                //}

                new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                {
                    OrdenTrabajo = new OrdenTrabajo
                    {
                        CuentaUsuario = siguienteUsuario
                        ,
                        IdOrden = Convert.ToInt32(respuesta.IdRespuesta)
                    },
                    ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 2 },//en espera de asignacion
                    Avanza = 1,
                    IdOrdenTrabajoActividadLog = 0
                });

                return respuesta;
            } 

        public bool PuedeAsignarOrdenTrabajo(string cuentaUsuario)
        {
            return new OrdenTrabajoDAC().PuedeAsignarOrdenTrabajo(cuentaUsuario);
        }
        public List<OrdenTrabajoTipoOperacion> GetordenTrabajoProducto(int idOt)
        {
            return new OrdenTrabajoDAC().GetordenTrabajoProducto(idOt);
        }
        public void UpdateProductoOrdenTrabajo(int idOt, string producto, int idSolicitud)
        {
            new OrdenTrabajoDAC().UpdateProductoOrdenTrabajo(idOt, producto, idSolicitud);
        }

        public DataTable GetReparos(int idOrdenTrabajo, string filas)
        {
           return new OrdenTrabajoDAC().GetReparos(idOrdenTrabajo, filas);
        }
         public void AddReparo(int idReparo, int idOrdenTrabajo, int idTipoReparo, string parametroResponsableReparo, string usuarioIngresoReparo,
           string usuarioResponsableReparo, string observacion, byte estado)
         {
             new OrdenTrabajoDAC().AddReparo(idReparo, idOrdenTrabajo, idTipoReparo, parametroResponsableReparo, usuarioIngresoReparo, usuarioResponsableReparo, observacion, estado);
         }

         public DataTable GetReparosById(int idReparo)
         {
             return new OrdenTrabajoDAC().GetReparosById(idReparo);
         }


    }
}
