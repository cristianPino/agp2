using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;


namespace CACCESO
{
	public class ClienteBancoFinancieraDAC : CACCESO.BaseDAC
	{

		public List<ClienteFinancieraCliente> getallBancofinanciera(string codigo, Int32 id_cliente)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_bancofinanciera";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					SqlDataReader reader = cmd.ExecuteReader();
					List<ClienteFinancieraCliente> lBancofinanciera = new List<ClienteFinancieraCliente>();
					while (reader.Read())
					{
						ClienteFinancieraCliente mBancofinanciera = new ClienteFinancieraCliente();
						mBancofinanciera.Codigo = reader["codigo_banco"].ToString().Trim();
						mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
						lBancofinanciera.Add(mBancofinanciera);
						mBancofinanciera = null;
					}
					return lBancofinanciera;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		
	}
}

