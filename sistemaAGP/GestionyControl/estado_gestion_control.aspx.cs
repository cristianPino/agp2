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
    public partial class estado_gestion_control : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
               
         
            if (!IsPostBack)
            {

                this.txt_desde.Text = DateTime.Today.ToShortDateString();
                this.txt_hasta.Text = DateTime.Today.ToShortDateString();

                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]),this.dl_cliente);
                combotipoproductocliente();
               
            }

        }

       

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
            combotipoproductocliente();
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {

            busca_operacion();
            this.ib_report.Visible = true;
            
        }
        public void carga_report()
        {
            string reporte = "InfOperacionesConYSeg.rpt";
			int id_solicitud = 0;
			if (this.txt_operacion.Text.Trim() != "")
				id_solicitud = Convert.ToInt32(this.txt_operacion.Text.Trim());
            int rut_adquiriente = 0;
            if (this.txt_operacion.Text.Trim() != "")
                rut_adquiriente = Convert.ToInt32(this.txt_rut.Text.Trim());

			string cadena = "";
			cadena += "?nombre_rpt=" + reporte;
			cadena += "&tipo_operacion=" + this.dl_producto.SelectedValue;
			cadena += "&id_cliente=" + this.dl_cliente.SelectedValue;
            cadena += "&id_solicitud=" + id_solicitud;
            cadena += "&rut_adquiriente=" + rut_adquiriente;
			cadena += "&numero_cliente=" + this.txt_cliente.Text.Trim();
			cadena += "&patente=" + "";
			cadena += "&desde=" + string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			cadena += "&hasta=" + string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
	

            
			Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('../reportes/view_report_ConYSeg.aspx" + cadena + "'); </script>");
		}

        private void combotipoproductocliente()
        {

            ProdCliente mprocliente = new ProdCliente();

            mprocliente.Id_producto_cliente = 0;
            mprocliente.Nombre = "Seleccionar";

            List<ProdCliente> lprocliente = new ProdClienteBC().getprodcliente(Convert.ToInt32(this.dl_cliente.SelectedValue));

            lprocliente.Add(mprocliente);

            this.dl_producto.DataSource = lprocliente;
            this.dl_producto.DataValueField = "id_producto_cliente";
            this.dl_producto.DataTextField = "nombre";
            this.dl_producto.DataBind();
            this.dl_producto.SelectedValue = "0";


        }
        private void busca_operacion()
        {
            this.Timer1.Enabled = false;
            double rut;
            Int32 noperacion;
            Int32 estado_actual;
            Int16 dl_sucursal;

            if (this.txt_rut.Text.Trim() == "")
            { rut = 0; }
            else
            { rut = Convert.ToDouble(this.txt_rut.Text); }

            if (this.txt_operacion.Text.Trim() == "")
            { noperacion = 0; }
            else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

            if (this.dpl_estado.SelectedValue == "")
            { estado_actual = 0; }
            else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }
          
            if (this.dl_sucursal.SelectedValue == "")
            { dl_sucursal = 0; }
            else { dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue); }

            List<Control_gestion> loperacion = new OperacionBC().getOperacionesbyCG(this.dl_producto.SelectedValue,
                                                               dl_sucursal,
                                                                Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut
                                                                , this.txt_cliente.Text.Trim(),
                                                                string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
                                                                string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())),
                                                                estado_actual, (string)(Session["usrname"]),this.chk_llamada.Checked.ToString());





            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("Cliente"));
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("total_gasto"));
            dt.Columns.Add(new DataColumn("rut_deudor"));
            dt.Columns.Add(new DataColumn("nombre_deudor"));
            dt.Columns.Add(new DataColumn("Cliente_nombre"));
            dt.Columns.Add(new DataColumn("ultimo_estado"));
            dt.Columns.Add(new DataColumn("total_gestion"));
            dt.Columns.Add(new DataColumn("numero_cuotas"));
            dt.Columns.Add(new DataColumn("numero_operacion"));
            dt.Columns.Add(new DataColumn("sucursal_origen"));
            dt.Columns.Add(new DataColumn("id_producto_cliente"));
            dt.Columns.Add(new DataColumn("llamada_programada"));
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("cuenta_regresiva"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("monto_final"));
         
            
            foreach (Control_gestion moperacion in loperacion)
            {
                DataRow dr = dt.NewRow();

                dr["id_solicitud"] = moperacion.Id_solicitud.Id_solicitud;
                dr["Cliente"] = moperacion.Id_solicitud.Cliente.Id_cliente;
				dr["Cliente_nombre"] = moperacion.Id_solicitud.Cliente.Persona.Nombre.ToUpper();
                dr["operacion"] = moperacion.Id_solicitud.Tipo_operacion.Operacion;
                dr["tipo_operacion"] = moperacion.Id_solicitud.Tipo_operacion.Codigo;
                dr["numero_cuotas"] = moperacion.Numero_cuotas;
                dr["numero_operacion"] = moperacion.Numero_operacion;
                dr["sucursal_origen"] = moperacion.Id_sucursal.Nombre;
                dr["id_producto_cliente"] = moperacion.Id_producto_cliente.Nombre;
                dr["descripcion"] = moperacion.Id_forma_pago.Descripcion;
                dr["cuenta_regresiva"] = moperacion.Cuenta_regresiva;
				dr["patente"] = moperacion.Patente;
				dr["monto_final"] = moperacion.Monto_final;

                if (moperacion.Rut != null)
                {
                    dr["rut_deudor"] = moperacion.Rut.Rut;
                    dr["nombre_deudor"] = (moperacion.Rut.Nombre + " " + moperacion.Rut.Apellido_paterno + " " + moperacion.Rut.Apellido_materno).ToUpper();
                }
                else
                {
                    dr["rut_deudor"] = "0";
                    dr["nombre_deudor"] = "Sin Adquiriente";
                }

                dr["total_gestion"] =FuncionGlobal.NumeroConFormato(moperacion.Total_gestion.ToString());
                dr["fecha"] = string.Format("{0:dd/MM/yyyy}",moperacion.Fecha_gestion);
                dr["ultimo_estado"] = moperacion.Id_solicitud.Estado;
                dr["llamada_programada"] = moperacion.Programacion;
                string date = moperacion.Programacion.ToString();
                if (date == " ")
                {
                    date = "01/01/2040";
                }

                DateTime fechallamada = Convert.ToDateTime(date.ToString());

                if (fechallamada <= DateTime.Now)
                {
                    this.Timer1.Enabled = true;
                }

                dt.Rows.Add(dr);


            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

           

            Carga_Link();
           


        }

        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
            HyperLink but;
            ImageButton ibuton;
            string tipo;
            string id_cliente;
            string nombre;
           


            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                int cont = gr_dato.DataKeys.Count;
                //string cliente = gr_dato.DataKeys[i].Value.ToString();
                tipo = gr_dato.DataKeys[i].Values[0].ToString() ;
                id_cliente = gr_dato.DataKeys[i].Values[1].ToString();

                if (row.RowType == DataControlRowType.DataRow)
                {

                   
                    nombre = (string)row.Cells[4].Text;

                    but = (HyperLink)row.Cells[0].Controls[0];
                   
                   
                  

                    TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "','','status:false;dialogWidth:650px;dialogHeight:550px')");

                    ibuton = (ImageButton)row.FindControl("ib_workflow");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../GestionyControl/mOperacion_estado_GyC.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(tipo) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&nombre_estado=" + nombre + "','','status:false;dialogWidth:500px;dialogHeight:280px')");

                    //ibuton = (ImageButton)row.FindControl("ib_Contactos");
                    //ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../GestionyControl/mDatos_Contacto.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','_blank','dilogheight=200,dialogwidth=400, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')");

                    ibuton = (ImageButton)row.FindControl("ib_cargar");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo="+ tipo + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

                    ibuton = (ImageButton)row.FindControl("ib_cdigital");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:800px;dialogHeight:600px')");



                }
            }
        }

      

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


      
        protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getestado(string tipo, DropDownList combo)
        {
            EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();

            mEstadotipooperacion.Codigo = "0";
            mEstadotipooperacion.Descripcion = "Seleccionar";

            List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionBC().getEstadoByTipooperacion(tipo);


            lEstadotipooperacion.Add(mEstadotipooperacion);

            combo.DataSource = lEstadotipooperacion;
            combo.DataValueField = "codigo_estado";
            combo.DataTextField = "descripcion";
            combo.DataBind();
            combo.SelectedValue = "0";



            return;


        }

        protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dl_producto.SelectedValue != "0")
            {
                this.lbl_flujo.Visible = true;
                this.dpl_estado.Visible = true;
                getestado(this.dl_producto.SelectedValue, this.dpl_estado);
            }
            else
            {
                this.lbl_flujo.Visible = false;
                this.dpl_estado.Visible = false;
            }



        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            FuncionGlobal.alerta_updatepanel("llamada programada no realizada", this.Page, this.UpdatePanel2);
       
        }

        protected void ib_exel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToSpreadsheet();
        }
        private void ExportToSpreadsheet()
        {

           
            double rut;
            Int32 noperacion;
            Int32 estado_actual;
            Int16 dl_sucursal;
         
            if (this.txt_rut.Text.Trim() == "")
            { rut = 0; }
            else
            { rut = Convert.ToDouble(this.txt_rut.Text); }

            if (this.txt_operacion.Text.Trim() == "")
            { noperacion = 0; }
            else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

            if (this.dpl_estado.SelectedValue == "")
            { estado_actual = 0; }
            else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

            if (this.dl_sucursal.SelectedValue == "")
            { dl_sucursal = 0; }
            else { dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue); }

            List<Control_gestion> loperacion = new OperacionBC().getOperacionesbyCG(this.dl_producto.SelectedValue,
                                                               dl_sucursal,
                                                                Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut
                                                                , this.txt_cliente.Text.Trim(),
                                                                string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
                                                                string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())),
                                                                estado_actual, (string)(Session["usrname"]), this.chk_llamada.Checked.ToString());


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("Cliente"));
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("total_gasto"));
            dt.Columns.Add(new DataColumn("rut_deudor"));
            dt.Columns.Add(new DataColumn("nombre_deudor"));
            dt.Columns.Add(new DataColumn("Cliente_nombre"));
            dt.Columns.Add(new DataColumn("ultimo_estado"));
            dt.Columns.Add(new DataColumn("total_gestion"));
            dt.Columns.Add(new DataColumn("numero_cuotas"));
            dt.Columns.Add(new DataColumn("numero_operacion"));
            dt.Columns.Add(new DataColumn("sucursal_origen"));
            dt.Columns.Add(new DataColumn("id_producto_cliente"));
            dt.Columns.Add(new DataColumn("llamada_programada"));
            dt.Columns.Add(new DataColumn("descripcion"));


            foreach (Control_gestion moperacion in loperacion)
            {
                DataRow dr = dt.NewRow();

                dr["id_solicitud"] = moperacion.Id_solicitud.Id_solicitud;
                dr["Cliente"] = moperacion.Id_solicitud.Cliente.Id_cliente;
                dr["Cliente_nombre"] = moperacion.Id_solicitud.Cliente.Persona.Nombre;
                dr["operacion"] = moperacion.Id_solicitud.Tipo_operacion.Operacion;
                dr["tipo_operacion"] = moperacion.Id_solicitud.Tipo_operacion.Codigo;
                dr["numero_cuotas"] = moperacion.Numero_cuotas;
                dr["numero_operacion"] = moperacion.Numero_operacion;
                dr["sucursal_origen"] = moperacion.Id_sucursal.Nombre;
                dr["id_producto_cliente"] = moperacion.Id_producto_cliente.Nombre;
                dr["descripcion"] = moperacion.Id_forma_pago.Descripcion;

                if (moperacion.Rut != null)
                {
                    dr["rut_deudor"] = moperacion.Rut.Rut;
                    dr["nombre_deudor"] = moperacion.Rut.Nombre + " " + moperacion.Rut.Apellido_paterno + " " + moperacion.Rut.Apellido_materno;
                }
                else
                {
                    dr["rut_deudor"] = "0";
                    dr["nombre_deudor"] = "Sin Adquiriente";
                }

                dr["total_gestion"] = moperacion.Total_gestion;
                dr["fecha"] = string.Format("{0:dd/MM/yyyy}", moperacion.Fecha_gestion);
                dr["ultimo_estado"] = moperacion.Id_solicitud.Estado;
                dr["llamada_programada"] = moperacion.Programacion;
                

                dt.Rows.Add(dr);

            }
         
            HttpContext context = HttpContext.Current;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringwrite = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(stringwrite);


            Page page = new Page();
            HtmlForm form = new HtmlForm();

            GridView gr = new GridView();
            gr.DataSource = dt;
            gr.DataBind();



            //HtmlTable table = new HtmlTable();
            //foreach (GridViewRow r in gr_dato.Rows)
            //{
            //    HtmlTableRow row = new HtmlTableRow();
            //    for (Int32 i = 0; i < r.Cells.Count; i++)
            //    {
            //        HtmlTableCell cell = new HtmlTableCell();
            //        cell.InnerText = r.Cells[i].Text;
            //        row.Cells.Add(cell);
            //    }
            //    table.Rows.Add(row);
            //}
            


            //this.gr_dato.EnableViewState = false;
            //form.Controls.Add(table);
            form.Controls.Add(gr);
            page.Controls.Add(form);
            //form.Controls.Add(this.gr_dato);
            page.RenderControl(htmlwriter);

			context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.ContentType = "application/vnd.ms-excel";
			context.Response.AppendHeader("Content-Disposition", "attachment; runat="+"Server;"+" filename=" + "informe" + ".xls");
            context.Response.Charset = "UTF-8";
            context.Response.ContentEncoding = System.Text.Encoding.Default;
            context.Response.Write(sb.ToString());
			context.Response.End();

            
	
        }

        protected void chk_llamada_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ib_report_Click(object sender, ImageClickEventArgs e)
        {
            carga_report();
        }

    }
}

