using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class GarantiaDAC : CACCESO.BaseDAC
	{
		public string add_garantia(Garantia garantia)
		{
			double rut = 0;
			double rut_para = 0;
			double rut_repre = 0;
			double rut_emisor = 0;
			if (garantia.Adquiriente != null) { rut = garantia.Adquiriente.Rut; }
			if (garantia.Compra_para != null) { rut_para = garantia.Compra_para.Rut; }
			if (garantia.Compra_repre != null) { rut_repre = garantia.Compra_repre.Rut; }
			if (garantia.Emisor != null) { rut_emisor = garantia.Emisor.Rut; }


			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_add_garantia", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", garantia.Operacion.Id_solicitud);
					cmd.Parameters.AddWithValue("@rut_persona", rut);
					cmd.Parameters.AddWithValue("@rut_para", rut_para);
					cmd.Parameters.AddWithValue("@creada", garantia.Creada);
					cmd.Parameters.AddWithValue("@rut_representante", rut_repre);
					cmd.Parameters.AddWithValue("@repertorio", garantia.Repertorio);
					cmd.Parameters.AddWithValue("@factura", garantia.N_factura);
					if (garantia.Fechafactura == "" || garantia.Fechafactura == null) { cmd.Parameters.AddWithValue("@fecha_factura", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_factura", Convert.ToDateTime(garantia.Fechafactura)); }
					cmd.Parameters.AddWithValue("@id_sucursal", garantia.Sucursal_origen.Id_sucursal);
					cmd.Parameters.AddWithValue("@rut_emisor", rut_emisor);
					cmd.Parameters.AddWithValue("@monto_credito", garantia.Monto);
					cmd.Parameters.AddWithValue("@n_cuotas", garantia.N_cuotas);
					if (garantia.Fecha_primera == "" || garantia.Fecha_primera == null) { cmd.Parameters.AddWithValue("@fecha_primera_cuota", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_primera_cuota", Convert.ToDateTime(garantia.Fecha_primera)); }
					if (garantia.Fecha_ultima == "" || garantia.Fecha_ultima == null) { cmd.Parameters.AddWithValue("@fecha_ultima_cuota", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_ultima_cuota", Convert.ToDateTime(garantia.Fecha_ultima)); }
					cmd.Parameters.AddWithValue("@cta_corriente", garantia.Cta_corriente);
					if (garantia.Bancofinanciera == null) { cmd.Parameters.AddWithValue("@codigo_banco", "0"); }
					else { cmd.Parameters.AddWithValue("@codigo_banco", garantia.Bancofinanciera); }
					cmd.Parameters.AddWithValue("@titular", garantia.Titular);
					cmd.Parameters.AddWithValue("@notario", garantia.Notario);
					cmd.Parameters.AddWithValue("@ciudad_notario", garantia.Ciudad_notario);
					if (garantia.Fecha_contrato == "" || garantia.Fecha_contrato == null) { cmd.Parameters.AddWithValue("@fecha_contrato", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_contrato", Convert.ToDateTime(garantia.Fecha_contrato)); }
					cmd.Parameters.AddWithValue("@neto_factura", Convert.ToDouble(garantia.Neto));
					cmd.Parameters.AddWithValue("@n_cheques", Convert.ToDouble(garantia.N_cheques));
					cmd.Parameters.AddWithValue("@tipo_pago_factura", garantia.Tipo_pago_factura);
					cmd.Parameters.AddWithValue("@factura_intereses", garantia.Factura_intereses);
					if (garantia.Fecha_factura_intereses == "" || garantia.Fecha_factura_intereses == null) { cmd.Parameters.AddWithValue("@fecha_factura_intereses", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_factura_intereses", Convert.ToDateTime(garantia.Fecha_factura_intereses)); }
					cmd.Parameters.AddWithValue("@monto_factura_intereses", garantia.Monto_factura_intereses);
					if (garantia.Fecha_protocolizacion == "" || garantia.Fecha_protocolizacion == null) { cmd.Parameters.AddWithValue("@fecha_protocolizacion", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_protocolizacion", Convert.ToDateTime(garantia.Fecha_protocolizacion)); }
					cmd.Parameters.AddWithValue("@n_protocolizacion", garantia.N_protocolizacion);
					cmd.Parameters.AddWithValue("@n_Repertorio_notaria", garantia.N_RepertorioNotaria);
					cmd.Parameters.AddWithValue("@n_Repertorio_rnp", garantia.N_RepertorioRNP);
					if (garantia.Fecha_repertorio == "" || garantia.Fecha_repertorio == null) { cmd.Parameters.AddWithValue("@fecha_repertorio", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_repertorio", Convert.ToDateTime(garantia.Fecha_repertorio)); }
					cmd.Parameters.AddWithValue("@oficina_Registro", (garantia.Oficina_Registro));
					cmd.Parameters.AddWithValue("@ing_alza_PN_registro", garantia.Ing_alza_PN_registro);
					cmd.Parameters.AddWithValue("@ing_alza_PH_registro", garantia.Ing_alza_PH_registro);
					cmd.Parameters.AddWithValue("@n_solicitud_PN_registro", garantia.N_solicitud_PN_registro);
					cmd.Parameters.AddWithValue("@n_solicitud_PH_registro", garantia.N_solicitud_PH_registro);
					cmd.Parameters.AddWithValue("@valor_vehiculo", garantia.Valor_vehiculo);
					cmd.Parameters.AddWithValue("@monto_pie", garantia.Monto_pie);
					cmd.Parameters.AddWithValue("@factura_gastos", garantia.Factura_gastos);
					if (garantia.Fecha_factura_gastos == "" || garantia.Fecha_factura_gastos == null) { cmd.Parameters.AddWithValue("@fecha_factura_gastos", DBNull.Value); }
					else { cmd.Parameters.AddWithValue("@fecha_factura_gastos", Convert.ToDateTime(garantia.Fecha_factura_gastos)); }
					cmd.Parameters.AddWithValue("@monto_factura_gastos", garantia.Monto_factura_gastos);
					cmd.Parameters.AddWithValue("@nro_credito", garantia.Nro_credito);
					cmd.Parameters.AddWithValue("@doc_fundante", garantia.Doc_fundante);
					cmd.Parameters.AddWithValue("@solicitante", garantia.Solicitante);

					cmd.Parameters.AddWithValue("@notaria_protocolizacion", garantia.Notaria_protocolizacion);
					cmd.Parameters.AddWithValue("@ciudad_notaria_protocolizacion", garantia.Ciudad_notaria_protocolizacion);

					if ((garantia.Fecha_repertorio_rnp ?? "") == "") cmd.Parameters.AddWithValue("@fecha_repertorio_rnp", DBNull.Value);
					else cmd.Parameters.AddWithValue("@fecha_repertorio_rnp", garantia.Fecha_repertorio_rnp);

					cmd.Parameters.AddWithValue("@estado_solicitud_rnp", garantia.Estado_solicitud_rnp);
					cmd.Parameters.AddWithValue("@estado_prenda", garantia.Estado_prenda);
                    cmd.Parameters.AddWithValue("@observaciones", garantia.Observaciones ?? "");

					cmd.Parameters.AddWithValue("@cav_comprado", garantia.Cav_comprado);

					cmd.Parameters.AddWithValue("@nro_declaracion", garantia.Nro_declaracion);

                    if (garantia.Fecha_pagare == "" || garantia.Fecha_pagare == null) { cmd.Parameters.AddWithValue("@fecha_pagare", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue("@fecha_pagare", Convert.ToDateTime(garantia.Fecha_pagare)); }

                    
                    cmd.Parameters.AddWithValue("@valor_cuotas", garantia.Valor_Cuotas);
                    cmd.Parameters.AddWithValue("@capital_pagare", garantia.Capital_pagare);
                    cmd.Parameters.AddWithValue("@tasa", garantia.Tasa);
                    cmd.Parameters.AddWithValue("@dia", garantia.Dia);

					cmd.ExecuteNonQuery();
					cnn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}

		public Garantia GetgarantiabyIdSolicitud(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(strConn, cnn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_garantiabyIdSolicitud";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					Garantia mgarantia = new Garantia();
					if (reader.Read())
					{
						string codigobanco = reader["codigo_banco"].ToString().Trim();
						mgarantia.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_persona"]));
						mgarantia.Bancofinanciera = codigobanco;
						mgarantia.Ciudad_notario = reader["ciudad_notario"].ToString();
						mgarantia.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mgarantia.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_para"]));
						mgarantia.Compra_repre = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_representante"]));
						mgarantia.Creada = reader["creada"].ToString();
						mgarantia.Cta_corriente = reader["cta_corriente"].ToString();
						mgarantia.Datos_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mgarantia.Emisor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_emisor"]));
						
						if (reader["fecha_contrato"].ToString() != "") mgarantia.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]).ToShortDateString();
						else mgarantia.Fecha_contrato = reader["fecha_contrato"].ToString();

						if (reader["fecha_primera_cuota"].ToString() != "") mgarantia.Fecha_primera = Convert.ToDateTime(reader["fecha_primera_cuota"]).ToShortDateString();
						else mgarantia.Fecha_primera = reader["fecha_primera_cuota"].ToString();

						if (reader["fecha_ultima_cuota"].ToString() != "") mgarantia.Fecha_ultima = Convert.ToDateTime(reader["fecha_ultima_cuota"]).ToShortDateString();
						else mgarantia.Fecha_ultima = reader["fecha_ultima_cuota"].ToString();
						
						if (reader["fecha_factura"].ToString() != "") mgarantia.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]).ToShortDateString();
						else mgarantia.Fechafactura = reader["fecha_factura"].ToString();

						mgarantia.Monto = Convert.ToDouble(reader["monto_credito"]);
						mgarantia.N_cheques = Convert.ToDouble(reader["n_cheques"]);
						mgarantia.N_cuotas = Convert.ToDouble(reader["n_cuotas"]);
						mgarantia.N_factura = Convert.ToDouble(reader["factura"]);
						mgarantia.Neto = Convert.ToDouble(reader["neto_factura"]);
						mgarantia.Notario = reader["notario"].ToString();
						mgarantia.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mgarantia.Repertorio = Convert.ToDouble(reader["repertorio"]);
						mgarantia.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"]));
						mgarantia.Titular = reader["titular"].ToString();
						mgarantia.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mgarantia.Factura_intereses = Convert.ToDouble(reader["factura_intereses"]);
						
						mgarantia.Fecha_protocolizacion = reader["fecha_protocolizacion"].ToString();
						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.Fecha_repertorio = reader["fecha_repertorio"].ToString();
						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.N_protocolizacion = reader["n_protocolizacion"].ToString();
						mgarantia.N_RepertorioNotaria = reader["n_repertorio_notaria"].ToString();
						mgarantia.N_RepertorioRNP = reader["n_repertorio_rnp"].ToString();
						mgarantia.Oficina_Registro = reader["oficina_registro"].ToString();
						mgarantia.Ing_alza_PN_registro = reader["ing_alza_pn_registro"].ToString();
						mgarantia.Ing_alza_PH_registro = reader["ing_alza_ph_registro"].ToString();
						mgarantia.N_solicitud_PN_registro = reader["n_solicitud_pn_registro"].ToString();
						mgarantia.N_solicitud_PH_registro = reader["n_solicitud_ph_registro"].ToString();
						mgarantia.Valor_vehiculo = Convert.ToDouble(reader["valor_vehiculo"]);
						mgarantia.Monto_pie = Convert.ToDouble(reader["monto_pie"]);

						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();
						
						mgarantia.Monto_factura_intereses = Convert.ToDouble(reader["monto_factura_intereses"]);

						mgarantia.Factura_gastos = Convert.ToDouble(reader["factura_gastos"]);
						if (reader["fecha_factura_gastos"].ToString() != "") mgarantia.Fecha_factura_gastos = Convert.ToDateTime(reader["fecha_factura_gastos"]).ToShortDateString();
						else mgarantia.Fecha_factura_gastos = "";

						mgarantia.Monto_factura_gastos = Convert.ToDouble(reader["monto_factura_gastos"]);
						mgarantia.Nro_credito = Convert.ToDouble(reader["nro_credito"]);
						mgarantia.Doc_fundante = reader["doc_fundante"].ToString();

						mgarantia.Solicitante = reader["solicitante"].ToString();

						mgarantia.Notaria_protocolizacion = reader["notaria_protocolizacion"].ToString();
						mgarantia.Ciudad_notaria_protocolizacion = reader["ciudad_notaria_protocolizacion"].ToString();
						if (reader["fecha_repertorio_rnp"] != DBNull.Value || reader["fecha_repertorio_rnp"].ToString() != "")
							mgarantia.Fecha_repertorio_rnp = Convert.ToDateTime(reader["fecha_repertorio_rnp"]).ToShortDateString();

						mgarantia.Estado_solicitud_rnp = reader["estado_solicitud_rnp"].ToString();
						mgarantia.Estado_prenda = reader["estado_prenda"].ToString();

						if (reader["observaciones"] != DBNull.Value) mgarantia.Observaciones = reader["observaciones"].ToString();
						else mgarantia.Observaciones = "";

						mgarantia.Cav_comprado = Convert.ToBoolean(reader["cav_comprado"]);

						mgarantia.Nro_declaracion = reader["nro_declaracion"].ToString();
                        mgarantia.Capital_pagare = Convert.ToInt32(reader["capital_pagare"].ToString());
                        mgarantia.Fecha_pagare = reader["fecha_pagare"].ToString();
                        mgarantia.Dia = Convert.ToInt32(reader["dia"].ToString());
                        mgarantia.Tasa = reader["tasa"].ToString();
                        mgarantia.Valor_Cuotas = Convert.ToInt32(reader["valor_cuotas"].ToString());
					}
					else
					{ mgarantia = null; }
					return mgarantia;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Garantia> GetGarantiasAlzamiento(int id_cliente, int id_sucursal, int id_solicitud, string desde, string hasta, double rut, string patente)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(strConn, cnn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_garantiasDisponiblesAlzamiento";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@desde", desde);
					cmd.Parameters.AddWithValue("@hasta", hasta);
					cmd.Parameters.AddWithValue("@rut", rut);
					cmd.Parameters.AddWithValue("@patente", patente);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Garantia> lgarantias = new List<Garantia>();
					while (reader.Read())
					{
						Garantia mgarantia = new Garantia();
						string codigobanco = reader["codigo_banco"].ToString().Trim();
						mgarantia.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_persona"]));
						mgarantia.Bancofinanciera = codigobanco;
						mgarantia.Ciudad_notario = reader["ciudad_notario"].ToString();
						mgarantia.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mgarantia.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_para"]));
						mgarantia.Compra_repre = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_representante"]));
						mgarantia.Creada = reader["creada"].ToString();
						mgarantia.Cta_corriente = reader["cta_corriente"].ToString();
						mgarantia.Datos_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mgarantia.Emisor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_emisor"]));

						if (reader["fecha_contrato"].ToString() != "") mgarantia.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]).ToShortDateString();
						else mgarantia.Fecha_contrato = reader["fecha_contrato"].ToString();

						if (reader["fecha_primera_cuota"].ToString() != "") mgarantia.Fecha_primera = Convert.ToDateTime(reader["fecha_primera_cuota"]).ToShortDateString();
						else mgarantia.Fecha_primera = reader["fecha_primera_cuota"].ToString();

						if (reader["fecha_ultima_cuota"].ToString() != "") mgarantia.Fecha_ultima = Convert.ToDateTime(reader["fecha_ultima_cuota"]).ToShortDateString();
						else mgarantia.Fecha_ultima = reader["fecha_ultima_cuota"].ToString();

						if (reader["fecha_factura"].ToString() != "") mgarantia.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]).ToShortDateString();
						else mgarantia.Fechafactura = reader["fecha_factura"].ToString();

						mgarantia.Monto = Convert.ToDouble(reader["monto_credito"]);
						mgarantia.N_cheques = Convert.ToDouble(reader["n_cheques"]);
						mgarantia.N_cuotas = Convert.ToDouble(reader["n_cuotas"]);
						mgarantia.N_factura = Convert.ToDouble(reader["factura"]);
						mgarantia.Neto = Convert.ToDouble(reader["neto_factura"]);
						mgarantia.Notario = reader["notario"].ToString();
						mgarantia.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mgarantia.Repertorio = Convert.ToDouble(reader["repertorio"]);
						mgarantia.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"]));
						mgarantia.Titular = reader["titular"].ToString();
						mgarantia.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mgarantia.Factura_intereses = Convert.ToDouble(reader["factura_intereses"]);

						mgarantia.Fecha_protocolizacion = reader["fecha_protocolizacion"].ToString();
						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.Fecha_repertorio = reader["fecha_repertorio"].ToString();
						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.N_protocolizacion = reader["n_protocolizacion"].ToString();
						mgarantia.N_RepertorioNotaria = reader["n_repertorio_notaria"].ToString();
						mgarantia.N_RepertorioRNP = reader["n_repertorio_rnp"].ToString();
						mgarantia.Oficina_Registro = reader["oficina_registro"].ToString();
						mgarantia.Ing_alza_PN_registro = reader["ing_alza_pn_registro"].ToString();
						mgarantia.Ing_alza_PH_registro = reader["ing_alza_ph_registro"].ToString();
						mgarantia.N_solicitud_PN_registro = reader["n_solicitud_pn_registro"].ToString();
						mgarantia.N_solicitud_PH_registro = reader["n_solicitud_ph_registro"].ToString();
						mgarantia.Valor_vehiculo = Convert.ToDouble(reader["valor_vehiculo"]);
						mgarantia.Monto_pie = Convert.ToDouble(reader["monto_pie"]);

						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.Monto_factura_intereses = Convert.ToDouble(reader["monto_factura_intereses"]);

						mgarantia.Factura_gastos = Convert.ToDouble(reader["factura_gastos"]);
						if (reader["fecha_factura_gastos"].ToString() != "") mgarantia.Fecha_factura_gastos = Convert.ToDateTime(reader["fecha_factura_gastos"]).ToShortDateString();
						else mgarantia.Fecha_factura_gastos = "";

						mgarantia.Monto_factura_gastos = Convert.ToDouble(reader["monto_factura_gastos"]);
						mgarantia.Nro_credito = Convert.ToDouble(reader["nro_credito"]);
						mgarantia.Doc_fundante = reader["doc_fundante"].ToString();

						mgarantia.Solicitante = reader["solicitante"].ToString();

						mgarantia.Notaria_protocolizacion = reader["notaria_protocolizacion"].ToString();
						mgarantia.Ciudad_notaria_protocolizacion = reader["ciudad_notaria_protocolizacion"].ToString();
						if (reader["fecha_repertorio_rnp"] != DBNull.Value || reader["fecha_repertorio_rnp"].ToString() != "")
							mgarantia.Fecha_repertorio_rnp = Convert.ToDateTime(reader["fecha_repertorio_rnp"]).ToShortDateString();

						mgarantia.Estado_solicitud_rnp = reader["estado_solicitud_rnp"].ToString();
						mgarantia.Estado_prenda = reader["estado_prenda"].ToString();

						if (reader["observaciones"] != DBNull.Value) mgarantia.Observaciones = reader["observaciones"].ToString();
						else mgarantia.Observaciones = "";

						mgarantia.Cav_comprado = Convert.ToBoolean(reader["cav_comprado"]);

						mgarantia.Nro_declaracion = reader["nro_declaracion"].ToString();

						lgarantias.Add(mgarantia);
					}
					return lgarantias;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Garantia Getgarantiabyfactura(Int16 id_cliente, double rut_emisor, double factura)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(strConn, cnn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_garantiabyFactura";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@rut_emisor", rut_emisor);
					cmd.Parameters.AddWithValue("@factura", factura);
					SqlDataReader reader = cmd.ExecuteReader();
					Garantia mgarantia = new Garantia();
					if (reader.Read())
					{
						string codigobanco = reader["codigo_banco"].ToString().Trim();
						mgarantia.Adquiriente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_persona"]));
						mgarantia.Bancofinanciera = codigobanco;
						mgarantia.Ciudad_notario = reader["ciudad_notario"].ToString();
						mgarantia.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"]));
						mgarantia.Compra_para = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_para"]));
						mgarantia.Compra_repre = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_representante"]));
						mgarantia.Creada = reader["creada"].ToString();
						mgarantia.Cta_corriente = reader["cta_corriente"].ToString();
						mgarantia.Datos_vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mgarantia.Emisor = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_emisor"]));

						if (reader["fecha_contrato"].ToString() != "") mgarantia.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]).ToShortDateString();
						else mgarantia.Fecha_contrato = reader["fecha_contrato"].ToString();

						if (reader["fecha_primera_cuota"].ToString() != "") mgarantia.Fecha_primera = Convert.ToDateTime(reader["fecha_primera_cuota"]).ToShortDateString();
						else mgarantia.Fecha_primera = reader["fecha_primera_cuota"].ToString();

						if (reader["fecha_ultima_cuota"].ToString() != "") mgarantia.Fecha_ultima = Convert.ToDateTime(reader["fecha_ultima_cuota"]).ToShortDateString();
						else mgarantia.Fecha_ultima = reader["fecha_ultima_cuota"].ToString();

						if (reader["fecha_factura"].ToString() != "") mgarantia.Fechafactura = Convert.ToDateTime(reader["fecha_factura"]).ToShortDateString();
						else mgarantia.Fechafactura = reader["fecha_factura"].ToString();

						mgarantia.Monto = Convert.ToDouble(reader["monto_credito"]);
						mgarantia.N_cheques = Convert.ToDouble(reader["n_cheques"]);
						mgarantia.N_cuotas = Convert.ToDouble(reader["n_cuotas"]);
						mgarantia.N_factura = Convert.ToDouble(reader["factura"]);
						mgarantia.Neto = Convert.ToDouble(reader["neto_factura"]);
						mgarantia.Notario = reader["notario"].ToString();
						mgarantia.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mgarantia.Repertorio = Convert.ToDouble(reader["repertorio"]);
						mgarantia.Sucursal_origen = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"]));
						mgarantia.Titular = reader["titular"].ToString();
						mgarantia.Tipo_pago_factura = reader["tipo_pago_factura"].ToString();
						mgarantia.Factura_intereses = Convert.ToDouble(reader["factura_intereses"]);

						mgarantia.Fecha_protocolizacion = reader["fecha_protocolizacion"].ToString();
						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.Fecha_repertorio = reader["fecha_repertorio"].ToString();
						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.N_protocolizacion = reader["n_protocolizacion"].ToString();
						mgarantia.N_RepertorioNotaria = reader["n_repertorio_notaria"].ToString();
						mgarantia.N_RepertorioRNP = reader["n_repertorio_rnp"].ToString();
						mgarantia.Oficina_Registro = reader["oficina_registro"].ToString();
						mgarantia.Ing_alza_PN_registro = reader["ing_alza_pn_registro"].ToString();
						mgarantia.Ing_alza_PH_registro = reader["ing_alza_ph_registro"].ToString();
						mgarantia.N_solicitud_PN_registro = reader["n_solicitud_pn_registro"].ToString();
						mgarantia.N_solicitud_PH_registro = reader["n_solicitud_ph_registro"].ToString();
						mgarantia.Valor_vehiculo = Convert.ToDouble(reader["valor_vehiculo"]);
						mgarantia.Monto_pie = Convert.ToDouble(reader["monto_pie"]);

						if (reader["fecha_factura_intereses"].ToString() != "") mgarantia.Fecha_factura_intereses = Convert.ToDateTime(reader["fecha_factura_intereses"]).ToShortDateString();
						else mgarantia.Fecha_factura_intereses = reader["fecha_factura_intereses"].ToString();

						mgarantia.Monto_factura_intereses = Convert.ToDouble(reader["monto_factura_intereses"]);

						mgarantia.Factura_gastos = Convert.ToDouble(reader["factura_gastos"]);
						if (reader["fecha_factura_gastos"].ToString() != "") mgarantia.Fecha_factura_gastos = Convert.ToDateTime(reader["fecha_factura_gastos"]).ToShortDateString();
						else mgarantia.Fecha_factura_gastos = "";

						mgarantia.Monto_factura_gastos = Convert.ToDouble(reader["monto_factura_gastos"]);
						mgarantia.Nro_credito = Convert.ToDouble(reader["nro_credito"]);
						mgarantia.Doc_fundante = reader["doc_fundante"].ToString();

						mgarantia.Solicitante = reader["solicitante"].ToString();

						mgarantia.Notaria_protocolizacion = reader["notaria_protocolizacion"].ToString();
						mgarantia.Ciudad_notaria_protocolizacion = reader["ciudad_notaria_protocolizacion"].ToString();
						if (reader["fecha_repertorio_rnp"] != DBNull.Value || reader["fecha_repertorio_rnp"].ToString() != "")
							mgarantia.Fecha_repertorio_rnp = Convert.ToDateTime(reader["fecha_repertorio_rnp"]).ToShortDateString();
                        
						mgarantia.Estado_solicitud_rnp = reader["estado_solicitud_rnp"].ToString();
						mgarantia.Estado_prenda = reader["estado_prenda"].ToString();

						if (reader["observaciones"] != DBNull.Value) mgarantia.Observaciones = reader["observaciones"].ToString();
						else mgarantia.Observaciones = "";

						mgarantia.Cav_comprado = Convert.ToBoolean(reader["cav_comprado"]);

						mgarantia.Nro_declaracion = reader["nro_declaracion"].ToString();

                        mgarantia.Fecha_pagare = reader["fecha_pagare"].ToString();
                        
					}
					else
					{ mgarantia = null; }
					return mgarantia;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}