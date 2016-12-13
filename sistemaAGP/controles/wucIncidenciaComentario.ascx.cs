using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.controles
{
    public partial class wucIncidenciaComentario : System.Web.UI.UserControl
    {
        private static int IdIncidencia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
          
        }

        public void ReiniciarComponentes(int idIncidencia)
        {
            IdIncidencia = idIncidencia;
            grComentario.DataSource = new IncidenciaBC().GetComentariosByIncidencia(Convert.ToInt32(IdIncidencia));
            grComentario.DataBind();
            txtComentario2.Text = string.Empty;          
        }


        protected void btnComentario_Click(object sender, EventArgs e)
        {
            if (txtComentario2.Text.Trim() == string.Empty)
            {
                FuncionGlobal.alerta("Agregue un comentario", Page);
                txtComentario2.Focus();
                return;
            }
            
            DataTable dt = new IncidenciaBC().GetIncidenciaById(IdIncidencia);
            var incidenciaEstado = Convert.ToInt32(dt.Rows[0]["id_incidencia_estado"]);
            new IncidenciaBC().AddComentario(IdIncidencia, incidenciaEstado, (string)(Session["usrname"]), txtComentario2.Text.Trim());


            grComentario.DataSource = new IncidenciaBC().GetComentariosByIncidencia(Convert.ToInt32(IdIncidencia));
            grComentario.DataBind();
            txtComentario2.Text = string.Empty;          
            FuncionGlobal.alerta("El comentario fue ingresado con éxito.", Page);
        }
    }
}