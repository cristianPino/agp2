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
using System.Drawing;

namespace sistemaAGP
{
    public partial class mOperacion_estado : System.Web.UI.Page
    {
        private string id_cliente;
        private string id_solicitud;
        private string tipo;
        private string nombre_operacion;


        protected void Page_Load(object sender, EventArgs e)
        {

            id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
            tipo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["tipo"].ToString());
            nombre_operacion = Request.QueryString["nombre_estado"].ToString();
            id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
              
            if (!IsPostBack)
            {

                
                this.lbl_solicitud.Text = id_solicitud;
                
                this.lbl_tipo.Text = nombre_operacion;
                getestado(tipo);
                getestadowork();
                
            }

        }

        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {
                add_estado();
            }


        }

        private void getestado(string tipo)
        {
            EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();

            mEstadotipooperacion.Codigo = "0";
            mEstadotipooperacion.Descripcion = "Seleccionar";

            List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionBC().getEstadoByTipooperacion(tipo);


            lEstadotipooperacion.Add(mEstadotipooperacion);

            dl_estado.DataSource = lEstadotipooperacion;
            dl_estado.DataValueField = "codigo_estado";
            dl_estado.DataTextField = "descripcion";
            dl_estado.DataBind();
            dl_estado.SelectedValue = "0";
            
            return;
          
           
        }

        private void add_estado()
        {
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            string add = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(this.id_solicitud), Convert.ToInt32( this.dl_estado.SelectedValue), this.txt_obs.Text, (string)(Session["usrname"]));

            if (add != "OK")
            {
                FuncionGlobal.alerta_updatepanel(add, Page, up);
                return;
            }

            FuncionGlobal.alerta_updatepanel("ESTADO ACTUALIZADO CON EXITO", Page, up);
            //FuncionGlobal.alerta("ESTADO ACTUALIZADO CON EXITO", this.Page);

            

            getestadowork();
            
            
            return;

        }

        private Boolean valida_ingreso()
        {
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

            if (tipo == "INMA")
            {
                EstadoOperacion MESTADO = new EstadooperacionBC().getEstadobycodigoestado(Convert.ToInt32(id_solicitud), Convert.ToInt32(this.dl_estado.SelectedValue));
                if (MESTADO.Estado_operacion != null)
                {
                    FuncionGlobal.alerta_updatepanel("ESTA OPERACION YA HA PASADO POR EL ESTADO SELECCIONADO", Page, up);
                    return false;
                }
            }
          
                if (this.txt_obs.Text == "")
                {
                    FuncionGlobal.alerta_updatepanel("DEBE INGRESAR LA OBSERVACION", Page, up);
                    //FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                    return false;

                }
            
            return true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>self.close();</script>");
        }

        protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_obs_TextChanged(object sender, EventArgs e)
        {

        }
        protected void getestadowork()
        {
            List<EstadoOperacion> lEstadooperacion = new EstadooperacionBC().getEstadoByoperacion(Convert.ToInt32(id_solicitud), (string)(Session["usrname"]));
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_estado"));
            dt.Columns.Add(new DataColumn("activo"));
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("cuenta_usuario"));
            dt.Columns.Add(new DataColumn("nombre_usuario"));
            dt.Columns.Add(new DataColumn("observacion"));
            dt.Columns.Add(new DataColumn("contador"));
            dt.Columns.Add(new DataColumn("semaforo"));

            foreach (EstadoOperacion mestadooperacion in lEstadooperacion)
            {
                DataRow dr = dt.NewRow();
                dr["id_estado"] = mestadooperacion.Id_estado.ToString().Trim();
                dr["activo"] = mestadooperacion.Activo.ToString().Trim();
                dr["estado"] = mestadooperacion.Estado_operacion.Descripcion;
                dr["fecha"] = mestadooperacion.Fecha_hora;
                dr["cuenta_usuario"] = mestadooperacion.Usuario.UserName;
                dr["nombre_usuario"] = mestadooperacion.Usuario.Nombre;
                dr["observacion"] = mestadooperacion.Observacion;
                dr["semaforo"] = mestadooperacion.Semaforo.Trim();
                dr["contador"] = mestadooperacion.Contador.ToString().Trim();

                dt.Rows.Add(dr);
            }
            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 id_estado = Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString());
                Boolean activo = Convert.ToBoolean(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());

                TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

                if (activo == false)
                {
                    e.Row.BackColor = Color.LightBlue;
                }
                HyperLink but1 = (HyperLink)e.Row.Cells[0].Controls[0];
                but1.Attributes.Add("onclick", "javascript:window.showModalDialog('../operacion/SubEstados.aspx?id_solicitud=" + id_solicitud + "&id_estado=" + id_estado + "','_blank','" + op.Tamano + "')");


            }
        }



    }
}
