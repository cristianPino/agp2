using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class PredatovehiculoDAC : CACCESO.BaseDAC
    {

        public string add_Predatovehiculo(Predatovehiculo predatovehiculo, Int32 id_solicitud)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_w_predatovehiculo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@id_modelo", predatovehiculo.Modelo.Id_Modelo);
                    oParam = Cmd.Parameters.AddWithValue("@chassis", predatovehiculo.Chassis);
                    oParam = Cmd.Parameters.AddWithValue("@ano", predatovehiculo.Ano);
                    oParam = Cmd.Parameters.AddWithValue("@motor", predatovehiculo.Motor);
                    oParam = Cmd.Parameters.AddWithValue("@cilindraje", predatovehiculo.Cilindraje);
                    oParam = Cmd.Parameters.AddWithValue("@patente", predatovehiculo.Patente);
                    oParam = Cmd.Parameters.AddWithValue("@color", predatovehiculo.Color);
                    oParam = Cmd.Parameters.AddWithValue("@carga", predatovehiculo.Carga);
                    oParam = Cmd.Parameters.AddWithValue("@pesobruto", predatovehiculo.Pesobruto);
                    oParam = Cmd.Parameters.AddWithValue("@combustible", predatovehiculo.Combustible);
                    oParam = Cmd.Parameters.AddWithValue("@npuerta", predatovehiculo.N_puerta);
                    oParam = Cmd.Parameters.AddWithValue("@nasiento", predatovehiculo.N_asiento);
                    oParam = Cmd.Parameters.AddWithValue("@dv", predatovehiculo.Dv);
                    
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


        public Predatovehiculo GetPredatovehiculobyIdSolicitud(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_PredatovehiculobyIdSolicitud";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Predatovehiculo mPredatovehiculo =   new Predatovehiculo();

                    if (reader.Read())
                    {


                        mPredatovehiculo.Modelo = new ModelovehiculoDAC().getModelovehiculo(Convert.ToInt16(reader["id_modelo"].ToString()));
                        mPredatovehiculo.Chassis = reader["chassis"].ToString();
                        mPredatovehiculo.Ano = Convert.ToInt16(reader["ano"].ToString());
                        mPredatovehiculo.Motor = reader["motor"].ToString();
                        mPredatovehiculo.Cilindraje = reader["cilindraje"].ToString();
                        mPredatovehiculo.Patente = reader["patente"].ToString();
                        mPredatovehiculo.Color = reader["color"].ToString();
                        mPredatovehiculo.Carga = Convert.ToDouble(reader["carga"].ToString());
                        mPredatovehiculo.Pesobruto = Convert.ToDouble(reader["pesobruto"].ToString());
                        mPredatovehiculo.Combustible = reader["combustible"].ToString();
                        mPredatovehiculo.N_asiento = Convert.ToInt16(reader["nasiento"].ToString());
                        mPredatovehiculo.N_puerta = Convert.ToInt16(reader["npuerta"].ToString());
                    }
                    else
                    { mPredatovehiculo = null;  }
                   
                    
                    return mPredatovehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
