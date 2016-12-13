using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ParametroDAC : CACCESO.BaseDAC
	{

		public List<Parametro> GetParametroByTipoParametro(string strTipo)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				try
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_Parametrobytipo";
					cmd.Parameters.AddWithValue("@tipoparametro", strTipo);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Parametro> lParametro = new List<Parametro>();
					while (reader.Read())
					{
						Parametro mParametro = new Parametro();
						mParametro.Codigoparametro = reader["codigoparametro"].ToString();
						mParametro.Valoralfanumerico = reader["ValorAlfanumerico"].ToString();
						mParametro.Valornumerico = Convert.ToDouble(reader["ValorNumero"]);
						mParametro.Orden = Convert.ToInt32(reader["orden"]);
						lParametro.Add(mParametro);
						mParametro = null;
					}
					sqlConn.Close();
					return lParametro;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}


        public Parametro getparametro(string tipo, string codigo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Parametro";
                    cmd.Parameters.AddWithValue("@tipoparametro", tipo);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Parametro mParametro = new Parametro();

                    if (reader.Read())
                    {

                        mParametro.Codigoparametro = reader["codigoparametro"].ToString();
                        mParametro.Valoralfanumerico = reader["ValorAlfanumerico"].ToString();
                        mParametro.Valornumerico = Convert.ToDouble(reader["ValorNumero"]);
                        mParametro.Orden = Convert.ToInt32(reader["orden"]);


                    }
                    else
                    {
                        mParametro = null;
                    }
                    sqlConn.Close();
                    return mParametro;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

	}
}