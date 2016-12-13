using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ContratosDAC : CACCESO.BaseDAC
    {
        public List<Contratos> getcontratos(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_contratos_tr";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Contratos> lcontrato = new List<Contratos>();
                    while (reader.Read())
                    {
                        Contratos mcontrato = new Contratos();
                        mcontrato.Id_contrato = Convert.ToInt32(reader["id_contrato"].ToString());
                        mcontrato.Nombre= reader["nombre"].ToString();
                        mcontrato.Descripcion = reader["descripcion"].ToString();

                        lcontrato.Add(mcontrato);
                        mcontrato = null;
                    }
                    return lcontrato;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contratos> getcontratosbycliente(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_contratos_trbycliente";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Contratos> lcontrato = new List<Contratos>();
                    while (reader.Read())
                    {
                        Contratos mcontrato = new Contratos();
                        mcontrato.Id_contrato = Convert.ToInt32(reader["id_contrato"].ToString());
                        mcontrato.Nombre = reader["nombre"].ToString();
                        mcontrato.Descripcion = reader["descripcion"].ToString();

                        lcontrato.Add(mcontrato);
                        mcontrato = null;
                    }
                    return lcontrato;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
