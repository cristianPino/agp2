using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class EstadoOperacion
    {
        private int id_estado;

        public int Id_estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }

        private int id_solicitud;

        public int Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        


        private DateTime fecha_hora;

        public DateTime Fecha_hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }

        private EstadoTipoOperacion estado_operacion;

        public EstadoTipoOperacion Estado_operacion
        {
            get { return estado_operacion; }
            set { estado_operacion = value; }
        }

        private string semaforo;

        public string Semaforo
        {
            get { return semaforo; }
            set { semaforo = value; }
        }
        private Int32 contador;

        public Int32 Contador
        {
            get { return contador; }
            set { contador = value; }
        }

        private Int32 total_dias;

        public Int32 Total_dias
        {
            get { return total_dias; }
            set { total_dias = value; }
        }

        private Boolean permite_estado;

        public Boolean Permite_estado
        {
            get { return permite_estado; }
            set { permite_estado = value; }
        }
        private Boolean activo;

        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        } 
    }
}
