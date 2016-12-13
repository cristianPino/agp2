using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.controles
{
    public partial class wucGrillaHipoteca : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void GetOperaciones(List<Hipotecario> lista, bool  sinSeleccionar)
        {

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idSolicitud"));
            dt.Columns.Add(new DataColumn("idCliente"));
            dt.Columns.Add(new DataColumn("ejecutivoIngreso"));
            dt.Columns.Add(new DataColumn("clienteNombre"));
            dt.Columns.Add(new DataColumn("tipoOperacion"));
            dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("numeroCliente"));
            dt.Columns.Add(new DataColumn("rutDeudor"));
            dt.Columns.Add(new DataColumn("nombreDeudor"));
            dt.Columns.Add(new DataColumn("idEstado"));
            dt.Columns.Add(new DataColumn("fechaIngreso"));
            dt.Columns.Add(new DataColumn("nombreEstado"));
            dt.Columns.Add(new DataColumn("contadorEstado"));
            dt.Columns.Add(new DataColumn("semaforoEstado"));
            dt.Columns.Add(new DataColumn("contadorOperacion"));
            dt.Columns.Add(new DataColumn("semaforoOperacion"));
            dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("urlEstado"));
            dt.Columns.Add(new DataColumn("urlCarpeta"));
            dt.Columns.Add(new DataColumn("urlTareas"));
            dt.Columns.Add(new DataColumn("urlHitos"));
            dt.Columns.Add(new DataColumn("url_contratos"));
            dt.Columns.Add(new DataColumn("url_escritura"));
            dt.Columns.Add(new DataColumn("tipoCredito"));
            dt.Columns.Add(new DataColumn("descripcionTipoOperacion"));
            dt.Columns.Add(new DataColumn("urlcambioEstado"));
            dt.Columns.Add(new DataColumn("soloLectura"));
            dt.Columns.Add(new DataColumn("ttsoloLectura"));
            dt.Columns.Add(new DataColumn("ordenEstado"));   

            foreach (var hipotecario in lista)
            {
                var dr = dt.NewRow();
                dr["idSolicitud"] = hipotecario.Operacion.Id_solicitud;
                dr["idCliente"] = hipotecario.Operacion.Cliente.Id_cliente;
                dr["clienteNombre"] = hipotecario.Operacion.Cliente.Persona.Nombre +
                                      hipotecario.Operacion.Cliente.Persona.Apellido_paterno;
                dr["tipoOperacion"] = hipotecario.Operacion.Tipo_operacion.Codigo;
                dr["operacion"] = hipotecario.Operacion.Tipo_operacion.Codigo;
                dr["numeroCliente"] = hipotecario.Operacion.Numero_cliente;
                dr["rutDeudor"] = hipotecario.Comprador == null ? "Sin info" : hipotecario.Comprador.Rut.ToString();
                dr["nombreDeudor"] = hipotecario.Comprador == null ? "Sin Deudor" : hipotecario.Comprador.Nombre + " " + hipotecario.Comprador.Apellido_paterno;
                dr["idEstado"] = hipotecario.Operacion.Id_estado;
                dr["nombreEstado"] = hipotecario.Estado;
                dr["contadorEstado"] = hipotecario.ContadorEtapa;
                dr["semaforoEstado"] = hipotecario.SemaforoImagen;
                dr["ejecutivoIngreso"] = hipotecario.EjecutivoIngreso.Nombre.ToUpper();
                var diasRestantes = hipotecario.Sla - hipotecario.ContadorOperacion;
                dr["contadorOperacion"] = diasRestantes;
                dr["semaforoOperacion"] = hipotecario.SemaforoOperacionImagen;

                dr["urlTareas"] = "../Operacion_Hipotecario/ingreso_hipotecario.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(hipotecario.Operacion.Id_solicitud.ToString());
                dr["urlTareas"] = dr["urlTareas"] + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(hipotecario.Operacion.Cliente.Id_cliente.ToString());
                dr["urlTareas"] = dr["urlTareas"] + "&tipo_operacion=" + hipotecario.Operacion.Tipo_operacion.Codigo;
                dr["urlTareas"] = dr["urlTareas"] + "&solo_lectura=" +
                FuncionGlobal.FuctionEncriptar(hipotecario.SoloLectura.ToString());
                dr["sucursal"] = hipotecario.Operacion.Sucursal.Nombre;
                dr["fechaIngreso"] = hipotecario.FechaIngreso;
                dr["urlEstado"] =  "../operacion/mWorkflow.aspx?&id_solicitud=" + FuncionGlobal.FuctionEncriptar(hipotecario.Operacion.Id_solicitud.ToString().Trim()) + "&nombre_estado=" + hipotecario.Operacion.Tipo_operacion.Operacion;
                dr["urlcambioEstado"] = sinSeleccionar
                                            ? "../operacion/mOperacion_estado.aspx?tipo=" +
                                              FuncionGlobal.FuctionEncriptar(
                                                  hipotecario.Operacion.Tipo_operacion.Codigo.Trim()) + "&id_cliente=" +
                                              FuncionGlobal.FuctionEncriptar(
                                                  hipotecario.Operacion.Cliente.Id_cliente.ToString()) +
                                              "&id_solicitud=" +
                                              FuncionGlobal.FuctionEncriptar(
                                                  hipotecario.Operacion.Id_solicitud.ToString().Trim()) +
                                              "&nombre_estado=" + hipotecario.Operacion.Tipo_operacion.Operacion
                                            : "";

                dr["tipoCredito"] = hipotecario.TipoCredito == "0"
                                        ? "Sin info"
                                        : new ParametroBC().getparametro("TICRE", hipotecario.TipoCredito).Valoralfanumerico;
                dr["descripcionTipoOperacion"] = hipotecario.DescripcionTipoOperacion;
                dr["urlCarpeta"] = "../digitalizacion/Visualizador.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(hipotecario.Operacion.Id_solicitud.ToString().Trim()) + "&tipo=" + hipotecario.Operacion.Tipo_operacion.Codigo.Trim();
                dr["urlHitos"] = "../operacion/SubEstados.aspx?id_solicitud=" + hipotecario.Operacion.Id_solicitud + "&id_estado=" + hipotecario.IdEstado;
                dr["soloLectura"] = hipotecario.SoloLectura == 0 ? "../imagenes/sistema/static/hipotecario/realizaCambios.png" : "../imagenes/sistema/static/hipotecario/soloLectura.png";
                dr["ttsoloLectura"] = hipotecario.SoloLectura == 0 ? "Puede modificar" : "Sólo lectura";
                dr["ordenEstado"] = hipotecario.OrdenEstadoActual;
                dt.Rows.Add(dr);


            }
           
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
            Ocultar(sinSeleccionar);

        } 
    
        public void Ocultar(bool sinSeleccionar)
        {
            //15=tareas 16=checks
            gr_dato.Columns[15].Visible = sinSeleccionar;
            gr_dato.Columns[16].Visible = !sinSeleccionar;
        }
        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(upGrillaHipoteca, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        public int Seleccionar()
        {
            var correctas = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {  
                var chk = (CheckBox) gr_dato.Rows[i].FindControl("chk");

                var id = Convert.ToInt32(gr_dato.DataKeys[i].Values["idSolicitud"]);
                var tipoOperacion = gr_dato.DataKeys[i].Values["tipoOperacion"].ToString();
                var ordenEstadoActual = Convert.ToInt32(gr_dato.DataKeys[i].Values["ordenEstado"]);
               
                if (!chk.Checked) continue;

                if (ordenEstadoActual != new EstadooperacionBC().getUltimoEstadoByIdoperacion(id).Estado_operacion.Orden) continue;
                new EstadooperacionBC().add_estado_orden(id, ordenEstadoActual + 1, tipoOperacion, "Seleccionado",
                                                         (string) (Session["usrname"]));
                correctas++;
            }
            return correctas;
        }

    }
}