using CNEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP.analisis_vehiculo
{
    public partial class Mensajes_masivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            GetMensajes();
        }

        private void GetMensajes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("idMensaje"));
            dt.Columns.Add(new DataColumn("mensaje"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("fecha"));

            DataTable dtDatos = new InfoAutoBC().GetMensajeAnalisis();

            foreach (DataRow drDatos in dtDatos.Rows)
            {
                var dr = dt.NewRow();
                dr["idMensaje"] = Convert.ToString(drDatos["id"]);
                dr["mensaje"] = Convert.ToString(drDatos["mensaje"]);
                dr["usuario"] = Convert.ToString(drDatos["nombre"]);
                dr["fecha"] = Convert.ToString(drDatos["fecha"]);
                dr["estado"] = Convert.ToString(drDatos["estado"]).Trim().ToLower() == "true" ? "ACTIVO" : "DESACTIVO";
                dt.Rows.Add(dr);
            }
            grMensajes.DataSource = dt;
            grMensajes.DataBind();
        }

        protected void grMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void grMensajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "desactivar")
            {
                new InfoAutoBC().DesactivaMensajeAnalisis();
                FuncionGlobal.alerta("El mensaje desactivado correctamente", Page);
                GetMensajes();
            }
        }

        protected void grMensajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = (string)e.Row.Cells[4].Text.Trim().ToLower();
                var boton = (ImageButton)e.Row.FindControl("iBaManual");               
                boton.Visible = estado == "activo";
            }
        }

        protected void btnMensaje_Click(object sender, EventArgs e)
        {
            new InfoAutoBC().AddMensajeAnalisis(Convert.ToString(Session["usrname"]), txtMensaje.Text);
            FuncionGlobal.alerta("El mensaje fue agregado correctamente", Page);
            GetMensajes();
        }
    }
}