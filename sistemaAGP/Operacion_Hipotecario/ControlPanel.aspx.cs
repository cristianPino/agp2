using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP.Operacion_Hipotecario
{
    public partial class ControlPanelCertificados : Page
    {

        public int FolioNomina = 0;
        #region ENUMS y CONSTANTES
         
        const int ESTADO_FACTURACION = 330;
        const int NOMINA_FACTURACION = 182;
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
                     

            if (IsPostBack) return;
            //Instancio al usuario session 
            var usuario = new UsuarioBC().GetUsuario(Session["usrname"].ToString());
            //se llenan los combo
            FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), dlCliente);
            FuncionGlobal.ComboUsuarioEstado(dlEstados, Session["usrname"].ToString(), 22);
            EstadosManuales(dlCambioEstado);
            dlTipoBusquedaMasiva.Items.Add("Busqueda masiva por Nº Banco");
            dlTipoBusquedaMasiva.Items.Add("Busqueda masiva por Rut Comprador");
            dlTipoBusquedaMasiva.Items.Add("Busqueda masiva por Número Factura");
            dlTipoBusquedaMasiva.Items.Add("Busqueda masiva por Id");
            ////este combo trae los productos de la familia para cuando el usuario requiera un cambio de producto
            //FuncionGlobal.comboProductobyfamilia(dl_producto_cambio, 22);
            dlCambioEstado.Items[0].Text = "¿A que estado cambiarás?";
            dlProductos.Items.Add(new ListItem("Productos del cliente", "0"));
            //Lleno el Dashboard dependiendo del usuario
            UsuarioDAshboard();
            //Mensaje de bienvenida una vez terminada la carga
            Mensajes("Bienvenido a tu panel de control", Enums.TiposMensajes.Bienvenido);
        }

               

        /// <summary>
        /// Llena Combobox estados manuales; 
        /// Familia 22 Hipotecario
        /// </summary>
        /// <param name="combobox"></param>
        public void EstadosManuales(DropDownList combobox)
        {

            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccion", "0"));
            combobox.DataSource = from e in new EstadotipooperacionBC().getEstadoByFamilia(22)
                                  where e.Estado_manual
                                  orderby e.Orden
                                  select new
                                  {
                                      codigo_estado = e.Codigo_estado,
                                      descripcion = e.Descripcion.ToUpper().Trim()
                                  };
            combobox.DataValueField = "codigo_estado";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }



        public DataTable ListaMasiva()
        {

            string[] split = txtBcoMultiple.Text.Split(new Char[] { ' ', ',', '.', ':', '\t', '\n' });
            var data = new DataTable();
            data.Columns.Add(new DataColumn("dato"));

            foreach (string s in split)
            {
                if (s.Trim() == string.Empty) continue;
                var dr = data.NewRow();
                dr["dato"] = s.Trim();
                data.Rows.Add(dr);
            }
            return data;
        }

        public DataTable GetOperaciones(int semaforo)
        {
            try
            {
                var dt = new DataTable();
                var semaforoBusqueda = string.Empty;
                switch (semaforo)
                {
                    case 1:
                        semaforoBusqueda = Constantes.IMAGEN_SEMAFORO_VERDE;
                        break;
                    case 2:
                        semaforoBusqueda = Constantes.IMAGEN_SEMAFORO_AMARILLO;
                        break;
                    case 3:
                        semaforoBusqueda = Constantes.IMAGEN_SEMAFORO_ROJO;
                        break;
                }

                var factura = 0;
                if (txtFactura.Value != "Factura" && txtFactura.Value.Trim() != string.Empty)
                {
                    factura = Convert.ToInt32(txtFactura.Value);
                }
                var idSolicitud = 0;
                if (txtAgp.Value != "Nº AGP" && txtAgp.Value.Trim() != string.Empty)
                {
                    idSolicitud = Convert.ToInt32(txtAgp.Value);
                }

                var tipoOperacion = dlProductos.SelectedValue == null ? "0" : dlProductos.SelectedValue.Trim();

                //busqueda masiva y filtro semaforo

                DataTable dataTableNumerosBanco = null;
                DataTable dataTableRut = null;
                DataTable dataTableFactura = null;
                DataTable dataTableIdSolicitud = null;

                if (txtBcoMultiple.Text.Trim() != string.Empty)
                {
                    switch (dlTipoBusquedaMasiva.Text)
                    {
                        case "Busqueda masiva por Nº Banco":
                            dataTableNumerosBanco = ListaMasiva();
                            break;
                        case "Busqueda masiva por Rut Comprador":
                            dataTableRut = ListaMasiva();
                            break;
                        case "Busqueda masiva por Id":
                            dataTableIdSolicitud = ListaMasiva();
                            break;
                        case "Busqueda masiva por Número Factura":
                            dataTableFactura = ListaMasiva();
                            break;
                    }
                }


                var lista = new HipotecarioBC().GetOperacionesHipotecario(tipoOperacion.Trim(),
                                                                          semaforoBusqueda,
                                                                          Session["usrname"].ToString().Trim(),
                                                                          txtRutComprador.Value.Trim(),
                                                                          txtNumeroBco.Value.Trim(),
                                                                          Convert.ToInt32(dlCliente.SelectedValue),
                                                                          dlEstados.SelectedValue.Trim(),
                                                                          idSolicitud,
                                                                          factura,
                                                                          dataTableNumerosBanco,
                                                                          dataTableRut,
                                                                          dataTableIdSolicitud,
                                                                          dataTableFactura);



                dt.TableName = "ordenes";
                dt.Columns.Add(new DataColumn("idSolicitud"));
                dt.Columns.Add(new DataColumn("idCliente"));
                dt.Columns.Add(new DataColumn("cliente"));
                dt.Columns.Add(new DataColumn("sucursal"));
                dt.Columns.Add(new DataColumn("comprador"));
                dt.Columns.Add(new DataColumn("nombreActividad"));
                dt.Columns.Add(new DataColumn("fechaInicio"));
                dt.Columns.Add(new DataColumn("horasActividad"));
                dt.Columns.Add(new DataColumn("codigoEstado"));
                dt.Columns.Add(new DataColumn("sla"));
                dt.Columns.Add(new DataColumn("semaforo"));
                dt.Columns.Add(new DataColumn("url_estado"));
                dt.Columns.Add(new DataColumn("urlCarpeta"));
                dt.Columns.Add(new DataColumn("rutComprador"));
                dt.Columns.Add(new DataColumn("urlTareas"));
                dt.Columns.Add(new DataColumn("numeroBanco"));
                dt.Columns.Add(new DataColumn("url_gastos"));
                dt.Columns.Add(new DataColumn("url_hito"));
                dt.Columns.Add(new DataColumn("tipoOperacion"));
                dt.Columns.Add(new DataColumn("gestoria"));
                dt.Columns.Add(new DataColumn("url_nominas"));
                dt.Columns.Add(new DataColumn("total_gastos"));
                dt.Columns.Add(new DataColumn("total_ingresos"));
                dt.Columns.Add(new DataColumn("saldo"));
                dt.Columns.Add(new DataColumn("factura"));



                foreach (var h in lista)
                {
                    var dr = dt.NewRow();
                    //encripto el id solicitud para usarlo varias veces.
                    var idSolicitudEncriptado = FuncionGlobal.FuctionEncriptar(h.IdSolicitud.ToString(CultureInfo.InvariantCulture).Trim());
                    dr["idSolicitud"] = h.IdSolicitud;
                    dr["cliente"] = h.NombreClienteAgp;
                    dr["idCliente"] = h.IdClienteAgp;
                    dr["numeroBanco"] = h.Numero;
                    dr["sucursal"] = h.Sucursal.Nombre;
                    dr["comprador"] = h.NombreComprador;
                    dr["nombreActividad"] = h.EstadoDescripcion;
                    dr["fechaInicio"] = h.FechaInicioEstado;
                    dr["horasActividad"] = h.ContadorEtapa + "/ " + h.Sla;
                    dr["tipoOperacion"] = h.TipoOperacion.Operacion.ToUpper();
                    dr["codigoEstado"] = h.Estado;
                    dr["total_gastos"] = h.TotalGastos;
                    dr["total_ingresos"] = h.TotalIngreso;
                    dr["saldo"] = Convert.ToInt32(h.TotalGastos.Trim()) - Convert.ToInt32(h.TotalIngreso.Trim());
                    dr["factura"] = h.NumeroFactura;
                    dr["sla"] = h.Sla;

                    //si la operacion está terminada  379
                    if (h.Estado == "379")
                    {
                        dr["semaforo"] = Constantes.IMAGEN_BANDERA_FINISH;
                    }
                    else
                    {
                        dr["semaforo"] = h.SemaforoImagen;
                    }
                    dr["url_estado"] = "../Flujo/ControlFlujo.aspx?id_solicitud=" + idSolicitudEncriptado + "&codigo_estado=" + FuncionGlobal.FuctionEncriptar(h.Estado) + "&tipo=" +
                                       h.TipoOperacion.Codigo.Trim();
                    dr["urlCarpeta"] = "../digitalizacion/Visualizador.aspx?id_solicitud=" + idSolicitudEncriptado + "&tipo=" + h.TipoOperacion.Codigo.Trim();
                    dr["rutComprador"] = h.RutComprador;
                    dr["url_hito"] = "../operacion/SubEstados.aspx?id_solicitud=" + h.IdSolicitud.ToString(CultureInfo.InvariantCulture).Trim() + "&id_estado=" + h.IdEstado;
                    dr["urlTareas"] = "~/" + h.Modal + "?id_solicitud=" + idSolicitudEncriptado;
                    dr["urlTareas"] = dr["urlTareas"] + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(h.IdClienteAgp.ToString(CultureInfo.InvariantCulture));
                    dr["urlTareas"] = dr["urlTareas"] + "&tipo_operacion=" + h.TipoOperacion.Codigo.Trim();
                    dr["urlTareas"] = dr["urlTareas"] + "&solo_lectura=" + FuncionGlobal.FuctionEncriptar("0") + "&idEstado=" + h.IdEstado;
                    dr["url_nominas"] = "../operacion/nominabyoperacion.aspx?id_solicitud=" + idSolicitudEncriptado;
                    dr["url_gastos"] = "../operacion/gastooperacion.aspx?id_solicitud=" + idSolicitudEncriptado;
                    dt.Rows.Add(dr);
                }

                return dt;

            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta_updatepanel(ex.Message, this.Page, UpdatePanel1);
                Mensajes(ex.Message, Enums.TiposMensajes.Error);
            }
            return null;
        }

        public void LlenaGrilla(int semaforo)
        {
            var dt = GetOperaciones(semaforo);

            //indico cuantas filas encontró la búsqueda
            var conteoFilas = dt.Rows.Count;
            lblConteoOperaciones.Text = conteoFilas.ToString(CultureInfo.InvariantCulture);

            //lleno la grilla
            gr_dato.DataSource = dt;
            gr_dato.DataBind();

            //guardo la busqueda en memoria
            //ViewState["operacionesHipotecario"] = dt;
            hdnBusqueda.Value = Convert.ToString(semaforo);
            //cada vez que se llene la gridview principal, se setea en 0 el label que indica las operaciones seleccionadas por el usuario
            ScriptManager.RegisterStartupScript(udp, GetType(), "setConteoSeleccion", "setearSel();", true);
        }

        /// <summary>
        /// UsuarioDAshboard()
        /// Llena Control de mando
        /// </summary>
        public void UsuarioDAshboard()
        {
            //trae una lista con las operaciones y sus semaforos y estados actuales
            var lista = new HipotecarioBC().GetUsuarioDashboard(Session["usrname"].ToString().Trim());
            var totalOperaciones = lista.Count;
            var totalRojas = 0;
            var totalVerdes = 0;
            var totalAmarillas = 0;
            var totalDias = 0;
            var diaMayor = 0;
            //Recorro las operaciones
            foreach (var x in lista)
            {   //aumento los contadores de los semaforos.
                switch (x.SemaforoImagen.Trim())
                {
                    case Constantes.IMAGEN_SEMAFORO_VERDE:
                        totalVerdes++;
                        break;
                    case Constantes.IMAGEN_SEMAFORO_AMARILLO:
                        totalAmarillas++;
                        break;
                    case Constantes.IMAGEN_SEMAFORO_ROJO:
                        totalRojas++;
                        break;
                }
                //Suma la cantidad de dias de la operación desde su creación
                totalDias = totalDias + x.ContadorOperacion;
                //se va guardando el día mayor dentro de la variable diaMayor
                if (diaMayor < x.ContadorOperacion)
                {
                    diaMayor = x.ContadorOperacion;
                }
            }
            //Si existen operaciones
            if (totalOperaciones > 0)
            {
                var porcentajeRojas = totalRojas > 0 ? (Convert.ToDouble(totalRojas) / Convert.ToDouble(totalOperaciones) * 100) : 0;
                var porcentajeAmarilla = totalAmarillas > 0 ? (Convert.ToDouble(totalAmarillas) / Convert.ToDouble(totalOperaciones) * 100) : 0;
                var porcentajeVerde = totalVerdes > 0 ? (Convert.ToDouble(totalVerdes) / Convert.ToDouble(totalOperaciones) * 100) : 0;
                var promedioDias = totalOperaciones > 0 ? totalDias / totalOperaciones : 0;

                lblTotalOp.Text = totalOperaciones.ToString(CultureInfo.InvariantCulture);
                lblRojas.Text = totalRojas.ToString(CultureInfo.InvariantCulture);
                lblrojasprom.Text = Math.Round(porcentajeRojas, 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblAmarillas.Text = totalAmarillas.ToString(CultureInfo.InvariantCulture);
                lblAmarillasprom.Text = Math.Round(porcentajeAmarilla, 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblVerdes.Text = totalVerdes.ToString(CultureInfo.InvariantCulture);
                lblVerdesprom.Text = Math.Round(porcentajeVerde, 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblDiaMayor.Text = diaMayor.ToString(CultureInfo.InvariantCulture);
                lblPromedioDias.Text = promedioDias.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                lblTotalOp.Text = "0";
                lblRojas.Text = totalRojas.ToString(CultureInfo.InvariantCulture);
                lblrojasprom.Text = "0" + "%";
                lblAmarillas.Text = "0";
                lblAmarillasprom.Text = "0" + "%";
                lblVerdes.Text = "0";
                lblVerdesprom.Text = "0" + "%";
                lblDiaMayor.Text = "0";
                lblPromedioDias.Text = "0" + "%";
            }         

        }

        /// <summary>
        /// Mensajes que muestra el sistema.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="tipo"></param>
        public void Mensajes(string mensaje, Enums.TiposMensajes tipo)
        {
            Master.LblInfo.Text = mensaje;

            switch (tipo)
            {
                case Enums.TiposMensajes.Correcto:
                    Master.ImeInfo.ImageUrl = Constantes.IMAGEN_SEMAFORO_VERDE;
                    break;
                case Enums.TiposMensajes.Informacion:
                    Master.ImeInfo.ImageUrl = Constantes.IMAGEN_SEMAFORO_AMARILLO;
                    break;
                case Enums.TiposMensajes.Error:
                    Master.ImeInfo.ImageUrl = Constantes.IMAGEN_SEMAFORO_ROJO;
                    break;
                case Enums.TiposMensajes.Bienvenido:
                    Master.ImeInfo.ImageUrl = Constantes.IMAGEN_BIENVENIDO;
                    break;
            }
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LlenaGrilla(0);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, Enums.TiposMensajes.Error);
            }
        }

        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            //llama a javascript para cabecera de grilla estatica
            ScriptManager.RegisterStartupScript(udp, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LlenaGrilla(1); //1 filtra por verdes
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, Enums.TiposMensajes.Error);
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LlenaGrilla(2);  //2 filtra por amarillos
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, Enums.TiposMensajes.Error);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LlenaGrilla(3); //3 filtra por rojos
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, Enums.TiposMensajes.Error);
            }
        }
        public int Acciones(Enums.TipoAcciones accion)
        {
            var total = 0;
            var correctas = 0;
            var tipoNomina = new TipoNomina();
            bool seObtuvoTipoNomina = false;

            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
                var dataKey = gr_dato.DataKeys[i];
                if (dataKey == null) continue;
                if (dataKey.Values == null) continue;
                var id = Convert.ToInt32(dataKey.Values["idSolicitud"]);
                var estadoActual = Convert.ToInt32(dataKey.Values["codigoEstado"]);
                var idCliente = Convert.ToInt32(dataKey.Values["idCliente"]);

                //por cada seleccion de la grilla
                if (!chk.Checked) continue;
                total++;

                //IMPORTANTE: Se ingresa solo una vez, ya que cada vez cambia el folio. para envios a facturar que no sean BCI=91
                if (Convert.ToInt32(dlCambioEstado.SelectedValue) == ESTADO_FACTURACION && idCliente != 91 && !seObtuvoTipoNomina)
                {
                    tipoNomina = new TipoNominaBC().getTiponominaBytipo(NOMINA_FACTURACION);
                    seObtuvoTipoNomina = true;
                }
                switch (accion)
                {
                    //dependiendo de la selección va al metodo que corresponda
                    case Enums.TipoAcciones.Eliminar:
                        //si la eliminación se realizó correctamente aumenta la variable correctas
                        if (Eliminar(id))
                        {
                            correctas++;
                        }
                        break;

                    case Enums.TipoAcciones.CambiarEstado:
                        //si el cambio de estado se realizó correctamente aumenta la variable correctas
                        if (CambioEstado(id, estadoActual, tipoNomina, idCliente))
                        {
                            correctas++;
                        }
                        break;

                    case Enums.TipoAcciones.CambiarProducto:
                        actualiza_producto(id);
                        correctas++;
                        break;
                }
            }
            return correctas;
        }

        protected bool Filas_Selecionadas()
        {           
            double cantidad = (from r in this.gr_dato.Rows.OfType<GridViewRow>()
                               where ((CheckBox)r.FindControl("chk")).Checked && r.RowType == DataControlRowType.DataRow
                               select r.RowIndex).Count();

            return cantidad != 0;
        }

        private bool Eliminar(int idSolicitud)
        {
            new OperacionBC().del_operacion(idSolicitud, (string)(Session["usrname"]));
            return true;
        }

        private bool CambioEstado(int idSolicitud, int estadoActual, TipoNomina tipoNomina, int idCliente)
        {
            bool validaComportamiento = false;
            if (Convert.ToInt32(dlCambioEstado.SelectedValue) == ESTADO_FACTURACION && idCliente != 91)
            {
                GenerarNomina(NOMINA_FACTURACION, idSolicitud, tipoNomina);
                validaComportamiento = true;
            }
            else
            {
                //valida si el siguiente estado seleccionado por usuario corresponde al estado de la tabla comportamiento
                validaComportamiento = new ComportamientoEstadoBC().ValidacionComportamiento(estadoActual, Convert.ToInt32(dlCambioEstado.SelectedValue));
                //si devuelve true, inserta el siguiente estado
                //if (validaComportamiento)
                //{
                new EstadooperacionBC().add_Estadooperacion(idSolicitud, Convert.ToInt32(dlCambioEstado.SelectedValue), txtComentarioAccion.Value.Trim().ToUpper(), (string)(Session["usrname"]));
                //}
                //devuelve el resultado true, false
            }
            return validaComportamiento;
        }

        protected void GenerarNomina(int idTipoNomina, int idSolicitud, TipoNomina lTiponomina)
        {
            new TipoNominaBC().add_tiponominaByOperacion(idSolicitud, idTipoNomina, lTiponomina.Folio, Session["usrname"].ToString());

            if (lTiponomina.Codigo_estado != 0)
            {
                new EstadooperacionBC().add_Estadooperacion(idSolicitud, lTiponomina.Codigo_estado, "", Session["usrname"].ToString());
            }
        }

        int _totalGastos = 0;
        int _totalIngresos = 0;
        int _saldo = 0;
        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var dataKey = gr_dato.DataKeys[e.Row.RowIndex];
                if (dataKey != null)
                {
                    if (dataKey.Values != null)
                    {
                        _totalGastos += Convert.ToInt32(dataKey.Values["total_gastos"]);
                        _totalIngresos += Convert.ToInt32(dataKey.Values["total_ingresos"]);
                        _saldo += Convert.ToInt32(dataKey.Values["saldo"]);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                var lblGastos = (Label)e.Row.FindControl("lbltotalGastos");
                lblGastos.Text = _totalGastos.ToString("N0");

                var lblIngresos = (Label)e.Row.FindControl("lbltotalIngresos");
                lblIngresos.Text = _totalIngresos.ToString("N0");

                var lblSaldo = (Label)e.Row.FindControl("lbltotalSaldo");
                lblSaldo.Text = _saldo.ToString("N0");

            }

        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            var dt = GetOperaciones(Convert.ToInt32(hdnBusqueda.Value));

            if (dt == null)
            {
                FuncionGlobal.alerta_updatepanel("Debe hacer una busqueda anteriormente para exportar.", Page, udp);
                return;
            }
            //creo el informe y obtengo su nombre
            var informe = new MatrizExcelBC().GetReporteHipotecario(Session["usrname"].ToString(), dt);

            //llamo al informe para ser abierto o guardado.
            var strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + informe.Trim() + "');";
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, UpdatePanel1.GetType(), "", strAlerta, true);
        }

        #region Código para cambiar de tipo operación


        private void actualiza_producto(int id)
        {
            new OperacionBC().actualiza_producto(id, this.dl_producto_cambio.SelectedValue, Session["usrname"].ToString(),"");

        }

        #endregion

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listaProductos =
                new TipooperacionBC().getTipo_OperacionByClienteandfamilia(Convert.ToInt16(dlCliente.SelectedValue),
                                                                           "todo",
                                                                           Convert.ToInt16(22));
            //lleno los productos
            LlenarComboCambioEstado(listaProductos, dlProductos);
            //para los cambio de productos...generalmente operaciones desistidas
            LlenarComboCambioEstado(listaProductos, dl_producto_cambio);

        }

        public void LlenarComboCambioEstado(List<TipoOperacion> lista, DropDownList combobox)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Productos del cliente", "0"));
            combobox.DataSource = from o in lista
                                  where o.Check
                                  orderby o.Operacion ascending
                                  select o;
            combobox.DataValueField = "codigo";
            combobox.DataTextField = "operacion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        protected void bt_dar_baja_Click(object sender, EventArgs e)
        {
            if (Filas_Selecionadas())
            {
                try
                {
                    var correctas = Acciones(Enums.TipoAcciones.Eliminar);
                    Mensajes(string.Format("Se eliminaron correctamente {0} operaciones", correctas),
                             Enums.TiposMensajes.Correcto);
                }
                catch (Exception ex)
                {
                    Mensajes(string.Format("Se produjo el siguiente ERROR no controlado: {0}. Comuniquese con informática o intentelo más tarde",ex.Message),
                              Enums.TiposMensajes.Error);                
                }
            }
            else
            {
                Mensajes("Seleccione una operación",
                          Enums.TiposMensajes.Informacion);
            }
        }

        protected void btnCambioEstado_Click(object sender, EventArgs e)
        {
            if (dlCambioEstado.SelectedValue == "0")
            {
                Mensajes("Seleccione un estado",
                             Enums.TiposMensajes.Informacion);
            }

            if (Filas_Selecionadas())
            {
                try
                {
                    var correctas = Acciones(Enums.TipoAcciones.CambiarEstado);
                    Mensajes(string.Format("Se cambiaron de estado correctamente {0} operaciones", correctas),
                            Enums.TiposMensajes.Correcto);
                }
                catch (Exception ex)
                {
                    Mensajes(string.Format("Se produjo el siguiente ERROR no controlado: {0}. Comuniquese con informática o intentelo más tarde", ex.Message),
                              Enums.TiposMensajes.Error);
                }
            }
            else
            {
                Mensajes("Seleccione una operación",
                          Enums.TiposMensajes.Informacion);
            }
        }
     

        protected void btnCambiarProd_Click(object sender, EventArgs e)
        {
            if (dl_producto_cambio.SelectedValue == "0")
            {
                Mensajes("Seleccione un producto",
                               Enums.TiposMensajes.Informacion);
                return;
            }

            if (Filas_Selecionadas())
            {
                try
                {
                    var correctas = Acciones(Enums.TipoAcciones.CambiarProducto);
                    Mensajes(string.Format("Se cambiaron de producto correctamente {0} operaciones", correctas),
                            Enums.TiposMensajes.Correcto);
                }
                catch (Exception ex)
                {
                    Mensajes(string.Format("Se produjo el siguiente ERROR no controlado: {0}. Comuniquese con informática o intentelo más tarde", ex.Message),
                               Enums.TiposMensajes.Error);
                }
            }
            else
            {
                Mensajes("Seleccione una operación",
                            Enums.TiposMensajes.Informacion);
            }
        }

        protected void ibBaja_Click(object sender, ImageClickEventArgs e)
        {
            mpe_baja.Show();
        }

        protected void ibCambiarProducto_Click(object sender, ImageClickEventArgs e)
        {
            mpeCambioProducto.Show();
        }

        protected void ibCambiarEstado_Click(object sender, ImageClickEventArgs e)
        {
            mpeCambioEstado.Show();
        }

      


    }
}