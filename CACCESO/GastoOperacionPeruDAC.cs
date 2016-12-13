using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class GastoOperacionPeruDAC : BaseDAC
	{
		public string AddGastoOperacion(Int32 id_solicitud, Int16 id_tipo_gasto, double monto, string cuenta_usuario, double cargo_cliente, double cargo_empresa, string chkgc)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_GastoOperacionPeru", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipo_gasto);
					Cmd.Parameters.AddWithValue("@monto", monto);
					Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					Cmd.Parameters.AddWithValue("@cargo_cliente", cargo_cliente);
					Cmd.Parameters.AddWithValue("@cargo_empresa", cargo_empresa);
					Cmd.Parameters.AddWithValue("@chkgc", chkgc);
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

		public string DelGastoOperacion(Int32 id_solicitud, Int16 id_tipo_gasto, string chkgc)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_GastoOperacionPeru", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipo_gasto);
					Cmd.Parameters.AddWithValue("@chkgc", chkgc);
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

		public List<GastoOperacionPeru> GetGastoOperacion(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastoOperacionPeru";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					List<GastoOperacionPeru> lgasto = new List<GastoOperacionPeru>();
					while (reader.Read())
					{
						GastoOperacionPeru mgasto = new GastoOperacionPeru();
						mgasto.Monto = Convert.ToDouble(reader["monto"]);

						mgasto.Tipogasto = new TipoGastoPeruDAC().getTipoGastoPeru(Convert.ToInt16(reader["id_tipogasto"]));
						mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mgasto.Check = Convert.ToBoolean(reader["check"]);
						mgasto.Cargo_cliente = Convert.ToDouble(reader["cargo_cliente"]);
						mgasto.Cargo_empresa = Convert.ToDouble(reader["cargo_empresa"]);
						mgasto.Tipogasto.Check = Convert.ToBoolean(reader["comun"]);
						mgasto.Bloqueo = Convert.ToBoolean(reader["bloqueo"]);
						if (mgasto.Tipogasto.Check == true)
						{
							GastosComunesPeru gc = new GastosComunesPeruDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
							TipoGastoPeru tg = new TipoGastoPeru();
							tg.Cargo_contable = gc.Cargo_contable;
							tg.Check = true;
							tg.Descripcion = gc.Descripcion;
							tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
							tg.Valor = gc.Valor;
							mgasto.Tipogasto = tg;
						}
						lgasto.Add(mgasto);
						mgasto = null;
					}
					return lgasto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<GastoOperacionPeru> GetGastoOperacionMovimiento(Int32 id_solicitud, string tipo_movimiento)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastoOperacionMovimientoPeru";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
					SqlDataReader reader = cmd.ExecuteReader();
					List<GastoOperacionPeru> lgasto = new List<GastoOperacionPeru>();
					while (reader.Read())					{
						GastoOperacionPeru mgasto = new GastoOperacionPeru();
						mgasto.Monto = Convert.ToDouble(reader["monto"].ToString());
						mgasto.Tipogasto = new TipoGastoPeruDAC().getTipoGastoPeru(Convert.ToInt16(reader["id_tipogasto"].ToString()));
						mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mgasto.Check = Convert.ToBoolean(reader["check"].ToString());
						mgasto.Cargo_cliente = Convert.ToDouble(reader["cargo_cliente"].ToString());
						mgasto.Cargo_empresa = Convert.ToDouble(reader["cargo_empresa"].ToString());
						mgasto.Tipogasto.Check = Convert.ToBoolean(reader["comun"].ToString());
						if (mgasto.Tipogasto.Check == true)
						{
							GastosComunesPeru gc = new GastosComunesPeruDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
							TipoGastoPeru tg = new TipoGastoPeru();
							tg.Cargo_contable = gc.Cargo_contable;
							tg.Check = true;
							tg.Descripcion = gc.Descripcion;
							tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
							tg.Valor = gc.Valor;
							mgasto.Tipogasto = tg;
						}
						lgasto.Add(mgasto);
						mgasto = null;
					}
					return lgasto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}