using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP
{
	public partial class Control_Maestro : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_desde.Text = DateTime.Today.AddDays(-7).ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.cal_desde.FirstDayOfWeek = FirstDayOfWeek.Monday;
				this.cal_hasta.FirstDayOfWeek = FirstDayOfWeek.Monday;
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
				FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
			if (Convert.ToInt16(this.dl_cliente.SelectedValue) == 0)
			{
				FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}
			else
			{
				FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
		}

		protected void bt_exportar_Click(object sender, ImageClickEventArgs e)
		{
			this.exportar_control_maestro();
		}

		protected void exportar_control_maestro()
		{
			Int16 id_cliente = Convert.ToInt16(this.dl_cliente.SelectedValue);
			int id_sucursal = Convert.ToInt32(this.dl_sucursal.SelectedValue);
			int id_solicitud = Convert.ToInt32(this.txt_operacion.Text != "" ? this.txt_operacion.Text : "0");
			DateTime desde = Convert.ToDateTime(this.txt_desde.Text);
			DateTime hasta = Convert.ToDateTime(this.txt_hasta.Text);
			double rut = Convert.ToDouble(this.txt_rut.Text != "" ? this.txt_rut.Text : "0");
			string patente = this.txt_patente.Text.Trim();
			string tipo_operacion = this.dl_producto.SelectedValue.Trim();

			if (id_solicitud != 0 || rut != 0 || patente != "")
			{
				id_cliente = 0;
				id_sucursal = 0;
				desde = DateTime.MinValue;
				hasta = DateTime.MaxValue;
				tipo_operacion = "0";
			}

			SqlParameter[] param = new SqlParameter[] {
				new SqlParameter("@id_cliente", id_cliente),
				new SqlParameter("@id_sucursal", id_sucursal),
				new SqlParameter("@id_solicitud", id_solicitud),
				new SqlParameter("@desde", desde),
				new SqlParameter("@hasta", hasta),
				new SqlParameter("@rut", rut),
				new SqlParameter("@patente", patente),
				new SqlParameter("@tipo_operacion", tipo_operacion)
			};

			ExportarExcel.ExportStoredProcedure("ControlMaestro.xls", "sp_r_getControlMaestroPrenda", param);
		}
	}
}