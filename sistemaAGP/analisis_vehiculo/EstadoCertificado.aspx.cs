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


namespace sistemaAGP.analisis_vehiculo
{
    public partial class EstadoCertificado : System.Web.UI.Page
    {
        public int TotalFilas = 0;
        public List<InfoAuto> Lautos = new List<InfoAuto>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) return;
            txtDesde.Text = DateTime.Today.ToShortDateString();
            txtHasta.Text = DateTime.Today.ToShortDateString();
            CargaCombobox();
            GetAllChartCertificado();  
        }

        public void CargaCombobox()
        {
            FuncionGlobal.ComboClientesCertificados(dlCliente);
        }

        public int Get()
        {
            Lautos = new InfoAutoBC().GetCertificados(txtPatente.Text.Trim(),
                                                      Convert.ToInt32(dlCliente.SelectedValue),
                                                      string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtDesde.Text.Trim())),
                                                       string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtHasta.Text.Trim())));
            divBotones.Visible = Lautos.Count > 0;
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idSolicitud"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("urlCarpeta"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("tipoOperacion"));
            dt.Columns.Add(new DataColumn("codigoEstado"));
            dt.Columns.Add(new DataColumn("urlSemaforo"));

            foreach (var x in Lautos)
            {
                var dr = dt.NewRow();
                dr["idSolicitud"] = x.Id_solicitud;
                dr["tipoOperacion"] = x.DescripcionTipoOperacion.ToUpper();
                dr["usuario"] = x.Usuario.ToUpper();
                dr["codigoEstado"] = x.IdEstadoFamilia;
                dr["fecha"] = x.FechaAdquisicion;
                dr["patente"] = x.Patente.ToUpper();
                dr["estado"] = x.EstadoFamilia.ToUpper();
                dr["urlCarpeta"] = "../digitalizacion/Visualizador.aspx?id_solicitud=" +
                                   FuncionGlobal.FuctionEncriptar(x.Id_solicitud.ToString().Trim()) + "&tipo=" +
                                   x.TipoOperacion.Trim();
                if (x.IdEstadoFamilia == 86 || x.IdEstadoFamilia == 322 || x.IdEstadoFamilia == 323)
                {
                    dr["urlSemaforo"] = "../imagenes/sistema/static/verde.png";
                }
                else
                {
                    if (x.TiempoTranscurrido > 5)
                    {
                        dr["urlSemaforo"] = "../imagenes/sistema/static/warning.png";
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
            GetAllChartCertificado();
            var totalDocumentosCav = new InfoAutoBC().CantidadCErtificados(string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtDesde.Text.Trim())),
                                                                            string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtHasta.Text.Trim())),
                                                                           40, Convert.ToInt32(dlCliente.SelectedValue));
            var totalDocumentosMultas = new InfoAutoBC().CantidadCErtificados(string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtDesde.Text.Trim())),
                                                                            string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtHasta.Text.Trim())),
                                                                          41, Convert.ToInt32(dlCliente.SelectedValue));
            if (dlCliente.SelectedValue == "0")
            {
                lblInfo.Text = "Por favor, Seleccione un Cliente. Documentos: Cav=" + totalDocumentosCav + ". RNMV=" + totalDocumentosMultas+".";
                return;
            }
            var total = Get();
            if (total > 1)
            {
                lblInfo.Text = "Última acción: Ha seleccionado " + total.ToString(CultureInfo.InvariantCulture) +
                               " operaciones. Documentos: Cav=" + totalDocumentosCav + ". RNMV=" + totalDocumentosMultas + ".";
            }
            if (total == 0)
            {
                lblInfo.Text = "Última acción: No existen operaciones para el criterio de busqueda utilizado.";
            }
            if (total == 1)
            {
                lblInfo.Text = "Última acción: Ha seleccionado " + total.ToString(CultureInfo.InvariantCulture) +
                               " operación. Documentos: Cav=" + totalDocumentosCav + ". RNMV=" + totalDocumentosMultas + ".";
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
                var check = (CheckBox)e.Row.FindControl("chk");
                Int16 codigoEstado = Convert.ToInt16(this.gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString());
                if (codigoEstado == 86 || codigoEstado == 322 || codigoEstado == 323)
                {
                    check.Checked = false;
                    check.Visible = false;
                }


            }
            if (e.Row.RowType != DataControlRowType.Footer) return;
            e.Row.Cells[0].Text = "Total:";
            e.Row.Cells[1].Text = TotalFilas.ToString();
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Font.Bold = true;
        }

        public int Reset()
        {
            var correctas = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var id = Convert.ToInt32(gr_dato.DataKeys[i].Values["idSolicitud"]);

                if (!chk.Checked) continue;
                new InfoAutoBC().ReiniciaCertificados(id);
                correctas++;
            }
            return correctas;
        }

        protected void imAvanzar_Click(object sender, ImageClickEventArgs e)
        {
            var total = 0;
            try
            {
                total = Reset();
            }
            catch (Exception ex)
            {
                imgInfo.ImageUrl = "../imagenes/sistema/static/no-small.jpg";
                lblInfo.Text = "Error al intentar reiniciar. Descripción del error: " + ex.Message +
                               ". Comuniquese con informática.";
                return;
            }

            if (total > 1)
            {
                lblInfo.Text = "Última acción: Se han reiniciado " + total.ToString(CultureInfo.InvariantCulture) +
                               " operaciones.";
            }
            else
                switch (total)
                {
                    case 1:
                        lblInfo.Text = "Última acción: Se ha reiniciado " + total.ToString(CultureInfo.InvariantCulture) +
                                       " operación.";
                        break;
                    case 0:
                        lblInfo.Text =
                            "Última acción: No se han reiniciado operaciones. Para esto seleccione alguna operación que pueda ser reiniciada.";
                        break;
                }
            imgInfo.ImageUrl = "../imagenes/sistema/static/infoAuto/exclamacion.png";
        }


       public void GetAllChartCertificado()
       {
          ResetHidden();
          var cliente =  Convert.ToInt32(dlCliente.SelectedValue);
           htitulo.Value = dlCliente.SelectedValue == "0" ? "" : "por " + dlCliente.SelectedItem.Text;
          var listaCAv = new InfoAutoBC().GetChartTodosCertificado("CCAV", cliente);
          var listaCMul = new InfoAutoBC().GetChartTodosCertificado("CAMUL", cliente);

          var conteo = 0;
           foreach (var d in listaCAv)
           {
               conteo++;
               switch (conteo)
               {
                   case 1:
                       Ch1.Value = d.ChartMesConteo.ToString();
                       hmes1.Value = d.ChartMesDescripcion;
                       break;
                   case 2:
                       ch2.Value = d.ChartMesConteo.ToString();
                       hmes2.Value = d.ChartMesDescripcion;
                       break;
                   case 3:
                       ch3.Value = d.ChartMesConteo.ToString();
                       hmes3.Value = d.ChartMesDescripcion;
                       break;
                   case 4:
                       ch4.Value = d.ChartMesConteo.ToString();
                       hmes4.Value = d.ChartMesDescripcion;
                       break;
                   case 5:
                       ch5.Value = d.ChartMesConteo.ToString();
                       hmes5.Value = d.ChartMesDescripcion;
                       break;
                   case 6:
                       ch6.Value = d.ChartMesConteo.ToString();
                       hmes6.Value = d.ChartMesDescripcion;
                       break;
                   case 7:
                       ch7.Value = d.ChartMesConteo.ToString();
                       hmes7.Value = d.ChartMesDescripcion;
                       break;
                   case 8:
                       ch8.Value = d.ChartMesConteo.ToString();
                       hmes8.Value = d.ChartMesDescripcion;
                       break;
                   case 9:
                       ch9.Value = d.ChartMesConteo.ToString();
                       hmes9.Value = d.ChartMesDescripcion;
                       break;
                   case 10:
                       ch10.Value = d.ChartMesConteo.ToString();
                       hmes10.Value = d.ChartMesDescripcion;
                       break;
                   case 11:
                       ch11.Value = d.ChartMesConteo.ToString();
                       hmes11.Value = d.ChartMesDescripcion;
                       break;
                   case 12:
                       ch12.Value = d.ChartMesConteo.ToString();
                       hmes12.Value = d.ChartMesDescripcion;
                       break; 
               }
           }



           foreach (var d in listaCMul)
           {
             if(hmes1.Value == d.ChartMesDescripcion)
             {
                 mh1.Value = d.ChartMesConteo.ToString();
             }
             else if(hmes2.Value == d.ChartMesDescripcion)
             {
                 mh2.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes3.Value == d.ChartMesDescripcion)
             {
                 mh3.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes4.Value == d.ChartMesDescripcion)
             {
                 mh4.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes5.Value == d.ChartMesDescripcion)
             {
                 mh5.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes6.Value == d.ChartMesDescripcion)
             {
                 mh6.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes7.Value == d.ChartMesDescripcion)
             {
                 mh7.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes8.Value == d.ChartMesDescripcion)
             {
                 mh8.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes9.Value == d.ChartMesDescripcion)
             {
                 mh9.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes10.Value == d.ChartMesDescripcion)
             {
                 mh10.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes11.Value == d.ChartMesDescripcion)
             {
                 mh11.Value = d.ChartMesConteo.ToString();
             }
             else if (hmes12.Value == d.ChartMesDescripcion)
             {
                 mh12.Value = d.ChartMesConteo.ToString();
             }
           }          

           //foreach (var d in listaCMul)
           //{
             
           //    switch (cont2)
           //    {
           //        case 1:
           //            mh1.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 2:
           //            mh2.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 3:
           //            mh3.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 4:
           //            mh4.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 5:
           //            mh5.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 6:
           //            mh6.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 7:
           //            mh7.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 8:
           //            mh8.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 9:
           //            mh9.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 10:
           //            mh10.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 11:
           //            mh11.Value = d.ChartMesConteo.ToString();
           //            break;
           //        case 12:
           //            mh12.Value = d.ChartMesConteo.ToString();
           //            break;
           //    }
           //}
       }
        public void ResetHidden()
        {
            Ch1.Value = "0";
            ch2.Value = "0";
            ch3.Value = "0";
            ch4.Value = "0";
            ch5.Value = "0";
            ch6.Value = "0";
            ch7.Value = "0";
            ch8.Value = "0";
            ch9.Value = "0";
            ch10.Value = "0";
            ch11.Value = "0";
            ch12.Value = "0";

            mh1.Value = "0";
            mh2.Value = "0";
            mh3.Value = "0";
            mh4.Value = "0"; 
            mh5.Value = "0";
            mh6.Value = "0";
            mh7.Value = "0";
            mh8.Value = "0";
            mh9.Value = "0";
            mh10.Value = "0";
            mh11.Value = "0";
            mh12.Value = "0";

            hmes1.Value = "";
            hmes2.Value = "";
            hmes3.Value = "";
            hmes4.Value = "";
            hmes5.Value = "";
            hmes6.Value = "";
            hmes7.Value = "";
            hmes8.Value = "";
            hmes9.Value = "";
            hmes10.Value = "";
            hmes11.Value = "";
            hmes12.Value = "";


        }




    }
}