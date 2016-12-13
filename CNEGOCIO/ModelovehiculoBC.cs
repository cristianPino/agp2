using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
   public class ModelovehiculoBC
    {
       public List<ModeloVehiculo> getallModelovehiculo(Int16 id_marca, string codigo)
        {
            List<ModeloVehiculo> ltipo = new ModelovehiculoDAC().getallModelovehiculo(id_marca,codigo);
            return ltipo;
        }

	   public List<ModeloVehiculo> getallModelovehiculoexterno(Int16 id_marca)
	   {
		   List<ModeloVehiculo> ltipo = new ModelovehiculoDAC().getallModelovehiculoexterno(id_marca);
		   return ltipo;
	   }
       public string add_Modelovehiculo(int id_modelo, string nombre, 
                                        string codigo, Int16 id_marca)
        {
            ModeloVehiculo mTipo = new ModeloVehiculo();
            mTipo.Id_Modelo = id_modelo;
            mTipo.Nombre = nombre;
            mTipo.Tipovehiculo = new TipovehiculoDAC().getTipovehiculo(codigo);
            mTipo.Marcavehiculo = new MarcavehiculoDAC().getMarcavehiculo(id_marca);


            string add = new ModelovehiculoDAC().add_Modelovehiculo(mTipo);
            return add;


        }

       public ModeloVehiculo getModeloImpuesto(Int32 id_modelo,DateTime fecha, Int32 monto)
       {
          ModeloVehiculo ltipo = new ModelovehiculoDAC().getModelovehiculoImpuesto(id_modelo,fecha,monto);
           return ltipo;
       }




    }
}
