using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class wucGrabar : System.Web.UI.UserControl
	{

				private int _id_solicitud;
                private int _carga_vent;
                private int cargo_final;
		
		public int Id_solicitud
		{
			get { return Convert.ToInt32(ViewState["id_solicitud"] ?? _id_solicitud); }
			set { _id_solicitud = value; ViewState["id_solicitud"] = _id_solicitud; }
		}
        public int Carga_vent
        {
            get { return Convert.ToInt32(ViewState["carga_vent"] ?? _carga_vent); }
            set { _carga_vent = value; ViewState["carga_vent"] = _carga_vent; }
        }
        //public string error
        //{
        //    get { return ViewState["error"].ToString() ?? error; }
        //    set { error = value; ViewState["error"] = error; }
          
        //}

        

		
		public delegate void ClickEventHandler(object sender, EventArgs e);
	
		//Boton aceptar
		
		public event ClickEventHandler Click = delegate { };
        

		public string Text
		{
			get { return btnAceptar.Text; }
			set {  btnAceptar.Text = value; }
		}

		public bool CausesValidation
		{
			get { return btnAceptar.CausesValidation; }
			set { btnAceptar.CausesValidation = value; }
		}

		public string OnClientClick
		{
			get { return btnAceptar.OnClientClick; }
			set { btnAceptar.OnClientClick = value; }
		}

		public string CssClass
		{
			get { return btnAceptar.CssClass; }
			set { btnAceptar.CssClass = value; }
		}

		protected void cmdLink_Click(object sender, EventArgs e)
		{
            Click(this, e);
            cargo_vta.Text = Convert.ToString(_carga_vent);

            lbl_numero.Text = Convert.ToString(_id_solicitud);
            if (this.lbl_numero.Text != "0")
            {
                //this.lbl_operacion.Visible = true;
                //this.lbl_operacion.Text = "OPERACION CON NUMERO ";
			
            this.ib_gasto.Visible = true;
            this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

            Operacion moper = new OperacionBC().getoperacion(_id_solicitud);
            //this.ib_poliza.Visible = true;
            //this.ib_poliza.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPoliza.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(moper.Cliente.Id_cliente.ToString()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

            this.ib_comgasto.Visible = true;
            this.ib_comgasto.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(moper.Tipo_operacion.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");


            this.ib_comgastoingreso.Visible = true;
            this.ib_comgastoingreso.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_ingreso.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(moper.Tipo_operacion.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");

            Operacion op = new OperacionBC().getoperacion(_id_solicitud);

            if (op.Tipo_operacion.Id_familia == 1 || op.Tipo_operacion.Codigo.Trim() == "GTDOC")
            {
                this.gr_dato.Visible = true;
                this.pnl_ingreso_riesgo.Visible = true;
                getgastos();
            }
            }
		}


	//	boton limpiar

        public void mostrar_operacion(string id_solicitud)
        {
              lbl_numero.Text = Convert.ToString(_id_solicitud);
          //  cargo_final = _carga_vent;
              
              if (this.lbl_numero.Text != "0")
              {
                  //this.lbl_operacion.Visible = true;
                  //this.lbl_operacion.Text = "OPERACION CON NUMERO ";
                  this.ib_gasto.Visible = true;
                  this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

                  Operacion moper = new OperacionBC().getoperacion(_id_solicitud);
                  //this.ib_poliza.Visible = true;
                  //this.ib_poliza.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPoliza.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(moper.Cliente.Id_cliente.ToString()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

                  this.ib_comgasto.Visible = true;
                  this.ib_comgasto.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(moper.Tipo_operacion.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");

                  this.ib_comgastoingreso.Visible = true;
                  this.ib_comgastoingreso.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_ingreso.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(moper.Tipo_operacion.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
              }
        }

			
		public event ClickEventHandler Click1 = delegate { };

		public string Text1
		{
			get { return bt_limpiar.Text; }
			set { bt_limpiar.Text = value; }
		}

		public bool CausesValidation1
		{
			get { return bt_limpiar.CausesValidation; }
			set { bt_limpiar.CausesValidation = value; }
		}

		public string OnClientClick1
		{
			get { return bt_limpiar.OnClientClick; }
			set { bt_limpiar.OnClientClick = value; }
		}

		public string CssClass1
		{
			get { return bt_limpiar.CssClass; }
			set { bt_limpiar.CssClass = value; }
		}

		protected void cmdLink_Click1(object sender, EventArgs e)
		{
			Click1(this, e);
			lbl_numero.Text = Convert.ToString(_id_solicitud);
         //   cargo_final = _carga_vent;
            ib_comgasto.Visible = true;
            ib_poliza.Visible = true;
            ib_gasto.Visible = true;
            ib_comgastoingreso.Visible = true;
		}

		//boton Selecionar Aceptar


		public event ClickEventHandler Click2 = delegate { };

		public string Text2
		{
			get { return btnSaveClick.Text; }
			set { btnSaveClick.Text = value; }
		}

		public bool CausesValidation2
		{
			get { return btnSaveClick.CausesValidation; }
			set { btnSaveClick.CausesValidation = value; }
		}

		public string OnClientClick2
		{
			get { return btnSaveClick.OnClientClick; }
			set { btnSaveClick.OnClientClick = value; }
		}

		public string CssClass2
		{
			get { return btnSaveClick.CssClass; }
			set { btnSaveClick.CssClass = value; }
		}

		protected void cmdLink_Click2(object sender, EventArgs e)
		{
			Click2(this, e);
			
		}

		protected void getgastos()
		{
			//ClienteTag lClientetag = new ClienteTagBC().getclientetag(Convert.ToInt16(dl_cliente.SelectedValue.ToString()), 1);

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("Gasto"));
			dt.Columns.Add(new DataColumn("Codigo"));
			DataColumn colhabilitado = new DataColumn("chk");
			colhabilitado.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(colhabilitado);
			//dt.Columns.Add(new DataColumn("check"));
			dt.Columns.Add(new DataColumn("monto"));
			DataColumn chkgchabilitado = new DataColumn("chkgc");
			chkgchabilitado.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(chkgchabilitado);



			List<GastoOperacion> lgasto = new GastooperacionBC().Getgastooperacion(Convert.ToInt32(this.lbl_numero.Text));
			foreach (GastoOperacion mcliente in lgasto)
			{


				DataRow dr = dt.NewRow();



				dr["Gasto"] = mcliente.Tipogasto.Descripcion;

				dr["chk"] = mcliente.Opcional;

				dr["monto"] = mcliente.Monto;
				dr["Codigo"] = mcliente.Tipogasto.Id_tipogasto;
				dr["chkgc"] = mcliente.Tipogasto.Check;

				if (Convert.ToBoolean(mcliente.Opcional) == false)
				{


					colhabilitado.ReadOnly = true;

				};



				dt.Rows.Add(dr);



				this.gr_dato.DataSource = dt;
				this.gr_dato.DataBind();
				Total_general();

			}
		}

		protected void MostrarForm(int id)
		{

			this.lbl_operacion.Text = _id_solicitud.ToString();
				
			
		}
      
		protected void Check_Grilla_Clicked(Object sender, EventArgs e)
		{
			Total_general();
			//this.ModalPopupExtender1.Show();
		}

		protected void Total_general()
		{
			this.lbl_total.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "monto"));

			//this.lbl_cargo_empresa.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_empresa"));
			//this.lbl_cargo_cliente.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_cliente"));
		}


		protected void txt_valor_gasto_Leave(object sender, EventArgs e)
		{
			Total_general();
			//this.ModalPopupExtender1.Show();

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

       

		protected void bt_guardar2_Click(object sender, EventArgs e)
		{
			if (this.lbl_numero.Text != "")
			{

				//string add_or = new  ClienteTagBC().addclientetagoperacion(Convert.ToInt32(add),52);
				GridViewRow row;

				for (int i = 0; i < gr_dato.Rows.Count; i++)
				{

					row = gr_dato.Rows[i];
					CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
					CheckBox chkgc = (CheckBox)gr_dato.Rows[i].FindControl("chkgc");
					//string montogasto = this.gr_dato.Rows[i].Cells[3].Text;
					TextBox montogasto = (TextBox)gr_dato.Rows[i].FindControl("monto");
					string codigo1 = this.gr_dato.Rows[i].Cells[0].Text;
					string codigo2 = this.gr_dato.Rows[i].Cells[1].Text;
					string codigo3 = this.gr_dato.Rows[i].Cells[2].Text;
					string codigo4 = this.gr_dato.Rows[i].Cells[3].Text;

					
					//	int id_cliente = id_cliente;

					if (chk.Checked == true)
					{
                        
						if (cargo_vta.Text == "6")
						{
							//string add_or = new ClienteTagBC().addclientetagoperacion(Convert.ToInt32(add), 52,Convert.ToInt32( montogasto));
                            //|| codigo1 == "26" || codigo1 == "32" || codigo1 == "31"
                            if ((codigo1 == "120" || codigo1 == "31" || codigo1 == "32") && chkgc.Checked == true)
                            {
                                string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]),0,  Convert.ToInt32(montogasto.Text), chkgc.Checked.ToString());
                            }
                            else
                            {
                                if (chkgc.Checked == false)
                                {
                                    string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), 0,Convert.ToInt32(montogasto.Text), chkgc.Checked.ToString());
                                }
                                else
                                {
                                    string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), Convert.ToInt32(montogasto.Text), 0, chkgc.Checked.ToString());
                                }
                            }
						}

                        if (cargo_vta.Text == "5")
                            //|| codigo1 == "26" || codigo1 == "32" || codigo1 == "31"
						{
                            if ((codigo1 == "120" || codigo1 == "31" || codigo1 == "32") && chkgc.Checked == true)
                            {
                                string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), Convert.ToInt32(montogasto.Text), 0, chkgc.Checked.ToString());
                            }
                            else
                            {
                                if (chkgc.Checked == false)
                                {
                                    string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), Convert.ToInt32(montogasto.Text),0, chkgc.Checked.ToString());
                                }
                                else
                                {
                                    string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), 0, Convert.ToInt32(montogasto.Text), chkgc.Checked.ToString());
                                }
                            }
						}
                        if (cargo_vta.Text == "4")
                        {

                            Int32 monto_div = Convert.ToInt32(montogasto.Text)/2;
                            string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), monto_div, monto_div, chkgc.Checked.ToString());
                        }
                        if (cargo_vta.Text == "1")
                        {
                            string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), 0, Convert.ToInt32(montogasto.Text), chkgc.Checked.ToString());
                        }
                        if (cargo_vta.Text == "2")
                        {
                            string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), Convert.ToInt32(montogasto.Text), 0, chkgc.Checked.ToString());
                        }
					}

					else
					{
						//string add_or = new ClienteTagBC().delclientetagoperacion(Convert.ToInt32(add), 52);
                        string add_or = new GastooperacionBC().del_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), chkgc.Checked.ToString(), (string)(Session["usrname"]));
					}
				}

				//Familia_Producto mfamilia1 = new Familia_productoBC().getfamiliabycodigo(tipo_operacion);
				//string addcom_or = new GastooperacionBC().add_gastooperacioncomunes(Convert.ToInt32(add), (string)(Session["usrname"]),tipo_operacion,Convert.ToInt16(id_cliente),Convert.ToInt16(mfamilia1.Id_familia.ToString()),Convert.ToInt16(this.dl_cargo_venta.SelectedValue));
			}
			pnl_ingreso_riesgo.Visible = false;
		}

		protected void btnAceptar_Click1(object sender, EventArgs e)
		{

		}

        protected void ib_poliza_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_gasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_comgasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bt_limpiar_Click(object sender, EventArgs e)
        {
            Click1(this, e); 
           
        }

        protected void ib_comgastoingreso_Click(object sender, ImageClickEventArgs e)
        {

        }

       
	}
	
}