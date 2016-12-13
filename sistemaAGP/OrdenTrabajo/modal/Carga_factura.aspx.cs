using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using System.Globalization;
using System.Data;

namespace sistemaAGP.OrdenTrabajo.modal
{
    public partial class Carga_factura : System.Web.UI.Page
    {

        #region VARIABLES GLOBALES DE LA CLASE Y ENUMS

        public enum Cliente
        {
            Gildemeister = 4,
            Porche = 89,
            Bech = 15,
            KiaChile = 71,
            SergioEscobar = 37
        }

        //VARIABLES AUXILIARES
        public string Factura = "0";
        public bool Transferencia;
        public bool Comprapara;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string usuario = Convert.ToString(Session["usrname"]).Trim();

            FuncionGlobal.ComboFormaPago(dlTipoPago, "FOPA");
            FuncionGlobal.ComboGruposUsuarios(dlGrupo, usuario);
            FuncionGlobal.comboclientesbyusuario(usuario, dlCliente);
     
            //Si tengo mas de 1 grupo le dejo la opcion por defecto para seleccionar, si tengo 1 grupo ese queda como defecto

            if (dlGrupo.Items.Count < 3)
            {
                dlGrupo.Items.Remove(dlGrupo.Items.FindByValue("0"));
            }
        }

        protected void btn_subir_Click(object sender, EventArgs e)
        {
            //PRUEBAS
            //LeerPdf(@"E:\prueba\33-61242.pdf");

            gr_filas.DataSource = SubirDoc();
            gr_filas.DataBind();
        }

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbyclienteShort(dlSucursal, Convert.ToInt16(dlCliente.SelectedValue));
        }

        #region FUNCIONALIDADES DE LA PAGINA

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!Page.IsClientScriptBlockRegistered("bc_header_script"))
                Page.RegisterClientScriptBlock("bc_header_script", "<script type=\"text/javascript\" src=\"scripts/utils.js\"></script>");

            string init_script = string.Format("<script type=\"text/javascript\">bc_load('{0}', '{1}');</script>",
                    inputField.ClientID, list_files.ClientID);
            Page.RegisterClientScriptBlock("bc_loader", init_script);
            base.OnPreRender(e);
        }

        #endregion

        #region CARGA DE DOCUMENTOS

        public DataTable SubirDoc()
        {
            if (Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Gildemeister 
                && Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Porche
                && Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.KiaChile
                && Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.SergioEscobar)
            {
                FuncionGlobal.alerta_updatepanel("CLIENTE NO TIENE INGRESO PRETICKET HABILITADO", Page, udp);
                return null;
            }

            if (dlTipoPago.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Seleccione tipo de forma de pago.", Page, udp);
                return null;
            }
            if (dlSucursal.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Seleccione una Sucursal del cliente.", Page, udp);
                return null;
            }

            if (Convert.ToInt32(dlGrupo.SelectedValue) < 1)
            {
                FuncionGlobal.alerta_updatepanel("Seleccione un grupo.", Page, udp);
                return null;
            }
            

            var respuesta = new RespuestaAgp();
            HttpFileCollection files = HttpContext.Current.Request.Files;
            
            List<Operacion> ope = new List<Operacion>();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("Estado"));
            dt.Columns.Add(new DataColumn("observaciones"));

            for (int i = 0; i < files.Count; i++)
            {

                HttpPostedFile file = files[i];
                if (file.ContentLength == 0) //continue;
                {
                    FuncionGlobal.alerta_updatepanel("Seleccione archivo(s) para subir.", Page, udp);
                    return null;
                }

                var dr = dt.NewRow();

                string nombreDoc = file.FileName.ToLower();
                nombreDoc = nombreDoc.Replace(".pdf", string.Empty);
                dr["nombre"] = nombreDoc;

                //divido la fecha en año mes dia.
                string x = DateTime.Now.ToString("yyyyMMddHHmmss");
                string anio = x.Substring(0, 4);
                string mes = x.Substring(4, 2);
                string dia = x.Substring(6, 2);

                //obtengo todos los nombres de los meses del año en español.
                String[] Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

                //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
                string numero_mes = CambiarMes(mes);
                string CarpetaMes = numero_mes + "." + Meses[Convert.ToInt32(mes) - 1].ToString();
                string nuevo_dia = CambiarDia(dia);

                //armo los strings con las rutas dependiendo de la consulta.
                string destino = string.Empty;
                destino = "/" + anio + "/" + CarpetaMes + "/" + nuevo_dia;

                string sPath = String.Format("{0}/{1}/{2}", "docs", nombreDoc, "1");//1=FACTURA
                if (!Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", "1");//1=FACTURA
                if (!Directory.Exists(@sPath)) sPath = "docs";

                FileInfo fi_documento = new FileInfo(file.FileName);

                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".png" || fi_documento.Extension.ToLower() == ".jpg" ||
                            fi_documento.Extension.ToLower() == ".gif" || fi_documento.Extension.ToLower() == ".pdf" ||
                            fi_documento.Extension.ToLower() == ".doc" || fi_documento.Extension.ToLower() == ".docx" ||
                            fi_documento.Extension.ToLower() == ".xls" || fi_documento.Extension.ToLower() == ".xlsx" ||
                            fi_documento.Extension.ToLower() == ".tiff")
                    {
                        if (file.ContentLength <= 10485760)
                        {
                            string sDoc = nombreDoc.ToString() + "_" + 1 + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                            //string sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;   
                            string sSave = @"F:/Docs" + destino + "\\" + sDoc;
                            try
                            {
                                //SUBE EL DOCUMENTO EN SERVIDOR
                                file.SaveAs(sSave);

                                //LEE EL DOCUMENTO
                               // respuesta = LeerPdf(@"C:\Lector Factura\AG\"+ file.FileName);
                                respuesta = LeerPdf(sSave);
                                dr["id"] = respuesta.IdRespuesta;

                                if (respuesta.IdRespuesta > 0)
                                {
                                    //GRABA EN LA BASE DE DATOS
                                    sSave = sPath + destino + "/" + sDoc;
                                    new ChecklistOrdenTrabajoBC().AddChecklistOrdenTrabajo(new ChecklistOrdenTrabajo
                                    {
                                        IdChecklist = 1,
                                        CuentaUsuario = Convert.ToString(Session["usrname"]),
                                        Url = sSave,
                                        Observacion = "Carga masiva: Pantalla de cargas",
                                        IdOrdenTrabajo = respuesta.IdRespuesta
                                    });
                                    dr["estado"] = "OK";
                                    dr["observaciones"] = "Nuevo preticket";
                                }
                                else
                                {
                                    dr["estado"] = "ERROR";
                                    dr["observaciones"] = respuesta.MensajeError;
                                }

                            }
                            catch (Exception ex)
                            {
                                dr["id"] = -999;                                
                                dr["observaciones"] = "ERROR DE LECTURA DE FACTURA:" + ex.Message; 
                                                              
                            }
                        }
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public string Carpetadestino(int consulta)
        {
            //divido la fecha en año mes dia.
            var x = DateTime.Now.ToString("yyyyMMddHHmmss");
            var anio = x.Substring(0, 4);
            var mes = x.Substring(4, 2);
            var dia = x.Substring(6, 2);

            //obtengo todos los nombres de los meses del año en español.
            String[] meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
            var numeroMes = CambiarMes(mes);
            var carpetaMes = numeroMes + "." + meses[Convert.ToInt32(mes) - 1];
            var nuevoDia = CambiarDia(dia);

            //armo los strings con las rutas dependiendo de la consulta.
            string destino = "";
            if (consulta == 1)
            {
                destino = anio + "/" + carpetaMes + "/" + nuevoDia;
            }
            else if (consulta == 2)
            {
                destino = "docs/" + anio + "/" + carpetaMes + "/" + nuevoDia + "/";
            }
            return destino;
        }

        public string CambiarMes(string mes)
        {
            var nuevomes = mes;
            if (Convert.ToInt32(mes) < 10)
            {
                nuevomes = nuevomes.Substring(1, nuevomes.Length - 1);
                return nuevomes;
            }
            return nuevomes;
        }

        public string CambiarDia(string dia)
        {
            string nuevodia = dia;
            if (Convert.ToInt32(dia) < 10)
            {
                nuevodia = nuevodia.Substring(1, nuevodia.Length - 1);
                return nuevodia;
            }
            return nuevodia;
        }

        #endregion

        #region LECTURA PDF 
        public RespuestaAgp LeerPdf(string rutaBusqueda)
        {
            var respuesta = new RespuestaAgp();
            var reader2 = new PdfReader(rutaBusqueda);
            var strText = string.Empty;
            for (var page = 1; page <= 1; page++)      //ojo solo lee la primera pagina
            {
                var its = new SimpleTextExtractionStrategy();
                var reader = new PdfReader(rutaBusqueda);
                var s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                s = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8,
                                                             Encoding.Default.GetBytes(s)));
                strText = strText + s;
                reader.Close();

            }
            reader2.Close();

            var idCliente = Convert.ToInt32(Convert.ToInt32(dlCliente.SelectedValue));
            switch (idCliente)
            {
                case (int)Cliente.Gildemeister:
                    respuesta = Gildemeister(strText);
                    break;
                case (int)Cliente.Porche:
                    respuesta = Porche(strText);
                    break;

                case (int)Cliente.Bech:
                    respuesta = Bech(strText);
                    break;

                case (int)Cliente.KiaChile:
                    respuesta = Indumotora(strText);
                    break;

                case (int)Cliente.SergioEscobar:
                    respuesta = SergioEscobar(strText);
                    break;
            }
            return respuesta;
        }

        #endregion

        #region METODOS LECTURA PDF POR CLIENTE

        #region -GILDEMEISTER

        public RespuestaAgp Gildemeister(string texto)
        {
            //variables especificas
            bool encontradoGiro = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoMotor = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando 
            bool encontradoFormaPago = false;  //se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoPuertas = false;  //se inicia en falso; si encuentro el puertas pasa a verdadero y no sigue buscando
            bool encontradoAsientos = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoPesoBruto = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando

            var datosFacturas = new DatoFactura {IdCliente = Convert.ToInt32(dlCliente.SelectedValue)};

            char[] delimiterChars = { '\n' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var contadorPalabras = 0;

            foreach (string s in words)
            {
                contadorPalabras++;
                var algo = s;
                switch (contadorPalabras)
                {
                    case 13:
                        datosFacturas.Nombre = s.Trim();
                        break;
                    case 15:
                        datosFacturas.Direccion = s.Trim();
                        break;
                    case 17:
                        var listaCiudadComuna = s.Split(new string[] { "CIUDAD" }, StringSplitOptions.None);
                        var contCiudad = 1;
                        foreach (var s1 in listaCiudadComuna)
                        {
                            switch (contCiudad)
                            {
                                case 1:
                                    datosFacturas.Comuna = s1.Trim();
                                    break;
                                case 2:
                                    datosFacturas.Ciudad = s1.Trim();
                                    break;
                            }
                            contCiudad++;
                        }
                        break;
                    case 19:
                        datosFacturas.FechaFactura = s.Trim();
                        break;
                    case 27:
                        datosFacturas.NumeroFactura = s.Replace("Nº", "").Trim();
                        Factura = datosFacturas.NumeroFactura;//valor factura para cambiar nombre del archivo en la carpeta de destino
                        break;
                    case 39:
                        var rutCompleto = s.Substring(0, 12);
                        string rut;
                        string dv;
                        if (rutCompleto.Trim().ToUpper().Contains("K"))
                        {
                            rut = FuncionGlobal.ConvierteTextoANumero(rutCompleto).ToString();                           
                            dv = "K";
                        }
                        else
                        {
                            var nuevo = FuncionGlobal.ConvierteTextoANumero(s.Substring(0, 12)).ToString(CultureInfo.InvariantCulture);
                            rut = (nuevo.Substring(0, nuevo.Length - 1));
                            dv = (nuevo.Substring(nuevo.Length - 1, 1));
                        }
                        datosFacturas.Rut = rut;
                        datosFacturas.Dv = dv;
                        break;
                    case 41:
                        if (s.Trim() != string.Empty)
                        {
                            datosFacturas.Giro = s.Trim();
                            encontradoGiro = true;
                        }
                        else
                        {
                            encontradoGiro = false;

                        }
                        break;
                    case 42:
                        if (!encontradoGiro)//si hubo un salto de linea nuevo el giro aparece en la posicion 42
                        {
                            datosFacturas.Giro = s.Trim();
                            encontradoGiro = true;
                            contadorPalabras -= 1;
                        }
                        break;
                    case 47:
                        datosFacturas.SucursalDestino = s.Trim();
                        break;
                    case 49:
                        if (s.Trim() != string.Empty)
                        {
                            datosFacturas.FormaPago = s.Trim();
                            encontradoFormaPago = true;
                        }
                        else
                        {
                            encontradoFormaPago = false;
                        }
                        break;
                    case 50:
                        if (!encontradoFormaPago)//si hubo un salto de linea nuevo el giro aparece en la posicion 42
                        {
                            datosFacturas.FormaPago = s.Trim();
                            encontradoFormaPago = true;
                            contadorPalabras -= 1;
                        }
                        break;
                    case 54:
                        datosFacturas.NotaPedido = FuncionGlobal.ConvierteTextoANumero(s).ToString(CultureInfo.InvariantCulture);
                        break;

                }
                //Para conocer valor neto de la factura
                if (!s.Contains("Monto Neto")) continue;
                var monto = s.Replace("Monto Neto", string.Empty).Trim();
                datosFacturas.ValorNeto = monto.Replace(".", string.Empty).Trim();
            }

            //Lee el detalle de la factura  
            string[] wordsDetalle = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in wordsDetalle)
            {
                var palabra = s.Trim().ToUpper();
                var palabraSinEspacio = palabra.Replace(" ", string.Empty);
                if (palabraSinEspacio.Contains("TIPODEVEHICULO:")|| palabraSinEspacio.Contains("TIPOVEHÍCULO:"))
                {
                    datosFacturas.TipoVehiculo = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("MARCA:"))
                {
                    var marca = SplitPalabras(s);
                    datosFacturas.MarcaVehiculo = new OrdenTrabajoBC().GetCodigoSga(marca.Trim(), "MARCA");
                }
                else if (palabraSinEspacio.Contains("AÑOCOMERCIAL:")|| palabraSinEspacio.Contains("AÑO:"))
                {
                    datosFacturas.AnioComercial = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("MODELO:"))
                {
                    datosFacturas.Modelo = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("CIT:"))
                {
                    datosFacturas.Cit = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("COLOR:"))
                {
                    datosFacturas.Color = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("PUERTAS:") && !encontradoPuertas)
                {
                    datosFacturas.Puertas = SplitPalabras(s);
                    encontradoPuertas = true;
                }
                else if ((palabraSinEspacio.Contains("ASIENTOS:")|| palabraSinEspacio.Contains("ASIENTO:")) && !encontradoAsientos)
                {
                    datosFacturas.Asiento = SplitPalabras(s);
                    encontradoAsientos = true;
                }
                else if (palabraSinEspacio.Contains("N°CHASSIS") || palabraSinEspacio.Contains("NROCHASSIS(VIN)") || palabraSinEspacio.Contains("NRO.CHASIS"))
                {
                    datosFacturas.Chassis = SplitPalabras(s);
                }
                else if ((palabraSinEspacio.Contains("MOTOR:")|| palabraSinEspacio.Contains("NRO.MOTOR:")) && !encontradoMotor)
                {
                    datosFacturas.Motor = SplitPalabras(s);
                    encontradoMotor = true;
                }
                else if (palabraSinEspacio.Contains("TIPODECOMBUSTIBL")|| palabraSinEspacio.Contains("TIPOCOMBUSTIBLE:") || palabraSinEspacio.Contains("COMBUSTIBLE:"))
                {
                    var dato = SplitPalabras(s).ToLower(); 
                    if (dato.Contains("bencina")||dato.Contains("gasolina"))
                    {
                        dato = "Gasolina";
                    }
                    else if (dato.Contains("diesel"))
                    {
                        dato = "Diesel";
                    }
                    else if (dato.Trim() == string.Empty)
                    {
                        dato = "No encontrado";
                    }
                    datosFacturas.Combustible = new OrdenTrabajoBC().GetCodigoSga(dato, "COMBUSTIBLE");
                }
                else if ((palabraSinEspacio.Contains("PESOBRUTO") || palabraSinEspacio.Contains("PESOBRUTOVEHICULAR") || palabraSinEspacio.Contains("PBV")) && !encontradoPesoBruto)
                {
                    //el PESO BRUTO puede venir distinto en algunas facturas por eso separamos desde los dos puntos
                    encontradoPesoBruto = true;
                    var peso = SplitPalabras(s).ToLower();
                    datosFacturas.PesoBruto = FuncionGlobal.ConvierteTextoANumero(peso).ToString(CultureInfo.InvariantCulture);
                }

            }

            //Para conocer si es inscripcion o transferencia
            Transferencia = texto.ToUpper().Contains("PATENTE");
            datosFacturas.Transferencia = Transferencia;
            if (Transferencia)
            {

                if (texto.ToUpper().Contains("PATENTE UNICA"))
                {
                    var textoPatente =
                        texto.ToUpper()
                            .Substring(texto.ToUpper().IndexOf("PATENTE UNICA", StringComparison.Ordinal),
                                texto.Length -
                                texto.ToUpper().IndexOf("PATENTE UNICA", StringComparison.Ordinal) - 1);

                    var textoRepertorio = textoPatente.ToUpper().Contains("REPERTORIO") ? "REPERTORIO" : "REPETORIO";
                    var patente = textoPatente.ToUpper()
                        .Substring(0, textoPatente.ToUpper().IndexOf(textoRepertorio, StringComparison.Ordinal));
                    patente = patente.Replace(",", string.Empty);
                    datosFacturas.Patente = patente.Replace("PATENTE UNICA", string.Empty).Trim();

                }
                else
                {
                    var textoPatente =
                        texto.ToUpper()
                            .Substring(texto.ToUpper().IndexOf("PATENTE", StringComparison.Ordinal),
                                texto.Length -
                                texto.ToUpper().IndexOf("PATENTE", StringComparison.Ordinal) - 1);

                    var textoRepertorio = "N° SOLICITUD";
                    var patente = textoPatente.ToUpper()
                        .Substring(0, textoPatente.ToUpper().IndexOf(textoRepertorio, StringComparison.Ordinal));
                    patente = patente.Replace(",", string.Empty);
                    patente = patente.Replace(".", string.Empty);
                    patente = patente.Replace("PATENTE", string.Empty).Trim();
                    datosFacturas.Patente = patente.Substring(0, 6);
                }
            }

            //para conocer si tiene compra para
            Comprapara = texto.ToUpper().Contains("COMPRA PARA");
            datosFacturas.TieneCompraPara = Comprapara;

            if (Comprapara)
            {
                string hasta = "RUT";
                var textonuevo = texto.Substring(texto.ToUpper().IndexOf("COMPRA PARA", StringComparison.Ordinal), texto.Length - texto.ToUpper().IndexOf("COMPRA PARA", StringComparison.Ordinal) - 1).ToUpper();
                //separamos el numbre del resto del texto
                if (textonuevo.Contains("R.U.T."))
                {
                    hasta = "R.U.T.";
                }
                else if (textonuevo.Contains("RUT"))
                {
                    hasta = "RUT";
                }
                else
                {
                    hasta = ",";
                }
                //hasta = textonuevo.Contains("RUT") ? "RUT" : ",";
                var nombreCompraPara = textonuevo.Substring(0, textonuevo.IndexOf(hasta, StringComparison.Ordinal) - 1);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace(":", string.Empty);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace(";", string.Empty);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace("COMPRA PARA", String.Empty);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace(",", string.Empty);

                //separamos el rut del resto del texto
                var nuevoTextoRut = textonuevo.Substring(textonuevo.IndexOf(hasta, StringComparison.Ordinal),
                                                    textonuevo.Length -
                                                    textonuevo.IndexOf(hasta, StringComparison.Ordinal) - 1);
                var rutTexto = nuevoTextoRut.Substring(0, 19);
                var rut = FuncionGlobal.ConvierteTextoANumero(rutTexto);
                var rutNumerico = Convert.ToInt32(Convert.ToString(rut).Substring(0, Convert.ToString(rut).Length - 1));
                var dv = Convert.ToString(rut).Substring(Convert.ToString(rut).Length - 1, 1);


                datosFacturas.CompraParaDescripcion = nombreCompraPara + " " + rutTexto;
                datosFacturas.CompraParaNombre = nombreCompraPara;
                datosFacturas.CompraParaRut = rutNumerico;
                datosFacturas.CompraParaDv = dv;

            }
            datosFacturas.FormaPago = Convert.ToString(dlTipoPago.SelectedValue);
            datosFacturas.CuentaUsuario = Convert.ToString(Session["usrname"]);
            datosFacturas.Grupo = dlGrupo.SelectedValue.Trim();
            datosFacturas.idSucursal = Convert.ToInt32(dlSucursal.SelectedValue);
            return Add(datosFacturas);
        }

        #endregion

        #region -PORCHE
        public RespuestaAgp Porche(string texto)
        {
            //variables especificas
            bool encontradoGiro = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoMotor = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando 
            bool encontradoFormaPago = false;  //se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoPuertas = false;  //se inicia en falso; si encuentro el puertas pasa a verdadero y no sigue buscando
            bool encontradoAsientos = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoPesoBruto = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool capturarValorNeto = false; //HACK!   si es true al siguiente recorrido obtengo el valor neto de la factura
            var datosFacturas = new CENTIDAD.DatoFactura();
            datosFacturas.IdCliente = Convert.ToInt32(dlCliente.SelectedValue);
            var consultarTipoFactura = true;


            //Para el encabezado de la factura
            //var numeroFactura = Funciones.CortadorTexto(texto, "FACTURA ELECTRÓNICA", @"S.I.I. - SANTIAGO");
            //datosFacturas.NumeroFactura = Funciones.ConvierteTextoANumero(numeroFactura).ToString(CultureInfo.InvariantCulture);
            //Factura = datosFacturas.NumeroFactura;


            char[] delimiterChars = { '\n' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var contadorPalabras = 0;
            //if (words[23].Trim() != "Forma de Pago")
            //    //SI NO TIENE LA FRASE FORMA DE PAGO EN CABECERA SE CORRE UNA POSICION EL PUNTERO CONTADORPALABRAS
            //{
            //    contadorPalabras = -1;
            //    pedirFormaPago = false;

            //}


            foreach (string s in words)
            {
                switch (contadorPalabras)
                {
                    case 1:
                        datosFacturas.FechaFactura = s.Trim();
                        break;
                    case 7:
                        if (s.Contains("PORSCHE INTER AUTO CHILE SpA") && consultarTipoFactura)
                        {
                            contadorPalabras -= 1;
                            consultarTipoFactura = false;
                        }
                        break;
                    case 6:
                        datosFacturas.NumeroFactura = s.Replace("Nº:", string.Empty).Trim();
                        Factura = datosFacturas.NumeroFactura;//valor factura para cambiar nombre del archivo en la carpeta de destino
                        break;
                    case 9:
                        datosFacturas.NotaPedido = FuncionGlobal.ConvierteTextoANumero(s).ToString(CultureInfo.InvariantCulture);
                        break;
                    case 25:
                        datosFacturas.Direccion = s.Trim();
                        break;
                    case 26:
                        datosFacturas.Ciudad = s.Trim();
                        break;
                    case 28:
                        datosFacturas.Comuna = s.Trim();
                        break;
                    case 34:
                        datosFacturas.Nombre = s.Trim();
                        break;
                    case 35:
                        datosFacturas.FormaPago = s.Trim();
                        break;
                    case 36:
                        datosFacturas.Giro = s.Trim();
                        break;
                    case 39:
                        var rutCompleto = s.Substring(0, 12);
                        string rut;
                        string dv;
                        if (rutCompleto.Trim().ToUpper().Contains("K"))
                        {
                            rut = FuncionGlobal.ConvierteTextoANumero(rutCompleto).ToString();
                            dv = "K";
                        }
                        else
                        {
                            var nuevo = FuncionGlobal.ConvierteTextoANumero(s.Substring(0, 12)).ToString(CultureInfo.InvariantCulture);
                            rut = (nuevo.Substring(0, nuevo.Length - 1));
                            dv = (nuevo.Substring(nuevo.Length - 1, 1));
                        }
                        datosFacturas.Rut = rut;
                        datosFacturas.Dv = dv;
                        break;

                    case 47:
                        datosFacturas.SucursalDestino = "N/A";
                        break;


                }

                contadorPalabras++;
            }

            //Lee el detalle de la factura  
            string[] wordsDetalle = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in wordsDetalle)
            {
                var palabra = s.Trim().ToUpper();
                var palabraSinEspacio = palabra.Replace(" ", string.Empty);
                if (palabraSinEspacio.Contains("TIPODEVEHICULO:"))
                {
                    datosFacturas.TipoVehiculo = (FuncionGlobal.DevuelveSoloLetras(SplitPalabras(s))).Trim();
                }
                else if (palabraSinEspacio.Contains("MARCA:"))
                {
                    datosFacturas.MarcaVehiculo = (SplitPalabras(s)).Trim();//TODO: HACER PARIDAD CON MARCAR DE AGP
                }
                else if (palabraSinEspacio.Contains("AÑO:"))
                {
                    datosFacturas.AnioComercial = (SplitPalabras(s)).Trim();
                }
                else if (palabraSinEspacio.Contains("CILINDRADA:"))
                {
                    datosFacturas.Cilindrada = FuncionGlobal.ConvierteTextoANumero((SplitPalabras(s)).Trim()).ToString();
                }
                else if (palabraSinEspacio.Contains("MODELO:"))
                {
                    datosFacturas.Modelo = (SplitPalabras(s)).Trim();
                }
                else if (palabraSinEspacio.Contains("CIT:"))
                {
                    datosFacturas.Cit = (SplitPalabras(s)).Trim();
                }
                else if (palabraSinEspacio.Contains("COLOR:"))
                {
                    datosFacturas.Color = (SplitPalabras(s)).Trim();
                }
                else if (palabraSinEspacio.Contains("CHASIS"))
                {
                    datosFacturas.Chassis = (SplitPalabras(s)).Trim();
                }
                else if (palabraSinEspacio.Contains("MOTOR:") && !encontradoMotor)
                {
                    datosFacturas.Motor = (SplitPalabras(s)).Trim();
                    encontradoMotor = true;
                }
                else if (capturarValorNeto)
                {
                    datosFacturas.ValorNeto = FuncionGlobal.ConvierteTextoANumero(s).ToString(CultureInfo.InvariantCulture);
                    capturarValorNeto = false;
                }
                else if (palabraSinEspacio == "TOTAL:")
                {
                    capturarValorNeto = true;
                }

                else if (palabraSinEspacio.Contains("COMBUSTIBLE:"))
                {
                    var dato = (SplitPalabras(s)).Trim().ToLower();
                    if (dato.Contains("bencina") || dato.Contains("gasolina"))
                    {
                        dato = "Gasolina";
                    }
                    else if (dato.Contains("diesel"))
                    {
                        dato = "Diesel";
                    }
                    else if (dato.Trim() == string.Empty)
                    {
                        dato = "No encontrado";
                    }
                    //TODO: HOMOLOGAR CON AGP
                    datosFacturas.Combustible = new OrdenTrabajoBC().GetCodigoSga(dato, "COMBUSTIBLE");
                }
                else if ((palabraSinEspacio.Contains("PESOBRUTO") || palabraSinEspacio.Contains("PESOBRUTOVEHICULAR:") || palabraSinEspacio.Contains("PBV")) && !encontradoPesoBruto)
                {
                    //el PESO BRUTO puede venir distinto en algunas facturas por eso separamos desde los dos puntos
                    encontradoPesoBruto = true;
                    var peso = SplitPalabras(s).ToLower();
                    datosFacturas.PesoBruto = FuncionGlobal.ConvierteTextoANumero(peso).ToString(CultureInfo.InvariantCulture);
                }
                else if (palabraSinEspacio.Contains("PATENTE"))
                {
                    //Para conocer si es inscripcion o transferencia
                    datosFacturas.Patente = (SplitPalabras(s)).Trim();
                    datosFacturas.Transferencia = true;
                }
                else if (palabraSinEspacio.Contains("COMPRAPARA"))
                {
                    //Para conocer si es inscripcion o transferencia
                    datosFacturas.CompraParaNombre = (SplitPalabras(s)).Trim();
                    datosFacturas.TieneCompraPara = true;

                }
                else if (palabraSinEspacio.Contains("RUT") && datosFacturas.TieneCompraPara)
                {
                    var rut = FuncionGlobal.ConvierteTextoANumero(s);
                    var rutNumerico = Convert.ToInt32(Convert.ToString(rut).Substring(0, Convert.ToString(rut).Length - 1));
                    var dv = Convert.ToString(rut).Substring(Convert.ToString(rut).Length - 1, 1);
                    datosFacturas.CompraParaRut = rutNumerico;
                    datosFacturas.CompraParaDv = dv;
                }

            }


            datosFacturas.FormaPago = Convert.ToString(dlTipoPago.SelectedValue);
            datosFacturas.CuentaUsuario = Convert.ToString(Session["usrname"]);
            datosFacturas.Grupo = dlGrupo.SelectedValue.Trim();
            datosFacturas.idSucursal = Convert.ToInt32(dlSucursal.SelectedValue);
            return Add(datosFacturas);

        }


        #endregion

        #region -BECH

        public RespuestaAgp Bech(string texto)
        {
            //variables especificas
            bool encontradoGiro = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoMotor = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando 
            bool encontradoFormaPago = false;  //se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoPuertas = false;  //se inicia en falso; si encuentro el puertas pasa a verdadero y no sigue buscando
            bool encontradoAsientos = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoPesoBruto = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool capturarValorNeto = false; //HACK!   si es true al siguiente recorrido obtengo el valor neto de la factura
            var datosFacturas = new CENTIDAD.DatoFactura();
            datosFacturas.IdCliente = Convert.ToInt32(dlCliente.SelectedValue);
            var consultarTipoFactura = true;

            char[] delimiterChars = { '\n' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var contadorPalabras = 0;

            foreach (string s in words)
            {
                switch (contadorPalabras)
                {
                    case 2:
                        datosFacturas.Giro = s.Replace("Giro:", string.Empty).Trim();
                        break;
                    case 3:
                        datosFacturas.Nombre = s.Replace("Nombre:", string.Empty).Trim();//s.Trim();
                        break;
                    case 4:
                        datosFacturas.FechaFactura = s.Trim();
                        break;
                    case 5:
                        var rutCompleto = s.Substring(0, 12);
                        string rut;
                        string dv;
                        if (rutCompleto.Trim().ToUpper().Contains("K"))
                        {
                            rut = FuncionGlobal.ConvierteTextoANumero(rutCompleto).ToString();
                            dv = "K";
                        }
                        else
                        {
                            var nuevo = FuncionGlobal.ConvierteTextoANumero(s.Substring(0, 12)).ToString(CultureInfo.InvariantCulture);
                            rut = (nuevo.Substring(0, nuevo.Length - 1));
                            dv = (nuevo.Substring(nuevo.Length - 1, 1));
                        }
                        datosFacturas.Rut = rut;
                        datosFacturas.Dv = dv;
                        break;

                    case 7:
                        datosFacturas.NumeroFactura = s.Replace("Nº ", string.Empty).Trim();
                        Factura = datosFacturas.NumeroFactura;//valor factura para cambiar nombre del archivo en la carpeta de destino
                        break;

                    case 20:
                        datosFacturas.NotaPedido = s.Replace("VENTA POR OPCION BIEN OP.", string.Empty).Trim();
                        break;

                    case 22:
                        datosFacturas.TipoVehiculo = s.Trim();
                        break;

                    case 24:
                        datosFacturas.AnioComercial = s.Replace("Año : ", string.Empty).Trim();
                        break;

                    case 26:
                        datosFacturas.MarcaVehiculo = s.Replace("Marca : ", string.Empty).Trim();
                        break;
                    case 28:
                        datosFacturas.Modelo = s.Replace("Modelo : ", string.Empty).Trim();
                        break;

                    case 30:
                        datosFacturas.Motor = s.Replace("Nro. Motor : ", string.Empty).Trim();
                        break;

                    case 32:
                        datosFacturas.Chassis = s.Replace("Nro. Chasis : ", string.Empty).Trim();
                        break;

                    case 34:
                        datosFacturas.Color = s.Replace("Color : ", string.Empty).Trim();
                        break;

                    case 36:
                        datosFacturas.Combustible = "COD2";//s.Replace("Combustible :", string.Empty).Trim();
                        break;

                    case 40:
                        var remplasar = s.Replace("Inscripción : ", string.Empty).Trim();
                        var pat = remplasar.Replace("-", string.Empty).Replace(".", string.Empty);
                        datosFacturas.Patente = (pat.Substring(0, pat.Length - 1));
                        break;

                    case 62:
                        datosFacturas.ValorNeto = s.Replace(".", string.Empty).Trim();
                        break;
                }
                contadorPalabras++;
            }

            datosFacturas.FormaPago = Convert.ToString(dlTipoPago.SelectedValue);
            datosFacturas.CuentaUsuario = Convert.ToString(Session["usrname"]);
            datosFacturas.Grupo = dlGrupo.SelectedValue.Trim();
            datosFacturas.idSucursal = Convert.ToInt32(dlSucursal.SelectedValue);
            return Add(datosFacturas);

        }

        #endregion

        #region INDUMOTORA
        public RespuestaAgp Indumotora(string texto)
        {
            //variables especificas
            bool encontradoGiro = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoMotor = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando 
            bool encontradoFormaPago = false;  //se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoPuertas = false;  //se inicia en falso; si encuentro el puertas pasa a verdadero y no sigue buscando
            bool encontradoAsientos = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoPesoBruto = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando

            var datosFacturas = new DatoFactura { IdCliente = Convert.ToInt32(dlCliente.SelectedValue) };

            char[] delimiterChars = { '\n' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var contadorPalabras = -1;

            foreach (string s in words)
            {
                contadorPalabras++;
                var algo = s;
                switch (contadorPalabras)
                {
                    case 33:
                        datosFacturas.Nombre = s.Trim();
                        break;
                    case 36:
                        datosFacturas.Direccion = s.Trim();
                        break;
                    case 37:
                        datosFacturas.Comuna = s.Trim();
                        break;
                    case 38:
                        datosFacturas.Ciudad = s.Trim();
                        break;
                    case 52:
                        datosFacturas.FechaFactura = s.Trim();
                        break;
                    case 13:
                        datosFacturas.NumeroFactura = s.Replace("Nº", "").Trim();
                        Factura = datosFacturas.NumeroFactura;//valor factura para cambiar nombre del archivo en la carpeta de destino
                        break;
                    case 34:
                        var rutCompleto = s.Substring(0, 12);
                        string rut;
                        string dv;
                        if (rutCompleto.Trim().ToUpper().Contains("K"))
                        {
                            rut = FuncionGlobal.ConvierteTextoANumero(rutCompleto).ToString();
                            dv = "K";
                        }
                        else
                        {
                            var nuevo = FuncionGlobal.ConvierteTextoANumero(s.Substring(0, 12)).ToString(CultureInfo.InvariantCulture);
                            rut = (nuevo.Substring(0, nuevo.Length - 1));
                            dv = (nuevo.Substring(nuevo.Length - 1, 1));
                        }
                        datosFacturas.Rut = rut;
                        datosFacturas.Dv = dv;
                        break;
                    case 35:
                        if (s.Trim() != string.Empty)
                        {
                            datosFacturas.Giro = s.Trim();
                            encontradoGiro = true;
                        }
                        else
                        {
                            encontradoGiro = false;

                        }
                        break;
                    case 42:
                        if (!encontradoGiro)//si hubo un salto de linea nuevo el giro aparece en la posicion 42
                        {
                            datosFacturas.Giro = s.Trim();
                            encontradoGiro = true;
                            contadorPalabras -= 1;
                        }
                        break;
                    case 55:
                            datosFacturas.FormaPago = s.Trim();
                       
                        break;
                    case 54:
                        datosFacturas.NotaPedido = FuncionGlobal.ConvierteTextoANumero(s).ToString(CultureInfo.InvariantCulture);
                        break;

                }
                //Para conocer valor neto de la factura
                if (!s.Contains("Monto Neto")) continue;
                var monto = s.Replace("Monto Neto", string.Empty).Trim();
                datosFacturas.ValorNeto = monto.Replace(".", string.Empty).Trim();
            }

            //Lee el detalle de la factura  
            string[] wordsDetalle = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in wordsDetalle)
            {
                var palabra = s.Trim().ToUpper();
                var palabraSinEspacio = palabra.Replace(" ", string.Empty);
                if (palabraSinEspacio.Contains("TIPO:") || palabraSinEspacio.Contains("TIPO:"))
                {
                    datosFacturas.TipoVehiculo = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("MARCA:"))
                {
                    var marca = SplitPalabras(s);
                    datosFacturas.MarcaVehiculo = new OrdenTrabajoBC().GetCodigoSga(marca.Trim(), "MARCA");
                }
                else if (palabraSinEspacio.Contains("ANO:") || palabraSinEspacio.Contains("AÑO:"))
                {
                    datosFacturas.AnioComercial = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("MODELO:"))
                {
                    datosFacturas.Modelo = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("CODIGODEINFORMETECNICO:"))
                {
                    datosFacturas.Cit = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("COLOR:"))
                {
                    datosFacturas.Color = SplitPalabras(s);
                }
                else if (palabraSinEspacio.Contains("PUERTA:") && !encontradoPuertas)
                {
                    datosFacturas.Puertas = SplitPalabras(s);
                    encontradoPuertas = true;
                }
                else if ((palabraSinEspacio.Contains("ASIENTOS:") || palabraSinEspacio.Contains("ASIENTO:")) && !encontradoAsientos)
                {
                    datosFacturas.Asiento = SplitPalabras(s);
                    encontradoAsientos = true;
                }
                else if (palabraSinEspacio.Contains("CHASSIS") || palabraSinEspacio.Contains("NROCHASSIS(VIN)") || palabraSinEspacio.Contains("NRO.CHASIS"))
                {
                    datosFacturas.Chassis = SplitPalabras(s);
                }
                else if ((palabraSinEspacio.Contains("MOTOR:") || palabraSinEspacio.Contains("NRO.MOTOR:")) && !encontradoMotor)
                {
                    datosFacturas.Motor = SplitPalabras(s);
                    encontradoMotor = true;
                }
                else if (palabraSinEspacio.Contains("TIPODECOMBUSTIBLE") || palabraSinEspacio.Contains("TIPOCOMBUSTIBLE:") || palabraSinEspacio.Contains("COMBUSTIBLE:"))
                {
                    var dato = SplitPalabras(s).ToLower();
                    if (dato.Contains("bencina") || dato.Contains("gasolina"))
                    {
                        dato = "Gasolina";
                    }
                    else if (dato.Contains("diesel"))
                    {
                        dato = "Diesel";
                    }
                    else if (dato.Trim() == string.Empty)
                    {
                        dato = "No encontrado";
                    }
                    datosFacturas.Combustible = new OrdenTrabajoBC().GetCodigoSga(dato, "COMBUSTIBLE");
                }
                else if ((palabraSinEspacio.Contains("PESOBRUTO") || palabraSinEspacio.Contains("PESOBRUTOVEHI") || palabraSinEspacio.Contains("PBV")) && !encontradoPesoBruto)
                {
                    //el PESO BRUTO puede venir distinto en algunas facturas por eso separamos desde los dos puntos
                    encontradoPesoBruto = true;
                    var peso = SplitPalabras(s).ToLower();
                    datosFacturas.PesoBruto = FuncionGlobal.ConvierteTextoANumero(peso).ToString(CultureInfo.InvariantCulture);
                }

            }
          

           
            datosFacturas.FormaPago = Convert.ToString(dlTipoPago.SelectedValue);
            datosFacturas.CuentaUsuario = Convert.ToString(Session["usrname"]);
            datosFacturas.Grupo = dlGrupo.SelectedValue.Trim();
            datosFacturas.idSucursal = Convert.ToInt32(dlSucursal.SelectedValue);
            return Add(datosFacturas);
        }
        #endregion

        #region -SERGIO ESCOBAR

        public RespuestaAgp SergioEscobar(string texto)
        {
            //variables especificas
            bool encontradoGiro = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoMotor = false;//se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando 
            bool encontradoFormaPago = false;  //se inicia en falso; si encuentro el giro pasa a verdadero y no sigue buscando
            bool encontradoPuertas = false;  //se inicia en falso; si encuentro el puertas pasa a verdadero y no sigue buscando
            bool encontradoAsientos = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoPesoBruto = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoComuna = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando
            bool encontradoCiudad = false;  //se inicia en falso; si encuentro el asientos pasa a verdadero y no sigue buscando

            var datosFacturas = new DatoFactura { IdCliente = Convert.ToInt32(dlCliente.SelectedValue) };

            char[] delimiterChars = { '\n' };
            string[] words = texto.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var contadorPalabras = 0;

            foreach (string s in words)
            {
                
                var dato = s.Trim().ToUpper();
                if (dato == "R.U.T.")
                {
                    var rutCompleto = words[contadorPalabras + 4];
                    string rut;
                    string dv;
                    if (rutCompleto.Trim().ToUpper().Contains("K"))
                    {
                        rut = FuncionGlobal.ConvierteTextoANumero(rutCompleto).ToString();
                        dv = "K";
                    }
                    else
                    {
                        var nuevo = FuncionGlobal.ConvierteTextoANumero(rutCompleto).ToString(CultureInfo.InvariantCulture);
                        rut = (nuevo.Substring(0, nuevo.Length - 1));
                        dv = (nuevo.Substring(nuevo.Length - 1, 1));
                    }
                    datosFacturas.Rut = rut;
                    datosFacturas.Dv = dv;
               
                }
                if (dato.Contains("MOTOR"))
                {
                    datosFacturas.Motor = words[contadorPalabras + 1];
                }
                else if (dato.Contains("CHASIS / SERIE"))
                {
                    datosFacturas.Chassis = words[contadorPalabras + 1];
                }
                else if (dato.Contains("AÑO COMERCIAL"))
                {
                    datosFacturas.AnioComercial = words[contadorPalabras + 1];
                }
                else if (dato.Contains("COLOR"))
                {
                    datosFacturas.Color = words[contadorPalabras + 1];
                }
                else if (dato.Contains("NRO. PUERTAS"))
                {
                    datosFacturas.Puertas = words[contadorPalabras + 16];
                }
                else if (dato.Contains("TIPO DE COMBUSTIBLE"))
                {
                    var d = words[contadorPalabras + 16].Trim().ToLower();
                    if (d.Contains("bencina") || d.Contains("gasolina"))
                    {
                        d = "Gasolina";
                    }
                    else if (d.Contains("diesel"))
                    {
                        d = "Diesel";
                    }
                    else if (d.Trim() == string.Empty)
                    {
                        d = "No encontrado";
                    }
                    datosFacturas.Combustible = new OrdenTrabajoBC().GetCodigoSga(d, "COMBUSTIBLE");
                }
                else if (dato.Contains("MARCA"))
                {
                    datosFacturas.MarcaVehiculo = words[contadorPalabras + 18];
                }
                else if (dato.Contains("MODELO"))//Modelo
                {
                    datosFacturas.Modelo = words[contadorPalabras + 18];
                }
                else if (dato.Contains("NRO. ASIENTOS"))//Modelo
                {
                    datosFacturas.Asiento = words[contadorPalabras + 18];
                }
                else if (dato.Contains("PESO BRUTO VEHICULAR"))//Modelo
                {
                    var peso = words[contadorPalabras + 18];
                    datosFacturas.PesoBruto = FuncionGlobal.ConvierteTextoANumero(peso).ToString(CultureInfo.InvariantCulture);
                
                }
                else if (dato.Contains("NOTA:"))
                {
                    datosFacturas.Cit = dato.Substring(dato.Length - 17, 17);
                }


                if (dato.Contains("SEÑOR(ES) :"))
                {
                    datosFacturas.Nombre = s.Replace("SEÑOR(ES) :", string.Empty).Trim();
                }
                else if (dato.Contains("DIRECCIÓN :"))
                {
                    datosFacturas.Direccion = s.Replace("DIRECCIÓN :", string.Empty).Trim();
                }
                else if (dato.Contains("COMUNA :") && dato.Contains("CIUDAD"))
                {
                    var listaCiudadComuna = s.Split(new string[] { ":" }, StringSplitOptions.None);
                    var contCiudad = 1;
                    foreach (var s1 in listaCiudadComuna)
                    {
                        switch (contCiudad)
                        {
                            case 1:
                                datosFacturas.Comuna = s1.Replace("CIUDAD",string.Empty).Trim();
                                encontradoComuna = true;
                                break;
                            case 2:
                                datosFacturas.Ciudad = s1.Trim();
                                encontradoCiudad = true;
                                break;
                        }
                        contCiudad++;
                    }
                }
                else if (dato.Contains("COMUNA :") && !encontradoComuna)
                {
                    datosFacturas.Comuna = s.Replace("COMUNA :", string.Empty).Trim();
                }
                else if (dato.Contains("CIUDAD :") && !encontradoCiudad)
                {
                    datosFacturas.Comuna = s.Replace("CIUDAD :", string.Empty).Trim();
                }
                else if (dato.Contains("PEDIDO DE VENTA :"))
                {
                    datosFacturas.NotaPedido = s.Replace("PEDIDO DE VENTA :", string.Empty).Trim();
                }
                else if (dato.Contains("GIRO :"))
                {
                    datosFacturas.Giro = s.Replace("GIRO :", string.Empty).Trim();
                }
                else if (dato.Contains("GIRO :"))
                {
                    datosFacturas.Giro = s.Replace("GIRO :", string.Empty).Trim();
                }
                else if (dato.Contains("COND.PAGO :"))
                {
                    datosFacturas.FormaPago = s.Replace("COND.PAGO :", string.Empty).Trim();
                }
                else if (dato.Contains("TOTAL NETO"))
                {
                    var monto = s.Replace("TOTAL NETO", string.Empty).Trim();
                    datosFacturas.ValorNeto = monto.Replace(".", string.Empty).Trim();
                }


                switch (contadorPalabras)
                {
                  
                    case 48://*
                        datosFacturas.FechaFactura = s.Trim();
                        break;
                    case 26://*
                        datosFacturas.NumeroFactura = s.Replace("Nº", "").Trim();
                        Factura = datosFacturas.NumeroFactura;//valor factura para cambiar nombre del archivo en la carpeta de destino
                        break;
                    
                }

                contadorPalabras++;
            }

            //Para conocer si es inscripcion o transferencia
            //Transferencia = texto.ToUpper().Contains("PATENTE");
            //datosFacturas.Transferencia = Transferencia;
            //if (Transferencia)
            //{

            //    if (texto.ToUpper().Contains("PATENTE UNICA"))
            //    {
            //        var textoPatente =
            //            texto.ToUpper()
            //                .Substring(texto.ToUpper().IndexOf("PATENTE UNICA", StringComparison.Ordinal),
            //                    texto.Length -
            //                    texto.ToUpper().IndexOf("PATENTE UNICA", StringComparison.Ordinal) - 1);

            //        var textoRepertorio = textoPatente.ToUpper().Contains("REPERTORIO") ? "REPERTORIO" : "REPETORIO";
            //        var patente = textoPatente.ToUpper()
            //            .Substring(0, textoPatente.ToUpper().IndexOf(textoRepertorio, StringComparison.Ordinal));
            //        patente = patente.Replace(",", string.Empty);
            //        datosFacturas.Patente = patente.Replace("PATENTE UNICA", string.Empty).Trim();

            //    }
            //    else
            //    {
            //        var textoPatente =
            //            texto.ToUpper()
            //                .Substring(texto.ToUpper().IndexOf("PATENTE", StringComparison.Ordinal),
            //                    texto.Length -
            //                    texto.ToUpper().IndexOf("PATENTE", StringComparison.Ordinal) - 1);

            //        var textoRepertorio = "N° SOLICITUD";
            //        var patente = textoPatente.ToUpper()
            //            .Substring(0, textoPatente.ToUpper().IndexOf(textoRepertorio, StringComparison.Ordinal));
            //        patente = patente.Replace(",", string.Empty);
            //        patente = patente.Replace(".", string.Empty);
            //        patente = patente.Replace("PATENTE", string.Empty).Trim();
            //        datosFacturas.Patente = patente.Substring(0, 6);
            //    }
            //}

            //para conocer si tiene compra para
            Comprapara = texto.ToUpper().Contains("COMPRA PARA");
            datosFacturas.TieneCompraPara = Comprapara;

            if (Comprapara)
            {
                string hasta = "RUT";
                var textonuevo = texto.Substring(texto.ToUpper().IndexOf("COMPRA PARA", StringComparison.Ordinal), texto.Length - texto.ToUpper().IndexOf("COMPRA PARA", StringComparison.Ordinal) - 1).ToUpper();
                //separamos el numbre del resto del texto
                if (textonuevo.Contains("R.U.T."))
                {
                    hasta = "R.U.T.";
                }
                else if (textonuevo.Contains("RUT"))
                {
                    hasta = "RUT";
                }
                else
                {
                    hasta = ",";
                }
                //hasta = textonuevo.Contains("RUT") ? "RUT" : ",";
                var nombreCompraPara = textonuevo.Substring(0, textonuevo.IndexOf(hasta, StringComparison.Ordinal) - 1);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace(":", string.Empty);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace(";", string.Empty);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace("COMPRA PARA", String.Empty);
                nombreCompraPara = nombreCompraPara.ToUpper().Replace(",", string.Empty);

                //separamos el rut del resto del texto
                var nuevoTextoRut = textonuevo.Substring(textonuevo.IndexOf(hasta, StringComparison.Ordinal),
                                                    textonuevo.Length -
                                                    textonuevo.IndexOf(hasta, StringComparison.Ordinal) - 1);
                var rutTexto = nuevoTextoRut.Substring(0, 19);
                var rut = FuncionGlobal.ConvierteTextoANumero(rutTexto);
                var rutNumerico = Convert.ToInt32(Convert.ToString(rut).Substring(0, Convert.ToString(rut).Length - 1));
                var dv = Convert.ToString(rut).Substring(Convert.ToString(rut).Length - 1, 1);


                datosFacturas.CompraParaDescripcion = nombreCompraPara + " " + rutTexto;
                datosFacturas.CompraParaNombre = nombreCompraPara;
                datosFacturas.CompraParaRut = rutNumerico;
                datosFacturas.CompraParaDv = dv;

            }
            datosFacturas.FormaPago = Convert.ToString(dlTipoPago.SelectedValue);
            datosFacturas.CuentaUsuario = Convert.ToString(Session["usrname"]);
            datosFacturas.Grupo = dlGrupo.SelectedValue.Trim();
            datosFacturas.idSucursal = Convert.ToInt32(dlSucursal.SelectedValue);
            return Add(datosFacturas);
        }

        #endregion

        #endregion

        #region METODO ADD

        public RespuestaAgp Add(CENTIDAD.DatoFactura datosFacturas)
        {
            var respuesta = new RespuestaAgp();
            var idCliente = datosFacturas.IdCliente;

            switch (idCliente)
            {
                case (int)Cliente.Gildemeister:
                    respuesta = new OrdenTrabajoBC().AddOrdenTrabajoWebservice(datosFacturas);
                    break;
                case (int)Cliente.Porche:
                    respuesta = new OrdenTrabajoBC().AddOrdenTrabajoPorche(datosFacturas);
                    break;

                case (int)Cliente.Bech:
                    respuesta = new OrdenTrabajoBC().AddOrdenTrabajoBech(datosFacturas);
                    break;
                case (int)Cliente.KiaChile:
                    respuesta = new OrdenTrabajoBC().AddOrdenTrabajoWebservice(datosFacturas);
                    break;
                case (int)Cliente.SergioEscobar:
                    respuesta = new OrdenTrabajoBC().AddOrdenTrabajoWebservice(datosFacturas);
                    break;
            }

            if (respuesta.IdRespuesta == -1 || respuesta.IdRespuesta == -2 || respuesta.IdRespuesta == -3)
            {
                return respuesta;
            }

            var lista = new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 2 } }, dlGrupo.SelectedValue.Trim());

            var siguienteUsuario = string.Empty;
            foreach (var usu in lista)
            {
                siguienteUsuario = usu.Usuario.UserName;
            }

            if (siguienteUsuario.Trim() == string.Empty)
            {
                siguienteUsuario = Convert.ToString(Session["usrname"]);
            }

            var ordenTrabajo = new OrdenTrabajoBC().GetOrdenTrabajo(respuesta.IdRespuesta);
            var listaProductos = new OrdenTrabajoBC().GetordenTrabajoProducto(respuesta.IdRespuesta);
            var log = new OrdenTrabajoActividadLogBC().GetLastOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog { OrdenTrabajo = new CENTIDAD.OrdenTrabajo { IdOrden = respuesta.IdRespuesta } });
            //si es una transferencia
            if (datosFacturas.Transferencia)
            {
                foreach (OrdenTrabajoTipoOperacion ordenTrabajoTipoOperacion in listaProductos)
                {
                    //si se solicita una primera inscripción
                    if (ordenTrabajoTipoOperacion.TipoOperacion.Codigo == "PI" || ordenTrabajoTipoOperacion.TipoOperacion.Codigo == "PITAG")
                    {

                        new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                        {
                            OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                            {
                                CuentaUsuario = Convert.ToString(Session["usrname"])
                        ,
                                IdOrden = Convert.ToInt32(respuesta.IdRespuesta)
                            },
                            ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 6 },//en reparo
                            Avanza = 0,
                            IdOrdenTrabajoActividadLog = 0
                        });

                        //new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(ordenTrabajo.CuentaUsuario, 6, Convert.ToInt32(respuesta.IdRespuesta), 0, log.IdOrdenTrabajoActividadLog); //id_actividad 6  = reparos
                        new OrdenTrabajoBC().AddReparo(0, respuesta.IdRespuesta, 1, "1", "lector_fact", ordenTrabajo.CuentaUsuario, "PANTALLA CARGA MASIVA TICKETS: EL TIPO DE OPERACION NO CORRESPONDE A LO LEIDO EN LA FACTURA", 0);

                        return respuesta;
                    }
                }
            }
            //si no es transferencia
            if (!datosFacturas.Transferencia)
            {
                foreach (OrdenTrabajoTipoOperacion ordenTrabajoTipoOperacion in listaProductos)
                {
                    //si se solicita una primera inscripción
                    if (ordenTrabajoTipoOperacion.TipoOperacion.Codigo == "TMAH" || ordenTrabajoTipoOperacion.TipoOperacion.Codigo == "TRCAR" || ordenTrabajoTipoOperacion.TipoOperacion.Codigo == "TRVFN")
                    {
                        new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                        {
                            OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                            {
                                CuentaUsuario = Convert.ToString(Session["usrname"])
                       ,
                                IdOrden = Convert.ToInt32(respuesta.IdRespuesta)
                            },
                            ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 6 },//en reparo
                            Avanza = 0,
                            IdOrdenTrabajoActividadLog = 0
                        });

                        new OrdenTrabajoBC().AddReparo(0, respuesta.IdRespuesta, 1, "1", "lector_fact", ordenTrabajo.CuentaUsuario, "APLICACION LECTOR FACTURAS: EL TIPO DE OPERACION NO CORRESPONDE A LO LEIDO EN LA FACTURA", 0);

                        return respuesta;
                    }
                }
            }

            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = siguienteUsuario
                       ,
                    IdOrden = Convert.ToInt32(respuesta.IdRespuesta)
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 2 },//en espera de asignacion
                Avanza = 1,
                IdOrdenTrabajoActividadLog = 0
            });

            return respuesta;
        }
        #endregion

        #region Utilidades

        private string SplitPalabras(string s)
        {
            char[] separador = { ':' };
            string[] split = s.Split(separador, StringSplitOptions.RemoveEmptyEntries);
            return split[1].Trim();
        }

        #endregion

    }
}