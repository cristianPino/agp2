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
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;

namespace sistemaAGP
{
    public partial class mModelovehiculo : System.Web.UI.Page
    {
        private string id_marca_vehiculo;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            id_marca_vehiculo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_marca"].ToString());


            Marcavehiculo mmarca = new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(id_marca_vehiculo));

            this.lbl_marca.Text = mmarca.Nombre;

            if (!IsPostBack)
            {
                FuncionGlobal.combotipovehiculo(this.dl_tipo);
                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add();
        }

        private void add()
        { 
        
            if (this.txt_modelo.Text == "" || this.dl_tipo.SelectedValue=="0" )
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

           


           string add = new ModelovehiculoBC().add_Modelovehiculo(0,this.txt_modelo.Text,
                                                            this.dl_tipo.SelectedValue,
                                                            Convert.ToInt16(id_marca_vehiculo));

           FuncionGlobal.alerta("MODELO INGRESADO CON EXITO", Page);
           this.txt_modelo.Text = "";
           getmodelos();


        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getmodelos();
        
        }

        private void getmodelos()
        {
            List<ModeloVehiculo> lmodelo = new ModelovehiculoBC().getallModelovehiculo(Convert.ToInt16(id_marca_vehiculo),
                                                                            this.dl_tipo.SelectedValue);

                this.gr_dato.DataSource = lmodelo;
                this.gr_dato.DataBind();

        
        }
    }
}
