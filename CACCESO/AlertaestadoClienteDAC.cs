using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class AlertaestadoClienteDAC : CACCESO.BaseDAC
	{

		public string add_Alerta_estado_cliente(int id_alerta, int codigo_estado, int id_cliente, string listacorreo, string envia_adquiriente, int dias_primer_a, int dias_ultimo_a, int caducidad_estado, int contador_estado, int id_documento, string habilitado)
		{
			

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					
					SqlCommand Cmd = new SqlCommand("sp_add_Estadoalertacliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_alerta", id_alerta);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
					oParam = Cmd.Parameters.AddWithValue("@listacorreo", listacorreo);
					oParam = Cmd.Parameters.AddWithValue("@envia_adquiriente", envia_adquiriente);
					oParam = Cmd.Parameters.AddWithValue("@dias_primer_a", dias_primer_a);
					oParam = Cmd.Parameters.AddWithValue("@dias_ultimo_a", dias_ultimo_a);
					oParam = Cmd.Parameters.AddWithValue("@caducidad_estado", caducidad_estado);
					oParam = Cmd.Parameters.AddWithValue("@contador_estado", contador_estado);
					oParam = Cmd.Parameters.AddWithValue("@id_documento", id_documento);
                    oParam = Cmd.Parameters.AddWithValue("@habilitado", id_documento);
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

		public List<AlertaestadoCliente> getEstadoAlertaFamiliaCliente(int id_familia, Int16 id_cliente)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_AlertaEstadoCliente";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					SqlDataReader reader = cmd.ExecuteReader();
					List<AlertaestadoCliente> lEstadotipooperacion = new List<AlertaestadoCliente>();
					while (reader.Read())
					{
						AlertaestadoCliente mEstadotipooperacion = new AlertaestadoCliente();

						mEstadotipooperacion.Estado_alerta = new EstadotipooperacionDAC().getEstadoBycodigo(Convert.ToInt16(reader["codigo_estado"]));
						mEstadotipooperacion.Dias_primer_a = Convert.ToInt16(reader["dias_primer_aviso"]);
						mEstadotipooperacion.Dias_ultimo_a = Convert.ToInt16(reader["dias_ultimo_aviso"]);
						mEstadotipooperacion.Contador_estado = Convert.ToInt16(reader["contador_estado"]);
						mEstadotipooperacion.Caducidad_estado = Convert.ToInt16(reader["caducidad_estado"]);
						mEstadotipooperacion.Envia_adquiriente = reader["envia_adquiriente"].ToString();
						mEstadotipooperacion.Lista_correo = reader["lista_correo"].ToString();
						mEstadotipooperacion.Id_documento = Convert.ToInt16(reader["id_documento"]);
						mEstadotipooperacion.Id_alerta = Convert.ToInt16(reader["id_alerta"]);
						mEstadotipooperacion.Id_cliente=Convert.ToInt16(reader["id_cliente"]);
						mEstadotipooperacion.Id_familia = Convert.ToInt16(reader["id_familia"]);
                        mEstadotipooperacion.Habilitado = (reader["habilitado"].ToString());

						lEstadotipooperacion.Add(mEstadotipooperacion);
						mEstadotipooperacion = null;
					}
					return lEstadotipooperacion;
				}


			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<AlertaestadoCliente> getReglaFamiliaCliente(int id_familia, Int16 id_alerta, int codigo_estado )
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_get_regla_estado_alerta_familia";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					cmd.Parameters.AddWithValue("@id_alerta", id_alerta);
					cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
					SqlDataReader reader = cmd.ExecuteReader();
					List<AlertaestadoCliente> lEstadotipooperacion = new List<AlertaestadoCliente>();
					while (reader.Read())
					{
						AlertaestadoCliente mEstadotipooperacion = new AlertaestadoCliente();


						mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
						
							mEstadotipooperacion.Estado_alerta = new EstadotipooperacionDAC().getEstadoBycodigo(Convert.ToInt16(reader["codigo_estado"]));
					//	mEstadotipooperacion.Id_alerta = Convert.ToInt16(reader["id_alerta"]);
					//	mEstadotipooperacion.Id_cliente = Convert.ToInt16(reader["id_cliente"]);
						mEstadotipooperacion.Id_familia = Convert.ToInt16(reader["id_familia"]);
						mEstadotipooperacion.Cheked = reader["check_regla"].ToString(); 

						lEstadotipooperacion.Add(mEstadotipooperacion);
						mEstadotipooperacion = null;
					}
					return lEstadotipooperacion;
				}





			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public string add_regla_estado_cliente(Int16 id_alerta, Int16 codigo_estado)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_add_regla_estado_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_alerta", id_alerta);
					oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);


					Cmd.ExecuteNonQuery();

					sqlConn.Close();

				}
				catch (Exception ex)
				{
					throw ex;
				}

				return "";

			}
		}

		




		public string del_regla_estado_cliente(Int16 id_alerta, Int16 id_estado)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_del_regla_estado_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_alerta", id_alerta);
					oParam = Cmd.Parameters.AddWithValue("@codigo_estado", id_estado);


					Cmd.ExecuteNonQuery();

					sqlConn.Close();

				}
				catch (Exception ex)
				{
					throw ex;
				}

				return "";

			}
		}


		

		
	}
}