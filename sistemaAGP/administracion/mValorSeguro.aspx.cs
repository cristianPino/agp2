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
    public partial class mValorseguro : System.Web.UI.Page
    {
        string codigo_distribuidor;
        string nombre;


        protected void Page_Load(object sender, EventArgs e)
        {
            codigo_distribuidor = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo_distribuidor"].ToString());
            nombre = Request.QueryString["nombre"].ToString();

            this.lbl_poliza.Text = nombre;

            if (!IsPostBack)
            {

                getvalosegurovehiculo();
            }
        }

        protected void getvalosegurovehiculo()
        {
            DataTable dt = new DataTable();


            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("valor"));
        
            List<Tipovehiculo> lvalorsegurovehiculo = new TipovehiculoBC().getallTipovehiculo();


            foreach (Tipovehiculo mvalorsegurovehiculo in lvalorsegurovehiculo)
            {
                DataRow dr = dt.NewRow();

                dr["codigo"] = mvalorsegurovehiculo.Codigo;
                dr["nombre"] = mvalorsegurovehiculo.Nombre;
                dr["valor"] = 0;
             
                dt.Rows.Add(dr);

            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }
        protected void getvalosegurovehiculoper()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("id_seguro"));
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("valor"));
            dt.Columns.Add(new DataColumn("fecha_inicio"));
            dt.Columns.Add(new DataColumn("fecha_final"));
            dt.Columns.Add(new DataColumn("periodo"));
            List<ValorSeguroVehiculo> lvalorsegurovehiculo = new ValorSeguroVehiculoBC().getallvalosegurovehiculo(codigo_distribuidor,Convert.ToInt32(dl_periodo2.SelectedValue),
                                                                                                                    Convert.ToInt32(dl_ano.SelectedValue));


            foreach (ValorSeguroVehiculo mvalorsegurovehiculo in lvalorsegurovehiculo)
            {
                DataRow dr = dt.NewRow();

                dr["id_seguro"] = mvalorsegurovehiculo.Id_seguro;
                dr["codigo"] = mvalorsegurovehiculo.Codigo_distribuidor;
                dr["nombre"] = mvalorsegurovehiculo.Tipovehiculo.Nombre;
                dr["valor"] = mvalorsegurovehiculo.Valor;
                dr["fecha_inicio"] = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(mvalorsegurovehiculo.FechaDesde));
                dr["fecha_final"] = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(mvalorsegurovehiculo.FechaHasta)); 
                dr["periodo"] = mvalorsegurovehiculo.Periodo;

                dt.Rows.Add(dr);

            }

            this.gr_dato2.DataSource = dt;
            this.gr_dato2.DataBind();
        }



        private void add_valorsegurovehiculo()
        {

            GridViewRow row;
            string add;
            for (int i = 0; i < gr_dato2.Rows.Count; i++)
            {
                row = gr_dato2.Rows[i];  
                TextBox txt = (TextBox)gr_dato2.Rows[i].FindControl("txt_valor");
                string codigo = this.gr_dato2.Rows[i].Cells[1].Text;
                string id_seguro = this.gr_dato2.Rows[i].Cells[0].Text;


                add = new ValorSeguroVehiculoBC().add_ValorSeguroVehiculo(codigo_distribuidor, codigo, Convert.ToInt32(txt.Text),id_seguro);


            }
        }
        protected void bt_cerrar_Click(object sender, EventArgs e)
        {

            Response.Write("<script>self.close();</script>");


        }
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            add_valorsegurovehiculo();
            FuncionGlobal.alerta("VALORES INGRESADO CON EXITO", Page);
            
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gr_dato2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txt_valor_Leave(object sender, EventArgs e)
        {

        }
        protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gr_dato.EditIndex = e.NewEditIndex;

        }
        protected void gr_dato2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gr_dato2.EditIndex = e.NewEditIndex;

        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bt_editar_Click(object sender, EventArgs e)
        {
            if (this.txt_fecha_inicio.Text != "" && this.txt_fecha_final.Text != "" && this.dl_periodo.SelectedValue != "0")
            {
                  GridViewRow row;
                string add;
                for (int i = 0; i < gr_dato.Rows.Count; i++)
                {
                    row = gr_dato.Rows[i];  
                    TextBox txt = (TextBox)gr_dato.Rows[i].FindControl("txt_valor");
                    string codigo = this.gr_dato.Rows[i].Cells[0].Text;
                    
                    add = new ValorSeguroVehiculoBC().add_seguros(codigo_distribuidor,codigo,Convert.ToInt32(txt.Text),Convert.ToInt32(this.dl_periodo.SelectedValue),
                                                            Convert.ToDateTime(this.txt_fecha_inicio.Text), Convert.ToDateTime(this.txt_fecha_final.Text));
                }

                getvalosegurovehiculo();
                this.txt_fecha_final.Text = "";
                this.txt_fecha_inicio.Text = "";
                this.dl_periodo.SelectedValue = "0";
            }
        }

        protected void bt_buscar_Click(object sender, EventArgs e)
        {
            if (this.dl_periodo2.SelectedValue != "0" && this.dl_ano.SelectedValue != "0")
            {
                getvalosegurovehiculoper();
                this.bt_guardar.Visible = true;
                this.gr_dato2.Visible = true;
            }
        }

        protected void txt_fecha_inicio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fecha_final_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_periodo2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_ano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_periodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}
