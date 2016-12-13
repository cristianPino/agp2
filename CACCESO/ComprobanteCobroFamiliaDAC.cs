using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class ComprobanteCobroFamiliaDAC : BaseDAC
	{
		public List<ComprobanteCobroFamilia> getAllComprobantes()
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_getAllComprobantes", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlDataReader dr = cmd.ExecuteReader();
					List<ComprobanteCobroFamilia> lista = null;
					if (dr.HasRows)
					{
						lista = new List<ComprobanteCobroFamilia>();
						while (dr.Read())
							lista.Add(new ComprobanteCobroFamilia()
							{
								Id_comprobante = Convert.ToInt32(dr["id_comprobante"]),
								Id_familia = Convert.ToInt32(dr["id_familia"]),
								Rpt_comprobante = dr["rpt_comprobante"].ToString()
							});
					}
					cnn.Close();
					return lista;
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public ComprobanteCobroFamilia getComprobante(int id_familia)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_getComprobante", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader dr = cmd.ExecuteReader();
					ComprobanteCobroFamilia comp = null;
					if (dr.Read())
						comp = new ComprobanteCobroFamilia()
						{
							Id_comprobante = Convert.ToInt32(dr["id_comprobante"]),
							Id_familia = Convert.ToInt32(dr["id_familia"]),
							Rpt_comprobante = dr["rpt_comprobante"].ToString()
						};
					cnn.Close();
					return comp;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
