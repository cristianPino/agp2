using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ParticipanteDAC : CACCESO.BaseDAC
	{

		public List<Participante> GetParticipante(double rut_persona)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GetParticipantes";
					cmd.Parameters.AddWithValue("@rut_persona", rut_persona);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Participante> lParticipante = new List<Participante>();
					while (reader.Read())
					{
						Participante mParticipante = new Participante();
						mParticipante.Persona = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut"]));
						mParticipante.Participe = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_participante"]));
						mParticipante.Tipo = reader["tipo"].ToString();
						mParticipante.Firma = Convert.ToBoolean(reader["firma"].ToString());
						mParticipante.Ciudad_notario = reader["ciudad_notario"].ToString();
						mParticipante.Notario_publico = reader["notario_publico"].ToString();
						mParticipante.Fecha_participante = reader["fecha_personeria"].ToString();
						lParticipante.Add(mParticipante);
						mParticipante = null;
					}
					return lParticipante;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_Participante(double rut_persona, double rut_participe, string tipo_participe, Boolean firma, string ciudad_notario, string notario_publico, DateTime fecha_personeria)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_Participe", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@rut_persona", rut_persona);
					Cmd.Parameters.AddWithValue("@rut_participe", rut_participe);
					Cmd.Parameters.AddWithValue("@tipo_participe", tipo_participe);
					Cmd.Parameters.AddWithValue("@firma", firma.ToString().ToUpper());
					Cmd.Parameters.AddWithValue("@ciudad_notario", ciudad_notario);
					Cmd.Parameters.AddWithValue("@notario_publico", notario_publico);
					Cmd.Parameters.AddWithValue("@fecha_personeria", fecha_personeria);

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

        public string del_participantes(double rut_persona)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_Participe", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut_persona", rut_persona);
          
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