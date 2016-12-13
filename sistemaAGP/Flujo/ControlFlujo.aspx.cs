using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.Flujo
{
    public partial class ControlFlujo : Page
    {   
        public int IdSolicitud;
        public int EstadoActual;
        public string Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
            EstadoActual = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo_estado"]));
            Tipo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["tipo"]);
            if(IsPostBack)return;
            //Traigo el codigo estado de la segunda fila de la tbl_estado_operacion
            var estadoOrigen = new ComportamientoEstadoBC().GetEstadoOrigen(IdSolicitud).Estado_origen;
            //seteo los hiddens para conservar los valores
            hdEstadoActual.Value = EstadoActual.ToString(CultureInfo.InvariantCulture);
            hdEstadoOrigen.Value = estadoOrigen.ToString(CultureInfo.InvariantCulture);
            hdIdSolicitud.Value = IdSolicitud.ToString(CultureInfo.InvariantCulture);
            //traigo una lista con los estados disponibles
            var lista = GetFlujo(EstadoActual,estadoOrigen);
            //si existen estados manuales
            if (lista.Any())
            {
                //lleno el combo de estados
                LlenaEstados(lista);
            }
            else
            {   //si no existen siguientes actividades se ocultan los botones avanzar y todo lo correspondiente al avance de la operación
                SinActividadSiguiente();
            }   
            //cargo el formulario
            CargaObjetosForm(EstadoActual, estadoOrigen, IdSolicitud);
            //cargo todos los estados
            Getestadowork(IdSolicitud);
        }

        private static IEnumerable<ComportamientoEstado> GetFlujo(int estadoActual,int estadoOrigen)
        {   
            //Con los estados cargo una lista con los estados disponibles
           return new ComportamientoEstadoBC().GetComportamientoFlujo(estadoActual, estadoOrigen);
        }

        public void CargaObjetosForm(int codigoEstadoActual,int codigoEestadoOrigen, int idSolicitud)
        {
            //Setea los objetos del formulario ...labels, textboxs, etc
            var estadoActual = new EstadooperacionBC().getEstadobycodigoestado(IdSolicitud, codigoEstadoActual);
            var estadoOrigen = new EstadooperacionBC().getEstadobycodigoestado(IdSolicitud, codigoEestadoOrigen);    
            lblActual.Text = estadoActual.Estado_operacion.Descripcion.ToUpper();
            lblOrigen.Text = estadoOrigen.Estado_operacion==null? "SIN ESTADO ANTERIOR": estadoOrigen.Estado_operacion.Descripcion.ToUpper();
        }



        private void LlenaEstados(IEnumerable<ComportamientoEstado> lista)
        {
            //Lena el combobox con los estados permitidos para avanzar. 
            dlEstados.Items.Clear();
            dlEstados.AppendDataBoundItems = true;
            dlEstados.Items.Add(new ListItem("¿Siguiente Estado?", "0", true));
            dlEstados.DataSource = lista;
            dlEstados.DataTextField = "EstadoFinalDescripcion";
            dlEstados.DataValueField = "Estado_final";
            dlEstados.DataBind();
        }

        protected void Getestadowork(int idSolicitud)
        {
            var lEstadooperacion = new EstadooperacionBC().getEstadoByoperacion(idSolicitud, (string)(Session["usrname"]));
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_estado"));
            dt.Columns.Add(new DataColumn("activo"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("cuenta_usuario"));
            dt.Columns.Add(new DataColumn("nombre_usuario"));
            dt.Columns.Add(new DataColumn("observacion"));
            dt.Columns.Add(new DataColumn("contador"));
            dt.Columns.Add(new DataColumn("semaforo"));

            foreach (var mestadooperacion in lEstadooperacion)
            {
                var dr = dt.NewRow();
                dr["id_estado"] = mestadooperacion.Id_estado.ToString().Trim();
                dr["activo"] = mestadooperacion.Activo.ToString().Trim();
                dr["estado"] = mestadooperacion.Estado_operacion.Descripcion;
                dr["fecha"] = mestadooperacion.Fecha_hora;
                dr["cuenta_usuario"] = mestadooperacion.Usuario.UserName;
                dr["nombre_usuario"] = mestadooperacion.Usuario.Nombre;
                dr["observacion"] = mestadooperacion.Observacion;
                dr["semaforo"] = mestadooperacion.Semaforo.Trim();
                dr["contador"] = mestadooperacion.Contador.ToString().Trim();

               //pinto los bordes superiores de los estados origen y actual con el color de semaforo 
                if (mestadooperacion.Estado_operacion.Descripcion.Trim() == lblOrigen.Text.Trim())
                {
                    switch (mestadooperacion.Semaforo.Trim())
                    {
                        case  "~/imagenes/sistema/static/rojo.png":
                            divEstadoOrigen.Style.Add("border-top-color","red");
                            break;
                        case "~/imagenes/sistema/static/amarillo.png":
                            divEstadoOrigen.Style.Add("border-top-color", "yellow");
                            break;
                        case "~/imagenes/sistema/static/verde.png":
                            divEstadoOrigen.Style.Add("border-top-color", "green");
                            break;
                    }
                }
                if (mestadooperacion.Estado_operacion.Descripcion.Trim() == lblActual.Text.Trim())
                {
                    switch (mestadooperacion.Semaforo.Trim())
                    {
                        case "~/imagenes/sistema/static/rojo.png":
                            divEstadoActual.Style.Add("border-top-color", "red");
                            break;
                        case "~/imagenes/sistema/static/amarillo.png":
                            divEstadoActual.Style.Add("border-top-color", "yellow");
                            break;
                        case "~/imagenes/sistema/static/verde.png":
                            divEstadoActual.Style.Add("border-top-color", "#a1ca6f");
                            break;
                    }
                }

                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var idEstado = Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString());
            var activo = Convert.ToBoolean(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());
            var op = new TipooperacionBC().getTipooperacion(Tipo);  
            if (activo == false)
            {
                e.Row.BackColor = Color.LightBlue;
            }
            var but1 = (HyperLink)e.Row.Cells[0].Controls[0];
            but1.Attributes.Add("onclick", "javascript:window.showModalDialog('../operacion/SubEstados.aspx?id_solicitud=" + IdSolicitud + "&id_estado=" + idEstado + "','_blank','" + op.Tamano + "')");
        }

        private void SinActividadSiguiente()
        {
            //seteo el formulario al estado solo lectura
            divBotones.Visible = false;
            dlEstados.Visible = false;
            tdComentario.Visible = false;
            imgCono.Visible = true;//muestra un mensaje indicando que no existen mas actividades manuales
        }

        protected void ibTerminar_Click(object sender, ImageClickEventArgs e)
        {
           if(dlEstados.SelectedValue=="0")
           {
               FuncionGlobal.alerta("Seleccione un estado",Page);
               return;
           }
            try
            {
                var resultado = Avanzar();
                if (resultado != "")
                {
                    FuncionGlobal.alerta(resultado, Page);
                    return;
                }
                //traigo una lista con los estados disponibles, pero  el estado seleccionado recientemente es el actual y el que era estado actual ahora es el origen
                var lista = GetFlujo(Convert.ToInt32(dlEstados.SelectedValue), Convert.ToInt32(hdEstadoActual.Value));
                //si existen estados manuales
                if (lista.Any())
                {
                    //lleno el combo de estados
                    LlenaEstados(lista);
                }
                else
                {   //si no existen siguientes actividades se ocultan los botones avanzar y todo lo correspondiente al avance de la operación
                    SinActividadSiguiente();
                }   
                //cargo el formulario  pero  el estado seleccionado recientemente es el actual y el que era estado actual ahora es el origen
                CargaObjetosForm(Convert.ToInt32(dlEstados.SelectedValue), Convert.ToInt32(hdEstadoActual.Value.Trim()), Convert.ToInt32(hdIdSolicitud.Value.Trim()));
                //cargo todos los estados
                Getestadowork(Convert.ToInt32(hdIdSolicitud.Value.Trim()));
                FuncionGlobal.alerta("¡Bien! Cambios realizados correctamente", Page);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta("Ups!..Algo ha ocurrido intentelo de nuevo o comuniquese con su área de informática. Descripción del error: " + ex.Message, Page); 
            }
         
        }

        public string  Avanzar()
        {   
            return new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(hdIdSolicitud.Value.Trim()), Convert.ToInt32(dlEstados.SelectedValue), txtObservacion.Value.Trim(), (string)(Session["usrname"]));
        }


    }
}