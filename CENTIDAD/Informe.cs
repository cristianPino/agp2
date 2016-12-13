using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Informe
    {
        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }

        private Int32 id_informe;

        public Int32 Id_informe
        {
            get { return id_informe; }
            set { id_informe = value; }
        }
        private Int32 id_informe_excel;

        public Int32 Id_informe_excel
        {
            get { return id_informe_excel; }
            set { id_informe_excel = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string sp_informe;

        public string Sp_informe
        {
            get { return sp_informe; }
            set { sp_informe = value; }
        }
    }
}
