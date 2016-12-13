using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class VentaSoapDAC : CACCESO.BaseDAC
    {
        public VentaSoap getSoap(Int32 id_solicitud, string codigo_distribuidor,string fecha_desde)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_wsventasoap";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);

                    SqlDataReader reader = cmd.ExecuteReader();

                    VentaSoap mventasoap= new VentaSoap();

                    if (reader.Read())
                    {
                        mventasoap.Ano = Convert.ToInt32(reader["ano"]);
                        mventasoap.Apellidomaterno = reader["apellido_materno"].ToString();
                        mventasoap.Apellidopaterno = reader["apellido_paterno"].ToString();
                        mventasoap.CodigoTipVehDisy = Convert.ToInt32(reader["CodigoTipVehDist"]);
                        mventasoap.Correo = reader["correo"].ToString();
                        mventasoap.Dvp = reader["dvp"].ToString();
                        mventasoap.Dvr = reader["dvr"].ToString();
                        mventasoap.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mventasoap.Marca = reader["marca"].ToString();
                        mventasoap.Modelo = reader["modelo"].ToString();
                        mventasoap.Motor = reader["motor"].ToString();
                        mventasoap.Nombre = reader["nombre"].ToString();
                        mventasoap.Patente = reader["patente"].ToString();
                        mventasoap.Prima = Convert.ToInt32(reader["prima"].ToString());
                        mventasoap.Telefono = reader["telefono"].ToString();
                        mventasoap.Rut = reader["rut_cliente"].ToString();
                    }
                    return mventasoap;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
