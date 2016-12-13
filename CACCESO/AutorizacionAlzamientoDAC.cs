using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class AutorizacionAlzamientoDAC : BaseDAC
	{
		public string AddAutorizacionAlzamiento(AutorizacionAlzamiento autorizacion)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_autorizacion_alzamiento", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud_gar", autorizacion.Id_solicitud_gar);
					cmd.Parameters.AddWithValue("@id_solicitud_alz", autorizacion.Id_solicitud_alz);
					cmd.Parameters.AddWithValue("@cuenta_usuario", autorizacion.Cuenta_usuario);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return "";
		}
	}
}