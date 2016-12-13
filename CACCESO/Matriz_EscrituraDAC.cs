using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class Matriz_EscrituraDAC : CACCESO.BaseDAC
    {
        public List<Matriz_Escritura> getMatriz(Int32 id_cliente, Int32 cod_notaria, string tipo_documento)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Get_all_Url";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@cod_notaria", cod_notaria);
                    cmd.Parameters.AddWithValue("@tipo_documento", tipo_documento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Matriz_Escritura> lmatriz = new List<Matriz_Escritura>();
                    while (reader.Read())
                    {
                        Matriz_Escritura mmatriz = new Matriz_Escritura();
                        mmatriz.Cod_notaria =Convert.ToInt32(reader["cod_notaria"].ToString());
                        mmatriz.Cod_matriz = Convert.ToInt32(reader["cod_matriz"].ToString());
                        mmatriz.Tipo_documento = reader["tipo_documento"].ToString();
                        mmatriz.Id_cliente =Convert.ToInt32(reader["id_cliente"].ToString());
                        mmatriz.Descripcion = reader["descripcion"].ToString();
                        mmatriz.Url_matriz = reader["url_matriz"].ToString();
                        mmatriz.Url_destino = reader["url_destino"].ToString();
                        


                        lmatriz.Add(mmatriz);
                        mmatriz = null;
                    }
                    return lmatriz;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Matriz_Escritura getMatrizbycodigo(Int32 cod_matriz, Int32 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Get_url";
                    cmd.Parameters.AddWithValue("@cod_matriz", cod_matriz);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Matriz_Escritura mmatriz = new Matriz_Escritura();
                    while (reader.Read())
                    {
                        mmatriz.Cod_matriz = Convert.ToInt32(reader["cod_matriz"].ToString());
                        mmatriz.Cod_notaria = Convert.ToInt32(reader["cod_notaria"].ToString());
                        mmatriz.Descripcion = reader["descripcion"].ToString();
                        mmatriz.Id_cliente =Convert.ToInt32(reader["id_cliente"].ToString());
                        mmatriz.Tipo_documento = reader["tipo_documento"].ToString();
                        mmatriz.Url_destino= reader["url_destino"].ToString();
                        mmatriz.Url_matriz= reader["url_matriz"].ToString();
                    }
                    return mmatriz;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Matriz_Escritura> getMatrizEscrituras(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getMatrizEscrituras";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Matriz_Escritura> lmatriz = new List<Matriz_Escritura>();
                    while (reader.Read())
                    {
                        Matriz_Escritura mmatriz = new Matriz_Escritura();
                        mmatriz.Cod_notaria = Convert.ToInt32(reader["cod_notaria"].ToString());
                        mmatriz.Cod_matriz = Convert.ToInt32(reader["cod_matriz"].ToString());
                        mmatriz.Tipo_documento = reader["tipo_documento"].ToString();
                        mmatriz.Id_cliente = Convert.ToInt32(reader["id_cliente"].ToString());
                        mmatriz.Descripcion = reader["descripcion"].ToString();
                        mmatriz.Url_matriz = reader["url_matriz"].ToString();
                        mmatriz.Url_destino = reader["url_destino"].ToString();



                        lmatriz.Add(mmatriz);
                        mmatriz = null;
                    }
                    return lmatriz;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
