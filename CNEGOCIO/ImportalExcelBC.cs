using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using CACCESO;

namespace CNEGOCIO
{
    public class ImportalExcelBC
    {

        public string importa_excel(string ruta)
        {

            string imp = new ImportarExcelDAC().importa_excel(ruta);

            return imp;

        }
        public DataTable carga_operaciones_amicar()
        {

            DataTable add = new ImportarExcelDAC().carga_operaciones_amicar();

            return add;
        }


    }
}
