using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class Replace_GarantiaDAC : CACCESO.BaseDAC
    {
        public List<Replace_garantia> getReplace()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_GET_REPLACE_TBL_REPLACE";
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Replace_garantia> lreplace = new List<Replace_garantia>();
                    while (reader.Read())
                    {
                        Replace_garantia mreplace = new Replace_garantia();
                        mreplace.Cod_replace = reader["cod_replace"].ToString();
                        mreplace.Cod_tabla= reader["cod_tabla"].ToString();

                        lreplace.Add(mreplace);
                        mreplace = null;
                    }
                    return lreplace;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
