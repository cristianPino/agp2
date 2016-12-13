using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP
{
	public partial class control_operaciones_peru_adv : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combofamilia_producto(this.dl_familia);
               
			}
		}

		protected void Click_Gasto(Object sender, EventArgs e)
		{
			busca_operacion();
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{

            FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			busca_operacion();
		}

		private void busca_operacion()
		{
			if (this.dl_familia.SelectedValue == "0")
			{
				return;
			}

			string rut = "";
			string factura = "";
			Int32 noperacion = 0;
			Int32 estado_actual = 0;
			Int16 dl_modulo = 0;
			Int16 dl_sucursal = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
			string patente = this.txt_patente.Text.Trim();

			if (this.txt_rut.Text.Trim() != "") rut = this.txt_rut.Text;
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.txt_factura.Text.Trim() != "") factura = this.txt_factura.Text;
			if (this.dpl_estado.SelectedValue != "") estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue);
			
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);

			if (noperacion != 0 || factura != "" || patente != "")
			{
				desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
				hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			}

			List<OperacionPeru> loperacion = new OperacionBC().getOperacionesPeru("0", dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue));

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("nombre_cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("total_egreso"));
			dt.Columns.Add(new DataColumn("total_ingreso"));
			dt.Columns.Add(new DataColumn("total_devolucion"));
			dt.Columns.Add(new DataColumn("saldo"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));
			dt.Columns.Add(new DataColumn("factura_emitida"));

			foreach (OperacionPeru moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;
				if (moperacion.Adquiriente != null)
				{
					dr["rut_persona"] = moperacion.Adquiriente.TipoDocumentoIdentidad + " Nº " + moperacion.Adquiriente.NroDocumentoIdentidad;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombres + " " + moperacion.Adquiriente.ApellidoPaterno + " " + moperacion.Adquiriente.ApellidoMaterno;
				}
				else
				{
					dr["rut_persona"] = "";
					dr["nombre_persona"] = "Sin Adquiriente";
				}
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo.Trim();
				dr["operacion"] = moperacion.Tipo_operacion.Operacion.ToString();
				dr["total_gasto"] = string.Format("{0:C2}", moperacion.Total_gasto * 1.18);
				dr["total_egreso"] = string.Format("{0:C2}", moperacion.Total_egreso);
				dr["total_ingreso"] = string.Format("{0:C2}", moperacion.Total_ingreso);
				dr["total_devolucion"] = string.Format("{0:C2}", moperacion.Total_devolucion);
				dr["saldo"] = string.Format("{0:C2}", (moperacion.Total_ingreso - moperacion.Total_gasto * 1.18));
				dr["ultimo_estado"] = moperacion.Estado;
				dr["factura_emitida"] = moperacion.Factura_emitida;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		private void getestado(string tipo, DropDownList combo)
		{
			EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();
			mEstadotipooperacion.Codigo = "0";
			mEstadotipooperacion.Descripcion = "Seleccionar";
			List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionBC().getEstadoByTipooperacion(tipo);
			lEstadotipooperacion.Add(mEstadotipooperacion);
			combo.DataSource = lEstadotipooperacion;
			combo.DataValueField = "codigo_estado";
			combo.DataTextField = "descripcion";
			combo.DataBind();
			combo.SelectedValue = "0";
			return;
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
			
				getestado("INMA", this.dpl_estado);
		
				this.lbl_flujo.Visible = true;
				this.dpl_estado.Visible = true;
			
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink but;
				ImageButton ibuton;
				string nombre;

				string tipo = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
				int cont = gr_dato.DataKeys.Count;
				Int16 id_cliente = Convert.ToInt16(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());
				nombre = (string)e.Row.Cells[4].Text;
				but = (HyperLink)e.Row.Cells[0].Controls[0];
				TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

                Usuario musuario = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
                if (musuario.Perfil.Codigoperfil.Trim() != "AGPE")
                {
                    but.NavigateUrl = "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "','_blank','dialogheight=600px;dialogWidth=850px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')";
                    //but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "','_blank','dialogheight=600px;dialogWidth=850px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')");
                }
				ibuton = (ImageButton)e.Row.FindControl("ib_workflow");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mOperacion_estado.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(tipo) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&nombre_estado=" + nombre + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_cdigital");
				ibuton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=pc','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");

				//ibuton = (ImageButton)e.Row.FindControl("ib_comGastos");
				//ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");

				ibuton = (ImageButton)e.Row.FindControl("ib_comGastos");
				ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(this.dl_familia.SelectedValue) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");
			}
		}
	}
}