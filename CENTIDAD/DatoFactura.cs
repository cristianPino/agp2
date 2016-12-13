using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class DatoFactura
    {
        public int IdCliente { get; set; }
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Giro { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Ciudad { get; set; }
        public string FechaFactura { get; set; }
        public string NumeroFactura { get; set; }
        public string SucursalDestino { get; set; }
        public string FormaPago { get; set; }
        public string NotaPedido { get; set; }
        public string TipoVehiculo { get; set; }
        public string MarcaVehiculo { get; set; }
        public string AnioComercial { get; set; }
        public string Modelo { get; set; }
        public string Cit { get; set; }
        public string Color { get; set; }
        public string Cilindrada { get; set; }
        public string Puertas { get; set; }
        public string Asiento { get; set; }
        public string Chassis { get; set; }
        public string Motor { get; set; }
        public string Combustible { get; set; }
        public string PesoBruto { get; set; }
        public string ValorNeto { get; set; }
        public string CuentaUsuario { get; set; }
        public bool Transferencia { get; set; }
        public bool TieneCompraPara { get; set; }
        public string CompraParaNombre { get; set; }
        public int CompraParaRut { get; set; }
        public string CompraParaDv { get; set; }
        public string CompraParaDescripcion { get; set; }
        public string Patente { get; set; }
        public string Grupo { get; set; }
        public string CuentaEjecutivo { get; set; }
        public int idSucursal { get; set;}
    }
}
