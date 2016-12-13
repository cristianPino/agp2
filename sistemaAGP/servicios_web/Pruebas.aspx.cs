using System;
using WsAgp;


namespace sistemaAGP.servicios_web
{
    public partial class Pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     

        protected void Button1_Click1(object sender, EventArgs e)
        {

           

            string dd = "";

            dd = FuncionGlobal.digitoVerificadorPatente("OB0826");

            
            //ServiceReference1.Service1SoapClient tt = new ServiceReference1.Service1SoapClient();

            //dd = tt.Encriptar("u53r4gp");

            //this.Label2.Text = dd;

            //Service1 xx = new Service1();
            //string ff = "";


            //IntegracionProvidencia.svrAgpSoapClient uu = new IntegracionProvidencia.svrAgpSoapClient();
            //ff = tt.getInformacionPermiso(FuncionGlobal.FuctionEncriptar("u53r4gp"), FuncionGlobal.FuctionEncriptar("p5wd4gp"), FuncionGlobal.FuctionEncriptar("HSFF84"));
            //this.Label2.Text = ff;

            //WsAgp.PermisoCirculacion yy = new WsAgp.PermisoCirculacion();

            //yy = xx.getInformacionPermisoXML(FuncionGlobal.FuctionEncriptar("u53r4gp"), FuncionGlobal.FuctionEncriptar("p5wd4gp"), FuncionGlobal.FuctionEncriptar("HSFF84"));

            //this.Label2.Text = yy.idOperacion.ToString();
        }

    }
}

  
