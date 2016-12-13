using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Grupo
    {
        private Int32 id_grupo;

        public Int32 Id_grupo
        {
            get { return id_grupo; }
            set { id_grupo = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private Int32 codigo_estado;

        public Int32 Codigo_estado
        {
            get { return codigo_estado; }
            set { codigo_estado = value; }
        }


    }
}
