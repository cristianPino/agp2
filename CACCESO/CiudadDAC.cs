using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class CiudadDAC : CACCESO.BaseDAC
    {

        public Ciudad getciudad(Int16 id_ciudad)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_ciudad";
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Ciudad mCiudad = new Ciudad();
                    
                    if (reader.Read())
                    {

                        mCiudad.Id_Ciudad = Convert.ToInt16(reader["id_ciudad"]);
                        mCiudad.Nombre = reader["nombre"].ToString();
                        mCiudad.Region = new RegionDAC().getregion(Convert.ToInt16(reader["id_region"]));

                    }
                    return mCiudad;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Ciudad> getciudadbyregion(Int16 id_region)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_ciudadbyregion";

                    cmd.Parameters.AddWithValue("@id_region", id_region);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Ciudad> lCiudad = new List<Ciudad>();

                    while (reader.Read())
                    {

                        Ciudad mCiudad = new Ciudad();

                        mCiudad.Id_Ciudad = Convert.ToInt16(reader["id_ciudad"]);
                        mCiudad.Nombre = reader["nombre"].ToString();
                        mCiudad.Region = new RegionDAC().getregion(Convert.ToInt16(reader["id_region"]));

                        lCiudad.Add (mCiudad);
                        mCiudad = null;

                    }
                    return lCiudad;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string add_Ciudad(Ciudad Ciudad)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Ciudad", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_region", Ciudad.Region.Id_region);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", Ciudad.Nombre);

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
