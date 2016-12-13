using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class PersonaPeruDAC : BaseDAC
	{
		public string AddPersona(PersonaPeru persona)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_personaperu", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@nro_documento_identidad", persona.NroDocumentoIdentidad);
					cmd.Parameters.AddWithValue("@tipo_documento_identidad", persona.TipoDocumentoIdentidad);
					cmd.Parameters.AddWithValue("@nombres", persona.Nombres);
					cmd.Parameters.AddWithValue("@apellido_paterno", persona.ApellidoPaterno);
					cmd.Parameters.AddWithValue("@apellido_materno", persona.ApellidoMaterno);
					cmd.Parameters.AddWithValue("@estado_civil", persona.EstadoCivil);
					cmd.Parameters.AddWithValue("@inscripcion_registral", persona.InscripcionRegistral);
					cmd.Parameters.AddWithValue("@domicilio", persona.Domicilio);
					cmd.Parameters.AddWithValue("@id_comuna", persona.Comuna.Id_Comuna);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return "";
		}

		public PersonaPeru GetPersona(string nroDocumentoIdentidad, string tipoDocumentoIdentidad)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_personaperu", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;

					PersonaPeru persona = new PersonaPeru();

					cmd.Parameters.AddWithValue("@nro_documento_identidad", nroDocumentoIdentidad);
					cmd.Parameters.AddWithValue("@tipo_documento_identidad", tipoDocumentoIdentidad);
					SqlDataReader dr = cmd.ExecuteReader();
					if (dr.Read())
					{
						persona.NroDocumentoIdentidad = dr["nro_documento_identidad"].ToString();
						persona.TipoDocumentoIdentidad = dr["tipo_documento_identidad"].ToString();
						persona.Nombres = dr["nombres"].ToString();
						persona.ApellidoPaterno = dr["apellido_paterno"].ToString();
						persona.ApellidoMaterno = dr["apellido_materno"].ToString();
						persona.EstadoCivil = dr["estado_civil"].ToString();
						persona.InscripcionRegistral = dr["inscripcion_registral"].ToString();
						persona.Domicilio = dr["domicilio"].ToString();
						persona.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(dr["id_comuna"]));
					}
					dr.Close();
					sqlConn.Close();
					return persona;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}