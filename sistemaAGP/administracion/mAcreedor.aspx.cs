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
    public partial class mAcreedor : System.Web.UI.Page
    {

        private string id_prohibicion;
        private string id_gr_prohibicion;

        protected void Page_Load(object sender, EventArgs e)
        {

            id_gr_prohibicion = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_gr_prohibicion"].ToString());
            id_prohibicion = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_prohibicion"].ToString());

            this.DatosParticipante.OnClickDireccion += new wucBotonEventHandler(DatosParticipante_OnClickDireccion);
            this.DatosParticipante.OnClickTelefono += new wucBotonEventHandler(DatosParticipante_OnClickTelefono);
            this.DatosParticipante.OnClickCorreo += new wucBotonEventHandler(DatosParticipante_OnClickCorreo);
            
            if (!IsPostBack)
            {
                getacreedor();
              
            }
        }


      
        protected void DatosParticipante_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void DatosParticipante_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void DatosParticipante_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }
        private void busca_persona(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if (mpersona != null)
            {
                this.DatosParticipante.Mostrar_Form(mpersona.Rut);
                //this.ib_persona.Visible = true;
                //this.ib_persona.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + FuncionGlobal.FuctionEncriptar( mpersona.Rut.ToString()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

                //this.txt_rut.Enabled = false;
                //this.txt_dv.Enabled = false;

                //this.txt_nombre.Text = mpersona.Nombre;
                //this.txt_paterno.Text = mpersona.Apellido_paterno;
                //this.txt_materno.Text = mpersona.Apellido_materno;
                //this.txt_dv.Text = mpersona.Dv;
                //this.txt_direccion.Text = mpersona.Direccion;
                //this.txt_numero.Text = mpersona.Numero;
                //this.txt_depto.Text = mpersona.Depto;
                //this.txt_telefono.Text = mpersona.Telefono;


                //this.dl_pais.SelectedValue = mpersona.Comuna.Ciudad.Region.Pais.Codigo;
                //FuncionGlobal.comboregion(this.dl_region, mpersona.Comuna.Ciudad.Region.Pais.Codigo);
                //this.dl_region.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Region.Id_region);

                //FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(mpersona.Comuna.Ciudad.Region.Id_region));
                //this.dl_ciudad.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Id_Ciudad);
                //FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(mpersona.Comuna.Ciudad.Id_Ciudad));
                //this.dl_comuna.SelectedValue = Convert.ToString(mpersona.Comuna.Id_Comuna);
            }
          


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            add_persona();
        
        }

       
        protected void ib_comuna_Click(object sender, ImageClickEventArgs e)
        {

        }

        private void add_persona()
        {
            
            string rupart = "";
   
            if (this.DatosParticipante.Guardar_Form())
            {
                if (this.DatosParticipante.InfoPersona != null)
                {
                    rupart = this.DatosParticipante.InfoPersona.Rut.ToString();
                }
            }

            Direcciones mdirec = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(rupart));
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

            if (mdirec.Id_direccion == 0)
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la direccion", Page, up);
                return;
            }

            add_gr_dato();
          

        }
        public void crear_table()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id_gr_pro"));
            dt.Columns.Add(new DataColumn("id_prohibicion"));
            dt.Columns.Add(new DataColumn("rut_acreedor"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("estado_civil"));
            dt.Columns.Add(new DataColumn("sexo"));
            dt.Columns.Add(new DataColumn("profesion"));
            ViewState["dt_acreedor"] = dt;
        }
        

        public void add_gr_dato()
        {

            this.crear_table();

            DataTable dt = (DataTable)ViewState["dt_acreedor"];
            DataRow dr = dt.NewRow();

            dr["id_gr_pro"] = id_gr_prohibicion; 
            dr["id_prohibicion"] = id_prohibicion;
            dr["rut_acreedor"] = this.DatosParticipante.InfoPersona.Rut;
            dr["nombre"] = this.DatosParticipante.InfoPersona.Nombre + " " + this.DatosParticipante.InfoPersona.Apellido_paterno + " " + this.DatosParticipante.InfoPersona.Apellido_materno;
            dr["estado_civil"] = this.DatosParticipante.InfoPersona.Estado_civil;
            dr["sexo"] = this.DatosParticipante.InfoPersona.Sexo;
            dr["profesion"] = this.DatosParticipante.InfoPersona.Profesion;
            dt.Rows.Add(dr);

            if (id_prohibicion != "0")
            {
                string add = new AcreedorBC().add_acreedor(Convert.ToInt32(id_prohibicion),Convert.ToInt32(this.DatosParticipante.InfoPersona.Rut));
                getacreedor();
            }
            else
            {
                
                if (Session["tabla_acreedor"] == null)
                {
                    Session["tabla_acreedor"] = dt;
                }
                else
                {
                    DataTable dta = (DataTable)Session["tabla_acreedor"];
                    foreach (DataRow row in dta.Rows)
                    {
                        
                        DataRow drr = dt.NewRow();

                        drr["id_gr_pro"] = Convert.ToString(row["id_gr_pro"]);
                        drr["id_prohibicion"] = Convert.ToString(row["id_prohibicion"]);
                        drr["rut_acreedor"] = Convert.ToString(row["rut_acreedor"]);
                        drr["nombre"] = Convert.ToString(row["nombre"]);
                        drr["estado_civil"] = Convert.ToString(row["estado_civil"]);
                        drr["sexo"] = Convert.ToString(row["sexo"]);
                        drr["profesion"] = Convert.ToString(row["profesion"]);

                        dt.Rows.Add(drr);
                    }

                    Session["tabla_acreedor"] = dt;
                }
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

            

        }
        

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void getacreedor()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id_gr_pro"));
            dt.Columns.Add(new DataColumn("id_prohibicion"));
            dt.Columns.Add(new DataColumn("rut_acreedor"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("estado_civil"));
            dt.Columns.Add(new DataColumn("sexo"));
            dt.Columns.Add(new DataColumn("profesion"));

            List<Acreedor> lacreedor = new AcreedorBC().getacreedores(Convert.ToInt32(id_prohibicion));

            if (id_prohibicion == "0")
            {
                DataTable dta = new DataTable();
                dta = (DataTable)Session["tabla_acreedor"];
                if (dta != null)
                {

                    foreach (DataRow row in dta.Rows)
                    {
                        string id = Convert.ToString(row["id_gr_pro"]);

                        if (id_gr_prohibicion == id)
                        {
                            DataRow dr = dt.NewRow();

                            dr["id_gr_pro"] = Convert.ToString(row["id_gr_pro"]);
                            dr["id_prohibicion"] = Convert.ToString(row["id_prohibicion"]);
                            dr["rut_acreedor"] = Convert.ToString(row["rut_acreedor"]);
                            dr["nombre"] = Convert.ToString(row["nombre"]);
                            dr["estado_civil"] = Convert.ToString(row["estado_civil"]);
                            dr["sexo"] = Convert.ToString(row["sexo"]);
                            dr["profesion"] = Convert.ToString(row["profesion"]);

                            dt.Rows.Add(dr);

                        }
                    }
                }
            }
            else
            {
                foreach (Acreedor macreedor in lacreedor)
                {
                    DataRow dr = dt.NewRow();

                    dr["id_gr_pro"] = "0";
                    dr["id_prohibicion"] = macreedor.Id_prohibicion;
                    dr["rut_acreedor"] = macreedor.P_acreedor.Rut;
                    dr["nombre"] = macreedor.P_acreedor.Nombre + " " + macreedor.P_acreedor.Apellido_paterno + " " + macreedor.P_acreedor.Apellido_materno;
                    dr["estado_civil"] = macreedor.P_acreedor.Estado_civil;
                    dr["sexo"] = macreedor.P_acreedor.Sexo;
                    dr["profesion"] = macreedor.P_acreedor.Profesion;

                    dt.Rows.Add(dr);
                }
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }
           
    }
}
