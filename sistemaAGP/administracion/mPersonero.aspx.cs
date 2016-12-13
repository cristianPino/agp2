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
    public partial class mPersonero : System.Web.UI.Page
    {
        private Int16 id_cliente;

        protected void Page_Load(object sender, EventArgs e)
        {

            string id_cli_encrip;

            id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

            id_cliente = Convert.ToInt16(id_cli_encrip);

            Cliente mcliente = new ClienteBC().getcliente(id_cliente);
            this.lbl_cliente.Text = mcliente.Persona.Nombre;

            if (!IsPostBack)
            {
                getpersonero();
                FuncionGlobal.comboparametro(this.dl_tipo, "TIPOCON");
                FuncionGlobal.combomodulo(this.dl_modulo, Convert.ToInt16(id_cliente));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add_personero();
        }

        private void getpersonero()
        {


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_personero"));
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("modulo"));
            dt.Columns.Add(new DataColumn("rut"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("tipo"));
            dt.Columns.Add(new DataColumn("profesion"));
            dt.Columns.Add(new DataColumn("id_modulo"));
            
            List<Personero> lPersonero = new PersoneroBC().getPersonerobycliente(Convert.ToInt16(id_cliente));
            foreach (Personero mpersonero in lPersonero)
            {
                DataRow dr = dt.NewRow();

                dr["id_personero"] = mpersonero.Id_personero;
                dr["cliente"] = mpersonero.Cliente.Persona.Nombre;
                dr["modulo"] = mpersonero.Modulocliente.Nombre;
                dr["rut"] = mpersonero.Rut_representante;
                dr["nombre"] = mpersonero.Nombre_representante;
                dr["tipo"] = mpersonero.Tipo;
                dr["profesion"] = mpersonero.Profesion;
                dr["descripcion"] = mpersonero.Descripcion;
                dr["id_modulo"] = mpersonero.Modulocliente.Id_modulo;

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

        }


        private void add_personero()
        {

            if (this.txt_rut.Text == "" | this.txt_nombre.Text =="" | 
                             this.txt_descripcion.Text =="" | this.txt_profesion.Text =="" )
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }

            string add = new PersoneroBC().add_personero(Convert.ToInt16(id_cliente), Convert.ToInt16(this.dl_modulo.SelectedValue),
                                                this.txt_rut.Text, this.txt_nombre.Text, this.txt_descripcion.Text,
                                                Convert.ToString(this.dl_tipo.SelectedValue), this.txt_profesion.Text);
                           

            FuncionGlobal.alerta("PERSONERO INGRESADO CON EXITO", Page);
            limpiar();
            getpersonero();
            
        }

        private void limpiar()
        {
            this.txt_profesion.Text = "";
            this.txt_rut.Text = "";
            this.txt_descripcion.Text = "";
            this.txt_nombre.Text = "";

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_rut.Text = ((GridView)sender).SelectedRow.Cells[3].Text;
            this.txt_nombre.Text = ((GridView)sender).SelectedRow.Cells[4].Text;
            this.txt_descripcion.Text = ((GridView)sender).SelectedRow.Cells[6].Text;
            this.txt_profesion.Text = ((GridView)sender).SelectedRow.Cells[7].Text;

            this.dl_tipo.SelectedValue = ((GridView)sender).SelectedRow.Cells[5].Text.Trim();
            this.dl_modulo.SelectedValue = ((GridView)sender).SelectedRow.Cells[8].Text.Trim();
        }

    }
}
