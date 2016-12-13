using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class PersoneroDAC : CACCESO.BaseDAC
    {


        public List<Personero> getPersonerobycliente(Int16 id_cliente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_personerobycliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Personero> lPersonero = new List<Personero>();

                    while (reader.Read())
                    {

                        Personero mPersonero = new Personero();


                        mPersonero.Id_personero = Convert.ToInt16(reader["id_personeria"]);
                        mPersonero.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
                        mPersonero.Modulocliente = new ModuloclienteDAC().getModulo(Convert.ToInt16(reader["id_modulo"]));
                        mPersonero.Rut_representante = reader["rut_representante"].ToString();
                        mPersonero.Nombre_representante = reader["nombre_representante"].ToString();
                        mPersonero.Descripcion =  reader["descripcion"].ToString();
                        mPersonero.Tipo = reader["tipo"].ToString();
                        mPersonero.Profesion = reader["profesion"].ToString();


                        lPersonero.Add(mPersonero);
                        mPersonero = null;

                    }
                    return lPersonero;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_Personero(Int16 id_cliente, Int16 id_modulo, string rut_representante,
                                    string nombre_representante, string descripcion, string tipo,
                                    string profesion)
        {


            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_personero", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                    oParam = Cmd.Parameters.AddWithValue("@rut_representante", rut_representante);
                    oParam = Cmd.Parameters.AddWithValue("@nombre_representante", nombre_representante);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    oParam = Cmd.Parameters.AddWithValue("@tipo", tipo);
                    oParam = Cmd.Parameters.AddWithValue("@profesion", profesion);

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


    
    }
}
