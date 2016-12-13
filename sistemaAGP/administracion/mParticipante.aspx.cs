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
    public partial class mParticipante : System.Web.UI.Page
    {

        private string rut_persona;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            rut_persona = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["rut"].ToString());

            this.DatosParticipante.OnClickDireccion += new wucBotonEventHandler(DatosParticipante_OnClickDireccion);
            this.DatosParticipante.OnClickTelefono += new wucBotonEventHandler(DatosParticipante_OnClickTelefono);
            this.DatosParticipante.OnClickCorreo += new wucBotonEventHandler(DatosParticipante_OnClickCorreo);
            
            if (!IsPostBack)
            {
                GetParticipantes();
                FuncionGlobal.comboparametro(this.dl_tipo, "TIPA");
               
                
            }
        }


        //protected void txt_rut_Leave(object sender, EventArgs e)
        //{

        //    this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

        //    busca_persona(Convert.ToDouble(this.txt_rut.Text));

        //    this.ib_persona.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

        //    this.ib_persona.Visible = true;
        //    this.txt_nombre.Focus();

        //}
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

        protected void bt_limpia_persona_Click(object sender, EventArgs e)
        {

        }

        //protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
        //}

        //protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        //}

        //protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        //    this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + FuncionGlobal.FuctionEncriptar(this.dl_ciudad.SelectedValue.Trim()) + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
        //    ib_comuna.Visible = true;
        //}
        //protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_persona();
            GetParticipantes();
        }

        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
           

        }

        protected void ib_comuna_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_adquiriente_Click(object sender, ImageClickEventArgs e)
        {

        }


        private void add_persona()
        {
            //string persona = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text),
            //                                                this.txt_dv.Text,
            //                                                Convert.ToInt16(this.dl_comuna.SelectedValue),
            //                                                   "",
            //                                                   this.txt_nombre.Text,
            //                                                   this.txt_paterno.Text,
            //                                                   this.txt_materno.Text,
            //                                                   "0",
            //                                                   "0",
            //                                                   "",
            //                                                   "",
            //                                                   "0",
            //                                                   this.txt_telefono.Text,
            //                                                   "",
            //                                                   "",
            //                                                   this.txt_direccion.Text,
            //                                                   this.txt_numero.Text,
            //                                                   this.txt_depto.Text,
            //                                                   "0");
            string rupart = "";
            DateTime direccion =Convert.ToDateTime("1991/01/01");
            if (this.DatosParticipante.Guardar_Form())
            {
                if (this.DatosParticipante.InfoPersona != null)
                {
                    rupart = this.DatosParticipante.InfoPersona.Rut.ToString();
                }
            }

            Direcciones mdirec = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(rupart));
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

            if (mdirec == null)
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la direccion", Page, up);
                return;
            }
            if (this.txt_fecha.Text != "")
            {
                direccion =Convert.ToDateTime(this.txt_fecha.Text);
            }

            if (rupart != "")

            {


                string participe = new ParticipanteBC().add_participe(Convert.ToDouble(rut_persona),
                                                                    Convert.ToDouble(rupart),
                                                                    this.dl_tipo.SelectedValue,
                                                                    this.chk_firma.Checked,
                                                                    this.txt_ciudad_n.Text,
                                                                    this.txt_notario.Text,
                                                                    direccion);

            
            }


        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GetParticipantes()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("rut_participe"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("tipo"));
            dt.Columns.Add(new DataColumn("ciudad_notario"));
            dt.Columns.Add(new DataColumn("notario_publico"));
            dt.Columns.Add(new DataColumn("fecha_participante"));
            
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);


            List<Participante> lparticipe = new ParticipanteBC().Getparticipante(Convert.ToDouble(rut_persona));



            foreach (Participante mparticipe in lparticipe)
            {
                DataRow dr = dt.NewRow();


                dr["rut_participe"] = mparticipe.Participe.Rut;
                dr["nombre"] = mparticipe.Participe.Nombre + " " + mparticipe.Participe.Apellido_paterno + " " + mparticipe.Participe.Apellido_materno;
                dr["tipo"] = mparticipe.Tipo;
                dr["check"] = mparticipe.Firma;
                dr["ciudad_notario"] = mparticipe.Ciudad_notario;
                dr["notario_publico"] = mparticipe.Notario_publico;
                dr["fecha_participante"] = string.Format("{0:dd/MM/yyyy}", mparticipe.Fecha_participante);

                dt.Rows.Add(dr);

            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
            Carga_Link();


        }
        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
            ImageButton ibuton;

            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string id = (string)row.Cells[0].Text;

                    ibuton = (ImageButton)row.FindControl("ib_sucursal");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mParticipantesucursal.aspx?id=" + FuncionGlobal.FuctionEncriptar(id) + "','','status:false;dialogWidth:500px;dialogHeight:260px')");
                }
            }
        }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chk_firma_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cb_eliminar_Click(object sender, EventArgs e)
        {



        }

        protected void txt_fecha_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_ciudad_n_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_notario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void Click_sucursales(Object sender, EventArgs e)
        {

        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            GridViewRow row;
            string rut_participe;
            string tipo;
            string ciudad_notario;
            string notario_publico;
            string fecha_personeria;

            string del = new ParticipanteBC().del_participe(Convert.ToDouble(rut_persona));
            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];

                tipo = (string)row.Cells[2].Text;
                ciudad_notario = (string)row.Cells[4].Text;
                notario_publico = (string)row.Cells[5].Text;
                fecha_personeria = (string)row.Cells[6].Text;
                rut_participe = (string)row.Cells[0].Text;
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
            
                string add = new ParticipanteBC().add_participe(Convert.ToDouble(rut_persona),Convert.ToDouble(rut_participe),tipo,chk.Checked,ciudad_notario,notario_publico,Convert.ToDateTime(fecha_personeria));
              
            }
        }


    }
}
