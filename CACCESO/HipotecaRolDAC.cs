using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaRolDAC   : BaseDAC
    {
        public string AddHipotecarioRol(int idSolicitud, string numeroRol,int idRol=0)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var resultado = "";
                    var cmd = new SqlCommand("sp_add_hipoteca_rol", sqlConn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                    cmd.Parameters.AddWithValue("@numeroRol", numeroRol);
                    cmd.Parameters.AddWithValue("@id_rol", idRol);
                    var reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        resultado = reader["resultado"].ToString();
                    }
                    sqlConn.Close();
                    return resultado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            }

        public List<HipotecaRol> Get_hipoteca_roles(int idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var resultado = "";
                    var cmd = new SqlCommand("sp_get_hipoteca_roles", sqlConn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud); 
                    var reader = cmd.ExecuteReader();
                    var lista = new List<HipotecaRol>();
                    while (reader.Read())
                    {
                        var r = new HipotecaRol
                            {
                                IdRol = Convert.ToInt32(reader["id_rol"]),
                                IdSolicitud = Convert.ToInt32(reader["id_solicitud"]),
                                NumeroRol = reader["numeroRol"].ToString()
                            };
                        lista.Add(r);
                    }
                    sqlConn.Close();
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DelHipotecarioRol(int idRol)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {  
                    var cmd = new SqlCommand("sp_del_hipoteca_rol", sqlConn) { CommandType = CommandType.StoredProcedure };  
                    cmd.Parameters.AddWithValue("@id_rol", idRol);
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
