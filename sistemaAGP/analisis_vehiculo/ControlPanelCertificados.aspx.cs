using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.analisis_vehiculo
{
    public partial class ControlPanelCertificados : Page
    {
        public bool PuedeHabilitar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                //Instancio al usuario session 
                var usuario = new UsuarioBC().GetUsuario(Session["usrname"].ToString());
                Permisos();

                //se llenan los combo                 
                FuncionGlobal.combosucursalbyclienteandUsuario(dlSucursal, usuario.Cliente.Id_cliente, usuario.UserName);
                LlenaComboboxUsuarioDefecto();
                LlenaComboboxProductos();
                LlenaComboboxEstados();
                dlSucursal.Items[0].Text = "Mi(s) sucursal(es)";
                txtDesde.Text = DateTime.Today.ToShortDateString();
                txtHasta.Text = DateTime.Today.ToShortDateString();

                //Lleno el Dashboard dependiendo del usuario
                UsuarioDAshboard();

                //Mensaje de bienvenida una vez terminada la carga
                Mensajes($"{FuncionGlobal.SaludosHorario()}, este es tu administrador de certificados", Enums.TiposMensajes.Bienvenido);
            }
            catch (Exception ex)
            {
                Mensajes("Rayos! Se generó el siguiente error: " + ex.Message, Enums.TiposMensajes.Error);
            }
        }

        private void Permisos()
        {
            var dt = new OrdenTrabajoBC().PermisosOrdenTrabajo(Convert.ToString(Session["usrname"]));

            if (dt.Rows.Count > 0)
            {
                PuedeHabilitar = Convert.ToBoolean(dt.Rows[0]["permiso_infocar_habilitar"]);

                ibHabilitar.Enabled = PuedeHabilitar;
                ibHabilitar.ImageUrl = PuedeHabilitar ? Constantes.IMAGEN_KEY_HABILITAR_ACTIVO : Constantes.IMAGEN_KEY_HABILITAR_DESACTIVO;
            }
            else
            {
                ibHabilitar.Enabled = false;
                ibHabilitar.ImageUrl = Constantes.IMAGEN_KEY_HABILITAR_DESACTIVO;
            }
        }


        public DataTable ListaMasiva()
        {

            string[] split = txtBcoMultiple.Text.Split(' ', ',', '.', ':', '\t', '\n');
            var data = new DataTable();
            data.Columns.Add(new DataColumn("dato"));

            foreach (string s in split)
            {
                if (s.Trim() == string.Empty || s.Trim().ToLower() == "patentes") continue;
                var dr = data.NewRow();
                dr["dato"] = s.Trim();
                data.Rows.Add(dr);
            }
            return data;
        }


        public DataTable GetOperacion(string usuario)
        {

            DataTable dtPatente = null;
            dtPatente = ListaMasiva();


            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("url_procesos"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("marca"));
            dt.Columns.Add(new DataColumn("propietario"));
            dt.Columns.Add(new DataColumn("encargo_robo"));
            dt.Columns.Add(new DataColumn("limitacion_dominio"));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("url_estado"));
            dt.Columns.Add(new DataColumn("monto_multas"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("img_contrato"));
            dt.Columns.Add(new DataColumn("url_contrato"));
            dt.Columns.Add(new DataColumn("url_ingreso"));
            dt.Columns.Add(new DataColumn("img_ingreso"));
            dt.Columns.Add(new DataColumn("img_documentos"));
            dt.Columns.Add(new DataColumn("url_documentos"));
            dt.Columns.Add(new DataColumn("producto"));
            dt.Columns.Add(new DataColumn("id_asociado"));
            dt.Columns.Add(new DataColumn("url_e_operacion_asociada"));
            dt.Columns.Add(new DataColumn("terminado"));
            dt.Columns.Add(new DataColumn("tipo_operacion"));

            var lista = new InfoAutoBC().GetInfoAutoNew(
                                                     usuario,
                                                     dlEstado.SelectedValue.Trim(),
                                                     dlProducto.SelectedValue,
                                                     ($"{Convert.ToDateTime(txtDesde.Text.Trim()):yyyyMMdd}"),
                                                     ($"{Convert.ToDateTime(txtHasta.Text.Trim()):yyyyMMdd}"),
                                                     Convert.ToInt32(dlSucursal.SelectedValue),
                                                     dtPatente);

            foreach (var a in lista)
            {
                const string sinInfo = "NO SE PUEDE ANALIZAR ESTA PATENTE";
                var dr = dt.NewRow();
                dr["id_solicitud"] = a.Id_solicitud;
                dr["fecha"] = a.FechaAdquisicion;
                dr["patente"] = a.Patente;
                dr["marca"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Marca;
                dr["producto"] = a.TipoOperacion;
                dr["sucursal"] = a.Sucursal.ToUpper(); 
                dr["usuario"] = a.Usuario.ToUpper();
                dr["semaforo"] = a.ConMuntas 
                    ? "../imagenes/sistema/static/rojo.png" 
                    :"../imagenes/sistema/static/verde.png";
                dr["estado"] = a.EstadoFamilia;
                dr["limitacion_dominio"] = a.TipoOperacion.Trim().ToUpper() == "INFOCAR" 
                    ? a.LimitacionDominio 
                    : "Aplica para INFOCAR";
                dr["monto_multas"] = "$" + a.MontoMulta.Replace(",", ".");
                dr["encargo_robo"] = a.EncargoRobo;
                dr["propietario"] = a.EstadoFamilia == sinInfo 
                    ? "SIN INFO." 
                    : a.Propietario_nombre;

                var infocarTerminado = a.CodigoEstado == 270 || a.CodigoEstado == 265;

                dr["terminado"] = infocarTerminado;
                dr["tipo_operacion"] = a.TipoOperacion.Trim().ToUpper();


                if (a.TipoOperacion.Trim().ToUpper() == "INFOCAR" 
                    && infocarTerminado
                    && a.HabilitadoTransferencia
                    && (a.IdCliente == (int)Enums.TipoCliente.BICE
                        || a.IdCliente == (int)Enums.TipoCliente.BK
                        || a.IdCliente == (int)Enums.TipoCliente.PORCHE
                        )
                     )
                {
                    dr["url_contrato"] = "../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.IdSolicitudAsociado.ToString().Trim());
                    dr["img_ingreso"] = Constantes.IMAGEN_INGRESO_ACTIVO;
                    dr["img_contrato"] = Constantes.IMAGEN_CONTRATO_ACTIVO;
                    dr["url_ingreso"] = "../analisis_vehiculo/SeleccionIngresoNuevoOperacion.aspx?patente=" + FuncionGlobal.FuctionEncriptar(a.Patente.Trim()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim()) +
                    "&id_cliente=" + FuncionGlobal.FuctionEncriptar(a.IdCliente.ToString());
                }
                else
                {
                    dr["img_ingreso"] = Constantes.IMAGEN_INGRESO_DESACTIVO;
                    dr["img_contrato"] = Constantes.IMAGEN_CONTRATO_DESACTIVO;
                }

                dr["url_documentos"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim()) + "&origen=ex";
                dr["img_documentos"] = @"../imagenes/sistema/static/panel_control/pdf.png";
                dr["url_procesos"] = @"../preinscripcion/InfoAutoProcesos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim());
                dr["id_asociado"] = a.IdSolicitudAsociado;
                if (a.IdSolicitudAsociado > 0)
                {
                    dr["url_e_operacion_asociada"] = "~/operacion/mWorkflow.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.IdSolicitudAsociado.ToString(CultureInfo.InvariantCulture).Trim());

                }
                dt.Rows.Add(dr);
            }

            return dt;
        }


        public void LlenaGrilla(string usuario)
        {
            var dt = GetOperacion(usuario);

            //indico cuantas filas encontró la búsqueda
            var conteoFilas = dt.Rows.Count;
            lblConteoOperaciones.Text = conteoFilas.ToString(CultureInfo.InvariantCulture);
           
            //lleno la grilla
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        /// <summary>
        /// UsuarioDAshboard()
        /// Llena Control de mando
        /// </summary>
        public void UsuarioDAshboard()
        {
            //trae una lista con las operaciones y sus semaforos y estados actuales
            var dt = new InfoAutoBC().GetdashboardCertificados(Session["usrname"].ToString().Trim());
            var totalOperaciones = Convert.ToString(dt.Rows[0]["total_operaciones"]);
            var totalCav = Convert.ToString(dt.Rows[0]["total_cav"]);
            var totalInfocar = Convert.ToString(dt.Rows[0]["total_infocar"]);
            var totalMultas = Convert.ToString(dt.Rows[0]["total_cav_multas"]);
           
            var mesCav = Convert.ToString(dt.Rows[0]["mes_cav"]);
            var mesInfocar = Convert.ToString(dt.Rows[0]["mes_infocar"]);
            var mesCavMultas = Convert.ToString(dt.Rows[0]["mes_cav_multas"]);
            var documentosMes = Convert.ToString(dt.Rows[0]["documentos_mes"]);


            lblTotalMes.Text = Convert.ToString(Convert.ToUInt32(mesCav) + Convert.ToUInt32(mesCavMultas) + Convert.ToUInt32(mesInfocar));
            lblTotalOp.Text = totalOperaciones;
            lblRojas.Text = mesCav;
            lblrojasprom.Text = totalCav;
            lblAmarillas.Text = mesCavMultas;
            lblAmarillasprom.Text = totalMultas;
            lblVerdes.Text = mesInfocar;
            lblVerdesprom.Text = totalInfocar;
            lblPromedioDias.Text = documentosMes;

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
                var usuario = dlUsuario.SelectedValue;
                LlenaGrilla(usuario);
                UsuarioDAshboard();
                var complementoMensaje = lblConteoOperaciones.Text.Trim() == "0" ? " Intenta con otros filtros." : string.Empty;

                Mensajes("Tú busqueda arrojó " + lblConteoOperaciones.Text + " Resultados." + complementoMensaje, Enums.TiposMensajes.Correcto);
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

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var usuario = dlUsuario.SelectedValue;
                var dt = GetOperacion(usuario);

                if (dt == null)
                {
                    FuncionGlobal.alerta_updatepanel("Ups! Debes hacer una busqueda anteriormente para exportar.", Page, udp);
                    return;
                }
                //creo el informe y obtengo su nombre
                var informe = new MatrizExcelBC().GetReporteCertificados(Session["usrname"].ToString(), dt);

                //llamo al informe para ser abierto o guardado.
                var strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + informe.Trim() + "');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", strAlerta, true);
            }
            catch (Exception ex)
            {
                Mensajes("Rayos! Se generó el siguiente error: " + ex.Message, Enums.TiposMensajes.Error);
            }
        }

        private void LlenaComboboxProductos()
        {
            List<TipoOperacion> lista = new List<TipoOperacion>();
            lista.Add(new TipoOperacion { Codigo = "INFAU", Operacion = "INFOCAR" });
            lista.Add(new TipoOperacion { Codigo = "CCAV", Operacion = "CAV" });
            lista.Add(new TipoOperacion { Codigo = "CAMUL", Operacion = "CAV Y MULTAS" });

            dlProducto.Items.Clear();
            dlProducto.AppendDataBoundItems = true;
            dlProducto.Items.Add(new ListItem("Todos los Productos", "0"));
            dlProducto.DataSource = from o in lista
                                    orderby o.Operacion ascending
                                    select o;
            dlProducto.DataValueField = "codigo";
            dlProducto.DataTextField = "operacion";
            dlProducto.DataBind();
            dlProducto.SelectedValue = "0";
        }

        private void LlenaComboboxEstados()
        {
            List<TipoOperacion> lista = new List<TipoOperacion>();
            lista.Add(new TipoOperacion { Codigo = "PROCESO", Operacion = "EN PROCESO DE COMPRA" });
            lista.Add(new TipoOperacion { Codigo = "COMPRADOS", Operacion = "COMPRADOS" });


            dlEstado.Items.Clear();
            dlEstado.AppendDataBoundItems = true;
            dlEstado.Items.Add(new ListItem("Todos los estados", "0"));
            dlEstado.DataSource = from o in lista
                                  select o;
            dlEstado.DataValueField = "codigo";
            dlEstado.DataTextField = "operacion";
            dlEstado.DataBind();
            dlEstado.SelectedValue = "0";

        }

        protected void dlSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool soyEncargado = new SucursalclienteBC().getEncargadoSucursal(Convert.ToInt16(dlSucursal.SelectedValue),
                                                                                Convert.ToString(Session["usrname"]));

            if (soyEncargado)
            {
                LlenarComboUsuarios(Convert.ToInt16(dlSucursal.SelectedValue));
            }
            else
            {
                LlenaComboboxUsuarioDefecto();
            }
        }

        private void LlenaComboboxUsuarioDefecto()
        {
            List<TipoOperacion> lista = new List<TipoOperacion>();
            lista.Add(new TipoOperacion { Codigo = Convert.ToString(Session["usrname"]), Operacion = "Mis certificados" });

            dlUsuario.Items.Clear();
            dlUsuario.AppendDataBoundItems = true;
            dlUsuario.DataSource = from o in lista
                                   select o;
            dlUsuario.DataValueField = "codigo";
            dlUsuario.DataTextField = "operacion";
            dlUsuario.DataBind();
            dlUsuario.SelectedIndex = 0;
        }

        private void LlenarComboUsuarios(Int16 idSucursal)
        {
            var lista = new SucursalclienteBC().GetUsuariosEnSucursal(idSucursal);
            dlUsuario.Items.Clear();
            dlUsuario.AppendDataBoundItems = true;
            dlUsuario.Items.Add(new ListItem("Todos los usuarios", "0"));
            dlUsuario.DataSource = from o in lista
                                   orderby o.Nombre
                                   select o;
            dlUsuario.DataValueField = "username";
            dlUsuario.DataTextField = "nombre";
            dlUsuario.DataBind();
            dlUsuario.SelectedValue = "0";
        }

        public int Habilitar()
        {
            var correctas = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var id = Convert.ToInt32(gr_dato.DataKeys[i].Values["id_solicitud"]);
                var terminado = Convert.ToBoolean(gr_dato.DataKeys[i].Values["terminado"]);
                var tipoOperacion = Convert.ToString(gr_dato.DataKeys[i].Values["tipo_operacion"]);
                var comentario = txtHabilitarComentario.Value.ToUpper();

                if (!chk.Checked || tipoOperacion != "INFOCAR" || !terminado) continue;
               new InfoAutoBC().HabilitarContratoDv(id, comentario);

                correctas++;
            }
            return correctas;
        }

        protected void bt_habilitar_Click(object sender, EventArgs e)
        {
            var correctos = Habilitar();

            if (correctos > 0)
            {
                Mensajes($"Se habilitaron {correctos} contratos.", Enums.TiposMensajes.Correcto);
            }
            else
            {
                Mensajes("No se habilitaron contratos. Revise nuevamente", Enums.TiposMensajes.Informacion);
            }


        }

        protected void ibHabilitar_Click(object sender, ImageClickEventArgs e)
        {
            mpe_habilitar.Show();
        }
    }
}