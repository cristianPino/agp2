using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Personero
    {
        private int id_personero;
        private Cliente cliente;
        private string rut_representante;
        private string nombre_representante;
        private string descripcion;
        private string tipo;
        private string profesion;
        private ModuloCliente modulocliente;

        public ModuloCliente Modulocliente
        {
            get { return modulocliente; }
            set { modulocliente = value; }
        }

        public string Profesion
        {
            get { return profesion; }
            set { profesion = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Nombre_representante
        {
            get { return nombre_representante; }
            set { nombre_representante = value; }
        }
 
        public string Rut_representante
        {
            get { return rut_representante; }
            set { rut_representante = value; }
        }
       
       

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

      
        public int Id_personero
        {
            get { return id_personero; }
            set { id_personero = value; }
        }
       
           
    }
}
