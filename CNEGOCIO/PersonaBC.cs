using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class PersonaBC
    {

        public Persona getpersonabyrut(double rut)
        {

            Persona mpersona = new PersonaDAC().getpersonabyrut(rut);

            return mpersona;

        }

        public string add_persona(double rut,string dv, Int16 comuna, string serie, string nombre,
                                string paterno, string materno, string sexo, string tipo_persona,
                                string nacionalidad,string profesion, string estado_civil,string telefono,
                                string celular, string correo, string direccion, string numero, string depto,
                                string tipo_empleador,string giro)
        {


            
            
            Persona mpersona = new Persona();

            mpersona.Rut = rut;
            mpersona.Comuna = new ComunaDAC().getComuna(comuna);
            mpersona.Dv = dv;
            mpersona.Serie = serie;
            mpersona.Nombre = nombre;
            mpersona.Apellido_paterno = paterno;
            mpersona.Apellido_materno = materno;
            mpersona.Sexo = sexo;
            mpersona.Tipo_persona = tipo_persona;
            mpersona.Nacionalidad = nacionalidad;
            mpersona.Profesion = profesion;
            mpersona.Estado_civil = estado_civil;
            mpersona.Telefono = telefono;
            mpersona.Celular = celular;
            mpersona.Correo = correo;
            mpersona.Direccion = direccion;
            mpersona.Numero = numero;
            mpersona.Depto = depto;
            mpersona.Tipo_empleador = tipo_empleador;
            mpersona.Giro = giro;

            string persona = new PersonaDAC().add_persona(mpersona);

            return persona;
        
        }

        public string add_personaCG(double rut, string dv, Int16 comuna, string serie, string nombre,
                              string paterno, string materno, string sexo, string tipo_persona,
                              string nacionalidad, string profesion, string estado_civil, string telefono,
                              string celular, string correo, string direccion, string numero, string depto,
                              string tipo_empleador)
        {


            Persona mpersona = new Persona();

            mpersona.Rut = rut;
            mpersona.Comuna = new ComunaDAC().getComuna(comuna);
            mpersona.Dv = dv;
            mpersona.Serie = serie;
            mpersona.Nombre = nombre;
            mpersona.Apellido_paterno = paterno;
            mpersona.Apellido_materno = materno;
            mpersona.Sexo = sexo;
            mpersona.Tipo_persona = tipo_persona;
            mpersona.Nacionalidad = nacionalidad;
            mpersona.Profesion = profesion;
            mpersona.Estado_civil = estado_civil;
            mpersona.Telefono = telefono;
            mpersona.Celular = celular;
            mpersona.Correo = correo;
            mpersona.Direccion = direccion;
            mpersona.Numero = numero;
            mpersona.Depto = depto;
            mpersona.Tipo_empleador = tipo_empleador;

            string persona = new PersonaDAC().add_personaCG(mpersona);

            return persona;

        }

        public Persona getpersonabyrutVTA(double rut)
        {

            Persona mpersona = new PersonaDAC().getpersonabyrutVTA(rut);

            return mpersona;

        }


    }
}
