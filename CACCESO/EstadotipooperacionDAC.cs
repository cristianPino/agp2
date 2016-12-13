using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class EstadotipooperacionDAC : CACCESO.BaseDAC
	{

		public string add_Estadotipooperacion( Int32 codigo_estado,Int16 id_familia,string descripcion, string correo_cliente, string correo_empresa, Int32 orden, string cliente_estado, string llamada, string envia_adquiriente, int dias_primer_a, int dias_ultimo_a, 
                int caducidad_estado, int contador_estado,int id_documento,string lista_correo,Int32 id_grupo, bool estado_manual)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_Estadotipooperacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    oParam = Cmd.Parameters.AddWithValue("@id_familia", id_familia);
					oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
					oParam = Cmd.Parameters.AddWithValue("@correo_cliente", correo_cliente);
					oParam = Cmd.Parameters.AddWithValue("@correo_empresa", correo_empresa);
					oParam = Cmd.Parameters.AddWithValue("@orden", orden);
					oParam = Cmd.Parameters.AddWithValue("@cliente_estado", cliente_estado);
					oParam = Cmd.Parameters.AddWithValue("@llamada", llamada);
					oParam = Cmd.Parameters.AddWithValue("@envia_adquiriente", envia_adquiriente);
					oParam = Cmd.Parameters.AddWithValue("@lista_correo", lista_correo);
					oParam = Cmd.Parameters.AddWithValue("@dias_primer_a",dias_primer_a);
					oParam = Cmd.Parameters.AddWithValue("@dias_ultimo_a",dias_ultimo_a);
					oParam = Cmd.Parameters.AddWithValue("@caducidad_estado", caducidad_estado);
					oParam = Cmd.Parameters.AddWithValue("@contador_estado",contador_estado);
					oParam = Cmd.Parameters.AddWithValue("@id_documento" , id_documento);
                    oParam = Cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                    oParam = Cmd.Parameters.AddWithValue("@estado_manual", estado_manual);
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

		public List<EstadoTipoOperacion> getEstadoByFamilia(int id_familia)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_EstadoByFamilia";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<EstadoTipoOperacion> lEstadotipooperacion = new List<EstadoTipoOperacion>();
					while (reader.Read())
					{
						EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();
						
						mEstadotipooperacion.Codigo_estado = Convert.ToInt16(reader["codigo_estado"]);
						mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
						mEstadotipooperacion.Correo_cliente = reader["correo_cliente"].ToString();
						mEstadotipooperacion.Correo_empresa = reader["correo_empresa"].ToString();
						mEstadotipooperacion.Orden = Convert.ToInt16(reader["orden"]);
						mEstadotipooperacion.Cliente_estado = reader["cliente_estado"].ToString();
						mEstadotipooperacion.Llamada = reader["llamada"].ToString();
						mEstadotipooperacion.Envia_adquirientes = reader["envia_adquiriente"].ToString();
						mEstadotipooperacion.Dias_primer_a = Convert.ToInt32(reader["dias_primer_a"]);
						mEstadotipooperacion.Dias_ultimo_a = Convert.ToInt32(reader["dias_ultimo_a"]);
						mEstadotipooperacion.Caducidad_estado = Convert.ToInt32(reader["caducidad_estado"]);
						mEstadotipooperacion.Contado_estado = Convert.ToInt32(reader["contador_estado"]);
						mEstadotipooperacion.Lista_correo = reader["lista_correo"].ToString();
                        mEstadotipooperacion.Id_grupo = Convert.ToInt32(reader["id_grupo"]);
						mEstadotipooperacion.Id_documento = reader["id_documento"].ToString();
					    mEstadotipooperacion.Estado_manual = Convert.ToBoolean(reader["estado_manual"]);

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

        public List<EstadoTipoOperacion> getEstadoByFamiliaByGrupo(int id_familia, int id_grupo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_EstadoByFamiliaByGrupo";
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<EstadoTipoOperacion> lEstadotipooperacion = new List<EstadoTipoOperacion>();
                    while (reader.Read())
                    {
                        EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();

                        mEstadotipooperacion.Codigo_estado = Convert.ToInt16(reader["codigo_estado"]);
                        mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
                        mEstadotipooperacion.Correo_cliente = reader["correo_cliente"].ToString();
                        mEstadotipooperacion.Correo_empresa = reader["correo_empresa"].ToString();
                        mEstadotipooperacion.Orden = Convert.ToInt16(reader["orden"]);
                        mEstadotipooperacion.Cliente_estado = reader["cliente_estado"].ToString();
                        mEstadotipooperacion.Llamada = reader["llamada"].ToString();
                        mEstadotipooperacion.Envia_adquirientes = reader["envia_adquiriente"].ToString();
                        mEstadotipooperacion.Dias_primer_a = Convert.ToInt32(reader["dias_primer_a"]);
                        mEstadotipooperacion.Dias_ultimo_a = Convert.ToInt32(reader["dias_ultimo_a"]);
                        mEstadotipooperacion.Caducidad_estado = Convert.ToInt32(reader["caducidad_estado"]);
                        mEstadotipooperacion.Contado_estado = Convert.ToInt32(reader["contador_estado"]);
                        mEstadotipooperacion.Lista_correo = reader["lista_correo"].ToString();
                        mEstadotipooperacion.Id_grupo = Convert.ToInt32(reader["id_grupo"]);
                        mEstadotipooperacion.Id_documento = reader["id_documento"].ToString();
                        mEstadotipooperacion.Estado_manual = Convert.ToBoolean(reader["estado_manual"]);

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



		public List<EstadoTipoOperacion> getEstadoByTipooperacion(string codigo)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_EstadoByTipooperacion";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					List<EstadoTipoOperacion> lEstadotipooperacion = new List<EstadoTipoOperacion>();
					while (reader.Read())
					{
						EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();
						mEstadotipooperacion.Codigo_estado = Convert.ToInt16(reader["codigo_estado"]);
						mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
						mEstadotipooperacion.Correo_cliente = reader["correo_cliente"].ToString();
						mEstadotipooperacion.Correo_empresa = reader["correo_empresa"].ToString();
						mEstadotipooperacion.Orden = Convert.ToInt16(reader["orden"]);
						mEstadotipooperacion.Cliente_estado = reader["cliente_estado"].ToString();
						mEstadotipooperacion.Llamada = reader["llamada"].ToString();
                        //mEstadotipooperacion.Id_grupo = Convert.ToInt32(reader["id_grupo"]);
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

		public EstadoTipoOperacion getEstadoBycodigo(Int32 codigo_estado)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_EstadoByCodigo";
					cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
					SqlDataReader reader = cmd.ExecuteReader();
					EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();
					if (reader.Read())
					{
						mEstadotipooperacion.Codigo_estado = Convert.ToInt16(reader["codigo_estado"]);
						mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
						mEstadotipooperacion.Correo_cliente = reader["correo_cliente"].ToString();
						mEstadotipooperacion.Correo_empresa = reader["correo_empresa"].ToString();
						mEstadotipooperacion.Orden = Convert.ToInt16(reader["orden"]);
						mEstadotipooperacion.Cliente_estado = reader["cliente_estado"].ToString();
						mEstadotipooperacion.Llamada = reader["llamada"].ToString();
                        mEstadotipooperacion.Id_grupo = Convert.ToInt32(reader["id_grupo"]);
					}
					return mEstadotipooperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public EstadoTipoOperacion GETULTIMOESTADO(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_ultimo_estado";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					EstadoTipoOperacion mestado = new EstadoTipoOperacion();
					while (reader.Read())
					{
						mestado.Orden = Convert.ToInt16(reader["orden"].ToString());
						mestado.Codigo_estado = Convert.ToInt32(reader["codigo_estado"].ToString());
						mestado.Descripcion = reader["descripcion"].ToString();
					}
					return mestado;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public List<EstadoTipoOperacion> getEstadoByTipooperacionCliente(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_EstadoByTipooperacioncliente";
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<EstadoTipoOperacion> lEstadotipooperacion = new List<EstadoTipoOperacion>();
                    while (reader.Read())
                    {
                        EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();
                        mEstadotipooperacion.Codigo_estado = Convert.ToInt16(reader["codigo_estado"]);
                        mEstadotipooperacion.Descripcion = reader["descripcion"].ToString();
                        mEstadotipooperacion.Correo_cliente = reader["correo_cliente"].ToString();
                        mEstadotipooperacion.Correo_empresa = reader["correo_empresa"].ToString();
                        mEstadotipooperacion.Orden = Convert.ToInt16(reader["orden"]);
                        mEstadotipooperacion.Cliente_estado = reader["cliente_estado"].ToString();
                        mEstadotipooperacion.Llamada = reader["llamada"].ToString();
                        mEstadotipooperacion.Id_grupo = Convert.ToInt32(reader["id_grupo"]);
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


      

	}
}