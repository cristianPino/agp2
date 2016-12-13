using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class GastooperacionDAC : CACCESO.BaseDAC
	{

        public string add_Gastooperacion(Int32 id_solicitud, Int16 id_tipo_gasto,
                                                            Int32 monto, string cuenta_usuario,
                                                               Int32 cargo_cliente, Int32 cargo_empresa, string chkgc, int sumarValor)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_add_Gastooperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipo_gasto);
                    oParam = Cmd.Parameters.AddWithValue("@monto", monto);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@cargo_cliente", cargo_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@cargo_empresa", cargo_empresa);
                    oParam = Cmd.Parameters.AddWithValue("@chkgc", chkgc);
                    oParam = Cmd.Parameters.AddWithValue("@suma_valor", sumarValor);

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


		public string add_Gastooperacioncomunes(Int32 id_solicitud,string cuenta_usuario, string operacion,int id_cliente, int id_familia)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{

					SqlCommand Cmd = new SqlCommand("sp_add_Gastooperacioncomunes", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
					oParam = Cmd.Parameters.AddWithValue("@producto", operacion);
					oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					oParam = Cmd.Parameters.AddWithValue("@id_familia", id_familia);
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





		public string del_Gastooperacion(Int32 id_solicitud, Int16 id_tipo_gasto, string chkgc,string cuenta_usuario)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{

					SqlCommand Cmd = new SqlCommand("sp_del_Gastooperacion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipo_gasto);
					oParam = Cmd.Parameters.AddWithValue("@chkgc", chkgc);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);

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

		public List<GastoOperacion> getGastooperacion(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_Gastooperacion";

					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

					SqlDataReader reader = cmd.ExecuteReader();

					List<GastoOperacion> lgasto = new List<GastoOperacion>();

					while (reader.Read())
					{
						GastoOperacion mgasto = new GastoOperacion();

						mgasto.Monto = Convert.ToInt32(reader["monto"].ToString());
						mgasto.Tipogasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
						mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mgasto.Check = Convert.ToBoolean(reader["check"].ToString());
						mgasto.Cargo_cliente = Convert.ToInt32(reader["cargo_cliente"].ToString());
						mgasto.Cargo_empresa = Convert.ToInt32(reader["cargo_empresa"].ToString());
                        mgasto.Opcional = reader["opcional"].ToString();
						mgasto.Tipogasto.Check = Convert.ToBoolean(reader["comun"].ToString());
						if (mgasto.Tipogasto.Check == true)
						{
							GastosComunes gc = new GastosComunesDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
							Tipogasto tg = new Tipogasto();
							tg.Cargo_contable = gc.Cargo_contable;
							tg.Check = true;
							tg.Descripcion = gc.Descripcion;
							tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
							tg.Valor = gc.Valor;
							mgasto.Tipogasto = tg;

						}
						lgasto.Add(mgasto);

						mgasto = null;
					}
					return lgasto;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<GastoOperacion> getGastooperacionMovimiento(Int32 id_solicitud, string tipo_movimiento)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();

					SqlCommand cmd = new SqlCommand(strConn, sqlConn);

					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.CommandText = "sp_r_Gastooperacionmovimiento";

					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);

					SqlDataReader reader = cmd.ExecuteReader();

					List<GastoOperacion> lgasto = new List<GastoOperacion>();

					while (reader.Read())
					{
						GastoOperacion mgasto = new GastoOperacion();

						mgasto.Monto = Convert.ToInt32(reader["monto"].ToString());
						mgasto.Tipogasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
						mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mgasto.Check = Convert.ToBoolean(reader["check"].ToString());
						mgasto.Cargo_cliente = Convert.ToInt32(reader["cargo_cliente"].ToString());
						mgasto.Cargo_empresa = Convert.ToInt32(reader["cargo_empresa"].ToString());
						mgasto.Tipogasto.Check = Convert.ToBoolean(reader["comun"].ToString());
						if (mgasto.Tipogasto.Check == true)
						{
							GastosComunes gc = new GastosComunesDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
							Tipogasto tg = new Tipogasto();
							tg.Cargo_contable = gc.Cargo_contable;
							tg.Check = true;
							tg.Descripcion = gc.Descripcion;
							tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
							tg.Valor = gc.Valor;
							mgasto.Tipogasto = tg;

						}
						lgasto.Add(mgasto);

						mgasto = null;
					}
					return lgasto;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<GastoOperacion> getGastooperacionTR(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastooperacionTR";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					List<GastoOperacion> lgasto = new List<GastoOperacion>();
					while (reader.Read())
					{
						GastoOperacion mgasto = new GastoOperacion();
						mgasto.Monto = Convert.ToInt32(reader["monto"].ToString());
						mgasto.Tipogasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
						mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
						mgasto.Check = Convert.ToBoolean(reader["check"].ToString());
						mgasto.Cargo_cliente = Convert.ToInt32(reader["cargo_cliente"].ToString());
						mgasto.Cargo_empresa = Convert.ToInt32(reader["cargo_empresa"].ToString());
						mgasto.Tipogasto.Check = Convert.ToBoolean(reader["comun"].ToString());
						if (mgasto.Tipogasto.Check == true)
						{
							GastosComunes gc = new GastosComunesDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
							Tipogasto tg = new Tipogasto();
							tg.Cargo_contable = gc.Cargo_contable;
							tg.Check = true;
							tg.Descripcion = gc.Descripcion;
							tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
							tg.Valor = gc.Valor;
							mgasto.Tipogasto = tg;
						}
						lgasto.Add(mgasto);

						mgasto = null;
					}
					return lgasto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public List<GastoOperacion> validacionGasto(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_validacionGasto";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<GastoOperacion> lgasto = new List<GastoOperacion>();

                    while (reader.Read())
                    {
                        GastoOperacion mgasto = new GastoOperacion();

                        mgasto.Monto = Convert.ToInt32(reader["monto"].ToString());
                        mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                        mgasto.Cuenta_facturacion = reader["cuenta_facturacion"].ToString();

                        if (Convert.ToInt32(reader["tipo"].ToString()) == 1)
                        {
                            mgasto.Tipogasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
                        }
                        else
                        {
                            GastosComunes gc = new GastosComunesDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
                            Tipogasto tg = new Tipogasto();
                            tg.Cargo_contable = gc.Cargo_contable;
                            tg.Check = true;
                            tg.Descripcion = gc.Descripcion;
                            tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
                            tg.Valor = gc.Valor;
                            mgasto.Tipogasto = tg;
                        }
                        lgasto.Add(mgasto);

                        mgasto = null;
                    }
                    return lgasto;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GastoOperacion> getGastooperacionMov(Int32 id_solicitud, string tipo_movimiento)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "sp_r_Gastooperacionmov";

                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<GastoOperacion> lgasto = new List<GastoOperacion>();

                    while (reader.Read())
                    {
                        GastoOperacion mgasto = new GastoOperacion();

                        mgasto.Monto = Convert.ToInt32(reader["monto"].ToString());
                        mgasto.Tipogasto = new TipogastoDAC().getTipogasto(Convert.ToInt16(reader["id_tipogasto"].ToString()));
                        mgasto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString());
                        mgasto.Check = Convert.ToBoolean(reader["check"].ToString());
                        mgasto.Cargo_cliente = Convert.ToInt32(reader["cargo_cliente"].ToString());
                        mgasto.Cargo_empresa = Convert.ToInt32(reader["cargo_empresa"].ToString());
                        mgasto.Tipogasto.Check = Convert.ToBoolean(reader["comun"].ToString());
                        if (mgasto.Tipogasto.Check == true)
                        {
                            GastosComunes gc = new GastosComunesDAC().getGastosComunes(Convert.ToInt32(reader["id_tipogasto"].ToString()));
                            Tipogasto tg = new Tipogasto();
                            tg.Cargo_contable = gc.Cargo_contable;
                            tg.Check = true;
                            tg.Descripcion = gc.Descripcion;
                            tg.Id_tipogasto = Convert.ToInt16(gc.Id_tipogasto);
                            tg.Valor = gc.Valor;
                            mgasto.Tipogasto = tg;

                        }
                        lgasto.Add(mgasto);

                        mgasto = null;
                    }
                    return lgasto;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



	}
}