using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class MasterBCADAC : CACCESO.BaseDAC
    {
        public string add_MasterBCA(Int32 operacion, string n_interno, Int32 id_credito)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("SP_add_MasterBCA", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", operacion);
                    oParam = Cmd.Parameters.AddWithValue("@id_interno", n_interno);
                    oParam = Cmd.Parameters.AddWithValue("@id_credito", id_credito);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception)
                {

                }
            }
            return "";
        }

        public List<MasterBCA> getListMasterBCA(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_R_GetMAsterBCA";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MasterBCA> lBCA = new List<MasterBCA>();
                    while (reader.Read())
                    {
                        MasterBCA mMasterBCA = new MasterBCA();
                        mMasterBCA.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mMasterBCA.Id_interno = reader["n_interno"].ToString();
                        mMasterBCA.Id_credito = Convert.ToInt32(reader["id_credito"]);
                        lBCA.Add(mMasterBCA);
                    }
                    return lBCA;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MasterBCA> getListMasterBCAall()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_R_GetMAsterBCAall";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MasterBCA> lBCA = new List<MasterBCA>();
                    while (reader.Read())
                    {
                        MasterBCA mMasterBCA = new MasterBCA();
                        mMasterBCA.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mMasterBCA.Id_interno = reader["n_interno"].ToString();
                        mMasterBCA.Id_credito = Convert.ToInt32(reader["id_credito"]);
                        lBCA.Add(mMasterBCA);
                    }
                    return lBCA;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MasterBCA getListMasterBCAbyidhijo(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_R_GetMAsterBCAbyid";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    MasterBCA mMasterBCA = new MasterBCA();
                    if (reader.Read())
                    {
                        mMasterBCA.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mMasterBCA.Id_interno = reader["n_interno"].ToString();
						//mMasterBCA.Id_credito = Convert.ToInt32(reader["id_hijo"]);
						mMasterBCA.Id_credito = Convert.ToInt32(reader["id_credito"]);
                        
                    }
                    else
                    {
                        mMasterBCA = null;
                    }
                    return mMasterBCA;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
