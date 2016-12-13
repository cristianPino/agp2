using System;

using System.Web.UI;

using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP
{
	public partial class mTasador : System.Web.UI.Page
	{
        private string id_solicitud;

		protected void Page_Load(object sender, EventArgs e)
		{

            id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());


			if (!IsPostBack)
			{
                Operacion mope = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

                FuncionGlobal.comboTasadorbyCliente(this.dl_tasador, mope.Cliente.Id_cliente);
				get_tasador(id_solicitud);

			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
            add_hipoteca();
		}

		private void add_hipoteca()
		{
			
            //Int32 valor_comercial = 0;
            //Int32 valor_liquidez = 0;
            //Int32 valor_seguro = 0;

            //if (this.txt_valor_comercial.Text != "")
            //{
            //    valor_comercial =Convert.ToInt32(this.txt_valor_comercial.Text);
            //}

            //if (this.txt_valor_liquidez.Text != "")
            //{
            //    valor_liquidez = Convert.ToInt32(this.txt_valor_liquidez.Text);
            //}

            //if (this.txt_valor_seguro.Text != "")
            //{
            //    valor_seguro = Convert.ToInt32(this.txt_valor_seguro.Text);
            //}
            //Int32 rut_acreedor = 0;
            //Hipotecario mhipo = new HipotecarioBC().gethipotecario(Convert.ToInt32(id_solicitud));
            //if (mhipo.RutAcreedor != null)
            //{
            //    rut_acreedor =Convert.ToInt32(mhipo.RutAcreedor.Rut);
            //}   


            //string add = new HipotecarioBC().add_hipotecario(Convert.ToInt32(id_solicitud),
            //                                                    rut_acreedor,
            //                                                    mhipo.TipoPropiedad,
                                                               
                                                               
            //                                                    mhipo.Rol,
                                                               
                                                               
            //                                                    mhipo.PrecioVivienda,
            //                                                    mhipo.MontoCredito,
            //                                                    mhipo.VctoPrimeraCuota.ToString(),
            //                                                    Convert.ToInt16(mhipo.PlazoAnos),
                                                               
            //                                                    mhipo.Sucursal.Id_sucursal,
            //                                                    mhipo.NumeroInterno,
            //                                                    Convert.ToInt16(mhipo.IdComuna),
            //                                                    mhipo.Direccion,
            //                                                    mhipo.Numero,
            //                                                    mhipo.Complemento,
            //                                                    mhipo.TipoCredito,
            //                                                    mhipo.Tasacion,
            //                                                    mhipo.Ejecutivo.UserName,
                                                               
            //                                                    mhipo.FinalCaratula, 
            //                                                    mhipo.FinalConservador,
                                                               
                                                               
                                                          
            //                                                    ,
            //                                                    valor_liquidez,
            //                                                    valor_seguro,
            //                                                    this.txt_metros_edificados.Text,
            //                                                    this.txt_metros_terreno.Text,
                                                               
            //                                                    this.txt_superficie_valorar.Text,
            //                                                    this.txt_permiso_edificacion.Text,
            //                                                    this.txt_estado_obra.Text,
            //                                                    this.txt_urbanizacion.Text,
            //                                                    this.txt_leyes_acogidas.Text,
            //                                                    );


            //UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            //FuncionGlobal.alerta_updatepanel("DATOS DEL TASADOR INGRESADOS CON EXITO", this.Page, up);
            //this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CloseWnd", "<script type=\"text/javascript\">window.close();</script>");
            //return;
			 
		
		}

		private void get_tasador(string id_solicitud)  {
        //{
        //    Hipotecario mhipo = new HipotecarioBC().gethipotecario(Convert.ToInt32(id_solicitud));

            
        //        this.txt_metros_edificados.Text = mhipo.Metros_edificados;
        //        this.txt_metros_terreno.Text = mhipo.Metros_terreno;
        //        this.txt_valor_comercial.Text = mhipo.ValorComercial.ToString();
        //        this.txt_valor_liquidez.Text = mhipo.Valor_liquidez.ToString();
        //        this.txt_valor_seguro.Text = mhipo.Valor_seguro.ToString();
        //        this.txt_leyes_acogidas.Text = mhipo.Leyes_acogidas;
        //        this.txt_estado_obra.Text = mhipo.Estado_obra;
        //        this.txt_permiso_edificacion.Text = mhipo.Permiso_edificacion;
        //        this.txt_urbanizacion.Text = mhipo.Urbanizacion;
        //        this.txt_superficie_valorar.Text = mhipo.Superficie_valorar;
        //        this.lbl_operacion.Text = id_solicitud;
        //        this.lbl_rol.Text = mhipo.Rol;
            
		}

        protected void txt_valor_comercial_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_metros_edificados_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_destino_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_inmueble_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_valor_liquidez_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_metros_terreno_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_valor_seguro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tasador_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

	}
}
