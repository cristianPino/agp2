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
    public partial class reparos : System.Web.UI.Page
    {
        public int IdOrdenTrabajo;
        public int IdOrdenTrabajoActividad;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_orden_trabajo"]));
            IdOrdenTrabajoActividad = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajoActividad"]));
            
            hdIdOrdenTrabajo.Value = IdOrdenTrabajo.ToString(CultureInfo.InvariantCulture);
            hdIdOrdenTrabajoActividad.Value = IdOrdenTrabajoActividad.ToString(CultureInfo.InvariantCulture);
            if(IsPostBack)return;
            GetReparo(new OrdenTrabajoBC().GetReparos(IdOrdenTrabajo, "una"));
            GetAll();
        }


        public void GetReparo(DataTable dt)
        {    

            foreach (DataRow r in dt.Rows)
            {
                lblTipoReparo.Text = Convert.ToString(r["tipo_reparo_descripcion"]);
                lblParametroTipoResponsable.Text = Convert.ToString(r["tipo_responsable_solucion"]);
                lblSla.Text = Convert.ToString(r["tipo_reparo_sla"]);
                lblTiempo.Text = Convert.ToString(r["tiempo_transcurrido"]);
                lblUsuarioIngresoReparo.Text = Convert.ToString(r["usuario_ingreso_reparo_nombre"]);
                lblEstadoReparo.Text = Convert.ToInt32(r["estado_subsano"])== 0 ? "ESPERANDO SUBSANO" : "SUBSANADO";
                lblObservacion.Text = Convert.ToString(r["observacion_preliminar"]);      
                lblUsuarioResponsable.Text = Convert.ToString(r["usuario_responsable_reparo_nombre"]);
                lblFechaIngreso.Text = Convert.ToString(r["fecha_ingreso"]);
                hdIdReparo.Value = Convert.ToString(r["id_reparo"]);

                //calcula semaforo
                var tiempotranscurrido = Convert.ToInt32(r["tiempo_transcurrido"]);
                var sla = Convert.ToInt32(r["tipo_reparo_sla"]);
                var slaDivision = Convert.ToDecimal(sla)/2;

                if(tiempotranscurrido >= sla)
                {   //rojo
                    imgSemaforo.ImageUrl = "~/imagenes/sistema/static/no.jpg";
                }
                else if (Convert.ToDecimal(tiempotranscurrido) <= slaDivision)
                {
                    //verde
                    imgSemaforo.ImageUrl = "~/imagenes/sistema/static/verde.png";
                }
                else if (Convert.ToDecimal(tiempotranscurrido) > slaDivision && tiempotranscurrido < sla)
                {   
                    //amarillo
                    imgSemaforo.ImageUrl = "~/imagenes/sistema/static/amarillo.png";
                }

            }

        }

        public void GetAll()
        {
            var dt = new OrdenTrabajoBC().GetReparos(IdOrdenTrabajo, "todo");
            var newdt = new DataTable();
            newdt.Columns.Add(new DataColumn("id_reparo"));
            newdt.Columns.Add(new DataColumn("tipo_reparo"));
            newdt.Columns.Add(new DataColumn("usuarioIngreso"));
            newdt.Columns.Add(new DataColumn("inicio"));
            newdt.Columns.Add(new DataColumn("termino"));
            newdt.Columns.Add(new DataColumn("sla"));
            newdt.Columns.Add(new DataColumn("horas"));
            newdt.Columns.Add(new DataColumn("semaforo"));

            foreach (DataRow dato in dt.Rows)
            {
                var dr = newdt.NewRow();
                dr["id_reparo"] = Convert.ToString(dato["id_reparo"]);
                dr["tipo_reparo"] = Convert.ToString(dato["tipo_reparo_descripcion"]);
                dr["usuarioIngreso"] = Convert.ToString(dato["usuario_ingreso_reparo_nombre"]);
                dr["inicio"] = Convert.ToString(dato["fecha_ingreso"]);
                dr["termino"] = Convert.ToInt32(dato["estado_subsano"]) == 0 ? "ESPERANDO SUBSANO" : Convert.ToString(dato["fecha_solucion"]);
                dr["sla"] = Convert.ToString(dato["tipo_reparo_sla"]);
                dr["horas"] = Convert.ToString(dato["tiempo_transcurrido"]);
                //calcula semaforo
                var tiempotranscurrido = Convert.ToInt32(dato["tiempo_transcurrido"]);
                var sla = Convert.ToInt32(dato["tipo_reparo_sla"]);
                var slaDivision = Convert.ToDecimal(sla) / 2;

                if (tiempotranscurrido >= sla)
                {   //rojo
                    dr["semaforo"] = "~/imagenes/sistema/static/no.jpg";
                }
                else if (Convert.ToDecimal(tiempotranscurrido) <= slaDivision)
                {
                    //verde
                    dr["semaforo"] = "~/imagenes/sistema/static/verde.png";
                }
                else if (Convert.ToDecimal(tiempotranscurrido) > slaDivision && tiempotranscurrido < sla)
                {
                    //amarillo
                   dr["semaforo"] = "~/imagenes/sistema/static/amarillo.png";
                }

                newdt.Rows.Add(dr);    
                
            }

            grHistorial.DataSource = newdt;
            grHistorial.DataBind();

        }

        protected void btnSubsano_Click(object sender, EventArgs e)
        {
            //actualiza el reparo lo deja subsanado
            new OrdenTrabajoBC().AddReparo(Convert.ToInt32(hdIdReparo.Value), Convert.ToInt32(hdIdOrdenTrabajo.Value), 0, "", "", "", "", 1);

            //avanza de actividad
            const int siguienteActividad = 2;
            var siguienteUsuario = "";

            foreach (var usuarios in new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(
                                       new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = siguienteActividad } },"0", 0))
            {
                siguienteUsuario = usuarios.Usuario.UserName;
            }
            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = siguienteUsuario
                    ,
                    IdOrden = Convert.ToInt32(hdIdOrdenTrabajo.Value)
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = siguienteActividad },
                Avanza = 1,
                IdOrdenTrabajoActividadLog = Convert.ToInt32(hdIdOrdenTrabajoActividad.Value)
            });

            //carga nuevamente el reparo
            GetReparo(new OrdenTrabajoBC().GetReparosById(Convert.ToInt32(hdIdReparo.Value)));
            FuncionGlobal.alerta_updatepanel("Reparo subsanado correctamente",Page,upd);
        }
    }
}