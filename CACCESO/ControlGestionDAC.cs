using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class ControlGestionDAC : CACCESO.BaseDAC
    {
        public string add_controlgestion(Int32 id_solicitud,  Int32 rut,Int32 id_producto_cliente,Int32 total_gestion, DateTime fecha_gestion, Int32 numero_cuotas,string numero_operacion,
                                        Int32 id_sucursal,string observacion, Int32 id_forma_pago, Int32 rut_vendedor,string patente, Int32 monto_final)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_w_controlgestion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@rut", rut);
                    oParam = Cmd.Parameters.AddWithValue("@id_producto_cliente", id_producto_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@total_gestion", total_gestion);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_gestion", fecha_gestion);
                    oParam = Cmd.Parameters.AddWithValue("@numero_cuotas", numero_cuotas);
                    oParam = Cmd.Parameters.AddWithValue("@numero_operacion", numero_operacion);
                    oParam = Cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
                    oParam = Cmd.Parameters.AddWithValue("@id_forma_pago", id_forma_pago);
                    oParam = Cmd.Parameters.AddWithValue("@rut_vendedor", rut_vendedor);
                    oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                    oParam = Cmd.Parameters.AddWithValue("@monto_final", monto_final);

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


        public Control_gestion getcontrolgestion(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_controlgestionbyIdSolicitud";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Control_gestion mcontrolgestion= new Control_gestion();

                    if (reader.Read())
                    {
                        mcontrolgestion.Id_solicitud = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
                        mcontrolgestion.Rut = new PersonaDAC().getpersonabyrut(Convert.ToInt32(reader["rut"]));
                        mcontrolgestion.Id_producto_cliente = new ProdClienteDAC().getProductoClietne(Convert.ToInt32(reader["id_producto_cliente"]));
                        mcontrolgestion.Total_gestion = Convert.ToInt32(reader["total_gestion"].ToString());
                        mcontrolgestion.Fecha_gestion = Convert.ToDateTime(reader["fecha_gestion"]);
                        mcontrolgestion.Numero_cuotas = Convert.ToInt32(reader["numero_cuotas"].ToString());
                        mcontrolgestion.Numero_operacion = reader["numero_operacion"].ToString();
                        mcontrolgestion.Id_sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"].ToString()));
                        mcontrolgestion.Observacion = reader["observacion"].ToString();
                        mcontrolgestion.Id_forma_pago=new FormaPagoDAC().getformapago(Convert.ToInt32(reader["id_forma_pago"].ToString()));
                        mcontrolgestion.Rut_vendedor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_vendedor"].ToString()));
                        mcontrolgestion.Patente = reader["patente"].ToString();
                        mcontrolgestion.Monto_final = Convert.ToInt32(reader["monto_final"].ToString());
                    }
                    else
                    { mcontrolgestion = null; }
                    return mcontrolgestion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
