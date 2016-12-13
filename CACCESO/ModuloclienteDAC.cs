using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ModuloclienteDAC : CACCESO.BaseDAC
    {

        public ModuloCliente getModulo(Int16 id_modulo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_modulo";

                    cmd.Parameters.AddWithValue("@id_modulo", id_modulo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    ModuloCliente mModulocliente = new ModuloCliente();

                    if (reader.Read())
                    {
                        mModulocliente.Id_modulo = Convert.ToInt16(reader["id_modulo"]);
                        mModulocliente.Nombre = reader["nombre"].ToString();
                        mModulocliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                    }
                    return mModulocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModuloCliente> getModuloclientebycliente(int id_cliente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Moduloclientebycliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ModuloCliente> lModulocliente = new List<ModuloCliente>();

                    while (reader.Read())
                    {

                        ModuloCliente mModulocliente = new ModuloCliente();

                        mModulocliente.Id_modulo = Convert.ToInt16(reader["id_Modulo"]);
                        mModulocliente.Nombre = reader["nombre"].ToString();
                        mModulocliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));

                        lModulocliente.Add(mModulocliente);
                        mModulocliente = null;

                    }
                    return lModulocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModuloCliente> getUsuariomodulo(string usuario)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Usuariomodulo";

                    cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ModuloCliente> lModulocliente = new List<ModuloCliente>();

                    while (reader.Read())
                    {

                        ModuloCliente mModulocliente = new ModuloCliente();

                        mModulocliente.Id_modulo = Convert.ToInt16(reader["id_Modulo"]);
                        mModulocliente.Nombre = reader["nombre"].ToString();
                        mModulocliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));

                        lModulocliente.Add(mModulocliente);
                        mModulocliente = null;

                    }
                    return lModulocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModuloCliente> getModuloclientebyusuario(string usuario, Int16 id_cliente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Moduloclientebyusuario";

                    cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ModuloCliente> lModulocliente = new List<ModuloCliente>();

                    while (reader.Read())
                    {

                        ModuloCliente mModulocliente = new ModuloCliente();

                        mModulocliente.Id_modulo = Convert.ToInt16(reader["id_Modulo"]);
                        mModulocliente.Nombre = reader["nombre"].ToString();
                        mModulocliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mModulocliente.Check = Convert.ToBoolean(reader["check"]);

                        lModulocliente.Add(mModulocliente);
                        mModulocliente = null;

                    }
                    return lModulocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_Modulocliente(int id_cliente, string nombre)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Modulocliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
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



    }
}
