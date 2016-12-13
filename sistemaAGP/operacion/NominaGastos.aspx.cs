using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class NominaGastos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                FuncionGlobal.combofamiliabyusuario(Session["usrname"].ToString(), this.dl_familia);
			}
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{

            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dt_operacion"];
            if (dt != null)
            {
               
                dt.Rows.Clear();
                this.gr_dato.DataSource = dt;
                this.gr_dato.DataBind();
            }
           


            FuncionGlobal.comboTipoNominagastoByFamilia(this.dl_tiponomina, Convert.ToInt32(this.dl_familia.SelectedValue));

           
		}


        protected void crear_data_table()
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
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("img_disponible", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("disponible"));
            dt.Columns.Add(new DataColumn("folio"));
            dt.Columns.Add(new DataColumn("familia"));

            ViewState["dt_operacion"] = dt;
        }

		protected void Buscar_Operaciones()
		{
            DataTable dt = new DataTable();

             dt = (DataTable)ViewState["dt_operacion"];

             if (dt == null)
             {
                 crear_data_table();
                 dt = (DataTable)ViewState["dt_operacion"];
             }

     

            List<Operacion> lnom = new OperacionBC().getOperacionesbynominagasto(Convert.ToInt32(this.dl_tiponomina.SelectedValue), Convert.ToInt32(this.txt_folio.Text), (string)Session["usrname"]);
            foreach (Operacion moperacion in lnom)
            {


                if (moperacion != null)
                {
                    this.bt_generar.Enabled = true;


                    DataRow dr = dt.NewRow();
                    dr["id_solicitud"] = moperacion.Id_solicitud;
                    dr["id_cliente"] = moperacion.Cliente.Id_cliente;
                    dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
                    dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
                    dr["operacion"] = moperacion.Tipo_operacion.Operacion;
                    dr["numero_factura"] = moperacion.Numero_factura;
                    dr["folio"] = moperacion.Folio;
                    dr["familia"] = moperacion.Familia;

                    DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(moperacion.Id_solicitud);
                    dr["patente"] = mdato.Patente;

                    if (moperacion.Adquiriente != null)
                    {
                        dr["rut_persona"] = moperacion.Adquiriente.Rut.ToString("N0") + "-" + moperacion.Adquiriente.Dv;
                        dr["nombre_persona"] = string.Format("{0} {1} {2}", moperacion.Adquiriente.Nombre, moperacion.Adquiriente.Apellido_paterno, moperacion.Adquiriente.Apellido_materno).Trim();
                    }
                    else
                    {
                        dr["rut_persona"] = "0-0";
                        dr["nombre_persona"] = "Sin Adquiriente";

                    }
                    dr["semaforo"] = moperacion.Semaforo.Trim();
                    dr["ultimo_estado"] = moperacion.Estado;
                    dt.Rows.Add(dr);

                }
            }
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

        
		}

        protected void GenerarWB()
		{

            GridViewRow row;
            MemoryStream m = new MemoryStream();

            XmlTextWriter xml = new XmlTextWriter(m, System.Text.Encoding.UTF8);
            xml.Formatting = Formatting.Indented;
            xml.Namespaces = true;
            xml.WriteStartDocument(false);
            xml.WriteStartElement("Root");
            string folio="";
            string familia = "";
            TipoNomina nom = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.dl_tiponomina.SelectedValue));
            GastosComunes gasto = new GastosComunesBC().getGastosComunes(Convert.ToInt32(nom.Id_tipogasto));

            Usuario muser = new UsuarioBC().GetUsuario((string)(Session["usrname"]));


            int nline = 10000;

            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
               
                string id_solicitud = this.gr_dato.DataKeys[i].Values[0].ToString();
                 folio = this.gr_dato.DataKeys[i].Values[1].ToString();
                 familia = this.gr_dato.DataKeys[i].Values[2].ToString();


                 List<GastoOperacion> lgasto = new GastooperacionBC().validacionGasto(Convert.ToInt32(id_solicitud));

                 if (lgasto.Count() != 0)
                 {

                     foreach (GastoOperacion mgasto in lgasto)
                     {


                         xml.WriteStartElement("GenJournalLine");
                         xml.WriteElementString("Libro", "GENERAL");
                         xml.WriteElementString("Seccion", "GENERICO");
                         xml.WriteElementString("LineNo", nline.ToString());
                         xml.WriteElementString("DocumentNo", "1505");
                         xml.WriteElementString("AccountType", "G/L Account");
                         xml.WriteElementString("AccountNo", mgasto.Cuenta_facturacion.ToString().Trim());//cuenta_gasto
                         xml.WriteElementString("PostingDate", DateTime.Now.ToString("dd-MM-yy"));
                         xml.WriteElementString("Description", "INT Y REAJUSTES PERC.");
                         xml.WriteElementString("Importe", mgasto.Monto.ToString());//valor_tramite
                         xml.WriteElementString("Nomina", folio);//folio
                         xml.WriteElementString("AreaCodigo", familia);
                         xml.WriteElementString("RutCodigo", muser.Usuanav.ToString());
                         xml.WriteElementString("RegionCodigo", "V");
                         xml.WriteElementString("Operacion", id_solicitud);//id_solicitud
                         xml.WriteElementString("CodterminosPago", "30DIAS");

                         xml.WriteEndElement();
                         nline = nline + 10000;

                     }
                 }

                    xml.WriteStartElement("GenJournalLine");
                    xml.WriteElementString("Libro", "GENERAL");
                    xml.WriteElementString("Seccion", "GENERICO");
                    xml.WriteElementString("LineNo", nline.ToString());
                    xml.WriteElementString("DocumentNo", "1505");
                    xml.WriteElementString("AccountType", "G/L Account");
                    xml.WriteElementString("AccountNo", gasto.Plandecuenta.Cuenta.ToString().Trim());//cuenta_gasto
                    xml.WriteElementString("PostingDate", DateTime.Now.ToString("dd-MM-yy"));
                    xml.WriteElementString("Description", "INT Y REAJUSTES PERC.");
                    xml.WriteElementString("Importe", gasto.Valor.ToString());//valor_tramite
                    xml.WriteElementString("Nomina", folio);//folio
                    xml.WriteElementString("AreaCodigo", familia);
                    xml.WriteElementString("RutCodigo", muser.Usuanav.ToString());
                    xml.WriteElementString("RegionCodigo", "V");
                    xml.WriteElementString("Operacion", id_solicitud);//id_solicitud
                    xml.WriteElementString("CodterminosPago", "30DIAS");

                    xml.WriteEndElement();
                    nline= nline+10000;
                   
            }
            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();

            m.Position = 0;
            string r = new StreamReader(m).ReadToEnd();

            xml.Close();
            m.Close();

            string strPath = System.Configuration.ConfigurationManager.AppSettings["DIARIO_GENERAL"];

            string path = strPath  +  DateTime.Now.ToString("dd-MM-yy")+"-"+folio+"-"+familia+ ".xml";
            XmlDataDocument xmDoc = new XmlDataDocument();
            xmDoc.LoadXml(r);
            xmDoc.Save(path);
		}


        protected bool validar_busqueda(int id_solicitud)
        {
           

            if ( this.dl_familia.SelectedValue == "0" || this.dl_tiponomina.SelectedValue =="0")
            {
                FuncionGlobal.alerta_updatepanel("Debe seleccionar todos los Filtros", this.Page, this.up_filtros);
                return false;
            }
            return true;
        }

        protected void dl_tiponomina_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if (this.dl_tiponomina.SelectedValue != "0")
            {
               
                this.txt_folio.Enabled = true;
            
                TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.dl_tiponomina.SelectedValue));
               
            }
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 fila;

            fila = this.gr_dato.SelectedIndex;

            DataTable dt = (DataTable)ViewState["dt_operacion"];

            dt.Rows.RemoveAt(fila);

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }

        protected void bt_generar_Click(object sender, ImageClickEventArgs e)
        {
            
            GenerarWB();
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_gasto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_monto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_c_empresa_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_c_cliente_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_folio_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_folio.Text != "")
            {
                Buscar_Operaciones();
                this.txt_folio.Text = "";      
            }
        }
	}
}