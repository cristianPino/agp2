using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Matriz_Escritura
    {
        private Int32 cod_matriz;

        public Int32 Cod_matriz
        {
            get { return cod_matriz; }
            set { cod_matriz = value; }
        }
        private Int32 id_cliente;

        public Int32 Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        private Int32 cod_notaria;

        public Int32 Cod_notaria
        {
            get { return cod_notaria; }
            set { cod_notaria = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private string url_matriz;

        public string Url_matriz
        {
            get { return url_matriz; }
            set { url_matriz = value; }
        }
        private string tipo_documento;

        public string Tipo_documento
        {
            get { return tipo_documento; }
            set { tipo_documento = value; }
        }
        private string url_destino;

        public string Url_destino
        {
            get { return url_destino; }
            set { url_destino = value; }
        }
    }
}
