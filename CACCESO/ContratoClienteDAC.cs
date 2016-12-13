using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ContratoClienteDAC : CACCESO.BaseDAC
    {

        public string add_Contrato_cliente(Int32 id_contrato, Int32 id_cliente,string codigo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_contrato_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);

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

        public string del_contrato_cliente(Int32 id_contrato, Int32 id_cliente, string codigo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_contrato_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_contrato", id_contrato);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);


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

        public List<ContratoCliente> getContratoByCliente(Int32 id_cliente, string all)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_ContratoByCliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@all", all);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ContratoCliente> lcontratoCliente = new List<ContratoCliente>();

                    while (reader.Read())
                    {
                        ContratoCliente mContratocliente = new ContratoCliente();


                        mContratocliente.Nombre =reader["nombre"].ToString();
                        mContratocliente.Id_contrato =Convert.ToInt32(reader["id_contrato"].ToString());
                        mContratocliente.Check = Convert.ToBoolean(reader["check"]);



                        lcontratoCliente.Add(mContratocliente);

                        mContratocliente = null;
                    }
                    return lcontratoCliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ContratoCliente> getContratoByClienteProducto(Int32 id_cliente, string all,string producto)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_ContratoByClienteProducto";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@all", all);
                    cmd.Parameters.AddWithValue("@producto", producto);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ContratoCliente> lcontratoCliente = new List<ContratoCliente>();

                    while (reader.Read())
                    {
                        ContratoCliente mContratocliente = new ContratoCliente();


                        mContratocliente.Nombre = reader["nombre"].ToString();
                        mContratocliente.Id_contrato = Convert.ToInt32(reader["id_contrato"].ToString());
                        mContratocliente.Check = Convert.ToBoolean(reader["check"]);



                        lcontratoCliente.Add(mContratocliente);

                        mContratocliente = null;
                    }
                    return lcontratoCliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
