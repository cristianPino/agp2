using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
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
    public partial class control_analisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_desde.Text = DateTime.Today.ToShortDateString();
                this.txt_hasta.Text = DateTime.Today.ToShortDateString();
                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
                FuncionGlobal.combotipooperacion(this.dl_producto);
            }
        }

        protected void Click_Gasto(Object sender, EventArgs e)
        {
            busca_operacion();
        }

        protected void Click_workflow(Object sender, EventArgs e)
        {
            busca_operacion();
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
            FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal,
                                                           Convert.ToInt16(this.dl_cliente.SelectedValue),
                                                           (string)(Session["usrname"]));
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                busca_operacion();
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta_updatepanel("Existe el siguiente Error: " + ex.Message, Page, UpdatePanel2);
            }

        }

        private void busca_operacion()
        {
            if (txt_desde.Text == string.Empty && txt_hasta.Text == string.Empty)
            {
                FuncionGlobal.alerta_updatepanel("Debe indicar fehchas de inicio y termino", Page, UpdatePanel2);
                return;
            }

            int noperacion = txt_operacion.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(this.txt_operacion.Text);

            List<Transferencia> loperacion = new OperacionBC().getOperacionesbyTR(dl_producto.SelectedValue,
                                                                                  0,
                                                                                  0,
                                                                                  Convert.ToInt16(dl_cliente.SelectedValue),
                                                                                  noperacion,
                                                                                  0,
                                                                                  0,
                                                                                  string.Empty,
                                                                                  txt_patente.Text.Trim(),
                                                                                  string.Format("{0:yyyyMMdd}",
                                                                                                Convert.ToDateTime(
                                                                                                    this.txt_desde.Text.
                                                                                                        Trim())),
                                                                                  string.Format("{0:yyyyMMdd}",
                                                                                                Convert.ToDateTime(
                                                                                                    this.txt_hasta.Text.
                                                                                                        Trim())),
                                                                                  0,
                                                                                  (string)(Session["usrname"]));

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("id_cliente"));
            dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("ejecutivo"));
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("cuenta_usuario"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("estado_operacion"));
            dt.Columns.Add(new DataColumn("codigo_estado"));
            dt.Columns.Add(new DataColumn("total_gasto"));
            DataColumn col = new DataColumn("check");
            col.DataType = Type.GetType("System.Boolean");
            dt.Columns.Add(col);

            dt.Columns.Add(new DataColumn("url_gasto"));
            dt.Columns.Add(new DataColumn("url_cav"));
            dt.Columns.Add(new DataColumn("url_autopista"));
            dt.Columns.Add(new DataColumn("url_cargar"));
           // dt.Columns.Add(new DataColumn("url_carpeta"));
            dt.Columns.Add(new DataColumn("url_alzamiento"));
            dt.Columns.Add(new DataColumn("url_estado"));
            dt.Columns.Add(new DataColumn("url_contrato"));
            dt.Columns.Add(new DataColumn("color_alzamiento"));
            dt.Columns.Add(new DataColumn("urlProcesos"));
            dt.Columns.Add(new DataColumn("url_op"));

            foreach (Transferencia moperacion in loperacion)
            {
                DataRow dr = dt.NewRow();

                SucursalCliente sucu = new SucursalclienteBC().GetSucursalShort(Convert.ToInt16(moperacion.Id_sucursal));

                dr["id_solicitud"] = moperacion.Operacion.Id_solicitud;
                dr["cliente"] = moperacion.Operacion.Cliente.Persona.Nombre;
                dr["id_cliente"] = moperacion.Operacion.Cliente.Id_cliente;
                dr["sucursal"] = sucu.Nombre;
                dr["ejecutivo"] = moperacion.Ejecutivo.Nombre;
                dr["estado_operacion"] = moperacion.Operacion.Estado;
                dr["codigo_estado"] = moperacion.Operacion.Id_estado;
                dr["patente"] = moperacion.Patente;
                dr["check"] = moperacion.Check;
                dr["nombre"] = moperacion.Operacion.Usuario.Nombre;
                dr["cuenta_usuario"] = moperacion.Operacion.Usuario.UserName;
                dr["tipo_operacion"] = moperacion.Operacion.Tipo_operacion.Codigo.Trim();
                dr["operacion"] = moperacion.Operacion.Tipo_operacion.Operacion;
                dr["total_gasto"] = moperacion.Operacion.Total_gasto;

                string usuarioSesion = Session["usrname"].ToString().Trim();

                if ((moperacion.Operacion.Usuario.UserName.Trim() == usuarioSesion && moperacion.Check) ||
                    (moperacion.Operacion.Estado.Trim() != "INGRESO AGP"))
                {

                    var idOperacionEncriptado = FuncionGlobal.FuctionEncriptar(moperacion.Operacion.Id_solicitud.ToString().Trim());
                    var patenteEncriptada = FuncionGlobal.FuctionEncriptar(moperacion.Patente);
                    var idClienteEncriptado = FuncionGlobal.FuctionEncriptar(moperacion.Operacion.Cliente.Id_cliente.ToString(CultureInfo.InvariantCulture));

                    dr["url_op"] = moperacion.Operacion.Tipo_operacion.Url_operacion + idOperacionEncriptado + "&id_cliente=" + idClienteEncriptado + "&patente=" + moperacion.Patente.Trim() + "&ventatipo=" + "&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar("0") ;

                    dr["url_gasto"] = "../operacion/gastooperacion.aspx?id_solicitud=" + idOperacionEncriptado;
                    dr["url_cav"] = "analisis_patente.aspx?id_solicitud=" + idOperacionEncriptado + "&patente=" + patenteEncriptada;
                    dr["url_autopista"] = "IngresoAutopistas.aspx?id_solicitud=" + idOperacionEncriptado + "&patente=" + patenteEncriptada;
                    dr["url_cargar"] = "../digitalizacion/Visualizador.aspx?id_solicitud=" + idOperacionEncriptado + "&tipo=" + moperacion.Operacion.Tipo_operacion.Codigo.Trim();                  
                    dr["url_alzamiento"] = "Analisis_Alzamiento.aspx?id_solicitud=" + idOperacionEncriptado;
                    dr["url_estado"] = "../operacion/mOperacion_estado.aspx?tipo=" +
                                                                                   FuncionGlobal.FuctionEncriptar(moperacion.Operacion.Tipo_operacion.Codigo.Trim()) +
                                                                                   "&id_cliente=" + idClienteEncriptado + "&id_solicitud=" + idOperacionEncriptado
                                                                                   + "&nombre_estado=" + moperacion.Operacion.Tipo_operacion.Operacion;

                    dr["url_contrato"] = "../reportes/contratos_rpt.aspx?id_solicitud=" + idOperacionEncriptado;

                    Analisis_Alza malza = new Analisis_AlzaBC().getAnalisis_Alza(moperacion.Operacion.Id_solicitud);

                    if (malza.Cod_financiera != null)
                    {
                        dr["color_alzamiento"] = "../imagenes/sistema/static/ok.png";
                    }
                    else
                    {
                        dr["color_alzamiento"] = "../imagenes/sistema/static/no-small.jpg";
                    }

                    dr["urlProcesos"] = @"../preinscripcion/InfoAutoProcesos.aspx?id_solicitud=" + idOperacionEncriptado;
                }

                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        protected string eliminar(string id_solicitud)
        {
            string elim = "";
            Operacion moperacion = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

            string act = new StockVentasBC().act_stockventa(Convert.ToInt32(id_solicitud));

            if (moperacion.Tipo_operacion.Codigo.Trim() == "CCV")
            {
                elim = new StockVentasBC().act_compra(Convert.ToInt32(id_solicitud));
            }
            else
            {
                elim = new OperacionBC().del_operacion(Convert.ToInt32(id_solicitud), (string)(Session["usrname"]));
            }
            busca_operacion();
            return elim;
        }


        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow roww;
            GridViewRow row;
            int i = this.gr_dato.SelectedIndex;
            roww = gr_dato.Rows[i];
            row = gr_dato.Rows[i];
            
            int idSolicitud = Convert.ToInt32(gr_dato.DataKeys[i]["id_solicitud"]);
            var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
            var nombre = gr_dato.DataKeys[i].Value.ToString();
            var tipo_operacion = gr_dato.DataKeys[i].Value.ToString();


            var check = (CheckBox)gr_dato.Rows[i].FindControl("chk");

            var o = new EstadooperacionBC().getUltimoEstadoByIdoperacion(Convert.ToInt32(idSolicitud));
            if (check.Checked && o.Estado_operacion.Descripcion == "ANALISIS MANUAL")
            {
                new InfoAutoBC().Reset_solicitudDVCancelar(Convert.ToInt32(idSolicitud));
            }
            if (check.Checked) return;
            chk.Checked = true;

            if (!chk.Checked) return;

            var tipo = new OperacionBC().getoperacion(Convert.ToInt32(idSolicitud));
            var orden = tipo.Tipo_operacion.Codigo.Trim() == "INFAU" ? 5 : 3;
            new EstadooperacionBC().add_estado_orden(Convert.ToInt32(idSolicitud), orden, nombre,
                                                     "tomado para analisis", (string)(Session["usrname"]));

            roww.Cells[16].Text = "EN ANALISIS";
            roww.Cells[17].Text = new UsuarioBC().GetUsuario((string)(Session["usrname"])).Nombre;

        }


        protected void gr_dato_onRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HyperLink but;
            GridViewRow row;
            row = gr_dato.Rows[e.RowIndex];
            but = (HyperLink)row.Cells[0].Controls[0];

            string elimi = eliminar(but.Text.ToString().Trim());

        }

        protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

        protected void Check_Clicked_Grilla(Object sender, EventArgs e)
        {

        }

        protected void Click_contratos(Object sender, EventArgs e)
        {

        }

        protected void Click_alzamiento(Object sender, EventArgs e)
        {
            busca_operacion();
        }

        protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nombre;

                string tipo = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string patente = (string)e.Row.Cells[6].Text;
                int cont = this.gr_dato.DataKeys.Count;
                Int16 id_cliente = Convert.ToInt16(this.gr_dato.DataKeys[e.Row.RowIndex].Values[3].ToString());
                nombre = (string)e.Row.Cells[4].Text;              
                var usuario = gr_dato.DataKeys[e.Row.RowIndex]["cuenta_usuario"];             
                var codEstado = Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex]["codigo_estado"]);

                var coperfil = new PerfilBC().GetPerfilByUsrName(Session["usrname"].ToString());
                var boton = (ImageButton)e.Row.FindControl("reiniciar");
                var btnAnalisisManual = (ImageButton)e.Row.FindControl("iBaManual"); 

                if (tipo.Trim() == "INFAU" || tipo.Trim() == "CTM" || tipo.Trim() == "CTMAC" || tipo.Trim() == "CCV" || tipo.Trim() == "CTC" || tipo.Trim() == "CTMAG")
                {
                    boton.Visible = true;
                    if (codEstado == 11 || codEstado == 12)
                    {
                        btnAnalisisManual.Visible = true;
                    }
                    else 
                    {
                        btnAnalisisManual.Visible = false;
                    }
                }
                else
                {
                    boton.Visible = false;
                }
            }
        }


        protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reiniciar")
            {
                var row = Convert.ToInt32(e.CommandArgument);
                var tipooperacion = gr_dato.DataKeys[row]["tipo_operacion"].ToString();
                if (tipooperacion == "INFAU" || tipooperacion == "CTM" || tipooperacion == "CTMAC" ||
                    tipooperacion == "CCV" || tipooperacion == "CTC" || tipooperacion == "CTMAG")
                {
                    var idSolicitud = Convert.ToInt32(gr_dato.DataKeys[row]["id_solicitud"]);
                    new OperacionBC().reiniciar_operacion_infoauto(idSolicitud);
                    busca_operacion();
                }
                FuncionGlobal.alerta_updatepanel("La operación ha sido reiniciada.", Page, UpdatePanel2);
            }
            else if (e.CommandName == "VespucioSur")
            {
                var row = Convert.ToInt32(e.CommandArgument);
                var estadoOperacion = gr_dato.DataKeys[row]["estado_operacion"].ToString();
                if (estadoOperacion != "CONSULTANDO AUTOPISTAS")
                {
                    FuncionGlobal.alerta_updatepanel("Sólo se puede avanzar en el estado CONSULTANDO AUTOPISTAS.", Page, UpdatePanel2);
                    return;
                }
                var dataKey = gr_dato.DataKeys[row];
                if (dataKey != null)
                {
                    var idSolicitud = Convert.ToInt32(dataKey["id_solicitud"]);
                    new OperacionBC().AvanzarVs(idSolicitud);
                    FuncionGlobal.alerta_updatepanel("Se avanzó vespucio Sur.", Page, UpdatePanel2);
                }
                else
                {
                    FuncionGlobal.alerta_updatepanel("No se pudo continuar.", Page, UpdatePanel2);
                }
            }

            else if (e.CommandName == "aManual")
            {
                var row = Convert.ToInt32(e.CommandArgument);
                var dataKey = gr_dato.DataKeys[row];
                if (dataKey != null)
                {
                    var idSolicitud = Convert.ToInt32(dataKey["id_solicitud"]);
                    var usuario = Session["usrname"].ToString();
                    new InfoAutoBC().Up_DicomVehiculoAnalisisManual(idSolicitud, usuario);
                }
            }

        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    //var timer = new Timer();

        //    //timer.Enabled = true;
        //    //timer.Interval = 15000;
        //    //timer.Enabled = true;
        //    //timer.Tick += BuscandoNuevaOperacion;
        //    Timer1.Interval = 3600;
        //    //gr_dato.DataBind();
        //    //busca_operacion();
        //}

        protected void gr_dato_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            gr_dato.DataBind();
        }


    }
}