using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class Cta_CteDAC : CACCESO.BaseDAC
    {
        public string add_cta_cte(string cuenta_usuario, string numero,string tipo,string banco)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_cta_cte", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@numero", numero);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_cuenta", tipo);
                    oParam = Cmd.Parameters.AddWithValue("@banco", banco);
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

        public List<Cuenta_Corriente> getCta_Cte(string cuenta_usuario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_cuenta_corriente";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cuenta_Corriente> lcta_cte = new List<Cuenta_Corriente>();
                    while (reader.Read())
                    {
                        Cuenta_Corriente mcta_cte = new Cuenta_Corriente();
                        mcta_cte.Id_cta_cte = Convert.ToInt32(reader["id_cta_cte"].ToString());
                        mcta_cte.Cuenta_usuario = reader["cuenta_usuario"].ToString();
                        mcta_cte.Banco = reader["banco"].ToString();
                        mcta_cte.Numero = reader["numero"].ToString();
                        mcta_cte.Tipo_cuenta =reader["tipo_cuenta"].ToString();
                        mcta_cte.Cuenta = reader["banco"].ToString() +" Nº "+ reader["numero"].ToString();
                        lcta_cte.Add(mcta_cte);
                        mcta_cte = null;
                    }
                    return lcta_cte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
