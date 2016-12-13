using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class MailBCADAC : CACCESO.BaseDAC
    {

        public MailBCA getMAilBycodigo(Int32 id_)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_R_GetMAIL_BCA";
                    cmd.Parameters.AddWithValue("@id", id_);
                    SqlDataReader reader = cmd.ExecuteReader();

                    MailBCA mMail = new MailBCA();
                    if (reader.Read())
                    {
                        mMail.Codigo = Convert.ToInt32(reader["codigoCorreo"]);
                        mMail.Subject = reader["Asunto"].ToString();
                        mMail.Body = reader["Body"].ToString();
                        mMail.Ccopy = reader["CC"].ToString();
                        mMail.Firma = reader["PiedeFirma"].ToString();
                    }
                    else
                    {
                        mMail = null;
                    }
                    return mMail;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
