using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class TipogastoDAC : CACCESO.BaseDAC
    {
		public Tipogasto getTipogasto(Int16 id_tipogasto)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Tipogasto";
                    cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    Tipogasto mTipogasto = new Tipogasto();
                    if (reader.Read())
                    {
                        mTipogasto.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));
                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                        mTipogasto.Tipooperacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mTipogasto.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
                    }
                    return mTipogasto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tipogasto> getTipoGastoMovimientocuenta(Int32 id_solicitud, string tipo_movimiento)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_GastosMovimiento";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Tipogasto> lTipogasto = new List<Tipogasto>();
                    while (reader.Read())
                    {
                        Tipogasto mTipogasto = new Tipogasto();
                        mTipogasto.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));
                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                        mTipogasto.Tipooperacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mTipogasto.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
                        lTipogasto.Add(mTipogasto);
                        mTipogasto = null;
                    }
                    return lTipogasto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tipogasto> getallTipogasto(Int16 id_cliente, string tipo_operacion)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Tipogastos";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Tipogasto> lTipogasto = new List<Tipogasto>();
                    while (reader.Read())
                    {
                        Tipogasto mTipogasto = new Tipogasto();
                        mTipogasto.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));
                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                        mTipogasto.Tipooperacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
                        mTipogasto.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
                        mTipogasto.Transferencia = Convert.ToBoolean(reader["transferencia"].ToString());
						mTipogasto.Habilitado = Convert.ToBoolean(reader["habilitado"].ToString());
						mTipogasto.Cuenta = reader["plan_cuenta"].ToString();
						mTipogasto.Cuenta_facturacion = reader["cuenta_facturacion"].ToString();

                        lTipogasto.Add(mTipogasto);
                        mTipogasto = null;
                    }
                    return lTipogasto;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public string add_Tipogasto(Int16 id_tipogasto, double valor, string descripcion, Int16 id_cliente, string tipo_operacion, string cargo_contable, string transferencia, string habil, string cuenta, string cuentafac)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Tipogasto", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    oParam = Cmd.Parameters.AddWithValue("@cargo_contable", cargo_contable);
                    oParam = Cmd.Parameters.AddWithValue("@transferencia", transferencia);
					oParam = Cmd.Parameters.AddWithValue("@habil", habil);
					oParam = Cmd.Parameters.AddWithValue("@cuenta", cuenta);
					oParam = Cmd.Parameters.AddWithValue("@cuentafac", cuentafac);
					
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