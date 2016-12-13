using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;

using CENTIDAD;
using System.Data;

namespace sistemaAGP.controles
{
    public partial class wucEjecutivoHipotecario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetEjecutivos(int idSolicitud)
        {

            var lista = new HipotecaOperacionEjecutivoBC().Get_hipoteca_operacion_ejecutivobyOperacion(idSolicitud);

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("sucursal"));
            dt.Columns.Add(new DataColumn("correo"));
            dt.Columns.Add(new DataColumn("correod"));
            dt.Columns.Add(new DataColumn("idSolicitud"));
           
            foreach (var x in lista)
            {
                var dr = dt.NewRow();
                dr["id"] = x.IdHipotecaOperacionEjecutivo;
                dr["idSolicitud"] = idSolicitud;
                dr["nombre"] = x.Nombre + " " + x.Apepat + " " + x.Apemat;
                dr["cliente"] = x.Cliente.Persona.Nombre;
                dr["sucursal"] = x.Sucursal.Nombre;
                dr["correo"] = x.Mail;
                dr["correod"] = "mailto:" + x.Mail;
               
                dt.Rows.Add(dr);
            }
            grEjecutivoHipotecario.DataSource = dt;
            grEjecutivoHipotecario.DataBind();

        }

        protected void grEjecutivoHipotecario_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Eliminar") return;
            var index = Convert.ToInt32(e.CommandArgument);
            var h = new HipotecaOperacionEjecutivo
                {
                    IdHipotecaOperacionEjecutivo = Convert.ToInt32(this.grEjecutivoHipotecario.DataKeys[index]["id"]),
                    IdSolicitud = Convert.ToInt32(this.grEjecutivoHipotecario.DataKeys[index]["idSolicitud"])
                };

            new HipotecaOperacionEjecutivoBC().DelEjecutivoHipoteca(h);
            GetEjecutivos(h.IdSolicitud);
            Mensaje("Participante Eliminado Correctamente");
            
            
        }   
        public string AddEjecutivoOperacion(HipotecaOperacionEjecutivo h)
        {
            var add = new HipotecaOperacionEjecutivoBC().AddEjecutivoHipoteca(h);
            GetEjecutivos(h.IdSolicitud);
            return add;
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje, Page, update1);
        }
    }
}