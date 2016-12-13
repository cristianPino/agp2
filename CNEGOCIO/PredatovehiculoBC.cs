using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;
namespace CNEGOCIO
{
    public class PredatovehiculoBC
    {

        public string add_Predatovehiculo(Int32 id_solicitud,
                                            Int16 id_modelo,
                                            string chassis,
                                            int ano,
                                            string motor,
                                            string cilindraje,
                                            string patente,
                                            string color,
                                            double carga,
                                            double pesobruto,
                                            string combustible,
                                            int npuerta,
                                            int nasiento,
                                            string dv)
      

        {

            Predatovehiculo mPdv = new Predatovehiculo();

            mPdv.Modelo = new ModelovehiculoDAC().getModelovehiculo(id_modelo);
            mPdv.Chassis = chassis;
            mPdv.Ano = ano;
            mPdv.Motor = motor;
            mPdv.Cilindraje = cilindraje;
            mPdv.Patente = patente;
            mPdv.Color = color;
            mPdv.Carga = carga;
            mPdv.Pesobruto = pesobruto;
            mPdv.Combustible = combustible;
            mPdv.N_puerta = npuerta;
            mPdv.N_asiento = nasiento;
            mPdv.Dv = dv;

            string add_Pdv = new PredatovehiculoDAC().add_Predatovehiculo(mPdv, id_solicitud);
            
            return add_Pdv;
        }

    }
}
