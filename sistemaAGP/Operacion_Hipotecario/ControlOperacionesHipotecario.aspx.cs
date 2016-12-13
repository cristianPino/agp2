using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;
using sistemaAGP.controles;

namespace sistemaAGP.Operacion_Hipotecario
{
    public partial class ControlOperacionesHipotecario : System.Web.UI.Page
    {
        public string Tab;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (IsPostBack) return;
          
            FuncionGlobal.combocliente(dl_cliente); 
            //FuncionGlobal.comboEstadoByFamilia(dpl_estado, 22);
            FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente); 
            FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
            FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dlFamilia);
            FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dlFamilia.SelectedValue));
            FuncionGlobal.comboparametro(dl_credito, "TICRE");
            FuncionGlobal.comboregion(dl_region,"CH");
            FuncionGlobal.comboparametro(dlTipoPropiedad, "TIPROP");
            FuncionGlobal.comboparametro(dlTipoSemaforo, "TSEMH");
            FuncionGlobal.combousuariobyperfil(dl_ejecutivo, "ABH");
            txt_desde.Text = "01/10/2014";
            txt_hasta.Text = DateTime.Today.ToShortDateString();

        }
        
        public void GetOperaciones(int semaforo, int semaforoOperacion)
        {   
            var h = new Hipotecario();
            var o = new Operacion();
            var to = new TipoOperacion();
            var cli = new Cliente();
            var sucu = new SucursalCliente();
            var eje = new Usuario();
            var vend = new Persona();
            var ciu = new Ciudad();
            var reg = new Region();
 
            o.Id_solicitud = txt_idSolicitud.Text == "" ? 0 : Convert.ToInt32(txt_idSolicitud.Text.Trim());
            to.Codigo = dl_producto.SelectedValue;
            o.Tipo_operacion = to;
            cli.Id_cliente = dl_cliente.SelectedValue == ""
                                                 ? Convert.ToInt16(0)
                                                 : Convert.ToInt16(dl_cliente.SelectedValue);
            o.Cliente = cli;
            sucu.Id_sucursal = dl_sucursal.SelectedValue == ""
                                                   ? Convert.ToInt16(0)
                                                   : Convert.ToInt16(dl_sucursal.SelectedValue);
            o.Sucursal = sucu;
            o.Numero_cliente = txt_numCliente.Text.Trim();
            o.Id_estado = dpl_estado.SelectedValue == "" ? 0 : Convert.ToInt32(dpl_estado.SelectedValue);
            eje.UserName = dl_ejecutivo.SelectedValue== "" ? "0" : dl_ejecutivo.SelectedValue;
            h.EjecutivoIngreso = eje;
            h.FechaDesde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(txt_desde.Text.Trim()));
            h.FechaHasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
            
            vend.Rut = txtRutCliBanco.Text.Trim() == "" ? 0 : Convert.ToInt32(txtRutCliBanco.Text);
            h.Vendedor = vend;
            h.TipoPropiedad = dlTipoPropiedad.SelectedValue;
            h.IdComuna = 0;
            h.TipoCredito = dl_credito.SelectedValue;
            h.SemaforoBusqueda = semaforo;
            h.SemaforoOperacion = semaforoOperacion;
            h.CuentaUsuarioSession = Session["usrname"].ToString();

            reg.Id_region = Convert.ToInt32(dl_region.SelectedValue?? "0");
            ciu.Id_Ciudad = Convert.ToInt32(dl_provincia.SelectedValue==""?"0":dl_provincia.SelectedValue);
            h.Ciudad = ciu;
            h.Region = reg;
            h.Operacion = o;


           var busqueda = Convert.ToInt32(Hidden1.Value);  
           var loperacion = new HipotecarioBC().GetAllOperaciones(h,busqueda);
            divBotones.Visible = loperacion.Count > 0;
           switch (busqueda)
            {
                case 0: SinSeleccionar.GetOperaciones(loperacion, Convert.ToBoolean(busqueda));
                    SinSeleccionar.EnableViewState = true;
                    break;
                case 1: MisPendientes.GetOperaciones(loperacion, Convert.ToBoolean(busqueda));
                    MisPendientes.EnableViewState = true;
                    break;

            } 
          
        }

      
        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {   
              GetOperaciones(0,0);
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbycliente(dl_sucursal,Convert.ToInt16(dl_cliente.SelectedValue));
            FuncionGlobal.combofamilia_cliente(dlFamilia,Convert.ToInt16(dl_cliente.SelectedValue));
           
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboProductobyfamilia(dl_producto, Convert.ToInt16(dlFamilia.SelectedValue));
            FuncionGlobal.comboEstadoByFamilia(this.dpl_estado, Convert.ToInt32(this.dlFamilia.SelectedValue));
        }

        protected void ibVerde_Click(object sender, ImageClickEventArgs e)
        {
            var semaforoEstado = 0;
            var semaforoOperacion = 0;
            if (dlTipoSemaforo.SelectedValue == "SEMES")
            {
                semaforoEstado = 1;
                semaforoOperacion = 0;
            }
            else if (dlTipoSemaforo.SelectedValue == "SEMOP")
            {
                semaforoEstado = 0;
                semaforoOperacion = 1;
            }
            GetOperaciones(semaforoEstado, semaforoOperacion);
        }

        protected void ibAmarillo_Click(object sender, ImageClickEventArgs e)
        {
            var semaforoEstado = 0;
            var semaforoOperacion = 0;
            switch (dlTipoSemaforo.SelectedValue)
            {
                case "SEMES":
                    semaforoEstado = 2;
                    semaforoOperacion = 0;
                    break;
                case "SEMOP":
                    semaforoEstado = 0;
                    semaforoOperacion = 2;
                    break;
            }
            GetOperaciones(semaforoEstado, semaforoOperacion);  
        }

        protected void ibRojo_Click(object sender, ImageClickEventArgs e)
        {
            var semaforoEstado = 0;
            var semaforoOperacion = 0;
            switch (dlTipoSemaforo.SelectedValue)
            {
                case "SEMES":
                    semaforoEstado = 3;
                    semaforoOperacion = 0;
                    break;
                case "SEMOP":
                    semaforoEstado = 0;
                    semaforoOperacion = 3;
                    break;
            }
            GetOperaciones(semaforoEstado, semaforoOperacion);
        }

   
        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_provincia, Convert.ToInt16(dl_region.SelectedValue));
        }

        protected void dl_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(dl_provincia.SelectedValue));
        }

        protected void dlTipoSemaforo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tdSemaforo.Visible = dlTipoSemaforo.SelectedValue != "0";
        }

        protected void imAvanzar_Click(object sender, ImageClickEventArgs e)
        {
             var seleccionadas = SinSeleccionar.Seleccionar();
             GetOperaciones(0, 0);
             Mensaje("Se han seleccionado "+seleccionadas + " operaciones");
        }
        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje,Page,upGrilla);
        }

        

      

       



    }
}