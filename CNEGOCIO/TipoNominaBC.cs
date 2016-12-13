using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class TipoNominaBC
	{


        public string actualiza_rendicion_nomina(Int32 id_solicitud, Int32 id_nomina, Int32 folio, string cuenta_usuario, Int32 id_inventario)
        {

            string add = new TipoNominaDAC().actualiza_rendicion_nomina(id_solicitud, id_nomina, folio, cuenta_usuario, id_inventario);    

                return add;
        }


		public List<TipoNomina> getTipoNominagastoByIdFamilia(int id_familia)
		{
			return new TipoNominaDAC().getTipoNominagastoByIdFamilia(id_familia);
		}

		public List<TipoNomina> getTiponomina()
		{
			List<TipoNomina> lTiponomina = new TipoNominaDAC().getTiponomina();
			return lTiponomina;
		}

		public TipoNomina getTiponominaBytipo(Int32 id_nomina)
		{
			TipoNomina lTiponomina = new TipoNominaDAC().getTiponominaBytipo(id_nomina);
			return lTiponomina;
		}

		public List<TipoNomina> getTipoNominaByIdFamilia(int id_familia)
		{
			return new TipoNominaDAC().getTipoNominaByIdFamilia(id_familia);
		}


		public List<TipoNomina> getTipoNominaByIdFamiliacheck(int id_familia)
		{
			return new TipoNominaDAC().getTipoNominaByIdFamiliacheck(id_familia);
		}

		public string add_tiponomina(string descripcion)
		{
			string add = new TipoNominaDAC().add_tiponomina(descripcion);
			return add;
		}

		public string actualiza_tiponomina(string descripcion,string reporte,Int16 estado,Int16 gasto, string check , int ID_FAM , int folio,int id_nomina)
		{
			string add = new TipoNominaDAC().actualiza_tiponomina(descripcion, reporte, estado, gasto,check,ID_FAM,folio,id_nomina);
			return add;
		}


		public string add_tiponominaByOperacion(int id_solicitud, int id_nomina, int folio, string cuenta_usuario)
		{
			string add = new TipoNominaDAC().add_tiponominaByOperacion(id_solicitud, id_nomina, folio, cuenta_usuario);
			return add;
		}


        public string envia_correo_nomina(int id_nomina, int folio)
        {
            string add = new TipoNominaDAC().envia_correo_nomina( id_nomina, folio);
            return add;
        }

        public string envia_correo_nomina_pdte(int id_nomina, int folio)
        {
            string add = new TipoNominaDAC().envia_correo_nomina_pdte(id_nomina, folio);
            return add;
        }


        public List<TipoNomina> getnominaByoperacion(Int32 id_solicitud)
		{
			List<TipoNomina> lTiponomina = new TipoNominaDAC().getnominabyoperacion(id_solicitud);
			return lTiponomina;
		}

		public string upd_FolioNomina(Int32 id_nomina)
		{
			string add = new TipoNominaDAC().upd_FolioNomina(id_nomina);
			return add;
		}

        public string del_Nominabyoperacion(Int32 id_nomina, Int32 id_solicitud, Int32 folio,string cuenta_usuario)
        {
            string add = new TipoNominaDAC().del_nominabyoperacion(id_solicitud, id_nomina, folio,cuenta_usuario);
            return add;
        }

        public bool respuesta_nomina(Int32 id_solicitud, Int16 id_nomina, Int32 id_familia,int id_cliente)
        {

            bool add = new TipoNominaDAC().respuesta_nomina(id_solicitud, id_nomina, id_familia,id_cliente);
            return add;
        }

        public List<TipoNomina> getTipoNominaByIdFamiliafactura(int id_familia)
        {
            return new TipoNominaDAC().getTipoNominaByIdFamiliafactura(id_familia);
        }




	}
}