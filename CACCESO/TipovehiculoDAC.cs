using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO {
	public class TipovehiculoDAC : CACCESO.BaseDAC {

		public Tipovehiculo getTipovehiculo(string codigo) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_Tipovehiculo";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					Tipovehiculo mTipovehiculo = new Tipovehiculo();
					if (reader.Read()) {
						mTipovehiculo.Codigo = reader["codigo"].ToString();
						mTipovehiculo.Nombre = reader["nombre"].ToString();
					}
					return mTipovehiculo;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public List<Tipovehiculo> getallTipovehiculo() {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_Tipovehiculos";
					SqlDataReader reader = cmd.ExecuteReader();
					List<Tipovehiculo> lTipovehiculo = new List<Tipovehiculo>();
					while (reader.Read()) {
						Tipovehiculo mTipovehiculo = new Tipovehiculo();
						mTipovehiculo.Codigo = reader["codigo"].ToString();
						mTipovehiculo.Nombre = reader["nombre"].ToString();
						lTipovehiculo.Add(mTipovehiculo);
						mTipovehiculo = null;
					}
                    sqlConn.Close();
					return lTipovehiculo;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public string add_Tipovehiculo(Tipovehiculo tipovehiculo) {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
				sqlConn.Open();
				try {
					SqlCommand Cmd = new SqlCommand("sp_add_Tipovehiculo", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", tipovehiculo.Codigo);
					oParam = Cmd.Parameters.AddWithValue("@nombre", tipovehiculo.Nombre);
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