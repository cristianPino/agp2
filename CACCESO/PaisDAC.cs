using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class PaisDAC : CACCESO.BaseDAC
    {

        public Pais getpais(string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_paises";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Pais mPais = new Pais();

                    if (reader.Read())
                    {
                        

                        mPais.Codigo = reader["codigo"].ToString();
                        mPais.Nombre = reader["nombre"].ToString();
                     
                    }
                    return mPais;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
    



        public List<Pais> getallpais(string codigo)
    {
    
     try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_paises";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    List<Pais> lPais = new List<Pais>();
                    
                    while (reader.Read())
                    {
                        Pais  mPais = new Pais();


                        mPais.Codigo  = reader["codigo"].ToString();
                        mPais.Nombre = reader["nombre"].ToString();
                   
                        lPais.Add(mPais);

                        mPais= null;
                    }
                    return lPais;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
    


        public string add_pais(Pais pais)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_pais", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", pais.Codigo);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
                    
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
