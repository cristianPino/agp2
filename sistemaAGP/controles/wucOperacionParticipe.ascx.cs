using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;

namespace sistemaAGP.controles
{
    public partial class wucOperacionParticipe : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetParticipantes(int idSolicitud, string tipo="")
        {

            var lista =
            from p in new ParticipeOperacionBC().getparticipes(idSolicitud)
            where p.Tipo == tipo || tipo == ""
            select p;

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("rut"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("tipo"));
            dt.Columns.Add(new DataColumn("url_contactos"));
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("url_representantes"));
            dt.Columns.Add(new DataColumn("url_correos"));
            dt.Columns.Add(new DataColumn("url_direcciones")); 
            dt.Columns.Add(new DataColumn("busqueda"));
            dt.Columns.Add(new DataColumn("tipo_descripcion")); 
            foreach (var x in lista)
            {
                var dr = dt.NewRow();  
                dr["rut"] = x.Participe.Rut;
                dr["nombre"] = x.Participe.Nombre + " " + x.Participe.Apellido_paterno + " " + x.Participe.Apellido_materno;
                dr["tipo"] = x.Tipo;
                dr["tipo_descripcion"] = new ParametroBC().getparametro("OPART", x.Tipo).Valoralfanumerico;
                dr["id_solicitud"] = idSolicitud;
                dr["url_correos"] = "../administracion/mCorreo.aspx?rut=" + FuncionGlobal.FuctionEncriptar(x.Participe.Rut.ToString().Trim());
                dr["url_direcciones"] = "../administracion/mDireccion.aspx?rut=" + FuncionGlobal.FuctionEncriptar(x.Participe.Rut.ToString().Trim());
                dr["url_contactos"] = "../administracion/mTelefonos.aspx?rut=" + FuncionGlobal.FuctionEncriptar(x.Participe.Rut.ToString().Trim());
                dr["url_representantes"] = "../administracion/mParticipante.aspx?rut=" + FuncionGlobal.FuctionEncriptar(x.Participe.Rut.ToString().Trim());
                dr["busqueda"] = tipo == "" ? "Por operacion" : "Por tipo";
                dt.Rows.Add(dr);
            }
            grOperacionParticipe.DataSource = dt;
            grOperacionParticipe.DataBind();     

        }
        protected void grOperacionParticipe_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Eliminar") return;
            var index = Convert.ToInt32(e.CommandArgument); 
            var idSolicitud = Convert.ToInt32(this.grOperacionParticipe.DataKeys[index]["id_solicitud"]);
            var rut = Convert.ToInt32(this.grOperacionParticipe.DataKeys[index]["rut"]);
            var tipo = this.grOperacionParticipe.DataKeys[index]["tipo"].ToString();
            var busqueda = this.grOperacionParticipe.DataKeys[index]["busqueda"].ToString();
            new ParticipeOperacionBC().Delparticipebytipo(idSolicitud,tipo,rut);
            switch (busqueda)
            {
                case "Por tipo":
                    this.GetParticipantes(idSolicitud, tipo);
                    break;
                case "Por operacion":
                    this.GetParticipantes(idSolicitud);
                    break;
            }
            FuncionGlobal.alerta_updatepanel("Participante Eliminado Correctamente",Page,update1);
        }

    }
}