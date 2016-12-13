using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
using Microsoft.SqlServer.Server;

namespace CACCESO
{
    public class HipotecarioDAC : CACCESO.BaseDAC
    {

        public DataTable GetIdSolicitud(int rutComprador)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                {
                    SqlCommand Cmd = new SqlCommand("get_solicitud_n_cliente_by_rut", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut_comprador", rutComprador);

                    var read = Cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(read);
                    sqlConn.Close();
                    return dt;
                }
            }
          
        }


        public Int32 add_prohibicion(Int32 id_solicitud, string fojas, string numero, Int32 ano, string descripcion, string comuna, string tipo, Int32 id_prohibicion, string aFavorDe, string comentario, string letra)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_hipotecarioProhibicion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@fojas", fojas);
                    oParam = Cmd.Parameters.AddWithValue("@numero", numero);
                    oParam = Cmd.Parameters.AddWithValue("@ano", ano);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    oParam = Cmd.Parameters.AddWithValue("@comuna", comuna);
                    oParam = Cmd.Parameters.AddWithValue("@tipo", tipo);
                    oParam = Cmd.Parameters.AddWithValue("@id_prohibicion", id_prohibicion);
                    oParam = Cmd.Parameters.AddWithValue("@id", 0);
                    oParam = Cmd.Parameters.AddWithValue("@aFavorDe", aFavorDe);
                    oParam = Cmd.Parameters.AddWithValue("@letra", letra);
                    oParam = Cmd.Parameters.AddWithValue("@comentario", comentario);


                    var reader = Cmd.ExecuteReader();
                    var nTheNewId = 0;
                    if (reader.Read())
                    {
                        nTheNewId = Convert.ToInt32(reader["id"]);

                    }

                    sqlConn.Close();
                    return nTheNewId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //return 0;

        }

        public string del_prohibicion(int idProhibicion)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_hipotecarioProhibicion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_prohibicion", idProhibicion);

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";

        }

        public string add_escritura_pendiente_hipoteca(Int32 id_solicitud)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_escritura_pendiente_hipoteca", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";

        }

        public string add_forma_pago(Hipoteca_FormaPago forma)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_add_hipotecarioFormaPago", sqlConn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@id_forma_pago", forma.IdFormaPago);
                    cmd.Parameters.AddWithValue("@id_solicitud", forma.IdSolicitud);
                    cmd.Parameters.AddWithValue("@cuota_inicioTasaMixta", forma.CuotainicioTasaMixta);
                    cmd.Parameters.AddWithValue("@cuota_finTasaFija", forma.CuotaFinalTasaFija);
                    cmd.Parameters.AddWithValue("@valor_dividendoTJ", forma.ValorDividendoTasaFija);
                    cmd.Parameters.AddWithValue("@tasaFija", forma.TasaFija);
                    cmd.Parameters.AddWithValue("@valor_dividendoTM", forma.ValorDividendoTasaMixta);
                    cmd.Parameters.AddWithValue("@tasaMixta", forma.TasaMixta);
                    cmd.Parameters.AddWithValue("@primerosDividendos", forma.ValorPrimerosDividendos);
                    cmd.Parameters.AddWithValue("@ultimoDividendo", forma.ValorUltimoDividendo);
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";

        }

        public string del_forma_pago(Int32 id_solicitud)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_hipotecarioFormaPago", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";

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

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getOperacionesHipotecario";
                    cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
                    cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
                    cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);
                    cmd.Parameters.AddWithValue("@familia", id_familia);
                    cmd.Parameters.AddWithValue("@estado_proceso", estado_proceso);
                    cmd.Parameters.AddWithValue("@rol", rol);
                    cmd.Parameters.AddWithValue("@nombre_deudor", nombre_deudor);
                    cmd.CommandTimeout = 0;

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Hipotecario> loperacion = new List<Hipotecario>();
                    while (reader.Read())
                    {
                        Hipotecario mOperacion = new Hipotecario();
                        mOperacion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
                        //mOperacion.Vendedor = get_participe_hipoteca(mOperacion.Operacion.Id_solicitud, "V");
                        //mOperacion.Comprador = get_participe_hipoteca(mOperacion.Operacion.Id_solicitud, "C");
                        //mOperacion.Anterior_ano = Convert.ToInt16(reader["anterior_ano"]);
                        //mOperacion.Anterior_fojas = Convert.ToInt16(reader["anterior_fojas"]);
                        //mOperacion.Anterior_numero  =Convert.ToInt16(reader["anterior_numero"]);
                        //mOperacion.Inscripcion_ano = Convert.ToInt16(reader["inscripcion_ano"]);
                        //mOperacion.Inscripcion_fojas = Convert.ToInt16(reader["inscripcion_fojas"]);
                        ////mOperacion.Inscripcion_numero = Convert.ToInt16(reader["inscripcion_numero"]);
                        //mOperacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"]));
                        ////mOperacion.Cantidad_mutuo = Convert.ToDouble(reader["cantidad_mutuo"]);
                        //mOperacion.Monto_credito = Convert.ToInt32(reader["precio_uf"]);
                        //mOperacion.Tasa = (reader["tasa"].ToString());
                        //mOperacion.Rol = (reader["rol"].ToString());



                        loperacion.Add(mOperacion);

                        mOperacion = null;
                    }
                    return loperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Hipoteca_FormaPago get_forma_pago(Int32 idSolicitud)
        {

            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    { CommandType = CommandType.StoredProcedure, CommandText = "sp_r_getHipotecaFormaPago" };
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                    cmd.CommandTimeout = 0;

                    SqlDataReader reader = cmd.ExecuteReader();
                    var mformapago = new Hipoteca_FormaPago();
                    if (reader.Read())
                    {
                        mformapago.IdFormaPago = Convert.ToInt32(reader["id_forma_pago"]);
                        mformapago.CuotaFinalTasaFija = Convert.ToInt32(reader["cuota_hasta"]);
                        mformapago.TasaFija = reader["tasa"].ToString();
                        mformapago.ValorDividendoTasaFija = reader["valor_dividendo"].ToString();
                        mformapago.CuotainicioTasaMixta = Convert.ToInt32(reader["cuota_inicio_tasa_mixta"]);
                        mformapago.TasaMixta = reader["tasaMixta"].ToString();
                        mformapago.ValorDividendoTasaMixta = reader["valor_dividendo_tasa_mixta"].ToString();
                        mformapago.ValorPrimerosDividendos = reader["valorPrimerosDividendos"].ToString();
                        mformapago.ValorUltimoDividendo = reader["valorUltimoDividendo"].ToString();

                    }

                    return mformapago;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<Hipotecario> GetUsuarioDashboard(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_hipoteca_usuario_dashboard" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                var lista = new List<Hipotecario>();
                while (reader.Read())
                {
                    var hip = new Hipotecario();

                    hip.SemaforoImagen = reader["semaforoEstado"].ToString();
                    hip.ContadorOperacion = Convert.ToInt32(reader["diasTotal"]);
                    hip.ContadorEtapa = Convert.ToInt32(reader["contadorEstado"]);
                    hip.EstadoDescripcion = reader["estadoDescripcion"].ToString();

                    lista.Add(hip);
                }
                sqlConn.Close();
                return lista;
            }
        }

        public bool ValidaExisteOperacion(string tipoOperacion, string numeroBanco, int idCliente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_validar_existe_operacion_hipotecario" };
                cmd.Parameters.AddWithValue("@tipo_operacion", tipoOperacion);
                cmd.Parameters.AddWithValue("@numero_banco", numeroBanco);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                var existe = true;
                if (reader.Read())
                {
                    existe = Convert.ToBoolean(reader["existe"]);

                }
                sqlConn.Close();
                return existe;
            }
        }

        public Hipotecario ValidarOperacion(int idSolicitud, string numeroBanco, int rut, int idCliente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_validar_operacion_hipotecario" };
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                cmd.Parameters.AddWithValue("@numero_banco", numeroBanco);
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                var hip = new Hipotecario();
                if (reader.Read())
                {
                    hip.IdSolicitud = Convert.ToInt32(reader["id_solicitud"]);
                    hip.NumeroCredito = Convert.ToString(reader["id_solicitud"]);
                    hip.TipoOperacion = new TipoOperacion { Codigo = Convert.ToString(reader["tipo_operacion"]) };

                }
                sqlConn.Close();
                return hip;
            }
        }

        public int GetNominaByNombre(int idFamilia, string nombreNomina)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_nomina_by_nombre" };
                cmd.Parameters.AddWithValue("@id_familia", idFamilia);
                cmd.Parameters.AddWithValue("@nombre_nomina", nombreNomina);
                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                var idNomina = 0;
                if (reader.Read())
                {
                    idNomina = Convert.ToInt32(reader["id_nomina"]);
                }
                sqlConn.Close();
                return idNomina;
            }
        }

        public int ValidaGestoria(string numeroCliente, int idCliente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_valida_gestoria" };
                cmd.Parameters.AddWithValue("@numero_cliente", numeroCliente);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                var respuesta = 0;
                if (reader.Read())
                {
                    respuesta = Convert.ToInt16(reader["conGestoria"]);
                }
                sqlConn.Close();
                return respuesta;
            }
        }


        public List<Hipotecario> GetEstructuraExcel()
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_hipotecario_estructura_excel" };

                cmd.CommandTimeout = 0;
                var reader = cmd.ExecuteReader();
                var listaEstructura = new List<Hipotecario>();
                while (reader.Read())
                {
                    var estructura = new Hipotecario();
                    estructura.ExcelIdCliente = Convert.ToInt16(reader["id_cliente"]);
                    estructura.ExcelQuery = Convert.ToString(reader["query"]);
                    estructura.ExcelTipo = Convert.ToString(reader["tipo"]);
                    listaEstructura.Add(estructura);
                }
                sqlConn.Close();
                return listaEstructura;
            }
        }

        public List<Hipotecario> GetOperacionesHipotecario(string tipoOperacion, string semaforo, string cuentaUsuario, string rutComprador, string numeroCliente, int idCliente, string codigoEstado,
            int idSolicitud, int numeroFactura, DataTable data, DataTable dtrut, DataTable dtIdSolicitud, DataTable dtfactura)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_operaciones_hipotecario" };
                cmd.Parameters.AddWithValue("@tipo_operacion", tipoOperacion);
                cmd.Parameters.AddWithValue("@semaforo", semaforo);
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@rut_comprador", rutComprador);
                cmd.Parameters.AddWithValue("@numero_cliente", numeroCliente);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@codigo_Estado", codigoEstado);
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                cmd.Parameters.AddWithValue("@numero_factura", numeroFactura);
                cmd.Parameters.Add("@prodids", SqlDbType.Structured).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@listaRut", SqlDbType.Structured).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@lista_id_solicitud", SqlDbType.Structured).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@lista_factura", SqlDbType.Structured).Direction = ParameterDirection.Input;
                cmd.Parameters[9].TypeName = "varchar_list_tbltype";
                cmd.Parameters[9].Value = data;

                cmd.Parameters[10].TypeName = "varchar_list_tbltype";
                cmd.Parameters[10].Value = dtrut
                    ;
                cmd.Parameters[11].TypeName = "integer_list_tbltype";
                cmd.Parameters[11].Value = dtIdSolicitud;

                cmd.Parameters[12].TypeName = "varchar_list_tbltype";
                cmd.Parameters[12].Value = dtfactura;

                cmd.CommandTimeout = 15000;
                var reader = cmd.ExecuteReader();
                var lista = new List<Hipotecario>();
                while (reader.Read())
                {
                    var hip = new Hipotecario
                    {
                        IdSolicitud = Convert.ToInt32(reader["id_solicitud"]),
                        IdEstado = Convert.ToInt32(reader["id_estado"]),
                        IdClienteAgp = Convert.ToInt32(reader["id_cliente"]),
                        TipoOperacion = new TipoOperacion { Codigo = Convert.ToString(reader["tipo_operacion"]), Operacion = Convert.ToString(reader["operacion"]) },
                        CuentaUsuarioIngreso = reader["cuenta_usuario"].ToString(),
                        NombreUsuarioIngreso = reader["nombre_usuario_ingreso"].ToString(),
                        FechaSolicitud = reader["fecha_solicitud"].ToString(),
                        Numero = reader["numero_cliente"].ToString(),
                        Sucursal =
                                new SucursalclienteDAC().GetSucursalShort(Convert.ToInt16(reader["id_sucursal"])),
                        RutComprador = reader["rut_comprador"].ToString(),
                        EstadoDescripcion = reader["estado_descripcion"].ToString(),
                        Estado = reader["codigo_Estado"].ToString(),
                        FechaInicioEstado = reader["fecha_hora"].ToString(),
                        NombreClienteAgp = reader["nombre_cliente"].ToString(),
                        NombreComprador = reader["comprador"].ToString(),
                        SemaforoImagen = reader["semaforoEstado"].ToString(),
                        Sla = Convert.ToInt32(reader["sla"]),
                        ContadorEtapa = Convert.ToInt32(reader["contador"]),
                        Modal = reader["modal"].ToString().Trim(),
                        TotalIngreso = reader["total_ingreso"].ToString().Trim(),
                        TotalGastos = reader["total_gasto"].ToString().Trim(),
                        NumeroFactura = Convert.ToInt32(reader["factura"])
                    };

                    lista.Add(hip);
                }
                sqlConn.Close();
                return lista;
            }



        }


        public Hipotecario GetDatoOperaciones(string numeroCliente, int idCliente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_hipoteca_datos_operacion" };

                cmd.Parameters.AddWithValue("@numero_cliente", numeroCliente);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                cmd.CommandTimeout = 0;

                var reader = cmd.ExecuteReader();
                var hip = new Hipotecario();
                if (reader.Read())
                {
                    hip.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"]));
                    hip.RutComprador = reader["rut_comprador"].ToString();
                }
                else
                {
                    hip = null;
                }
                sqlConn.Close();
                return hip;
            }
        }


        public List<Hipoteca_Prohibicion> get_Prohibicion(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getHipotecaProhibicion";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    cmd.CommandTimeout = 0;

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Hipoteca_Prohibicion> lprohibicion = new List<Hipoteca_Prohibicion>();
                    while (reader.Read())
                    {
                        Hipoteca_Prohibicion mprohibicion = new Hipoteca_Prohibicion();
                        mprohibicion.Id_prohibicion = Convert.ToInt32(reader["id_prohibicion"]);
                        mprohibicion.Tipo_prohibicion = reader["tipo_prohibicion"].ToString();
                        mprohibicion.Numero = (reader["numero"].ToString());
                        mprohibicion.Letra = reader["letra"].ToString();
                        mprohibicion.Fojas = (reader["fojas"].ToString());
                        mprohibicion.Ano = Convert.ToInt16(reader["ano"].ToString());
                        mprohibicion.Comuna = (reader["comuna"].ToString());
                        mprohibicion.AfavorDe = (reader["aFavorDe"].ToString());
                        mprohibicion.Comentario = reader["comentario"].ToString();
                        lprohibicion.Add(mprohibicion);
                        mprohibicion = null;
                    }


                    return lprohibicion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public List<Persona> get_participe_hipoteca(Int32 id_solicitud, string tipo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getParticipeHipoteca";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.CommandTimeout = 0;

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Persona> lpersona = new List<Persona>();
                    while (reader.Read())
                    {
                        Persona mPersona = new Persona();


                        mPersona.Rut = Convert.ToDouble(reader["rut"]);
                        mPersona.Dv = reader["dv"].ToString();
                        mPersona.Serie = reader["serie"].ToString();
                        mPersona.Nombre = reader["nombre"].ToString();
                        mPersona.Apellido_paterno = reader["apellido_paterno"].ToString();
                        mPersona.Apellido_materno = reader["apellido_materno"].ToString();
                        mPersona.Sexo = reader["sexo"].ToString();
                        mPersona.Tipo_persona = reader["tipo_persona"].ToString();
                        mPersona.Nacionalidad = reader["nacionalidad"].ToString();
                        mPersona.Profesion = reader["profesion"].ToString();
                        mPersona.Estado_civil = reader["estado_civil"].ToString();
                        mPersona.Telefono = reader["telefono"].ToString();
                        mPersona.Celular = reader["celular"].ToString();
                        mPersona.Correo = reader["correo"].ToString();
                        mPersona.Direccion = reader["direccion"].ToString();
                        mPersona.Numero = reader["numero"].ToString();
                        mPersona.Depto = reader["depto"].ToString();
                        mPersona.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                        mPersona.Tipo_empleador = reader["tipo_empleador"].ToString();


                        lpersona.Add(mPersona);
                        mPersona = null;
                    }


                    return lpersona;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Persona> GetBeneficiariosSubsidio(Int32 idSolicitud)
        {

            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_get_hipoteca_beneficiarios_subsidio"
                    };
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                    cmd.CommandTimeout = 0;
                    var reader = cmd.ExecuteReader();
                    var lpersona = new List<Persona>();
                    while (reader.Read())
                    {
                        var mPersona = new Persona
                        {
                            Rut = Convert.ToDouble(reader["rut"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido_paterno = reader["apellido_paterno"].ToString(),
                            Apellido_materno = reader["apellido_materno"].ToString()
                        };

                        lpersona.Add(mPersona);
                    }

                    return lpersona;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public HipotecaSubsidio GetSubsidio(Int32 idSolicitud)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_get_hipoteca_subsidio"
                    };
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                    cmd.CommandTimeout = 0;
                    var reader = cmd.ExecuteReader();
                    var sub = new HipotecaSubsidio();
                    if (reader.Read())
                    {
                        sub.IdSolicitud = Convert.ToInt32(reader["id_solicitud"]);
                        sub.IdSubsidio = Convert.ToInt32(reader["id_subsidio"]);
                        sub.Ahorro = reader["ahorro_previo"].ToString();
                        sub.NumeroCuenta = reader["numero_cuenta_ahorro"].ToString();
                        sub.Banco = reader["banco"].ToString();
                        sub.Monto = reader["monto_subsidio"].ToString();
                        sub.NumeroSerie = reader["numero_serie_certificado"].ToString();
                        sub.Titulo = reader["titulo"].ToString();
                        sub.Beneficiario = reader["beneficiario_subsidio"].ToString();

                    }
                    sqlConn.Close();
                    return sub;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int AddSubsidio(HipotecaSubsidio hipo)
        {

            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_add_hipoteca_subsidio"
                    };

                    cmd.Parameters.AddWithValue("@id_solicitud", hipo.IdSolicitud);
                    cmd.Parameters.AddWithValue("@ahorro", hipo.Ahorro);
                    cmd.Parameters.AddWithValue("@numeroCuenta", hipo.NumeroCuenta);
                    cmd.Parameters.AddWithValue("@banco", hipo.Banco);
                    cmd.Parameters.AddWithValue("@monto", hipo.Monto);
                    cmd.Parameters.AddWithValue("@numeroSerie", hipo.NumeroSerie);
                    cmd.Parameters.AddWithValue("@titulo", hipo.Titulo);
                    cmd.Parameters.AddWithValue("@beneficiario", hipo.Beneficiario);
                    cmd.Parameters.AddWithValue("@id_subsidio", hipo.IdSubsidio);
                    var oParam = cmd.Parameters.AddWithValue("@folio", 0);
                    oParam.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    var id = Convert.ToInt32(cmd.Parameters["@folio"].Value);
                    sqlConn.Close();
                    return id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

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
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    var Cmd = new SqlCommand("sp_add_hipotecario", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                    Cmd.Parameters.AddWithValue("@tipo_propiedad", tipoPropiedad);
                    Cmd.Parameters.AddWithValue("@precio_vivienda", precioVivienda);
                    Cmd.Parameters.AddWithValue("@monto_credito", montoCredito);
                    Cmd.Parameters.AddWithValue("@vencimiento_primera_cuota", fechaVencimiento);
                    Cmd.Parameters.AddWithValue("@plazo_anos", plazoAnos);
                    Cmd.Parameters.AddWithValue("@sucursal", sucursal);
                    Cmd.Parameters.AddWithValue("@numero_interno", numeroInterno);
                    Cmd.Parameters.AddWithValue("@id_comuna", idComuna);
                    Cmd.Parameters.AddWithValue("@direccion", direccion);
                    Cmd.Parameters.AddWithValue("@numero", numero);
                    Cmd.Parameters.AddWithValue("@complemento", complemento);
                    Cmd.Parameters.AddWithValue("@tipo_credito", tipoCredito);
                    Cmd.Parameters.AddWithValue("@tasacion", tasacion);
                    Cmd.Parameters.AddWithValue("@ejecutivo", ejecutivo);
                    Cmd.Parameters.AddWithValue("@final_caratula", finalCaratula);
                    Cmd.Parameters.AddWithValue("@final_conservador", finalConservador);
                    Cmd.Parameters.AddWithValue("@meses_gracia", mesesGracia);
                    Cmd.Parameters.AddWithValue("@valor_comercial", valorComercial);
                    Cmd.Parameters.AddWithValue("@descripcionDeslindes", descripcionDeslinde);

                    Cmd.Parameters.AddWithValue("@pie", pie);
                    Cmd.Parameters.AddWithValue("@mes_carencia_uno", mesCarenciaUno);
                    Cmd.Parameters.AddWithValue("@mes_carencia_dos", mesCarenciaDos);
                    Cmd.Parameters.AddWithValue("@codeudor_con_seguro", codeudorConSeguro);
                    Cmd.Parameters.AddWithValue("@porcentaje_seguro_codeudor", porcentajeSeguroCodeudor);
                    Cmd.Parameters.AddWithValue("@dfl2", dfl2);
                    Cmd.Parameters.AddWithValue("@tipo_ubicacion", tipoUbicacion);
                    Cmd.Parameters.AddWithValue("@sub_producto_tipo_credito", subProductoTipoCredito);
                    Cmd.Parameters.AddWithValue("@numero_credito", numeroCredito);
                    Cmd.Parameters.AddWithValue("@tasa", tasa);
                    Cmd.Parameters.AddWithValue("@vivienda_social", viviendaSocial);
                    Cmd.Parameters.AddWithValue("@tipo_transferencia", tipoTransferencia);
                    Cmd.Parameters.AddWithValue("@tipo_hipoteca", tipoHipoteca);
                    Cmd.Parameters.AddWithValue("@fecha_memo", fechaMemo);
                    Cmd.Parameters.AddWithValue("@seguro_invalidez", segInvalidez);
                    Cmd.Parameters.AddWithValue("@seguro_cesantia", segCesantia);




                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }

        public Hipotecario getHipotecario(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_hipotecario";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    var reader = cmd.ExecuteReader();
                    var mhipotecario = new Hipotecario();
                    while (reader.Read())
                    {
                        mhipotecario.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
                        mhipotecario.Vendedor = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_vendedor"].ToString()));
                        mhipotecario.Comprador = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_comprador"].ToString()));
                        mhipotecario.RutAcreedor = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_acreedor"].ToString()));
                        mhipotecario.NumeroInterno = reader["numero_interno"].ToString();
                        mhipotecario.MontoCredito = Convert.ToInt32(reader["monto_credito"].ToString());
                        mhipotecario.PrecioVivienda = Convert.ToInt32(reader["precio_vivienda"].ToString());
                        mhipotecario.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal"].ToString()));
                        mhipotecario.IdComuna = Convert.ToInt32(reader["id_comuna"].ToString());
                        mhipotecario.Complemento = reader["complemento"].ToString();
                        mhipotecario.Direccion = reader["direccion"].ToString();
                        mhipotecario.Numero = reader["numero"].ToString();
                        mhipotecario.VctoPrimeraCuota = reader["vencimiento_primera_cuota"].ToString();
                        mhipotecario.TipoPropiedad = reader["tipo_propiedad"].ToString();
                        mhipotecario.PlazoAnos = Convert.ToInt16(reader["plazo_anos"].ToString());
                        mhipotecario.TipoCredito = reader["tipo_credito"].ToString().Trim();
                        mhipotecario.Tasacion = Convert.ToInt32(reader["tasacion"].ToString());
                        mhipotecario.Ejecutivo = new UsuarioDAC().GetusuariobyUsername(reader["ejecutivo"].ToString().Trim());
                        mhipotecario.FinalCaratula = reader["final_caratula"].ToString().Trim();
                        mhipotecario.FinalConservador = reader["final_conservador"].ToString().Trim();
                        mhipotecario.MesesGracia = reader["meses_gracias"].ToString().Trim();
                        mhipotecario.ValorComercial = Convert.ToInt32(reader["valor_comercial"].ToString().Trim());
                        mhipotecario.DescripcionDeslindes = reader["descripcionDeslindes"].ToString();
                        mhipotecario.SubProductoCredito = reader["sub_producto_tipo_credito"].ToString();
                        mhipotecario.Tasa = reader["tasa"].ToString();

                        mhipotecario.NumeroCredito = reader["numero_credito"].ToString();
                        mhipotecario.Pie = reader["pie"].ToString();
                        mhipotecario.MesCarenciaUno = reader["mes_carencia_uno"].ToString();
                        mhipotecario.MesCarenciaDos = reader["mes_carencia_dos"].ToString();
                        mhipotecario.CodeudorConSeguro = Convert.ToByte(Convert.ToInt32(reader["codeudor_con_seguro"]));
                        mhipotecario.CodeudorPorcentaje = reader["porcentaje_seguro_codeudor"].ToString();
                        mhipotecario.Dfl2 = Convert.ToByte(Convert.ToInt32(reader["dfl2"]));
                        mhipotecario.TipoUbicacion = reader["tipo_ubicacion"].ToString();
                        mhipotecario.ViviendaSocial = Convert.ToByte(reader["vivienda_social"]);
                        mhipotecario.TipoTransferencia = reader["tipo_transferencia"].ToString();
                        mhipotecario.TipoHipoteca = reader["tipo_hipoteca"].ToString();
                        mhipotecario.FechaMemo = reader["fecha_memo"].ToString();
                        mhipotecario.SeguroInvalidez = Convert.ToByte(reader["seguro_invalidez"]);
                        mhipotecario.SeguroCesantia = Convert.ToByte(reader["seguro_desempleo"]);

                    }
                    return mhipotecario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Hipotecario> GetAllOperacionesSeleccionadas(Hipotecario h)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_operaciones_hipotecaSeleccionadas";
                    cmd.Parameters.AddWithValue("@id_solicitud", h.Operacion.Id_solicitud);
                    cmd.Parameters.AddWithValue("@cuenta_usuario_Ingreso", h.EjecutivoIngreso.UserName);
                    cmd.Parameters.AddWithValue("@tipo_operacion", h.Operacion.Tipo_operacion.Codigo);
                    cmd.Parameters.AddWithValue("@id_cliente", h.Operacion.Cliente.Id_cliente);
                    cmd.Parameters.AddWithValue("@id_sucursal", h.Operacion.Sucursal.Id_sucursal);
                    cmd.Parameters.AddWithValue("@fecha_desde", h.FechaDesde);
                    cmd.Parameters.AddWithValue("@fecha_hasta", h.FechaHasta);
                    cmd.Parameters.AddWithValue("@numeroCliente", h.Operacion.Numero_cliente);
                    cmd.Parameters.AddWithValue("@deudorRut", h.Vendedor.Rut);
                    cmd.Parameters.AddWithValue("@codigo_estado", h.Operacion.Id_estado);
                    cmd.Parameters.AddWithValue("@tipo_propiedad", h.TipoPropiedad);
                    cmd.Parameters.AddWithValue("@id_comuna", h.IdComuna);
                    cmd.Parameters.AddWithValue("@id_ciudad", h.Ciudad.Id_Ciudad);
                    cmd.Parameters.AddWithValue("@id_region", h.Region.Id_region);
                    cmd.Parameters.AddWithValue("@tipo_credito", h.TipoCredito);
                    cmd.Parameters.AddWithValue("@semaforo", h.SemaforoBusqueda);
                    cmd.Parameters.AddWithValue("@semaforoOperacion", h.SemaforoOperacion);
                    cmd.Parameters.AddWithValue("@cuentaUsuarioSesion", h.CuentaUsuarioSession);

                    var reader = cmd.ExecuteReader();
                    var lista = new List<Hipotecario>();
                    while (reader.Read())
                    {
                        var mhipotecario = new Hipotecario();
                        mhipotecario.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
                        mhipotecario.Vendedor = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_vendedor"].ToString()));
                        mhipotecario.Comprador = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_comprador"].ToString()));
                        mhipotecario.RutAcreedor = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_acreedor"].ToString()));
                        mhipotecario.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"].ToString()));
                        mhipotecario.IdComuna = Convert.ToInt32(reader["id_comuna"].ToString());
                        mhipotecario.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(mhipotecario.IdComuna));
                        mhipotecario.TipoPropiedad = reader["tipo_propiedad"].ToString();
                        mhipotecario.TipoCredito = reader["tipo_credito"].ToString().Trim();
                        mhipotecario.EjecutivoIngreso = new UsuarioDAC().GetusuariobyUsername(reader["UsuarioRut"].ToString().Trim());
                        mhipotecario.ContadorEtapa = Convert.ToInt32(reader["contador"]);
                        mhipotecario.ContadorOperacion = Convert.ToInt32(reader["total_dias"]);
                        mhipotecario.FechaIngreso = reader["fecha_solicitud"].ToString();
                        mhipotecario.SemaforoImagen = reader["semaforo"].ToString();
                        mhipotecario.Estado = reader["estado"].ToString();
                        mhipotecario.IdEstado = Convert.ToInt32(reader["id_estado"]);
                        mhipotecario.DescripcionTipoOperacion = reader["descripcionTipoOperacion"].ToString();
                        mhipotecario.SemaforoOperacionImagen = reader["semaforoOperacion"].ToString();
                        mhipotecario.Sla = Convert.ToInt32(reader["sla"]);
                        mhipotecario.SoloLectura = Convert.ToByte(reader["solo_lectura"]);
                        mhipotecario.OrdenEstadoActual = Convert.ToInt32(reader["OrdenEstado"]);
                        lista.Add(mhipotecario);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<Hipotecario> GetAllOperacionesSinSeleccionar(Hipotecario h)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_operaciones_hipotecaSinSeleccionar";
                    cmd.Parameters.AddWithValue("@id_solicitud", h.Operacion.Id_solicitud);
                    cmd.Parameters.AddWithValue("@cuenta_usuario_Ingreso", h.EjecutivoIngreso.UserName);
                    cmd.Parameters.AddWithValue("@tipo_operacion", h.Operacion.Tipo_operacion.Codigo);
                    cmd.Parameters.AddWithValue("@id_cliente", h.Operacion.Cliente.Id_cliente);
                    cmd.Parameters.AddWithValue("@id_sucursal", h.Operacion.Sucursal.Id_sucursal);
                    cmd.Parameters.AddWithValue("@fecha_desde", h.FechaDesde);
                    cmd.Parameters.AddWithValue("@fecha_hasta", h.FechaHasta);
                    cmd.Parameters.AddWithValue("@numeroCliente", h.Operacion.Numero_cliente);
                    cmd.Parameters.AddWithValue("@deudorRut", h.Vendedor.Rut);
                    cmd.Parameters.AddWithValue("@codigo_estado", h.Operacion.Id_estado);
                    cmd.Parameters.AddWithValue("@tipo_propiedad", h.TipoPropiedad);
                    cmd.Parameters.AddWithValue("@id_comuna", h.IdComuna);
                    cmd.Parameters.AddWithValue("@id_ciudad", h.Ciudad.Id_Ciudad);
                    cmd.Parameters.AddWithValue("@id_region", h.Region.Id_region);
                    cmd.Parameters.AddWithValue("@tipo_credito", h.TipoCredito);
                    cmd.Parameters.AddWithValue("@semaforo", h.SemaforoBusqueda);
                    cmd.Parameters.AddWithValue("@semaforoOperacion", h.SemaforoOperacion);
                    cmd.Parameters.AddWithValue("@cuentaUsuarioSesion", h.CuentaUsuarioSession);

                    var reader = cmd.ExecuteReader();
                    var lista = new List<Hipotecario>();
                    while (reader.Read())
                    {
                        var mhipotecario = new Hipotecario();
                        mhipotecario.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
                        mhipotecario.Vendedor = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_vendedor"].ToString()));
                        mhipotecario.Comprador = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_comprador"].ToString()));
                        mhipotecario.RutAcreedor = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_acreedor"].ToString()));
                        mhipotecario.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"].ToString()));
                        mhipotecario.IdComuna = Convert.ToInt32(reader["id_comuna"].ToString());
                        mhipotecario.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(mhipotecario.IdComuna));
                        mhipotecario.TipoPropiedad = reader["tipo_propiedad"].ToString();
                        mhipotecario.TipoCredito = reader["tipo_credito"].ToString().Trim();
                        mhipotecario.EjecutivoIngreso = new UsuarioDAC().GetusuariobyUsername(reader["UsuarioRut"].ToString().Trim());
                        mhipotecario.ContadorEtapa = Convert.ToInt32(reader["contador"]);
                        mhipotecario.ContadorOperacion = Convert.ToInt32(reader["total_dias"]);
                        mhipotecario.FechaIngreso = reader["fecha_solicitud"].ToString();
                        mhipotecario.SemaforoImagen = reader["semaforo"].ToString();
                        mhipotecario.Estado = reader["estado"].ToString();
                        mhipotecario.IdEstado = Convert.ToInt32(reader["id_estado"]);
                        mhipotecario.DescripcionTipoOperacion = reader["descripcionTipoOperacion"].ToString();
                        mhipotecario.SemaforoOperacionImagen = reader["semaforoOperacion"].ToString();
                        mhipotecario.Sla = Convert.ToInt32(reader["sla"]);
                        mhipotecario.SoloLectura = Convert.ToByte(reader["solo_lectura"]);
                        mhipotecario.OrdenEstadoActual = Convert.ToInt32(reader["OrdenEstado"]);
                        lista.Add(mhipotecario);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
