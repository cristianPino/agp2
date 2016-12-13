using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class MovimientocuentaDAC : CACCESO.BaseDAC
    {

        public MovimientoCuenta getMovimientocuentabyGasto(Int32 id_solicitud, 
                                                            string tipo_movimiento,
                                                            Int16 id_tipogasto)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_MovimientocuentabyGasto";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                    cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);


                    SqlDataReader reader = cmd.ExecuteReader();

                    MovimientoCuenta mMovimientocuenta = new MovimientoCuenta();

                    if (reader.Read())
                    {

                        mMovimientocuenta.Cuenta_banco = new CuentabancoDAC().getCuentabanco(Convert.ToInt16(reader["id_Cuenta_banco"].ToString()));
                        mMovimientocuenta.Documento_especial = reader["documento_especial"].ToString();
                        mMovimientocuenta.Fecha_movimiento = Convert.ToDateTime(reader["fecha_movimiento"].ToString());
                        mMovimientocuenta.Id_movimiento_cuenta = Convert.ToInt16(Convert.ToInt16(reader["id_movimiento_cuenta"].ToString()));
                        mMovimientocuenta.Numero_documento = reader["numero_documento"].ToString();
                        mMovimientocuenta.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
                        mMovimientocuenta.Tipo_gasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
                        mMovimientocuenta.Tipo_movimiento = reader["tipo_movimiento"].ToString();
                        mMovimientocuenta.Tipo_operacion = reader["tipo_operacion"].ToString();
                        mMovimientocuenta.Monto = Convert.ToInt32(reader["monto"].ToString());
                        mMovimientocuenta.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());


                    }
                    else
                    {
                        mMovimientocuenta = null;
                    }

                    return mMovimientocuenta;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<MovimientoCuenta> getMovimientocuenta(Int32 id_solicitud, string tipo_movimiento)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_MovimientocuentabyIdSolicitud";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<MovimientoCuenta> lMovimientocuenta = new List<MovimientoCuenta>();

                    while (reader.Read())
                    {
                        MovimientoCuenta mMovimientocuenta = new MovimientoCuenta();                        
                        
                        mMovimientocuenta.Cuenta_banco = new CuentabancoDAC().getCuentabanco(Convert.ToInt16( reader["id_Cuenta_banco"].ToString()));
                        mMovimientocuenta.Documento_especial = reader["documento_especial"].ToString();
                        mMovimientocuenta.Fecha_movimiento = Convert.ToDateTime(reader["fecha_movimiento"].ToString());
                        mMovimientocuenta.Id_movimiento_cuenta = Convert.ToInt32(reader["id_movimiento_cuenta"].ToString());
                        mMovimientocuenta.Numero_documento = reader["numero_documento"].ToString();
                        mMovimientocuenta.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"].ToString()));
                        mMovimientocuenta.Tipo_gasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
                        mMovimientocuenta.Tipo_movimiento = reader["tipo_movimiento"].ToString();
                        mMovimientocuenta.Tipo_operacion = reader["tipo_operacion"].ToString();
                        mMovimientocuenta.Monto = Convert.ToInt32(reader["monto"].ToString());
                        mMovimientocuenta.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                        mMovimientocuenta.Tipo_gasto.Check = Convert.ToBoolean(reader["comun"].ToString());
                        if (mMovimientocuenta.Tipo_gasto.Check == true)
                        {
                            GastosComunes gc = new GastosComunesDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
                            Tipogasto tg = new Tipogasto();
                            tg.Cargo_contable = gc.Cargo_contable;
                            tg.Check = true;
                            tg.Descripcion = gc.Descripcion;
                            tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
                            tg.Valor = gc.Valor;
                            mMovimientocuenta.Tipo_gasto = tg;

                        }

                        lMovimientocuenta.Add(mMovimientocuenta);

                        mMovimientocuenta = null;
                    }
                    return lMovimientocuenta;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string add_Movimientocuenta(Int16 id_Movimiento_cuenta,
                                        Int32 id_solicitud,
                                        Int16 id_cuenta_banco,
                                        Int16 id_tipogasto,
                                        string numero_documento,
                                        string tipo_movimiento,
                                    string tipo_operacion,
                                    string documento_especial,
                                    string cuenta_usuario,
                                    Int32 monto,
                                    string chkgc)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_add_Movimientocuenta", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_movimiento_cuenta", id_Movimiento_cuenta);
                    oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@id_cuenta_banco", id_cuenta_banco);
                    oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
                    oParam = Cmd.Parameters.AddWithValue("@numero_documento", numero_documento);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    oParam = Cmd.Parameters.AddWithValue("@documento_especial", documento_especial);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@monto", monto);
                    oParam = Cmd.Parameters.AddWithValue("@chkgc", chkgc);


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


        public string add_MovimientocuentaPagoCompleto(
                                      Int32 id_solicitud,
                                      Int16 id_cuenta_banco,
                                      string numero_documento,
                                      string tipo_operacion,
                                      string documento_especial,
                                        string cuenta_usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_add_MovimientocuentaPagoCompleto", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@id_cuenta_banco", id_cuenta_banco);
                    oParam = Cmd.Parameters.AddWithValue("@numero_documento", numero_documento);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    oParam = Cmd.Parameters.AddWithValue("@documento_especial", documento_especial);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    

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


        public string del_Movimientocuenta(Int32 id_Movimiento_cuenta,string chkgc)
                                       
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_del_Movimientocuenta", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_movimiento_cuenta", id_Movimiento_cuenta);
                    oParam = Cmd.Parameters.AddWithValue("@chkgc", chkgc);
                    

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


        public string add_Rebajar_factura(Int16 id_cuenta_banco,
                                      string numero_documento,
                                  string tipo_operacion,
                                  string documento_especial,
                                  string cuenta_usuario,
                                  Int32 n_factura)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_add_MovimientocuentaFactura", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cuenta_banco", id_cuenta_banco);
                    oParam = Cmd.Parameters.AddWithValue("@numero_documento", numero_documento);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    oParam = Cmd.Parameters.AddWithValue("@documento_especial", documento_especial);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@n_factura", n_factura);


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
