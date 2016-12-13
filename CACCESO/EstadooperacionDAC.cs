using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class EstadooperacionDAC : CACCESO.BaseDAC
	{

		public string add_Estadooperacion(int id_solicitud, Int32 codigo_estado, string observacion, string cuenta_usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_Estadooperacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
					oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
					oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
				catch (Exception ex)
				{
                    return ex.Message;
                    //return (ex.Message.ToString().Trim());
				}
			}
			return "";
		}
        public string add_Estadooperacioncliente(int id_solicitud, Int32 codigo_estado, string observacion, string cuenta_usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Estadooperacioncliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    //return (ex.Message.ToString().Trim());
                }
            }
            return "";
        }

		public string update_EstadoOperacionOrdenSiguiente(int id_solicitud, string codigo, string observacion, string cuenta_usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_w_estado_orden_siguiente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@observacion", observacion);
					Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					Cmd.Parameters.AddWithValue("@codigo", codigo);
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

		public List<EstadoOperacion> getEstadoByoperacion(int id_solicitud, string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_EstadoByoperacion";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<EstadoOperacion> lEstadooperacion = new List<EstadoOperacion>();
					while (reader.Read())
					{
						EstadoOperacion mEstadooperacion = new EstadoOperacion();
						mEstadooperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
						mEstadooperacion.Estado_operacion = new EstadotipooperacionDAC().getEstadoBycodigo(Convert.ToInt32(reader["codigo_estado"]));
						mEstadooperacion.Observacion = reader["observacion"].ToString();
						mEstadooperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mEstadooperacion.Fecha_hora = Convert.ToDateTime(reader["fecha_hora"].ToString());
                        mEstadooperacion.Semaforo = reader["semaforo"].ToString();
                        mEstadooperacion.Contador = Convert.ToInt32(reader["contador"]);
                        mEstadooperacion.Total_dias = Convert.ToInt32(reader["total_dias"]);
                        mEstadooperacion.Id_estado = Convert.ToInt32(reader["id_estado"]);
                        mEstadooperacion.Activo = Convert.ToBoolean(reader["activo"]);
						lEstadooperacion.Add(mEstadooperacion);
						mEstadooperacion = null;
					}
					return lEstadooperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_estado_orden(int id_solicitud, Int32 orden, string codigo, string observacion, string cuenta_usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_Estado_orden", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = Cmd.Parameters.AddWithValue("@orden", orden);
					oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
					oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
					oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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

		public EstadoOperacion getUltimoEstadoByIdoperacion(int id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getUltimoEstadoOperacion";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					EstadoOperacion mEstadooperacion = new EstadoOperacion();
					while (reader.Read())
					{
						mEstadooperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mEstadooperacion.Id_estado = Convert.ToInt32(reader["id_estado"]);
                        mEstadooperacion.Estado_operacion = new EstadotipooperacionDAC().getEstadoBycodigo(Convert.ToInt32(reader["codigo_estado"]));
						mEstadooperacion.Observacion = reader["observacion"].ToString();
						mEstadooperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mEstadooperacion.Fecha_hora = Convert.ToDateTime(reader["fecha_hora"].ToString());
					}
					return mEstadooperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public EstadoOperacion getEstadobyCodigoestado(int id_solicitud, int codigo_estado)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getestadobycodigoestado";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
					SqlDataReader reader = cmd.ExecuteReader();
					EstadoOperacion mEstadooperacion = new EstadoOperacion();
					while (reader.Read())
					{
						mEstadooperacion.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mEstadooperacion.Id_estado = Convert.ToInt32(reader["id_estado"]);
                        mEstadooperacion.Estado_operacion = new EstadotipooperacionDAC().getEstadoBycodigo(Convert.ToInt32(reader["codigo_estado"]));
						mEstadooperacion.Observacion = reader["observacion"].ToString();
						mEstadooperacion.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mEstadooperacion.Fecha_hora = Convert.ToDateTime(reader["fecha_hora"].ToString());
					}
					return mEstadooperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public string add_estado_patente(int id_solicitud, string patente, string cuenta_usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_patente_estado", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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

        public string add_delEstadooperacion(int id_solicitud, Int32 codigo_estado)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_actEstadooperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@id_estado", codigo_estado);

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    //return (ex.Message.ToString().Trim());
                }
            }
            return "";
        }

        public string add_actEstadooperacion(int id_solicitud, Int32 codigo_estado, string observacion, string fecha)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_actEstadooperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@id_estado", codigo_estado);
                    oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
                    oParam = Cmd.Parameters.AddWithValue("@fecha", fecha);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    //return (ex.Message.ToString().Trim());
                }
            }
            return "";
        }


        public EstadoOperacion getEstadobyorden(int id_solicitud, int orden)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getestadobyorden";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@orden", orden);
                    SqlDataReader reader = cmd.ExecuteReader();
                    EstadoOperacion mEstadooperacion = new EstadoOperacion();
                    while (reader.Read())
                    {
                        mEstadooperacion.Permite_estado = Convert.ToBoolean(reader["permite_estado"]);
                    }
                    return mEstadooperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstadoOperacion getEstadobyordenNomina(int folio, int orden, int id_nomina)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getestadobyordenNomina";
                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@orden", orden);
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    SqlDataReader reader = cmd.ExecuteReader();
                    EstadoOperacion mEstadooperacion = new EstadoOperacion();
                    while (reader.Read())
                    {
                        mEstadooperacion.Permite_estado = Convert.ToBoolean(reader["permite_estado"]);
                      
                    }
                    return mEstadooperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




	}
}