using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class DistribuidorpolizaDAC : CACCESO.BaseDAC
    {
        public DistribuidorPoliza getDistribuidorpoliza(string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_distribuidorpolizabycodigo";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    DistribuidorPoliza mDistribuidorpoliza = new DistribuidorPoliza();

                    if (reader.Read())
                    {
                        
                        mDistribuidorpoliza.Codigo = reader["codigo_distribuidor"].ToString().Trim();
                        mDistribuidorpoliza.Nombre = reader["nombre"].ToString();

                    }
                    return mDistribuidorpoliza;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public List<DistribuidorPoliza> getallDistribuidorpoliza(string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_distribuidorpoliza";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DistribuidorPoliza> lDistribuidorpoliza = new List<DistribuidorPoliza>();

                    while (reader.Read())
                    {
                        DistribuidorPoliza mDistribuidorpoliza = new DistribuidorPoliza();


                        mDistribuidorpoliza.Codigo = reader["codigo_distribuidor"].ToString().Trim();
                        mDistribuidorpoliza.Nombre = reader["nombre"].ToString();

                        lDistribuidorpoliza.Add(mDistribuidorpoliza);

                        mDistribuidorpoliza = null;
                    }
                    return lDistribuidorpoliza;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public string add_distribuidorpoliza(DistribuidorPoliza distribuidorpoliza)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_distribuidorpoliza", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", distribuidorpoliza.Codigo);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", distribuidorpoliza.Nombre);

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
