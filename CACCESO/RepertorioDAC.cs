using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class RepertorioDAC : BaseDAC
	{
		public int add_repertorio(string cuenta_usuario)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					int id_repertorio = 0;
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_repertorio", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader dr = cmd.ExecuteReader();
					if (dr.Read())
						id_repertorio = Convert.ToInt32(dr["id_repertorio"]);
					cnn.Close();
					return id_repertorio;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_repertorio_operacion(int id_repertorio, int id_solicitud)
		{
			string msj = "";
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_repertorio_operacion", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_repertorio", id_repertorio);
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
			}
			catch (Exception ex)
			{
				msj = ex.Message;
			}
			return msj;
		}
	}
}