using System;  
using System.Collections.Generic;
using System.Data;     
using System.Globalization;
using System.IO;
using System.Linq;   
using System.Web.UI;
using System.Web.UI.WebControls;   
using CNEGOCIO;
using CENTIDAD;


namespace sistemaAGP.Operacion_Hipotecario
{
    public partial class ingreso_hipotecario : Page
    {

        private Int32 _idSolicitud;
        private Int16 _idCliente;
        private string _tipoOperacion;
        public Usuario Usuario;
        public byte SoloLectura;

        protected void Page_Load(object sender, EventArgs e)
        {

            _idSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
            _idCliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"]));
            _tipoOperacion = Request.QueryString["tipo_operacion"];
            SoloLectura = Convert.ToByte(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["solo_lectura"]));  
            Usuario = new UsuarioBC().GetUsuario(Session["usrname"].ToString().Trim());
            cambiar_titulo();

            if (IsPostBack) return;
            ComboMesesGracia();
            GetTitulosDoc();
            FuncionGlobal.comboparametro(dlVencimientoPriemraCuota, "HVOTPC");
            FuncionGlobal.comboparametro(dlMescarencia1, "MESANIO");
            FuncionGlobal.comboparametro(dlMescarencia2, "MESANIO");
            FuncionGlobal.comboparametro(dlCodeudorSeguroPorcentaje, "HPORCS");
            FuncionGlobal.comboparametro(dlMonedaPie, "TMONEDA");
            FuncionGlobal.comboparametro(dlUbicacion, "HTIPUB");
            FuncionGlobal.comboparametro(dl_tipo_credito, "TICRE");
            FuncionGlobal.GetHipotecaTipoSubProducto(dlSubProductoCredito, _idCliente);
            FuncionGlobal.comboparametro(dlTipoTransferencia, "HTT");
            FuncionGlobal.comboparametro(dlTipoHipoteca, "HTHIP");
            FuncionGlobal.comboparametro(dlFechaMemo, "MESANIO");
            FuncionGlobal.comboparametro(dlTipoDoc, "DOCHIP");
            FuncionGlobal.comboparametro(dlPlazoMeses, "HPLA");
            FuncionGlobal.comboparametro(dlInicioTasaMixta, "HITM");
            FuncionGlobal.comboparametro(dlFinTasafija, "HFTF");
            FuncionGlobal.comboparametro(dlSubsidioBanco, "HBCOS");
            FuncionGlobal.comboparametro(dlSubsidioTitulo, "HSTIT");
            FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
            FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal_origen, Convert.ToInt16(_idCliente), (string)(Session["usrname"]));
            FuncionGlobal.comboparametro(dl_tipo_prohibicion, "TIPROH");
            FuncionGlobal.comboparametro(dl_tipo_prohibicionCBR, "TIPROH");
            FuncionGlobal.comboparametro(dl_tipo_propiedad, "TIPROP");
            FuncionGlobal.comboregion(dl_region, "CH");  
           // FuncionGlobal.comboTasadorbyCliente(this.dl_tasador, _idCliente); 
            dlVencimientoPriemraCuota.Items.RemoveAt(0);

            
            
            if (_idSolicitud!=0)
            {
                lbl_numero.Text = _idSolicitud.ToString(CultureInfo.InvariantCulture);
                hpParticipantes.NavigateUrl = "../administracion/admParticipantes.aspx";
                compradores1.GetParticipantes(_idSolicitud);   
                hpCompradorAdicional.NavigateUrl = "../administracion/mParticipanteOperacion.aspx?idSolicitud=" + FuncionGlobal.FuctionEncriptar(_idSolicitud.ToString()) +
                     "&tipo=" + FuncionGlobal.FuctionEncriptar("COMPH");  
                hpVendedorAdicional.NavigateUrl = "../administracion/mParticipanteOperacion.aspx?idSolicitud=" + FuncionGlobal.FuctionEncriptar(_idSolicitud.ToString()) +
                     "&tipo=" + FuncionGlobal.FuctionEncriptar("VENDH");
                hpOtrosParticipantes.NavigateUrl = "../administracion/mParticipanteOperacion.aspx?idSolicitud=" + FuncionGlobal.FuctionEncriptar(_idSolicitud.ToString()) +
                     "&tipo=" + FuncionGlobal.FuctionEncriptar("FCS");
                Fojas1.GetAllFojasbyTipo(_idSolicitud,"FOJA");
                FojasFinal.GetAllFojasbyTipo(_idSolicitud, "FFOJA");
                var oper = new OperacionBC().getoperacion(_idSolicitud);
                lblEjecutivo.Text = oper.Usuario.Nombre;
                txt_p_a_favor_deCBR.Text = oper.Cliente.Persona.Nombre;
                EjecutivosHipotecario.GetEjecutivos(_idSolicitud);
                GetDocs(_idSolicitud);
                FuncionGlobal.ComboBeneficiariosSubsidioHipoteca(dlSubsidioBeneficiario,_idSolicitud);
                busca_operacion();
                FuncionGlobal.ComboEjecutivosHipotecario(Convert.ToInt32(dl_sucursal_origen.SelectedValue), dlEjecutivosHipotecario);
                FuncionGlobal.ComboTitulosHipotecaInsertos(dlInsertoTitulos);
                GetAllInsertos();

            }
            else
            {
                lbl_numero.Text = "0";
                ibCreaBorradorEscritura.Visible = false;
                tpEjecutivos.Visible = false;
                tbl_participantes.Visible = false;
                tblFojas.Visible = false;
                tblFinalFojas.Visible = false;
                lblEjecutivo.Text = Usuario.Nombre;
                tab_documentos.Visible = false;
            }  
            
            
            dl_cliente.SelectedValue = _idCliente.ToString(CultureInfo.InvariantCulture);
            var itemToRemove1 = dl_tipo_prohibicion.Items.FindByValue("4");
            var itemToRemove2 = dl_tipo_prohibicion.Items.FindByValue("5");
            var itemToRemove3 = dl_tipo_prohibicion.Items.FindByValue("6");

            var itemToRemove4 = dl_tipo_prohibicionCBR.Items.FindByValue("1");
            var itemToRemove5 = dl_tipo_prohibicionCBR.Items.FindByValue("2");
            var itemToRemove6 = dl_tipo_prohibicionCBR.Items.FindByValue("3");
            var itemToRemove7 = dl_tipo_prohibicionCBR.Items.FindByValue("7");

            if (itemToRemove1 != null) { dl_tipo_prohibicion.Items.Remove(itemToRemove1); }
            if (itemToRemove2 != null) { dl_tipo_prohibicion.Items.Remove(itemToRemove2); }
            if (itemToRemove3 != null) { dl_tipo_prohibicion.Items.Remove(itemToRemove3); }
            if (itemToRemove4 != null) { dl_tipo_prohibicionCBR.Items.Remove(itemToRemove4); }
            if (itemToRemove5 != null) { dl_tipo_prohibicionCBR.Items.Remove(itemToRemove5); }
            if (itemToRemove6 != null) { dl_tipo_prohibicionCBR.Items.Remove(itemToRemove6); }
            if (itemToRemove7 != null) { dl_tipo_prohibicionCBR.Items.Remove(itemToRemove7); }
            dlVencimientoPriemraCuota.SelectedValue = dlMesesGracia.SelectedValue;
          
            Session["tabla_acreedor"] = null; 
            DataTableProhibicion();
            txt_p_a_favor_deCBR.Text = dl_cliente.SelectedItem.ToString(); 
            if(SoloLectura==1)
            {
                Solo_Lectura();
            }
        }

        public void Solo_Lectura()
        {
            panel_tasador.Enabled = false;
            panel_operacion.Enabled = false;
            panel_hgp.Enabled = false;
            panel_ejecutivo.Enabled = false;  
            panel_datos_propiedad.Enabled = false;
            panel_dato_final.Enabled = false;
            panel_credito.Enabled = false;
            panel_cabecera.Enabled = false;
            tbl_solo_lectura.Visible = true;
            ImageButton1.Visible = false; 
        }  
        protected void cambiar_titulo()
        {
            var p = new TipooperacionBC().getTipooperacion(_tipoOperacion);
            Title = p.Operacion;
            lbl_titulo.Text = p.Operacion; 
        }


        private void GetDocs(Int32 idSolicitud)
        {
            i_documento.Attributes["src"] = "";

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_documento_operacion"));
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("id_documento"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("url"));
            dt.Columns.Add(new DataColumn("extension"));
            dt.Columns.Add(new DataColumn("peso"));
            dt.Columns.Add(new DataColumn("observaciones"));
            dt.Columns.Add(new DataColumn("usuario"));

            var lista = new DocumentosOperacionBC().getDocumentos(idSolicitud, 0);
            btnEliminar.Visible = lista.Count > 0;
            foreach (var doc in lista)
            {
                var dr = dt.NewRow();
                dr["id_documento_operacion"] = doc.Id_documento_operacion;
                dr["id_solicitud"] = doc.Id_solicitud;
                dr["id_documento"] = doc.Id_documento;
                dr["nombre"] = doc.Nombre;
                dr["url"] = "../digitalizacion/"+doc.Url;
                dr["extension"] = doc.Extension;
                dr["peso"] = (doc.Peso / 1024).ToString() + "Kb.";
                dr["observaciones"] = doc.Observaciones;
                dr["usuario"] = doc.CuentaUsuario == "" ? "Sin info." : doc.Usuario.Nombre;
                dt.Rows.Add(dr);
            }
            gr_documentos.DataSource = dt;
            gr_documentos.DataBind();
        }

        public void GetTitulosDoc()
        {
            var dt = new DataTable();
            dt.Columns.Add("id_documento");
            dt.Columns.Add("nombre");
            var dr = dt.NewRow();
            dr["id_documento"] = 0;
            dr["nombre"] = "Seleccione un título";
            dt.Rows.Add(dr);

            //Actividad por prod_cliente
            var lista = new DocumentosBC().getDocumentosByProductos(_tipoOperacion, 0);
            foreach (var d in lista)
            {
                dr = dt.NewRow();
                dr["id_documento"] = d.Id_documento;
                dr["nombre"] = d.Nombre;
                dt.Rows.Add(dr);
            }
            dlTitulo.DataSource = dt;
            dlTitulo.DataTextField = "nombre";
            dlTitulo.DataValueField = "id_documento";
            dlTitulo.SelectedValue = "0";
            dlTitulo.DataBind();
        }

        protected void gr_documentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "View") return;
            var idx = Convert.ToInt32(e.CommandArgument);
            var url = gr_documentos.DataKeys[idx].Values[3].ToString(); ;
            i_documento.Attributes["src"] = url;
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            subir_archivos();
        }

        protected void subir_archivos()
        {
            var subida = false;
            var idDocumento = Convert.ToInt32(dlTitulo.SelectedValue);

            //divido la fecha en año mes dia.
            string x = DateTime.Now.ToString("yyyyMMddHHmmss");
            string anio = x.Substring(0, 4);
            string mes = x.Substring(4, 2);
            string dia = x.Substring(6, 2);

            //obtengo todos los nombres de los meses del año en español.
            String[] meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
            string numeroMes = CambiarMes(mes);
            string carpetaMes = numeroMes + "." + meses[Convert.ToInt32(mes) - 1];
            string nuevoDia = CambiarDia(dia);

            //armo los strings con las rutas dependiendo de la consulta.
            var destino = "";

            destino = "/" + anio + "/" + carpetaMes + "/" + nuevoDia;

            var pre = new OperacionBC().getoperacion(_idSolicitud);
            var sPath = String.Format("{0}/{1}/{2}", "docs", pre.Cliente.Id_cliente.ToString().Trim(), pre.Tipo_operacion.Codigo.Trim());
            if (!Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", pre.Tipo_operacion.Codigo.Trim());
            if (!Directory.Exists(@sPath)) sPath = "docs";

            var observaciones = txtComentario.Text.Trim();

            var fuDocumento = fu_archivo;
            if (fuDocumento.PostedFile == null || fuDocumento.PostedFile.ContentLength <= 0) return;
            var fiDocumento = new FileInfo(fuDocumento.FileName);
            if (fiDocumento.Extension.ToLower() != ".png" && fiDocumento.Extension.ToLower() != ".jpg" &&
                fiDocumento.Extension.ToLower() != ".gif" && fiDocumento.Extension.ToLower() != ".pdf" &&
                fiDocumento.Extension.ToLower() != ".doc" && fiDocumento.Extension.ToLower() != ".docx" &&
                fiDocumento.Extension.ToLower() != ".xls" && fiDocumento.Extension.ToLower() != ".xlsx" &&
                fiDocumento.Extension.ToLower() != ".tiff") return;
            if (fuDocumento.PostedFile.ContentLength > 6194304) return;
            var sDoc = _idSolicitud + "_" + idDocumento + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fiDocumento.Extension;
            var sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;
            try
            {
                fuDocumento.PostedFile.SaveAs(sSave);
                sSave = sPath + destino + "/" + sDoc;
                var doc = new DocumentosOperacionBC();
                doc.add_documentos(_idSolicitud, idDocumento, sSave, fiDocumento.Extension, fuDocumento.PostedFile.ContentLength, observaciones, Usuario.UserName);
                var cambiaEstado = new DocumentoCambioEstadoBC().GotoDocumentosCambioEstado(_idSolicitud, idDocumento, Usuario.UserName);
                if (cambiaEstado == 1)
                {
                    Mensaje("Archivo subido con éxito. Esta acción cambió de estado la operación.");
                }
                subida = true;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.updateP, this.updateP.GetType(), "ShowError", string.Format("<script type=\"text/javascript\">alert('Error al subir el archivo {0}\n\n{1}');</script>", fuDocumento.FileName, ex.Message), false);
            }
            Mensaje(subida ? "Archivo subido con éxito" : "No se pudo subir el archivo seleccionado");
            GetDocs(_idSolicitud);
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


        public int AddHSubsidio(int idSolicitud)
        {
            var s = new HipotecaSubsidio
                {
                    IdSolicitud = idSolicitud,
                    IdSubsidio = Convert.ToInt32(lblIdSubsidio.Text.Trim()),
                    Monto = txtSubsidioMonto.Text.Trim(),
                    NumeroCuenta = txtSubsidioNumeroCuentaAhorro.Text.Trim(),
                    Ahorro = txtSubsidioAhorroPrevio.Text.Trim(),
                    NumeroSerie = txtSubsidioNumSerie.Text.Trim(),
                    Titulo = dlSubsidioTitulo.SelectedValue,
                    Banco = dlSubsidioBanco.SelectedValue,
                    Beneficiario = dlSubsidioBeneficiario.SelectedValue
                };

           return new HipotecarioBC().AddSubsidio(s);
        }

        private void eliminar_documentos()
        {
            var eliminados = 0;
            for (var idx = 0; idx < gr_documentos.Rows.Count; idx++)
            {
                var row = gr_documentos.Rows[idx];
                if (row.RowType != DataControlRowType.DataRow) continue;
                var idDocumentoOperacion = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[0].ToString());
                var chkDel = (CheckBox)row.FindControl("chk_eliminar");
                if (!chkDel.Checked) continue;
                try
                {
                    new DocumentosOperacionBC().del_documentos(idDocumentoOperacion, Convert.ToString(Session["usrname"]));
                    eliminados += 1;
                    var url = Server.MapPath(gr_documentos.DataKeys[idx].Values[3].ToString());
                    var fiDoc = new FileInfo(url);
                    if (fiDoc.Exists)
                    {
                        fiDoc.Delete();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            Mensaje("Se han eliminado " + eliminados + " documentos.");
            GetDocs(_idSolicitud);
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar_documentos();
        }

        private void add()
        {   
            string tasacion = "0";
            string f_ano = "0";
            string monto_credito = "0";
            string tipo_credito = "0";
            string tipo_propiedad = "0";
            Int16 comuna = 0;
            string precio = "0"; 
            string i_ano = "0";  
            Int32 valor_seguro = 0;
            Int32 valor_liquidez = 0;
            Int32 valor_comercial = 0;

            if (this.dl_tipo_propiedad.SelectedValue.Trim() != "")
            {
                tipo_propiedad = this.dl_tipo_propiedad.SelectedValue;
            }
            if (this.dl_tipo_credito.SelectedValue.Trim() != "")
            {
                tipo_credito = this.dl_tipo_credito.SelectedValue;
            }

            if (this.txt_valor_seguro.Text != "")
            {
                valor_seguro = Convert.ToInt32(this.txt_valor_seguro.Text);
            }
            if (this.txt_valor_liquidez.Text != "")
            {
                valor_liquidez = Convert.ToInt32(this.txt_valor_liquidez.Text);
            }
            if (this.txt_valor_comercial.Text != "")
            {
                valor_comercial = Convert.ToInt32(this.txt_valor_comercial.Text);
            }

            if (this.txt_tasacion.Text != "")
            {
                tasacion =FuncionGlobal.NumeroSinFormato(this.txt_tasacion.Text);
            }
            if (this.txt_f_año.Text != "")
            {
                f_ano =FuncionGlobal.NumeroSinFormato(this.txt_f_año.Text);
            }  
            if (this.txt_monto_credito.Text != "")
            {
                monto_credito = FuncionGlobal.NumeroSinFormato(this.txt_monto_credito.Text);
            }
            if (this.txt_precio.Text != "")
            {
                precio =FuncionGlobal.NumeroSinFormato(this.txt_precio.Text);
            }   
            if (this.txt_i_ano.Text != "")
            {
                i_ano =FuncionGlobal.NumeroSinFormato(this.txt_i_ano.Text);
            }
            if (this.dl_comuna.SelectedValue.Trim() != "")
            {
                comuna =Convert.ToInt16(this.dl_comuna.SelectedValue);
            }
            
           

            var usuario = Convert.ToInt32(lbl_numero.Text.Trim()) == 0
                              ? (string) (Session["usrname"])
                              : new OperacionBC().getoperacion(_idSolicitud).Usuario.UserName;
            var add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), 
                                                            Convert.ToInt16(_idCliente), _tipoOperacion,
                                                            usuario, 0, this.txt_numero_interno.Text, Convert.ToInt32(this.dl_sucursal_origen.SelectedValue), 0);


            _idSolicitud = add;

           

            if (add != 0)
            {
                if (Convert.ToInt32(lbl_numero.Text) == 0)
                {
                    new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, _tipoOperacion, "", (string)(Session["usrname"]));   
                }
                GetAllInsertos();
                ibCreaBorradorEscritura.Visible = true;
                tpEjecutivos.Visible = true;
                GetDocs(add);
                tbl_participantes.Visible = true;
                tblFinalFojas.Visible = true;
                tblFojas.Visible = true;
                tab_documentos.Visible = true;
                FuncionGlobal.ComboTitulosHipotecaInsertos(dlInsertoTitulos);
                FuncionGlobal.ComboEjecutivosHipotecario(Convert.ToInt16(this.dl_sucursal_origen.SelectedValue), dlEjecutivosHipotecario);
                hpParticipantes.NavigateUrl = "../administracion/admParticipantes.aspx";
                hpCompradorAdicional.NavigateUrl = "../administracion/mParticipanteOperacion.aspx?idSolicitud=" + FuncionGlobal.FuctionEncriptar(add.ToString()) +
                     "&tipo=" + FuncionGlobal.FuctionEncriptar("COMPH");
                hpVendedorAdicional.NavigateUrl = "../administracion/mParticipanteOperacion.aspx?idSolicitud=" + FuncionGlobal.FuctionEncriptar(add.ToString()) +
                     "&tipo=" + FuncionGlobal.FuctionEncriptar("VENDH");
                hpOtrosParticipantes.NavigateUrl = "../administracion/mParticipanteOperacion.aspx?idSolicitud=" + FuncionGlobal.FuctionEncriptar(add.ToString()) +
                     "&tipo=" + FuncionGlobal.FuctionEncriptar("FCS");

                var addHp = new HipotecarioBC().add_hipotecario(add,
                                                                         0, 
                                                                         tipo_propiedad, 
                                                                         Convert.ToInt32(precio),
                                                                         Convert.ToInt32(monto_credito),
                                                                         dlVencimientoPriemraCuota.SelectedValue,
                                                                         Convert.ToInt32(dlPlazoMeses.SelectedValue),
                                                                         Convert.ToInt16(dl_sucursal_origen.SelectedValue),
                                                                         txt_numero_interno.Text.Trim() ,
                                                                         comuna,
                                                                         txt_direccion.Text,
                                                                         txt_numero_direccion.Text,
                                                                         txt_complemento.Text, 
                                                                         tipo_credito.ToString(),
                                                                         Convert.ToInt32(tasacion),
                                                                         Usuario.UserName,  
                                                                         txt_f_caratula.Text,  
                                                                         lblConservador.Text, 
                                                                         Convert.ToInt32(dlMesesGracia.SelectedValue),
                                                                         valor_comercial,
                                                                         txt_comentarios_deslinde.Text,
                                                                         txtPie.Text,
                                                                         dlMescarencia1.SelectedValue,
                                                                         dlMescarencia2.SelectedValue,
                                                                         ckCodeudorSeguro.Checked?Convert.ToByte(1):Convert.ToByte(0),
                                                                         dlCodeudorSeguroPorcentaje.SelectedValue,
                                                                         ckDfl2.Checked? Convert.ToByte(1):Convert.ToByte(0),
                                                                         dlUbicacion.SelectedValue,
                                                                         dlSubProductoCredito.SelectedValue,
                                                                         txtNumeroCredito0.Text,txt_tasa.Text
                                                                         ,Convert.ToByte(ckViviendaSocial.Checked),
                                                                         dlTipoTransferencia.SelectedValue,
                                                                         dlTipoHipoteca.SelectedValue,
                                                                         dlFechaMemo.SelectedValue,
                                                                         ckSeguroInvalidez.Checked?Convert.ToByte(1):Convert.ToByte(0),
                                                                         ckSeguroDesempleo.Checked ? Convert.ToByte(1) : Convert.ToByte(0));



                if (addHp == "")
                {
                    switch (dlSubProductoCredito.SelectedValue)
                    {  
                        case "3":
                            lblIdSubsidio.Text = AddHSubsidio(add).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "4":
                            lblIdSubsidio.Text = AddHSubsidio(add).ToString(CultureInfo.InvariantCulture);
                            break;
                    }
                    add_forma_pago(add);
                    add_prohibicion();
                    add_prohibicionCBR();
                    add_roles();
                   
                }    
            }

            
            lbl_operacion.Visible = true;
            lbl_numero.Visible = true;
            lbl_operacion.Text = "Operación de Hipotecaria Numero:";
            lbl_numero.Text = add.ToString().Trim();
            Mensaje("OPERACION, INGRESADA CON EXITO");   

        }

       
        private void add_forma_pago(int idSolicitud)
        {

            var forma = new Hipoteca_FormaPago();
            forma.IdSolicitud = idSolicitud;
            forma.CuotaFinalTasaFija = Convert.ToInt32(dlFinTasafija.SelectedValue);
            forma.TasaFija = txt_tasa.Text.Trim();
            forma.ValorDividendoTasaFija = txtValorDividendo.Text.Trim();
            forma.ValorDividendoTasaMixta = txtValorDividendoTasaMixta.Text.Trim();
            forma.CuotainicioTasaMixta = Convert.ToInt32(dlInicioTasaMixta.SelectedValue);
            forma.TasaMixta = txtTasaMixta.Text.Trim();
            forma.IdFormaPago = Convert.ToInt32(lblIdFormaPago.Text.Trim());
            forma.ValorPrimerosDividendos = txtPrimerosDividendos.Text.Trim();
            forma.ValorUltimoDividendo = txtUltimoDividendo.Text.Trim();
            new HipotecarioBC().add_forma_pago(forma); 
            
        }


        private void add_roles()
        {     
            for (var i = 0; i < grRoles.Rows.Count; i++)
            { 
                var idRol = Convert.ToInt32(grRoles.DataKeys[i].Value);
                var numeroRol = grRoles.Rows[i].Cells[1].Text;   
                new HipotecaRolBC().AddHipotecarioRol(_idSolicitud, numeroRol, idRol);  
            }
        }



        private void add_prohibicion()
        {
            GridViewRow row;

            var e = 1;
            for (var i = 0; i < gr_prohibicion.Rows.Count; i++)
            { 
                var idPro =Convert.ToInt32(gr_prohibicion.DataKeys[i].Value);

                string codigo = gr_prohibicion.Rows[i].Cells[2].Text;
                string fojas = gr_prohibicion.Rows[i].Cells[4].Text;
                string letra = gr_prohibicion.Rows[i].Cells[5].Text;
                string numero = gr_prohibicion.Rows[i].Cells[6].Text;
                string ano = gr_prohibicion.Rows[i].Cells[7].Text;
                string afavor = gr_prohibicion.Rows[i].Cells[8].Text;
                string comuna = gr_prohibicion.Rows[i].Cells[9].Text;
                string comentario = gr_prohibicion.Rows[i].Cells[10].Text;

                Int32 add = new HipotecarioBC().add_prohibicion(_idSolicitud, fojas, numero, Convert.ToInt32( ano), "", comuna, codigo,idPro,afavor,comentario, letra);

                DataTable dt = new DataTable();
                dt = (DataTable)Session["tabla_acreedor"];

                if (dt != null)
                {
                   
                    foreach (DataRow rowW in dt.Rows)
                    {
                      
                        Int32 id_gr = Convert.ToInt32(rowW["id_gr_pro"]);
                        if(e==id_gr)
                        {
                           string addc = new AcreedorBC().add_acreedor(Convert.ToInt32(add), Convert.ToInt32(rowW["rut_acreedor"]));
                        }
                    }
                }
                e++;
            }  
        }


        public void ComboMesesGracia()
        {
             for(var i=0;i<7;i++)
             {
                 dlMesesGracia.Items.Add(i.ToString());
             }
        }

        private void add_prohibicionCBR()
        {
            GridViewRow row;

            int e = 1;
            for (int i = 0; i < this.gr_prohibicionCBR.Rows.Count; i++)
            {

                row = gr_prohibicionCBR.Rows[i];
                Int32 id_pro = Convert.ToInt32(this.gr_prohibicionCBR.DataKeys[i].Value);

                string codigo = this.gr_prohibicionCBR.Rows[i].Cells[2].Text;
                string fojas = this.gr_prohibicionCBR.Rows[i].Cells[4].Text;
                string letra = this.gr_prohibicionCBR.Rows[i].Cells[5].Text;
                string numero = this.gr_prohibicionCBR.Rows[i].Cells[6].Text;
                string ano = this.gr_prohibicionCBR.Rows[i].Cells[7].Text;
                string afavor = this.gr_prohibicionCBR.Rows[i].Cells[8].Text;
                string comuna = this.gr_prohibicionCBR.Rows[i].Cells[9].Text;
                string comentario = this.gr_prohibicionCBR.Rows[i].Cells[10].Text;

                Int32 add = new HipotecarioBC().add_prohibicion(_idSolicitud, fojas, numero, Convert.ToInt16(ano), "", comuna, codigo, id_pro, afavor,comentario, letra);

                DataTable dt = new DataTable();
                dt = (DataTable)Session["tabla_acreedor"];

                if (dt != null)
                {

                    foreach (DataRow rowW in dt.Rows)
                    {

                        Int32 id_gr = Convert.ToInt32(rowW["id_gr_pro"]);
                        if (e == id_gr)
                        {
                            new AcreedorBC().add_acreedor(Convert.ToInt32(add), Convert.ToInt32(rowW["rut_acreedor"]));
                        }
                    }
                }
                e++;
            }
        }

        private void busca_operacion()
        {
            // DESCOMENTARIAR
            var mhipotecaria = new HipotecarioBC().gethipotecario(_idSolicitud);

            if (mhipotecaria == null) return;
            dl_sucursal_origen.SelectedValue = mhipotecaria.Sucursal.Id_sucursal.ToString().Trim();
            dl_cliente.SelectedValue = mhipotecaria.Operacion.Cliente.Id_cliente.ToString().Trim();
             
            var mcomuna = new ComunaBC().getComuna(Convert.ToInt16(mhipotecaria.IdComuna));
            if (mcomuna.Id_Comuna != 0)
            {
                var m = new CiudadBC().getciudad(Convert.ToInt16(mcomuna.Ciudad.Id_Ciudad));

                dl_region.SelectedValue = m.Region.Id_region.ToString();
                FuncionGlobal.combociudad(dl_ciudad, Convert.ToInt16(dl_region.SelectedValue));
                dl_ciudad.SelectedValue = mcomuna.Ciudad.Id_Ciudad.ToString().Trim();
                FuncionGlobal.combocomuna(dl_comuna, Convert.ToInt16(dl_ciudad.SelectedValue));
                dl_comuna.SelectedValue = mhipotecaria.IdComuna.ToString().Trim();
            }
            dlFechaMemo.SelectedValue = mhipotecaria.FechaMemo.Trim();
            dlTipoHipoteca.SelectedValue = mhipotecaria.TipoHipoteca.Trim();
            dlTipoTransferencia.SelectedValue = mhipotecaria.TipoTransferencia.Trim();
            dl_tipo_propiedad.SelectedValue = mhipotecaria.TipoPropiedad.Trim(); 
            txt_complemento.Text = mhipotecaria.Complemento;
            dlPlazoMeses.SelectedValue = mhipotecaria.PlazoAnos.ToString();
            txt_direccion.Text = mhipotecaria.Direccion;  
            txt_i_ano.Text = mhipotecaria.InscripcionAno.ToString();
            txt_i_fojas.Text = mhipotecaria.InscripcionFojas;
            txt_i_numero.Text = mhipotecaria.InscripcionNumero;
            txt_monto_credito.Text = mhipotecaria.MontoCredito.ToString(); 
            txt_numero_direccion.Text = mhipotecaria.Numero;
            txt_precio.Text = mhipotecaria.PrecioVivienda.ToString(); 
            txt_f_año.Text = mhipotecaria.FinalAno.ToString();
            txt_f_caratula.Text = mhipotecaria.FinalCaratula;  
            txt_f_fojas.Text = mhipotecaria.FinalFojas;
            txt_f_numero.Text = mhipotecaria.FinalNumero; 
            dl_tipo_credito.SelectedValue = mhipotecaria.TipoCredito.Trim();  
            txt_valor_comercial.Text = mhipotecaria.ValorComercial.ToString(); 
            lbl_tasador.Visible = false;
            dl_tasador.Visible = false;
            tab_tasador.Visible = false;  
            txt_tasacion.Text = mhipotecaria.Tasacion.ToString(CultureInfo.InvariantCulture);
            txt_numero_interno.Text = mhipotecaria.NumeroInterno;
            
            ckDfl2.Checked = Convert.ToBoolean(mhipotecaria.Dfl2);
            ckViviendaSocial.Checked = Convert.ToBoolean(mhipotecaria.ViviendaSocial);
            ckViviendaSocial.Visible = ckDfl2.Checked;
            dlUbicacion.SelectedValue = mhipotecaria.TipoUbicacion.Trim();
            dlSubProductoCredito.SelectedValue = mhipotecaria.SubProductoCredito.Trim(); 
            txtTasa.Enabled = dlSubProductoCredito.SelectedValue == "1";
            switch (dlSubProductoCredito.SelectedValue)
            {
                case "2":
                    txtTasa.Text = "0";
                    txt_tasa.Enabled = true;
                    txtTasaMixta.Enabled = true;
                    panel_subsidio.Visible = false;
                    break;
                case "1":
                    txt_tasa.Text = txtTasa.Text.Trim();
                    txtTasaMixta.Text = txtTasa.Text.Trim();
                    txt_tasa.Enabled = false;
                    txtTasaMixta.Enabled = false;
                    panel_subsidio.Visible = false;
                    break;
                case "3":
                    txt_tasa.Text = txtTasa.Text.Trim();
                    txtTasaMixta.Text = txtTasa.Text.Trim();
                    txt_tasa.Enabled = false;
                    txtTasaMixta.Enabled = false;
                    panel_subsidio.Visible = true; 
                    break;
            }
            txtNumeroCredito0.Text = mhipotecaria.NumeroCredito;
            txtTasa.Text = mhipotecaria.Tasa;
            txtPie.Text = mhipotecaria.Pie;
            dlMesesGracia.SelectedValue = mhipotecaria.MesesGracia.Trim();
            dlVencimientoPriemraCuota.SelectedValue = mhipotecaria.VctoPrimeraCuota.Trim();
            dlMescarencia1.SelectedValue = mhipotecaria.MesCarenciaUno.Trim();
            dlMescarencia2.SelectedValue = mhipotecaria.MesCarenciaDos.Trim();
            ckCodeudorSeguro.Checked = Convert.ToBoolean(mhipotecaria.CodeudorConSeguro);
            dlCodeudorSeguroPorcentaje.SelectedValue = mhipotecaria.CodeudorPorcentaje.Trim();
            txt_tasa.Text = txtTasa.Text;
            trPorcsegurocodeudordescripcion.Visible = ckCodeudorSeguro.Checked;
            trPorcsegurocodeudor.Visible = ckCodeudorSeguro.Checked;
            lblConservador.Text = mhipotecaria.FinalConservador.ToUpper();
            txt_comentarios_deslinde.Text = mhipotecaria.DescripcionDeslindes;
            ckSeguroDesempleo.Checked = Convert.ToBoolean(mhipotecaria.SeguroCesantia);
            ckSeguroInvalidez.Checked = Convert.ToBoolean(mhipotecaria.SeguroInvalidez);
          
            busca_forma_pago();
            busca_prohibicion();
            busca_prohibicionCBR();
            busca_Roles();
            BuscaSubsidio();                    

            lbl_operacion.Visible = true;
            lbl_numero.Visible = true;
            lbl_operacion.Text = "Operación de Transferencia Numero:";
            lbl_numero.Text = Convert.ToString(_idSolicitud);
           
        }

        public void BuscaSubsidio()
        {
            var s = new HipotecarioBC().GetSubsidio(_idSolicitud);
            if(s.IdSolicitud==0)return;
            txtSubsidioMonto.Text = s.Monto.Trim();
            txtSubsidioAhorroPrevio.Text = s.Ahorro.Trim();
            txtSubsidioNumeroCuentaAhorro.Text = s.NumeroCuenta.Trim();
            txtSubsidioNumSerie.Text = s.NumeroSerie.Trim();
            dlSubsidioBanco.SelectedValue = s.Banco.Trim();
            dlSubsidioTitulo.SelectedValue = s.Titulo.Trim();
            dlSubsidioBeneficiario.SelectedValue = s.Beneficiario.Trim();
            lblIdSubsidio.Text = s.IdSubsidio.ToString(CultureInfo.InvariantCulture).Trim();
        }


        private void busca_forma_pago()
        {   
           var lformapago = new HipotecarioBC().GetFormaPago(_idSolicitud);
            if (lformapago.IdFormaPago == 0) return;
            dlInicioTasaMixta.SelectedValue = lformapago.CuotainicioTasaMixta.ToString(CultureInfo.InvariantCulture).Trim();
            dlFinTasafija.SelectedValue = lformapago.CuotaFinalTasaFija.ToString(CultureInfo.InvariantCulture).Trim();
            txt_tasa.Text = String.IsNullOrEmpty(lformapago.TasaFija.Trim()) ? "0" : lformapago.TasaFija.Trim();
            txtTasaMixta.Text = String.IsNullOrEmpty(lformapago.TasaMixta.Trim()) ? "0" : lformapago.TasaMixta.Trim(); 
            txtValorDividendo.Text = lformapago.ValorDividendoTasaFija.Trim();
            txtValorDividendoTasaMixta.Text = String.IsNullOrEmpty(lformapago.ValorDividendoTasaMixta.Trim()) ? "0" : lformapago.ValorDividendoTasaMixta.Trim(); 
            lblIdFormaPago.Text = lformapago.IdFormaPago.ToString(CultureInfo.InvariantCulture).Trim();
            txtUltimoDividendo.Text = lformapago.ValorUltimoDividendo.Trim();
            txtPrimerosDividendos.Text = lformapago.ValorPrimerosDividendos.Trim();
        }


        private void busca_prohibicion()
        {

            if (ViewState["dt_Prohibicion"] == null) this.DataTableProhibicion();

            var dt = (DataTable)ViewState["dt_Prohibicion"];

            var lprohibicion =
            from p in new HipotecarioBC().getProhibicion(_idSolicitud)
            where p.Tipo_prohibicion.Trim() != "4" && p.Tipo_prohibicion.Trim() != "5" && p.Tipo_prohibicion.Trim() != "6"
            select p;
            int i = 1;
            foreach (Hipoteca_Prohibicion fp in lprohibicion)
            {
                DataRow dr = dt.NewRow();
                            
                dr["cod_tipo"] = fp.Tipo_prohibicion;
                dr["id_prohibicion"] = fp.Id_prohibicion; 
                dr["tipo"] = new ParametroBC().getparametro("TIPROH", fp.Tipo_prohibicion).Valoralfanumerico;  
                dr["fojas"] = fp.Fojas;
                dr["letra"] = fp.Letra;
                dr["numero"] = fp.Numero;
                dr["ano"] = fp.Numero;
                dr["comuna"] = fp.Comuna;
                dr["a_favor"] = fp.AfavorDe;
                dr["url_acreedor"] = "../administracion/mAcreedor.aspx?id_prohibicion=" + FuncionGlobal.FuctionEncriptar(fp.Id_prohibicion.ToString())+"&id_gr_prohibicion="+FuncionGlobal.FuctionEncriptar(i.ToString());
                dt.Rows.Add(dr);
                i++;
            }

            this.gr_prohibicion.DataSource = dt;
            this.gr_prohibicion.DataBind();
        }

        private void busca_Roles()
        {   
            if (ViewState["dt_rol"] == null) DataTableRoles();  
            var dt = (DataTable)ViewState["dt_rol"];
            var lista = new HipotecaRolBC().Get_hipoteca_roles(_idSolicitud); 
            foreach (var r in lista)
            {
                var dr = dt.NewRow();

                dr["idRol"] = r.IdRol;
                dr["numeroRol"] = r.NumeroRol;  
                dt.Rows.Add(dr);
            }  
            grRoles.DataSource = dt;
            grRoles.DataBind();
        }

        private void busca_prohibicionCBR()
        {

            if (ViewState["dt_ProhibicionCBR"] == null) this.DataTableProhibicionCBR();

            DataTable dt = (DataTable)ViewState["dt_ProhibicionCBR"];

            var lprohibicion =
            from p in  new HipotecarioBC().getProhibicion(_idSolicitud)
            where p.Tipo_prohibicion.Trim() != "1" && p.Tipo_prohibicion.Trim() != "2" && p.Tipo_prohibicion.Trim() != "3" && p.Tipo_prohibicion.Trim() != "7"
            select p;

            int i = 1;
            foreach (Hipoteca_Prohibicion fp in lprohibicion)
            {
                DataRow dr = dt.NewRow();

                dr["cod_tipo"] = fp.Tipo_prohibicion;
                dr["id_prohibicion"] = fp.Id_prohibicion;
                dr["tipo"] = new ParametroBC().getparametro("TIPROH", fp.Tipo_prohibicion).Valoralfanumerico;
                dr["fojas"] = fp.Fojas;
                dr["numero"] = fp.Numero;
                dr["letra"] = fp.Letra;
                dr["ano"] = fp.Numero;
                dr["comuna"] = fp.Comuna;
                dr["a_favor"] = fp.AfavorDe;
                dr["comentario"] = fp.Comentario;
                dr["url_acreedor"] = "../administracion/mAcreedor.aspx?id_prohibicion=" + FuncionGlobal.FuctionEncriptar(fp.Id_prohibicion.ToString()) + "&id_gr_prohibicion=" + FuncionGlobal.FuctionEncriptar(i.ToString());
                dt.Rows.Add(dr);
                i++;
            }

            this.gr_prohibicionCBR.DataSource = dt;
            this.gr_prohibicionCBR.DataBind();
        }

        protected void carga_link()
        {
            int i;
            GridViewRow row;
            ImageButton but;
            for (i = 0; i < gr_prohibicion.Rows.Count; i++)
            {
                row = gr_prohibicion.Rows[i];
                Cliente mcleinte = new ClienteBC().getcliente(Convert.ToInt16(row.Cells[0].Text));
                if (row.RowType == DataControlRowType.DataRow)
                {
                    but = (ImageButton)row.FindControl("ib_personero");
                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('mParticipante.aspx?rut=" + FuncionGlobal.FuctionEncriptar(mcleinte.Persona.Rut.ToString()) + "','_blank','height=355,width=700, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=no,copyhistory= false')");
                }
            }
        }
           

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dl_cliente.SelectedValue=="0")return;
            txt_p_a_favor_deCBR.Text = dl_cliente.SelectedItem.ToString();
        }



        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //DESCOMENTARIAR
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        }

        protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conservador mcon = new ConservadorBC().getconservador(Convert.ToInt16(this.dl_comuna.SelectedValue));

            if (mcon != null)
            {
                lblConservador.Text = mcon.Nombre.Trim();
               
            }
        }  
       

        private void DataTableProhibicion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fila", Type.GetType("System.Int32"));
            dt.Columns.Add(new DataColumn("id_prohibicion"));
            dt.Columns.Add(new DataColumn("cod_tipo"));
            dt.Columns.Add(new DataColumn("tipo"));
            dt.Columns.Add(new DataColumn("fojas"));
            dt.Columns.Add(new DataColumn("numero"));
            dt.Columns.Add(new DataColumn("ano"));
            dt.Columns.Add(new DataColumn("letra"));
            dt.Columns.Add(new DataColumn("comuna"));
            dt.Columns.Add(new DataColumn("url_acreedor"));
            dt.Columns.Add(new DataColumn("a_favor"));
            dt.Columns.Add(new DataColumn("comentario"));
            dt.Columns["fila"].AutoIncrement = true;
            dt.Columns["fila"].AutoIncrementSeed = 1;
            ViewState["dt_Prohibicion"] = dt;
        }


        protected void Limpiar_DataTableProhibicion()
        {
            ViewState["dt_Prohibicion"] = null;
            this.gr_prohibicion.DataSource = null;
            this.gr_prohibicion.DataBind();
        }

        private void DataTableProhibicionCBR()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fila", Type.GetType("System.Int32"));
            dt.Columns.Add(new DataColumn("id_prohibicion"));
            dt.Columns.Add(new DataColumn("cod_tipo"));
            dt.Columns.Add(new DataColumn("tipo"));
            dt.Columns.Add(new DataColumn("fojas"));
            dt.Columns.Add(new DataColumn("letra"));
            dt.Columns.Add(new DataColumn("numero"));
            dt.Columns.Add(new DataColumn("ano"));
            dt.Columns.Add(new DataColumn("comuna"));
            dt.Columns.Add(new DataColumn("url_acreedor"));
            dt.Columns.Add(new DataColumn("comentario"));
            dt.Columns.Add(new DataColumn("a_favor"));
            dt.Columns["fila"].AutoIncrement = true;
            dt.Columns["fila"].AutoIncrementSeed = 1;
            ViewState["dt_ProhibicionCBR"] = dt;
        }

        private void DataTableRoles()
        {
            var dt = new DataTable();
            dt.Columns.Add("fila", Type.GetType("System.Int32"));
            dt.Columns.Add(new DataColumn("idRol"));
            dt.Columns.Add(new DataColumn("numeroRol"));
            dt.Columns["fila"].AutoIncrement = true;
            dt.Columns["fila"].AutoIncrementSeed = 1;
            ViewState["dt_rol"] = dt;
        }

        protected void Limpiar_DataTableRoles()
        {
            ViewState["dt_rol"] = null;
            this.grRoles.DataSource = null;
            this.grRoles.DataBind();
        }

        protected void Limpiar_DataTableProhibicionCBR()
        {
            ViewState["dt_ProhibicionCBR"] = null;
            this.gr_prohibicionCBR.DataSource = null;
            this.gr_prohibicionCBR.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (this.dl_tipo_prohibicion.SelectedValue != "0")
            {
                if (ViewState["dt_Prohibicion"] == null) this.DataTableProhibicion();

                DataTable dt = (DataTable)ViewState["dt_Prohibicion"];
                DataRow dr = dt.NewRow();
                dr["cod_tipo"] = this.dl_tipo_prohibicion.SelectedValue;
                dr["id_prohibicion"] = 0;
                dr["tipo"] = this.dl_tipo_prohibicion.SelectedItem.Text;
                dr["fojas"] = this.txt_p_fojas.Text.Trim();
                dr["numero"] = this.txt_p_numero.Text.Trim();
                dr["letra"] = this.txt_p_letra.Text.Trim();
                dr["ano"] = this.txt_p_ano.Text.Trim();
                dr["comuna"] = this.lblConservador.Text.Trim();
                dr["a_favor"] = this.txt_p_a_favor_de.Text;
                dr["comentario"] = this.txt_p_comentario.Text;

                string id_gr_prohibicion = (dt.Rows.Count + 1).ToString();

                dr["url_acreedor"] = "../administracion/mAcreedor.aspx?id_prohibicion=" + FuncionGlobal.FuctionEncriptar("0") + "&id_gr_prohibicion=" + FuncionGlobal.FuctionEncriptar(id_gr_prohibicion);
                dt.Rows.Add(dr);

                this.gr_prohibicion.DataSource = dt;
                this.gr_prohibicion.DataBind();

                txt_p_letra.Text = "";
                this.txt_p_fojas.Text = "";
                this.txt_p_numero.Text = "";
                this.txt_p_ano.Text = "";
                txt_p_a_favor_de.Text = "";
                txt_p_comentario.Text = "";


            }
            else
            {
                 UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

                    FuncionGlobal.alerta_updatepanel("Debe ingresar el Tipo de Prohibicion", Page, up);
                    return;
            }
        }  
       

        protected void gr_prohibicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 fila;

            fila = this.gr_prohibicion.SelectedIndex;

            DataTable dt = (DataTable)ViewState["dt_Prohibicion"];

            Int32 id_prohibicion = Convert.ToInt32(gr_prohibicion.DataKeys[fila].Value);

            string del = new HipotecarioBC().del_prohibicion(id_prohibicion);

            dt.Rows.RemoveAt(fila);

            this.gr_prohibicion.DataSource = dt;
            this.gr_prohibicion.DataBind();
        }

        protected void gr_prohibicionCBR_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 fila;

            fila = this.gr_prohibicionCBR.SelectedIndex;

            DataTable dt = (DataTable)ViewState["dt_Prohibicion"];

            Int32 id_prohibicion = Convert.ToInt32(gr_prohibicionCBR.DataKeys[fila].Value);

            string del = new HipotecarioBC().del_prohibicion(id_prohibicion);

            dt.Rows.RemoveAt(fila);

            this.gr_prohibicionCBR.DataSource = dt;
            this.gr_prohibicionCBR.DataBind();
        }

        protected void gr_roles_SelectedIndexChanged(object sender, EventArgs e)
        {  
            var fila = grRoles.SelectedIndex;  
            var dt = (DataTable)ViewState["dt_rol"];
            var idRol = Convert.ToInt32(grRoles.DataKeys[fila].Value); 
            new HipotecaRolBC().DelHipotecarioRol(idRol); 
            dt.Rows.RemoveAt(fila);  
            grRoles.DataSource = dt;
            grRoles.DataBind();
        }
            
        protected void txt_i_ano_TextChanged(object sender, EventArgs e)
        {
            ValidaAnio(txt_i_ano);
        }

        public void ValidaAnio(TextBox txt)
        {
            var anio = txt.Text.Trim();
            if (Convert.ToInt32(anio) >= 1980 && Convert.ToInt32(anio) <= DateTime.Now.Year) return;
            txt.Text = "0";
            FuncionGlobal.alerta_updatepanel("Fecha incorrecta", Page, updatePropiedad);
        }  

        protected void dl_tasador_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (lbl_numero.Visible == true)
            {
                string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(this.lbl_numero.Text), 11, _tipoOperacion, "", (string)(Session["usrname"]));
            }
        }  


        public void AgregarParticipanteOperacion(int rut ,string tipo)
        {  
            new ParticipeOperacionBC().add_participe(_idSolicitud, rut, tipo);   
            Mensaje("Se ha agregado un nuevo participante.");
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje,Page,updateP);
        }

        protected void ibActualiza_Click(object sender, ImageClickEventArgs e)
        {
            
            if(Convert.ToInt32(lbl_numero.Text)!=0)
            {
                compradores1.GetParticipantes(Convert.ToInt32(lbl_numero.Text));
            }
        }

        protected void txt_p_ano_TextChanged(object sender, EventArgs e)
        {
            ValidaAnio(txt_p_ano);
        }    
      
     
        protected void btnAgregarFinalFoja_Click(object sender, EventArgs e)
        {
            if (txt_f_año.Text.Trim() == "" || txt_f_fojas.Text.Trim() == "" || txt_f_numero.Text.Trim() == "" || txt_f_letra.Text.Trim()=="")
            { Mensaje("Ingrese los datos que corresponde -Final Foja número letra -Final Foja año -Final Foja Inscripción"); return; }

            var f = new hipotecaFoja
                {
                    IdFoja = 0,
                    IdSolicitud = Convert.ToInt32(lbl_numero.Text.Trim()),
                    CodigoTipo = "FFOJA",
                    InscripcionFoja = txt_f_fojas.Text.Trim(),
                    InscripcionAnio = txt_f_año.Text.Trim(),
                    InscripcionNumero = txt_f_numero.Text.Trim(),
                    InscripcionFojaLetra = txt_f_letra.Text.Trim(),
                    Observacion =
                        txt_observacionFinalFoja.Text == "Escribe una observación..."
                            ? ""
                            : txt_observacionFinalFoja.Text
                };

            FojasFinal.AddFojas(f);
            FojasFinal.GetAllFojasbyTipo(Convert.ToInt32(lbl_numero.Text.Trim()), "FFOJA");
            txt_f_año.Text = "";
            txt_f_fojas.Text = "";
            txt_f_numero.Text = "";
            txt_f_letra.Text = "";
            txt_observacionFinalFoja.Text = "Escribe una observación...";
        }


        protected void ib_add_rol_Click(object sender, ImageClickEventArgs e)
        {
           if (ViewState["dt_rol"] == null) DataTableRoles();

            var dt = (DataTable)ViewState["dt_rol"];
            var dr = dt.NewRow();
            dr["idRol"] = 0;
            dr["numeroRol"] = txtNRol.Text.Trim();  
            dt.Rows.Add(dr);

            grRoles.DataSource = dt;
            grRoles.DataBind();
            txtNRol.Text = "";

        }

        protected void ib_prohibicionCBR_Click(object sender, ImageClickEventArgs e)
        {
            if (this.dl_tipo_prohibicionCBR.SelectedValue != "0")
            {
                if (ViewState["dt_ProhibicionCBR"] == null) this.DataTableProhibicionCBR();

                DataTable dt = (DataTable)ViewState["dt_ProhibicionCBR"];
                DataRow dr = dt.NewRow();
                dr["cod_tipo"] = this.dl_tipo_prohibicionCBR.SelectedValue;
                dr["id_prohibicion"] = 0;
                dr["tipo"] = this.dl_tipo_prohibicionCBR.SelectedItem.Text;
                dr["fojas"] = this.txt_p_fojasCBR.Text.Trim();
                dr["numero"] = this.txt_p_numeroCBR.Text.Trim();
                dr["letra"] = this.txt_p_fojasLetraCBR.Text.Trim();
                dr["ano"] = this.txt_p_anoCBR.Text.Trim();
                dr["comuna"] = this.lblConservador.Text.Trim();
                dr["a_favor"] = this.txt_p_a_favor_deCBR.Text;
                dr["comentario"] = this.txt_p_comentarioCBR.Text;

                string id_gr_prohibicion = (dt.Rows.Count + 1).ToString();

                dr["url_acreedor"] = "../administracion/mAcreedor.aspx?id_prohibicion=" + FuncionGlobal.FuctionEncriptar("0") + "&id_gr_prohibicion=" + FuncionGlobal.FuctionEncriptar(id_gr_prohibicion);
                dt.Rows.Add(dr);

                this.gr_prohibicionCBR.DataSource = dt;
                this.gr_prohibicionCBR.DataBind();

                txt_p_fojasLetraCBR.Text = "";
                this.txt_p_fojasCBR.Text = "";
                this.txt_p_numeroCBR.Text = "";
                this.txt_p_anoCBR.Text = "";
                txt_p_comentarioCBR.Text = "";
                txt_p_a_favor_de.Text = dl_cliente.SelectedItem.Text;

            }
            else
            {
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

                FuncionGlobal.alerta_updatepanel("Debe ingresar el Tipo de Prohibicion", Page, up);
                return;
            }
        }

        protected void txt_p_anoCBR_TextChanged(object sender, EventArgs e)
        {
            ValidaAnio(txt_p_anoCBR);
        }

        protected void btnAgregarEjecutivo_Click(object sender, EventArgs e)
        {
            var h = new HipotecaOperacionEjecutivo();
            h.IdEjecutivo = Convert.ToInt32(dlEjecutivosHipotecario.SelectedValue);
            h.IdSolicitud = Convert.ToInt32(lbl_numero.Text.Trim()); 
            try
            {
              Mensaje(EjecutivosHipotecario.AddEjecutivoOperacion(h));
            }
            catch (Exception ex)
            {
               Mensaje(ex.Message);
                throw;
            }   

        }

        protected void dl_sucursal_origen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.ComboEjecutivosHipotecario(Convert.ToInt32(dl_sucursal_origen.SelectedValue),dlEjecutivosHipotecario);
        }

        protected void dlMesesGracia_SelectedIndexChanged(object sender, EventArgs e)
        {
            dlVencimientoPriemraCuota.SelectedValue = dlMesesGracia.SelectedValue;
        }

        protected void ckCodeudorSeguro_CheckedChanged(object sender, EventArgs e)
        {    
            trPorcsegurocodeudor.Visible = ckCodeudorSeguro.Checked;
            trPorcsegurocodeudordescripcion.Visible = ckCodeudorSeguro.Checked;
        }

        protected void ckDfl2_CheckedChanged(object sender, EventArgs e)
        {
            ckViviendaSocial.Visible = ckDfl2.Checked;
            if(!ckDfl2.Checked)
            {
                ckViviendaSocial.Checked = false;
            }
        }


        public void CrearBorrador()
        {
            try
            {
            switch (dlTipoDoc.SelectedValue)
            {
                case "BORR":
                        new HipotecarioBC().add_escritura_pendiente_hipoteca(Convert.ToInt32(lbl_numero.Text.Trim()));
                        Mensaje("Documento en proceso de creación. Por favor espere unos segundos.");
                        tab_opciones.ActiveTab = tab_documentos;
                        GetDocs(Convert.ToInt32(lbl_numero.Text));
                break;
                   
            }   
               
            }
            catch (Exception e)
            {
                Mensaje("No se a podido crear el borrador debido a: "+e.Message);
            }
           
        }
      
        protected void txtTasa_TextChanged(object sender, EventArgs e)
        {
            txt_tasa.Text = txtTasa.Text.Trim();
        }

        protected void dlSubProductoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTasa.Enabled = dlSubProductoCredito.SelectedValue == "1";
            switch (dlSubProductoCredito.SelectedValue)
            {
                case "2":
                    txtTasa.Text = "0";
                    txt_tasa.Enabled = true;
                    txtTasaMixta.Enabled = true;
                    panel_subsidio.Visible = false;
                    break;
                case "1":
                    txt_tasa.Text = txtTasa.Text.Trim();
                    txtTasaMixta.Text = txtTasa.Text.Trim();
                    txt_tasa.Enabled = false;
                    txtTasaMixta.Enabled = false;
                    panel_subsidio.Visible = false;
                    break;
                case "3":
                    txt_tasa.Text = txtTasa.Text.Trim();
                    txtTasaMixta.Text = txtTasa.Text.Trim();
                    txt_tasa.Enabled = false;
                    txtTasaMixta.Enabled = false;
                    panel_subsidio.Visible = true;
                    break;
            }
        }

        protected void ibCreaBorradorEscritura_Click(object sender, ImageClickEventArgs e)
        {
           CrearBorrador();
        }

        protected void ibRefrescar_Click(object sender, ImageClickEventArgs e)
        {
           GetDocs(Convert.ToInt32(lbl_numero.Text));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");


            if (this.dl_sucursal_origen.SelectedValue.Trim() == "0")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la Sucursal de Origen", Page, up);
                return;
            }

            if (this.txt_numero_interno.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar el Numero Interno", Page, up);
                return;
            }


            if (_tipoOperacion.Trim() != "ALHIP")
            {
                if (this.dl_comuna.SelectedValue.Trim() == "0" || this.dl_comuna.SelectedValue.Trim() == "")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar la Comuna de la propiedad", Page, up);
                    return;
                }

                if (this.dl_tipo_propiedad.SelectedValue.Trim() == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el Tipo de Propiedad", Page, up);
                    return;
                }
                if (this.dl_tipo_credito.SelectedValue.Trim() == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el Tipo de Credito", Page, up);
                    return;
                }
            }


            add();
        }

        protected void ibAgregarFojas_Click(object sender, ImageClickEventArgs e)
        {
            if (txt_i_ano.Text.Trim() == "" || txt_i_fojas.Text.Trim() == "" || txt_i_numero.Text.Trim() == "")
            { Mensaje("Ingrese los datos que corresponde -Foja número -Foja año -Foja Inscripción"); return; }

            var f = new hipotecaFoja();

            f.IdFoja = 0;
            f.IdSolicitud = Convert.ToInt32(lbl_numero.Text.Trim());
            f.CodigoTipo = "FOJA";
            f.InscripcionFoja = txt_i_fojas.Text.Trim();
            f.InscripcionAnio = txt_i_ano.Text.Trim();
            f.InscripcionNumero = txt_i_numero.Text.Trim();
            f.Observacion = txt_i_observacion.Text == "Escribe una observación..." ? "" : txt_i_observacion.Text;
            f.InscripcionFojaLetra = txt_i_fojas_letras.Text;

            Fojas1.AddFojas(f);
            Fojas1.GetAllFojasbyTipo(Convert.ToInt32(lbl_numero.Text.Trim()), "FOJA");

            txt_i_ano.Text = "";
            txt_i_fojas.Text = "";
            txt_i_numero.Text = "";
            txt_i_observacion.Text = "Escribe una observación...";
            txt_i_fojas_letras.Text = "";
        }

        protected void dlFinTasafija_SelectedIndexChanged(object sender, EventArgs e)
        {
            dlInicioTasaMixta.SelectedValue = dlFinTasafija.SelectedValue=="0" ? "0" : (Convert.ToInt32(dlFinTasafija.SelectedValue) + 1).ToString(CultureInfo.InvariantCulture);
        }

        protected void btnInsertoSubir_Click(object sender, EventArgs e)
        {
             if(dlInsertoTitulos.SelectedValue=="0"|| txtInsertoTexto.Text.Trim()=="")return;
            var inserto = new HipotecaInserto();
            inserto.IdInserto = Convert.ToInt32(lblIdInserto.Text.Trim());
            inserto.IdInsertoTitulo = Convert.ToInt32(dlInsertoTitulos.SelectedValue);
            inserto.Texto = FuncionGlobal.NumerosALetras(txtInsertoTexto.Text);
            inserto.CuentaUsuario = Session["usrname"].ToString().Trim();
            inserto.IdSolicitud = Convert.ToInt32(lbl_numero.Text.Trim());

            new HipotecaInsertoBC().AddInserto(inserto);
            txtInsertoTexto.Text = "";
            dlInsertoTitulos.SelectedValue = "0";
            GetAllInsertos();
            Mensaje("Agregado correctamente");

        }

        public void GetAllInsertos()
        {
           
            var lista = new HipotecaInsertoBC().GetAllInserto(Convert.ToInt32(lbl_numero.Text));
            

            var dt = new DataTable();
            
            dt.Columns.Add(new DataColumn("nombre")); 
            dt.Columns.Add(new DataColumn("fecha"));  
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("id_inserto_hipoteca"));
            dt.Columns.Add(new DataColumn("id_inserto"));

            foreach (var x in lista)
            {
                var dr = dt.NewRow();

                dr["nombre"] = x.InsertoTitulo.Descripcion;
                dr["fecha"] = x.Fecha;
                dr["usuario"] = x.Usuario.Nombre;
                dr["id_inserto_hipoteca"] = x.IdInserto;
                dr["id_inserto"] = x.IdInsertoTitulo;
                dt.Rows.Add(dr);
            }
            gr_insertos.DataSource = dt;
            gr_insertos.DataBind();  
        }

        protected void btnInsertoEliminar_Click(object sender, EventArgs e)
        {
            if(lblIdInserto.Text.Trim()=="0") return;
            new HipotecaInsertoBC().DelInserto(Convert.ToInt32(lblIdInserto.Text.Trim()));
            dlInsertoTitulos.SelectedValue = "0";
            txtInsertoTexto.Text = "";
            GetAllInsertos();
            Mensaje("Eliminado correctamente");
        }

        protected void gr_insertos_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "editar") return;
            var index = Convert.ToInt32(e.CommandArgument);
            var idInserto = Convert.ToInt32(gr_insertos.DataKeys[index]["id_inserto"]);

            var inserto = new HipotecaInsertoBC().GetInserto(idInserto, Convert.ToInt32(lbl_numero.Text.Trim()));

            lblIdInserto.Text = inserto.IdInserto.ToString();
            dlInsertoTitulos.SelectedValue = inserto.IdInserto.ToString();
            txtInsertoTexto.Text = inserto.Texto;

        }

        protected void ibRefrescar_Click1(object sender, ImageClickEventArgs e)
        {
             GetDocs(Convert.ToInt32(lbl_numero.Text.Trim()));
        }
    }


}