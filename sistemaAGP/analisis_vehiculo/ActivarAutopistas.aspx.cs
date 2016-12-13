using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.analisis_vehiculo
{
    public partial class ActivarAutopistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            GetPasos();

            if (Convert.ToString(Session["usrname"]).Trim() != "153636613"
                && Convert.ToString(Session["usrname"]).Trim() != "141548085"
                && Convert.ToString(Session["usrname"]).Trim() != "151105157"
                && Convert.ToString(Session["usrname"]).Trim() != "159667367")
            {
                gr_dato.Enabled = false;
                btnCambiar.Enabled = false;
            }
            else
            {
                gr_dato.Enabled = true;
                btnCambiar.Enabled = true;
            }

        }

        private void GetPasos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_dicom_vehiculo_pasos"));
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("estado", typeof(bool)));

            var dtDatos = new InfoAutoBC().GetPasosInfoauto();
            foreach (DataRow dra in dtDatos.Rows)
            {
                var dr = dt.NewRow();
                dr["id_dicom_vehiculo_pasos"] = dra["id_dicom_vehiculo_pasos"].ToString();
                dr["descripcion"] = dra["descripcion"].ToString();
                dr["estado"] = Convert.ToBoolean(dra["estado"]);
                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }


        private void ActualizarEstado()
        {
            var mensaje = $"Actualización Estado info Autopistas:";

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chkEstado");

                int idPaso = Convert.ToInt32(gr_dato.DataKeys[i]["id_dicom_vehiculo_pasos"]);
                var descripcion = Convert.ToString(gr_dato.DataKeys[i]["descripcion"]);
                var estado = chk.Checked ? "ACTIVADO" : "DESACTIVADO";
                mensaje += $" {descripcion} = {estado};";

                // ACTUALIZA
                new InfoAutoBC().ActualizarPasoInfocar(idPaso, chk.Checked ? "TRUE" : "FALSE");
            }
            
            new InfoAutoBC().AddMensajeAnalisis(Convert.ToString(Session["usrname"]), mensaje);
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarEstado();
                FuncionGlobal.alerta("Actualizado correctamente", Page);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta($"Ups! se ha producido el siguiente error: {ex.Message}", Page);
            }

            GetPasos();
        }
    }
}