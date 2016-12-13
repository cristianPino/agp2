using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;


namespace CACCESO
{
    public class InfoAutoDAC : CACCESO.BaseDAC
    {
        public DataTable GetPasosInfoauto()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_pasos_dv";
                SqlDataReader reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                sqlConn.Close();
                return dt;
            }
        }


        public void ActualizarPasoInfocar(int idDicomVehiculoPaso, string estado)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "udp_paso_dv";
                cmd.Parameters.AddWithValue("@id_dicom_vehiculo_pasos", idDicomVehiculoPaso);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }


        public void HabilitarContratoDv(int idSolicitud,string comentario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "habilitar_contrato_dv";
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                cmd.Parameters.AddWithValue("@comentario", comentario);
                cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
        }


        public void SetIdSolicitudAsociado(int idSolicitudAsociado, int idSolicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "set_id_solicitud_asociada_infocar";
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                cmd.Parameters.AddWithValue("@id_solicitud_asociada", idSolicitudAsociado);
                cmd.ExecuteNonQuery();                
                sqlConn.Close();
               
            }
        }

        public DataTable GetInfocarBySolicitud(int idSolicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_infocar_by_solicitud";
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);              
                SqlDataReader reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                sqlConn.Close();
                return dt;
            }
        }

        public DataTable ValidaExistenciaOperacion(int id_solicitud,string patente)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "valida_existe_operacion";
                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                cmd.Parameters.AddWithValue("@PATENTE", patente);
                SqlDataReader reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                sqlConn.Close();
                return dt;
            }
        }
        public void AddMensajeAnalisis(string cuentaUsuario,string mensaje)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "add_mensaje_analisis";
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@mensaje", mensaje);
                cmd.ExecuteNonQuery();
                sqlConn.Close();               
            }

        }

        public void DesactivaMensajeAnalisis()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "desactiva_mensaje_analisis";
                cmd.ExecuteNonQuery();
                sqlConn.Close();
               
            }
        }

        public DataTable GetMensajeAnalisis()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_mensaje_analisis";                
                SqlDataReader reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                sqlConn.Close();
                return dt;
            }
        }


        public DataTable GetdashboardCertificados(string cuentaUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_dashboard_infocar";
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                SqlDataReader reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                sqlConn.Close();
                return dt;
            }

        }

        public void Up_DicomVehiculoAnalisisManual(int numeroSolicitud, string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_up_DicomVehiculoAnalisisManual", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", numeroSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@estado", 1));
                    cmd.Parameters.Add(new SqlParameter("@usuario", cuentaUsuario));


                    cmd.ExecuteNonQuery();
                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AddDatoGeneral(InfoAuto v)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_Add_DatosGeneralesDicomV", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", v.Id_solicitud));
                    cmd.Parameters.Add(new SqlParameter("@patente", v.Patente ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@tipo", v.Tipo_vehiculo ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@marca", v.Marca ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@modelo", v.Modelo ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@color", v.Color ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@anio", v.Ano));
                    cmd.Parameters.Add(new SqlParameter("@numMotor", v.Motor ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@numChassis", v.Chassis ?? "S/I"));
                    cmd.Parameters.Add(new SqlParameter("@numVin", v.Vin ?? "S/I"));

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<InfoAuto> GetChartTodosCertificado(string tipoOperacion, int idCliente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_get_chart_todo_certificado", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@tipoOperacion", tipoOperacion));
                    cmd.Parameters.Add(new SqlParameter("@id_cliente", idCliente));

                    var reader = cmd.ExecuteReader();
                    var lista = new List<InfoAuto>();
                    while (reader.Read())
                    {
                        var xx = new InfoAuto();
                        xx.ChartMes = Convert.ToInt32(reader["MES"]);
                        xx.ChartMesConteo = Convert.ToInt32(reader["CONTEO"]);
                        xx.ChartMesDescripcion = reader["DESCRIPCIONMES"].ToString();
                        lista.Add(xx);
                    }
                    sqlConn.Close();
                    return lista;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int CantidadCErtificados(string fechaDesde, string fechahasta, int idDocumento, int idCliente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_get_cantidad_certificados", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    Cmd.Parameters.AddWithValue("@fechaHasta", fechahasta);
                    Cmd.Parameters.AddWithValue("@idDoc", idDocumento);
                    Cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    var reader = Cmd.ExecuteReader();
                    var total = 0;
                    if (reader.Read())
                    {
                        total = Convert.ToInt32(reader["total"]);
                    }
                    sqlConn.Close();
                    return total;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string ReiniciaCertificados(Int32 idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_reinicia_operaciones_certificados", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<InfoAuto> Get_productoCertificadoByCliente(int idCliente)
        {
            //trae la lista del tipo operacion familia certifiicado por cliente
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_productoCertificadoByCliente";
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    var reader = cmd.ExecuteReader();

                    var lDatosvehiculo = new List<InfoAuto>();
                    while (reader.Read())
                    {
                        var mDatosvehiculo = new InfoAuto
                        {
                            EstadoFamilia = reader["codigo"].ToString(),
                            Propietario_nombre = reader["operacion"].ToString()
                        };
                        lDatosvehiculo.Add(mDatosvehiculo);

                    }
                    sqlConn.Close();
                    return lDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<InfoAuto> GetClienteCertificados()
        {
            //trae la lista de los clientes que tienen habilitado la compra de cav o multas
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_cliente_by_productoCertificados";
                    var reader = cmd.ExecuteReader();

                    var lDatosvehiculo = new List<InfoAuto>();
                    while (reader.Read())
                    {
                        var mDatosvehiculo = new InfoAuto
                        {
                            Id_solicitud = Convert.ToInt32(reader["id_cliente"]),
                            Propietario_nombre = reader["nombre"].ToString()
                        };
                        lDatosvehiculo.Add(mDatosvehiculo);

                    }
                    sqlConn.Close();
                    return lDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoAuto> GetCertificados(string patente, int idCliente, string desde, string hasta)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_certificados";
                    cmd.Parameters.AddWithValue("@patente", patente);
                    cmd.Parameters.AddWithValue("@cliente", idCliente);
                    cmd.Parameters.AddWithValue("@fechaDesde", desde);
                    cmd.Parameters.AddWithValue("@fechaHasta", hasta);
                    cmd.CommandTimeout = 10000;

                    var reader = cmd.ExecuteReader();

                    var lDatosvehiculo = new List<InfoAuto>();
                    while (reader.Read())
                    {
                        var mDatosvehiculo = new InfoAuto
                        {
                            Id_solicitud = Convert.ToInt32(reader["id_solicitud"]),
                            Marca = reader["marca"].ToString(),
                            Tipo_vehiculo = reader["tipo"].ToString(),
                            Patente = reader["patente"].ToString().ToUpper(),
                            Modelo = reader["modelo"].ToString(),
                            Chassis = reader["numChasis"].ToString(),
                            Motor = reader["numMotor"].ToString(),
                            Vin = reader["numVin"].ToString(),
                            Ano = Convert.ToInt32(reader["anioFab"]),
                            Color = reader["color"].ToString(),
                            Combustible = reader["combustible"].ToString(),
                            FechaAdquisicion = reader["fecha"].ToString(),
                            ConMuntas = Convert.ToBoolean(reader["conMultas"]),
                            Propietario_nombre = reader["propietario"].ToString(),
                            EstadoFamilia = reader["estadoFamilia"].ToString(),
                            EncargoRobo = reader["encargoRobo"].ToString(),
                            LimitacionDominio = reader["limDom"].ToString(),
                            RevisionTecnica = reader["revtecven"].ToString(),
                            MontoMulta = reader["montoMultas"].ToString(),
                            Usuario = reader["usuario"].ToString(),
                            TipoOperacion = reader["tipoOperacion"].ToString(),
                            DescripcionTipoOperacion = reader["descripcionTipoOperacion"].ToString(),
                            IdEstadoFamilia = Convert.ToInt32(reader["codigo_estado"]),
                            TiempoTranscurrido = Convert.ToInt32(reader["tiempoTranscurrido"])


                        };
                        lDatosvehiculo.Add(mDatosvehiculo);

                    }
                    sqlConn.Close();
                    return lDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_Datosvehiculo(Int32 id_solicitud, string patente, Int32 estado, Int32 idSolicitudAsociada = 0)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_infoauto", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                    oParam = Cmd.Parameters.AddWithValue("@estado", estado);
                    oParam = Cmd.Parameters.AddWithValue("@id_solicitud_asociada", idSolicitudAsociada);
                    
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public void Upt_solicitudDV(Int32 id_solicitud, string usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_upt_solicitudDV", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<InfoAutoDetalle> Get_DicomVehiculoDetalle(int idSolicitud, string parametro)
        {
            //CREADO 19/06/2014
            //POR CRISTIAN PINO
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_Get_DicomVehiculoDetalle", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@parametro", parametro));
                    var reader = cmd.ExecuteReader();

                    var lista = new List<InfoAutoDetalle>();

                    while (reader.Read())
                    {
                        var m = new InfoAutoDetalle
                        {
                            IdDicomVehiculoDetalle = reader["id_dicom_vehiculo_detalle"].ToString(),//fechaInfraccion
                            Patente = reader["patente"].ToString(),
                            FechaHecho = reader["fechaHecho"].ToString() ?? "",//fechaInfraccion
                            Descripcion = reader["descripcion"].ToString() ?? "",//infraccion
                            Lugar = reader["lugar"].ToString() ?? "",//tribunal
                            FechaInformacion = reader["fechaInformacion"].ToString() ?? "",//fechaSentencia
                            Monto = reader["monto"].ToString() ?? "",//monto
                            Observacion = reader["observacion"].ToString() ?? "",//rol
                            Arancel = reader["arancel"].ToString() ?? "",//arancel
                            TipoMoneda = reader["tipoMoneda"].ToString(),//tipoMoneda
                            FechaIngresoRmnp = reader["fechaIngresoRMNP"].ToString() ?? "",//fechaIngresoRMNP
                            IdMulta = reader["idMulta"].ToString() ?? "",//idMulta,
                            Rut = reader["rut"].ToString() ?? "",
                            Nombre = reader["nombre"].ToString() ?? ""

                        };


                        lista.Add(m);
                    }

                    sqlConn.Close();
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //CREADO 26/06/2014
        public void Del_DicomVehiculoDetalle(int idDicomVehiculoDetalle)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_DelDicomVehiculoDetalle", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@idDicomVehiculoDetalle", idDicomVehiculoDetalle));

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public void UpdateDicomVehiculoProcesos(int idSolicitud, int tipoActualizacion, int proceso)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_updateDicomVehiculoProcesos", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@proceso", proceso));
                    cmd.Parameters.Add(new SqlParameter("@tipoActualizacion", tipoActualizacion));
                    cmd.ExecuteNonQuery();

                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int Get_ProcesoDicomVehiculoByPaso(int idSolicitud, int idPaso)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var estado = 0;
                    var cmd = new SqlCommand("sp_get_ProcesoDicomVehiculoByPaso", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@id_paso", idPaso));

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        estado = Convert.ToInt32(reader["estado"]);
                    }

                    sqlConn.Close();
                    return estado;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Get_DicomVehiculoRevisados(int idSolicitud, string tipo)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var conteo = false;
                    var cmd = new SqlCommand("sp_get_DicomVehiculoRevisados", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@tipo", tipo));

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        conteo = Convert.ToBoolean(reader["conteo"]);
                    }

                    sqlConn.Close();
                    return conteo;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }




        //CREADO 20/06/2014
        public string add_InfoAutoDetalle(string idDicomVehiculoDetalle, string idSolicitud, string parametro, string proveedor, string fechaHecho = "", string descripcion = "",
                                            string lugar = "", string fechaInformacion = "", string monto = "", string observacion = "", string nombre = "",
                                            string rut = "", string arancel = "", string tipoMoneda = "", string idMulta = "", string fechaIngresoMrnp = "")
        {


            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_add_InfoAutoDetalle", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    var oParam = cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                    cmd.Parameters.AddWithValue("@idDicomVehiculoDetalle", idDicomVehiculoDetalle);
                    cmd.Parameters.AddWithValue("@parametro", parametro);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor);
                    cmd.Parameters.AddWithValue("@fechaHecho", fechaHecho);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@lugar", lugar);
                    cmd.Parameters.AddWithValue("@fechaInformacion", fechaInformacion);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.Parameters.AddWithValue("@observacion", observacion);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.Parameters.AddWithValue("@arancel", arancel);
                    cmd.Parameters.AddWithValue("@tipoMoneda", tipoMoneda);
                    cmd.Parameters.AddWithValue("@idMulta", idMulta);
                    cmd.Parameters.AddWithValue("@fechaIngresoMrnp", fechaIngresoMrnp);


                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public InfoAuto getDatoVehiculo(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_infoautobyid_solicitud";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    InfoAuto mDatosvehiculo = new InfoAuto();
                    if (reader.Read())
                    {
                        mDatosvehiculo.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mDatosvehiculo.Patente = reader["patente"].ToString();
                        mDatosvehiculo.Dv = reader["dv"].ToString();


                    }
                    else
                    {
                        mDatosvehiculo = null;
                    }
                    sqlConn.Close();
                    return mDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public InfoAuto getexiste(string patente, Int16 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_infoautobycliente";
                    cmd.Parameters.AddWithValue("@patente", patente);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    InfoAuto mDatosvehiculo = new InfoAuto();
                    if (reader.Read())
                    {
                        mDatosvehiculo.Existe = Convert.ToBoolean(reader["existe"]);
                    }
                    else
                    {
                        mDatosvehiculo = null;
                    }
                    sqlConn.Close();
                    return mDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<InfoAuto> GetInfoAutoNew(string usuario,
                                            string idEstadoFamilia,
                                            string tipoOperacion,
                                            string fechaDesde,
                                            string fechaHasta,
                                            int idsucursal,
                                            DataTable dt)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_InfoAuto_new";
                cmd.Parameters.AddWithValue("@cuentaUsuario", usuario);
                cmd.Parameters.AddWithValue("@estadoFamilia", idEstadoFamilia);
                cmd.Parameters.AddWithValue("@tipo_operacion", tipoOperacion);
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("@sucursal_consulta", idsucursal);
                cmd.Parameters.Add("@listaPatente", SqlDbType.Structured).Direction = ParameterDirection.Input;
                cmd.Parameters[6].TypeName = "varchar_list_tbltype";
                cmd.Parameters[6].Value = dt;
                cmd.CommandTimeout = 15000;
                var reader = cmd.ExecuteReader();

                var lDatosvehiculo = new List<InfoAuto>();
                while (reader.Read())
                {
                    var mDatosvehiculo = new InfoAuto
                    {
                        Id_solicitud = Convert.ToInt32(reader["id_solicitud"]),
                        Marca = reader["marca"].ToString(),
                        Tipo_vehiculo = reader["tipo"].ToString(),
                        Patente = reader["patente"].ToString().ToUpper(),
                        Modelo = reader["modelo"].ToString(),
                        Chassis = reader["numChasis"].ToString(),
                        Motor = reader["numMotor"].ToString(),
                        Vin = reader["numVin"].ToString(),
                        Ano = Convert.ToInt32(reader["anioFab"]),
                        Color = reader["color"].ToString(),
                        Combustible = reader["combustible"].ToString(),
                        FechaAdquisicion = reader["fecha"].ToString(),
                        ConMuntas = Convert.ToBoolean(reader["conMultas"]),
                        Propietario_nombre = reader["propietario"].ToString(),
                        EstadoFamilia = reader["estadoFamilia"].ToString(),
                        EncargoRobo = reader["encargoRobo"].ToString(),
                        LimitacionDominio = reader["limDom"].ToString(),
                        RevisionTecnica = reader["revtecven"].ToString(),
                        MontoMulta = reader["montoMultas"].ToString(),
                        EjecutivoActual = reader["ejecutivoActual"].ToString(),
                        CorreoComprador = reader["correo"].ToString(),
                        IdSolicitudEncriptado = reader["idSolicitudEncriptado"].ToString(),
                        PatenteEncriptado = reader["patenteEncriptado"].ToString(),
                        Usuario = reader["usuario"].ToString(),
                        TipoOperacion = Convert.ToString(reader["operacion"]),
                        Sucursal = Convert.ToString(reader["sucursal"]),
                        IdCliente = Convert.ToInt32(reader["id_cliente"]),
                        CodigoEstado = Convert.ToInt32(reader["codigo_estado"]),
                        IdSolicitudAsociado = Convert.ToInt32(reader["id_solicitud_asociada"]),
                        HabilitadoTransferencia = Convert.ToBoolean(reader["habilitado_transferencia"])

                    };
                    lDatosvehiculo.Add(mDatosvehiculo);

                }
                sqlConn.Close();
                return lDatosvehiculo;
            }

        }

        public List<InfoAuto> GetInfoAuto(Int32 idSolicitud, string patente, string usuario, int idEstadoFamilia, string tipoOperacion, string fechaDesde, string fechaHasta)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_InfoAuto";
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                    cmd.Parameters.AddWithValue("@patente", patente);
                    cmd.Parameters.AddWithValue("@cuentaUsuario", usuario);
                    cmd.Parameters.AddWithValue("@estadoFamilia", idEstadoFamilia);
                    cmd.Parameters.AddWithValue("@tipo_operacion", tipoOperacion);
                    cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    var reader = cmd.ExecuteReader();

                    var lDatosvehiculo = new List<InfoAuto>();
                    while (reader.Read())
                    {
                        var mDatosvehiculo = new InfoAuto
                        {
                            Id_solicitud = Convert.ToInt32(reader["id_solicitud"]),
                            Marca = reader["marca"].ToString(),
                            Tipo_vehiculo = reader["tipo"].ToString(),
                            Patente = reader["patente"].ToString().ToUpper(),
                            Modelo = reader["modelo"].ToString(),
                            Chassis = reader["numChasis"].ToString(),
                            Motor = reader["numMotor"].ToString(),
                            Vin = reader["numVin"].ToString(),
                            Ano = Convert.ToInt32(reader["anioFab"]),
                            Color = reader["color"].ToString(),
                            Combustible = reader["combustible"].ToString(),
                            FechaAdquisicion = reader["fecha"].ToString(),
                            ConMuntas = Convert.ToBoolean(reader["conMultas"]),
                            Propietario_nombre = reader["propietario"].ToString(),
                            EstadoFamilia = reader["estadoFamilia"].ToString(),
                            EncargoRobo = reader["encargoRobo"].ToString(),
                            LimitacionDominio = reader["limDom"].ToString(),
                            RevisionTecnica = reader["revtecven"].ToString(),
                            MontoMulta = reader["montoMultas"].ToString(),
                            EjecutivoActual = reader["ejecutivoActual"].ToString(),
                            CorreoComprador = reader["correo"].ToString(),
                            IdSolicitudEncriptado = reader["idSolicitudEncriptado"].ToString(),
                            PatenteEncriptado = reader["patenteEncriptado"].ToString(),
                            Usuario = reader["usuario"].ToString()

                        };
                        lDatosvehiculo.Add(mDatosvehiculo);

                    }
                    sqlConn.Close();
                    return lDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<InfoAuto> GetInfoCarPublico(Int32 oc, string patente, int fecha)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_InfoAuto_publico";
                    cmd.Parameters.AddWithValue("@oc", oc);
                    cmd.Parameters.AddWithValue("@patente", patente);
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    var reader = cmd.ExecuteReader();

                    var lDatosvehiculo = new List<InfoAuto>();
                    while (reader.Read())
                    {
                        var mDatosvehiculo = new InfoAuto
                        {
                            Id_solicitud = Convert.ToInt32(reader["id_solicitud"]),
                            FechaAdquisicion = reader["fecha"].ToString(),
                            Patente = reader["patente"].ToString(),
                            EstadoFamilia = reader["estadoFamilia"].ToString(),
                            IdEstadoFamilia = Convert.ToInt32(reader["codigo_estado"]),
                            EjecutivoActual = reader["ejecutivoActual"].ToString(),
                            CorreoComprador = reader["correo"].ToString(),
                            OrdenCompra = Convert.ToInt32(reader["oc"]),
                            TiempoTranscurrido = Convert.ToInt32(reader["tiempo"])

                        };
                        lDatosvehiculo.Add(mDatosvehiculo);

                    }
                    sqlConn.Close();
                    return lDatosvehiculo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Reset_solicitudDVCancelar(int idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_Reset_solicitudDVCancelar", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));


                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



    }
}