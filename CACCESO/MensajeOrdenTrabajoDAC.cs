using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class MensajeOrdenTrabajoDAC : CACCESO.BaseDAC
    {
        public int AddMensaje(MensajeOrdenTrabajo mensaje)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_add_mensaje_orden_trabajo" };
                cmd.Parameters.AddWithValue("@mensaje", mensaje.Mensaje);
                cmd.Parameters.AddWithValue("@id_orden_trabajo", mensaje.IdOrdenTrabajo);
                cmd.Parameters.AddWithValue("@id_usuario", mensaje.IdUsuario);
                var read = cmd.ExecuteReader();
                var nuevoId = 0;
                if(read.Read())
                {
                    nuevoId = Convert.ToInt32(read["newId"]);
                }
                sqlConn.Close();
                sqlConn.Dispose();
                return nuevoId;
                
            }  
        }     

        public List<MensajeOrdenTrabajo> GetMensajes(int idOrdenTrabajo)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_mensaje_orden_trabajo" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOrdenTrabajo);
                var reader = cmd.ExecuteReader();
                var lista = new List<MensajeOrdenTrabajo>();
                while (reader.Read())
                {
                    var m = new MensajeOrdenTrabajo();
                    m.IdMensaje = Convert.ToInt32(reader["id_mensaje"]);
                    m.Mensaje = Convert.ToString(reader["mensaje"]);
                    m.IdUsuario = Convert.ToString(reader["cuenta_usuario"]);
                    m.Fecha = Convert.ToString(reader["fecha_mensaje"]);
                    m.NombreUsuario = Convert.ToString(reader["nombre"]);
                    lista.Add(m);
                }    
                sqlConn.Close();
                sqlConn.Dispose();
                return lista;
            }
        }

        public List<MensajeOrdenTrabajo> GetContactos(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_contacto_mensaje" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                var lista = new List<MensajeOrdenTrabajo>();
                while (reader.Read())
                {
                    var m = new MensajeOrdenTrabajo(); 
                    m.IdUsuario = Convert.ToString(reader["usuario_destinatario"]); 
                    m.NombreUsuario = Convert.ToString(reader["nombre"]);
                    m.Favorito = Convert.ToBoolean(reader["favorito"]);
                    lista.Add(m);
                }
                sqlConn.Close();
                sqlConn.Dispose();
                return lista;
            }
        }

        public void AddMensajeaDestinatarios(int idMensaje, string usuarioDestino, string actualizaFecha)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_add_mensaje_a_destinatarios" };
                cmd.Parameters.AddWithValue("@id_mensaje", idMensaje);
                cmd.Parameters.AddWithValue("@fecha_lectura", actualizaFecha);
                cmd.Parameters.AddWithValue("@id_usuario_destino", usuarioDestino);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
    }
}
