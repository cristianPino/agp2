using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Text;

namespace sistemaAGP
{

    public partial class mAgendas : System.Web.UI.Page
    {

        //private string id_solicitud;
        private string id_cliente;
        private string id_solicitud;
        private string fecha;
        private string hora;
        private string tipo;
        private string giro = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
                lbl_Oper_IDCli.Text = id_cliente;
                TBL_Agenda.Visible = true;
                TBL_Operacion.Visible = false;
                FuncionGlobal.combocomuna(cboComuna, 1);
                FuncionGlobal.combousuariobyperfil(cbo_EjeCom, "ECCA");
                FuncionGlobal.combousuariobyperfil(dl_Usuarios, "EAAGP");

            }
        }

        protected void cld_FechaFirma_SelectionChanged(object sender, EventArgs e)
        {
            lblfechaseleccionada.Text = cld_FechaFirma.SelectedDate.ToShortDateString();

            BuscarAgenda();
        }

        private void BuscarAgenda()
        {
            try
            {
                if (dl_Usuarios.SelectedValue != "0")
                {
                    List<Agenda> lagenda = new AgendaBC().getAgendas((string)(Session["usrname"]).ToString().Trim(), cld_FechaFirma.SelectedDate.ToString("yyyyMMdd"));
                    this.grdResultado.DataSource = lagenda;
                    this.grdResultado.DataBind();
                    lblError.Text = "";
                    dl_Usuarios.BackColor = System.Drawing.Color.White;
                }
                else
                {
                    lblError.Text = "Seleccione Usuario para agendar";
                    dl_Usuarios.BackColor = System.Drawing.Color.Yellow;
                    dl_Usuarios.Focus();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        #region grdResultado_RowCreated

        protected void grdResultado_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton addtoamda = (ImageButton)e.Row.Cells[1].FindControl("btn_Tomada");
                addtoamda.ToolTip = "Hora Tomada";
                addtoamda.CommandArgument = e.Row.RowIndex.ToString();

                ImageButton adddisponible = (ImageButton)e.Row.Cells[1].FindControl("btn_Disponible");
                adddisponible.ToolTip = "Hora Disponible";
                adddisponible.CommandArgument = e.Row.RowIndex.ToString();

                ImageButton adddbtnReasignar = (ImageButton)e.Row.Cells[7].FindControl("btnReasignar");
                adddbtnReasignar.ToolTip = "Reasignar";
                adddbtnReasignar.CommandArgument = e.Row.RowIndex.ToString();

                ImageButton adddbtnrechazo = (ImageButton)e.Row.Cells[8].FindControl("btnRechazo");
                adddbtnrechazo.ToolTip = "Rechazo";
                adddbtnrechazo.CommandArgument = e.Row.RowIndex.ToString();

            }
        }

        #endregion

        #region grdResultado_RowDataBound

        protected void grdResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton addtoamda = (ImageButton)e.Row.Cells[1].FindControl("btn_Tomada");
                    ImageButton adddisponible = (ImageButton)e.Row.Cells[1].FindControl("btn_Disponible");

                    string tipodoc = e.Row.Cells[3].Text;

                    if (!tipodoc.Equals("DISPONIBLE", StringComparison.InvariantCultureIgnoreCase))
                    {
                        addtoamda.Visible = true;
                        adddisponible.Visible = false;
                    }
                    else
                    {
                        addtoamda.Visible = false;
                        adddisponible.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        #endregion

        #region grdResultado_RowCommand

        protected void grdResultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdResultado.Rows[index];

            string hora = (string)row.Cells[0].Text;
            string id_solicitud = (string)row.Cells[2].Text;
            string estadoAgenda = (string)row.Cells[3].Text;

            lbl_hora.Text = hora;
            if (e.CommandName == "Reasignar")
            {

                this.lblnroOpe.Visible = true;
                this.lblnroOpe.Text = (string)row.Cells[2].Text;
            }
            if (e.CommandName == "Tomada")
            {
                CrearOperacion(id_solicitud.Trim(), hora.Trim(), "C", cld_FechaFirma.SelectedDate.ToString("yyyy/MM/dd"));

            }
            if (e.CommandName == "Disponible")
            {
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

                if (this.lblnroOpe.Visible == true)
                {
                    Agenda getagenda = new AgendaBC().getAgenda(Convert.ToInt32(lblnroOpe.Text));
                    EstadoOperacion mestado = new EstadooperacionBC().getUltimoEstadoByIdoperacion(Convert.ToInt32(lblnroOpe.Text));
                    if (getagenda.N_intentos < 3 && mestado.Estado_operacion.Orden < 99)
                    {
                        string add_estado = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(this.lblnroOpe.Text), 80, "AGND", "", (string)(Session["usrname"]));
                        string add_operacion = new AgendaBC().add_agenda(Convert.ToInt32(lblnroOpe.Text), Convert.ToDateTime(cld_FechaFirma.SelectedDate.ToString("yyyy/MM/dd")), hora, Convert.ToInt32(getagenda.Rut_persona), (string)(Session["usrname"]), getagenda.Ejecutivo, cbo_tipoagenda.SelectedValue, dl_Usuarios.SelectedValue.Trim());
                        mensaje(3, lblnroOpe.Text);

                    }
                    else
                    {
                        if (mestado.Estado_operacion.Orden == 99)
                        {
                            FuncionGlobal.alerta_updatepanel("esta operacion esta finalizada", Page, up);
                        }
                        else
                        {
                            string add_estado = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(lblnroOpe.Text), 99, "AGND", "", (string)(Session["usrname"]));
                            Int32 opr = new OperacionBC().add_operacion(0, Convert.ToInt16(id_cliente), "AGND", (string)(Session["usrname"]), Convert.ToInt32(lblnroOpe.Text), "", 0,0);
                            string add_operacion = new AgendaBC().add_agenda(Convert.ToInt32(opr), Convert.ToDateTime(cld_FechaFirma.SelectedDate.ToString("yyyy/MM/dd")), hora, Convert.ToInt32(getagenda.Rut_persona), (string)(Session["usrname"]), getagenda.Ejecutivo, cbo_tipoagenda.SelectedValue, dl_Usuarios.SelectedValue.Trim());
                            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(opr), 10, "AGND", "", (string)(Session["usrname"]));
                            FuncionGlobal.alerta_updatepanel("A alcanzado el limite de cambios de Fecha y Hora su nueva Operacion es la " + opr, Page, up);

                            string magenda = new AgendaBC().del_agenda(Convert.ToInt32(lblnroOpe.Text));
                        }
                    }
                    this.lblnroOpe.Text = "";
                    this.lblnroOpe.Visible = false;
             }
             else
              {
                    CrearOperacion(id_solicitud.Trim(), hora.Trim(), "T", cld_FechaFirma.SelectedDate.ToString("yyyy/MM/dd"));
              }
            }
            if (e.CommandName == "Rechazo")
            {
                Int32 idSol;
                if (estadoAgenda.Trim() != "FIRMADA")
                {
                    idSol = Convert.ToInt32(id_solicitud);
                    if (idSol > 0)
                    {
                        string add_estado = new EstadooperacionBC().add_estado_orden(Convert.ToInt16(id_solicitud), 60, "AGND", "", (string)(Session["usrname"]));
                        string magenda = new AgendaBC().del_agenda(idSol);
                    }
                }
                else
                {
                    lblError.Text = "No Puede Rechazar, si la Operacion esta Finalizada.";
                }
            }


            BuscarAgenda();
        }

        protected void GET_AGENDA()
        {
            Agenda magenda = new AgendaBC().getAgenda(Convert.ToInt32(lbl_Oper_ID.Text));
            //this.Datosvendedor.Mostrar_Form(magenda.Rut_persona);
            this.lbl_intentos.Visible = true;
            this.lbl_intentos.Text = magenda.N_intentos.ToString();
            //this.bt_guardar.Enabled = true;
            
            EstadoOperacion mestado = new EstadooperacionBC().getUltimoEstadoByIdoperacion(Convert.ToInt32(lbl_Oper_ID.Text));
            if (mestado.Estado_operacion != null)
            {
                if (mestado.Estado_operacion.Orden == 99)
                {
                    this.label_fin.Visible = true;
                    this.bt_finalizar.Visible = false;
                    this.bt_guardar.Visible = false;
                    this.bt_Volver.Visible = true;
                    this.btnRechCred.Visible = false;
                }
            }

        }

        #endregion

       
        protected void dl_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dl_Usuarios.SelectedValue != "0")
            {
                grdResultado.Visible = true;
                BuscarAgenda();
            }
            else
            {
                grdResultado.Visible = false;
            }
        }

        protected void mensaje(int codigo, string id_solicitud)
        {
            Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            MailBCA mBCA = new MailBCABC().getMailbycodigo(codigo);

            Usuario musuarioComercial = new UsuarioBC().GetUsuario(cbo_EjeCom.SelectedValue);


            string ccopia = mBCA.Ccopy;

            if (codigo == 4)
            {
                ccopia = ccopia + ";" + musuarioComercial.Correo;
            }


            string[] body = mBCA.Body.Split('.');
            Mail.Mail mail = new Mail.Mail();
            StringBuilder strBody = new StringBuilder();

            strBody.Append("<html><head><title>Correo Automatico</title><body>");
            strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            strBody.Append("<tr><td>");
            foreach (string item in body)
            {
                strBody.AppendLine("<br/>");
                strBody.AppendLine(item.Replace("XX:XX", lbl_hora.Text));
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

            mail.SendMail(musuario.Correo, mBCA.Ccopy, mBCA.Subject.Replace("NOperacion", id_solicitud), strBody.ToString().Replace("XX:XX", lbl_hora.Text).Replace("NOperacion", id_solicitud));
        }

        private void CrearOperacion(string _id_oper, string _hora, string _tipo, string _fecha)
        {
            txt_obs.Text = "";
            TBL_Agenda.Visible = false;
            TBL_Operacion.Visible = true;
            lblerror2.Text = "";
            id_solicitud = _id_oper;
            fecha = _fecha;
            hora = _hora;
            tipo = _tipo;
            bt_guardar.Enabled = false;
            lbl_Oper_Fecha.Text = fecha;
            lbl_Oper_Hora.Text = hora;
            lbl_Oper_ID.Text = _id_oper;
            lbl_Oper_Tipo.Text = _tipo;

            if (tipo == "C")
            {
                Agenda agaux = new AgendaBC().getAgenda(Convert.ToInt32(id_solicitud));

                Persona pers = new PersonaBC().getpersonabyrut(agaux.Rut_persona);
                Direcciones dirper = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(pers.Rut));
                List<Telefonos> telper = new TelefonoBC().gettelefonos(Convert.ToInt32(pers.Rut));
                txt_rut.Text = pers.Rut.ToString();
                txt_dv.Text = pers.Dv;
                txtNombre.Text = pers.Nombre;
                txtApellidoP.Text = pers.Apellido_paterno;
                txtApellidoM.Text = pers.Apellido_materno;
                cbo_EjeCom.SelectedValue = agaux.Ejecutivo;
                txtdireccion.Text = dirper.Direccion;
                txt_numeriDir.Text = dirper.Numero;
                this.giro = pers.Giro;
                foreach (Telefonos item in telper)
                {
                    if (item.Tipo_telefono == "TCEL")
                    {
                        txt_celular.Text = item.Numero.ToString();
                    }
                    if (item.Tipo_telefono == "TOFI")
                    {
                        txt_telefono.Text = item.Numero.ToString();
                    }
                }

                if (dirper.Tipo_direccion != null && dirper.Tipo_direccion != "")
                {
                    rdbtipodir.SelectedValue = dirper.Tipo_direccion.Trim();
                }
                //this.bt_finalizar.Visible = true;
                //this.bt_guardar.Text = "Eliminar";

                txt_cantidadCredito.Visible = false;
                btnAgregarcredito.Visible = false;
                Label18.Visible = false;

                btnRechCred.Visible = false;
                List<MasterBCA> lbca = new MasterBCABC().getMAsterBCA(Convert.ToInt32(id_solicitud));
                CreditosBice(lbca);

            }

            this.lbl_fecha.Text = fecha;// +" " + hora;
            this.lbl_operacion.Text = id_solicitud;
            GET_AGENDA();

        }
      
        protected void bt_finalizar_Click(object sender, EventArgs e)
        {

            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(lbl_Oper_ID.Text), 99, "AGND", txt_obs.Text, (string)(Session["usrname"]));
            this.label_fin.Visible = true;
            this.bt_finalizar.Visible = false;
            this.bt_guardar.Visible = false;
            this.bt_Volver.Visible = true;
            this.btnRechCred.Visible = false;
            // Int32 oprCredito = new OperacionBC().add_operacion(0, Convert.ToInt16(lbl_Oper_IDCli.Text), "CBCA", (string)(Session["usrname"]),0);

            foreach (GridViewRow row in grdCrditos.Rows)
            {
                string idref = row.Cells[2].Text;
                string add_esta = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(idref), 20, "CBCA", txt_obs.Text, (string)(Session["usrname"]));
            }

            mensajeOper(4, lbl_Oper_ID.Text);

        }

        protected void mensajeOper(int codigo, string id_solicitud)
        {
            Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            MailBCA mBCA = new MailBCABC().getMailbycodigo(codigo);

            EstadoOperacion mobservacion = new EstadooperacionBC().getEstadobycodigoestado(Convert.ToInt32(id_solicitud), 123);
            Usuario musuarioComercial = new UsuarioBC().GetUsuario(cbo_EjeCom.SelectedValue);

            
            string ccopia = mBCA.Ccopy;

            if (codigo == 4)
            {
                ccopia = ccopia + ";" + musuarioComercial.Correo;
            }


            string[] body = mBCA.Body.Split('.');
            Mail.Mail mail = new Mail.Mail();
            StringBuilder strBody = new StringBuilder();

            strBody.Append("<html><head><title>Correo Automatico</title><body>");
            strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            strBody.Append("<tr><td>");
            foreach (string item in body)
            {
                strBody.AppendLine("<br/>");
                strBody.AppendLine(item.Replace("XX:XX", lbl_hora.Text));
                
            }
            strBody.Append("<tr><td>");
            strBody.AppendLine("OBS.: " + mobservacion.Observacion);
            strBody.Append("</td></tr>");
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

            mail.SendMail(musuario.Correo, mBCA.Ccopy, mBCA.Subject.Replace("NOperacion", id_solicitud), strBody.ToString().Replace("XX:XX", lbl_hora.Text).Replace("NOperacion", id_solicitud));
        }

        protected void txt_rut_TextChanged(object sender, EventArgs e)
        {
            if (txt_rut.Text != "")
            {
                txt_dv.Text = digitoVerificador(txt_rut.Text);
            }
            Persona person = new PersonaBC().getpersonabyrut(Convert.ToInt32(txt_rut.Text.Trim()));

            if (person != null)
            {
                txtNombre.Text = person.Nombre;
                txtApellidoP.Text = person.Apellido_paterno;
                txtApellidoM.Text = person.Apellido_materno;

                txt_celular.Text = person.Celular;

                List<Telefonos> telper = new TelefonoBC().gettelefonos(Convert.ToInt32(person.Rut));

                foreach (Telefonos item in telper)
                {
                    if (item.Tipo_telefono == "TCEL")
                    {
                        txt_celular.Text = item.Numero.ToString();
                    }
                    if (item.Tipo_telefono == "TOFI")
                    {
                        txt_telefono.Text = item.Numero.ToString();
                    }
                }

                Direcciones dirper = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(person.Rut));



                if (dirper != null)
                {
                    txt_numeriDir.Text = dirper.Numero;
                    txtdireccion.Text = dirper.Direccion;

                    Comuna compers = new ComunaBC().getComuna(Convert.ToInt16(dirper.Comuna.Id_Comuna));
                    cboComuna.SelectedValue = compers.Id_Comuna.ToString();
                }
            }
            else
            {
                txtNombre.Focus();
            }
        }

        public static string digitoVerificador(string strRut)
        {
            int rut;
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            string RutDigito;
            if (strRut == "")
            {
                return "";
            }
            rut = Convert.ToInt32(strRut);
            Contador = 2;
            Acumulador = 0;
            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }
            }
            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }
            return (RutDigito);
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            lblerror2.Text = "";
            if (rdbtipodir.SelectedIndex == -1)
            {
                lblerror2.Visible = true;
                lblerror2.Text = "Debe seleccionar un tipo de direccion";
            }
            else
            {
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

                
                if (txt_celular.Text != "")
                {
                    string celupers = new TelefonoBC().add_telefonos(Convert.ToInt32(txt_rut.Text), "TCEL", Convert.ToInt32(this.txt_celular.Text), 0);
                }
              

                if (txt_telefono.Text != "")
                {
                    string telefonopers = new TelefonoBC().add_telefonos(Convert.ToInt32(txt_rut.Text), "TOFI", Convert.ToInt32(this.txt_telefono.Text), 0);
                }
                
                string pers = new PersonaBC().add_persona(Convert.ToInt32(txt_rut.Text), txt_dv.Text.Trim(), 2, "", txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, "0", "0", "", "", "", txt_telefono.Text, "", "", txtdireccion.Text, "0", rdbtipodir.SelectedValue, "",giro);
                string dirpers = new DireccionesBC().add_direcciones(Convert.ToInt32(txt_rut.Text), this.txtdireccion.Text, rdbtipodir.SelectedValue, this.txt_numeriDir.Text, Convert.ToInt32(cboComuna.SelectedValue), "", 0);

                switch (lbl_Oper_Tipo.Text)
                {
                    //case "C":
                    //    string magenda = new AgendaBC().del_agenda(Convert.ToInt32(lbl_Oper_ID.Text));
                    //    string add_esta = new EstadooperacionBC().add_estado_orden(Convert.ToInt16(lbl_Oper_ID.Text), 60, "AGND", txt_obs.Text, (string)(Session["usrname"]));
                    //    FuncionGlobal.alerta_updatepanel("Operacion " + lbl_Oper_ID.Text + " guardada correctamente", Page, up);

                    //    mensajeOper(7, lbl_Oper_ID.Text);

                    //    break;
                    case "R":
                        if (cbo_EjeCom.SelectedValue != "0")
                        {
                            lblerror2.Text = "";
                            cbo_EjeCom.BackColor = System.Drawing.Color.White;
                            Int32 rut = Convert.ToInt32(txt_rut.Text);
                            string add = new AgendaBC().add_agenda(Convert.ToInt32(lbl_Oper_ID.Text), Convert.ToDateTime(lbl_Oper_Fecha.Text), lbl_Oper_Hora.Text, rut, (string)(Session["usrname"]), cbo_EjeCom.SelectedValue, cbo_tipoagenda.SelectedValue, dl_Usuarios.SelectedValue.Trim());
                            string add_est = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(lbl_Oper_ID.Text), 80, "AGND", txt_obs.Text, (string)(Session["usrname"]));

                        }
                        else
                        {
                            lblerror2.Text = "debe Seleccionar un Ejecutivo Comercial";
                            cbo_EjeCom.BackColor = System.Drawing.Color.Yellow;
                            cbo_EjeCom.Focus();
                            return;
                        }
                        break;
                    case "T":
                        if (cbo_EjeCom.SelectedValue != "0")
                        {
                            lblerror2.Text = "";
                            cbo_EjeCom.BackColor = System.Drawing.Color.White;
                            Int32 opr = new OperacionBC().add_operacion(0, Convert.ToInt16(lbl_Oper_IDCli.Text), "AGND", (string)(Session["usrname"]), 0,"",0,0);
                            string add_operacion = new AgendaBC().add_agenda(Convert.ToInt32(opr), Convert.ToDateTime(lbl_Oper_Fecha.Text), lbl_Oper_Hora.Text, Convert.ToInt32(txt_rut.Text), (string)(Session["usrname"]), cbo_EjeCom.SelectedValue, cbo_tipoagenda.SelectedValue, dl_Usuarios.SelectedValue.Trim());
                            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(opr), 10, "AGND", txt_obs.Text, (string)(Session["usrname"]));

                            foreach (GridViewRow row in grdAddCreditos.Rows)
                            {
                                string idref = row.Cells[0].Text;
                                string addBCA = new MasterBCABC().add_MasterBCA(opr, idref, 0);
                            }
                            mensajeOper(1, opr.ToString());
                            FuncionGlobal.alerta_updatepanel("Operacion " + opr + " guardada correctamente", Page, up);
                        }
                        else
                        {
                            lblerror2.Text = "debe Seleccionar un Ejecutivo Comercial";
                            cbo_EjeCom.BackColor = System.Drawing.Color.Yellow;
                            cbo_EjeCom.Focus();
                            return;
                        }
                        break;
                }

                bt_guardar.Enabled = false;
                bt_Volver.Visible = true;
            }
        }

        protected void bt_Volver_Click(object sender, EventArgs e)
        {
            TBL_Agenda.Visible = true;
            TBL_Operacion.Visible = false;
            BuscarAgenda();
            LimpiarOper();
            bt_Volver.Visible = false;
        }

        private void LimpiarOper()
        {
            this.txt_numeriDir.Text = "";
            this.txt_dv.Text = "";
            this.txt_celular.Text = "";
            this.txt_rut.Text = "";
            this.txtApellidoM.Text = "";
            this.txtApellidoP.Text = "";
            this.txtdireccion.Text = "";
            this.txtNombre.Text = "";
            this.cboComuna.SelectedIndex = 0;
        }

        private void CreditosBice(List<MasterBCA> lst)
        {
            if (lst.Count > 0)
            {
                this.btnRechCred.Visible = true;
                this.bt_finalizar.Visible = true;
                DataTable dt = new DataTable();
                dt.Columns.Add("Id_solicitud", typeof(string));
                dt.Columns.Add("Id_interno", typeof(string));
                dt.Columns.Add("Id_credito", typeof(string));

                DataRow rowcr;
                foreach (MasterBCA item in lst)
                {
                    rowcr = dt.Rows.Add();
                    rowcr["Id_solicitud"] = item.Id_solicitud;
                    rowcr["Id_interno"] = item.Id_interno;
                    rowcr["Id_credito"] = item.Id_credito;

                }

                this.grdCrditos.DataSource = dt;
                this.grdCrditos.DataBind();
            }
            else
            {
                lblError.Text = "Aun no Se firman Creditos para esta operacion";
            }
        }

        protected void grdCrditos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string idoper = e.Row.Cells[2].Text;
                ImageButton ibuton;

                ibuton = (ImageButton)e.Row.FindControl("ib_cdigital");
                ibuton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(idoper) + "&origen=pc','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");

            }
        }

        protected void btnRechCred_Click(object sender, EventArgs e)
        {
            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(lbl_Oper_ID.Text), 99, "AGND", txt_obs.Text, (string)(Session["usrname"]));
            this.label_fin.Visible = true;
            this.bt_finalizar.Visible = false;
            this.bt_guardar.Visible = false;
            this.bt_Volver.Visible = true;

            foreach (GridViewRow row in grdCrditos.Rows)
            {
                string idref = row.Cells[1].Text;
                string add_esta = new EstadooperacionBC().add_estado_orden(Convert.ToInt16(idref), 70, "CBCA", txt_obs.Text, (string)(Session["usrname"]));
            }

            mensajeOper(7, lbl_Oper_ID.Text);
        }

        protected void btnAgregarcredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cantidadCredito.Text != "")
                {
                    DataTable dtaddcred = new DataTable();
                    dtaddcred.Columns.Add("Id_interno", typeof(string));

                    DataRow drNewRow = dtaddcred.NewRow();

                    for (int i = 0; i < grdAddCreditos.Rows.Count; i++)
                    {
                        drNewRow = dtaddcred.NewRow();
                        drNewRow["Id_interno"] = this.grdAddCreditos.Rows[i].Cells[0].Text;
                        dtaddcred.Rows.Add(drNewRow);
                    }

                    if (this.txt_cantidadCredito.Text != "")
                    {
                        drNewRow = dtaddcred.NewRow();
                        drNewRow["Id_interno"] = this.txt_cantidadCredito.Text;
                        dtaddcred.Rows.Add(drNewRow);
                    }


                    if (dtaddcred.Rows.Count > 0)
                    {
                        bt_guardar.Enabled = true;
                    }
                    grdAddCreditos.DataSource = dtaddcred;
                    grdAddCreditos.DataBind();
                    txt_cantidadCredito.Text = "";
                    txt_cantidadCredito.Focus();
                }
            }
            catch (Exception ex)
            {
                lblerror2.Text = ex.Message;
            }

        }

    }
}