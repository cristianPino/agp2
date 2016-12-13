using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Globalization;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace sistemaAGP.OrdenTrabajo.modal
{
    public partial class IngresoGarantias : Page
    {
        const string IMAGEN_SOLO_LECTURA = "~/imagenes/sistema/static/hipotecario/soloLectura.png";
        const string IMAGE_REALIZA_CAMBIOS = "~/imagenes/sistema/static/hipotecario/realizaCambios.png";
        const string IMAGEN_ROJO = "~/imagenes/sistema/static/rojo.png";

        public class Valida
        {
            public string Patente { get; set; }
            public int Rut { get; set; }
        }

        public static List<Valida> ListaValidacion = new List<Valida>();


        public enum Cliente
        {
            Scotiabank = 19,
            Bice = 14,
            Bk = 58
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FuncionGlobal.comboclientesbyusuario(Convert.ToString(Session["usrname"]), dlCliente);
        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            if (FuncionGlobal.digitoVerificador(txtRut.Text) != txtDv.Text)
            {
                FuncionGlobal.alerta_updatepanel("RUT ERRONEO", Page, upd);
                return;
            }
            if (Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Scotiabank &&
                Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Bice &&
                Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Bk)
            {
                FuncionGlobal.alerta_updatepanel("CLIENTE NO TIENE INGRESO PRETICKET HABILITADO", Page, upd);
                return;
            }

            if ((Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bice ||
               Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bk) &&
               (txtOperacion.Text.Trim() == string.Empty)
               )

            {
                FuncionGlobal.alerta_updatepanel("INGRESE NUMERO DE OPERACION", Page, upd);
                return;
            }


            string usuario = Convert.ToString(Session["usrname"]);
            if (string.IsNullOrEmpty(usuario))
            {
                FuncionGlobal.alerta_updatepanel("Ha perdido la sessión, ingrese al sistema y vuelva a intentarlo", this.Page, upd);
                return;
            }

            if (txtPatente.Text.Trim().Length != 6 || txtRut.Text.Trim() == string.Empty ||
                txtCorreo.Text.Trim() == string.Empty || !FuncionGlobal.formatoPatente(txtPatente.Text.Trim()) |
                hdnIdSucursal.Value == "0"
                )
            {
                FuncionGlobal.alerta_updatepanel("Llene todos los datos. Asegurese de que la patente esté bien ingresada. Asegurese de que la sucursal exista", Page, upd);
            }
            else
            {
                Crear();
            }
        }

        private void Crear()
        {

            int idNuevaOrden = 0;
            //GUARDA OT
            var otr = new CENTIDAD.OrdenTrabajo
            {
                CuentaUsuario = Convert.ToString(Session["usrname"]),
                Patente = txtPatente.Text.Trim(),
                Observacion = txtCorreo.Text.Trim(),
                RutAdquiriente = txtRut.Text.Trim(),
                IdCliente = Convert.ToInt32(dlCliente.SelectedValue),
                IdSucursal = Convert.ToInt32(hdnIdSucursal.Value),
                NumeroOrden = Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bice ||
                                Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bk ?
                                txtOperacion.Text.Trim()
                                : "0"
            };

            idNuevaOrden = new OrdenTrabajoBC().AddOrdenTrabajoGarantia(otr);

            //GUARDA ESTADOS 2 Y 3
            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = Convert.ToString(Session["usrname"])
                    ,
                    IdOrden = idNuevaOrden
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 2 },//en espera de asignacion
                Avanza = 1,
                IdOrdenTrabajoActividadLog = 0
            });

            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Scotiabank ?
                                            "174295700" //OJO EN DURO A Carla Nicole Venegas Aguillón...LUEGO CREAR GRUPO USUARIOS PARA HACERLO DINAMICO
                                            : "17303492k"//OJO EN DURO A Camila Aguayo...LUEGO CREAR GRUPO USUARIOS PARA HACERLO DINAMICO
                            ,
                    IdOrden = idNuevaOrden
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 3 },//en espera de asignacion
                Avanza = 1,
                IdOrdenTrabajoActividadLog = new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyidOT(idNuevaOrden).IdOrdenTrabajoActividadLog
            });

            //SUBE ARCHIVO
            subir_archivos(idNuevaOrden);

            FuncionGlobal.alerta_updatepanel($"Nuevo ticket creado con el Nº {idNuevaOrden}", Page, upd);

            txtCorreo.Text = string.Empty;
            txtPatente.Text = string.Empty;
        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }


        protected void txtRut_TextChanged(object sender, EventArgs e)
        {
            txtDv.Text = FuncionGlobal.digitoVerificador(txtRut.Text);
        }


        #region CODIGO QUE CARGA DOCUMENTOS

        protected void subir_archivos(int idOrdenTrabajo)
        {

            Int32 idDocumento = 3;//CAV

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
            string destino = "";

            destino = "/" + anio + "/" + CarpetaMes + "/" + nuevo_dia;

            string sPath = String.Format("{0}/{1}/{2}", "docs", idOrdenTrabajo, idDocumento);
            if (!System.IO.Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", idDocumento);
            if (!System.IO.Directory.Exists(@sPath)) sPath = "docs";


            FileUpload fu_documento = fu_archivo;
            if (fu_documento.PostedFile != null && fu_documento.PostedFile.ContentLength > 0)
            {
                FileInfo fi_documento = new FileInfo(fu_documento.FileName);
                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".png" || fi_documento.Extension.ToLower() == ".jpg" ||
                        fi_documento.Extension.ToLower() == ".gif" || fi_documento.Extension.ToLower() == ".pdf" ||
                        fi_documento.Extension.ToLower() == ".doc" || fi_documento.Extension.ToLower() == ".docx" ||
                        fi_documento.Extension.ToLower() == ".xls" || fi_documento.Extension.ToLower() == ".xlsx" ||
                        fi_documento.Extension.ToLower() == ".tiff")
                    {
                        if (fu_documento.PostedFile.ContentLength <= 6194304)
                        {
                            string sDoc = idOrdenTrabajo.ToString() + "_" + idDocumento.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                            string sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;
                            //string sSave = Server.MapPath(@"docs") + "\\" + sDoc;
                            try
                            {

                                fu_documento.PostedFile.SaveAs(sSave);
                                //sSave = "docs/" + sDoc;
                                sSave = sPath + destino + "/" + sDoc;
                                new ChecklistOrdenTrabajoBC().AddChecklistOrdenTrabajo(new ChecklistOrdenTrabajo
                                {
                                    IdChecklist = idDocumento,
                                    CuentaUsuario = Session["usrname"].ToString().Trim(),
                                    Url = sSave,
                                    Observacion = "Carga inicial",
                                    IdOrdenTrabajo = idOrdenTrabajo
                                });


                                ;
                            }
                            catch (Exception ex)
                            {
                                FuncionGlobal.alerta_updatepanel(ex.Message, Page, upd);
                                return;
                            }
                        }
                    }
                }

            }

        }


        public string CambiarMes(string mes)
        {
            string nuevomes = mes;
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

        protected void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            hdnIdSucursal.Value = "0";
            var sucursal = new SucursalclienteBC().getSucursalParidad(txtSucursal.Text.Trim(), Convert.ToInt32(dlCliente.SelectedValue));

            if (sucursal.Id_sucursal > 0)
            {
                lblNombreSucursal.Text = sucursal.Nombre;
                hdnIdSucursal.Value = sucursal.Id_sucursal.ToString();
            }
            else
            {
                lblNombreSucursal.Text = "Sucursal no encontrada";
            }
        }



        #region Codigo obtencion data excel cargas masivas

        private void ImportarExcel(string ruta)
        {
            //obtengo la estructura de columnas de todas las hojas del excel
            string estructuraExcel = "SELECT [codigo_sucursal],[patente],[rut_adquiriente],[correo],[n_operacion] FROM [Hoja1$]";
            //Declaro en viewstate datatable que mostrara la info 
            DataTableIngreso();
            DataSet dsDatos = new DataSet();
            dsDatos = ObtenerDataSetExcel(estructuraExcel, ruta);
            LlenarNuevasOperaciones(dsDatos);
        }


        public void DataTableIngreso()
        {
            var dtIngreso = new DataTable();
            dtIngreso.Columns.Add(new DataColumn("fila_excel"));
            dtIngreso.Columns.Add(new DataColumn("id_sucursal"));
            dtIngreso.Columns.Add(new DataColumn("nombre_sucursal"));
            dtIngreso.Columns.Add(new DataColumn("codigo_sucursal"));
            dtIngreso.Columns.Add(new DataColumn("correo"));
            dtIngreso.Columns.Add(new DataColumn("rut"));
            dtIngreso.Columns.Add(new DataColumn("patente"));
            dtIngreso.Columns.Add(new DataColumn("estado_revision"));
            dtIngreso.Columns.Add(new DataColumn("n_operacion"));
            dtIngreso.Columns.Add(new DataColumn("semaforo"));
            dtIngreso.Columns.Add(new DataColumn("mensaje"));
            dtIngreso.Columns.Add(new DataColumn("rut_formateado"));
            ViewState["dtIngreso"] = dtIngreso;
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


        public void LlenarNuevasOperaciones(DataSet ds)
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
                //variables de respuesta valores por defecto positivos
                var mensajeAnalisis = string.Empty;
                var iconoAnalisis = IMAGE_REALIZA_CAMBIOS;
                var estadoAnalisis = "1";

                //INICIALIZACION VARIABLES PARA USO MULTIPLE
                var rut = string.IsNullOrEmpty(Convert.ToString(drInfo["rut_adquiriente"])) ? string.Empty : Convert.ToString(drInfo["rut_adquiriente"]).Trim();
                var patente = string.IsNullOrEmpty(Convert.ToString(drInfo["patente"])) ? string.Empty : Convert.ToString(drInfo["patente"]);
                var codigoSucursal = string.IsNullOrEmpty(Convert.ToString(drInfo["codigo_sucursal"])) ? string.Empty : Convert.ToString(drInfo["codigo_sucursal"]);
                var correo = string.IsNullOrEmpty(Convert.ToString(drInfo["correo"])) ? string.Empty : Convert.ToString(drInfo["correo"]);
                var n_operacion = string.IsNullOrEmpty(Convert.ToString(drInfo["n_operacion"])) ? string.Empty : Convert.ToString(drInfo["n_operacion"]);

                patente = patente.Replace(" ", string.Empty);
                var rutFormateado = string.Empty;

                int idSucursalAgp = 0;
                string nombreSucursal = string.Empty;

                #region VALIDACIONES DE LOS CAMPOS

                //SE VALIDA QUE LOS CAMPOS IMPORTANTES CONTENGAN INFO
                if (rut != string.Empty && patente != string.Empty && codigoSucursal != string.Empty)
                {
                    //RUT
                    if (ValidarRut(rut.Trim()))
                    {
                        rutFormateado = rut.Replace(".", string.Empty);
                        rutFormateado = rutFormateado.Replace("-", string.Empty);
                        rutFormateado = rutFormateado.Replace(",", string.Empty);
                        rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);
                        //PATENTE
                        if (FuncionGlobal.formatoPatente(patente))
                        {
                            //OPERACION --si NO existe, continúa
                            if (ValidarOperacionUnica(patente, rutFormateado))
                            {
                                //CORREO
                                if (ComprobarFormatoEmail(correo))
                                {
                                    //SUCURSAL
                                    var sucursal = new SucursalclienteBC().getSucursalParidad(codigoSucursal, Convert.ToInt32(dlCliente.SelectedValue));
                                    if (sucursal.Id_sucursal > 0)
                                    {
                                        nombreSucursal = sucursal.Nombre;
                                        idSucursalAgp = sucursal.Id_sucursal;

                                        //N operacion para bk bice
                                        if ((Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bk ||
                                            Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bice) &&
                                            (n_operacion == string.Empty))
                                        {
                                            mensajeAnalisis = "FALTA NUMERO OPERACION";
                                            iconoAnalisis = IMAGEN_SOLO_LECTURA;
                                            estadoAnalisis = "0";
                                        }

                                    }
                                    else
                                    {
                                        mensajeAnalisis = "SUCURSAL NO ENCONTRADA";
                                        iconoAnalisis = IMAGEN_SOLO_LECTURA;
                                        estadoAnalisis = "0";
                                    }
                                }
                                else
                                {
                                    mensajeAnalisis = "CORREO ERRONEO";
                                    iconoAnalisis = IMAGEN_SOLO_LECTURA;
                                    estadoAnalisis = "0";
                                }
                            }
                            else
                            {
                                mensajeAnalisis = "OPERACION EXISTE";
                                iconoAnalisis = IMAGEN_SOLO_LECTURA;
                                estadoAnalisis = "0";
                            }

                        }
                        else
                        {
                            mensajeAnalisis = "PATENTE INVALIDA";
                            iconoAnalisis = IMAGEN_SOLO_LECTURA;
                            estadoAnalisis = "0";
                        }

                    }
                    else
                    {
                        mensajeAnalisis = "RUT INVALIDO";
                        iconoAnalisis = IMAGEN_SOLO_LECTURA;
                        estadoAnalisis = "0";
                    }
                }
                else
                {
                    mensajeAnalisis = "ALGUNO DE LOS CAMPOS NO EXISTEN";
                    iconoAnalisis = IMAGEN_SOLO_LECTURA;
                    estadoAnalisis = "0";
                }

                #endregion

                //LLENADO DE GRIDVIEW
                var dr = dt.NewRow();
                dr["fila_excel"] = filaExcel;
                dr["id_sucursal"] = idSucursalAgp;
                dr["nombre_sucursal"] = nombreSucursal;
                dr["codigo_sucursal"] = codigoSucursal;
                dr["n_operacion"] = n_operacion;
                dr["correo"] = correo;
                dr["rut"] = rut;
                dr["rut_formateado"] = rutFormateado;
                dr["patente"] = patente;
                dr["estado_revision"] = estadoAnalisis;
                dr["semaforo"] = iconoAnalisis;
                dr["mensaje"] = mensajeAnalisis == string.Empty ? "CORRECTO" : mensajeAnalisis;

                dt.Rows.Add(dr);
            }

            grDato.DataSource = dt;
            grDato.DataBind();
            ViewState["dtIngreso"] = dt;

            if (dtInfo.Rows.Count > 0)
            {
                fileuploadExcel.Visible = false;
                btnAnalisisMasivo.Visible = false;
                btnUpload.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                fileuploadExcel.Visible = true;
                btnAnalisisMasivo.Visible = true;
                btnUpload.Visible = false;
                btnCancel.Visible = false;
            }

            ListaValidacion.Clear();
        }

        #region VALIDACIONES       

        public bool ValidarOperacionUnica(string patente, string rut)
        {
            bool respuesta = true;
            bool existe = false;

            if (ListaValidacion != null)
            {
                existe = ListaValidacion.Exists(x => x.Rut == Convert.ToInt32(rut) && x.Patente.ToLower().Trim() == patente.ToLower().Trim());
            }
            if (existe)
            {
                respuesta = false;
            }
            else
            {
                //si no existe en la lista lo agrego 
                ListaValidacion.Add(new Valida { Patente = patente, Rut = Convert.ToInt32(rut) });

                //Valida si existe una operacion con el rut y la patente si existe devuelve true
                DataTable dt = new OrdenTrabajoBC().ValidaGarantias(Convert.ToInt32(rut), patente);
                if (Convert.ToBoolean(dt.Rows[0]["existe"]))
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        private bool ValidarRut(string rut)
        {
            var rutFormateado = Convert.ToString(FuncionGlobal.ConvierteTextoANumero(rut));
            var dv = rut.Substring(rut.Length - 1, 1);
            if (dv.Trim().ToLower() != "k")
            {
                rutFormateado = rutFormateado.Substring(0, rutFormateado.Length - 1);
            }
           
            var dvValidacion = FuncionGlobal.digitoVerificador(rutFormateado);
            return dvValidacion.ToLower().Trim() == dv.ToLower().Trim();
        }

        private bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            if (sEmailAComprobar.Trim().ToLower() != string.Empty)
            {
                String sFormato;
                sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(sEmailAComprobar, sFormato))
                {
                    if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        #endregion

        #endregion

        protected void btnAnalisisMasivo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Scotiabank &&
                Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Bice &&
                Convert.ToInt32(dlCliente.SelectedValue) != (int)Cliente.Bk)
            {
                FuncionGlobal.alerta_updatepanel("CLIENTE NO TIENE INGRESO PRETICKET HABILITADO", Page, upd);
                return;
            }

            try
            {
                //ImportarExcel(@"E:\prueba\14-11-2016 (2).xlsx");
                ImportarExcel(carga_archivo());
                FuncionGlobal.alerta_updatepanel("Análisis Terminado", this.Page, upd);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta_updatepanel(
                    $"ERROR: SE HA PRODUCIDO EL SIGUIENTE ERROR EN EL PROCESO DE ANALISIS: {ex.Message}",
                    this.Page,
                    upd
                    );
            }

        }

        private string carga_archivo()
        {
            string sSave = "";

            if (fileuploadExcel.PostedFile != null && fileuploadExcel.PostedFile.ContentLength > 0)
            {
                var fiDocumento = new FileInfo(fileuploadExcel.FileName);
                if (fiDocumento.Extension.ToLower() == ".xlsx")
                {

                    if (fileuploadExcel.PostedFile.ContentLength <= 6194304)
                    {
                        string sDoc = "CM_" + Convert.ToString(Session["usrname"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fiDocumento.Extension;
                        string sPath = $"{"~/digitalizacion/docs"}/{"preticket"}/{"cargas_masivas"}";
                        sSave = Server.MapPath(@sPath) + "\\" + sDoc;
                        fileuploadExcel.PostedFile.SaveAs(sSave);
                    }
                }
            }
            return sSave;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string usuario = Convert.ToString(Session["usrname"]);
            if (string.IsNullOrEmpty(usuario))
            {
                FuncionGlobal.alerta_updatepanel("Ha perdido la sessión, ingrese al sistema y vuelva a intentarlo", this.Page, upd);
                return;
            }
            //GUARDA POSITIVOS
            var buenas = 0;
            for (int i = 0; i < grDato.Rows.Count; i++)
            {
                var estadoRevision = Convert.ToString(grDato.DataKeys[i].Values["estado_revision"]);
                if (estadoRevision == "1")
                {
                    int idNuevaOrden = 0;
                    //GUARDA OT
                    var otr = new CENTIDAD.OrdenTrabajo
                    {
                        CuentaUsuario = usuario,
                        Patente = Convert.ToString(grDato.DataKeys[i].Values["patente"]),
                        Observacion = Convert.ToString(grDato.DataKeys[i].Values["correo"]),
                        RutAdquiriente = Convert.ToString(grDato.DataKeys[i].Values["rut_formateado"]),
                        IdCliente = Convert.ToInt32(dlCliente.SelectedValue),
                        IdSucursal = Convert.ToInt32(grDato.DataKeys[i].Values["id_sucursal"]),
                        NumeroOrden = Convert.ToString(grDato.DataKeys[i].Values["n_operacion"]),
                    };

                    idNuevaOrden = new OrdenTrabajoBC().AddOrdenTrabajoGarantia(otr);

                    //GUARDA ESTADOS 2 Y 3
                    new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                    {
                        OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                        {
                            CuentaUsuario = usuario
                            ,
                            IdOrden = idNuevaOrden
                        },
                        ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 2 },//en espera de asignacion
                        Avanza = 1,
                        IdOrdenTrabajoActividadLog = 0
                    });

                    new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                    {
                        OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                        {
                            CuentaUsuario = Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Scotiabank ?
                                            "174295700" //OJO EN DURO A Carla Nicole Venegas Aguillón...LUEGO CREAR GRUPO USUARIOS PARA HACERLO DINAMICO
                                            : "17303492k"//OJO EN DURO A Camila Aguayo...LUEGO CREAR GRUPO USUARIOS PARA HACERLO DINAMICO
                            ,
                            IdOrden = idNuevaOrden
                        },
                        ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 3 },//ESPERANDO INGRESO AGP
                        Avanza = 1,
                        IdOrdenTrabajoActividadLog = new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyidOT(idNuevaOrden).IdOrdenTrabajoActividadLog
                    });
                    buenas++;
                }
            }

            ViewState["dtIngreso"] = null;
            grDato.DataSource = null;
            grDato.DataBind();

            fileuploadExcel.Visible = true;
            btnAnalisisMasivo.Visible = true;
            btnUpload.Visible = false;
            btnCancel.Visible = false;

            FuncionGlobal.alerta_updatepanel($"Se crearon {buenas} pretickets con éxito", this.Page, upd);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ViewState["dtIngreso"] = null;
            grDato.DataSource = null;
            grDato.DataBind();

            fileuploadExcel.Visible = true;
            btnAnalisisMasivo.Visible = true;
            btnUpload.Visible = false;
            btnCancel.Visible = false;
        }

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            trNumeroOperacion.Visible = Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bice ||
                                        Convert.ToInt32(dlCliente.SelectedValue) == (int)Cliente.Bk;
        }
    }
}