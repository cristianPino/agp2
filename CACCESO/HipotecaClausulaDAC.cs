using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaClausulaDAC  :BaseDAC
    {
        public string AddClausula(Int32 idCalusula, int tipoCredito)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {     

                    SqlCommand Cmd = new SqlCommand("sp_add_hipotecaClausula", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@idClausula", idCalusula);
                    oParam = Cmd.Parameters.AddWithValue("@idTipoCredito", tipoCredito);
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

        public string DelClausula(Int32 idCalusula, int tipoCredito)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_hipotecaClausula", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@idClausula", idCalusula);
                    oParam = Cmd.Parameters.AddWithValue("@idTipoCredito", tipoCredito); 
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
        public List<HipotecaClausula> GetAll(Int32 idCliente, int idTipoCredito)
        {  
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand(strConn, sqlConn)
                        {
                            CommandType = CommandType.StoredProcedure, CommandText = "sp_r_hipotecaClausula"
                        };

                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idTipoCredito", idTipoCredito);    
                    var reader = cmd.ExecuteReader();

                    var lista = new List<HipotecaClausula>();

                    while (reader.Read())
                    {   
                        var cla = new HipotecaClausula
                            {
                                IdClausula = Convert.ToInt32(reader["id_clausula"]),
                                Nombre = reader["formato"].ToString(),
                                Texto = reader["texto"].ToString(),
                                Pertenece = Convert.ToBoolean(reader["check"])
                            };

                        lista.Add(cla);  
                    }
                    return lista;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
