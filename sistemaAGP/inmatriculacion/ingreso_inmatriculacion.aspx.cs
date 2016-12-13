using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.WSPeru;
using Mail;
using System.Text;
//using Word = Microsoft.Office.Interop.Word;

namespace sistemaAGP.inmatriculacion
{
	public partial class ingreso_inmatriculacion : System.Web.UI.Page
	{
		private string id_solicitud;
		private string id_cliente;
		private string tipo_operacion;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			this.id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
			this.tipo_operacion = Request.QueryString["tipo_operacion"].ToString().ToUpper();

			if (!IsPostBack)
			{
				this.lbl_numero.Text = "0";
                
                Usuario musuaper = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
                if (musuaper.Perfil.Codigoperfil.Trim() == "ADVP")
                {
                    this.txt_vendedor.Text = musuaper.Nombre;
                }
                else
                {
                    this.txt_vendedor.Visible = true;
                    this.lbl_vendedor.Visible = true;
                }
                 Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
                 if (musuario.Perfil.Codigoperfil.Trim() != "EJPE")
                 {
                     this.chk_dua.Checked = true;
                 }
                 else
                 {
                     this.chk_dua.Visible = true;
                 }

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.ddlCliente);
				this.ddlCliente.SelectedValue = this.id_cliente;
				
				FuncionGlobal.comboparametro(this.ddlTipoDocNat, "TDIPERU");
				this.ddlTipoDocNat.Items.Remove(this.ddlTipoDocNat.Items.FindByValue("RUC"));
				
				FuncionGlobal.comboparametro(this.ddlTipoDocJur, "TDIPERU");
				this.ddlTipoDocJur.SelectedValue = "RUC";
				this.ddlTipoDocJur.Enabled = false;

				FuncionGlobal.comboparametro(this.ddlTipoDocRep, "TDIPERU");
				this.ddlTipoDocRep.Items.Remove(this.ddlTipoDocRep.Items.FindByValue("RUC"));

				FuncionGlobal.comboparametro(this.ddlEstadoCivilNat, "ESCIVIL");

				FuncionGlobal.comboregion(this.ddlRegion, "PER");

				FuncionGlobal.combosucursalbyclienteandUsuario(this.ddlSucursal, Convert.ToInt16(this.ddlCliente.SelectedValue), (string)(Session["usrname"]));
				if (this.ddlSucursal.Items.Count == 2)
				{
					this.ddlSucursal.SelectedIndex = 1;
				}

				FuncionGlobal.combomarcavehiculo(this.ddlVehMarca);

				FuncionGlobal.comboparametro(this.ddlVehCombus, "COMB");
				FuncionGlobal.comboparametro(this.ddlFormaPago, "FOPA");
				FuncionGlobal.comboparametro(this.ddlCargoVenta, "CAVE");
				this.ddlCargoVenta.SelectedValue = "1";

				FuncionGlobal.combotipomoneda(this.ddlMoneda);

				FuncionGlobal.combobanco(this.ddlFinanciera,Convert.ToInt32(id_cliente));

				FuncionGlobal.combotipoclasificacionvehicular(this.ddlVehCat);
				FuncionGlobal.combotipocarroceria(this.ddlVehCarroceria);

				this.ibtnSUNARP.Visible = false;
				this.ibtnFormaPago.Visible = false;
				this.ibtnAAP.Visible = false;
				this.ibtSAT.Visible = false;
				this.ibtCheck.Visible = false;
				this.ibtAnexo.Visible = false;
				this.ibtAnexo1.Visible = false;
				this.ibtAnexo2.Visible = false;

				if (Session["numero_placa"] == null)
				{
					Session.Add("numero_placa", "");
				}

				GetOperacionById(Convert.ToInt32(this.id_solicitud));
			}
		}

		protected void lstTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
		{
			CambiarTipoPersona();
		}

		private void CambiarTipoPersona()
		{
			if (this.lstTipoPersona.SelectedValue == "1")
			{
				this.pnlPersonaNatural.Visible = true;
				this.pnlPersonaJuridica.Visible = false;
				if (ddlEstadoCivilNat.SelectedValue == "CAS")
				{
                    if (this.chk_bienes.Checked == true)
                    {
                        this.pnlDatosBienes.Visible = true;
                    }
                    else
                    {
                        this.pnlRepresentante.Visible = true;
                        this.lblPanel.Text = "CÓNYUGE";
                    }
				}
				else
				{
					this.pnlRepresentante.Visible = false;
					this.lblPanel.Text = "";
				}
			}
			else if (this.lstTipoPersona.SelectedValue == "2")
			{
				this.pnlPersonaNatural.Visible = false;
				this.pnlPersonaJuridica.Visible = true;
				this.pnlRepresentante.Visible = true;
				this.lblPanel.Text = "REPRESENTANTE";
			}
		}

		protected void ddlEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlEstadoCivilNat.SelectedValue == "CAS")
			{
                this.chk_bienes.Visible = true;
                if (this.chk_bienes.Checked != true)
                {
                    this.pnlRepresentante.Visible = true;
                    this.lblPanel.Text = "CÓNYUGE";
                }
                else
                {
                    this.chk_bienes.Visible = true;
                }
			}
			else
			{
                this.chk_bienes.Checked = false;
				this.pnlRepresentante.Visible = false;
				this.lblPanel.Text = "";
			}
		}

		protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combociudad(this.ddlCiudad, Convert.ToInt16(this.ddlRegion.SelectedValue));
		}

		protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocomuna(this.ddlComuna, Convert.ToInt16(this.ddlCiudad.SelectedValue));
		}

		protected void txtNotaPedido_TextChanged(object sender, EventArgs e)
		{
			if (!GetOperacionByNotaVenta())
			{
				Cliente cli = new ClienteBC().getcliente(Convert.ToInt16(this.ddlCliente.SelectedValue));
				if (cli != null)
				{
					switch (cli.Id_webservice)
					{
						case 2:
							GetOperacionWSPeru();
							break;
						default:
							break;
					}
				}
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e) { }

		protected void btnAceptar_Click(object sender, EventArgs e) {
			if (ValidarDatos())
			{
				AddInmatriculacion();
			}
		}

		protected void btnCancelar_Click(object sender, EventArgs e) { }

		protected void bt_limpiar_Click(object sender, EventArgs e) { }

		protected void bt_caratula_Click(object sender, EventArgs e) { }

		private void GetOperacionById(int id_solicitud)
		{
			//Inmatriculacion operacion = new InmatriculacionBC().GetInmatriculacion(Convert.ToInt32(this.id_solicitud));
			try
			{
				Inmatriculacion operacion = new InmatriculacionBC().GetInmatriculacion(id_solicitud);
				CargarInfoInmatriculacion(operacion);
			}
			catch (Exception ex)
			{
				UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
			}
		}

		private bool GetOperacionByNotaVenta()
		{
			bool resp = false;
			if (this.txtNotaPedido.Text.Trim() == "") return resp;
			try
			{
				Inmatriculacion operacion = new InmatriculacionBC().GetInmatriculacionByNotaPedido(Convert.ToInt16(this.ddlCliente.SelectedValue), this.txtNotaPedido.Text);
				return CargarInfoInmatriculacion(operacion);
			}
			catch (Exception ex)
			{
				UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
			}
			return false;
		}

		private bool CargarInfoInmatriculacion(Inmatriculacion operacion)
		{
			bool resp = false;
			if (operacion.Operacion != null)
			{
				try
				{
					this.lbl_operacion.Visible = true;
					this.lbl_numero.Visible = true;
					this.lbl_operacion.Text = "Número de Operación:";
					this.lbl_numero.Text = Convert.ToString(operacion.Operacion.Id_solicitud);

					this.ddlCliente.SelectedValue = operacion.Operacion.Cliente.Id_cliente.ToString();
					FuncionGlobal.combosucursalbyclienteandUsuario(this.ddlSucursal, Convert.ToInt16(this.ddlCliente.SelectedValue), (string)(Session["usrname"]));
					this.ddlSucursal.SelectedValue = operacion.Sucursal.Id_sucursal.ToString();
					this.txtNotaPedido.Text = operacion.NumeroNotaPedido;
                    this.txt_vendedor.Text = operacion.Vendedor;
					this.txtFechaDocVenta.Text = operacion.FechaEmisionDocumentoVenta.ToShortDateString();
					this.txtMontoTotalVeh.Text = operacion.MontoTotalVehiculo.ToString();
					this.txtNroDocVenta.Text = operacion.NumeroDocumentoVenta.Trim();
					this.ddlMoneda.SelectedValue = operacion.TipoMoneda;

					//this.ddlFormaPago.SelectedValue = operacion.FormaPago;
					FuncionGlobal.BuscarValueCombo(this.ddlFormaPago, (operacion.FormaPago ?? "0").Trim());
					
					//this.ddlFinanciera.SelectedValue = (operacion.Financiera.Codigo ?? "0").Trim();
					FuncionGlobal.BuscarValueCombo(this.ddlFinanciera, (operacion.Financiera.Codigo ?? "0").Trim());

					//this.ddlCargoVenta.SelectedValue = operacion.Cargo_venta.Trim() != "" ? operacion.Cargo_venta.Trim() : "0";
					FuncionGlobal.BuscarValueCombo(this.ddlCargoVenta, (operacion.Cargo_venta ?? "0").Trim());

					this.txtObsFP.Text = operacion.Obs_fp;

					this.txtNumeroTitulo.Text = (operacion.Numero_titulo != 0) ? operacion.Numero_titulo.ToString() : "";
					this.txtObsOp.Text = operacion.Obs_operacion;

					this.txtPartidaElectronica.Text = operacion.Partida_electronica ?? "";
					this.txtFicha.Text = operacion.Ficha_nro ?? "";
					this.txtTomo.Text = operacion.Tomo ?? "";
					this.txtFojas.Text = operacion.Fojas ?? "";
					this.txtOficinaRegistral.Text = operacion.Oficina_registral ?? "";
                    this.chk_dua.Checked = operacion.Dua;
                    this.chk_bienes.Checked = operacion.Separacion_bienes;
                    if (operacion.Separacion_bienes == true)
                    {
                        this.chk_bienes.Visible = true;
                    }
                        this.txtOficiRegBienes.Text = operacion.Ofic_reg_bienes;
                        this.txtPartElectBienes.Text = operacion.Part_elect_bienes;
                  
					if (operacion.Comprador.TipoDocumentoIdentidad.Trim().ToUpper() == "RUC")
					{
						this.lstTipoPersona.SelectedValue = "2";
						this.txtNroDocJur.Text = operacion.Comprador.NroDocumentoIdentidad.Trim();
						this.txtNombreJur.Text = operacion.Comprador.Nombres.Trim().ToUpper();

						FuncionGlobal.BuscarValueCombo(this.ddlTipoDocRep, operacion.Comprador.TipoDocumentoIdentidad.Trim().ToUpper());
					}
					else
					{
						this.lstTipoPersona.SelectedValue = "1";
						FuncionGlobal.BuscarValueCombo(this.ddlTipoDocNat, operacion.Comprador.TipoDocumentoIdentidad.Trim().ToUpper());
						this.txtNroDocNat.Text = operacion.Comprador.NroDocumentoIdentidad.Trim();
						FuncionGlobal.BuscarTextoCombo(this.ddlEstadoCivilNat, operacion.Comprador.EstadoCivil.Trim());
						this.txtNombreNat.Text = operacion.Comprador.Nombres.Trim().ToUpper();
						this.txtPaternoNat.Text = operacion.Comprador.ApellidoPaterno.Trim().ToUpper();
						this.txtMaternoNat.Text = operacion.Comprador.ApellidoMaterno.Trim().ToUpper();
						//this.ddlEstadoCivilNat.SelectedValue = operacion.Comprador.EstadoCivil;
						FuncionGlobal.BuscarValueCombo(this.ddlEstadoCivilNat, operacion.Comprador.EstadoCivil);
					}

					this.txtDomicilioCom.Text = operacion.Comprador.Domicilio.Trim().ToUpper();
					this.ddlRegion.SelectedValue = operacion.Comprador.Comuna.Ciudad.Region.Id_region.ToString();
					FuncionGlobal.combociudad(this.ddlCiudad, Convert.ToInt16(this.ddlRegion.SelectedValue));
					this.ddlCiudad.SelectedValue = operacion.Comprador.Comuna.Ciudad.Id_Ciudad.ToString();
					FuncionGlobal.combocomuna(this.ddlComuna, Convert.ToInt16(this.ddlCiudad.SelectedValue));
					this.ddlComuna.SelectedValue = operacion.Comprador.Comuna.Id_Comuna.ToString();

					CambiarTipoPersona();

					if (operacion.Representante.Nombres != null)
					{
						this.ddlTipoDocRep.SelectedValue = operacion.Representante.TipoDocumentoIdentidad.Trim();
						this.txtNroDocRep.Text = operacion.Representante.NroDocumentoIdentidad.Trim();
						this.txtNombreRep.Text = operacion.Representante.Nombres.Trim().ToUpper();
						this.txtPaternoRep.Text = operacion.Representante.ApellidoPaterno.Trim().ToUpper();
						this.txtMaternoRep.Text = operacion.Representante.ApellidoMaterno.Trim().ToUpper();
					}

					FuncionGlobal.BuscarTextoCombo(this.ddlFormaPago, operacion.FormaPago.Trim());

					DatosVehiculoPeru vehiculo = new DatosVehiculoPeruBC().GetVehiculoByIdSolicitud(operacion.Operacion.Id_solicitud);
					if (vehiculo.NumeroVin != null)
					{
						Session["numero_placa"] = vehiculo.NumeroPlaca;
						this.txtVehPlaca.Text = vehiculo.NumeroPlaca;
						this.txtVehVin.Text = vehiculo.NumeroVin.Trim();
						this.txtVehSerie.Text = vehiculo.NumeroSerieVin.Trim();
						this.ddlVehMarca.SelectedValue = vehiculo.Marca.Id_marca.ToString();
						this.txtVehModelo.Text = vehiculo.Modelo.Trim();
						this.txtVehVersion.Text = vehiculo.Version.Trim();
						this.txtVehAnioM.Text = vehiculo.AModelo.Trim();
						this.txtVehAnioF.Text = vehiculo.AFabricacion.Trim();
						//this.txtVehCat.Text = vehiculo.ClaseCarroceria.Trim();
						this.ddlVehCat.SelectedValue = vehiculo.Tipo_clasificacion.Id_categoria.ToString();
						this.ddlVehCarroceria.SelectedValue = vehiculo.Tipo_carroceria.Cod_tipo_carroceria.ToString();
						this.txtVehColor.Text = vehiculo.Color.Trim();
						this.txtVehNroMotor.Text = vehiculo.NumeroMotor.Trim();
						this.txtVehPotMotor.Text = vehiculo.PotenciaMotor.Trim();
						this.ddlVehCombus.SelectedValue = vehiculo.Combustible.Trim();
						this.txtVehCilindros.Text = vehiculo.Cilindros.Trim();
						this.txtVehCilindrada.Text = vehiculo.Cilindrada.Trim();
						this.txtVehLong.Text = vehiculo.Longitud.Trim();
						this.txtVehPasajeros.Text = vehiculo.NumeroPasajeros.Trim();
						this.txtVehPesoNeto.Text = vehiculo.PesoNeto.Trim();
						this.txtVehCargaUtil.Text = vehiculo.CargaUtil.Trim();
						this.txtVehPesoBruto.Text = vehiculo.PesoBruto.Trim();
						this.txtVehAsientos.Text = vehiculo.NumeroAsientos.Trim();
						this.txtVehEjes.Text = vehiculo.NumeroEjes.Trim();
						this.txtVehAncho.Text = vehiculo.Ancho.Trim();
						this.txtVehPuertas.Text = vehiculo.NumeroPuertas.Trim();
						this.txtVehAlto.Text = vehiculo.Alto.Trim();
						this.txtVehRuedas.Text = vehiculo.NumeroRuedas.Trim();
						this.txtVehFormula.Text = vehiculo.FormulaRodante.Trim();
					}
					vehiculo = null;

					DataTable tfp = new DataTable();
					tfp.Columns.Add("id_solicitud");
					tfp.Columns.Add("nro_cuenta");
					tfp.Columns.Add("banco");
					tfp.Columns.Add("medio_pago");
					tfp.Columns.Add("monto");
					tfp.Columns.Add("moneda");
					tfp.Columns.Add("fecha");
					tfp.Columns.Add("observaciones");

					List<FormaPagoInmatriculacion> lfp = new FormaPagoInmatriculacionBC().GetFormaPago(operacion.Operacion.Id_solicitud);
					int numFilas = lfp.Count;
					if (numFilas > 0)
					{
						foreach (FormaPagoInmatriculacion fp in new FormaPagoInmatriculacionBC().GetFormaPago(operacion.Operacion.Id_solicitud))
						{
							DataRow row = tfp.NewRow();
							row["id_solicitud"] = fp.Id_solicitud;
							row["nro_cuenta"] = fp.Numero_cuenta_corriente;
							row["banco"] = fp.Banco.Nombre;
							row["medio_pago"] = fp.Tipo_forma_pago.Descripcion.Trim();
							row["monto"] = fp.Monto_abono;
							row["moneda"] = fp.Moneda.Nombre.Trim();
							row["fecha"] = fp.Fecha_abono.ToShortDateString();
							row["observaciones"] = fp.Observaciones;
							tfp.Rows.Add(row);
						}
					}
					//else
					//{
					for (int i = 1; i <= 10 - numFilas; i++)
					{
						DataRow row = tfp.NewRow();
						row["id_solicitud"] = operacion.Operacion.Id_solicitud;
						row["nro_cuenta"] = "";
						row["banco"] = "";
						row["medio_pago"] = "";
						row["monto"] = "";
						row["moneda"] = "";
						row["fecha"] = "";
						row["observaciones"] = "";
						tfp.Rows.Add(row);
					}
					//}

					//this.grdFormaPago.DataSource = new FormaPagoInmatriculacionBC().GetFormaPago(operacion.Operacion.Id_solicitud);
					this.grdFormaPago.DataSource = tfp;
					this.grdFormaPago.DataBind();

					string cadena = "";
					cadena += "&tipo_operacion=0";
					cadena += "&id_modulo=0";
					cadena += "&id_sucursal=0";
					cadena += "&id_cliente=0";
					cadena += "&id_solicitud=" + this.lbl_numero.Text;
					cadena += "&rut_adquiriente=0";
					cadena += "&numero_factura=0";
					cadena += "&numero_cliente=";
					cadena += "&patente=";
					cadena += "&desde=";
					cadena += "&hasta=";
					cadena += "&ultimo_estado=0";
					cadena += "&folio=0";
					cadena += "&id_nomina=0";
					cadena += "&id_ciudad=0";
					cadena += "&id_familia=0";

					this.ibtnSUNARP.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=InfDocumentoSUNARP.rpt{0}", cadena);

					if (this.ddlCliente.SelectedValue == "43") //MAQUINARIA NACIONAL PERÚ S.A.
						this.ibtnFormaPago.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=infFormaPagoMANASAPeru.rpt{0}", cadena);
					else if (this.ddlCliente.SelectedValue == "44") //AUTOMOTORES GILDEMEISTER PERÚ S.A.
						this.ibtnFormaPago.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=infFormaPagoAGPeru.rpt{0}", cadena);
					else if (this.ddlCliente.SelectedValue == "46") //MOTOR MUNDO S.A.
						this.ibtnFormaPago.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=infFormaPagoMotorMundo.rpt{0}", cadena);
					else //GENERAL
						this.ibtnFormaPago.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=infFormaPago.rpt{0}", cadena);

					this.ibtAnexo1.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=InfAnexo1SUNARPTodos.rpt{0}", cadena);
					this.ibtAnexo2.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=InfAnexo2SUNARP_per.rpt{0}", cadena);

					if (this.lstTipoPersona.SelectedValue == "1")
					{
						this.ibtAnexo.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=InfAnexo1SUNARP_per.rpt{0}", cadena);
						this.ibtAnexo.ToolTip = "Anexo I";
					}
					else
					{
						this.ibtAnexo.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=InfAnexo2SUNARP.rpt{0}", cadena);
						this.ibtAnexo.ToolTip = "Anexo II";
					}

					this.ibtnAAP.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=infPoderAAP.rpt{0}", cadena);
					this.ibtSAT.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=infPoderSAT.rpt{0}", cadena);
					this.ibtCheck.NavigateUrl = string.Format("../reportes/view_report_agp.aspx?nombre_rpt=InfChecklistPeru.rpt{0}", cadena);

					this.ibtnSUNARP.Visible = true;
					this.ibtnFormaPago.Visible = true;
					this.ibtnAAP.Visible = true;
					this.ibtSAT.Visible = true;
					this.ibtCheck.Visible = true;
					this.ibtAnexo.Visible = true;
					this.ibtAnexo1.Visible = true;
					this.ibtAnexo2.Visible = true;

					resp = true;
				}
				catch (Exception ex)
				{
					UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
					FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
				}
			}
			else
			{
				DataTable tfp = new DataTable();
				tfp.Columns.Add("id_solicitud");
				tfp.Columns.Add("nro_cuenta");
				tfp.Columns.Add("banco");
				tfp.Columns.Add("medio_pago");
				tfp.Columns.Add("monto");
				tfp.Columns.Add("moneda");
				tfp.Columns.Add("fecha");
				tfp.Columns.Add("observaciones");

				for (int i = 1; i <= 10; i++)
				{
					DataRow row = tfp.NewRow();
					row["id_solicitud"] = "0";
					row["nro_cuenta"] = "";
					row["banco"] = "";
					row["medio_pago"] = "";
					row["monto"] = "";
					row["moneda"] = "";
					row["fecha"] = "";
					row["observaciones"] = "";
					tfp.Rows.Add(row);
				}
				this.grdFormaPago.DataSource = tfp;
				this.grdFormaPago.DataBind();
			}
			operacion = null;
			return resp;
		}

		private void UpdateOperacionWSPeru()
		{
			System.Net.ServicePointManager.Expect100Continue = false;
			ServiceIntegracionClient ws = new ServiceIntegracionClient();
			ws.Open();
			try
			{
				string ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();
				ws.SetInformacionRetorno(ws.Encriptar(ConfigurationManager.AppSettings["wsperu_user"]),
											ws.Encriptar(ConfigurationManager.AppSettings["wsperu_pswd"]),
											ws.Encriptar(this.txtNotaPedido.Text),
											ws.Encriptar(DateTime.Now.ToShortDateString()),
											ws.Encriptar(this.txtVehPlaca.Text),
											ws.Encriptar((string)(Session["usrname"])),
											ws.Encriptar(DateTime.Now.ToShortDateString()),
											ws.Encriptar(ip));
			}
			catch (Exception ex)
			{
				UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel(ex.Message, Page, up);
			}
			ws.Close();
		}

		private void GetOperacionWSPeru()
		{
			if (this.txtNotaPedido.Text.Trim() == "") return;
			try
			{
				//FuncionGlobal.actualizar_bancos();

				System.Net.ServicePointManager.Expect100Continue = false;
				ServiceIntegracionClient ws = new ServiceIntegracionClient();
				TX_DATO_GENERAL_NOTA_PEDIDO obj = ws.GetNotaVenta(ws.Encriptar(ConfigurationManager.AppSettings["wsperu_user"]), ws.Encriptar(ConfigurationManager.AppSettings["wsperu_pswd"]), ws.Encriptar(this.txtNotaPedido.Text));

                if (obj != null)
				{
					this.txtFechaDocVenta.Text = obj.FECHA_EMISION_DOC_VENTA.ToShortDateString();
					this.txtMontoTotalVeh.Text = obj.MONTO_TOTAL_VEHICULO.ToString();
					this.txtNroDocVenta.Text = obj.NUMERO_DOCUMENTO_VENTA.Trim();
                    this.txt_vendedor.Text = obj.ASESOR_COMERCIAL.ToString();

					if (obj.TIPO_DOCUMENTO_IDENTIDAD.Trim().ToUpper() == "RUC")
					{
						this.lstTipoPersona.SelectedValue = "2";
						this.txtNroDocJur.Text = obj.NRO_DOCUMENTO_IDENTIDAD.Trim();
						this.txtNombreJur.Text = obj.RAZON_SOCIAL.Trim().ToUpper();

						FuncionGlobal.BuscarValueCombo(this.ddlTipoDocRep, obj.TIPO_DOCUMENTO_IDENTIDAD_REP_LEGAL.Trim().ToUpper());
						this.txtNombreRep.Text = obj.REPRESENTANTE_LEGAL.Trim().ToUpper();
						this.txtPaternoRep.Text = "";
						this.txtMaternoRep.Text = "";

						this.txtDomicilioCom.Text = obj.DOMICILIO_RAZON_SOCIAL.Trim().ToUpper();
					}
					else
					{
						this.lstTipoPersona.SelectedValue = "1";
						FuncionGlobal.BuscarValueCombo(this.ddlTipoDocNat, obj.TIPO_DOCUMENTO_IDENTIDAD.Trim().ToUpper());
						this.txtNroDocNat.Text = obj.NRO_DOCUMENTO_IDENTIDAD.Trim();
						FuncionGlobal.BuscarTextoCombo(this.ddlEstadoCivilNat, obj.ESTADO_CIVIL.ToUpper().Trim());
						this.txtNombreNat.Text = obj.NOMBRES.Trim().ToUpper();
						this.txtPaternoNat.Text = obj.APELLIDO_PATERNO.Trim().ToUpper();
						this.txtMaternoNat.Text = obj.APELLIDO_MATERNO.Trim().ToUpper();

						this.txtNombreRep.Text = (obj.NOMBRES_CONYUGE ?? "").Trim().ToUpper();
						this.txtPaternoRep.Text = (obj.APELLIDO_PATERNO_CONYUGE ?? "").Trim().ToUpper();
						this.txtMaternoRep.Text = (obj.APELLIDO_MATERNO_CONYUGE ?? "").Trim().ToUpper();

						this.txtDomicilioCom.Text = obj.DOMICILIO.Trim().ToUpper();
					}
					CambiarTipoPersona();

					FuncionGlobal.BuscarTextoCombo(this.ddlRegion, obj.DEPARTAMENTO.Trim().ToUpper() ?? "Seleccionar");
					FuncionGlobal.combociudad(this.ddlCiudad, Convert.ToInt16(this.ddlRegion.SelectedValue));
					FuncionGlobal.BuscarTextoCombo(this.ddlCiudad, obj.PROVINCIA.Trim().ToUpper() ?? "Seleccionar");
					FuncionGlobal.combocomuna(this.ddlComuna, Convert.ToInt16(this.ddlCiudad.SelectedValue));
					FuncionGlobal.BuscarTextoCombo(this.ddlComuna, obj.DISTRITO.Trim().ToUpper() ?? "Seleccionar");

					FuncionGlobal.BuscarTextoCombo(this.ddlFormaPago, obj.FORMA_PAGO.Trim());
					FuncionGlobal.BuscarTextoCombo(this.ddlMoneda, obj.TIPO_MONEDA);

					this.txtVehVin.Text = obj.NUMERO_VIN.Trim();
					this.txtVehSerie.Text = obj.NUMERO_SERIE_VIN.Trim();
					FuncionGlobal.BuscarTextoCombo(this.ddlVehMarca, obj.MARCA.Trim());
					this.txtVehModelo.Text = obj.MODELO.Trim();
					this.txtVehVersion.Text = obj.VERSION.Trim();
					this.txtVehAnioM.Text = obj.A_MODELO.Trim();
					this.txtVehAnioF.Text = obj.A_FABRICACION.Trim();
					//CLASE_CARROCERIA
					//this.txtVehCat.Text = obj.CLASE_CARROCERIA.Trim();
					FuncionGlobal.BuscarTextoCombo(this.ddlVehCat, obj.CLASE_CARROCERIA.Trim());
					//this.txtVehCarroceria.Text = obj.CARROCERIA.Trim();
					//this.ddlVehCarroceria.SelectedValue = obj.CARROCERIA.Trim();
					FuncionGlobal.BuscarTextoCombo(this.ddlVehCarroceria, obj.CARROCERIA.Trim());
					this.txtVehColor.Text = obj.COLOR.Trim();
					this.txtVehNroMotor.Text = obj.NUMERO_MOTOR.Trim();
					this.txtVehPotMotor.Text = obj.POTENCIA_MOTOR.Trim();
					FuncionGlobal.BuscarTextoCombo(this.ddlVehCombus, obj.COMBUSTIBLE.Trim());
					this.txtVehCilindros.Text = obj.CILINDROS.Trim();
					this.txtVehCilindrada.Text = obj.CILINDRADA.Trim();
					this.txtVehLong.Text = obj.LONGITUD.Trim();
					this.txtVehPasajeros.Text = obj.NUMERO_PASAJEROS.Trim();
					this.txtVehPesoNeto.Text = obj.PESO_NETO.Trim();
					this.txtVehCargaUtil.Text = obj.CARGA_UTIL.Trim();
					this.txtVehPesoBruto.Text = obj.PESO_BRUTO.Trim();
					this.txtVehAsientos.Text = obj.NUMERO_ASIENTO.Trim();
					this.txtVehEjes.Text = obj.NUMERO_EJES.Trim();
					this.txtVehAncho.Text = obj.ANCHO.Trim();
					this.txtVehPuertas.Text = obj.NUMERO_PUERTAS.Trim();
					this.txtVehAlto.Text = obj.ALTO.Trim();
					this.txtVehRuedas.Text = obj.NUMERO_RUEDAS.Trim();
					this.txtVehFormula.Text = obj.FORMULA_RODANTE.Trim();

					DataTable tfp = new DataTable();
					tfp.Columns.Add("id_solicitud");
					tfp.Columns.Add("nro_cuenta");
					tfp.Columns.Add("banco");
					tfp.Columns.Add("medio_pago");
					tfp.Columns.Add("monto");
					tfp.Columns.Add("moneda");
					tfp.Columns.Add("fecha");
					tfp.Columns.Add("observaciones");
                    
					if (obj.TX_DETALLE_FORMA_PAGO.Count() > 0)
					{
                
						for (int i = 0; i < obj.TX_DETALLE_FORMA_PAGO.Count(); i++)
						{
							DataRow row = tfp.NewRow();
							row["id_solicitud"] = "0";
							row["nro_cuenta"] = obj.TX_DETALLE_FORMA_PAGO[i].NUMERO_CUENTA_CORRIENTE.Trim();
							row["banco"] = (obj.TX_DETALLE_FORMA_PAGO[i].BANCO ?? "").Trim().ToUpper();
							row["medio_pago"] = (obj.TX_DETALLE_FORMA_PAGO[i].MEDIO_PAGO ?? "").Trim().ToUpper();
							row["monto"] = obj.TX_DETALLE_FORMA_PAGO[i].MONTO_ABONO.ToString();
							row["moneda"] = (obj.TX_DETALLE_FORMA_PAGO[i].MONEDA_CUENTA_BANCO ?? "").Trim().ToUpper();
							row["fecha"] = obj.TX_DETALLE_FORMA_PAGO[i].FECHA_ABONO.ToShortDateString();
							row["observaciones"] = "";
							tfp.Rows.Add(row);
						}
					}
					else
					{
						for (int i = 1; i <= 10; i++)
						{
							DataRow row = tfp.NewRow();
							row["id_solicitud"] = "0";
							row["nro_cuenta"] = "";
							row["banco"] = "";
							row["medio_pago"] = "";
							row["monto"] = "";
							row["moneda"] = "";
							row["fecha"] = "";
							row["observaciones"] = "";
							tfp.Rows.Add(row);
						}
					}

					//this.grdFormaPago.DataSource = new FormaPagoInmatriculacionBC().GetFormaPago(operacion.Operacion.Id_solicitud);
					this.grdFormaPago.DataSource = tfp;
					this.grdFormaPago.DataBind();

					obj = null;
				}
				ws.Close();
			}
			catch (Exception ex)
			{
				UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
			}
			//catch (Exception ex)
			//{
			//    //UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			//    //FuncionGlobal.alerta_updatepanel(ex.Message, Page, up);
			//    //Response.Write(Server.HtmlEncode(ex.Message));
			//}
		}

		private void AddInmatriculacion()
		{
			string nro_documento_identidad = "";
			string tipo_documento_identidad = "";
			string nombres = "";
			string apellido_paterno = "";
			string apellido_materno = "";
			string estado_civil = "";
			string inscripcion_registral = "";
			string domicilio = "";
            string vendedor = "";
			string nro_documento_identidad_rep = "";
			string tipo_documento_identidad_rep = "";
			string nombres_rep = "";
			string apellido_paterno_rep = "";
			string apellido_materno_rep = "";
           

			Int16 id_comuna;
			if (this.lstTipoPersona.SelectedValue == "1")
			{
				nro_documento_identidad = this.txtNroDocNat.Text;
				tipo_documento_identidad = this.ddlTipoDocNat.SelectedValue;
				nombres = this.txtNombreNat.Text.Trim().ToUpper();
				apellido_paterno = this.txtPaternoNat.Text.Trim().ToUpper();
				apellido_materno = this.txtMaternoNat.Text.Trim().ToUpper();
				estado_civil = this.ddlEstadoCivilNat.SelectedValue;
			}
			else
			{
				nro_documento_identidad = this.txtNroDocJur.Text;
				tipo_documento_identidad = this.ddlTipoDocJur.SelectedValue;
				nombres = this.txtNombreJur.Text.Trim().ToUpper();
			}
			domicilio = this.txtDomicilioCom.Text.Trim().ToUpper();
			id_comuna = Convert.ToInt16((this.ddlComuna.SelectedValue == "") ? "0" : this.ddlComuna.SelectedValue);

			string addc = new PersonaPeruBC().AddPersona(nro_documento_identidad, tipo_documento_identidad, nombres, apellido_paterno, apellido_materno, estado_civil, inscripcion_registral, domicilio, id_comuna);

			if (this.txtNroDocRep.Text.Trim() != "")
			{
				nro_documento_identidad_rep = this.txtNroDocRep.Text;
				tipo_documento_identidad_rep = this.ddlTipoDocRep.SelectedValue;
				nombres_rep = this.txtNombreRep.Text.Trim().ToUpper();
				apellido_paterno_rep = this.txtPaternoRep.Text.Trim().ToUpper();
				apellido_materno_rep = this.txtMaternoRep.Text.Trim().ToUpper();
			}

			if (nro_documento_identidad_rep != "")
			{
				string addr = new PersonaPeruBC().AddPersona(nro_documento_identidad_rep, tipo_documento_identidad_rep, nombres_rep, apellido_paterno_rep, apellido_materno_rep, "", "", domicilio, id_comuna);
			}

            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(this.ddlCliente.SelectedValue), this.tipo_operacion, (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.ddlSucursal.SelectedValue),0);
			if (add != 0)
			{				
				Inmatriculacion inma = new Inmatriculacion();
				inma.Operacion = new OperacionBC().getoperacion(add);
				inma.AdministradorVenta = "";
				inma.AsesorComercial = "";
				inma.CategoriaMtc = "";
				inma.Comprador = new PersonaPeruBC().GetPersona(nro_documento_identidad, tipo_documento_identidad);
				if (this.txtNroDocRep.Text.Trim() != "")
				{
					inma.Representante = new PersonaPeruBC().GetPersona(nro_documento_identidad_rep, tipo_documento_identidad_rep);
				}
				inma.TipoMoneda = this.ddlMoneda.SelectedValue;
				inma.UsoMtc = "";
				inma.FechaEmisionDocumentoVenta = Convert.ToDateTime(this.txtFechaDocVenta.Text);
				inma.MontoTotalVehiculo = Convert.ToDecimal(this.txtMontoTotalVeh.Text);
				inma.NumeroNotaPedido = this.txtNotaPedido.Text;
				inma.NumeroDocumentoVenta = this.txtNroDocVenta.Text;
				inma.UsoMtc = "";
				inma.FormaPago = this.ddlFormaPago.SelectedValue;
				inma.Sucursal = new SucursalclienteBC().getSucursal(Convert.ToInt16(this.ddlSucursal.SelectedValue));
				inma.Financiera = new BancofinancieraBC().getBancofinanciera(this.ddlFinanciera.SelectedValue);
				inma.Obs_fp = this.txtObsFP.Text.Trim();
				inma.Cargo_venta = this.ddlCargoVenta.SelectedValue.Trim();
				inma.Numero_titulo = Convert.ToDouble((this.txtNumeroTitulo.Text.Trim() != "") ? this.txtNumeroTitulo.Text.Trim() : "0");
				inma.Obs_operacion = this.txtObsOp.Text.Trim();
				inma.Partida_electronica = this.txtPartidaElectronica.Text.Trim();
				inma.Ficha_nro = this.txtFicha.Text.Trim();
				inma.Tomo = this.txtTomo.Text.Trim();
				inma.Fojas = this.txtFojas.Text.Trim();
				inma.Oficina_registral = this.txtOficinaRegistral.Text.Trim();
                inma.Separacion_bienes = this.chk_bienes.Checked;
                inma.Part_elect_bienes = this.txtPartElectBienes.Text;
                inma.Ofic_reg_bienes = this.txtOficiRegBienes.Text;
                inma.Dua = this.chk_dua.Checked;
                if (this.txt_vendedor.Text != "") { vendedor = this.txt_vendedor.Text; }
                inma.Vendedor = vendedor;
				string add_inma = new InmatriculacionBC().AddInmatriculacion(inma);
				//if (this.chk_dua.Checked == false)
				//{
				//    mensaje("La operacion " + inma.Operacion.Id_solicitud.ToString() + " le falta DUA", "Falta DUA");
				//}

				if (add_inma == "")
				{
					string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, "INMA", "", (string)(Session["usrname"]));

					//string add_veh = new DatosVehiculoPeruBC().AddVehiculo(0, add, Convert.ToInt32(this.ddlVehMarca.SelectedValue), this.txtVehVin.Text, this.txtVehSerie.Text, this.txtVehModelo.Text, this.txtVehVersion.Text, this.txtVehAnioM.Text, this.txtVehAnioF.Text, this.txtVehCat.Text, this.ddlVehCarroceria.SelectedValue, this.txtVehColor.Text, this.txtVehNroMotor.Text, this.txtVehPotMotor.Text, this.ddlVehCombus.SelectedValue, this.txtVehCilindros.Text, this.txtVehCilindrada.Text, this.txtVehLong.Text, this.txtVehPasajeros.Text, this.txtVehPesoNeto.Text, this.txtVehCargaUtil.Text, this.txtVehPesoBruto.Text, this.txtVehAsientos.Text, this.txtVehEjes.Text, this.txtVehAncho.Text, this.txtVehPuertas.Text, this.txtVehAlto.Text, this.txtVehRuedas.Text, this.txtVehFormula.Text);
					string add_veh = new DatosVehiculoPeruBC().AddVehiculo(0, add, Convert.ToInt32(this.ddlVehMarca.SelectedValue), this.txtVehVin.Text, this.txtVehSerie.Text, this.txtVehModelo.Text, this.txtVehVersion.Text, this.txtVehAnioM.Text, this.txtVehAnioF.Text, "", this.ddlVehCarroceria.SelectedValue, this.txtVehColor.Text, this.txtVehNroMotor.Text, this.txtVehPotMotor.Text, this.ddlVehCombus.SelectedValue, this.txtVehCilindros.Text, this.txtVehCilindrada.Text, this.txtVehLong.Text, this.txtVehPasajeros.Text, this.txtVehPesoNeto.Text, this.txtVehCargaUtil.Text, this.txtVehPesoBruto.Text, this.txtVehAsientos.Text, this.txtVehEjes.Text, this.txtVehAncho.Text, this.txtVehPuertas.Text, this.txtVehAlto.Text, this.txtVehRuedas.Text, this.txtVehFormula.Text, Convert.ToInt32(this.ddlVehCat.SelectedValue), this.txtVehPlaca.Text.Trim());

					var query = from r in this.grdFormaPago.Rows.OfType<GridViewRow>()
								where r.RowType == DataControlRowType.DataRow &&
								((TextBox)r.FindControl("txtNCuenta")).Text.Trim() != "" &&
								(((DropDownList)r.FindControl("ddlMedioPago")).SelectedValue != "" || ((DropDownList)r.FindControl("ddlMedioPago")).SelectedValue != "0") &&
								((TextBox)r.FindControl("txtMonto")).Text.Trim() != "" &&
								((TextBox)r.FindControl("txtFecha")).Text.Trim() != "" &&
								(((DropDownList)r.FindControl("ddlBanco")).SelectedValue != "" || ((DropDownList)r.FindControl("ddlBanco")).SelectedValue != "0") &&
								(((DropDownList)r.FindControl("ddlMoneda")).SelectedValue != "" || ((DropDownList)r.FindControl("ddlMoneda")).SelectedValue != "0")
								select r;
					if (query.Count() > 0)
					{
						new FormaPagoInmatriculacionBC().DelFormaPago(add);
						foreach (GridViewRow dr in query)
						{
							string numero_cuenta_corriente = ((TextBox)dr.FindControl("txtNCuenta")).Text;
							string id_formapago = ((DropDownList)dr.FindControl("ddlMedioPago")).SelectedValue;
							string monto_abono = ((TextBox)dr.FindControl("txtMonto")).Text;
							string fecha_abono = ((TextBox)dr.FindControl("txtFecha")).Text;
							string banco = ((DropDownList)dr.FindControl("ddlBanco")).SelectedValue;
							string moneda = ((DropDownList)dr.FindControl("ddlMoneda")).SelectedValue;
							string observaciones = ((TextBox)dr.FindControl("txtObservaciones")).Text;

							string addfp = new FormaPagoInmatriculacionBC().AddFormaPago(add, numero_cuenta_corriente, Convert.ToInt32(id_formapago), Convert.ToDouble(monto_abono), Convert.ToDateTime(fecha_abono), banco, moneda, observaciones);
						}
					}
				}

				if (Session["numero_placa"].ToString().ToUpper().Trim() != this.txtVehPlaca.Text.ToUpper().Trim())
				{
					UpdateOperacionWSPeru();
				}

				GetOperacionById(add);
			}
		}

		private bool ValidarDatos()
		{
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			if (this.ddlSucursal.SelectedValue == "0" || this.ddlSucursal.SelectedValue == "")
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar la sucursal", Page, up);
				this.ddlSucursal.Focus();
				return false;
			}
			if (this.ddlComuna.SelectedValue == "0" || this.ddlComuna.SelectedValue == "")
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar el distrito para el comprador", Page, up);
				this.ddlComuna.Focus();
				return false;
			}
            if (this.ddlFinanciera.SelectedValue == "0" || this.ddlFinanciera.SelectedValue == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la entidad financiera", Page, up);
                this.ddlFinanciera.Focus();
                return false;
            }
			if (this.lstTipoPersona.SelectedValue == "1" && (this.ddlEstadoCivilNat.SelectedValue == "0" || this.ddlEstadoCivilNat.SelectedValue == ""))
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar el estado civil para el comprador", Page, up);
				this.ddlEstadoCivilNat.Focus();
				return false;
			}
            if (this.txtNroDocRep.Text.Trim() != "" && this.ddlTipoDocRep.SelectedValue.ToString() == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar el tipo de documento para el representante", Page, up);
                this.ddlTipoDocRep.Focus();
                return false;
            }
            if (this.txtFechaDocVenta.Text == "" )
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la fecha del documento de venta", Page, up);
                this.txtFechaDocVenta.Focus();
                return false;
            }
            if (this.txtMontoTotalVeh.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar el monto total del vehiculo", Page, up);
                this.txtMontoTotalVeh.Focus();
                return false;
            }
			//if (this.ddlFormaPago.SelectedValue == "0" || this.ddlFormaPago.SelectedValue == "")
			//{
			//    FuncionGlobal.alerta_updatepanel("Debe ingresar la forma de pago", Page, up);
			//    this.ddlFormaPago.Focus();
			//    return false;
			//}
			//if (this.ddlFinanciera.SelectedValue == "0" || this.ddlFinanciera.SelectedValue == "")
			//{
			//    FuncionGlobal.alerta_updatepanel("Debe ingresar la entidad financiera", Page, up);
			//    this.ddlFinanciera.Focus();
			//    return false;
			//}
			if (this.ddlCargoVenta.SelectedValue == "0" || this.ddlCargoVenta.SelectedValue == "")
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar el cargo de la venta", Page, up);
				this.ddlCargoVenta.Focus();
				return false;
			}
			if (this.ddlVehCat.SelectedValue == "0" || this.ddlVehCat.SelectedValue == "")
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar la categoría del vehículo", Page, up);
				this.ddlVehCat.Focus();
				return false;
			}
            if (this.ddlVehMarca.SelectedValue == "0" || this.ddlVehMarca.SelectedValue == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la marca del vehículo", Page, up);
                this.ddlVehMarca.Focus();
                return false;
            }
            if (this.ddlVehCarroceria.SelectedValue == "0" || this.ddlVehCarroceria.SelectedValue == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la carroceria del vehículo", Page, up);
                this.ddlVehCarroceria.Focus();
                return false;
            }
            if (this.ddlVehCombus.SelectedValue == "0" || this.ddlVehCombus.SelectedValue == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar el Combustible del vehículo", Page, up);
                this.ddlVehCombus.Focus();
                return false;
            }

			return true;
		}

		protected void txtNroDocNat_TextChanged(object sender, EventArgs e)
		{
			BuscarPersonaNat(false);
		}

		private void BuscarPersonaNat(bool representante)
		{
			string tipo_documento = "";
			string nro_documento = "";
			if (!representante)
			{
				tipo_documento = this.ddlTipoDocNat.SelectedValue;
				nro_documento = this.txtNroDocNat.Text.Trim();
			}
			else
			{
				tipo_documento = this.ddlTipoDocRep.SelectedValue;
				nro_documento = this.txtNroDocRep.Text.Trim();
			}
			if (tipo_documento != "0" && nro_documento != "")
			{
				PersonaPeru per = new PersonaPeruBC().GetPersona(nro_documento, tipo_documento);
				if (per.Nombres != null)
				{
					if (!representante)
					{
						this.txtNombreNat.Text = per.Nombres;
						this.txtPaternoNat.Text = per.ApellidoPaterno;
						this.txtMaternoNat.Text = per.ApellidoMaterno;
						this.txtDomicilioCom.Text = per.Domicilio;
						this.ddlEstadoCivilNat.SelectedValue = per.EstadoCivil.Trim();
						this.ddlRegion.SelectedValue = per.Comuna.Ciudad.Region.Id_region.ToString();
						FuncionGlobal.combociudad(this.ddlCiudad, Convert.ToInt16(this.ddlRegion.SelectedValue));
						this.ddlCiudad.SelectedValue = per.Comuna.Ciudad.Id_Ciudad.ToString();
						FuncionGlobal.combocomuna(this.ddlComuna, Convert.ToInt16(this.ddlCiudad.SelectedValue));
						this.ddlComuna.SelectedValue = per.Comuna.Id_Comuna.ToString();
					}
					else
					{
						this.txtNombreRep.Text = per.Nombres;
						this.txtPaternoRep.Text = per.ApellidoPaterno;
						this.txtMaternoRep.Text = per.ApellidoMaterno;
					}
				}
			}
		}

		protected void ddlTipoDocNat_SelectedIndexChanged(object sender, EventArgs e)
		{
			BuscarPersonaNat(false);
		}

		protected void ddlTipoDocJur_SelectedIndexChanged(object sender, EventArgs e)
		{
			BuscarPersonaJur();
		}

		protected void txtNroDocJur_TextChanged(object sender, EventArgs e)
		{
			BuscarPersonaJur();
		}

		private void BuscarPersonaJur()
		{
			if (this.ddlTipoDocJur.SelectedValue != "0" && this.txtNroDocJur.Text != "")
			{
				PersonaPeru per = new PersonaPeruBC().GetPersona(this.txtNroDocJur.Text, this.ddlTipoDocJur.SelectedValue);
				if (per.Nombres != null)
				{
					this.txtNombreJur.Text = per.Nombres;
					this.txtDomicilioCom.Text = per.Domicilio;
					this.ddlRegion.SelectedValue = per.Comuna.Ciudad.Region.Id_region.ToString();
					FuncionGlobal.combociudad(this.ddlCiudad, Convert.ToInt16(this.ddlRegion.SelectedValue));
					//this.ddlCiudad.SelectedValue = per.Comuna.Ciudad.Id_Ciudad.ToString();
					FuncionGlobal.BuscarValueCombo(this.ddlCiudad, this.ddlRegion.SelectedValue);
					FuncionGlobal.combocomuna(this.ddlComuna, Convert.ToInt16(this.ddlCiudad.SelectedValue));
					//this.ddlCiudad.SelectedValue = per.Comuna.Id_Comuna.ToString();
					FuncionGlobal.BuscarValueCombo(this.ddlComuna, this.ddlCiudad.SelectedValue);
				}
			}
		}

		protected void ddlTipoDocRep_SelectedIndexChanged(object sender, EventArgs e)
		{
			BuscarPersonaNat(true);
		}

		protected void txtNroDocRep_TextChanged(object sender, EventArgs e)
		{
			BuscarPersonaNat(true);
		}

		protected void grdFormaPago_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				string banco = this.grdFormaPago.DataKeys[e.Row.RowIndex].Values[1].ToString().Trim();
				string medio_pago = this.grdFormaPago.DataKeys[e.Row.RowIndex].Values[2].ToString().Trim();
				string moneda = this.grdFormaPago.DataKeys[e.Row.RowIndex].Values[3].ToString().Trim();

				DropDownList ddl = (DropDownList)e.Row.FindControl("ddlBanco");
				try
				{
					FuncionGlobal.combobanco(ddl,Convert.ToInt32(id_cliente));
					FuncionGlobal.BuscarTextoCombo(ddl, banco);
				}
				catch (Exception ex)
				{
					UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
					FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
				}

				ddl = (DropDownList)e.Row.FindControl("ddlMedioPago");
				try{
					FuncionGlobal.combotipoformapago(ddl);
					FuncionGlobal.BuscarTextoCombo(ddl, medio_pago);
				}
				catch (Exception ex)
				{
					UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
					FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
				}

				ddl = (DropDownList)e.Row.FindControl("ddlMoneda");
				try{
					FuncionGlobal.combotipomoneda(ddl);
					FuncionGlobal.BuscarTextoCombo(ddl, moneda);
				}
				catch (Exception ex)
				{
					UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
					FuncionGlobal.alerta_updatepanel(ex.Message.Replace("\n", ""), Page, up);
				}
			}
		}

     
        protected void rdb_dua_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtPartElectBienes_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtOficiRegBienes_TextChanged(object sender, EventArgs e)
        {

        }

        protected void mensaje(string mensaje, string asunto)
        {
            Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            Mail.Mail mail = new Mail.Mail();
            StringBuilder strBody = new StringBuilder();
            strBody.AppendLine("Estimado Usuario");
            strBody.AppendLine("");
            strBody.AppendLine(mensaje);
            strBody.AppendLine("");
            strBody.AppendLine("Atte.");
            strBody.AppendLine(musuario.Nombre);
			mail.SendMail("s.miyake@gypsa.com.pe", "", asunto, strBody.ToString());

        }

        protected void chk_bienes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_bienes.Checked == true)
            {
                this.pnlDatosBienes.Visible = true;
                this.pnlRepresentante.Visible = false;
            }
            else
            {
                this.pnlDatosBienes.Visible = false;
                this.pnlRepresentante.Visible = true;
            }
        }

        protected void chk_dua_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtvendedor_TextChanged(object sender, EventArgs e)
        {

        }
	}
}