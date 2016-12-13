using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP.Incidencias
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        #region ENUMS y CONSTANTES
        public enum TiposMensajes
        {
            Error,
            Correcto,
            Informacion,
            Bienvenido
        }

        public const string IMAGEN_ELIMINAR = "~/imagenes/sistema/static/hipotecario/delete.png";
        public const string IMAGEN_ASIGNAR = "~/imagenes/sistema/static/hipotecario/asignar.png";
        public const string IMAGEN_CAMBIO_ESTADO = "~/imagenes/sistema/static/hipotecario/workflow.png";
        public const string IMAGEN_ELIMINAR_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/delete_morado.png";
        public const string IMAGEN_ASIGNAR_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/asignar_morado.png";
        public const string IMAGEN_CAMBIO_ESTADO_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/workflow_morado.png";
        public const string IMAGEN_COMENTARIO = "~/imagenes/sistema/static/hipotecario/note.png";
        public const string IMAGEN_COMENTARIO_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/note_morado.png";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string origenExterno = Request.QueryString["origen"];
            string semaforoExterno = Request.QueryString["semaforo"];
            string proc = Request.QueryString["proc"];

            origenExterno = origenExterno == null ? "FALSE" :  FuncionGlobal.FuctionDesEncriptar(origenExterno);            
            semaforoExterno = semaforoExterno == null? "0" : FuncionGlobal.FuctionDesEncriptar(semaforoExterno);
            proc = proc == null ? "0" : FuncionGlobal.FuctionDesEncriptar(proc);

            if (IsPostBack) return;

            Permisos(Convert.ToString(Session["usrname"]));
            Mensaje("Hola", TiposMensajes.Bienvenido);
            LlenarComboBusquedaMasiva();
            FuncionGlobal.ComboEstadosIncidencia(dlEstados, "todo");

            if (Convert.ToBoolean(origenExterno))
            {
                gr_dato.DataSource = GetIncidenciaExterna(Convert.ToString(Session["usrname"]), semaforoExterno, Convert.ToInt32(proc));
                gr_dato.DataBind();
                lblConteoOperaciones.Text = Convert.ToString(gr_dato.Rows.Count);
            }
        }

        private DataTable GetIncidencias(string usuario)
        {
            //limpiamos la grilla
            gr_dato.DataSource = null;

            //llenado de variables de filtros
            string patente = txtPatente.Value.Trim();
            string id_ticket = txtTicket.Value.Trim() == string.Empty ? "0" : txtTicket.Value.Trim();
            //valida que el tiket sea numérico
            int number1 = 0;
            bool ticketEntero = int.TryParse(id_ticket, out number1);

            //si no es numero devuelve null
            if (!ticketEntero) { Mensaje("El filtro por número de ticket no es númerico.", TiposMensajes.Error); return null; }

            int ticket = Convert.ToInt32(id_ticket);
            int estado = Convert.ToInt32(dlEstados.SelectedValue);

            //llena busqueda masiva: Al ser null devuelve datos de otros filtros
            DataTable dataTableTickets = null;
            DataTable dataTablePatentes = null;
            DataTable dataTableChasis = null;
            //si hay seleccionado una opcionde busqueda masiva
            switch (dlTipoBusquedaMasiva.Text.ToLowerInvariant())
            {
                case "ticket":
                    dataTableTickets = ListaMasiva();
                    break;
                case "patente":
                    dataTablePatentes = ListaMasiva();
                    break;
                case "chasis":
                    dataTableChasis = ListaMasiva();
                    break;
            }

            DataTable dtDatos = new DataTable();
            try
            {
                dtDatos = new IncidenciaBC().GetIncidencias(usuario,
                                                           estado,
                                                           ticket,
                                                           patente,
                                                           dataTableTickets,
                                                           dataTablePatentes,
                                                           dataTableChasis);


                string mensaje = dtDatos.Rows.Count == 0 ?
                               "Su busqueda no trajo resultados, intentelo con otros filtros" :
                               "Se encontraron " + dtDatos.Rows.Count + " filas";

                Mensaje(mensaje, TiposMensajes.Informacion);

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message, TiposMensajes.Error);
            }

            return dtDatos;
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

        private void Mensaje(string mensaje, TiposMensajes tipoMensaje)
        {
            Master.LblInfo.Text = mensaje;

            switch (tipoMensaje)
            {
                case TiposMensajes.Correcto:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/verde.png";
                    break;
                case TiposMensajes.Informacion:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/warning.png";
                    break;
                case TiposMensajes.Error:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/rojo.png";
                    break;
                case TiposMensajes.Bienvenido:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/bienvenido.png";
                    break;
            }
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            gr_dato.DataSource = GetIncidencias(Convert.ToString(Session["usrname"]));
            gr_dato.DataBind();
            lblConteoOperaciones.Text = Convert.ToString(gr_dato.Rows.Count);
        }

        private void LlenarComboBusquedaMasiva()
        {
            List<TipoOperacion> lista = new List<TipoOperacion>();
            lista.Add(new TipoOperacion { Codigo = "ticket", Operacion = "VARIOS TICKETS" });
            lista.Add(new TipoOperacion { Codigo = "patente", Operacion = "VARIAS PATENTES" });
            lista.Add(new TipoOperacion { Codigo = "chasis", Operacion = "VARIOS CHASIS" });

            dlTipoBusquedaMasiva.Items.Clear();
            dlTipoBusquedaMasiva.AppendDataBoundItems = true;
            dlTipoBusquedaMasiva.Items.Add(new ListItem("Busqueda multiple", "0"));
            dlTipoBusquedaMasiva.DataSource = from o in lista
                                              select o;
            dlTipoBusquedaMasiva.DataValueField = "codigo";
            dlTipoBusquedaMasiva.DataTextField = "operacion";
            dlTipoBusquedaMasiva.DataBind();
            dlTipoBusquedaMasiva.SelectedValue = "0";
        }

        protected void ibBaja_Click(object sender, ImageClickEventArgs e)
        {
            mpe_baja.Show();
        }

        private void Permisos(string usuario)
        {
            try
            {
                DataTable dtPermisos = new IncidenciaBC().GetIncidenciasPermisos(usuario);

                var permisoEliminar = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_eliminar"]);
                var permisoDerivar = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_derivar"]);
                var permisoCambiarEstado = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_cambiar_estado"]);
                var permisoComentario = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_comentario"]);

                ibAsignar.Enabled = permisoDerivar;
                ibBaja.Enabled = permisoEliminar;
                ibCambiarEstado.Enabled = permisoCambiarEstado;
                ibComentario.Enabled = permisoComentario;

                ibAsignar.ImageUrl = permisoDerivar ? IMAGEN_ASIGNAR : IMAGEN_ASIGNAR_NO_HABILITADO;
                ibBaja.ImageUrl = permisoEliminar ? IMAGEN_ELIMINAR : IMAGEN_ELIMINAR_NO_HABILITADO;
                ibCambiarEstado.ImageUrl = permisoCambiarEstado ? IMAGEN_CAMBIO_ESTADO : IMAGEN_CAMBIO_ESTADO_NO_HABILITADO;
                ibComentario.ImageUrl = permisoComentario ? IMAGEN_COMENTARIO : IMAGEN_COMENTARIO_NO_HABILITADO;

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message, TiposMensajes.Error);
            }
        }

        protected void ibAsignar_Click(object sender, ImageClickEventArgs e)
        {
            FuncionGlobal.ComboEstadosIncidencia(dlAsignarEstados, "manual");
            FuncionGlobal.ComboUsuarioGrupo(dlAsignarUsuario, false, Convert.ToString(Session["usrname"]));
            mpe_asignar.Show();
        }

        protected void ibCambiarEstado_Click(object sender, ImageClickEventArgs e)
        {
            FuncionGlobal.ComboEstadosIncidencia(dlEstadoCambios, "manual");
            mpe_cambio_estado.Show();
        }

        protected void ibComentario_Click(object sender, ImageClickEventArgs e)
        {
            mpe_comentario.Show();
        }

        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(udpForm, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }


        #region Codigo Botonera

        protected void bt_dar_baja_Click(object sender, EventArgs e)
        {
            var comentario = txtBajaComentario.Value;

            if (comentario.Trim() == string.Empty)
            {
                FuncionGlobal.alerta_updatepanel("Ingrese un comentario", Page, this.udpForm);
            }
            else
            {
                var filasGrid = from r in this.gr_dato.Rows.OfType<GridViewRow>()
                                where ((CheckBox)r.FindControl("chk")).Checked && r.RowType == DataControlRowType.DataRow
                                select r.RowIndex;

                if (filasGrid.Count() > 0)
                {
                    try
                    {

                        foreach (int i in filasGrid)
                        {
                            int idIncidencia = Convert.ToInt32(this.gr_dato.DataKeys[i].Values[0]);
                            new IncidenciaBC().DarBajaIncidencia(idIncidencia, Convert.ToString(Session["usrname"]), comentario);
                        }

                        GetIncidencias(Convert.ToString(Session["usrname"]));
                        FuncionGlobal.alerta_updatepanel("Incidencias seleccionadas dadas de baja correctamente.", Page, this.udpForm);
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message, TiposMensajes.Error);
                    }
                }
                else
                {
                    FuncionGlobal.alerta_updatepanel("No ha seleccionado ningún ticket", Page, this.udpForm);
                }
            }
        }

        protected void bt_asignar_Click(object sender, EventArgs e)
        {
            var comentario = txtAsignarComentario.Value;

            if (comentario.Trim() == string.Empty)
            {
                FuncionGlobal.alerta_updatepanel("Ingrese un comentario", Page, this.udpForm);
                return;
            }

            if (dlAsignarUsuario.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Seleccione un usuario", Page, this.udpForm);
                return;
            }

            //si estado = 0 ...se inserta en la tabla de estados incidencias el mismo estado actual, pero con el usuario asignado nuevo.
            var filasGrid = from r in this.gr_dato.Rows.OfType<GridViewRow>()
                            where ((CheckBox)r.FindControl("chk")).Checked && r.RowType == DataControlRowType.DataRow
                            select r.RowIndex;
            if (filasGrid.Count() > 0)
            {
                foreach (int i in filasGrid)
                {
                    var estado = Convert.ToInt32(dlAsignarEstados.SelectedValue);
                    int idIncidencia = Convert.ToInt32(this.gr_dato.DataKeys[i].Values[0]);
                    int idEstado = Convert.ToInt32(this.gr_dato.DataKeys[i].Values["id_estado"]);
                    if (estado == 0)
                    {
                        estado = idEstado;
                    }
                    new IncidenciaBC().AsignarUsuario(idIncidencia, estado, Convert.ToString(Session["usrname"]), Convert.ToString(dlAsignarUsuario.SelectedValue), comentario, dlAsignarEstados.SelectedItem.Text);
                }
                GetIncidencias(Convert.ToString(Session["usrname"]));
                FuncionGlobal.alerta_updatepanel("Tickets asignados correctamente", Page, this.udpForm);
            }
            else
            {
                FuncionGlobal.alerta_updatepanel("No seleccionó ningún ticket de incidencia", Page, this.udpForm);
            }
        }

        protected void bt_cambio_estado_Click(object sender, EventArgs e)
        {
            var comentario = txtComentarioEstado.Value;
            if (comentario.Trim() == string.Empty)
            {
                FuncionGlobal.alerta_updatepanel("Ingrese un comentario", Page, this.udpForm);
                return;
            }
            if (dlEstadoCambios.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Seleccione un Estado", Page, this.udpForm);
                return;
            }
            var filasGrid = from r in this.gr_dato.Rows.OfType<GridViewRow>()
                            where ((CheckBox)r.FindControl("chk")).Checked && r.RowType == DataControlRowType.DataRow
                            select r.RowIndex;
            if (filasGrid.Count() > 0)
            {
                foreach (int i in filasGrid)
                {
                    var estado = Convert.ToInt32(dlEstadoCambios.SelectedValue);
                    int idIncidencia = Convert.ToInt32(this.gr_dato.DataKeys[i].Values[0]);
                    var usuarioResponsable = Convert.ToString(this.gr_dato.DataKeys[i].Values["cuenta_usuario_responsable"]);
                    new IncidenciaBC().CambioEstado(idIncidencia, estado, Convert.ToString(Session["usrname"]), usuarioResponsable, comentario, dlEstadoCambios.SelectedItem.Text);
                }
                GetIncidencias(Convert.ToString(Session["usrname"]));
                FuncionGlobal.alerta_updatepanel("Tickets asignados correctamente", Page, this.udpForm);
            }
            else
            {
                FuncionGlobal.alerta_updatepanel("No seleccionó ningún ticket de incidencia", Page, this.udpForm);
            }
        }

        protected void bt_comentario_Click(object sender, EventArgs e)
        {
            var comentario = txtComentarioNuevo.Value.Trim();

            if (comentario == string.Empty)
            {
                FuncionGlobal.alerta_updatepanel("Ingrese un comentario", Page, this.udpForm);
                return;
            }

            var filasGrid = from r in this.gr_dato.Rows.OfType<GridViewRow>()
                            where ((CheckBox)r.FindControl("chk")).Checked && r.RowType == DataControlRowType.DataRow
                            select r.RowIndex;

            foreach (int i in filasGrid)
            {
                int idIncidencia = Convert.ToInt32(this.gr_dato.DataKeys[i].Values[0]);
                int idIncidenciaEstado = Convert.ToInt32(this.gr_dato.DataKeys[i].Values["id_incidencia_estado"]);
                new IncidenciaBC().AddComentario(idIncidencia, 22, Convert.ToString(Session["usrname"]), comentario);
            }
        }
        #endregion

        #region Busqueda de incidencias desde paginas externas
        private DataTable GetIncidenciaExterna(string usuario, string semaforo, int tipoResumen)
        {
            var sp = string.Empty;

            switch (tipoResumen)
            {
                case (int)Enums.TipoVistaResumen.Ingresador:
                    sp = Constantes.SP_RESUMEN_INGRESADOR;
                    break;
                case (int)Enums.TipoVistaResumen.Ejecutivo:
                    sp = Constantes.SP_RESUMEN_EJECUTIVO;
                    break;
                case (int)Enums.TipoVistaResumen.Supervisor:
                    sp = Constantes.SP_RESUMEN_SUPERVISOR;
                    break;
            }


            //limpiamos la grilla
            gr_dato.DataSource = null;

            //llenado de variables de defecto
            string patente = string.Empty;
            int ticket = 0;
            int estado = 0;

            //llena busqueda masiva: Al ser null devuelve datos de otros filtros
            DataTable dataTableTickets = new DataTable();
            DataTable dataTablePatentes = null;
            DataTable dataTableChasis = null;

            //se traspasan los datos para la busqueda por id incidencia
            var dt = new IncidenciaBC().GetDatosResumen(Convert.ToString(Session["usrname"]), sp);
            dataTableTickets.Columns.Add(new DataColumn("dato"));
            foreach (DataRow dr in dt.Rows)
            {
                var sla = Convert.ToInt32(dr["sla"]);
                var tiempoLab = Convert.ToInt32(dr["tiempo_laboral"]);
                var drn = dataTableTickets.NewRow();
                switch (semaforo)
                {
                    case "v":
                        if (tiempoLab < sla / 2)
                        {
                            drn["dato"] = dr["id_incidencia"].ToString();
                            dataTableTickets.Rows.Add(drn);
                        }
                        break;
                    case "a":
                        if (tiempoLab >= sla / 2 && tiempoLab < sla)
                        {
                            drn["dato"] = dr["id_incidencia"].ToString();
                            dataTableTickets.Rows.Add(drn);
                        }
                        break;
                    case "r":
                        if (tiempoLab >= sla)
                        {
                            drn["dato"] = dr["id_incidencia"].ToString();
                            dataTableTickets.Rows.Add(drn);
                        }
                        break;
                    default:
                        drn["dato"] = dr["id_incidencia"].ToString();
                        dataTableTickets.Rows.Add(drn);
                        break;
                }





            }


            DataTable dtDatos = new DataTable();
            if (dataTableTickets.Rows.Count > 0)
            {
                try
                {
                    dtDatos = new IncidenciaBC().GetIncidencias(usuario,
                                                               estado,
                                                               ticket,
                                                               patente,
                                                               dataTableTickets,
                                                               dataTablePatentes,
                                                               dataTableChasis);


                    string mensaje = dtDatos.Rows.Count == 0 ?
                                   "Su busqueda no trajo resultados, intentelo con otros filtros" :
                                   "Se encontraron " + dtDatos.Rows.Count + " filas";

                    Mensaje(mensaje, TiposMensajes.Informacion);

                }
                catch (Exception ex)
                {
                    Mensaje(ex.Message, TiposMensajes.Error);
                }
            }
            else
            {
                Mensaje("Su busqueda no trajo resultados, intentelo con otros filtros", TiposMensajes.Informacion);
            }
            return dtDatos;
        }
        #endregion
    }
}