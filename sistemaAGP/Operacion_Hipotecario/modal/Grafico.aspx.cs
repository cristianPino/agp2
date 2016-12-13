using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.Operacion_Hipotecario.modal
{
    public partial class Grafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if(IsPostBack)return;
              //trae una lista con las operaciones y sus semaforos y estados actuales
              var lista = new HipotecarioBC().GetUsuarioDashboard(Session["usrname"].ToString().Trim());
              GetGrafico(lista);
        }
        /// <summary>
        /// Grafico()
        /// Llena el gráfico los hiddenfield para los gráficos
        /// Es llamado desde el método UsuarioDAshboard()
        /// </summary>
        /// <param name="listaSemaforo"></param>
        private void GetGrafico(List<Hipotecario> listaSemaforo)
        {
            //llena una lista con los estados de operacion que puede ver
            var listaActividades = from d in new UsuarioEstadoBC().get_all(Session["usrname"].ToString(), 22) where d.Pertenece select d;

            var num = 1;  //se usa esta variable para ir cambiando de nombre los hidden
            foreach (var ac in listaActividades)
            {   //se llenan los hidden de la página para mostrar la información del gráfico por javascript.
                var hidenEstado = (HiddenField)udp.FindControl("e" + num.ToString(CultureInfo.InvariantCulture));
                hidenEstado.Value = ac.NombreEstado;
                var hidenVerde = (HiddenField)udp.FindControl("v" + num.ToString(CultureInfo.InvariantCulture));
                var hidenamarillo = (HiddenField)udp.FindControl("a" + num.ToString(CultureInfo.InvariantCulture));
                var hidenrojo = (HiddenField)udp.FindControl("r" + num.ToString(CultureInfo.InvariantCulture));
                var verde = 0;
                var rojo = 0;
                var amarillo = 0;
                foreach (var sem in listaSemaforo)
                {
                    if (sem.EstadoDescripcion.Trim() != ac.NombreEstado.Trim()) continue;
                    switch (sem.SemaforoImagen.Trim())
                    {
                        case "~/imagenes/sistema/static/verde.png":
                            verde++;
                            break;
                        case "~/imagenes/sistema/static/amarillo.png":
                            amarillo++;
                            break;
                        case "~/imagenes/sistema/static/rojo.png":
                            rojo++;
                            break;
                    }
                }
                hidenVerde.Value = verde.ToString(CultureInfo.InvariantCulture);
                hidenamarillo.Value = amarillo.ToString(CultureInfo.InvariantCulture);
                hidenrojo.Value = rojo.ToString(CultureInfo.InvariantCulture);

                num++;
            }
        }
    }
}