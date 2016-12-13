using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class HomologacionPolizaDAC : CACCESO.BaseDAC
    {

        public string add_homologacionpoliza(string codigo_distribuidor, string codigo, Int32 CodigoTipVehDist)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_homologacionpoliza", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    oParam = Cmd.Parameters.AddWithValue("@CodigoTipVehDist", CodigoTipVehDist);
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


        public List<HomologacionPoliza> getHomologacionpoliza(string codigo_distribuidor)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_HomoTipVehDist";

                    cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<HomologacionPoliza> lhomologacionpoliza= new List<HomologacionPoliza>();

                    while (reader.Read())
                    {
                        HomologacionPoliza mhomologacionpoliza= new HomologacionPoliza();


                        mhomologacionpoliza.Codigo = reader["codigo"].ToString();
                        mhomologacionpoliza.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                        mhomologacionpoliza.CodigoTipVehDist = Convert.ToInt32(reader["codigoTipVehDist"].ToString());

                        lhomologacionpoliza.Add(mhomologacionpoliza);
                        mhomologacionpoliza = null;
                    }
                    return lhomologacionpoliza;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HomologacionPoliza getHomologacionpolizabycodigo(string codigo_distribuidor, string codigoTipVehDist)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_HomoTipVehDistbycodigo";

                    cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    cmd.Parameters.AddWithValue("@codigoTipVehDist", codigoTipVehDist);
                    SqlDataReader reader = cmd.ExecuteReader();

                    HomologacionPoliza mhomologacionpoliza = new HomologacionPoliza();

                    if (reader.Read())
                    {
                        mhomologacionpoliza.Codigo = reader["codigo"].ToString();
                        mhomologacionpoliza.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                        mhomologacionpoliza.CodigoTipVehDist = Convert.ToInt32(reader["codigoTipVehDist"].ToString());

                       
                    }
                    return mhomologacionpoliza;
                }
               
                }

            
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
