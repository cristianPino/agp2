using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ParticipanteSucursal
    {

        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private Comuna comuna;

        public Comuna Comuna
        {
            get { return comuna; }
            set { comuna = value; }
        }
        private Int16 Ind_principal;

        public Int16 Ind_principal1
        {
            get { return Ind_principal; }
            set { Ind_principal = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private ModuloCliente modulocliente;

        public ModuloCliente Modulocliente
        {
            get { return modulocliente; }
            set { modulocliente = value; }
        }
        private Int32 id_sucursal;

        public Int32 Id_sucursal1
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }
        private bool check;

        public bool Check
        {
            get { return check; }
            set { check = value; }
        }

        public Int32 Id_sucursal
        {
            get { return id_sucursal; }
            set { id_sucursal = value; }
        }
        private Int32 rut_participante;

        public Int32 Rut_participante
        {
            get { return rut_participante; }
            set { rut_participante = value; }
        }

    }
}
