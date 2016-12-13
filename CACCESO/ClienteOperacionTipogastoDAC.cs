using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ClienteOperacionTipogastoDAC : CACCESO.BaseDAC
    {
		
		public List<ClienteOperacionTipogasto> GetClienteOperaciontipogasto(int id_cliente, int id_familia, string codpro, int codigo)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_Cliente_Tipooperacion_Gasto";
					cmd.Parameters.AddWithValue("@cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@codpro", codpro);
					cmd.Parameters.AddWithValue("@id_gasto", codigo);    

					SqlDataReader reader = cmd.ExecuteReader();
					List<ClienteOperacionTipogasto> lTipogasto = new List<ClienteOperacionTipogasto>();
					while (reader.Read())
					{
						ClienteOperacionTipogasto mTipogasto = new ClienteOperacionTipogasto();
						mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
						mTipogasto.Descripcion = reader["descripcion"].ToString();
						mTipogasto.Check = Convert.ToBoolean(reader["check"].ToString());
						
						lTipogasto.Add(mTipogasto);
						mTipogasto = null;
					}
					return lTipogasto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public string add_cliente_operacion_tipogasto(int id_cliente, int id_familia, string codpro,int codigo)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_add_cliente_familia_tipogasto", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					
					Cmd.Parameters.AddWithValue("@id_familia", id_familia);
					oParam = Cmd.Parameters.AddWithValue("@codpro", codpro);
					oParam = Cmd.Parameters.AddWithValue("@id_gasto", codigo);

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


		public string del_cliente_operacion_tipogasto(int id_cliente, int id_familia, string codpro, int codigo)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_del_CLIENTE_TIPOOPERACION_TIPOGASTOCOMUN", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

					Cmd.Parameters.AddWithValue("@id_familia", id_familia);
					oParam = Cmd.Parameters.AddWithValue("@codpro", codpro);
					oParam = Cmd.Parameters.AddWithValue("@id_gasto", codigo);
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


		public List<ClienteOperacionTipogasto> GetOperaciontipogasto(int id_familia, string codpro)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_Tipooperacion_Gasto";
					cmd.Parameters.AddWithValue("@codpro", codpro);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<ClienteOperacionTipogasto> lTipogasto = new List<ClienteOperacionTipogasto>();
					while (reader.Read())
					{
						ClienteOperacionTipogasto mTipogasto = new ClienteOperacionTipogasto();
						mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
						mTipogasto.Descripcion = reader["descripcion"].ToString();
						mTipogasto.Check = Convert.ToBoolean(reader["check"].ToString());

						lTipogasto.Add(mTipogasto);
						mTipogasto = null;
					}
					return lTipogasto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public string add_operacion_tipogasto( int id_gasto, string codpro)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_add_familia_tipogasto", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codpro", codpro);
					
					oParam = Cmd.Parameters.AddWithValue("@id_gasto", id_gasto);

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


		public string del_operacion_tipogasto( string codpro, int id_gasto)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_del_TIPOOPERACION_TIPOGASTOCOMUN", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codpro", codpro);

					Cmd.Parameters.AddWithValue("@id_gasto", id_gasto);
					
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


    }
}