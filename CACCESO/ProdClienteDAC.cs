using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ProdClienteDAC : CACCESO.BaseDAC
    {

        public List<ProdCliente> getProductobyCliente(Int32 id_cliente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_productobycliente";

                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ProdCliente> lproductocliente = new List<ProdCliente>();

                    while (reader.Read())
                    {

                        ProdCliente mproductocliente= new ProdCliente();

                        mproductocliente.Id_producto_cliente = Convert.ToInt32(reader["id_Producto_cliente"].ToString());
                        mproductocliente.Nombre= reader["nombre"].ToString();


                        lproductocliente.Add(mproductocliente);
                        mproductocliente = null;

                    }
                    return lproductocliente;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string add_ProdCliente(Int32 id_cliente,
                                           string nombre)
        {


            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_add_producto_cliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@nombre", nombre);
 

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

        public ProdCliente getProductoClietne(Int32 id_producto_cliente)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_productocliente";

                    cmd.Parameters.AddWithValue("@id_producto_cliente", id_producto_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();

                    ProdCliente mProductoClietne = new ProdCliente();

                    if (reader.Read())
                    {
                        mProductoClietne.Id_cliente = Convert.ToInt32(reader["id_cliente"]);
                        mProductoClietne.Id_producto_cliente = Convert.ToInt32(reader["id_producto_cliente"]);
                        mProductoClietne.Nombre = reader["nombre"].ToString();
                       
                    }
                    return mProductoClietne;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
