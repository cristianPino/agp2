using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ClienteConcesionarioDAC : CACCESO.BaseDAC
	{


		public List<ClienteConce> getclienteconcesionario(int id_cliente)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_get_clienteconcesionario";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

					SqlDataReader reader = cmd.ExecuteReader();

					List<ClienteConce> lClineteConcesionario = new List<ClienteConce>();

					while (reader.Read())
					{
						ClienteConce mClineteConcesionario = new ClienteConce();


						mClineteConcesionario.Codigo_concesionaria = reader["codigo_amicar"].ToString();
						mClineteConcesionario.Nombre = reader["Nombre"].ToString();



						lClineteConcesionario.Add(mClineteConcesionario);

						mClineteConcesionario = null;
					}
					return lClineteConcesionario;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		
	}
}