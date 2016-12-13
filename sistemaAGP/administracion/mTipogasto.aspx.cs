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
    public partial class mTipogasto : System.Web.UI.Page
    {
        private Int16 id_cliente;
		private Int16 id_familia;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt_valor.Attributes.Add("OnKeyPress", "'javascript:return solonumeros(event)'");
			id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString()));
			if (!IsPostBack)
			{
				Cliente mcliente = new ClienteBC().getcliente(id_cliente);
				this.lbl_cliente.Text = mcliente.Persona.Nombre;

				FuncionGlobal.comboTipoOperacionCliente(this.dl_producto, id_cliente);
				
			}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            add(); 
        }

		protected void Button3_Click(object sender, EventArgs e)
		{
			add2();
		}

        private void add()
        {
            if (this.txt_nombre.Text == "" | this.txt_valor.Text == "")
            {
                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return;
            }


            string add = new TipogastoBC().add_tipogasto(0, Convert.ToDouble(this.txt_valor.Text),
                                            this.txt_nombre.Text,
                                            Convert.ToInt16(id_cliente),
                                            this.dl_producto.SelectedValue,
                                            Convert.ToString(this.chk_gasto.Checked),
                                            Convert.ToString(this.chk_transferencia.Checked),"true","","");

            FuncionGlobal.alerta("TIPO GASTO INGRESADO CON EXITO", Page);

            this.txt_nombre.Text = "";
            this.txt_valor.Text = "";
            getalltipogasto();

            return;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
			add2();
        }

		private void add2()
		{


			GridViewRow row;

			for (int i = 0; i < GridView1.Rows.Count; i++)
			{

				row = GridView1.Rows[i];
				CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("check");
				string codigo = this.GridView1.Rows[i].Cells[0].Text;
				//	int id_cliente = id_cliente;
				Familia_Producto fma = new Familia_productoBC().getfamiliabycodigo(this.dl_producto.SelectedValue.Trim());
				if (chk.Checked == true)
				{
					
					string add = new ClienteOperacionTipogastoBC().add_cliente_operacion_tipogasto(id_cliente,fma.Id_familia, this.dl_producto.SelectedValue, Convert.ToInt32(codigo));

				}
					
				else
				{

					string add = new ClienteOperacionTipogastoBC().del_cliente_operacion_tipogasto(id_cliente,fma.Id_familia, this.dl_producto.SelectedValue, Convert.ToInt32(codigo));

				}


			}



		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        
        }

		protected void Gr_gasto_SelectedIndexChanged(object sender, EventArgs e)
		{


		}
        protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gr_dato.EditIndex = e.NewEditIndex;
        }

        public void getalltipogasto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_tipogasto"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("valor"));
            dt.Columns.Add(new DataColumn("producto"));
			dt.Columns.Add(new DataColumn("cuentafac"));
			dt.Columns.Add(new DataColumn("cuenta"));
			dt.Columns.Add(new DataColumn("nombrecuenta"));

            DataColumn col = new DataColumn("cargo_contable");
            DataColumn coll = new DataColumn("transferencia");
			DataColumn colll = new DataColumn("habilitado");
            col.DataType = System.Type.GetType("System.Boolean");
            coll.DataType = System.Type.GetType("System.Boolean");
			colll.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);
            dt.Columns.Add(coll);
			dt.Columns.Add(colll);

            List<Tipogasto> lTipogasto = new TipogastoBC().getalltipogasto(Convert.ToInt16(id_cliente), this.dl_producto.SelectedValue);

            if (lTipogasto.Count > 0)
            {
                this.bt_editar.Visible = true;
            }
            
            foreach (Tipogasto mtipogasto in lTipogasto)
            {
                DataRow dr = dt.NewRow();

                dr["id_tipogasto"] = mtipogasto.Id_tipogasto ;
                dr["nombre"] = mtipogasto.Descripcion;
                dr["valor"] = mtipogasto.Valor;
                dr["producto"] = mtipogasto.Tipooperacion.Operacion;
				
                PlandeCuenta cunenta = new PlandeCuentaBC().getplan(mtipogasto.Cuenta.ToString());
                
                
                dr["cargo_contable"] = mtipogasto.Cargo_contable;
                dr["transferencia"] = mtipogasto.Transferencia;
				dr["habilitado"] = mtipogasto.Habilitado;
				
                dr["cuenta"] = mtipogasto.Cuenta;
				dr["cuentafac"] = mtipogasto.Cuenta_facturacion;

                if (cunenta != null)
                {
                    dr["nombrecuenta"] = cunenta.Nombre.ToString();
                }
                else

                {

                    dr["nombrecuenta"] = "";
                
                }

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }

        protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            getalltipogasto();
			getalltipogastocomun();
        }


		 public void getalltipogastocomun()
        {
			DataTable dt2 = new DataTable();
			dt2.Columns.Add(new DataColumn("id_tipogasto"));

			dt2.Columns.Add(new DataColumn("descripcion"));
			DataColumn col = new DataColumn("check");
			col.DataType = System.Type.GetType("System.Boolean");


			dt2.Columns.Add(col);

			Familia_Producto fma = new Familia_productoBC().getfamiliabycodigo(this.dl_producto.SelectedValue.Trim());
			List<ClienteOperacionTipogasto> lTipogasto = new ClienteOperacionTipogastoBC().GetClienteOperaciontipogasto(Convert.ToInt32(id_cliente), fma.Id_familia, this.dl_producto.SelectedValue);



			foreach (ClienteOperacionTipogasto mtipogasto in lTipogasto)
			{
				DataRow dr2 = dt2.NewRow();

				dr2["id_tipogasto"] = mtipogasto.Id_tipogasto;
				dr2["descripcion"] = mtipogasto.Descripcion;


				dr2["check"] = mtipogasto.Check;


				dt2.Rows.Add(dr2);
			}

			this.GridView1.DataSource = dt2;
			this.GridView1.DataBind();

        }

        protected void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_valor_gasto_TextChanged(object sender, EventArgs e)
        {

        }
		protected void txt_cuenta_TextChanged(object sender, EventArgs e)
		{

		}
		protected void txt_nombrecuenta_TextChanged(object sender, EventArgs e)
		{

		}
        protected void txt_nombre_gasto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bt_editar_Click(object sender, EventArgs e)
        {

            int i;
            GridViewRow row;
            string chk;
            string chk_trans;
			string chk_habil;
            
            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {

                    Int16 id_tipogasto = Convert.ToInt16(this.gr_dato.Rows[i].Cells[0].Text);

                    TextBox t_valor = ((TextBox)(row.FindControl("txt_valor_gasto")));
                    TextBox t_nombre = ((TextBox)(row.FindControl("txt_nombre_gasto")));
					TextBox t_cuenta = ((TextBox)(row.FindControl("cuenta")));
					TextBox t_cuentafac = ((TextBox)(row.FindControl("cuentafac")));
					TextBox t_nombrecuenta = ((TextBox)(row.FindControl("nombrecuenta")));
                    CheckBox t_check =((CheckBox)(row.FindControl("chk")));
                    CheckBox t_check_trans = ((CheckBox)(row.FindControl("chk_trans")));
					CheckBox t_check_habil = ((CheckBox)(row.FindControl("chk_habilitado")));

                    chk = "FALSE";
                    chk_trans = "FALSE";
					chk_habil = "FALSE";

                    if (t_check.Checked == true)
                    { chk = "TRUE";
                    }
                    if (t_check_trans.Checked == true)
                    {
                        chk_trans = "TRUE";
                    }
					if (t_check_habil.Checked == true)
					{
						chk_habil = "TRUE";
					}

                    string add = new TipogastoBC().add_tipogasto(id_tipogasto,
                                                    Convert.ToDouble(t_valor.Text),
                                                    t_nombre.Text,
                                                    Convert.ToInt16(id_cliente),
                                                    this.dl_producto.SelectedValue,
                                                    chk, chk_trans,chk_habil,t_cuenta.Text,t_cuentafac.Text);


                    


                        

                }
            }

            FuncionGlobal.alerta("GASTOS ACTUALIZADOS CON EXITO", Page);
            getalltipogasto();                    

        }

        protected void chk_gasto_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
