using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CENTIDAD;

namespace CACCESO {
	public class TipoSolicitudRCProductoDAC : CACCESO.BaseDAC {
		public string addTipoSolicitudRC_TipoOperacion(string codigo, Int32 cod_solicrc) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "sp_add_solicitudrc_by_tipooperacion";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					cmd.Parameters.AddWithValue("@cod_solicrc", cod_solicrc);
					cmd.ExecuteNonQuery();
					return "";
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public string delTipoSolicitudRC_TipoOperacion(int id) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "sp_del_solicitudrc_by_tipooperacion";
					cmd.Parameters.AddWithValue("@id_solicrc_toper", id);
					cmd.ExecuteNonQuery();
					return "";
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
					cmd.CommandText = "sp_r_getsolicitudesrc_by_tipooperacion2";
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