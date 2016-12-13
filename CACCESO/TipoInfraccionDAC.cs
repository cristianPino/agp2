using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class TipoInfraccionDAC : CACCESO.BaseDAC
    {
        public TipoInfraccion getInfraccion(string codigo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Infraccion";

                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    TipoInfraccion mInfracion = new TipoInfraccion();

                    if (reader.Read())
                    {


                        mInfracion.Codigo = reader["codigo"].ToString();
                        mInfracion.Descripcion = reader["descripcion"].ToString();

                    }
                    return mInfracion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public List<TipoInfraccion> getallInfraccion()
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_tipoInfraccion";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TipoInfraccion> lTipoInfraccion = new List<TipoInfraccion>();

                    while (reader.Read())
                    {
                        TipoInfraccion mTipoInfraccion = new TipoInfraccion();


                        mTipoInfraccion.Codigo = reader["codigo"].ToString();
                        mTipoInfraccion.Descripcion = reader["descripcion"].ToString();

                        lTipoInfraccion.Add(mTipoInfraccion);

                        mTipoInfraccion = null;
                    }
                    return lTipoInfraccion;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public string add_TipoInfraccion(string codigo, string descripcion)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_tipoinfraccion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
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



    }
}
