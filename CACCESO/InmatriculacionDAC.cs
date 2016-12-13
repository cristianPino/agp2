using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class InmatriculacionDAC:BaseDAC
	{
		public string AddInmatriculacion(Inmatriculacion inmatriculacion)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_inmatriculacion", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", inmatriculacion.Operacion.Id_solicitud);
					cmd.Parameters.AddWithValue("@nro_documento_identidad_com", inmatriculacion.Comprador.NroDocumentoIdentidad);
					cmd.Parameters.AddWithValue("@tipo_documento_identidad_com", inmatriculacion.Comprador.TipoDocumentoIdentidad);
					if (inmatriculacion.Representante != null)
					{
						cmd.Parameters.AddWithValue("@nro_documento_identidad_rep", inmatriculacion.Representante.NroDocumentoIdentidad);
						cmd.Parameters.AddWithValue("@tipo_documento_identidad_rep", inmatriculacion.Representante.TipoDocumentoIdentidad);
					}
					else
					{
						cmd.Parameters.AddWithValue("@nro_documento_identidad_rep", DBNull.Value);
						cmd.Parameters.AddWithValue("@tipo_documento_identidad_rep", DBNull.Value);
					}
					cmd.Parameters.AddWithValue("@numero_nota_pedido", inmatriculacion.NumeroNotaPedido);
					cmd.Parameters.AddWithValue("@numero_documento_venta", inmatriculacion.NumeroDocumentoVenta);
					cmd.Parameters.AddWithValue("@fecha_emision_documento_venta", inmatriculacion.FechaEmisionDocumentoVenta);
					cmd.Parameters.AddWithValue("@monto_total_vehiculo", inmatriculacion.MontoTotalVehiculo);
					cmd.Parameters.AddWithValue("@tipo_moneda", inmatriculacion.TipoMoneda);
					cmd.Parameters.AddWithValue("@categoria_mtc", inmatriculacion.CategoriaMtc);
					cmd.Parameters.AddWithValue("@uso_mtc", inmatriculacion.UsoMtc);
					cmd.Parameters.AddWithValue("@asesor_comercial", inmatriculacion.AsesorComercial);
					cmd.Parameters.AddWithValue("@administrador_venta", inmatriculacion.AdministradorVenta);
					cmd.Parameters.AddWithValue("@forma_pago", inmatriculacion.FormaPago);
					cmd.Parameters.AddWithValue("@id_sucursal", inmatriculacion.Sucursal.Id_sucursal);
					cmd.Parameters.AddWithValue("@codigo_banco", inmatriculacion.Financiera.Codigo);
					cmd.Parameters.AddWithValue("@obs_fp", inmatriculacion.Obs_fp);
					cmd.Parameters.AddWithValue("@cargo_venta", inmatriculacion.Cargo_venta);
					cmd.Parameters.AddWithValue("@numero_titulo", inmatriculacion.Numero_titulo);
					cmd.Parameters.AddWithValue("@obs_operacion", inmatriculacion.Obs_operacion);
					cmd.Parameters.AddWithValue("@partida_electronica", inmatriculacion.Partida_electronica);
					cmd.Parameters.AddWithValue("@ficha_nro", inmatriculacion.Ficha_nro);
					cmd.Parameters.AddWithValue("@tomo", inmatriculacion.Tomo);
					cmd.Parameters.AddWithValue("@fojas", inmatriculacion.Fojas);
					cmd.Parameters.AddWithValue("@oficina_registral", inmatriculacion.Oficina_registral);
                    cmd.Parameters.AddWithValue("@dua", inmatriculacion.Dua);
                    cmd.Parameters.AddWithValue("@separacion_bienes", inmatriculacion.Separacion_bienes);
                    cmd.Parameters.AddWithValue("@ofic_reg_bienes", inmatriculacion.Ofic_reg_bienes);
                    cmd.Parameters.AddWithValue("@part_elect_bienes", inmatriculacion.Part_elect_bienes);
                    cmd.Parameters.AddWithValue("@vendedor", inmatriculacion.Vendedor);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return "";
		}

		public Inmatriculacion GetInmatriculacion(int id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_get_inmatriculacion", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = cmd.ExecuteReader();
					Inmatriculacion inmatriculacion = new Inmatriculacion();
					if (dr.Read())
					{
						inmatriculacion.Operacion = new OperacionDAC().getOperacion(id_solicitud);
						inmatriculacion.Comprador = new PersonaPeruDAC().GetPersona(dr["nro_documento_identidad_com"].ToString(), dr["tipo_documento_identidad_com"].ToString());
						inmatriculacion.Representante = new PersonaPeruDAC().GetPersona(dr["nro_documento_identidad_rep"].ToString(), dr["tipo_documento_identidad_rep"].ToString());
						inmatriculacion.NumeroNotaPedido = dr["numero_nota_pedido"].ToString();
						inmatriculacion.NumeroDocumentoVenta = dr["numero_documento_venta"].ToString();
						inmatriculacion.FechaEmisionDocumentoVenta = Convert.ToDateTime(dr["fecha_emision_documento_venta"]);
						inmatriculacion.MontoTotalVehiculo = Convert.ToDecimal(dr["monto_total_vehiculo"]);
						inmatriculacion.TipoMoneda = dr["tipo_moneda"].ToString();
						inmatriculacion.CategoriaMtc = dr["categoria_mtc"].ToString();
						inmatriculacion.UsoMtc = dr["uso_mtc"].ToString();
						inmatriculacion.AsesorComercial = dr["asesor_comercial"].ToString();
						inmatriculacion.AdministradorVenta = dr["administrador_venta"].ToString();
						inmatriculacion.FormaPago = dr["forma_pago"].ToString();
						inmatriculacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(dr["id_sucursal"]));
						inmatriculacion.Financiera = new BancofinancieraDAC().getBancofinanciera(dr["codigo_banco"].ToString());
						inmatriculacion.Obs_fp = dr["obs_fp"].ToString();
						inmatriculacion.Cargo_venta = dr["cargo_venta"].ToString();
						inmatriculacion.Numero_titulo = (dr["numero_titulo"] != DBNull.Value) ? Convert.ToDouble(dr["numero_titulo"]) : 0;
						inmatriculacion.Obs_operacion = dr["obs_operacion"].ToString();
						inmatriculacion.Partida_electronica = dr["partida_electronica"].ToString();
						inmatriculacion.Ficha_nro = dr["ficha_nro"].ToString();
						inmatriculacion.Tomo = dr["tomo"].ToString();
						inmatriculacion.Fojas = dr["fojas"].ToString();
						inmatriculacion.Oficina_registral = dr["oficina_registral"].ToString();
                        inmatriculacion.Dua =Convert.ToBoolean(dr["dua"].ToString());
                        inmatriculacion.Separacion_bienes =Convert.ToBoolean(dr["separacion_bienes"].ToString());
                        inmatriculacion.Ofic_reg_bienes = dr["ofic_reg_bienes"].ToString();
                        inmatriculacion.Part_elect_bienes = dr["part_elect_bienes"].ToString();
                        inmatriculacion.Vendedor = dr["vendedor"].ToString();
					}
					dr.Close();
					sqlConn.Close();
					return inmatriculacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Inmatriculacion GetInmatriculacionByNotaPedido(Int16 id_cliente, string nota_venta)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_get_inmatriculacion_by_nota_pedido", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@numero_nota_pedido", nota_venta);
					SqlDataReader dr = cmd.ExecuteReader();
					Inmatriculacion inmatriculacion = new Inmatriculacion();
					if (dr.Read())
					{
						inmatriculacion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(dr["id_solicitud"]));
						inmatriculacion.Comprador = new PersonaPeruDAC().GetPersona(dr["nro_documento_identidad_com"].ToString(), dr["tipo_documento_identidad_com"].ToString());
						inmatriculacion.Representante = new PersonaPeruDAC().GetPersona(dr["nro_documento_identidad_rep"].ToString(), dr["tipo_documento_identidad_rep"].ToString());
						inmatriculacion.NumeroNotaPedido = dr["numero_nota_pedido"].ToString();
						inmatriculacion.NumeroDocumentoVenta = dr["numero_documento_venta"].ToString();
						inmatriculacion.FechaEmisionDocumentoVenta = Convert.ToDateTime(dr["fecha_emision_documento_venta"]);
						inmatriculacion.MontoTotalVehiculo = Convert.ToDecimal(dr["monto_total_vehiculo"]);
						inmatriculacion.TipoMoneda = dr["tipo_moneda"].ToString();
						inmatriculacion.CategoriaMtc = dr["categoria_mtc"].ToString();
						inmatriculacion.UsoMtc = dr["uso_mtc"].ToString();
						inmatriculacion.AsesorComercial = dr["asesor_comercial"].ToString();
						inmatriculacion.AdministradorVenta = dr["administrador_venta"].ToString();
						inmatriculacion.FormaPago = dr["forma_pago"].ToString();
						inmatriculacion.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(dr["id_sucursal"]));
						inmatriculacion.Financiera = new BancofinancieraDAC().getBancofinanciera(dr["codigo_banco"].ToString());
						inmatriculacion.Cargo_venta = dr["cargo_venta"].ToString();
						inmatriculacion.Numero_titulo = (dr["numero_titulo"] != DBNull.Value) ? Convert.ToDouble(dr["numero_titulo"]) : 0;
						inmatriculacion.Obs_operacion = dr["obs_operacion"].ToString();
						inmatriculacion.Partida_electronica = dr["partida_electronica"].ToString();
						inmatriculacion.Ficha_nro = dr["ficha_nro"].ToString();
						inmatriculacion.Tomo = dr["tomo"].ToString();
						inmatriculacion.Fojas = dr["fojas"].ToString();
						inmatriculacion.Oficina_registral = dr["oficina_registral"].ToString();
                        inmatriculacion.Dua = Convert.ToBoolean(dr["dua"].ToString());
                        inmatriculacion.Separacion_bienes = Convert.ToBoolean(dr["separacion_bienes"].ToString());
                        inmatriculacion.Ofic_reg_bienes = dr["ofic_reg_bienes"].ToString();
                        inmatriculacion.Part_elect_bienes = dr["part_elect_bienes"].ToString();
                        inmatriculacion.Vendedor = dr["vendedor"].ToString();
					}
					dr.Close();
					sqlConn.Close();
					return inmatriculacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}