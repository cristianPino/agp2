using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO {
	public class TipovehiculoBC {
		public List<Tipovehiculo> getallTipovehiculo() {
			List<Tipovehiculo> ltipo = new TipovehiculoDAC().getallTipovehiculo();
			return ltipo;
		}

		public Tipovehiculo getTipoVehiculo(string codigo) {
			return new TipovehiculoDAC().getTipovehiculo(codigo);
		}

		public string add_Tipovehiculo(string codigo, string nombre) {
			Tipovehiculo mTipo = new Tipovehiculo();
			mTipo.Codigo = codigo;
			mTipo.Nombre = nombre;

			string add = new TipovehiculoDAC().add_Tipovehiculo(mTipo);
			return add;


		}
	}
}