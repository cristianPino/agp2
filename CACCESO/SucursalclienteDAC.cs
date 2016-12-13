using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class SucursalclienteDAC : CACCESO.BaseDAC
    {
        public List<Usuario> GetUsuariosEnSucursal(Int16 id_sucursal)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_usuarios_sucursal";
                cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);   
                SqlDataReader reader = cmd.ExecuteReader();

                var lista = new List<Usuario>();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario = new Usuario
                    {
                        UserName = Convert.ToString(reader["cuenta_usuario"]),
                        Nombre = Convert.ToString(reader["nombre"]).ToUpper()
                    };

                    lista.Add(usuario);
                }
                sqlConn.Close();
                return lista;
            }
        }

        public bool getEncargadoSucursal(Int16 id_sucursal, string cuenta_usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "es_encargado_sucursal";
                cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                SqlDataReader reader = cmd.ExecuteReader();

                bool encargado = false;
                if (reader.Read())
                {
                    encargado = Convert.ToBoolean(reader["encargado"]);
                }
                sqlConn.Close();
                return encargado;
            }
        }



        public SucursalCliente getSucursal(Int16 id_sucursal)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursal";
                cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                SqlDataReader reader = cmd.ExecuteReader();
                SucursalCliente mSucursalcliente = new SucursalCliente();
                if (reader.Read())
                {
                    mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                }
                sqlConn.Close();
                return mSucursalcliente;
            }

        }

        public SucursalCliente GetSucursalShort(Int16 id_sucursal)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursal";
                cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                SqlDataReader reader = cmd.ExecuteReader();
                SucursalCliente mSucursalcliente = new SucursalCliente();
                if (reader.Read())
                {
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();

                }
                sqlConn.Close();
                return mSucursalcliente;
            }

        }

        public SucursalCliente getSucursalParidadAG(string codigo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursal_paridad_ag";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                SqlDataReader reader = cmd.ExecuteReader();
                SucursalCliente mSucursalcliente = new SucursalCliente();
                if (reader.Read())
                {
                    mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                }
                sqlConn.Close();
                return mSucursalcliente;
            }

        }

        public List<SucursalCliente> getSucursalbycliente(Int16 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursalbycliente";
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                    lSucursalcliente.Add(mSucursalcliente);
                    mSucursalcliente = null;
                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }

        public List<SucursalCliente> GetSucursalbyclienteShort(Int16 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursalbycliente";
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Modulocliente = new ModuloCliente
                    {
                        Id_modulo = Convert.ToInt16(reader["id_modulo"]),
                        Nombre = reader["modulo"].ToString(),
                        Cliente = new Cliente { Id_cliente = Convert.ToInt16(reader["id_cliente"]), Persona = new Persona {Nombre = reader["nom_cliente"].ToString() } }
                    };
                    mSucursalcliente.Comuna = new Comuna{ Id_Comuna= Convert.ToInt16(reader["id_comuna"]),Nombre = reader["comuna"].ToString()};

                    lSucursalcliente.Add(mSucursalcliente);

                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }

        public List<SucursalCliente> GetSucursalbyclienteCombobox(Int16 idCliente)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_r_sucursalbycliente" };
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                SqlDataReader reader = cmd.ExecuteReader();
                var lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    var mSucursalcliente = new SucursalCliente
                        {
                            Id_sucursal = Convert.ToInt16(reader["id_sucursal"]),
                            Nombre = reader["nombre"].ToString()
                        };
                    lSucursalcliente.Add(mSucursalcliente);

                }
                sqlConn.Close();
                return lSucursalcliente;
            }
        }


        public List<SucursalCliente> getSucursalbymodulo(Int16 id_modulo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursalbymodulo";
                cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                    lSucursalcliente.Add(mSucursalcliente);
                    mSucursalcliente = null;
                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }

        public List<SucursalCliente> getUsuariosucursal(Int16 id_modulo, string usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_Usuariosucursal";
                cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                    mSucursalcliente.Check = Convert.ToBoolean(reader["check"]);
                    mSucursalcliente.Check_encargado = Convert.ToBoolean(reader["encargado"].ToString());
                    mSucursalcliente.Check_supervisor = Convert.ToBoolean(reader["supervisor"].ToString());
                    lSucursalcliente.Add(mSucursalcliente);
                    mSucursalcliente = null;
                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }

        public string add_Sucursalcliente(Int16 id_comuna, Int16 id_cliente, Int16 id_modulo, string nombre, int ind_principal)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("sp_add_sucursal_cliente", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_comuna", id_comuna);
                oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                oParam = Cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                oParam = Cmd.Parameters.AddWithValue("@nombre", nombre);
                oParam = Cmd.Parameters.AddWithValue("@ind_principal", ind_principal);
                Cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
            return string.Empty;
        }

        public List<SucursalCliente> getSucursalByClienteAndUsuario(Int16 id_cliente, string usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_SucursalByClienteAndUsuario";
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    //mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    //mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    //mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                    mSucursalcliente.Check = Convert.ToBoolean(reader["check"]);
                    lSucursalcliente.Add(mSucursalcliente);
                    mSucursalcliente = null;
                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }

        public List<SucursalCliente> GetSucursalByClienteAndUsuarioShort(Int16 id_cliente, string usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_SucursalByClienteAndUsuario";
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    lSucursalcliente.Add(mSucursalcliente);
                    mSucursalcliente = null;
                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }


        public List<SucursalCliente> getSucursalByClienteAndUsuarioconc(Int16 id_cliente, string usuario, string concesionaria)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_SucursalByClienteAndUsuarioconces";
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                cmd.Parameters.AddWithValue("@concesionaria", concesionaria);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SucursalCliente> lSucursalcliente = new List<SucursalCliente>();
                while (reader.Read())
                {
                    SucursalCliente mSucursalcliente = new SucursalCliente();
                    mSucursalcliente.Cliente = new Cliente {Id_cliente = (Convert.ToInt16(reader["id_cliente"])),
                        Persona = new Persona {Rut = Convert.ToDouble(reader["rut"].ToString()),Nombre = reader["nom_cliente"].ToString() } };
                    mSucursalcliente.Comuna = new Comuna { Id_Comuna = (Convert.ToInt16(reader["id_comuna"])),Nombre = reader["comuna"].ToString(),
                        Ciudad = new Ciudad {Id_Ciudad = Convert.ToInt32(reader["id_ciudad"].ToString()),Nombre = reader["ciudad"].ToString() } };
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloCliente {Id_modulo= (Convert.ToInt16(reader["id_modulo"])),Nombre = reader["modulo"].ToString() };
                    mSucursalcliente.Check = Convert.ToBoolean(reader["check"]);
                    lSucursalcliente.Add(mSucursalcliente);
                    mSucursalcliente = null;
                }
                sqlConn.Close();
                return lSucursalcliente;
            }

        }



        public SucursalCliente getSucursalParidad(string codigo, Int32 id_cliente)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_sucursal_paridad";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                SqlDataReader reader = cmd.ExecuteReader();
                SucursalCliente mSucursalcliente = new SucursalCliente();
                if (reader.Read())
                {
                    mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                    mSucursalcliente.Nombre = reader["nombre"].ToString();
                    mSucursalcliente.Ind_principal = Convert.ToInt16(reader["ind_principal"]);
                    mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                }
                sqlConn.Close();
                return mSucursalcliente;
            }

        }

        public SucursalCliente getsucursalnav(Int32 id_sucursal)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_getregion_nav";
                cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                SqlDataReader reader = cmd.ExecuteReader();
                SucursalCliente mSucursalcliente = new SucursalCliente();
                if (reader.Read())
                {
                    mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"].ToString());
                    mSucursalcliente.Codnav = reader["codnav"].ToString();

                }
                sqlConn.Close();
                return mSucursalcliente;
            }

        }


    }
}