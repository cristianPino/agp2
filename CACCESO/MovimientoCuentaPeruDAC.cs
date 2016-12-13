using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class MovimientoCuentaPeruDAC : BaseDAC
	{
		public MovimientoCuentaPeru getMovimientocuentabyGasto(Int32 id_solicitud, string tipo_movimiento, Int16 id_tipogasto)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(strConn, cnn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_MovimientocuentabyGasto_Peru";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
					cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					SqlDataReader reader = cmd.ExecuteReader();
					MovimientoCuentaPeru mMovimientocuenta = new MovimientoCuentaPeru();
					if (reader.Read())
					{
						mMovimientocuenta.Cuenta_banco = new CuentabancoDAC().getCuentabanco(Convert.ToInt16(reader["id_Cuenta_banco"].ToString()));
						mMovimientocuenta.Documento_especial = reader["documento_especial"].ToString();
						mMovimientocuenta.Fecha_movimiento = Convert.ToDateTime(reader["fecha_movimiento"].ToString());
						mMovimientocuenta.Id_movimiento_cuenta = Convert.ToInt16(Convert.ToInt16(reader["id_movimiento_cuenta"].ToString()));
						mMovimientocuenta.Numero_documento = reader["numero_documento"].ToString();
						mMovimientocuenta.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
						mMovimientocuenta.Tipo_gasto = new TipoGastoPeruDAC().getTipoGastoPeru(Convert.ToInt16(reader["id_tipogasto"].ToString()));
						mMovimientocuenta.Tipo_movimiento = reader["tipo_movimiento"].ToString();
						mMovimientocuenta.Tipo_operacion = reader["tipo_operacion"].ToString();
						mMovimientocuenta.Monto = Convert.ToInt32(reader["monto"].ToString());
						mMovimientocuenta.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
					}
					else
					{
						mMovimientocuenta = null;
					}
					return mMovimientocuenta;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<MovimientoCuentaPeru> getMovimientocuenta(Int32 id_solicitud, string tipo_movimiento)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(strConn, cnn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_MovimientocuentabyIdSolicitud_Peru";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
					SqlDataReader reader = cmd.ExecuteReader();
					List<MovimientoCuentaPeru> lMovimientocuenta = new List<MovimientoCuentaPeru>();
					while (reader.Read())
					{
						MovimientoCuentaPeru mMovimientocuenta = new MovimientoCuentaPeru();
						mMovimientocuenta.Cuenta_banco = new CuentabancoDAC().getCuentabanco(Convert.ToInt16(reader["id_Cuenta_banco"].ToString()));
						mMovimientocuenta.Documento_especial = reader["documento_especial"].ToString();
						mMovimientocuenta.Fecha_movimiento = Convert.ToDateTime(reader["fecha_movimiento"].ToString());
						mMovimientocuenta.Id_movimiento_cuenta = Convert.ToInt32(reader["id_movimiento_cuenta"].ToString());
						mMovimientocuenta.Numero_documento = reader["numero_documento"].ToString();
						mMovimientocuenta.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
						mMovimientocuenta.Tipo_gasto = new TipoGastoPeruDAC().getTipoGastoPeru(Convert.ToInt16(reader["id_tipogasto"].ToString()));
						mMovimientocuenta.Tipo_movimiento = reader["tipo_movimiento"].ToString();
						mMovimientocuenta.Tipo_operacion = reader["tipo_operacion"].ToString();
						mMovimientocuenta.Monto = Convert.ToDouble(reader["monto"].ToString());
						mMovimientocuenta.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mMovimientocuenta.Tipo_gasto.Check = Convert.ToBoolean(reader["comun"].ToString());
						if (mMovimientocuenta.Tipo_gasto.Check == true)
						{
							GastosComunesPeru gc = new GastosComunesPeruDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
							TipoGastoPeru tg = new TipoGastoPeru();
							tg.Cargo_contable = gc.Cargo_contable;
							tg.Check = true;
							tg.Descripcion = gc.Descripcion;
							tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
							tg.Valor = gc.Valor;
							mMovimientocuenta.Tipo_gasto = tg;
						}
						lMovimientocuenta.Add(mMovimientocuenta);
						mMovimientocuenta = null;
					}
					return lMovimientocuenta;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_Movimientocuenta(Int16 id_Movimiento_cuenta, Int32 id_solicitud, Int16 id_cuenta_banco, Int16 id_tipogasto, string numero_documento, string tipo_movimiento, string tipo_operacion, string documento_especial, string cuenta_usuario, double monto, string chkgc)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_add_Movimientocuenta_Peru", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_movimiento_cuenta", id_Movimiento_cuenta);
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@id_cuenta_banco", id_cuenta_banco);
					cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					cmd.Parameters.AddWithValue("@numero_documento", numero_documento);
					cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@documento_especial", documento_especial);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@monto", monto);
					cmd.Parameters.AddWithValue("@chkgc", chkgc);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return "";
		}

		public string add_MovimientocuentaPagoCompleto(Int32 id_solicitud, Int16 id_cuenta_banco, string numero_documento, string tipo_operacion, string documento_especial, string cuenta_usuario)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_add_MovimientocuentaPagoCompleto_Peru", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@id_cuenta_banco", id_cuenta_banco);
					cmd.Parameters.AddWithValue("@numero_documento", numero_documento);
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					cmd.Parameters.AddWithValue("@documento_especial", documento_especial);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return "";
		}

		public string del_Movimientocuenta(Int32 id_Movimiento_cuenta, string chkgc)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_del_Movimientocuenta_Peru", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_movimiento_cuenta", id_Movimiento_cuenta);
					cmd.Parameters.AddWithValue("@chkgc", chkgc);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return "";
		}
	}
}