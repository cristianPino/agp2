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



    public partial class mComportamiento : System.Web.UI.Page
	{

        Int32 id_familia;
		Int32 id_estado;
		
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

                getComportamiento();

                FuncionGlobal.comboEstadoByFamilia(this.dpl_origen,id_familia);
                FuncionGlobal.comboEstadoByFamilia(this.dpl_final,id_familia);
			}


		}

		private void getComportamiento()
		{

			List<ComportamientoEstado> ldocu = new ComportamientoEstadoBC().getcomportamiento(id_estado);


			DataTable dt = new DataTable();
            dt.Columns.Add("id_comportamiento");
            dt.Columns.Add("estado_origen");
            dt.Columns.Add("estado_final");
			

            foreach (ComportamientoEstado docest in ldocu)
			{
				DataRow dr = dt.NewRow();

                dr["id_comportamiento"] = docest.Id_comportamiento;

                EstadoTipoOperacion origen = new EstadotipooperacionBC().getestadobycodigoestado(Convert.ToInt16(docest.Estado_origen));
                if(origen!=null)
                {
                    dr["estado_origen"] = origen.Descripcion;
                }
                else
                {
                    dr["estado_origen"] = "";
                }
                EstadoTipoOperacion final = new EstadotipooperacionBC().getestadobycodigoestado(Convert.ToInt16(docest.Estado_final));
                if(final!=null)
                {
                    dr["estado_final"] = final.Descripcion;
                }
                else
                {
                    dr["estado_final"] = "";
                }
				dt.Rows.Add(dr);

			}


			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{


		}


        private void add_comportamiento_estado()
		{

            if(this.dpl_final.SelectedValue=="0" && this.dpl_origen.SelectedValue =="0")
            {
                FuncionGlobal.alerta("Debe elegir algun Comportamiento para el estado", this.Page);
            }
            else
            {
                string add = new ComportamientoEstadoBC().add_comportamienti(id_estado, Convert.ToInt32(this.dpl_origen.SelectedValue.ToString()), Convert.ToInt32(this.dpl_final.SelectedValue.ToString()));
                getComportamiento();
            }
		}

        protected void dpl_origen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dpl_final_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void nuevo_Click(object sender, EventArgs e)
        {
            add_comportamiento_estado();
        }

        protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
                Int32 id_comportamiento = Convert.ToInt32(this.gr_dato.DataKeys[e.RowIndex].Values[0].ToString());
                string del = new ComportamientoEstadoBC().del_comportamiento(id_comportamiento);
                getComportamiento();

        }

	}
}