using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using System.Data;
using System.Globalization;

namespace sistemaAGP.controles
{
    public partial class wucIncidenciaResumenEjecutivo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var verdes = 0;
            var amarilla = 0;
            var rojas = 0;
            var dt = new IncidenciaBC().GetDatosResumen(Convert.ToString(Session["usrname"]), Constantes.SP_RESUMEN_EJECUTIVO);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var sla = Convert.ToInt32(dr["sla"]);
                    var tiempoLab = Convert.ToInt32(dr["tiempo_laboral"]);

                    if (tiempoLab < sla / 2)
                    {
                        //VERDE
                        verdes++;
                    }
                    else if (tiempoLab >= sla / 2 && tiempoLab < sla)
                    {
                        //AMARILLO
                        amarilla++;
                    }
                    else
                    {
                        //ROJO
                        rojas++;
                    }
                }

                var porcentajeRojas = rojas > 0 ? (Convert.ToDouble(rojas) / Convert.ToDouble(dt.Rows.Count) * 100) : 0;
                var porcentajeAmarilla = amarilla > 0 ? (Convert.ToDouble(amarilla) / Convert.ToDouble(dt.Rows.Count) * 100) : 0;
                var porcentajeVerde = verdes > 0 ? (Convert.ToDouble(verdes) / Convert.ToDouble(dt.Rows.Count) * 100) : 0;

                hpRojo.Text = Convert.ToString(rojas);
                hpVerdes.Text = Convert.ToString(verdes);
                hpAmarillo.Text = Convert.ToString(amarilla);
                hpTotal.Text = Convert.ToString(dt.Rows.Count);

                lblrojasprom.Text = Math.Round(porcentajeRojas, 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblAmarillasprom.Text = Math.Round(porcentajeAmarilla, 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblVerdesprom.Text = Math.Round(porcentajeVerde, 2).ToString(CultureInfo.InvariantCulture) + "%";

                string tipoResumen = Convert.ToString((int)Enums.TipoVistaResumen.Ejecutivo);

                hpRojo.NavigateUrl = "../Incidencias/ControlPanel.aspx?D=" + FuncionGlobal.FuctionEncriptar("CIN") +
                    "&origen=" + FuncionGlobal.FuctionEncriptar("true") + "&semaforo=" + FuncionGlobal.FuctionEncriptar("r")+
                    "&proc="+ FuncionGlobal.FuctionEncriptar(tipoResumen) ;
                hpVerdes.NavigateUrl = "../Incidencias/ControlPanel.aspx?D=" + FuncionGlobal.FuctionEncriptar("CIN") +
                    "&origen=" + FuncionGlobal.FuctionEncriptar("true") + "&semaforo=" + FuncionGlobal.FuctionEncriptar("v") +
                    "&proc=" + FuncionGlobal.FuctionEncriptar(tipoResumen);
                hpAmarillo.NavigateUrl = "../Incidencias/ControlPanel.aspx?D=" + FuncionGlobal.FuctionEncriptar("CIN") +
                    "&origen=" + FuncionGlobal.FuctionEncriptar("true") + "&semaforo=" + FuncionGlobal.FuctionEncriptar("a") +
                    "&proc=" + FuncionGlobal.FuctionEncriptar(Constantes.SP_RESUMEN_EJECUTIVO);
                hpTotal.NavigateUrl = "../Incidencias/ControlPanel.aspx?D=" + FuncionGlobal.FuctionEncriptar("CIN") +
                    "&origen=" + FuncionGlobal.FuctionEncriptar("true") + "&semaforo=" + FuncionGlobal.FuctionEncriptar("t") +
                    "&proc=" + FuncionGlobal.FuctionEncriptar(tipoResumen);

            }
        }
    }
}