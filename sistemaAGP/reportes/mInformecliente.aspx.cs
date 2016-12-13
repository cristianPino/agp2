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
namespace sistemaAGP
{
    public partial class mInformecliente : System.Web.UI.Page
    {

        private string id_perfil;

        protected void Page_Load(object sender, EventArgs e)
        {


            id_perfil = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_perfil"].ToString());

            if (!IsPostBack)
            {
                List<Informe> lInforme = new InformeBC().getInformeByCliente(id_perfil);

                this.gr_dato.DataSource = lInforme;
                this.gr_dato.DataBind();
            }
        }
        


        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

        public void add_informecliente()
        {


            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                Int32 id_informe = Convert.ToInt32(gr_dato.DataKeys[i].Values[0].ToString());
                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
                
                if (chk.Checked == true)
                {

                    string add = new InformeBC().add_informe_check(id_perfil, id_informe);
                    FuncionGlobal.alerta("INFORME AGREGADO CON EXITO", Page);
                }
                else
                {
                    string add = new InformeBC().del_informe_check(id_perfil, id_informe);
                }
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
             add_informecliente();
             
        }






    }
}






//public void add_informe_check(Int32 id_informe, string nivel)
//{
//    string add = new InformeBC().add_informe_check(nivel, id_informe);
//}

//public void del_informe_check(Int32 id_informe, string nivel)
//{
//    string del = new InformeBC().del_informe_check(nivel, id_informe);
//}

//protected void Button3_Click(object sender, EventArgs e)
//{
//    add_check();

//}

//private void add_check()
//{

//    GridViewRow row;
//    string ger = "GERE";
//    string ejec = "EJEC";
//    string supe = "SUPE";

//    for (int i = 0; i < gr_dato.Rows.Count; i++)
//    {

//        row = gr_dato.Rows[i];
//        CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
//        CheckBox chke = (CheckBox)gr_dato.Rows[i].FindControl("chke");
//        CheckBox chks = (CheckBox)gr_dato.Rows[i].FindControl("chks");

//        Int32 id_informe1 = Convert.ToInt32(this.gr_dato.Rows[i].Cells[0].Text);

//        if (chk.Checked == true)
//        { add_informe_check(id_informe1, ger); }
//        else
//        { del_informe_check(id_informe1, ger); }

//        if (chke.Checked == true)
//        { add_informe_check(id_informe1, ejec); }
//        else
//        { del_informe_check(id_informe1, ejec); }

//        if (chks.Checked == true)
//        { add_informe_check(id_informe1, supe); }
//        else
//        { del_informe_check(id_informe1, supe); }

//    }


//}




