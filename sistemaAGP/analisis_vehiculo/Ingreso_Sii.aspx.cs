using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class Ingreso_Sii : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
				FuncionGlobal.combomarcavehiculo(this.dl_marca_vehiculo);
				FuncionGlobal.comboparametro(this.dl_combustible, "COMB");
				FuncionGlobal.comboparametro(this.dl_transmicion, "TRAUT");
				FuncionGlobal.comboparametro(this.dl_equipo, "EQUIP");
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			UpdatePanel up = this.UpdatePanel1;
			if (this.dl_tipo_vehiculo.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Tipo de Vehiculo", Page, up);
				return;
			}


			if (this.dl_marca_vehiculo.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Marca del  Vehiculo", Page, up);
				return;
			}

			if (this.dl_combustible.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Combustible del Vehiculo", Page, up);
				return;
			}
			if (this.dl_transmicion.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Transmicion del Vehiculo", Page, up);
				return;
			}
			if (this.dl_equipo.SelectedValue == "0")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Equipamiento del Vehiculo", Page, up);
				return;
			}
			if (this.txt_ano.Text == "")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Año del Vehiculo", Page, up);
				return;
			}

			if (this.txt_tasacion.Text == "")
			{
				FuncionGlobal.alerta_updatepanel("Ingrese Tasacion del Vehiculo", Page, up);
				return;
			}
			add();
			FuncionGlobal.alerta_updatepanel("Codigo Creado con Exito", Page, up);
		}



		protected void limpair()
		{
			this.dl_tipo_vehiculo.SelectedValue = "0";
			this.dl_marca_vehiculo.SelectedValue = "0";
			this.txt_modelo.Text = "";
			this.txt_ano.Text = "";
			this.txt_cilindrada.Text = "";
			this.txt_puerta.Text = "";
			this.dl_combustible.SelectedValue = "0";
			this.dl_transmicion.SelectedValue = "0";
			this.dl_equipo.SelectedValue = "0";
			this.txt_tasacion.Text = "";
			this.txt_permiso.Text = "";
			this.lbl_codigo.Text = "";
		}


		protected void add()
		{

			Marcavehiculo marca = new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue));
			Tipovehiculo vehi = new TipovehiculoBC().getTipoVehiculo(this.dl_tipo_vehiculo.SelectedValue);

			string codigo = new TasacionSIIBC().add_tasacionSII(vehi, marca, this.txt_modelo.Text, Convert.ToInt16(this.txt_ano.Text), this.txt_cilindrada.Text, Convert.ToInt16(this.txt_puerta.Text), this.dl_combustible.SelectedValue,
															  this.dl_transmicion.SelectedValue, this.dl_equipo.SelectedValue, Convert.ToInt32(this.txt_tasacion.Text), 0);


			this.lbl_codigo.Text = codigo;
		}


		protected void Button2_Click(object sender, EventArgs e)
		{
			limpair();
		}


	}

}