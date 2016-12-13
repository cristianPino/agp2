using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class ParametrotipoDAC : CACCESO.BaseDAC
    {

        //public Parametrotipo getparametrotipo(string codigotipoparametro)
        //{

        //    try
        //    {
        //        using (SqlConnection sqlConn = new SqlConnection(this.strConn))
        //        {
        //            sqlConn.Open();

        //            SqlCommand cmd = new SqlCommand(strConn, sqlConn);

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            cmd.CommandText = "sp_r_Parametrotipo";

        //            cmd.Parameters.AddWithValue("@codigotipoparametro", codigotipoparametro);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            Parametrotipo mParametrotipo = new Parametrotipo();

        //            if (reader.Read())
        //            {


        //                mParametrotipo.Codigotipoparametro = reader["codigotipoparametro"].ToString();
        //                mParametrotipo.Descripcion = reader["descripcion"].ToString();

        //            }
        //            return mParametrotipo;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}






        public List<Parametrotipo> getallparametrotipo(string codigotipoparametro)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_parametrotipo";

                    cmd.Parameters.AddWithValue("@codigotipoparametro", codigotipoparametro);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Parametrotipo> lParametrotipo = new List<Parametrotipo>();

                    while (reader.Read())
                    {
                        Parametrotipo mParametrotipo = new Parametrotipo();


                        mParametrotipo.Codigotipoparametro = reader["codigotipoparametro"].ToString();
                        mParametrotipo.Descripcion = reader["decripcion"].ToString();

                        lParametrotipo.Add(mParametrotipo);

                        mParametrotipo = null;
                    }
                    return lParametrotipo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public string add_parametrotipo(Parametrotipo parametrotipo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Parametrotipo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigotipoparametro", parametrotipo.Codigotipoparametro);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", parametrotipo.Descripcion);

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

