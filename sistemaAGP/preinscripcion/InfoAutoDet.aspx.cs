using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using System.Timers;
using Timer = System.Timers.Timer;

namespace sistemaAGP
{
    public partial class InfoAutoDet : Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMensajeAnalisis();
            if (IsPostBack) return;
            txtDesde.Text = DateTime.Today.ToShortDateString();
            txtHasta.Text = DateTime.Today.ToShortDateString();
            FuncionGlobal.comboEstadoByFamilia(dlEstado,21); 
            GetAutos();
            GetCav();
            GetCavMultas();
        }


        private void GetMensajeAnalisis()
        {
            var dt= new InfoAutoBC().GetMensajeAnalisis();
            lblMensajeAnalisis.Text = "Bienvenido";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["estado"].ToString().Trim().ToLower() == "true")
                {
                    lblMensajeAnalisis.Text = dr["mensaje"].ToString();
                }
            
            }
        }


        protected void GetAutos()
        {
            var operacion = 0; 
            if (txt_operacion.Text != "")
            {
                operacion = Convert.ToInt32(txt_operacion.Text);
            }

            

            var lautos = new InfoAutoBC().GetInfoAuto(operacion,
                                                        txt_patente.Text.Trim(), (string)(Session["usrname"]), Convert.ToInt32(dlEstado.SelectedValue), "INFAU", (string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtDesde.Text.Trim()))), (string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtHasta.Text.Trim()))));
            lblMensaje.Text = lautos.Count == 0 ? "No existen datos para la busqueda realizada" : "";

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("marca"));
            dt.Columns.Add(new DataColumn("motor"));
            dt.Columns.Add(new DataColumn("propietario"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("toolTipEstado"));
            dt.Columns.Add(new DataColumn("urlInforme"));
            dt.Columns.Add(new DataColumn("imagenInforme"));
            dt.Columns.Add(new DataColumn("estadoInforme"));
            dt.Columns.Add(new DataColumn("estadoFamilia"));
            dt.Columns.Add(new DataColumn("encargo"));
            dt.Columns.Add(new DataColumn("limitacionDominio"));
            dt.Columns.Add(new DataColumn("revisionTecnica"));
            dt.Columns.Add(new DataColumn("montoMulta"));
            dt.Columns.Add(new DataColumn("urlProcesos"));
            foreach (var a in lautos)
            {
                const string sinInfo = "NO SE PUEDE ANALIZAR ESTA PATENTE";
                var dr = dt.NewRow();
                dr["id_solicitud"] = a.Id_solicitud;
                dr["fecha"] = a.FechaAdquisicion;
                dr["patente"] = a.Patente;
                dr["marca"] = a.EstadoFamilia==sinInfo? "SIN INFO.": a.Marca;
                dr["motor"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Motor;
                dr["estadoFamilia"] = a.EstadoFamilia;
                dr["montoMulta"] = "$"+ a.MontoMulta.Replace(",",".");
                dr["limitacionDominio"] = a.LimitacionDominio;
                dr["revisionTecnica"] = a.RevisionTecnica;
                dr["encargo"] = a.EncargoRobo;
                dr["propietario"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Propietario_nombre;
                dr["toolTipEstado"] = a.ConMuntas ? "Con Multas" : "Sin Multas";
                dr["estado"] = a.ConMuntas ? "../imagenes/sistema/static/rojo.png" :
                                    "../imagenes/sistema/static/verde.png";

                dr["urlInforme"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim()) + "&origen=ex";
                dr["imagenInforme"] = @"../imagenes/sistema/static/panel_control/pdf.png";
                dr["urlProcesos"] = @"../preinscripcion/InfoAutoProcesos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim());
                dt.Rows.Add(dr);
            }

            gr_dato.DataSource = dt;
            gr_dato.DataBind();
          
        }
      
        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GetCav()
        {
            var operacion = 0;
            var fecha = DateTime.Now;
            if (txt_operacion.Text != "")
            {
                operacion = Convert.ToInt32(txt_operacion.Text);
            }

            var lautos = new InfoAutoBC().GetInfoAuto(operacion,
                                                        txt_patente.Text.Trim(), (string)Session["usrname"], Convert.ToInt32(dlEstado.SelectedValue), "CCAV", string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtDesde.Text.Trim())), string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtHasta.Text.Trim())));
            lblMensaje.Text = lautos.Count == 0 ? "No existen datos para la busqueda realizada" : "";
                       

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("marca"));
            dt.Columns.Add(new DataColumn("motor"));
            dt.Columns.Add(new DataColumn("propietario"));  
            dt.Columns.Add(new DataColumn("urlInforme"));
            dt.Columns.Add(new DataColumn("imagenInforme"));
            dt.Columns.Add(new DataColumn("estadoInforme"));
            dt.Columns.Add(new DataColumn("estadoFamilia"));
            dt.Columns.Add(new DataColumn("encargo"));
            dt.Columns.Add(new DataColumn("limitacionDominio"));
        
            
            dt.Columns.Add(new DataColumn("urlProcesos"));
            foreach (var a in lautos)
            {
                const string sinInfo = "NO SE PUEDE ANALIZAR ESTA PATENTE";
                var dr = dt.NewRow();
                dr["id_solicitud"] = a.Id_solicitud;
                dr["fecha"] = a.FechaAdquisicion;
                dr["patente"] = a.Patente;
                dr["marca"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Marca;
                dr["motor"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Motor;
                dr["estadoFamilia"] = a.EstadoFamilia;  
                dr["limitacionDominio"] = a.LimitacionDominio; 
                dr["encargo"] = a.EncargoRobo;
                dr["propietario"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Propietario_nombre; 
                dr["urlInforme"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim()) + "&origen=ex";
                dr["imagenInforme"] = @"../imagenes/sistema/static/panel_control/pdf.png";
                dr["urlProcesos"] = @"../preinscripcion/InfoAutoProcesos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim());
                dt.Rows.Add(dr);
            }

            grCav.DataSource = dt;
            grCav.DataBind();
           
        }

        protected void GetCavMultas()
        {
            var operacion = 0;   
            if (txt_operacion.Text.Trim() != "")
            {
                operacion = Convert.ToInt32(txt_operacion.Text);
            }

            var lautos = new InfoAutoBC().GetInfoAuto(operacion,
                                                        txt_patente.Text.Trim(), (string)Session["usrname"], Convert.ToInt32(dlEstado.SelectedValue), "CAMUL", string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtDesde.Text.Trim())), string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtHasta.Text.Trim())));
            lblMensaje.Text = lautos.Count == 0 ? "No existen datos para la busqueda realizada" : "";
       

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("marca"));
            dt.Columns.Add(new DataColumn("motor"));
            dt.Columns.Add(new DataColumn("propietario"));
            dt.Columns.Add(new DataColumn("urlInforme"));
            dt.Columns.Add(new DataColumn("imagenInforme"));
            dt.Columns.Add(new DataColumn("estadoInforme"));
            dt.Columns.Add(new DataColumn("estadoFamilia"));
            dt.Columns.Add(new DataColumn("encargo"));
            dt.Columns.Add(new DataColumn("limitacionDominio"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("toolTipEstado"));
            dt.Columns.Add(new DataColumn("montoMulta"));

            dt.Columns.Add(new DataColumn("urlProcesos"));
            foreach (var a in lautos)
            {
                const string sinInfo = "NO SE PUEDE ANALIZAR ESTA PATENTE";
                var dr = dt.NewRow();
                dr["id_solicitud"] = a.Id_solicitud;
                dr["fecha"] = a.FechaAdquisicion;
                dr["patente"] = a.Patente;
                dr["marca"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Marca;
                dr["motor"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Motor;
                dr["estadoFamilia"] = a.EstadoFamilia;
                dr["limitacionDominio"] = a.LimitacionDominio;
                dr["montoMulta"] = "$" + a.MontoMulta.Replace(",", ".");
                dr["encargo"] = a.EncargoRobo;
                dr["estado"] = a.ConMuntas ? "../imagenes/sistema/static/rojo.png" :
                                   "../imagenes/sistema/static/verde.png";
                dr["toolTipEstado"] = a.ConMuntas ? "Con Multas" : "Sin Multas";
                dr["propietario"] = a.EstadoFamilia == sinInfo ? "SIN INFO." : a.Propietario_nombre;
                dr["urlInforme"] = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim()) + "&origen=ex";
                dr["imagenInforme"] = @"../imagenes/sistema/static/panel_control/pdf.png";
                dr["urlProcesos"] = @"../preinscripcion/InfoAutoProcesos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(a.Id_solicitud.ToString().Trim());
                dt.Rows.Add(dr);
            }

            grMultas.DataSource = dt;
            grMultas.DataBind();

        }
      
       
        protected void btn_buscar_click(object sender, EventArgs e)
        {
            switch (tab_datos.ActiveTab.TabIndex)
            {
                case 0:
                    GetAutos();
                    break;
                case 1:
                    GetCav();
                    break;
                default:
                    GetCavMultas();
                    break;
            }
        }  

        protected void tab_datos_Load(object sender, EventArgs e)
        {
            
        }
    

    }
}
