using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class CuentabancoDAC : CACCESO.BaseDAC
    {
        public CuentaBanco getCuentabancobycuenta(string codigo_banco, int id_cuenta_banco)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_cuentabco";

                    cmd.Parameters.AddWithValue("@codigo_banco", codigo_banco);
                    cmd.Parameters.AddWithValue("@id_cuenta_banco", id_cuenta_banco);

                    SqlDataReader reader = cmd.ExecuteReader();

                    CuentaBanco mCuentabanco = new CuentaBanco();

                    if (reader.Read())
                    {

                        mCuentabanco.Id_cuenta_banco = Convert.ToInt16(reader["id_Cuenta_banco"].ToString());
                        mCuentabanco.Numero_cuenta = reader["numero_cuenta"].ToString();
                        mCuentabanco.Banco = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());

                    }
                    return mCuentabanco;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CuentaBanco getCuentabanco(Int16 id_Cuentabanco)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Cuentabanco";

                    cmd.Parameters.AddWithValue("@id_Cuentabanco", id_Cuentabanco);

                    SqlDataReader reader = cmd.ExecuteReader();

                    CuentaBanco mCuentabanco = new CuentaBanco();

                    if (reader.Read())
                    {

                        mCuentabanco.Id_cuenta_banco = Convert.ToInt16(reader["id_Cuenta_banco"].ToString());
                        mCuentabanco.Numero_cuenta = reader["numero_cuenta"].ToString();
                        mCuentabanco.Banco = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());

                    }
                    return mCuentabanco;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public List<CuentaBanco> getallCuentabanco(string codigo_banco)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_CuentabancobyBanco";

                    cmd.Parameters.AddWithValue("@codigo_banco", codigo_banco);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<CuentaBanco> lCuentabanco = new List<CuentaBanco>();

                    while (reader.Read())
                    {
                        CuentaBanco mCuentabanco = new CuentaBanco();


                        mCuentabanco.Id_cuenta_banco = Convert.ToInt16(reader["id_Cuenta_banco"].ToString());
                        mCuentabanco.Numero_cuenta = reader["numero_cuenta"].ToString();
                        mCuentabanco.Banco = new BancofinancieraDAC().getBancofinanciera(reader["codigo_banco"].ToString());



                        lCuentabanco.Add(mCuentabanco);

                        mCuentabanco = null;
                    }
                    return lCuentabanco;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string add_Cuentabanco(Int16 id_Cuentabanco, 
                                        string codigo_banco,
                                        string numero_cuenta)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_add_Cuentabanco", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo_banco", codigo_banco);
                    oParam = Cmd.Parameters.AddWithValue("@numero_cuenta", numero_cuenta);
                    oParam = Cmd.Parameters.AddWithValue("@id_cuenta_banco", id_Cuentabanco);
                    

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
