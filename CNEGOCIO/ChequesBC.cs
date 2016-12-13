using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
   public class chequesBC
    {
       public DataTable GetMovimientoCajaChicaByFamilia(int idFamilia)
       {
           return new chequesDAC().GetMovimientoCajaChicaByFamilia(idFamilia);
       }

       public string[] AddMovimientoCajaChica(string cuentaUsuario, int idFamilia, int monto, string tipo, int tipoGasto = 0, int idSolicitud = 0)
       {
           return new chequesDAC().AddMovimientoCajaChica(cuentaUsuario, idFamilia, monto, tipo, tipoGasto, idSolicitud);
       }

       public List<Cheques> getCta_Cte(string desde, string hasta, Int16 tipo_movimiento, string rendido)
        {
            List<Cheques> lCta_Cte = new chequesDAC().getCta_Cte(desde, hasta, tipo_movimiento, rendido );
            return lCta_Cte;
        }

		public Cheques getCheque_Cte(string id_inventario)
		{
			Cheques get_lCta_Cte = new chequesDAC().getcheqques(id_inventario);
			return get_lCta_Cte;
		}

		


        public string add_Cta_Cte(string banco, string ctacte, string talonario, string tipo_movimiento,int montorendido,
                    string   numero_cheque,string usuario, string solicitante )
        {
            string add = new chequesDAC().add_cta_cte(banco, Convert.ToInt32(ctacte), talonario, tipo_movimiento, montorendido, numero_cheque, usuario, solicitante);
            return add;
        }
        public string rendir_cheque(Int32 id_inventario, string observacion, Int32 monto_rendido)
        {
            string add = new chequesDAC().rendir_cheque(id_inventario, observacion, monto_rendido);
            return add;
        }

		public string del_Cta_Cte(int fila)
		{
			string add = new chequesDAC().del_cta_cte(fila);
			return add;
		}

    }
}
