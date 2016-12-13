using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.administracion
{
    public partial class mParticipanteOperacion : Page
    {
        public int IdSolicitud;
        public string Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idSolicitud"]));
            Tipo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["tipo"]);
            if(IsPostBack)return;
            FuncionGlobal.comboparametro(dlTipo, "OPART");
            dlTipo.SelectedValue = Tipo;
            dlTipo.Enabled = false;
            Participante.GetParticipantes(IdSolicitud,Tipo);
        }

        public void AddPersona()
        {
           if(DatosParticipante.Guardar_Form())
           {
               AddParticipanteOperacion();
           }
           else
           {
               Mensaje("Error: No se ha podido agregar el Participante");
           }
        }
        public void AddParticipanteOperacion()
        {
            var tipo = dlTipo.SelectedValue;
            var rut =Convert.ToInt32(DatosParticipante.InfoPersona.Rut);
            if(tipo =="0")
            {
                Mensaje("Error: Seleccione un tipo de Participante");
                return;
            }
            new ParticipeOperacionBC().add_participe(IdSolicitud, rut, tipo); 
           
            Participante.GetParticipantes(IdSolicitud,tipo);
            Mensaje("Se ha agregado un nuevo Participante.");
        }  

        public void Mensaje(string mensaje)
        {
           FuncionGlobal.alerta_updatepanel(mensaje,Page,updatePanelIngreso);
        }  

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
           AddPersona();
        }
    }
}