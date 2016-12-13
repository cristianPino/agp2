using CNEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP.Incidencias.modal
{
    public partial class Administracion : System.Web.UI.Page
    {
        private static int IdIncidencia;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            IdIncidencia = Convert.ToInt32(Request.QueryString["id_incidencia"]);
            var tipoOrigen = Convert.ToInt32(Request.QueryString["origen"]);
            Permisos(Convert.ToString(Session["usrname"]));
            //PARA LA PANTALLA DE CREACION DE INCIDENCIAS
            switch (tipoOrigen)
            { 
                case 1://NUEVA
                    FuncionGlobal.alerta_updatepanel(string.Format("Nueva incidencia Nº: {0} creada correctamente.",IdIncidencia), Page, up_inicio);
                    break;
                case 2://EXISTE UNA 
                    FuncionGlobal.alerta_updatepanel(string.Format("Ya existe una incidencia abierta para ese chasis o patente con el Nº: {0}.", IdIncidencia), Page, up_inicio);
                    break;
            }

        }

        private void Permisos(string usuario)
        {
            DataTable dtPermisos = new IncidenciaBC().GetIncidenciasPermisos(usuario);

            var permisoInicio = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_inicio"]);
            var permisoCierre = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_resolver"]);
            var permisoComentario = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_comentario"]);
            var permisoDocumentos = Convert.ToBoolean(dtPermisos.Rows[0]["permiso_modificar_documento"]);
            DataTable dt = new IncidenciaBC().GetIncidenciaById(IdIncidencia);

            if (!permisoInicio ||
                (Convert.ToInt32(dt.Rows[0]["id_estado"]) != 1 && Convert.ToInt32(dt.Rows[0]["id_estado"]) != 3) ||
                Convert.ToString(dt.Rows[0]["cuenta_usuario_responsable"]) != Convert.ToString(Session["usrname"]))
            {
                tab_opciones.Tabs[0].Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(dt.Rows[0]["id_estado"]) == 1)
                {
                    this.wucInicio.AvanzarEstadoAbiertoSupervisor();
                }

                this.wucInicio.InicioComponentes(IdIncidencia);

            }                       


            // CIERRES
            if (!permisoCierre || 
                (Convert.ToInt32(dt.Rows[0]["id_estado"]) != 5 && Convert.ToInt32(dt.Rows[0]["id_estado"]) != 4) ||
                Convert.ToString(dt.Rows[0]["cuenta_usuario_responsable"]) != Convert.ToString(Session["usrname"])
                )
            {
                tab_opciones.Tabs[1].Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(dt.Rows[0]["id_estado"]) == 4)
                {
                    this.wucCierre.AvanzarEstadoAbiertoEjecutivo(IdIncidencia);
                }
                this.wucCierre.ReiniciarComponentes(IdIncidencia, Convert.ToInt32(dt.Rows[0]["id_incidencia_estado"]));
            }

            //COMENTARIOS
            if (!permisoComentario)
            {
                tab_opciones.Tabs[2].Enabled = false;
            }
            else 
            {
                wucComentario.ReiniciarComponentes(IdIncidencia);
            }

            wucDocumento.VerPanelAcciones = permisoDocumentos;
            wucDocumento.Inicio(IdIncidencia);
            

        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }
    }
}