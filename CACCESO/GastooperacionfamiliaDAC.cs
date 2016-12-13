using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{

	public class GastooperacionfamiliaDAC : CACCESO.BaseDAC
	{


		public string add_operacion_cliente_gasto_comun(string codigo, int id_cliente,  Int16 id_tipogasto)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_r_operacion_cliente_gasto_comun", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);


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



		public List<Gastooperacionfamilia> getEstadoByFamilia(string codigo,string cliente, string codpro)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_gasto_comun_operacion_cliente";
					cmd.Parameters.AddWithValue("@codigo", codpro);
					cmd.Parameters.AddWithValue("@cliente", cliente);
					cmd.Parameters.AddWithValue("@id_familia", codigo);

					SqlDataReader reader = cmd.ExecuteReader();
					List<Gastooperacionfamilia> lEstadotipooperacion = new List<Gastooperacionfamilia>();
					while (reader.Read())
					{
						Gastooperacionfamilia mEstadotipooperacion = new Gastooperacionfamilia();

						mEstadotipooperacion.Id_tipogasto = reader["id_tipogasto"].ToString();
						mEstadotipooperacion.Valor = Convert.ToInt32(reader["valor"]);
						mEstadotipooperacion.Descripcion=reader["descripcion"].ToString();
						mEstadotipooperacion.Cargo_cont = reader["cargo_contable"].ToString();
						mEstadotipooperacion.Transf=reader["transferencia"].ToString();
						
						mEstadotipooperacion.Id_familia = Convert.ToInt32(reader["id_familia"]);
						mEstadotipooperacion.Codigo = reader["codigo"].ToString();
						mEstadotipooperacion.Cheked = reader["check"].ToString();

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

		public string del_operacion_cliente_gasto_comun(string codigo, int id_cliente, Int16 id_tipogasto)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_del_operacion_cliente_gasto_comun", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);


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