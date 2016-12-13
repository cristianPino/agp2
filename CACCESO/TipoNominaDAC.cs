using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
	public class TipoNominaDAC : CACCESO.BaseDAC
	{


		public List<TipoNomina> getTipoNominagastoByIdFamilia(int id_familia)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_tipoNominagastoByIdFamilia";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoNomina> lTiponomina = new List<TipoNomina>();
					while (reader.Read())
					{
						TipoNomina mTiponomina = new TipoNomina();
						mTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
						mTiponomina.Descripcion = reader["descripcion"].ToString();
						mTiponomina.Folio = Convert.ToInt32(reader["folio"]);
						mTiponomina.Reporte = reader["reporte"].ToString();
						mTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
						mTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
						mTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);

						lTiponomina.Add(mTiponomina);
						mTiponomina = null;
					}
                    sqlConn.Close();
					return lTiponomina;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public string add_tiponomina(string descripcion)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_tiponomina", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@descripcion", descripcion);
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



		public string actualiza_tiponomina(string descripcion,string reporte,Int16 estado,Int16 gasto,string check,int id_familia,int folio,int id_nomina)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_act_tiponomina", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@descripcion", descripcion);
					Cmd.Parameters.AddWithValue("@reporte", reporte);
					Cmd.Parameters.AddWithValue("@estado", estado);
					Cmd.Parameters.AddWithValue("@gasto", gasto);
					Cmd.Parameters.AddWithValue("@check", check);
					Cmd.Parameters.AddWithValue("@folio", folio);
					Cmd.Parameters.AddWithValue("@id_familia", id_familia);
					Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
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

		public List<TipoNomina> getTiponomina()
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_tiponomina";
					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoNomina> lTiponomina = new List<TipoNomina>();
					while (reader.Read())
					{
						TipoNomina mTiponomina = new TipoNomina();
						mTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
						mTiponomina.Descripcion = reader["descripcion"].ToString();
						mTiponomina.Folio = Convert.ToInt32(reader["folio"]);
						mTiponomina.Reporte = reader["reporte"].ToString();
						mTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
						mTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
						mTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);
						lTiponomina.Add(mTiponomina);
						mTiponomina = null;
					}
                    sqlConn.Close();
					return lTiponomina;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public TipoNomina getTiponominaBytipo(Int32 id_nomina)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_tiponominaBytipo";
					cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					SqlDataReader reader = cmd.ExecuteReader();
					TipoNomina lTiponomina = null;
					if (reader.HasRows)
					{
						lTiponomina = new TipoNomina();
						if (reader.Read())
						{
							lTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
							lTiponomina.Descripcion = reader["descripcion"].ToString();
							lTiponomina.Folio = Convert.ToInt32(reader["folio"]);
							lTiponomina.Reporte = reader["reporte"].ToString();
							lTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
							lTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
							lTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);
                            lTiponomina.Id_tipogasto = Convert.ToInt32(reader["id_tipogastos"] ?? 0);
                            lTiponomina.Permite_factura = Convert.ToBoolean(reader["permite_factura"] ?? false);
                            lTiponomina.Cliente_unico = Convert.ToBoolean(reader["cliente_unico"] ?? false); 
						}
					}
                    sqlConn.Close();
					return lTiponomina;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<TipoNomina> getTipoNominaByIdFamilia(int id_familia)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_tipoNominaByIdFamilia";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoNomina> lTiponomina = new List<TipoNomina>();
					while (reader.Read())
					{
						TipoNomina mTiponomina = new TipoNomina();
						mTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
						mTiponomina.Descripcion = reader["descripcion"].ToString();
						mTiponomina.Folio = Convert.ToInt32(reader["folio"]);
						mTiponomina.Reporte = reader["reporte"].ToString();
						mTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
						mTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
						mTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);
					
						lTiponomina.Add(mTiponomina);
						mTiponomina = null;
					}
                    sqlConn.Close();
					return lTiponomina;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<TipoNomina> getTipoNominaByIdFamiliacheck(int id_familia)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_tipoNominaByIdFamiliachek";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoNomina> lTiponomina = new List<TipoNomina>();
					while (reader.Read())
					{
						TipoNomina mTiponomina = new TipoNomina();
						mTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
						mTiponomina.Descripcion = reader["descripcion"].ToString();
						mTiponomina.Folio = Convert.ToInt32(reader["folio"]);
						mTiponomina.Reporte = reader["reporte"].ToString();
						mTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
						mTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
						mTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);
						mTiponomina.Codigo_estado = Convert.ToInt32(reader["codigo_estado"] ?? 0);
						mTiponomina.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"] ?? 0);
						mTiponomina.Chek = Convert.ToInt16(reader["permite_factura"]);


						lTiponomina.Add(mTiponomina);
						mTiponomina = null;
					}
                    sqlConn.Close();
					return lTiponomina;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public string actualiza_rendicion_nomina(Int32 id_solicitud, Int32 id_nomina, Int32 folio, string cuenta_usuario, Int32 id_inventario )
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_act_actualiza_rendicion_nomina", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    Cmd.Parameters.AddWithValue("@folio", folio);
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    Cmd.Parameters.AddWithValue("@id_inventario", id_inventario);
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

		public string add_tiponominaByOperacion(int id_solicitud, int id_nomina, int folio, string cuenta_usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_tiponominaByOperacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					Cmd.Parameters.AddWithValue("@folio", folio);
					Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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


        public string envia_correo_nomina( int id_nomina, int folio)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_envia_correo_nomina", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@folio", folio);
                    Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
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

        public string envia_correo_nomina_pdte(int id_nomina, int folio)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_envia_correo_nomina_pdte", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@folio", folio);
                    Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
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


        public List<TipoNomina> getnominabyoperacion(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getnominabyoperacion";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

					SqlDataReader reader = cmd.ExecuteReader();
					List<TipoNomina> lTiponomina = new List<TipoNomina>();
					while (reader.Read())
					{
						TipoNomina mTiponomina = new TipoNomina();
						mTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
						mTiponomina.Descripcion = reader["descripcion"].ToString();
						mTiponomina.Folio = Convert.ToInt32(reader["folio"]);
						mTiponomina.Reporte = reader["reporte"].ToString();
						mTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
						mTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
						mTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);
						lTiponomina.Add(mTiponomina);
						mTiponomina = null;
					}
                    sqlConn.Close();
					return lTiponomina;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string upd_FolioNomina(Int32 id_nomina)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_w_ActualizarFolio", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
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

        public string del_nominabyoperacion(Int32 id_solicitud, Int32 id_nomina, Int32 folio,string cuenta_usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_w_nominabyoperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@folio", folio);
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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


        public bool respuesta_nomina(Int32 id_solicitud, Int16 id_nomina, Int32 id_familia,int id_cliente)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_r_respuesta_nomina", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    oParam = cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    oParam = cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = cmd.Parameters.AddWithValue("@respuesta", false);
                    oParam.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    bool nTheNewId = Convert.ToBoolean(cmd.Parameters["@respuesta"].Value);
                    sqlConn.Close();
                    return nTheNewId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public List<TipoNomina> getTipoNominaByIdFamiliafactura(int id_familia)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_tipoNominaByIdFamiliafactura";
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<TipoNomina> lTiponomina = new List<TipoNomina>();
                    while (reader.Read())
                    {
                        TipoNomina mTiponomina = new TipoNomina();
                        mTiponomina.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
                        mTiponomina.Descripcion = reader["descripcion"].ToString();
                        mTiponomina.Folio = Convert.ToInt32(reader["folio"]);
                        mTiponomina.Reporte = reader["reporte"].ToString();
                        mTiponomina.Id_familia = Convert.ToInt32(reader["id_familia"] ?? 0);
                        mTiponomina.Orden_old = Convert.ToInt32(reader["orden_old"] ?? 0);
                        mTiponomina.Orden_new = Convert.ToInt32(reader["orden_new"] ?? 0);
                        lTiponomina.Add(mTiponomina);
                        mTiponomina = null;
                    }
                    sqlConn.Close();
                    return lTiponomina;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



	}
}