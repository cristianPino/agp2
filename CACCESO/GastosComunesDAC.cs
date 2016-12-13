using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
	public class GastosComunesDAC : CACCESO.BaseDAC
	{
		public List<GastosComunes> getallGastosComunes(int id_familia)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastosComunes";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<GastosComunes> lGastosComunes = new List<GastosComunes>();
					while (reader.Read())
					{
						lGastosComunes.Add(new GastosComunes()
						{
							Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"].ToString()),
							Descripcion = reader["descripcion"].ToString(),
							Valor = Convert.ToInt32(reader["valor"].ToString()),
							Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString()),
							Transferencia = Convert.ToBoolean(reader["transferencia"].ToString()),
							Bloqueo = Convert.ToBoolean(reader["bloqueo"]),
							Id_familia = Convert.ToInt32(reader["id_familia"].ToString()),
					        Plandecuenta  = new PlandeCuentaDAC().getplan( reader["plan_de_cuenta"].ToString().Trim()),
							Proveedor = reader["proveedor"].ToString(),
							Factura = Convert.ToBoolean(reader["factura"]),
							Opcional = Convert.ToBoolean(reader["opcional"]),
							Cuenta_facturacion = reader["cuenta_facturacion"].ToString()

                             
						});
					}
					return lGastosComunes;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_GastoasComunes(Int32 id_tipogasto, int valor, string descripcion, string cargo_contable, string transferencia, string bloqueo, int id_familia, string plandecta, string proveedor, string factura,string opcional, string ctafac)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{

				if (bloqueo == "True")
				{
					bloqueo = "1";
				}
				else
				{
					bloqueo = "0";
				}
		
				
				sqlConn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_add_GastosComunes", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					cmd.Parameters.AddWithValue("@valor", valor);
					cmd.Parameters.AddWithValue("@descripcion", descripcion);
					cmd.Parameters.AddWithValue("@cargo_contable", cargo_contable);
					cmd.Parameters.AddWithValue("@transferencia", transferencia);
					cmd.Parameters.AddWithValue("@bloqueo", bloqueo);
					cmd.Parameters.AddWithValue("@factura", factura);
					cmd.Parameters.AddWithValue("@opcional", opcional);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@plandecta",plandecta);
					cmd.Parameters.AddWithValue("@ctafact", ctafac);
					cmd.Parameters.AddWithValue("@proveedor", proveedor);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return "";
		}

		public GastosComunes getGastosComunes(Int32 id_tipogasto)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastosComunesDes";
					cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					SqlDataReader reader = cmd.ExecuteReader();
					GastosComunes mGastosComunes = new GastosComunes();
					if (reader.Read())
					{
						mGastosComunes.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"].ToString());
						mGastosComunes.Descripcion = reader["descripcion"].ToString();
						mGastosComunes.Valor = Convert.ToInt32(reader["valor"].ToString());
						mGastosComunes.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
                        mGastosComunes.Cuenta_grupo = reader["plan_de_cuenta"].ToString().Trim();
					}
					return mGastosComunes;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public string add_cotizacion(string id_marca_vehiculo, string fecha_factura, int monto, string vendedor, string adquiriente)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_cotizacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_marca_vehiculo", id_marca_vehiculo);
                    Cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura);
                    Cmd.Parameters.AddWithValue("@monto", monto);
                    Cmd.Parameters.AddWithValue("@vendedor", vendedor);
                    Cmd.Parameters.AddWithValue("@adquiriente", adquiriente);
                  

                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }



        public GastosComunes getGastoComunbyId_solandId_gasto(Int32 id_solicitud, Int32 id_tipogasto)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_GastoComunebyid_solandId_tipogasto";
                    cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    GastosComunes mGastosComunes = new GastosComunes();
                    if (reader.Read())
                    {
                        mGastosComunes.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"].ToString());
                        mGastosComunes.Descripcion = reader["descripcion"].ToString();
                        mGastosComunes.Valor = Convert.ToInt32(reader["monto"].ToString());
                        mGastosComunes.Id_familia = Convert.ToInt32(reader["id_familia"].ToString());

                    }
                    return mGastosComunes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cotizacion> getallcotizacion(string cuenta_usuario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_cotizacion2";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cotizacion> lcotizacion = new List<Cotizacion>();
                    while (reader.Read())
                    {

                        lcotizacion.Add(new Cotizacion()
                        {
                            Id_cotizacion = Convert.ToInt32(reader["Id_cotizacion"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Modelo = reader["modelo"].ToString(),
                            Monto = Convert.ToInt32(reader["monto"].ToString()),
                            Fechafac = reader["fechafac"].ToString()
                            
                            
                            


                        });
                    }
                    return lcotizacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public GastosComunes getGastos_Cero(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Gastos_Cero";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    GastosComunes mGastosComunes = new GastosComunes();
                    if (reader.Read())
                    {
                        mGastosComunes.Comprobar = Convert.ToBoolean(reader["comprobante"].ToString());
                    }

                    return mGastosComunes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
	}
}