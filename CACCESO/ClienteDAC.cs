using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ClienteDAC : CACCESO.BaseDAC
	{

		public string add_cliente(Int32 rut_persona)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut", rut_persona);
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

        public List<Cliente> getclienteship()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_clientehip";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cliente> lCliente = new List<Cliente>();
                    while (reader.Read())
                    {
                        Cliente mCliente = new Cliente();
                        mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
                        mCliente.Imagen = reader["imagen"].ToString();
                        mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
                        mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
                        mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
                        lCliente.Add(mCliente);
                    }
                    sqlConn.Close();
                    return lCliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



		public string add_clientefinanciera(Int32 rut_persona, string financiera)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_cliente_financiera", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", rut_persona);
					 oParam = Cmd.Parameters.AddWithValue("@financiera", financiera);
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


		public string del_usuario_cliente(Int16 id_cliente, string cuenta_usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_usuario_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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

		public string add_usuario_cliente(Int16 id_cliente, string cuenta_usuario)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_usuario_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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

		public Cliente Getcliente(Int16 id_cliente)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_clientebyid";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					SqlDataReader reader = cmd.ExecuteReader();
					Cliente mCliente = new Cliente();
					if (reader.Read())
					{
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Imagen = reader["imagen"].ToString();
						mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
						mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
						mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
                        mCliente.Codigo_nav = reader["codigo_nav"].ToString();
                        mCliente.Facturanav = reader["folionav"].ToString();
					}
                    sqlConn.Close();
					return mCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Cliente GetClienteByUsuario(string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_clientebyusrname";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					Cliente mCliente = new Cliente();
					if (reader.Read())
					{
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Imagen = reader["imagen"].ToString();
						mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
						mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
						mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
					}
                    sqlConn.Close();
					return mCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Cliente> getclientes()
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_cliente";
					SqlDataReader reader = cmd.ExecuteReader();
					List<Cliente> lCliente = new List<Cliente>();
					while (reader.Read())
					{
						Cliente mCliente = new Cliente();
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Imagen = reader["imagen"].ToString();
						mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
						mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
						mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
						lCliente.Add(mCliente);
					}
                    sqlConn.Close();
					return lCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ClienteFinanciera> getclientesfinan()
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_clientefinanciera";
					SqlDataReader reader = cmd.ExecuteReader();
					List<ClienteFinanciera> lCliente = new List<ClienteFinanciera>();
					while (reader.Read())
					{
						ClienteFinanciera mCliente = new ClienteFinanciera();
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Financiera = reader["nombre"].ToString();
						mCliente.Check = Convert.ToBoolean(reader["check"].ToString());
						
						lCliente.Add(mCliente);
					}
                    sqlConn.Close();
					return lCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ClienteFinanciera> getclientesfinantxt(string cuenta_usuario, DateTime fechadesde, DateTime fechahasta)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getOperacionesAmicar";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					cmd.Parameters.AddWithValue("@desde", fechadesde);
					cmd.Parameters.AddWithValue("@hasta", fechahasta);
					SqlDataReader reader = cmd.ExecuteReader();
					List<ClienteFinanciera> lCliente = new List<ClienteFinanciera>();
					while (reader.Read())
					{
						ClienteFinanciera mCliente = new ClienteFinanciera();
						mCliente.Rutcliente = reader["rut_cliente"].ToString();
						mCliente.Nombrecliente = reader["nombre_cliente"].ToString();
						mCliente.Financiera = reader["financiera"].ToString();
						mCliente.Fechafel = reader["fecha_fel"].ToString();
                        mCliente.Url_carpeta = reader["url_carpeta"].ToString();
                        mCliente.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"].ToString()));
                        mCliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));


                        lCliente.Add(mCliente);
					}
                    sqlConn.Close();
					return lCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Cliente> getclientesbyusuario(string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getclientebyusuario";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Cliente> lCliente = new List<Cliente>();
					while (reader.Read())
					{
						Cliente mCliente = new Cliente();
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Imagen = reader["imagen"].ToString();
						mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
						mCliente.Check = Convert.ToBoolean(reader["check"]);
						mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
						mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
						lCliente.Add(mCliente);
					}
                    sqlConn.Close();
					return lCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Cliente> getUsuarioclientes(string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getUsuariocliente";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Cliente> lCliente = new List<Cliente>();
					while (reader.Read())
					{
						Cliente mCliente = new Cliente();
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Imagen = reader["imagen"].ToString();
						mCliente.Persona = new Persona{Rut = Convert.ToDouble(reader["rut"]),Nombre = reader["nombre"].ToString()};
						mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
						mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
						lCliente.Add(mCliente);
					}
                    sqlConn.Close();
					return lCliente;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Cliente getClientePorRut(double rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_clientebyrut";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					Cliente mCliente = new Cliente();
					if (reader.Read())
					{
						mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mCliente.Imagen = reader["imagen"].ToString();
						mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
						mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
						mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
					}
                    sqlConn.Close();
					return mCliente;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public Cliente getClienteusuario(double rut_cliente,string cuenta_usuario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_clientebyusuario";
                    cmd.Parameters.AddWithValue("@rut_cliente", rut_cliente);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Cliente mCliente = new Cliente();
                    if (reader.Read())
                    {
                        mCliente.Check= Convert.ToBoolean(reader["check"]);
                        
                    }
                    sqlConn.Close();
                    return mCliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Cliente> Get_clientesAgp_hipoteca()
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_clientesAgp_hipoteca";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cliente> lCliente = new List<Cliente>();
                    while (reader.Read())
                    {
                        Cliente mCliente = new Cliente();
                        mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
                        mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
                        lCliente.Add(mCliente);
                    }
                    sqlConn.Close();
                    return lCliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Cliente Getclientefac(Int16 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_clientebyidfac";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Cliente mCliente = new Cliente();
                    if (reader.Read())
                    {
                        mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
                        mCliente.Imagen = reader["imagen"].ToString();
                        mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
                        mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
                        mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
                        mCliente.Codigo_nav = reader["codigo_nav"].ToString();
                        mCliente.Facturanav = reader["folionav"].ToString();
                        mCliente.Direccion = reader["direccion"].ToString();
                        mCliente.Numero = reader["numero"].ToString();
                        mCliente.Complemento = reader["complemento"].ToString();
                    }
                    sqlConn.Close();
                    return mCliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Cliente GetclientefacVTA(Int32 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_clientebyidfac";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Cliente mCliente = new Cliente();
                    if (reader.Read())
                    {
                        mCliente.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
                        mCliente.Imagen = reader["imagen"].ToString();
                        mCliente.Persona = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
                        mCliente.Id_webservice = Convert.ToInt16(reader["id_webservice"]);
                        mCliente.Fondo_Pantalla = reader["fondo_pantalla"].ToString();
                        mCliente.Codigo_nav = reader["codigo_nav"].ToString();
                        mCliente.Facturanav = reader["folionav"].ToString();
                        mCliente.Direccion = reader["direccion"].ToString();
                        mCliente.Numero = reader["numero"].ToString();
                        mCliente.Complemento = reader["complemento"].ToString();
                    }
                    sqlConn.Close();
                    return mCliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


	}
}