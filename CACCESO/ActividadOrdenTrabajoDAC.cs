using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using System.Data.SqlClient;
using CENTIDAD;

namespace CACCESO
{
    public class ActividadOrdenTrabajoDAC : BaseDAC
    {
        public ActividadDeOrdenTrabajo GetActividad(ActividadDeOrdenTrabajo ac)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_actividad_by_id" };
                cmd.Parameters.AddWithValue("@id_actividad", ac.IdActividad);
                var reader = cmd.ExecuteReader();
                var act = new ActividadDeOrdenTrabajo();
                if (reader.Read())
                {
                    act.IdActividad = Convert.ToInt32(reader["id_actividad_orden_trabajo"]);
                    act.Descripcion = reader["descripcion"].ToString();
                    act.Orden = Convert.ToInt32(reader["orden"]);
                    act.Url = reader["url"].ToString();
                    act.Sla = Convert.ToInt32(reader["sla"]);
                }
                sqlConn.Close();
                return act;

            }


        }

        public ActividadDeOrdenTrabajo GetSiguienteActividad(ActividadDeOrdenTrabajo ac)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_sigiuente_actividad_ot" };
                cmd.Parameters.AddWithValue("@id_actividad", ac.IdActividad);
                var reader = cmd.ExecuteReader();
                var act = new ActividadDeOrdenTrabajo();
                if (reader.Read())
                {
                    act.IdActividad = Convert.ToInt32(reader["id_actividad_orden_trabajo"]);
                    act.Descripcion = reader["descripcion"].ToString();
                    act.Orden = Convert.ToInt32(reader["orden"]);
                    act.Url = reader["url"].ToString();
                    act.Sla = Convert.ToInt32(reader["sla"]);
                }
                sqlConn.Close();
                return act;

            }


        }

        public List<ActividadDeOrdenTrabajo> GetActividadesOtByUsuario(string cuentaUsuario)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_actividades_ot" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                var lista = new List<ActividadDeOrdenTrabajo>();
                while (reader.Read())
                {
                    var act = new ActividadDeOrdenTrabajo();
                    act.IdActividad = Convert.ToInt32(reader["id_actividad_orden_trabajo"]);
                    act.Descripcion = reader["descripcion"].ToString();
                    act.Orden = Convert.ToInt32(reader["orden"]);
                    act.Url = reader["url"].ToString();
                    act.Sla = Convert.ToInt32(reader["sla"]);
                    lista.Add(act);
                }
                sqlConn.Close();
                return lista;

            }

        }
    }
}
