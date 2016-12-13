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

namespace sistemaAGP {
	public partial class mValorsegurocliente : System.Web.UI.Page {
		Int32 id_cliente;
		string id;
		string nombre;


		protected void Page_Load(object sender, EventArgs e) {
			id = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
			nombre =  Request.QueryString["nombre"].ToString();

			this.lbl_cliente.Text = nombre;
			id_cliente = Convert.ToInt32(id);

			if (!IsPostBack) {
				getvalosegurocliente();
			}
		}

		protected void getvalosegurocliente() {
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("codigo"));
			dt.Columns.Add(new DataColumn("nombre"));
			dt.Columns.Add(new DataColumn("valor"));
            dt.Columns.Add(new DataColumn("valorAGP"));
           

			List<Tipovehiculo> lvalorsegurocliente = new TipovehiculoBC().getallTipovehiculo();

			foreach (Tipovehiculo mvalorsegurocliente in lvalorsegurocliente) {
				DataRow dr = dt.NewRow();

				dr["codigo"] = mvalorsegurocliente.Codigo;
				dr["nombre"] = mvalorsegurocliente.Nombre;
				dr["valor"] = 0;
                dr["valorAGP"] = 0;
               

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
            dt.Columns.Add(new DataColumn("valorAGP"));
            dt.Columns.Add(new DataColumn("fecha_inicio"));
            dt.Columns.Add(new DataColumn("fecha_final"));
            dt.Columns.Add(new DataColumn("periodo"));
            List<ValorSeguroCliente> lvalorsegurovehiculo = new ValorseguroclienteBC().getallvalosegurocliente(id_cliente, Convert.ToInt32(dl_periodo2.SelectedValue),
                                                                                                                    Convert.ToInt32(dl_ano.SelectedValue));


            foreach (ValorSeguroCliente mvalorsegurovehiculo in lvalorsegurovehiculo)
            {
                DataRow dr = dt.NewRow();

                dr["id_seguro"] = mvalorsegurovehiculo.Id_seguro_cliente;
                dr["codigo"] = mvalorsegurovehiculo.Codigo;
                dr["nombre"] = mvalorsegurovehiculo.Tipovehiculo.Nombre;
                dr["valor"] = mvalorsegurovehiculo.Valor;
                dr["valorAGP"] = mvalorsegurovehiculo.ValorAGP;
                dr["fecha_inicio"] = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(mvalorsegurovehiculo.FechaDesde));
                dr["fecha_final"] = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(mvalorsegurovehiculo.FechaHasta));
                dr["periodo"] = mvalorsegurovehiculo.Periodo;

                dt.Rows.Add(dr);

            }

            this.gr_dato2.DataSource = dt;
            this.gr_dato2.DataBind();
        }



		private void add_valorsegurocliente() {
			GridViewRow row;
			string add;
			for (int i = 0; i < gr_dato2.Rows.Count; i++) {
				row = gr_dato2.Rows[i];
				TextBox txt = (TextBox)gr_dato2.Rows[i].FindControl("txt_valor");
                TextBox txtAGP = (TextBox)gr_dato2.Rows[i].FindControl("txt_valorAGP");
				string codigo = this.gr_dato2.Rows[i].Cells[0].Text;
                string id_seguro_cliente = this.gr_dato2.Rows[i].Cells[0].Text;

                add = new ValorseguroclienteBC().add_ValorSegurocliente(id, codigo, Convert.ToInt32(txt.Text), Convert.ToInt32(txtAGP.Text),Convert.ToInt32(id_seguro_cliente));
			}
		}

		protected void bt_cerrar_Click(object sender, EventArgs e) {
			Response.Write("<script>self.close();</script>");
		}

		protected void bt_guardar_Click(object sender, EventArgs e) {
			add_valorsegurocliente();
			FuncionGlobal.alerta("VALORES INGRESADO CON EXITO", Page);
			
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gr_dato2_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void gr_dato2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gr_dato2.EditIndex = e.NewEditIndex;

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
                    TextBox txtAGP = (TextBox)gr_dato.Rows[i].FindControl("txt_valorAGP");
                    string codigo = this.gr_dato.Rows[i].Cells[0].Text;

                    add = new ValorseguroclienteBC().add_seguro_cliente(id_cliente.ToString(), codigo, Convert.ToInt32(txt.Text),Convert.ToInt32(txtAGP.Text), Convert.ToInt32(this.dl_periodo.SelectedValue),
                                                            Convert.ToDateTime(this.txt_fecha_inicio.Text), Convert.ToDateTime(this.txt_fecha_final.Text));
                }

                getvalosegurocliente();
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

		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e) {
			gr_dato.EditIndex = e.NewEditIndex;
		}

        protected void txt_fecha_inicio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fecha_final_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ib_calendario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dl_periodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_periodo2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_ano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}