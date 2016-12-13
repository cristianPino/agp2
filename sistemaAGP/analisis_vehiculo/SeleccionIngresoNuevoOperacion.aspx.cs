using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;

namespace sistemaAGP.analisis_vehiculo
{
    public partial class SeleccionIngresoNuevoOperacion : System.Web.UI.Page
    {
        public int IdSolicitud;
        public int IdCliente;
        public string Patente;
        protected void Page_Load(object sender, EventArgs e)
        {
            Patente = Convert.ToString(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["patente"]));
            IdCliente = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"]));
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));

            var dt = new InfoAutoBC().GetInfocarBySolicitud(IdSolicitud);
            int idAsociado = Convert.ToInt32(dt.Rows[0]["id_solicitud_asociada"]);



            if (idAsociado != 0)
            {
                dlTipoOperacion.Visible = false;
                ibIr.Visible = false;
                pnelAlto.Visible = true;
                lblMensaje.Text = $"Ya existe una operación con el número {idAsociado} asociado a este INFOCAR";
            }
            else
            {
                dlTipoOperacion.Visible = true;
                ibIr.Visible = true;
                pnelAlto.Visible = false;
                lblMensaje.Text = "Seleccione un tipo de operación";
                if (IsPostBack) return;
             FuncionGlobal.ComboProductosByFamiliaClienteUsuario(dlTipoOperacion, 3, Convert.ToInt16(IdCliente), Convert.ToString(Session["usrname"]));
            }

        }

        protected void ibIr_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToString(dlTipoOperacion.SelectedValue) != "0")
            {
                Response.Redirect(string.Format("../contrato_transferencia/ingreso_contrato.aspx?id_solicitud={0}&id_cliente={1}&tipo_operacion={2}&patente={3}&ventatipo={4}&id_solicitud_infocar={5}",
                  FuncionGlobal.FuctionEncriptar("0"),
                  FuncionGlobal.FuctionEncriptar(IdCliente.ToString()),
                  Convert.ToString(dlTipoOperacion.SelectedValue),
                  Patente.Trim(),
                  string.Empty,
                  FuncionGlobal.FuctionEncriptar(IdSolicitud.ToString()))
                  );
            }
            else
            {
                FuncionGlobal.alerta("Seleccione un tipo de operación", Page);
            }

        }
    }
}