using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class DocumentoEstado
    {
        private Int32 id_documento_estado;

        public Int32 Id_documento_estado
        {
            get { return id_documento_estado; }
            set { id_documento_estado = value; }
        }
        private Int32 codigo_estado;

        public Int32 Codigo_estado
        {
            get { return codigo_estado; }
            set { codigo_estado = value; }
        }
        private Int32 id_documento;

        public Int32 Id_documento
        {
            get { return id_documento; }
            set { id_documento = value; }
        }


        private bool chk_doc;

        public bool Chk_doc
        {
            get { return chk_doc; }
            set { chk_doc = value; }
        }

    }
}
