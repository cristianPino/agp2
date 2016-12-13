using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class FormaPagoDAC : CACCESO.BaseDAC
    {
        public string add_formapago(Int32 id_cliente, string descripcion)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_formapago", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
                 
             
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


        public List<FormaPago> getformapagobycliente(Int32 id_cliente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_formapago";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<FormaPago> lformapago = new List<FormaPago>();

                    while (reader.Read())
                    {

                        FormaPago mformapago= new FormaPago();

                        mformapago.Id_forma_pago= Convert.ToInt32(reader["id_forma_pago"]);
                        mformapago.Descripcion= reader["descripcion"].ToString();


                        lformapago.Add(mformapago);
                        mformapago = null;

                    }
                    return lformapago;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FormaPago getformapago(Int32 id_forma_pago)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_formapagobyid";

                    cmd.Parameters.AddWithValue("@id_forma_pago", id_forma_pago);

                    SqlDataReader reader = cmd.ExecuteReader();



                    FormaPago mformapago= new FormaPago();

                    if (reader.Read())
                    {



                        mformapago.Id_forma_pago= Convert.ToInt32(reader["id_forma_pago"]);
                        mformapago.Id_cliente= Convert.ToInt32(reader["id_cliente"].ToString());
                        mformapago.Descripcion= reader["descripcion"].ToString();


                    }
                    return mformapago;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
