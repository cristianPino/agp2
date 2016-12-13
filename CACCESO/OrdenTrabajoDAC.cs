using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CENTIDAD;

namespace CACCESO
{
    public class OrdenTrabajoDAC : BaseDAC
    {

        public DataTable GetPermisosEspeciales(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_get_permisos_especiales_ot" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public void AddGrupoUsuario(string cuentaUsuario, int idGrupo, bool jefe, bool observador, bool activo)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_grupo_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@id_grupo", idGrupo);
                cmd.Parameters.AddWithValue("@jefe", jefe);
                cmd.Parameters.AddWithValue("@observador", observador);
                cmd.Parameters.AddWithValue("@activo", activo);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public void AddBusquedaUsuario(string cuentaUsuario, int idBusqueda, bool permisoEliminar, bool permisoAsignar, bool permisoGarantia, bool permisoPrimera)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_add_busqueda_orden_trabajo_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@id_tipo_busqueda", idBusqueda);
                cmd.Parameters.AddWithValue("@permiso_eliminar", permisoEliminar);
                cmd.Parameters.AddWithValue("@permiso_asignar", permisoAsignar);
                cmd.Parameters.AddWithValue("@permiso_garantia", permisoGarantia);
                cmd.Parameters.AddWithValue("@permiso_primera", permisoPrimera);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public void DelActividadUsuario(string cuentaUsuario, int idActividad)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_del_actividad_orden_trabajo_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@id_actividad", idActividad);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public void GuardarActividadUsuario(string cuentaUsuario, int idActividad, bool soloLectura)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_add_actividad_orden_trabajo" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@id_actividad", idActividad);
                cmd.Parameters.AddWithValue("@solo_lectura", soloLectura);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public void GuardarPorUsuario(string cuentaUsuario, string usuarioCopia)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_guardar_desde_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@usuarioCopia", usuarioCopia);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public void GuardarPorPerfil(string cuentaUsuario, string perfil)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_guardar_desde_perfil" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                cmd.Parameters.AddWithValue("@perfil", perfil);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public DataTable GetGruposUsuario(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_get_grupos_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetActividadesUsuario(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "m_get_actividades_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetUsuariosBySucursal(int idSucursal)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "get_usuario_by_sucursal_ot" };
                cmd.Parameters.AddWithValue("@id_sucursal   ", idSucursal);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable ValidaGarantias(int rut, string patente)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "valida_prohibicion_garantia" };
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.Parameters.AddWithValue("@patente", patente);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetUsuariosByGrupos(string grupo)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "get_usuarios_by_grupo" };
                cmd.Parameters.AddWithValue("@id_grupo", grupo);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetUsuariosGrupos(bool jefe, bool todos, string grupo, string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "get_usuarios_de_grupo" };
                cmd.Parameters.AddWithValue("@jefe", jefe);
                cmd.Parameters.AddWithValue("@parametro_grupo", grupo);
                cmd.Parameters.AddWithValue("@todos", todos);
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public DataTable GetGrupoByUsuario(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "get_grupo_ot_by_usuario" };
                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public RespuestaAgp AddOrdenTrabajoWebservice(DatoFactura ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_addOrdenTrabajoWebservice" };
                var oParam =
                cmd.Parameters.AddWithValue("@activo", 1);
                cmd.Parameters.AddWithValue("@id_usuario", ot.CuentaUsuario);
                cmd.Parameters.AddWithValue("@num_orden_trabajo", ot.NotaPedido);
                cmd.Parameters.AddWithValue("@num_factura", ot.NumeroFactura);
                cmd.Parameters.AddWithValue("@rut_adquiriente", ot.Rut);
                cmd.Parameters.AddWithValue("@dv_adquiriente", ot.Dv);
                cmd.Parameters.AddWithValue("@nombre_adquiriente", ot.Nombre);
                cmd.Parameters.AddWithValue("@apepat_adquiriente", "");
                cmd.Parameters.AddWithValue("@apemat_adquiriente", "");
                cmd.Parameters.AddWithValue("@factura_neto", ot.ValorNeto);
                cmd.Parameters.AddWithValue("@fecha_factura", ot.FechaFactura);
                cmd.Parameters.AddWithValue("@vehiculo_marca", ot.MarcaVehiculo);
                cmd.Parameters.AddWithValue("@vehiculo_modelo", ot.Modelo);
                cmd.Parameters.AddWithValue("@vehiculo_anio", ot.AnioComercial);
                cmd.Parameters.AddWithValue("@vehiculo_cilindrada", "0");
                cmd.Parameters.AddWithValue("@vehiculo_puertas", ot.Puertas);
                cmd.Parameters.AddWithValue("@vehiculo_asientos", ot.Asiento);
                cmd.Parameters.AddWithValue("@vehiculo_peso_bruto", ot.PesoBruto);
                cmd.Parameters.AddWithValue("@vehiculo_carga", "0");
                cmd.Parameters.AddWithValue("@vehiculo_combustible", ot.Combustible);
                cmd.Parameters.AddWithValue("@vehiculo_color", ot.Color);
                cmd.Parameters.AddWithValue("@vehiculo_motor", ot.Motor);
                cmd.Parameters.AddWithValue("@vehiculo_vin", ot.Chassis);
                cmd.Parameters.AddWithValue("@vehiculo_chasis", ot.Chassis);
                cmd.Parameters.AddWithValue("@url_factura", "");
                cmd.Parameters.AddWithValue("@vin_corto", ot.Chassis.Substring(ot.Chassis.Length - 6, 6));
                cmd.Parameters.AddWithValue("@Nacionalidad", "CL");
                cmd.Parameters.AddWithValue("@sexo", "0");
                cmd.Parameters.AddWithValue("@cit", ot.Cit);
                cmd.Parameters.AddWithValue("@tiene_compra_para", ot.TieneCompraPara);
                cmd.Parameters.AddWithValue("@compra_para_nombre", ot.CompraParaNombre);
                cmd.Parameters.AddWithValue("@compra_para_rut", ot.CompraParaRut);
                cmd.Parameters.AddWithValue("@compra_para_dv", ot.CompraParaDv);
                cmd.Parameters.AddWithValue("@descripcion_compra_para", ot.CompraParaDescripcion);
                cmd.Parameters.AddWithValue("@vehiculo_patente", ot.Patente);
                cmd.Parameters.AddWithValue("@id_cliente", ot.IdCliente);
                cmd.Parameters.AddWithValue("@forma_pago", ot.FormaPago == null ? "0" : ot.FormaPago);
                cmd.Parameters.AddWithValue("@grupo", ot.Grupo);
                cmd.Parameters.AddWithValue("@id_sucursal", ot.idSucursal);
                var reader = cmd.ExecuteReader();
                var respuesta = new RespuestaAgp();
                if (reader.Read())
                {
                    respuesta.IdRespuesta = Convert.ToInt32(reader["id"].ToString().Trim());
                    respuesta.MensajeError = reader["mensajeError"].ToString().Trim();
                }
                sqlConn.Close();
                return respuesta;
            }
        }

        public RespuestaAgp AddOrdenTrabajoPorche(DatoFactura ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_addOrdenTrabajo_porche" };
                var oParam =
                cmd.Parameters.AddWithValue("@activo", 1);
                cmd.Parameters.AddWithValue("@id_usuario", ot.CuentaUsuario);
                cmd.Parameters.AddWithValue("@num_orden_trabajo", ot.NotaPedido);
                cmd.Parameters.AddWithValue("@num_factura", ot.NumeroFactura);
                cmd.Parameters.AddWithValue("@rut_adquiriente", ot.Rut);
                cmd.Parameters.AddWithValue("@dv_adquiriente", ot.Dv);
                cmd.Parameters.AddWithValue("@nombre_adquiriente", ot.Nombre);
                cmd.Parameters.AddWithValue("@apepat_adquiriente", "");
                cmd.Parameters.AddWithValue("@apemat_adquiriente", "");
                cmd.Parameters.AddWithValue("@factura_neto", ot.ValorNeto);
                cmd.Parameters.AddWithValue("@fecha_factura", ot.FechaFactura);
                cmd.Parameters.AddWithValue("@vehiculo_marca", ot.MarcaVehiculo);
                cmd.Parameters.AddWithValue("@vehiculo_modelo", ot.Modelo);
                cmd.Parameters.AddWithValue("@vehiculo_anio", ot.AnioComercial);
                cmd.Parameters.AddWithValue("@vehiculo_cilindrada",ot.Cilindrada);
                cmd.Parameters.AddWithValue("@vehiculo_puertas", ot.Puertas);
                cmd.Parameters.AddWithValue("@vehiculo_asientos", ot.Asiento);
                cmd.Parameters.AddWithValue("@vehiculo_peso_bruto", ot.PesoBruto);
                cmd.Parameters.AddWithValue("@vehiculo_carga", "0");
                cmd.Parameters.AddWithValue("@vehiculo_combustible", ot.Combustible);
                cmd.Parameters.AddWithValue("@vehiculo_color", ot.Color);
                cmd.Parameters.AddWithValue("@vehiculo_motor", ot.Motor);
                cmd.Parameters.AddWithValue("@vehiculo_vin", ot.Chassis);
                cmd.Parameters.AddWithValue("@vehiculo_chasis", ot.Chassis);
                cmd.Parameters.AddWithValue("@url_factura", "");
                cmd.Parameters.AddWithValue("@vin_corto", ot.Chassis.Substring(ot.Chassis.Length - 6, 6));
                cmd.Parameters.AddWithValue("@Nacionalidad", "CL");
                cmd.Parameters.AddWithValue("@sexo", "0");
                cmd.Parameters.AddWithValue("@cit", ot.Cit);
                cmd.Parameters.AddWithValue("@tiene_compra_para", ot.TieneCompraPara);
                cmd.Parameters.AddWithValue("@compra_para_nombre", ot.CompraParaNombre);
                cmd.Parameters.AddWithValue("@compra_para_rut", ot.CompraParaRut);
                cmd.Parameters.AddWithValue("@compra_para_dv", ot.CompraParaDv);
                cmd.Parameters.AddWithValue("@descripcion_compra_para", ot.CompraParaDescripcion);
                cmd.Parameters.AddWithValue("@vehiculo_patente", ot.Patente);
                cmd.Parameters.AddWithValue("@id_cliente", ot.IdCliente);
                cmd.Parameters.AddWithValue("@forma_pago", ot.FormaPago == null ? "0" : ot.FormaPago);
                cmd.Parameters.AddWithValue("@grupo", ot.Grupo);
                cmd.Parameters.AddWithValue("@id_sucursal", ot.idSucursal);
                var reader = cmd.ExecuteReader();
                var respuesta = new RespuestaAgp();
                if (reader.Read())
                {
                    respuesta.IdRespuesta = Convert.ToInt32(reader["id"].ToString().Trim());
                    respuesta.MensajeError = reader["mensajeError"].ToString().Trim();
                }
                sqlConn.Close();
                return respuesta;
            }
        }

        public RespuestaAgp AddOrdenTrabajoBech(DatoFactura ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_addOrdenTrabajo_bech" };
                var oParam =
                cmd.Parameters.AddWithValue("@activo", 1);
                cmd.Parameters.AddWithValue("@id_usuario", ot.CuentaUsuario);
                cmd.Parameters.AddWithValue("@num_orden_trabajo", ot.NotaPedido);
                cmd.Parameters.AddWithValue("@num_factura", ot.NumeroFactura);
                cmd.Parameters.AddWithValue("@rut_adquiriente", ot.Rut);
                cmd.Parameters.AddWithValue("@dv_adquiriente", ot.Dv);
                cmd.Parameters.AddWithValue("@nombre_adquiriente", ot.Nombre);
                cmd.Parameters.AddWithValue("@apepat_adquiriente", "");
                cmd.Parameters.AddWithValue("@apemat_adquiriente", "");
                cmd.Parameters.AddWithValue("@factura_neto", ot.ValorNeto);
                cmd.Parameters.AddWithValue("@fecha_factura", ot.FechaFactura);
                cmd.Parameters.AddWithValue("@vehiculo_marca", ot.MarcaVehiculo);
                cmd.Parameters.AddWithValue("@vehiculo_modelo", ot.Modelo);
                cmd.Parameters.AddWithValue("@vehiculo_anio", ot.AnioComercial);
                cmd.Parameters.AddWithValue("@vehiculo_cilindrada", (ot.Cilindrada == null) ? (object)0 : ot.Cilindrada);
                cmd.Parameters.AddWithValue("@vehiculo_puertas", ot.Puertas);
                cmd.Parameters.AddWithValue("@vehiculo_asientos", ot.Asiento);
                cmd.Parameters.AddWithValue("@vehiculo_peso_bruto", ot.PesoBruto);
                cmd.Parameters.AddWithValue("@vehiculo_carga", "0");
                cmd.Parameters.AddWithValue("@vehiculo_combustible", ot.Combustible);
                cmd.Parameters.AddWithValue("@vehiculo_color", ot.Color);
                cmd.Parameters.AddWithValue("@vehiculo_motor", ot.Motor);
                cmd.Parameters.AddWithValue("@vehiculo_vin", ot.Chassis);
                cmd.Parameters.AddWithValue("@vehiculo_chasis", ot.Chassis);
                cmd.Parameters.AddWithValue("@url_factura", "");
                cmd.Parameters.AddWithValue("@vin_corto", ot.Chassis.Substring(ot.Chassis.Length - 6, 6));
                cmd.Parameters.AddWithValue("@Nacionalidad", "CL");
                cmd.Parameters.AddWithValue("@sexo", "0");
                cmd.Parameters.AddWithValue("@cit", ot.Cit);
                cmd.Parameters.AddWithValue("@tiene_compra_para", ot.TieneCompraPara);
                cmd.Parameters.AddWithValue("@compra_para_nombre", ot.CompraParaNombre);
                cmd.Parameters.AddWithValue("@compra_para_rut", ot.CompraParaRut);
                cmd.Parameters.AddWithValue("@compra_para_dv", ot.CompraParaDv);
                cmd.Parameters.AddWithValue("@descripcion_compra_para", ot.CompraParaDescripcion);
                cmd.Parameters.AddWithValue("@vehiculo_patente", ot.Patente);
                cmd.Parameters.AddWithValue("@id_cliente", ot.IdCliente);
                cmd.Parameters.AddWithValue("@forma_pago", ot.FormaPago == null ? "0" : ot.FormaPago);
                cmd.Parameters.AddWithValue("@grupo", ot.Grupo);
                cmd.Parameters.AddWithValue("@id_sucursal", ot.idSucursal);
                var reader = cmd.ExecuteReader();
                var respuesta = new RespuestaAgp();
                if (reader.Read())
                {
                    respuesta.IdRespuesta = Convert.ToInt32(reader["id"].ToString().Trim());
                    respuesta.MensajeError = reader["mensajeError"].ToString().Trim();
                }
                sqlConn.Close();
                return respuesta;
            }
        }
        public string GetCodigoSga(string descripcion, string tipo)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_codigo_SGA_by_tipo_descripcion" };
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                var reader = cmd.ExecuteReader();
                var codigo = "";
                if (reader.Read())
                {
                    codigo = reader["codigo_sga"].ToString();

                }
                sqlConn.Close();
                return codigo;

            }
        }

        public int AddOrdenTrabajoGarantia(OrdenTrabajo ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_add_ordenTrabajo_garantia" };
                SqlParameter oParam =
                    cmd.Parameters.AddWithValue("@id_orden_trabajo", 0);
                cmd.Parameters.AddWithValue("@patente", ot.Patente);
                cmd.Parameters.AddWithValue("@correo", ot.Observacion);
                cmd.Parameters.AddWithValue("@cuenta_usuario", ot.CuentaUsuario);
                cmd.Parameters.AddWithValue("@rut", ot.RutAdquiriente);
                cmd.Parameters.AddWithValue("@id_cliente", ot.IdCliente);
                cmd.Parameters.AddWithValue("@id_sucursal", ot.IdSucursal);
                cmd.Parameters.AddWithValue("@numero_orden", ot.NumeroOrden);//numero operacion


                oParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var nTheNewId = Convert.ToInt32(cmd.Parameters["@id_orden_trabajo"].Value);
                sqlConn.Close();
                return nTheNewId;

            }
        }


        public int AddOrdenTrabajo(OrdenTrabajo ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn)
                { CommandType = CommandType.StoredProcedure, CommandText = "sp_add_orden_trabajo" };
                SqlParameter oParam =
                cmd.Parameters.AddWithValue("@id_orden_trabajo", ot.IdOrden);
                cmd.Parameters.AddWithValue("@id_orden_trabajo_existente", ot.IdOrden);
                cmd.Parameters.AddWithValue("@activo", ot.Activo);
                cmd.Parameters.AddWithValue("@id_usuario", ot.CuentaUsuario);
                cmd.Parameters.AddWithValue("@responsable_pago", ot.QuienPaga);
                cmd.Parameters.AddWithValue("@terminacion_especial", ot.TmEspecial);
                cmd.Parameters.AddWithValue("@num_orden_trabajo", ot.NumeroOrden);
                cmd.Parameters.AddWithValue("@id_cliente", ot.IdCliente);
                cmd.Parameters.AddWithValue("@compraPara", ot.CompraPara);
                cmd.Parameters.AddWithValue("@idSucursal", ot.IdSucursal);
                cmd.Parameters.AddWithValue("@codigoFormaPago", ot.CodigoFormaPago);
                cmd.Parameters.AddWithValue("@codigoFinanciera", ot.CodigoFinanciera);
                cmd.Parameters.AddWithValue("@impuestoVerde", ot.ImpuestoVerde);
                cmd.Parameters.AddWithValue("@observacion", ot.Observacion);
                cmd.Parameters.AddWithValue("@vinCorto", ot.VinCorto);
                cmd.Parameters.AddWithValue("@cit", ot.VehiculoCit);
                cmd.Parameters.AddWithValue("@abono", ot.AbonoCliente);


                oParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var nTheNewId = Convert.ToInt32(cmd.Parameters["@id_orden_trabajo"].Value);
                sqlConn.Close();
                return nTheNewId;

            }
        }

        public RespuestaAgp AddOrdenTrabajoWebservice(OrdenTrabajo ot)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_addOrdenTrabajoWebservice" };
                var oParam =
                cmd.Parameters.AddWithValue("@activo", ot.Activo);
                cmd.Parameters.AddWithValue("@id_usuario", ot.CuentaUsuario);
                cmd.Parameters.AddWithValue("@num_orden_trabajo", ot.NumeroOrden);
                cmd.Parameters.AddWithValue("@num_factura", ot.NumeroFactura);
                cmd.Parameters.AddWithValue("@rut_adquiriente", ot.RutAdquiriente);
                cmd.Parameters.AddWithValue("@dv_adquiriente", ot.DvAdquiriente);
                cmd.Parameters.AddWithValue("@nombre_adquiriente", ot.NombreAdquiriente);
                cmd.Parameters.AddWithValue("@apepat_adquiriente", ot.ApepatAdquiriente);
                cmd.Parameters.AddWithValue("@apemat_adquiriente", ot.ApematAdquiriente);
                cmd.Parameters.AddWithValue("@factura_neto", ot.FacturaNeto);
                cmd.Parameters.AddWithValue("@fecha_factura", ot.FechaFactura);
                cmd.Parameters.AddWithValue("@vehiculo_marca", ot.VehiculoMarca);
                cmd.Parameters.AddWithValue("@vehiculo_modelo", ot.VehiculoModelo);
                cmd.Parameters.AddWithValue("@vehiculo_anio", ot.VehiculoAnio);
                cmd.Parameters.AddWithValue("@vehiculo_cilindrada", ot.VehiculoCilindrada);
                cmd.Parameters.AddWithValue("@vehiculo_puertas", ot.VehiculoPuertas);
                cmd.Parameters.AddWithValue("@vehiculo_asientos", ot.VehiculoAsientos);
                cmd.Parameters.AddWithValue("@vehiculo_peso_bruto", ot.VehiculoPesoBruto);
                cmd.Parameters.AddWithValue("@vehiculo_carga", ot.VehiculoCarga);
                cmd.Parameters.AddWithValue("@vehiculo_combustible", ot.VehiculoCombustible);
                cmd.Parameters.AddWithValue("@vehiculo_color", ot.VehiculoColor);
                cmd.Parameters.AddWithValue("@vehiculo_motor", ot.VehiculoMotor);
                cmd.Parameters.AddWithValue("@vehiculo_vin", ot.VehiculoVin);
                cmd.Parameters.AddWithValue("@vehiculo_chasis", ot.VehiculoChasis);
                cmd.Parameters.AddWithValue("@url_factura", ot.UrlFactura);
                cmd.Parameters.AddWithValue("@vin_corto", ot.VinCorto.Trim());
                cmd.Parameters.AddWithValue("@Nacionalidad", ot.Nacionalidad);
                cmd.Parameters.AddWithValue("@sexo", ot.Sexo);


                var reader = cmd.ExecuteReader();
                var respuesta = new RespuestaAgp();
                if (reader.Read())
                {
                    respuesta.IdRespuesta = Convert.ToInt32(reader["id"].ToString().Trim());
                    respuesta.MensajeError = reader["mensajeError"].ToString().Trim();
                }
                sqlConn.Close();
                return respuesta;
            }
        }

        public List<OrdenTrabajoTipoOperacion> GetordenTrabajoProducto(int idOt)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_ordenTrabajoProducto" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);
                var reader = cmd.ExecuteReader();
                var lista = new List<OrdenTrabajoTipoOperacion>();

                while (reader.Read())
                {
                    var ordenTipo = new OrdenTrabajoTipoOperacion();
                    ordenTipo.TipoOperacion = new TipooperacionDAC().getTipooperacion(reader["id_producto"].ToString());
                    ordenTipo.Ok = Convert.ToBoolean(reader["ok"]);
                    ordenTipo.IdSolicitud = Convert.ToInt32(reader["id_solicitud"]);
                    lista.Add(ordenTipo);
                }
                sqlConn.Close();
                return lista;
            }
        }


        public void UpdateProductoOrdenTrabajo(int idOt, string producto, int idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_update_producto_orden_trabajo" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);
                cmd.Parameters.AddWithValue("@codigo_producto", producto);
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
        }

        public ModeloVehiculo ValidaCit(string cit)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_orden_trabajo_valida_cit" };
                cmd.Parameters.AddWithValue("@cit", cit);
                var reader = cmd.ExecuteReader();
                var mode = new ModeloVehiculo();
                if (reader.Read())
                {
                    mode.Nombre = reader["modelo"].ToString();
                    mode.Marcavehiculo = new Marcavehiculo { Nombre = reader["marca"].ToString() };
                }

                sqlConn.Close();
                return mode;
            }
        }

        /// <summary>
        /// TRAE LAS FILAS DE LA TABLA TBL_ORDEN_TRABAJO_REPARO
        /// </summary>
        /// <param name="idOrdenTrabajo"> id tbl_orden_de_Trabajo</param>
        /// <param name="filas">"todo";"una" para traer la fila actual o todas </param>
        /// <returns>data table con resultados del select</returns>
        public DataTable GetReparos(int idOrdenTrabajo, string filas)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_reparo" };
                cmd.Parameters.AddWithValue("@id_orden_Trabajo", idOrdenTrabajo);
                cmd.Parameters.AddWithValue("@filas", filas);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        /// <summary>
        /// TRAE LA FILA DE LA TABLA TBL_ORDEN_TRABAJO_REPARO por id  del reparo
        /// </summary>
        /// <param name="idReparo"> id tbl_reparo</param>   
        /// <returns>data table con resultados del select</returns>
        public DataTable GetReparosById(int idReparo)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_orden_trabajo_reparo_by_id" };
                cmd.Parameters.AddWithValue("@id_reparo", idReparo);

                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                sqlConn.Close();
                return dt;
            }
        }

        public void AddReparo(int idReparo, int idOrdenTrabajo, int idTipoReparo, string parametroResponsableReparo, string usuarioIngresoReparo,
           string usuarioResponsableReparo, string observacion, byte estado)
        {
            //inserta o actualiza un reparo
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_add_orden_trabajo_reparo" };
                cmd.Parameters.AddWithValue("@id_reaparo", idReparo);
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOrdenTrabajo);
                cmd.Parameters.AddWithValue("@id_tipo_reparo", idTipoReparo);
                cmd.Parameters.AddWithValue("@id_parametro_tipo_responsable_solucion", parametroResponsableReparo);
                cmd.Parameters.AddWithValue("@id_usuario_ingreso_reparo", usuarioIngresoReparo);
                cmd.Parameters.AddWithValue("@id_usuario_responsable_subsano", usuarioResponsableReparo);
                cmd.Parameters.AddWithValue("@observacion_preliminar", observacion);
                cmd.Parameters.AddWithValue("@estado_subsano", estado);

                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        public DataTable PermisosOrdenTrabajo(string cuentaUsuario)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "get_orden_trabajo_permisos" };

                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                return dt;
            }

        }


        public bool PuedeAsignarOrdenTrabajo(string cuentaUsuario)
        {
            //BORRAR EN DESUSO
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_puede_asignar_orden_trabajo" };

                cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);


                var reader = cmd.ExecuteReader();
                var puede = false;
                if (reader.Read())
                {
                    puede = Convert.ToBoolean(reader["puede_asignar"]);
                }
                return puede;
            }

        }

        public void AddServicio(int idOt, string servicio)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_add_servicio_Orden_trabajo" };

                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);
                cmd.Parameters.AddWithValue("@id_servicio", servicio);

                cmd.ExecuteNonQuery();
            }

        }

        public void DelServicio(int idOt)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_del_orden_trabajo_servicio" };

                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);

                cmd.ExecuteNonQuery();
            }

        }



        public void AddDocumento(int idOt, int doc)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_add_documento_Orden_trabajo" };

                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);
                cmd.Parameters.AddWithValue("@id_documento", doc);

                cmd.ExecuteNonQuery();
            }

        }


        public OrdenTrabajo GetOrdenTrabajo(int idOt)
        {

            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_getOrdenTrabajo" };
                cmd.Parameters.AddWithValue("@id_orden_trabajo", idOt);
                var reader = cmd.ExecuteReader();
                var ot = new OrdenTrabajo();
                if (reader.Read())
                {
                    ot.IdOrden = Convert.ToInt32(reader["id_orden_trabajo"]);
                    ot.Activo = Convert.ToBoolean(reader["activo"]);
                    ot.CuentaUsuario = reader["id_usuario"].ToString();
                    ot.QuienPaga = reader["responsable_pago"].ToString();
                    ot.TmEspecial = reader["terminacion_especial"].ToString();
                    ot.FechaIngreso = reader["fecha_ingreso"].ToString();
                    ot.NumeroOrden = reader["num_orden_trabajo"].ToString();
                    ot.NumeroFactura = reader["num_factura"].ToString();
                    ot.IdCliente = Convert.ToInt32(reader["id_cliente"]);
                    ot.RutAdquiriente = reader["rut_adquiriente"].ToString();
                    ot.UrlFactura = reader["url_factura"].ToString();
                    ot.IdSucursal = Convert.ToInt32(reader["id_sucursal"]);
                    ot.CodigoFormaPago = reader["codigoFormaPago"].ToString();
                    ot.CodigoFinanciera = reader["codigoFinanciera"].ToString();
                    ot.CompraPara = reader["compraPara"].ToString();
                    ot.ImpuestoVerde = reader["impuestoVerde"].ToString();
                    ot.Observacion = reader["observacion"].ToString();
                    ot.FacturaNeto = reader["factura_neto"].ToString();
                    ot.FechaFactura = reader["factura_fecha"].ToString();
                    ot.VehiculoMarca = reader["vehiculo_marca"].ToString();
                    ot.VehiculoModelo = reader["vehiculo_modelo"].ToString();
                    ot.VehiculoAnio = reader["vehiculo_anio"].ToString();
                    ot.VehiculoCilindrada = reader["vehiculo_cilindrada"].ToString();
                    ot.VehiculoPuertas = Convert.ToInt32(reader["vehiculo_puertas"]);
                    ot.VehiculoAsientos = Convert.ToInt32(reader["vehiculo_asientos"]);
                    ot.VehiculoPesoBruto = Convert.ToInt32(reader["vehiculo_peso_bruto"]);
                    ot.VehiculoCarga = Convert.ToInt32(reader["vehiculo_carga"]);
                    ot.VehiculoCombustible = reader["vehiculo_combustible"].ToString();
                    ot.VehiculoColor = reader["vehiculo_color"].ToString();
                    ot.VehiculoMotor = reader["vehiculo_motor"].ToString();
                    ot.VehiculoVin = reader["vehiculo_vin"].ToString();
                    ot.VehiculoCit = reader["vehiculo_cit"].ToString();
                    ot.VehiculoChasis = reader["vehiculo_chasis"].ToString();
                    ot.AbonoCliente = Convert.ToInt32(reader["abono_cliente"]);
                    ot.TieneCompraPara = Convert.ToBoolean(reader["tiene_compra_para"]);
                    ot.CompraParaRut = Convert.ToInt32(reader["compra_para_rut"]);
                    ot.CompraParaDv = Convert.ToString(reader["compra_para_dv"]);
                    ot.CompraParaNombre = Convert.ToString(reader["compra_para_nombre"]);
                    ot.Patente = Convert.ToString(reader["vehiculo_patente"]);
                    ot.ConCreditoAmicar = Convert.ToBoolean(reader["credito_amicar"]);

                }
                sqlConn.Close();
                return ot;
            }


        }


    }
}
