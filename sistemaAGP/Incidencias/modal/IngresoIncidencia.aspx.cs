using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using CENTIDAD;
using CNEGOCIO;
using DataTable = System.Data.DataTable;

namespace sistemaAGP.Incidencias.Modal
{
    public partial class IngresoIncidencia : System.Web.UI.Page
    {
        public DataTable numInc;
        public static int idIncidencia;
        public static int idIncidenciaEstado;
        public static string dato;
        public static bool buscarPatente;       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                FuncionGlobal.comboparametro(dlTipoIncidencia, "TINCI");
                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), dlCliente);               
            }
        }

        protected void btnSubeDoc_Click(object sender, EventArgs e)
        {
            //VALIDAR EXISTENCIA DE PATENTE EN BASE DATOS AGP
            if (dlCliente.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Seleccionar Cliente", Page, upPrincipal);
                return;
            }
            if (dlSucursal.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Seleccionar Sucursal", Page, upPrincipal);
                return;
            }
            if (!txPatente.Value.Trim().Any() && !txtChasis.Value.Trim().Any())
            {
                FuncionGlobal.alerta_updatepanel("Indicar patente y/o chasis", Page, upPrincipal);
                return;
            }
            if (!txPatente.Value.Trim().Any() && txtChasis.Value.Trim().Length < 6)
            {
                FuncionGlobal.alerta_updatepanel("Ingrese los últimos 6 caracteres del chasis", Page, upPrincipal);
                return;
            }
            if (!txtChasis.Value.Trim().Any() && txPatente.Value.Trim().Length < 6)
            {
                FuncionGlobal.alerta_updatepanel("Ingrese 6 caracteres en patente", Page, upPrincipal);
                return;
            }

            if (!txtChasis.Value.Trim().Any() && !FuncionGlobal.formatoPatente(txPatente.Value.Trim()))
            {
                FuncionGlobal.alerta_updatepanel("Patente inválida", Page, upPrincipal);
                return;
            }

            if(dlTipoIncidencia.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Indicar Tipo de Incidencia.", Page, upPrincipal);
                return;
            }           

            Incidencia();
           
        }      

        public void Incidencia()
        {
            dato = string.Empty;
            buscarPatente = false;
            switch (txPatente.Value.Trim().Any())
            { 
                case true:
                    dato = txPatente.Value.Trim();
                    buscarPatente = true;
                    break;
                default: 
                    dato = txtChasis.Value.Trim();
                    break;
            }

            var inc = new IncidenciaBC().GetIncidenciaByChasisORPatente(dato,buscarPatente);

            if (inc.Rows.Count > 0)
            {               
                idIncidencia = Convert.ToInt32(inc.Rows[0]["id_incidencia"]);
                Response.Redirect("~/Incidencias/modal/Administracion.aspx?id_incidencia=" + idIncidencia + "&origen=2");
            }
            else
            {
                new IncidenciaBC().AddIncidencia((string)(Session["usrname"]), 
                                                    dlTipoIncidencia.SelectedValue, 
                                                    txPatente.Value, 
                                                    txtComentario.Text,
                                                    Convert.ToInt32(dlCliente.SelectedValue),
                                                    Convert.ToInt32(dlSucursal.SelectedValue),
                                                    txtChasis.Value.Trim());

                numInc = new IncidenciaBC().GetIncidenciaByChasisORPatente(dato, buscarPatente);
                idIncidencia = Convert.ToInt32(numInc.Rows[0]["id_incidencia"]);                
                Response.Redirect("~/Incidencias/modal/Administracion.aspx?id_incidencia=" + idIncidencia + "&origen=1");        
                
            }
        }

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbyclienteandUsuario(dlSucursal, Convert.ToInt16(dlCliente.SelectedValue), (string)(Session["usrname"]));
        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }
    }
}