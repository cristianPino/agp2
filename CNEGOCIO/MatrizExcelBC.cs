using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CACCESO;

namespace CNEGOCIO
{
    public class MatrizExcelBC
    {

        public string GetReportePreticket(string usuario, DataTable dt)
        {
            return new MatrizExcelDAC().GetReportePreticket(usuario, dt);
        }


        public string getnominamatrizgasto(Int16 id_nomina, Int32 folio_nomina, Int32 id_familia, string titulo)
        {

            string add = new MatrizExcelDAC().getnominamatrizgasto(id_nomina, folio_nomina, id_familia, titulo);

            return add;
        }

        public string getMatrizReporteCobranza(string usuario, string tipo)
        {

            string add = new MatrizExcelDAC().getReporteCobranzaa(usuario, tipo);

            return add;
        }
        public string getMatrizRetiroCarpeta(string desde,string hasta, string usuario)
        {

            string add = new MatrizExcelDAC().getMatrizRetiroCarpeta(desde,hasta, usuario);

            return add;
        }


        public string getmatrizinforme(string desde, string hasta, string usuario, string sp_informe, string tipo_operacion, int id_modulo, int id_sucursal, int id_cliente, int id_solicitud,
                                        int rut_adquiriente, int numero_factura, string numero_cliente, string patente, int ultimo_estado, int folio, int id_nomina, int id_ciudad,
                                        int id_familia,string titulo)
        {

            string add = new MatrizExcelDAC().getMatrizinforme(desde, hasta, usuario,sp_informe,tipo_operacion,id_modulo,id_sucursal,id_cliente,id_solicitud,rut_adquiriente,numero_factura,numero_cliente,patente,
                                                ultimo_estado,folio,id_nomina,id_ciudad,id_familia,titulo);

            return add;
        }

        public string GetReporteCertificados(string usuario, DataTable dt)
        {
            return new MatrizExcelDAC().GetReporteCertificados(usuario, dt);
        }
        public string GetReporteHipotecario(string usuario, DataTable dt)
        {
            return new MatrizExcelDAC().GetReporteHipotecario(usuario, dt);
        }


        public string getmatrizinforme_Excel(string usuario, string desde, string hasta, string sp_informe, int id_familia, string titulo)
        {

            string add = new MatrizExcelDAC().getMatrizinforme_Excel(usuario, desde, hasta, sp_informe, id_familia, titulo);

            return add;
        }


    }
}
