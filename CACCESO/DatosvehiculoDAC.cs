using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;


namespace CACCESO {
	public class DatosvehiculoDAC : CACCESO.BaseDAC {

		public string add_Datosvehiculo(Int32 id_solicitud, Marcavehiculo marca, Tipovehiculo tipo_vehiculo, string patente, string dv,
										string modelo, string chassis, string motor, string vin, string serie, int ano,
                                        string cilindraje, string color, int carga, int pesobruto, string combustible, int npuerta,
                                        int nasiento,Int32 kilometraje,Int32 precio_venta,Int32 tasacion,string codigo_SII,
                                        Int32 id_dato_vehiculo,string forma_pago,DateTime fecha_contrato,string prenda,string estado_vehiculo,
										Int32 rut_prenda, string financiamiento_amicar,string transmision, string equipamiento)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_add_Datosvehiculo", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = Cmd.Parameters.AddWithValue("@id_marca_vehiculo", marca.Id_marca);
					oParam = Cmd.Parameters.AddWithValue("@codigo", tipo_vehiculo.Codigo);
					oParam = Cmd.Parameters.AddWithValue("@patente", patente);
					oParam = Cmd.Parameters.AddWithValue("@dv", dv);
					oParam = Cmd.Parameters.AddWithValue("@modelo", modelo);
					oParam = Cmd.Parameters.AddWithValue("@chassis", chassis);
					oParam = Cmd.Parameters.AddWithValue("@motor", motor);
					oParam = Cmd.Parameters.AddWithValue("@vin", vin);
					oParam = Cmd.Parameters.AddWithValue("@serie", serie);
					oParam = Cmd.Parameters.AddWithValue("@ano", ano);
					oParam = Cmd.Parameters.AddWithValue("@cilindraje", cilindraje);
					oParam = Cmd.Parameters.AddWithValue("@color", color);
					oParam = Cmd.Parameters.AddWithValue("@carga", carga);
					oParam = Cmd.Parameters.AddWithValue("@pesobruto", pesobruto);
					oParam = Cmd.Parameters.AddWithValue("@combustible", combustible);
					oParam = Cmd.Parameters.AddWithValue("@npuerta", npuerta);
					oParam = Cmd.Parameters.AddWithValue("@nasiento", nasiento);
                    oParam = Cmd.Parameters.AddWithValue("@kilometraje", kilometraje);
                    oParam = Cmd.Parameters.AddWithValue("@precio", precio_venta);
                    oParam = Cmd.Parameters.AddWithValue("@tasacion", tasacion);
                    oParam = Cmd.Parameters.AddWithValue("@codigoSII", codigo_SII);
                    oParam = Cmd.Parameters.AddWithValue("@id_dato_vehiculo", id_dato_vehiculo);
                    oParam = Cmd.Parameters.AddWithValue("@forma_pago", forma_pago);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_contrato", fecha_contrato);
                    oParam = Cmd.Parameters.AddWithValue("@prenda", prenda);
                    oParam = Cmd.Parameters.AddWithValue("@estado_vehiculo", estado_vehiculo);
                    oParam = Cmd.Parameters.AddWithValue("@rut_prenda",rut_prenda);
					oParam = Cmd.Parameters.AddWithValue("@financiamiento_amicar", financiamiento_amicar);
                    oParam = Cmd.Parameters.AddWithValue("@transmision", transmision);
                    oParam = Cmd.Parameters.AddWithValue("@equipamiento", equipamiento);
                    
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				} catch (Exception ex) {
					return ex.Message;
				}
			}
		}

		public DatosVehiculo getDatoVehiculo(Int32 id_solicitud) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_Datosvehiculo";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					DatosVehiculo mDatosvehiculo = new DatosVehiculo();
                    if (reader.Read())
                    {
                        mDatosvehiculo.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mDatosvehiculo.Marca = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt32(reader["id_marca_vehiculo"]));
                        mDatosvehiculo.Tipo_vehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                        mDatosvehiculo.Patente = reader["patente"].ToString();
                        mDatosvehiculo.Dv = reader["dv"].ToString();
                        mDatosvehiculo.Modelo = reader["modelo"].ToString();
                        mDatosvehiculo.Chassis = reader["chassis"].ToString();
                        mDatosvehiculo.Motor = reader["motor"].ToString();
                        mDatosvehiculo.Vin = reader["vin"].ToString();
                        mDatosvehiculo.Serie = reader["serie"].ToString();
                        mDatosvehiculo.Ano = Convert.ToInt32(reader["ano"]);
                        mDatosvehiculo.Cilindraje = reader["cilindraje"].ToString();
                        mDatosvehiculo.Color = reader["color"].ToString();
                        mDatosvehiculo.Carga = Convert.ToInt32(reader["carga"]);
                        mDatosvehiculo.Pesobruto = Convert.ToInt32(reader["pesobruto"]);
                        mDatosvehiculo.Combustible = reader["combustible"].ToString();
                        mDatosvehiculo.Npuerta = Convert.ToInt32(reader["npuerta"]);
                        mDatosvehiculo.Nasiento = Convert.ToInt32(reader["nasiento"]);
                        mDatosvehiculo.Kilometraje = Convert.ToInt32(reader["kilometraje"]);
                        mDatosvehiculo.Tasacion = Convert.ToInt32(reader["tasacion"]);
                        mDatosvehiculo.Codigo_SII = reader["codigoSII"].ToString();
                        mDatosvehiculo.Precio = Convert.ToInt32(reader["precio"]);
                        mDatosvehiculo.Id_dato_vehiculo = Convert.ToInt32(reader["id_dato_vehiculo"]);
                        mDatosvehiculo.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
                        mDatosvehiculo.Prenda = reader["prenda"].ToString();
                        mDatosvehiculo.Forma_pago = reader["forma_pago"].ToString();
                        mDatosvehiculo.Estado_vehiculo = reader["estado_analisis"].ToString();
                        mDatosvehiculo.Rut_prenda = Convert.ToInt32(reader["rut_prenda"].ToString());
                        mDatosvehiculo.Financiamiento_amicar = reader["fina_externo"].ToString();
                        mDatosvehiculo.Transmision = reader["transmision"].ToString();
                        mDatosvehiculo.Equipamiento = reader["equipamiento"].ToString();

                    }
                    else
                    {
                        mDatosvehiculo = null;
                    }
					return mDatosvehiculo;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<DatosVehiculo> getDatosvehiculo(Int32 id_solicitud) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_Datosvehiculo";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					List<DatosVehiculo> lDatosvehiculo = new List<DatosVehiculo>();
					while (reader.Read()) {
						DatosVehiculo mDatosvehiculo = new DatosVehiculo();
						mDatosvehiculo.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mDatosvehiculo.Marca = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt32(reader["id_marca_vehiculo"]));
						mDatosvehiculo.Tipo_vehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
						mDatosvehiculo.Patente = reader["patente"].ToString();
						mDatosvehiculo.Dv = reader["dv"].ToString();
						mDatosvehiculo.Modelo = reader["modelo"].ToString();
						mDatosvehiculo.Chassis = reader["chassis"].ToString();
						mDatosvehiculo.Motor = reader["motor"].ToString();
						mDatosvehiculo.Vin = reader["vin"].ToString();
						mDatosvehiculo.Serie = reader["serie"].ToString();
						mDatosvehiculo.Ano = Convert.ToInt32(reader["ano"]);
						mDatosvehiculo.Cilindraje = reader["cilindraje"].ToString();
						mDatosvehiculo.Color = reader["color"].ToString();
						mDatosvehiculo.Carga = Convert.ToInt32(reader["carga"]);
						mDatosvehiculo.Pesobruto = Convert.ToInt32(reader["pesobruto"]);
						mDatosvehiculo.Combustible = reader["combustible"].ToString();
						mDatosvehiculo.Npuerta = Convert.ToInt32(reader["npuerta"]);
						mDatosvehiculo.Nasiento = Convert.ToInt32(reader["nasiento"]);
                        mDatosvehiculo.Kilometraje = Convert.ToInt32(reader["kilometraje"]);
                        mDatosvehiculo.Tasacion = Convert.ToInt32(reader["tasacion"]);
                        mDatosvehiculo.Codigo_SII= reader["codigoSII"].ToString();
                        mDatosvehiculo.Precio = Convert.ToInt32(reader["precio"]);
                        mDatosvehiculo.Id_dato_vehiculo = Convert.ToInt32(reader["id_dato_vehiculo"]);
                        mDatosvehiculo.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
                        mDatosvehiculo.Prenda = reader["prenda"].ToString();
                        mDatosvehiculo.Forma_pago = reader["forma_pago"].ToString();
                        mDatosvehiculo.Estado_vehiculo = reader["estado_analisis"].ToString();
						mDatosvehiculo.Rut_prenda = Convert.ToInt32(reader["rut_prenda"].ToString());
                        mDatosvehiculo.Transmision = reader["transmision"].ToString();
                        mDatosvehiculo.Equipamiento = reader["equipamiento"].ToString();

						lDatosvehiculo.Add(mDatosvehiculo);
						mDatosvehiculo = null;
					}
					return lDatosvehiculo;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<string> getListaModelosVehiculos(string modelo) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_ListaModelosVehiculos";
					cmd.Parameters.AddWithValue("@modelo", modelo);
					SqlDataReader reader = cmd.ExecuteReader();
					List<string> lModelos = new List<string> { };
					while (reader.Read()) {
						lModelos.Add(reader[0].ToString().ToUpper());
					}
					return lModelos;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<string> getListaColoresVehiculos(string color) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_ListaColoresVehiculos";
					cmd.Parameters.AddWithValue("@color", color);
					SqlDataReader reader = cmd.ExecuteReader();
					List<string> lColores = new List<string> { };
					while (reader.Read()) {
						lColores.Add(reader[0].ToString().ToUpper());
					}
					return lColores;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

        public string del_vehiculos(int id_solicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_Datosvehiculo", sqlConn);
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

        public string del_vehiculos_id(int id_dato_vehiculo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_Datosvehiculo_id", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_dato_vehiculo", id_dato_vehiculo);


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
        public DatosVehiculo getDatoVehiculobypatente(string patente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Datosvehiculobypatente";
                    cmd.Parameters.AddWithValue("@patente", patente);
                    SqlDataReader reader = cmd.ExecuteReader();
					DatosVehiculo mDatosvehiculo = null;
					if (reader.HasRows)
					{
						mDatosvehiculo = new DatosVehiculo();
                        if (reader.Read())
                        {
                            mDatosvehiculo.Id_dato_vehiculo = Convert.ToInt32(reader["id_dato_vehiculo"]);
                            mDatosvehiculo.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                            mDatosvehiculo.Marca = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt32(reader["id_marca_vehiculo"]));
                            mDatosvehiculo.Tipo_vehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                            mDatosvehiculo.Patente = reader["patente"].ToString();
                            mDatosvehiculo.Dv = reader["dv"].ToString();
                            mDatosvehiculo.Modelo = reader["modelo"].ToString();
                            mDatosvehiculo.Chassis = reader["chassis"].ToString();
                            mDatosvehiculo.Motor = reader["motor"].ToString();
                            mDatosvehiculo.Vin = reader["vin"].ToString();
                            mDatosvehiculo.Serie = reader["serie"].ToString();
                            mDatosvehiculo.Ano = Convert.ToInt32(reader["ano"]);
                            mDatosvehiculo.Cilindraje = reader["cilindraje"].ToString();
                            mDatosvehiculo.Color = reader["color"].ToString();
                            mDatosvehiculo.Carga = Convert.ToInt32(reader["carga"]);
                            mDatosvehiculo.Pesobruto = Convert.ToInt32(reader["pesobruto"]);
                            mDatosvehiculo.Combustible = reader["combustible"].ToString();
                            mDatosvehiculo.Npuerta = Convert.ToInt32(reader["npuerta"]);
                            mDatosvehiculo.Nasiento = Convert.ToInt32(reader["nasiento"]);
                            mDatosvehiculo.Kilometraje = Convert.ToInt32(reader["kilometraje"]);
                            mDatosvehiculo.Tasacion = Convert.ToInt32(reader["tasacion"]);
                            mDatosvehiculo.Codigo_SII = reader["codigoSII"].ToString();
                            mDatosvehiculo.Precio = Convert.ToInt32(reader["precio"]);
                            mDatosvehiculo.Id_dato_vehiculo = Convert.ToInt32(reader["id_dato_vehiculo"]);
                            mDatosvehiculo.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
                            mDatosvehiculo.Prenda = reader["prenda"].ToString();
                            mDatosvehiculo.Forma_pago = reader["forma_pago"].ToString();
                            mDatosvehiculo.Estado_vehiculo = reader["estado_analisis"].ToString();
                            mDatosvehiculo.Rut_prenda = Convert.ToInt32(reader["rut_prenda"].ToString());
                            mDatosvehiculo.Transmision = reader["transmision"].ToString();
                            mDatosvehiculo.Equipamiento = reader["equipamiento"].ToString();
                        }
                        else
                        {
                            mDatosvehiculo = null;
                        }
						reader.Close();
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


		public DatosVehiculo getDatovehiculobyPatente_id_solicitud(string patente, Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_DatovehiculobyPatente_id_vehiculo";
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

					SqlDataReader reader = cmd.ExecuteReader();
					DatosVehiculo mDatosvehiculo;
						mDatosvehiculo = new DatosVehiculo();
						if (reader.Read())
						{
							mDatosvehiculo.Id_dato_vehiculo = Convert.ToInt32(reader["id_dato_vehiculo"]);
							mDatosvehiculo.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
							mDatosvehiculo.Marca = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt32(reader["id_marca_vehiculo"]));
							mDatosvehiculo.Tipo_vehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
							mDatosvehiculo.Patente = reader["patente"].ToString();
							mDatosvehiculo.Dv = reader["dv"].ToString();
							mDatosvehiculo.Modelo = reader["modelo"].ToString();
							mDatosvehiculo.Chassis = reader["chassis"].ToString();
							mDatosvehiculo.Motor = reader["motor"].ToString();
							mDatosvehiculo.Vin = reader["vin"].ToString();
							mDatosvehiculo.Serie = reader["serie"].ToString();
							mDatosvehiculo.Ano = Convert.ToInt32(reader["ano"]);
							mDatosvehiculo.Cilindraje = reader["cilindraje"].ToString();
							mDatosvehiculo.Color = reader["color"].ToString();
							mDatosvehiculo.Carga = Convert.ToInt32(reader["carga"]);
							mDatosvehiculo.Pesobruto = Convert.ToInt32(reader["pesobruto"]);
							mDatosvehiculo.Combustible = reader["combustible"].ToString();
							mDatosvehiculo.Npuerta = Convert.ToInt32(reader["npuerta"]);
							mDatosvehiculo.Nasiento = Convert.ToInt32(reader["nasiento"]);
							mDatosvehiculo.Kilometraje = Convert.ToInt32(reader["kilometraje"]);
							mDatosvehiculo.Tasacion = Convert.ToInt32(reader["tasacion"]);
							mDatosvehiculo.Codigo_SII = reader["codigoSII"].ToString();
							mDatosvehiculo.Precio = Convert.ToInt32(reader["precio"]);
							mDatosvehiculo.Id_dato_vehiculo = Convert.ToInt32(reader["id_dato_vehiculo"]);
							mDatosvehiculo.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
							mDatosvehiculo.Prenda = reader["prenda"].ToString();
							mDatosvehiculo.Forma_pago = reader["forma_pago"].ToString();
							mDatosvehiculo.Estado_vehiculo = reader["estado_analisis"].ToString();
							mDatosvehiculo.Rut_prenda = Convert.ToInt32(reader["rut_prenda"].ToString());
                            mDatosvehiculo.Transmision = reader["transmision"].ToString();
                            mDatosvehiculo.Equipamiento = reader["equipamiento"].ToString();
						}
						else
						{
							mDatosvehiculo = null;
						}
						reader.Close();
						sqlConn.Close();
						return mDatosvehiculo;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



	}
}