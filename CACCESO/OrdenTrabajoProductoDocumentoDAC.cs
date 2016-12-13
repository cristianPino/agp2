using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class OrdenTrabajoProductoDocumentoDAC : BaseDAC
    {
        public List<OrdenTrabajoProductoDocumento> GetAllProductos()
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_getAllProductosOrdenPedido" };

                var reader = cmd.ExecuteReader();
                var lista = new List<OrdenTrabajoProductoDocumento>();
                while (reader.Read())
                {
                    var prodoc = new OrdenTrabajoProductoDocumento { TipoOperacion = new TipooperacionDAC().getTipooperacion(reader["codigoProducto"].ToString().Trim()) };
                    lista.Add(prodoc);

                }
                sqlConn.Close();
                return lista; 
            }
        }



        public bool ExisteProducto(int idOrdenTrabajo, string idProducto)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_getAllProductosByOrdenPedido" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOrdenTrabajo);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                var reader = cmd.ExecuteReader();

                var respuesta = false;
                while (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["existe"]);
                }
                sqlConn.Close();
                return respuesta;
            }
        }

        public bool ExisteDocumento(int idOrdenTrabajo, int idDocumnento)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_getAllDocumentoByOrdenPedido" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOrdenTrabajo);
                cmd.Parameters.AddWithValue("@id_documento", idDocumnento);
                var reader = cmd.ExecuteReader();

                var respuesta = false;
                while (reader.Read())
                {
                    respuesta = Convert.ToBoolean(reader["existe"]);
                }
                sqlConn.Close();
                return respuesta;
            }
        }

        public List<OrdenTrabajoProductoDocumento> GetAllDocumentoByProducto(string codigoProducto)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_getAllDocumentosByProductoOt" };
                cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
                var reader = cmd.ExecuteReader();
                var lista = new List<OrdenTrabajoProductoDocumento>();
                while (reader.Read())
                {
                    var prodoc = new OrdenTrabajoProductoDocumento { Documento = new DocumentosDAC().getDocumentosbyID(Convert.ToInt16(reader["idDocumento"])) };
                    lista.Add(prodoc);

                }
                sqlConn.Close();
                return lista;
            }
        }
    }
}
