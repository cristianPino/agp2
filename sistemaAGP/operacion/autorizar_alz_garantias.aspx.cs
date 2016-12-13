using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class autorizar_alz_garantias : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.cal_desde.FirstDayOfWeek = FirstDayOfWeek.Monday;
				this.cal_hasta.FirstDayOfWeek = FirstDayOfWeek.Monday;
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			busca_operacion();
		}

		private void busca_operacion()
		{
			int id_cliente = Convert.ToInt32(this.dl_cliente.SelectedValue);
			int id_sucursal = 0;
			int id_solicitud = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
			double rut = 0;
			string patente = this.txt_patente.Text.Trim();

			if (this.dl_sucursal.SelectedValue != "") id_sucursal = Convert.ToInt32(this.dl_sucursal.SelectedValue);
			if (!int.TryParse(this.txt_operacion.Text, out id_solicitud)) id_solicitud = 0;
			if (!double.TryParse(this.txt_rut.Text, out rut)) rut = 0;

			if (id_solicitud != 0 || patente != "")
			{
				desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
				hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			}

			this.gr_dato.DataSource = from g in new GarantiaBC().GetGarantiasAlzamiento(id_cliente, id_sucursal, id_solicitud, desde, hasta, rut, patente)
									  select new
									  {
										  id_solicitud = g.Operacion.Id_solicitud,
										  id_cliente = g.Cliente.Id_cliente,
										  tipo_producto = g.Operacion.Tipo_operacion.Codigo.Trim(),
										  nombre_cliente = g.Cliente.Persona.Nombre.Trim().ToUpper(),
										  patente = g.Datos_vehiculo.Patente.Trim().ToUpper(),
										  rut = string.Format("{0:N0}-{1}", g.Adquiriente.Rut, g.Adquiriente.Dv.ToUpper()),
										  nombre = (g.Adquiriente.Nombre + ' ' + g.Adquiriente.Apellido_paterno + ' ' + g.Adquiriente.Apellido_materno).Trim().ToUpper(),
										  fecha_ultimo = g.Fecha_ultima,
										  url = "javascript:window.showModalDialog('" + g.Operacion.Tipo_operacion.Url_operacion + FuncionGlobal.FuctionEncriptar(g.Operacion.Id_solicitud.ToString()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(g.Cliente.Id_cliente.ToString()) + "','_blank','dialogheight=600px,dialogWidth=850px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')"
									  };
			this.gr_dato.DataBind();
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(this.gr_dato);
		}

		protected void ib_autorizar_Click(object sender, ImageClickEventArgs e)
		{
			autorizar_alzamientos();
		}

		protected void autorizar_alzamientos()
		{
			var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
						where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
						select r;
			if (query.Count() > 0)
			{
				foreach (GridViewRow row in query)
				{
					int id = Convert.ToInt32(this.gr_dato.DataKeys[row.RowIndex].Values[0].ToString());
					Garantia garantia = new GarantiaBC().GetgarantiabyIdSolicitud(id);

                    int add = new OperacionBC().add_operacion(0, garantia.Cliente.Id_cliente, "ALZGA", (string)(Session["usrname"]), id, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);
					if (add != 0)
					{
						string aux = new GarantiaBC().add_Garantia(add, garantia.Adquiriente.Rut, garantia.Cliente.Id_cliente, (garantia.Compra_para != null) ? garantia.Compra_para.Rut : 0, garantia.Creada, (garantia.Compra_repre != null) ? garantia.Compra_repre.Rut : 0,
							garantia.Repertorio, garantia.N_factura, garantia.Fechafactura, garantia.Sucursal_origen.Id_sucursal, garantia.Emisor.Rut, garantia.Monto, garantia.N_cuotas, garantia.Fecha_primera,
							garantia.Fecha_ultima, garantia.Cta_corriente, garantia.Bancofinanciera, garantia.Titular, garantia.Notario, garantia.Ciudad_notario, garantia.Fecha_contrato, garantia.N_cheques, garantia.Neto,
							garantia.Tipo_pago_factura, garantia.Factura_intereses, garantia.Fecha_factura_intereses, garantia.Monto_factura_intereses, garantia.Fecha_protocolizacion, garantia.N_protocolizacion, garantia.N_RepertorioNotaria, garantia.N_RepertorioRNP,
							garantia.Fecha_repertorio, garantia.Oficina_Registro, garantia.Ing_alza_PN_registro, garantia.Ing_alza_PH_registro, garantia.N_solicitud_PN_registro, garantia.N_solicitud_PH_registro, garantia.NombreEstado, garantia.FechaUltimoEstado,
							garantia.Valor_vehiculo, garantia.Monto_pie, garantia.Factura_gastos, garantia.Fecha_factura_gastos, garantia.Monto_factura_gastos, garantia.Nro_credito, garantia.Doc_fundante, garantia.Solicitante,
                            garantia.Notaria_protocolizacion, garantia.Ciudad_notaria_protocolizacion, garantia.Fecha_repertorio_rnp, garantia.Estado_solicitud_rnp, garantia.Estado_prenda, garantia.Observaciones, false, garantia.Nro_declaracion, garantia.Fecha_pagare,
                                                                                                        garantia.Valor_Cuotas, garantia.Capital_pagare, garantia.Tasa, garantia.Dia);

						foreach (DatosVehiculo veh in new DatosvehiculoBC().getDatosvehiculo(id))
						{
							aux = new DatosvehiculoBC().add_Datosvehiculo(add, veh.Marca, veh.Tipo_vehiculo, veh.Patente, veh.Dv, veh.Modelo, veh.Chassis, veh.Motor, veh.Vin, veh.Serie, veh.Ano,
								veh.Cilindraje, veh.Color, veh.Carga, veh.Pesobruto, veh.Combustible, veh.Npuerta, veh.Nasiento, veh.Kilometraje, veh.Tasacion, veh.Codigo_SII, veh.Precio,
								0, veh.Fecha_contrato, veh.Forma_pago, veh.Prenda, veh.Estado_vehiculo, veh.Rut_prenda,veh.Financiamiento_amicar,veh.Transmision,veh.Equipamiento);
						}

						aux = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, "ALZGA", "", (string)(Session["usrname"]));
					}
				}

				this.busca_operacion();

				string cadena = "";
				cadena += "?nombre_rpt=InfAlzamientosAutorizados.rpt";
				cadena += "&tipo_operacion=ALZGA";
				cadena += "&id_modulo=0";
				cadena += "&id_sucursal=" + this.dl_sucursal.SelectedValue.ToString().Trim();
				cadena += "&id_cliente=" + this.dl_cliente.SelectedValue.ToString().Trim();
				cadena += "&id_solicitud=0";
				cadena += "&rut_adquiriente=0";
				cadena += "&numero_factura=0";
				cadena += "&numero_cliente=";
				cadena += "&patente=";
				cadena += "&desde=" + string.Format("{0:yyyyMMdd}", DateTime.Today);
				cadena += "&hasta=" + string.Format("{0:yyyyMMdd}", DateTime.Today);
				cadena += "&ultimo_estado=0";
				cadena += "&folio=0";
				cadena += "&id_nomina=0";
				cadena += "&id_ciudad=0";
				cadena += "&id_familia=0";
				ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "window.open('../reportes/view_report_agp.aspx" + cadena + "');", true);

				FuncionGlobal.alerta_updatepanel("Operaciones seleccionadas autorizadas con éxito", this.Page, this.upFiltros);
			}
			else
			{
				FuncionGlobal.alerta_updatepanel("No hay ninguna operación de prenda seleccionada", this.Page, this.upFiltros);
			}
		}
	}
}