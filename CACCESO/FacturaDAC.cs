using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class FacturaDAC : CACCESO.BaseDAC
    {

        public string add_factura(int id_nomina, Int32 folio, Int32 n_factura_agp, string fecha_factura_agp, string cuenta_usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_act_estado_agp_factura", sqlConn);
                    Cmd.CommandTimeout = 10000;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    oParam = Cmd.Parameters.AddWithValue("@folio", folio);
                    oParam = Cmd.Parameters.AddWithValue("@n_factura_agp", n_factura_agp);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura_agp);
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



        public string del_factura(int id_solicitud)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_estado_agp", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
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


        public string add_tabla_factura(Int32 n_factura_agp, string fecha_factura_agp, Int32 total_neto, string orden_compra, 
                                    Int32 id_cliente, string observacion, string cuenta_usuario,Int32 rut_tercero)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_add_facturacion", sqlConn);
                    Cmd.CommandTimeout = 10000;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@total", total_neto);
                    oParam = Cmd.Parameters.AddWithValue("@n_factura", n_factura_agp);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura_agp);
                    oParam = Cmd.Parameters.AddWithValue("@orden_compra", orden_compra);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@rut_tercero", rut_tercero);
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


        public List<Factura> GetOperacion_Fac(Int32 id_nomina, Int32 folio, Int32 id_cliente, Int32 numero_factura,Int32 id_familia)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_operaciones_factura";
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Factura> lfactura = new List<Factura>();
                    while (reader.Read())
                    {
                        Factura mfactura = new Factura();
                        mfactura.Cantidad_operaciones = Convert.ToInt32(reader["cantidad_operaciones"].ToString());
                        mfactura.Tipo_operacion = reader["tipo_operacion"].ToString();
                        mfactura.N_factura_agp = Convert.ToInt32(reader["n_factura"].ToString());
                        mfactura.Total_gasto = Convert.ToInt32(reader["total"].ToString());
                        mfactura.Folio = Convert.ToInt32(reader["folio"].ToString());
                        mfactura.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));
                        lfactura.Add(mfactura);
                        mfactura = null;
                    }
                    return lfactura;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Factura> getCobranza(Int32 id_cliente, Int32 numero_factura)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_operaciones_cobranza";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Factura> lfactura = new List<Factura>();
                    while (reader.Read())
                    {
                        Factura mfactura = new Factura();
                        mfactura.Fecha_factura_agp = Convert.ToDateTime(reader["fecha_factura"].ToString());
                        mfactura.N_factura_agp = Convert.ToInt32(reader["n_factura"].ToString());
                        mfactura.Total_gasto = Convert.ToInt32(reader["total"].ToString());
                        mfactura.Total_neto = Convert.ToInt32(reader["total_neto"].ToString());
                        mfactura.Saldo_pendiente = Convert.ToInt32(reader["saldo_pendiente"].ToString());
                        mfactura.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));

                        lfactura.Add(mfactura);
                        mfactura = null;
                    }
                    return lfactura;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Factura> GetOperacion_Fac_operacion(Int32 id_solicitud, Int32 id_familia)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_operaciones_factura_id_solicitud";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Factura> lfactura = new List<Factura>();
                    while (reader.Read())
                    {
                        Factura mfactura = new Factura();
                        
                        mfactura.Cantidad_operaciones = Convert.ToInt32(reader["cantidad_operaciones"].ToString());
                        mfactura.Tipo_operacion = reader["tipo_operacion"].ToString();
                        mfactura.N_factura_agp = Convert.ToInt32(reader["n_factura"].ToString());
                        mfactura.Total_gasto = Convert.ToInt32(reader["total"].ToString());
                        mfactura.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));
                        lfactura.Add(mfactura);
                        mfactura = null;
                    }
                    return lfactura;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_factura_oper(int id_solicitud, Int32 n_factura_agp, string fecha_factura_agp, string cuenta_usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_act_estado_agp_factura_oper", sqlConn);
                    Cmd.CommandTimeout = 10000;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@n_factura_agp", n_factura_agp);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura_agp);
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


        public string add_factura_oper_del(int id_solicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_act_estado_agp_factura_oper_del", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
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

        public string add_cambia_folio(int folio)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_cambia_folio", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@folio", folio);
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


        public string act_factura_del(int folio,int id_nomina)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_act_agp_factura_del", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@folio", folio);
                    Cmd.Parameters.AddWithValue("@id_nomina",id_nomina);
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
