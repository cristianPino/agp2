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
	public partial class mControl_cliente : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
            GetMensajeAnalisis();
			if (!IsPostBack)
			{
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), this.dl_familia);
                //FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
			}
		}
        private void GetMensajeAnalisis()
        {
            var dt = new InfoAutoBC().GetMensajeAnalisis();
            lblMensajeAnalisis.Text = "Bienvenido";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["estado"].ToString().Trim().ToLower() == "true")
                {
                    lblMensajeAnalisis.Text = dr["mensaje"].ToString();
                }

            }
        }

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), this.dl_familia);
			this.gr_dato.DataSource = null;
			this.gr_dato.DataBind();
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GetTipoOperaciones();
		}

		protected void GetTipoOperaciones()
		{
          
			this.gr_dato.DataSource = from t in new TipooperacionBC().getTipo_OperacionByUsuarioandfamilia(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), "true", Convert.ToInt32(this.dl_familia.SelectedValue),"True")
									  orderby t.Operacion ascending
									  select new
									  {
                                       
										  operacion = t.Operacion.ToUpper().Trim(),
                                          url = t.Url_operacion + "fDded4a93u2d" + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(this.dl_cliente.SelectedValue) + "&ventatipo=&patente=" + "&solo_lectura=" + FuncionGlobal.FuctionEncriptar("0")
									 + "&idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar("0")
                                      };
			this.gr_dato.DataBind();
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		//protected void getallTipooperacion()
		//{
		//    List<TipoOperacion> ltipooperacion = new TipooperacionBC().getTipo_OperacionByUsuarioandfamilia(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), "true",Convert.ToInt32(this.dl_familia.SelectedValue));
		//    this.gr_dato.DataSource = ltipooperacion;
		//    this.gr_dato.DataBind();
		//}

		//protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    if (this.dl_familia.SelectedValue != "0")
		//        this.getallTipooperacion();
		//}

		//protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		//{
		//    if (e.Row.RowType == DataControlRowType.DataRow)
		//    {
		//        string tamano = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
		//        string url_dinamica = this.gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString();
		//        ((ImageButton)e.Row.FindControl("ib_producto")).Attributes.Add("onclick", "javascript:window.showModalDialog('" + url_dinamica + "fDded4a93u2d" + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(this.dl_cliente.SelectedValue) + "&ventatipo=" + "" + "&patente=" + "" + "','_blank','" + tamano + "')");
		//    }
		//}
	}
}