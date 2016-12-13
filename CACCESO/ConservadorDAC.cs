using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class ConservadorDAC : CACCESO.BaseDAC
    {


        public Conservador getconservador(Int32 id_comuna)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_ConservadorbyComuna";
                    cmd.Parameters.AddWithValue("@id_comuna", id_comuna);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Conservador mconservador = new Conservador();
                    if (reader.Read())
                    {
                        mconservador.Id_conservador = Convert.ToInt32(reader["id_conservador"].ToString());
                        mconservador.Nombre = reader["nombre"].ToString();

                    }
                    else
                    { mconservador = null; }


                    return mconservador;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Conservador> GetAllconservador()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_getAllConservador"; 
                    SqlDataReader reader = cmd.ExecuteReader();

                    var lista = new List<Conservador>();
                    while(reader.Read())
                    {
                        var mconservador = new Conservador();
                        mconservador.Id_conservador = Convert.ToInt32(reader["id_conservador"].ToString());
                        mconservador.Nombre = reader["nombre"].ToString();
                        lista.Add(mconservador);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddConservador(int idConservador, string nombre)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_addConservador";
                    cmd.Parameters.AddWithValue("@idConservador", idConservador);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    SqlDataReader reader = cmd.ExecuteReader();

                    var respuesta = "";
                    if (reader.Read())
                    { 
                        respuesta = reader["resultado"].ToString();
                        
                    }
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ConservadorComuna> GetConservadorComunas(int idConservador)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_getConservadorComunas";
                    cmd.Parameters.AddWithValue("@idConservador", idConservador);
                    var reader = cmd.ExecuteReader();

                    var lista = new List<ConservadorComuna>();
                    while (reader.Read())
                    {
                        var c = new ConservadorComuna(); 
                        c.Existe = Convert.ToBoolean(reader["check"]);
                        c.Id_Comuna = Convert.ToInt32(reader["id_comuna"]);
                        c.Nombre = reader["nombre"].ToString();
                        c.Ciudad = new CiudadDAC().getciudad(Convert.ToInt16(reader["id_ciudad"]));
                        lista.Add(c);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit_JuridiccionConservador(int idConservador, int idComuna, int tipo)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_edit_JuridiccionConservador";
                    cmd.Parameters.AddWithValue("@idConservador", idConservador);
                    cmd.Parameters.AddWithValue("@idComuna", idComuna);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
