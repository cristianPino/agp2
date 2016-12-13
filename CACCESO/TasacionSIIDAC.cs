using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO 
{
   public class TasacionSIIDAC : CACCESO.BaseDAC
    {
       public string add_tasacionSII(Tipovehiculo tipo_vehiculo, Marcavehiculo marca,string modelo,int ano, string cilindraje, int npuerta, string combustible,string transmicion,
                                        string equipo, Int32 tasacion, Int32 permiso)
       {
           string val="";
           using (SqlConnection sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();
               try
               {
                   SqlCommand Cmd = new SqlCommand("sp_r_Add_CodigoSII", sqlConn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter oParam = Cmd.Parameters.AddWithValue("@tipo", tipo_vehiculo.Nombre);
                   oParam = Cmd.Parameters.AddWithValue("@marca", marca.Nombre);
                   oParam = Cmd.Parameters.AddWithValue("@modelo", modelo);
                   oParam = Cmd.Parameters.AddWithValue("@ano", ano);
				   oParam = Cmd.Parameters.AddWithValue("@cilindrada", cilindraje);
				   oParam = Cmd.Parameters.AddWithValue("@puertas", npuerta);
                   oParam = Cmd.Parameters.AddWithValue("@combustible", combustible);
                   oParam = Cmd.Parameters.AddWithValue("@transmicion", transmicion);
                   oParam = Cmd.Parameters.AddWithValue("@equipo", equipo);
                   oParam = Cmd.Parameters.AddWithValue("@tasacion", tasacion);
                   oParam = Cmd.Parameters.AddWithValue("@permiso", permiso);
                   SqlDataReader reader = Cmd.ExecuteReader();
                   if (reader.Read())
                   {
                       val = reader["CodigoSII"].ToString();
                   }
                                       
                   
                   sqlConn.Close();



               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return val;
       } 
       
       
       
       
       public List<TasacionSII> GetTasacionbydatos(string codigo, string marca, string modelo, Int16 ano)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Tasacionbydatos";

                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@ano", ano);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    List<TasacionSII> lTasacionSII = new List<TasacionSII>();
                    
                    while (reader.Read())
                    {
                        TasacionSII  mTasacionSII = new TasacionSII();


                        mTasacionSII.Id_vehiculo  = Convert.ToDouble(reader["idvehiculo"]);
                        mTasacionSII.Codigosii = reader["codigosii"].ToString();
                        mTasacionSII.Tipo_vehiculo = reader["tipovehiculo"].ToString();
                        mTasacionSII.Marca = reader["marca"].ToString();
                        mTasacionSII.Modelo = reader["modelo"].ToString();
                        mTasacionSII.Puerta = Convert.ToInt32(reader["puertas"]);
                        mTasacionSII.Cilindrada = Convert.ToDouble(reader["cilindrada"]);
                        mTasacionSII.Combustible = reader["combustible"].ToString();
                        mTasacionSII.Transmision = reader["tranasmision"].ToString();
                        mTasacionSII.Equipo = reader["equipo"].ToString();
                        mTasacionSII.Tasacion = Convert.ToDouble(reader["tasacion"]);
                        mTasacionSII.Permiso = Convert.ToDouble(reader["permiso"]);
                        mTasacionSII.Ano = Convert.ToInt32(reader["ano"]); 


                        lTasacionSII.Add(mTasacionSII);

                        mTasacionSII = null;
                    }
                    return lTasacionSII;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
