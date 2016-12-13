using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.OrdenTrabajo.modal
{
    public partial class Grafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            LlenaGrafico();
        }
        public void LlenaGrafico()
        {
            try
            {  
                var lista =
               new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyUsuarioGrafico(new OrdenTrabajoActividadLog()
               {
                   Usuario = new Usuario { UserName = Session["usrname"].ToString() },
                   OrdenTrabajo = new CENTIDAD.OrdenTrabajo { NumeroOrden = "0" },
                   ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 0 }
               });

                var esperaFactVerde = 0;
                var esperaFactAmarillo = 0;
                var esperaFacturaRojo = 0;

                var esperaAsignacionVerde = 0;
                var esperaAsignacionAmarillo = 0;
                var esperaAsignacionRojo = 0;

                var esperaIngresoVerde = 0;
                var esperaIngresoAmarillo = 0;
                var esperaIngresoRojo = 0;

                var reparoVerde = 0;
                var reparoAmarillo = 0;
                var reparoRojo = 0;

                foreach (var ot in lista)
                {
                    var horas = ot.HorasActividad;
                    var sla = ot.ActividadDeOrdenTrabajo.Sla;

                    if (horas < (sla / 2))
                    {
                        switch (ot.ActividadDeOrdenTrabajo.IdActividad)
                        {
                            case 1:
                                esperaFactVerde++;
                                break;
                            case 2:
                                esperaAsignacionVerde++;
                                break;
                            case 3:
                                esperaIngresoVerde++;
                                break;
                            case 6:
                                reparoVerde++;
                                break;
                        }
                    }
                    else if (horas >= (sla / 2) && horas < sla)
                    {
                        switch (ot.ActividadDeOrdenTrabajo.IdActividad)
                        {
                            case 1:
                                esperaFactAmarillo++;
                                break;
                            case 2:
                                esperaAsignacionAmarillo++;
                                break;
                            case 3:
                                esperaIngresoAmarillo++;
                                break;
                            case 6:
                                reparoAmarillo++;
                                break;
                        }

                    }
                    else if (horas >= sla)
                    {
                        switch (ot.ActividadDeOrdenTrabajo.IdActividad)
                        {
                            case 1:
                                esperaFacturaRojo++;
                                break;
                            case 2:
                                esperaIngresoRojo++;
                                break;
                            case 3:
                                esperaAsignacionRojo++;
                                break;
                            case 6:
                                reparoRojo++;
                                break;
                        }
                    }
                }

                hdFacturaVerde.Value = esperaFactVerde.ToString(CultureInfo.InvariantCulture);
                hdFacturaAmarillo.Value = esperaFactAmarillo.ToString(CultureInfo.InvariantCulture);
                hdFacturaRojo.Value = esperaFacturaRojo.ToString(CultureInfo.InvariantCulture);

                hdAsignacionVerde.Value = esperaAsignacionVerde.ToString(CultureInfo.InvariantCulture);
                hdAsignacionAmarillo.Value = esperaAsignacionAmarillo.ToString(CultureInfo.InvariantCulture);
                hdAsignacionRojo.Value = esperaAsignacionRojo.ToString(CultureInfo.InvariantCulture);

                hdIngresoVerde.Value = esperaIngresoVerde.ToString(CultureInfo.InvariantCulture);
                hdIngresoAmarillo.Value = esperaIngresoAmarillo.ToString(CultureInfo.InvariantCulture);
                hdIngresoRojo.Value = esperaIngresoRojo.ToString(CultureInfo.InvariantCulture);

                hdReparoVerde.Value = reparoVerde.ToString(CultureInfo.InvariantCulture);
                hdReparoAmarillo.Value = reparoAmarillo.ToString(CultureInfo.InvariantCulture);
                hdIngresoRojo.Value = reparoRojo.ToString(CultureInfo.InvariantCulture);


            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta(ex.Message,this.Page);
            }

        }
    }
}