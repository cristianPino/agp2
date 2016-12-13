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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
namespace sistemaAGP
{
	public partial class mInfraccion : System.Web.UI.Page
	{

		private string id_solicitud;
		private string id_cliente;
		private string tipo_operacion;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.lbl_numero.Text != "")
			{
				//carga_rpt(Convert.ToInt32(this.lbl_numero.Text));
			}
			this.agpInfractor.OnClickDireccion += new wucBotonEventHandler(agpAdquiriente_OnClickDireccion);
			this.agpInfractor.OnClickTelefono += new wucBotonEventHandler(agpAdquiriente_OnClickTelefono);
			this.agpInfractor.OnClickCorreo += new wucBotonEventHandler(agpAdquiriente_OnClickCorreo);
			this.bt_caratula.Attributes.Add("onclick", "javascript:window.open('../reportes/reporte_prueba.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");

			this.id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			this.id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
			this.tipo_operacion = Request.QueryString["tipo_operacion"].ToString().ToUpper();

			cambiar_titulo();

			if (!IsPostBack)
			{
				this.lbl_operacion.Visible = false;
				this.lbl_numero.Visible = false;

				this.lbl_numero.Text = "0";

				this.lbl_operacion.Text = "";

				combotipoInfraccion();
				FuncionGlobal.combocliente(this.dl_cliente);
				this.dl_cliente.SelectedValue = id_cliente;
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
				//FuncionGlobal.combopais(this.dl_pais);
				getInfraccion(id_solicitud);
				combotipoInfraccion();

				this.busca_operacion();
			}
		}
		protected void agpAdquiriente_OnClickDireccion(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
		}

		protected void agpAdquiriente_OnClickTelefono(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
		}

		protected void agpAdquiriente_OnClickCorreo(object sender, wucBotonEventArgs e)
		{
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
		}

		protected void dl_tipo_infraccion_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		//protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e) {
		//    FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
		//}
		//protected void dl_region_SelectedIndexChanged(object sender, EventArgs e) {
		//    FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
		//}

		//protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e) {
		//    FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
		//    this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + FuncionGlobal.FuctionEncriptar(this.dl_ciudad.SelectedValue.Trim()) + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
		//    ib_comuna.Visible = true;
		//}
		//protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e) {

		//}

		protected void txt_patente_Leave(object sender, EventArgs e)
		{
			busca_operacion_por_patente(this.txt_patente.Text);
			this.txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(txt_patente.Text);
		}

		//private void carga_rpt(Int32 id_solicitud) {
		//    ReportDocument rpt = new ReportDocument();

		//    rpt.Load(Server.MapPath("../reportes/InfCaratulaPI.rpt"));

		//    rpt.SetParameterValue(0, id_solicitud);


		//    rpt.OpenSubreport("DATOVEHICULO");
		//    rpt.SetParameterValue(1, id_solicitud);

		//    rpt.OpenSubreport("DETALLE_GASTOS");
		//    rpt.SetParameterValue(2, id_solicitud);


		//    Session.Add("documento", rpt);
		//    Session.Add("nombre_rpt", "InfCaratulaPI.rpt");
		//}

		private void busca_operacion_por_patente(string patente)
		{
			Int32 id_cliente = Convert.ToInt32(this.dl_cliente.SelectedValue);

			#region Modificación
			//Autor: jmcandia
			//Fecha: 14-02-2012
			//Comentario: Si hace esto no permite generar operaciones nuevas para una misma patente, así que lo comenté
			//Infraccion minfraccion = new InfraccionBC().Getinfraccionbypatente(id_cliente, patente, this.tipo_operacion);
			//if (minfraccion != null)
			//{

			//    this.lbl_operacion.Visible = true;
			//    this.lbl_numero.Visible = true;
			//    this.ib_gasto.Visible = true;
			//    this.lbl_operacion.Text = "Operación de Infraccion Numero:";
			//    this.lbl_numero.Text = Convert.ToString(minfraccion.Operacion.Id_solicitud);
			//    getInfraccion(this.lbl_numero.Text);
			//    this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
			//    getInfraccion(this.lbl_numero.Text);

			//    //**datos vehiculo

			//    if (minfraccion.Operacion != null)
			//    {

			//        this.dl_cliente.SelectedValue = minfraccion.Operacion.Cliente.Id_cliente.ToString();
			//        this.dl_sucursal_origen.SelectedValue = minfraccion.Secursal_origen.ToString();


			//        this.txt_patente.Text = minfraccion.Patente.Trim();
			//    }


			//    //**adquiriente

			//    //if (minfraccion.Rut != 0)
			//    //{
			//    //    busca_persona(minfraccion.Rut);
			//    //    this.txt_rut.Text = minfraccion.Rut.ToString();
			//    //}
			//    if (minfraccion.Rut != null)
			//    {
			//        //busca_persona(mpreinscripcion.Adquiriente.Rut);
			//        //this.txt_rut.Text = mpreinscripcion.Adquiriente.Rut.ToString();
			//        this.agpInfractor.Mostrar_Form(minfraccion.Rut);
			//    }

			//    minfraccion = null;
			//}
			#endregion
		}

		private void busca_operacion()
		{
			Infraccion minfraccion = new InfraccionBC().GetinfraccionbyIdSolicitud(Convert.ToInt32(id_solicitud));

			if (minfraccion != null)
			{

				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;
				this.ib_gasto.Visible = true;
				this.lbl_operacion.Text = "Operación de Multas Numero:";
				this.lbl_numero.Text = Convert.ToString(minfraccion.Operacion.Id_solicitud);
				this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
				getInfraccion(this.lbl_numero.Text);

				//**datos vehiculo

				if (minfraccion.Patente != null)
				{

					this.dl_cliente.SelectedValue = minfraccion.Operacion.Cliente.Id_cliente.ToString();
					this.txt_patente.Text = minfraccion.Patente.Trim();
					this.dl_sucursal_origen.SelectedValue = minfraccion.Secursal_origen.ToString();
					this.txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(txt_patente.Text);
				}

				//**adquiriente

				//if (minfraccion.Rut != 0)
				//{
				//    busca_persona(minfraccion.Rut);
				//    this.txt_rut.Text = minfraccion.Rut.ToString();
				//}
				//if (minfraccion.Rut != null)
				if (minfraccion.Rut != 0)
				{
					this.agpInfractor.Mostrar_Form(minfraccion.Rut);
				}
				minfraccion = null;

			}
		}

		//protected void txt_rut_Leave(object sender, EventArgs e) {
		//    this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

		//    busca_persona(Convert.ToDouble(this.txt_rut.Text));

		//    this.txt_nombre.Focus();
		//}




		//private void busca_persona(double rut) {

		//    Persona mpersona = new PersonaBC().getpersonabyrut(rut);

		//    if (mpersona != null) {

		//        this.txt_rut.Enabled = false;
		//        this.txt_dv.Enabled = false;

		//        this.txt_nombre.Text = mpersona.Nombre;
		//        this.txt_paterno.Text = mpersona.Apellido_paterno;
		//        this.txt_materno.Text = mpersona.Apellido_materno;
		//        this.txt_dv.Text = mpersona.Dv;
		//        this.txt_direccion.Text = mpersona.Direccion;
		//        this.txt_numero.Text = mpersona.Numero;
		//        this.txt_depto.Text = mpersona.Depto;
		//        this.txt_telefono.Text = mpersona.Telefono;


		//        this.dl_pais.SelectedValue = mpersona.Comuna.Ciudad.Region.Pais.Codigo;
		//        FuncionGlobal.comboregion(this.dl_region, mpersona.Comuna.Ciudad.Region.Pais.Codigo);
		//        this.dl_region.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Region.Id_region);

		//        FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(mpersona.Comuna.Ciudad.Region.Id_region));
		//        this.dl_ciudad.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Id_Ciudad);
		//        FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(mpersona.Comuna.Ciudad.Id_Ciudad));
		//        this.dl_comuna.SelectedValue = Convert.ToString(mpersona.Comuna.Id_Comuna);
		//    } else {
		//        this.txt_dv.Focus();
		//    }
		//}

		//protected void bt_limpia_persona_Click(object sender, EventArgs e) {
		//    this.txt_rut.Enabled = true;
		//    this.txt_rut.Text = "";
		//    this.txt_dv.Text = "";
		//    this.txt_nombre.Text = "";
		//    this.txt_paterno.Text = "";
		//    this.txt_materno.Text = "";
		//    this.txt_direccion.Text = "";
		//    this.txt_numero.Text = "";
		//    this.txt_depto.Text = "";
		//    this.txt_telefono.Text = "";

		//    FuncionGlobal.combopais(this.dl_pais);
		//    this.dl_region.Items.Clear();
		//    this.dl_ciudad.Items.Clear();
		//    this.dl_comuna.Items.Clear();
		//    this.txt_rut.Focus();
		//}


		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			if (valida_ingreso() == true)
			{
				add_operacion();
			}
		}

		private void add_operacion()
		{
			double rut = 0;

			GridViewRow row;

			if (this.agpInfractor.Guardar_Form())
			{
				if (this.agpInfractor.InfoPersona != null)
				{
					rut = this.agpInfractor.InfoPersona.Rut;
				}
			}



			//if (this.txt_rut.Text == "") { rut = 0; } else {
			//    rut = Convert.ToDouble(this.txt_rut.Text);
			//    string persona = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text),
			//                                                     this.txt_dv.Text,
			//                                                     Convert.ToInt16(this.dl_comuna.SelectedValue),
			//                                                        "",
			//                                                        this.txt_nombre.Text,
			//                                                        this.txt_paterno.Text,
			//                                                        this.txt_materno.Text,
			//                                                        "0",
			//                                                        "0",
			//                                                        "",
			//                                                        "",
			//                                                        "0",
			//                                                        this.txt_telefono.Text,
			//                                                        "",
			//                                                        "",
			//                                                        this.txt_direccion.Text,
			//                                                        this.txt_numero.Text,
			//                                                        this.txt_depto.Text,
			//                                                        "0");
			//}



            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(this.dl_cliente.SelectedValue), this.tipo_operacion, (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),0);

			string addI_MU = new InfraccionBC().add_infraccion(add,
																	   this.txt_patente.Text,
																	   Convert.ToInt32(rut),

																	   this.dl_sucursal_origen.SelectedValue
																	   );



			if (add != 0)
			{
				string add_MU = "";
				Int32 monto;
				for (int i = 0; i < gr_dato.Rows.Count; i++)
				{

					row = gr_dato.Rows[i];

					DropDownList dl = (DropDownList)gr_dato.Rows[i].FindControl("dl_tipo_infraccion");
					TextBox txt_observacion = (TextBox)gr_dato.Rows[i].FindControl("txt_observacion");
					TextBox txt_monto = (TextBox)gr_dato.Rows[i].FindControl("txt_monto");
					TextBox txt_fecha = (TextBox)gr_dato.Rows[i].FindControl("txt_fecha");

					string codigo = dl.SelectedValue.ToString();
					string observacion = txt_observacion.Text.ToString();
					string fecha = txt_fecha.Text.ToString();
					if (txt_monto.Text != "")
						monto = Convert.ToInt32(txt_monto.Text.ToString());
					else
						monto = 0;

					if (codigo != "0")

						add_MU = new GastosInfraccionBC().add_gastosInfraccion(add,
																		  codigo,
																		  observacion,
																		  monto,
																		  fecha
																		  );
				}

				if (add_MU == "")
				{
					string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, "MU", "", (string)(Session["usrname"]));
				}


			}

			this.lbl_operacion.Visible = true;
			this.lbl_numero.Visible = true;

			this.lbl_operacion.Text = "Operación de Infraccion Numero:";
			this.lbl_numero.Text = Convert.ToString(add);

			this.ib_gasto.Visible = true;
			this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

			this.bt_caratula.Visible = true;
			//carga_rpt(add);
			getInfraccion(this.lbl_numero.Text);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			this.lbl_numero.Text = "0";
			this.lbl_operacion.Text = "";
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

		private Boolean valida_ingreso()
		{
			if (this.txt_patente.Text == "")
			{
				FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
				return false;
			}
			return true;
		}

		public void getInfraccion(string solicitud)
		{

			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("tipoInfraccion"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("observacion"));
			dt.Columns.Add(new DataColumn("monto"));
			dt.Columns.Add(new DataColumn("fecha"));



			List<GastosInfraccion> lInfraccion = new GastosInfraccionBC().Getinfraccion(Convert.ToInt32(solicitud));

			if (lInfraccion.Count > 0)
			{
				this.bt_guardar.Visible = true;
			}

			foreach (GastosInfraccion mInfraccion in lInfraccion)
			{
				DataRow dr = dt.NewRow();

				dr["tipoInfraccion"] = mInfraccion.Codigo;
				dr["descripcion"] = mInfraccion.Descripcion;
				dr["observacion"] = mInfraccion.Observacion;
				dr["monto"] = mInfraccion.Monto;
				dr["fecha"] = mInfraccion.Fecha;
				dt.Rows.Add(dr);
			}


			DataRow draux = dt.NewRow();
			draux["tipoInfraccion"] = "0";
			draux["descripcion"] = "";
			draux["observacion"] = "";
			draux["monto"] = "";
			draux["fecha"] = "";


			dt.Rows.Add(draux);

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

		}




		private void combotipoInfraccion()
		{
			//TipoInfraccion mtipoinfraccion = new TipoInfraccion();
			//GridViewRow row;

			//mtipoinfraccion.Codigo = "0";
			//mtipoinfraccion.Descripcion = "Seleccionar";

			//List<TipoInfraccion> ltipoinfraccion = new TipoInfraccionBC().getallTipoInfraccion();

			//ltipoinfraccion.Add(mtipoinfraccion);

			//for (int i = 0; i < gr_dato.Rows.Count; i++)
			//{

			//    row = gr_dato.Rows[i];

			//    DropDownList dl = (DropDownList)gr_dato.Rows[0].FindControl("dl_tipo_infraccion");

			//    dl.DataSource = ltipoinfraccion;
			//    dl.DataValueField = "codigo";
			//    dl.DataTextField = "descripcion";
			//    dl.DataBind();
			//    dl.SelectedValue = "0";
			//}
		}
		//protected void ib_comuna_Click(object sender, ImageClickEventArgs e)
		//{
		//    FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
		//}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{

		}

		protected void bt_caratula_Click(object sender, EventArgs e)
		{

		}

		protected void btnCancelar_Click(object sender, EventArgs e)
		{

		}

		protected void ib_gasto_Click(object sender, ImageClickEventArgs e)
		{

		}

		protected void dl_tipo_tramite_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		protected void txt_observacion_Leave(object sender, EventArgs e)
		{

		}

		protected void txt_monto_Leave(object sender, EventArgs e)
		{

		}
		protected void txt_fecha_Leave(object sender, EventArgs e)
		{

		}
		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
		{

			gr_dato.EditIndex = e.NewEditIndex;

		}

		protected void txt_patente_TextChanged(object sender, EventArgs e)
		{
			busca_operacion_por_patente(this.txt_patente.Text);
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				TipoInfraccion mtipoinfraccion = new TipoInfraccion();
				mtipoinfraccion.Codigo = "0";
				mtipoinfraccion.Descripcion = "Seleccionar";

				List<TipoInfraccion> ltipoinfraccion = new TipoInfraccionBC().getallTipoInfraccion();
				ltipoinfraccion.Add(mtipoinfraccion);

				DropDownList dl = (DropDownList)e.Row.FindControl("dl_tipo_infraccion");

				dl.DataSource = ltipoinfraccion;
				dl.DataValueField = "codigo";
				dl.DataTextField = "descripcion";
				dl.DataBind();

				dl.SelectedValue = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
			}
		}

		protected void dl_sucursal_origen_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
		{

		}

		protected void ib_mas_Click(object sender, ImageClickEventArgs e)
		{


			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("tipoInfraccion"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("observacion"));
			dt.Columns.Add(new DataColumn("monto"));
			dt.Columns.Add(new DataColumn("fecha"));

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				DataRow dr = dt.NewRow();
				DropDownList dl = (DropDownList)gr_dato.Rows[i].FindControl("dl_tipo_infraccion");
				dl.SelectedValue.ToString();



				dr["tipoInfraccion"] = dl.SelectedValue.ToString();
				dr["descripcion"] = gr_dato.DataKeys[0].Values[0].ToString();
				TextBox txt_observacion2 = (TextBox)gr_dato.Rows[i].FindControl("txt_observacion");
				dr["observacion"] = txt_observacion2.Text;
				TextBox txt_monto2 = (TextBox)gr_dato.Rows[i].FindControl("txt_monto");
				dr["monto"] = txt_monto2.Text;
				TextBox txt_fecha2 = (TextBox)gr_dato.Rows[i].FindControl("txt_fecha");
				dr["fecha"] = txt_fecha2.Text;


				dt.Rows.Add(dr);
			}

			DataRow draux = dt.NewRow();
			draux["tipoInfraccion"] = "0";
			draux["descripcion"] = "";
			draux["observacion"] = "";
			draux["monto"] = "";
			draux["fecha"] = "";

			dt.Rows.Add(draux);

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

		}

		protected void txt_fecha_infraccion_TextChanged(object sender, EventArgs e)
		{

		}

		protected void gr_dato_SelectedIndexChanged2(object sender, EventArgs e)
		{

		}

		protected void cambiar_titulo()
		{
			TipoOperacion p = new TipooperacionBC().getTipooperacion(this.tipo_operacion);
			this.Title = p.Operacion;
			this.lbl_titulo.Text = p.Operacion;
			p = null;
		}
	}
}