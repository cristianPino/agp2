using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class FacturaBC
    {
        public string add_factura(int id_nomina, Int32 folio, Int32 n_factura_agp, string fecha_factura_agp, string cuenta_usuario)
        {


            string add = new FacturaDAC().add_factura(id_nomina, folio, n_factura_agp, fecha_factura_agp, cuenta_usuario);
            return add;

        }
        public string add_factura_oper(int id_solicitud, Int32 n_factura_agp, string fecha_factura_agp, string cuenta_usuario)
        {


            string add = new FacturaDAC().add_factura_oper(id_solicitud, n_factura_agp, fecha_factura_agp, cuenta_usuario);
            return add;

        }
        public string add_tabla_factura(Int32 n_factura_agp, string fecha_factura_agp, Int32 total_neto, string orden_compra, 
                                            Int32 id_cliente, string observacion, string cuenta_usuario,int rut_tercero)
        {


            string add = new FacturaDAC().add_tabla_factura(n_factura_agp, fecha_factura_agp, total_neto, orden_compra, id_cliente, observacion, cuenta_usuario,rut_tercero);
            return add;

        }
        public string del_factura(int id_solicitud)
        {


            string add = new FacturaDAC().del_factura(id_solicitud);
            return add;

        }

        public List<Factura> getfacturas(Int32 id_nomina, Int32 folio, Int32 id_cliente, Int32 numero_factura,Int32 id_familia)
        {
            return new FacturaDAC().GetOperacion_Fac(id_nomina, folio, id_cliente, numero_factura, id_familia);
        }
        public List<Factura> getfacturasbyoperacion(Int32 id_solicitud, Int32 id_familia)
        {
            return new FacturaDAC().GetOperacion_Fac_operacion(id_solicitud,id_familia);
        }
        public List<Factura> getcobranza(Int32 id_cliente, Int32 numero_factura)
        {
            return new FacturaDAC().getCobranza(id_cliente, numero_factura);
        }

        public string add_factura_oper_del(int id_solicitud)
        {


            string add = new FacturaDAC().add_factura_oper_del(id_solicitud);
            return add;

        }

        public string add_cambia_folio(int folio)
        {


            string add = new FacturaDAC().add_cambia_folio(folio);
            return add;

        }


        public string act_factura_del(int folio,int id_nomina)
        {


            string add = new FacturaDAC().act_factura_del(folio,id_nomina);
            return add;

        }

    }
}
