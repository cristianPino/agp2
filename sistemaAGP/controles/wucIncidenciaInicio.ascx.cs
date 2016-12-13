using System;
using CNEGOCIO;

namespace sistemaAGP.controles
{
    public partial class wucIncidenciaInicio : System.Web.UI.UserControl
    {
        private static int IdIncidencia;
        private static bool guardando;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            guardando = false;
        }

        public void InicioComponentes(int idIncidencia)
        {
            IdIncidencia = idIncidencia;
            //se llama al metodo desde la pantalla administracion de incidenetes
            FuncionGlobal.ComboUsuarioGrupo(dlAsignarUsuario, false, Convert.ToString(Session["usrname"]));
            gr_dato.DataSource = new IncidenciaBC().GetOperacionesIncidencia(IdIncidencia);
            gr_dato.DataBind();
            btnAsignar.Visible = gr_dato.Rows.Count > 0;
        }

        public void AvanzarEstadoAbiertoSupervisor()
        {
            //se llama al metodo desde la pantalla administracion de incidenetes CUANDO EL USUARIO SUPERVISOR ABRE LA PANTALLA
            new IncidenciaBC().CambioEstado(IdIncidencia,
                                            3,
                                            Convert.ToString(Session["usrname"]),
                                            Convert.ToString(Session["usrname"]),
                                            "CAMBIO AUTOMATICO",
                                            "ABIERTO POR SUPERVISOR, EN ESPERA DE DERIVACION");
        }


        protected void btnNoAsignar_Click(object sender, EventArgs e)
        {
            AvanzarSinAsignar();
            Finalizar();
        }

        private void AvanzarSinAsignar()
        {

            new IncidenciaBC().ActualizaIncidencia(IdIncidencia,
                                                   0,
                                                   txtComentario.Text.Trim(),
                                                   Convert.ToInt32(dlTipoCierre.SelectedValue),
                                                   dlTipoCierre.SelectedItem.Text,
                                                   dlCargoCliente.SelectedValue.Trim() == "1",
                                                   Convert.ToString(Session["usrname"]),
                                                   dlAsignarUsuario.SelectedValue);
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(Request.Form["rbSeleccion"]);
            if (idSolicitud == 0 || idSolicitud == null )
            {
                FuncionGlobal.alerta_updatepanel("Seleccione una operación", Page, udp_wuc_incidencia_inicio);
            }
            else
            {
                if (guardando == false)
                {
                    guardando = true;
                    AvanzarYAsignar(idSolicitud);
                    Finalizar();
                }
               
            }


        }

        private void AvanzarYAsignar(int idSolicitud)
        {

            new IncidenciaBC().ActualizaIncidencia(IdIncidencia,
                                                   idSolicitud,
                                                   txtComentario.Text.Trim(),
                                                   Convert.ToInt32(dlTipoCierre.SelectedValue),
                                                   dlTipoCierre.SelectedItem.Text,
                                                   dlCargoCliente.SelectedValue.Trim() == "1",
                                                   Convert.ToString(Session["usrname"]),
                                                   dlAsignarUsuario.SelectedValue);
        }

        private void Finalizar()
        {
            txtComentario.Text = string.Empty;
            btnAsignar.Visible = false;
            btnNoAsignar.Visible = false;
            FuncionGlobal.alerta_updatepanel("Incidencia asignada correctamente", Page, udp_wuc_incidencia_inicio);
        }

    }
}