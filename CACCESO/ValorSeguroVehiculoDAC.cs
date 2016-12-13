using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ValorSeguroVehiculoDAC : CACCESO.BaseDAC
    {
        

        public string add_ValorSeguroVehiculo(string codigo_distribuidor, string codigo, Int32 valor,string id_seguro)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_act_valorsegurovehiculo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@id_seguro", Convert.ToInt32(id_seguro));


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

        public string add_seguros(string codigo_distribuidor, string codigo, Int32 valor,Int32 periodo,DateTime fecha_inicio,DateTime fecha_final)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_valorsegurovehiculo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@periodo", periodo);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_desde", fecha_inicio);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_hasta", fecha_final);


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


        public List<ValorSeguroVehiculo> getallvalorsegurovehiculo(string codigo_distribuidor,Int32 periodo,Int32 anno)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_valorsegurovehiculo";

                    cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@anno", anno);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ValorSeguroVehiculo> lvalorsegurovehiculo = new List<ValorSeguroVehiculo>();

                    while (reader.Read())
                    {
                        ValorSeguroVehiculo mvalorsegurovehiculo = new ValorSeguroVehiculo();

                        mvalorsegurovehiculo.Id_seguro = Convert.ToInt32(reader["id_seguro"].ToString());
                        mvalorsegurovehiculo.Codigo_distribuidor = reader["codigo_distribuidor"].ToString();
                        mvalorsegurovehiculo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                        mvalorsegurovehiculo.Valor =Convert.ToInt32(reader["valor"]);
                        mvalorsegurovehiculo.FechaDesde = Convert.ToDateTime(reader["fecha_desde"]);
                        mvalorsegurovehiculo.FechaHasta = Convert.ToDateTime(reader["fecha_hasta"]);
                        mvalorsegurovehiculo.Periodo = Convert.ToInt32(reader["periodo"]);
                        lvalorsegurovehiculo.Add(mvalorsegurovehiculo);

                        mvalorsegurovehiculo = null;
                    }
                    return lvalorsegurovehiculo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ValorSeguroVehiculo getallvalorsegurovehiculobycodigo(string codigo_distribuidor,string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_valorsegurovehiculobycodigo";

                    cmd.Parameters.AddWithValue("@codigo_distribuidor", codigo_distribuidor);
                    cmd.Parameters.AddWithValue("@codigo", codigo);


                    SqlDataReader reader = cmd.ExecuteReader();

                
                        ValorSeguroVehiculo mvalorsegurovehiculo = new ValorSeguroVehiculo();

                        if (reader.Read())
                        {
                            mvalorsegurovehiculo.Codigo = reader["codigo"].ToString();
                            mvalorsegurovehiculo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(reader["codigo"].ToString());
                            mvalorsegurovehiculo.Valor = Convert.ToInt32(reader["valor"]);

                        }
                        return mvalorsegurovehiculo;
                    }
                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
