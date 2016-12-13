using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class FoliadorDAC : CACCESO.BaseDAC
    {
        public int getfolio1()
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
					SqlCommand Cmd = new SqlCommand("sp_get_folio", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                  

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return 1;

        }


		public int getfolio()
		{
			try
			{
				
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					  int folio =0;
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_folio";
					
					SqlDataReader reader = cmd.ExecuteReader();
					
					if (reader.Read())
					{
					folio=  Convert.ToInt32(reader["folio"].ToString());

					}
					return folio;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        
    }
}
