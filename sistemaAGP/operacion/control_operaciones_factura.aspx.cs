using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Xml;


namespace sistemaAGP
{
    public partial class control_operaciones_factura : System.Web.UI.Page
    {
      
		private Int32 cantidad = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
      
            //DatosTercero.InfoPersona.Rut = '.';
			int mfolio = new FoliadorBC().getfolio();
            txt_fac_facturacion.Text = mfolio.ToString();
            DatosTercero.OnClickDireccion += new wucBotonEventHandler(DatosTercero_OnClickDireccion);
            DatosTercero.OnClickTelefono += new wucBotonEventHandler(DatosTercero_OnClickTelefono);
            DatosTercero.OnClickCorreo += new wucBotonEventHandler(DatosTercero_OnClickCorreo);

            if (!IsPostBack)
            { 

                FuncionGlobal.combofamilia_producto(dl_familia);
                crear_datatable();
                FuncionGlobal.combocliente(ddlCliente);
                if ((string)(Session["usrname"]).ToString().Trim() == "153636613" 
                    || (string)(Session["usrname"]).ToString().Trim() == "152814631"
                    || (string)(Session["usrname"]).ToString().Trim() == "157481150"
					 || (string)(Session["usrname"]).ToString().Trim() == "130851339"
                     || (string)(Session["usrname"]).ToString().Trim() == "153603456"
                     || (string)(Session["usrname"]).ToString().Trim() == "153944601"
                    || (string)(Session["usrname"]).ToString().Trim() == "124662869"
                    || (string)(Session["usrname"]).ToString().Trim() == "163806533")
                {
                    Label1.Visible = true;
                    Imagebutton1.Visible = true;
                    id_folio.Visible = true;
                    lbl_eliminar_agp.Visible = true;
                    ib_nomina_eliminar.Visible=true;
                    DropDownList1.Visible = true;
                    
                }

                rdb_nomina.Checked = true;
              
            }

          
        }

        protected void crear_datatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud")); 
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("numero_factura"));
            dt.Columns.Add(new DataColumn("total_gasto"));
            dt.Columns.Add(new DataColumn("cantidad_operaciones"));
            dt.Columns.Add(new DataColumn("folio"));
            dt.Columns.Add(new DataColumn("cliente"));


            if (Session["dt"] == null)
                Session.Add("dt", dt);
            else
                Session["dt"] = dt;
        }
        protected void DatosTercero_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel3");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void DatosTercero_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel3");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void DatosTercero_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel3");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }
        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            busca_operacion();
        }

        //busca_operacion_facturacion
        private void busca_operacion()
        {
            if (dl_familia.SelectedValue == "0")
            {
                return;
            }
          

            Int32 factura_agp = 0;
            Int32 total = 0;
            Int32 id_nomina = 0;
            Int32 folio = 0;
            Int32 id_familia = 0;
			 Int32 cantidad = 0;

            if (txt_factura_agp.Text.Trim() != "") factura_agp = Convert.ToInt32(txt_factura_agp.Text);
            if (dpl_nomina.SelectedValue != "") id_nomina = Convert.ToInt32(dpl_nomina.SelectedValue);
            if (txt_nomina.Text != "") folio = Convert.ToInt32(txt_nomina.Text);
            if (dl_familia.SelectedValue != "0") id_familia = Convert.ToInt32(dl_familia.SelectedValue);


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud")); 
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("total_gasto"));
            dt.Columns.Add(new DataColumn("numero_factura"));
            dt.Columns.Add(new DataColumn("cantidad_operaciones"));
            dt.Columns.Add(new DataColumn("folio"));
            dt.Columns.Add(new DataColumn("cliente"));
            List<Factura> lfactura;
            if (txt_operacion.Text != "")
            {
                lfactura = new FacturaBC().getfacturasbyoperacion(Convert.ToInt32(txt_operacion.Text),Convert.ToInt32(dl_familia.SelectedValue));
                foreach (Factura mfactura in lfactura)
                {

                    DataRow dr = dt.NewRow();
                    dr["id_solicitud"] = txt_operacion.Text;
                    dr["tipo_operacion"] = mfactura.Tipo_operacion;
                    dr["numero_factura"] = mfactura.N_factura_agp;
                    dr["total_gasto"] = mfactura.Total_gasto;
                    dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                    dr["cliente"] = mfactura.Cliente.Persona.Nombre;
                    cantidad = mfactura.Cantidad_operaciones;
                    dt.Rows.Add(dr);
                    total = total + mfactura.Total_gasto;
                }

                ViewState["dt_excel"] = dt ;

                txt_neto.Text = total.ToString();
                gr_dato.DataSource = dt;
                gr_dato.DataBind();
            }
            else
            {

                if (txt_operacion.Text == "" && txt_nomina.Text == "")
                {
                    lfactura = new FacturaBC().getfacturas(id_nomina, folio, Convert.ToInt32(ddlCliente.SelectedValue), factura_agp,Convert.ToInt32(dl_familia.SelectedValue));
                    foreach (Factura mfactura in lfactura)
                    {

                        DataRow dr = dt.NewRow();
                        dr["id_solicitud"] = 0;
                        dr["tipo_operacion"] = mfactura.Tipo_operacion;
                        dr["numero_factura"] = mfactura.N_factura_agp;
                        dr["total_gasto"] = mfactura.Total_gasto;
                        dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                        dr["folio"] = mfactura.Folio;
                        dr["cliente"] = mfactura.Cliente.Persona.Nombre;
                        cantidad = mfactura.Cantidad_operaciones;
                        dt.Rows.Add(dr);
                        total = total + mfactura.Total_gasto;
                    }

                    txt_neto.Text = total.ToString();
                    gr_dato.DataSource = dt;
                    gr_dato.DataBind();
                }
                else
                {
                    if (ddlCliente.SelectedValue == "0")
                    {
                        return;
                    }

                    if (rdb_nomina.Checked == true)
                    {
                        lfactura = new FacturaBC().getfacturas(id_nomina, folio, Convert.ToInt32(ddlCliente.SelectedValue), factura_agp,Convert.ToInt32(dl_familia.SelectedValue));
                        foreach (Factura mfactura in lfactura)
                        {

                            DataRow dr = dt.NewRow();
                            dr["id_solicitud"] = 0;
                            dr["tipo_operacion"] = mfactura.Tipo_operacion;
                            dr["numero_factura"] = mfactura.N_factura_agp;
                            dr["total_gasto"] = mfactura.Total_gasto;
                            dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                            cantidad = mfactura.Cantidad_operaciones;
                            dt.Rows.Add(dr);
                            total = total + mfactura.Total_gasto;
                        }

                        txt_neto.Text = total.ToString();
                        gr_dato.DataSource = dt;
                        gr_dato.DataBind();
                    }
                    else
                    {
                        List<Operacion> op = new OperacionBC().getOperacionesbynomina(id_nomina,folio,(string)(Session["usrname"]));
                        foreach (Operacion ope in op)
                        {
                            lfactura = new FacturaBC().getfacturasbyoperacion(ope.Id_solicitud, Convert.ToInt32(dl_familia.SelectedValue));
                            foreach (Factura mfactura in lfactura)
                            {

                                DataRow dr = dt.NewRow();

                                dr["id_solicitud"] = ope.Id_solicitud;
                                dr["tipo_operacion"] = mfactura.Tipo_operacion;
                                dr["numero_factura"] = mfactura.N_factura_agp;
                                dr["total_gasto"] = mfactura.Total_gasto;
                                dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                                cantidad = mfactura.Cantidad_operaciones;
                                dt.Rows.Add(dr);
                                total = total + mfactura.Total_gasto;
                            }

                       
                        }

                        txt_neto.Text = total.ToString();
                        ViewState["dt_excel"] = dt;
                        gr_dato.DataSource = dt;
                        gr_dato.DataBind();

                    }
                }


            }
         

     
      
        }

     

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }




        protected void dl_nomina_SelectedIndexChanged(object sender, EventArgs e) { }


        public Int32 traerfolio(Int32 id_nomina)
        {
            TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(id_nomina);
            Int32 folio = Convert.ToInt32(lTiponomina.Folio);
            return folio;
        }



        protected void txt_operacion_TextChanged(object sender, EventArgs e)
        {
            busca_operacion();
        }

        protected void btn_nomina_pdf_Click(object sender, ImageClickEventArgs e)
        {
            ver_reporte_nomina();
        }
        protected void ver_reporte_nomina()
        {
            Int32 id_nomina;
            Int32 folio;



            if (dl_familia.SelectedValue == "0")
            {

                return;

            }


            id_nomina = Convert.ToInt32(dpl_nomina.SelectedValue);
            if (!Int32.TryParse(txt_nomina.Text, out folio)) { folio = 0; }

            if (id_nomina != 0 && folio != 0)
            {

                string cadena = "/reportes/view_nomina.aspx";
                cadena += "?id_familia=" + dl_familia.SelectedValue.ToString();
                cadena += "&folio=" + folio.ToString();
                cadena += "&id_nomina=" + id_nomina.ToString();
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ViewNomina", "<script type=\"text/javascript\">window.open('" + cadena + "'); </script>", false);
            }
        }


        protected void btn_factura_rpt_Click(object sender, ImageClickEventArgs e)
        {
            UpdatePanel up = (UpdatePanel)Master.FindControl("UpdatePanel1");
            if (txt_factura_agp.Text.Trim() != "")
            {
                carga_factura();
                txt_factura_agp.Text = "";
            }
            else

                FuncionGlobal.alerta_updatepanel("Falta Nº Factura AGP!!!!", Page, up);
        }

        public void carga_factura()
        {
            //string cadena = "/reportes/view_nomina.aspx";
            //cadena += "?id_familia=" + this.dl_familia.SelectedValue.ToString();
            //cadena += "&folio=" + folio.ToString();
            //cadena += "&id_nomina=" + id_nomina.ToString();
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ViewNomina", "<script type=\"text/javascript\">window.open('" + cadena + "'); </script>", false);
            string nombre = "";
            if (dl_familia.SelectedValue == "7")
            {
                nombre = "Facturacion_peru.rpt";
            }
            //this.btn_factura_rpt.Attributes.Add("onclick", "javascript:window.open('../reportes/view_factura.aspx?num_factura=" + FuncionGlobal.FuctionEncriptar(this.txt_factura_agp.Text.Trim()) + "&nombre=" + nombre + "','_blank','height=355,width=500,
            //top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");
            string cadena = string.Format("../reportes/view_factura.aspx?num_factura={0}&nombre={1}", FuncionGlobal.FuctionEncriptar(txt_factura_agp.Text.Trim()), nombre);
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ViewFactura", "window.open('" + cadena + "');", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool respuesta=false;
            if (txt_operacion.Text != "")
            {
                EstadoOperacion mesta = new EstadooperacionBC().getEstadobyorden(Convert.ToInt32(txt_operacion.Text), 88);
                respuesta = mesta.Permite_estado;
            }
            else
            {
                EstadoOperacion mesta = new EstadooperacionBC().getEstadobyordenNomina(Convert.ToInt32(txt_nomina.Text), 88,Convert.ToInt32(dpl_nomina.SelectedValue));
                respuesta = mesta.Permite_estado;
            }

            if (respuesta == false)
            {
                //FuncionGlobal.alerta_updatepanel("No cumple con los requisitos de estado", this.Page, this.UpdatePanel2);
                lbl_cantidad.Text = "No cumple con los requisitos de estado";
                return;
            }

            if (txt_neto.Text == "0")
            {
                //FuncionGlobal.alerta_updatepanel("El Valor Total Neto es 0", this.Page, this.UpdatePanel2);
                lbl_cantidad.Text = "El Valor Total Neto es 0";
                return;
            }
            if (ddlCliente.SelectedValue == "0")
            {
                //FuncionGlobal.alerta_updatepanel("Debe Seleccionar un Cliente", this.Page, this.UpdatePanel2);
                lbl_cantidad.Text = "Debe Seleccionar un Cliente";
                return;
            }
			//if (this.DropDownList1.SelectedValue != "Electronica")
			//{
			//    if (this.txt_fac_facturacion.Text == "")
			//    {
			//        FuncionGlobal.alerta_updatepanel("Debe Colocar un Nº de Factura", this.Page, this.UpdatePanel2);
			//        return;
			//    }
			//}
            if (txt_fecha_factura.Text == "")
            {
                //FuncionGlobal.alerta_updatepanel("Debe Colocar una fecha de factura", this.Page, this.UpdatePanel2);
                lbl_cantidad.Text = "Debe Colocar una fecha de factura";
                return;
            }
            int rut_tercero = 0;

            if (DatosTercero.Guardar_Form())
            {
                if (DatosTercero.InfoPersona != null)
                {
                    rut_tercero =Convert.ToInt32(DatosTercero.InfoPersona.Rut.ToString());
                }
            }

            //if (DatosTercero.InfoPersona != null)
            //{
            //    Double rut = DatosTercero.getRut();
            //    rut_tercero = Convert.ToInt32(rut);
            //    List<Direcciones> ldireccion = new DireccionesBC().getdirecciones(rut_tercero);


            //}

            if (txt_operacion.Text != "")
            {
            
               if( crear_xml(Convert.ToInt32(txt_operacion.Text), 0) == false)
                {
                    FuncionGlobal.alerta_direccion("Problema con XML, no se puede crear Factura", Page);
                }

            }
            else
            {
                if (crear_xml(0, 0) == false)
                {
                    FuncionGlobal.alerta_direccion("Problema con XML, no se puede crear Factura", Page);
                }
            }

            

            string add_facturacion = new FacturaBC().add_tabla_factura(Convert.ToInt32(txt_fac_facturacion.Text), txt_fecha_factura.Text,
                                                                       Convert.ToInt32(txt_neto.Text), txt_orden_compra.Text, Convert.ToInt32(ddlCliente.SelectedValue),
                                                                       txt_observacion.Text,(string)(Session["usrname"]),rut_tercero);

            if (txt_operacion.Text != "")
            {
                string add = new FacturaBC().add_factura_oper(Convert.ToInt32(txt_operacion.Text),
                    Convert.ToInt32(txt_fac_facturacion.Text), txt_fecha_factura.Text, (string)(Session["usrname"]));
            }
            else
            {
                string add = new FacturaBC().add_factura(Convert.ToInt32(dpl_nomina.SelectedValue), Convert.ToInt32(txt_nomina.Text),
                    Convert.ToInt32(txt_fac_facturacion.Text), txt_fecha_factura.Text, (string)(Session["usrname"]));
            }



            //FuncionGlobal.alerta_updatepanel("Factura creada con exito", this.Page, this.UpdatePanel2);
            lbl_cantidad.Text = "Factura creada con exito";
            Panel1.Visible = false;
            txt_factura_agp.Text = txt_fac_facturacion.Text.Trim();
            busca_operacion();
            txt_fac_facturacion.Text = "";
            txt_fecha_factura.Text = "";



        }


        protected Boolean crear_xml(int id_solicitud, int total)
        {
			
            MemoryStream m = new MemoryStream();
			MemoryStream m1 = new MemoryStream();
            string nomina = "0";

            Cliente mcliente = new ClienteBC().getclientefac(Convert.ToInt16(ddlCliente.SelectedValue));
			
			
			
			int mfolio = new FoliadorBC().getfolio();

            if (txt_nomina.Text != "" && rdb_nomina.Checked==true)
            {
                nomina = txt_nomina.Text;
            }

            string doctype = ConfigurationManager.AppSettings["DocType"].ToString();

			if (DropDownList1.SelectedValue == "Electronica")
			{
                txt_fac_facturacion.Text = mcliente.Facturanav.ToString();
                txt_fac_facturacion.Text = txt_fac_facturacion.Text.Substring(5, 5);

			}

            XmlTextWriter xml = new XmlTextWriter(m, System.Text.Encoding.UTF8);
			XmlTextWriter xml1 = new XmlTextWriter(m1, System.Text.Encoding.UTF8);
            xml.Formatting = Formatting.Indented;
            xml.Namespaces = true;
            xml.WriteStartDocument(false);



            xml.WriteStartElement("Root");
            xml.WriteStartElement("Order");
            xml.WriteElementString("DocumentType", "Invoice");
			
			if (DropDownList1.SelectedValue == "Electronica")
			{
				xml.WriteElementString("No", "FVEX00" + mfolio.ToString());
				//---------------------encabezado factura electronica------//
				//XmlTextWriter xml1 = new XmlTextWriter(m1, System.Text.Encoding.UTF8);
				xml1.Formatting = Formatting.Indented;
				xml1.Namespaces = true;
				xml1.WriteStartDocument(false);
				xml1.WriteStartElement("Documento");

			   	xml1.WriteStartElement("Encabezado");
					xml1.WriteStartElement("IdDoc");
					xml1.WriteElementString("TipoDTE", "34");



                    xml1.WriteElementString("Folio", mfolio.ToString());
                    
                    if (rdb_operacion.Checked == true)
                    {
                        xml1.WriteElementString("FchEmis", string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(txt_fecha_fac_oper.Text.Trim())));
                    }
                    else
                    {
                        xml1.WriteElementString("FchEmis", string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(txt_fecha_factura.Text.Trim())));
                    }	
				xml1.WriteEndElement();


			//aqui va lo de AGPdr["numero"].ToString()

				xml1.WriteStartElement("Emisor");
					xml1.WriteElementString("RUTEmisor", "76095476-4");
					xml1.WriteElementString("RznSoc", "ASESORIAS Y GESTION DE PROCESOS S.A.");
				    xml1.WriteElementString("GiroEmis", "OTRAS ACTIVIDADES EMPRESARIALES N.C.P.");
					xml1.WriteElementString("Acteco", "749990");
					xml1.WriteElementString("DirOrigen", "MIGUEL CLARO #070 L.44 BLOCK T");
					xml1.WriteElementString("CmnaOrigen", "PROVIDENCIA");		
					xml1.WriteElementString("CiudadOrigen", "SANTIAGO");
				xml1.WriteEndElement();

				//-----------Receptor de Factura------
                if (DatosTercero.InfoPersona != null)
                //	if (this.ddlCliente.SelectedValue == "0")
                {
                    Persona mpersona = new PersonaBC().getpersonabyrutVTA(DatosTercero.InfoPersona.Rut);
                    xml1.WriteStartElement("Receptor");
                    xml1.WriteElementString("RUTRecep", (mpersona.Rut + "-" + mpersona.Dv).ToString());
                    xml1.WriteElementString("RznSocRecep", (mpersona.Nombre + " " + mpersona.Apellido_paterno + " " + mpersona.Apellido_materno).ToString());
                    xml1.WriteElementString("GiroRecep", txt_orden_compra.Text.ToString());
                    xml1.WriteElementString("DirRecep", mpersona.Direccion + " " + mpersona.Numero + " " + mpersona.Depto);
                    xml1.WriteElementString("CmnaRecep", mpersona.Comuna.Nombre.ToString());
                    xml1.WriteElementString("CiudadRecep", mpersona.Comuna.Ciudad.Nombre.ToString());
                    xml1.WriteEndElement();
                }


                else
		
		    {
                if (rdb_operacion.Checked == true)
                {
                    Operacion mo = new OperacionBC().getoperacion(id_solicitud);


                        if (mo.Adquiriente.Direccion == "")
                        {
                            return false;
                        }

                        xml1.WriteStartElement("Receptor");
                    xml1.WriteElementString("RUTRecep", (mo.Adquiriente.Rut + "-" + mo.Adquiriente.Dv).ToString());
                   
                    xml1.WriteElementString("RznSocRecep", (mo.Adquiriente.Nombre + " " + mo.Adquiriente.Apellido_paterno + " " + mo.Adquiriente.Apellido_materno).ToString());
                    if (DatosTercero.InfoPersona != null)
                    {
                        xml1.WriteElementString("GiroRecep", txt_orden_compra.Text.ToString());
                    }
                    if (DatosTercero.InfoPersona == null)
                    {
                        xml1.WriteElementString("GiroRecep", "Persona Natural");
                    }
                    xml1.WriteElementString("DirRecep", mo.Adquiriente.Direccion + " " + mo.Adquiriente.Numero + " " );
                    xml1.WriteElementString("CmnaRecep", mo.Adquiriente.Comuna.Nombre.ToString());
                    xml1.WriteElementString("CiudadRecep", mo.Adquiriente.Comuna.Ciudad.Nombre.ToString());

                    xml1.WriteEndElement();
                }
                else
                {

                    //  Persona mpersona = new PersonaBC().getpersonabyrut(mcliente.Persona.Rut);
                    xml1.WriteStartElement("Receptor");
                    xml1.WriteElementString("RUTRecep", (mcliente.Persona.Rut + "-" + mcliente.Persona.Dv).ToString());
                    //xml1.WriteElementString("RznSocRecep", (mcliente.Persona.Nombre + mcliente.Persona.Apellido_paterno + mcliente.Persona.Apellido_materno).ToString());
                    //    xml1.WriteElementString("GiroRecep", mcliente.Persona.Giro);
                    //    xml1.WriteElementString("DirRecep", mcliente.Direccion.ToString() + " " + mcliente.Numero.ToString() + " " + mcliente.Complemento.ToString() );
                    //    xml1.WriteElementString("CmnaRecep", mcliente.Persona.Comuna.Nombre.ToString());
                    //    xml1.WriteElementString("CiudadRecep", mcliente.Persona.Comuna.Ciudad.Nombre.ToString());
                    xml1.WriteElementString("RznSocRecep", (mcliente.Persona.Nombre + " " + mcliente.Persona.Apellido_paterno + " " + mcliente.Persona.Apellido_materno).ToString());
                    if (DatosTercero.InfoPersona != null)
                    {
                        xml1.WriteElementString("GiroRecep", txt_orden_compra.Text.ToString());
                    }
                    if (DatosTercero.InfoPersona == null)
                    {
                        xml1.WriteElementString("GiroRecep", mcliente.Persona.Giro.ToString());
                    }
                    xml1.WriteElementString("DirRecep", mcliente.Direccion + " " + mcliente.Numero + " " + mcliente.Complemento);
                    xml1.WriteElementString("CmnaRecep", mcliente.Persona.Comuna.Nombre.ToString());
                    xml1.WriteElementString("CiudadRecep", mcliente.Persona.Comuna.Ciudad.Nombre.ToString());

                    xml1.WriteEndElement();
                }
			}
				//--------------------------
		
             //-----------totales----------------
					xml1.WriteStartElement("Totales");
                    if (total != 0)
                    {
                        xml1.WriteElementString("MntExe", total.ToString());

                        xml1.WriteElementString("MntTotal", total.ToString());
                    }
                    else
                    {
                        xml1.WriteElementString("MntExe", txt_neto.Text.ToString());

                        xml1.WriteElementString("MntTotal", txt_neto.Text.ToString());
                    }
					xml1.WriteEndElement();
			xml1.WriteEndElement();


			//---------------------------------------------------------//
			}
			else 
			{
                xml.WriteElementString("No", "FVEX00" + mfolio.ToString());
			}
            if (rdb_operacion.Checked == true)
            {
                xml.WriteElementString("PostingDate", txt_fecha_fac_oper.Text);
            }
            else
            {
                xml.WriteElementString("PostingDate", DateTime.Now.ToString("dd/MM/yyyy"));
            }
            xml.WriteElementString("SellCustomer", mcliente.Codigo_nav.Trim());
            xml.WriteElementString("DocType", doctype);
            xml.WriteElementString("Nomina", nomina);
            xml.WriteElementString("Detalle", dl_familia.SelectedItem.Text);
			if (DropDownList1.SelectedValue == "Electronica")
			{
                xml.WriteElementString("PostingNo", "FVEX00" + mfolio.ToString());
			}
			else
			{
				xml.WriteElementString("PostingNo", txt_fac_facturacion.ToString());
			}


			xml.WriteEndElement();

            int nline = 10000;
			int linef =1;

            if (id_solicitud != 0)
            {




                Operacion moper = new OperacionBC().getoperacionfacxml(Convert.ToInt32(id_solicitud));
                Operacion mopsec = new OperacionBC().getoperacion(moper.Id_solicitud);
                SucursalCliente msuc = new SucursalclienteBC().getsucursalnav(mopsec.Sucursal.Id_sucursal);

                xml.WriteStartElement("Lineas");
                xml.WriteElementString("TipoDoc", "Invoice");

				if (DropDownList1.SelectedValue == "Electronica")
				{
                    txt_fac_facturacion.Text = mfolio.ToString();
					
						xml1.WriteStartElement("Detalle");
								xml1.WriteElementString("NroLinDet", linef.ToString());
							xml1.WriteStartElement("CdgItem");
							xml1.WriteElementString("TpoCodigo", "interno");
								xml1.WriteElementString("VlrCodigo", moper.Cuenta_monto_factura.ToString());
							xml1.WriteEndElement();
								xml1.WriteElementString("NmbItem", moper.Observacion.ToString());
				//	xml1.WriteElementString("DscItem",this.txt_observacion.Text);
								xml1.WriteElementString("PrcRef", moper.Total_facturar.ToString().ToString());
								xml1.WriteElementString("QtyItem",  "1");
								xml1.WriteElementString("PrcItem", moper.Total_facturar.ToString());
								xml1.WriteElementString("MontoItem", moper.Total_facturar.ToString());
						xml1.WriteEndElement();


				}

				if (DropDownList1.SelectedValue == "Electronica")
				{

                    xml.WriteElementString("DocumentNo", "FVEX00" + mfolio.ToString());

				}
				else
				{

					xml.WriteElementString("DocumentNo", txt_fac_facturacion.Text);

				}

                xml.WriteElementString("NLinea", nline.ToString());
                xml.WriteElementString("Type", "G/L Account");
                xml.WriteElementString("Num", moper.Cuenta_monto_factura.ToString().Trim());
                xml.WriteElementString("LocationCode", "GENERICO");
                xml.WriteElementString("Quantity", "1");
                xml.WriteElementString("UnitOfMeasure", "UN");
                xml.WriteElementString("Amount", moper.Total_facturar.ToString());//valor_tramite
                xml.WriteElementString("AreaCodigo", new Familia_productoBC().getFamiliabyidFamilia(Convert.ToInt32(dl_familia.SelectedValue)).Codigo_nav.Trim());
                xml.WriteElementString("RutCodigo", mcliente.Persona.Rut.ToString());
                xml.WriteElementString("RegionCodigo", msuc.Codnav.Trim());
                xml.WriteElementString("OperacionCodigo", moper.Id_solicitud.ToString());//id_solicitud
                xml.WriteEndElement();

            }
            else
            {
                if (rdb_nomina.Checked == true && txt_operacion.Text == "" )
                {

                    List<Operacion> lnom = new OperacionBC().getOperacionesbynominaExpress(Convert.ToInt32(dpl_nomina.SelectedValue), Convert.ToInt32(txt_nomina.Text), (string)Session["usrname"]);
                    List<Operacion> lnomac = new OperacionBC().getOperacionesbynominaExpressacum(Convert.ToInt32(dpl_nomina.SelectedValue), Convert.ToInt32(txt_nomina.Text), (string)Session["usrname"]);
                    Usuario muser = new UsuarioBC().GetUsuario((string)(Session["usrname"]));

                    foreach (Operacion moper in lnom)
                    {

                        Operacion mopsec = new OperacionBC().getoperacion(moper.Id_solicitud);
                        SucursalCliente msuc = new SucursalclienteBC().getsucursalnav(mopsec.Sucursal.Id_sucursal);

                        xml.WriteStartElement("Lineas");
                        xml.WriteElementString("TipoDoc", "Invoice");
                        if (DropDownList1.SelectedValue == "Electronica")
                        {

                            xml.WriteElementString("DocumentNo", "FVEX00" + mfolio.ToString());
                            txt_fac_facturacion.Text = mfolio.ToString();

                        }
                        else
                        {

                            xml.WriteElementString("DocumentNo", txt_fac_facturacion.Text);

                        }
                        xml.WriteElementString("NLinea", nline.ToString());
                        xml.WriteElementString("Type", "G/L Account");
                        xml.WriteElementString("Num", moper.Cuenta_monto_factura.ToString().Trim());
                        xml.WriteElementString("LocationCode", "GENERICO");
                        xml.WriteElementString("Quantity", "1");
                        xml.WriteElementString("UnitOfMeasure", "UN");
                        xml.WriteElementString("Amount", moper.Total_facturar.ToString());//valor_tramite
                        xml.WriteElementString("AreaCodigo", new Familia_productoBC().getFamiliabyidFamilia(Convert.ToInt32(dl_familia.SelectedValue)).Codigo_nav.Trim());
                        xml.WriteElementString("RutCodigo", mcliente.Persona.Rut.ToString());
                        xml.WriteElementString("RegionCodigo", msuc.Codnav.Trim());
                        xml.WriteElementString("OperacionCodigo", moper.Id_solicitud.ToString());//id_solicitud
                        xml.WriteEndElement();
                        nline = nline + 10000;

                    }

                    string operacio;
                    operacio = "";



                    foreach (Operacion moperac in lnomac)
                    {

                        if (DropDownList1.SelectedValue == "Electronica")
                        {


                            List<Factura> lfactura;
                            if (txt_operacion.Text != "")
                            {
                                lfactura = new FacturaBC().getfacturasbyoperacion(Convert.ToInt32(txt_operacion.Text), Convert.ToInt32(dl_familia.SelectedValue));
                            }
                            else
                            {
                                lfactura = new FacturaBC().getfacturas(Convert.ToInt32(dpl_nomina.SelectedValue), Convert.ToInt32(txt_nomina.Text), Convert.ToInt32(ddlCliente.SelectedValue), 0, Convert.ToInt32(dl_familia.SelectedValue));
                            }
                            foreach (Factura mfactura in lfactura)
                            {



                                //dr["tipo_operacion"] = mfactura.Tipo_operacion;
                                //dr["numero_factura"] = mfactura.N_factura_agp;
                                //dr["total_gasto"] = mfactura.Total_gasto;
                                //dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                                cantidad = mfactura.Cantidad_operaciones;

                            }



                            //xml.WriteElementString("DocumentNo", this.txt_fac_facturacion.Text);
                            xml1.WriteStartElement("Detalle");
                            xml1.WriteElementString("NroLinDet", linef.ToString());
                            xml1.WriteStartElement("CdgItem");
                            xml1.WriteElementString("TpoCodigo", "interno");
                            xml1.WriteElementString("VlrCodigo", moperac.Contador.ToString());
                            xml1.WriteEndElement();
                            //	xml1.WriteElementString("NmbItem", "");
                            xml1.WriteElementString("NmbItem", moperac.Observacion.ToString());
                            //xml1.WriteElementString("DscItem", this.txt_observacion.Text);
                            xml1.WriteElementString("PrcRef", moperac.Monto.ToString().ToString());
                            xml1.WriteElementString("QtyItem", moperac.Contador.ToString());
                            xml1.WriteElementString("PrcItem", moperac.Monto.ToString());
                            xml1.WriteElementString("MontoItem", moperac.Total_facturar.ToString());
                            xml1.WriteEndElement();
                            linef = linef + 1;


                        }


                    }
                }
                //******
            }


            xml1.WriteStartElement("Adjuntos");

            if (id_solicitud != 0)
            {
                Operacion operac = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

                if (operac.Tipo_operacion.Id_familia == 22)
                {
                    xml1.WriteElementString("Observacion", "Op. " + operac.Numero_cliente.ToString());
                }
                else
                {
                    xml1.WriteElementString("Observacion", "Op. " + id_solicitud.ToString());
                }
            }
            else
            {
                xml1.WriteElementString("Observacion", txt_observacion.Text.ToString());
            }
            //xml1.WriteElementString("MailReceptor", "ALEJANDRO.ZARATE@AGYS.CL");
            //xml1.WriteElementString("MailEmisor", "noreply@agpsa.cl");
            //xml1.WriteElementString("Subject_Mail", "Factura Electronica");

            xml1.WriteElementString("Impresora", "FACTURACION");
            xml1.WriteElementString("Copias", "1");

            xml1.WriteEndElement();




            //---------fac elec------
            //xml1.WriteEndElement();
            xml1.WriteEndDocument();
            xml1.Flush();


            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();

			
			////-------------------------
            m.Position = 0;
            string r = new StreamReader(m).ReadToEnd();
			m1.Position = 0;
			string r1 = new StreamReader(m1).ReadToEnd();


            xml.Close();
			//xml1.Close();
            m.Close();
			m1.Close();

            string strPath = System.Configuration.ConfigurationManager.AppSettings["PEDIDOS_VENTA"];


           // string path2 = "c:/navision/" + DateTime.Now.ToString("dd-MM-yy") + "-" + this.txt_fac_facturacion.Text + "-" + this.dl_familia.SelectedItem.Text + ".xml";
          //  string path = "c:/navision/" + DateTime.Now.ToString("dd-MM-yy") + "-" + this.txt_fac_facturacion.Text + "-" + this.dl_familia.SelectedItem.Text + "1.xml";
            string path2 = "c:/electronica/f" + txt_fac_facturacion.Text + dl_familia.SelectedValue + ".xml";
           string path = strPath + DateTime.Now.ToString("dd-MM-yy") + "-" + txt_fac_facturacion.Text + "-" + dl_familia.SelectedItem.Text + ".xml";
            XmlDataDocument xmDoc = new XmlDataDocument();
			XmlDataDocument xmDoc1 = new XmlDataDocument();
            xmDoc.LoadXml(r);
			xmDoc1.LoadXml(r1);
            xmDoc.Save(path);
			xmDoc1.Save(path2);

            return true;

			//-----------------------------------------------------
			
			//------------------------------------------------------
            
        }




        protected void txt_factura_agp_TextChanged(object sender, EventArgs e)
        {
          
        }
        protected void dpl_nomina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_nomina_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fac_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_orden_compra_TextChanged(object sender, EventArgs e)
        {

        }


        protected void txt_observacion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_valor_neto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_obs_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ib_nomina_Click(object sender, ImageClickEventArgs e)
        {

            int rut_tercero = 0;
            GridViewRow row;

            if (DatosTercero.getRut() != 0)
            {
                rut_tercero =Convert.ToInt32(DatosTercero.getRut());
            }

            bool respuesta = false;


            if (ddlCliente.SelectedValue != "0")
            {

                if (rdb_nomina.Checked == false)
                {
                    int count = 0;

                    for (int i = 0; i < gr_dato.Rows.Count; i++)
                    {
                        row = gr_dato.Rows[i];
                        int mfolio = new FoliadorBC().getfolio();
                        string id_solicitud = (string)row.Cells[0].Text;
                        string total = (string)row.Cells[5].Text;

                        EstadoOperacion mesta = new EstadooperacionBC().getEstadobyorden(Convert.ToInt32(id_solicitud), 88);
                        respuesta = mesta.Permite_estado;

                        Operacion ope = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

                        rut_tercero = Convert.ToInt32(ope.Adquiriente.Rut);

                        if (respuesta == true)
                        {
                            
                         if (crear_xml(Convert.ToInt32(id_solicitud), Convert.ToInt32(total)) == false)
                         {
                              FuncionGlobal.alerta_direccion("Problema con XML, no se puede crear Factura", Page);
                                return;
                         }
                                
                            string add_facturacion = new FacturaBC().add_tabla_factura(Convert.ToInt32(mfolio), DateTime.Now.ToString(),
                                                                                  Convert.ToInt32(total), txt_orden_compra.Text, Convert.ToInt32(ddlCliente.SelectedValue),
                                                                                  txt_observacion.Text, (string)(Session["usrname"]), rut_tercero);

                            string add = new FacturaBC().add_factura_oper(Convert.ToInt32(id_solicitud),
                                Convert.ToInt32(mfolio), DateTime.Now.ToString(), (string)(Session["usrname"]));
                        }
                        else
                        {
                            count = count + 1;
                        }

                    }

                    //FuncionGlobal.alerta_updatepanel("Factura creada con exito, errores = " + count.ToString(), this.Page, this.UpdatePanel2);
                    lbl_cantidad.Text = "Factura creada con exito, errores = " + count.ToString();

                    gr_dato.DataSource = null;
                    gr_dato.DataBind();


                    DataTable dtt = (DataTable)ViewState["dt_excel"];

                    foreach (DataRow drr in dtt.Rows)
                    {
                        Int32 total = 0;
                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn("id_solicitud"));
                        dt.Columns.Add(new DataColumn("tipo_operacion"));
                        dt.Columns.Add(new DataColumn("total_gasto")); ;
                        dt.Columns.Add(new DataColumn("numero_factura"));
                        dt.Columns.Add(new DataColumn("cantidad_operaciones"));
                        dt.Columns.Add(new DataColumn("folio"));
                        dt.Columns.Add(new DataColumn("cliente"));

                        List<Factura> lfactura;


                        lfactura = new FacturaBC().getfacturasbyoperacion(Convert.ToInt32(drr["id_solicitud"]), Convert.ToInt32(dl_familia.SelectedValue));

                        foreach (Factura mfactura in lfactura)
                        {

                            DataRow dr = dt.NewRow();

                            dr["id_solicitud"] = drr["id_solicitud"];
                            dr["tipo_operacion"] = mfactura.Tipo_operacion;
                            dr["numero_factura"] = mfactura.N_factura_agp;
                            dr["total_gasto"] = mfactura.Total_gasto;
                            dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                            dr["folio"] = mfactura.Folio;
                            dr["cliente"] = mfactura.Cliente.Persona.Nombre;
                            cantidad = mfactura.Cantidad_operaciones;
                            dt.Rows.Add(dr);
                            total = mfactura.Total_gasto;
                        }

                        txt_neto.Text = total.ToString();
                        gr_dato.DataSource = dt;
                        gr_dato.DataBind();

                    }
                    txt_fac_facturacion.Text = "";

                }
                else
                {
                    if (Panel1.Visible == true)
                    {
                        Panel1.Visible = false;
                    }
                    else
                    {
                        Panel1.Visible = true;
                    }
                }
            }

            else
            {

                var query = from r in gr_dato.Rows.OfType<GridViewRow>()
						where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
						select r.RowIndex;
			    

                foreach (int i in query)
                {

                    if (rdb_nomina.Checked == false)
                    {


                    }
                    else
                    {
                        if (Panel1.Visible == true)
                        {
                            Panel1.Visible = false;
                        }
                        else
                        {
                            Panel1.Visible = true;
                        }

                    }


                }
            }


        }


        protected void checkall_CheckedChanged(object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }


        protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combonominabyfamiliafactura(dpl_nomina, Convert.ToInt32(dl_familia.SelectedValue));    
        }

        protected void ib_nomina_eliminar_Click(object sender, ImageClickEventArgs e)
        {
            if (txt_operacion.Text != "")
            {
                string add = new FacturaBC().add_factura_oper_del(Convert.ToInt32(txt_operacion.Text));
                lbl_cantidad.Text = "Operacion eliminada de la Factura con exito";
            }
            else
            {
                if (txt_nomina.Text != "" && dpl_nomina.SelectedValue != "0")
                {
                    string add = new FacturaBC().act_factura_del(Convert.ToInt32(txt_nomina.Text),Convert.ToInt32(dpl_nomina.SelectedValue));
                    //FuncionGlobal.alerta_updatepanel("Factura eliminada con exito", this.Page, this.UpdatePanel2);
                    lbl_cantidad.Text = "Factura eliminada con exito";
                }
                else 
                {
                    //FuncionGlobal.alerta_updatepanel("Nº operacion o Nomina no seleccionada", this.Page, this.UpdatePanel2);
                    lbl_cantidad.Text = "Nº operacion o Nomina no seleccionada" ;
                }
            }

           
            busca_operacion();
        }

        protected void ib_Cambia_folio(object sender, ImageClickEventArgs e)
        {

            string add = new FacturaBC().add_cambia_folio(Convert.ToInt32(id_folio.Text));


            //FuncionGlobal.alerta_updatepanel("FOLIO ACTUALIZADO, FOLIO ACTUAL" + id_folio.Text, this.Page, this.UpdatePanel2);
            lbl_cantidad.Text = "FOLIO ACTUALIZADO, FOLIO ACTUAL";


            busca_operacion();
        }

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{



			if (DropDownList1.SelectedValue == "Electronica") {

                txt_fac_facturacion.ReadOnly = true;

			}
			if (DropDownList1.SelectedValue == "Manual")
			{

                txt_fac_facturacion.ReadOnly = false;

			}
		}

        private string carga_archivo()
        {
            string sSave = "";

            if (fileuploadExcel.PostedFile != null && fileuploadExcel.PostedFile.ContentLength > 0)
            {
                FileInfo fi_documento = new FileInfo(fileuploadExcel.FileName);
                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".xls")
                    {

                        if (fileuploadExcel.PostedFile.ContentLength <= 6194304)
                        {
                            string sDoc = "Factura_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                            sSave = "c:\\Archivo_Factura\\" + sDoc;
                            try
                            {
                                fileuploadExcel.PostedFile.SaveAs(sSave);
                                //sSave = "docs/" + sDoc;
                                //sSave = sPath + "/" + sDoc;

                            }
                            catch (Exception ex)
                            {
                                //Response.Write(ex.Message);
                                //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ShowError", string.Format("<script language=javascript>alert('Error al subir el archivo {0}\n\n{1}');</script>", fu_documento.FileName, ex.Message));

                            }
                        }
                    }
                    else
                    {
                        lbl_cantidad.Text = "El formato del Excel solo puede ser .xls";

                    }
                }
            }

            return sSave;

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (dl_familia.SelectedValue == "0")
            {
                lbl_cantidad.Text = "Seleccione la Familia" ;
                return;
            }
            if (ddlCliente.SelectedValue == "0")
            {
                lbl_cantidad.Text = "Seleccione la Cliente";
                return;
            }
            importa_excel(carga_archivo());
              //this.lbl_cantidad.Text = "" ;
        }

        private void importa_excel(string ruta)
        {


            //Connection String to Excel Workbook
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";


            string query = "SELECT [id_solicitud]  FROM [Hoja1$] ";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            lbl_cantidad.Visible = true;
            lbl_cantidad.Text = "Numero de Filas en Archivo : " + ds.Tables[0].Rows.Count.ToString();

            da.Dispose();
            conn.Close();
            conn.Dispose();

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtt = ds.Tables[0];
                
                ViewState["dt_excel"] = dtt;
                Int32 total = 0;
                Int32 factura_agp = 0;
                Int32 id_nomina = 0;
                Int32 folio = 0;
                Int32 id_familia = 0;
                Int32 cantidad = 0;

                if (txt_factura_agp.Text.Trim() != "") factura_agp = Convert.ToInt32(txt_factura_agp.Text);
                if (dpl_nomina.SelectedValue != "") id_nomina = Convert.ToInt32(dpl_nomina.SelectedValue);
                if (txt_nomina.Text != "") folio = Convert.ToInt32(txt_nomina.Text);
                if (dl_familia.SelectedValue != "0") id_familia = Convert.ToInt32(dl_familia.SelectedValue);

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("id_solicitud"));
                dt.Columns.Add(new DataColumn("tipo_operacion"));
                dt.Columns.Add(new DataColumn("total_gasto")); 
                dt.Columns.Add(new DataColumn("numero_factura"));
                dt.Columns.Add(new DataColumn("cantidad_operaciones"));
                dt.Columns.Add(new DataColumn("folio"));
                dt.Columns.Add(new DataColumn("cliente"));

                foreach (DataRow drr in dtt.Rows)
                {

                    List<Factura> lfactura = new List<Factura>();

                    if (drr["id_solicitud"] != null && drr["id_solicitud"].ToString().Trim() != "")
                    {

                        lfactura = new FacturaBC().getfacturasbyoperacion(Convert.ToInt32(drr["id_solicitud"]), Convert.ToInt32(dl_familia.SelectedValue));
                    }

                    foreach (Factura mfactura in lfactura)
                    {

                        DataRow dr = dt.NewRow();
                        dr["id_solicitud"] = drr["id_solicitud"];
                        dr["tipo_operacion"] = mfactura.Tipo_operacion;
                        dr["numero_factura"] = mfactura.N_factura_agp;
                        dr["total_gasto"] = mfactura.Total_gasto;
                        dr["cantidad_operaciones"] = mfactura.Cantidad_operaciones;
                        dr["folio"] = mfactura.Folio;
                        dr["cliente"] = mfactura.Cliente.Persona.Nombre;
                        cantidad = mfactura.Cantidad_operaciones;
                        dt.Rows.Add(dr);
                        total = total + mfactura.Total_gasto;
                    }


                }
                txt_neto.Text = total.ToString();
                ViewState["dt_excel"] = dt;
                gr_dato.DataSource = dt;
                gr_dato.DataBind();

            }
        }

        protected void rdb_operacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_operacion.Checked == true)
            {
                lbl_f_fac_oper.Visible = true;
                txt_fecha_fac_oper.Visible = true;
                imgb_fecha_fac_oper.Visible = true;
            }
        }

        protected void rdb_nomina_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_nomina.Checked == true)
            {
                lbl_f_fac_oper.Visible = false;
                txt_fecha_fac_oper.Visible = false;
                imgb_fecha_fac_oper.Visible = false;
            }
        }


    }
}