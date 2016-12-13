using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.AgNotaPedido;

namespace sistemaAGP.OrdenTrabajo
{
    public partial class NuevaOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            FuncionGlobal.comboclientesbyusuario(Session["usrname"].ToString(), dlCliente);
            FuncionGlobal.comboparametro(dlQuienPaga, "CAVE");
            ComboFormaPago(dlFormaPago, "FOPA");
            FuncionGlobal.comboparametro(dlImpuestoVerde, "IMPV");
            dlFormaPago.Items[0].Text = "Forma de pago";
            dlQuienPaga.Items[0].Text = "Quién paga";
            dlCliente.Items[0].Text = "Cliente";
            dlImpuestoVerde.Items[0].Text = "¿Con impuesto verde?";
            GetProductos();
            Mensajes("Hola, crea una nueva solicitud de pedido", 4);
        }

        public void ComboFormaPago(DropDownList combobox, string tipoparametro)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));

            //solo credito y contado
            IOrderedEnumerable<Parametro> lParametro = from p in new ParametroBC().GetParametroByTipoParametro(tipoparametro)
                                                       where p.Codigoparametro == "1" || p.Codigoparametro == "2"
                                                       orderby p.Orden ascending
                                                       select p;   


            combobox.DataSource = lParametro;
            combobox.DataValueField = "codigoparametro";
            combobox.DataTextField = "valoralfanumerico";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        protected void ibTerminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Add();
                Mensajes("Nueva solicitud ingresada", 1);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, 3);
            }

        }


        public void Mensajes(string mensaje, int tipo)
        {
            Master.LblInfo.Text = mensaje;

            switch (tipo)
            {
                case 1:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/verde.png";
                    break;
                case 2:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/warning.png";
                    break;
                case 3:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/rojo.png";
                    break;
                case 4:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/bienvenido.png";
                    break;
            }
        }


        public void GetProductos()
        {
            var list = from x in new OrdenTrabajoProductoDocumentoBC().GetAllProductos() orderby x.TipoOperacion.Operacion ascending  select  x;

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("producto"));

            foreach (var ot in list)
            {
                var dr = dt.NewRow();
                dr["codigo"] = ot.TipoOperacion.Codigo;
                dr["producto"] = ot.TipoOperacion.Operacion;
             

                dt.Rows.Add(dr);
            }

            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }




        protected void add_leido(Object sender, EventArgs e)
        {

            var row = (GridViewRow)(((CheckBox)sender).NamingContainer);
            var hdnCod = (HiddenField)row.Cells[2].FindControl("hdCod");
            var checkbox = (CheckBox)sender;

            if (checkbox.Checked)
            {
                GetDocumentos(hdnCod.Value);
            }
            else
            {
                DelFila(hdnCod.Value);
            }
        }

        public void DelFila(string tipoOperacion)
        {
            var dt = (DataTable)ViewState["documentos"];
            for (int i = grDoc.Rows.Count - 1; i > -1; i--)
            {

                var codigoProd = grDoc.DataKeys[i]["codProducto"].ToString();
                if (codigoProd.Trim() == tipoOperacion.Trim())
                {
                    dt.Rows[i].Delete();

                }
            }

            ViewState["documentos"] = dt;
            grDoc.DataSource = dt;
            grDoc.DataBind();
        }




        public void GetDocumentos(string producto)
        {
            var dt = new DataTable();
            if (ViewState["documentos"] != null)
            {
                dt = (DataTable)ViewState["documentos"];
            }
            else
            {

                dt.Columns.Add(new DataColumn("codProducto"));
                dt.Columns.Add(new DataColumn("idDocumento"));
                dt.Columns.Add(new DataColumn("ducumento"));
            }

            var lDocumentos = new OrdenTrabajoProductoDocumentoBC().GetAllDocumentoByProducto(producto);



            foreach (var ot in lDocumentos)
            {
                if (dt.AsEnumerable().Any(row => ot.Documento.Id_documento.ToString() == row.Field<String>("idDocumento"))) continue;
                var dr = dt.NewRow();
                dr["codProducto"] = producto;
                dr["idDocumento"] = ot.Documento.Id_documento;
                dr["ducumento"] = ot.Documento.Nombre;

                dt.Rows.Add(dr);
            }
            ViewState["documentos"] = dt;
            grDoc.DataSource = dt;
            grDoc.DataBind();

        }



        public void Add()
        {
            var errores = "";
            if (dlSucursal.SelectedValue == "0" || dlSucursal.SelectedValue == "") errores = errores + (" - Seleccione una sucursal");
            if (dlQuienPaga.SelectedValue == "0") errores = errores + (" - Seleccione Quién Paga");
            if (dlImpuestoVerde.SelectedValue == "0") errores = errores + (" - Seleccione Con o sin Impuesto verde");
            if (dlFormaPago.SelectedValue == "2" && dlFinanciera.SelectedValue == "0")
            {
                errores = errores + " - Si selecciona opción de pago Crédito, seleccione la financiera";
            }
            if (errores != "")
            {
                throw new ArgumentException(errores);
            }

            var val = ValidaProductosCheckeados();
            if (val.Cantidad == 0)
            {
                throw new ArgumentException("Seleccione uno o mas servicios");
            }
            if (val.PedirNumeroPedido)
            {
                ModalPopupExtender2.Show();
                return;
            }
            const int siguienteActividad = 2;
            var siguienteUsuario = "";

            foreach (var usuarios in new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(
                                       new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = siguienteActividad } }, "1",0))//1= grupo primera
            {
                siguienteUsuario = usuarios.Usuario.UserName;
            }


            AddOrdenTrabajo(siguienteActividad, siguienteUsuario);

        }

        public void AddOrdenTrabajo(int siguienteActividad, string siguienteUsuario)
        {     //V000000006
            //var numeroPedido = "V";
            //if (txtNumeroPedido.Value.Trim() != "Número de pedido")
            //{

            //    var caracteresIngresados = txtNumeroPedido.Value.Trim().Length;
            //    if (caracteresIngresados > 9)
            //    {
            //        throw new ArgumentException("Ingrese un numero válido de Nota de Pedido.");
            //    }
            //    var conteo = 0;
            //    while (conteo < (9 - caracteresIngresados))
            //    {
            //        numeroPedido = numeroPedido + "0";
            //        conteo++;
            //    }
            //    numeroPedido = numeroPedido + txtNumeroPedido.Value.Trim();
            //}


            var id = new OrdenTrabajoBC().AddOrdenTrabajo(new CENTIDAD.OrdenTrabajo
            {
                IdOrden = 0,
                Activo = true,
                CuentaUsuario = Session["usrname"].ToString(),
                QuienPaga = dlQuienPaga.SelectedValue,
                TmEspecial = GetTerminacionEspecial(),
                NumeroOrden = txtNumeroPedido.Value.Trim() == "Número de pedido" || txtNumeroPedido.Value.Trim() == "" ? "S/N" : txtNumeroPedido.Value.Trim(),
                IdCliente = Convert.ToInt32(dlCliente.SelectedValue),
                IdSucursal = Convert.ToInt32(dlSucursal.SelectedValue),
                CodigoFormaPago = dlFormaPago.SelectedValue,
                CodigoFinanciera = dlFinanciera.SelectedValue,
                ImpuestoVerde = dlImpuestoVerde.SelectedValue,
                CompraPara = txtCompraPara.Value,
                Observacion = txtObservación.Value,
                VinCorto = txtVin.Value.Trim() == "Vin" || txtVin.Value.Trim() == "" ? "" : txtVin.Value.Trim(),
                VehiculoCit = txtCit.Value.Trim() == "Cit" || txtCit.Value.Trim() == "" ? "" : txtCit.Value.Trim(),
                AbonoCliente = txtAbono.Value.Trim() == "Abono cliente" || txtAbono.Value.Trim() == "" ? 0 : Convert.ToInt32(txtAbono.Value.Trim())

            });

            if (id == -1)
            {
                Mensajes("Ya existe una Orden de pedido", 3);
                return;
            }

            AddServicios(id);
            AddDocumentos(id);

            //var logExiste =
            //    new OrdenTrabajoActividadLogBC().GetLastOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog { OrdenTrabajo = new CENTIDAD.OrdenTrabajo { IdOrden = id } });


            ////if (logExiste.IdOrdenTrabajoActividadLog != 0)
            //{
            //    var lista = new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 1 } });

            //    foreach (var usu in lista)
            //    {
            //        siguienteUsuario = usu.Usuario.UserName;
            //    }
            //    siguienteActividad = siguienteActividad + 1;
            //}
            //else
            //{
            //    siguienteUsuario = "wsag";
            //}

            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = siguienteUsuario
                    ,
                    IdOrden = id
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = siguienteActividad },
                Avanza = 1,
                IdOrdenTrabajoActividadLog = 0
            });


        }


        public void Limpiar()
        {
            dlFormaPago.SelectedValue = "0";
            dlFinanciera.SelectedValue = "0";
            dlQuienPaga.SelectedValue = "0";
            dlImpuestoVerde.SelectedValue = "0";
            ck0.Checked = false;
            ck1.Checked = false;
            ck2.Checked = false;
            ck3.Checked = false;
            ck4.Checked = false;
            ck5.Checked = false;
            ck6.Checked = false;
            ck7.Checked = false;
            ck8.Checked = false;
            ck9.Checked = false;
            dlFinanciera.Visible = false;
            txtCit.Value = "";
            txtAbono.Value = "";
            txtObservación.Value = "";
            txtNumeroPedido.Value = "";
            txtVin.Value = "";
            txtCompraPara.Value = "";
            txtVin.MaxLength = 6;
            txtVin.Attributes.Add("placeholder", "Vin");

        }


        public string GetTerminacionEspecial()
        {
            var check = "";
            if (ck0.Checked)
            {
                check = "(0)";
            }
            if (ck1.Checked)
            {
                check = check + "(1)";
            }
            if (ck2.Checked)
            {
                check = check + "(2)";
            }
            if (ck3.Checked)
            {
                check = check + "(3)";
            }
            if (ck4.Checked)
            {
                check = check + "(4)";
            }
            if (ck5.Checked)
            {
                check = check + "(5)";
            }
            if (ck6.Checked)
            {
                check = check + "(6)";
            }
            if (ck7.Checked)
            {
                check = check + "(7)";
            }
            if (ck8.Checked)
            {
                check = check + "(8)";
            }
            if (ck9.Checked)
            {
                check = check + "(9)";
            }
            return check;
        }

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.CombosucursalbyclienteCombobox(dlSucursal, Convert.ToInt16(dlCliente.SelectedValue));
            FuncionGlobal.combobanco(dlFinanciera, Convert.ToInt16(dlCliente.SelectedValue));
            dlFinanciera.Items[0].Text = "Financiera";
            dlSucursal.Items[dlSucursal.Items.Count - 1].Text = "Sucursal";

            //regla de negocio especiales para clientes. muestra el formulario que se necesite.
            FormularioParaCliente(Convert.ToInt32(dlCliente.SelectedValue));
        }


        private void FormularioParaCliente(int idCliente)
        {
           //regla de negocio especiales para clientes. muestra el formulario que se necesite.
            switch (idCliente)
            {
                case 4://para GUILDEMEISTER
                    txtCompraPara.Visible = false;
                    txtCit.Visible = false;
                    break;
                default: //todo el formulario visible 
                    txtCit.Visible = true;
                    txtCompraPara.Visible = true;
                    break;
            } 

        }



        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(udp, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        public class RespuestaVal
        {
            public int Cantidad { get; set; }
            public bool PedirNumeroPedido { get; set; }
        }

        public void AddServicios(int idOt)
        {
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var idProd = gr_dato.DataKeys[i].Values["codigo"].ToString().Trim();

                if (chk.Checked)
                {
                    new OrdenTrabajoBC().AddServicio(idOt, idProd);
                }
            }
        }

        public void AddDocumentos(int idOt)
        {

            for (var i = 0; i < grDoc.Rows.Count; i++)
            {
                var chk = (CheckBox)grDoc.Rows[i].FindControl("chk");

                var idDoc = Convert.ToInt32(grDoc.DataKeys[i].Values["idDocumento"].ToString().Trim());

                if (chk.Checked)
                {
                    new OrdenTrabajoBC().AddDocumento(idOt, idDoc);
                }
            }
        }

        public RespuestaVal ValidaProductosCheckeados()
        {
            var conteo = 0;
            var resp = new RespuestaVal();
            var pedirNumero = false;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
                var codigo = gr_dato.DataKeys[i].Values["codigo"].ToString().Trim();

                if (!chk.Checked) continue;
                conteo++;
                if (codigo == "IP" || codigo == "PI" || codigo == "STMH" || codigo == "TFPI" || codigo == "TFSI" || codigo == "TMAH")
                {
                    pedirNumero = true;
                }
            }
            resp.Cantidad = conteo;
            resp.PedirNumeroPedido = pedirNumero;
            return resp;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var error = "";
            if (txtNumeroPedido.Value.Trim() == "Número de pedido" || txtNumeroPedido.Value.Trim() == "")
            {
                error = error + " - Ingrese un número de pedido para seguir avanzando";
            }
            if ((txtCit.Value.Trim() == "Cit" || txtCit.Value.Trim() == "")&& dlCliente.SelectedValue != "4")//4 AG
            {
                error = error + " - Ingrese un número Cit";
            }
            if (txtVin.Value.Trim() == "Vin" || txtVin.Value.Trim() == "")
            {
                error = error + " - Ingrese el Vin";
            }
            if (dlFormaPago.SelectedValue == "2" && dlFinanciera.SelectedValue == "0")
            {
                error = error + " - Si selecciona opción de pago Crédito, seleccione la financiera";
            }
            if (error.Trim() != "")
            {
                Mensajes(error, 2);
            }

            //METODO WEB SERVICE QUE ENVIA NOTA PEDIDO Y VIN CORTO DE 6 CARACTERES, AL RETORNAR -2 ESTO OBLIGA A INGRESAR EL VIN COMPLETO DE 17 CARACTERES

            //DESCOMENTAR EN DESARROLLO
            //var respuesta = DarNumerosAg();

            //if (respuesta.codigo == -2)
            //{
            //    txtVin.Value = "";
            //    txtVin.MaxLength = 17;
            //    txtVin.Attributes.Add("placeholder", "Vin completo");
            //    ModalPopupExtender2.Show();
            //    Mensajes("Ups!... Por favor Ingresa el Vin Completo en lugar de los últimos 6 caracteres.", 2);
            //    return;
            //}

            //if (respuesta.codigo == -1)
            //{
            //    Mensajes("Ups!... Existe el siguiente error. " + respuesta.msg_Error, 3);
            //    return;
            //}

            try
            {
                AddOrdenTrabajo(1, "wsag");
                Limpiar();
                GetProductos();
                GetDocumentos("");
                Mensajes("Nueva solicitud ingresada", 1);

            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, 3);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtNumeroPedido.Value = "";
            ModalPopupExtender2.Hide();
        }

        //DESCOMENTAR EN DESARROLLO
        public NotaPedidoBE DarNumerosAg()
        {
            var numeroPedido = "V";
            if (txtNumeroPedido.Value.Trim() != "Número de pedido")
            {     
                var caracteresIngresados = txtNumeroPedido.Value.Trim().Length;
                if (caracteresIngresados > 9)
                {
                    throw new ArgumentException("Ingrese un numero válido de Nota de Pedido.");
                }
                var conteo = 0;
                while (conteo < (9 - caracteresIngresados))
                {
                    numeroPedido = numeroPedido + "0";
                    conteo++;
                }
                numeroPedido = numeroPedido + txtNumeroPedido.Value.Trim();
            }
            var xx = new NotaPedidoServiceClient();

            var respuesta = xx.RegistraNotaPedido(numeroPedido, txtVin.Value.Trim(), Session["usrname"].ToString());
            xx.Close();
            return respuesta;

        }

        public int InsertarEstadoAg(string vin)
        {
            var xx = new NotaPedidoServiceClient();      
            var respuesta =  xx.ActualizaEstadoNotaPedido(vin, "A1");
            xx.Close();
            return respuesta;
        }

        protected void dlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccion = dlFormaPago.SelectedValue;
            //si seleccion es credito (2) se muestra la financiera
            dlFinanciera.Visible = seleccion == "2";
        }
    }
}