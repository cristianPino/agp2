using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class UsuarioDAC : BaseDAC
    {

        public void ReestablecerContrasenia(string userName, string clave)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "reestablecer_contrasenia"
                    };
                cmd.Parameters.AddWithValue("@usuario", userName);
                cmd.Parameters.AddWithValue("@clave", clave);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }


        public Usuario GetusuariobyUsername(string userName)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_usuariobyusername";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", userName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Usuario unUsuario = new Usuario();
                    if (reader.Read())
                    {
                        unUsuario.Nombre = reader["Nombre"].ToString();
                        unUsuario.UserName = reader["cuenta_usuario"].ToString();
                        unUsuario.Contraseña = reader["clave"].ToString();
                        unUsuario.Codigoperfil = reader["codigoperfil"].ToString();
                        unUsuario.Telefono = reader["telefono"].ToString();
                        unUsuario.Correo = reader["correo"].ToString();
                        unUsuario.Usuanav = reader["usuanav"].ToString();
                        unUsuario.Anexo = Convert.ToInt16(reader["anexo"]);
                        unUsuario.Itentos = Convert.ToInt16(reader["intentos"]);
                        unUsuario.Nivel = reader["nivel"].ToString().Trim();
                        unUsuario.Perfil = new PerfilDAC().GetPerfilByUsrName(reader["cuenta_usuario"].ToString());
                        unUsuario.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        unUsuario.Permite_eliminar = Convert.ToBoolean(reader["permite_eliminar"]);
                        unUsuario.Permite_pagar = Convert.ToBoolean(reader["permite_pagar"]);
                        unUsuario.Fechacaducacion = Convert.ToDateTime(reader["fechacaducacion"]);
                    }
                    sqlConn.Close();
                    return unUsuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUsuarioBySesion(string userName, string clave)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 50000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_usuariobysesion";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", userName);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Usuario unUsuario = new Usuario();
                    if (reader.Read())
                    {
                        unUsuario.Nombre = reader["Nombre"].ToString();
                        unUsuario.UserName = reader["cuenta_usuario"].ToString();
                        unUsuario.Contraseña = reader["clave"].ToString();
                        unUsuario.Codigoperfil = reader["codigoperfil"].ToString();
                        unUsuario.Perfil = new PerfilDAC().GetPerfilByUsrName(reader["cuenta_usuario"].ToString());
                        unUsuario.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        unUsuario.Permite_eliminar = Convert.ToBoolean(reader["permite_eliminar"]);
                    }
                    sqlConn.Close();
                    return unUsuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int add_usuario(Usuario usuario)
        {
            int insercion = 0;
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_add_usuario";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", usuario.UserName);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@clave", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@anexo", usuario.Anexo);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@nivel", usuario.Nivel);
                    cmd.Parameters.AddWithValue("@intentos", usuario.Itentos);
                    cmd.Parameters.AddWithValue("@id_cliente", usuario.Cliente.Id_cliente);
                    cmd.Parameters.AddWithValue("@codigoperfil", usuario.Perfil.Codigoperfil);
                    cmd.Parameters.AddWithValue("@permite_eliminar", usuario.Permite_eliminar);
                    cmd.Parameters.AddWithValue("@usuanav", usuario.Usuanav);
                    cmd.Parameters.AddWithValue("@permite_pagar", usuario.Permite_pagar);
                    insercion = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return insercion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int add_modulo_usuario(string cuenta_usuario, Int16 id_modulo)
        {
            int insercion = 0;
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_add_usuario_modulo";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                    insercion = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return insercion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int del_modulo_usuario(string cuenta_usuario, Int16 id_modulo)
        {
            int insercion = 0;
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_del_usuario_modulo";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                    insercion = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return insercion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int add_sucursal_usuario(string cuenta_usuario, Int16 id_sucursal, Boolean check_encargado, Boolean check_supervisor)
        {
            int insercion = 0;
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_add_usuario_sucursal";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    cmd.Parameters.AddWithValue("@check_encargado", check_encargado);
                    cmd.Parameters.AddWithValue("@check_supervisor", check_supervisor);
                    insercion = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return insercion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int del_sucursal_usuario(string cuenta_usuario, Int16 id_sucursal, Boolean check_encargado, Boolean check_supervisor)
        {
            int insercion = 0;
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_del_usuario_sucursal";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);

                    insercion = cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return insercion;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string add_Usuarioopcionmenu(string cuenta_usuario, string codigoopcionmenu)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Usuarioopcionmenu", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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

        public string del_Usuarioopcionmenu(string cuenta_usuario, string codigoopcionmenu)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_Usuarioopcionmenu", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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

        public List<Usuario> Getusuariobycliente(Int32 id_cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_usuariobycliente";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Usuario> lusuario = new List<Usuario>();
                    while (reader.Read())
                    {
                        Usuario mUsuario = new Usuario();
                        mUsuario.Nombre = reader["Nombre"].ToString();
                        mUsuario.UserName = reader["cuenta_usuario"].ToString();
                        mUsuario.Codigoperfil = reader["codigoperfil"].ToString();
                        mUsuario.Nivel = reader["nivel"].ToString().Trim();
                        mUsuario.Perfil = new PerfilDAC().GetPerfilByUsrName(reader["cuenta_usuario"].ToString());
                        lusuario.Add(mUsuario);
                        mUsuario = null;
                    }
                    sqlConn.Close();
                    return lusuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> getusuariobyperfil(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_usuariobyperfil";
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Usuario> lcorreo = new List<Usuario>();
                    while (reader.Read())
                    {
                        Usuario mUsuario = new Usuario();
                        mUsuario.Nombre = reader["Nombre"].ToString();
                        mUsuario.UserName = reader["cuenta_usuario"].ToString();
                        mUsuario.Codigoperfil = reader["codigoperfil"].ToString();
                        mUsuario.Nivel = reader["nivel"].ToString().Trim();
                        mUsuario.Perfil = new PerfilDAC().GetPerfilByUsrName(reader["cuenta_usuario"].ToString());
                        lcorreo.Add(mUsuario);
                        mUsuario = null;
                    }
                    sqlConn.Close();
                    return lcorreo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Usuario> getusuariobynivel(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_usuariobynivel";
                    cmd.Parameters.AddWithValue("@nivel", codigo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Usuario> lcorreo = new List<Usuario>();
                    while (reader.Read())
                    {
                        Usuario mUsuario = new Usuario();
                        mUsuario.Nombre = reader["Nombre"].ToString();
                        mUsuario.UserName = reader["cuenta_usuario"].ToString();
                        mUsuario.Codigoperfil = reader["codigoperfil"].ToString();
                        mUsuario.Nivel = reader["nivel"].ToString().Trim();
                        mUsuario.Perfil = new PerfilDAC().GetPerfilByUsrName(reader["cuenta_usuario"].ToString());
                        lcorreo.Add(mUsuario);  
                    }
                    sqlConn.Close();
                    return lcorreo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}