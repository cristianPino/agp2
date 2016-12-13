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


namespace sistemaAGP
{
    public partial class Control_Stockventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                this.txt_desde.Text = DateTime.Today.ToShortDateString();
                this.txt_hasta.Text = DateTime.Today.ToShortDateString();

                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]),this.dl_cliente);
                FuncionGlobal.combotipooperacion(this.dl_producto);
               
            }

        }

      

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
            FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {

            busca_operacion();
        }

        private void busca_operacion()
        {

            double rut;
            Int32 noperacion;
            Int32 estado_actual;
            Int16 dl_modulo;
            Int16 dl_sucursal;

            if (this.txt_rut.Text.Trim() == "")
            { rut = 0; }
            else
            { rut = Convert.ToDouble(this.txt_rut.Text); }


            if (this.txt_operacion.Text.Trim() == "")
            { noperacion = 0; }
            else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

            if (this.dpl_estado.SelectedValue == "")
            { estado_actual = 0; }
            else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

            if (this.dl_modulo.SelectedValue == "")
            { dl_modulo = 0; }
            else { dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue); }

            if (this.dl_sucursal.SelectedValue == "")
            { dl_sucursal = 0; }
            else { dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue); }

			List<Transferencia> loperacion = new OperacionBC().getOperacionesbyStockVenta(this.dl_producto.SelectedValue,
																dl_modulo,
																dl_sucursal,
																Convert.ToInt16(this.dl_cliente.SelectedValue),
																noperacion,
																rut,
																0,
																this.txt_cliente.Text.Trim(),
																this.txt_patente.Text.Trim(),
																string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
																string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())),
																estado_actual,
																(string)(Session["usrname"]));

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("operacion"));
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("cliente_nombre"));
            dt.Columns.Add(new DataColumn("Patente"));
            dt.Columns.Add(new DataColumn("monto"));
            dt.Columns.Add(new DataColumn("rut_vendedor"));
            dt.Columns.Add(new DataColumn("nombre_vendedor"));
            //dt.Columns.Add(new DataColumn("rut_comprador"));
            //dt.Columns.Add(new DataColumn("nombre_comprador"));
            dt.Columns.Add(new DataColumn("ultimo_estado"));
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("habilitada"));
            dt.Columns.Add(new DataColumn("seguimiento"));


            
            foreach (Transferencia moperacion in loperacion)
            {
                DataRow dr = dt.NewRow();

                dr["operacion"] = moperacion.Operacion.Id_solicitud;
                dr["cliente"] = moperacion.Operacion.Cliente.Id_cliente;
                dr["cliente_nombre"] = moperacion.Operacion.Cliente.Persona.Nombre;
                dr["Patente"] = moperacion.Patente;
                dr["habilitada"] = moperacion.Habilitada;
                dr["monto"] = moperacion.PrecioVenta;
                dr["tipo_operacion"] = moperacion.Operacion.Tipo_operacion.Codigo.Trim();


                if (moperacion.Operacion.Tipo_operacion.Codigo.Trim() == "CTC"|| moperacion.Operacion.Tipo_operacion.Codigo.Trim() =="CTMAG" )
                {
                    dr["rut_vendedor"] = moperacion.Vendedor.Rut;
                    dr["nombre_vendedor"] = moperacion.Vendedor.Nombre + " " + moperacion.Vendedor.Apellido_paterno + " " + moperacion.Vendedor.Apellido_materno;
                }
                else
                {
                    dr["rut_vendedor"] = moperacion.Comprador.Rut;
                    dr["nombre_vendedor"] = moperacion.Comprador.Nombre + " " + moperacion.Comprador.Apellido_paterno + " " + moperacion.Comprador.Apellido_materno;
                }
                    //dr["rut_comprador"] = moperacion.Comprador.Rut;
                    //dr["nombre_comprador"] = moperacion.Comprador.Nombre + " " + moperacion.Comprador.Apellido_paterno + " " + moperacion.Comprador.Apellido_materno;

                
                dr["ultimo_estado"] = moperacion.Operacion.Estado;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

            Carga_Link();
            getestado(this.dl_producto.SelectedValue, this.dpl_estado);


        }

        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
        
            ImageButton ibuton;
            string id_cliente;
           


            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
               
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string tipo = gr_dato.DataKeys[i].Values[0].ToString();

                  
                   string operacion = gr_dato.DataKeys[i].Values[2].ToString();

                     string habilitada = gr_dato.DataKeys[i].Values[3].ToString();

                    id_cliente = gr_dato.DataKeys[i].Values[1].ToString();

                    string patente = (string)row.Cells[4].Text; 

                     TipoOperacion ven = new TipooperacionBC().getTipooperacion("CVT");

                    ibuton = (ImageButton)row.FindControl("ib_cdigital");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(operacion) + "&origen=eo','','status:false;dialogWidth:800px;dialogHeight:600px')");

                   
                    if (habilitada == "True")
                    {

                        ibuton = (ImageButton)row.FindControl("ib_ventas");
                        ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('" + ven.Url_operacion + FuncionGlobal.FuctionEncriptar(operacion) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&ventatipo=" + tipo + "&patente=" + patente + "&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar("0") + "','_blank','dialogheight=600px;dialogWidth=850px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')");
                    }
                    else
                    {

                        //FuncionGlobal.alerta_updatepanel("Operacion Pendiente falta habilitacion", this.Page, this.UpdatePanel2);
                    }


                }
            }
        }

      

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


      
        protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getestado(string tipo, DropDownList combo)
        {
            EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();

            mEstadotipooperacion.Codigo = "0";
            mEstadotipooperacion.Descripcion = "Seleccionar";

            List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionBC().getEstadoByTipooperacion(tipo);


            lEstadotipooperacion.Add(mEstadotipooperacion);

            combo.DataSource = lEstadotipooperacion;
            combo.DataValueField = "codigo_estado";
            combo.DataTextField = "descripcion";
            combo.DataBind();
            combo.SelectedValue = "0";



            return;


        }

        protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dl_producto.SelectedValue != "0")
            {
                this.lbl_flujo.Visible = true;
                this.dpl_estado.Visible = true;
                getestado(this.dl_producto.SelectedValue, this.dpl_estado);
            }
            else
            {
                this.lbl_flujo.Visible = false;
                this.dpl_estado.Visible = false;
            }
        }
            protected void Click_ventas(Object sender, EventArgs e)
		{
            busca_operacion();
		}

        


    }
}

