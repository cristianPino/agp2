using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace sistemaAGP
{
	public partial class reporteador_Cobranza : System.Web.UI.Page
	{

      

        protected void ContactsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excel")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gr_dato.Rows[index];

                int Id = Convert.ToInt16(this.gr_dato.DataKeys[index]["id_informe_excel"]);

                Informe minforme = new InformeBC().getinformebyid_excel(Convert.ToInt16(Id));

                    carga_excel(minforme.Sp_informe.Trim(), minforme.Descripcion.Trim());
                
            }
        }


        protected void carga_excel(string sp_informe,string titulo)
        {
            string desde = string.Format("{0:yyyyMMdd}",DateTime.Now);
            string hasta = string.Format("{0:yyyyMMdd}",DateTime.Now);
            if (this.txt_desde.Text.Trim() != "")
            {
                 desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
            }
            if (this.txt_hasta.Text.Trim() != "")
            {
                 hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
            }
         
            int id_familia = 0;
         
       
            string add = "";
            add = new MatrizExcelBC().getmatrizinforme_Excel((string)(Session["usrname"]), desde, hasta, sp_informe,id_familia,titulo);

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(Page,Page.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", strAlerta, true);


            return;
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
				List<Informe> lInforme = new InformeBC().getInformeByUsuario_excel(musuario.Codigoperfil.Trim());

				this.gr_dato.DataSource = lInforme;
				this.gr_dato.DataBind();

				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();

			
			}
		}

	

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
            

		}

      
	}
}