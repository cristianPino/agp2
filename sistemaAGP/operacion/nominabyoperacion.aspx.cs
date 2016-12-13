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
    public partial class nominabyoperacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
            if (!IsPostBack)
            {

				this.gr_dato.DataSource = from n in new TipoNominaBC().getnominaByoperacion(Convert.ToInt32(ViewState["id_solicitud"]))
										  orderby n.Id_nomina ascending
										  select new
										  {
                                             id_nomina = n.Id_nomina,
											  descripcion = n.Descripcion,
											  folio = n.Folio,
											  reporte_url = string.Format("/reportes/view_nomina.aspx?id_familia={0}&folio={1}&id_nomina={2}", n.Id_familia, n.Folio, n.Id_nomina),

                                              
										  };
                this.gr_dato.DataBind();
            }
        }



        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (new UsuarioBC().GetUsuario(Session["usrname"].ToString()).Permite_eliminar)
            {

                int id_solicitud = Convert.ToInt32(ViewState["id_solicitud"]);
                int id_nomina = Convert.ToInt32(this.gr_dato.DataKeys[e.RowIndex].Values[0].ToString());
                HyperLink folio_x = (HyperLink)gr_dato.Rows[e.RowIndex].Cells[2].Controls[0];
                int folio = Convert.ToInt32(folio_x.Text.Trim().Replace(".",""));
                //int folio = Convert.ToInt32(gr_dato.Rows[e.RowIndex].Cells[2].Controls[0].ToString());

                //EstadoOperacion mesta = new EstadooperacionBC().getEstadobyorden(id_solicitud, 97);

                //if (mesta.Permite_estado == false)
                //{
                    this.Borrar_Operacion(id_solicitud,id_nomina,folio);
                //}
                //else
                //{

                //    e.Cancel = true;
                //    FuncionGlobal.alerta_updatepanel("No se puede eliminar una Operacion que tiene Despacho a cobranza", this.Page, this.up_grilla);
                //}
            }
            else
            {
                e.Cancel = true;
                FuncionGlobal.alerta_updatepanel("Ud. no tiene los permisos suficientes para eliminar esta operación de la Nomina", this.Page, this.up_grilla);
            }
          
        }

        protected void Borrar_Operacion(Int32 id_solicitud, Int32 id_nomina, Int32 folio)
        {


            string del = new TipoNominaBC().del_Nominabyoperacion(id_nomina, id_solicitud, folio, (string)(Session["usrname"]));

            FuncionGlobal.alerta_updatepanel(string.Format("Operacion nro. {0} eliminada correctamente", id_solicitud), this.Page, this.up_grilla);

            this.gr_dato.DataSource = from n in new TipoNominaBC().getnominaByoperacion(Convert.ToInt32(ViewState["id_solicitud"]))
                                      orderby n.Id_nomina ascending
                                      select new
                                      {
                                          id_nomina = n.Id_nomina,
                                          descripcion = n.Descripcion,
                                          folio = n.Folio,
                                          reporte_url = string.Format("/reportes/view_nomina.aspx?id_familia={0}&folio={1}&id_nomina={2}", n.Id_familia, n.Folio, n.Id_nomina),


                                      };
            this.gr_dato.DataBind();
        }

    }
}
