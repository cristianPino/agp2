using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class ParticipanteSucursalDAC : CACCESO.BaseDAC
    {
        public List<ParticipanteSucursal> getParticipantesucursal(Int16 id_modulo, string rut_participante)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Participantesucursal";
                    cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                    cmd.Parameters.AddWithValue("@rut_participante", rut_participante);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ParticipanteSucursal> lSucursalcliente = new List<ParticipanteSucursal>();
                    while (reader.Read())
                    {
                        ParticipanteSucursal mSucursalcliente = new ParticipanteSucursal();
                        mSucursalcliente.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mSucursalcliente.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(reader["id_comuna"]));
                        mSucursalcliente.Id_sucursal = Convert.ToInt16(reader["id_sucursal"]);
                        mSucursalcliente.Nombre = reader["nombre"].ToString();
                        mSucursalcliente.Ind_principal1 = Convert.ToInt16(reader["ind_principal"]);
                        mSucursalcliente.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                        mSucursalcliente.Check =Convert.ToBoolean(reader["check"].ToString());
                        lSucursalcliente.Add(mSucursalcliente);
                        mSucursalcliente = null;
                    }
                    return lSucursalcliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_ParticipanteSucursal(string rut_participante, Int32 id_sucursal)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_ParticipanteSucursal", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut_participante", rut_participante);
                    oParam = Cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
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

        public string del_ParticipanteSucursal(string rut_participante,Int32 id_sucursal)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_ParticipanteSucursal", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@rut_participante", rut_participante);
                    oParam = Cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
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
