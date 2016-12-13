using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;


namespace CACCESO
{
	public class BancofinancieraDAC : CACCESO.BaseDAC
	{
		public BancoFinanciera getBancofinanciera(string codigo)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_bancofinancierabycodigo";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					BancoFinanciera mBancofinanciera = new BancoFinanciera();
                    if (reader.Read())
                    {
                        mBancofinanciera.Codigo = reader["codigo_banco"].ToString();
                        mBancofinanciera.Nombre = reader["nombre"].ToString();
                    }
                    else
                    {
                        mBancofinanciera = null;  
                    
                    }
					return mBancofinanciera;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<BancoFinanciera> getFinancieraall(string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_bancofinancierausuario";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
					while (reader.Read())
					{
						BancoFinanciera mBancofinanciera = new BancoFinanciera();
						mBancofinanciera.Codigo_banco = reader["codigo_banco"].ToString().Trim();
						mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
						mBancofinanciera.Check =Convert.ToBoolean(reader["chk"].ToString().Trim());
						lBancofinanciera.Add(mBancofinanciera);
						mBancofinanciera = null;
					}
					return lBancofinanciera;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public int add_usuario_financiera(string cuenta_usuario, string financiera)
		{
			int insercion = 0;
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_add_usuario_financiera";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@financiera", financiera);
					
					insercion = cmd.ExecuteNonQuery();
					return insercion;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public int del_usuario_financiera(string cuenta_usuario, string financiera)
		{
			int insercion = 0;
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_del_usuario_financiera";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@financiera", financiera);

					insercion = cmd.ExecuteNonQuery();
					return insercion;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}


        public List<BancoFinanciera> getFinancieraCliente(Int32 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_GetFinancieraCliente";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
                    while (reader.Read())
                    {
                        BancoFinanciera mBancofinanciera = new BancoFinanciera();
                        mBancofinanciera.Codigo = reader["codigo_banco"].ToString().Trim();
                        mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
                        lBancofinanciera.Add(mBancofinanciera);
                        mBancofinanciera = null;
                    }
                    return lBancofinanciera;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public List<BancoFinanciera> getallBancofinanciera(string codigo,Int32 id_cliente)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_bancofinanciera";
					cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					SqlDataReader reader = cmd.ExecuteReader();
					List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
					while (reader.Read())
					{
						BancoFinanciera mBancofinanciera = new BancoFinanciera();
						mBancofinanciera.Codigo = reader["codigo_banco"].ToString().Trim();
						mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
						lBancofinanciera.Add(mBancofinanciera);
						mBancofinanciera = null;
					}
					return lBancofinanciera;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public BancoFinanciera gettipodocbanco(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "get_tipodocumento";
                    cmd.Parameters.AddWithValue("@id", codigo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    BancoFinanciera mBancofinanciera = new BancoFinanciera();
                    if (reader.Read())
                    {
                        mBancofinanciera.Codigo = reader["CodigoTipoParametro"].ToString();
                        mBancofinanciera.Nombre = reader["ValorAlfanumerico"].ToString();
                    }
                    return mBancofinanciera;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public string add_bancofinanciera(BancoFinanciera bancofinanciera)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_bancofinanciera", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", bancofinanciera.Codigo);
					oParam = Cmd.Parameters.AddWithValue("@nombre", bancofinanciera.Nombre);
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

		public string add_bancofinanciera_automatica(string nombre)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_bancofinanciera_automatico", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@nombre", nombre);
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

        public List<BancoFinanciera> getallBancoallfinanciera()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_bancoallfinanciera";

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
                    while (reader.Read())
                    {
                        BancoFinanciera mBancofinanciera = new BancoFinanciera();
                        mBancofinanciera.Codigo = reader["codigo_banco"].ToString().Trim();
                        mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
                        lBancofinanciera.Add(mBancofinanciera);
                        mBancofinanciera = null;
                    }
                    return lBancofinanciera;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



		public List<BancoFinanciera> getallBancoallfinancieraconces()
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_bancoallfinancieraconces";

					SqlDataReader reader = cmd.ExecuteReader();
					List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
					while (reader.Read())
					{
						BancoFinanciera mBancofinanciera = new BancoFinanciera();
						mBancofinanciera.Codigo = reader["codigo_banco"].ToString().Trim();
						mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
						lBancofinanciera.Add(mBancofinanciera);
						mBancofinanciera = null;
					}
					return lBancofinanciera;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}





        public List<BancoFinanciera> getallBancoallfinancieracliente(int id_clientef)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_bancoallfinancieracliente";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@id_clientef", id_clientef);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
                    while (reader.Read())
                    {
                        BancoFinanciera mBancofinanciera = new BancoFinanciera();
                        mBancofinanciera.Codigo = reader["id_cliente"].ToString().Trim();
                        mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
                        lBancofinanciera.Add(mBancofinanciera);
                        mBancofinanciera = null;
                    }
                    return lBancofinanciera;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<BancoFinanciera> getallBancoallfinancieracliente2(int id_clientef)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Clientefinancieraxcliente";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@id_cliente", id_clientef);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BancoFinanciera> lBancofinanciera = new List<BancoFinanciera>();
                    while (reader.Read())
                    {
                        BancoFinanciera mBancofinanciera = new BancoFinanciera();
                        mBancofinanciera.Codigo = reader["id_cliente"].ToString().Trim();
                        mBancofinanciera.Nombre = reader["nombre"].ToString().Trim();
                        lBancofinanciera.Add(mBancofinanciera);
                        mBancofinanciera = null;
                    }
                    return lBancofinanciera;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




	}
}