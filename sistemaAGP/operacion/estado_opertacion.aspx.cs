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
    public partial class estado_operacion : System.Web.UI.Page
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
				FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
				FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));

				this.Crear_DataTable();
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
			if (Convert.ToInt16(this.dl_cliente.SelectedValue) == 0)
			{
				FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}
			else
			{
				FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}

			this.Limpiar_DataTable();
		}

		protected void Limpiar_DataTable()
		{
			ViewState["dt"] = null;
			this.gr_dato.DataSource = null;
			this.gr_dato.DataBind();
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));

			this.Limpiar_DataTable();
            if (this.dl_familia.SelectedValue.Trim() == "19")
            {
                this.ib_exportar.Visible = true;
            }
            else
            {
                this.ib_exportar.Visible = false;
            }
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Convert.ToInt16(this.dl_modulo.SelectedValue) == 0)
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
			else
				FuncionGlobal.combosucursalbymodulo(this.dl_sucursal, Convert.ToInt16(this.dl_modulo.SelectedValue));
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_producto.SelectedValue == "0")
				this.pnl_flujo.Style.Add("display", "none");
			else
				this.pnl_flujo.Style.Add("display", "inline");

			FuncionGlobal.comboestado(this.dpl_estado, this.dl_producto.SelectedValue.Trim());

			this.Limpiar_DataTable();
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			this.Busca_Operacion();
		}

		protected void Busca_Operacion()
		{
			double rut = 0;
            double rut_para = 0;
			Int32 factura = 0;
			Int32 noperacion = 0;
			Int32 estado_actual = 0;
			Int16 dl_modulo = 0;
			Int16 dl_sucursal = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
			string patente = this.txt_patente.Text.Trim();

			if (this.txt_rut.Text.Trim() != "") rut = Convert.ToDouble(this.txt_rut.Text);
            if (this.txt_rut_para.Text.Trim() != "") rut_para = Convert.ToDouble(this.txt_rut_para.Text);
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.txt_factura.Text.Trim() != "") factura = Convert.ToInt32(this.txt_factura.Text);
			if (this.dpl_estado.SelectedValue != "") estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue);
			if (this.dl_modulo.SelectedValue != "") dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			
			if (noperacion == 0 && this.chk_agrupar.Checked == true) return;

			this.txt_operacion.Text = "";
			this.txt_operacion.Focus();

			if (noperacion != 0 || factura != 0 || patente != "")
			{
				desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
				hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			}
			if (noperacion == 0 && this.chk_agrupar.Checked == false)
			{
				ViewState["dt"] = null;
				this.Crear_DataTable();
			}

			if (ViewState["dt"] == null) this.Crear_DataTable();

			DataTable dt = (DataTable)ViewState["dt"];

			List<Operacion> loperacion = new List<Operacion>();
			loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue, dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue), "TODO",0,"","",rut_para);


			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
				if (moperacion.Numero_factura != 0)
					dr["numero_factura"] = moperacion.Numero_factura;
				else
					dr["numero_factura"] = "";
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;
				if (moperacion.Adquiriente != null)
				{
					dr["rut_persona"] = moperacion.Adquiriente.Rut;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
				}
				else
				{
					dr["rut_persona"] = "0";
					dr["nombre_persona"] = "Sin Adquiriente";
				}
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo.Trim();
				dr["operacion"] = moperacion.Tipo_operacion.Operacion.ToString();
				dr["total_gasto"] = moperacion.Total_gasto;
				dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_gasto);
				dr["ultimo_estado"] = moperacion.Estado;
				dr["factura_emitida"] = moperacion.Factura_emitida;
				dr["sucursal"] = moperacion.Sucursal.Nombre.ToUpper().Trim();

				dr["url_digital"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&origen=eo";
				dr["url_estado"] = "mWorkflow.aspx?&id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&nombre_estado=" + moperacion.Tipo_operacion.Operacion.ToString();



                dr["semaforo"] = moperacion.Semaforo.Trim();
                dr["contador"] = moperacion.Contador.ToString().Trim() + "/" + moperacion.Total_dias.ToString().Trim();



				if (new UsuarioBC().GetUsuario((string)(Session["usrname"])).Cliente.Id_cliente != 3)
				{
					if (moperacion.Tipo_operacion.Codigo.Trim() == "MU")
						dr["url_comgastos"] = "../reportes/view_comprobante_cobro_multa.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim());
					else if (moperacion.Tipo_operacion.Codigo.Trim() == "PPUP")
						dr["url_comgastos"] = "../reportes/view_comprobante_cobro_ppu.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(this.dl_familia.SelectedValue);
					else
                        if (this.dl_familia.SelectedValue != "19")
                        {
                            dr["url_comgastos"] = "../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(this.dl_familia.SelectedValue);
                        }
				}
				else
				{
					dr["url_comgastos"] = "javascript:alert('Ud. no tiene los privilegios para ver el comprobante de cobro');";
				}

				if (moperacion.Cliente.Id_cliente.ToString() != "DOCUMENTO HIPOTECARIO")
					dr["url_contratos"] = "../operacion/Contra_vehiculos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
				else
                    if (this.dl_familia.SelectedValue == "19")
                    {
                        dr["url_contratos"] = "javascript:alert('Ud. no tiene los privilegios para ver Contratos');";
                    }
                    else
                    {

                        dr["url_contratos"] = "../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
                    }
				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void Crear_DataTable()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("nombre_cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("saldo"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));
			dt.Columns.Add(new DataColumn("factura_emitida"));
			dt.Columns.Add(new DataColumn("sucursal"));
			dt.Columns.Add(new DataColumn("url_digital"));
			dt.Columns.Add(new DataColumn("url_estado"));
			dt.Columns.Add(new DataColumn("url_comgastos"));
			dt.Columns.Add(new DataColumn("url_contratos"));
            dt.Columns.Add(new DataColumn("contador"));
            dt.Columns.Add(new DataColumn("semaforo"));
			ViewState["dt"] = dt;
		}

		protected void txt_operacion_TextChanged(object sender, EventArgs e)
		{
			this.Busca_Operacion();
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ib_exportar_Click(object sender, ImageClickEventArgs e)
        {

            string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
            string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));


            string add = "";

            if (this.dl_familia.SelectedValue == "19")
            {
                add = new MatrizExcelBC().getMatrizRetiroCarpeta(desde, hasta, Session["usrname"].ToString());

                string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
                //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
                ScriptManager.RegisterStartupScript(this.up_arriba, this.up_arriba.GetType(), "", strAlerta, true);


            }

         

            return;



        }

        protected void txt_rut_para_TextChanged(object sender, EventArgs e)
        {

        }


        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (this.dl_familia.SelectedValue == "19")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string nombre;

                    string tipo = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    string patente = this.gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();
                    int cont = this.gr_dato.DataKeys.Count;
                    Int16 id_cliente = Convert.ToInt16(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());
               
                    nombre = (string)e.Row.Cells[4].Text;
                    TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

                    HyperLink but = (HyperLink)e.Row.Cells[0].Controls[0];
                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&patente=" + patente + "&ventatipo=1','_blank','" + op.Tamano + "')");

                }
            }
        }





		//protected void Page_Load(object sender, EventArgs e)
		//{
		//    if (!IsPostBack)
		//    {

		//        this.txt_desde.Text = DateTime.Today.ToShortDateString();
		//        this.txt_hasta.Text = DateTime.Today.ToShortDateString();

		//        FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
		//        FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
		//        FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
		//        FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
		//        FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
		//    }
		//}

		//protected void Click_Gasto(Object sender, EventArgs e)
		//{
		//    busca_operacion();
		//}

		//protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
		//    FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
		//    if (Convert.ToInt16(this.dl_cliente.SelectedValue) == 0)
		//    {
		//        FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
		//        FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
		//    }
		//    else
		//    {
		//        FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), this.dl_familia);
		//        FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
		//    }
		//}

		//protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		//{
		//    busca_operacion();
		//}

		//private void busca_operacion()
		//{
		//    if (this.dl_familia.SelectedValue == "0")
		//    {
		//        return;
		//    }

		//    double rut;
		//    Int32 factura;
		//    Int32 noperacion;
		//    Int32 estado_actual;
		//    Int16 dl_modulo;
		//    Int16 dl_sucursal;

		//    if (this.txt_rut.Text.Trim() == "")
		//    { rut = 0; }
		//    else
		//    { rut = Convert.ToDouble(this.txt_rut.Text); }


		//    if (this.txt_operacion.Text.Trim() == "")
		//    { noperacion = 0; }
		//    else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

		//    if (this.txt_factura.Text.Trim() == "")
		//    { factura = 0; }
		//    else { factura = Convert.ToInt32(this.txt_factura.Text); }


		//    if (this.dpl_estado.SelectedValue == "")
		//    { estado_actual = 0; }
		//    else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

		//    if (this.dl_modulo.SelectedValue == "")
		//    { dl_modulo = 0; }
		//    else { dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue); }

		//    if (this.dl_sucursal.SelectedValue == "")
		//    { dl_sucursal = 0; }
		//    else { dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue); }

		//    List<Operacion> loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue,
		//                                                        dl_modulo,
		//                                                        dl_sucursal,
		//                                                        Convert.ToInt16(this.dl_cliente.SelectedValue),
		//                                                        noperacion,
		//                                                        rut,
		//                                                        factura,
		//                                                        this.txt_cliente.Text.Trim(),
		//                                                        this.txt_patente.Text.Trim(),
		//                                                        string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
		//                                                        string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())),
		//                                                        estado_actual,
		//                                                        (string)(Session["usrname"]),Convert.ToInt32(this.dl_familia.SelectedValue),
		//                                                        "TODO");

		//    DataTable dt = new DataTable();
		//    dt.Columns.Add(new DataColumn("id_solicitud"));
		//    dt.Columns.Add(new DataColumn("cliente"));
		//    dt.Columns.Add(new DataColumn("tipo_operacion"));
		//    dt.Columns.Add(new DataColumn("cod_tip_operacion"));
		//    dt.Columns.Add(new DataColumn("numero_factura"));
		//    dt.Columns.Add(new DataColumn("patente"));
		//    dt.Columns.Add(new DataColumn("total_gasto"));
		//    dt.Columns.Add(new DataColumn("numero_cliente"));
		//    dt.Columns.Add(new DataColumn("rut_persona"));
		//    dt.Columns.Add(new DataColumn("nombre_persona"));
		//    dt.Columns.Add(new DataColumn("cliente_nombre"));
		//    dt.Columns.Add(new DataColumn("ultimo_estado"));
		//    dt.Columns.Add(new DataColumn("saldo"));
            
		//    foreach (Operacion moperacion in loperacion)
		//    {
		//        DataRow dr = dt.NewRow();

		//        dr["id_solicitud"] = moperacion.Id_solicitud;
		//        dr["cliente"] = moperacion.Cliente.Id_cliente;
		//        dr["cliente_nombre"] = moperacion.Cliente.Persona.Nombre;
		//        dr["numero_factura"] = moperacion.Numero_factura;
		//        dr["patente"] = moperacion.Patente;
		//        dr["numero_cliente"] = moperacion.Numero_cliente;
		//        dr["tipo_operacion"] = moperacion.Tipo_operacion.Operacion;
		//        dr["cod_tip_operacion"] = moperacion.Tipo_operacion.Codigo;

		//        if (moperacion.Adquiriente != null)
		//        {
		//            dr["rut_persona"] = moperacion.Adquiriente.Rut;
		//            dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
		//        }
		//        else
		//        {
		//            dr["rut_persona"] = "0";
		//            dr["nombre_persona"] = "Sin Adquiriente";
		//        }

		//        dr["total_gasto"] = moperacion.Total_gasto;
		//        dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_egreso);
		//        dr["ultimo_estado"] = moperacion.Estado;
		//        dt.Rows.Add(dr);
		//    }

		//    this.gr_dato.DataSource = dt;
		//    this.gr_dato.DataBind();

		//    Carga_Link();
		//    FuncionGlobal.comboestado(this.dpl_estado, this.dl_producto.SelectedValue.Trim());
		//}

		//protected void Carga_Link()
		//{
		//    int i;
		//    GridViewRow row;
		//    HyperLink but;
		//    ImageButton ibuton;
		//    string tipo;
		//    string id_cliente;
           
		//    for (i = 0; i < gr_dato.Rows.Count; i++)
		//    {
		//        row = gr_dato.Rows[i];
		//        int cont = gr_dato.DataKeys.Count;
		//        string cliente = gr_dato.DataKeys[i].Value.ToString();

		//        if (row.RowType == DataControlRowType.DataRow)
		//        {
		//            tipo = (string)row.Cells[2].Text;

		//            but = (HyperLink)row.Cells[0].Controls[0];
                   
		//            id_cliente = (row.Cells[1].Text);
					
		//            ibuton = (ImageButton)row.FindControl("ib_workflow");
		//            ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mWorkflow.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

		//            ibuton = (ImageButton)row.FindControl("ib_comGastos");
		//            if (tipo == "MU")
		//                ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro_multa.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");
		//            else
		//                ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(this.dl_familia.SelectedValue) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");

		//            ibuton = (ImageButton)row.FindControl("ib_cdigital");
		//            ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=eo','','status:false;dialogWidth:800px;dialogHeight:600px')");

		//            if (cliente != "DOCUMENTO HIPOTECARIO")
		//            {
		//                ibuton = (ImageButton)row.FindControl("ib_vehiculo");
		//                ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../operacion/Contra_vehiculos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=eo','','status:false;dialogWidth:600px;dialogHeight:300px')");
		//            }
		//            else
		//            {
		//                ibuton = (ImageButton)row.FindControl("ib_vehiculo");
		//                ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:300px;dialogHeight:260px')");
		//            }

		//        }
		//    }
		//}
		
		//protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    if (Convert.ToInt16(this.dl_modulo.SelectedValue) == 0)
		//        FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
		//    else
		//        FuncionGlobal.combosucursalbymodulo(this.dl_sucursal, Convert.ToInt16(this.dl_modulo.SelectedValue));
		//}

		//protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    if (this.dl_producto.SelectedValue != "0")
		//    {
		//        this.lbl_flujo.Visible = true;
		//        this.dpl_estado.Visible = true;
		//        FuncionGlobal.comboestado(this.dpl_estado, this.dl_producto.SelectedValue.Trim());
		//    }
		//    else
		//    {
		//        this.lbl_flujo.Visible = false;
		//        this.dpl_estado.Visible = false;
		//    }
		//}

		//protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
		//}
    }
}