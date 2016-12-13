using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class AcreedorDAC : CACCESO.BaseDAC
    {





        public DataSet getPagosgrid()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_PagosGrid";

                    cmd.Parameters.AddWithValue("@id_solicitud", 249477);
                    cmd.Parameters.AddWithValue("@tipo_oper", "transferencia");
                    SqlDataAdapter DaRec2 = new SqlDataAdapter(cmd);
                    DataTable DtLocal = new DataTable();
                    DataSet DsLocal = new DataSet();

                    DaRec2.Fill(DsLocal);    

                    return DsLocal;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string add_prohibicion(Int32 id_prohibicion, Int32 rut_acreedor)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_acreedor", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_prohibicion", id_prohibicion);
                    oParam = Cmd.Parameters.AddWithValue("@rut_acreedor", rut_acreedor);

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


        public string del_prohibicion(Int32 id_prohibicion)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_acreedor", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_prohibicion", id_prohibicion);

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


        public List<Acreedor> get_acreedores(Int32 id_prohibicion)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_acreedores";
                    cmd.Parameters.AddWithValue("@id_prohibicion", id_prohibicion);

                    cmd.CommandTimeout = 0;

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Acreedor> lacreedor = new List<Acreedor>();
                    while (reader.Read())
                    {
                        Acreedor macreedor= new Acreedor();


                        macreedor.P_acreedor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_acreedor"]));
                        macreedor.Id_acreedor = Convert.ToInt32(reader["id_acreedor"]);
                        macreedor.Id_prohibicion = Convert.ToInt32(reader["id_prohibicion"].ToString());

                        lacreedor.Add(macreedor);
                        macreedor = null;
                    }


                    return lacreedor;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
