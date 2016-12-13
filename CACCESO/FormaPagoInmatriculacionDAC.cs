using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO {
	public class FormaPagoInmatriculacionDAC : BaseDAC {

		public string AddFormaPago(FormaPagoInmatriculacion fp) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_forma_pago_inmatriculacion", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", fp.Id_solicitud);
					cmd.Parameters.AddWithValue("@numero_cuenta_corriente", fp.Numero_cuenta_corriente);
					cmd.Parameters.AddWithValue("@id_formapago", fp.Tipo_forma_pago.Id_FormaPago);
					cmd.Parameters.AddWithValue("@monto_abono", fp.Monto_abono);
					cmd.Parameters.AddWithValue("@fecha_abono", fp.Fecha_abono);
					cmd.Parameters.AddWithValue("@codigo_banco", fp.Banco.Codigo);
					cmd.Parameters.AddWithValue("@cod_moneda", fp.Moneda.Cod_moneda);
					cmd.Parameters.AddWithValue("@observaciones", fp.Observaciones);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
			} catch (Exception ex) {
				throw ex;
			}
			return "";
		}

		public string DelFormaPago(int id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_del_forma_pago_inmatriculacion", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
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

		public List<FormaPagoInmatriculacion> GetFormaPago(int id_solicitud) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_forma_pago_inmatriculacion", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					List<FormaPagoInmatriculacion> lfp = new List<FormaPagoInmatriculacion>();
					SqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read()) {
						FormaPagoInmatriculacion fp = new FormaPagoInmatriculacion();
						fp.Id_detalle_forma_pago = Convert.ToInt32(dr["id_detalle_forma_pago"]);
						fp.Id_solicitud = Convert.ToInt32(dr["id_solicitud"]);
						fp.Numero_cuenta_corriente = dr["numero_cuenta_corriente"].ToString();
						fp.Tipo_forma_pago = new TipoFormaPagoDAC().GetTipoFormaPago(Convert.ToInt32(dr["id_formapago"]));
						fp.Monto_abono = Convert.ToDouble(dr["monto_abono"]);
						fp.Fecha_abono = Convert.ToDateTime(dr["fecha_abono"]);
						fp.Banco = new BancofinancieraDAC().getBancofinanciera(dr["codigo_banco"].ToString());
						fp.Moneda = new TipoMonedaDAC().GetTipoMoneda(dr["cod_moneda"].ToString());
						fp.Observaciones = dr["observaciones"].ToString();
						lfp.Add(fp);
					}
					dr.Close();
					sqlConn.Close();
					return lfp;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}