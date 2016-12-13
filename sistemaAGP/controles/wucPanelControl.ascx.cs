using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
    public partial class wucPanelControl : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Busca_Operacion(int id_solicitud)
        {
            Operacion moperacion = new OperacionBC().getoperacion(id_solicitud);
            Familia_Producto mfamilia = new Familia_productoBC().getfamiliabycodigo(moperacion.Tipo_operacion.Codigo);

            this.lbl_operacion.Text = id_solicitud.ToString();
            this.lbl_cliente.Text = moperacion.Cliente.Persona.Nombre;

            if (moperacion.Numero_factura != 0)
            {
                lbl_nfactura.Text = moperacion.Numero_factura.ToString();
            }
            else
            {
                lbl_nfactura.Text = "";
                lbl_patente.Text = moperacion.Patente.ToString();
                lbl_ncliente.Text = moperacion.Numero_cliente.ToString();
            }

            lbl_producto.Text = moperacion.Tipo_operacion.Operacion.ToString();
            lbl_sucursal.Text = moperacion.Sucursal.Nombre.ToUpper().Trim();
            
            if (moperacion.Adquiriente != null)
            {
                lbl_rutadqui.Text = moperacion.Adquiriente.Rut.ToString();
                lbl_nomadqui.Text = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
            }
            else
            {
                lbl_rutadqui.Text = "0";
                lbl_nomadqui.Text = "Sin Adquiriente";
            }

            lbl_nrepertorio.Text = (moperacion.N_repertorio == 0) ? "" : moperacion.N_repertorio.ToString("N0"); ;

            lnk_nomina.NavigateUrl = "nominabyoperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim());
            lnk_cargar.NavigateUrl = "../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) +  "&tipo=" + moperacion.Tipo_operacion.Codigo.Trim();
            lnk_cdigital.NavigateUrl = "../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&origen=pc";

            lbl_dias.Text = moperacion.Contador.ToString().Trim() + "/" + moperacion.Total_dias.ToString().Trim();
            lbl_estadoactual.Text = moperacion.Estado;

            if ((string)(Session["usrname"].ToString().Trim()) == "153944601" || (string)(Session["usrname"].ToString().Trim()) == "81947139" && mfamilia.Id_familia == 19)
            {
                lnk_estado.NavigateUrl = "../Retiro_Carpeta/mOperacion_estadoRe.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(moperacion.Tipo_operacion.Codigo.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(moperacion.Cliente.Id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&nombre_estado=" + moperacion.Tipo_operacion.Operacion.ToString();
            }
            else
            {
                lnk_estado.NavigateUrl = "mOperacion_estado.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(moperacion.Tipo_operacion.Codigo.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(moperacion.Cliente.Id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&nombre_estado=" + moperacion.Tipo_operacion.Operacion.ToString();
            }

            lnk_estado.ImageUrl = moperacion.Semaforo.Trim();
            
            lnk_poliza.NavigateUrl = "../administracion/mPoliza.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(moperacion.Cliente.Id_cliente.ToString());
            lnk_solicrc.NavigateUrl = "solicitudrc_operacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=" + moperacion.Tipo_operacion.Codigo.Trim();

            TipoOperacion mtipo = new TipooperacionBC().getcomprobantebyoperacion(moperacion.Id_solicitud);

            GastosComunes gstco = new GastosComunesBC().getGastos_Cero(moperacion.Id_solicitud);

            if (gstco.Comprobar == false)
            {
                lnk_comgasto.NavigateUrl = "gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim());
            }
            else
            {
                lnk_comgasto.NavigateUrl = mtipo.Comprobante + "?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString());
            }
           
            lnk_gasto.NavigateUrl = "gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim());
            lnk_ingreso.NavigateUrl = "gastomovimientocuenta.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&tipo=I";

            if (moperacion.Cliente.Id_cliente.ToString() != "DOCUMENTO HIPOTECARIO")
                lnk_contrato.NavigateUrl = "../operacion/Contra_vehiculos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());
            else
                lnk_contrato.NavigateUrl = "../reportes/contratos_rpt.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString());

            lbl_totalgastos.Text = moperacion.Total_gasto.ToString();
            lbl_totalpagos.Text = moperacion.Total_ingreso.ToString();
            lbl_saldo.Text = (moperacion.Total_ingreso - moperacion.Total_gasto).ToString();
            lbl_facturaemitida.Text = moperacion.Factura_emitida.ToString();

            lnk_comingreso.NavigateUrl = "../reportes/view_comprobante_ingreso.aspx" + "?id_solicitud=" + FuncionGlobal.FuctionEncriptar(moperacion.Id_solicitud.ToString().Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString());
        
        }

        protected void bt_eliminar_Click1(object sender, ImageClickEventArgs e)
        {

        }
    }
}