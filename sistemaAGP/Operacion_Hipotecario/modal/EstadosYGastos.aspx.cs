using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using CENTIDAD;
using CNEGOCIO;
using DataTable = System.Data.DataTable;


namespace sistemaAGP.Operacion_Hipotecario.modal
{
    public partial class EstadosYGastos : Page
    {
        const string IMAGEN_SOLO_LECTURA = "~/imagenes/sistema/static/hipotecario/soloLectura.png";
        const string IMAGE_REALIZA_CAMBIOS = "~/imagenes/sistema/static/hipotecario/realizaCambios.png";
        const string IMAGEN_ROJO = "~/imagenes/sistema/static/rojo.png";

        public enum ClienteHipotecario
        {
            SCOTIABANK = 19,
            BCI = 91
        }

        public enum HojasExcel
        {
            NUEVA_OP_BCI,
            NUEVA_OP_SCOTIABANK,
            CAMBIO_EST_BCI,
            CAMBIO_EST_SCOTIABANK,
            NUEVAS_GESTORIAS
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {

        }

        protected void ImgSubir_Click(object sender, ImageClickEventArgs e)
        {
            string ruta;
            try
            {
                ruta = carga_archivo();
                //ruta = @"E:\prueba\carga.xlsm";
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta("Se ha producido un error en la carga del documento.", Page);
                return;
            }

            if (ruta.Trim() == string.Empty)
            {
                FuncionGlobal.alerta("No ha seleccionado ningún archivo valido", Page);
                return;
            }
            ImportarExcel(ruta);
            FuncionGlobal.alerta("Carga y analisis completo", Page);
            divPaso2Grilla.Visible = true;
            divPaso3.Visible = true;

        }

        private string carga_archivo()
        {
            string sSave = "";

            if (fileuploadExcel.PostedFile != null && fileuploadExcel.PostedFile.ContentLength > 0)
            {
                var fiDocumento = new FileInfo(fileuploadExcel.FileName);
                if (fiDocumento.Extension.ToLower() == ".xlsm")
                {

                    if (fileuploadExcel.PostedFile.ContentLength <= 6194304)
                    {
                        string sDoc = "CM_" + Convert.ToString(Session["usrname"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fiDocumento.Extension;
                        string sPath = String.Format("{0}/{1}/{2}", "~/digitalizacion/docs", "hipotecario", "cargas_masivas");
                        sSave = Server.MapPath(@sPath) + "\\" + sDoc;
                        fileuploadExcel.PostedFile.SaveAs(sSave);
                    }
                }
            }
            return sSave;
        }

        public DataSet ObtenerDataSetExcel(string query, string ruta)
        {
            query = query.Replace("\n", string.Empty);
            query = query.Replace("\r", string.Empty);
            query = query.Replace("\t", string.Empty);
            //Connection String to Excel Workbook
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=" + ruta + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            //string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return ds;
        }

        private void ImportarExcel(string ruta)
        {
            //recogo la lista con la estructura de columnas de todas las hojas del excel
            var listaQueryEstructuraExcel = new HipotecarioBC().GetEstructuraExcel();
            //Variables dataset
            DataTableIngreso();
            DataTableCambioEstado();
            foreach (var estructuraExcel in listaQueryEstructuraExcel)
            {
                DataSet dsDatos = new DataSet();
                var hojaExcel = new HojasExcel();
                var cliente = new ClienteHipotecario();
                dsDatos = ObtenerDataSetExcel(estructuraExcel.ExcelQuery, ruta);
                switch (estructuraExcel.ExcelTipo.Trim())
                {
                    case "NUEVA":
                        switch (estructuraExcel.ExcelIdCliente)
                        {
                            case 19:
                                hojaExcel = HojasExcel.NUEVA_OP_SCOTIABANK;
                                cliente = ClienteHipotecario.SCOTIABANK;
                                break;
                            case 91:
                                hojaExcel = HojasExcel.NUEVA_OP_BCI;
                                cliente = ClienteHipotecario.BCI;
                                break;
                        }
                        LlenarNuevasOperaciones(dsDatos, cliente, hojaExcel);
                        break;

                    case "GESTOR":
                        hojaExcel = HojasExcel.NUEVAS_GESTORIAS;
                        LlenarNuevasOperaciones(dsDatos, cliente, hojaExcel, gestoria: true);
                        break;

                    case "NOMINA":
                        switch (estructuraExcel.ExcelIdCliente)
                        {
                            case 19:
                                hojaExcel = HojasExcel.CAMBIO_EST_SCOTIABANK;
                                cliente = ClienteHipotecario.SCOTIABANK;
                                break;
                            case 91:
                                hojaExcel = HojasExcel.CAMBIO_EST_BCI;
                                cliente = ClienteHipotecario.BCI;
                                break;
                        }
                        LlenarCambioEstado(dsDatos, cliente);
                        break;
                }
            }

            lblMessage.Text = "Archivo analizado correctamente";
        }

        public void DataTableIngreso()
        {
            var dtIngreso = new DataTable();
            dtIngreso.Columns.Add(new DataColumn("hoja_excel"));
            dtIngreso.Columns.Add(new DataColumn("fila_excel"));
            dtIngreso.Columns.Add(new DataColumn("cliente"));
            dtIngreso.Columns.Add(new DataColumn("id_cliente"));
            dtIngreso.Columns.Add(new DataColumn("estado_revision"));
            dtIngreso.Columns.Add(new DataColumn("codigo_tipo_operacion"));
            dtIngreso.Columns.Add(new DataColumn("tipo_operacion"));
            dtIngreso.Columns.Add(new DataColumn("numero_banco"));
            dtIngreso.Columns.Add(new DataColumn("rut"));
            dtIngreso.Columns.Add(new DataColumn("nombre"));
            dtIngreso.Columns.Add(new DataColumn("apepat"));
            dtIngreso.Columns.Add(new DataColumn("apemat"));
            dtIngreso.Columns.Add(new DataColumn("e_titulo"));
            dtIngreso.Columns.Add(new DataColumn("borrador"));
            dtIngreso.Columns.Add(new DataColumn("inscripcion_cbr"));
            dtIngreso.Columns.Add(new DataColumn("tarifa_servicio"));
            dtIngreso.Columns.Add(new DataColumn("notaria"));
            dtIngreso.Columns.Add(new DataColumn("cbr"));
            dtIngreso.Columns.Add(new DataColumn("semaforo"));
            dtIngreso.Columns.Add(new DataColumn("mensaje"));
            dtIngreso.Columns.Add(new DataColumn("total_gastos"));
            dtIngreso.Columns.Add(new DataColumn("gp"));
            dtIngreso.Columns.Add(new DataColumn("dominio"));
            dtIngreso.Columns.Add(new DataColumn("cert_alzam"));
            dtIngreso.Columns.Add(new DataColumn("varios"));
            dtIngreso.Columns.Add(new DataColumn("copia_plano"));
            dtIngreso.Columns.Add(new DataColumn("insc_comercio"));
            dtIngreso.Columns.Add(new DataColumn("cert_numero"));
            dtIngreso.Columns.Add(new DataColumn("recep_final"));
            dtIngreso.Columns.Add(new DataColumn("avaluo_detallado"));
            dtIngreso.Columns.Add(new DataColumn("cert_no_exprop"));
            dtIngreso.Columns.Add(new DataColumn("archivo_judicial"));
            dtIngreso.Columns.Add(new DataColumn("cert_deslinde"));
            dtIngreso.Columns.Add(new DataColumn("envio"));
            dtIngreso.Columns.Add(new DataColumn("vivienda_social"));
            dtIngreso.Columns.Add(new DataColumn("comentario"));
            dtIngreso.Columns.Add(new DataColumn("gestoria"));
            ViewState["dtIngreso"] = dtIngreso;
        }

        public void DataTableCambioEstado()
        {
            var dtCambioEstado = new DataTable();
            dtCambioEstado.Columns.Add(new DataColumn("hoja_excel"));
            dtCambioEstado.Columns.Add(new DataColumn("fila_excel"));
            dtCambioEstado.Columns.Add(new DataColumn("cliente"));
            dtCambioEstado.Columns.Add(new DataColumn("id_cliente"));
            dtCambioEstado.Columns.Add(new DataColumn("codigo_tipo_operacion"));
            dtCambioEstado.Columns.Add(new DataColumn("estado_revision"));
            dtCambioEstado.Columns.Add(new DataColumn("nomina"));
            dtCambioEstado.Columns.Add(new DataColumn("id_nomina"));
            dtCambioEstado.Columns.Add(new DataColumn("id_solicitud"));
            dtCambioEstado.Columns.Add(new DataColumn("numero_banco"));
            dtCambioEstado.Columns.Add(new DataColumn("rut"));
            dtCambioEstado.Columns.Add(new DataColumn("total_gastos"));
            dtCambioEstado.Columns.Add(new DataColumn("e_titulo"));
            dtCambioEstado.Columns.Add(new DataColumn("borrador"));
            dtCambioEstado.Columns.Add(new DataColumn("inscripcion_cbr"));
            dtCambioEstado.Columns.Add(new DataColumn("tarifa_servicio"));
            dtCambioEstado.Columns.Add(new DataColumn("notaria"));
            dtCambioEstado.Columns.Add(new DataColumn("cbr"));
            dtCambioEstado.Columns.Add(new DataColumn("semaforo"));
            dtCambioEstado.Columns.Add(new DataColumn("mensaje"));
            dtCambioEstado.Columns.Add(new DataColumn("gp"));
            dtCambioEstado.Columns.Add(new DataColumn("dominio"));
            dtCambioEstado.Columns.Add(new DataColumn("cert_alzam"));
            dtCambioEstado.Columns.Add(new DataColumn("varios"));
            dtCambioEstado.Columns.Add(new DataColumn("copia_plano"));
            dtCambioEstado.Columns.Add(new DataColumn("insc_comercio"));
            dtCambioEstado.Columns.Add(new DataColumn("cert_numero"));
            dtCambioEstado.Columns.Add(new DataColumn("recep_final"));
            dtCambioEstado.Columns.Add(new DataColumn("avaluo_detallado"));
            dtCambioEstado.Columns.Add(new DataColumn("cert_no_exprop"));
            dtCambioEstado.Columns.Add(new DataColumn("archivo_judicial"));
            dtCambioEstado.Columns.Add(new DataColumn("cert_deslinde"));
            dtCambioEstado.Columns.Add(new DataColumn("envio"));
            dtCambioEstado.Columns.Add(new DataColumn("vivienda_social"));
            dtCambioEstado.Columns.Add(new DataColumn("comentario"));
            dtCambioEstado.Columns.Add(new DataColumn("gestoria"));
            ViewState["dtCambioEstado"] = dtCambioEstado;
        }

        public void LlenarCambioEstado(DataSet ds, ClienteHipotecario cliente)
        {
            DataTable dtInfo = ds.Tables[0];
            var dt = (DataTable)ViewState["dtCambioEstado"];
            //filaExcel identifica la ubicación en el excel de la fila
            var filaExcel = 1;
            int correctas = 0;
            var incorracta = 0;
            foreach (DataRow drInfo in dtInfo.Rows)
            {
                var rut = string.IsNullOrEmpty(Convert.ToString(drInfo["RUT"])) ? "0" : Convert.ToString(drInfo["RUT"]);
                if (rut == "0")
                {
                    return;
                }

                var rutFormateado = rut.Replace(".", string.Empty);
                rutFormateado = rut.Replace("-", string.Empty);
                rutFormateado = rut.Replace(",", string.Empty);

                var dv = rutFormateado.Substring(rutFormateado.Length - 1, 1);
                rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);


                //INCREMENTO LA FILA DEL EXCEL
                filaExcel++;

                //VARIABLES PARA USO MULTIPLE               
                var idSolicitud = Convert.ToInt32(string.IsNullOrEmpty(Convert.ToString(drInfo["NUMERO AGP"])) ? "0" : Convert.ToString(drInfo["NUMERO AGP"]));




                var numeroBanco = string.IsNullOrEmpty(Convert.ToString(drInfo["NUMERO BANCO"])) ? "0" : Convert.ToString(drInfo["NUMERO BANCO"]);
                var nombreCliente = cliente;
                var nombreNomina = string.IsNullOrEmpty(Convert.ToString(drInfo["NOMINA"])) ? "0" : Convert.ToString(drInfo["NOMINA"]).Trim();
                var idTipoNomina = 0;
                idTipoNomina = nombreNomina != "NOMINA SOLO VALORES" ? new HipotecarioBC().GetNominaByNombre(22, nombreNomina.Trim()) :
                                                                      -1;//-1 para diferenciar las nominas que solo actualizan gastos                          

                var idTipoOperacion = string.Empty;

                //variables de respuesta valores por defecto positivos
                var mensajeAnalisis = string.Empty;
                var iconoAnalisis = IMAGE_REALIZA_CAMBIOS;
                var estadoAnalisis = "1";

                //validación rut
                if (!ValidarRut(rut))
                {
                    mensajeAnalisis = mensajeAnalisis + "Rut inválido-";
                    iconoAnalisis = IMAGEN_SOLO_LECTURA;
                    estadoAnalisis = "0";
                }

                if (cliente == ClienteHipotecario.BCI)
                {

                    var operacionHipoteca = ValidarIdSolicitud(idSolicitud, numeroBanco, Convert.ToInt32(rutFormateado), Convert.ToInt32(cliente));

                    if (operacionHipoteca.IdSolicitud == 0)
                    {
                        mensajeAnalisis = "NO EXISTE OPERACION-";
                        iconoAnalisis = IMAGEN_SOLO_LECTURA;
                        estadoAnalisis = "0";
                    }
                    else
                    {
                        numeroBanco = operacionHipoteca.NumeroCredito;
                        idSolicitud = operacionHipoteca.IdSolicitud;
                        idTipoOperacion = operacionHipoteca.TipoOperacion.Codigo;
                    }
                }

                if (cliente == ClienteHipotecario.SCOTIABANK)
                {
                    var dtOperaciones = new HipotecarioBC().GetIdSolicitud(Convert.ToInt32(rutFormateado));
                    if (dtOperaciones.Rows.Count > 0)
                    {
                        if (dtOperaciones.Rows.Count == 1)
                        {
                            idSolicitud = Convert.ToInt32(dtOperaciones.Rows[0]["id_solicitud"]);
                            numeroBanco = Convert.ToString(dtOperaciones.Rows[0]["numero_cliente"]);
                        }
                        else
                        {
                            mensajeAnalisis = "EXISTEN VARIAS OPERACIONES PARA ESTE COMPRADOR";
                            iconoAnalisis = IMAGEN_SOLO_LECTURA;
                            estadoAnalisis = "0";
                        }
                    }
                    else
                    {
                        mensajeAnalisis = "NO EXISTE OPERACION-";
                        iconoAnalisis = IMAGEN_SOLO_LECTURA;
                        estadoAnalisis = "0";
                    }

                }

                hdnidTipoNomina.Value = idTipoNomina.ToString(CultureInfo.InvariantCulture);

                if (idTipoNomina == 0)
                {
                    mensajeAnalisis = mensajeAnalisis + "Movimiento nómina existe o viene vacío";
                    iconoAnalisis = IMAGEN_ROJO;
                    estadoAnalisis = "0";

                }
                if (nombreNomina != "NOMINA SOLO VALORES" && idTipoNomina != 0)
                {
                    //VALIDAR NOMINA////////// 
                    var disponible = ValidarNomina(idSolicitud, Convert.ToInt16(idTipoNomina), Convert.ToInt32(cliente));
                    if (!disponible)
                    {
                        mensajeAnalisis = mensajeAnalisis + "Movimiento nómina no válido";
                        iconoAnalisis = IMAGEN_ROJO;
                        estadoAnalisis = "0";
                    }
                }

                //llena la grilla
                var dr = dt.NewRow();
                dr["hoja_excel"] = cliente;
                dr["fila_excel"] = filaExcel;
                dr["cliente"] = nombreCliente;
                dr["id_cliente"] = Convert.ToInt32(cliente);
                dr["id_solicitud"] = idSolicitud;
                dr["numero_banco"] = numeroBanco;
                dr["codigo_tipo_operacion"] = idTipoOperacion;
                dr["rut"] = rut;
                dr["id_nomina"] = idTipoNomina;
                dr["nomina"] = nombreNomina;
                dr["comentario"] = Convert.ToString(drInfo["NUEVO COMENTARIO"]);

                //VARIABLE QUE GUARDA EL VALOR DE LOS TRAMITES
                int gastosTramites = 0;

                if (cliente == ClienteHipotecario.BCI)
                {
                    var gastoEtitulo = string.IsNullOrEmpty(Convert.ToString(drInfo["ESTUDIO DE TITULO"])) ? "0" : Convert.ToString(drInfo["ESTUDIO DE TITULO"]);
                    var gastoBorador = string.IsNullOrEmpty(Convert.ToString(drInfo["BORRADOR ESCRITURA"])) ? "0" : Convert.ToString(drInfo["BORRADOR ESCRITURA"]);
                    var gastoInscripcionCbr = string.IsNullOrEmpty(Convert.ToString(drInfo["SERVICIO CBR"])) ? "0" : Convert.ToString(drInfo["SERVICIO CBR"]);
                    var gastoGestoria = string.IsNullOrEmpty(Convert.ToString(drInfo["SERVICIO GESTORIA"])) ? "0" : Convert.ToString(drInfo["SERVICIO GESTORIA"]);

                    dr["e_titulo"] = gastoEtitulo;
                    dr["borrador"] = gastoBorador;
                    dr["inscripcion_cbr"] = gastoInscripcionCbr;
                    dr["gestoria"] = gastoGestoria;

                    gastosTramites = Convert.ToInt32(gastoEtitulo)
                                    + Convert.ToInt32(gastoBorador)
                                    + Convert.ToInt32(gastoInscripcionCbr)
                                    + Convert.ToInt32(gastoGestoria);

                    dr["tarifa_servicio"] = 0;

                }
                else if (cliente == ClienteHipotecario.SCOTIABANK)
                {
                    var gastoTramiteNotaría = string.IsNullOrEmpty(Convert.ToString(drInfo["TARIFA SERVICIO UF"])) ? "0" : Convert.ToString(drInfo["TARIFA SERVICIO UF"]);
                    dr["tarifa_servicio"] = gastoTramiteNotaría;
                    gastosTramites = Convert.ToInt32(gastoTramiteNotaría);

                }

                #region GASTOS TRANSVERSALES

                var gastoNotaría = string.IsNullOrEmpty(Convert.ToString(drInfo["Notaria"])) ? "0" : Convert.ToString(drInfo["Notaria"]);
                var gastoCbr = string.IsNullOrEmpty(Convert.ToString(drInfo["CBR"])) ? "0" : Convert.ToString(drInfo["CBR"]);
                var gastoGp = string.IsNullOrEmpty(Convert.ToString(drInfo["GP"])) ? "0" : Convert.ToString(drInfo["GP"]);
                var gastoDominio = string.IsNullOrEmpty(Convert.ToString(drInfo["DV"])) ? "0" : Convert.ToString(drInfo["DV"]);
                var gastoAlzamiento = string.IsNullOrEmpty(Convert.ToString(drInfo["Alzam"])) ? "0" : Convert.ToString(drInfo["Alzam"]);
                var gastoVarios = string.IsNullOrEmpty(Convert.ToString(drInfo["Varios"])) ? "0" : Convert.ToString(drInfo["Varios"]);
                var gastocopiaPlano = string.IsNullOrEmpty(Convert.ToString(drInfo["Plano"])) ? "0" : Convert.ToString(drInfo["Plano"]);
                var gastoComercio = string.IsNullOrEmpty(Convert.ToString(drInfo["Insc Comercio"])) ? "0" : Convert.ToString(drInfo["Insc Comercio"]);
                var gastocertNum = string.IsNullOrEmpty(Convert.ToString(drInfo["Numero"])) ? "0" : Convert.ToString(drInfo["Numero"]);
                var gastoRecpFin = string.IsNullOrEmpty(Convert.ToString(drInfo["Rec Final"])) ? "0" : Convert.ToString(drInfo["Rec Final"]);
                var gastoAvaluo = string.IsNullOrEmpty(Convert.ToString(drInfo["Avaluo Det"])) ? "0" : Convert.ToString(drInfo["Avaluo Det"]);
                var gastoNoExprop = string.IsNullOrEmpty(Convert.ToString(drInfo["No Exprop"])) ? "0" : Convert.ToString(drInfo["No Exprop"]);
                var gastoArchJudi = string.IsNullOrEmpty(Convert.ToString(drInfo["Archivo Judicial"])) ? "0" : Convert.ToString(drInfo["Archivo Judicial"]);
                var gastoDeslindes = string.IsNullOrEmpty(Convert.ToString(drInfo["Deslinde"])) ? "0" : Convert.ToString(drInfo["Deslinde"]);
                var gastoEnvio = string.IsNullOrEmpty(Convert.ToString(drInfo["Envio"])) ? "0" : Convert.ToString(drInfo["Envio"]);
                var gastoViviendaSocial = string.IsNullOrEmpty(Convert.ToString(drInfo["Vivienda Social"])) ? "0" : Convert.ToString(drInfo["Vivienda Social"]);

                dr["notaria"] = gastoNotaría;
                dr["cbr"] = gastoCbr;
                dr["gp"] = gastoGp;
                dr["dominio"] = gastoDominio;
                dr["cert_alzam"] = gastoAlzamiento;
                dr["varios"] = gastoVarios;
                dr["copia_plano"] = gastocopiaPlano;
                dr["insc_comercio"] = gastoComercio;
                dr["cert_numero"] = gastocertNum;
                dr["recep_final"] = gastoRecpFin;
                dr["avaluo_detallado"] = gastoAvaluo;
                dr["cert_no_exprop"] = gastoNoExprop;
                dr["archivo_judicial"] = gastoArchJudi;
                dr["cert_deslinde"] = gastoDeslindes;
                dr["envio"] = gastoEnvio;
                dr["vivienda_social"] = gastoViviendaSocial;
                dr["total_gastos"] = gastosTramites + Convert.ToInt32(gastoNotaría) + Convert.ToInt32(gastoCbr) +
                                    Convert.ToInt32(gastoGp) + Convert.ToInt32(gastoDominio) +
                                    Convert.ToInt32(gastoAlzamiento) + Convert.ToInt32(gastoVarios) +
                                    Convert.ToInt32(gastocopiaPlano) + Convert.ToInt32(gastoComercio) +
                                    Convert.ToInt32(gastocertNum) + Convert.ToInt32(gastoRecpFin) + Convert.ToInt32(gastoAvaluo) +
                                    Convert.ToInt32(gastoNoExprop) + Convert.ToInt32(gastoArchJudi) + Convert.ToInt32(gastoDeslindes) +
                                    Convert.ToInt32(gastoEnvio) + Convert.ToInt32(gastoViviendaSocial);
                #endregion

                dr["estado_revision"] = estadoAnalisis;
                dr["semaforo"] = iconoAnalisis;
                dr["mensaje"] = mensajeAnalisis == string.Empty ? "Correcto" : mensajeAnalisis;
                dt.Rows.Add(dr);

                if (estadoAnalisis == "1")
                {
                    correctas++;
                }
                else
                {
                    incorracta++;
                }
            }
            grCambioEstado.DataSource = dt;
            grCambioEstado.DataBind();
            ViewState["dtCambioEstado"] = dt;

        }

        public void LlenarNuevasOperaciones(DataSet ds, ClienteHipotecario cliente, HojasExcel hojaExcel, bool gestoria = false)
        {
            DataTable dtInfo = ds.Tables[0];
            var dt = (DataTable)ViewState["dtIngreso"];

            //filaExcel identifica la ubicación en el excel de la fila
            var filaExcel = 1;
            var correctas = 0;
            var incorracta = 0;
            foreach (DataRow drInfo in dtInfo.Rows)
            {
                //INCREMENTO LA FILA DEL EXCEL
                filaExcel++;

                //VARIABLES PARA USO MULTIPLE
                var rut = string.IsNullOrEmpty(Convert.ToString(drInfo["RUT"])) ? "0" : Convert.ToString(drInfo["RUT"]);

                string nombreTipoOperacion;

                if (!gestoria)
                {
                    nombreTipoOperacion = string.IsNullOrEmpty(Convert.ToString(drInfo["TIPO OPERACION"])) ? "0" : Convert.ToString(drInfo["TIPO OPERACION"]);
                }
                else
                {
                    nombreTipoOperacion = "GESTORIA DOCUMENTAL";

                    var nombreClienteExcel = Convert.ToString(drInfo["CLIENTE"]).Trim().ToUpper();

                    switch (nombreClienteExcel)
                    {
                        case "BCI":
                            cliente = ClienteHipotecario.BCI;
                            break;
                        case "SCOTIABANK":
                            cliente = ClienteHipotecario.SCOTIABANK;
                            break;
                    }


                }

                #region VALIDACIONES DE LOS CAMPOS

                //variables de respuesta valores por defecto positivos
                var mensajeAnalisis = string.Empty;
                var iconoAnalisis = IMAGE_REALIZA_CAMBIOS;
                var estadoAnalisis = "1";

                //RUT
                if (!ValidarRut(rut))
                {
                    mensajeAnalisis = "Rut inválido";
                    iconoAnalisis = IMAGEN_SOLO_LECTURA;
                    estadoAnalisis = "0";
                }

                //TIPO OPERACION
                var tipoOperacion = ValidaTipoOperacion(nombreTipoOperacion, Convert.ToInt32(cliente));
                if (!tipoOperacion.DatoBoleano)
                {
                    mensajeAnalisis = mensajeAnalisis + ", Tipo Operación Inválido";
                    iconoAnalisis = IMAGEN_SOLO_LECTURA;
                    estadoAnalisis = "0";
                }

                //SI OPERACION EXISTE
                var numeroBanco = Convert.ToString(drInfo["NUMERO BANCO"]);
                if (numeroBanco.Trim() != "0")
                {
                    var existeOperacion = ValidaExisteOperacion(tipoOperacion.DatoTexto,
                                                           numeroBanco, Convert.ToInt32(cliente));

                    if (existeOperacion)
                    {
                        mensajeAnalisis = mensajeAnalisis + ", Operación ya fue ingresada";
                        iconoAnalisis = IMAGEN_SOLO_LECTURA;
                        estadoAnalisis = "0";
                    }
                }

                #endregion

                //LLENADO DE GRIDVIEW
                var dr = dt.NewRow();
                dr["hoja_excel"] = hojaExcel;
                dr["fila_excel"] = filaExcel;
                dr["cliente"] = cliente;
                dr["id_cliente"] = Convert.ToInt32(cliente);
                dr["codigo_tipo_operacion"] = tipoOperacion.DatoTexto;
                dr["tipo_operacion"] = nombreTipoOperacion;
                dr["numero_banco"] = string.IsNullOrEmpty(Convert.ToString(drInfo["NUMERO BANCO"])) ? "0" : Convert.ToString(drInfo["NUMERO BANCO"]);
                dr["rut"] = rut;
                dr["nombre"] = Convert.ToString(drInfo["Nombre"]);
                dr["apepat"] = Convert.ToString(drInfo["Apellido Paterno"]);
                dr["apemat"] = Convert.ToString(drInfo["Apellido Materno"]);
                dr["comentario"] = Convert.ToString(drInfo["NUEVO COMENTARIO"]);

                //VARIABLE QUE GUARDA EL VALOR DE LOS TRAMITES
                int gastosTramites = 0;

                if (cliente == ClienteHipotecario.BCI && !gestoria)
                {
                    var gastoEtitulo = string.IsNullOrEmpty(Convert.ToString(drInfo["ESTUDIO DE TITULO"])) ? "0" : Convert.ToString(drInfo["ESTUDIO DE TITULO"]);
                    var gastoBorador = string.IsNullOrEmpty(Convert.ToString(drInfo["BORRADOR ESCRITURA"])) ? "0" : Convert.ToString(drInfo["BORRADOR ESCRITURA"]);
                    var gastoInscripcionCbr = string.IsNullOrEmpty(Convert.ToString(drInfo["SERVICIO CBR"])) ? "0" : Convert.ToString(drInfo["SERVICIO CBR"]);
                    var gastoGestoria = string.IsNullOrEmpty(Convert.ToString(drInfo["SERVICIO GESTORIA"])) ? "0" : Convert.ToString(drInfo["SERVICIO GESTORIA"]);

                    dr["e_titulo"] = gastoEtitulo;
                    dr["borrador"] = gastoBorador;
                    dr["inscripcion_cbr"] = gastoInscripcionCbr;
                    dr["gestoria"] = gastoGestoria;

                    gastosTramites = Convert.ToInt32(gastoEtitulo)
                                    + Convert.ToInt32(gastoBorador)
                                    + Convert.ToInt32(gastoInscripcionCbr)
                                    + Convert.ToInt32(gastoGestoria);

                    dr["tarifa_servicio"] = 0;

                }
                else if (cliente == ClienteHipotecario.SCOTIABANK && !gestoria)
                {
                    var tarifaServicio = string.IsNullOrEmpty(Convert.ToString(drInfo["TARIFA SERVICIO UF"])) ? "0" : Convert.ToString(drInfo["TARIFA SERVICIO UF"]);

                    dr["tarifa_servicio"] = tarifaServicio;
                    gastosTramites = Convert.ToInt32(tarifaServicio);

                }

                #region GASTOS TRANSVERSALES

                var gastoNotaría = string.IsNullOrEmpty(Convert.ToString(drInfo["Notaria"])) ? "0" : Convert.ToString(drInfo["Notaria"]);
                var gastoCbr = string.IsNullOrEmpty(Convert.ToString(drInfo["CBR"])) ? "0" : Convert.ToString(drInfo["CBR"]);
                var gastoGp = string.IsNullOrEmpty(Convert.ToString(drInfo["GP"])) ? "0" : Convert.ToString(drInfo["GP"]);
                var gastoDominio = string.IsNullOrEmpty(Convert.ToString(drInfo["DV"])) ? "0" : Convert.ToString(drInfo["DV"]);
                var gastoAlzamiento = string.IsNullOrEmpty(Convert.ToString(drInfo["Alzam"])) ? "0" : Convert.ToString(drInfo["Alzam"]);
                var gastoVarios = string.IsNullOrEmpty(Convert.ToString(drInfo["Varios"])) ? "0" : Convert.ToString(drInfo["Varios"]);
                var gastocopiaPlano = string.IsNullOrEmpty(Convert.ToString(drInfo["Plano"])) ? "0" : Convert.ToString(drInfo["Plano"]);
                var gastoComercio = string.IsNullOrEmpty(Convert.ToString(drInfo["Insc Comercio"])) ? "0" : Convert.ToString(drInfo["Insc Comercio"]);
                var gastocertNum = string.IsNullOrEmpty(Convert.ToString(drInfo["Numero"])) ? "0" : Convert.ToString(drInfo["Numero"]);
                var gastoRecpFin = string.IsNullOrEmpty(Convert.ToString(drInfo["Rec Final"])) ? "0" : Convert.ToString(drInfo["Rec Final"]);
                var gastoAvaluo = string.IsNullOrEmpty(Convert.ToString(drInfo["Avaluo Det"])) ? "0" : Convert.ToString(drInfo["Avaluo Det"]);
                var gastoNoExprop = string.IsNullOrEmpty(Convert.ToString(drInfo["No Exprop"])) ? "0" : Convert.ToString(drInfo["No Exprop"]);
                var gastoArchJudi = string.IsNullOrEmpty(Convert.ToString(drInfo["Archivo Judicial"])) ? "0" : Convert.ToString(drInfo["Archivo Judicial"]);
                var gastoDeslindes = string.IsNullOrEmpty(Convert.ToString(drInfo["Deslinde"])) ? "0" : Convert.ToString(drInfo["Deslinde"]);
                var gastoEnvio = string.IsNullOrEmpty(Convert.ToString(drInfo["Envio"])) ? "0" : Convert.ToString(drInfo["Envio"]);
                var gastoViviendaSocial = string.IsNullOrEmpty(Convert.ToString(drInfo["Vivienda Social"])) ? "0" : Convert.ToString(drInfo["Vivienda Social"]);

                dr["notaria"] = gastoNotaría;
                dr["cbr"] = gastoCbr;
                dr["gp"] = gastoGp;
                dr["dominio"] = gastoDominio;
                dr["cert_alzam"] = gastoAlzamiento;
                dr["varios"] = gastoVarios;
                dr["copia_plano"] = gastocopiaPlano;
                dr["insc_comercio"] = gastoComercio;
                dr["cert_numero"] = gastocertNum;
                dr["recep_final"] = gastoRecpFin;
                dr["avaluo_detallado"] = gastoAvaluo;
                dr["cert_no_exprop"] = gastoNoExprop;
                dr["archivo_judicial"] = gastoArchJudi;
                dr["cert_deslinde"] = gastoDeslindes;
                dr["envio"] = gastoEnvio;
                dr["vivienda_social"] = gastoViviendaSocial;
                dr["total_gastos"] = gastosTramites + Convert.ToInt32(gastoNotaría) + Convert.ToInt32(gastoCbr) +
                                    Convert.ToInt32(gastoGp) + Convert.ToInt32(gastoDominio) +
                                    Convert.ToInt32(gastoAlzamiento) + Convert.ToInt32(gastoVarios) +
                                    Convert.ToInt32(gastocopiaPlano) + Convert.ToInt32(gastoComercio) +
                                    Convert.ToInt32(gastocertNum) + Convert.ToInt32(gastoRecpFin) + Convert.ToInt32(gastoAvaluo) +
                                    Convert.ToInt32(gastoNoExprop) + Convert.ToInt32(gastoArchJudi) + Convert.ToInt32(gastoDeslindes) +
                                    Convert.ToInt32(gastoEnvio) + Convert.ToInt32(gastoViviendaSocial);
                #endregion

                dr["estado_revision"] = estadoAnalisis;
                dr["semaforo"] = iconoAnalisis;
                dr["mensaje"] = mensajeAnalisis == string.Empty ? "Correcto" : mensajeAnalisis;
                dt.Rows.Add(dr);

                switch (estadoAnalisis)
                {
                    case "1":
                        correctas++;
                        break;
                    default:
                        incorracta++;
                        break;
                }

            }

            grDato.DataSource = dt;
            grDato.DataBind();
            ViewState["dtIngreso"] = dt;

        }

        public bool ValidarRut(string rut)
        {
            var rutFormateado = rut.Replace(".", string.Empty);
            rutFormateado = rut.Replace("-", string.Empty);
            rutFormateado = rut.Replace(",", string.Empty);

            var dv = rutFormateado.Substring(rutFormateado.Length - 1, 1);
            rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);
            var dvValidacion = FuncionGlobal.digitoVerificador(rutFormateado);
            return dvValidacion.ToLower().Trim() == dv.ToLower().Trim();
        }

        public class ObjetoDatos
        {
            public string DatoTexto { get; set; }
            public bool DatoBoleano { get; set; }
            public int DatoNumerico { get; set; }
        }

        public Hipotecario ValidarIdSolicitud(int idSolicitud, string numeroOperación, int rut, int idCliente)
        {
            return new HipotecarioBC().ValidarOperacion(idSolicitud, numeroOperación, rut, idCliente);
        }

        public bool ValidaExisteOperacion(string tipoOperacion, string numeroBanco, int idCliente)
        {
            return new HipotecarioBC().ValidaExisteOperacion(tipoOperacion, numeroBanco, idCliente);
        }

        public ObjetoDatos ValidaTipoOperacion(string tipoOperacion, int idCliente)
        {
            var listaTipoOperacion = from tipo in new TipooperacionBC().getTipo_OperacionByClienteandfamilia(Convert.ToInt16(idCliente), "todo", 22) where tipo.Check select tipo;
            var resultado = new ObjetoDatos { DatoBoleano = false, DatoTexto = string.Empty };
            foreach (var operacion in listaTipoOperacion)
            {
                if (operacion.Operacion.ToLower().Trim() != tipoOperacion.ToLower().Trim()) continue;
                resultado.DatoBoleano = true;
                resultado.DatoTexto = operacion.Codigo;
            }
            return resultado;
        }

        public int AddOperacion(string codigoTipoOperacion, Int16 idCliente, string numeroCliente, int idSucursal, Persona comprador)
        {
            string persona = new PersonaBC().add_persona(comprador.Rut, comprador.Dv, 1, "", comprador.Nombre, comprador.Apellido_paterno, comprador.Apellido_materno, "0", "0", "", "", "0", "", "", "", "", "", "", "0", "PARTICULAR");

            new DireccionesBC().add_direcciones(Convert.ToInt32(comprador.Rut), "Miguel Claro", "DOFI", "070", 1,
                                                "Oficina 33, Edificio Torres de Tajamar torre C", 0);

            const int factura = 0; //siempre 0 por defecto

            Int32 add = new OperacionBC().add_operacion(0, idCliente,
                                                        codigoTipoOperacion, (string)(Session["usrname"]), 0, numeroCliente,
                                                        idSucursal, factura, "");

            string addparven = new ParticipeOperacionBC().add_participe(Convert.ToInt32(add), Convert.ToInt32(comprador.Rut), "COMPR");

            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, codigoTipoOperacion, "", (string)(Session["usrname"]));

            return add;

        }

        public void AgregarGastos(int idSolicitud, Int32 idTipoGasto, int monto, string gastoComun = "true", int sumarValores = 0)
        {
            if (monto != 0)
            {
                string add = new GastooperacionBC().add_gastooperacion(idSolicitud, Convert.ToInt16(idTipoGasto), monto, (string)(Session["usrname"]), monto, 0, gastoComun, sumarValores);
                //  new chequesBC().AddMovimientoCajaChica((string) (Session["usrname"]), 22, monto, "1", idTipoGasto,   idSolicitud);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NuevaOperacion();
                IngresoEstado();
                Limpiar();

                FuncionGlobal.alerta("Los cambios fueron aplicados correctamente", Page);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta(ex.Message, Page);
            }

        }

        public void NuevaOperacion()
        {
            for (int i = 0; i < grDato.Rows.Count; i++)
            {
                var estadoRevision = Convert.ToString(grDato.DataKeys[i].Values["estado_revision"]);
                //si pasa las validaciones
                if (estadoRevision == "1")
                {
                    bool gastoTransversalesFacturables = false;
                    var codigoTipoOperacion = Convert.ToString(grDato.DataKeys[i].Values["codigo_tipo_operacion"]);
                    var numeroBanco = Convert.ToString(grDato.DataKeys[i].Values["numero_banco"]);
                    var idCliente = Convert.ToInt16(grDato.DataKeys[i].Values["id_cliente"]);
                    string rut = Convert.ToString(grDato.DataKeys[i].Values["rut"]);
                    string dv = rut.Substring(rut.Length - 1, 1);
                    rut = rut.Substring(0, rut.Length - 1);
                    var cliente = new ClienteHipotecario();
                    var sucursalDefecto = 0;
                    switch (idCliente)
                    {
                        case 91:
                            cliente = ClienteHipotecario.BCI;
                            sucursalDefecto = 1624;
                            gastoTransversalesFacturables = false;
                            break;
                        case 19:
                            cliente = ClienteHipotecario.SCOTIABANK;
                            sucursalDefecto = 789;
                            gastoTransversalesFacturables = true;
                            break;
                    }


                    var comprador = new Persona
                    {
                        Rut = Convert.ToInt32(rut),
                        Dv = dv,
                        Nombre = Convert.ToString(grDato.DataKeys[i].Values["nombre"]),
                        Apellido_paterno = Convert.ToString(grDato.DataKeys[i].Values["apepat"]),
                        Apellido_materno = Convert.ToString(grDato.DataKeys[i].Values["apemat"])
                    };

                    var idSolicitud = AddOperacion(codigoTipoOperacion, idCliente, numeroBanco, sucursalDefecto, comprador);
                    string comentario = Convert.ToString(grDato.DataKeys[i].Values["comentario"]).Trim();
                    if (comentario != string.Empty)
                    {
                        AddComentarioOperacion(idSolicitud, comentario);
                    }


                    #region Gastos
                    //gastos para cliente BCI

                    #region ID GASTOS
                    Int32 idGastoEstudioTitulo = 0;
                    Int32 idGastoBorrador = 0;
                    Int32 idGestoria = 0;
                    Int32 idTramiteIngresoCbr = 0;
                    Int32 idTarifaServicio = 0;
                    //TRANSVERSALES
                    Int32 idGastoNotaria = 0;
                    Int32 idGastoCbr = 0;
                    Int32 idGastoGp = 0;
                    Int32 idGastoDominio = 0;
                    Int32 idGastoCertAlz = 0;
                    Int32 idGastoVarios = 0;
                    Int32 idGastoCopiaPlano = 0;
                    Int32 idGastoInscComercio = 0;
                    Int32 idGastoCertNum = 0;
                    Int32 idGastoRecepFinal = 0;
                    Int32 idGastoAvaluoDetallado = 0;
                    Int32 idGastoCertNoExprop = 0;
                    Int32 idGastoArchivoJudicial = 0;
                    Int32 idGastoCertDeslindes = 0;
                    Int32 idGastoEnvio = 0;
                    Int32 idGastoViviendaSocial = 0;
                    #endregion

                    #region VALORES GASTOS
                    Int32 estudioTitulo;
                    Int32 borradorEscritura;
                    Int32 ingresoCbr;
                    Int32 tarifaServicio;
                    Int32 gestoria;

                    //--
                    Int32 notaria;
                    Int32 cbr;
                    Int32 Gp;
                    Int32 Dominio;
                    Int32 CertAlz;
                    Int32 Varios;
                    Int32 CopiaPlano;
                    Int32 InscComercio;
                    Int32 CertNum;
                    Int32 RecepFinal;
                    Int32 AvaluoDetallado;
                    Int32 CertNoExprop;
                    Int32 ArchivoJudicial;
                    Int32 CertDeslindes;
                    Int32 Envio;
                    Int32 Social;

                    #endregion

                    if (cliente == ClienteHipotecario.BCI && codigoTipoOperacion.Trim() != "GTDOC")
                    {
                        estudioTitulo = Convert.ToInt32(grDato.DataKeys[i].Values["e_titulo"]);
                        borradorEscritura = Convert.ToInt32(grDato.DataKeys[i].Values["borrador"]);
                        ingresoCbr = Convert.ToInt32(grDato.DataKeys[i].Values["inscripcion_cbr"]);
                        gestoria = Convert.ToInt32(grDato.DataKeys[i].Values["gestoria"]);
                        //LLENAR ID
                        //LLENAR ID
                        switch (codigoTipoOperacion.Trim().ToLowerInvariant())
                        {
                            case "chip":
                            case "cvdh":
                            case "canco":
                                idGastoEstudioTitulo = 131;
                                idGastoBorrador = 132;
                                break;
                            case "rech":
                            case "rcdh":
                            case "fgrls":
                                idGastoEstudioTitulo = 136;
                                idGastoBorrador = 137;
                                break;
                        }
                        idTramiteIngresoCbr = 134;
                        idGastoNotaria = 133;
                        idGastoCbr = 135;
                        idGestoria = 174;///cambiar

                        //LLENAR VALORES EN BD
                        if (estudioTitulo != 0)
                        {
                            AgregarGastos(idSolicitud, idGastoEstudioTitulo, estudioTitulo);
                        }
                        if (borradorEscritura != 0)
                        {
                            AgregarGastos(idSolicitud, idGastoBorrador, borradorEscritura);
                        }
                        if (ingresoCbr != 0)
                        {
                            AgregarGastos(idSolicitud, idTramiteIngresoCbr, ingresoCbr);
                        }
                        if (gestoria != 0)
                        {
                            AgregarGastos(idSolicitud, idGestoria, gestoria);
                        }
                    }
                    else if (cliente == ClienteHipotecario.SCOTIABANK && codigoTipoOperacion.Trim() != "GTDOC")
                    {
                        tarifaServicio = Convert.ToInt32(grDato.DataKeys[i].Values["tarifa_servicio"]);

                        switch (codigoTipoOperacion.Trim().ToLowerInvariant())
                        {
                            case "conh":
                                break;
                                AgregarGastos(idSolicitud, 1178, tarifaServicio, "FALSE");//CONSUMER
                            case "refin":
                                AgregarGastos(idSolicitud, 1177, tarifaServicio, "FALSE");//REF INTERNO
                                break;
                            case "renh":
                                AgregarGastos(idSolicitud, 1176, tarifaServicio, "FALSE");//RENEGOCIACIONES
                                break;
                        }

                    }
                    //para las gestorias
                    else if (codigoTipoOperacion.Trim() == "GTDOC")
                    {
                        //gasto del tramite
                        if (cliente == ClienteHipotecario.BCI)
                        {
                            AgregarGastos(idSolicitud, 1152, 18000, "FALSE");  //OJO!!!!en duro gasto gestoria para bci 18000
                        }
                        else if (cliente == ClienteHipotecario.SCOTIABANK)
                        {
                            AgregarGastos(idSolicitud, 1175, 0, "FALSE");  //OJO!!!!en duro gasto gestoria para bci 18000
                        }

                    }

                    idGastoNotaria = gastoTransversalesFacturables ? 175 : 133;
                    idGastoCbr = gastoTransversalesFacturables ? 165 : 147;
                    idGastoGp = gastoTransversalesFacturables ? 159 : 141;
                    idGastoDominio = gastoTransversalesFacturables ? 160 : 142;
                    idGastoCertAlz = gastoTransversalesFacturables ? 161 : 143;
                    idGastoVarios = gastoTransversalesFacturables ? 172 : 154;
                    idGastoCopiaPlano = gastoTransversalesFacturables ? 163 : 145;
                    idGastoInscComercio = gastoTransversalesFacturables ? 164 : 146;
                    idGastoCertNum = gastoTransversalesFacturables ? 166 : 148;
                    idGastoRecepFinal = gastoTransversalesFacturables ? 167 : 149;
                    idGastoAvaluoDetallado = gastoTransversalesFacturables ? 168 : 150;
                    idGastoCertNoExprop = gastoTransversalesFacturables ? 169 : 151;
                    idGastoArchivoJudicial = gastoTransversalesFacturables ? 170 : 152;
                    idGastoCertDeslindes = gastoTransversalesFacturables ? 171 : 153;
                    idGastoEnvio = gastoTransversalesFacturables ? 162 : 144;
                    idGastoViviendaSocial = gastoTransversalesFacturables ? 173 : 155;


                    notaria = Convert.ToInt32(grDato.DataKeys[i].Values["notaria"]);
                    cbr = Convert.ToInt32(grDato.DataKeys[i].Values["cbr"]);
                    Gp = Convert.ToInt32(grDato.DataKeys[i].Values["gp"]);
                    Dominio = Convert.ToInt32(grDato.DataKeys[i].Values["dominio"]);
                    CertAlz = Convert.ToInt32(grDato.DataKeys[i].Values["cert_alzam"]);
                    Varios = Convert.ToInt32(grDato.DataKeys[i].Values["varios"]);
                    CopiaPlano = Convert.ToInt32(grDato.DataKeys[i].Values["copia_plano"]);
                    InscComercio = Convert.ToInt32(grDato.DataKeys[i].Values["insc_comercio"]);
                    CertNum = Convert.ToInt32(grDato.DataKeys[i].Values["cert_numero"]);
                    RecepFinal = Convert.ToInt32(grDato.DataKeys[i].Values["recep_final"]);
                    AvaluoDetallado = Convert.ToInt32(grDato.DataKeys[i].Values["avaluo_detallado"]);
                    CertNoExprop = Convert.ToInt32(grDato.DataKeys[i].Values["cert_no_exprop"]);
                    ArchivoJudicial = Convert.ToInt32(grDato.DataKeys[i].Values["archivo_judicial"]);
                    CertDeslindes = Convert.ToInt32(grDato.DataKeys[i].Values["cert_deslinde"]);
                    Envio = Convert.ToInt32(grDato.DataKeys[i].Values["envio"]);
                    Social = Convert.ToInt32(grDato.DataKeys[i].Values["vivienda_social"]);

                    int sumaGatos = cliente == ClienteHipotecario.SCOTIABANK ? 1 : 0;

                    if (notaria != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoNotaria, notaria, "true", sumaGatos);
                    }
                    if (cbr != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCbr, cbr, "true", sumaGatos);
                    }
                    if (Gp != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoGp, Gp, "true", sumaGatos);
                    }
                    if (Dominio != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoDominio, Dominio, "true", sumaGatos);
                    }
                    if (CertAlz != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertAlz, CertAlz, "true", sumaGatos);
                    }
                    if (Varios != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoVarios, Varios, "true", sumaGatos);
                    }
                    if (CopiaPlano != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCopiaPlano, CopiaPlano, "true", sumaGatos);
                    }
                    if (InscComercio != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoInscComercio, InscComercio, "true", sumaGatos);
                    }
                    if (CertNum != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertNum, CertNum, "true", sumaGatos);
                    }
                    if (RecepFinal != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoRecepFinal, RecepFinal, "true", sumaGatos);
                    }
                    if (AvaluoDetallado != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoAvaluoDetallado, AvaluoDetallado, "true", sumaGatos);
                    }
                    if (CertNoExprop != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertNoExprop, CertNoExprop, "true", sumaGatos);
                    }
                    if (ArchivoJudicial != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoArchivoJudicial, ArchivoJudicial, "true", sumaGatos);
                    }
                    if (CertDeslindes != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertDeslindes, CertDeslindes, "true", sumaGatos);
                    }
                    if (Envio != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoEnvio, Envio, "true", sumaGatos);
                    }
                    if (Social != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoViviendaSocial, Social, "true", sumaGatos);
                    }


                    #endregion Gastos


                }

            }
        }

        public void IngresoEstado()
        {
            var cliente = new ClienteHipotecario();//AQUI QUEDE....LLENAR AL CLIENTE...
            var idtiponomina = hdnidTipoNomina.Value;
            var tipoNomina = new TipoNomina();
            var gastoTransversalesFacturables = false;
            if (Convert.ToInt32(idtiponomina) != -1)  //si la nomina no es de solo actulización de gastos
            {
                tipoNomina = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(idtiponomina));
            }

            for (var i = 0; i < grCambioEstado.Rows.Count; i++)
            {
                var estadoRevision = Convert.ToString(grCambioEstado.DataKeys[i].Values["estado_revision"]);
                //si pasa las validaciones
                if (estadoRevision == "1")
                {

                    var idCliente = Convert.ToInt16(grCambioEstado.DataKeys[i].Values["id_cliente"]);
                    switch (idCliente)
                    {
                        case 19:
                            cliente = ClienteHipotecario.SCOTIABANK;
                            gastoTransversalesFacturables = true;
                            break;
                        case 91:
                            cliente = ClienteHipotecario.BCI;
                            gastoTransversalesFacturables = false;
                            break;
                    }

                    var codigoTipoOperacion = Convert.ToString(grCambioEstado.DataKeys[i].Values["codigo_tipo_operacion"]).Trim().ToUpper();
                    var idSolicitud = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["id_solicitud"]);
                    string rut = Convert.ToString(grCambioEstado.DataKeys[i].Values["rut"]);
                    rut = rut.Substring(0, rut.Length - 1);
                    var rutNumerico = Convert.ToInt32(rut);

                    if (Convert.ToInt32(idtiponomina) != -1)    //si la nomina no es de solo actulización de gastos
                    {
                        //insertar estado con nominas////aqui
                        GenerarNomina(Convert.ToInt32(idtiponomina), idSolicitud, tipoNomina);
                    }

                    new DireccionesBC().add_direcciones(rutNumerico, "Miguel Claro", "DOFI", "070", 1,
                                                "Oficina 33, Edificio Torres de Tajamar torre C", 0);

                    string comentario = Convert.ToString(grCambioEstado.DataKeys[i].Values["comentario"]).Trim();
                    if (comentario != string.Empty)
                    {
                        AddComentarioOperacion(idSolicitud, comentario);
                    }

                    #region Gastos

                    #region ID GASTOS
                    Int32 idGastoEstudioTitulo = 0;
                    Int32 idGastoBorrador = 0;
                    Int32 idGestoria = 0;
                    Int32 idTramiteIngresoCbr = 0;
                    Int32 idTarifaServicio = 0;
                    //TRANSVERSALES
                    Int32 idGastoNotaria = 0;
                    Int32 idGastoCbr = 0;
                    Int32 idGastoGp = 0;
                    Int32 idGastoDominio = 0;
                    Int32 idGastoCertAlz = 0;
                    Int32 idGastoVarios = 0;
                    Int32 idGastoCopiaPlano = 0;
                    Int32 idGastoInscComercio = 0;
                    Int32 idGastoCertNum = 0;
                    Int32 idGastoRecepFinal = 0;
                    Int32 idGastoAvaluoDetallado = 0;
                    Int32 idGastoCertNoExprop = 0;
                    Int32 idGastoArchivoJudicial = 0;
                    Int32 idGastoCertDeslindes = 0;
                    Int32 idGastoEnvio = 0;
                    Int32 idGastoViviendaSocial = 0;
                    #endregion

                    #region VALORES GASTOS
                    Int32 estudioTitulo;
                    Int32 borradorEscritura;
                    Int32 ingresoCbr;
                    Int32 tarifaServicio;
                    Int32 gestoria;

                    //--
                    Int32 notaria;
                    Int32 cbr;
                    Int32 Gp;
                    Int32 Dominio;
                    Int32 CertAlz;
                    Int32 Varios;
                    Int32 CopiaPlano;
                    Int32 InscComercio;
                    Int32 CertNum;
                    Int32 RecepFinal;
                    Int32 AvaluoDetallado;
                    Int32 CertNoExprop;
                    Int32 ArchivoJudicial;
                    Int32 CertDeslindes;
                    Int32 Envio;
                    Int32 Social;

                    #endregion

                    if (cliente == ClienteHipotecario.BCI && codigoTipoOperacion.Trim() != "GTDOC")
                    {
                        estudioTitulo = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["e_titulo"]);
                        borradorEscritura = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["borrador"]);
                        ingresoCbr = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["inscripcion_cbr"]);
                        gestoria = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["gestoria"]);

                        //LLENAR ID
                        switch (codigoTipoOperacion.Trim().ToLowerInvariant())
                        {
                            case "chip":
                            case "cvdh":
                            case "canco":
                                idGastoEstudioTitulo = 131;
                                idGastoBorrador = 132;
                                break;
                            case "rech":
                            case "rcdh":
                            case "fgrls":
                                idGastoEstudioTitulo = 136;
                                idGastoBorrador = 137;
                                break;
                        }

                        idTramiteIngresoCbr = 134;
                        idGastoNotaria = 133;
                        idGastoCbr = 135;
                        idGestoria = 174;///cambiar

                        //LLENAR VALORES EN BD
                        if (estudioTitulo != 0)
                        {
                            AgregarGastos(idSolicitud, idGastoEstudioTitulo, estudioTitulo);
                        }
                        if (borradorEscritura != 0)
                        {
                            AgregarGastos(idSolicitud, idGastoBorrador, borradorEscritura);
                        }
                        if (ingresoCbr != 0)
                        {
                            AgregarGastos(idSolicitud, idTramiteIngresoCbr, ingresoCbr);
                        }
                        if (gestoria != 0)
                        {
                            AgregarGastos(idSolicitud, idGestoria, gestoria);
                        }
                    }
                    else if (cliente == ClienteHipotecario.SCOTIABANK && codigoTipoOperacion.Trim() != "GTDOC")
                    {
                        tarifaServicio = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["tarifa_servicio"]);

                        if (tarifaServicio != 0)
                        {
                            switch (codigoTipoOperacion.Trim().ToLowerInvariant())
                            {
                                case "conh":
                                    break;
                                    AgregarGastos(idSolicitud, 1178, tarifaServicio, "FALSE");//CONSUMER
                                case "refin":
                                    AgregarGastos(idSolicitud, 1177, tarifaServicio, "FALSE");//REF INTERNO
                                    break;
                                case "renh":
                                    AgregarGastos(idSolicitud, 1176, tarifaServicio, "FALSE");//RENEGOCIACIONES
                                    break;
                            }
                        }

                    }

                    idGastoNotaria = gastoTransversalesFacturables ? 175 : 133;
                    idGastoCbr = gastoTransversalesFacturables ? 165 : 147;
                    idGastoGp = gastoTransversalesFacturables ? 159 : 141;
                    idGastoDominio = gastoTransversalesFacturables ? 160 : 142;
                    idGastoCertAlz = gastoTransversalesFacturables ? 161 : 143;
                    idGastoVarios = gastoTransversalesFacturables ? 172 : 154;
                    idGastoCopiaPlano = gastoTransversalesFacturables ? 163 : 145;
                    idGastoInscComercio = gastoTransversalesFacturables ? 164 : 146;
                    idGastoCertNum = gastoTransversalesFacturables ? 166 : 148;
                    idGastoRecepFinal = gastoTransversalesFacturables ? 167 : 149;
                    idGastoAvaluoDetallado = gastoTransversalesFacturables ? 168 : 150;
                    idGastoCertNoExprop = gastoTransversalesFacturables ? 169 : 151;
                    idGastoArchivoJudicial = gastoTransversalesFacturables ? 170 : 152;
                    idGastoCertDeslindes = gastoTransversalesFacturables ? 171 : 153;
                    idGastoEnvio = gastoTransversalesFacturables ? 162 : 144;
                    idGastoViviendaSocial = gastoTransversalesFacturables ? 173 : 155;


                    notaria = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["notaria"]);
                    cbr = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["cbr"]);
                    Gp = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["gp"]);
                    Dominio = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["dominio"]);
                    CertAlz = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["cert_alzam"]);
                    Varios = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["varios"]);
                    CopiaPlano = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["copia_plano"]);
                    InscComercio = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["insc_comercio"]);
                    CertNum = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["cert_numero"]);
                    RecepFinal = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["recep_final"]);
                    AvaluoDetallado = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["avaluo_detallado"]);
                    CertNoExprop = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["cert_no_exprop"]);
                    ArchivoJudicial = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["archivo_judicial"]);
                    CertDeslindes = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["cert_deslinde"]);
                    Envio = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["envio"]);
                    Social = Convert.ToInt32(grCambioEstado.DataKeys[i].Values["vivienda_social"]);

                    int sumaGatos = cliente == ClienteHipotecario.SCOTIABANK ? 1 : 0;

                    if (notaria != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoNotaria, notaria, "true", sumaGatos);
                    }
                    if (cbr != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCbr, cbr, "true", sumaGatos);
                    }
                    if (Gp != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoGp, Gp, "true", sumaGatos);
                    }
                    if (Dominio != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoDominio, Dominio, "true", sumaGatos);
                    }
                    if (CertAlz != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertAlz, CertAlz, "true", sumaGatos);
                    }
                    if (Varios != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoVarios, Varios, "true", sumaGatos);
                    }
                    if (CopiaPlano != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCopiaPlano, CopiaPlano, "true", sumaGatos);
                    }
                    if (InscComercio != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoInscComercio, InscComercio, "true", sumaGatos);
                    }
                    if (CertNum != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertNum, CertNum, "true", sumaGatos);
                    }
                    if (RecepFinal != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoRecepFinal, RecepFinal, "true", sumaGatos);
                    }
                    if (AvaluoDetallado != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoAvaluoDetallado, AvaluoDetallado, "true", sumaGatos);
                    }
                    if (CertNoExprop != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertNoExprop, CertNoExprop, "true", sumaGatos);
                    }
                    if (ArchivoJudicial != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoArchivoJudicial, ArchivoJudicial, "true", sumaGatos);
                    }
                    if (CertDeslindes != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoCertDeslindes, CertDeslindes, "true", sumaGatos);
                    }
                    if (Envio != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoEnvio, Envio, "true", sumaGatos);
                    }
                    if (Social != 0)
                    {
                        AgregarGastos(idSolicitud, idGastoViviendaSocial, Social, "true", sumaGatos);
                    }

                    #endregion Gastos




                }

            }
        }


        protected bool ValidarNomina(int idSolicitud, Int16 idTipoNomina, int idCliente)
        {
            var mtipo = new TipoNominaBC().getTiponominaBytipo(idTipoNomina);
            var gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(idSolicitud, mtipo.Id_tipogasto);

            if (mtipo.Id_tipogasto != 0)
            {
                if (gasto.Valor == 0)
                {
                    return false;
                }
            }

            if (mtipo.Permite_factura)
            {
                var respuesta = new TipoNominaBC().respuesta_nomina(idSolicitud, idTipoNomina, 22, idCliente);
                return respuesta;
            }
            else
            {
                var respuesta = new TipoNominaBC().respuesta_nomina(idSolicitud, idTipoNomina, 22, idCliente);
                return respuesta;
            }
        }

        protected void GenerarNomina(int idTipoNomina, int idSolicitud, TipoNomina lTiponomina)
        {

            new TipoNominaBC().add_tiponominaByOperacion(idSolicitud, idTipoNomina, lTiponomina.Folio, Session["usrname"].ToString());

            if (lTiponomina.Codigo_estado != 0)
            {
                new EstadooperacionBC().add_Estadooperacion(idSolicitud, lTiponomina.Codigo_estado, "", Session["usrname"].ToString());
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblMessage.Text = "Esperando carga y validación de Archivo Macro de Excel .xlsm";
        }

        private void Limpiar()
        {
            grCambioEstado.DataSource = null;
            grCambioEstado.DataBind();

            grDato.DataSource = null;
            grDato.DataBind();

            hdnidTipoNomina.Value = "0";
            ViewState["dtCambioEstado"] = null;
            ViewState["dtIngreso"] = null;

            divPaso2Grilla.Visible = false;
            divPaso3.Visible = false;
        }

        protected void tab_datos_ActiveTabChanged(object sender, EventArgs e)
        {
            //llama a javascript para cabecera de grilla estatica
            ScriptManager.RegisterStartupScript(upPrincipal, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        private void AddComentarioOperacion(int idSolicitud, string comentario)
        {
            EstadoOperacion estado = new EstadooperacionBC().getUltimoEstadoByIdoperacion(idSolicitud);
            new HitoBC().add_hito(estado.Id_estado, comentario, DateTime.Now.ToShortDateString(), 1);
        }

    }
}