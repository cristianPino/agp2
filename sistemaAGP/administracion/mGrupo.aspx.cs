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
using System.Collections.Generic;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP
{
    public partial class mGrupo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                getallgrupo();

            }

        }

        private void add()
        {
            if (this.txt_grupo.Text == "")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new GrupoBC().add_Grupo(0, this.txt_grupo.Text.Trim());

            FuncionGlobal.alerta("DATO INGRESADO CON EXITO", Page);

            this.txt_grupo.Text = "";
            getallgrupo();

            return;

        }

        public void getallgrupo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_grupo"));
            dt.Columns.Add(new DataColumn("nombre"));

            List<Grupo> lGrupo = new GrupoBC().getallgrupo();

            if (lGrupo.Count > 0)
            {
                this.bt_editar.Visible = true;
            }

            foreach (Grupo mgrupo in lGrupo)
            {
                DataRow dr = dt.NewRow();
                dr["id_grupo"] = mgrupo.Id_grupo;
                dr["nombre"] = mgrupo.Descripcion;

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }

        protected void txt_grupo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bt_editar_Click(object sender, EventArgs e)
        {
            int i;
            GridViewRow row;

            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Int32 id_grupo = Convert.ToInt32(this.gr_dato.Rows[i].Cells[0].Text);
                    TextBox t_nombre = ((TextBox)(row.FindControl("nombre")));

                    string add = new GrupoBC().add_Grupo(id_grupo, t_nombre.Text.Trim());
                }
            }

            FuncionGlobal.alerta("DATOS ACTUALIZADOS CON EXITO", Page);
            getallgrupo();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add();
        }

        protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gr_dato.EditIndex = e.NewEditIndex;
        }

        protected void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}