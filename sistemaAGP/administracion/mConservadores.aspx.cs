using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.administracion
{
    public partial class mConservadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            GetAllConservador();
        }

        public void GetAllConservador()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idConservador"));
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("urlComunas"));

            var lista = new ConservadorBC().GetAllconservador();

            foreach (var c in lista)
            {
                var dr = dt.NewRow();
                dr["idConservador"] = c.Id_conservador;
                dr["descripcion"] = c.Nombre;
                dr["urlComunas"] = "../administracion/mConservadorComuna.aspx?idConservador=" + FuncionGlobal.FuctionEncriptar(c.Id_conservador.ToString());
                dt.Rows.Add(dr);
            }
            Session["dt"] = dt;
            grConcervador.DataSource = dt;
            grConcervador.DataBind();
        }

        protected void grConcervador_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grConcervador.EditIndex = e.NewEditIndex; 
            BindData();
        }
        private void BindData()
        {
            grConcervador.DataSource = Session["dt"];
            grConcervador.DataBind();
        }
        public string AddConservador(int idConservador, string nombre)
        {
            var add = new ConservadorBC().AddConservador(idConservador, nombre);
            return add;
        }

        protected void grConcervador_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {  
            grConcervador.EditIndex = -1;   
            BindData();
        }

        protected void grConcervador_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the table from the session object.
            var dt = (DataTable)Session["dt"];

            //Update the values.
   
            var row = grConcervador.Rows[e.RowIndex];
            var id = Convert.ToInt32(grConcervador.DataKeys[e.RowIndex]["idConservador"]);
            var nombre = ((TextBox)(row.Cells[1].Controls[0])).Text;
            try
            {
              Mensaje(AddConservador(id, nombre));
            }
            catch(Exception ex)
            {
              Mensaje(ex.Message);
            }
            dt.Rows[row.DataItemIndex]["idConservador"] = id;
            dt.Rows[row.DataItemIndex]["descripcion"] = nombre;
          
            grConcervador.EditIndex = -1;
            BindData();
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje,Page,updateGrilla);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Mensaje(AddConservador(0, txtDescripcion.Text.TrimEnd().TrimStart()));
            }
            catch (Exception ex)
            {
               Mensaje(ex.Message);  
            }
           
        }
    }
}