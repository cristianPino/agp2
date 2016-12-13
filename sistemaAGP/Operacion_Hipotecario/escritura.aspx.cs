using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace sistemaAGP.Operacion_Hipotecario
{
    public partial class escritura : System.Web.UI.Page
    {

        Int32 id_solicitud = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString()));
            
            
            if (!IsPostBack)
            {

                combo_escritura();
                combo_notaria();
                
            }

        }


        private void combo_escritura()
        {

            List<Matriz_Escritura> lmatriz = new Matriz_EscrituraBC().getmatrizescrituras(id_solicitud);

            this.dl_escritura.DataSource = lmatriz;
            this.dl_escritura.DataValueField = "cod_matriz";
            this.dl_escritura.DataTextField = "descripcion";
            this.dl_escritura.DataBind();
            this.dl_escritura.SelectedValue = "0";
        
        }

        private void combo_notaria()
        {

            List<Notaria> lnotaria = new NotariaBC().getNotaria();

            this.dl_notario.DataSource = lnotaria;
            this.dl_notario.DataValueField = "cod_notaria";
            this.dl_notario.DataTextField = "nombre";
            this.dl_notario.DataBind();
            this.dl_notario.SelectedValue = "0";

        }


        public void findAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
    

         }

    }
}