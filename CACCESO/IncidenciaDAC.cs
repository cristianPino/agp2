using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CACCESO
{
    public class IncidenciaDAC : CACCESO.BaseDAC
    {

        #region CODIGO PARA CAMBIAR ESTADOS DE OPERACION
        public int addEstadoIncidencia(int idIncidencia, int idEstado, string cuentaUsuario, string cuentaUsuarioResponsable)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("add_incidencia_estado", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                Cmd.Parameters.AddWithValue("@id_estado", idEstado);
                Cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                Cmd.Parameters.AddWithValue("@cuenta_usuario_responsable", cuentaUsuarioResponsable);
                var reader = Cmd.ExecuteReader();
                int nuevoId = 0;

                if (reader.Read())
                {
                    nuevoId = Convert.ToInt32(reader["new_id"]);
                }
                sqlConn.Close();
                return nuevoId;
            }
        }

        #endregion

        #region DOCUMENTOS DE INCIDENCIA
        public void AddDocumentoIncidencia(int id_incidencia, string titulo, string url,string cuenta_usuario,string comentario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_incidencia_from_solicitud_nueva";
                cmd.Parameters.AddWithValue("@id_incidencia", id_incidencia);
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                cmd.Parameters.AddWithValue("@comentario", comentario);

                cmd.ExecuteNonQuery();
                sqlConn.Close();
               
            }
        }

        public DataTable GetDocumentosIncidencia(int idIncidencia)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_incidencia_documentos";
                cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        #endregion

        #region RESUMEN (home.aspx)
        public DataTable GetResumen(string codigoUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_perfil_resumen";
                cmd.Parameters.AddWithValue("@cuenta_usuario", codigoUsuario);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetDatosResumen(string codigoUsuario, string procedimiento)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedimiento;
                cmd.Parameters.AddWithValue("@cuenta_usuario", codigoUsuario);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        #endregion

        public DataTable GetIncidenciaFromNuevaSolicitud(int idSolicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_incidencia_from_solicitud_nueva";
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetJefeGrupoInc(string tipo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetJefeGrupoInc";
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetIncidenciaByChasis(string chasis)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getIncidencia_by_chasis";
                cmd.Parameters.AddWithValue("@chasis", chasis);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetIncidenciaById(int idIncidencia)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_incidencia_by_id";
                cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetComentariosByIncidencia(int idIncidencia)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_comentario_incidencia";
                cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }


        public DataTable GetIncidenciaByPatente(string patente)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getIncidencia";
                cmd.Parameters.AddWithValue("@patente", patente);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }              
        }

        public DataTable GetOperacionesIncidencia(int idIncidencia)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandTimeout = 2000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_operaciones_incidentes";
                cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public int AddIncidencia(string cuenta_usuario, string tipo, string patente, string comentario,int idCliente,int idSucursal, string chasis)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("AddIncidencia", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                oParam = Cmd.Parameters.AddWithValue("@chasis", chasis);
                oParam = Cmd.Parameters.AddWithValue("@id_sucursal", idSucursal);
                oParam = Cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                oParam = Cmd.Parameters.AddWithValue("@tipo", tipo);
                oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                oParam = Cmd.Parameters.AddWithValue("@comentario", comentario);
                var reader = Cmd.ExecuteReader();
                int nuevo_id = 0;
                if (reader.Read())
                {
                    nuevo_id = Convert.ToInt32(reader["nuevo_id"]);
                }
                sqlConn.Close();
                return nuevo_id;
            }
        }




        public int addComentarioIncidencia(int idIncidencia, int idIncidenciaEstado, string comentario, string cuentaUsuario, string asunto, string cuerpoCorreo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("add_incidencia_comentario", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                Cmd.Parameters.AddWithValue("@id_incidencia_estado", idIncidenciaEstado);
                Cmd.Parameters.AddWithValue("@comentario", comentario);
                Cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                Cmd.Parameters.AddWithValue("@asunto", asunto);
                Cmd.Parameters.AddWithValue("@cuerpo_correo", cuerpoCorreo);
                var reader = Cmd.ExecuteReader();
                int resultado = 0;

                if (reader.Read())
                {
                    resultado = Convert.ToInt32(reader["resultado"]);
                }
                sqlConn.Close();
                return resultado;
            }
        }

        public void addComentarioIncidenciaSinCorreo(int idIncidencia,string comentario, string cuentaUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("add_coemtario_incidencia_sin_correo", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);             
                Cmd.Parameters.AddWithValue("@comentario", comentario);
                Cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                Cmd.ExecuteNonQuery();            
                sqlConn.Close();               
            }
        }


        public void updIncidencia(int idIncidencia, int idSolicitud, int tipoCierre, bool cargoCliente)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("upd_incidencia", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                Cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                Cmd.Parameters.AddWithValue("@tipo_cierre", tipoCierre);
                Cmd.Parameters.AddWithValue("@cargo_cliente", cargoCliente);
                Cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }


        public void updIncidencia(int idIncidencia, int idSolicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("upd_incidencia_nueva_operacion", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                Cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);              
                Cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public DataTable GetTipoOperacionIncidencia(int idIncidencia)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("get_tipo_operacion_incidencia", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_incidencia", idIncidencia);
                DataTable dt = new DataTable();
                dt.Load(Cmd.ExecuteReader());
                sqlConn.Close();
                return dt;
            }
        }


        public DataTable GetIncidenciasUsuariosPorGrupo(bool jefe, string usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("get_incidencia_usuarios_de_grupo", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@jefe", jefe);
                Cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                DataTable dt = new DataTable();
                dt.Load(Cmd.ExecuteReader());
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetIncidenciasPermisos(string usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("get_incidencia_permisos", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                DataTable dt = new DataTable();
                dt.Load(Cmd.ExecuteReader());
                sqlConn.Close();
                return dt;
            }
        }


        public string GetProcedimientoBusqueda(string usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("get_incidencias", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);

                string procedimiento = string.Empty;
                var reader = Cmd.ExecuteReader();
                if (reader.Read())
                {
                    procedimiento = Convert.ToString(reader["procedimiento"]);
                }
                sqlConn.Close();
                return procedimiento;
            }

        }







        public DataTable GetIncidencias(string usuario, int idEstado, int idTicket, string patente, DataTable dtTickets, DataTable dtPatentes,DataTable dtChasis)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                var procedimiento = GetProcedimientoBusqueda(usuario);
                DataTable dt = new DataTable();
                if (procedimiento != string.Empty)
                {
                    SqlCommand Cmd = new SqlCommand(procedimiento, sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                    Cmd.Parameters.AddWithValue("@patente", patente);
                    Cmd.Parameters.AddWithValue("@numero_ticket", idTicket);
                    Cmd.Parameters.AddWithValue("@id_estado", idEstado);
                    Cmd.Parameters.Add("@lista_ticket", SqlDbType.Structured).Direction = ParameterDirection.Input;
                    Cmd.Parameters.Add("@lista_patente", SqlDbType.Structured).Direction = ParameterDirection.Input;
                    Cmd.Parameters.Add("@lista_chasis", SqlDbType.Structured).Direction = ParameterDirection.Input;

                    Cmd.Parameters[4].TypeName = "integer_list_tbltype";
                    Cmd.Parameters[4].Value = dtTickets;

                    Cmd.Parameters[5].TypeName = "varchar_list_tbltype";
                    Cmd.Parameters[5].Value = dtPatentes;

                    Cmd.Parameters[6].TypeName = "varchar_list_tbltype";
                    Cmd.Parameters[6].Value = dtChasis;

                    Cmd.CommandTimeout = 15000;


                    dt.Load(Cmd.ExecuteReader());
                    sqlConn.Close();
                }
                return dt;
            }

        }

        public DataTable GetIncidenciasEstado()
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                SqlCommand Cmd = new SqlCommand("get_all_incidencia_estado", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(Cmd.ExecuteReader());
                sqlConn.Close();
                return dt;
            }
        }



    }
}
