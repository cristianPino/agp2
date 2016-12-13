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
using sistemaAGP.OrdenTrabajo;

namespace sistemaAGP.controles
{
    public partial class wucOtPropiedades : UserControl
    {
        public int IdOrdenTrabajo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_orden_trabajo"]));
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

            GetAll();

        }


        private void GetAll()
        {
            var ordenTrabajo = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);
            dlFormaPago.SelectedValue = ordenTrabajo.CodigoFormaPago.Trim();  
            dlQuienPaga.SelectedValue = ordenTrabajo.QuienPaga.Trim();
            dlImpuestoVerde.SelectedValue = ordenTrabajo.ImpuestoVerde.Trim();
            dlCliente.SelectedValue = ordenTrabajo.IdCliente.ToString(CultureInfo.InvariantCulture);
            FuncionGlobal.CombosucursalbyclienteCombobox(dlSucursal, Convert.ToInt16(dlCliente.SelectedValue));
            FuncionGlobal.combobanco(dlFinanciera, Convert.ToInt16(ordenTrabajo.IdCliente));       
            dlSucursal.Items[dlSucursal.Items.Count - 1].Text = "Sucursal";
            dlFinanciera.SelectedValue = ordenTrabajo.CodigoFinanciera.Trim();      
            txtAbono.Value = ordenTrabajo.AbonoCliente.ToString(CultureInfo.InvariantCulture);
            dlSucursal.SelectedValue = ordenTrabajo.IdSucursal.ToString(CultureInfo.InvariantCulture);
            txtCit.Value = ordenTrabajo.VehiculoCit;
            txtObservación.Value = ordenTrabajo.Observacion;
            txtCompraPara.Value = ordenTrabajo.CompraPara;

            //split terminacion especial
            TerminaciónEspecial(ordenTrabajo.TmEspecial);     
        }

        private void TerminaciónEspecial(string terminacion)
        {
            if(terminacion.Trim()==string.Empty)return;
            char[] separador = { ')' };
            string[] lista = terminacion.Split(separador, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in lista)
            {
                var numero = FuncionGlobal.ConvierteTextoANumero(s);
                switch (numero)
                {
                    case 0:
                        ck0.Checked = true;
                        break;
                    case 1:
                        ck1.Checked=true;
                        break;
                    case 2:
                        ck2.Checked = true;
                        break;
                    case 3:
                        ck3.Checked = true;
                        break;
                    case 4:
                        ck4.Checked = true;
                        break;
                    case 5:
                        ck5.Checked = true;
                        break;
                    case 6:
                        ck6.Checked = true;
                        break;
                    case 7:
                        ck7.Checked = true;
                        break;
                    case 8:
                        ck8.Checked = true;
                        break;
                    case 9:
                        ck9.Checked = true;
                        break;
                }
            }

        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var check = (CheckBox)e.Row.FindControl("chk");
                var existe = Convert.ToBoolean(gr_dato.DataKeys[e.Row.RowIndex]["chk"]);
                var idProducto = Convert.ToString(gr_dato.DataKeys[e.Row.RowIndex]["codigo"]);
               if(existe)
               {
                   check.Checked = true;
                   GetDocumentos(idProducto);
               }     

            }    
        }

        protected void grDoc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var check = (CheckBox)e.Row.FindControl("chk");
                var existe = Convert.ToBoolean(grDoc.DataKeys[e.Row.RowIndex]["chk"]);
                if (existe)
                {
                    check.Checked = true; 
                }


            }
        }

        protected void ibTerminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Add();
               FuncionGlobal.alerta_updatepanel("Orden de trabajo Actualizada Correctamente",Page,udp);
               FuncionGlobal.alerta("Orden de trabajo Actualizada Correctamente", Page);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta_updatepanel(ex.Message, Page, udp);
                FuncionGlobal.alerta(ex.Message, Page);
            } 
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
            

            AddOrdenTrabajo();

        }

        public void AddOrdenTrabajo()
        {    

            var id = new OrdenTrabajoBC().AddOrdenTrabajo(new CENTIDAD.OrdenTrabajo
            {
                IdOrden = IdOrdenTrabajo,
                Activo = true,
                CuentaUsuario = Session["usrname"].ToString(),
                QuienPaga = dlQuienPaga.SelectedValue,
                TmEspecial = GetTerminacionEspecial(),
                IdCliente = Convert.ToInt32(dlCliente.SelectedValue),
                IdSucursal = Convert.ToInt32(dlSucursal.SelectedValue),
                CodigoFormaPago = dlFormaPago.SelectedValue,
                CodigoFinanciera = dlFinanciera.SelectedValue,
                ImpuestoVerde = dlImpuestoVerde.SelectedValue,
                CompraPara = txtCompraPara.Value,
                Observacion = txtObservación.Value, 
                VehiculoCit = txtCit.Value.Trim() == "Cit" || txtCit.Value.Trim() == "" ? "" : txtCit.Value.Trim(),
                AbonoCliente = txtAbono.Value.Trim() == "Abono cliente" || txtAbono.Value.Trim() == "" ? 0 : Convert.ToInt32(txtAbono.Value.Trim())
                ,VinCorto = string.Empty
            });

            new OrdenTrabajoBC().DelServicio(id); //Elimina todos los servicios y documentos
            AddServicios(id);
            AddDocumentos(id);

            
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
        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(udp, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        public NuevaOrden.RespuestaVal ValidaProductosCheckeados()
        {
            var conteo = 0;
            var resp = new NuevaOrden.RespuestaVal();
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
                dt.Columns.Add(new DataColumn("chk"));
            }

            var lDocumentos = new OrdenTrabajoProductoDocumentoBC().GetAllDocumentoByProducto(producto); 

            foreach (var ot in lDocumentos)
            {
                if (dt.AsEnumerable().Any(row => ot.Documento.Id_documento.ToString() == row.Field<String>("idDocumento"))) continue;
                var dr = dt.NewRow();
                dr["codProducto"] = producto;
                dr["idDocumento"] = ot.Documento.Id_documento;
                dr["ducumento"] = ot.Documento.Nombre;
                dr["chk"] = new OrdenTrabajoProductoDocumentoBC().ExisteDocumento(IdOrdenTrabajo,  ot.Documento.Id_documento);
                dt.Rows.Add(dr);
            }
            ViewState["documentos"] = dt;
            grDoc.DataSource = dt;
            grDoc.DataBind();

        }

        public void DelFila(string tipoOperacion)
        {
            var dt = (DataTable)ViewState["documentos"];
            for (int i = grDoc.Rows.Count - 1; i > -1; i--)
            {
                var dataKey = grDoc.DataKeys[i];
                if (dataKey == null) continue;
                var codigoProd = dataKey["codProducto"].ToString();
                if (codigoProd.Trim() == tipoOperacion.Trim())
                {
                    dt.Rows[i].Delete();

                }
            }

            ViewState["documentos"] = dt;
            grDoc.DataSource = dt;
            grDoc.DataBind();
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

        public void GetProductos()
        {
            var list = from x in new OrdenTrabajoProductoDocumentoBC().GetAllProductos() orderby x.TipoOperacion.Operacion ascending select x;

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("producto"));
            dt.Columns.Add(new DataColumn("chk"));

            foreach (var ot in list)
            {
                var dr = dt.NewRow();
                dr["codigo"] = ot.TipoOperacion.Codigo;
                dr["producto"] = ot.TipoOperacion.Operacion;
                dr["chk"] = new OrdenTrabajoProductoDocumentoBC().ExisteProducto(IdOrdenTrabajo, ot.TipoOperacion.Codigo);

                dt.Rows.Add(dr);
            }

            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        protected void dlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.CombosucursalbyclienteCombobox(dlSucursal, Convert.ToInt16(dlCliente.SelectedValue));
            FuncionGlobal.combobanco(dlFinanciera, Convert.ToInt16(dlCliente.SelectedValue));
            dlFinanciera.Items[0].Text = "Financiera";
            dlSucursal.Items[dlSucursal.Items.Count - 1].Text = "Sucursal";  
            
        }

       

        protected void dlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccion = dlFormaPago.SelectedValue;
            //si seleccion es credito (2) se muestra la financiera
            dlFinanciera.Visible = seleccion == "2";
        }
    }
}