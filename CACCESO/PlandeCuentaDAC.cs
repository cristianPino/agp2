using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class PlandeCuentaDAC : CACCESO.BaseDAC
    {

        public PlandeCuenta getplan(string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_plandecuenta";

                    cmd.Parameters.AddWithValue("@cuenta", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    PlandeCuenta mPlan = new PlandeCuenta();

                    if (reader.Read())
                    {


                        mPlan.Cuenta = reader["cuenta"].ToString();
                        mPlan.Nombre = reader["nombre"].ToString();

                    }

                    else

                    { mPlan = null;  }
                    
                    return mPlan;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
    



        public List<PlandeCuenta> getallplan(string codigo)
    {
    
     try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_plandecuenta";

                    cmd.Parameters.AddWithValue("@cuenta", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    List<PlandeCuenta> lPlande = new List<PlandeCuenta>();
                    
                    while (reader.Read())
                    {
                        PlandeCuenta  mPlan = new PlandeCuenta();

						
                       
                         mPlan.Cuenta  = reader["cuenta"].ToString();
						 mPlan.Nombre = reader["nombre"].ToString();
                   
                        lPlande.Add(mPlan);

                        mPlan= null;
                    }
                    return lPlande;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<PlandeCuenta> getallplan2(string codigo)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_plandecuenta";

					cmd.Parameters.AddWithValue("@cuenta", codigo);

					SqlDataReader reader = cmd.ExecuteReader();

					List<PlandeCuenta> lPlande = new List<PlandeCuenta>();

					while (reader.Read())
					{
						PlandeCuenta mPlan = new PlandeCuenta();



						mPlan.Cuenta = reader["cuenta"].ToString();
						mPlan.Nombre = reader["nombre"].ToString();

						lPlande.Add(mPlan);

						mPlan = null;
					}
					return lPlande;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
    
    


        public string add_plan(PlandeCuenta plan)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


					SqlCommand Cmd = new SqlCommand("sp_add_plan", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta", plan.Cuenta);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", plan.Nombre);
                    
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
