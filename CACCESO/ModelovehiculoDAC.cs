using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class ModelovehiculoDAC : CACCESO.BaseDAC
    {
        public ModeloVehiculo getModelovehiculo(int id_modelo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Modelovehiculo";

                    cmd.Parameters.AddWithValue("@id_modelo", id_modelo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    ModeloVehiculo mModelovehiculo = new ModeloVehiculo();

                    if (reader.Read())
                    {


                        mModelovehiculo.Id_Modelo = Convert.ToInt16(reader["id_modelo"]);
                        mModelovehiculo.Nombre = reader["nombre"].ToString();
                        mModelovehiculo.ValorNox = Convert.ToInt32(reader["valorNox"].ToString());
                        mModelovehiculo.Rendimiento = Convert.ToInt32(reader["rendimiento"].ToString());
                        mModelovehiculo.Marcavehiculo = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt16(reader["id_marca_vehiculo"]));
                        mModelovehiculo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());

                    }
                    return mModelovehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModeloVehiculo> getallModelovehiculo(Int16 id_marca_vehiculo, string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Modelovehiculos";

                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_marca_vehiculo", id_marca_vehiculo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ModeloVehiculo> lModelovehiculo = new List<ModeloVehiculo>();

                    while (reader.Read())
                    {
                        ModeloVehiculo mModelovehiculo = new ModeloVehiculo();


                        mModelovehiculo.Id_Modelo = Convert.ToInt16(reader["id_modelo"]);
                        mModelovehiculo.Nombre = reader["nombre"].ToString();
                        mModelovehiculo.Marcavehiculo = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt16(reader["id_marca_vehiculo"]));
                        mModelovehiculo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo((reader["codigo"].ToString()));
                        
                        lModelovehiculo.Add(mModelovehiculo);

                        mModelovehiculo = null;
                    }
                    return lModelovehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<ModeloVehiculo> getallModelovehiculoexterno(Int16 id_marca_vehiculo)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_Modelovehiculos";

					
					cmd.Parameters.AddWithValue("@id_marca_vehiculo", id_marca_vehiculo);

					SqlDataReader reader = cmd.ExecuteReader();

					List<ModeloVehiculo> lModelovehiculo = new List<ModeloVehiculo>();

					while (reader.Read())
					{
						ModeloVehiculo mModelovehiculo = new ModeloVehiculo();


						mModelovehiculo.Id_Modelo = Convert.ToInt16(reader["id_modelo"]);
						mModelovehiculo.Nombre = reader["nombre"].ToString();
						mModelovehiculo.Marcavehiculo = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt16(reader["id_marca_vehiculo"]));
						mModelovehiculo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo((reader["codigo"].ToString()));

						lModelovehiculo.Add(mModelovehiculo);

						mModelovehiculo = null;
					}
					return lModelovehiculo;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}





        public string add_Modelovehiculo(ModeloVehiculo modelovehiculo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Modelovehiculo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_modelo_vehiculo", modelovehiculo.Id_Modelo);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", modelovehiculo.Nombre);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", modelovehiculo.Tipovehiculo.Codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_marca_vehiculo", modelovehiculo.Marcavehiculo.Id_marca);

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



        public ModeloVehiculo getModelovehiculoImpuesto(int id_modelo,DateTime fecha, Int32 monto)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_ModelovehiculoImpuesto";

                    cmd.Parameters.AddWithValue("@id_modelo", id_modelo);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@monto", monto);

                    SqlDataReader reader = cmd.ExecuteReader();

                    ModeloVehiculo mModelovehiculo = new ModeloVehiculo();

                    if (reader.Read())
                    {


                        mModelovehiculo.Id_Modelo = Convert.ToInt16(reader["id_modelo"]);
                        mModelovehiculo.Nombre = reader["nombre"].ToString();
                        mModelovehiculo.ValorNox = Convert.ToInt32(reader["valorNox"].ToString());
                        mModelovehiculo.Rendimiento = Convert.ToInt32(reader["rendimiento"].ToString());
                        mModelovehiculo.Marcavehiculo = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt16(reader["id_marca_vehiculo"]));
                        mModelovehiculo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                        mModelovehiculo.Impuesto = Convert.ToInt32(reader["impuesto"].ToString());

                    }
                    return mModelovehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
