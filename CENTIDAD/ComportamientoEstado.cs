using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ComportamientoEstado
    {
       
        private Int32 id_comportamiento;

        public Int32 Id_comportamiento
        {
            get { return id_comportamiento; }
            set { id_comportamiento = value; }
        }
        private Int32 estado_origen;

        public Int32 Estado_origen
        {
            get { return estado_origen; }
            set { estado_origen = value; }
        }
        private Int32 estado_final;

        public Int32 Estado_final
        {
            get { return estado_final; }
            set { estado_final = value; }
        }
        private Int32 codigo_estado;

        public Int32 Codigo_estado
        {
            get { return codigo_estado; }
            set { codigo_estado = value; }
        }

        public string EstadoFinalDescripcion { get; set; }
    }
}
