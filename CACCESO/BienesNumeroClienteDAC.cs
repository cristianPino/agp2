using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class BienesNumeroClienteDAC : CACCESO.BaseDAC
    {
        public string add_integracion_leasing(int id_solicitud, int dl_bien, int numero_emisor, string tipo_operacion)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("add_integracion_leasing", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@dl_bien", dl_bien);
                    Cmd.Parameters.AddWithValue("@numero_emisor", numero_emisor);
                    Cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
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

        public List<BienesNumeroCliente> GetBienesByNnumeroCliente(string numero_cliente, string tipo_operacion)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_bienes";
                    cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
                    cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BienesNumeroCliente> lBienes = new List<BienesNumeroCliente>();
                    while (reader.Read())
                    {
                        BienesNumeroCliente mBienes = new BienesNumeroCliente();
                        mBienes.NumeroCliente = numero_cliente;
                        mBienes.Detalle = reader["detalle"].ToString();
                        mBienes.Bien = Convert.ToInt32(reader["id_bien"]);
                        lBienes.Add(mBienes);
                        mBienes = null;
                    }
                    sqlConn.Close();
                    return lBienes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string act_datos_bien(int numeroOperacion,int factura,int id_bien,int id_solicitud,
                                     string patente,DateTime fecha_emision_factura,int instruccion_de_pago,int normaEuro)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_w_BienByFactura", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@numeroOperacion", numeroOperacion);
                    Cmd.Parameters.AddWithValue("@factura", factura);
                    Cmd.Parameters.AddWithValue("@id_bien", id_bien);
                    Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@patente", patente);
                    Cmd.Parameters.AddWithValue("@fecha_emision_factura", fecha_emision_factura);
                    Cmd.Parameters.AddWithValue("@instruccion_de_pago", instruccion_de_pago);
                    Cmd.Parameters.AddWithValue("@normaEuro", normaEuro);
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