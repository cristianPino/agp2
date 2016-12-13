using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;

namespace sistemaAGP.administracion
{
    public partial class mConservadorComuna : System.Web.UI.Page
    {
        public int IdConservador;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdConservador = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idConservador"]));
            if(IsPostBack)return;
            GetComunas();
        }

        public void GetComunas()
        {  
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idComuna"));  
            dt.Columns.Add(new DataColumn("region"));
            dt.Columns.Add(new DataColumn("ciudad"));
            dt.Columns.Add(new DataColumn("comuna"));
            dt.Columns.Add(new DataColumn("check", typeof(bool)));

            var lista = new ConservadorBC().GetConservadorComunas(IdConservador);

            foreach (var c in lista)
            {
                var dr = dt.NewRow();

                dr["idComuna"] = c.Id_Comuna; 
                dr["region"] = c.Ciudad.Region.Nombre;
                dr["ciudad"] = c.Ciudad.Nombre;
                dr["comuna"] = c.Nombre;
                dr["check"] = c.Existe;
                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
       
        }

        public void Guardar()
        {
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var idComuna = Convert.ToInt32(gr_dato.DataKeys[i]["idComuna"]);

                if (chk.Checked)
                {
                    try
                    {
                        new ConservadorBC().Edit_JuridiccionConservador(IdConservador, idComuna, 1);
                    }
                    catch(Exception ex)
                    {
                        Mensaje(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        new ConservadorBC().Edit_JuridiccionConservador(IdConservador, idComuna, 2);
                    }
                    catch (Exception ex)
                    {
                      Mensaje(ex.Message);
                    }
                   
                }

            }

            Mensaje("Se actualizaron los datos Correctamente");
           
        }
        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje,Page,updateGrilla);
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}