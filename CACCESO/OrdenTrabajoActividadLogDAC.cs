using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class OrdenTrabajoActividadLogDAC : BaseDAC
    {
        public void AddOrdenTrabajoLog(OrdenTrabajoActividadLog ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_add_actividad_orden_trabajo" };
                cmd.Parameters.AddWithValue("@id_usuario", ot.OrdenTrabajo.CuentaUsuario);
                cmd.Parameters.AddWithValue("@id_actividad", ot.ActividadDeOrdenTrabajo.IdActividad);
                cmd.Parameters.AddWithValue("@id_orden_trabajo", ot.OrdenTrabajo.IdOrden);
                cmd.Parameters.AddWithValue("@avanza", ot.Avanza);
                cmd.Parameters.AddWithValue("@id_ota_origen", ot.IdOrdenTrabajoActividadLog);


                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public List<OrdenTrabajoActividadLog> GetOrdenTrabajoLogbyUsuario(OrdenTrabajoActividadLog ot, string desde, string hasta, string usuarioBusqueda,
            string grupo, int idCliente)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_by_usuario" };
                cmd.Parameters.AddWithValue("@cuentaUsuario", ot.Usuario.UserName);
                //cmd.Parameters.AddWithValue("@numeroOt", ot.OrdenTrabajo.NumeroOrden);
                cmd.Parameters.AddWithValue("@factura", ot.OrdenTrabajo.NumeroOrden);
                cmd.Parameters.AddWithValue("@id_actividad", ot.ActividadDeOrdenTrabajo.IdActividad);
                cmd.Parameters.AddWithValue("@fecha_desde", desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", hasta);
                cmd.Parameters.AddWithValue("@usuario_consulta", usuarioBusqueda);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@grupo", grupo);
                var reader = cmd.ExecuteReader();

                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog
                    {
                        IdOrdenTrabajoActividadLog = Convert.ToInt32(reader["id_orden_trabajo_actividad"]),
                        FechaInicio = reader["fecha_inicio"].ToString(),
                        UsuarioActualCuenta = reader["u_actual_cuenta"].ToString(),
                        UsuarioActualNombre = reader["u_actual_nombre"].ToString(),
                        ActividadDeOrdenTrabajo =
                                new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo
                                { IdActividad = Convert.ToInt32(reader["id_actividad"]) }),
                        OrdenTrabajo = new OrdenTrabajo
                        {
                            IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]),
                            NumeroOrden = reader["num_orden_trabajo"].ToString(),
                            UsuarioIngresoNombre = reader["u_ingreso_nombre"].ToString(),
                            UsuarioIngresoCuenta = reader["u_ingreso_cuenta"].ToString(),
                            NumeroFactura = reader["num_factura"].ToString(),
                            FechaIngreso = reader["fecha_ingreso"].ToString(),
                            VinCorto = reader["vin_corto"].ToString(),
                            IdCliente = Convert.ToInt16(reader["id_cliente"]),
                            ClienteNombre = reader["cliente"].ToString(),
                            //SucursalNombre = reader["sucursal_nombre"].ToString(),
                            IdSucursal = Convert.ToInt16(reader["id_sucursal"]),
                            IdSolicitud = Convert.ToInt32(reader["id_solicitud"]),
                            FormaPago = Convert.ToString(reader["forma_pago"]),
                            VehiculoChasis = Convert.ToString(reader["chasis"]),
                            Patente = Convert.ToString(reader["vehiculo_patente"]),
                            Usuario_cliente = Convert.ToString(reader["ejecutivo_cliente"])

                        },
                        HorasActividad = Convert.ToInt32(reader["horas"])
                    };

                    lista.Add(otr);
                }
                sqlConn.Close();
                return lista;
            }
        }
        public List<OrdenTrabajoActividadLog> GetOrdenTrabajoLogbyUsuarioGrafico(OrdenTrabajoActividadLog ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_by_usuario" };
                cmd.Parameters.AddWithValue("@cuentaUsuario", ot.Usuario.UserName);
                cmd.Parameters.AddWithValue("@numeroOt", ot.OrdenTrabajo.NumeroOrden);
                cmd.Parameters.AddWithValue("@id_actividad", ot.ActividadDeOrdenTrabajo.IdActividad);
                var reader = cmd.ExecuteReader();

                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog
                    {

                        ActividadDeOrdenTrabajo =
                            new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) }),

                        HorasActividad = Convert.ToInt32(reader["horas"])
                    };

                    lista.Add(otr);
                }
                sqlConn.Close();
                return lista;
            }
        }

        public OrdenTrabajoActividadLog GetOrdenTrabajoLogbyid(OrdenTrabajoActividadLog ot)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_by_id_orden_trabajo_actividad_ot" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo_actividad", ot.IdOrdenTrabajoActividadLog);
                var reader = cmd.ExecuteReader();

                var otr = new OrdenTrabajoActividadLog();
                if (reader.Read())
                {
                    otr.IdOrdenTrabajoActividadLog = Convert.ToInt32(reader["id_orden_trabajo_actividad"]);
                    otr.ActividadDeOrdenTrabajo = new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) });
                    otr.OrdenTrabajo = new OrdenTrabajo
                    {
                        IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]),
                    };
                    otr.FechaInicio = reader["fecha_inicio"].ToString();
                    otr.FechaTermino = reader["fecha_termino"].ToString();
                    otr.Estado = Convert.ToByte(reader["estado"]);
                    otr.IdOtOrigen = Convert.ToInt32(reader["id_ota_origen"]);
                    otr.Avanza = Convert.ToInt32(reader["avanza"]);
                    otr.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_usuario"].ToString());
                }
                sqlConn.Close();
                return otr;
            }

        }


        public OrdenTrabajoActividadLog GetOrdenTrabajoLogbyidOT(int id)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_by_id_orden_trabajo" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", id);
                var reader = cmd.ExecuteReader();

                var otr = new OrdenTrabajoActividadLog();
                if (reader.Read())
                {
                    otr.IdOrdenTrabajoActividadLog = Convert.ToInt32(reader["id_orden_trabajo_actividad"]);
                    otr.ActividadDeOrdenTrabajo = new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) });
                    otr.OrdenTrabajo = new OrdenTrabajo
                    {
                        IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]),
                    };
                    otr.FechaInicio = reader["fecha_inicio"].ToString();
                    otr.FechaTermino = reader["fecha_termino"].ToString();
                    otr.Estado = Convert.ToByte(reader["estado"]);
                    otr.IdOtOrigen = Convert.ToInt32(reader["id_ota_origen"]);
                    otr.Avanza = Convert.ToInt32(reader["avanza"]);
                    otr.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_usuario"].ToString());
                }
                sqlConn.Close();
                return otr;
            }

        }




        public List<OrdenTrabajoActividadLog> GetCargTrabajoUsuariosByActividadOt(OrdenTrabajoActividadLog ot, string grupo, int all = 0)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_carga_trabajo_usuarios_by_actividad_ot" };
                cmd.Parameters.AddWithValue("@id_actividad", ot.ActividadDeOrdenTrabajo.IdActividad);
                cmd.Parameters.AddWithValue("@all", all);
                cmd.Parameters.AddWithValue("@grupo", grupo);
                var reader = cmd.ExecuteReader();

                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog();
                    otr.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                    otr.CargaTrabajo = Convert.ToInt32(reader["carga"]);
                    lista.Add(otr);
                }
                sqlConn.Close();
                return lista;


            }

        }

        public DataTable GetGrafico(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_grafico_inicio_ot_by_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public OrdenTrabajoActividadLog GetOrdenTrabajoAnterior(OrdenTrabajoActividadLog ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_actividad_anterior_ot" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", ot.OrdenTrabajo.IdOrden);
                var reader = cmd.ExecuteReader();

                var otr = new OrdenTrabajoActividadLog();
                if (reader.Read())
                {
                    otr.IdOrdenTrabajoActividadLog = Convert.ToInt32(reader["id_orden_trabajo_actividad"]);
                    otr.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_usuario"].ToString());
                    otr.ActividadDeOrdenTrabajo = new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) });
                    otr.OrdenTrabajo = new OrdenTrabajo { IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]) };
                    otr.FechaInicio = reader["fecha_inicio"].ToString();
                    otr.FechaTermino = reader["fecha_termino"].ToString();
                    otr.Estado = Convert.ToByte(reader["estado"]);
                    otr.IdOtOrigen = Convert.ToInt32(reader["id_ota_origen"]);
                    otr.Avanza = Convert.ToByte(reader["avanza"]);
                    otr.CargaTrabajo = Convert.ToInt32(reader["carga"]);

                }
                sqlConn.Close();
                return otr;


            }


        }

        public List<OrdenTrabajoActividadLog> GetOrdenTrabajoFlujo(OrdenTrabajoActividadLog ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_flujo_ot" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", ot.OrdenTrabajo.IdOrden);
                var reader = cmd.ExecuteReader();

                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog();
                    otr.IdOrdenTrabajoActividadLog = Convert.ToInt32(reader["id_orden_trabajo_actividad"]);
                    otr.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_usuario"].ToString());
                    otr.ActividadDeOrdenTrabajo = new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) });
                    otr.OrdenTrabajo = new OrdenTrabajo { IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]) };
                    otr.FechaInicio = reader["fecha_inicio"].ToString();
                    otr.FechaTermino = reader["fecha_termino"].ToString();
                    otr.Estado = Convert.ToByte(reader["estado"]);
                    otr.IdOtOrigen = Convert.ToInt32(reader["id_ota_origen"]);
                    otr.Avanza = Convert.ToByte(reader["avanza"]);
                    otr.HorasActividad = Convert.ToInt32(reader["horas"]);
                    lista.Add(otr);

                }
                sqlConn.Close();
                return lista;


            }

        }



        public OrdenTrabajoActividadLog GetLastOrdenTrabajoLogbyid(OrdenTrabajoActividadLog ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_last_orden_trabajo_by_id_orden_trabajo_actividad_ot" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", ot.OrdenTrabajo.IdOrden);
                var reader = cmd.ExecuteReader();

                var otr = new OrdenTrabajoActividadLog();
                if (reader.Read())
                {
                    otr.IdOrdenTrabajoActividadLog = Convert.ToInt32(reader["id_orden_trabajo_actividad"]);
                    otr.ActividadDeOrdenTrabajo = new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) });
                    otr.OrdenTrabajo = new OrdenTrabajo
                    {
                        IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]),
                        IdSolicitud = Convert.ToInt32(reader["id_solicitud"])
                    };
                    otr.FechaInicio = reader["fecha_inicio"].ToString();
                    otr.FechaTermino = reader["fecha_termino"].ToString();
                    otr.Estado = Convert.ToByte(reader["estado"]);
                    otr.IdOtOrigen = Convert.ToInt32(reader["id_ota_origen"]);
                    otr.Avanza = Convert.ToInt32(reader["avanza"]);
                    otr.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["idUsuarioActual"].ToString());
                    otr.HorasActividad = Convert.ToInt32(reader["horas"]);
                    
                }
                sqlConn.Close();
                return otr;


            }

        }

        public bool PuedeVerOrdenTrabajoOt(OrdenTrabajoActividadLog ot)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_puede_ver_orden_trabajo_ot" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo_actividad", ot.IdOrdenTrabajoActividadLog);
                cmd.Parameters.AddWithValue("@id_usuario", ot.Usuario.UserName);
                var reader = cmd.ExecuteReader();

                var respuesta = false;
                if (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["respuesta"]);
                }
                sqlConn.Close();
                return respuesta;
            }
        }

        public List<OrdenTrabajoActividadLog> get_productos_primera_ot()
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "sp_get_productos_primera_ot"
                };

                var reader = cmd.ExecuteReader();
                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog();
                    otr.Codigo = reader["codigo"].ToString();
                    otr.Operacion = reader["operacion"].ToString();
                    lista.Add(otr);
                }
                sqlConn.Close();
                return lista;
            }
        }

        public List<OrdenTrabajoActividadLog> get_documentos_ot()
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "sp_get_documentos_ot"
                };

                var reader = cmd.ExecuteReader();
                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog();
                    otr.IdDocumento = Convert.ToInt32(reader["id_documento"]);
                    otr.Nombre = reader["nombre"].ToString();
                    lista.Add(otr);
                }
                sqlConn.Close();
                return lista;
            }

        }

        public List<OrdenTrabajoActividadLog> getCheckEjecutivo_by_idActividad(int idAct, int tipoChec)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "sp_getCheckEjecutivo_by_idActividad"
                };
                cmd.Parameters.AddWithValue("@id_actividad", idAct);
                cmd.Parameters.AddWithValue("@tipo", tipoChec);
                var reader = cmd.ExecuteReader();
                var lista = new List<OrdenTrabajoActividadLog>();
                while (reader.Read())
                {
                    var otr = new OrdenTrabajoActividadLog();
                    otr.IdActividad = Convert.ToInt32(reader["id_checklist"]);
                    otr.IdActividad = Convert.ToInt32(reader["id_actividad"]);
                    otr.ActividadDeOrdenTrabajo = new ActividadOrdenTrabajoDAC().GetActividad(new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(reader["id_actividad"]) });
                    //otr.CheckListActividadOrdenTrabajo =
                    //    new CheckActividadOrdenTrabajoDAC().GetCheckListActividadOrdenTrabajo( new CheckListActividadOrdenTrabajo { idCheklist = Convert.ToInt32(reader["id_checklist"]), tipo = tipoChec });
                    lista.Add(otr);
                }
                sqlConn.Close();
                return lista;
            }

        }


    }
}
