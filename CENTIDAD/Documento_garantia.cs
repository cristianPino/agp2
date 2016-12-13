using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Documento_garantia
    {
        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        private Int32 cod_matriz;

        public Int32 Cod_matriz
        {
            get { return cod_matriz; }
            set { cod_matriz = value; }
        }
        private DateTime fecha_doc;

        public DateTime Fecha_doc
        {
            get { return fecha_doc; }
            set { fecha_doc = value; }
        }
        private string cuenta_usuario;

        public string Cuenta_usuario
        {
            get { return cuenta_usuario; }
            set { cuenta_usuario = value; }
        }
        private bool documento;

        public bool Documento
        {
            get { return documento; }
            set { documento = value; }
        }
    }
}
