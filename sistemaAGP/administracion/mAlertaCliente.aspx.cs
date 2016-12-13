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

namespace sistemaAGP.administracion
{
    public partial class mAlertaCliente : System.Web.UI.Page
    {

		string codigo;
		Int16 id_cliente;
		
			protected void Page_Load(object sender, EventArgs e)
		{
			
			
			string id_cli_encrip;
			id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
			id_cliente = Convert.ToInt16(id_cli_encrip);

			codigo = Request.QueryString["id_producto"];

			if (!IsPostBack)
			{

				FuncionGlobal.combofamilia_cliente(dl_familia, Convert.ToInt16(id_cliente));

			}

			
			
				
				
		}

			protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
			{
				int id_cliente;
				string id_cli_encrip;
				id_cli_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
				id_cliente = Convert.ToInt16(id_cli_encrip);
				


				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					EstadoTipoOperacion mtipooperacion = new EstadoTipoOperacion();

					mtipooperacion.Codigo_estado = 0;
					mtipooperacion.Descripcion = "Seleccionar";
					List<EstadoTipoOperacion> ltipooperacion = new EstadotipooperacionBC().getEstadoByFamilia(Convert.ToInt16(dl_familia.SelectedValue));
					
					ltipooperacion.Add(mtipooperacion);

					DropDownList dl = (DropDownList)e.Row.FindControl("dl_estado");
					

					dl.DataSource = ltipooperacion;
					dl.DataValueField = "codigo_estado";
					dl.DataTextField = "descripcion";
					dl.DataBind();

					Documentos mdocuemnto = new Documentos();
					mdocuemnto.Id_documento = 0;
					mdocuemnto.Nombre = "Seleccionar";



					List<Documentos> ldocumento = new DocumentosBC().getallDocumentos();
					ldocumento.Add(mdocuemnto);

					DropDownList dl2 = (DropDownList)e.Row.FindControl("dl_documento");

					dl2.DataSource = ldocumento;
					dl2.DataValueField = "id_documento";
					dl2.DataTextField = "nombre";
					dl2.DataBind();




					dl.SelectedValue = gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();
					dl2.SelectedValue = gr_dato.DataKeys[e.Row.RowIndex].Values[3].ToString();
				}
			}

		
		private void getestadoall()
		{

			

			DataTable dt = new DataTable();
			
			dt.Columns.Add(new DataColumn("id_alerta"));
			dt.Columns.Add(new DataColumn("codigo_estado"));
			dt.Columns.Add(new DataColumn("id_cliente"));
			dt.Columns.Add(new DataColumn("dias_primer_aviso"));
			dt.Columns.Add(new DataColumn("dias_ultimo_aviso"));
			dt.Columns.Add(new DataColumn("caducidad_estado"));
			dt.Columns.Add(new DataColumn("contador_estado"));
			dt.Columns.Add(new DataColumn("id_documento"));
			//dt.Columns.Add(new DataColumn("envia_adquiriente"));
			dt.Columns.Add(new DataColumn("lista_correo"));
			dt.Columns.Add(new DataColumn("descripcion"));
			DataColumn col = new DataColumn("envia_adquiriente");
			col.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(new DataColumn("url_modulo"));
            DataColumn colhabilitado = new DataColumn("chk_habilitado");
            colhabilitado.DataType = System.Type.GetType("System.Boolean");
            dt.Columns.Add(colhabilitado);
           
			
			dt.Columns.Add(col);

            List<AlertaestadoCliente> lEstadotipooperacion = new AlertaestadoClienteBC().getEstadoAlertaFamiliaCliente(Convert.ToInt32(dl_familia.SelectedValue), id_cliente);

            

			foreach (AlertaestadoCliente estadotipo in lEstadotipooperacion)
			{
				DataRow dr = dt.NewRow();

				
				dr["id_alerta"] = estadotipo.Id_alerta;
				dr["codigo_estado"] = estadotipo.Estado_alerta.Codigo_estado ;
				dr["descripcion"] = estadotipo.Estado_alerta.Descripcion;
				dr["id_cliente"] = estadotipo.Id_cliente;
				dr["dias_primer_aviso"] = estadotipo.Dias_primer_a;
				dr["dias_ultimo_aviso"] = estadotipo.Dias_ultimo_a;
				dr["caducidad_estado"] = estadotipo.Caducidad_estado;
				dr["contador_estado"] = estadotipo.Contador_estado;
				dr["id_documento"] = estadotipo.Id_documento;
				dr["envia_adquiriente"] = estadotipo.Envia_adquiriente;
				dr["lista_correo"] = estadotipo.Lista_correo;
                dr["chk_habilitado"] = estadotipo.Habilitado; 
				dr["url_modulo"] = "mreglaestadocliente.aspx?id_alerta=" + FuncionGlobal.FuctionEncriptar (  estadotipo.Id_alerta.ToString()) + "&id_familia=" +  FuncionGlobal.FuctionEncriptar(dl_familia.SelectedValue)
					+ "&codigo_estado=" + FuncionGlobal.FuctionEncriptar(estadotipo.Codigo_estado.ToString()  );
				
				dt.Rows.Add(dr);
			}



			 this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
        }

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Button2.Visible = true;
			getestadoall();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			
		}


		protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}


		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}

		protected void presionado(object sender, EventArgs e)
		{
			GridViewRow row;



			string add_MU = "";

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];


				TextBox txt_correo = (TextBox)gr_dato.Rows[i].FindControl("txt_correo");
				CheckBox chk_aviso = (CheckBox)gr_dato.Rows[i].FindControl("chk_aviso");
                CheckBox chk_habilitado = (CheckBox)gr_dato.Rows[i].FindControl("check_habilitado");
				TextBox txt_fecha = (TextBox)gr_dato.Rows[i].FindControl("txt_aviso");
				TextBox txt_termino = (TextBox)gr_dato.Rows[i].FindControl("txt_termino");
				TextBox txt_caducidad = (TextBox)gr_dato.Rows[i].FindControl("txt_caducidad");
				DropDownList dl = (DropDownList)gr_dato.Rows[i].FindControl("dl_estado");
				DropDownList dl2 = (DropDownList)gr_dato.Rows[i].FindControl("dl_documento");
				Int16 kay1 = Convert.ToInt16(gr_dato.DataKeys[i].Values[0].ToString());
				Int16 kay2 = Convert.ToInt16(gr_dato.DataKeys[i].Values[1].ToString());

				string estado = dl.SelectedValue.ToString();
				string documento = dl.SelectedValue.ToString();
				string correo = txt_correo.Text.ToString();
				string aviso = txt_fecha.Text.ToString();
				string termino = txt_termino.Text.ToString();
				string caducidad = txt_caducidad.Text.ToString();
				string check = chk_aviso.Checked.ToString();
                string str_habilitado = chk_habilitado.Checked.ToString();
				if (aviso.Trim() == "") { aviso = "0"; }
				if (termino.Trim() == "") { termino = "0"; }
				if (caducidad.Trim() == "") { caducidad = "0"; }



				add_MU = new AlertaestadoClienteBC().add_Alerta_estado_cliente(kay1, kay2, id_cliente, correo, chk_aviso.Checked.ToString(), Convert.ToInt16(aviso), Convert.ToInt16(termino), Convert.ToInt16(caducidad), Convert.ToInt16(estado), Convert.ToInt16(documento),str_habilitado);


				



			}
			this.getestadoall(); 
		}


		 


    }
}