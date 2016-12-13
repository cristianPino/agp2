using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WsAgp;

namespace sistemaAGP.servicios_web
{
    public partial class prueba2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Service1 xx = new Service1();
            string ss;
            ss = xx.getInformacionPermiso(FuncionGlobal.FuctionEncriptar("u53r4gp"), FuncionGlobal.FuctionEncriptar("p5wd4gp"), "zw1176");

            this.Label1.Text = xx.getInformacionPermiso(FuncionGlobal.FuctionEncriptar("u53r4gp"), FuncionGlobal.FuctionEncriptar("p5wd4gp"), "zw1176");

        }
    }
}