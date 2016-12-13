using System;
using System.Collections;
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
using System.Collections.Generic;

namespace sistemaAGP
{
	public partial class actualizar_vehiculo : System.Web.UI.Page
	{
		private string patente;
		private string id_solicitud;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.txt_precio_venta.Attributes.Add("onkeypress", "javascript:return solonumeros(event);");
			patente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["patente"].ToString());
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());


			this.lbl_patente.Text = patente;

			if (!IsPostBack)
			{
				FuncionGlobal.combobanco(this.dl_financiera,1);
				this.lbl_patente.Text = patente;
				getDatosvehiculo(id_solicitud);
				getDatosleasing(patente);

			}
		}



		protected void Button1_Click(object sender, EventArgs e)
		{
			add_datosvehiculo();
		}

		private void add_datosvehiculo()
		{
			DateTime fecha = Convert.ToDateTime("01/01/1900");
			Int32 precio = 0;
			Int32 kilometraje = 0;
			Int32 cantidad = 0;
			Int32 valor_cesion = 0;
			Int32 valor_opcion = 0;
			Int32 contrato = 0;
            Int32 impuesto = 0;

			string forma_pago = "";

         
                impuesto = Convert.ToInt32(this.dl_impuesto.SelectedValue);
          
            
            string mstock = new StockVentasBC().act_stockventaImp(Convert.ToInt32(id_solicitud),impuesto);


			string dv = FuncionGlobal.digitoVerificadorPatente(patente);
			DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculobyPatente_id_solicitud(patente,Convert.ToInt32(this.id_solicitud));
			if (this.txt_fecha_contrato.Text != "")
			{
				fecha = Convert.ToDateTime(this.txt_fecha_contrato.Text);
			}

			if (this.txt_forma_pago.Text != "")
			{
				forma_pago = this.txt_forma_pago.Text;
			}

			if (this.txt_precio_venta.Text != "")
			{
				precio = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_precio_venta.Text));
			}

			if (this.txt_kilometraje.Text != "")
			{
				kilometraje = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_kilometraje.Text));
			}


			Int32 rut_prenda = 0;
			

			if (this.chk_prenda.Checked == true)
			{
				if (this.Datosprendedor.Guardar_Form())
				{
					if (this.Datosprendedor.InfoPersona != null)
					{
						rut_prenda = Convert.ToInt32(this.Datosprendedor.InfoPersona.Rut.ToString());
					}
				}

			}
			else { precio = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_precio_venta.Text)); }

			Marcavehiculo marca = new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(mdato.Marca.Id_marca));
			Tipovehiculo vehi = new TipovehiculoBC().getTipoVehiculo(mdato.Tipo_vehiculo.Codigo);

			string add = new DatosvehiculoBC().add_Datosvehiculo(Convert.ToInt32(this.id_solicitud), marca,
																	vehi, this.patente, dv, mdato.Modelo, mdato.Chassis
																   , mdato.Motor, mdato.Vin,
																	mdato.Serie, mdato.Ano, mdato.Cilindraje, mdato.Color,
																	mdato.Carga, mdato.Pesobruto, mdato.Combustible, mdato.Npuerta,
																	mdato.Nasiento, kilometraje, mdato.Tasacion, mdato.Codigo_SII,
																	precio, mdato.Id_dato_vehiculo, fecha, forma_pago, chk_prenda.Checked.ToString().Trim(),
																	mdato.Estado_vehiculo, rut_prenda,mdato.Financiamiento_amicar,mdato.Transmision,mdato.Equipamiento);

			int n_cheques = 0;
			if (int.TryParse(this.txt_cheques.Text, out n_cheques))
			{
				ChequesFormaPagoBC cheques = new ChequesFormaPagoBC();

				cheques.del_cheques_operacion(Convert.ToInt32(this.id_solicitud));

				for (int i = 0; i < this.gr_cheques.Rows.Count; i++)
				{
					int id_cheque = Convert.ToInt32(this.gr_cheques.Rows[i].Cells[0].Text);
					int nro_cheque = Convert.ToInt32(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_nro_cheque")).Text);
					DateTime fecha_cheque = Convert.ToDateTime(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text);
					int monto_cheque = Convert.ToInt32(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_monto_cheque")).Text);
					cheques.add_cheques_operacion(id_cheque, Convert.ToInt32(this.id_solicitud), nro_cheque, fecha_cheque, monto_cheque, this.dl_financiera.SelectedValue, "");
				}

				cheques = null;
			}

			if (Panel2.Visible == true)
			{
				DateTime fecha_cesion = Convert.ToDateTime(this.txt_fecha_cesion.Text);
			
				if (this.txt_cantidad.Text != "" && Convert.ToInt16(this.txt_cantidad.Text) > 0)
				{
					cantidad = Convert.ToInt16(FuncionGlobal.NumeroSinFormato(this.txt_cantidad.Text));
				}
				if (this.txt_valor_cesion.Text != "")
				//if (this.txt_valor_cesion.Text != ""&& Convert.ToUInt16(this.txt_valor_cesion.Text) > 0)
				{
					valor_cesion = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_valor_cesion.Text));
				}

				if (this.txt_valor_opcion.Text != "")
				//if (this.txt_valor_opcion.Text != "" && Convert.ToInt32(this.txt_valor_opcion.Text) > 0)
				{
					valor_opcion = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_valor_opcion.Text));
				}
				if (this.txt_contrato.Text != "")
				//if (this.txt_contrato.Text != "" && Convert.ToInt32(this.txt_contrato.Text) >0)
				{
					contrato = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_contrato.Text));
				}

				string addleasing = new Leasing_transferenciaBC().add_leasing(Convert.ToInt32(this.id_solicitud), patente, contrato, fecha_cesion, valor_opcion, valor_cesion, cantidad);
			}

			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("DATOS DEL VEHICULO ACTUALIZADOS CON EXITO", this.Page, up);
			this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CloseWnd", "<script type=\"text/javascript\">window.close();</script>");
			return;
			 
		
		}

		private object Int16(string p)
		{
			throw new NotImplementedException();
		}




		private void getDatosvehiculo(string id_solicitud)
		{
			DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(Convert.ToInt32(this.id_solicitud));
			if (mdato != null)
			{
                Operacion moper = new OperacionBC().getoperacion(Convert.ToInt32(this.id_solicitud));

                if (moper.Cliente.Id_cliente == 3 && moper.Tipo_operacion.Codigo.Trim() == "CTC" || moper.Cliente.Id_cliente == 4 && moper.Tipo_operacion.Codigo.Trim() == "CTC")
                {
                    this.dl_impuesto.Visible = true;
                }
                
				if (mdato.Forma_pago != null)
				{
					this.txt_forma_pago.Text = mdato.Forma_pago.ToString();
				}

				if (mdato.Precio != 0)
				{
					this.txt_precio_venta.Text = FuncionGlobal.NumeroConFormato(mdato.Precio.ToString());
				}
				if (mdato.Kilometraje != 0)
				{
					this.txt_kilometraje.Text = FuncionGlobal.NumeroConFormato(mdato.Kilometraje.ToString());
				}

				if (mdato.Fecha_contrato.ToShortDateString() != "01/01/1900")
				{
					this.txt_fecha_contrato.Text = mdato.Fecha_contrato.ToShortDateString();
				}
				if (mdato.Prenda != "false")
				{
					this.chk_prenda.Checked = Convert.ToBoolean(mdato.Prenda);
					this.Datosprendedor.Visible = true;
					this.Datosprendedor.Mostrar_Form(Convert.ToDouble(mdato.Rut_prenda));
				}




				DataTable dt = new DataTable();
				dt.Columns.Add("nro_cuota");
				dt.Columns.Add("nro_cheque");
				dt.Columns.Add("fecha_cheque");
				dt.Columns.Add("monto_cheque");
				foreach (ChequesFormaPago cheque in new ChequesFormaPagoBC().get_cheques_operacion(mdato.Id_solicitud))
				{
					DataRow dr = dt.NewRow();
					dr["nro_cuota"] = cheque.Id_cheque;
					dr["nro_cheque"] = cheque.Nro_cheque;
					dr["fecha_cheque"] = cheque.Fecha_cheque.ToShortDateString();
					dr["monto_cheque"] = cheque.Monto_cheque;
					dt.Rows.Add(dr);
					//this.dl_financiera.SelectedValue = cheque.Codigo_banco;
					FuncionGlobal.BuscarValueCombo(this.dl_financiera, cheque.Codigo_banco.Trim());
				}
				if (dt.Rows.Count > 0)
				{
					this.txt_cheques.Text = dt.Rows.Count.ToString();
					this.pnlInfoCheques.Visible = true;
					this.gr_cheques.DataSource = dt;
					this.gr_cheques.DataBind();
					suma_grilla();
				}
				else
				{
					this.txt_cheques.Text = "0";
					this.pnlInfoCheques.Visible = false;
					this.gr_cheques.DataSource = null;
					this.gr_cheques.DataBind();
				}

			}
			return;
		}



		protected void dl_tipo_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void dl_marca_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void txt_fecha_contrato_TextChanged(object sender, EventArgs e)
		{

		}

		protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
		{

		}

		protected void txt_forma_pago_TextChanged(object sender, EventArgs e)
		{

		}

		protected void txt_precio_venta_TextChanged(object sender, EventArgs e)
		{
			this.txt_precio_venta.Text = FuncionGlobal.NumeroConFormato(this.txt_precio_venta.Text);
		}

		protected void chk_prenda_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chk_prenda.Checked == true)
			{
				this.Datosprendedor.Visible = true;
			}
			else
			{
				this.Datosprendedor.Visible = false;
			}
		}

		protected void txt_kilometraje_TextChanged(object sender, EventArgs e)
		{
			this.txt_kilometraje.Text = FuncionGlobal.NumeroConFormato(this.txt_kilometraje.Text);
		}

		protected void txt_cheques_TextChanged(object sender, EventArgs e)
		{

			int cheques = 0;
			this.pnlInfoCheques.Visible = true;
			if (this.txt_cheques.Text.Trim() != "")
			{
				if (int.TryParse(this.txt_cheques.Text, out cheques))
				{

					DataTable dt = new DataTable();
					dt.Columns.Add("nro_cuota");
					dt.Columns.Add("nro_cheque");
					dt.Columns.Add("fecha_cheque");
					dt.Columns.Add("monto_cheque");
					for (int i = 0; i < cheques; i++)
					{
						DataRow dr = dt.NewRow();
						dr["nro_cuota"] = i + 1;
						dr["nro_cheque"] = "";
						dr["fecha_cheque"] = "";
						dr["monto_cheque"] = "";
						dt.Rows.Add(dr);
					}
					this.gr_cheques.DataSource = dt;
					this.gr_cheques.DataBind();
					suma_grilla();
				}
			}
		}



		protected void suma_grilla()
		{
			int suma = 0;
			for (int idx = 0; idx < this.gr_cheques.Rows.Count; idx++)
			{
				int valor = 0;
				if (int.TryParse(((TextBox)this.gr_cheques.Rows[idx].FindControl("txt_monto_cheque")).Text, out valor))
					suma += valor;
				else
					suma += 0;
			}
			((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text = suma.ToString();
		}

		protected void gr_cheques_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int index;
			int valor;
			DateTime fecha;
			switch (e.CommandName)
			{
				case "FillDownNro":
					index = Convert.ToInt32(e.CommandArgument);
					if (int.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_nro_cheque")).Text, out valor))
					{
						for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
						{
							valor++;
							((TextBox)this.gr_cheques.Rows[i].FindControl("txt_nro_cheque")).Text = valor.ToString();
						}
					}
					break;
				case "FillDownMonto":
					index = Convert.ToInt32(e.CommandArgument);
					if (int.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_monto_cheque")).Text, out valor))
					{
						for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
						{
							((TextBox)this.gr_cheques.Rows[i].FindControl("txt_monto_cheque")).Text = valor.ToString();
						}
					}
					break;
				case "FillDownFecha":
					index = Convert.ToInt32(e.CommandArgument);
					if (DateTime.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_fecha_cheque")).Text, out fecha))
					{
						for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
						{
							fecha = fecha.AddMonths(1);
							((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text = fecha.ToShortDateString();
						}
					}
					break;
			}
			suma_grilla();
		}

		protected void gr_cheques_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				((ImageButton)e.Row.FindControl("btn_nro_cheque")).CommandArgument = e.Row.RowIndex.ToString();
				((ImageButton)e.Row.FindControl("btn_monto_cheque")).CommandArgument = e.Row.RowIndex.ToString();
				((ImageButton)e.Row.FindControl("btn_fecha_cheque")).CommandArgument = e.Row.RowIndex.ToString();
			}
		}

		protected void gr_cheques_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		protected void txt_monto_cheque_TextChanged(object sender, EventArgs e)
		{
			suma_grilla();
		}

		private void getDatosleasing(string patente)
		{
			Leasing_transferencia mdato = new Leasing_transferenciaBC().getLeasing(patente);
			if (mdato.Patente != null)
			{
				if (mdato.Valor_cesion != 0)
				{
					this.txt_valor_cesion.Text = FuncionGlobal.NumeroConFormato(mdato.Valor_cesion.ToString());
				}

				if (mdato.Valor_opcion != 0)
				{
					this.txt_valor_opcion.Text = FuncionGlobal.NumeroConFormato(mdato.Valor_opcion.ToString());
				}

				if (mdato.Fecha_contrato.ToShortDateString() != "01/01/1900")
				{
					this.txt_fecha_cesion.Text = mdato.Fecha_contrato.ToShortDateString();
				}
				if (mdato.N_vehiculos != 0)
				{
					this.txt_cantidad.Text = FuncionGlobal.NumeroConFormato(mdato.N_vehiculos.ToString());
				}
				
					this.txt_contrato.Text = (mdato.N_contrato.ToString());
					Panel2.Visible = true;
				
			}
		}

		protected void txt_valor_cesion_TextChanged(object sender, EventArgs e)
		{
			this.txt_valor_cesion.Text = FuncionGlobal.NumeroConFormato(this.txt_valor_cesion.Text);
		}

		protected void txt_valor_opcion_TextChanged(object sender, EventArgs e)
		{
			this.txt_valor_opcion.Text = FuncionGlobal.NumeroConFormato(this.txt_valor_opcion.Text);
		}

		protected void txt_fecha_cesion_TextChanged(object sender, EventArgs e)
		{
			
			
		}

		protected void ib_fecha_cesion_Click(object sender, ImageClickEventArgs e)
		{

		}

		protected void txt_cantidad_TextChanged(object sender, EventArgs e)
		{
			this.txt_cantidad.Text = FuncionGlobal.NumeroConFormato(this.txt_cantidad.Text);
	
		}

		protected void txt_contrato_TextChanged(object sender, EventArgs e)
		{
			this.txt_contrato.Text = FuncionGlobal.NumeroConFormato(this.txt_contrato.Text);
		}

       

        protected void dl_impuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

	}
}
