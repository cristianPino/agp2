using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO {
	public class TipoSolicitudRCDAC : CACCESO.BaseDAC {

		public string addTipoSolicitudRC(TipoSolicitudRC solicitud) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "sp_add_solicitudrc";
					cmd.Parameters.AddWithValue("@cod_solicrc", solicitud.CodSolicRC);
					cmd.Parameters.AddWithValue("@desc_solicrc", solicitud.DescSolicRC);
					cmd.Parameters.AddWithValue("@correos_solicrc", solicitud.ListaCorreos);
					cmd.ExecuteNonQuery();
					return "";
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public TipoSolicitudRC getTipoSolicitudRC(int codigo) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getsolicitudrc";
					cmd.Parameters.AddWithValue("@cod_solicrc", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					TipoSolicitudRC mEstado = new TipoSolicitudRC();
					if (reader.Read()) {
						mEstado.CodSolicRC = Convert.ToInt32(reader["cod_solicrc"]);
						mEstado.DescSolicRC = reader["desc_solicrc"].ToString();
						mEstado.ListaCorreos = reader["correos_solicrc"].ToString();
					}
					return mEstado;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<TipoSolicitudRC> getTipoSolicitudRC() {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getsolicitudesrc";
					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoSolicitudRC> lEstado = new List<TipoSolicitudRC>();
					while (reader.Read()) {
						TipoSolicitudRC mEstado = new TipoSolicitudRC();
						mEstado.CodSolicRC = Convert.ToInt32(reader["cod_solicrc"]);
						mEstado.DescSolicRC = reader["desc_solicrc"].ToString();
						mEstado.ListaCorreos = reader["correos_solicrc"].ToString();
						lEstado.Add(mEstado);
					}
					return lEstado;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<TipoSolicitudRCProducto> getTipoSolicitudRC_by_TipoOperacion(string codigo) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getsolicitudesrc_by_tipooperacion";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoSolicitudRCProducto> lEstado = new List<TipoSolicitudRCProducto>();
					while (reader.Read()) {
						TipoSolicitudRCProducto mEstado = new TipoSolicitudRCProducto();
						mEstado.ID = Convert.ToInt32(reader["id_solicrc_toper"]);
						mEstado.CodSolicRC = Convert.ToInt32(reader["cod_solicrc"]);
						mEstado.DescSolicRC = reader["desc_solicrc"].ToString();
						mEstado.Check = Convert.ToBoolean(reader["chk"]);
						lEstado.Add(mEstado);
					}
					return lEstado;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}