using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP
{
    public partial class SoliInfoAuto : Page
    {
        public Usuario Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            //FuncionGlobal.comboparametro(dlTipoDoc, "TIDOCINF"); 
            FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), dlCliente);
            Usuario = new UsuarioBC().GetUsuario(Session["usrname"].ToString());
            hdIdCliente.Value = Usuario.Cliente.Id_cliente.ToString();
            if (Usuario.Cliente.Id_cliente != 1)
            {
                txtVariasOperaciones.Style.Add("display", "none");
                txtOperacion.Style.Add("display", "none");
                chkAsociar.Style.Add("display", "none");
                chkAsociarVarias.Style.Add("display", "none");                           
            }
            if (Usuario.Cliente.Id_cliente != 72) return;
            var cav = dlTipoDoc.Items.FindByValue("SCAV");
            var multas = dlTipoDoc.Items.FindByValue("CAVMUL");
            dlTipoDoc.Items.Remove(cav);
            dlTipoDoc.Items.Remove(multas);
        }

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbyclienteandUsuario(dlSucursal, Convert.ToInt16(dlCliente.SelectedValue), (string)(Session["usrname"]));
            //FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), dlFamilia); 
            FuncionGlobal.CombofamiliabyusuarioInfocarCav((string)(Session["usrname"]), dlFamilia);
            txtOperacion.Enabled = false;
            txtOperacion.Text = string.Empty;

        }

        protected void ibPedir_Click(object sender, ImageClickEventArgs e)
        {
            add_oper();
            Limpiar();
        }

        private void Limpiar()
        {
            txtPatenteSol.Text = string.Empty;
            txtVariasPatentes.Text = string.Empty;
            txtOperacion.Text = string.Empty;
            txtVariasOperaciones.Text = string.Empty;
            dlCliente.SelectedValue = "0";
            dlSucursal.SelectedValue = "0";
            dlFamilia.SelectedValue = "0";

        }

        protected void add_oper()
        {
            var correctas = "Resultado: ";
            if (rdbuna.Checked)
            {
                if (txtPatenteSol.Text.Trim() == "" || dlCliente.SelectedValue == "0" || dlSucursal.SelectedValue == "0" || dlFamilia.SelectedValue == "0")
                {
                    Mensaje("Por favor ingrese todos los datos.");
                    return;
                }
                if (!FuncionGlobal.formatoPatente(txtPatenteSol.Text.Trim()))
                {
                    Mensaje("Por favor ingrese un formato correcto de patente Ej: LLNNNN - LLLNNN - LLLLNN.");
                    txtPatenteSol.Text = "";
                    txtPatenteSol.Focus();
                    return;
                }
            }
            else if (rdbVarias.Checked)
            {
                if (txtVariasPatentes.Text.Trim() == "" || dlCliente.SelectedValue == "0" || dlSucursal.SelectedValue == "0")
                {
                    Mensaje("Por favor ingrese todos los datos.");
                    return;
                } 
            }

            try
            {

                var idSolicitudAsociada = txtOperacion.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txtOperacion.Text.Trim());

                switch (dlTipoDoc.SelectedValue.Trim())
                {
                    case "INFAU":
                        if (rdbuna.Checked)
                        {
                            var add = new OperacionBC().add_operacion(0, Convert.ToInt16(dlCliente.SelectedValue), "INFAU", (string)(Session["usrname"]), 0, "", Convert.ToInt32(dlSucursal.SelectedValue), 0);
                            new EstadooperacionBC().add_estado_orden(add, 1, "INFAU", "", (string)(Session["usrname"]));
                            new InfoAutoBC().add_Datosvehiculo(add, txtPatenteSol.Text, 259);
                            Mensaje("Solicitud ingresada satisfactoriamente, con el número: " + add.ToString().Trim() + ", por favor espere mientras procesamos la información.");
                            break;
                        }
                        if (rdbVarias.Checked)
                        {
                            correctas = correctas + AddVarias("INFAU",false);
                        }

                        break;
                    case "CCAV":
                        if (rdbuna.Checked)
                        {
                            if (chkAsociar.Checked)
                            {
                                if (!ValidarOperacionAsociada(idSolicitudAsociada, txtPatenteSol.Text.Trim()))
                                {
                                    Mensaje(@"No se puede asociar la patente a la solicitud por los siguientes motivos: \n 
                                           No exite operacion. \n
                                           La patente no corresponde a la operación a la que se loe intenta asociar.\n
                                           La operación a asociar no es de la familia TRANSFERENCIAS, GARANTIAS o PRIMERA.");
                                    break;
                                }
                            }
                            else
                            {
                                //Si no esta el check de asociar SIEMPRE DEBE SER 0 
                                idSolicitudAsociada = 0;
                            }

                            var xx = new OperacionBC().add_operacion(0, Convert.ToInt16(dlCliente.SelectedValue),
                                                                     "CCAV", (string)(Session["usrname"]), 0, "",
                                                                     Convert.ToInt32(dlSucursal.SelectedValue), 0);

                            new InfoAutoBC().add_Datosvehiculo(xx, txtPatenteSol.Text, 259, idSolicitudAsociada);
                            new EstadooperacionBC().add_estado_orden(xx, 1, "CCAV", "Solicitud ingresada",
                                                                     (string)(Session["usrname"]));
                            Mensaje("Solicitud ingresada satisfactoriamente, con el número: " + xx.ToString().Trim() +
                                    ", por favor espere mientras procesamos la información.");

                        }
                        else if (rdbVarias.Checked)
                        {
                            var mensajeIngreso = AddVarias("CCAV", chkAsociarVarias.Checked);
                            Mensaje(mensajeIngreso);
                        }

                        break;
                    case "CAMUL":
                        if (rdbuna.Checked)
                        {
                            if (chkAsociar.Checked)
                            {
                                if (!ValidarOperacionAsociada(idSolicitudAsociada, txtPatenteSol.Text.Trim()))
                                {
                                    Mensaje(@"No se puede asociar la patente a la solicitud por los siguientes motivos: No exite operacion. La patente no corresponde a la operación a la que se loe intenta asociar. La operación a asociar no es de la familia TRANSFERENCIAS, GARANTIAS o PRIMERA.");
                                    break;
                                }
                            }
                            else
                            {
                                //Si no esta el check de asociar SIEMPRE DEBE SER 0 
                                idSolicitudAsociada = 0;
                            }

                            var hh = new OperacionBC().add_operacion(0, Convert.ToInt16(dlCliente.SelectedValue),
                                                                     "CAMUL", (string)(Session["usrname"]), 0, "",
                                                                     Convert.ToInt32(dlSucursal.SelectedValue), 0);

                            new InfoAutoBC().add_Datosvehiculo(hh, txtPatenteSol.Text, 259, idSolicitudAsociada);
                            new EstadooperacionBC().add_estado_orden(hh, 1, "CAMUL", "Solicitud ingresada",
                                                                     (string)(Session["usrname"]));
                            Mensaje("Solicitud ingresada satisfactoriamente, con el número: " + hh.ToString().Trim() +
                                    ", por favor espere mientras procesamos la información.");
                            break;
                        }
                        if (rdbVarias.Checked)
                        {
                            var mensajeIngreso = AddVarias("CAMUL",chkAsociarVarias.Checked);
                            Mensaje(mensajeIngreso);
                        }
                        break;
                }

                //Mensaje(correctas);

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private bool ValidarOperacionAsociada(int idSolicitudAsociada, string patente)
        {
            //VALIDAR QUE EXISTA OPERACION/VALIDAR QUE PATENTE PERTENEZCA A OPERACION
            var dt = new InfoAutoBC().ValidaExistenciaOperacion(idSolicitudAsociada, patente);
            return Convert.ToBoolean(dt.Rows[0]["resultado"]);
        }

        public string AddVarias(string tipoOperacion, bool asociar)
        {
            var correctas = 0;
            var incorrectasCount = 0;

            var incorrectas = "Las siguientes Patentes son Incorrectas por error de formato: ";

            var textoPatentes = txtVariasPatentes.Text.Trim();
            textoPatentes = textoPatentes.Replace("-", "");
            textoPatentes = textoPatentes.Replace(" ", "");
            char[] delimiterCharsPatentes = { '\n' };

            var textoSolicitud = txtVariasOperaciones.Text.Trim();
            textoSolicitud = textoSolicitud.Replace("-", "");
            textoSolicitud = textoSolicitud.Replace(" ", "");
            char[] delimiterCharsSolicitudes = { '\n' };


            string[] wordsPatentes = textoPatentes.Split(delimiterCharsPatentes, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsOperaciones = textoSolicitud.Split(delimiterCharsPatentes, StringSplitOptions.RemoveEmptyEntries);


            if (!asociar)
            {
                if (wordsPatentes.Any())
                {
                    foreach (var patente in wordsPatentes.Select(x => x.Substring(0, 6)))
                    {
                        if (!FuncionGlobal.formatoPatente(patente))
                        {
                            incorrectasCount++;
                            incorrectas = incorrectas + patente + "- ";
                        }
                    }

                    if (incorrectasCount == 0)
                    {
                        foreach (var patente in wordsPatentes.Select(x => x.Substring(0, 6)))
                        {
                            var xx = new OperacionBC().add_operacion(0, Convert.ToInt16(dlCliente.SelectedValue),
                                                                         tipoOperacion, (string)(Session["usrname"]), 0, "",
                                                                         Convert.ToInt32(dlSucursal.SelectedValue), 0);
                            new InfoAutoBC().add_Datosvehiculo(xx, patente, 259);
                            new EstadooperacionBC().add_estado_orden(xx, 1, tipoOperacion, "Solicitud ingresada",
                                                                     (string)(Session["usrname"]));
                            correctas++;
                        }
                    
                    }

                }
            }
            else
            {
                if (wordsPatentes.Any())
                {
                    if (wordsPatentes.Count() == wordsOperaciones.Count())
                    {
                        foreach (var patente in wordsPatentes.Select(x => x.Substring(0, 6)))
                        {
                            if (!FuncionGlobal.formatoPatente(patente))
                            {
                                incorrectasCount++;
                                incorrectas = incorrectas + patente + ", ";
                            }
                        }

                        if (incorrectasCount == 0)
                        {
                            incorrectas= @"No exite operacion. La patente no corresponde a la operación a la que se le intenta asociar. La operación a asociar no es de la familia TRANSFERENCIAS, GARANTIAS o PRIMERA.";
                            for (var i = 0; i < wordsPatentes.Count(); i++)
                            {
                                var patente = wordsPatentes[i].Substring(0, 6);
                                var idSolicitud = wordsOperaciones[i].Substring(0, 6);
                                if(!ValidarOperacionAsociada(Convert.ToInt32(idSolicitud),patente.Trim()))
                                {
                                    incorrectasCount++;
                                    incorrectas = incorrectas + idSolicitud + "-";
                                }                            
                            }

                            if (incorrectasCount == 0)
                            {
                                for (var i = 0; i < wordsPatentes.Count(); i++)
                                {
                                    var patente = wordsPatentes[i].Substring(0, 6);
                                    var idSolicitud = wordsOperaciones[i].Substring(0, 6);

                                    var xx = new OperacionBC().add_operacion(0, Convert.ToInt16(dlCliente.SelectedValue),
                                                                     tipoOperacion, (string)(Session["usrname"]), 0, "",
                                                                     Convert.ToInt32(dlSucursal.SelectedValue), 0);
                                    new InfoAutoBC().add_Datosvehiculo(xx, patente, 259, Convert.ToInt32(idSolicitud));
                                    new EstadooperacionBC().add_estado_orden(xx, 1, tipoOperacion, "Solicitud ingresada",
                                                                             (string)(Session["usrname"]));
                                    correctas++;
                                }
                            }

                        }

                    }

                }

            }




            if (incorrectasCount == 0)
            {
                return "Se han solicitado correctamente " + correctas + " patentes.";
            }
            else
            {
                return "ERROR. No se procesaron las solicitudes debido a:" + incorrectas + ".Revise e intente nuevamente."; 
            }

        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta("hola",Page);
            FuncionGlobal.alerta_updatepanel(mensaje, Page, UpdatePanel1);
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOperacion.Enabled = false;
            txtOperacion.Text = string.Empty;
            FuncionGlobal.ComboProductosByFamiliaClienteUsuario(dlTipoDoc, Convert.ToInt32(dlFamilia.SelectedValue), Convert.ToInt16(dlCliente.SelectedValue), Session["usrname"].ToString());
        }

        protected void dlTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idClienteUsuario = Convert.ToInt32(hdIdCliente.Value);

            if (idClienteUsuario == 1)
            {
                switch (dlTipoDoc.SelectedValue.ToLower().Trim())
                {
                    case "ccav":
                    case "camul":
                        txtOperacion.Enabled = true;
                        break;
                    default:
                        txtOperacion.Enabled = false;
                        break;
                }
            }
            else
            {
                txtOperacion.Enabled = false;
            }
        }

        protected void chkAsociar_CheckedChanged(object sender, EventArgs e)
        {
            txtOperacion.Text = string.Empty;
            txtOperacion.Enabled = chkAsociar.Checked;
            txtOperacion.BorderColor = chkAsociar.Checked ? System.Drawing.Color.Green : System.Drawing.Color.Azure;
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            if (rdbuna.Checked)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "ocultarVarios", "ocultarVarios()", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "mostrarVarios", "mostrarVarios()", true);
            }
            if (hdIdCliente.Value.Trim() != "1")
            { ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "mostrarUsuariosAGPAsociaciones", "mostrarUsuariosAGPAsociaciones()", true); }
           
            
        }




    }
}
