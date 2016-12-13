using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class chequesDAC : CACCESO.BaseDAC
    {

        public DataTable GetMovimientoCajaChicaByFamilia(int idFamilia)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand("get_movimientos_caja_chica_by_familia", sqlConn)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                cmd.Parameters.AddWithValue("@id_familia", idFamilia);  

                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                sqlConn.Close();
                return dt;
            }

        }

        public string[] AddMovimientoCajaChica(string cuentaUsuario, int idFamilia, int monto, string tipo, int tipoGasto = 0, int idSolicitud = 0)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand("add_movimiento_caja_chica", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@id_familia", idFamilia);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@id_tipo_gasto", tipoGasto);
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                var reader = cmd.ExecuteReader();
                var devolucion = new string[2];
               
                if (reader.Read())
                {
                    devolucion = new[]{ Convert.ToString(reader["resultado"]),  //true ; false
                                                     Convert.ToString(reader["mensaje"]) }; //mensaje string

                }

                sqlConn.Close();
                return devolucion;
            }

        }



        public string add_cta_cte(string banco, int ctacte, string talonario, string tipo_movimiento,
                    int montoini, string numero_cheque, string usuar, string solicitante)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_cheque", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@banco", banco);

                    oParam = Cmd.Parameters.AddWithValue("@cuenta", ctacte);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                    oParam = Cmd.Parameters.AddWithValue("@talonario", talonario);
                    oParam = Cmd.Parameters.AddWithValue("@montoini", montoini);
                    oParam = Cmd.Parameters.AddWithValue("@numero_cheque", numero_cheque);
                    oParam = Cmd.Parameters.AddWithValue("@usuario", usuar);
                    oParam = Cmd.Parameters.AddWithValue("@solicitante", solicitante);
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

        public string rendir_cheque(Int32 id_inventario, string observacion, Int32 monto_rendido)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_w_rendir_cheque", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_inventario", id_inventario);
                    oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
                    oParam = Cmd.Parameters.AddWithValue("@monto_rendido", monto_rendido);
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
        public string del_cta_cte(int fila)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_cheques", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_inventario", fila);


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



        public List<Cheques> getCta_Cte(string desde, string hasta, Int16 tipo_movimiento, string rendido)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_cheques";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@desde", Convert.ToDateTime(desde).ToString("yyyyMMdd"));
                    oParam = cmd.Parameters.AddWithValue("@hasta", Convert.ToDateTime(hasta).ToString("yyyyMMdd"));
                    oParam = cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                    oParam = cmd.Parameters.AddWithValue("@rendido", rendido);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cheques> lcta_cte = new List<Cheques>();
                    while (reader.Read())
                    {
                        Cheques mcta_cte = new Cheques();

                        mcta_cte.Banco = reader["banco"].ToString().Trim();
                        mcta_cte.Ctacte = Convert.ToInt32(reader["cuenta"]);
                        mcta_cte.Talonario = Convert.ToInt32(reader["talonario"]);
                        mcta_cte.Num_cheq = (reader["numero_cheque"].ToString().Trim());
                        mcta_cte.Monto_inicial = Convert.ToInt32(reader["montoini"]);
                        mcta_cte.Tipo_movimiento = Convert.ToInt32(reader["tipo_movimiento"]);
                        mcta_cte.Id_inventario = Convert.ToInt32(reader["id_inventario"]);
                        mcta_cte.Rendido = reader["rendido"].ToString();
                        mcta_cte.Fecha_movimiento = Convert.ToDateTime(reader["fecha_movi"].ToString());
                        mcta_cte.Fecha_rendicion = Convert.ToDateTime(reader["fecharendicion"].ToString());
                        mcta_cte.Monto_rendido = Convert.ToInt32(reader["montorendido"].ToString());
                        mcta_cte.Solicitante = reader["solicitante"].ToString();
                        mcta_cte.Nomina = reader["Nomina"].ToString();
                        mcta_cte.Folio = reader["folio"].ToString();
                        lcta_cte.Add(mcta_cte);
                        mcta_cte = null;
                    }
                    return lcta_cte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cheques getcheqques(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_inventario_cheques";
                    cmd.Parameters.AddWithValue("@id_inventario", codigo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Cheques mCheques = new Cheques();
                    if (reader.Read())
                    {
                        mCheques.Nombre_banco = reader["nombre"].ToString();
                        mCheques.Numerocta = reader["numero_cuenta"].ToString();
                        mCheques.Monto_inicial = Convert.ToInt32(reader["montoini"].ToString());
                        mCheques.Num_cheq = reader["numero_cheque"].ToString().Trim();
                    }
                    return mCheques;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
