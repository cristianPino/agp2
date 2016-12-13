using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;
using System.Data;
using System.Text;

namespace sistemaAGP.control_cliente
{
    public partial class SG_CreditoBCA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CagraGrilla();
            }
        }

        private void CagraGrilla()
        {
            List<Operacion> lstcreditos = new OperacionBC().getCreditosBCA();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_solicitud", typeof(string));
            dt.Columns.Add("N_interno", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("OBS", typeof(string));

            DataRow row;
            foreach (Operacion item in lstcreditos)
            {
                
                if (item.Estado == "CREDITO OTORGADO NO PAGADO")
                {
                    MasterBCA mst = new MasterBCABC().getMAsterBCAbyid(Convert.ToInt32(item.Id_solicitud));
                    Agenda agd = new AgendaBC().getAgenda(mst.Id_solicitud);
                    Persona pers = new PersonaBC().getpersonabyrut(agd.Rut_persona);
                    EstadoOperacion estop = new EstadooperacionBC().getUltimoEstadoByIdoperacion(Convert.ToInt32(item.Id_solicitud));
                    row = dt.Rows.Add();
                    row["id_solicitud"] = item.Id_solicitud;
                    row["N_interno"] = mst.Id_interno;
                    row["Cliente"] = pers.Nombre + " " + pers.Apellido_paterno + " " + pers.Apellido_materno;
                    row["Estado"] = item.Estado;
                    row["Fecha"] = item.Fecha_solicitud;
                    row["OBS"] = estop.Observacion;
                }
            }

            if (dt.Columns.Count > 0)
            {
                this.btn_Aceptar.Enabled = true;
            }
            this.grdResultado.DataSource = dt;
            this.grdResultado.DataBind();

        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.grdResultado.Rows)
            {
                string idref = row.Cells[1].Text;
                
                RadioButton pg = (RadioButton)row.Cells[5].FindControl("rdb_Pagado");
                RadioButton anl = (RadioButton)row.Cells[5].FindControl("rdb_Anulado");
                Int32 id_sol = Convert.ToInt32(row.Cells[0].Text);

                if (pg.Checked)
                {
                    string add_or = new EstadooperacionBC().add_estado_orden(id_sol, 99, "CBCA", txt_obs.Text, (string)(Session["usrname"]));
                    mensajeOper(9, idref);              
                }

                if (anl.Checked)
                {
                    string add_or = new EstadooperacionBC().add_estado_orden(id_sol, 90, "CBCA", txt_obs.Text, (string)(Session["usrname"]));
                    mensajeOper(5, idref);
                }
             }
            txt_obs.Text = "";
            CagraGrilla();
        }

        protected void grdResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string idoper = e.Row.Cells[0].Text;
                ImageButton ibuton;
                ibuton = (ImageButton)e.Row.FindControl("ib_cdigital");
                ibuton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(idoper) + "&origen=pc','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");

            }
        }

        protected void mensajeOper(int codigo, string id_solicitud)
        {
            Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            MailBCA mBCA = new MailBCABC().getMailbycodigo(codigo);
            string ccopia = mBCA.Ccopy;

            string[] body = mBCA.Body.Split('.');
            Mail.Mail mail = new Mail.Mail();
            StringBuilder strBody = new StringBuilder();

            strBody.Append("<html><head><title>Correo Automatico</title><body>");
            strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            strBody.Append("<tr><td>");
            foreach (string item in body)
            {
                strBody.AppendLine("<br/>");
                strBody.AppendLine(item);
            }
            strBody.AppendLine("");

            strBody.Append("</td></tr>");
            strBody.Append("<tr><td>");
            strBody.AppendLine("<br/>");
            strBody.AppendLine("Atte.,");
            strBody.AppendLine("<br/>");
            strBody.AppendLine(mBCA.Firma);
            strBody.Append("</td></tr><tr><td>");
            strBody.Append("<IMG SRC=" + "http://190.196.121.53/imagenes/firmaCA.jpg" + ">");
            strBody.Append("</td></tr></table>");
            strBody.Append("</body></html>");

            mail.SendMail(musuario.Correo, mBCA.Ccopy, mBCA.Subject.Replace("NOperacion", id_solicitud), strBody.ToString().Replace("NOperacion", id_solicitud));
        }
    }
}