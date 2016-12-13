using System;
using System.Collections;
using System.Collections.Generic;
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
using sistemaAGP.IntegracionProvidencia;

namespace sistemaAGP
{
	public partial class gastooperacion : System.Web.UI.Page
	{
		private string id_solicitud;
        Pago EMI = new Pago();
        Pago pag = new Pago();
        Pago placa = new Pago();
        svrAgpSoapClient m = new svrAgpSoapClient();
        

		protected void Page_Load(object sender, EventArgs e)
		{
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
           this.lbl_operacion.Text = id_solicitud;

            //EMI = m.getEmitidoByOperacion(Convert.ToInt32(id_solicitud));
            //pag = m.getPagoByOperacion(Convert.ToInt32(id_solicitud));

            var tip = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

            if (tip.Tipo_operacion.Id_familia == 1)
            {
                EMI = m.getEmitidoByOperacion(Convert.ToInt32(id_solicitud));
                pag = m.getPagoByOperacion(Convert.ToInt32(id_solicitud));
            }

            

            //placa = m.getEmitidoByPlaca("gths62");

            if (!IsPostBack)
			{
				getGasto();
			}
		}

		protected void Total_general()
		{
			this.lbl_total.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_valor_gasto"));
			this.lbl_cargo_empresa.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_empresa"));
			this.lbl_cargo_cliente.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_cliente"));
		}

		protected void txt_valor_gasto_Leave(object sender, EventArgs e)
		{
			Total_general();
		}

		protected void txt_cargo_empresa_Leave(object sender, EventArgs e)
		{
			Total_general();
		}

		protected void txt_cargo_cliente_Leave(object sender, EventArgs e)
		{
			Total_general();
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
			Total_general();
		}

		protected void Check_Grilla_Clicked(Object sender, EventArgs e)
		{
			Total_general();
		}

		public void getGasto()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_tipogasto"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("valor"));
			dt.Columns.Add(new DataColumn("cargo_cliente"));
			dt.Columns.Add(new DataColumn("cargo_empresa"));
			DataColumn col = new DataColumn("check");
			DataColumn coll = new DataColumn("checkgc");
			DataColumn colll = new DataColumn("bloqueo");
			col.DataType = System.Type.GetType("System.Boolean");
			coll.DataType = System.Type.GetType("System.Boolean");
			colll.DataType = System.Type.GetType("System.Boolean");

			dt.Columns.Add(col);
			dt.Columns.Add(coll);
			dt.Columns.Add(colll);

			List<GastoOperacion> lgasto = new GastooperacionBC().Getgastooperacion(Convert.ToInt32(id_solicitud));

            //getPagoByOperacionRequest id = new getPagoByOperacionRequest();
            //id.Body.IdOperacion = Convert.ToInt32(id_solicitud);

           

			if (lgasto.Count > 0)
			{
				this.bt_guardar.Visible = true;
			}

			foreach (GastoOperacion mgasto in lgasto)
			{
				DataRow dr = dt.NewRow();

				dr["checkgc"] = mgasto.Tipogasto.Check;
				dr["id_tipogasto"] = mgasto.Tipogasto.Id_tipogasto;
				dr["descripcion"] = mgasto.Tipogasto.Descripcion;

                if (mgasto.Tipogasto.Check == true && mgasto.Tipogasto.Id_tipogasto == 32)
                {
                    if (EMI.IdOperacion != 0)
                    {
                        dr["valor"] = EMI.total_pago;

                        Preinscripcion pre = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(Convert.ToInt32(id_solicitud));
                        int cargo = Convert.ToInt32(pre.Cargo_venta.Trim());

                        switch (cargo)
                        {
                            case 1:
                                dr["cargo_empresa"] = EMI.total_pago;
                                 dr["cargo_cliente"] = 0;
                                break;
                            case 2:
                                dr["cargo_empresa"] = 0;
                                dr["cargo_cliente"] = EMI.total_pago;
                                break;
                            case 4:
                                dr["cargo_empresa"] = EMI.total_pago / 2;
                                dr["cargo_cliente"] = EMI.total_pago / 2;
                                break;
                            case 5:
                                dr["cargo_empresa"] = 0;
                                dr["cargo_cliente"] = EMI.total_pago;
                                break;
                            case 6:
                                dr["cargo_empresa"] = EMI.total_pago;
                                dr["cargo_cliente"] = 0;
                                break;
                        }

                          
                        
                        //--239
                    }
                    else
                    {
                        dr["valor"] = mgasto.Monto;
                        dr["cargo_empresa"] = mgasto.Cargo_empresa;
                        dr["cargo_cliente"] = mgasto.Cargo_cliente;
                        FuncionGlobal.alerta_updatepanel("NO EXISTE EL PERMISO EN LA BASE DE PROVIDENCIA", this.Page, this.up_datos);
                    }
                }
                else
                {
                    dr["valor"] = mgasto.Monto;
                    dr["cargo_empresa"] = mgasto.Cargo_empresa;
                    dr["cargo_cliente"] = mgasto.Cargo_cliente;
                }

				dr["check"] = mgasto.Check;
				dr["bloqueo"] = mgasto.Bloqueo;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
			Total_general();
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
             EstadoOperacion mesta = new EstadooperacionBC().getEstadobyorden(Convert.ToInt32(id_solicitud), 88);

             Usuario usu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));


             if (usu.Permite_eliminar == true)
             {
                 if ((Convert.ToInt32(this.lbl_cargo_cliente.Text) + Convert.ToInt32(this.lbl_cargo_empresa.Text)) != Convert.ToInt32(this.lbl_total.Text))
                 {
                     FuncionGlobal.alerta_updatepanel("EXISTEN DIFERENCIAS ENTRE LOS MONTOS", this.Page, this.up_datos);
                 }
                 else
                 {
                     add_gastos();
                     FuncionGlobal.alerta_updatepanel("GASTOS ACTUALIZADOS CON EXITO", this.Page, this.up_datos);
                     if (EMI.IdOperacion != 0)
                     {
                         string add_or = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(id_solicitud), 239, "PERMISO EMITIDO POR PROVIDENCIA", (string)(Session["usrname"]));
                     }
                 }

             }
             else
             {
                 if (mesta.Permite_estado == false)
                 {

                     if ((Convert.ToInt32(this.lbl_cargo_cliente.Text) + Convert.ToInt32(this.lbl_cargo_empresa.Text)) != Convert.ToInt32(this.lbl_total.Text))
                     {
                         FuncionGlobal.alerta_updatepanel("EXISTEN DIFERENCIAS ENTRE LOS MONTOS", this.Page, this.up_datos);
                     }
                     else
                     {
                         add_gastos();
                         FuncionGlobal.alerta_updatepanel("GASTOS ACTUALIZADOS CON EXITO", this.Page, this.up_datos);
                         if (EMI.IdOperacion != 0)
                         {
                             string add_or = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(id_solicitud), 239, "PERMISO EMITIDO POR PROVIDENCIA", (string)(Session["usrname"]));
                         }
                     }
                 }
                 else
                 {
                     FuncionGlobal.alerta_updatepanel("NO SE PUEDE MODIFICAR LOS GASTOS, YA QUE LA OPERACION ESTA EN COBRANZA", this.Page, this.up_datos);
                     //FuncionGlobal.alerta("NO SE PUEDE MODIFICAR LOS GASTOS, YA QUE LA OPERACION ESTA EN COBRANZA", this.Page);
                 }
             }

         
		}

		private void add_gastos()
		{
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				string id_tipogasto = this.gr_dato.Rows[i].Cells[1].Text;
				string chkgc = ((CheckBox)gr_dato.Rows[i].FindControl("chkgc")).Checked.ToString();

				if (chk.Checked == true)
				{
					TextBox txt = (TextBox)gr_dato.Rows[i].FindControl("txt_valor_gasto");
					TextBox txt_ccliente = (TextBox)gr_dato.Rows[i].FindControl("txt_cargo_cliente");
					TextBox txt_cempresa = (TextBox)gr_dato.Rows[i].FindControl("txt_cargo_empresa");
					Int32 montogasto = Convert.ToInt32(txt.Text.ToString());
					Int32 cargo_cliente = Convert.ToInt32(txt_ccliente.Text.ToString());
					Int32 cargo_empresa = Convert.ToInt32(txt_cempresa.Text.ToString());
					string add = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt16(id_tipogasto), montogasto, (string)(Session["usrname"]), cargo_cliente, cargo_empresa, chkgc);

				}
				else
				{
                     Usuario usu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));

                     if (usu.UserName.Trim() == "116333627" || usu.UserName.Trim() == "153636613" || usu.UserName.Trim() == "141548085" || usu.UserName.Trim() == "118550129" || usu.UserName.Trim() == "153944601" || usu.UserName.Trim() == "17483833k")
                     {
                         string add = new GastooperacionBC().del_gastooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt16(id_tipogasto), chkgc, (string)(Session["usrname"]));
                     }
				}
			}
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				try
				{
					if (Convert.ToBoolean(this.gr_dato.DataKeys[e.Row.RowIndex].Values["bloqueo"]))
					{
						((TextBox)e.Row.FindControl("txt_valor_gasto")).Enabled = false;
						((TextBox)e.Row.FindControl("txt_cargo_cliente")).Enabled = false;
						((TextBox)e.Row.FindControl("txt_cargo_empresa")).Enabled = false;
					}
				}
				catch
				{
				}
			}
		}

        protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

   
	}
}