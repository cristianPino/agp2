using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP.analisis_vehiculo
{
    public partial class IngresoAutopistas : Page
    {
        protected string IdSolicitud;
        protected string Patente;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]);
            Patente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["patente"]);

            if (IsPostBack) return;

            //AQUÍ BUSCAR INFOCAR Y MOSTRAR DATOS RELEVANTES DEL PROPIETARIO.
            var dtInfocar = new InfoAutoBC().GetInfocarBySolicitud(Convert.ToInt32(IdSolicitud));
            if (dtInfocar.Rows.Count > 0)
            {
                lblRutPropietario.Text = Convert.ToString(dtInfocar.Rows[0]["propietarioRut"]);
                lblNombrePropietario.Text = Convert.ToString(dtInfocar.Rows[0]["propietarioNombre"]).Trim().ToUpper();
            }

            var estado = new EstadooperacionBC().getUltimoEstadoByIdoperacion(Convert.ToInt32(IdSolicitud));
            // Estado 268 en analisis pRO  274 DESARROLLO; ESTADO 284 ESPERANDO_EJECUTIVO EN VEHICULO PARTE DE PAGO
            ibTerminar.Visible = estado.Estado_operacion.Codigo_estado == 268 || estado.Estado_operacion.Codigo_estado == 275;
            lblPatente.Text = Patente.ToUpper();
            FuncionGlobal.comboparametro(dlFuenteInformacion, "TIPREDIVE");
            OcultarItems();
            dlFuenteInformacion.SelectedValue = "ACENTRALFACT";
            VerificaEstado();

            GetProveedorInformacion();

        }

        //"REVTEC"
        public void OcultarItems()
        {
            string[] ocultar = { "LIMDOM", "ALTC", "PROAN", "CMULTNOP", "ACENTRALNOFACT", "MCN", "MVN", "MMOP", "TRANSPUB", "ENCAROBO", "REVTECVENC", "MVS" };
            foreach (var t in ocultar)
            {
                var eliminar = dlFuenteInformacion.Items.FindByValue(t);
                dlFuenteInformacion.Items.Remove(eliminar);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var insert = 0;

            var texto = TextArea1.Value;

            switch (dlFuenteInformacion.SelectedValue)
            {
                case "ACENTRALFACT":
                    insert = CrearAutopistaCentralNOFacturado(texto);
                    insert = insert + CrearAutopistaCentralFacturado(txtDatosVehiculo.Value);
                    //
                    gr_dato.DataSource = GetFilas(dlFuenteInformacion.SelectedValue);
                    gr_dato.DataBind();
                    gr2.DataSource = GetFilas("ACENTRALNOFACT");
                    gr2.DataBind();
                    break;
                case "VIASEXC":
                    insert = CrearViasExclusivas(texto);
                    gr_dato.DataSource = GetFilas(dlFuenteInformacion.SelectedValue);
                    gr_dato.DataBind();
                    break;
                case "REVTEC":
                    insert = CrearRevisionTecnica(texto);
                    CrearRevisionTecnicaDatosVehiculo(txtDatosVehiculo.Value);
                    gr_dato.DataSource = GetFilas(dlFuenteInformacion.SelectedValue);
                    gr_dato.DataBind();
                    break;
            }


            Mensaje("Se ha(n) insertado " + insert + " multa(s)");

            GetProveedorInformacion();//se llama nuevamente al metodo para ocultar las columnas innesesarias.
            TextArea1.Value = "";
            TextArea1.Visible = false;
            txtDatosVehiculo.Value = "";
            txtDatosVehiculo.Visible = false;

        }

        public int CrearAutopistaCentralFacturado(string texto)
        {
            var proveedor = GetProveedorInformacion();
            var info = new InfoAutoDetalle();
            char[] delimiterChars = { '\t' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var col = -1;
            var insert = 0;


            foreach (var s in words)
            {
                info.Rut = lblRutPropietario.Text;
                info.Propietario_nombre = lblNombrePropietario.Text;
                col += 1;
                switch (col)
                {

                    case 1:
                        info.Descripcion = s;//Patente
                        break;
                    case 3:
                        info.Observacion = s.Trim();//numero boleta o documento
                        break;
                    case 4:
                        var d = s.Replace("$", string.Empty);
                        d = d.Replace(".", string.Empty);
                        info.Monto = d;//total
                        col = -1;
                        insert += 1;
                        new InfoAutoBC().add_InfoAutoDetalle("0", IdSolicitud, dlFuenteInformacion.SelectedValue,
                                                              proveedor, rut: info.Rut, monto: info.Monto, descripcion: info.Descripcion,
                                                              observacion: info.Observacion, nombre: info.Propietario_nombre);
                        break;
                }

            }


            return insert;
        }

        public int CrearAutopistaCentralNOFacturado(string texto)
        {
            var proveedor = GetProveedorInformacion();
            var info = new InfoAutoDetalle();
            char[] delimiterChars = { '\t' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var col = -1;
            var insert = 0;
            foreach (var s in words)
            {
                info.Rut = lblRutPropietario.Text;
                info.Propietario_nombre = lblNombrePropietario.Text;
                col += 1;
                switch (col)
                {
                    case 1:
                        info.Observacion = s.Trim();//numero boleta o documento
                        break;
                    case 2:
                        info.Descripcion = s;//Fecha
                        break;
                    case 4:
                        var d = s.Replace("$", string.Empty);
                        d = d.Replace(".", string.Empty);
                        info.Monto = d;//total
                        col = -1;
                        insert += 1;
                        new InfoAutoBC().add_InfoAutoDetalle("0", IdSolicitud, "ACENTRALNOFACT",
                                                              "AUTOPISTA CENTRAL NO FACTURADO", rut: info.Rut, monto: info.Monto, descripcion: info.Descripcion,
                                                              observacion: info.Observacion, nombre: info.Propietario_nombre);
                        break;
                }

            }
            return insert;
        }


        public int CrearViasExclusivas(string texto)
        {
            var proveedor = GetProveedorInformacion();
            var info = new InfoAutoDetalle();
            var insert = 0;
            char[] filas = { '\n' };
            string[] filasPalabras = texto.Split(filas, StringSplitOptions.RemoveEmptyEntries);

            foreach (var filasPalabra in filasPalabras)
            {
                char[] delimiterChars = { '\t' };
                string[] words = filasPalabra.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                var col = 0;

                foreach (var s in words)
                {
                    col += 1;
                    switch (col)
                    {
                        case 1:
                            var d = s;
                            if (s.Length > 10)
                            {
                                d = s.Substring(s.Length - 10, 10);
                            }
                            info.FechaHecho = d;//Fecha
                            break;
                        case 2:
                            info.Lugar = s;//Lugar
                            break;
                        case 3:
                            col = 0;
                            new InfoAutoBC().add_InfoAutoDetalle("0", IdSolicitud, dlFuenteInformacion.SelectedValue,
                                proveedor, fechaHecho: info.FechaHecho, lugar: info.Lugar);
                            insert += 1;
                            break;
                    }
                }
            }

            return insert;
        }

        public int CrearRevisionTecnica(string texto)
        {
            var complemento = txtComplemento.Text.Trim();
            if (complemento.Contains("La placa ingresada no existe."))
            {
                complemento = "Sin info para esta placa";
            }
            else if (complemento == "")
            {
                complemento = "Al día.";
            }
            new InfoAutoBC().add_InfoAutoDetalle(lblIdComplemento.Text,
                                                IdSolicitud,
                                                 "REVTECVENC",
                                                 "PRT.CL", descripcion: complemento);

            var proveedor = GetProveedorInformacion();
            var info = new InfoAutoDetalle();
            var insert = 0;
            char[] filas = { '\n' };
            string[] filasPalabras = texto.Split(filas, StringSplitOptions.RemoveEmptyEntries);

            foreach (var filasPalabra in filasPalabras)
            {
                char[] delimiterChars = { '\t' };
                string[] words = filasPalabra.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                var col = 0;

                foreach (var s in words)
                {
                    col += 1;
                    switch (col)
                    {
                        case 1:
                            info.FechaHecho = s;
                            break;
                        case 2:
                            info.Rut = s;
                            break;
                        case 3:
                            info.Lugar = s;
                            break;
                        case 4:
                            info.Descripcion = s;
                            break;
                        case 5:
                            info.FechaInformacion = s;
                            break;
                        case 6:
                            info.Observacion = s;

                            new InfoAutoBC().add_InfoAutoDetalle("0",
                                                                IdSolicitud, "REVTEC",
                                                                "PRT.CL", lugar: info.Lugar,
                                                                observacion: info.Observacion, fechaHecho: info.FechaHecho,
                                                                fechaInformacion: info.FechaInformacion,
                                                                descripcion: info.Descripcion,
                                                                rut: info.Rut);
                            col = 0;
                            insert += 1;
                            break;
                    }
                }
            }

            return insert;
        }


        public void CrearRevisionTecnicaDatosVehiculo(string texto)
        {
            var proveedor = GetProveedorInformacion();
            var info = new InfoAutoDetalle();
            var insert = 0;
            char[] filas = { '\n' };
            string[] filasPalabras = texto.Split(filas, StringSplitOptions.RemoveEmptyEntries);
            var col = 0;
            foreach (var o in filasPalabras)
            {
                col += 1;
                switch (col)
                {
                    case 1:
                        info.Id_solicitud = Convert.ToInt32(IdSolicitud);
                        info.Patente = o == null ? "S/I" : o.Substring(7, o.Trim().Length - 7).Trim();
                        break;
                    case 2:
                        info.Tipo_vehiculo = o == null ? "S/I" : o.Substring(4, o.Trim().Length - 4).Trim();
                        break;
                    case 3:
                        info.Marca = o == null ? "S/I" : o.Substring(5, o.Trim().Length - 5).Trim();
                        break;
                    case 4:
                        info.Modelo = o == null ? "S/I" : o.Substring(6, o.Trim().Length - 6).Trim();
                        break;
                    case 5:
                        info.Ano = Convert.ToInt32(o.Substring(8, o.Trim().Length - 8).Trim());
                        break;
                    case 6:
                        info.Motor = o == null ? "S/I" : o.Substring(8, o.Trim().Length - 8).Trim();
                        break;
                    case 7:
                        info.Chassis = o == null ? "S/I" : o.Substring(9, o.Trim().Length - 9).Trim();
                        break;
                    case 8:
                        info.Vin = o == null ? "" : o.Substring(6, o.Trim().Length - 6).Trim();
                        new InfoAutoBC().AddDatoGeneral(info);
                        col = 0;
                        break;
                }
            }
        }

        public string GetProveedorInformacion()
        {
            var seleccionCombo = dlFuenteInformacion.SelectedValue;
            var proveedor = "NO IDENTIFICADO";           
            lblInfoFuente.Text = "Información de la fuente";

            switch (seleccionCombo)
            {
                case "LIMDOM":
                    proveedor = "REGISTRO CIVIL LIMITACION AL DOMINIO";
                    break;
                case "ALTC":
                    proveedor = "REGISTRO CIVIL ALTERACION CARACTERISTICA";
                    break;
                case "PROAN":
                    proveedor = "REGISTRO CIVIL PROPIETARIO ANTERIOR";
                    break;
                case "CMULTNOP":
                    proveedor = "REGISTRO CIVIL CERTIFICADO MULTAS";
                    break;
                case "MCN":
                    proveedor = "COSTANERA NORTE";
                    break;
                case "MVN":
                    proveedor = "VESPUCIO NORTE";
                    break;
                case "MMOP":
                    proveedor = "MOP";
                    break;
                case "REVTEC":
                    proveedor = "PRT.CL";
                    hlinkPaginas.NavigateUrl = @"http://www.prt.cl/Paginas/RevisionTecnica.aspx";
                    lblLink.Text = "IR A " + proveedor;
                    var lista = new InfoAutoBC().Get_DicomVehiculoDetalle(Convert.ToInt32(IdSolicitud), "REVTECVENC");
                    trComplemento.Visible = true;
                    trDatoVehiculoTitulo.Visible = true;
                    lbldatoVehiculo.Text = "Datos del Vehiculo";
                    trDatoVehiculo.Visible = true;

                    foreach (var infoAutoDetalle in lista)
                    {
                        txtComplemento.Text = infoAutoDetalle.Descripcion;
                        lblIdComplemento.Text = infoAutoDetalle.IdDicomVehiculoDetalle;
                    }
                    if (gr_dato.Rows.Count > 0 && gr_dato.Visible)
                    {
                        gr_dato.Columns[0].Visible = true;
                        gr_dato.Columns[1].Visible = true;
                        gr_dato.Columns[2].Visible = true;
                        gr_dato.Columns[3].Visible = true;
                        gr_dato.Columns[4].Visible = true;
                        gr_dato.Columns[5].Visible = true;
                        gr_dato.Columns[6].Visible = false;
                        gr_dato.Columns[7].Visible = true;
                        gr_dato.Columns[8].Visible = false;
                        gr_dato.Columns[9].Visible = true;
                        gr_dato.Columns[10].Visible = false;
                        gr_dato.Columns[11].Visible = false;
                        gr_dato.Columns[12].Visible = false;
                        gr_dato.Columns[13].Visible = false;
                    }
                    break;
                case "TRANSPUB":
                    proveedor = "REG NAC TRANSPORTE PUBLICO ESCOLAR";
                    break;
                //case "ACENTRALNOFACT":
                //    proveedor = "AUTOPISTA CENTRAL NO FACTURADO";
                //    hlinkPaginas.NavigateUrl = @"http://www.autopistacentral.cl/publico/consultaInfracciones";
                //    lblLink.Text = "IR A " + proveedor + " FACTURACION INFRACTORA";
                //    lblIdComplemento.Text = "0";
                //    txtComplemento.Text = "";
                //    trComplemento.Visible = true;
                //    trDatoVehiculoTitulo.Visible = false;
                //    trDatoVehiculo.Visible = false;
                //    tdACentral.Visible = true;

                //    if (gr_dato.Rows.Count > 0 && gr_dato.Visible)
                //    {
                //        gr_dato.Columns[0].Visible = true;
                //        gr_dato.Columns[1].Visible = true;
                //        gr_dato.Columns[2].Visible = false;
                //        gr_dato.Columns[3].Visible = true;
                //        gr_dato.Columns[4].Visible = false;
                //        gr_dato.Columns[5].Visible = false;
                //        gr_dato.Columns[6].Visible = true;
                //        gr_dato.Columns[7].Visible = false;
                //        gr_dato.Columns[8].Visible = false;
                //        gr_dato.Columns[9].Visible = true;
                //        gr_dato.Columns[10].Visible = false;
                //        gr_dato.Columns[11].Visible = false;
                //        gr_dato.Columns[12].Visible = false;
                //        gr_dato.Columns[13].Visible = false;
                //    }
                //    break;                
                case "ACENTRALFACT":
                    proveedor = "AUTOPISTA CENTRAL FACTURADO";
                    hlinkPaginas.NavigateUrl = @"http://www.autopistacentral.cl/publico/consultaInfracciones";
                    lblLink.Text = "IR A " + proveedor + " FACTURADO";
                    lblIdComplemento.Text = "0";
                    txtComplemento.Text = string.Empty;
                    trComplemento.Visible = false;
                    trDatoVehiculoTitulo.Visible = true;
                    lbldatoVehiculo.Text = "FACTURADO";
                    lblInfoFuente.Text = "NO FACTURADO";
                    trDatoVehiculo.Visible = true;                  


                    if (gr_dato.Rows.Count > 0 && gr_dato.Visible)
                    {
                        gr_dato.Columns[0].Visible = true;
                        gr_dato.Columns[1].Visible = true;
                        gr_dato.Columns[2].Visible = false;
                        gr_dato.Columns[3].Visible = true;
                        gr_dato.Columns[4].Visible = false;
                        gr_dato.Columns[5].Visible = false;
                        gr_dato.Columns[6].Visible = true;
                        gr_dato.Columns[7].Visible = false;
                        gr_dato.Columns[8].Visible = false;
                        gr_dato.Columns[9].Visible = true;
                        gr_dato.Columns[10].Visible = false;
                        gr_dato.Columns[11].Visible = false;
                        gr_dato.Columns[12].Visible = false;
                        gr_dato.Columns[13].Visible = false;

                    }

                    if (gr2.Rows.Count > 0 && gr2.Visible)
                    {
                        gr2.Columns[0].Visible = true;
                        gr2.Columns[1].Visible = true;
                        gr2.Columns[2].Visible = false;
                        gr2.Columns[3].Visible = true;
                        gr2.Columns[4].Visible = false;
                        gr2.Columns[5].Visible = false;
                        gr2.Columns[6].Visible = true;
                        gr2.Columns[7].Visible = false;
                        gr2.Columns[8].Visible = false;
                        gr2.Columns[9].Visible = true;
                        gr2.Columns[10].Visible = false;
                        gr2.Columns[11].Visible = false;
                        gr2.Columns[12].Visible = false;
                        gr2.Columns[13].Visible = false;
                    }
                    break;
                case "VIASEXC":
                    proveedor = "FISCALIZACION DE VIAS EXCLUSIVAS";
                    hlinkPaginas.NavigateUrl = @"http://vias.fiscalizacion.cl/";
                    lblLink.Text = "IR A " + proveedor;
                    lblIdComplemento.Text = "0";
                    txtComplemento.Text = "";
                    trComplemento.Visible = false;
                    trDatoVehiculoTitulo.Visible = false;
                    trDatoVehiculo.Visible = false;

                    if (gr_dato.Rows.Count > 0 && gr_dato.Visible)
                    {
                        gr_dato.Columns[0].Visible = true;
                        gr_dato.Columns[1].Visible = true;
                        gr_dato.Columns[2].Visible = true;
                        gr_dato.Columns[3].Visible = false;
                        gr_dato.Columns[4].Visible = true;
                        gr_dato.Columns[5].Visible = false;
                        gr_dato.Columns[6].Visible = false;
                        gr_dato.Columns[7].Visible = false;
                        gr_dato.Columns[8].Visible = false;
                        gr_dato.Columns[9].Visible = false;
                        gr_dato.Columns[10].Visible = false;
                        gr_dato.Columns[11].Visible = false;
                        gr_dato.Columns[12].Visible = false;
                        gr_dato.Columns[13].Visible = false;
                    }
                    break;
            }

            return proveedor;
        }


        public DataTable GetFilas(string parametro)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_dicom_vehiculo_detalle"));
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("fechaHecho"));
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("lugar"));
            dt.Columns.Add(new DataColumn("fechaInformacion"));
            dt.Columns.Add(new DataColumn("monto"));
            dt.Columns.Add(new DataColumn("observacion"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("rut"));
            dt.Columns.Add(new DataColumn("arancel"));
            dt.Columns.Add(new DataColumn("tipoMoneda"));
            dt.Columns.Add(new DataColumn("idMulta"));
            dt.Columns.Add(new DataColumn("fechaIngresoRMNP"));
            ViewState["dt"] = dt;


            var lista = new InfoAutoBC().Get_DicomVehiculoDetalle(Convert.ToInt32(IdSolicitud), parametro);
            btnGuardarGrid.Visible = lista.Count > 0;
            lblMensaje.Text = lista.Count == 0 ? "No existe información para la consulta seleccionada." : "";
            foreach (var i in lista)
            {
                var dr = dt.NewRow();
                dr["id_dicom_vehiculo_detalle"] = i.IdDicomVehiculoDetalle;
                dr["id_solicitud"] = IdSolicitud;
                dr["patente"] = i.Patente;
                dr["fechaHecho"] = i.FechaHecho;
                dr["descripcion"] = i.Descripcion;
                dr["lugar"] = i.Lugar;
                dr["fechaInformacion"] = i.FechaInformacion;
                dr["monto"] = i.Monto;
                dr["observacion"] = i.Observacion;
                dr["nombre"] = i.Nombre;
                dr["rut"] = i.Rut;
                dr["arancel"] = i.Arancel;
                dr["tipoMoneda"] = i.TipoMoneda;
                dr["idMulta"] = i.IdMulta;
                dr["fechaIngresoRMNP"] = i.FechaIngresoRmnp;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public void Mensaje(string mensaje)
        {
            var up = (UpdatePanel)Master.FindControl("UpdatePanel1");
            FuncionGlobal.alerta_updatepanel(mensaje, Page, up);
        }


        protected void gr_dato_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var i = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName != "Eliminar") return;
            var dataKey = gr_dato.DataKeys[i];
            if (dataKey == null) return;
            var idDicomVehiculoDetalle = Convert.ToInt32(dataKey.Value);

            try
            {
                new InfoAutoBC().Del_DicomVehiculoDetalle(idDicomVehiculoDetalle);
                gr_dato.DataSource = GetFilas(dlFuenteInformacion.SelectedValue);
                gr_dato.DataBind();
                if (dlFuenteInformacion.SelectedValue == "ACENTRALFACT")
                {
                    gr2.DataSource = GetFilas("ACENTRALNOFACT");
                    gr2.DataBind();
                }

                Mensaje("Eliminado correctamente");
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            if (dlFuenteInformacion.SelectedValue == "0")
            {
                Mensaje("Seleccione una fuente de información");
                return;
            }


            gr_dato.DataSource = GetFilas(dlFuenteInformacion.SelectedValue);
            gr_dato.DataBind();

            if (dlFuenteInformacion.SelectedValue == "ACENTRALFACT")
            {
                gr2.DataSource = GetFilas("ACENTRALNOFACT");
                gr2.DataBind();
            }



            GetProveedorInformacion();
            TextArea1.Visible = false;
            btnCrear.Visible = false;

        }

        protected void gr2_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            var grid = gr2;
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var lblFechaHechoAlias = (Label)grid.HeaderRow.FindControl("lblFechaHechoAlias");
            var lblDescripcionAlias = (Label)grid.HeaderRow.FindControl("lblDescripcionAlias");
            var lblLugarAlias = (Label)grid.HeaderRow.FindControl("lblLugarAlias");
            var lblFechaInformacionAlias = (Label)grid.HeaderRow.FindControl("lblFechaInformacionAlias");
            var lblMontoAlias = (Label)grid.HeaderRow.FindControl("lblMontoAlias");
            var lblObservacionAlias = (Label)grid.HeaderRow.FindControl("lblObservacionAlias");
            var lblNombreAlias = (Label)grid.HeaderRow.FindControl("lblNombreAlias");
            var lblRutAlias = (Label)grid.HeaderRow.FindControl("lblRutAlias");
            var lblArancelAlias = (Label)grid.HeaderRow.FindControl("lblArancelAlias");
            var lblTipoMonedaAlias = (Label)grid.HeaderRow.FindControl("lblTipoMonedaAlias");
            var lblIdMultaAlias = (Label)grid.HeaderRow.FindControl("lblIdMultaAlias");
            var lblfechaIngresoRmnpAlias = (Label)grid.HeaderRow.FindControl("lblfechaIngresoRMNPAlias");

            var seleccionCombo = dlFuenteInformacion.SelectedValue;

            switch (seleccionCombo)
            {
                case "REVTEC":
                    lblFechaHechoAlias.Text = "Fecha";
                    lblDescripcionAlias.Text = "Nº Certificado";
                    lblLugarAlias.Text = "Concecionario";
                    lblFechaInformacionAlias.Text = "Fecha vto";
                    lblObservacionAlias.Text = "Estado";
                    lblRutAlias.Text = "Cod. Prt";
                    break;
                case "LimitacionDominio":
                    lblDescripcionAlias.Text = "Descripción";
                    break;
                case "AltCarac":
                    lblDescripcionAlias.Text = "Descripcion";
                    break;
                case "PropietarioAnterior":
                    lblFechaHechoAlias.Text = "Fecha";
                    lblNombreAlias.Text = "Nombre";
                    lblRutAlias.Text = "Rut";
                    lblLugarAlias.Text = "Repertorio";
                    lblObservacionAlias.Text = "Nº Repertorio";
                    break;
                case "MultasMop":
                    lblFechaHechoAlias.Text = "Fecha Infracción";
                    lblDescripcionAlias.Text = "Infracción";
                    lblLugarAlias.Text = "Tribunal";
                    lblFechaInformacionAlias.Text = "Fecha de Sentencia";
                    lblMontoAlias.Text = "Monto";
                    lblObservacionAlias.Text = "Rol";
                    lblIdMultaAlias.Text = "Id Multa";
                    lblArancelAlias.Text = "Arancel";
                    lblTipoMonedaAlias.Text = "Tipo Moneda";
                    lblfechaIngresoRmnpAlias.Text = "Fecha Ingreso RMNP";
                    break;
                case "MultasCostaneraNorte":
                    lblFechaHechoAlias.Text = "Fecha Infracción";
                    lblDescripcionAlias.Text = "Categoría";
                    lblObservacionAlias.Text = "Estado Infracción";
                    break;
                case "Vespucio Norte":
                    lblDescripcionAlias.Text = "Descripción";
                    break;
                case "ACENTRALFACT":
                    lblDescripcionAlias.Text = "Número";
                    break;
                case "VIASEXC":
                    lblFechaHechoAlias.Text = "Fecha";
                    lblLugarAlias.Text = "Lugar";
                    break;
            }

        }

        protected void gr_dato_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            var grid = gr_dato;
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var lblFechaHechoAlias = (Label)grid.HeaderRow.FindControl("lblFechaHechoAlias");
            var lblDescripcionAlias = (Label)grid.HeaderRow.FindControl("lblDescripcionAlias");
            var lblLugarAlias = (Label)grid.HeaderRow.FindControl("lblLugarAlias");
            var lblFechaInformacionAlias = (Label)grid.HeaderRow.FindControl("lblFechaInformacionAlias");
            var lblMontoAlias = (Label)grid.HeaderRow.FindControl("lblMontoAlias");
            var lblObservacionAlias = (Label)grid.HeaderRow.FindControl("lblObservacionAlias");
            var lblNombreAlias = (Label)grid.HeaderRow.FindControl("lblNombreAlias");
            var lblRutAlias = (Label)grid.HeaderRow.FindControl("lblRutAlias");
            var lblArancelAlias = (Label)grid.HeaderRow.FindControl("lblArancelAlias");
            var lblTipoMonedaAlias = (Label)grid.HeaderRow.FindControl("lblTipoMonedaAlias");
            var lblIdMultaAlias = (Label)grid.HeaderRow.FindControl("lblIdMultaAlias");
            var lblfechaIngresoRmnpAlias = (Label)grid.HeaderRow.FindControl("lblfechaIngresoRMNPAlias");

            var seleccionCombo = dlFuenteInformacion.SelectedValue;

            switch (seleccionCombo)
            {
                case "REVTEC":
                    lblFechaHechoAlias.Text = "Fecha";
                    lblDescripcionAlias.Text = "Nº Certificado";
                    lblLugarAlias.Text = "Concecionario";
                    lblFechaInformacionAlias.Text = "Fecha vto";
                    lblObservacionAlias.Text = "Estado";
                    lblRutAlias.Text = "Cod. Prt";
                    break;
                case "LimitacionDominio":
                    lblDescripcionAlias.Text = "Descripción";
                    break;
                case "AltCarac":
                    lblDescripcionAlias.Text = "Descripcion";
                    break;
                case "PropietarioAnterior":
                    lblFechaHechoAlias.Text = "Fecha";
                    lblNombreAlias.Text = "Nombre";
                    lblRutAlias.Text = "Rut";
                    lblLugarAlias.Text = "Repertorio";
                    lblObservacionAlias.Text = "Nº Repertorio";
                    break;
                case "MultasMop":
                    lblFechaHechoAlias.Text = "Fecha Infracción";
                    lblDescripcionAlias.Text = "Infracción";
                    lblLugarAlias.Text = "Tribunal";
                    lblFechaInformacionAlias.Text = "Fecha de Sentencia";
                    lblMontoAlias.Text = "Monto";
                    lblObservacionAlias.Text = "Rol";
                    lblIdMultaAlias.Text = "Id Multa";
                    lblArancelAlias.Text = "Arancel";
                    lblTipoMonedaAlias.Text = "Tipo Moneda";
                    lblfechaIngresoRmnpAlias.Text = "Fecha Ingreso RMNP";
                    break;
                case "MultasCostaneraNorte":
                    lblFechaHechoAlias.Text = "Fecha Infracción";
                    lblDescripcionAlias.Text = "Categoría";
                    lblObservacionAlias.Text = "Estado Infracción";
                    break;
                case "Vespucio Norte":
                    lblDescripcionAlias.Text = "Descripción";
                    break;
                case "ACENTRALFACT":
                    lblDescripcionAlias.Text = "Número";
                    break;
                case "VIASEXC":
                    lblFechaHechoAlias.Text = "Fecha";
                    lblLugarAlias.Text = "Lugar";
                    break;
            }

        }



        protected void dlFuenteInformacion_SelectedIndexChanged(object sender, EventArgs e)
        {            
            gr_dato.DataBind();
            GetFilas(dlFuenteInformacion.SelectedValue);
            GetProveedorInformacion();
            VerificaEstado();
        }

        protected void ib_insertar_Click(object sender, ImageClickEventArgs e)
        {
            lblMensaje.Text = "";
            gr_dato.DataBind();
            TextArea1.Visible = true;
            switch (dlFuenteInformacion.SelectedValue)
            {
                case "ACENTRALFACT":
                    lblIdComplemento.Text = "0";
                    txtComplemento.Text = string.Empty;
                    trComplemento.Visible = false;
                    trDatoVehiculoTitulo.Visible = true;
                    lbldatoVehiculo.Text = "FACTURADO";
                    lblInfoFuente.Text = "NO FACTURADO";
                    trDatoVehiculo.Visible = true;                   
                    break;
                case "REVTEC":
                    trComplemento.Visible = true;
                    trDatoVehiculoTitulo.Visible = true;
                    lbldatoVehiculo.Text = "Datos del Vehiculo";
                    trDatoVehiculo.Visible = true;
                    break;
            }


            btnGuardarGrid.Visible = false;
            btnCrear.Visible = true;
        }

        protected void btnGuardarGrid_Click(object sender, EventArgs e)
        {
            if (dlFuenteInformacion.SelectedValue == "ACENTRALFACT")
            {
                var p = GetProveedorInformacion();
                GuardarAutopistaCentralFacturado(p);
                Mensaje("Cambios realizados correctamente");
            }
        }

        public void GuardarAutopistaCentralFacturado(string proveedor)
        {
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var row = gr_dato.Rows[i];
                var rut = ((TextBox)row.FindControl("txtrut")).Text.Trim();
                var monto = ((TextBox)row.FindControl("txtmonto")).Text.Trim();
                var descripcion = ((TextBox)row.FindControl("txtdescripcion")).Text.Trim();
                var dataKey = gr_dato.DataKeys[i];
                if (dataKey == null) continue;
                var idDicomVehiculoDetalle = dataKey.Value.ToString();

                new InfoAutoBC().add_InfoAutoDetalle(idDicomVehiculoDetalle, IdSolicitud, dlFuenteInformacion.SelectedValue,
                                                                proveedor, rut: rut, monto: monto, descripcion: descripcion);

            }

        }

        public void VerificaEstado()
        {
            if (dlFuenteInformacion.SelectedValue == "0")
            {
                btnIniciar.Visible = false;
                btnExito.Visible = false;
                btnFracaso.Visible = false;
                return;
            }
            var estado = 0;
            switch (dlFuenteInformacion.SelectedValue)
            {
                case "VIASEXC":
                    estado = new InfoAutoBC().Get_ProcesoDicomVehiculoByPaso(Convert.ToInt32(IdSolicitud), 9); //proceso 9 vias exclusivas
                    break;
                case "ACENTRALFACT":
                    estado = new InfoAutoBC().Get_ProcesoDicomVehiculoByPaso(Convert.ToInt32(IdSolicitud), 8);   //proceso 8 autopista central
                    break;
                case "REVTEC":
                    estado = new InfoAutoBC().Get_ProcesoDicomVehiculoByPaso(Convert.ToInt32(IdSolicitud), 2);   //proceso 2 REVISION TECNICA
                    break;
            }

            switch (estado)
            {
                case 0:
                    btnIniciar.Visible = true;
                    btnExito.Visible = false;
                    btnFracaso.Visible = false;
                    break;
                case 1:
                    btnIniciar.Visible = false;
                    btnExito.Visible = true;
                    btnFracaso.Visible = true;
                    break;
                case 2:
                    btnIniciar.Visible = false;
                    btnExito.Visible = false;
                    btnFracaso.Visible = false;
                    break;
                case 3:
                    btnIniciar.Visible = false;
                    btnExito.Visible = false;
                    btnFracaso.Visible = false;
                    break;
            }
        }


        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            if (dlFuenteInformacion.SelectedValue == "0") return;
            CambioProceso("Proceso Iniciado...", 1);//Leyendo  
            VerificaEstado();
        }

        protected void btnExito_Click(object sender, EventArgs e)
        {
            if (dlFuenteInformacion.SelectedValue == "0") return;
            CambioProceso("Proceso Terminado...", 2);//terminado
            VerificaEstado();
        }
        protected void btnFracaso_Click(object sender, EventArgs e)
        {
            if (dlFuenteInformacion.SelectedValue == "0") return;
            CambioProceso("Proceso Pendiente...", 0);//Error
            VerificaEstado();
        }

        public void CambioProceso(string mensaje, int tipoCambio)
        {
            switch (dlFuenteInformacion.SelectedValue)
            {
                case "VIASEXC":
                    new InfoAutoBC().UpdateDicomVehiculoProcesos(Convert.ToInt32(IdSolicitud), tipoCambio, 9);   //proceso 9 vias exclusivas
                    break;
                case "ACENTRALFACT":
                    new InfoAutoBC().UpdateDicomVehiculoProcesos(Convert.ToInt32(IdSolicitud), tipoCambio, 8);   //proceso 8 autopista central
                    break;
                case "REVTEC":
                    new InfoAutoBC().UpdateDicomVehiculoProcesos(Convert.ToInt32(IdSolicitud), tipoCambio, 2);   //proceso 8 autopista central
                    break;
            }

            Mensaje(mensaje);
        }

        protected void ibTerminar_Click(object sender, ImageClickEventArgs e)
        {
            if (!new InfoAutoBC().Get_DicomVehiculoRevisados(Convert.ToInt32(IdSolicitud), "MANU"))
            {
                Mensaje("Aún le falta por revisar información.");
                return;
            }

            try
            {
                new InfoAutoBC().Upt_solicitudDV(Convert.ToInt32(IdSolicitud), Session["usrname"].ToString());
                Mensaje("La solicitud ha cambiado de estado");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "parent.$.fancybox.close();", true);
            }
            catch (Exception exception)
            {
                Mensaje(exception.Message);
            }
        }



    }
}