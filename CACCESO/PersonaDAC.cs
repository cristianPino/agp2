using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{

	public class PersonaDAC : CACCESO.BaseDAC
	{
		public Persona getpersonabyrut(double rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_personabyrut";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					Persona mPersona = null;
					if (reader.Read())
					{
						mPersona = new Persona();
						mPersona.Rut = Convert.ToDouble(reader["rut"]);
						mPersona.Dv = reader["dv"].ToString();
						mPersona.Serie = reader["serie"].ToString();
						mPersona.Nombre = reader["nombre"].ToString();
						mPersona.Apellido_paterno = reader["apellido_paterno"].ToString();
						mPersona.Apellido_materno = reader["apellido_materno"].ToString();
						mPersona.Sexo = reader["sexo"].ToString();
						mPersona.Tipo_persona = reader["tipo_persona"].ToString();
						mPersona.Nacionalidad = reader["nacionalidad"].ToString();
						mPersona.Profesion = reader["profesion"].ToString();
						mPersona.Estado_civil = reader["estado_civil"].ToString();
						mPersona.Telefono = reader["telefono"].ToString();
						mPersona.Celular = reader["celular"].ToString();
						mPersona.Correo = reader["correo"].ToString();
						mPersona.Direccion = reader["direccion"].ToString();
						mPersona.Numero = reader["numero"].ToString();
						mPersona.Depto = reader["depto"].ToString();
						mPersona.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
						mPersona.Tipo_empleador = reader["tipo_empleador"].ToString();
                        mPersona.Giro = reader["giro"].ToString();
					}
					else
					{
						mPersona = null;
					}
					return mPersona;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_persona(Persona persona)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_w_persona", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut", persona.Rut);
					oParam = Cmd.Parameters.AddWithValue("@dv", persona.Dv);
					oParam = Cmd.Parameters.AddWithValue("@serie", persona.Serie);
					oParam = Cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
					oParam = Cmd.Parameters.AddWithValue("@apellido_paterno", persona.Apellido_paterno);
					oParam = Cmd.Parameters.AddWithValue("@apellido_materno", persona.Apellido_materno);
					oParam = Cmd.Parameters.AddWithValue("@sexo", persona.Sexo);
					oParam = Cmd.Parameters.AddWithValue("@tipo_persona", persona.Tipo_persona);
					oParam = Cmd.Parameters.AddWithValue("@nacionalidad", persona.Nacionalidad);
					oParam = Cmd.Parameters.AddWithValue("@profesion", persona.Profesion);
					oParam = Cmd.Parameters.AddWithValue("@estado_civil", persona.Estado_civil);
					oParam = Cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
					oParam = Cmd.Parameters.AddWithValue("@celular", persona.Celular);
					oParam = Cmd.Parameters.AddWithValue("@correo", persona.Correo);
					oParam = Cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
					oParam = Cmd.Parameters.AddWithValue("@numero", persona.Numero);
					oParam = Cmd.Parameters.AddWithValue("@depto", persona.Depto);
					oParam = Cmd.Parameters.AddWithValue("@id_comuna", persona.Comuna.Id_Comuna);
					oParam = Cmd.Parameters.AddWithValue("@tipo_empleador", persona.Tipo_empleador);
                    oParam = Cmd.Parameters.AddWithValue("@Giro", persona.Giro);
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

		public string add_personaCG(Persona persona)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_w_personaCG", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut", persona.Rut);
					oParam = Cmd.Parameters.AddWithValue("@dv", persona.Dv);
					oParam = Cmd.Parameters.AddWithValue("@serie", persona.Serie);
					oParam = Cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
					oParam = Cmd.Parameters.AddWithValue("@apellido_paterno", persona.Apellido_paterno);
					oParam = Cmd.Parameters.AddWithValue("@apellido_materno", persona.Apellido_materno);
					oParam = Cmd.Parameters.AddWithValue("@sexo", persona.Sexo);
					oParam = Cmd.Parameters.AddWithValue("@tipo_persona", persona.Tipo_persona);
					oParam = Cmd.Parameters.AddWithValue("@nacionalidad", persona.Nacionalidad);
					oParam = Cmd.Parameters.AddWithValue("@profesion", persona.Profesion);
					oParam = Cmd.Parameters.AddWithValue("@estado_civil", persona.Estado_civil);
					oParam = Cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
					oParam = Cmd.Parameters.AddWithValue("@celular", persona.Celular);
					oParam = Cmd.Parameters.AddWithValue("@correo", persona.Correo);
					oParam = Cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
					oParam = Cmd.Parameters.AddWithValue("@numero", persona.Numero);
					oParam = Cmd.Parameters.AddWithValue("@depto", persona.Depto);
					oParam = Cmd.Parameters.AddWithValue("@id_comuna", persona.Comuna.Id_Comuna);

					oParam = Cmd.Parameters.AddWithValue("@tipo_empleador", persona.Tipo_empleador);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}



        public Persona getpersonabyrutVTA(double rut)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_personabyrutVTA";
                    cmd.Parameters.AddWithValue("@rut", rut);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Persona mPersona = null;
                    if (reader.Read())
                    {
                        mPersona = new Persona();
                        mPersona.Rut = Convert.ToDouble(reader["rut"]);
                        mPersona.Dv = reader["dv"].ToString();
                        mPersona.Serie = reader["serie"].ToString();
                        mPersona.Nombre = reader["nombre"].ToString();
                        mPersona.Apellido_paterno = reader["apellido_paterno"].ToString();
                        mPersona.Apellido_materno = reader["apellido_materno"].ToString();
                        mPersona.Sexo = reader["sexo"].ToString();
                        mPersona.Tipo_persona = reader["tipo_persona"].ToString();
                        mPersona.Nacionalidad = reader["nacionalidad"].ToString();
                        mPersona.Profesion = reader["profesion"].ToString();
                        mPersona.Estado_civil = reader["estado_civil"].ToString();
                        mPersona.Telefono = reader["telefono"].ToString();
                        mPersona.Celular = reader["celular"].ToString();
                        mPersona.Correo = reader["correo"].ToString();
                        mPersona.Direccion = reader["direccion"].ToString();
                        //	mPersona.Direccionfac = reader["direcFac"].ToString();
                        mPersona.Numero = reader["numero"].ToString();
                        mPersona.Depto = reader["complemento"].ToString();
                        mPersona.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                        mPersona.Tipo_empleador = reader["tipo_empleador"].ToString();
                        mPersona.Giro = reader["giro"].ToString();
                    }
                    else
                    {
                        mPersona = null;
                    }
                    return mPersona;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


	}
}