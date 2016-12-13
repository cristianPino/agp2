using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;
using CNEGOCIO;
using CENTIDAD;


namespace sistemaAGP
{
	public partial class Doc_Garantia : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Response.ExpiresAbsolute = DateTime.Now;
				Response.Expires = -1441;
				Response.CacheControl = "no-cache";
				Response.AddHeader("Pragma", "no-cache");
				Response.AddHeader("Pragma", "no-store");
				Response.AddHeader("cache-control", "no-cache");
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
				Response.Cache.SetNoServerCaching();

				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combotipooperacion(this.dl_producto);
				getnotaria(this.dl_notaria);
			}
		}

		protected void Click_Gasto(Object sender, EventArgs e)
		{
			busca_operacion();
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
			if (this.dl_notaria.SelectedValue != "0" && this.dl_producto.SelectedValue != "0")
			{
				getmatrizdocumento(this.dl_doc);
			}
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			busca_operacion();
		}

		private void busca_operacion()
		{
			if (this.dl_notaria.SelectedValue == "0" || this.dl_producto.SelectedValue == "0" || this.dl_cliente.SelectedValue == "0")
			{
				return;
			}
			double rut;
			Int32 factura;
			Int32 noperacion;
			Int32 estado_actual;
			Int16 dl_modulo;
			Int16 dl_sucursal;
			if (this.txt_rut.Text.Trim() == "")
			{ rut = 0; }
			else
			{ rut = Convert.ToDouble(this.txt_rut.Text); }

			if (this.txt_operacion.Text.Trim() == "")
			{ noperacion = 0; }
			else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

			if (this.txt_factura.Text.Trim() == "")
			{ factura = 0; }
			else { factura = Convert.ToInt32(this.txt_factura.Text); }

			if (this.dpl_estado.SelectedValue == "")
			{ estado_actual = 0; }
			else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

			if (this.dl_modulo.SelectedValue == "")
			{ dl_modulo = 0; }
			else { dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue); }

			if (this.dl_sucursal.SelectedValue == "")
			{ dl_sucursal = 0; }
			else { dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue); }

			List<Operacion> loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue.Trim(), dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), this.txt_patente.Text.Trim(), string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())), string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())), estado_actual, (string)(Session["usrname"]), 0, "TODO",0,"","",0);

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("cod_tip_operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("cliente_nombre"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));
			dt.Columns.Add(new DataColumn("doc"));

			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				Documento_garantia doc_gar = new Documento_garantiaBC().getdocumento_garantia(moperacion.Id_solicitud);
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["cliente_nombre"] = moperacion.Cliente.Persona.Nombre;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Operacion;
				dr["cod_tip_operacion"] = moperacion.Tipo_operacion.Codigo;
				dr["doc"] = doc_gar.Documento;
				if (moperacion.Adquiriente != null)
				{
					dr["rut_persona"] = moperacion.Adquiriente.Rut;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
				}
				else
				{
					dr["rut_persona"] = "0";
					dr["nombre_persona"] = "Sin Adquiriente";
				}
				dr["ultimo_estado"] = moperacion.Estado;
				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

			getestado(this.dl_producto.SelectedValue, this.dpl_estado);
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
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

		private void getmatrizdocumento(DropDownList combo)
		{
			Matriz_Escritura mmatriz = new Matriz_Escritura();
			mmatriz.Cod_matriz = 0;
			mmatriz.Descripcion = "Seleccionar";
			Int32 id_cliente = Convert.ToInt32(this.dl_cliente.SelectedValue);
			Int32 cod_notaria = Convert.ToInt32(this.dl_notaria.SelectedValue);
			List<Matriz_Escritura> lmatriz = new Matriz_EscrituraBC().getmatriz(id_cliente, cod_notaria, this.dl_producto.SelectedValue);
			lmatriz.Add(mmatriz);
			combo.DataSource = lmatriz;
			combo.DataValueField = "cod_matriz";
			combo.DataTextField = "descripcion";
			combo.DataBind();
			combo.SelectedValue = "0";
			return;
		}

		private void getnotaria(DropDownList combo)
		{
			Notaria mnotaria = new Notaria();
			mnotaria.Cod_notaria = "0";
			mnotaria.Nombre = "Seleccionar";
			List<Notaria> lmatriz = new NotariaBC().getNotaria();
			lmatriz.Add(mnotaria);
			combo.DataSource = lmatriz;
			combo.DataValueField = "cod_notaria";
			combo.DataTextField = "nombre";
			combo.DataBind();
			combo.SelectedValue = "0";
			return;
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_producto.SelectedValue != "0")
			{
				this.lbl_flujo.Visible = true;
				this.dpl_estado.Visible = true;
				getestado(this.dl_producto.SelectedValue, this.dpl_estado);
			}
			else
			{
				this.lbl_flujo.Visible = false;
				this.dpl_estado.Visible = false;
			}

			if (this.dl_cliente.SelectedValue != "0" && this.dl_notaria.SelectedValue != "0")
			{
				getmatrizdocumento(this.dl_doc);
			}
		}

		protected void dl_notaria_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_cliente.SelectedValue != "0" && this.dl_producto.SelectedValue != "0")
			{
				getmatrizdocumento(this.dl_doc);
			}
		}

		protected void ib_word_Click(object sender, ImageClickEventArgs e)
		{
			UpdatePanel up = (UpdatePanel)this.Page.FindControl("up_grilla");
			Int32 tipo = Convert.ToInt32(this.dl_doc.SelectedValue);

			if (tipo > 0)
			{
				GridViewRow row;
				HyperLink but;
				for (int i = 0; i < gr_dato.Rows.Count; i++)
				{
					row = gr_dato.Rows[i];
					CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

					but = (HyperLink)row.Cells[0].Controls[0];
					string id_solicitud = but.Text.Trim();

					if (chk.Checked == true)
					{
						crearescritura(Convert.ToInt32(id_solicitud), tipo);
					}
				}
				//Para darle tiempo al demonio para generar las escrituras
				FuncionGlobal.Sleep(10);
				FuncionGlobal.alerta_updatepanel("Documento(s) de Garantia generado(s) con exito", this.Page, this.up_grilla);
			}
			else
			{
				FuncionGlobal.alerta_updatepanel("Debe selecionar una opcion en los *", this.Page, this.up_grilla);
			}
			busca_operacion();
			return;
		}

		public void crearescritura(Int32 id_solicitud, Int32 cod_matriz)
		{
			Int32 tipo = Convert.ToInt32(this.dl_doc.SelectedValue);
			Matriz_Escritura matriz = new Matriz_EscrituraBC().getmatrizbycod(tipo,0);

			string origen = Server.MapPath(matriz.Url_matriz.Trim());
			string destino = Server.MapPath(matriz.Url_destino.Trim() + "\\" + id_solicitud + ".doc");
			string add = new Documento_garantiaBC().add_escritura_pendiente(id_solicitud, origen, destino);

			string document = new Documento_garantiaBC().add_documento_garantia(id_solicitud, (string)(Session["usrname"]), cod_matriz, DateTime.Now, true);
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink but;
				ImageButton ibuton;
				string tipo;
				string id_cliente;
				string tiene_doc;
				//string cliente = this.gr_dato.DataKeys[e.Row.RowIndex].Value.ToString();

				but = (HyperLink)e.Row.Cells[0].Controls[0];
				id_cliente = gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();// row.Cells[1].Text.Trim();
				tiene_doc = gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString();
				tipo = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();

				TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

				but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "patente=&ventatipo=','_blank','" + op.Tamano + "')");

				ibuton = (ImageButton)e.Row.FindControl("ib_workflow");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mWorkflow.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_cdigital");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=eo','','status:false;dialogWidth:800px;dialogHeight:600px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_reemplazar");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('UploadEscritura.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente) + "','','status:false;dialogWidth:600px;dialogHeight:400px')");
				ibuton.Visible = Convert.ToBoolean(tiene_doc);

				HyperLink lnk = (HyperLink)e.Row.FindControl("lnk_word");
				if (tiene_doc == "True")
				{
					string url = "";
                    //switch (id_cliente)
                    //{
                    //    case "1": //AGP S.A.
                    //        url = "generadas/agp/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "4": //AUTOMOTORES GILDEMEISTER S.A.
                    //        url = "generadas/ag/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "6": //AUTOMOTRIZ PORTILLO S.A.
                    //        url = "generadas/portillo/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "10": //AMICAR
                    //        url = "generadas/amicar/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "14": //BICE CREDIAUTO
                    //        url = "generadas/bice/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "15": //BANCO ESTADO
                    //        url = "generadas/bestado/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "16": //SANTANDER CONSUMER
                    //        url = "generadas/santander/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "19": //SCOTIABANK
                    //        url = "generadas/scotiabank/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "35": //AUTOMOTORA PORTEZUELO S.A.
                    //        url = "generadas/portezuelo/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "44": //FACTORLINE
                    //        url = "generadas/factorline/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    case "50": //TANNER
                    //        url = "generadas/tanner/" + but.Text.Trim() + ".doc";
                    //        break;
                    //    default:
                    //        url = "generadas/" + but.Text.Trim() + ".doc";
                    //        break;
                    //}

                    Int32 documento = Convert.ToInt32(this.dl_doc.SelectedValue);
                    Matriz_Escritura matriz = new Matriz_EscrituraBC().getmatrizbycod(documento,Convert.ToInt32(this.dl_cliente.SelectedValue));
                    url = matriz.Url_destino.Trim() + but.Text.Trim() + ".doc";

					lnk.ImageUrl = "../imagenes/sistema/static/word-small.jpg";
					lnk.NavigateUrl = url;
					lnk.ToolTip = "Escritura";
					lnk.Target = "_blank";
				}
				else
				{
					lnk.ImageUrl = "../imagenes/sistema/static/no-small.jpg";
					lnk.NavigateUrl = "javascript:alert('La operacion " + but.Text.Trim() + " no tiene su documento generado');";
					lnk.ToolTip = "Sin Escritura";
					lnk.Target = "_self";
				}
			}
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}