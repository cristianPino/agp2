using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization; 
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.analisis_vehiculo
{
    public partial class Infocar : Page
    {

        public int TotalFilas = 0;
        public List<InfoAuto> Lautos = new List<InfoAuto>();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(IsPostBack)return;
            CargaCombobox();
        }

        public void CargaCombobox()
        {  
            FuncionGlobal.comboparametro(dlMes, "TB");
            dlMes.Items.RemoveAt(0);
        }

        public int Get()
        {
            Lautos = new InfoAutoBC().GetInfoCarPublico(Convert.ToInt32(txtOc.Text.Trim() == "" ? "0" : txtOc.Text.Trim()), txtPatente.Text.Trim(), Convert.ToInt32(dlMes.SelectedValue));
            divBotones.Visible = Lautos.Count > 0;
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idSolicitud"));
            dt.Columns.Add(new DataColumn("oc"));
            dt.Columns.Add(new DataColumn("correo"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("urlTareas"));
            dt.Columns.Add(new DataColumn("codigoEstado"));
            dt.Columns.Add(new DataColumn("urlCarpeta"));
            dt.Columns.Add(new DataColumn("urlSemaforo"));
            dt.Columns.Add(new DataColumn("urlProcesos"));

            foreach (var x in Lautos)
            {
                var dr = dt.NewRow();
                dr["idSolicitud"] = x.Id_solicitud;
                dr["oc"] = x.OrdenCompra.ToString();
                dr["correo"] = x.CorreoComprador;
                dr["codigoEstado"] = x.IdEstadoFamilia;
                dr["fecha"] = x.FechaAdquisicion;
                dr["patente"] = x.Patente.ToUpper();
                dr["estado"] = x.EstadoFamilia.ToUpper();
                dr["urlProcesos"] = x.EstadoFamilia.ToUpper();
                dr["urlCarpeta"] = "../digitalizacion/Visualizador.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(x.Id_solicitud.ToString().Trim()) + "&tipo=" + "INFAU";
                dr["urlTareas"] = "IngresoAutopistas.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(x.Id_solicitud.ToString().Trim()) + "&patente=" + FuncionGlobal.FuctionEncriptar(x.Patente);
                dr["urlProcesos"] = @"../preinscripcion/InfoAutoProcesos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(x.Id_solicitud.ToString().Trim());
                if (x.EstadoFamilia.Trim() == "TERMINADO" || x.EstadoFamilia.Trim() == "TRAMITE TERMINADO - EN COBRANZA" || x.EstadoFamilia.Trim() == "TRAMITE EN TRANSFERENCIA - NO APLICA COBRANZA")
                {
                    dr["urlSemaforo"] = "../imagenes/sistema/static/verde.png";
                }
                else
                {
                    if (x.TiempoTranscurrido > 5 && x.TiempoTranscurrido < 60)
                    {
                        dr["urlSemaforo"] = "../imagenes/sistema/static/warning.png";
                    }
                    else if(x.TiempoTranscurrido >= 60)
                    {
                        dr["urlSemaforo"] = "../imagenes/sistema/static/no-small.jpg";
                    }
                    else
                    {
                        dr["urlSemaforo"] = "../imagenes/sistema/static/verde.png";
                    }
                }
                dt.Rows.Add(dr);
            }

            gr_dato.DataSource = dt;
            gr_dato.DataBind();
            return Lautos.Count;
        }

        protected void imBuscar_Click(object sender, ImageClickEventArgs e)
        {   
            var total = Get();
            if (total > 1)
            {
                lblInfo.Text = "Última acción: Ha seleccionado " + total.ToString(CultureInfo.InvariantCulture) + " operaciones.";
            }
            if (total == 0)
            {
                lblInfo.Text = "Última acción: No existen operaciones para el criterio de busqueda utilizado.";
            }
            if (total == 1)
            {
                lblInfo.Text = "Última acción: Ha seleccionado " + total.ToString(CultureInfo.InvariantCulture) + " operación.";
            }
            imgInfo.ImageUrl = "../imagenes/sistema/static/infoAuto/exclamacion.png";
        }

        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(upGrillaHipoteca, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalFilas++;
               
                var imgTareas = (HyperLink)e.Row.FindControl("lnk_tareas");
                var btnTrabajar = (ImageButton)e.Row.FindControl("ImageButton1");
                var chk = (CheckBox)e.Row.FindControl("chk");
                
                var estado = gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();
                if(estado =="EN ANALISIS")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#343536");
                    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                }

                if (estado == "EN ANALISIS" || estado =="TERMINADO C/FALTANTE" )
                {
                    imgTareas.Enabled = true;
                }
                else
                {
                    imgTareas.Enabled = false;
                }

                if (estado == "TERMINADO" || estado == "TRAMITE TERMINADO - EN COBRANZA" || estado == "TRAMITE EN TRANSFERENCIA - NO APLICA COBRANZA")
                {
                    chk.Checked = false;
                    chk.Visible = false;
                }
                else
                {
                    chk.Visible = true;
                }

                btnTrabajar.Visible = estado.Trim() == "ESPERANDO EJECUTIVO";


            }
            if (e.Row.RowType != DataControlRowType.Footer) return;
            e.Row.Cells[0].Text = "Total:";
            e.Row.Cells[1].Text = TotalFilas.ToString(CultureInfo.InvariantCulture);
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Font.Bold = true;
        }

        protected void gr_dato_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "trabajar") return;

            var index = Convert.ToInt32(e.CommandArgument);
            var row = gr_dato.Rows[index];
            var id = Convert.ToInt32(gr_dato.DataKeys[index]["idSolicitud"]);
            var estado = gr_dato.DataKeys[index]["estado"].ToString();
            var imgTrabajar = (HyperLink)row.FindControl("lnk_tareas");
            var btnTrabajar = (ImageButton)row.FindControl("ImageButton1");
            imgTrabajar.Enabled = true;
            btnTrabajar.Visible = false;     
            new EstadooperacionBC().add_estado_orden(id, 5, "INFAU", "tomado para analisis", (string)(Session["usrname"]));
            row.Cells[5].Text = "EN ANALISIS";
            row.BackColor = System.Drawing.ColorTranslator.FromHtml("#343536");
            row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        }

        public int Reset()
        {
            var correctas = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var id = Convert.ToInt32(gr_dato.DataKeys[i].Values["idSolicitud"]);

                if (!chk.Checked) continue;
                new InfoAutoBC().Reset_solicitudDVCancelar(id);
                correctas++;
            }
            return correctas;
        }

        protected void imAvanzar_Click(object sender, ImageClickEventArgs e)
        {
            var total = 0;
            try { total = Reset(); }
            catch (Exception ex)
            {
                imgInfo.ImageUrl = "../imagenes/sistema/static/no-small.jpg";
                lblInfo.Text = "Error al intentar reiniciar. Descripción del error: " + ex.Message +
                               ". Comuniquese con informática.";
                return;
            }

            if (total > 1)
            {
                lblInfo.Text = "Última acción: Se han reiniciado " + total.ToString(CultureInfo.InvariantCulture) + " operaciones.";
            }
            else switch (total)
                {
                    case 1:
                        lblInfo.Text = "Última acción: Se ha reiniciado " + total.ToString(CultureInfo.InvariantCulture) + " operación.";
                        break;
                    case 0:
                        lblInfo.Text = "Última acción: No se han reiniciado operaciones. Para esto seleccione alguna operación que pueda ser reiniciada.";
                        break;
                }
            imgInfo.ImageUrl = "../imagenes/sistema/static/infoAuto/exclamacion.png";
            Get();
        }
    }
}