using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class NotariaDAC : CACCESO.BaseDAC
    {

        public List<Notaria> getNotaria()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_notaria";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Notaria> lmatriz = new List<Notaria>();
                    while (reader.Read())
                    {
                        Notaria mmatriz = new Notaria();
               
                        mmatriz.Cod_notaria = reader["cod_notaria"].ToString();
                        mmatriz.Nombre = reader["nombre"].ToString();


                        lmatriz.Add(mmatriz);
                        mmatriz = null;
                    }
                    return lmatriz;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
