using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class BancoClienteDAC : CACCESO.BaseDAC
	{

		

		public List<BancoCliente> getbancobycliente( string cliente)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_get_Banco_Cliente";

					cmd.Parameters.AddWithValue("@cliente", cliente);

					SqlDataReader reader = cmd.ExecuteReader();

					List<BancoCliente> lgasto = new List<BancoCliente>();

					while (reader.Read())
					{
						BancoCliente mbancocliente = new BancoCliente();

						mbancocliente.Codigo_banco = reader["codigo_banco"].ToString();
						mbancocliente.Id_cliente = reader["id_cliente"].ToString(); ;
						mbancocliente.Nombre = reader["nombre"].ToString(); ;
						mbancocliente.Check = reader["check"].ToString();
						
						lgasto.Add(mbancocliente);

						mbancocliente = null;
					}
					return lgasto;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_banco_cliente(string codigo, int id_cliente)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_banco_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
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

		public string del_banco_cliente(string codigo, int id_cliente)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_banco_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
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