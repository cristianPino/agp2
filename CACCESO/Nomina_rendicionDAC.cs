using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
	public class Nomina_rendicionDAC : CACCESO.BaseDAC
    {


        public List<TipoNomina> getnomina_rendicion(int id_inventario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_operaciones_nom_gasto";
                    cmd.Parameters.AddWithValue("@id_inventario", id_inventario);

				         SqlDataReader reader = cmd.ExecuteReader();
                    
                    List<TipoNomina> lnomina = new List<TipoNomina>(); 
                    
                    TipoNomina mNominarendicion;
                    
                    while (reader.Read())
                    {

                        mNominarendicion= new TipoNomina();
                        mNominarendicion.Folio = Convert.ToInt32(reader["folio"]);
                        mNominarendicion.Monto = Convert.ToInt32(reader["total"]);
                        mNominarendicion.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
                        mNominarendicion.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"]);
                        mNominarendicion.Id_inventario = Convert.ToInt32(reader["id_inventario"]);
                        mNominarendicion.Id_familia = Convert.ToInt32(reader["id_familia"]);
                        lnomina.Add(mNominarendicion);
                        mNominarendicion = null;

                    }

                    return lnomina;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public   List<TipoNomina> Getnomina_rendida(Int32 id_inventario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Getnomina_rendida";
                    cmd.Parameters.AddWithValue("@id_inventario", id_inventario);
                    

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    List<TipoNomina> lnomina = new List<TipoNomina>(); 
                    
                    TipoNomina mNominarendicion;
                    
                    while (reader.Read())
                    {

                        mNominarendicion= new TipoNomina();

                        mNominarendicion.Folio = Convert.ToInt32(reader["folio"]);
                        mNominarendicion.Monto = Convert.ToInt32(reader["total"]);
                        mNominarendicion.Id_nomina = Convert.ToInt32(reader["id_nomina"]);
                        mNominarendicion.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"]);
                        mNominarendicion.Id_inventario = Convert.ToInt32(reader["id_inventario"]);
                        mNominarendicion.Id_familia = Convert.ToInt32(reader["id_familia"]);
                    
                    lnomina.Add(mNominarendicion); 
                        mNominarendicion = null;
                    
                    }
                    
                    

                    return lnomina;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public string Delnomina_rendida(int id_nomina,int folio)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_nomina_inventario", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
								 oParam = Cmd.Parameters.AddWithValue("@folio", folio);

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

		public string Addnomina_rendida(int id_nomina, int folio, int cheque)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_nomina_inventario", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
					oParam = Cmd.Parameters.AddWithValue("@folio", folio);
					oParam = Cmd.Parameters.AddWithValue("@ncheque", cheque);

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
