using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using System.Text;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
    public partial class GeneracionNomina : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            int secion_count =0;
			if (!IsPostBack)
			{
                this.lbl_cantidad.Text = ""; 
                this.txt_operacion.Visible = false;
                secion_count = Session.Count;

                FuncionGlobal.combofamiliabyusuario(Session["usrname"].ToString(), this.dl_familia);
                FuncionGlobal.comboclientesbyusuario(Session["usrname"].ToString(), this.dl_cliente);
                this.txt_desde.Text = DateTime.Today.ToShortDateString();
                this.txt_hasta.Text = DateTime.Today.ToShortDateString();

			}
		}
    

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
            this.txt_operacion.Text = "";
            this.txt_operacion.Visible = false;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dt_operacion"];
            if (dt != null)
            {
               
                dt.Rows.Clear();
                this.gr_dato.DataSource = dt;
                this.gr_dato.DataBind();
            }
           
            FuncionGlobal.comboTipoNominaByFamilia(this.dl_tiponomina, Convert.ToInt32(this.dl_familia.SelectedValue));
            this.LinkButton1.Visible = false;

            if (this.dl_familia.SelectedValue == "19")
            {
                this.txt_credito.Visible = true;
                
                this.lbl_credito.Visible = true;
            }
            else
            {
                this.txt_credito.Visible = false;
            }
		}


        protected void crear_data_table()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("id_cliente", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("nombre_cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("tipo_operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("numero_factura", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("patente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("rut_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("nombre_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("img_disponible", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("disponible"));
            dt.Columns.Add(new DataColumn("monto_gasto"));
            dt.Columns.Add(new DataColumn("monto_factura")); 

            ViewState["dt_operacion"] = dt;
          
        }
        protected void crear_data_table_gasto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("id_cliente", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("nombre_cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("tipo_operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("numero_factura", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("patente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("rut_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("nombre_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("img_disponible", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("disponible"));
            dt.Columns.Add(new DataColumn("monto_gasto"));
            dt.Columns.Add(new DataColumn("monto_factura"));

            ViewState["dt_operacion_gasto"] = dt;          
        }
        protected void crear_data_table_cliente()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("id_cliente", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("nombre_cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("tipo_operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("numero_factura", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("patente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("rut_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("nombre_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("img_disponible", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("disponible"));
            dt.Columns.Add(new DataColumn("monto_gasto"));
            dt.Columns.Add(new DataColumn("monto_factura"));

            ViewState["dt_operacion_cliente"] = dt;
          
        }
        protected void crear_data_table_nomina()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("id_cliente", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("nombre_cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("tipo_operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("numero_factura", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("patente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("rut_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("nombre_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("img_disponible", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("disponible"));
            dt.Columns.Add(new DataColumn("monto_gasto"));
            dt.Columns.Add(new DataColumn("monto_factura"));

            ViewState["dt_operacion_nomina"] = dt;           
            
        }

		protected void Buscar_Operaciones(int id_solicitud,bool disponible)
		{
            DataTable dt = new DataTable();

             dt = (DataTable)ViewState["dt_operacion"];

             if (dt == null)
             {
                 crear_data_table();
                 dt = (DataTable)ViewState["dt_operacion"];
             }

            Operacion moperacion = new OperacionBC().getOperacionCreacionNomina(id_solicitud, Convert.ToInt32(this.dl_cliente.SelectedValue),Convert.ToInt32(this.dl_familia.SelectedValue));
            GastosComunes gasto; 
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue));
            
            if (moperacion != null)
			{
				this.bt_generar.Enabled = true;

			    DataRow dr = dt.NewRow();
                   
                   gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(moperacion.Id_solicitud, mtipo.Id_tipogasto);                   

                   if (mtipo.Id_tipogasto != 0)
                   {
                       dr["monto_gasto"] = gasto.Valor.ToString();
                   }                 
     
                    dr["id_solicitud"] = moperacion.Id_solicitud;
                    dr["id_cliente"] = moperacion.Cliente.Id_cliente;
                    dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
                    dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
                    dr["operacion"] = moperacion.Tipo_operacion.Operacion;
                    dr["numero_factura"] = moperacion.Numero_factura;
                    dr["disponible"] = disponible;
                
                    if (disponible == true)
                    {
                        dr["img_disponible"] = "../imagenes/sistema/static/ok.png";
                    }
                    else
                    {
                        dr["img_disponible"] = "../imagenes/sistema/static/no-small.jpg";
                        
                    }

                    DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(moperacion.Id_solicitud);
                    if (mdato == null)
                    {
                        dr["patente"] = "";
                    }
                    else
                    {
                        dr["patente"] = mdato.Patente;
                    }
                    
                    if (moperacion.Adquiriente != null)
                    {
                        dr["rut_persona"] = moperacion.Adquiriente.Rut.ToString("N0") + "-" + moperacion.Adquiriente.Dv;
                        dr["nombre_persona"] = string.Format("{0} {1} {2}", moperacion.Adquiriente.Nombre, moperacion.Adquiriente.Apellido_paterno, moperacion.Adquiriente.Apellido_materno).Trim                        ();
                    }
                    else
                    {
                        dr["rut_persona"] = "0-0";
                        dr["nombre_persona"] = "Sin Adquiriente";
                    
                    }
           
                    dr["semaforo"] = moperacion.Semaforo.Trim();
                    dr["ultimo_estado"] = moperacion.Estado;

                    dt.Rows.Add(dr);

			}

            ViewState["dt_operacion"] = dt;
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
            this.txt_operacion.Focus(); 

		}

        
        protected void Buscar_OperacionesGasto(int id_solicitud, bool disponible)
        {
            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["dt_operacion_gasto"];

            if (dt == null)
            {
                crear_data_table_gasto();
                dt = (DataTable)ViewState["dt_operacion_gasto"];
            }
  
            Operacion moperacion = new OperacionBC().getOperacionCreacionNomina(id_solicitud, Convert.ToInt32(this.dl_cliente.SelectedValue), Convert.ToInt32(this.dl_familia.SelectedValue)); 
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue));
            GastosComunes gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(moperacion.Id_solicitud, mtipo.Id_tipogasto);

            if (moperacion != null)
            {
                this.bt_generar.Enabled = true;
                DataRow dr = dt.NewRow();
                gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(moperacion.Id_solicitud, mtipo.Id_tipogasto);

                if (mtipo.Id_tipogasto != 0)
                {
                    dr["monto_gasto"] = gasto.Valor.ToString();
                }
                else
                {
                    dr["monto_gasto"] = "0";
                }

                dr["id_solicitud"] = moperacion.Id_solicitud;
                dr["id_cliente"] = moperacion.Cliente.Id_cliente;
                dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
                dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
                dr["operacion"] = moperacion.Tipo_operacion.Operacion;
                dr["numero_factura"] = moperacion.Numero_factura;
                dr["disponible"] = disponible;

                if (disponible == true)
                {
                    dr["img_disponible"] = "../imagenes/sistema/static/ok.png";
                }
                else
                {
                    dr["img_disponible"] = "../imagenes/sistema/static/no-small.jpg";
                }

                DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(moperacion.Id_solicitud);
                dr["patente"] = mdato.Patente;

                if (moperacion.Adquiriente != null)
                {
                    dr["rut_persona"] = moperacion.Adquiriente.Rut.ToString("N0") + "-" + moperacion.Adquiriente.Dv;
                    dr["nombre_persona"] = string.Format("{0} {1} {2}", moperacion.Adquiriente.Nombre, moperacion.Adquiriente.Apellido_paterno,                                                                              moperacion.Adquiriente.Apellido_materno).Trim();
                }
                else
                {
                    dr["rut_persona"] = "0-0";
                    dr["nombre_persona"] = "Sin Adquiriente";

                }

                dr["semaforo"] = moperacion.Semaforo.Trim();
                dr["ultimo_estado"] = moperacion.Estado;
                dt.Rows.Add(dr);



            }
        }

		protected void GenerarNomina()
		{

            GridViewRow row;
            TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.dl_tiponomina.SelectedValue));
            
            int contador = 0;
            string[] nomina = lTiponomina.Descripcion.Split();
            if (nomina[0]+nomina[1]+nomina[2] == "NOMINAPAGOGASTO")
            {
                Usuario usu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
                if (usu.Perfil.Codigoperfil.Trim() == "GYC" || usu.UserName.Trim() == "153636613")
                {

                        for (int i = 0; i < gr_dato.Rows.Count; i++)
                        {
                            row = gr_dato.Rows[i];
                            string id_solicitud = (string)row.Cells[0].Text;
                            HyperLink but = (HyperLink)row.Cells[0].Controls[0];
                            string disponible = gr_dato.DataKeys[i].Values[3].ToString().Trim();
                            if (DropDowncheque.Text == "0" && lTiponomina.Id_tipogasto != 0)
                            {
                                FuncionGlobal.alerta_updatepanel("Fallo en la nomina, se necesita escoger cheque", this.Page, this.up_datos);
                            }
                            else
                            {
                                if (disponible == "True")
                                {
                                    string add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(but.Text.Trim()), Convert.ToInt32(this.dl_tiponomina.SelectedValue), lTiponomina.Folio, Session["usrname"].ToString());

                                    contador++;
                                }

                            }
                        }

                }
                else
                {
                     FuncionGlobal.alerta_updatepanel("Su Perfil no cumple con los requisitos para crear este tipo de Nomina", this.Page, this.up_datos);
                }
            }
            else
            {
                for (int i = 0; i < gr_dato.Rows.Count; i++)
                {
                    row = gr_dato.Rows[i];
                    string id_solicitud = (string) row.Cells[0].Text;
                    HyperLink but = (HyperLink) row.Cells[0].Controls[0];
                    string disponible = gr_dato.DataKeys[i].Values[3].ToString().Trim();
                    if (DropDowncheque.Text == "0" && lTiponomina.Id_tipogasto != 0)
                    {
                        FuncionGlobal.alerta_updatepanel("Fallo en la nomina, se necesita escoger cheque", this.Page,
                        this.up_datos);
                    }
                    else
                    {
                        if (disponible == "True")
                        {
                            string add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(but.Text.Trim()),
                                Convert.ToInt32(this.dl_tiponomina.SelectedValue), lTiponomina.Folio,
                                Session["usrname"].ToString());
                            contador++;
                        }

                    }
                }

            }
            if (contador > 0 )
            {
                if (this.DropDowncheque.SelectedValue != "")
                {
                    Int32 add = new OperacionBC().Actualizar_ChequeInventario(lTiponomina.Folio, Convert.ToInt32(DropDowncheque.SelectedValue.ToString()), lTiponomina.Id_nomina);
                    FuncionGlobal.combochequeinventario(DropDowncheque);
                }

                if (this.dl_tiponomina.SelectedValue.Trim() == "200")
                {
                    string correo = new TipoNominaBC().envia_correo_nomina(Convert.ToInt32(this.dl_tiponomina.SelectedValue.Trim()), lTiponomina.Folio);
                }

                if (this.dl_tiponomina.SelectedValue.Trim() == "129")
                {
                    string correo = new TipoNominaBC().envia_correo_nomina_pdte(Convert.ToInt32(this.dl_tiponomina.SelectedValue.Trim()), lTiponomina.Folio);
                }

                FuncionGlobal.alerta_updatepanel(string.Format("Nómina {0} con folio {1} generada con éxito", lTiponomina.Descripcion, lTiponomina.Folio), this.Page,                              this.up_datos);
            }
            else
                {
                    FuncionGlobal.alerta_updatepanel("Fallo en la nomina, favor revisar disponibilidad de las operaciones", this.Page, this.up_datos);
                }
		}

        protected void txt_operacion_TextChanged(object sender, EventArgs e)
        {
            
            if (this.txt_operacion.Text != "")
            {
              
                    Buscar_Operaciones(Convert.ToInt32(this.txt_operacion.Text),validar_busqueda(Convert.ToInt32(this.txt_operacion.Text)) );
                    this.txt_operacion.Text = "";
                  
               
            }
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue));
            if (mtipo.Id_tipogasto != 0)
            {
                Total_gasto();
            }
        }


        protected bool validar_busqueda(int id_solicitud)
        {

            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16 ( this.dl_tiponomina.SelectedValue  ));
            GastosComunes gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(id_solicitud, mtipo.Id_tipogasto);
            GastosComunes tipoGasto = new GastosComunesBC().getGastosComunes(mtipo.Id_tipogasto);

        
            if (mtipo.Id_tipogasto != 0)
            {

                if (gasto.Valor == 0 && mtipo.Id_tipogasto != 120)
                {
                   // FuncionGlobal.alerta_updatepanel("La operacion no tiene el Gasto " + tipoGasto.Descripcion.Trim() + " cargado."  , this.Page, this.up_filtros);
                    return false;
                }

            }
     
            if (mtipo.Permite_factura == true)
            {
                if ( this.dl_familia.SelectedValue != "0" & this.dl_tiponomina.SelectedValue != "0")
                {
                    bool respuesta = new TipoNominaBC().respuesta_nomina(id_solicitud, Convert.ToInt16(this.dl_tiponomina.SelectedValue)
                                                              , Convert.ToInt32(this.dl_familia.SelectedValue),Convert.ToInt32(this.dl_cliente.SelectedValue));

                    if (respuesta == true)
                    {
                        return true;
                    }
                    else
                    {
                        if (this.txt_folio.Text == "" && this.txt_operacion.Text !="")
                        {
                            FuncionGlobal.alerta_updatepanel("Esta operacion no cumple los requisitos para estar en la nomina seleccionada", this.Page, this.up_filtros);
                        }
                        return false;
                    }
                }
                else
                {
                    if (this.txt_folio.Text == "" && this.txt_operacion.Text != "")
                    {
                        FuncionGlobal.alerta_updatepanel("Debe seleccionar todos los Filtros", this.Page, this.up_filtros);
                    }
                    return false;
                }

            }
            else
            {
                if (this.dl_familia.SelectedValue != "0" & this.dl_tiponomina.SelectedValue != "0")
                {
                    bool respuesta = new TipoNominaBC().respuesta_nomina(id_solicitud, Convert.ToInt16(this.dl_tiponomina.SelectedValue)
                                                              , Convert.ToInt32(this.dl_familia.SelectedValue),Convert.ToInt32(this.dl_cliente.SelectedValue));

                    if (respuesta == true)
                    {
                        return true;
                    }
                    else
                    {
                        if (this.txt_folio.Text == "" && this.txt_operacion.Text != "")
                        {
                            FuncionGlobal.alerta_updatepanel("Esta operacion no cumple los requisitos para estar en la nomina seleccionada", this.Page, this.up_filtros);
                        }
                        return false;
                    }
                }
                else
                {
                    if (this.txt_folio.Text == "")
                    {
                        FuncionGlobal.alerta_updatepanel("Debe seleccionar todos los Filtros", this.Page, this.up_filtros);
                    }
                    return false;
                }
            }

        }

        protected void dl_tiponomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_operacion.Visible = true;
            this.LinkButton1.Visible = false;
            if (this.dl_tiponomina.SelectedValue != "0")
            {
                this.txt_operacion.Enabled = true;
                this.txt_folio.Enabled = true;
                

                TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.dl_tiponomina.SelectedValue));
                if (lTiponomina.Cliente_unico == true && this.dl_cliente.SelectedValue == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Debe seleccionar un cliente", this.Page, this.up_filtros);
                    GridViewRow row;

                    for (int i = 0; i < gr_dato.Rows.Count; i++)
                    {

                        row = gr_dato.Rows[i];
                        string id_solicitud = (string)row.Cells[0].Text;
                        HyperLink but = (HyperLink)row.Cells[0].Controls[0];
                        this.Buscar_OperacionesNomina(Convert.ToInt32(but.Text), validar_busqueda(Convert.ToInt32(but.Text)));


                    }

                    this.gr_dato.DataSource = (DataTable)ViewState["dt_operacion_nomina"];
                    this.gr_dato.DataBind();
                    this.txt_operacion.Focus();
                }
                else
                {

                    if (lTiponomina.Id_tipogasto != 0)
                    {
                        GastosComunes mgasto = new GastosComunesBC().getGastosComunes(Convert.ToInt16(lTiponomina.Id_tipogasto));
                        this.txt_monto.Text = mgasto.Valor.ToString();
                        this.txt_gasto.Text = mgasto.Descripcion;
                        this.Panel1.Visible = true;

                        GridViewRow row;

                        for (int i = 0; i < gr_dato.Rows.Count; i++)
                        {

                            row = gr_dato.Rows[i];
                            string id_solicitud = (string)row.Cells[0].Text;
                            HyperLink but = (HyperLink)row.Cells[0].Controls[0];
                            this.Buscar_OperacionesGasto(Convert.ToInt32(but.Text), validar_busqueda(Convert.ToInt32(but.Text)));


                        }

                        this.gr_dato.DataSource = (DataTable)ViewState["dt_operacion_gasto"];
                        this.gr_dato.DataBind();
                        this.txt_operacion.Focus();


                    }
                    else
                    {
                        GridViewRow row;

                        for (int i = 0; i < gr_dato.Rows.Count; i++)
                        {

                            row = gr_dato.Rows[i];
                            string id_solicitud = (string)row.Cells[0].Text;
                            HyperLink but = (HyperLink)row.Cells[0].Controls[0];
                            this.Buscar_OperacionesNomina(Convert.ToInt32(but.Text), validar_busqueda(Convert.ToInt32(but.Text)));


                        }

                        this.gr_dato.DataSource = (DataTable)ViewState["dt_operacion_nomina"];
                        this.gr_dato.DataBind();
                        this.txt_operacion.Focus();

                        this.Panel1.Visible = false;
                    }

                }

                if (lTiponomina.Permite_factura == true)
                {
                    this.lbl_cliente.Visible = true;
                    this.dl_cliente.Visible = true;
                }
                if (lTiponomina.Id_tipogasto != 0)
                {
                    Total_gasto();
                }
            }
          
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 fila;

            fila = this.gr_dato.SelectedIndex;

            DataTable dt = (DataTable)ViewState["dt_operacion"];

            dt.Rows.RemoveAt(fila);

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }

        protected void Total_gasto()
        {
            int total_gasto = 0;
           
            GridViewRow row;
             
            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];

          
                total_gasto = total_gasto + Convert.ToInt32(row.Cells[10].Text);
                
            }

            this.txt_total.Text = total_gasto.ToString();

            FuncionGlobal.combochequeinventario(DropDowncheque);
        }

        protected void bt_generar_Click(object sender, ImageClickEventArgs e)
        {
            
            GenerarNomina();

        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row;

            if (gr_dato.Rows.Count > 0)
            {
                for (int i = 0; i < gr_dato.Rows.Count; i++)
                {

                    row = gr_dato.Rows[i];
                    string id_solicitud = (string)row.Cells[0].Text;
                    HyperLink but = (HyperLink)row.Cells[0].Controls[0];
                    this.Buscar_OperacionesCliente(Convert.ToInt32(but.Text), validar_busqueda(Convert.ToInt32(but.Text)));


                }

                this.gr_dato.DataSource = (DataTable)ViewState["dt_operacion_cliente"];
                this.gr_dato.DataBind();
                this.txt_operacion.Focus();

                this.lbl_cantidad1.Text = "Cantidad de Operaciones " + this.gr_dato.Rows.Count.ToString();
                this.lbl_cantidad.Text = "Cantidad de Operaciones " + this.gr_dato.Rows.Count.ToString();

               
            }
        }


     

        protected void ib_opedia_Click(object sender, ImageClickEventArgs e)
        {
                
                this.gr_dato.DataSourceID=null;
                this.gr_dato.DataSource=null;
                this.gr_dato.DataBind();
                ViewState["dt_operacion"] = null;
                this.lbl_cantidad1.Text = "";
                
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue)); 

                if (this.txt_folio.Text != "")
                {

                    if (mtipo.Cliente_unico  && this.dl_cliente.SelectedValue == "0")
                    {
                        FuncionGlobal.alerta_updatepanel("Debe seleccionar un Cliente", this.Page, this.up_filtros);
                    }
                    else
                    {
                        List<Operacion> lnom = new OperacionBC().getOperacionesbynominaExpress(Convert.ToInt32(this.dl_tiponomina.SelectedValue), Convert.ToInt32(this.txt_folio.Text), (string)Session["usrname"]);

                        this.lbl_cantidad1.Text = "Cantidad de Operaciones " + lnom.Count().ToString();
                        this.lbl_cantidad.Text = "Cantidad de Operaciones " + lnom.Count().ToString();

                        foreach (Operacion moper in lnom)
                        {
                            Buscar_Operaciones(moper.Id_solicitud, validar_busqueda(moper.Id_solicitud));                         
                        }

                        if (mtipo.Id_tipogasto != 0)
                        {
                            Total_gasto();
                        }
                    }
                }
                else
                {
                    if (this.dl_familia.SelectedValue != "0" && this.txt_folio.Text == "" && this.txt_operacion.Text == "" && this.dl_tiponomina.SelectedValue != "0")
                    {
                        if (mtipo.Cliente_unico == true && this.dl_cliente.SelectedValue == "0")
                        {
                            FuncionGlobal.alerta_updatepanel("Debe seleccionar un Cliente", this.Page, this.up_filtros);
                        }
                        else
                        {

                            List<Operacion> lnom = new OperacionBC().Operacionesnomina_desde_hasta(id_familia: Convert.ToInt32(this.dl_familia.SelectedValue),
                            id_cliente: Convert.ToInt32(this.dl_cliente.Text), desde: string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
                            hasta: string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())));

                            this.lbl_cantidad1.Text = "Cantidad de Operaciones " + lnom.Count().ToString();
                            this.lbl_cantidad.Text = "Cantidad de Operaciones " + lnom.Count().ToString();


                            foreach (Operacion moper in lnom)
                            {

                                Buscar_Operaciones(moper.Id_solicitud, validar_busqueda(moper.Id_solicitud));
                                //this.txt_folio.Text = "";

                            }


                        

                        if (mtipo.Id_tipogasto != 0)
                            {
                                Total_gasto();
                            }

                        }
                    }
                }
                lbl_cantidad1.Visible = true;
                lbl_cantidad.Visible = true;
        }

    

        protected void ib_exportar_Click(object sender, ImageClickEventArgs e)
        {
            if (this.dl_tiponomina.SelectedValue == "0" || this.txt_folio.Text.Trim() == "")
            { return; }

            string titulo = "";

            titulo = "NOMINA AREA: " + this.dl_familia.SelectedItem.Text.Trim() + " - TIPO :  " +
                                this.dl_tiponomina.SelectedItem.Text.Trim() + "  NUMERO:  " + this.txt_folio.Text.Trim();


            string add = new MatrizExcelBC().getnominamatrizgasto(Convert.ToInt16(this.dl_tiponomina.SelectedValue),
                                                                    Convert.ToInt32(this.txt_folio.Text),
                                                                    Convert.ToInt16(this.dl_familia.SelectedValue), titulo);




            FuncionGlobal.alerta_updatepanel("Nomina con detalle de gastos, generada con exito", this.Page, this.up_filtros);
        }

        protected void btn_nomina_pdf_Click(object sender, ImageClickEventArgs e)
        {
            this.Ver_Reporte_Nomina();
        }

        protected void Ver_Reporte_Nomina()
        {
            int id_nomina = Convert.ToInt32(this.dl_tiponomina.SelectedValue);
            int folio;

            if (!int.TryParse(this.txt_folio.Text, out folio)) { folio = 0; }

            if (id_nomina != 0 && folio != 0)
            {
                string cadena = string.Format("../reportes/view_nomina.aspx?id_familia={0}&folio={1}&id_nomina={2}", this.dl_familia.SelectedValue, folio, id_nomina);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ViewNomina", "window.open('" + cadena + "');", true);
            }
        }

        protected void txt_folio_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void btn_nomina_txt_Click(object sender, ImageClickEventArgs e)
        {

            if (this.txt_folio.Text != "")
            {
                FileStream fs = new FileStream("D:\\Sistema\\txt_meras\\" + (string)(Session["usrname"]) + this.txt_folio.Text + this.dl_tiponomina.SelectedValue + "_utf8.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);

                FileStream fsa = new FileStream("D:\\Sistema\\txt_meras\\" + (string)(Session["usrname"]) + this.txt_folio.Text + this.dl_tiponomina.SelectedValue + "_anci.txt", FileMode.Create);
                StreamWriter swa = new StreamWriter(fsa, Encoding.GetEncoding(1250));

                GridViewRow row;


                for (int i = 0; i < gr_dato.Rows.Count; i++)
                {
                    row = gr_dato.Rows[i];
                    HyperLink but = (HyperLink)row.Cells[0].Controls[0];
                    string disponible = gr_dato.DataKeys[i].Values[3].ToString().Trim();

                    Operacion moper = new OperacionBC().getoperacion(Convert.ToInt32(but.Text.ToString()));
                    DatosVehiculo mve = new DatosvehiculoBC().getDatovehiculo(Convert.ToInt32(moper.Id_solicitud));
                    ParticipeOperacion mcompra = new ParticipeOperacionBC().getparticipebytipo(Convert.ToInt32(but.Text.ToString()), "COMPR");
                    ParticipeOperacion mvende = new ParticipeOperacionBC().getparticipebytipo(Convert.ToInt32(but.Text.ToString()), "VENDE");
                    string razon_social = "";

                    Meratenencia mera = new MeratenenciaBC().getmeratenencia(Convert.ToInt32(but.Text.ToString()));

                    if (mvende.Participe.Rut > 50000000)
                    {
                        razon_social = mcompra.Participe.Nombre + " " + mcompra.Participe.Apellido_paterno + " " + mcompra.Participe.Apellido_materno;
                    }

                   
                        string dia = mera.Fecha_doc.Day.ToString().Trim();
                        string mes = mera.Fecha_doc.Month.ToString().Trim();
                        if (mes.Length == 1) { mes = "0" + mes; }
                        if (dia.Length == 1) { dia = "0" + dia; }
                        string n_doc = "";
                        n_doc = mera.N_doc.Replace(".", "");

                        string rut_vende = FuncionGlobal.CreaRelleno(8 - (mvende.Participe.Rut.ToString().Trim().Length), "0").Trim();
                        string rut_compra = FuncionGlobal.CreaRelleno(8 - (mcompra.Participe.Rut.ToString().Trim().Length), "0").Trim();
                        string n_documento = FuncionGlobal.CreaRelleno(13 - (n_doc.Trim().Length), " ");
                        string lugar = FuncionGlobal.CreaRelleno(26 - (mera.Lugar_doc.Trim().Length), " ");
                        string autorizacion = FuncionGlobal.CreaRelleno(24 - (mera.Autorizacion.Trim().Length), " ");
                        string tribunal = FuncionGlobal.CreaRelleno(25 - (mera.Tribunal.Length), " ");
                        string anno_causa = FuncionGlobal.CreaRelleno(4 - (mera.Anno_causa.ToString().Trim().Length), "0").Trim();
                        string aut = mera.Autorizacion;
                        if (mera.Autorizacion.Trim().Length > 24)
                        {
                            aut = mera.Autorizacion.Trim().Substring(0, 24);
                        }
                        string patente;
                        if (mve.Patente.Trim() == "")
                        {
                            patente = "      ";
                        }
                        else
                        {
                            patente = mve.Patente.Trim();
                        }
                   
                        sw.WriteLine(patente + rut_vende + mvende.Participe.Rut.ToString().Trim() + mvende.Participe.Dv.Trim() + "0" + mera.Titulo_mera.Trim() + "0" + mera.Calidad_mero.Trim()
                           + rut_compra + mcompra.Participe.Rut.ToString().Trim() + mcompra.Participe.Dv.Trim() + "16086274223280200" + mera.Tipo_doc.Trim() +
                             mera.Naturaleza_doc.Trim() + n_doc.Trim() + n_documento + mera.Fecha_doc.Year.ToString().Trim() + mes + dia +
                            mera.Lugar_doc.Trim() + lugar + aut.Trim() + autorizacion + mera.Tribunal + tribunal + mera.Anno_causa + anno_causa);

                        swa.WriteLine(patente + rut_vende + mvende.Participe.Rut.ToString().Trim() + mvende.Participe.Dv.Trim() + "0" + mera.Titulo_mera.Trim() + "0" + mera.Calidad_mero.Trim()
                           + rut_compra + mcompra.Participe.Rut.ToString().Trim() + mcompra.Participe.Dv.Trim() + "16086274223280200" + mera.Tipo_doc.Trim() +
                           mera.Naturaleza_doc.Trim() + n_doc.Trim() + n_documento + mera.Fecha_doc.Year.ToString().Trim() + mes + dia +
                          mera.Lugar_doc.Trim() + lugar + aut.Trim() + autorizacion + mera.Tribunal + tribunal + mera.Anno_causa + anno_causa);
                    
                }

                sw.Close();
                swa.Close();

                this.LinkButton1.NavigateUrl = "../txt_meras/" + (string)(Session["usrname"]) + this.txt_folio.Text + this.dl_tiponomina.SelectedValue + "_utf8.txt";
                this.LinkButton1.Visible = true;

                this.LinkButton2.NavigateUrl = "../txt_meras/" + (string)(Session["usrname"]) + this.txt_folio.Text + this.dl_tiponomina.SelectedValue + "_anci.txt";
                this.LinkButton2.Visible = true;

            }
        }

        protected void txt_credito_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_credito.Text != "")
            {
                Retiro_Carpeta mre = new Retiro_carpetaBC().getretirobycredito(Convert.ToInt32(this.txt_credito.Text.Trim()));

                if (mre.Id_solicitud != 0)
                {
                    Buscar_Operaciones(Convert.ToInt32(mre.Id_solicitud), validar_busqueda(Convert.ToInt32(mre.Id_solicitud)));

                }
                else
                {
                    FuncionGlobal.alerta_updatepanel("Numero de Credito no existe", this.Page, this.up_filtros);
                }
                this.txt_credito.Text = "";
            }

        }

        protected void txt_total_TextChanged(object sender, EventArgs e)
        {

        }




        protected void Buscar_OperacionesCliente(int id_solicitud, bool disponible)
        {
            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["dt_operacion_cliente"];

            if (dt == null)
            {
                crear_data_table_cliente();
                dt = (DataTable)ViewState["dt_operacion_cliente"];
            }

            Operacion moperacion = new OperacionBC().getOperacionCreacionNomina(id_solicitud, Convert.ToInt32(this.dl_cliente.SelectedValue), Convert.ToInt32(this.dl_familia.SelectedValue));
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue));
            

            if (moperacion != null)
            {
                this.bt_generar.Enabled = true;


                DataRow dr = dt.NewRow();

               

                if (mtipo.Id_tipogasto != 0)
                {
                    GastosComunes gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(moperacion.Id_solicitud, mtipo.Id_tipogasto);
                    dr["monto_gasto"] = gasto.Valor.ToString();

                }
                else
                {
                    dr["monto_gasto"] = "0";
                }

                dr["id_solicitud"] = moperacion.Id_solicitud;
                dr["id_cliente"] = moperacion.Cliente.Id_cliente;
                dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
                dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
                dr["operacion"] = moperacion.Tipo_operacion.Operacion;
                dr["numero_factura"] = moperacion.Numero_factura;
                dr["disponible"] = disponible;

                if (disponible == true)
                {
                    dr["img_disponible"] = "../imagenes/sistema/static/ok.png";
                }
                else
                {
                    dr["img_disponible"] = "../imagenes/sistema/static/no-small.jpg";
                }

                DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(moperacion.Id_solicitud);
                if (mdato != null)
                {
                    dr["patente"] = mdato.Patente;
                }
                else
                {
                    dr["patente"] = "";
                }
                if (moperacion.Adquiriente != null)
                {
                    dr["rut_persona"] = moperacion.Adquiriente.Rut.ToString("N0") + "-" + moperacion.Adquiriente.Dv;
                    dr["nombre_persona"] = string.Format("{0} {1} {2}", moperacion.Adquiriente.Nombre, moperacion.Adquiriente.Apellido_paterno, moperacion.Adquiriente.Apellido_materno).Trim();
                }
                else
                {
                    dr["rut_persona"] = "0-0";
                    dr["nombre_persona"] = "Sin Adquiriente";

                }

                dr["semaforo"] = moperacion.Semaforo.Trim();
                dr["ultimo_estado"] = moperacion.Estado;
                dt.Rows.Add(dr);



            }
        }


        protected void Buscar_OperacionesNomina(int id_solicitud, bool disponible)
        {
            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["dt_operacion_nomina"];

            if (dt == null)
            {
                crear_data_table_nomina();
                dt = (DataTable)ViewState["dt_operacion_nomina"];
            }

            Operacion moperacion = new OperacionBC().getOperacionCreacionNomina(id_solicitud, Convert.ToInt32(this.dl_cliente.SelectedValue), Convert.ToInt32(this.dl_familia.SelectedValue));
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue));
         

            if (moperacion != null)
            {
                this.bt_generar.Enabled = true;


                DataRow dr = dt.NewRow();

              

                if (mtipo.Id_tipogasto != 0)
                {
                    GastosComunes gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(moperacion.Id_solicitud, mtipo.Id_tipogasto);
                    dr["monto_gasto"] = gasto.Valor.ToString();

                }
                else
                {
                    dr["monto_gasto"] = "0";
                }

                dr["id_solicitud"] = moperacion.Id_solicitud;
                dr["id_cliente"] = moperacion.Cliente.Id_cliente;
                dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
                dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
                dr["operacion"] = moperacion.Tipo_operacion.Operacion;
                dr["numero_factura"] = moperacion.Numero_factura;
                dr["disponible"] = disponible;

                if (disponible == true)
                {
                    dr["img_disponible"] = "../imagenes/sistema/static/ok.png";
                }
                else
                {
                    dr["img_disponible"] = "../imagenes/sistema/static/no-small.jpg";
                }

                DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(moperacion.Id_solicitud);

                if(mdato ==null)
                {
                    dr["patente"] = "";
                }
                else
                {
                    dr["patente"] = mdato.Patente;
                }
                if (moperacion.Adquiriente != null)
                {
                    dr["rut_persona"] = moperacion.Adquiriente.Rut.ToString("N0") + "-" + moperacion.Adquiriente.Dv;
                    dr["nombre_persona"] = string.Format("{0} {1} {2}", moperacion.Adquiriente.Nombre, moperacion.Adquiriente.Apellido_paterno, moperacion.Adquiriente.Apellido_materno).Trim();
                }
                else
                {
                    dr["rut_persona"] = "0-0";
                    dr["nombre_persona"] = "Sin Adquiriente";

                }

                dr["semaforo"] = moperacion.Semaforo.Trim();
                dr["ultimo_estado"] = moperacion.Estado;
                dt.Rows.Add(dr);



            }
            ViewState["dt_operacion_nomina"] = dt;
        }


        private string carga_archivo()
        {
            string sSave = "";

            if (this.fileuploadExcel.PostedFile != null && this.fileuploadExcel.PostedFile.ContentLength > 0)
            {
                FileInfo fi_documento = new FileInfo(fileuploadExcel.FileName);
                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".xls")
                    {

                        if (fileuploadExcel.PostedFile.ContentLength <= 6194304)
                        {
                            string sDoc = "Nomina_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                            sSave = "c:\\Archivo_Nomina\\" + sDoc;
                            try
                            {
                                this.fileuploadExcel.PostedFile.SaveAs(sSave);
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
                        this.lbl_cantidad.Text = "El formato del Excel solo puede ser .xls";
                    }
                }
            }

            return sSave;

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            importa_excel(carga_archivo());
        }

        private void importa_excel(string ruta)
        {
            this.gr_dato.DataSourceID = null;
            this.gr_dato.DataSource = null;
            this.gr_dato.DataBind();
            ViewState["dt_operacion"] = null;
            this.lbl_cantidad1.Text = "";
            TipoNomina mtipo = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt16(this.dl_tiponomina.SelectedValue));




            if (this.dl_familia.SelectedValue != "0" && this.txt_folio.Text == "" && this.txt_operacion.Text == "" && this.dl_tiponomina.SelectedValue != "0")
            {
                if (mtipo.Cliente_unico == true && this.dl_cliente.SelectedValue == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Debe seleccionar un Cliente", this.Page, this.up_filtros);
                }
                else
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


                    this.lbl_cantidad1.Visible = true;
                    this.lbl_cantidad.Visible = true;
                    this.lbl_cantidad1.Text = "Numero de Filas en Archivo : " + ds.Tables[0].Rows.Count.ToString();
                    this.lbl_cantidad.Text = "Numero de Filas en Archivo : " + ds.Tables[0].Rows.Count.ToString();

                    da.Dispose();
                    conn.Close();
                    conn.Dispose();

                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["id_solicitud"] != null && dr["id_solicitud"].ToString().Trim() !="")
                        {
                            Buscar_Operaciones(Convert.ToInt32(dr["id_solicitud"]), validar_busqueda(Convert.ToInt32(dr["id_solicitud"])));
                            //this.txt_folio.Text = "";
                        }
                    }


                    if (mtipo.Id_tipogasto != 0)
                    {
                        Total_gasto();
                    }

                }
            }
           
        }

        protected void txt_gasto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_monto_TextChanged(object sender, EventArgs e)
        {

        }

      




	}
}