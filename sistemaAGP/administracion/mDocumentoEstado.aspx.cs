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



    public partial class mDocumentoEstado : System.Web.UI.Page
	{


		
		Int16 id_familia;
		Int16 id_estado;
		
		protected void Page_Load(object sender, EventArgs e)
		{

			
			string id_estado_str;
			id_estado_str = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo_estado"].ToString());
			id_estado = Convert.ToInt16(id_estado_str);

			string id_familia_str;
			id_familia_str = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_familia"].ToString());
			id_familia = Convert.ToInt16(id_familia_str);

            string nombre_familia = (Request.QueryString["nombre_familia"].ToString());

			if (!IsPostBack)
			{

                this.lbl_familia.Text = nombre_familia.Trim();
                this.lbl_estado.Text = new EstadotipooperacionBC().getestadobycodigoestado(id_estado).Descripcion.Trim();       
                
                getDocumento();
			}


		}

		private void getDocumento()
		{

			List<DocumentoEstado> ldocu = new DocumentoEstadoBC().DocumentosbyEstado(id_estado);


			DataTable dt = new DataTable();
            dt.Columns.Add("codigo_documento");
			dt.Columns.Add("descripcion");
			DataColumn col = new DataColumn("chekalert");
			col.DataType = System.Type.GetType("System.Boolean");
			//dt.Columns.Add(new DataColumn("chk2"));
			dt.Columns.Add(col);

            foreach (DocumentoEstado docest in ldocu)
			{
				DataRow dr = dt.NewRow();

                dr["codigo_documento"] = docest.Id_documento;
                dr["descripcion"] = new DocumentosBC().getDocumentosbyID(Convert.ToInt16(docest.Id_documento)).Nombre.ToString();
                dr["chekalert"] = docest.Chk_doc.ToString();
				dt.Rows.Add(dr);

			}


			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{


		}

		protected void Button1_Click(object sender, EventArgs e)
		{


			add_Documento_estado();




		}


        private void add_Documento_estado()
		{

			GridViewRow row;

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk2");

				string codigo = gr_dato.DataKeys[i].Values[0].ToString();
			//	string regla = gr_dato.DataKeys[i].Values[1].ToString();

				string codigo2 = this.gr_dato.Rows[i].Cells[0].Text;

				if (chk.Checked == true)
				{

                    string add = new DocumentoEstadoBC().add_Documento_Estado(Convert.ToInt16(id_estado), Convert.ToInt16(codigo));

				}
				else
				{
                    string add = new DocumentoEstadoBC().del_documento_estado(Convert.ToInt16(id_estado), Convert.ToInt16(codigo));
				}

			}

            getDocumento();


		}

	}
}