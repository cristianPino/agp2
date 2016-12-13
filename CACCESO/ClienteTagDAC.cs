using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ClienteTagDAC : CACCESO.BaseDAC
	{


		public ClienteTag getclientetag(Int32 id_cliente, int id_familia)
		{

			try
			{


				
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_clientetag";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					ClienteTag mclientetag = new ClienteTag();
					if (reader.Read())
					{

						mclientetag.Monto = reader["Monto_cliente"].ToString();
						mclientetag.Montotag = reader["Monto_agp"].ToString();
						mclientetag.Id_familia = Convert.ToInt16(reader["id_familia"].ToString());

					


						return mclientetag;
					}

					else
					{
						mclientetag.Monto = "0";
					
					
					}
					return mclientetag;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ClienteTag> getclientetaglist(Int32 id_cliente, int id_familia,string tipo_operacion)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_clientetaglist";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);

					SqlDataReader reader = cmd.ExecuteReader();
					List<ClienteTag> lClientetag = new List<ClienteTag>();
					while (reader.Read())
					{
						ClienteTag mCliente = new ClienteTag();
						mCliente.Id_codigo =Convert.ToInt16(reader["id_tipogasto"].ToString());
						mCliente.Montotag = Convert.ToString(reader["valor"]);
						mCliente.Opcional = Convert.ToString(reader["opcional"]);
						mCliente.Nombre = reader["Descripcion"].ToString();
						lClientetag.Add(mCliente);
					}
					return lClientetag;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public string add_clientetag(int id_cliente, int monto_agp,int monto_cliente, int id_familia)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_clientetag", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					Cmd.Parameters.AddWithValue("@monto_agp", monto_agp);
					Cmd.Parameters.AddWithValue("@monto_cliente", monto_cliente);
					Cmd.Parameters.AddWithValue("@id_familia", id_familia);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}


		public string add_clientetagoperacion(int id_solicitud, int id_tipogasto, int montogasto)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_clientetagoperacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					Cmd.Parameters.AddWithValue("@montogasto", montogasto);
					
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}


		public string del_clientetagoperacion(int id_solicitud, int id_tipogasto)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_clientetagoperacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);

					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}


	}
}