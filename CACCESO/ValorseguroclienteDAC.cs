using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ValorseguroclienteDAC : CACCESO.BaseDAC
    {
        public string add_ValorSegurocliente(string id_cliente, string codigo, Int32 valor,Int32 valorAGP,Int32 id_seguro_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_act_valorsegurocliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@valorAGP", valorAGP);
                    oParam = Cmd.Parameters.AddWithValue("@id_seguro_cliente", id_seguro_cliente);
                 
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

        public string add_seguros(string id_cliente, string codigo, Int32 valor, Int32 valorAGP, Int32 periodo,DateTime fecha_desde,DateTime fecha_hasta)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_seguro_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@valorAGP", valorAGP);
                    oParam = Cmd.Parameters.AddWithValue("@periodo", periodo);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

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



        public List<ValorSeguroCliente> getallvalorsegurocliente(Int32 id_cliente,Int32 periodo,Int32 anno)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_valorsegurocliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@anno", anno);
                    cmd.Parameters.AddWithValue("@periodo", periodo);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ValorSeguroCliente> lvalorsegurocliente = new List<ValorSeguroCliente>();

                    while (reader.Read())
                    {
                        ValorSeguroCliente mvalorsegurocliente = new ValorSeguroCliente();

                        mvalorsegurocliente.Id_seguro_cliente=Convert.ToInt32(reader["id_seguro_cliente"].ToString());
                        mvalorsegurocliente.Codigo = reader["codigo"].ToString();
                        mvalorsegurocliente.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                        mvalorsegurocliente.Valor = Convert.ToInt32(reader["valor"]);
                        mvalorsegurocliente.ValorAGP = Convert.ToInt32(reader["valorAGP"]);
                        mvalorsegurocliente.FechaDesde =Convert.ToDateTime(reader["fecha_desde"].ToString());
                        mvalorsegurocliente.FechaHasta = Convert.ToDateTime(reader["fecha_hasta"].ToString());
                        mvalorsegurocliente.Periodo =Convert.ToInt32(reader["periodo"].ToString());

                        lvalorsegurocliente.Add(mvalorsegurocliente);

                        mvalorsegurocliente = null;
                    }
                    return lvalorsegurocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ValorSeguroCliente getallvalorseguroclientebycodigo(Int32 id_cliente,string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_valorseguroclientebycodigo";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);


                    SqlDataReader reader = cmd.ExecuteReader();

               
                        ValorSeguroCliente mvalorsegurocliente = new ValorSeguroCliente();

                        if (reader.Read())
                        {
                            mvalorsegurocliente.Codigo = reader["codigo"].ToString();
                            mvalorsegurocliente.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                            mvalorsegurocliente.Valor = Convert.ToInt32(reader["valor"]);
                            mvalorsegurocliente.ValorAGP = Convert.ToInt32(reader["valorAGP"]);
                        }

                        return mvalorsegurocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
