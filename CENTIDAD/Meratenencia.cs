using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public class Meratenencia
    {
        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
       private string titulo_mera;

       public string Titulo_mera
       {
           get { return titulo_mera; }
           set { titulo_mera = value; }
       }
       private string calidad_mero;

       public string Calidad_mero
       {
           get { return calidad_mero; }
           set { calidad_mero = value; }
       }
       private string tipo_doc;

       public string Tipo_doc
       {
           get { return tipo_doc; }
           set { tipo_doc = value; }
       }
       private string naturaleza_doc;

       public string Naturaleza_doc
       {
           get { return naturaleza_doc; }
           set { naturaleza_doc = value; }
       }
       private string n_doc;

       public string N_doc
       {
           get { return n_doc; }
           set { n_doc = value; }
       }
       private DateTime fecha_doc;

       public DateTime Fecha_doc
       {
           get { return fecha_doc; }
           set { fecha_doc = value; }
       }
       private string lugar_doc;

       public string Lugar_doc
       {
           get { return lugar_doc; }
           set { lugar_doc = value; }
       }
       private string autorizacion;

       public string Autorizacion
       {
           get { return autorizacion; }
           set { autorizacion = value; }
       }
       private string tribunal;

       public string Tribunal
       {
           get { return tribunal; }
           set { tribunal = value; }
       }
       private Int32 anno_causa;

       public Int32 Anno_causa
       {
           get { return anno_causa; }
           set { anno_causa = value; }
       }

       private Int32 rut_comprador;

       public Int32 Rut_comprador
       {
           get { return rut_comprador; }
           set { rut_comprador = value; }
       }
       private Int32 rut_vendedor;

       public Int32 Rut_vendedor
       {
           get { return rut_vendedor; }
           set { rut_vendedor = value; }
       }

       private string n_bien;

       public string N_bien
       {
           get { return n_bien; }
           set { n_bien = value; }
       }
    }
}
