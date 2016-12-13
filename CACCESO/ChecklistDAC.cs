using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
   public  class ChecklistDAC       :BaseDAC
   {
       public List<Checklist> GetCecklistbyTipo(int tipo)
       {
           using (var sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();

               var cmd = new SqlCommand("sp_getChecklistByTipo", sqlConn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@tipo", tipo);
               var reader = cmd.ExecuteReader();
               var lista = new List<Checklist>();
               while (reader.Read())
               {
                    var check = new Checklist();
                    check.IdChecklist = Convert.ToInt32(reader["id_checklist"]);
                   check.Descripcion = reader["descripcion"].ToString().Trim();
                   lista.Add(check);
               }


               sqlConn.Close();
               return lista;

           }
       }
    }
}
