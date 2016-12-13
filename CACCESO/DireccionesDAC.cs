using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class DireccionesDAC : CACCESO.BaseDAC
	{

		public string add_direcciones(string tipo_direccion, int rut, string numero, string direccion, int comuna, string complemento, int id_direccion)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_direccion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@tipo_direccion", tipo_direccion);
					Cmd.Parameters.AddWithValue("@rut", rut);
					Cmd.Parameters.AddWithValue("@numero", numero);
					Cmd.Parameters.AddWithValue("@direccion", direccion);
					Cmd.Parameters.AddWithValue("@id_comuna", comuna);
					Cmd.Parameters.AddWithValue("@complemento", complemento);
					Cmd.Parameters.AddWithValue("@id_direccion", id_direccion);
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

		public string act_checkDireccion(int id_direccion, string check)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_act_checkDireccion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_direccion", id_direccion);
					oParam = Cmd.Parameters.AddWithValue("@check", check);

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

		public Direcciones getDireccionPorDefecto(int rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_direccion_por_defecto";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					Direcciones mdirecciones = new Direcciones();
                    if (reader.Read())
                    {
                        mdirecciones.Id_direccion = Convert.ToInt32(reader["id_direccion"].ToString());
                        mdirecciones.Rut = Convert.ToInt32(reader["rut"].ToString());
                        mdirecciones.Tipo_direccion = reader["tipo_direccion"].ToString();
                        mdirecciones.Direccion = reader["direccion"].ToString();
                        //mdirecciones.Comuna = reader["id_comuna"].ToString();
                        mdirecciones.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                        mdirecciones.Numero = reader["numero"].ToString();
                        mdirecciones.Complemento = reader["complemento"].ToString();
                        mdirecciones.Check = reader["prioridad"].ToString();
                    }
                    else
                    { mdirecciones = null; }


					return mdirecciones;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Direcciones> getdirecciones(int rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_direcciones";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Direcciones> ldirecciones = new List<Direcciones>();
					while (reader.Read())
					{
						Direcciones mdirecciones = new Direcciones();
						mdirecciones.Id_direccion = Convert.ToInt32(reader["id_direccion"].ToString());
						mdirecciones.Rut = Convert.ToInt32(reader["rut"].ToString());
						mdirecciones.Tipo_direccion = reader["tipo_direccion"].ToString();
						mdirecciones.Direccion = reader["direccion"].ToString();
						//mdirecciones.Comuna = reader["id_comuna"].ToString();
						mdirecciones.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
						//mdirecciones.Numero = Convert.ToInt32(reader["numero"].ToString());
						mdirecciones.Numero = reader["numero"].ToString();
						mdirecciones.Complemento = reader["complemento"].ToString();
						mdirecciones.Check = reader["prioridad"].ToString();

						ldirecciones.Add(mdirecciones);
						mdirecciones = null;
					}
					return ldirecciones;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}