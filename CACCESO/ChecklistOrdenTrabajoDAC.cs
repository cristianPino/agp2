using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class ChecklistOrdenTrabajoDAC : BaseDAC
    {
        public string AddChecklistOrdenTrabajo(ChecklistOrdenTrabajo check)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
               
                    var Cmd = new SqlCommand("sp_addChecklistOrdenTrabajo", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@idChecklist", check.IdChecklist);
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", check.CuentaUsuario);
                    Cmd.Parameters.AddWithValue("@idOrdenTrabajo", check.IdOrdenTrabajo);
                    Cmd.Parameters.AddWithValue("@url", check.Url);
                    Cmd.Parameters.AddWithValue("@observacion", check.Observacion);
                    
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "0";  
               
            }
        }

        public List<ChecklistOrdenTrabajo> GetCecklistOrdenTrabajo(int idOrdenTrabajo)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                var Cmd = new SqlCommand("sp_getChecklistOrdenTrabajo", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idOrdenTrabajo", idOrdenTrabajo);
                var reader = Cmd.ExecuteReader();
                var lista = new List<ChecklistOrdenTrabajo>();
                while(reader.Read())
                {
                    var check = new ChecklistOrdenTrabajo();
                    check.IdChecklistOrdenTrabajo = Convert.ToInt32(reader["id_checklist_orden_trabajo"]);
                    check.IdChecklist = Convert.ToInt32(reader["id_checklist"]);
                    check.IdOrdenTrabajo = Convert.ToInt32(reader["id_orden_trabajo"]);
                    check.Url = reader["url"].ToString();
                    check.Fecha = reader["fecha"].ToString();
                    check.CuentaUsuario = reader["cuenta_usuario"].ToString();
                    check.Observacion = reader["observacion"].ToString();
                    check.DescripcionChecklist = reader["descripcion"].ToString();
                    lista.Add(check);
                }


                sqlConn.Close();
                return lista;

            }
        }

        public void DelCecklistOrdenTrabajo(int idChecklistOt)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                var Cmd = new SqlCommand("sp_del_checklist_orden_trabajo", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@id_checklist_orden_trabajo", idChecklistOt);
                Cmd.ExecuteNonQuery();   
                sqlConn.Close();
                

            }
        }
    }
}
