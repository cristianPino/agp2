using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace sistemaAGP
{
    public partial class ingreso_contrato_Porsche : System.Web.UI.Page
	{

		private Int32 id_solicitud;
		private Int16 id_cliente;
		private string vent = "";
		private string tipo_operacion;
		private string patente = "";
		private Int32 id_dat_veh = 0;


		protected void Page_Load(object sender, EventArgs e)
		{
			this.Datoscomprador.OnActivarCompraPara += new wucPersonaEventHandler(agpdatoscomprador_OnActivarCompraPara);

			this.Datosvendedor.OnClickDireccion += new wucBotonEventHandler(Datosvendedor_OnClickDireccion);
			this.Datosvendedor.OnClickTelefono += new wucBotonEventHandler(Datosvendedor_OnClickTelefono);
			this.Datosvendedor.OnClickCorreo += new wucBotonEventHandler(Datosvendedor_OnClickCorreo);
			this.Datosvendedor.OnClickParticipante += new wucBotonEventHandler(Datosvendedor_OnClickParticipante);

			this.Datoscomprador.OnClickDireccion += new wucBotonEventHandler(Datoscomprador_OnClickDireccion);
			this.Datoscomprador.OnClickTelefono += new wucBotonEventHandler(Datoscomprador_OnClickTelefono);
			this.Datoscomprador.OnClickCorreo += new wucBotonEventHandler(Datoscomprador_OnClickCorreo);
			this.Datoscomprador.OnClickParticipante += new wucBotonEventHandler(Datoscomprador_OnClickParticipante);

			this.agpCompraPara.OnClickDireccion += new wucBotonEventHandler(agpCompraPara_OnClickDireccion);
			this.agpCompraPara.OnClickTelefono += new wucBotonEventHandler(agpCompraPara_OnClickTelefono);
			this.agpCompraPara.OnClickCorreo += new wucBotonEventHandler(agpCompraPara_OnClickCorreo);
			this.agpCompraPara.OnClickParticipante += new wucBotonEventHandler(agpCompraPara_OnClickParticipante);

			id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString()));
			id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString()));
			tipo_operacion = Request.QueryString["tipo_operacion"].ToString();
			patente = Request.QueryString["patente"].ToString();
			vent = Request.QueryString["ventatipo"].ToString();
			cambiar_titulo();

			this.txt_precio.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");
			this.txt_kilometraje.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");
			this.txt_tasacion.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");
			this.txt_valor_cesion.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");
			this.txt_valor_opcion.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");

            if (id_cliente != 15)
            {
                tdFactura.Visible = false;
                tdTxtFactura.Visible = false;
            }
            if (id_cliente == 15 || id_cliente==4)
            {
                tdFactura.Visible = true;
                tdTxtFactura.Visible = true;
            }

		    if (!IsPostBack)
			{


                FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
                FuncionGlobal.combomarcavehiculo(this.dl_marca_vehiculo);
                FuncionGlobal.comboparametro(this.dl_combustible, "COMB");

                if (Session["id_dato"] == null)
					Session.Add("id_dato", "0");

				this.id_leasing.Visible = false;
				this.lbl_numero.Text = "0";
				if (tipo_operacion == "CVT" || tipo_operacion == "CVEN" || tipo_operacion == "CCV")
				{
					this.chk_leasing.Visible = true;
				}

                if (tipo_operacion == "CTM")
                {
                    this.dl_forma_pago.SelectedValue = "1";
                    FuncionGlobal.combobanco(this.dl_financiera, id_cliente);
                    this.dl_financiera.SelectedValue = "CON";
                    this.dl_financiera.Enabled = false;
                    this.dl_forma_pago.Enabled = false;
                }


				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = id_cliente.ToString();
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
                //FuncionGlobal.comboparametro(this.dl_forma_pago, "FOPA");
               
                FuncionGlobal.comboparametro(this.dl_tag, "TAG");


                if (vent == "")
                { dato_tipo(); }
                
				if (id_solicitud != 0)
				{ busca_operacion(); }
				carga_manual();


			}

		}
		protected void agpdatoscomprador_OnActivarCompraPara(object sender, wucPersonaEventArgs e)
		{
			this.agpCompraPara.Visible = e.Activar;
		}
		protected void cambiar_titulo()
		{
			TipoOperacion p = new TipooperacionBC().getTipooperacion(this.tipo_operacion);
			this.Title = p.Operacion;
			this.lbl_titulo.Text = p.Operacion;
			p = null;
		}

		protected void Datoscomprador_OnClickParticipante(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}

		protected void agpCompraPara_OnClickParticipante(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}

		protected void Datosvendedor_OnClickParticipante(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}
		protected void Datosvendedor_OnClickDireccion(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}

		protected void Datosvendedor_OnClickTelefono(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
		}

		protected void Datosvendedor_OnClickCorreo(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
		}

		protected void Datoscomprador_OnClickDireccion(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}

		protected void Datoscomprador_OnClickTelefono(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
		}

		protected void Datoscomprador_OnClickCorreo(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
		}

		protected void agpCompraPara_OnClickDireccion(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}

		protected void agpCompraPara_OnClickTelefono(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
		}

		protected void agpCompraPara_OnClickCorreo(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
		}

		private void dato_tipo()
		{
            if (tipo_operacion == "TRCAR")
            {

                this.Datoscomprador.Mostrar_Form(Convert.ToInt32(96630680));
                this.Datoscomprador.HabilitarCompraPara = true;
                this.Datoscomprador.HabilitarCorreo = true;
                this.Datoscomprador.HabilitarDireccion = true;
                this.Datoscomprador.HabilitarTelefono = true;
                this.Datosvendedor.HabilitarParticipante = true;
                this.Datoscomprador.HabilitarParticipante = false;

                this.Datosvendedor.Mostrar_Form(Convert.ToInt32(96510300));
                this.Datosvendedor.HabilitarCompraPara = true;
                this.Datosvendedor.HabilitarCorreo = true;
                this.Datosvendedor.HabilitarDireccion = true;
                this.Datosvendedor.HabilitarTelefono = true;
                this.Datosvendedor.HabilitarParticipante = true;
                this.Datosvendedor.HabilitarParticipante = false;

            }


			if (tipo_operacion == "CTM")
			{
				Cliente mcliente = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
				this.Datoscomprador.Mostrar_Form(mcliente.Persona.Rut);
				this.Datoscomprador.HabilitarCompraPara = true;
				this.Datoscomprador.HabilitarCorreo = true;
				this.Datoscomprador.HabilitarDireccion = true;
				this.Datoscomprador.HabilitarTelefono = true;
				this.Datosvendedor.HabilitarParticipante = true;
				this.Datoscomprador.HabilitarParticipante = false;

			}
			if (tipo_operacion == "CTC" || tipo_operacion == "CTMAG")
			{
				this.Datoscomprador.Visible = false;
				this.Datoscomprador.HabilitarCompraPara = false;
				this.Datoscomprador.HabilitarCorreo = false;
				this.Datoscomprador.HabilitarDireccion = false;
				this.Datoscomprador.HabilitarTelefono = false;
				this.Datosvendedor.HabilitarParticipante = true;
				this.Datoscomprador.HabilitarParticipante = false;
			}
			if (tipo_operacion == "CCV")
			{
				this.Datoscomprador.Visible = true;
				this.Datoscomprador.HabilitarCompraPara = true;
				this.Datoscomprador.HabilitarCorreo = true;
				this.Datoscomprador.HabilitarDireccion = true;
				this.Datoscomprador.HabilitarTelefono = true;
				this.Datoscomprador.HabilitarParticipante = true;
				this.Datosvendedor.HabilitarParticipante = true;
			}
			if (tipo_operacion == "CVT" || tipo_operacion == "CVEN")
			{
				Cliente mcliente = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
				this.Datosvendedor.Mostrar_Form(mcliente.Persona.Rut);

			}
		}
		private void busca_operacion()
		{
			Transferencia mtransferencia = new TransferenciaBC().GettransferenciabyIdSolicitud(id_solicitud);


			if (mtransferencia != null)
			{
                this.dl_forma_pago.SelectedValue = mtransferencia.Forma_pago.Trim();

                if (mtransferencia.Banco_financiera != null)
                {
                    if (id_cliente == 4 && mtransferencia.Forma_pago.Trim() != "1" || id_cliente == 3 && mtransferencia.Forma_pago.Trim() != "1")
                    {
                        this.dl_financiera.Items.Clear();

                        DataTable dt;
                        dt = new DataTable("Tabla");

                        dt.Columns.Add("Codigo");
                        dt.Columns.Add("Descripcion");

                        DataRow dr;

                        dr = dt.NewRow();
                        dr["Codigo"] = "TANN";
                        dr[1] = "TANNER";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "SCO";
                        dr[1] = "BANCO SCOTIABANK";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "FOR";
                        dr[1] = "FORUM";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "MITS";
                        dr[1] = "MITSUI";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "BFALA";
                        dr[1] = "BANCO FALABELLA";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "SAN";
                        dr[1] = "SANTANDER CONSUMER";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "BCI";
                        dr[1] = "BANCO CREDITO E INVERSIONES";
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr[0] = "MCRE ";
                        dr[1] = "MARUBENI CREDIT";
                        dt.Rows.Add(dr);

                        this.dl_financiera.DataSource = dt;
                        this.dl_financiera.DataValueField = "Codigo";
                        this.dl_financiera.DataTextField = "Descripcion";
                        this.dl_financiera.DataBind();

                        this.dl_financiera.Enabled = true;
                    }
                    else
                    {
                        FuncionGlobal.combobanco(this.dl_financiera, id_cliente);
                    }
                    this.dl_financiera.SelectedValue = mtransferencia.Banco_financiera.Codigo.Trim();
                }

                this.txt_numero_emisor.Text = mtransferencia.Operacion.Numero_cliente.Trim();    

				if (vent == "CTC" || vent == "" || vent == "CTMAG")
				{
					this.lbl_operacion.Visible = true;
					this.lbl_numero.Visible = true;
					this.lbl_operacion.Text = "Operación de Transferencia Numero:";
					this.lbl_numero.Text = Convert.ToString(mtransferencia.Operacion.Id_solicitud);
                    
				}

                this.dl_tag.SelectedValue = mtransferencia.Tag;
				this.dl_cliente.SelectedValue = Convert.ToString(mtransferencia.Operacion.Cliente.Id_cliente);
				this.dl_sucursal_origen.SelectedValue = mtransferencia.Id_sucursal.ToString();

				Leasing_transferencia lleasing = new Leasing_transferenciaBC().getLeasingById(id_solicitud);
				if (lleasing != null)
				{
					this.id_datounico.Visible = true;
					this.txt_precio.Enabled = true;
					this.id_leasing.Visible = true;
					chk_leasing.Checked = true;
                    this.txt_n_contrato.Text = lleasing.N_contrato.ToString();
                    this.txt_n_vehiculos.Text = lleasing.N_vehiculos.ToString();
                    this.txt_valor_cesion.Text = lleasing.Valor_cesion.ToString();
                    this.txt_valor_opcion.Text = lleasing.Valor_opcion.ToString();
                    this.txt_fecha_contrato.Text = lleasing.Fecha_contrato.ToString("dd-MM-yyyy");    
				}
				
					DatosVehiculo mdatosvehiculo = new DatosvehiculoBC().getDatovehiculo(id_solicitud);

					this.txt_patente.Text = mdatosvehiculo.Patente.Trim();
					this.txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(mdatosvehiculo.Patente.Trim());
					this.txt_kilometraje.Text = FuncionGlobal.NumeroConFormato(mdatosvehiculo.Kilometraje.ToString());
					this.txt_tasacion.Text = FuncionGlobal.NumeroConFormato(mdatosvehiculo.Tasacion.ToString());
                    this.txt_modelo.Text = mdatosvehiculo.Modelo;
                    this.txt_p_bruto.Text = mdatosvehiculo.Pesobruto.ToString();
                    this.txt_motor.Text = mdatosvehiculo.Motor;
                    this.txt_color.Text = mdatosvehiculo.Color;
                    this.txt_anno.Text = mdatosvehiculo.Ano.ToString();
                    this.txt_chassis.Text = mdatosvehiculo.Chassis;
                    this.dl_tipo_vehiculo.SelectedValue = mdatosvehiculo.Tipo_vehiculo.ToString();
                    this.dl_marca_vehiculo.SelectedValue = mdatosvehiculo.Marca.Id_marca.ToString();
                    this.dl_combustible.SelectedValue = mdatosvehiculo.Combustible.ToString();
                    
					this.lbl_codigo.Text = (mdatosvehiculo.Codigo_SII ?? "").Trim();
                    if (vent != "CTM" && vent != "CTC")
                    {
                        this.txt_precio.Text = FuncionGlobal.NumeroConFormato(mdatosvehiculo.Precio.ToString());
                    }
                  
				}



				if (mtransferencia.Vendedor != null)
				{
					if (vent == "CTM")
					{
						this.Datosvendedor.Mostrar_Form(mtransferencia.Comprador.Rut);
					}
					else
					{
						this.Datosvendedor.Mostrar_Form(mtransferencia.Vendedor.Rut);
					}
				}

				if (mtransferencia.Comprador != null)
				{
					if (vent == "")
					{
						this.Datoscomprador.Mostrar_Form(mtransferencia.Comprador.Rut);
					}
				}

				if (mtransferencia.Compra_para != null)
				{
					this.Datoscomprador.setCompraPara(true);
					this.agpCompraPara.Visible = true;
					this.agpCompraPara.Mostrar_Form(mtransferencia.Compra_para.Rut);

				}


			

		}




		private void add()
		{
			string rutcomp = "0";
			string rutvend = "0";
			string rutcompp = "0";
            string financiamiento = "0";
			
			
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			double rut2 = this.Datoscomprador.getRut();
			List<Direcciones> ldireccion = new DireccionesBC().getdirecciones(Convert.ToInt32(rut2));

            if (this.dl_forma_pago.SelectedValue == "2" & this.dl_financiera.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Debe seleccionar un banco o financiera", Page, up);
                return;

            }

            if (id_cliente == 3 || id_cliente == 4)
            {
                if (tipo_operacion == "CVT")
                {
                    if (this.dl_forma_pago.SelectedValue == "0")
                    {
                        FuncionGlobal.alerta_updatepanel("Debe seleccionar forma de pago", Page, up);
                        return;
                    }
                }
            }
                  


			if (vent == "CTC" || vent == "CTMAG")
			{
				Cliente mcliente = new ClienteBC().getclienteusuario(this.Datoscomprador.getRut(), (string)(Session["usrname"]));
				if (vent == "CTC" &&  mcliente.Check == true || vent == "CTMAG" && mcliente.Check == true)
				{
					tipo_operacion = "CTM";
				}
				else
				{
                    if (vent == "CTC")
                    {
                        tipo_operacion = "CCV";
                    }
                    else
                    {
                        tipo_operacion = "CVEN";
                    }
					if (ldireccion.Count == 0)
					{
						FuncionGlobal.alerta_updatepanel("El comprador no tiene direccion", Page, up);
						return;
					}
				}


			}

			if (tipo_operacion != "CTC" || tipo_operacion != "CTMAG")
			{
				if (this.Datoscomprador.Guardar_Form())
				{
					if (this.Datoscomprador.InfoPersona != null)
					{
						rutcomp = this.Datoscomprador.InfoPersona.Rut.ToString();
					}
				}
			}
			if (this.Datosvendedor.Guardar_Form())
			{
				if (this.Datosvendedor.InfoPersona != null)
				{
					rutvend = this.Datosvendedor.InfoPersona.Rut.ToString();
				}
			}

			if (this.agpCompraPara.Guardar_Form())
			{
				if (this.agpCompraPara.InfoPersona != null)
				{
					rutcompp = this.agpCompraPara.InfoPersona.Rut.ToString();
				}
			}

            int factura=0;

            if(this.txtNumFactura.Text !="")
            {
                factura = Convert.ToInt32(txtNumFactura.Text);
            }

		    Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text),
		                                                Convert.ToInt16(this.dl_cliente.SelectedValue), tipo_operacion,
		                                                (string) (Session["usrname"]), 0, this.txt_numero_emisor.Text.Trim(),
		                                                Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),factura );

            if (tipo_operacion != "CVT")
            {
                this.id_solicitud = Convert.ToInt32(this.lbl_numero.Text);
            }
            else
            {
                if (this.lbl_numero.Visible == true)
                {
                    this.id_solicitud = Convert.ToInt32(this.lbl_numero.Text);
                }
            }

			if (chk_leasing.Checked == true)
            {
                string leasing = new Leasing_transferenciaBC().add_leasing(add,
                                                                this.txt_patente.Text.Trim(),
                                                                Convert.ToInt32(this.txt_n_contrato.Text),
                                                                Convert.ToDateTime(this.txt_fecha_contrato.Text),
                                                                Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_valor_opcion.Text)),
                                                                Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_valor_cesion.Text)),
                                                                Convert.ToInt32(this.txt_n_vehiculos.Text));
            }
                    DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculobyPatente_id_solicitud(this.txt_patente.Text.Trim(), id_solicitud);
                    //DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculobypatente(this.txt_patente.Text);

                    Marcavehiculo marca = new MarcavehiculoBC().getmarcavehiculo(69);
                    Tipovehiculo tipvehi = new TipovehiculoBC().getTipoVehiculo("PDF");
                    Int32 id_dato_vehiculo = 0;
                    Int32 rut_prenda = 0;
                    if (mdato != null && id_solicitud!= 0)
                    {
                        if (vent == "CTM")
                        {
                            marca = mdato.Marca;
                            tipvehi = mdato.Tipo_vehiculo;
                            id_dato_vehiculo = 0;
                        }
                        else
                        {
                            rut_prenda = mdato.Rut_prenda;
                            id_dato_vehiculo = mdato.Id_dato_vehiculo;
                            marca = mdato.Marca;
                            tipvehi = mdato.Tipo_vehiculo;
                        }
                    }

                DatosVehiculo mdato2;
                if (id_dato_vehiculo != 0)
                {
                    mdato2 = new DatosvehiculoBC().getDatovehiculobyPatente_id_solicitud(this.txt_patente.Text.Trim(), id_solicitud);
                }
                else
                {
                    mdato2 = new DatosvehiculoBC().getDatovehiculobypatente(this.txt_patente.Text);

                }
                if (mdato2 != null)
                {
                    string datovehi = new DatosvehiculoBC().add_Datosvehiculo(add,
                                                                            mdato2.Marca,
                                                                            mdato2.Tipo_vehiculo,
                                                                            txt_patente.Text,
                                                                            FuncionGlobal.digitoVerificadorPatente(txt_patente.Text),
                                                                            mdato2.Modelo, mdato2.Chassis, mdato2.Motor, mdato2.Vin, mdato2.Serie, Convert.ToInt32(mdato2.Ano), "", mdato2.Color, 0, 0, "", 0, 0,
                                                                            Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_kilometraje.Text)),
                                                                            Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_tasacion.Text)),
                                                                            lbl_codigo.Text, Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_precio.Text)),
                                                                            Convert.ToInt32(id_dato_vehiculo), DateTime.Now, "", "false", "", 0, financiamiento,mdato2.Transmision,mdato2.Equipamiento);

                }
                else
                {
                    if (this.dl_marca_vehiculo.SelectedValue != "0")
                    {
                        marca = new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue));
                    }
                    if (this.dl_tipo_vehiculo.SelectedValue != "0")
                    {
                        tipvehi = new TipovehiculoBC().getTipoVehiculo(this.dl_tipo_vehiculo.SelectedValue);
                    }
                    
                    string datovehi = new DatosvehiculoBC().add_Datosvehiculo(add,
                                                                                marca,
                                                                               tipvehi,
                                                                                txt_patente.Text,
                                                                                FuncionGlobal.digitoVerificadorPatente(txt_patente.Text),
                                                                                this.txt_modelo.Text, this.txt_chassis.Text, this.txt_motor.Text, "", "",Convert.ToInt32(this.txt_anno.Text), "",this.txt_color.Text, 0,Convert.ToInt32(this.txt_p_bruto.Text),this.dl_combustible.SelectedValue, 0, 0,
                                                                                Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_kilometraje.Text)),
                                                                                Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_tasacion.Text)),
                                                                                lbl_codigo.Text, Convert.ToInt32(FuncionGlobal.NumeroSinFormato(txt_precio.Text)), id_dato_vehiculo, DateTime.Now,
                                                                                "", "false", "", 0, financiamiento.Trim(), this.dl_financiera.SelectedValue,"0","0");
                }
                if (vent == "")
                {
                    DatosVehiculo vehicu = new DatosvehiculoBC().getDatovehiculobyPatente_id_solicitud (this.txt_patente.Text,add);
                    if (tipo_operacion == "CTMAG")
                    {
                        string add_stock = new StockVentasBC().add_sotckventas(add, 0, "false", vehicu.Id_dato_vehiculo, false);
                    }
                    else
                    {
                        string add_stock = new StockVentasBC().add_sotckventas(add, 0, "false", vehicu.Id_dato_vehiculo, true);
                    }
                }
                else
                {
                    DatosVehiculo vehicu = new DatosvehiculoBC().getDatovehiculo(id_solicitud);
                    if (vent == "CTC" || vent == "CTMAG")
                    {
                        Cliente mcliente = new ClienteBC().getclienteusuario(this.Datoscomprador.InfoPersona.Rut, (string)(Session["usrname"]));
                        if (vent == "CTC" && mcliente.Check == true || vent == "CTMAG")
                        {
                            string add_stock = new StockVentasBC().add_sotckventas(id_solicitud, add, "false", vehicu.Id_dato_vehiculo, true);
                        }
                        else
                        {
                            string add_stock = new StockVentasBC().add_sotckventas(id_solicitud, add, "true", vehicu.Id_dato_vehiculo, true);
                        }
                    }
                    else
                    {
                        string add_stock = new StockVentasBC().add_sotckventas(id_solicitud, add, "true", vehicu.Id_dato_vehiculo, true);
                    }
                }
           
			if (add != 0)
			{
			    string add_TR = new TransferenciaBC().add_Transferencia(add,
			                                                            Convert.ToDouble(rutvend),
			                                                            Convert.ToDouble(rutcomp),
			                                                            Convert.ToDouble(rutcompp),
			                                                            Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),
			                                                            this.dl_tag.SelectedValue,
			                                                            this.dl_financiera.SelectedValue,
			                                                            this.dl_forma_pago.SelectedValue
			        );



				if (add_TR == "" && vent != "CTC" || vent != "CTMAG")
				{
					string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));
				}

			}



			this.lbl_operacion.Visible = true;
			this.lbl_numero.Visible = true;
			this.lbl_operacion.Text = "Operación de Transferencia Numero:";
			this.lbl_numero.Text = Convert.ToString(add);
		
			FuncionGlobal.alerta("CONTRATO DE TRANSFERENCIA, INGRESADO CON EXITO", Page);

            }
		
		protected void ib_busca_sii_Click(object sender, ImageClickEventArgs e)
		{
			if (this.txt_sii.Text.Trim() != "")
			{
				busca_sii();

			}
		}

		private void busca_sii()
		{
			List<TasacionSII> ltasa = new TasacionSIIBC().GetTasacionbydatos(this.txt_sii.Text.Trim(), "", "", 0);


			this.gr_dato.DataSource = ltasa;
			this.gr_dato.DataBind();
			this.ModalPopupExtender.Show();

		}
		private void carga_manual()
		{
			Usuario musu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
			if (musu.Codigoperfil.Trim() == "VEN")
			{
				this.lnk_manual.NavigateUrl = "~/imagenes/Manual_Transferencia.pdf";
			}
			else
			{
				this.lnk_manual.NavigateUrl = "~/imagenes/Manual_toma.pdf";
			}
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow row = gr_dato.SelectedRow;

			Int32 valor;
			valor = Convert.ToInt32(row.Cells[8].Text);

			this.txt_tasacion.Text = FuncionGlobal.NumeroConFormato(valor.ToString());
			this.lbl_codigo.Text = this.txt_sii.Text.Trim();
		}


		protected void bt_guardar_Click2(object sender, EventArgs e)
		{
			

		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            if (tipo_operacion == "CVT" || tipo_operacion == "CCV")
            {
                Correo mcorreo = new CorreoBC().getCorreoPorDefecto(Convert.ToInt32(this.Datoscomprador.getRut().ToString()));

                if (mcorreo == null)
                {
                    FuncionGlobal.alerta_updatepanel(
                        "Vendedor: En esta venta debe ingresar el correo del Comprador, o ingresar su correo Personal",
                        Page, up);
                    return;
                }
            }

		    if (!this.chk_leasing.Checked)
			{
				if (this.txt_patente.Text.Trim() == "")
				{
					FuncionGlobal.alerta_updatepanel("Debe ingresar la patente", Page, up);
					return;
				}
			}

			if (this.dl_sucursal_origen.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese la Sucursal de origen", Page, up);
                return;
			}
          

            double rut_vendedor = this.Datosvendedor.getRut();
         
            List<Direcciones> ldireccion_vendedor = new DireccionesBC().getdirecciones(Convert.ToInt32(rut_vendedor));
            if (ldireccion_vendedor.Count == 0)
            {
			
                FuncionGlobal.alerta_updatepanel("El Vendedor no tiene direccion", Page, up);
                return;
            }
			else
			{
				if (chk_leasing.Checked == true)
				{
					if (tipo_operacion == "CTC")
					{
						double rut = this.Datosvendedor.getRut();
						List<Participante> lparticipantes = new ParticipanteBC().Getparticipante(rut);
						if (lparticipantes.Count > 0)
						{
							add();
							
						
						}
						else
						{
							
							FuncionGlobal.alerta_updatepanel("El vendedor no tiene participantes", Page, up);
                            return;
						}
					}
					else
					{
						double rut = this.Datosvendedor.getRut();
						List<Participante> lparticipantes = new ParticipanteBC().Getparticipante(rut);
						double rut2 = this.Datoscomprador.getRut();
						List<Participante> lparticipantes2 = new ParticipanteBC().Getparticipante(rut2);
						if (lparticipantes.Count > 0 && lparticipantes2.Count >= 0)
						{
							add();
							
						}
						else
						{
							
							FuncionGlobal.alerta_updatepanel("Faltan Participantes", Page, up);
                            return;
						}

					}

				}
				else
				{
                    if (this.txt_kilometraje.Text == "")
                    {
						
                        FuncionGlobal.alerta_updatepanel("Debe ingresar el kilometraje", Page, up);
                        return;
                    }
                    if (this.lbl_codigo.Text == "")// modificar a  
					{
					
						FuncionGlobal.alerta_updatepanel("Ingrese el codigo de Servicio Impuestos Internos", Page, up);
                        return;
					}
					else
					{
						if (this.txt_precio.Text == "")
						{
							
							FuncionGlobal.alerta_updatepanel("Ingrese el precio del vehiculo", Page, up);
                            return;
						}
						else
						{
							double rut = this.Datosvendedor.getRut();
							List<Participante> lparticipantes = new ParticipanteBC().Getparticipante(rut);

							double rut2 = this.Datoscomprador.getRut();
							List<Participante> lparticipantes2 = new ParticipanteBC().Getparticipante(rut2);

							List<Direcciones> ldireccion = new DireccionesBC().getdirecciones(Convert.ToInt32(rut2));

                            List<Correo> lcorreo = new CorreoBC().getcorreos(Convert.ToInt32(rut2));

							if (tipo_operacion != "CTC" && tipo_operacion != "CTMAG")
							{

								if (this.Datoscomprador.getRut() >= 50000000)
								{
									if (lparticipantes2.Count == 0)
									{
									
										FuncionGlobal.alerta_updatepanel("El comprador no tiene Representantes", Page, up);
										return;
									}
								}


                                if (id_cliente == 3 || id_cliente == 4)
                                {

                                    if (lcorreo.Count == 0)
                                    {
										
                                        FuncionGlobal.alerta_updatepanel("No ingreso correo electronico para el comprador", Page, up);
                                        return; 
                                    
                                    }
                                
                                }
                                
                                if (ldireccion.Count == 0)
								{
									
									FuncionGlobal.alerta_updatepanel("El comprador no tiene direccion", Page, up);
									return;
								}
							}
							if (this.Datosvendedor.getRut() >= 50000000)
							{
								if (lparticipantes.Count == 0)
								{
									
									FuncionGlobal.alerta_updatepanel("El vendedor no tiene Representantes", Page, up);
									return;
								}
							}
						
					
						
							add();
							
						}
					}
				}
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			this.lbl_numero.Text = "0";
			this.lbl_operacion.Text = "";
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

		}
		
		protected void txt_patente_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_patente.Text.Trim() != "")
			{
				if (FuncionGlobal.formatoPatente(this.txt_patente.Text))
				{
					this.txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);

                    DatosVehiculo mdatosvehiculo = new DatosvehiculoBC().getDatovehiculobypatente(this.txt_patente.Text);

                    if (mdatosvehiculo != null)
                    {
                        this.txt_modelo.Text = mdatosvehiculo.Modelo;
                        this.txt_p_bruto.Text = mdatosvehiculo.Pesobruto.ToString();
                        this.txt_motor.Text = mdatosvehiculo.Motor;
                        this.txt_color.Text = mdatosvehiculo.Color;
                        this.txt_anno.Text = mdatosvehiculo.Ano.ToString();
                        this.txt_chassis.Text = mdatosvehiculo.Chassis;
                        this.dl_tipo_vehiculo.SelectedValue = mdatosvehiculo.Tipo_vehiculo.Codigo.ToString();
                        this.dl_marca_vehiculo.SelectedValue = mdatosvehiculo.Marca.Id_marca.ToString();
                        this.dl_combustible.SelectedValue = mdatosvehiculo.Combustible.ToString();
                    }
				}
				else
				{
					UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
					ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "validacion_ppu", "alert('La patente no cumple con el formato requerido (LLNNNN|LLLLNN). Si la patente es de una moto, coloque un cero (0) entre las letras y los números.');", true);
					this.txt_patente.Text = "";
					this.txt_dv_patente.Text = "";
					this.txt_patente.Focus();
				}
			}
		}

		
		

		protected void chk_leasing_CheckedChanged(object sender, EventArgs e)
		{
			if (chk_leasing.Checked == true)
			{
				//this.ib_mas.Visible = true;
				this.id_leasing.Visible = true;
				this.id_datounico.Visible = true;
				//this.txt_precio.Enabled = false;
			}
			else
			{
				//this.ib_mas.Visible = false;
				this.id_leasing.Visible = false;
				//this.txt_precio.Enabled = true;
			}

		}

		protected void txt_precio_TextChanged(object sender, EventArgs e)
		{
			this.txt_precio.Text = FuncionGlobal.NumeroConFormato(this.txt_precio.Text);
		}

		protected void txt_kilometraje_TextChanged(object sender, EventArgs e)
		{
			this.txt_kilometraje.Text = FuncionGlobal.NumeroConFormato(this.txt_kilometraje.Text);
		}

		protected void txt_tasacion_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_tasacion.Text != "")
			{
				this.txt_tasacion.Text = FuncionGlobal.NumeroConFormato(this.txt_tasacion.Text);
			}
		}

		protected void txt_valor_opcion_TextChanged(object sender, EventArgs e)
		{
			this.txt_valor_opcion.Text = FuncionGlobal.NumeroConFormato(this.txt_valor_opcion.Text);
		}

		protected void txt_valor_cesion_TextChanged(object sender, EventArgs e)
		{
			this.txt_valor_cesion.Text = FuncionGlobal.NumeroConFormato(this.txt_valor_cesion.Text);
		}

		protected void Button1_Click1(object sender, EventArgs e)
		{
			this.lbl_numero.Text = "0";
			this.lbl_operacion.Text = "";
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
		}

        protected void dl_financiamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dl_forma_pago.SelectedValue.Trim() == "2")
            {
                if (id_cliente == 4 || id_cliente == 3)
                {
                    this.dl_financiera.Items.Clear();
                  
                    DataTable dt;
                    dt = new DataTable("Tabla");

                    dt.Columns.Add("Codigo");
                    dt.Columns.Add("Descripcion");

                    DataRow dr;

                    dr = dt.NewRow();
                    dr["Codigo"] = "TANN";
                    dr[1] = "TANNER";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "SCO";
                    dr[1] = "BANCO SCOTIABANK";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "FOR";
                    dr[1] = "FORUM";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "MITS";
                    dr[1] = "MITSUI";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "BFALA";
                    dr[1] = "BANCO FALABELLA";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "SAN";
                    dr[1] = "SANTANDER CONSUMER";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "BCI";
                    dr[1] = "BANCO CREDITO E INVERSIONES";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[0] = "MCRE ";
                    dr[1] = "MARUBENI CREDIT";
                    dt.Rows.Add(dr);

                    this.dl_financiera.DataSource = dt;
                    this.dl_financiera.DataValueField = "Codigo";
                    this.dl_financiera.DataTextField = "Descripcion";
                    this.dl_financiera.DataBind();
                    
                    this.dl_financiera.Enabled = true;
                }
                else
                {
                    FuncionGlobal.comboFinancieraCliente(this.dl_financiera, id_cliente);
                    this.dl_financiera.Enabled = true;
                }
            }
            else
            {
                if (this.dl_forma_pago.SelectedValue.Trim() == "1")
                {
                    FuncionGlobal.combobanco(this.dl_financiera, id_cliente);
                    this.dl_financiera.SelectedValue = "CON";
                    this.dl_financiera.Enabled = false;
                }
                else
                {
                    FuncionGlobal.comboFinancieraCliente(this.dl_financiera, id_cliente);
                    this.dl_financiera.Enabled = true;
                }
              
              
            }
        }

		
        protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_marca_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		
	}
}