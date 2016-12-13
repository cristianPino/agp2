using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class OrdenTrabajo
    {
        public bool ConCreditoAmicar { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; } 
        public int IdOrden { get; set; } 
        public int IdCliente { get; set; }
        public int RutEmisor { get; set; }
        public string VinCorto { get; set; } //usado para crear la clave única número de nota pedido + últimos 6 caracteres del vin.
        public string RutAdquiriente { get; set; }
        public string DvAdquiriente { get; set; }
        public string NombreAdquiriente { get; set; }
        public string ApepatAdquiriente { get; set; }
        public string ApematAdquiriente { get; set; }
        public int AbonoCliente { get; set; }

        public string NumeroFactura { get; set; }
        public string QuienPaga { get; set; }
        public string Observacion { get; set; }
        public string TmEspecial { get; set; }
        public string FechaIngreso { get; set; }
        public string  CuentaUsuario { get; set; }
        public Usuario UsuarioIngreso { get; set; }
        public string NumeroOrden { get; set; }
        public string UrlFactura { get; set; }
        public bool Activo { get; set; }
        public Cliente Cliente { get; set; }
        public string CodigoFinanciera { get; set; }
        public string CodigoFormaPago { get; set; }
        public string FormaPago { get; set; }
        public string CompraPara { get; set; }
        public string ImpuestoVerde { get; set; }
        public int IdSucursal { get; set; }
        public SucursalCliente Sucursal { get; set; }  

        public string FacturaNeto { get; set; }
        public string FechaFactura { get; set; }
        public string VehiculoMarca { get; set; }
        public string VehiculoModelo { get; set; } 
       
        public string VehiculoAnio { get; set; } 
        public string VehiculoCilindrada { get; set; } 
        public int VehiculoPuertas { get; set; } 
        public int VehiculoAsientos { get; set; } 
        public int VehiculoPesoBruto { get; set; } 
        public int VehiculoCarga { get; set; } 
        public string VehiculoCombustible { get; set; } 
        public string VehiculoColor { get; set; } 
        public string VehiculoMotor { get; set; } 
        public string VehiculoVin { get; set; }
        public string VehiculoChasis { get; set; }
        public string VehiculoCit { get; set; }
       

        public string ClienteNombre { get; set; }
        public string SucursalNombre { get; set; } 
        public string UsuarioIngresoNombre { get; set; }
        public string UsuarioIngresoCuenta { get; set; }

        public bool TieneCompraPara { get; set; }
        public string CompraParaNombre { get; set; }
        public int CompraParaRut { get; set; }
        public string CompraParaDv { get; set; }
        public string Patente { get; set; }
        public int IdSolicitud { get; set; }

        public string Usuario_cliente { get; set; }
    }
}
