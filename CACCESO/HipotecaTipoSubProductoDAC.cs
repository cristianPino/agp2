using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaTipoSubProductoDAC   :BaseDAC
    {
        public List<HipotecaTipoSubProducto> GetAll(HipotecaTipoSubProducto h)
        {  
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
               
                    var cmd = new SqlCommand("sp_get_hipoteca_subproducto_by_cliente", sqlConn)
                        {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@id_cliente", h.IdCliente);
                    
                    var reader = cmd.ExecuteReader();
                    var lista = new List<HipotecaTipoSubProducto>();
      
                    while (reader.Read())
                    {  
                        var hi = new HipotecaTipoSubProducto
                            {
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                Id = Convert.ToInt32(reader["id_tipo_subProducto"]),
                                Descripcion = reader["descripcion"].ToString()
                            };
                        lista.Add(hi);
                    }

                    sqlConn.Close();
                    return lista;
                }
               
            }
        

        
    }
}
