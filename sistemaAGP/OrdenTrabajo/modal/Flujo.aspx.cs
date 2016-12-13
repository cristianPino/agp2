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
    public partial class Flujo : Page
    {
        public int IdOrdenTrabajoActividad;
        public OrdenTrabajoActividadLog Otra;
        public CENTIDAD.OrdenTrabajo Ot;
        protected void Page_Load(object sender, EventArgs e)
        {
           IdOrdenTrabajoActividad = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajoActividad"]));
           Otra = new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog
            {
                IdOrdenTrabajoActividadLog = IdOrdenTrabajoActividad
            });
            Ot=new OrdenTrabajoBC().GetOrdenTrabajo(Otra.OrdenTrabajo.IdOrden);
            if(IsPostBack)return;
            var dt = GetOperaciones(Otra);
            GetProducto(Otra);
            Llenagrid(dt);
        }

        public DataTable GetOperaciones(OrdenTrabajoActividadLog otra)
        {
           var lista =
                new OrdenTrabajoActividadLogBC().GetOrdenTrabajoFlujo(new OrdenTrabajoActividadLog
                    {
                        OrdenTrabajo = new CENTIDAD.OrdenTrabajo { IdOrden = otra.OrdenTrabajo.IdOrden }
                    }); 
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idOtAct"));
            dt.Columns.Add(new DataColumn("idOt"));
            dt.Columns.Add(new DataColumn("idActividad"));
            dt.Columns.Add(new DataColumn("actividad"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("idUsuario"));
            dt.Columns.Add(new DataColumn("inicio"));
            dt.Columns.Add(new DataColumn("termino"));
            dt.Columns.Add(new DataColumn("horas"));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("flujo"));
            dt.Columns.Add(new DataColumn("sla"));


          
            foreach (var ot in lista)
            {
                var dr = dt.NewRow();
                dr["idOtAct"] = ot.IdOrdenTrabajoActividadLog;
                dr["idOt"] = ot.OrdenTrabajo.IdOrden;
                dr["idActividad"] = ot.ActividadDeOrdenTrabajo.IdActividad;
                dr["actividad"] = ot.ActividadDeOrdenTrabajo.Descripcion;
                dr["usuario"] = ot.Usuario.Nombre;
                dr["idUsuario"] = ot.Usuario.UserName.ToUpper();
                dr["inicio"] = ot.FechaInicio;
                dr["termino"] = ot.Estado ==1?"":ot.FechaTermino;
                dr["sla"] = ot.ActividadDeOrdenTrabajo.Sla;
                dr["horas"] = ot.HorasActividad;
                var horas = ot.HorasActividad;
                var sla = ot.ActividadDeOrdenTrabajo.Sla;
                if(horas<(sla/2))
                {
                    dr["semaforo"] = "~/imagenes/sistema/static/verde.png";
                }
                else if(horas>=(sla/2)&& horas < sla)
                {
                    dr["semaforo"] = "~/imagenes/sistema/static/amarillo.png";
                }
                else if(horas >= sla)
                {
                    dr["semaforo"] = "~/imagenes/sistema/static/rojo.png";
                }
                // si la actividad es ingresada no tiene Sla y semaforo es verde.
                if (ot.ActividadDeOrdenTrabajo.IdActividad == 4) //4 = operacion ingresada
                {
                    dr["sla"] = 0;
                    dr["horas"] = 0;
                    dr["semaforo"] = "~/imagenes/sistema/static/verde.png";
                }


                var urlAvanza="";
                switch (ot.Avanza)
                {
                    case 1:
                        urlAvanza = "~/imagenes/sistema/static/flecha_arriba.png";
                        break;
                    case 2:
                        urlAvanza = "~/imagenes/sistema/static/flecha_abajo.png";
                        break;
                    default:
                        urlAvanza = "";
                        break;
                }
                dr["flujo"] = urlAvanza ;
                dt.Rows.Add(dr);      
            }
            return dt;

        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }

        public void Llenagrid(DataTable dt)
        {
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        public void GetProducto(OrdenTrabajoActividadLog otra)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("producto"));
            dt.Columns.Add(new DataColumn("urlEstadoOperacion"));
            dt.Columns.Add(new DataColumn("idSolicitud"));

            var lista = new OrdenTrabajoBC().GetordenTrabajoProducto(otra.OrdenTrabajo.IdOrden);  
            foreach (var ot in lista)
            {
                var dr = dt.NewRow();
              
                dr["producto"] = ot.TipoOperacion.Operacion;
               
                if (ot.Ok)
                {  
                    dr["idSolicitud"] = "Nº Agp " + ot.IdSolicitud;
                    dr["urlEstadoOperacion"] = "~/operacion/mWorkflow.aspx?id_solicitud="  + FuncionGlobal.FuctionEncriptar(ot.IdSolicitud.ToString(CultureInfo.InvariantCulture).Trim());
                }

                dt.Rows.Add(dr);
            }

          
            grOperacion.DataSource = dt;
            grOperacion.DataBind();
        }



    }
}