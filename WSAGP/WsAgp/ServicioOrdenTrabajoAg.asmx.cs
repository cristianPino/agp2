using System;     
using System.Globalization;   
using System.Web.Services; 
using System.Xml.Linq;
using CENTIDAD; 
using CNEGOCIO;

namespace WsAgp
{
    /// <summary>
    /// Descripción: Llena las notas de pedido con datos de la factura y cambia de estado.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    public class ServicioOrdenTrabajoAg : WebService
    {

        [WebMethod()]
        public RespuestaAgp AddOrdenPedido(string texto)
        {
            try
            {
                var xDoc = XElement.Parse(texto); 
                var otr = new OrdenTrabajo {CuentaUsuario = "wsag"};
                var notaPedido = xDoc.Descendants("NOTA_PEDIDO");
                foreach (var np in notaPedido)
                {
                    //otr.NumeroOrden = np.Element("NUMERO").Value;
                    var numeroNota = np.Element("NUMERO").Value;
                    numeroNota = numeroNota.Replace("V", "0");
                    otr.NumeroOrden = Convert.ToInt32(numeroNota).ToString(CultureInfo.InvariantCulture);
                    otr.VinCorto = np.Element("VINCORTO").Value;
                }
                var datoVehiculo = xDoc.Descendants("DATOS_VEHICULO");
                foreach (var np in datoVehiculo)
                {
                    otr.VehiculoMarca = np.Element("MARCA").Value;
                    otr.VehiculoModelo = np.Element("MODELO").Value;
                    otr.VehiculoChasis = np.Element("CHASIS_VIN").Value;
                    otr.VehiculoVin = np.Element("CHASIS_VIN").Value;
                    otr.VehiculoMotor = np.Element("MOTOR").Value;
                    otr.VehiculoAnio = np.Element("ANIO").Value;
                    otr.VehiculoCilindrada = np.Element("CILINDRADA").Value;
                    otr.VehiculoColor = np.Element("COLOR").Value;
                    otr.VehiculoCarga = Convert.ToInt32(np.Element("CARGA").Value);
                    otr.VehiculoPesoBruto = Convert.ToInt32(np.Element("PESO_BRUTO").Value);
                    otr.VehiculoCombustible = np.Element("COMBUSTIBLE").Value;
                    otr.VehiculoPuertas = Convert.ToInt32(np.Element("NUMERO_PUERTA").Value);
                    otr.VehiculoAsientos = Convert.ToInt32(np.Element("NUMERO_ASIENTO").Value);
                }

                var datoFactura = xDoc.Descendants("DATOS_FACTURA");
                foreach (var np in datoFactura)
                {
                    var numFactura = np.Element("NUMERO_FACTURA").Value;
                    if (numFactura.Trim() == "")
                    {
                        throw new ArgumentException("Debe contener número de factura.");
                    }
                    if (numFactura.Trim() != "0")
                    {
                        numFactura = numFactura.Substring(numFactura.Length - 6, 6);
                    }
                    int factura;
                    var canConvert = int.TryParse(numFactura, out factura);
                    if (canConvert)
                    {
                        otr.NumeroFactura = Convert.ToInt32(numFactura.Trim()).ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        throw new ArgumentException("El Numero de factura debe ser numérico.");
                    }

                    var fecha = np.Element("FECHA_FACTURACION").Value;
                    if (fecha.Trim() == "")
                    {
                        throw new ArgumentException("Debe contener fecha de factura.");
                    }
                    otr.FechaFactura = fecha;


                    otr.UrlFactura = np.Element("URL_FACTURA").Value;
                    var neto = np.Element("NETO").Value;
                    neto = neto.Substring(0, neto.Length - 3);
                    otr.FacturaNeto = neto;
                }

                var datoAdquiriente = xDoc.Descendants("DATOS_ADQUIRIENTE");
                foreach (var np in datoAdquiriente)
                {
                    var rut = 0;
                    var canConvert = int.TryParse(np.Element("RUT").Value.Trim(), out rut);
                    if (canConvert)
                    {
                        otr.RutAdquiriente = np.Element("RUT").Value;
                    }
                    else
                    {
                        throw new ArgumentException("El Rut debe ser numérico");
                    }

                    otr.DvAdquiriente = np.Element("DV").Value;
                    otr.NombreAdquiriente = np.Element("NOMBRE").Value;
                    otr.ApepatAdquiriente = np.Element("APELLIDO_PATERNO").Value;
                    otr.ApematAdquiriente = np.Element("APELLIDO_MATERNO").Value;
                    otr.Nacionalidad = np.Element("NACIONALIDAD").Value;
                    otr.Sexo = np.Element("SEXO").Value == "" ? "0" : np.Element("SEXO").Value;
                }

                var respuesta = new OrdenTrabajoBC().AddOrdenTrabajoWebservice(otr);
                return respuesta;
            }
            catch (Exception ex)
            {
                return new RespuestaAgp { IdRespuesta = -1, MensajeError = ex.Message };
            }
        }



    }
}
