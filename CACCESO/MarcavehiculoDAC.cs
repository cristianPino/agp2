using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class MarcavehiculoDAC : CACCESO.BaseDAC
    {
        public Marcavehiculo getMarcavehiculo(int id_marca)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Marcavehiculo";

                    cmd.Parameters.AddWithValue("@id_marca", id_marca);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Marcavehiculo mMarcavehiculo = new Marcavehiculo();

                    if (reader.Read())
                    {


                        mMarcavehiculo.Id_marca = Convert.ToInt16(reader["id_marca_vehiculo"]);
                        mMarcavehiculo.Nombre = reader["nombre"].ToString();

                    }
                    return mMarcavehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Marcavehiculo> getallMarcavehiculo()
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Marcavehiculos";


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Marcavehiculo> lMarcavehiculo = new List<Marcavehiculo>();

                    while (reader.Read())
                    {
                        Marcavehiculo mMarcavehiculo = new Marcavehiculo();


                        mMarcavehiculo.Id_marca = Convert.ToInt16( reader["id_marca_vehiculo"]);
                        mMarcavehiculo.Nombre = reader["nombre"].ToString();

                        lMarcavehiculo.Add(mMarcavehiculo);

                        mMarcavehiculo = null;
                    }
                    return lMarcavehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public string add_Marcavehiculo(Marcavehiculo marcavehiculo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Marcavehiculo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_marca_vehiculo", marcavehiculo.Id_marca);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", marcavehiculo.Nombre);

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

