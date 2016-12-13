using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class InformeDac : CACCESO.BaseDAC
    {
        public string add_informe(string nombre, string  descripcion)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Informe", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@nombre", nombre);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
                   

                    Cmd.ExecuteNonQuery();

                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return "";

        }



        public List<Informe> getInforme()
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Informe";

                    

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Informe> lInforme = new List<Informe>();

                    while (reader.Read())
                    {

                        Informe mInforme = new Informe();

                        mInforme.Id_informe =Convert.ToInt32(reader["id_informe"]);
                        mInforme.Nombre = reader["nombre_rpt"].ToString();
                        mInforme.Descripcion = reader["descripcion"].ToString();

                        lInforme.Add(mInforme);
                        mInforme = null;

                    }
                    return lInforme;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Informe> getInformeByCliente(string codigoperfil)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_InformeByCliente";

                    cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Informe> lInforme = new List<Informe>();

                    while (reader.Read())
                    {

                        Informe mInforme = new Informe();

                        mInforme.Id_informe = Convert.ToInt32(reader["id_informe"]);
                        mInforme.Nombre = reader["nombre_rpt"].ToString();
                        mInforme.Descripcion = reader["descripcion"].ToString();
                        mInforme.Check = Convert.ToBoolean(reader["check"]);

                        lInforme.Add(mInforme);
                        mInforme = null;

                    }
                    return lInforme;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Informe> getInformebyUsuario(string codigoperfil)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_InformeByUsuario";

                    cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Informe> lInforme = new List<Informe>();

                    while (reader.Read())
                    {

                        Informe mInforme = new Informe();

                        mInforme.Id_informe = Convert.ToInt32(reader["id_informe"]);
                        mInforme.Nombre = reader["nombre_rpt"].ToString();
                        mInforme.Descripcion = reader["descripcion"].ToString();
                      
                        lInforme.Add(mInforme);
                        mInforme = null;

                    }
                    return lInforme;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_informe_check(string codigoperfil, Int32 id_informe)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_Informe_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_informe", id_informe);
                    oParam = Cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);


                    Cmd.ExecuteNonQuery();

                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return "";

        }


        public string del_informe_check(string codigoperfil, Int32 id_informe)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_del_Informe_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_informe", id_informe);
                    oParam = Cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);


                    Cmd.ExecuteNonQuery();

                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return "";

        }



        public Informe GetInformebyid(Int16 id_report)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_informebyId";
                    cmd.Parameters.AddWithValue("@id_informe", id_report);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Informe minforme = new Informe();
                    if (reader.Read())
                    {
                        minforme.Id_informe = Convert.ToInt16(reader["id_informe"]);
                        minforme.Descripcion = reader["descripcion"].ToString();
                        minforme.Sp_informe = reader["sp_informe"].ToString();
                    }
                    return minforme;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public Informe GetInformebyid_excel(Int16 id_report)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_informebyId_excel";
                    cmd.Parameters.AddWithValue("@id_informe", id_report);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Informe minforme = new Informe();
                    if (reader.Read())
                    {
                        minforme.Id_informe = Convert.ToInt16(reader["id_informe_excel"]);
                        minforme.Descripcion = reader["descripcion"].ToString();
                        minforme.Sp_informe = reader["sp_informe"].ToString();
                    }
                    return minforme;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<Informe> getInformebyUsuario_excel(string codigoperfil)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_InformeByUsuario_excel";

                    cmd.Parameters.AddWithValue("@codigoperfil", codigoperfil);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Informe> lInforme = new List<Informe>();

                    while (reader.Read())
                    {

                        Informe mInforme = new Informe();

                        mInforme.Id_informe_excel = Convert.ToInt32(reader["id_informe_excel"]);
                        mInforme.Sp_informe = reader["sp_informe"].ToString();
                        mInforme.Descripcion = reader["descripcion"].ToString();

                        lInforme.Add(mInforme);
                        mInforme = null;

                    }
                    return lInforme;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
