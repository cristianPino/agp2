using System;
using System.IO;
using System.Xml;
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



namespace sistemaAGP
{



	public partial class mRendicionCheque : System.Web.UI.Page
	{

        MemoryStream me = new MemoryStream();
		string id_inventario;
        string rendido;
        

        int nline;

		protected void Page_Load(object sender, EventArgs e)
		{

			
			
			id_inventario = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());
            rendido = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["rendido"].ToString());
            


			if (!IsPostBack)
			{


				FuncionGlobal.combofamiliabyusuario(Session["usrname"].ToString(), this.dl_familia);
				getestado();
                //FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]),dl_familia);

                if (rendido == "True")
                {

                    //this.Button1.Enabled = false;
                    this.ImageButton1.Enabled = false;
                    carga_rendicion();

                }
                else
                {
                    carga_nomina_cheque();
                }

				
			}


		}


        private void carga_rendicion()
        { 
        
        	
			

            List<TipoNomina> lnomina = new Nomina_rendicionBC().Getnomina_rendida(Convert.ToInt32( id_inventario));
            
            int folio = 0;
			int monto = 0;
            DataTable dt = new DataTable();

           
			dt.Columns.Add(new DataColumn("id_nomina"));
			dt.Columns.Add(new DataColumn("folio"));
			dt.Columns.Add(new DataColumn("tipo_nomina"));

			dt.Columns.Add(new DataColumn("monto"));
			dt.Columns.Add(new DataColumn("familia"));
            dt.Columns.Add(new DataColumn("nombre_familia"));
            dt.Columns.Add(new DataColumn("id_gasto"));



            foreach (TipoNomina add in lnomina)
            {


                DataRow draux = dt.NewRow();

                draux["id_nomina"] = add.Id_nomina.ToString();
                draux["folio"] = add.Folio.ToString();
                draux["tipo_nomina"] = new TipoNominaBC().getTiponominaBytipo(add.Id_nomina).Descripcion.Trim();
                draux["monto"] = add.Monto;
                draux["familia"] = add.Id_familia.ToString();
                draux["nombre_familia"] =  new Familia_productoBC().getFamiliabyidFamilia(add.Id_familia).Descripcion.Trim() ;
                draux["id_gasto"] = add.Id_tipogasto.ToString();

                if (folio != 1 && add.Folio != 0)
                {
                    monto = monto + add.Monto;
                    dt.Rows.Add(draux);
                    this.total.Text = monto.ToString();
					this.Label5.Text = monto.ToString();
                }

            }

			
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();



		}

        



		private void getestado()
		{

            Cheques mCheques = new chequesBC().getCheque_Cte(id_inventario);
			 banco.Text = mCheques.Nombre_banco;
			 cuenta1.Text  = mCheques.Numerocta.ToString();
			 montoini.Text = mCheques.Monto_inicial.ToString();
			 numdoc.Text = mCheques.Num_cheq.ToString();
			//HiddenField1.Value = mcheques.Monto_inicial.ToString();


			

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

           

		}

        protected void carga_nomina_cheque()
        {
            int monto = 0;
            List<TipoNomina> lti = new Nomina_rendicionBC().getnomminarendicion(Convert.ToInt32(id_inventario));

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_nomina"));
            dt.Columns.Add(new DataColumn("folio"));
            dt.Columns.Add(new DataColumn("tipo_nomina"));

            dt.Columns.Add(new DataColumn("monto"));
            dt.Columns.Add(new DataColumn("familia"));
            dt.Columns.Add(new DataColumn("nombre_familia"));
            dt.Columns.Add(new DataColumn("id_gasto"));
			DataColumn col = new DataColumn("chk2");
			col.DataType = System.Type.GetType("System.Boolean");


			dt.Columns.Add(col);


            foreach (TipoNomina add in lti)
            {
                DataRow draux = dt.NewRow();

                draux["id_nomina"] = add.Id_nomina;
                draux["folio"] = add.Folio;
                draux["tipo_nomina"] = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(add.Id_nomina)).Descripcion.Trim();
                draux["monto"] = add.Monto;
                draux["familia"] = add.Id_familia;
                draux["nombre_familia"] = new Familia_productoBC().getFamiliabyidFamilia(add.Id_familia).Descripcion.Trim();
                draux["id_gasto"] = add.Id_tipogasto.ToString();
				draux["chk2"] = add.Chek;
                if (add.Folio != 1 && add.Folio != 0)
                {
                    monto = monto + add.Monto;
                    dt.Rows.Add(draux);
                    this.total.Text = monto.ToString();
					this.Label5.Text = monto.ToString();
                }
            }

			



            //dt.Rows.Add(draux);


            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();


			this.GridView1.DataSource = dt;
			this.GridView1.DataBind();
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    if (this.txt_codigo.Text.Trim() == "")

        //    {
        //        this.lbl_error.Text = "Ingrese Folio de Nomina";
        //        this.txt_codigo.Text = "";
        //        this.txt_codigo.Focus();
        //        return;
            
        //    }

			
        //    TipoNomina nomina_rendicion = new TipoNomina();
        //    TipoNomina add = new Nomina_rendicionBC().getnomminarendicion(Convert.ToInt32(tipo_nomina.SelectedValue), Convert.ToInt32(txt_codigo.Text));
        //    int folio = 0;
        //    int monto = 0;
        //    DataTable dt = new DataTable();

        //    if (add != null)

        //    {
        //        if (add.Id_inventario > 0)

        //        {
        //            this.lbl_error.Text = "Nomina Rendida Anteriormente";
        //            this.txt_codigo.Text = "";
        //            this.txt_codigo.Focus();  
        //            return;
        //        }

        //        if (add.Monto == 0)
        //        {
        //            this.lbl_error.Text = "Nomina no posee gastos cargados";
        //            this.txt_codigo.Text = "";
        //            this.txt_codigo.Focus();
        //            return;
        //        }


			
        //    dt.Columns.Add(new DataColumn("id_nomina"));
        //    dt.Columns.Add(new DataColumn("folio"));
        //    dt.Columns.Add(new DataColumn("tipo_nomina"));

        //    dt.Columns.Add(new DataColumn("monto"));
        //    dt.Columns.Add(new DataColumn("familia"));
        //    dt.Columns.Add(new DataColumn("nombre_familia"));
        //    dt.Columns.Add(new DataColumn("id_gasto"));

			
        //    for (int i = 0; i < gr_dato.Rows.Count; i++)
        //    {

        //        DataRow dr = dt.NewRow();
        //        dr["id_nomina"] = gr_dato.DataKeys[i].Values[0].ToString();
        //        dr["folio"] = gr_dato.DataKeys[i].Values[1].ToString();
        //        dr["tipo_nomina"] =  new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(gr_dato.DataKeys[i].Values[0])).Descripcion.Trim();
        //        dr["monto"] = gr_dato.DataKeys[i].Values[3].ToString();
        //        dr["familia"] = gr_dato.DataKeys[i].Values[4].ToString();
        //        dr["nombre_familia"] = new Familia_productoBC().getFamiliabyidFamilia(Convert.ToInt32( gr_dato.DataKeys[i].Values[4])).Descripcion.Trim() ;
        //        dr["id_gasto"] = gr_dato.DataKeys[i].Values[5].ToString();

        //        monto = Convert.ToInt32(gr_dato.DataKeys[i].Values[3].ToString()) + monto;
        //        dt.Rows.Add(dr);

        //        if (Convert.ToInt32(this.txt_codigo.Text) == Convert.ToInt32(gr_dato.DataKeys[i].Values[1]) && (Convert.ToInt32(tipo_nomina.SelectedValue) == Convert.ToInt32(gr_dato.DataKeys[i].Values[0])))
        //        {
        //            folio = 1;
        //        }
				
        //    }


        //    DataRow draux = dt.NewRow();
			
        //    draux["id_nomina"] = this.tipo_nomina.SelectedValue;
        //    draux["folio"] = txt_codigo.Text;
        //    draux["tipo_nomina"] = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.tipo_nomina.SelectedValue)).Descripcion.Trim();
        //    draux["monto"] = add.Monto;
        //    draux["familia"] = dl_familia.SelectedValue;
        //    draux["nombre_familia"] = dl_familia.SelectedItem.Text.Trim() ;
        //    draux["id_gasto"] = add.Id_tipogasto.ToString(); 

        //    if (folio != 1 && add.Folio != 0)
        //    {	
        //        monto = monto + add.Monto;
        //        dt.Rows.Add(draux);
        //        this.total.Text = monto.ToString();
        //    }
			
        //    //dt.Rows.Add(draux);

			
        //    this.gr_dato.DataSource = dt;
        //    this.gr_dato.DataBind();


        //        }

        //}




		protected void dl_tipo_SelectedIndexChanged(object sender, EventArgs e)
		{

		}



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


            if (this.txt_observacion.Text.Trim() == "")
            {
                this.lbl_error.Text = "Debe ingresar una observacion";
                return;
            
            }


            XmlTextWriter xml = new XmlTextWriter(me, System.Text.Encoding.UTF8);
            xml.Formatting = Formatting.Indented;
            xml.Namespaces = true;
            xml.WriteStartDocument(false);
            xml.WriteStartElement("Root");

            nline = 10000;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {



                operacion_nomina(Convert.ToInt32(  gr_dato.DataKeys[i].Values[0].ToString()),
                                        Convert.ToInt32(gr_dato.DataKeys[i].Values[1].ToString()),
                                        Convert.ToInt16(gr_dato.DataKeys[i].Values[5].ToString()),xml);

            }

            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();

            me.Position = 0;
            string r = new StreamReader(me).ReadToEnd();

            xml.Close();
            me.Close();

            string strPath = System.Configuration.ConfigurationManager.AppSettings["DIARIO_GENERAL"];


            string path = strPath + id_inventario+ "-"  +DateTime.Now.ToString("dd-MM-yy")+ ".xml";
            XmlDataDocument xmDoc = new XmlDataDocument();
            xmDoc.LoadXml(r);
            xmDoc.Save(path);





            string mrendir = new chequesBC().rendir_cheque(Convert.ToInt32(id_inventario), this.txt_observacion.Text.Trim() ,
                Convert.ToInt32(this.total.Text));

         
            this.ImageButton1.Enabled = false;

            this.lbl_error.Text = "CONTROL DE EGRESO REALIZADO CON EXITO";


        }


        protected void operacion_nomina(Int32 id_nomina, Int32  folio, Int16 id_gasto,XmlTextWriter xml)
        {
            //string add = "";

            List<Operacion> loperacion = new List<Operacion>();
            loperacion = new OperacionBC().getOperacionesbynominaExpress(id_nomina, folio, Session["usrname"].ToString());
            string plan_cuenta = "";
            string nombre_cuenta = "";

            foreach (Operacion moperacion in loperacion)
            {


                //add = new TipoNominaBC().actualiza_rendicion_nomina(moperacion.Id_solicitud,
                //                    id_nomina, folio, Session["usrname"].ToString(), Convert.ToInt32(  id_inventario));

                
            Usuario muser = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
            TipoNomina nom = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(id_nomina));
            
            GastosComunes cuentagasto = new GastosComunesBC().getGastosComunes(id_gasto);
            GastosComunes gasto = new GastosComunesBC().getGastoComunbyId_solandId_gasto(moperacion.Id_solicitud, id_gasto);

            Operacion mopsec = new OperacionBC().getoperacion(moperacion.Id_solicitud);
            SucursalCliente msuc = new SucursalclienteBC().getsucursalnav(mopsec.Sucursal.Id_sucursal);
            
            //List<GastoOperacion> lgasto = new GastooperacionBC().validacionGasto(Convert.ToInt32(moperacion.Id_solicitud));
            //if (lgasto.Count() != 0)
            //{

            //    foreach (GastoOperacion mgasto in lgasto)
            //    {
            //        xml.WriteStartElement("GenJournalLine");
            //        xml.WriteElementString("Libro", "GENERAL");
            //        xml.WriteElementString("Seccion", muser.Usuanav.ToString().Trim());
            //        xml.WriteElementString("LineNo", nline.ToString());
            //        xml.WriteElementString("DocumentNo", "1505");
            //        xml.WriteElementString("AccountType", "G/L Account");
            //        xml.WriteElementString("AccountNo", mgasto.Cuenta_facturacion.ToString().Trim());//cuenta_gasto
            //        xml.WriteElementString("PostingDate", DateTime.Now.ToString("dd-MM-yy"));
            //        xml.WriteElementString("Description", "INT Y REAJUSTES PERC.");
            //        xml.WriteElementString("Importe", mgasto.Monto.ToString());//valor_tramite
            //        xml.WriteElementString("Nomina", folio.ToString());//folio
            //        xml.WriteElementString("AreaCodigo", new Familia_productoBC().getFamiliabyidFamilia (nom.Id_familia).Codigo_nav.Trim());
            //        xml.WriteElementString("RutCodigo", moperacion.Cliente.Persona.Rut.ToString());
            //        xml.WriteElementString("RegionCodigo", "V");
            //        xml.WriteElementString("Operacion", moperacion.Id_solicitud.ToString());//id_solicitud
            //        xml.WriteElementString("CodterminosPago", "30DIAS");
            //        xml.WriteEndElement();
            //        nline = nline + 10000;
            //    }
            //}
            string x = "";
            string y = "";
            if (cuentagasto.Cuenta_grupo != null && gasto.Id_familia != 6 && gasto.Id_familia != 14 && gasto.Id_familia != 15)
            { plan_cuenta = cuentagasto.Cuenta_grupo.Trim();}


            if (gasto.Id_familia == 6 || gasto.Id_familia == 14 || gasto.Id_familia == 15)
            {
                x = "G/L Account";
                y = cuentagasto.Cuenta_grupo.Trim();
            }
            else
            {
                x = "Customer";
                y = moperacion.Cliente.Codigo_nav;
            }
                xml.WriteStartElement("GenJournalLine");
                xml.WriteElementString("Libro", "GENERAL");
                xml.WriteElementString("Seccion",muser.Usuanav.ToString().Trim() );
                xml.WriteElementString("DocumentType","");
                xml.WriteElementString("LineNo", nline.ToString());
                xml.WriteElementString("DocumentNo", this.numdoc.Text);
                xml.WriteElementString("AccountType", x);
                xml.WriteElementString("AccountNo", y);
                xml.WriteElementString("PostingGroup", plan_cuenta);
                xml.WriteElementString("PostingDate", DateTime.Now.ToString("dd-MM-yy"));
                xml.WriteElementString("Description","");
                xml.WriteElementString("Importe",gasto.Valor.ToString() );//valor_tramite
                //xml.WriteElementString("Nomina", folio.ToString());//folio
                xml.WriteElementString("AreaCodigo", new Familia_productoBC().getFamiliabyidFamilia(gasto.Id_familia).Codigo_nav.Trim());
                xml.WriteElementString("RutCodigo", moperacion.Cliente.Persona.Rut.ToString()    );
                xml.WriteElementString("RegionCodigo", msuc.Codnav.ToString().Trim());
                xml.WriteElementString("Operacion", moperacion.Id_solicitud.ToString());//id_solicitud
                xml.WriteElementString("CodterminosPago", "30DIAS");

                xml.WriteEndElement();
                nline = nline + 10000;

            }

        }

		protected void Button_Click(object sender, EventArgs e)
		{



			GridViewRow row;

			for (int i = 0; i < GridView1.Rows.Count; i++)
			{

				row = GridView1.Rows[i];
				CheckBox chk1 = (CheckBox)GridView1.Rows[i].FindControl("chk2");

				string id_nomina = GridView1.DataKeys[i].Values[0].ToString();
				string folio = GridView1.DataKeys[i].Values[1].ToString();
			    //string folio = gr_dato.DataKeys[i].Values[2].ToString();

			    //string codigo = this.gr_dato.Rows[i].Cells[0].Text;

			    if (chk1.Checked == true)
			    {

			        string add = new Nomina_rendicionBC().Delnomina_rendida(Convert.ToInt32(id_nomina), Convert.ToInt32(folio));		

			    }
				
			}



			//GridViewRow row;

			//for (int i = 0; i < gr_dato.Rows.Count; i++)
			//{

			//    row = gr_dato.Rows[i];
			//    CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk2");
			//        string id_nomina = gr_dato.DataKeys[i].Values[0].ToString();
			//        string folio = gr_dato.DataKeys[i].Values[1].ToString();
			//    string codigo = this.gr_dato.Rows[i].Cells[0].Text;
			//    //	int id_cliente = id_cliente;

			//    if (chk.Checked == true)
			//    {

			//        string add = new Nomina_rendicionBC().Delnomina_rendida(Convert.ToInt32(id_nomina), Convert.ToInt32(folio));		

			//    }

				


			//}




			carga_nomina_cheque();
		
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combonominabyfamilia(dl_tiponomina, Convert.ToInt16(this.dl_familia.SelectedValue.ToString()));
			
		}

		protected void dl_tiponomina_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void Button_Click1(object sender, EventArgs e)
		{
			string add = new Nomina_rendicionBC().Addnomina_rendida(Convert.ToInt32(Convert.ToInt16(dl_tiponomina.SelectedValue.ToString())), Convert.ToInt32(Convert.ToInt32(txt_folio.Text)),Convert.ToInt32(id_inventario));
			//dl_familia.SelectedValue = "Seleccionar";
			//dl_tiponomina.SelectedValue = "Seleccionar";
			txt_folio.Text = "";


			carga_nomina_cheque();
		}

		protected void txt_folio_TextChanged1(object sender, EventArgs e)
		{

		}



		





	}
}