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
    public partial class mcheques : System.Web.UI.Page
    {
        
		private string cuenta_usuario;

     
        protected void Page_Load(object sender, EventArgs e)
        {

			cuenta_usuario = (string)(Session["usrname"]);

			
            if (!IsPostBack)
            {
				FuncionGlobal.combobanco(this.dl_banco,1);
				FuncionGlobal.comboparametro(this.dl_tipo_movimiento, "FMO");
				FuncionGlobal.combousuariobynivel(this.dl_solicitante,"GERE");
                this.txt_desde.Text = DateTime.Today.ToShortDateString();
                this.txt_hasta.Text = DateTime.Today.ToShortDateString();
                FuncionGlobal.ComboFamilia(dlFamilia);
                FuncionGlobal.comboparametro(dlTipoMovimiento, "CATIPREND");
            }
            
        }
        private void getallTipooperacion()
        {



            DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_inventario"));
			dt.Columns.Add(new DataColumn("banco"));
			dt.Columns.Add(new DataColumn("ctacte"));
            dt.Columns.Add(new DataColumn("taloncheque"));
			dt.Columns.Add(new DataColumn("numero_cheque"));
			dt.Columns.Add(new DataColumn("montoini"));
            dt.Columns.Add(new DataColumn("fecha_movimiento"));
			dt.Columns.Add(new DataColumn("tipo_movimiento"));
            dt.Columns.Add(new DataColumn("fecha_rendicion"));
            dt.Columns.Add(new DataColumn("monto_rendido"));
			dt.Columns.Add(new DataColumn("rendido"));
            dt.Columns.Add(new DataColumn("solicitante"));
			dt.Columns.Add(new DataColumn("url_rendir"));
			dt.Columns.Add(new DataColumn("Nomina"));
			dt.Columns.Add(new DataColumn("folio")); 

			List<Cheques> lcheques = new chequesBC().getCta_Cte(this.txt_desde.Text, this.txt_hasta.Text,
                                                Convert.ToInt16(this.dl_tipo_movimiento.SelectedValue), this.dl_rendido.SelectedValue);


            foreach (Cheques cheuq in lcheques)
            {
				
			
				
				DataRow dr = dt.NewRow();

				BancoFinanciera mbancofinanciera = new BancoFinanciera();

				BancoFinanciera banco = new BancofinancieraBC().getBancofinanciera(cheuq.Banco.ToString());

				BancoFinanciera mtipodoc = new BancoFinanciera();

				BancoFinanciera documento = new BancofinancieraBC().gettipodocbanco(cheuq.Tipo_movimiento.ToString());

				CuentaBanco mcuentabanco = new CuentaBanco();

				CuentaBanco ctacte = new CuentabancoBC().getcuentabancobycuenta(cheuq.Banco.ToString(), Convert.ToInt32(cheuq.Ctacte));


                

				dr["id_inventario"] = cheuq.Id_inventario;
				dr["banco"] = banco.Nombre;
				dr["ctacte"] = ctacte.Numero_cuenta;
				dr["taloncheque"] = cheuq.Talonario;
				dr["numero_cheque"] = cheuq.Num_cheq;
				dr["rendido"] = cheuq.Rendido;
				dr["montoini"] = cheuq.Monto_inicial;
				dr["tipo_movimiento"] = documento.Nombre;
                dr["fecha_movimiento"] = cheuq.Fecha_movimiento.ToString("dd-MM-yyyy");
                dr["fecha_rendicion"] = cheuq.Fecha_rendicion.ToString("dd-MM-yyyy");
                dr["monto_rendido"] = cheuq.Monto_rendido.ToString();
                dr["solicitante"] = cheuq.Solicitante.Trim();
				dr["Nomina"] = cheuq.Nomina.Trim();
				dr["folio"] = cheuq.Folio.Trim(); 
                dr["url_rendir"] = "mrendicioncheque.aspx?id=" + FuncionGlobal.FuctionEncriptar(cheuq.Id_inventario.ToString().Trim()) + "&rendido=" + FuncionGlobal.FuctionEncriptar(cheuq.Rendido.Trim());

				
                dt.Rows.Add(dr);
            
			}

			this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();




        }

      
     
        protected void Button1_Click(object sender, EventArgs e)
        {
	
                

                string add = new chequesBC().add_Cta_Cte(this.dl_banco.SelectedValue.ToString(),this.dl_cta.SelectedValue.ToString(),this.txt_talonario.Text.ToString(),
                    this.dl_tipmov.SelectedValue.ToString(),Convert.ToInt32(this.Monto_inicial.Text),(this.Numcheq1.Text.Trim()),this.cuenta_usuario,
                    this.dl_solicitante.SelectedValue.Trim() );


                FuncionGlobal.alerta("MOVIMIENTO INGRESADO CON EXITO", this.Page);
            
            
                getallTipooperacion();
        }


			protected void dl_banco_SelectedIndexChanged(object sender, EventArgs e)
			{
				FuncionGlobal.comboctacte(this.dl_cta , this.dl_banco.SelectedValue);
				FuncionGlobal.comboparametro(this.dl_tipmov, "FMO");
			}

			protected void txt_talonario_TextChanged(object sender, EventArgs e)
			{

			}

			protected void Numcheq1_TextChanged(object sender, EventArgs e)
			{

			}

			protected void Monto_inicial_TextChanged(object sender, EventArgs e)
			{

			}

			protected void dl_ctacte_SelectedIndexChanged(object sender, EventArgs e)
			{
			
			}

			protected void dl_movimiento_SelectedIndexChanged(object sender, EventArgs e)
			{

			}
			protected void dl_movimiento2_SelectedIndexChanged(object sender, EventArgs e)
			{
				
			}

			protected void dl_famrendir_SelectedIndexChanged(object sender, EventArgs e)
			{

			}
			protected void dl_tipnomrendir_SelectedIndexChanged(object sender, EventArgs e)
			{

			}

			protected void eliminar_Click(object sender,  ImageClickEventArgs e)
			{
			}

			protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
			{
					

					GridViewRow row;
					row = gr_dato.Rows[e.RowIndex];

					
					string fila = gr_dato.DataKeys[e.RowIndex].Values[3].ToString();
					string add = new chequesBC().del_Cta_Cte(Convert.ToInt32(fila));	

					
			
			}

			protected void ib_opedia_Click(object sender, ImageClickEventArgs e)
			{

                getallTipooperacion();
                
                this.ib_opedia.Visible = true;
                
                ib_opedia.Attributes.Add("onclick", "javascript:window.open('../reportes/view_cheques_rendicion.aspx?desde=" +
                    this.txt_desde.Text + "&hasta=" + this.txt_hasta.Text + "&tip_mov=" + this.dl_tipo_movimiento.SelectedValue
                    + "&estado=" + this.dl_rendido.SelectedValue.ToString() + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
			}

            protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            protected void Button2_Click(object sender, EventArgs e)
            {
               var monto = Convert.ToInt32(txtMontoCajaChica.Text.Trim());
               //var idFamilia = Convert.ToInt32(dlFamilia.SelectedValue);
                CargarMontoCajaChica(monto, 22);
            }

        private void CargarMontoCajaChica(int monto, int idFamilia)
        {
            const string tipo = "2"; //carga de dinero a caja chica
            var mensaje = new chequesBC().AddMovimientoCajaChica(cuenta_usuario, idFamilia, monto, tipo);
            FuncionGlobal.alerta(mensaje[0], Page);

        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dlFamilia.SelectedValue == "0")
            {
                lblSaldo.Text = "Sin Selección";
                return;                          
            }
              
            lblSaldo.Text = GetMovimientoCajaChica(Convert.ToInt32(dlFamilia.SelectedValue)); 
        }

        private string GetMovimientoCajaChica(int idFamilia)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_movimiento"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("familia"));
            dt.Columns.Add(new DataColumn("inicial"));
            dt.Columns.Add(new DataColumn("observacion"));
            dt.Columns.Add(new DataColumn("final"));
            dt.Columns.Add(new DataColumn("tipoMovimiento"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("monto"));

            var dtdatos = new chequesBC().GetMovimientoCajaChicaByFamilia(idFamilia);
            string saldoFinal = "0";
            var conteo = 1;
            foreach (DataRow drDatos in dtdatos.Rows)
            {
                if(conteo == 1)
                {
                    saldoFinal = Convert.ToString(drDatos["final"]);
                }
                DataRow dr = dt.NewRow();
                dr["id_movimiento"] = Convert.ToString(drDatos["id"]);
                dr["fecha"] = Convert.ToString(drDatos["fecha"]);
                dr["familia"] = Convert.ToString(drDatos["familia"]);
                dr["monto"] = Convert.ToString(drDatos["monto"]);
                dr["inicial"] = Convert.ToString(drDatos["inicial"]);
                dr["observacion"] = Convert.ToString(drDatos["observacion"]);
                dr["final"] = Convert.ToString(drDatos["final"]);
                dr["tipoMovimiento"] = Convert.ToString(drDatos["ValorAlfanumerico"]);
                dr["usuario"] = Convert.ToString(drDatos["nombre"]); 
                dt.Rows.Add(dr);
                conteo++;
            }   
            grMovimientoCajaChica.DataSource = dt;
            grMovimientoCajaChica.DataBind();
            return saldoFinal;

        }




    }
}
