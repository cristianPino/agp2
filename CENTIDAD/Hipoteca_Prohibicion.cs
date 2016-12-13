using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Hipoteca_Prohibicion
    {

        public string Letra { get; set; }
        private Int32 id_prohibicion;

        public Int32 Id_prohibicion
        {
            get { return id_prohibicion; }
            set { id_prohibicion = value; }
        }

        public string AfavorDe { get; set; }
        private string fojas;


        public string Fojas
        {
            get { return fojas; }
            set { fojas = value; }
        }
        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private string comuna;

        public string Comuna
        {
            get { return comuna; }
            set { comuna = value; }
        }

        private string tipo_prohibicion;

        public string Tipo_prohibicion
        {
            get { return tipo_prohibicion; }
            set { tipo_prohibicion = value; }
        }

        private string comentario;

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

    }
}
