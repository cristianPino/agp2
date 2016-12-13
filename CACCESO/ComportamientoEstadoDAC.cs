using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ComportamientoEstadoDAC : CACCESO.BaseDAC
    {

        public string add_comportamiento(Int32 codigo_estado, Int32 origen, Int32 codigo_final)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
               
                    SqlCommand Cmd = new SqlCommand("sp_add_comportamiento", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    Cmd.Parameters.AddWithValue("@origen", origen);
                    Cmd.Parameters.AddWithValue("@codigo_final", codigo_final);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";  
            }
        }


        public string del_comportamiento(Int32 id_comportamiento)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                
                    SqlCommand Cmd = new SqlCommand("sp_del_comportamiento", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_comportamiento", id_comportamiento);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }  
            
        }

        public bool ValidacionComportamiento(int estadoActual, int siguienteEstado)
        {
            //Valida que el siguiente estado esté especificado en los comportamientos
            //Para asegurar que no se dirija a un estado que no le corresponda
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "valida_comportamiento_estado_familia" };
                cmd.Parameters.AddWithValue("@estado_actual", estadoActual);
                cmd.Parameters.AddWithValue("@estado_final", siguienteEstado);
                var reader = cmd.ExecuteReader();
                var permiteCambio = false;
                if (reader.Read())
                {
                    permiteCambio = Convert.ToBoolean(reader["respuesta"].ToString()); 
                }
                sqlConn.Close();
                return permiteCambio;
            }    
        }



        public List<ComportamientoEstado> getComportamiento(Int32 codigo_estado)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_comportamiento";
                    cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ComportamientoEstado> lcomp = new List<ComportamientoEstado>();
                    while (reader.Read())
                    {
                        ComportamientoEstado mcomp = new ComportamientoEstado();
                        mcomp.Id_comportamiento = Convert.ToInt32(reader["id_comportamiento"].ToString());
                        mcomp.Codigo_estado = Convert.ToInt32(reader["codigo_estado"].ToString());
                        mcomp.Estado_origen = Convert.ToInt32(reader["origen"].ToString());
                        mcomp.Estado_final = Convert.ToInt32(reader["codigo_final"].ToString());
                        lcomp.Add(mcomp);
                        mcomp = null;
                    }
                    sqlConn.Close();
                    return lcomp;
                }    
        }

        public List<ComportamientoEstado> GetComportamientoFlujo(int codigoEstado, int codigoOrigen)
        {
            //Trae las alternativas para poder cambiar de estado....solo trae alternativas cambio manual true
            using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_flujo_comportamiento" };
                    cmd.Parameters.AddWithValue("@codigo_estado", codigoEstado);
                    cmd.Parameters.AddWithValue("@codigo_origen", codigoOrigen);
                    var reader = cmd.ExecuteReader();
                    var lcomp = new List<ComportamientoEstado>();
                    while (reader.Read())
                    {
                        var mcomp = new ComportamientoEstado
                            {
                                Id_comportamiento = Convert.ToInt32(reader["id_comportamiento"].ToString()),
                                Codigo_estado = Convert.ToInt32(reader["codigo_estado"].ToString()),
                                Estado_origen = Convert.ToInt32(reader["origen"].ToString()),
                                Estado_final = Convert.ToInt32(reader["codigo_final"].ToString())     ,
                                EstadoFinalDescripcion = reader["final_descripcion"].ToString()
                            };
                        lcomp.Add(mcomp); 
                    }
                    sqlConn.Close();
                    return lcomp;
                } 
        }

        public ComportamientoEstado GetEstadoOrigen(int idSolicitud)
        {
            //Trae la segunda fila de la tabla estado_operacion 
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "get_estado_origen" };
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                var reader = cmd.ExecuteReader();
                ComportamientoEstado mcomp;
                if (reader.Read())
                {
                    mcomp = new ComportamientoEstado
                    {  
                        Estado_origen = Convert.ToInt32(reader["origen"].ToString()), 
                    };
                }
                else
                {
                    mcomp = new ComportamientoEstado
                    {
                        Estado_origen = 0,
                    };
                }
                sqlConn.Close();
                return mcomp;
            }
        }



    }
}
