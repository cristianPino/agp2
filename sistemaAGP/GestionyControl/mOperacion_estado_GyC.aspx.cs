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
    public partial class mOperacion_estado_GyC : System.Web.UI.Page
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

            string add = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(this.id_solicitud), Convert.ToInt32( this.dl_estado.SelectedValue), this.txt_obs.Text, (string)(Session["usrname"]));

            if (Panel1.Visible == true & this.txt_fecha.Text != "" & this.txt_hora.Text != "")
            {
                string ad = new ProgramacionGCBC().add_programacioGC(Convert.ToInt32(id_solicitud), Convert.ToDateTime(this.txt_fecha.Text), this.txt_hora.Text);
            }

            FuncionGlobal.alerta("ESTADO ACTUALIZADO CON EXITO", this.Page);

            getestadowork();
            
            
            return;

        }

        private Boolean valida_ingreso()
        {

            if (this.txt_obs.Text == "")
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
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
            if (this.dl_estado.SelectedValue == "0")
            {
                this.Panel1.Visible = false;
            }
            else
            {
                EstadoTipoOperacion mestado = new EstadotipooperacionBC().getestadobycodigoestado(Convert.ToInt32(this.dl_estado.SelectedValue.ToString()));
                string llamada = mestado.Llamada.ToString();
                if (llamada.ToUpper() == "FALSE")
                {
                    this.Panel1.Visible = false;
                }
                else
                { 
                        this.Panel1.Visible = true;
                }
            }

        }
        protected void txt_obs_TextChanged(object sender, EventArgs e)
        {

        }
        protected void getestadowork()
        {

            List<EstadoOperacion> lEstadooperacion = new EstadooperacionBC().getEstadoByoperacion(Convert.ToInt32(id_solicitud),
                                                        (string)(Session["usrname"]));


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("estado"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("cuenta_usuario"));
            dt.Columns.Add(new DataColumn("nombre_usuario"));
            dt.Columns.Add(new DataColumn("observacion"));
        
             foreach (EstadoOperacion mestadooperacion in lEstadooperacion)
            {
                DataRow dr = dt.NewRow();

                dr["estado"] = mestadooperacion.Estado_operacion.Descripcion;
                dr["fecha"] = mestadooperacion.Fecha_hora;
                dr["cuenta_usuario"] = mestadooperacion.Usuario.UserName;
                dr["nombre_usuario"] = mestadooperacion.Usuario.Nombre;
                dr["observacion"] = mestadooperacion.Observacion;
              

                 dt.Rows.Add(dr);

            }


             this.gr_dato.DataSource = dt; 
            this.gr_dato.DataBind();

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txt_fecha_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_hora_TextChanged(object sender, EventArgs e)
        {

        }

       



    }
}
