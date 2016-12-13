using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO {
	public class PreinscripcionDAC : CACCESO.BaseDAC {

		public string add_Preinscripcion(Preinscripcion preinscripcion, Int32 id_solicitud) {
			double rut = 0;
			double rut_para = 0;
			if (preinscripcion.Adquiriente != null) { rut = preinscripcion.Adquiriente.Rut; }
			if (preinscripcion.Compra_para != null) { rut_para = preinscripcion.Compra_para.Rut; }
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_w_pinscripcion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    if (preinscripcion.N_factura != 0)
                        oParam = Cmd.Parameters.AddWithValue("@numero_factura", preinscripcion.N_factura);
					oParam = Cmd.Parameters.AddWithValue("@numero_poliza", preinscripcion.N_poliza);
					oParam = Cmd.Parameters.AddWithValue("@tag", preinscripcion.Tag);
					oParam = Cmd.Parameters.AddWithValue("@legalizar", preinscripcion.Legalizar);
					oParam = Cmd.Parameters.AddWithValue("@tipo_tramite", preinscripcion.Tipo_tramite);
					oParam = Cmd.Parameters.AddWithValue("@cargo_venta", preinscripcion.Cargo_venta);
                    if (preinscripcion.N_factura != 0)
                        oParam = Cmd.Parameters.AddWithValue("@fecha_factura", preinscripcion.Fechafactura);
					oParam = Cmd.Parameters.AddWithValue("@rut_cliente", rut);
					oParam = Cmd.Parameters.AddWithValue("@codigo_banco", preinscripcion.Bancofinanciera.Codigo);
					oParam = Cmd.Parameters.AddWithValue("@codigo_distribuidor", preinscripcion.Distribuidor_poliza.Codigo);
					oParam = Cmd.Parameters.AddWithValue("@rut_compra_para", rut_para);
					oParam = Cmd.Parameters.AddWithValue("@tipo_pago_factura", preinscripcion.Tipo_pago_factura);
					oParam = Cmd.Parameters.AddWithValue("@neto_factura", preinscripcion.Neto_factura);
					oParam = Cmd.Parameters.AddWithValue("@terminacion_especial", preinscripcion.Terminacion_especial);
					oParam = Cmd.Parameters.AddWithValue("@sucursal_origen", preinscripcion.Sucursal_origen.Id_sucursal);
					oParam = Cmd.Parameters.AddWithValue("@sucursal_destino", preinscripcion.Sucursal_destino.Id_sucursal);
					oParam = Cmd.Parameters.AddWithValue("@nota_venta", preinscripcion.Nota_venta);
					oParam = Cmd.Parameters.AddWithValue("@rut_vendedor", preinscripcion.Rut_vendedor);
                    oParam = Cmd.Parameters.AddWithValue("@cit", preinscripcion.Cit);
                    oParam = Cmd.Parameters.AddWithValue("@tieneImpuestoVerde", preinscripcion.TieneImpuestoVerde);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
				} catch (Exception ex) {
					throw ex;
				}
			}
			return "";
		}



        public string ValidaOperacionExistente(Int32 id_cliente, Int32 numero_factura, string tipo_operacion,
                                                string chassis)
        {

            string strRetorno ="";

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_ValidaOperacionExistente";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
                    cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    cmd.Parameters.AddWithValue("@chassis", chassis);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Preinscripcion mpreinscripcion = new Preinscripcion();
                    if (reader.Read())
                    {
                        if(reader["id_solicitud"].ToString()!="")
                        {
                            strRetorno = "Esta operacion es identica a la Nº" + reader["id_solicitud"].ToString();
                        }
                        
                    }
                   


                    return strRetorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        
        
        }

		public Preinscripcion GetpreinscripcionbyIdSolicitud(Int32 id_solicitud) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_preinscripcionbyIdSolicitud";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					Preinscripcion mpreinscripcion = new Preinscripcion();
					if (reader.Read()) {
						mpreinscripcion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
                        if (reader["n_factura"].ToString() != "")
                            mpreinscripcion.N_factura = Convert.ToInt32(reader["n_factura"]);
                        else
                            mpreinscripcion.N_factura = 0;
						mpreinscripcion.N_poliza = reader["n_poliza"].ToString();
						mpreinscripcion.Tag = reader["tag"].ToString();
						mpreinscripcion.Legalizar = reader["legalizar"].ToString();
                        mpreinscripcion.Cit = reader["cit"].ToString();
						mpreinscripcion.Tipo_tramite = reader["tipo_tramite"].ToString();
						mpreinscripcion.Cargo_venta = reader["cargo_venta"].ToString();
						if (reader["fecha_factura"].ToString() != "")
							mpreinscripcion.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]);
						else
							mpreinscripcion.Fechafactura = Convert.ToDateTime("01/01/1001");
						mpreinscripcion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_cliente"]));
						mpreinscripcion.Bancofinanciera = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());
						mpreinscripcion.Distribuidor_poliza = new DistribuidorpolizaDAC().getDistribuidorpoliza(reader["codigo_distribuidor"].ToString());
						mpreinscripcion.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_compra_para"]));
						mpreinscripcion.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mpreinscripcion.Neto_factura = Convert.ToDouble(reader["neto_factura"].ToString());
						mpreinscripcion.Terminacion_especial = reader["terminacion_especial"].ToString();
                        mpreinscripcion.TieneImpuestoVerde = Convert.ToString(reader["tiene_impuesto_verde"]);
						mpreinscripcion.Iva = Convert.ToInt16(reader["iva"].ToString());
						mpreinscripcion.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_origen"].ToString()));
						mpreinscripcion.Sucursal_destino = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_destino"].ToString()));
						mpreinscripcion.Dato_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						//mpreinscripcion.Pre_dato_vehiculo = new PredatovehiculoDAC().GetPredatovehiculobyIdSolicitud(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Nota_venta = Convert.ToDouble(reader["nota_venta"]);
						mpreinscripcion.Rut_vendedor = Convert.ToDouble(reader["rut_vendedor"]);
					} else { mpreinscripcion = null; }
					return mpreinscripcion;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public Preinscripcion Getpreinscripcionbyfactura(Int16 id_cliente, double factura) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_preinscripcionbyfactura";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@factura", factura);
					SqlDataReader reader = cmd.ExecuteReader();
					Preinscripcion mpreinscripcion = new Preinscripcion();
					if (reader.Read()) {
						mpreinscripcion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.N_factura = Convert.ToInt32(reader["n_factura"]);
						mpreinscripcion.N_poliza = reader["n_poliza"].ToString();
						mpreinscripcion.Tag = reader["tag"].ToString();
						mpreinscripcion.Legalizar = reader["legalizar"].ToString();
						mpreinscripcion.Tipo_tramite = reader["tipo_tramite"].ToString();
						mpreinscripcion.Cargo_venta = reader["cargo_venta"].ToString();
						mpreinscripcion.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]);
						mpreinscripcion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_cliente"]));
						mpreinscripcion.Bancofinanciera = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());
						mpreinscripcion.Distribuidor_poliza = new DistribuidorpolizaDAC().getDistribuidorpoliza(reader["codigo_distribuidor"].ToString());
						mpreinscripcion.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_compra_para"]));
						mpreinscripcion.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mpreinscripcion.Neto_factura = Convert.ToDouble(reader["neto_factura"].ToString());
						mpreinscripcion.Terminacion_especial = reader["terminacion_especial"].ToString();
						mpreinscripcion.Iva = Convert.ToInt16(reader["iva"].ToString());
						mpreinscripcion.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_origen"].ToString()));
						mpreinscripcion.Sucursal_destino = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_destino"].ToString()));
						//mpreinscripcion.Pre_dato_vehiculo = new PredatovehiculoDAC().GetPredatovehiculobyIdSolicitud(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Dato_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Nota_venta = Convert.ToDouble(reader["nota_venta"].ToString());
						mpreinscripcion.Rut_vendedor = Convert.ToDouble(reader["rut_vendedor"]);
					} else { mpreinscripcion = null; }
					return mpreinscripcion;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		//public Preinscripcion GetpreinscripcionbyfacturayTipo(Int16 id_cliente, double factura, string tipo_operacion)
		public Preinscripcion GetpreinscripcionbyfacturayTipo(Int16 id_cliente, double rut_emisor, double factura, string tipo_operacion)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_preinscripcionbyfacturaytipo";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@rut_vendedor", rut_emisor);
					cmd.Parameters.AddWithValue("@factura", factura);
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					SqlDataReader reader = cmd.ExecuteReader();
					Preinscripcion mpreinscripcion = new Preinscripcion();
					if (reader.Read())
					{
						mpreinscripcion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.N_factura = Convert.ToInt32(reader["n_factura"]);
						mpreinscripcion.N_poliza = reader["n_poliza"].ToString();
						mpreinscripcion.Tag = reader["tag"].ToString();
						mpreinscripcion.Legalizar = reader["legalizar"].ToString();
						mpreinscripcion.Tipo_tramite = reader["tipo_tramite"].ToString();
						mpreinscripcion.Cargo_venta = reader["cargo_venta"].ToString();
						mpreinscripcion.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]);
						mpreinscripcion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_cliente"]));
						mpreinscripcion.Bancofinanciera = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());
						mpreinscripcion.Distribuidor_poliza = new DistribuidorpolizaDAC().getDistribuidorpoliza(reader["codigo_distribuidor"].ToString());
						mpreinscripcion.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_compra_para"]));
						mpreinscripcion.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mpreinscripcion.Neto_factura = Convert.ToDouble(reader["neto_factura"].ToString());
						mpreinscripcion.Terminacion_especial = reader["terminacion_especial"].ToString();
						mpreinscripcion.Iva = Convert.ToInt16(reader["iva"].ToString());
						mpreinscripcion.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_origen"].ToString()));
						mpreinscripcion.Sucursal_destino = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_destino"].ToString()));
						//mpreinscripcion.Pre_dato_vehiculo = new PredatovehiculoDAC().GetPredatovehiculobyIdSolicitud(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Dato_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Nota_venta = Convert.ToDouble(reader["nota_venta"].ToString());
						mpreinscripcion.Rut_vendedor = Convert.ToDouble(reader["rut_vendedor"]);
					}
					else { mpreinscripcion = null; }
					return mpreinscripcion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Preinscripcion> getOperacionbyControl(Int16 id_cliente, Int16 id_modulo, Int16 id_sucursal, Int32 id_solicitud) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_OperacionbycontrolPI";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Preinscripcion> lpreinscripcion = new List<Preinscripcion>();
					while (reader.Read()) {
						Preinscripcion mpreinscripcion = new Preinscripcion();
						mpreinscripcion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.N_factura = Convert.ToInt32(reader["n_factura"]);
						mpreinscripcion.N_poliza = reader["n_poliza"].ToString();
						mpreinscripcion.Tag = reader["tag"].ToString();
						mpreinscripcion.Legalizar = reader["legalizar"].ToString();
						mpreinscripcion.Tipo_tramite = reader["tipo_tramite"].ToString();
						mpreinscripcion.Cargo_venta = reader["cargo_venta"].ToString();
						mpreinscripcion.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]);
						mpreinscripcion.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_cliente"]));
						mpreinscripcion.Bancofinanciera = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());
						mpreinscripcion.Distribuidor_poliza = new DistribuidorpolizaDAC().getDistribuidorpoliza(reader["codigo_distribuidor"].ToString());
						mpreinscripcion.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_compra_para"]));
						mpreinscripcion.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mpreinscripcion.Neto_factura = Convert.ToDouble(reader["neto_factura"].ToString());
						mpreinscripcion.Terminacion_especial = reader["terminacion_especial"].ToString();
						mpreinscripcion.Iva = Convert.ToInt16(reader["iva"].ToString());
						mpreinscripcion.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_origen"].ToString()));
						mpreinscripcion.Sucursal_destino = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["sucursal_destino"].ToString()));
						//mpreinscripcion.Pre_dato_vehiculo = new PredatovehiculoDAC().GetPredatovehiculobyIdSolicitud(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Dato_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mpreinscripcion.Nota_venta = Convert.ToDouble(reader["nota_venta"].ToString());
						lpreinscripcion.Add(mpreinscripcion);
					}
					return lpreinscripcion;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}