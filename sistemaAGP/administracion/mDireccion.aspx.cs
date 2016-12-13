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
    public partial class mDireccion : System.Web.UI.Page
    {
        private Int32 rut;
        protected void Page_Load(object sender, EventArgs e)
        {
            string rut_encrip;
            string nombre;

            rut_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["rut"].ToString());           

            rut= Convert.ToInt32(rut_encrip);

			Persona mpersona = new PersonaBC().getpersonabyrut(rut);
			nombre = mpersona.Nombre;
			this.lbl_nombre.Text = mpersona.Nombre;
			this.lbl_rut.Text = rut_encrip;
			this.lbl_nombre.Text = nombre;
			string paremetro = "TDIR";
			
			if (!IsPostBack)
            {
                getdireccion();
                FuncionGlobal.combopais(this.dl_pais);
                FuncionGlobal.comboparametro(this.dl_tipo_direccion, paremetro);
                
            }
        }

        private void getdireccion()
        {          
			DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_direccion"));
            dt.Columns.Add(new DataColumn("tipo_direccion"));
            dt.Columns.Add(new DataColumn("direccion"));
            dt.Columns.Add(new DataColumn("numero"));
            dt.Columns.Add(new DataColumn("comuna"));
            dt.Columns.Add(new DataColumn("Complemento"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");
            dt.Columns.Add(col);

            List<Direcciones> ldireccion= new DireccionesBC().getdirecciones(Convert.ToInt32(rut));
            foreach (Direcciones mdireccion in ldireccion)
            {
                DataRow dr = dt.NewRow();

                dr["id_direccion"] = mdireccion.Id_direccion;
                dr["tipo_direccion"] = mdireccion.Tipo_direccion;
                dr["direccion"] = mdireccion.Direccion;
                dr["numero"] = mdireccion.Numero;
                dr["comuna"] = mdireccion.Comuna.Nombre;
                dr["complemento"] = mdireccion.Complemento;
                dr["check"] = mdireccion.Check;
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.txt_direcion.Text == "" | this.dl_comuna.SelectedValue == "0" | this.dl_tipo_direccion.SelectedValue == "0")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new DireccionesBC().add_direcciones(Convert.ToInt32(lbl_rut.Text), this.txt_direcion.Text, this.dl_tipo_direccion.SelectedValue.ToString(), this.txt_numero.Text, Convert.ToInt32(this.dl_comuna.SelectedValue.ToString()), this.txt_complemento.Text.ToString(), 0);

            FuncionGlobal.alerta("DIRECCION INGRESADA CON EXITO", Page);
            this.txt_direcion.Text = "";
            this.txt_numero.Text = "";

            getdireccion();
        }

		protected void Button2_Click(object sender, EventArgs e) { }

        protected void dl_region_SelectedIndexChanged1(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        protected void dl_ciudad_SelectedIndexChanged1(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        }

		protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region,this.dl_pais.SelectedValue);
        }

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void Button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        public void actualizar()
        {
            GridViewRow row;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                string id_direccion = this.gr_dato.Rows[i].Cells[0].Text;

                string add = new DireccionesBC().act_checkDireccion(Convert.ToInt32(id_direccion), chk.Checked.ToString());

                FuncionGlobal.alerta("PRIORIDAD ACTUALIZADA CON EXITO", Page);
            }
            getdireccion();
        }
    }
}