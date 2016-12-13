using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class OperacionDAC : CACCESO.BaseDAC
	{

	    public Operacion validaNumOperacionBanco(int numBanco, int numFactura)
	    {
	        try
	        {
	            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
	            {
	                sqlConn.Open();
	                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
	                cmd.CommandType = System.Data.CommandType.StoredProcedure;
	                cmd.CommandText = "validaNumOperacionBanco";
	                cmd.Parameters.AddWithValue("@numBanco", numBanco);
	                cmd.Parameters.AddWithValue("@numFactura", numFactura);
	                SqlDataReader reader = cmd.ExecuteReader();
	                Operacion mOperacion = new Operacion();
	                if (reader.Read())
	                {
	                    mOperacion.Numero_cliente = Convert.ToString(reader["numBanco"]);
	                }

	                sqlConn.Close();
	                return mOperacion;
	            }
	        }
	        catch (Exception ex)
	        {
	            throw ex;
	        }
	    }

	    public string del_impuesto_verde(Int32 id_solicitud, string usrname)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
                    SqlCommand Cmd = new SqlCommand("del_impuesto_verde", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@usrname", usrname);
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


        public void crear_garantias(Int32 id_solicitud)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
              
                    SqlCommand Cmd = new SqlCommand("crear_garantia_prohibicion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.ExecuteNonQuery();
                sqlConn.Close();
               
            }
           
        }




        public void AvanzarVs(int idSolicitud)
        {   //metodo provisorio para avanzar la busqueda de una página caida en infocar
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand("AVANZA_VESPUCIOSUR", sqlConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
        }

        public int reiniciar_operacion_infoauto(int id_solicitud)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
                    SqlCommand cmd = new SqlCommand("sp_reiniciar_operacion_infoauto", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
					int nTheNewId = 0;
					return nTheNewId;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}


        public List<Operacion> getOperacionesbyoperfacxmlHIP(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_getOperacionesbyfacxmlhip";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    SqlDataReader reader = cmd.ExecuteReader();


                    List<Operacion> loperacion = new List<Operacion>();

                    //  Operacion mOperacion = new Operacion();
                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cuenta_monto_factura = reader["plan_cuenta"].ToString().Trim();
                        mOperacion.Total_facturar = Convert.ToInt32(reader["total_facturar"].ToString().Trim());
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacion.Facturanav = reader["folionav"].ToString();
                        mOperacion.Observacion = reader["operacion"].ToString();
                        loperacion.Add(mOperacion);
                        mOperacion = null;
                    }

                    sqlConn.Close();
                    return loperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int32 add_operacion_habilitar(Int32 id_solicitud)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_U_Operacion_venta", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
					Int32 nTheNewId = 0;
					return nTheNewId;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public Int32 add_operacion(Int32 id_solicitud, Int16 id_cliente, string tipo_operacion, string cuenta_usuario, Int32 id_referencia,string n_interno,Int32 id_sucursal,Int32 n_factura ,string observacion)
		//public Int32 add_operacion(Int32 id_solicitud, Int16 id_cliente, string tipo_operacion, string cuenta_usuario, Int32 id_referencia, string proceso_AGP)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_w_Operacion", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					oParam = cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					oParam = cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = cmd.Parameters.AddWithValue("@id_referencia", id_referencia);
                    oParam = cmd.Parameters.AddWithValue("@numero_cliente", n_interno);
                    oParam = cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    oParam = cmd.Parameters.AddWithValue("@n_factura", n_factura);
                    oParam = cmd.Parameters.AddWithValue("@observacion", observacion);
					//oParam = cmd.Parameters.AddWithValue("@proceso_AGP", proceso_AGP);
					oParam = cmd.Parameters.AddWithValue("@folio", 0);
					oParam.Direction = ParameterDirection.Output;
					cmd.ExecuteNonQuery();
					Int32 nTheNewId = Convert.ToInt32(cmd.Parameters["@folio"].Value);
					sqlConn.Close();
					return nTheNewId;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

        public Int32 actualiza_producto(Int32 id_solicitud, string tipo_operacion, string cuenta_usuario, string financiera)
        //public Int32 add_operacion(Int32 id_solicitud, Int16 id_cliente, string tipo_operacion, string cuenta_usuario, Int32 id_referencia, string proceso_AGP)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_act_modifica_producto", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    oParam = cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = cmd.Parameters.AddWithValue("@financiera", financiera);

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return id_solicitud;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public List<Operacion> getOperaciones(string tipo_operacion,
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
                                                Int32 semaforo,
                                                string chassis,
                                                string motor,
                                                double rut_para)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 10000;

					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getOperaciones_prueba";
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);
					cmd.Parameters.AddWithValue("@familia", id_familia);
					cmd.Parameters.AddWithValue("@estado_proceso", estado_proceso);
                    cmd.Parameters.AddWithValue("@semaforo", semaforo);
                    cmd.Parameters.AddWithValue("@chassis", chassis);
                    cmd.Parameters.AddWithValue("@motor", motor);
                    cmd.Parameters.AddWithValue("@rut_para", rut_para);
					

					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();
					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new Cliente { Id_cliente = Convert.ToInt16(reader["id_cliente"]), Persona = new Persona { Nombre = reader["nom_cliente"].ToString() } };
                        mOperacion.Tipo_operacion = new TipoOperacion { Codigo = reader["tipo_operacion"].ToString(), Operacion = reader["operacion"].ToString(), Url_operacion = reader["url_operacion"].ToString() };
						mOperacion.Usuario = new Usuario{UserName = reader["cuenta_usuario"].ToString()};
						mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
						mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
						mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
						mOperacion.Total_devolucion = Convert.ToInt32(reader["total_devolucion"]);
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						if (reader["numero_factura"].ToString() != "")
							mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
						else
							mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
                        mOperacion.Adquiriente = new Persona { Rut = Convert.ToDouble(reader["rut_adquiriente"].ToString()), Nombre = reader["nombre_adquiriente"].ToString() };
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
                        mOperacion.Id_estado = Convert.ToInt32(reader["id_estado"].ToString());
						// mOperacion.Usuario.UserName = reader["cuenta_usuario"].ToString();
						mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());
                        mOperacion.Sucursal = new SucursalCliente { Id_sucursal = Convert.ToInt16(reader["sucursal"]), Nombre = reader["sucursal_nombre"].ToString() };

						mOperacion.EstadoAGP = new Estado_AGP{Id_solicitud= Convert.ToInt32(reader["id_solicitud"]),Repertorio_solicitado =Convert.ToBoolean(reader["repertorio_solicitado"].ToString())};
                        mOperacion.Semaforo = reader["semaforo"].ToString();
                        mOperacion.Contador = Convert.ToInt32(reader["contador"]);
                        mOperacion.Total_dias = Convert.ToInt32(reader["total_dias"]);
						mOperacion.N_repertorio = Convert.ToInt32(reader["n_repertorio"]);

						loperacion.Add(mOperacion);

						mOperacion = null;
					}
                    sqlConn.Close();
                    return loperacion;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<Operacion> getOperacionescarpeta(Int32 id_sucursal,
												Int32 numero_operacion,
                                                Int32 rut_adquiriente,
												string desde,
												string hasta,
												string cuenta_usuario,
                                                int numero_cliente        
												)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandTimeout = 5000;
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getOperacionescarpeta";
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
                    
					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();
					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new Cliente { Id_cliente = (Convert.ToInt16(reader["id_cliente"])), Persona = new Persona { Nombre = reader["nom_cliente"].ToString() } };
                        mOperacion.Tipo_operacion = new TipoOperacion { Codigo = (reader["tipo_operacion"].ToString()), Operacion = reader["operacion"].ToString() };
                        mOperacion.Usuario = new Usuario { UserName = (reader["cuenta_usuario"].ToString()), Nombre = reader["usuario"].ToString() };
                        mOperacion.Sucursal = new SucursalCliente { Id_sucursal = (Convert.ToInt16(reader["id_sucursal"].ToString())), Nombre = reader["sucursal"].ToString() };
                        mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Financiera = reader["financiera"].ToString();
                        mOperacion.Adquiriente = new Persona{ Rut = (Convert.ToDouble(reader["rut_adquiriente"])), Nombre = reader["nombre_adquiriente"].ToString(), Apellido_paterno = reader["apellido_paterno"].ToString(), Apellido_materno = reader["apellido_materno"].ToString()};
                        loperacion.Add(mOperacion);
                        
                        mOperacion = null;
					}
                    sqlConn.Close();
                    return loperacion;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

       public List<Operacion> sp_r_getOperacionesejecutivo(Int32 id_sucursal,
                                              Int32 numero_operacion,
                                              Int32 rut_adquiriente,
                                              string desde,
                                              string hasta,
                                              string cuenta_usuario,
                                              String numero_cliente
                                              )
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 5000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[sp_r_getOperacionesejecutivo]";
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
                    cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@patente", numero_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Operacion> loperacion = new List<Operacion>();
                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
                        mOperacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"].ToString()));
                        mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
                        mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
                        mOperacion.Financiera = reader["financiera"].ToString();
                        mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_adquiriente"].ToString()));
                        loperacion.Add(mOperacion);

                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public List<Operacion> getOperacionesTAG(Int32 id_sucursal,
                                              Int32 numero_operacion,
                                              Int32 rut_adquiriente,
                                              string desde,
                                              string hasta,
                                              string cuenta_usuario,
                                              Int32 numero_cliente,
                                              Int16 id_cliente  
                                              )
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 5000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getOperacionesTAG";
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
                    cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Operacion> loperacion = new List<Operacion>();
                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Id_cliente = Convert.ToInt32(reader["id_cliente"]);
                        mOperacion.Nom_cliente = reader["nombre_cliente"].ToString();
                        mOperacion.Producto = reader["operacion"].ToString();
                        mOperacion.Codigo_operacion = reader["tipo_operacion"].ToString();
                        mOperacion.Usuario = new Usuario{UserName = reader["cuenta_usuario"].ToString(), Nombre = reader["usuario"].ToString()};
                        mOperacion.Nom_sucursal = reader["sucursal"].ToString();
                        mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
                        mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
                        mOperacion.Adquiriente = new Persona{Rut =Convert.ToInt32(reader["rut_adquiriente"].ToString()),Nombre = reader["nombre"].ToString()};
                        mOperacion.Patente = reader["patente"].ToString();
                        mOperacion.Estado = reader["estado"].ToString();
                        mOperacion.Total_gasto = Convert.ToInt32(reader["n_agp_origen"].ToString());

                        loperacion.Add(mOperacion);

                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Operacion> getOpercarpEjecCliente(Int32 id_sucursal,
                                              Int32 numero_operacion,
                                              Int32 rut_adquiriente,
                                              string desde,
                                              string hasta,
                                              string cuenta_usuario,
                                              Int32 numero_cliente
                                              )
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 5000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getOperCarpEjectclie";
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
                    cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
                    

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Operacion> loperacion = new List<Operacion>();
                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
                        mOperacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"].ToString()));
                        mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
                        mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
                        mOperacion.Financiera = reader["financiera"].ToString();
                        mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut_adquiriente"].ToString()));
                        loperacion.Add(mOperacion);

                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      



		public List<OperacionPeru> getOperacionesPeru(string tipo_operacion,
												Int16 id_modulo,
												Int16 id_sucursal,
												Int16 id_cliente,
												Int32 numero_operacion,
												string rut_adquiriente,
												string numero_factura,
												string numero_cliente,
												string patente,
												string desde,
												string hasta,
												Int32 ultimo_estado,
												string cuenta_usuario,
												Int32 id_familia)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_getOperaciones_Peru";

					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);
					cmd.Parameters.AddWithValue("@familia", id_familia);

					SqlDataReader reader = cmd.ExecuteReader();

					List<OperacionPeru> loperacion = new List<OperacionPeru>();

					while (reader.Read())
					{
						OperacionPeru mOperacion = new OperacionPeru();

						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Total_gasto = Convert.ToDouble(reader["total_gasto"]);
						mOperacion.Total_ingreso = Convert.ToDouble(reader["total_ingreso"]);
						mOperacion.Total_egreso = Convert.ToDouble(reader["total_egreso"]);
						mOperacion.Total_devolucion = Convert.ToDouble(reader["total_devolucion"]);
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						mOperacion.Numero_factura = reader["numero_factura"].ToString();
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaPeruDAC().GetPersona(reader["rut_adquiriente"].ToString(), reader["tipo_documento"].ToString());
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
						// mOperacion.Usuario.UserName = reader["cuenta_usuario"].ToString();
						mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());

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

		public List<Operacion> getOperacionesbynomina(Int32 id_nomina, Int32 folio,
											   string cuenta_usuario)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 5000;
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getOperacionesbynomina";
					cmd.Parameters.AddWithValue("@folio", folio);
					cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();

					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
						mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
						mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
						mOperacion.Total_devolucion = Convert.ToInt32(reader["total_devolucion"]);
                        mOperacion.Total_facturar = Convert.ToInt32(reader["total_facturar"]);
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						if (reader["numero_factura"].ToString() != "") mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
						else mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
						mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());
						mOperacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal"]));

						mOperacion.EstadoAGP = new Estado_AGPDAC().get_estado_agp(Convert.ToInt32(reader["id_solicitud"]));

						mOperacion.N_repertorio = Convert.ToInt32(reader["n_repertorio"]);
                        mOperacion.Semaforo = reader["semaforo"].ToString();
                        mOperacion.Contador = Convert.ToInt32(reader["contador"]);
                        mOperacion.Total_dias = Convert.ToInt32(reader["total_dias"]);
						

						loperacion.Add(mOperacion);
						mOperacion = null;
					}
                    sqlConn.Close();
					return loperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public List<Operacion> getOperacionesbynominaExpress(Int32 id_nomina, Int32 folio,
                                               string cuenta_usuario)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_getOperacionesbynominaExpress";

                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Operacion> loperacion = new List<Operacion>();

                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cuenta_monto_factura = reader["plan_cuenta"].ToString().Trim();
                        mOperacion.Total_facturar = Convert.ToInt32(reader["total_facturar"].ToString().Trim());
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                      

                     

                        loperacion.Add(mOperacion);
                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Operacion getOperacionesbyoperfacxml(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_getOperacionesbyfacxml";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    SqlDataReader reader = cmd.ExecuteReader();

                        Operacion mOperacion = new Operacion();
                        if (reader.Read())
                        {
                            mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                            mOperacion.Cuenta_monto_factura = reader["plan_cuenta"].ToString().Trim();
                            mOperacion.Total_facturar = Convert.ToInt32(reader["total_facturar"].ToString().Trim());
                            mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                            mOperacion.Facturanav = reader["folionav"].ToString();
                            mOperacion.Observacion = reader["operacion"].ToString();
                        }

                        sqlConn.Close();
                        return mOperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public Operacion getOperacion(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_Operacion";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					Operacion mOperacion = new Operacion();
                    if (reader.Read())
                    {
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new Cliente { Id_cliente = (Convert.ToInt16(reader["id_cliente"])),Facturanav = reader["codigo_nav"].ToString(), Persona = new Persona { Nombre = reader["nom_cliente"].ToString(), Rut = Convert.ToDouble(reader["rut"]) } };
                        mOperacion.Tipo_operacion = new TipoOperacion { Codigo = (reader["tipo_operacion"].ToString()), Operacion = reader["operacion"].ToString(),Id_familia = Convert.ToInt32(reader["id_familia"].ToString()) };
                        mOperacion.Usuario = new Usuario { UserName = (reader["cuenta_usuario"].ToString()), Nombre = reader["usuario"].ToString() };
                        mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
                        mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
                        mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
                        mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
                        mOperacion.Sucursal = new SucursalCliente { Id_sucursal = (Convert.ToInt16(reader["id_sucursal"].ToString())), Nombre = reader["sucursal"].ToString() };
                        mOperacion.Observacion = reader["observacion"].ToString();
                        mOperacion.Adquiriente = new Persona {Rut = (Convert.ToDouble(reader["rut_adquiriente"])), Dv = reader["dv_adquiriente"].ToString(), Nombre = reader["adquiriente"].ToString(),Direccion = reader["direccion"].ToString(),Numero = reader["numero"].ToString()
                                                   ,Comuna = new Comuna {Id_Comuna = Convert.ToInt32(reader["id_comuna"].ToString()),Nombre=reader["comuna"].ToString(),Ciudad = new Ciudad {Id_Ciudad = Convert.ToInt32(reader["id_ciudad"].ToString())
                                                   ,Nombre = reader["ciudad"].ToString()} } };
                        mOperacion.usuarioImpuestoVerde = reader["usuarioImpuestoVerde"].ToString();
                        mOperacion.tipo_operacion_ = reader["tipo_operacion"].ToString();
                        mOperacion.Numero_factura = Convert.ToInt32(reader["factura"].ToString());

                    }
                    sqlConn.Close();
					return mOperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public Operacion getOperacionCreacionNomina(Int32 id_solicitud, Int32 id_cliente, Int32 id_familia)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_OperacionCreacionNomina";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Operacion mOperacion = new Operacion();
                    if (reader.Read())
                    {
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                        mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
                        mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
                        mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
                        mOperacion.Semaforo = reader["semaforo"].ToString();
                        mOperacion.Estado = reader["estado"].ToString();
                        
                        
                    }
                    else
                    {
                        mOperacion= null;
                    }

                    sqlConn.Close();
                    return mOperacion;

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Operacion getCruceFactura(Int32 factura, Int32 id_cliente, Int32 id_familia)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_OperacionCreacionNomina";
                    cmd.Parameters.AddWithValue("@factura", factura);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Operacion mOperacion = new Operacion();
                    if (reader.Read())
                    {
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                        mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
                        mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
                        mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
                        mOperacion.Estado = reader["estado"].ToString();


                    }
                    else
                    {
                        mOperacion = null;
                    }

                    sqlConn.Close();
                    return mOperacion;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public string del_peracion(Int32 id_solicitud,string usuario)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_operacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@usuario", usuario);
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

		public List<Control_gestion> getOperacionesbyGestionControl(string tipo_operacion, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_deudor, string numero_cliente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario, string check_llamada)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getOperacionesbyGC";
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_deudor", rut_deudor);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);
					cmd.Parameters.AddWithValue("@check_llamada", check_llamada);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Control_gestion> loperacion = new List<Control_gestion>();
					while (reader.Read())
					{
						Control_gestion mOperacion = new Control_gestion();
						mOperacion.Programacion = reader["llamada_programada"].ToString();
						mOperacion.Id_solicitud = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mOperacion.Id_solicitud.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Id_solicitud.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Id_solicitud.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Fecha_gestion = Convert.ToDateTime(reader["fecha"]);
						mOperacion.Rut = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_deudor"].ToString()));
						mOperacion.Id_solicitud.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Id_solicitud.Estado = reader["estado_actual"].ToString();
						mOperacion.Total_gestion = Convert.ToInt32(reader["total_gestion"].ToString());
						mOperacion.Numero_cuotas = Convert.ToInt32(reader["numero_cuotas"].ToString());
						mOperacion.Numero_operacion = reader["numero_operacion"].ToString();
						mOperacion.Id_producto_cliente = new ProdClienteDAC().getProductoClietne(Convert.ToInt32(reader["id_producto_cliente"].ToString()));
						mOperacion.Id_sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_origen"].ToString()));
						mOperacion.Programacion = reader["llamada_programada"].ToString();
						mOperacion.Id_forma_pago = new FormaPagoDAC().getformapago(Convert.ToInt32(reader["id_forma_pago"]));
						mOperacion.Cuenta_regresiva = Convert.ToInt32(reader["cuenta_regresiva"].ToString());
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Monto_final = Convert.ToInt32(reader["monto_final"]);

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


        public List<Transferencia> getOperacionesTR(string tipoOperacion,
                                                    Int16 idModulo,
                                                    Int16 idSucursal,
                                                    Int16 idCliente,
                                                    Int32 numeroOperacion,
                                                    double rutAdquiriente,
                                                    Int32 numeroFactura,
                                                    string numeroCliente,
                                                    string patente,
                                                    string desde,
                                                    string hasta,
                                                    Int32 ultimoEstado,
                                                    string cuentaUsuario)
        {


            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_r_getOperacionesTR" };

                cmd.Parameters.AddWithValue("@tipo_operacion", tipoOperacion);
                cmd.Parameters.AddWithValue("@id_modulo", idModulo);
                cmd.Parameters.AddWithValue("@id_sucursal", idSucursal);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@id_solicitud", numeroOperacion);
                cmd.Parameters.AddWithValue("@rut_adquiriente", rutAdquiriente);
                cmd.Parameters.AddWithValue("@numero_factura", numeroFactura);
                cmd.Parameters.AddWithValue("@numero_cliente", numeroCliente);
                cmd.Parameters.AddWithValue("@patente", patente);
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@ultimo_estado", ultimoEstado);


                var reader = cmd.ExecuteReader();

                var ltransferencia = new List<Transferencia>();

                while (reader.Read())
                {
                    var mtransferencia = new Transferencia();

                    mtransferencia.Operacion = new Operacion { Id_solicitud = Convert.ToInt32(reader["id_solicitud"]), Tipo_operacion = new TipoOperacion { Codigo = reader["tipo_operacion"].ToString(), Operacion = reader["producto"].ToString(), Url_operacion = reader["url_operacion"].ToString() } };
                    mtransferencia.Operacion.Cliente = new Cliente{ Id_cliente = Convert.ToInt16(reader["id_cliente"]),Persona =new Persona{Nombre=reader["nom_cliente"].ToString()}};
                    mtransferencia.Operacion.Tipo_operacion = new TipoOperacion { Codigo = reader["tipo_operacion"].ToString(),Operacion = reader["producto"].ToString(),Url_operacion=reader["url_operacion"].ToString() };
                    mtransferencia.Operacion.Total_gasto = Convert.ToInt32(reader["total_gasto"].ToString());
                    mtransferencia.Operacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"].ToString());
                    mtransferencia.Patente = reader["patente"].ToString();
                    mtransferencia.Operacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
                    mtransferencia.Operacion.Estado = reader["estado_actual"].ToString();
                    mtransferencia.Operacion.Id_estado = Convert.ToInt32(reader["codigo_estado"]);
                    mtransferencia.Tasacion = 0;
                    mtransferencia.Id_sucursal = Convert.ToInt32(reader["sucursal_origen"].ToString());
                    mtransferencia.Operacion.Nom_sucursal = reader["sucursal"].ToString();
                    mtransferencia.Operacion.Usuario = new Usuario { UserName = Convert.ToString(reader["cuenta_usuario"]), Nombre = Convert.ToString(reader["nombre_usuario"]) };
                    mtransferencia.Check = Convert.ToBoolean(reader["bloqueo"].ToString());
                    mtransferencia.Ejecutivo = new Usuario { Nombre = Convert.ToString(reader["nombre_ejecutivo"]) };
                    ltransferencia.Add(mtransferencia);

                }
                sqlConn.Close();
                return ltransferencia;
            }
        }



		public List<Transferencia> getOperacionesSocktVenta(string tipo_operacion,
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
											   string cuenta_usuario)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 5000;
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_getOperacionesStockVenta";

					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);

					SqlDataReader reader = cmd.ExecuteReader();

					List<Transferencia> ltransferencia = new List<Transferencia>();

					while (reader.Read())
					{
						Transferencia mtransferencia = new Transferencia();


						mtransferencia.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
						mtransferencia.Operacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mtransferencia.Operacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mtransferencia.Operacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mtransferencia.Operacion.Total_gasto = Convert.ToInt32(reader["total_gasto"].ToString());
						mtransferencia.Vendedor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_vendedor"].ToString()));
						mtransferencia.Patente = reader["patente"].ToString();
						mtransferencia.Comprador = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_comprador"].ToString()));
						mtransferencia.Operacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mtransferencia.Operacion.Estado = reader["estado_actual"].ToString();
						mtransferencia.Tasacion = Convert.ToInt32(reader["tasacion"].ToString());
						mtransferencia.PrecioVenta = Convert.ToInt32(reader["precio_venta"].ToString());
						mtransferencia.Id_sucursal = Convert.ToInt32(reader["sucursal_origen"].ToString());
						mtransferencia.Habilitada = Convert.ToBoolean(reader["habilitada"].ToString());


						ltransferencia.Add(mtransferencia);

						mtransferencia = null;
					}
                    sqlConn.Close();
					return ltransferencia;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Transferencia> getOperacionesVenta(string tipo_operacion,
											   Int16 id_modulo,
											   Int16 id_sucursal,
											   Int16 id_cliente,
											   Int32 numero_operacion,
											   Int32 rut_adquiriente,
											   Int32 numero_factura,
											   string numero_cliente,
											   string patente,
											   string desde,
											   string hasta,
											   Int32 ultimo_estado,
											   string cuenta_usuario)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 5000;
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
					cmd.CommandText = "sp_r_getOperacionesVenta";

					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);

					SqlDataReader reader = cmd.ExecuteReader();

					List<Transferencia> ltransferencia = new List<Transferencia>();

					while (reader.Read())
					{
						Transferencia mtransferencia = new Transferencia();


						mtransferencia.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
						mtransferencia.Operacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mtransferencia.Operacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mtransferencia.Operacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mtransferencia.Operacion.Total_gasto = Convert.ToInt32(reader["total_gasto"].ToString());
						mtransferencia.Vendedor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_vendedor"].ToString()));
						mtransferencia.Patente = reader["patente"].ToString();
						mtransferencia.Comprador = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_comprador"].ToString()));
						mtransferencia.Operacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mtransferencia.Operacion.Estado = reader["estado_actual"].ToString();
						mtransferencia.Tasacion = Convert.ToInt32(reader["tasacion"].ToString());
						mtransferencia.PrecioVenta = Convert.ToInt32(reader["precio_venta"].ToString());
						mtransferencia.Id_sucursal = Convert.ToInt32(reader["sucursal_origen"].ToString());

						ltransferencia.Add(mtransferencia);

						mtransferencia = null;
					}
                    sqlConn.Close();
					return ltransferencia;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Operacion> getOperacionesfacturacion(Int32 folio, string desde, string hasta, Int32 id_familia, Int32 id_nomina, string id_factura, Int32 factura_agp)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 5000;

					cmd.CommandText = "sp_r_getOperacionesfacturacion";
					cmd.Parameters.AddWithValue("@folio", folio);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					cmd.Parameters.AddWithValue("@id_factura", id_factura);
					cmd.Parameters.AddWithValue("@factura_agp", factura_agp);


					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();
					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
						mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
						mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
						mOperacion.Total_devolucion = Convert.ToInt32(reader["total_devolucion"]);
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						if (reader["numero_factura"].ToString() != "")
							mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
						else
							mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
						// mOperacion.Usuario.UserName = reader["cuenta_usuario"].ToString();
						mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());

						loperacion.Add(mOperacion);
						mOperacion = null;
					}
                    sqlConn.Close();
					return loperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public List<Operacion> getOperacionesGA(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 5000;
					cmd.CommandText = "sp_r_getOperacionesGA";
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();
					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						if (reader["numero_factura"].ToString() != "")
							mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
						else
							mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						loperacion.Add(mOperacion);
						mOperacion = null;
					}
                    sqlConn.Close();
					return loperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Operacion> getOperacionesGA_Pendientes(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 5000;
					cmd.CommandText = "sp_r_getOperacionesGA_Pendientes";
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();
					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						if (reader["numero_factura"].ToString() != "")
							mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
						else
							mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.P_completado = Convert.ToDouble(reader["p_completado"]);
						loperacion.Add(mOperacion);
						mOperacion = null;
					}
                    sqlConn.Close();
					return loperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Operacion> getOperaciones_patente(string tipo_operacion,
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
												Int32 id_familia)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_getOperaciones_patente";

					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_solicitud", numero_operacion);
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
					cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);
					cmd.Parameters.AddWithValue("@familia", id_familia);

					SqlDataReader reader = cmd.ExecuteReader();

					List<Operacion> loperacion = new List<Operacion>();

					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();


						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
						mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
						mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
						mOperacion.Total_devolucion = Convert.ToInt32(reader["total_devolucion"]);
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						if (reader["numero_factura"].ToString() != "")
							mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
						else
							mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
						// mOperacion.Usuario.UserName = reader["cuenta_usuario"].ToString();
						mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());


						loperacion.Add(mOperacion);

						mOperacion = null;
					}
                    sqlConn.Close();
					return loperacion;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Operacion> getOperacionesParaNomina(int id_nomina, int id_cliente, DateTime desde, DateTime hasta, string cuenta_usuario)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_getOperacionesParaNomina", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

					SqlDataReader reader = cmd.ExecuteReader();

					List<Operacion> loperacion = null;

					if (reader.HasRows)
					{
						loperacion = new List<Operacion>();
						while (reader.Read())
						{
							Operacion mOperacion = new Operacion();

							mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
							mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
							mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
							mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
							if (reader["numero_factura"].ToString() != "")
								mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
							else
								mOperacion.Numero_factura = 0;
							mOperacion.Patente = reader["patente"].ToString();
							mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
							mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
							mOperacion.Estado = reader["estado_actual"].ToString();
							loperacion.Add(mOperacion);
							mOperacion = null;
						}
					}
					cnn.Close();
					return loperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<OperacionPeru> getOperacionesfacturacionPeru(Int32 folio, string desde, string hasta, Int32 id_familia, Int32 id_nomina, string id_factura, Int32 factura_agp)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getOperacionesfacturacion";
					cmd.Parameters.AddWithValue("@folio", folio);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					cmd.Parameters.AddWithValue("@id_factura", id_factura);
					cmd.Parameters.AddWithValue("@factura_agp", factura_agp);


					SqlDataReader reader = cmd.ExecuteReader();
					List<OperacionPeru> loperacion = new List<OperacionPeru>();

					while (reader.Read())
					{
						OperacionPeru mOperacion = new OperacionPeru();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
						mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
						mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
						mOperacion.Total_devolucion = Convert.ToInt32(reader["total_devolucion"]);
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						if (reader["numero_factura"].ToString() != "")
							mOperacion.Numero_factura = reader["numero_factura"].ToString();
						else
							mOperacion.Numero_factura = "0";
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaPeruDAC().GetPersona(reader["rut_adquiriente"].ToString(), reader["tipo_documento"].ToString());
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
						// mOperacion.Usuario.UserName = reader["cuenta_usuario"].ToString();
						mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());

						loperacion.Add(mOperacion);
						mOperacion = null;

					}
                    sqlConn.Close();
					return loperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public List<Operacion> getOperacionesBCA()
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GetCreditosCA";
					cmd.CommandTimeout = 0;

					SqlDataReader reader = cmd.ExecuteReader();
					List<Operacion> loperacion = new List<Operacion>();
					while (reader.Read())
					{
						Operacion mOperacion = new Operacion();
						mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
						mOperacion.Total_gasto = 0;
						mOperacion.Total_ingreso = 0;
						mOperacion.Total_egreso = 0;
						mOperacion.Total_devolucion = 0;
						mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
						mOperacion.Numero_factura = 0;
						mOperacion.Patente = reader["patente"].ToString();
						mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
						mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
						mOperacion.Estado = reader["estado_actual"].ToString();
						// mOperacion.Usuario.UserName = reader["cuenta_usuario"].ToString();
						mOperacion.Factura_emitida = 0;


						loperacion.Add(mOperacion);

						mOperacion = null;
					}
                    sqlConn.Close();
					return loperacion;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<Operacion> getOperacionesbynominagasto(Int32 id_nomina, Int32 folio,
                                           string cuenta_usuario)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_getOperacionesbynominagasto";

                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Operacion> loperacion = new List<Operacion>();

                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacion.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacion.Tipo_operacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mOperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["id_solicitud"].ToString());
                        mOperacion.Total_gasto = Convert.ToInt32(reader["total_gasto"]);
                        mOperacion.Total_ingreso = Convert.ToInt32(reader["total_ingreso"]);
                        mOperacion.Total_egreso = Convert.ToInt32(reader["total_egreso"]);
                        mOperacion.Total_devolucion = Convert.ToInt32(reader["total_devolucion"]);
                        mOperacion.Numero_cliente = reader["numero_cliente"].ToString();
                        if (reader["numero_factura"].ToString() != "") mOperacion.Numero_factura = Convert.ToInt32(reader["numero_factura"]);
                        else mOperacion.Numero_factura = 0;
                        mOperacion.Patente = reader["patente"].ToString();
                        mOperacion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_adquiriente"].ToString()));
                        mOperacion.Fecha_solicitud = Convert.ToDateTime(reader["fecha_solicitud"]);
                        mOperacion.Estado = reader["estado_actual"].ToString();
                        mOperacion.Factura_emitida = Convert.ToInt32(reader["factura_emitida"].ToString());
                        mOperacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal"]));
                        mOperacion.EstadoAGP = new Estado_AGPDAC().get_estado_agp(Convert.ToInt32(reader["id_solicitud"]));
                        mOperacion.Familia = reader["familia"].ToString();
                        mOperacion.Folio =Convert.ToInt32(reader["folio"].ToString());
                        mOperacion.N_repertorio = Convert.ToInt32(reader["n_repertorio"]);
                        mOperacion.Semaforo = reader["semaforo"].ToString();
                        mOperacion.Contador = Convert.ToInt32(reader["contador"]);
                        mOperacion.Total_dias = Convert.ToInt32(reader["total_dias"]);
                        

                        loperacion.Add(mOperacion);
                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Operacion> Operacionesnomina_desde_hasta(Int32 id_familia, Int32 id_cliente, string desde, string hasta)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_tiponomina_by_desde_hasta";

                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Operacion> loperacion = new List<Operacion>();

                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        //mOperacion.Estado = reader["disponible"].ToString();
                        loperacion.Add(mOperacion);

                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Operacion> get_ChequeInventario()
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_get_cheque_inventario";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Operacion> loperacion = new List<Operacion>();

                    while (reader.Read())
                    {
                        Operacion mOperacion = new Operacion();
                        mOperacion.Num_cheque = reader["numero_cheque"].ToString();
                        mOperacion.Id_inventario = Convert.ToInt32(reader["id_inventario"]);
                        loperacion.Add(mOperacion);
                        mOperacion = null;
                    }
                    sqlConn.Close();
                    return loperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 Actualizar_ChequeInventario(Int32 folio, Int32 id_inventario, Int32 id_nomina)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_update_cheque_inventario", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@folio", folio);
                    oParam = cmd.Parameters.AddWithValue("@id_inventario", id_inventario);
                    oParam = cmd.Parameters.AddWithValue("@id_nomina", id_nomina);

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public List<Operacion> getOperacionesbynominaExpressacum(Int32 id_nomina, Int32 folio,
                                                                 string cuenta_usuario)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_getOperacionesbynominaExpressacum";

                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Operacion> loperacionacum = new List<Operacion>();

                    while (reader.Read())
                    {
                        Operacion mOperacionacum = new Operacion();
                        //mOperacionacum.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mOperacionacum.Cuenta_monto_factura = reader["plan_cuenta"].ToString().Trim();
                        mOperacionacum.Total_facturar = Convert.ToInt32(reader["total_facturar"].ToString().Trim());
                        mOperacionacum.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mOperacionacum.Observacion = reader["operacion"].ToString().Trim();
                        mOperacionacum.Contador = Convert.ToInt32(reader["cantidad"].ToString().Trim());
                        mOperacionacum.Monto = Convert.ToInt32(reader["monto"].ToString().Trim());

                        loperacionacum.Add(mOperacionacum);
                        mOperacionacum = null;
                    }
                    sqlConn.Close();
                    return loperacionacum;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





	}
}