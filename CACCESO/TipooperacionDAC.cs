using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class TipooperacionDAC : CACCESO.BaseDAC
    {

        public TipoOperacion getTipooperacion(string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Tipooperacion";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    TipoOperacion mTipooperacion = new TipoOperacion();

                    if (reader.Read())
                    {

                        mTipooperacion.Codigo = reader["codigo"].ToString();
                        mTipooperacion.Operacion = reader["operacion"].ToString();
                        mTipooperacion.Id_familia =Convert.ToInt32(reader["id_familia"].ToString());
                        mTipooperacion.Imagen = reader["imagen"].ToString();
                        mTipooperacion.Url_operacion = reader["url_operacion"].ToString();

						mTipooperacion.Tamano = reader["tamano"].ToString();
                        mTipooperacion.Codigo_nav = reader["codigo_nav"].ToString();
                    }
                    return mTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<TipoOperacion> getallTipooperacion()
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Tipooperaciones";

                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TipoOperacion> lTipooperacion = new List<TipoOperacion>();

                    while (reader.Read())
                    {
                        TipoOperacion mTipooperacion = new TipoOperacion();


                        mTipooperacion.Codigo = reader["codigo"].ToString();
                        mTipooperacion.Operacion = reader["operacion"].ToString();
                        mTipooperacion.Tamano = reader["tamano"].ToString();
                    

                        lTipooperacion.Add(mTipooperacion);

                        mTipooperacion = null;
                    }
                    return lTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string add_Tipooperacion(string codigo,string operacion, string imagen, string url_operacion,string tamano)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Tipooperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@operacion", operacion);
                    oParam = Cmd.Parameters.AddWithValue("@imagen", imagen);
                    oParam = Cmd.Parameters.AddWithValue("@url_operacion", url_operacion);
                    oParam = Cmd.Parameters.AddWithValue("@tamano", tamano);

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
        public string act_Tipooperacion(string codigo, string tamano , string operacion)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_act_Tipooperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@tamano", tamano);
					oParam = Cmd.Parameters.AddWithValue("@operacion", operacion);
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


        public string add_tipo_operacion_cliente(string codigo, Int16 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_tipo_operacion_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    
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

        public string add_usuario_tipo_operacion(string cuenta_usuario,string codigo,Int16 id_cliente, string check_ingresa)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_usuario_tipo_operacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario",cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente",id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@check_ingresa", check_ingresa);
                    

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

        public List<TipoOperacion> getTipo_OperacionByCliente(Int16 id_cliente, string all)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Tipo_OperacionByCliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@all", all);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TipoOperacion> lTipooperacion = new List<TipoOperacion>();

                    while (reader.Read())
                    {
                        TipoOperacion mTipooperacion = new TipoOperacion();


                        mTipooperacion.Codigo = reader["codigo"].ToString();
                        mTipooperacion.Operacion = reader["operacion"].ToString();
                        mTipooperacion.Imagen = reader["imagen"].ToString();
                        mTipooperacion.Url_operacion = reader["url_operacion"].ToString();
                        mTipooperacion.Check = Convert.ToBoolean(reader["check"]);



                        lTipooperacion.Add(mTipooperacion);

                        mTipooperacion = null;
                    }
                    return lTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<TipoOperacion> getTipo_OperacionByClienteandfamilia(Int16 id_cliente, string all,Int16 id_familia)
		{

			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_Tipo_OperacionByClienteandfamilia";

					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@all", all);
					cmd.Parameters.AddWithValue("@id_familia", id_familia);

					SqlDataReader reader = cmd.ExecuteReader();

					List<TipoOperacion> lTipooperacion = new List<TipoOperacion>();

					while (reader.Read())
					{
						TipoOperacion mTipooperacion = new TipoOperacion();


						mTipooperacion.Codigo = reader["codigo"].ToString();
						mTipooperacion.Operacion = reader["operacion"].ToString();
						mTipooperacion.Imagen = reader["imagen"].ToString();
						mTipooperacion.Url_operacion = reader["url_operacion"].ToString();
						mTipooperacion.Check = Convert.ToBoolean(reader["check"]);



						lTipooperacion.Add(mTipooperacion);

						mTipooperacion = null;
					}
					return lTipooperacion;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



        public List<TipoOperacion> getTipo_OperacionByUsuario(Int16 id_cliente,string cuenta_usuario, string all)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Tipo_OperacionByUsuario";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@all", all);
                    


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TipoOperacion> lTipooperacion = new List<TipoOperacion>();

                    while (reader.Read())
                    {
                        TipoOperacion mTipooperacion = new TipoOperacion();


                        mTipooperacion.Codigo = reader["codigo"].ToString();
                        mTipooperacion.Operacion = reader["operacion"].ToString();
                        mTipooperacion.Imagen = reader["imagen"].ToString();
                        mTipooperacion.Url_operacion = reader["url_operacion"].ToString();
                        mTipooperacion.Check = Convert.ToBoolean(reader["check"]);
                        mTipooperacion.Tamano = reader["tamano"].ToString();
                        mTipooperacion.Check_ingresa = reader["check_ingresa"].ToString();


                        lTipooperacion.Add(mTipooperacion);

                        mTipooperacion = null;
                    }
                    return lTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoOperacion> getTipo_OperacionByUsuarioandfamilia(Int16 id_cliente, string cuenta_usuario, string all,Int32 id_familia, string ingresa)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Tipo_OperacionByUsuarioandfamilia";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@all", all);
                    cmd.Parameters.AddWithValue("@check_ingresa", ingresa);



                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TipoOperacion> lTipooperacion = new List<TipoOperacion>();

                    while (reader.Read())
                    {
                        TipoOperacion mTipooperacion = new TipoOperacion();


                        mTipooperacion.Codigo = reader["codigo"].ToString();
                        mTipooperacion.Operacion = reader["operacion"].ToString();
                        mTipooperacion.Imagen = reader["imagen"].ToString();
                        mTipooperacion.Url_operacion = reader["url_operacion"].ToString();
                        mTipooperacion.Check = Convert.ToBoolean(reader["check"]);
                        mTipooperacion.Tamano = reader["tamano"].ToString();
                        mTipooperacion.Check_ingresa = reader["check_ingresa"].ToString();



                        lTipooperacion.Add(mTipooperacion);

                        mTipooperacion = null;
                    }
                    return lTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string del_tipo_operacion_cliente(string codigo, Int16 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_tipo_operacion_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

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


        public string del_tipo_operacion_usuario(string cuenta_usuario, string codigo, Int16 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_tipo_operacion_usuario", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

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



        public TipoOperacion getcomprobantebyoperacion(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_view_comprobante";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    SqlDataReader reader = cmd.ExecuteReader();

                    TipoOperacion mTipooperacion = new TipoOperacion();

                    if (reader.Read())
                    {

                        mTipooperacion.Codigo = reader["codigo"].ToString();
                        mTipooperacion.Comprobante = reader["comprobante"].ToString();
                        mTipooperacion.Comprobante_rpt = reader["comprobante_rpt"].ToString();
                    }
                    return mTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TipoOperacion getcomprobantegastos(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sigastoencero";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    TipoOperacion mTipooperacion = new TipoOperacion();
                    if (reader.Read())
                    {
                        mTipooperacion.Check = Convert.ToBoolean(reader["check"].ToString());
                    }
                    return mTipooperacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<TipoOperacion> GetProductosByFamiliaClienteUsuario(Int16 idCliente, string cuentaUsuario, Int32 idFamilia)
        {

            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_get_producto_by_familia_usuario"
                    };

                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                    cmd.Parameters.AddWithValue("@id_familia", idFamilia);

                    var reader = cmd.ExecuteReader();

                    var lTipooperacion = new List<TipoOperacion>();

                    while (reader.Read())
                    {
                        var mTipooperacion = new TipoOperacion { Codigo = reader["codigo"].ToString(), Operacion = reader["operacion"].ToString() };
                        lTipooperacion.Add(mTipooperacion);
                    }
                    return lTipooperacion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
