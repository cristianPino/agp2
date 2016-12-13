using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class TipoOperacion
    {
        private int id_familia;

        public int Id_familia
        {
            get { return id_familia; }
            set { id_familia = value; }
        }

        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        private string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }


        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        private string url_operacion;

        public string Url_operacion
        {
            get { return url_operacion; }
            set { url_operacion = value; }
        }


        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }
        private string tamano;

        public string Tamano
        {
            get { return tamano; }
            set { tamano = value; }
        }


        private string check_ingresa;

        public string Check_ingresa
        {
            get { return check_ingresa; }
            set { check_ingresa = value; }
        }


        private string comprobante;

        public string Comprobante
        {
            get { return comprobante; }
            set { comprobante = value; }
        }


        private string comprobante_rpt;

        public string Comprobante_rpt
        {
            get { return comprobante_rpt; }
            set { comprobante_rpt = value; }
        }


        private string codigo_nav;

        public string Codigo_nav
        {
            get { return codigo_nav; }
            set { codigo_nav = value; }
        }

    }
}
