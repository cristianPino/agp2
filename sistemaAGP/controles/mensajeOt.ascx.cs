using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.controles
{
    public partial class mensajeOt : System.Web.UI.UserControl
    {
        public int IdOrdenTrabajo;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_orden_trabajo"]));
            hdnIdOrdenTrabajo.Value = Convert.ToString(IdOrdenTrabajo);
            
            if(IsPostBack)return;
            GetMensaje(IdOrdenTrabajo);
            GetContactos();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
             NuevoMensaje();
        }

        public void NuevoMensaje()
        {
            var mensaje = new MensajeOrdenTrabajo
                {
                    Mensaje = txtMensaje.Text.Trim(),
                    IdOrdenTrabajo = Convert.ToInt32(hdnIdOrdenTrabajo.Value),
                    IdUsuario = Convert.ToString(Session["usrname"])
                };
            try
            {
                var idMensaje =  new MensajeOrdenTrabajoBC().AddMensaje(mensaje);
                EnviarDestinatarios(idMensaje);
                GetMensaje(Convert.ToInt32(hdnIdOrdenTrabajo.Value));
                FuncionGlobal.alerta_updatepanel("Mensaje guardado correctamente", this.Page, updmensaje);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta(ex.Message,Page);
            }

        }

        public void EnviarDestinatarios(int idMensaje)
        {
            for (var i = 0; i < grContactos.Rows.Count; i++)
            {
                var chk = (CheckBox)grContactos.Rows[i].FindControl("chk");

                var usuarioDestino = Convert.ToString(grContactos.DataKeys[i].Values["id_usuario"]);

                if (!chk.Checked) continue;
                new MensajeOrdenTrabajoBC().AddMensajeaDestinatarios(idMensaje,usuarioDestino,"NO"); 
            }

        }

        public void GetMensaje(int idOrdenTrabajo)
        {
            var lista = new MensajeOrdenTrabajoBC().GetMensajes(idOrdenTrabajo);
            
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_mensaje"));
            dt.Columns.Add(new DataColumn("id_usuario"));
            dt.Columns.Add(new DataColumn("usuarioIngreso"));
            dt.Columns.Add(new DataColumn("inicio"));
            dt.Columns.Add(new DataColumn("mensaje"));

            foreach (var m in lista)
            {
                var dr = dt.NewRow();
                dr["id_mensaje"] = m.IdMensaje;
                dr["id_usuario"] = m.IdUsuario;
                dr["usuarioIngreso"] = m.NombreUsuario;
                dr["inicio"] = m.Fecha;
                dr["mensaje"] = m.Mensaje;
                dt.Rows.Add(dr);
            }

            grMensajes.DataSource = dt;
            grMensajes.DataBind();

        }

        public void GetContactos()
        {
            var lista = new MensajeOrdenTrabajoBC().GetContactos(Convert.ToString(Session["usrname"]));
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_usuario"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("imagen_fav"));
     

            foreach (var m in lista)
            {
                var dr = dt.NewRow();
                dr["id_usuario"] = m.IdUsuario;
                dr["usuario"] = m.NombreUsuario;
                dr["imagen_fav"] = m.Favorito ? "~/imagenes/sistema/static/pre_ticket/favourites7.png" :"";
              
                dt.Rows.Add(dr);
            }

            grContactos.DataSource = dt;
            grContactos.DataBind();
        }

    }
}