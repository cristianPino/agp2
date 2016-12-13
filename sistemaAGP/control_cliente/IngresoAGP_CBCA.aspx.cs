using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;
using System.Text;

namespace sistemaAGP.control_cliente
{
    public partial class IngresoAGP_CBCA : Page
    {
		private string estadoagenda;
        private int auxcredito;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarAgenda(DateTime.Today.ToString("yyyyMMdd"));
            }
            //btn_Enviar.Visible = false;
        }

        private void BuscarAgenda(string _fecha)
        {
            try
            {
                List<Agenda> lagenda = new AgendaBC().getAgendas((string)(Session["usrname"]), _fecha);

                DataTable dtcbo = new DataTable();
                dtcbo.Columns.Add("idSolicitud", typeof(string));

                DataTable dt = new DataTable();
                dt.Columns.Add("Hora_firma", typeof(string));
                dt.Columns.Add("id_solicitud", typeof(string));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Direccion", typeof(string));
                dt.Columns.Add("comuna", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Celular", typeof(string));
                dt.Columns.Add("N_intentos", typeof(string));

                DataRow row;
                DataRow rowCbo;
                rowCbo = dtcbo.Rows.Add();
                rowCbo["idSolicitud"] = "Selecionar";
                foreach (Agenda item in lagenda)
                {
					estadoagenda = item.Estado;
                    row = dt.Rows.Add();
                    row["Hora_firma"] = item.Hora_firma;
                    row["id_solicitud"] = item.Id_solicitud;
                    row["Cliente"] = item.Cliente;
                    row["Direccion"] = item.Direccion;
                    row["comuna"] = item.comuna;
                    row["Telefono"] = item.Telefono;
                    row["Celular"] = item.Celular;
                    row["N_intentos"] = item.N_intentos;

                    if (item.Id_solicitud.ToString() != "0" && item.Estado.Trim() !="FIRMADA")
                    {
                        rowCbo = dtcbo.Rows.Add();
                        rowCbo["idSolicitud"] = item.Id_solicitud;
                    }
                }

                this.grdResultado.DataSource = dt;
                this.grdResultado.DataBind();

                this.cbo_nsol.DataSource = dtcbo;
                cbo_nsol.DataTextField = "idSolicitud";
                cbo_nsol.DataValueField = "idSolicitud";
                this.cbo_nsol.DataBind();
                cbo_nsol.SelectedValue = "Selecionar";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void cld_FechaFirma_SelectionChanged(object sender, EventArgs e)
        {
            BuscarAgenda(cld_FechaFirma.SelectedDate.ToString("yyyyMMdd"));
        }

        #region grdResultado_RowCommand

        protected void grdResultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = grdResultado.Rows[index];

            //string hora = (string)row.Cells[0].Text;
            //string idsolicitud = (string)row.Cells[1].Text;
            //string Nmbcli = (string)row.Cells[2].Text;

            //if (e.CommandName == "Ingreso")
            //{
            //    TBL_ING_CREDITO.Visible = true;
            //    TBL_AGENDA.Visible = false;
            //    lblid.Text = idsolicitud;
            //    lblCli.Text = Nmbcli;
            //}
                  
        }

        #endregion

        #region grdResultado_RowCreated

        protected void grdResultado_RowCreated(object sender, GridViewRowEventArgs e)
        {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        ImageButton addtoamda = (ImageButton)e.Row.Cells[7].FindControl("btnIngresar");
        //        addtoamda.ToolTip = "Ingresar Creditos Firmados";
        //        addtoamda.CommandArgument = e.Row.RowIndex.ToString();
        //    }
        }

        #endregion
 
        protected void btn_Crt_Firm_Click(object sender, EventArgs e)
        {
            try
            {

                List<MasterBCA> msc = new MasterBCABC().getMAsterBCA(Convert.ToInt32(lblid.Text));

                foreach (MasterBCA itemBCA in msc)
                {
                    auxcredito = auxcredito + itemBCA.Id_credito;
                }

                if (auxcredito == 0)
                {
                    TBL_ING_CREDITO.Visible = true;
                    TBL_AGENDA.Visible = false;
                    lblid.Text = cbo_nsol.SelectedValue;

                    DataTable dtcr = new DataTable();
                    dtcr.Columns.Add("idSolicitud", typeof(string));
                    dtcr.Columns.Add("idInterno", typeof(string));

                    List<MasterBCA> LstBCA = new MasterBCABC().getMAsterBCA(Convert.ToInt32(cbo_nsol.SelectedValue));

                    DataRow drNewRow;
                    foreach (MasterBCA item in LstBCA)
                    {
                        drNewRow = dtcr.NewRow();
                        drNewRow["idSolicitud"] = item.Id_solicitud;
                        drNewRow["idInterno"] = item.Id_interno;
                        dtcr.Rows.Add(drNewRow);
                    }

                    this.grdCreditos.DataSource = dtcr;
                    this.grdCreditos.DataBind();
                }
                else
                {
                    TBL_ING_CREDITO.Visible = true;
                    TBL_AGENDA.Visible = false;
                    lblid.Text = cbo_nsol.SelectedValue;

                    cargagrillacredito();
                    grdCreditos.Visible = false;
                    grdnewcredit.Visible = true;
                    bt_GrabaCreditos.Enabled = false;
                    btn_Enviar.Visible = true;

                }
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
            }
        }

        private void cargagrillacredito()
        {
            lblid.Text = cbo_nsol.SelectedValue;

            List<MasterBCA> msc = new MasterBCABC().getMAsterBCA(Convert.ToInt32(lblid.Text)); 

            DataTable dtcra = new DataTable();
            dtcra.Columns.Add("idSolicitud", typeof(string));
            dtcra.Columns.Add("ninterno", typeof(string));
            dtcra.Columns.Add("id_Ope", typeof(string));

            foreach (MasterBCA item in msc)
            {
				if (item.Id_credito != 0)
				{
					DataRow rowcr;
					rowcr = dtcra.Rows.Add();
					rowcr["idSolicitud"] = item.Id_solicitud;
					rowcr["ninterno"] = item.Id_interno;
					rowcr["id_Ope"] = item.Id_credito;
				}
            }
            this.grdnewcredit.DataSource = dtcra;
            this.grdnewcredit.DataBind();
        }

        protected void cbo_nsol_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblid.Text = cbo_nsol.SelectedValue.ToString().Trim();
        }

        protected void grdnewcredit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {   
                string idoper  = e.Row.Cells[2].Text;
                ImageButton ibuton;

                ibuton = (ImageButton)e.Row.FindControl("ib_cargar");
                ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(idoper) + "&tipo=" + "CBCA" + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_cdigital");
				ibuton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(idoper) + "&origen=eo','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");
            }
        }

        protected void mensajeOper(int codigo, string id_solicitud)
        {
            MailBCA mBCA = new MailBCABC().getMailbycodigo(codigo);
            Operacion op = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));
            string ccopia = mBCA.Ccopy;

            Agenda agn = new AgendaBC().getAgenda(Convert.ToInt32(id_solicitud));

            //Usuario eject = new UsuarioBC().GetUsuario(agn.Ejecutivo);

            Persona pers = new PersonaBC().getpersonabyrut(agn.Rut_persona);

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
            strBody.AppendLine("<br/>");
            strBody.AppendLine("Se Frimaron los siguientes Creditos");
            strBody.AppendLine("<br/>");
            strBody.AppendLine("<table whidth=\"70px\">");
            foreach (GridViewRow row in grdCreditos.Rows)
            {
                string idref;
                string idinterno;
                idref = row.Cells[0].Text;
                idinterno = row.Cells[1].Text;
                CheckBox chkF = (CheckBox)row.Cells[2].FindControl("chkfirma");

                if (chkF.Checked)
                {
                    strBody.Append("<tr><td aling=\"Center\">");
                    strBody.AppendLine(idinterno);
                    strBody.Append("</td></tr>");
                }
            }
            strBody.AppendLine("</table>");
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
            //op.Usuario.Correo
            mail.SendMail(op.Usuario.Correo, mBCA.Ccopy, mBCA.Subject.Replace("NOperacion", id_solicitud), strBody.ToString().Replace("NOperacion", id_solicitud).Replace("NombreCliente", pers.Nombre + " " + pers.Apellido_paterno + " " + pers.Apellido_materno));
        }

        protected void bt_GrabaCreditos_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCreditos.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCreditos.Rows)
                    {
                        string idref;
                        string idinterno;
                        idref = row.Cells[0].Text;
                        idinterno = row.Cells[1].Text;
                        CheckBox chkF = (CheckBox)row.Cells[2].FindControl("chkfirma");

                        if (chkF.Checked)
                        {
                            Int32 opr = new OperacionBC().add_operacion(0, 1, "CBCA", (string)(Session["usrname"]), 0, "", 0,0);
                            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(opr), 1, "CBCA", "", (string)(Session["usrname"]));
                            string add = new MasterBCABC().add_MasterBCA(Convert.ToInt32(idref), idinterno, opr);
                        }
                    }
                    cargagrillacredito();
                    grdCreditos.Visible = false;
                    grdnewcredit.Visible = true;
                    bt_GrabaCreditos.Enabled = false;
                    btn_Enviar.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void btn_Enviar_Click(object sender, EventArgs e)
        {
            mensajeOper(2, cbo_nsol.SelectedValue);
            TBL_ING_CREDITO.Visible = false;
            TBL_AGENDA.Visible = true;
            BuscarAgenda(DateTime.Today.ToString("yyyyMMdd"));
        }

    }
}