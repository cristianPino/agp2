using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaInsertoTituloDAC         : BaseDAC
    {
        public HipotecaInsertoTitulo GetInsertoTitulo(int idInsertoTitulo)
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure,
                            CommandText = "sp_get_hipoteca_inserto_tituloById"
                        };
                    cmd.Parameters.AddWithValue("@id_inserto_titulo", idInsertoTitulo);
                    var reader = cmd.ExecuteReader();
                    var insertoTitulo = new HipotecaInsertoTitulo();
                    if (reader.Read())
                    {
                        insertoTitulo.IdInsertoTitulo = Convert.ToInt32(reader["id_inserto"]);
                        insertoTitulo.Descripcion = reader["descripcion"].ToString();
                        insertoTitulo.Formato = reader["formato"].ToString();
                    }
                    return insertoTitulo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HipotecaInsertoTitulo> GetAllInsertoTitulo()
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_get_hipoteca_inserto_titulo"
                    };
                    var reader = cmd.ExecuteReader();
                    var lista = new List<HipotecaInsertoTitulo>();
                    while (reader.Read())
                    {
                        var insertoTitulo = new HipotecaInsertoTitulo
                            {
                                IdInsertoTitulo = Convert.ToInt32(reader["id_inserto"]),
                                Descripcion = reader["descripcion"].ToString(),
                                Formato = reader["formato"].ToString()
                            };
                        lista.Add(insertoTitulo);
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
