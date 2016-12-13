using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class OpcionmenuDAC : CACCESO.BaseDAC
    {
        public List<OpcionMenu> GetOpcionmenuFavoritoByusuario(string cuentaUsuario)
        {     
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "get_menu_favorito";

                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<OpcionMenu> lOpcionmenu = new List<OpcionMenu>();
                    while (reader.Read())
                    {
                        OpcionMenu mOpcionmenu = new OpcionMenu();

                        mOpcionmenu.Codigoopcionmenu = reader["codigoopcionmenu"].ToString();
                        mOpcionmenu.Descripcion = reader["descripcion"].ToString();
                        mOpcionmenu.Url = reader["url"].ToString();
                        mOpcionmenu.Orden = Convert.ToInt32(reader["orden"]);
                        mOpcionmenu.Estado = reader["estado"].ToString();   
                        lOpcionmenu.Add(mOpcionmenu);   
                    }
                    sqlConn.Close();
                    return lOpcionmenu;
                }    
        }


        public OpcionMenu GetOpcionmenuBycodigo(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_opcionmenubyCodigo";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    OpcionMenu mOpcionmenu = new OpcionMenu();

                    if (reader.Read())
                    {


                        mOpcionmenu.Codigoopcionmenu = reader["codigoopcionmenu"].ToString();
                        mOpcionmenu.Descripcion = reader["descripcion"].ToString();
                        mOpcionmenu.Url = reader["url"].ToString();
                        mOpcionmenu.Orden = Convert.ToInt32(reader["orden"]);
                        mOpcionmenu.Estado = reader["estado"].ToString();
                        mOpcionmenu.UrlManual = reader["url_manual"].ToString();

                    }
                    sqlConn.Close();
                    return mOpcionmenu;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<OpcionMenu> GetOpcionmenuByPerfil(string strPerfil)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_opcionmenubyperfil";

                    cmd.Parameters.AddWithValue("@CodigoPerfil", strPerfil);

                    SqlDataReader reader = cmd.ExecuteReader();

                    


                    List<OpcionMenu> lOpcionmenu = new List<OpcionMenu >();


                    while (reader.Read())
                    {
                        OpcionMenu mOpcionmenu = new OpcionMenu();

                        mOpcionmenu.Codigoopcionmenu  = reader["codigoopcionmenu"].ToString();
                        mOpcionmenu.Descripcion  = reader["descripcion"].ToString();
                        mOpcionmenu.Url   = reader["url"].ToString();
                        mOpcionmenu.Orden =   Convert.ToInt32(reader["orden"]); 
                        mOpcionmenu.Estado = reader["estado"].ToString();

                        lOpcionmenu.Add(mOpcionmenu);

                        mOpcionmenu = null;
                    }
                    sqlConn.Close();
                    return lOpcionmenu ;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpcionMenu> GetOpcionmenuByusuario(string cuenta_usuario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_opcionmenubyusuario";

                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

                    SqlDataReader reader = cmd.ExecuteReader();




                    List<OpcionMenu> lOpcionmenu = new List<OpcionMenu>();


                    while (reader.Read())
                    {
                        OpcionMenu mOpcionmenu = new OpcionMenu();

                        mOpcionmenu.Codigoopcionmenu = reader["codigoopcionmenu"].ToString();
                        mOpcionmenu.Descripcion = reader["descripcion"].ToString();
                        mOpcionmenu.Url = reader["url"].ToString();
                        mOpcionmenu.Orden = Convert.ToInt32(reader["orden"]);
                        mOpcionmenu.Estado = reader["estado"].ToString();

                        lOpcionmenu.Add(mOpcionmenu);

                        mOpcionmenu = null;
                    }
                    sqlConn.Close();
                    return lOpcionmenu;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpcionMenu> GetPerfilopcionmenu(string strPerfil)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Perfilopcionmenu";

                    cmd.Parameters.AddWithValue("@CodigoPerfil", strPerfil);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<OpcionMenu> lOpcionmenu = new List<OpcionMenu >();


                    while (reader.Read())
                    {
                        OpcionMenu mOpcionmenu = new OpcionMenu();

                        mOpcionmenu.Codigoopcionmenu  = reader["codigoopcionmenu"].ToString();
                        mOpcionmenu.Descripcion  = reader["descripcion"].ToString();
                        mOpcionmenu.Url   = reader["url"].ToString();
                        mOpcionmenu.Orden =   Convert.ToInt32(reader["orden"]); 
                        mOpcionmenu.Estado = reader["estado"].ToString();
                        mOpcionmenu.Check = Convert.ToBoolean(reader["check"].ToString());

                        lOpcionmenu.Add(mOpcionmenu);

                        mOpcionmenu = null;
                    }
                    sqlConn.Close();
                    return lOpcionmenu ;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OpcionMenu> GetUsuarioopcionmenu(string strUsuario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Usuarioopcionmenu";

                    cmd.Parameters.AddWithValue("@cuenta_usuario", strUsuario);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<OpcionMenu> lOpcionmenu = new List<OpcionMenu>();


                    while (reader.Read())
                    {
                        OpcionMenu mOpcionmenu = new OpcionMenu();

                        mOpcionmenu.Codigoopcionmenu = reader["codigoopcionmenu"].ToString();
                        mOpcionmenu.Descripcion = reader["descripcion"].ToString();
                        mOpcionmenu.Url = reader["url"].ToString();
                        mOpcionmenu.Orden = Convert.ToInt32(reader["orden"]);
                        mOpcionmenu.Estado = reader["estado"].ToString();
                        mOpcionmenu.Check = Convert.ToBoolean(reader["check"].ToString());

                        lOpcionmenu.Add(mOpcionmenu);

                        mOpcionmenu = null;
                    }
                    sqlConn.Close();
                    return lOpcionmenu;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

