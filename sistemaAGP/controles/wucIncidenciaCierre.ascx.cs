using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;

namespace sistemaAGP.controles
{
    public partial class wucIncidenciaCierre : System.Web.UI.UserControl
    {
        public static int IdIncidencia;
        public static int IdIncidenciaEstado;
        public static string IdCliente;
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (IsPostBack) return;
           

        }
        public void ReiniciarComponentes(int idIncidencia, int idIncidenciaEstado)
        {
            IdIncidencia = idIncidencia;
            IdIncidenciaEstado = idIncidenciaEstado;           
            DataTable dtIncidencia = new IncidenciaBC().GetIncidenciaById(IdIncidencia);
            lblTipoCierre.Text = string.Format("Tipo de Cierre definido por supervisor: {0}",
                                              Convert.ToString(dtIncidencia.Rows[0]["tipo_cierre"]));
            int idSolicitudNueva = Convert.ToInt32(dtIncidencia.Rows[0]["id_solicitud_nueva"]);

            switch (Convert.ToInt32(dtIncidencia.Rows[0]["id_tipo_cierre"]))
            {
                case 1:
                    pnlCierre.Visible = false;
                    if (idSolicitudNueva != 0)
                    {
                        ConOperacionIngresada(idSolicitudNueva);
                    }
                    else
                    {
                        LlenarComboboxTipoProducto();
                    }                    
                    break;
                case 2:
                    pnlOperacion.Visible = false;
                    break;
                default:
                    pnlCierre.Visible = false;
                    pnlOperacion.Visible = false;
                    break;
            }
            
        }

        private void ConOperacionIngresada(int idSolicitudNueva)
        {
            lblIdSolicitud.Text = string.Format("Solicitud Ingresada Nº {0}", idSolicitudNueva);
            dlTipoOperacion.Visible = false;
            btnCierre.Visible = false;
        }

        public void AvanzarEstadoAbiertoEjecutivo(int idIncidencia)
        {
            //se llama al metodo desde la pantalla administracion de incidenetes CUANDO EL USUARIO SUPERVISOR ABRE LA PANTALLA
            IdIncidencia = idIncidencia;
            new IncidenciaBC().CambioEstado(IdIncidencia,
                                            5,
                                            Convert.ToString(Session["usrname"]),
                                            Convert.ToString(Session["usrname"]),
                                            "CAMBIO AUTOMATICO",
                                            "ABIERTO POR EJECUTIVO, ESPERANDO CORRECCION");
        }

        private void LlenarComboboxTipoProducto()
        {
            var dt = new IncidenciaBC().GetTipoOperacionIncidencia(IdIncidencia);
            DataTable dtIncidencia = new IncidenciaBC().GetIncidenciaById(IdIncidencia);
            dlTipoOperacion.DataSource = dt;
            dlTipoOperacion.DataTextField = "descripcion";
            dlTipoOperacion.DataValueField = "url_operacion";
            dlTipoOperacion.DataBind();
            dlTipoOperacion.SelectedValue = "0";

            IdCliente = Convert.ToString(dtIncidencia.Rows[0]["id_cliente"]);

            if (dt.Rows.Count > 0)
            {
                lnk.HRef = dlTipoOperacion.SelectedValue + 
                    FuncionGlobal.FuctionEncriptar("0")+
                    "&id_cliente=" + FuncionGlobal.FuctionEncriptar(IdCliente) +
                    "&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar("0")+
                    "&id_incidencia=" + FuncionGlobal.FuctionEncriptar(Convert.ToString(IdIncidencia)); 
            }


        }

        protected void dlTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnk.HRef = dlTipoOperacion.SelectedValue +
                    FuncionGlobal.FuctionEncriptar("0") +
                    "&id_cliente=" + FuncionGlobal.FuctionEncriptar(IdCliente) +
                    "&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar("0") +
                    "&id_incidencia=" + FuncionGlobal.FuctionEncriptar(Convert.ToString(IdIncidencia));
        }

        protected void btnCierre_Click(object sender, EventArgs e)
        {
            if (txtCierreComentario.Text.Trim() == string.Empty)
            {
                FuncionGlobal.alerta("Ingrese un comentario.", Page);                
            }
            else 
            {
                CerrarIncidencia();
            }
        }

        protected void CerrarIncidencia()
        { 
            //Este método cerrará la incidencia enviará un correo al usuario
            new IncidenciaBC().CerrarIncidencia(Convert.ToString(Session["usrname"]), txtCierreComentario.Text.Trim(), IdIncidenciaEstado, IdIncidencia);
            
        }

        protected void botonReload_Click(object sender, EventArgs e)
        {
            DataTable dtIncidencia = new IncidenciaBC().GetIncidenciaById(IdIncidencia);
            int idSolicitudNueva = Convert.ToInt32(dtIncidencia.Rows[0]["id_solicitud_nueva"]);
            if (idSolicitudNueva != 0)
            {
                ConOperacionIngresada(idSolicitudNueva);
            }
            
        }
    }
}