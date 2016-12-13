using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class TasadorDAC : CACCESO.BaseDAC
    {
        public List<Tasador> getUsuariosTasacion(Int32 id_cliente, string all)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Usuarios_Tasacion";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@all", all); 
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Tasador> ltasador = new List<Tasador>();
                    while (reader.Read())
                    {
                        Tasador mtasador = new Tasador();
                        mtasador.Usu_tasador =new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                        mtasador.Id_cliente =Convert.ToInt32(reader["id_cliente"].ToString());
                        mtasador.Check = Convert.ToBoolean(reader["check"]);
                        ltasador.Add(mtasador);

                        mtasador = null;
                    }
                    return ltasador;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_tasador(string cuenta_usuario, Int32 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_tasador", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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


        public string del_tasador(string cuenta_usuario, Int32 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_tasador", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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


        public Tasador gettasador(string cuenta_usuario,Int32 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_tasadorbycuenta";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Tasador mtasador = new Tasador();
                    while (reader.Read())
                    {
                        mtasador.Id_cliente = Convert.ToInt32(reader["id_cliente"].ToString());
                        mtasador.Usu_tasador = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                       
                    }
                    return mtasador;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
