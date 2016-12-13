using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.Operacion_Hipotecario.modal
{
    public partial class IngresoFirmas : System.Web.UI.Page
    {
        public int IdSolicitud;
        public int IdEstado;

        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
            IdEstado = Convert.ToInt32(Request.QueryString["idEstado"]);
            hdIdSolicitud.Value = IdSolicitud.ToString(CultureInfo.InvariantCulture);
            hdIdEstado.Value = IdEstado.ToString(CultureInfo.InvariantCulture);
            if(IsPostBack)return;
            GetAll();
        }

        public void GetAll()
        {
            var dt = new DataTable();  
            dt.Columns.Add(new DataColumn("idHipotecarioFirma"));
            dt.Columns.Add(new DataColumn("firma"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("comentario"));
            dt.Columns.Add(new DataColumn("idFirma"));
            dt.Columns.Add(new DataColumn("check", typeof(bool)));
            var lista = new HipotecarioFirmaBC().GetHipotecarioFirma(IdSolicitud);

            foreach (var h in lista)
            {
                var dr = dt.NewRow();  
                dr["idHipotecarioFirma"] = h.IdHipotecarioFirma;
                 dr["comentario"] = h.Comentario;
                dr["firma"] = h.Titulo.ToUpper();
                dr["idFirma"] = h.IdFirma;
                dr["fecha"] = h.IdHipotecarioFirma == 0 ? "" : h.FechaFirma.ToString();
                dr["usuario"] = h.UsuarioFirma.UserName == null ? "": h.UsuarioFirma.Nombre.ToUpper();
                dr["check"] = h.Existe;
                dt.Rows.Add(dr);

            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        public int Add()
        {
            var contador = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox) gr_dato.Rows[i].FindControl("chk"); 
                if (!chk.Checked) continue;
                var textbox = (TextBox) gr_dato.Rows[i].FindControl("txtComentario");
                var idSolicitud = Convert.ToInt32(hdIdSolicitud.Value.Trim());
                var idFirma = Convert.ToInt32(gr_dato.DataKeys[i]["idFirma"]);
                var titulo = gr_dato.DataKeys[i]["firma"];
                var h = new HipotecarioFirma
                    {
                        IdSolicitud = idSolicitud,
                        IdFirma = idFirma,
                        UsuarioFirma = new Usuario {UserName = Session["usrname"].ToString()},
                        Comentario = textbox.Text.Trim()
                    };
                new HipotecarioFirmaBC().AddHipotecarioFirma(h);
                AddHito(titulo+": "+ textbox.Text.Trim());
                contador++;
            }
            return contador;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
               var correctas = Add();
               GetAll();
               FuncionGlobal.alerta_updatepanel("Se guardaron "+correctas+" firmas.", this.Page, upd); 

            }
            catch (Exception ex)
            {
               FuncionGlobal.alerta_updatepanel(ex.Message,this.Page,upd);
            }
        }

        public void AddHito(string observacion)
        {
            new HitoBC().add_hito(Convert.ToInt32(hdIdEstado.Value.Trim()), observacion, DateTime.Now.ToShortDateString(),1);
        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var check = (CheckBox)e.Row.FindControl("chk");
            var text = (TextBox)e.Row.FindControl("txtComentario");
            if (!check.Checked) return;
            check.Enabled = false;
            text.ReadOnly = true;
        }
    }
}