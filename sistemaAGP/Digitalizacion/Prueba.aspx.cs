using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace GestionAGP
{
    public partial class Prueba : System.Web.UI.Page
    {
        Int16 tipo;
        Int32 id_solicitud;

        protected void Page_Load(object sender, EventArgs e)
        {

            tipo = Convert.ToInt16(Request.QueryString["tipo"]);
            id_solicitud = Convert.ToInt32(Request.QueryString["id_solicitud"]);
            this.txtFileName.Text = id_solicitud.ToString().Trim();
            Documentos mdoc = new DocumentosBC().getDocumentosbyID(tipo);
            this.txt_tipo.Text = mdoc.Nombre.Trim();


            this.txtActionPage.Value = "SaveToFile.aspx?tipo=" + tipo.ToString().Trim() + "&id_solicitud=" + id_solicitud.ToString().Trim() + "&user=153944601";  
            
            //this.txtActionPage.Text = "SaveToFile.aspx?tipo=" + tipo.ToString().Trim() +  "&id_solicitud=" + id_solicitud.ToString().Trim() + "&user=153944601";  

        }
    }
}