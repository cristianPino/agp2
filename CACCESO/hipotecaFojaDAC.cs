using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;


namespace CACCESO
{
    public class hipotecaFojaDAC  : BaseDAC
    {
        public void AddFojas(hipotecaFoja h)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_add_hipoteca_fojas", sqlConn)
                        {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@id_foja",h.IdFoja );
                    cmd.Parameters.AddWithValue("@id_solicitud",h.IdSolicitud );
                    cmd.Parameters.AddWithValue("@tipofoja",h.CodigoTipo );
                    cmd.Parameters.AddWithValue("@inscripcionFojas",h.InscripcionFoja );
                    cmd.Parameters.AddWithValue("@inscripcionNumero",h.InscripcionNumero );
                    cmd.Parameters.AddWithValue("@inscripcionAnio",h.InscripcionAnio );
                    cmd.Parameters.AddWithValue("@observacion",h.Observacion);
                    cmd.Parameters.AddWithValue("@fojasLetra", h.InscripcionFojaLetra);
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();   
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public void del_Fojas(hipotecaFoja h)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_del_foja", sqlConn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@id_foja", h.IdFoja);
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<hipotecaFoja> GetFojas(hipotecaFoja h)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_get_fojasbyTipo", sqlConn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@id_solicitud", h.IdSolicitud);
                    cmd.Parameters.AddWithValue("@tipofoja", h.CodigoTipo);
                    var read = cmd.ExecuteReader();
                    var lista = new List<hipotecaFoja>();

                    while (read.Read())
                    {
                        var f = new hipotecaFoja
                            {
                                IdFoja = Convert.ToInt32(read["id_foja"]),
                                IdSolicitud = Convert.ToInt32(read["id_solicitud"]),
                                TipoFoja = new ParametroDAC().getparametro("FOJHI", read["tipoFoja"].ToString()),
                                InscripcionFoja = read["inscripcionFojas"].ToString(),
                                InscripcionNumero = read["inscripcionNumero"].ToString(),
                                InscripcionAnio = read["inscripcionAnio"].ToString(),
                                Observacion = read["observacion"].ToString() ,
                                InscripcionFojaLetra = read["fojasLetras"].ToString()
                            };
                        lista.Add(f);
                    }
                    sqlConn.Close();
                    return lista; 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
