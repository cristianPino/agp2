using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class AlertaestadoFamiliaDAC : CACCESO.BaseDAC
	{





		public List<AlertaestadoFamilia> getRegla_EstadoFamilia(int id_familia,  int codigo_estado )
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getRegla_EstadoFamilia";
					    cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
					SqlDataReader reader = cmd.ExecuteReader();
					List<AlertaestadoFamilia> lEstadotipooperacion = new List<AlertaestadoFamilia>();
					while (reader.Read())
					{
						AlertaestadoFamilia mEstadotipooperacion = new AlertaestadoFamilia();


						mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
						
						mEstadotipooperacion.Estado_alerta = new EstadotipooperacionDAC().getEstadoBycodigo(Convert.ToInt16(reader["codigo_estado"]));
						mEstadotipooperacion.Id_familia = Convert.ToInt16(reader["id_familia"]);
						mEstadotipooperacion.Cheked = reader["check_regla"].ToString(); 

						lEstadotipooperacion.Add(mEstadotipooperacion);
						mEstadotipooperacion = null;
					}
					return lEstadotipooperacion;
				}





			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public string add_regla_estado_familia(Int16 codigo_estado, Int16 codigo_estado_regla)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_add_regla_estado_familia", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    oParam = Cmd.Parameters.AddWithValue("@codigo_estado_regla", codigo_estado_regla);


					Cmd.ExecuteNonQuery();

					sqlConn.Close();

				}
				catch (Exception ex)
				{
					throw ex;
				}

				return "";

			}
		}



		public string del_regla_estado_familia(Int16 codigo_estado, Int16 codigo_estado_alerta)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_del_regla_estado_familia", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    oParam = Cmd.Parameters.AddWithValue("@codigo_estado_regla", codigo_estado_alerta);


					Cmd.ExecuteNonQuery();

					sqlConn.Close();

				}
				catch (Exception ex)
				{
					throw ex;
				}

				return "";

			}
		}


		

		
	}
}