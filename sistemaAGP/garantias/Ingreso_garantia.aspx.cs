using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.garantias
{
    public partial class Ingreso_garantia : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
			string id_solicitud;
			string id_cliente;
            string tipo_operacion;
            
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
			tipo_operacion = Request.QueryString["tipo_operacion"].ToString();

			//switch (id_cliente)
			//{
			//    case "4": //AUTOMOTORES GILDEMEISTER S.A.
			//    case "34": //COMERCIAL INDUMOTORA S.A.
			//        Response.Redirect("Ingreso_garantia_ag.aspx?" + Request.QueryString.ToString());
			//        break;
			//    case "6": //AUTOMOTRIZ PORTILLO S.A.
			//    case "35": //AUTOMOTORA PORTEZUELO S.A.
			//        Response.Redirect("Ingreso_garantia_portillo.aspx?" + Request.QueryString.ToString());
			//        break;
			//    case "14": //BICE CREDIAUTO
			//        Response.Redirect("Ingreso_garantia_bice.aspx?" + Request.QueryString.ToString());
			//        break;
			//    case "19": //SCOTIABANK
			//        Response.Redirect("Ingreso_garantia_scotiabank.aspx?" + Request.QueryString.ToString());
			//        break;
			//    case "50": //TANNER
			//        Response.Redirect("Ingreso_garantia_tanner.aspx?" + Request.QueryString.ToString());
			//        break;
			//    case "1": //AGP S.A.
			//    case "10": //AMICAR
			//    case "15": //BANCO ESTADO
			//    default:
			//        Response.Redirect("Ingreso_garantia_modal.aspx?" + Request.QueryString.ToString());
			//        break;
			//}

			switch (new ClienteBC().getcliente(Convert.ToInt16(id_cliente)).Persona.Rut.ToString())
			{
                case "96630680":
				case "79649140": //AUTOMOTORES GILDEMEISTER S.A
				case "79567420": //COMERCIALIZADORA INDUMOTORA S.A.
                case "88525600": //SERGIO ESCOBAR Y CIA LTDA.
                case "89414100": //RTC
                case "96970070": //COMERCIAL SAINT GERMAIN
                case "93435000": //CITROEN CHILE S.A.C
                case "79587410": //CAM INMOBILIARIA
                case "76216474": //EUROPARTS S.A.
                case "77120160": //SERGIO ESCOBAR MIRANDA Y CIA LTDA.
                    Response.Redirect("Ingreso_garantia_ag.aspx?" + Request.QueryString.ToString());
					break;
				case "79802860": //AUTOMOTRIZ PORTILLO S.A.
				case "77008670": //AUTOMOTRIZ PORTEZUELO S.A.
					Response.Redirect("Ingreso_garantia_portillo.aspx?" + Request.QueryString.ToString());
					break;
				case "79791730": //BICE CREDIAUTO
				case "76002293": //SANTANDER CONSUMER S.A.
                case "76307553": //BK SPA
					Response.Redirect("Ingreso_garantia_bice.aspx?" + Request.QueryString.ToString());
					break;
				case "97018000": //SCOTIABANK CHILE
                case "90146000":
                case "76178493"://PORSHE
                    Response.Redirect("Ingreso_garantia_scotiabank.aspx?" + Request.QueryString.ToString());
                    break;
                case "76547410": //amicar
					Response.Redirect("Ingreso_garantia_amicar.aspx?" + Request.QueryString.ToString());
					break;
				case "96667560": //TANNER SERVICIOS FINANCIERO SOCIEDAD ANÓNIMA
					Response.Redirect("Ingreso_garantia_tanner.aspx?" + Request.QueryString.ToString());
					break;
                case "88918500": //YUTRONIC
                    Response.Redirect("Ingreso_garantia_ag.aspx?" + Request.QueryString.ToString());
                    break;
				case "11111111": //AGP S.A.
				case "1": //AMICAR
				case "44444444": //BANCO ESTADO
				default:
					Response.Redirect("Ingreso_garantia_modal.aspx?" + Request.QueryString.ToString());
					break;
			}
        }
    }
}
