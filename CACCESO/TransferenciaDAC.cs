using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
   public class TransferenciaDAC : CACCESO.BaseDAC
    {



       public Transferencia GetTransferenciaByIdSolicitud(Int32 id_solicitud)
       {

           try
           {
               using (SqlConnection sqlConn = new SqlConnection(this.strConn))
               {
                   sqlConn.Open();
                   SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.CommandText = "sp_r_transferenciabyIdSolicitud";
                   cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                   SqlDataReader reader = cmd.ExecuteReader();
                   Transferencia mtransferencia = new Transferencia();

                   if (reader.Read())
                   {
                       mtransferencia.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
                       mtransferencia.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble( reader["rut_compra_para"].ToString()));
                       mtransferencia.Comprador = new PersonaDAC().getpersonabyrut( Convert.ToDouble(reader["rut_comprador"].ToString()));
                       mtransferencia.Ejecutivo = new UsuarioDAC().GetusuariobyUsername(reader["rut_comprador"].ToString());
                       mtransferencia.Vendedor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_vendedor"].ToString()));
                       mtransferencia.Id_sucursal = Convert.ToInt32(reader["id_sucursal"].ToString());
                       mtransferencia.Forma_pago = reader["forma_pago"].ToString();
                       mtransferencia.Banco_financiera  =  new BancofinancieraDAC().getBancofinanciera ( reader["financiamiento"].ToString());
                       mtransferencia.Tag = reader["tag"].ToString();
                        mtransferencia.Tipo_Transferencia = reader["tipo_transferencia"].ToString();

                    }
                   else
                   { mtransferencia = null; }
                   return mtransferencia;
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


        public string add_Transferencia(Transferencia transferencia, Int32 id_solicitud)
        {

            


            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    string codigo_banco;

                    if (transferencia.Banco_financiera == null)
                    {
                        codigo_banco = "0";
                    }
                    else
                    {
                        codigo_banco = transferencia.Banco_financiera.Codigo.Trim();    
                    }

                    double rut_comprador;
                    if (transferencia.Comprador == null)
                    { rut_comprador=0;}
                    else { rut_comprador = transferencia.Comprador.Rut; }

                    double rut_compra_para;
                    if (transferencia.Compra_para == null)
                    { rut_compra_para = 0; }
                    else { rut_compra_para = transferencia.Compra_para.Rut; }




                    SqlCommand Cmd = new SqlCommand("sp_w_transferencia", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@rut_vendedor", transferencia.Vendedor.Rut);
                    oParam = Cmd.Parameters.AddWithValue("@rut_comprador", rut_comprador);
                    oParam = Cmd.Parameters.AddWithValue("@rut_compra_para", rut_compra_para);
                    oParam = Cmd.Parameters.AddWithValue("@id_sucursal", transferencia.Id_sucursal);
                    oParam = Cmd.Parameters.AddWithValue("@financiamiento", codigo_banco);
                    oParam = Cmd.Parameters.AddWithValue("@forma_pago", transferencia.Forma_pago);
                    oParam = Cmd.Parameters.AddWithValue("@tag", transferencia.Tag);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_transferencia", transferencia.Tipo_Transferencia);

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




        public Transferencia ValidarTransferencia(Int32 rut_comprador, string patente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_validar_transferencia";
                    cmd.Parameters.AddWithValue("@rut_comprador", rut_comprador);
                    cmd.Parameters.AddWithValue("@patente", patente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Transferencia mtransferencia = new Transferencia();

                    if (reader.Read())
                    {
                        mtransferencia.Validacion = reader["validacion"].ToString();
                    }
                    else
                    { mtransferencia = null; }
                    return mtransferencia;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
