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
    public partial class estado_patente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

            }

        }

        protected void Click_Gasto(Object sender, EventArgs e)
        {
            busca_operacion();
        }

      
        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {

            busca_operacion();

        }

        private void busca_operacion()
        {

			List<Operacion> loperacion = new OperacionBC().getOperaciones_patente("0",
																0,
																0,
																0,
																0,
																0,
																0,
																"0",
																this.txt_patente.Text.Trim(),
																string.Format("{0:yyyyMMdd}", Convert.ToDateTime("1991/01/01")),
                                                                string.Format("{0:yyyyMMdd}", Convert.ToDateTime("1991/01/01")),
																0,
																(string)(Session["usrname"]),Convert.ToInt32(3));

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("tipo_operacion"));
            dt.Columns.Add(new DataColumn("cod_tip_operacion"));
            dt.Columns.Add(new DataColumn("numero_factura"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("total_gasto"));
            dt.Columns.Add(new DataColumn("numero_cliente"));
            dt.Columns.Add(new DataColumn("rut_persona"));
            dt.Columns.Add(new DataColumn("nombre_persona"));
            dt.Columns.Add(new DataColumn("cliente_nombre"));
            dt.Columns.Add(new DataColumn("ultimo_estado"));
            dt.Columns.Add(new DataColumn("saldo"));
            
            foreach (Operacion moperacion in loperacion)
            {
                DataRow dr = dt.NewRow();

                dr["id_solicitud"] = moperacion.Id_solicitud;
                dr["cliente"] = moperacion.Cliente.Id_cliente;
                dr["cliente_nombre"] = moperacion.Cliente.Persona.Nombre;
                dr["numero_factura"] = moperacion.Numero_factura;
                dr["patente"] = moperacion.Patente;
                dr["numero_cliente"] = moperacion.Numero_cliente;
                dr["tipo_operacion"] = moperacion.Tipo_operacion.Operacion;
                dr["cod_tip_operacion"] = moperacion.Tipo_operacion.Codigo;

                if (moperacion.Adquiriente != null)
                {
                    dr["rut_persona"] = moperacion.Adquiriente.Rut;
                    dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
                }
                else
                {
                    dr["rut_persona"] = "0";
                    dr["nombre_persona"] = "Sin Adquiriente";
                }

                dr["total_gasto"] = moperacion.Total_gasto;
                dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_egreso);
                dr["ultimo_estado"] = moperacion.Estado;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

            Carga_Link();
        }

        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
            HyperLink but;
            ImageButton ibuton;
            string tipo;
            string id_cliente;
           


            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                int cont = gr_dato.DataKeys.Count;
                string cliente = gr_dato.DataKeys[i].Value.ToString();

                if (row.RowType == DataControlRowType.DataRow)
                {

                    tipo = (string)row.Cells[2].Text;

                    but = (HyperLink)row.Cells[0].Controls[0];
                   
                    id_cliente = (row.Cells[1].Text);

                    ibuton = (ImageButton)row.FindControl("ib_workflow");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mWorkflow.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

                    ibuton = (ImageButton)row.FindControl("ib_comGastos");
                    if (cliente == "MU")
                        ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro_multa.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");
                    else
                        ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar("3") + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");

                    ibuton = (ImageButton)row.FindControl("ib_cdigital");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=eo','','status:false;dialogWidth:800px;dialogHeight:600px')");


                    if (cliente != "DOCUMENTO HIPOTECARIO")
                    {
                        ibuton = (ImageButton)row.FindControl("ib_vehiculo");
                        ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../operacion/Contra_vehiculos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=eo','','status:false;dialogWidth:600px;dialogHeight:300px')");
                    }
                    else
                    {
                        ibuton = (ImageButton)row.FindControl("ib_vehiculo");
                        ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:300px;dialogHeight:260px')");
                    }

                }
            }
        }

      

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

