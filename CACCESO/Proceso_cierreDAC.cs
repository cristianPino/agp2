using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class Proceso_cierreDAC : CACCESO.BaseDAC
    {
        public DataTable getProceso(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo,Int32 id_familia)
       {

           try
           {
               using (SqlConnection sqlConn = new SqlConnection(this.strConn))
               {
                   sqlConn.Open();
                   SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                   cmd.CommandTimeout = 10000;
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.CommandText = "sp_get_mod_cie_cli";
                   cmd.Parameters.AddWithValue("@desde", desde);
                   cmd.Parameters.AddWithValue("@hasta", hasta);
                   cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                   cmd.Parameters.AddWithValue("@codigo", codigo);
                   cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                   cmd.Parameters.AddWithValue("@tipo", tipo);
                   cmd.Parameters.AddWithValue("@id_familia", id_familia);
                   SqlDataReader reader = cmd.ExecuteReader();
                   DataTable mcierre = new DataTable();

                   mcierre.Load(reader);
                  
                  
               
                   return mcierre;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


        public DataTable getProcesoALL(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo, Int32 id_familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_all";
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable mcierre = new DataTable();

                    mcierre.Load(reader);



                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable getProcesoCliente(string desde, string hasta, string id_cliente, string codigo, string id_ciudad,int tipo,string familia)
       {

           try
           {
               using (SqlConnection sqlConn = new SqlConnection(this.strConn))
               {
                   sqlConn.Open();
                   SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                   cmd.CommandTimeout = 10000;
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.CommandText = "sp_get_mod_cie_cli_oper";
                   cmd.Parameters.AddWithValue("@desde", desde);
                   cmd.Parameters.AddWithValue("@hasta", hasta);
                   cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                   cmd.Parameters.AddWithValue("@codigo", codigo);
                   cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                   cmd.Parameters.AddWithValue("@tipo", tipo);
                   cmd.Parameters.AddWithValue("@familia", familia);
                   SqlDataReader reader = cmd.ExecuteReader();
                  
                   DataTable mcierre = new DataTable();
                  
                       mcierre.Load(reader);
                   return mcierre;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public DataTable getProcesoClientePro(string desde, string hasta, string id_cliente, string codigo, string id_ciudad,int tipo)
       {

           try
           {
               using (SqlConnection sqlConn = new SqlConnection(this.strConn))
               {
                   sqlConn.Open();
                   SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                   cmd.CommandTimeout = 10000;
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.CommandText = "sp_get_mod_cie_cli_oper_Pro";
                   cmd.Parameters.AddWithValue("@desde", desde);
                   cmd.Parameters.AddWithValue("@hasta", hasta);
                   cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                   cmd.Parameters.AddWithValue("@codigo", codigo);
                   cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                   cmd.Parameters.AddWithValue("@tipo", tipo);
                   SqlDataReader reader = cmd.ExecuteReader();

                   DataTable mcierre = new DataTable();      
                       mcierre.Load(reader);
                   return mcierre;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public DataTable getProcesoClienteProSuc(string desde, string hasta, string id_cliente, string codigo, string id_ciudad,int tipo)
       {

           try
           {
               using (SqlConnection sqlConn = new SqlConnection(this.strConn))
               {
                   sqlConn.Open();
                   SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                   cmd.CommandTimeout = 10000;
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.CommandText = "sp_get_mod_cie_cli_oper_Pro_suc";
                   cmd.Parameters.AddWithValue("@desde", desde);
                   cmd.Parameters.AddWithValue("@hasta", hasta);
                   cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                   cmd.Parameters.AddWithValue("@codigo", codigo);
                   cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                   cmd.Parameters.AddWithValue("@tipo", tipo);
                   SqlDataReader reader = cmd.ExecuteReader();

                   DataTable mcierre = new DataTable();
                   mcierre.Load(reader);
                   return mcierre;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



        public DataTable getProcesoSaldoFinal(string desde, string hasta, string id_cliente, string codigo, string id_ciudad,string tipo, string familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_proceso_saldo_final";
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@id_familia", familia);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable mcierre = new DataTable();
                    mcierre.Load(reader);
                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getProcesoSaldoinicial(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, string tipo, string familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_proceso_saldo_inicial";
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@id_familia", familia);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable mcierre = new DataTable();
                    mcierre.Load(reader);
                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getProcesoSaldoBaCant(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, string tipo, string familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_proceso_saldo_Base_Cantidad";
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@id_familia", familia);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable mcierre = new DataTable();
                    mcierre.Load(reader);
                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable getProcesofamiliaGestion(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_mod_cie_gest_fam";
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable mcierre = new DataTable();

                    mcierre.Load(reader);
                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public string NewProcesoTabla(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, string tipo, Int32 id_familia, string cuenta_usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_get_proceso_cobranza_tablas", sqlConn);
                    Cmd.CommandTimeout = 5000;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@desde", desde);
                    Cmd.Parameters.AddWithValue("@hasta", hasta);
                    Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    Cmd.Parameters.AddWithValue("@codigo", codigo);
                    Cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    Cmd.Parameters.AddWithValue("@tipo", tipo);
                    Cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
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




        public DataTable procesos_sucursal(string nombre_tabla, string id_cliente, string codigo, string id_ciudad, string id_familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_procesos_sucursal";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@nombre_tabla", nombre_tabla);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable mcierre = new DataTable();

                    mcierre.Load(reader);



                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable procesos_familia(string nombre_tabla, string id_cliente, string codigo, string id_ciudad, string id_familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_procesos_familia";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@nombre_tabla", nombre_tabla);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable mcierre = new DataTable();

                    mcierre.Load(reader);



                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable procesos_cliente(string nombre_tabla, string id_cliente, string codigo, string id_ciudad, string id_familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_procesos_cliente";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@nombre_tabla", nombre_tabla);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable mcierre = new DataTable();

                    mcierre.Load(reader);



                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable procesos_producto(string nombre_tabla, string id_cliente, string codigo, string id_ciudad, string id_familia)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_procesos_producto";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@nombre_tabla", nombre_tabla);

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable mcierre = new DataTable();

                    mcierre.Load(reader);



                    return mcierre;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
