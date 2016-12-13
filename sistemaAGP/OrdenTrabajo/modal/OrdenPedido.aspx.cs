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

namespace sistemaAGP.OrdenTrabajo.modal
{
    public partial class OrdenPedido : System.Web.UI.Page
    {
        public int IdOrdenTrabajoActividad;
        public OrdenTrabajoActividadLog Otra;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            IdOrdenTrabajoActividad = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajoActividad"]));
            hdOrdenTrabajoActividad.Value = IdOrdenTrabajoActividad.ToString(CultureInfo.InvariantCulture);
            Otra =
                new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog
                {
                    IdOrdenTrabajoActividadLog = IdOrdenTrabajoActividad
                });
            hdIdOrdenPedido.Value = Otra.OrdenTrabajo.IdOrden.ToString(CultureInfo.InvariantCulture);

            GetOt(Otra.OrdenTrabajo.IdOrden);         
            LlenarCombo();           
        }




        public void TerminarOrdenTrabajo()
        {
            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = Session["usrname"].ToString()
                    ,
                    IdOrden = Otra.OrdenTrabajo.IdOrden
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 4 }, //4treminada
                Avanza = 1,
                IdOrdenTrabajoActividadLog = new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyidOT(Otra.OrdenTrabajo.IdOrden).IdOrdenTrabajoActividadLog
            });
        }
        

        public void GetOt(int idOt)
        {
            var otra = new OrdenTrabajoBC().GetOrdenTrabajo(idOt);
            lblNumerOrden.Text = otra.NumeroOrden;
            var cliente = new ClienteBC().getcliente(Convert.ToInt16(otra.IdCliente));
            lblCliente.Text = cliente.Persona.Nombre.ToUpper(); ;
            hdIdCliente.Value = cliente.Id_cliente.ToString(CultureInfo.InvariantCulture);
            lblSucursal.Text = otra.IdSucursal == 0 ? "" : new SucursalclienteBC().getSucursal(Convert.ToInt16(otra.IdSucursal)).Nombre.ToUpper();
            lblFormaPago.Text = otra.CodigoFormaPago.Trim() == "0" ? "" : new ParametroBC().getparametro("FOPA", otra.CodigoFormaPago.Trim()).Valoralfanumerico.ToUpper();
            lblFinanciera.Text = otra.CodigoFinanciera.Trim() == "0" ? "" : new BancofinancieraBC().getBancofinanciera(otra.CodigoFinanciera.Trim()).Nombre.ToUpper();
            lblQuienPaga.Text = otra.QuienPaga.Trim() == "0" ? "" : new ParametroBC().getparametro("CAVE", otra.QuienPaga).Valoralfanumerico.ToUpper();
            lblCompraPara.Text = otra.CompraPara.ToUpper();
            lblTerminacionEspecial.Text = otra.TmEspecial.ToUpper();
            lblImpuestoVerde.Text = otra.ImpuestoVerde.Trim() == "0" ? "No se ha especificado." : new ParametroBC().getparametro("IMPV", otra.ImpuestoVerde.Trim()).Valoralfanumerico.ToUpper();
            lblObservacion.Text = otra.Observacion.ToUpper();
            lblFacturaNumero.Text = otra.NumeroFactura;
            hlFactura.NavigateUrl = otra.UrlFactura.Trim();
            lblAbonoCliente.Text = otra.AbonoCliente.ToString(CultureInfo.InvariantCulture);

            lblFacturaFecha.Text = otra.FechaFactura.Trim() == "" ? "" : Convert.ToDateTime(otra.FechaFactura.Trim()).ToShortDateString();
            lblFacturaNeto.Text = otra.FacturaNeto.Trim();
            var adquiriente = new PersonaBC().getpersonabyrut(Convert.ToDouble(otra.RutAdquiriente.Substring(0, otra.RutAdquiriente.Length - 1)));
            lblCompradorRut.Text = adquiriente == null ? "" : adquiriente.Rut + "-" + adquiriente.Dv;
            lblCompradorNombre.Text = adquiriente == null ? "" : adquiriente.Nombre.ToUpper();
            lblCompApepat.Text = adquiriente == null ? "" : adquiriente.Apellido_paterno.Trim().ToUpper();
            lblCompApemat.Text = adquiriente == null ? "" : adquiriente.Apellido_materno.Trim().ToUpper();


            lblVehiculoMarca.Text = otra.VehiculoMarca.Trim() == "0" ? "" : new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(otra.VehiculoMarca.Trim())).Nombre.ToUpper();
            lblVehiculoModelo.Text = otra.VehiculoModelo.Trim().ToUpper();
            lblVehiculoAnio.Text = otra.VehiculoAnio.Trim().ToUpper();
            lblVehiculoCilindrada.Text = otra.VehiculoCilindrada.Trim().ToUpper();
            lblVehiculoNumAsientos.Text = otra.VehiculoAsientos.ToString(CultureInfo.InvariantCulture);
            lblNumeroPuertas.Text = otra.VehiculoPuertas.ToString(CultureInfo.InvariantCulture);
            lblVehiculoPesoBruto.Text = otra.VehiculoPesoBruto.ToString(CultureInfo.InvariantCulture);
            lblVehiculoCarga.Text = otra.VehiculoCarga.ToString(CultureInfo.InvariantCulture);
            lblVehiculoCombustible.Text = otra.VehiculoCombustible.Trim() == "" || otra.VehiculoCombustible.Trim() == "0" ? "" : new ParametroBC().getparametro("COMB", otra.VehiculoCombustible.Trim()).Valoralfanumerico.Trim().ToUpper();
            lblVehiculoColor.Text = otra.VehiculoColor.Trim().ToUpper();
            lblVehiculoMotor.Text = otra.VehiculoMotor.Trim().ToUpper();
            lblPatente.Text = otra.Patente.Trim().ToUpper();

            lblVehiculoChasis.Text = otra.VehiculoChasis.Trim().ToUpper();
            lblVehiculoVin.Text = otra.VehiculoVin.Trim().ToUpper();
            lblVehiculoCit.Text = otra.VehiculoCit.Trim().ToUpper();

        }

        protected void botonReload_Click(object sender, EventArgs e)
        {
            Otra =
               new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog
               {
                   IdOrdenTrabajoActividadLog = Convert.ToInt32(hdOrdenTrabajoActividad.Value)
               });

            LlenarCombo();
            GetOt(Convert.ToInt32(hdIdOrdenPedido.Value));
        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }

        private void LlenarCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("url"));
            dt.Columns.Add(new DataColumn("descripcion"));

            var lista = new OrdenTrabajoBC().GetordenTrabajoProducto(Otra.OrdenTrabajo.IdOrden);
            var listaOk = from x in new OrdenTrabajoBC().GetordenTrabajoProducto(Otra.OrdenTrabajo.IdOrden) where x.Ok select x;

            var final = listaOk as List<OrdenTrabajoTipoOperacion> ?? listaOk.ToList();
            var listaFinal = final.Count() == 1 ? final : lista;

            var todoOk = 0;
            foreach (var ot in listaFinal)
            {
                var dr = dt.NewRow();
                dr["descripcion"] = ot.TipoOperacion.Operacion;
                if (Otra.ActividadDeOrdenTrabajo.IdActividad == 3 && !ot.Ok && Otra.Usuario.UserName.Trim() == Session["usrname"].ToString().Trim()) //si la actividad es lista para trabajar se asignan las url de las pantallas a los productos
                {
                    dr["url"] = "../" + ot.TipoOperacion.Url_operacion + "fDded4a93u2d" + "&id_cliente=" +
                    FuncionGlobal.FuctionEncriptar(hdIdCliente.Value) + "&ventatipo=&patente=" + "&solo_lectura=" +
                    FuncionGlobal.FuctionEncriptar("0") + "&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar(Otra.OrdenTrabajo.IdOrden.ToString(CultureInfo.InvariantCulture));
                }

                else
                {
                    dr["url"] = "";
                }

                if (ot.Ok)
                {
                    todoOk++;
                    imgOk.Src = "../../imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png";
                    lblIdAgp.Text = "Producto asociado: " + ot.TipoOperacion.Operacion.ToUpper() + ". Nº AGP" + ot.IdSolicitud;
                    dlProductos.Enabled = false;
                }

                dt.Rows.Add(dr);

            }
            
            dlProductos.DataSource = dt;
            dlProductos.DataValueField = "url";
            dlProductos.DataTextField = "descripcion";           
            dlProductos.DataBind();
            lnk.HRef = dlProductos.SelectedValue;


            if (todoOk > 0 && Otra.ActividadDeOrdenTrabajo.IdActividad == 3)
            {
                TerminarOrdenTrabajo();
            }
   
        }

        protected void dlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnk.HRef = dlProductos.SelectedValue;
        }




    }
}