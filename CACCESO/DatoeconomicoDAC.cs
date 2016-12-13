using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class DatoeconomicoDAC : CACCESO.BaseDAC
    {

        public List<DatoEconomico> GetDatoeconomico()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Datoeconomico";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DatoEconomico> lDatoeconomico = new List<DatoEconomico>();


                    while (reader.Read())
                    {
                        DatoEconomico mDatoeconomico = new DatoEconomico();

                        mDatoeconomico.Codigo = reader["codigo"].ToString();
                        mDatoeconomico.Valor = Convert.ToDouble((reader["valor"]));


                        lDatoeconomico.Add(mDatoeconomico);

                        mDatoeconomico = null;
                    }
                    return lDatoeconomico;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatoEconomico GetDatoeconomicobycodigo(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Datoeconomicobycodigo";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    DatoEconomico mDatoeconomico = new DatoEconomico();

                    if (reader.Read())
                    {


                        mDatoeconomico.Codigo = reader["codigo"].ToString();
                        mDatoeconomico.Valor = Convert.ToDouble((reader["valor"]));


                    }
                    return mDatoeconomico;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_Datoeconomico(DatoEconomico Datoeconomico)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Datoeconomico", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", Datoeconomico.Codigo);
                    oParam = Cmd.Parameters.AddWithValue("@valor", Datoeconomico.Valor);

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

