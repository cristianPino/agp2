using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO {
	public class DocumentosDAC : CACCESO.BaseDAC {


        public Documentos getDocumentosbyID(Int16 id_tipo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_documentosbyID";
                    cmd.Parameters.AddWithValue("@id", id_tipo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Documentos mDocumentos = new Documentos();
                    if (reader.Read())
                    {

                        mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
                        mDocumentos.Nombre = reader["nombre"].ToString();
                    }
                    else
                    {

                        mDocumentos = null;

                    }
                    return mDocumentos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Documentos> GetDocumentosbyOrdenTrabajo(int idOt)
        {
           using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "sp_get_ordenTrabajoDocumento"
                        };
                    cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);
                    SqlDataReader reader = cmd.ExecuteReader();

                    var lista = new List<Documentos>();
                    while (reader.Read())
                    {
                     lista.Add(new DocumentosDAC().getDocumentosbyID(Convert.ToInt16(reader["id_documento"])));   
                        
                    }  
                    return lista;
                }  
        }
        
        public string add_documentos(string nombre) {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_add_documentos", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@nombre", nombre);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
				} catch (Exception ex) {
					throw ex;
				}
			}
			return "";
		}

		public List<Documentos> getAllDocumentos() {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_documentos";
					SqlDataReader reader = cmd.ExecuteReader();
					List<Documentos> lDocumentos = new List<Documentos>();
					while (reader.Read()) {
						Documentos mDocumentos = new Documentos();
						mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
						mDocumentos.Nombre = reader["nombre"].ToString();
						mDocumentos.Publico = Convert.ToBoolean(reader["publico"]);
						lDocumentos.Add(mDocumentos);
						mDocumentos = null;
					}
					return lDocumentos;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<Documentos> getDocumentos(string tipo) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_documentosbytipo";
					cmd.Parameters.Add(new SqlParameter("@codigo", tipo));
					SqlDataReader reader = cmd.ExecuteReader();
					List<Documentos> lDocumentos = new List<Documentos>();
					while (reader.Read()) {
						Documentos mDocumentos = new Documentos();
						mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
						mDocumentos.Nombre = reader["nombre"].ToString();
						lDocumentos.Add(mDocumentos);
						mDocumentos = null;
					}
					return lDocumentos;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<Documentos> getDocumentosbyProducto(string codigo,Int32 id_documento) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_documentosbyproducto";
					cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_documento", id_documento);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Documentos> lDocumentos = new List<Documentos>();
					while (reader.Read()) {
						Documentos mDocumentos = new Documentos();
						mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
						mDocumentos.Nombre = reader["nombre"].ToString();
						mDocumentos.Check = Convert.ToBoolean(reader["check"]);
						lDocumentos.Add(mDocumentos);
						mDocumentos = null;
					}
					return lDocumentos;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<Documentos> getDocumentosAsociadosProducto(string codigo) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_documentos_asoc_producto";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Documentos> lDocumentos = new List<Documentos>();
					while (reader.Read()) {
						Documentos mDocumentos = new Documentos();
						mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
						mDocumentos.Nombre = reader["nombre"].ToString();
						mDocumentos.Check = Convert.ToBoolean(reader["check"]);
						lDocumentos.Add(mDocumentos);
						mDocumentos = null;
					}
					return lDocumentos;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public string add_documento_check(string codigo, Int32 id_documento) {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_add_documento_producto", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
					Cmd.Parameters.Add(new SqlParameter("@id_documento", id_documento));
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
				} catch (Exception ex) {
					throw ex;
				}
			}
			return "";
		}
		
		public string del_documento_check(string codigo, Int32 id_documento) {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_del_documento_producto", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
					oParam = Cmd.Parameters.AddWithValue("@id_documento", id_documento);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
				} catch (Exception ex) {
					throw ex;
				}
			}
			return "";
		}

		public string upd_documento_publico(Int32 id_documento, Boolean publico) {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_upd_documento_visible", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_documento", id_documento);
					oParam = Cmd.Parameters.AddWithValue("@publico", Convert.ToInt16(publico));
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
				} catch (Exception ex) {
					throw ex;
				}
			}
			return "";
		}
	}
}