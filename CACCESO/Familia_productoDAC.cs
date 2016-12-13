using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class Familia_productoDAC : CACCESO.BaseDAC
	{
		public List<Familia_Producto> getallfamilia_producto()
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_familia_productos";
					SqlDataReader reader = cmd.ExecuteReader();
					List<Familia_Producto> lFamiliaProducto = new List<Familia_Producto>();
					while (reader.Read())
					{
						Familia_Producto mFamiliaProducto = new Familia_Producto();
						mFamiliaProducto.Id_familia = Convert.ToInt32(reader["id_familia"].ToString());
						mFamiliaProducto.Descripcion = reader["descripcion"].ToString();
						lFamiliaProducto.Add(mFamiliaProducto);
						mFamiliaProducto = null;
					}
					return lFamiliaProducto;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<Familia_Producto> getallfamilia_cliente(Int16 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_familia_byCliente";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Familia_Producto> lFamiliaProducto = new List<Familia_Producto>();
                    while (reader.Read())
                    {
                        Familia_Producto mFamiliaProducto = new Familia_Producto();
                        mFamiliaProducto.Id_familia = Convert.ToInt32(reader["id_familia"].ToString());
                        mFamiliaProducto.Descripcion = reader["descripcion"].ToString();
                        lFamiliaProducto.Add(mFamiliaProducto);
                        mFamiliaProducto = null;
                    }
                    return lFamiliaProducto;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Familia_Producto getFamiliabyidFamilia(Int32 id_familia )
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_familiabyidFamilia";
                    cmd.Parameters.AddWithValue("@id_familia", id_familia );
                    SqlDataReader reader = cmd.ExecuteReader();
                    Familia_Producto mfamilia = new Familia_Producto();
                    if (reader.Read())
                    {
                        mfamilia.Id_familia = Convert.ToInt16(reader["id_familia"]);
                        mfamilia.Descripcion = reader["descripcion"].ToString();
                        mfamilia.Codigo_nav = reader["codigo_nav"].ToString();
                    }
                    return mfamilia;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public Familia_Producto getFamilia(string codigo)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_familiabyproducto";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					Familia_Producto mfamilia = new Familia_Producto();
					if (reader.Read())
					{
						mfamilia.Id_familia = Convert.ToInt16(reader["id_familia"]);
						mfamilia.Descripcion = reader["descripcion"].ToString();
					}
					return mfamilia;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Familia_Producto> getFamiliaProductoByUsuario(string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_productobyusuario";
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Familia_Producto> lFamiliaProducto = new List<Familia_Producto>();
					while (reader.Read())
					{
						Familia_Producto mFamiliaProducto = new Familia_Producto();
						mFamiliaProducto.Id_familia = Convert.ToInt32(reader["id_familia"].ToString());
						mFamiliaProducto.Descripcion = reader["descripcion"].ToString();
						lFamiliaProducto.Add(mFamiliaProducto);
						mFamiliaProducto = null;
					}
					return lFamiliaProducto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Familia_Producto> getProductoByfamilia(Int16 id_familia)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_get_productobyfamilia";
					cmd.Parameters.AddWithValue("@id_familia", id_familia);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Familia_Producto> lProductofamilia = new List<Familia_Producto>();
					while (reader.Read())
					{
						Familia_Producto mFamiliaProducto = new Familia_Producto();
						mFamiliaProducto.Codigo = reader["codigo"].ToString();
						mFamiliaProducto.Operacion = reader["operacion"].ToString();
						lProductofamilia.Add(mFamiliaProducto);
						mFamiliaProducto = null;
					}
					return lProductofamilia;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public List<Familia_Producto> getFamilia_by_cliente_usuario(Int16 id_cliente, string cuenta_usuario)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_getFamilia_Cliente_Usuario";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Familia_Producto> lProductofamilia = new List<Familia_Producto>();
					while (reader.Read())
					{
						Familia_Producto mFamiliaProducto = new Familia_Producto();
						mFamiliaProducto.Id_familia = Convert.ToInt32(reader["id_familia"]);
						mFamiliaProducto.Descripcion = reader["descripcion"].ToString();
						lProductofamilia.Add(mFamiliaProducto);
						mFamiliaProducto = null;
					}
					return lProductofamilia;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}