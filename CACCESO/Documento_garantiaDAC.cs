using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class Documento_garantiaDAC : CACCESO.BaseDAC
    {
        public Documento_garantia getdocumentos_garantia(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Documento_garantia";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Documento_garantia mmatriz = new Documento_garantia();
                    while (reader.Read())
                    {
                        mmatriz.Cod_matriz = Convert.ToInt32(reader["cod_matriz"].ToString());
                        mmatriz.Id_solicitud = Convert.ToInt32(reader["id_solicitud"].ToString());
                        mmatriz.Fecha_doc =Convert.ToDateTime(reader["fecha_doc"].ToString());
                        mmatriz.Documento = Convert.ToBoolean(reader["documento"].ToString());
                        mmatriz.Cuenta_usuario = reader["cuenta_usuario"].ToString();
                       
                    }
                    return mmatriz;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_documento_garantia(string cuenta_usuario, Int32 id_solicitud,Int32 cod_matriz, bool documento,DateTime fecha_doc)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_documento_garantia", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@cod_matriz", cod_matriz);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_doc", fecha_doc);
                    oParam = Cmd.Parameters.AddWithValue("@documento", documento);

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

		public string add_escritura_pendiente(int id_solicitud, string origen, string destino)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_add_escritura_pendiente", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@origen", origen);
					cmd.Parameters.AddWithValue("@destino", destino);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return "";
		}
    }
}
