using System;
using System.IO;
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
using System.Xml;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
//using sistemaAGP.WSVentaSoap;
using sistemaAGP.swventasoap;

namespace sistemaAGP
{
	public partial class mPoliza : System.Web.UI.Page
	{
		private string id_solicitud;
		private string id_cliente;

		protected void Page_Load(object sender, EventArgs e)
		{
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
			//Carga_Link();
			if (!IsPostBack)
			{
				this.txt_fechadesde.Text = DateTime.Now.ToShortDateString();

				/*DateTime fecha = new DateTime(DateTime.Now.Year + 1, 3, 31);
				this.txt_fecha_hasta.Text = fecha.ToShortDateString();
				*/
				combodistribuidorpoliza();
				getPoliza();
				//Carga_Link();
			}
		}

		private void combodistribuidorpoliza()
		{
			DistribuidorPoliza mdistribuidorpoliza = new DistribuidorPoliza();

			mdistribuidorpoliza.Codigo = Convert.ToString(0);
			mdistribuidorpoliza.Nombre = "Seleccionar";

			List<DistribuidorPoliza> ldistribuidorpoliza = new DistribuidorpolizaBC().getalldistribuidorpoliza("TODO");

			ldistribuidorpoliza.Add(mdistribuidorpoliza);

			this.dl_distribuidor_poliza.DataSource = ldistribuidorpoliza;
			this.dl_distribuidor_poliza.DataValueField = "codigo";
			this.dl_distribuidor_poliza.DataTextField = "nombre";
			this.dl_distribuidor_poliza.DataBind();
			//this.dl_distribuidor_poliza.SelectedValue = "0";
			this.dl_distribuidor_poliza.SelectedValue = "1";
			this.btn_solicitar.Enabled = true;
			valores_poliza();
		}

		private void add_poliza()
		{
			if (valida_ingreso())
			{
				Poliza poliza = new Poliza();
				poliza.Distribuidor_poliza = this.dl_distribuidor_poliza.SelectedValue.ToString();
				poliza.Id_solicitud = Convert.ToInt32(id_solicitud);
				poliza.Nfolio = Convert.ToInt64(this.txt_nfolio.Text);
				poliza.Npoliza = this.txt_npoliza.Text;
				poliza.Pagp = Convert.ToInt32(this.txtPagp.Text);
				poliza.Pcliente = Convert.ToInt32(this.txtPcliente.Text);
				poliza.Ppiso = Convert.ToInt32(this.txtPpiso.Text);
				poliza.Prima = Convert.ToInt32(this.txt_prima.Text);
				poliza.Url_poliza = this.txt_url.Text;
				poliza.Vigencia_desde = Convert.ToDateTime(this.txt_fechadesde.Text);
				poliza.Vigencia_hasta = Convert.ToDateTime(this.txt_fecha_hasta.Text);

				string add = new PolizaBC().add_poliza(poliza,(string)(Session["usrname"]));
			}
			getPoliza();
			//Carga_Link();
		}

		private Boolean valida_ingreso()
		{
			string poliza = this.txt_npoliza.Text.Trim();
			//if (poliza.IndexOf("-") < poliza.LastIndexOf("-"))
			if (poliza.IndexOf("-") == -1 || poliza.LastIndexOf("-") == -1)
			{
				UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel("EL NÚMERO DE PÓLIZA NO ES VÁLIDO", this.Page, pnl);
				return false;
			}

			while (poliza.IndexOf("-") < poliza.LastIndexOf("-"))
				poliza = poliza.Substring(poliza.IndexOf("-") + 1);

			string digito = poliza.Substring(poliza.IndexOf("-") + 1);
			poliza = poliza.Substring(0, poliza.IndexOf("-"));
			if (FuncionGlobal.digitoVerificador(poliza) != digito.ToUpper())
			{
				UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel("EL NÚMERO DE PÓLIZA NO ES VÁLIDO", this.Page, pnl);
				return false;
			}
			this.txt_npoliza.Text = poliza + "-" + digito;
			//if (this.txt_npoliza.Text == "" || this.txt_nfolio.Text == "" || this.dl_distribuidor_poliza.SelectedValue.ToString() == "0")
			if (this.txt_npoliza.Text == "" || this.dl_distribuidor_poliza.SelectedValue.ToString() == "0")
			{
				//FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
				UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				FuncionGlobal.alerta_updatepanel("INGRESE LOS DATOS CORRESPONDIENTES", this.Page, pnl);
				return false;
			}

            if (this.txt_prima.Text == "" || this.txt_prima.Text== "0")
            {
                //FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                FuncionGlobal.alerta_updatepanel("FAVOR REVISAR TIPO VEHICULO, LA PRIMA NO PUEDE SER 0", this.Page, pnl);
                return false;
            }

			if (this.txt_nfolio.Text == "") this.txt_nfolio.Text = "0";
			return true;
		}

		public void getPoliza()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("distribuidor_poliza"));
			dt.Columns.Add(new DataColumn("npoliza"));
			dt.Columns.Add(new DataColumn("nfolio"));
			dt.Columns.Add(new DataColumn("ppiso"));
			dt.Columns.Add(new DataColumn("pagp"));
			dt.Columns.Add(new DataColumn("pcliente"));
			dt.Columns.Add(new DataColumn("prima"));
			dt.Columns.Add(new DataColumn("url_poliza"));
			dt.Columns.Add(new DataColumn("vigencia_desde"));
			dt.Columns.Add(new DataColumn("vigencia_hasta"));
			dt.Columns.Add(new DataColumn("total"));
			dt.Columns.Add(new DataColumn("id_poliza"));
			dt.Columns.Add(new DataColumn("poliza_nula"));

			List<Poliza> lpoliza = new PolizaBC().getallpoliza(Convert.ToInt32(id_solicitud));
			foreach (Poliza mpoliza in lpoliza)
			{
				DataRow dr = dt.NewRow();

				dr["id_solicitud"] = mpoliza.Id_solicitud;
				dr["distribuidor_poliza"] = mpoliza.Distribuidor_poliza;
				dr["npoliza"] = mpoliza.Npoliza;
				dr["nfolio"] = mpoliza.Nfolio;
				dr["ppiso"] = mpoliza.Ppiso;
				dr["pagp"] = mpoliza.Pagp;
				dr["pcliente"] = mpoliza.Pcliente;
				dr["prima"] = mpoliza.Prima;
				dr["url_poliza"] = mpoliza.Url_poliza;
				dr["vigencia_desde"] = string.Format("{0:dd/MM/yyyy}", mpoliza.Vigencia_desde);
				dr["vigencia_hasta"] = string.Format("{0:dd/MM/yyyy}", mpoliza.Vigencia_hasta);
				dr["total"] = Convert.ToString(Convert.ToInt32(mpoliza.Pagp) + Convert.ToInt32(mpoliza.Ppiso) + Convert.ToInt32(mpoliza.Pcliente));
				dr["id_poliza"] = mpoliza.Id_poliza;
				dr["poliza_nula"] = mpoliza.Poliza_vigente ? "NO" : "SI";

				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		//protected void Carga_Link()
		//{
		//    int i;
		//    GridViewRow row;
		//    ImageButton ibuton;
		//    string id;

		//    for (i = 0; i < gr_dato.Rows.Count; i++)
		//    {
		//        row = gr_dato.Rows[i];
		//        if (row.RowType == DataControlRowType.DataRow)
		//        {
		//            id = (string)row.Cells[0].Text;
		//            Poliza pol = new PolizaBC().getpolizabyid_poliza(Convert.ToInt32(id));
		//            ibuton = (ImageButton)row.FindControl("ib_poliza");
		//            //ibuton.Attributes.Add("onclick", pol.Url_poliza.ToString());
		//            ibuton.Attributes.Add("onclick", "javascript:window.open('" + pol.Url_poliza.ToString() + "','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");
		//        }
		//    }
		//}

		protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			GridViewRow row;
			string id_poliza;

			row = gr_dato.Rows[e.RowIndex];
			id_poliza = (string)row.Cells[0].Text;

			string del = new PolizaBC().del_poliza(Convert.ToInt32(id_poliza));
			getPoliza();
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				string url = this.gr_dato.DataKeys[e.Row.RowIndex].Values["url_poliza"].ToString(); //(string)e.Row.Cells[0].Text;
				ImageButton ibuton = (ImageButton)e.Row.FindControl("ib_poliza");
				if (url != "")
				{
					ibuton.Attributes.Add("onclick", "javascript:window.open('" + url + "','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");
					ibuton.Visible = true;
				}
				else {
					ibuton.Visible = false;
				}
				string nula = this.gr_dato.DataKeys[e.Row.RowIndex].Values["poliza_nula"].ToString();
				Button button = (Button)e.Row.FindControl("btn_eliminar");
				button.Enabled = (nula.ToUpper().Trim() == "NO") ? true : false;
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			add_poliza();
		}

		protected void ib_calendario_Click(object sender, ImageClickEventArgs e) { }

		protected void txt_fechadesde_TextChanged(object sender, EventArgs e) 
        {
            valores_poliza();
        
        }

		protected void dl_distribuidor_poliza_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dl_distribuidor_poliza.SelectedValue.ToString() != "SP")
			{
				btn_solicitar.Enabled = true;
				valores_poliza();
			}
		}

		public void valores_poliza()
		{
			if (dl_distribuidor_poliza.SelectedValue.ToString() != "SP")
			{
				Poliza mpoliza = new PolizaBC().valores_poliza(Convert.ToInt32(id_solicitud), Convert.ToInt32(id_cliente), dl_distribuidor_poliza.SelectedValue.ToString(),this.txt_fechadesde.Text);

				txt_prima.Text = mpoliza.Prima.ToString();
				txtPagp.Text = mpoliza.Pagp.ToString();
				txtPcliente.Text = mpoliza.Pcliente.ToString();
				txtPpiso.Text = mpoliza.Ppiso.ToString();
				txt_fecha_hasta.Text = string.Format("{0:dd/MM/yyyy}", mpoliza.Vigencia_hasta);
				txt_fechadesde.Text = string.Format("{0:dd/MM/yyyy}", mpoliza.Vigencia_desde);
				 



			}
		}

		protected void txt_fecha_hasta_TextChanged(object sender, EventArgs e) { }

		protected void txt_ncuotas_TextChanged(object sender, EventArgs e) { }

		protected void txt_url_TextChanged(object sender, EventArgs e) { }

		protected void txtPpiso_TextChanged(object sender, EventArgs e) { }

		protected void txtPagp_TextChanged(object sender, EventArgs e) { }

		protected void txtPcliente_TextChanged(object sender, EventArgs e) { }

		public void wsventasoap()
		{
			VentaSoap msoap = new VentaSoapBC().getsoap(Convert.ToInt32(id_solicitud), dl_distribuidor_poliza.SelectedValue.ToString(),this.txt_fechadesde.Text);

            string pariedad;
            if (msoap.CodigoTipVehDisy.ToString().Length == 1)
            {
                pariedad = "0" + msoap.CodigoTipVehDisy.ToString();
            }
            else
            {
                pariedad = msoap.CodigoTipVehDisy.ToString();
            }

			string paterno= " ";
			string materno= " ";

			if (msoap.Apellidopaterno != "" || msoap.Apellidopaterno != null)
			{
				paterno = msoap.Apellidopaterno;
			}

			if (msoap.Apellidomaterno != "" || msoap.Apellidomaterno!= null)
			{
				materno = msoap.Apellidomaterno;
			}


			MemoryStream m = new MemoryStream();

			XmlTextWriter xml = new XmlTextWriter(m, System.Text.Encoding.UTF8);
			xml.Formatting = Formatting.Indented;
			xml.Namespaces = true;

			xml.WriteStartDocument(false);
			xml.WriteStartElement("VentaSoap");
			xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
			xml.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
			xml.WriteStartElement("Vehiculo");
			xml.WriteElementString("NumeroPatente", msoap.Patente);
			xml.WriteElementString("DigitoVerificadorPatente", msoap.Dvp);
			xml.WriteElementString("Anio", msoap.Ano.ToString());
			xml.WriteStartElement("TipoVehiculo");
			xml.WriteElementString("Codigo", pariedad);
			xml.WriteEndElement();
			xml.WriteElementString("NumeroMotor", msoap.Motor.ToString());
			xml.WriteStartElement("Marca");
			xml.WriteElementString("Nombre", msoap.Marca);
			xml.WriteEndElement();
			xml.WriteStartElement("Modelo");
			xml.WriteElementString("Nombre", msoap.Modelo);
			xml.WriteEndElement();
			xml.WriteEndElement();
			xml.WriteStartElement("Propietario");
			xml.WriteElementString("Rut", msoap.Rut);
			xml.WriteElementString("DigitoVerificador", msoap.Dvr);
			xml.WriteElementString("Nombre", msoap.Nombre);
			xml.WriteElementString("ApellidoPaterno", paterno);
			xml.WriteElementString("ApellidoMaterno", materno);
			//xml.WriteElementString("Email", "");
            xml.WriteElementString("Email", "mail.agpsa@agpsa.cl");
            //xml.WriteElementString("Telefono", "562" + msoap.Telefono);
            xml.WriteElementString("Telefono", "562" + "12345678");
			xml.WriteEndElement();
			xml.WriteStartElement("ResponsablePago");
			xml.WriteElementString("Rut", msoap.Rut.ToString());
			xml.WriteElementString("DigitoVerificador", msoap.Dvr.ToString());
			xml.WriteEndElement();
			xml.WriteStartElement("FormaPago");
			xml.WriteElementString("Codigo", "03");
			xml.WriteEndElement();
			xml.WriteStartElement("Usuario");
            xml.WriteElementString("NombreIngreso", "USRAGPPROV");
            xml.WriteElementString("Contrasena", "USRAGPPROV");
			xml.WriteEndElement();
			xml.WriteStartElement("Prima");
			xml.WriteStartElement("Monto");
			xml.WriteElementString("Valor", msoap.Prima.ToString());
			xml.WriteEndElement();
			xml.WriteEndElement();
			xml.WriteStartElement("Empresa");
			xml.WriteElementString("Rut", "76095476");
			xml.WriteElementString("DigitoVerificador", "4");
			xml.WriteEndElement();
			xml.WriteEndElement();
			xml.WriteEndDocument();

			//xml.WriteStartDocument(false);
			//xml.WriteStartElement("VentaSoap");
			//xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
			//xml.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
			//xml.WriteStartElement("Vehiculo");
			//xml.WriteElementString("NumeroPatente", "zs3549");
			//xml.WriteElementString("DigitoVerificadorPatente", "k");
			//xml.WriteElementString("Anio", "2006");
			//xml.WriteStartElement("TipoVehiculo");
			//xml.WriteElementString("Codigo", "01");
			//xml.WriteEndElement();
			//xml.WriteElementString("NumeroMotor", "GHT25570231");
			//xml.WriteStartElement("Marca");
			//xml.WriteElementString("Nombre", "RENAULT");
			//xml.WriteEndElement();
			//xml.WriteStartElement("Modelo");
			//xml.WriteElementString("Nombre", "SCENIC AUNTENTHIQUE 1.6");
			//xml.WriteEndElement();
			//xml.WriteEndElement();
			//xml.WriteStartElement("Propietario");
			//xml.WriteElementString("Rut", "2232868");
			//xml.WriteElementString("DigitoVerificador", "k");
			//xml.WriteElementString("Nombre", "Wilfredo");
			//xml.WriteElementString("ApellidoPaterno", "Silva");
			//xml.WriteElementString("ApellidoMaterno", "Valenzuela");
			//xml.WriteElementString("Email", "wilfredo@pulse-it.cl");
			//xml.WriteElementString("Telefono", "5623456321");
			//xml.WriteEndElement();
			//xml.WriteStartElement("ResponsablePago");
			//xml.WriteElementString("Rut", "2232868");
			//xml.WriteElementString("DigitoVerificador", "k");
			//xml.WriteEndElement();
			//xml.WriteStartElement("FormaPago");
			//xml.WriteElementString("Codigo", "03");
			//xml.WriteEndElement();
			//xml.WriteStartElement("Usuario");
			//xml.WriteElementString("NombreIngreso", "USRPULSE");
			//xml.WriteElementString("Contrasena", "12345");
			//xml.WriteEndElement();
			//xml.WriteStartElement("Prima");
			//xml.WriteStartElement("Monto");
			//xml.WriteElementString("Valor", "9000");
			//xml.WriteEndElement();
			//xml.WriteEndElement();
			//xml.WriteStartElement("Empresa");
			//xml.WriteElementString("Rut", "11222333");
			//xml.WriteElementString("DigitoVerificador", "9");
			//xml.WriteEndElement();
			//xml.WriteEndElement();
			//xml.WriteEndDocument();

			xml.Flush();

			m.Position = 0;
			string r = new StreamReader(m).ReadToEnd();
			xml.Close();
			m.Close();

			//Service venta = new Service();

			ServiceSoapClient venta = new ServiceSoapClient("ServiceSoap");
			System.Net.ServicePointManager.Expect100Continue = false;
			try
			{
                
                RespuestaVentaSoap datos = venta.EmitirVentaSoap(r);
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
				switch (datos.CodigoEstado)
				{
					case 0:
						FuncionGlobal.alerta_updatepanel("Transaccion exitosa", Page,up);
						RespuestaSalidaVentaSoap resp = (RespuestaSalidaVentaSoap)datos;

						add_solicitar(resp);
						break;
					case 1: FuncionGlobal.alerta_updatepanel("usuario no valido", Page, up);; break;
					case 7: FuncionGlobal.alerta_updatepanel("datos erroneos al ingresar", Page,up); break;
                    case 8: FuncionGlobal.alerta_updatepanel("No se puede emitir 2 poliza soap para un mismo numero de patente dado la fecha de vigencia", Page, up); break;
                    case 9: FuncionGlobal.alerta_updatepanel("tipo forma de pago desconocido", Page, up); break;
                    case 10: FuncionGlobal.alerta_updatepanel("tipo de vehiculo desconocido", Page, up); break;
                    case 11: FuncionGlobal.alerta_updatepanel("empresa no registrada", Page, up); break;
                    case 12: FuncionGlobal.alerta_updatepanel("el digito verificador de la empresa es incorrecto", Page, up); break;
                    case 13: FuncionGlobal.alerta_updatepanel("el digito verificador del responsable de pago es incorrecto", Page, up); break;
                    case 14: FuncionGlobal.alerta_updatepanel("el digito verificador del propietario es incorrecto", Page, up); break;
                    case 15: FuncionGlobal.alerta_updatepanel("el tipo de vehiculo no esta permitido para la campaña vigente", Page, up); break;
                    case 16: FuncionGlobal.alerta_updatepanel("el año del vehiculo no es valido", Page, up); break;
                    case 17: FuncionGlobal.alerta_updatepanel("la prima informada es inferior a la prima minima de la campaña vigente", Page, up); break;
                    case 19: FuncionGlobal.alerta_updatepanel("el delimitador seleccionado no es el correcto y/o  los campos de la linea no son los especificos", Page, up); break;
                    case 30: FuncionGlobal.alerta_updatepanel("los apellidos del propietario son obligatorios", Page, up); break;
                    case 99: FuncionGlobal.alerta_updatepanel("se a producido un error generico", Page, up); break;
                    case 18: FuncionGlobal.alerta_updatepanel("no existe campaña vigente para la empresa y/o el o los campos de la linea no son los especificados", Page, up); break;
				}
			}
			catch (Exception ex)
			{
				throw ex;
                //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                //FuncionGlobal.alerta_updatepanel(ex.Message, this.Page, pnl);
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			//int i;
			//GridViewRow row;
			//string id;

			//for (i = 0; i < gr_dato.Rows.Count; i++)
			//{
			//    row = gr_dato.Rows[i];
			//    id = (string)row.Cells[0].Text;
			//    Poliza pol = new PolizaBC().getpolizabyid_poliza(Convert.ToInt32(id));
			//    UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

			//    if (pol.Poliza_vigente == true)
			//    {
			//        FuncionGlobal.alerta_updatepanel("Debe cancelar la Poliza vigente antes de solicitar otra", Page, up);
			//        return;
			//    }
			//}
			wsventasoap();
		}

		protected void ib_calendario0_Click(object sender, ImageClickEventArgs e) { }

		private void add_solicitar(RespuestaSalidaVentaSoap resp)
		{
			Poliza poliza = new Poliza();

			HomologacionPoliza mtipo = new HomologacionPolizaBC().gethomologacionpolizabycodigo(dl_distribuidor_poliza.SelectedValue.ToString(), resp.Descripcion.TipoVehiculo.ToString());
			//ValorSeguroVehiculo mvalorPO = new ValorSeguroVehiculoBC().getallvalosegurovehiculobycodigo(dl_distribuidor_poliza.SelectedValue.ToString(), mtipo.Codigo.ToString());
			//ValorSeguroCliente mvalor = new ValorseguroclienteBC().getallvaloseguroclientebycodigo(Convert.ToInt32(id_cliente), mtipo.Codigo.ToString());

			Poliza mpoliza = new PolizaBC().valores_poliza(Convert.ToInt32(id_solicitud), Convert.ToInt32(id_cliente), dl_distribuidor_poliza.SelectedValue.ToString(),this.txt_fechadesde.Text);


			DateTime desde = DateTime.ParseExact(resp.Descripcion.VigenciaDesde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
			DateTime hasta = DateTime.ParseExact(resp.Descripcion.Vigenciahasta, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

			poliza.Distribuidor_poliza = this.dl_distribuidor_poliza.SelectedValue.ToString();
			poliza.Id_solicitud = Convert.ToInt32(id_solicitud);
			poliza.Nfolio = resp.Descripcion.NumeroFolio;
			poliza.Npoliza = resp.Descripcion.NumeroPoliza.ToString();
			poliza.Pagp = Convert.ToInt32(mpoliza.Pagp.ToString());
			poliza.Pcliente = Convert.ToInt32(mpoliza.Pcliente.ToString());
			poliza.Ppiso = Convert.ToInt32(mpoliza.Ppiso.ToString());
			poliza.Prima = mpoliza.Prima;
			poliza.Url_poliza = resp.Descripcion.UrlPolizaSoap.ToString();
			poliza.Vigencia_desde = desde;
			poliza.Vigencia_hasta = hasta;
			string add = new PolizaBC().add_poliza(poliza,(string)(Session["usrname"]));
			getPoliza();
			//Carga_Link();
		}


		protected void txt_npoliza_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_npoliza.Text != "")
			{
			}
		}
	}
}