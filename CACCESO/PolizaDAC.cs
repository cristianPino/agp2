using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class PolizaDAC : CACCESO.BaseDAC
	{
		public Poliza getpoliza(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_poliza";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					Poliza mpoliza = new Poliza();
					if (reader.Read())
					{
						mpoliza.Id_solicitud = Convert.ToInt32(reader["id_solicitud"].ToString().Trim());
						mpoliza.Distribuidor_poliza = reader["codigo_distribuidor"].ToString();
						mpoliza.Nfolio = Convert.ToInt64(reader["nfolio_distribuidor"].ToString());
						mpoliza.Npoliza = reader["npoliza"].ToString();
						mpoliza.Pagp = Convert.ToInt32(reader["precio_agp"].ToString());
						mpoliza.Ppiso = Convert.ToInt32(reader["precio_piso"].ToString());
						mpoliza.Pcliente = Convert.ToInt32(reader["precio_cliente"].ToString());
						mpoliza.Prima = Convert.ToInt32(reader["prima"].ToString());
						mpoliza.Url_poliza = reader["url_poliza_soap"].ToString();
						mpoliza.Vigencia_desde = Convert.ToDateTime(reader["vigencia_desde"].ToString());
						mpoliza.Vigencia_hasta = Convert.ToDateTime(reader["vigencia_hasta"].ToString());
						mpoliza.Poliza_vigente = Convert.ToBoolean(reader["poliza_vigente"]);
					}
					return mpoliza;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Poliza getvalores_poliza(Int32 id_solicitud, Int32 id_cliente, string codigo_distribuidor,string fecha_desde)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_valores_poliza";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
					SqlDataReader reader = cmd.ExecuteReader();
					Poliza mpoliza = new Poliza();
					if (reader.Read())
					{
						mpoliza.Pagp = Convert.ToInt32(reader["valorAGP"].ToString().Trim());
						mpoliza.Pcliente = Convert.ToInt32(reader["valorCLI"].ToString());
						mpoliza.Ppiso = Convert.ToInt32(reader["valorDIS"].ToString());
						mpoliza.Prima = Convert.ToInt32(reader["prima"].ToString());
						mpoliza.Vigencia_desde = Convert.ToDateTime(reader["fecha_desde"].ToString());
						mpoliza.Vigencia_hasta = Convert.ToDateTime(reader["fecha_hasta"].ToString());

					}
					return mpoliza;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Poliza getpolizabyid_poliza(Int32 id_poliza)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_polizabyid";
					cmd.Parameters.AddWithValue("@id_poliza", id_poliza);
					SqlDataReader reader = cmd.ExecuteReader();
					Poliza mpoliza = new Poliza();
					if (reader.Read())
					{
						mpoliza.Id_solicitud = Convert.ToInt32(reader["id_solicitud"].ToString().Trim());
						mpoliza.Distribuidor_poliza = reader["codigo_distribuidor"].ToString();
						mpoliza.Nfolio = Convert.ToInt64(reader["nfolio_distribuidor"].ToString());
						mpoliza.Npoliza = reader["npoliza"].ToString();
						mpoliza.Pagp = Convert.ToInt32(reader["precio_agp"].ToString());
						mpoliza.Ppiso = Convert.ToInt32(reader["precio_piso"].ToString());
						mpoliza.Pcliente = Convert.ToInt32(reader["precio_cliente"].ToString());
						mpoliza.Prima = Convert.ToInt32(reader["prima"].ToString());
						mpoliza.Url_poliza = reader["url_poliza_soap"].ToString();
						mpoliza.Vigencia_desde = Convert.ToDateTime(reader["vigencia_desde"].ToString());
						mpoliza.Vigencia_hasta = Convert.ToDateTime(reader["vigencia_hasta"].ToString());
						mpoliza.Poliza_vigente = Convert.ToBoolean(reader["poliza_vigente"]);
					}
					return mpoliza;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_poliza(Poliza poliza,string usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					//Deja como no vigentes todas las otras pólizas
					SqlCommand Cmd = new SqlCommand("sp_del_polizas_operacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", poliza.Id_solicitud);
                    
					Cmd.ExecuteNonQuery();
					Cmd = null;
					//Agrega la nueva póliza
					Cmd = new SqlCommand("sp_add_poliza", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@codigo_distribuidor", poliza.Distribuidor_poliza);
					Cmd.Parameters.AddWithValue("@id_solicitud", poliza.Id_solicitud);
					Cmd.Parameters.AddWithValue("@npoliza", poliza.Npoliza);
					Cmd.Parameters.AddWithValue("@nfolio_distribuidor", poliza.Nfolio);
					Cmd.Parameters.AddWithValue("@vigencia_desde", poliza.Vigencia_desde);
					Cmd.Parameters.AddWithValue("@vigencia_hasta", poliza.Vigencia_hasta);
					Cmd.Parameters.AddWithValue("@prima", poliza.Prima);
					Cmd.Parameters.AddWithValue("@url_poliza_soap", poliza.Url_poliza);
					Cmd.Parameters.AddWithValue("@precio_piso", poliza.Ppiso);
					Cmd.Parameters.AddWithValue("@precio_agp", poliza.Pagp);
					Cmd.Parameters.AddWithValue("@precio_cliente", poliza.Pcliente);
                    Cmd.Parameters.AddWithValue("@usuario", usuario);
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

		public List<Poliza> getallpoliza(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_polizalist";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Poliza> lpoliza = new List<Poliza>();
					while (reader.Read())
					{
						Poliza mpoliza = new Poliza();
						mpoliza.Id_poliza = Convert.ToInt32(reader["id_poliza"]);
						mpoliza.Id_solicitud = Convert.ToInt32(reader["id_solicitud"].ToString().Trim());
						mpoliza.Distribuidor_poliza = reader["codigo_distribuidor"].ToString();
						mpoliza.Nfolio = Convert.ToInt64(reader["nfolio_distribuidor"].ToString());
						mpoliza.Npoliza = reader["npoliza"].ToString();
						mpoliza.Pagp = Convert.ToInt32(reader["precio_agp"].ToString());
						mpoliza.Ppiso = Convert.ToInt32(reader["precio_piso"].ToString());
						mpoliza.Pcliente = Convert.ToInt32(reader["precio_cliente"].ToString());
						mpoliza.Prima = Convert.ToInt32(reader["prima"].ToString());
						mpoliza.Url_poliza = reader["url_poliza_soap"].ToString();
						mpoliza.Vigencia_desde = Convert.ToDateTime(reader["vigencia_desde"].ToString());
						mpoliza.Vigencia_hasta = Convert.ToDateTime(reader["vigencia_hasta"].ToString());
						mpoliza.Poliza_vigente = Convert.ToBoolean(reader["poliza_vigente"]);
						lpoliza.Add(mpoliza);
						mpoliza = null;
					}
					return lpoliza;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string del_poliza(Int32 id_poliza)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_poliza", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_poliza", id_poliza);
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
	}
}