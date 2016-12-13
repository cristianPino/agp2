using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Hipotecario
    {
        public Operacion Operacion { get; set; }
        public byte SoloLectura { get; set; }
        public string CuentaUsuarioSession { get; set; }
        public string SemaforoImagen { get; set; }
        public int SemaforoBusqueda { get; set; } 
        public Usuario EjecutivoIngreso { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public Cliente Cliente { get; set; }
        public SucursalCliente Sucursal { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string FechaIngreso { get; set; }
        public Usuario UsuarioSession { get; set; }
        public Comuna Comuna { get; set; }
        public int ContadorEtapa { get; set; }
        public int ContadorOperacion { get; set; }
        public string Estado { get; set; }
        public string DescripcionTipoOperacion { get; set; }
        public int Sla { get; set; }
        public Ciudad Ciudad { get; set; }
        public Region Region { get; set; }
        public int IdEstado { get; set; }
        public int SemaforoOperacion { get; set; }
        public string SemaforoOperacionImagen { get; set; }
        public Persona Comprador { get; set; }    
        public Persona Vendedor { get; set; } 
        public string DescripcionDeslindes { get; set; }
        public string Rol { get; set; }             
        public Int32 PrecioVivienda { get; set; } 
        public Int32 MontoCredito{ get; set; }      
        public string TipoCredito { get; set; }     
        public string TipoPropiedad { get; set; }   
        public string InscripcionFojas{ get; set; }
        public string InscripcionNumero { get; set; }
        public int InscripcionAno{ get; set; } 
        public string AnteriorFojas{ get; set; } 
        public string AnteriorNumero  { get; set; } 
        public int AnteriorAno { get; set; }        
        public string VctoPrimeraCuota { get; set; }
        public Int32 IdComuna { get; set; }      
        public string Direccion { get; set; }    
        public string Numero { get; set; }       
        public string Complemento { get; set; }  
        public string NumeroInterno { get; set; }
        public Int32 PlazoAnos { get; set; } 
        public Persona RutAcreedor { get; set; } 
        public Int32 Tasacion { get; set; }  
        public Usuario Ejecutivo{ get; set; } 
        public string FinalNumero { get; set; } 
        public string FinalConservador { get; set; } 
        public string FinalFojas { get; set; }  
        public string FinalCaratula { get; set; }   
        public int FinalAno { get; set; } 
        public string MesesGracia { get; set; }
        public Int32 ValorComercial  { get; set; }
        public string SubProductoCredito { get; set; }
        public string NumeroCredito { get; set; }
        public string Tasa { get; set; }
        public string Pie { get; set; }
        public string MesCarenciaUno { get; set; }
        public string MesCarenciaDos { get; set; }
        public byte CodeudorConSeguro { get; set; }
        public byte SeguroInvalidez { get; set; }
        public byte SeguroCesantia { get; set; }
        public string CodeudorPorcentaje { get; set; }
        public byte Dfl2 { get; set; }
        public string TipoUbicacion { get; set; }
        public byte ViviendaSocial { get; set; }
        public string TipoTransferencia { get; set; }
        public string TipoHipoteca { get; set; }
        public string FechaMemo { get; set; }
        public int OrdenEstadoActual { get; set; }

        //nuevo...para nuevo sistema hipotecario
        public int IdClienteAgp { get; set; }
        public string NombreClienteAgp { get; set; }

        public string RutComprador { get; set; }
        public string NombreComprador { get; set; }

        public int IdSolicitud { get; set; }
        public string FechaSolicitud { get; set; }
        public string FechaInicioEstado { get; set; }
        public string CuentaUsuarioIngreso { get; set; }
        public string NombreUsuarioIngreso { get; set; }
        public string EstadoDescripcion { get; set; }
        public string Modal { get; set; }
        public string TotalGastos { get; set; }
        public string TotalIngreso { get; set; }
        public int NumeroFactura { get; set; }

        //para la carga de Excel
        public int ExcelIdCliente { get; set; }
        public string ExcelQuery { get; set; }
        public string ExcelTipo { get; set; }














    }
}
