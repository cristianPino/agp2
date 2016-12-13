using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class PerfilDAC : BaseDAC
    {


        public List<Perfil> GetPerfiles()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_perfiles";

                    

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Perfil> lperfil = new List<Perfil>();

                    

                    while (reader.Read())
                    {
                        Perfil mPerfil = new Perfil();

                        mPerfil.Codigoperfil = reader["codigoperfil"].ToString();
                        mPerfil.Descripcion = reader["descripcion"].ToString();
                        mPerfil.Url_inicio = reader["url_index"].ToString();

                        lperfil.Add(mPerfil);

                    }
                    return lperfil;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Perfil GetPerfil(string codigoperfil)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_perfil";

                    cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Perfil mPerfil = new Perfil();

                    if (reader.Read())
                    {

                        mPerfil.Codigoperfil = reader["codigoperfil"].ToString();
                        mPerfil.Descripcion = reader["descripcion"].ToString();
                        mPerfil.Url_inicio = reader["url_index"].ToString();

                    }
                    return mPerfil;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Perfil GetPerfilByUsrName(string  usrName)
      {         
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_perfilbyusrname";

                    cmd.Parameters.AddWithValue("@cuenta_usuario", usrName);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    Perfil mPerfil = new Perfil();

                    if (reader.Read())
                    {

                        mPerfil.Codigoperfil = reader["codigoperfil"].ToString();
                        mPerfil.Descripcion = reader["descripcion"].ToString();
                        mPerfil.Url_inicio  = reader["url_index"].ToString();

                    }
                    return mPerfil;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string add_Perfil(string codigoperfil, string nombre)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Perfil", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", nombre);

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
        public List<Perfil> getPerfil()
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_perfiles";


                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Perfil> lPerfil = new List<Perfil>();

                    List<Perfil> lModulocliente = new List<Perfil>();

                    while (reader.Read())
                    {

                       Perfil mperfil = new Perfil();
                       
                       mperfil.Descripcion = reader["descripcion"].ToString();
                       mperfil.Codigoperfil = reader["codigoperfil"].ToString();
                       
                        lPerfil.Add(mperfil);
                        mperfil = null;

                    }
                    return lPerfil;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string add_Perfilopcionmenu(string codigoperfil, string codigoopcionmenu)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Perfilopcionmenu", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);
                    oParam = Cmd.Parameters.AddWithValue("@codigoopcionmenu", codigoopcionmenu);

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

        public string del_Perfilopcionmenu(string codigoperfil, string codigoopcionmenu)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_Perfilopcionmenu", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);
                    oParam = Cmd.Parameters.AddWithValue("@codigoopcionmenu", codigoopcionmenu);

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

