using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
   public class Proceso_cierreBC
    {
       public DataTable getproceso(string desde, string hasta, string id_cliente, string codigo, string id_ciudad,int tipo,Int32 id_familia)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProceso(desde, hasta, id_cliente, codigo, id_ciudad, tipo, id_familia);
           return lcierre;
       }
       public DataTable getprocesocliente(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo,string familia)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesoCliente(desde, hasta, id_cliente, codigo, id_ciudad, tipo, familia);
           return lcierre;
       }
       public DataTable getprocesoclientePro(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesoClientePro(desde, hasta, id_cliente, codigo, id_ciudad, tipo);
           return lcierre;
       }
       public DataTable getprocesoclienteProSuc(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesoClienteProSuc(desde,hasta, id_cliente, codigo,  id_ciudad,tipo);
           return lcierre;
       }
       public DataTable getprocesoSaldoFinal(string desde, string hasta, string id_cliente, string codigo, string id_ciudad,string tipo,string familia)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesoSaldoFinal(desde, hasta, id_cliente, codigo, id_ciudad,tipo,familia);
           return lcierre;
       }
       public DataTable getprocesoSaldoInicial(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, string tipo, string familia)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesoSaldoinicial(desde, hasta, id_cliente, codigo, id_ciudad, tipo, familia);
           return lcierre;
       }

       public DataTable getprocesoSaldoBaCant(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, string tipo, string familia)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesoSaldoBaCant(desde, hasta, id_cliente, codigo, id_ciudad, tipo, familia);
           return lcierre;
       }

       public DataTable getprocesoFamiliaGestion(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, int tipo)
       {
           DataTable lcierre = new Proceso_cierreDAC().getProcesofamiliaGestion(desde, hasta, id_cliente, codigo, id_ciudad, tipo);
           return lcierre;
       }

       public string NewProcesoTabla(string desde, string hasta, string id_cliente, string codigo, string id_ciudad, string tipo, Int32 id_familia, string cuenta_usuario)
       {
           string add = new Proceso_cierreDAC().NewProcesoTabla(desde,hasta,id_cliente,codigo,id_ciudad,tipo,id_familia,cuenta_usuario);
           return add;
       }


       public DataTable ProcesoCliente(string id_cliente, string codigo, string id_ciudad, string tipo, string familia, string nombre_tabla)
       {
           DataTable lcierre = new Proceso_cierreDAC().procesos_cliente(nombre_tabla,id_cliente, codigo, id_ciudad, familia);
           return lcierre;
       }

       public DataTable procesos_familia(string id_cliente, string codigo, string id_ciudad, string tipo, string familia, string nombre_tabla)
       {
           DataTable lcierre = new Proceso_cierreDAC().procesos_familia(nombre_tabla, id_cliente, codigo, id_ciudad, familia);
           return lcierre;
       }

       public DataTable procesos_producto(string id_cliente, string codigo, string id_ciudad, string tipo, string familia, string nombre_tabla)
       {
           DataTable lcierre = new Proceso_cierreDAC().procesos_producto(nombre_tabla, id_cliente, codigo, id_ciudad, familia);
           return lcierre;
       }

       public DataTable procesos_sucursal(string id_cliente, string codigo, string id_ciudad, string tipo, string familia, string nombre_tabla)
       {
           DataTable lcierre = new Proceso_cierreDAC().procesos_sucursal(nombre_tabla, id_cliente, codigo, id_ciudad, familia);
           return lcierre;
       }


    }
}
