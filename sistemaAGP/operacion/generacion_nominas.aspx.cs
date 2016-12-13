using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class generacion_nominas : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FuncionGlobal.combofamiliabyusuario(Session["usrname"].ToString(), this.dl_familia);
				if (this.dl_familia.Items.Count == 2)
					this.dl_familia.SelectedIndex = 1;
				FuncionGlobal.comboTipoNominaByFamilia(this.dl_tiponomina, Convert.ToInt32(this.dl_familia.SelectedValue));
				FuncionGlobal.comboclientesbyusuario(Session["usrname"].ToString(), this.dl_cliente);
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), Session["usrname"].ToString());
				this.txt_desde.Text = DateTime.Now.ToShortDateString();
				this.txt_hasta.Text = DateTime.Now.ToShortDateString();
				this.txt_observaciones.Text = "";

				this.Buscar_Operaciones();
			}
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.comboTipoNominaByFamilia(this.dl_tiponomina, Convert.ToInt32(this.dl_familia.SelectedValue));
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), Session["usrname"].ToString());
		}

		protected void bt_buscar_Click(object sender, ImageClickEventArgs e)
		{
			if (this.ValidarAntesDeBuscar())
				this.Buscar_Operaciones();
		}

		protected void bt_generar_Click(object sender, ImageClickEventArgs e)
		{
			if (!this.ValidarAntesDeGenerar())
				FuncionGlobal.alerta_updatepanel("No hay filas seleccionadas para la generación de la nómina", this, this.up_filtros);
			else
				this.GenerarNomina();
		}

		protected bool ValidarAntesDeBuscar()
		{
			if (this.dl_familia.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Debe seleccionar la familia", this, this.up_filtros);
				this.dl_familia.Focus();
				return false;
			}
			if (this.dl_tiponomina.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Debe seleccionar un tipo de nómina", this, this.up_filtros);
				this.dl_tiponomina.Focus();
				return false;
			}
			return true;
		}

		protected bool ValidarAntesDeGenerar()
		{
			//Valida que existan filas seleccionadas
			if (this.gr_dato.Rows.Count > 0)
			{
				var query = (from r in this.gr_dato.Rows.OfType<GridViewRow>()
							 where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
							 select r).Count();
				return query > 0;
			}
			else
			{
				return false;
			}
		}

		protected void chk_checkall_CheckedChanged(object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(this.gr_dato);
		}

		protected void Buscar_Operaciones()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud", System.Type.GetType("System.Int32")));
			dt.Columns.Add(new DataColumn("id_cliente", System.Type.GetType("System.Int32")));
			dt.Columns.Add(new DataColumn("nombre_cliente", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("tipo_operacion", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("operacion", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("numero_factura", System.Type.GetType("System.Int32")));
			dt.Columns.Add(new DataColumn("patente", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("rut_persona", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("nombre_persona", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));

			List<Operacion> loperacion = new OperacionBC().getOperacionesParaNomina(Convert.ToInt32(this.dl_tiponomina.SelectedValue), Convert.ToInt32(this.dl_cliente.SelectedValue), Convert.ToDateTime(this.txt_desde.Text), Convert.ToDateTime(this.txt_hasta.Text), Session["usrname"].ToString());
			if (loperacion != null)
			{
				this.bt_generar.Enabled = true;
				foreach (Operacion op in loperacion)
				{
					DataRow dr = dt.NewRow();
					dr["id_solicitud"] = op.Id_solicitud;
					dr["id_cliente"] = op.Cliente.Id_cliente;
					dr["nombre_cliente"] = op.Cliente.Persona.Nombre;
					dr["tipo_operacion"] = op.Tipo_operacion.Codigo;
					dr["operacion"] = op.Tipo_operacion.Operacion;
					dr["numero_factura"] = op.Numero_factura;
					dr["patente"] = op.Patente;

                    if (op.Adquiriente != null)
                    {
                        dr["rut_persona"] = op.Adquiriente.Rut.ToString("N0") + "-" + op.Adquiriente.Dv;
                        dr["nombre_persona"] = string.Format("{0} {1} {2}", op.Adquiriente.Nombre, op.Adquiriente.Apellido_paterno, op.Adquiriente.Apellido_materno).Trim();
                    }
                    else
                    {
                        dr["rut_persona"] = "0-0";
                        dr["nombre_persona"] = "Sin Adquiriente";
                    
                    }

                    
					dr["ultimo_estado"] = op.Estado;
					dt.Rows.Add(dr);
				}
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void GenerarNomina()
		{
			TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.dl_tiponomina.SelectedValue));

			int folio = Convert.ToInt32(lTiponomina.Folio);
			int orden_new = lTiponomina.Orden_new;

			var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
						where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
						select r;
			foreach (GridViewRow r in query)
			{
				string add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(this.gr_dato.DataKeys[r.RowIndex].Values[0]), Convert.ToInt32(this.dl_tiponomina.SelectedValue), folio, Session["usrname"].ToString());
				if (orden_new != 0)
					add = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(this.gr_dato.DataKeys[r.RowIndex].Values[0]), orden_new, this.gr_dato.DataKeys[r.RowIndex].Values[2].ToString(), this.txt_observaciones.Text.Trim(), Session["usrname"].ToString());
			}
			string upd = new TipoNominaBC().upd_FolioNomina(Convert.ToInt32(this.dl_tiponomina.SelectedValue));

			string cadena = "/reportes/view_nomina.aspx";
			cadena += "?id_familia=" + this.dl_familia.SelectedValue;
			cadena += "&folio=" + folio.ToString();
			cadena += "&id_nomina=" + this.dl_tiponomina.SelectedValue;
			ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ViewNomina", "window.open('" + cadena + "');", true);
			
			this.Buscar_Operaciones();
		}
	}
}