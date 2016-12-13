using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class EjecutivosucursalDAC : CACCESO.BaseDAC
    {

       

        public List<Ejecutivosucursal> getEjecutivoclientebycliente(int id_cliente, int id_sucursal)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_Ejecutivoclientebycliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@sucursal", id_sucursal);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Ejecutivosucursal> lModulocliente = new List<Ejecutivosucursal>();

                    while (reader.Read())
                    {

                        Ejecutivosucursal mModulocliente = new Ejecutivosucursal();

                        mModulocliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
						mModulocliente.Id_sucursal_cliente = reader["id_sucursal_ejecutivo"].ToString();
						mModulocliente.Nombre = reader["nombre"].ToString();
					//	mModulocliente.Descripcion = reader["descripcion"].ToString();
						mModulocliente.Correo = reader["correo"].ToString();
                        mModulocliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));

                        lModulocliente.Add(mModulocliente);
                        mModulocliente = null;

                    }
					return lModulocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public string add_Ejecutivocliente(Int16 id_cliente, Int16 id_sucursal, string nombre, string correo,
            Int16 id_cliente_financiera)
    {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_ejecutivo_sucursal_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					
					oParam = Cmd.Parameters.AddWithValue("@nombre", nombre);
					oParam = Cmd.Parameters.AddWithValue("@correo", correo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente_financiera", id_cliente_financiera);
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

	
		public string del_Ejecutivocliente(Int16 id_cliente_sucursal)
    {
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_del_ejecutivo_sucursal_cliente", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_sucursal_cliente", id_cliente_sucursal);
					
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




