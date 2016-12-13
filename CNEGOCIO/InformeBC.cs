using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class InformeBC
    {
        public List<Informe> getInforme()
        {

            List<Informe> lInforme = new InformeDac().getInforme();
            return lInforme;

        }

		public List<Informe> getInformeByCliente(string codigoperfil) {

			List<Informe> lInforme = new InformeDac().getInformeByCliente(codigoperfil);
			return lInforme;

		}
        public List<Informe> getInformeByUsuario(string codigoperfil)
        {

            List<Informe> lInforme = new InformeDac().getInformebyUsuario(codigoperfil);
            return lInforme;

        }
        public List<Informe> getInformeByUsuario_excel(string codigoperfil)
        {

            List<Informe> lInforme = new InformeDac().getInformebyUsuario_excel(codigoperfil);
            return lInforme;

        }
        public Informe getinformebyid(Int16 id_report)
        {
            Informe minforme = new InformeDac().GetInformebyid(id_report);
            return minforme;
        }
        public Informe getinformebyid_excel(Int16 id_report)
        {
            Informe minforme = new InformeDac().GetInformebyid_excel(id_report);
            return minforme;
        }

        public string add_informe(string nombre, string descripcion)
        {


            string add = new InformeDac().add_informe(nombre,descripcion);
            return add;

        }
        public string add_informe_check(string id_perfil, Int32 id_informe)
        {


            string add = new InformeDac().add_informe_check(id_perfil, id_informe);
            return add;

        }
        public string del_informe_check(string id_perfil, Int32 id_informe)
        {


            string del = new InformeDac().del_informe_check(id_perfil, id_informe);
            return del;

        }





    }
}
