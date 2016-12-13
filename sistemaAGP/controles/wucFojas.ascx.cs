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
    public partial class wucFojas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetAllFojasbyTipo(int idSolicitud, string tipo)
        {
            lblTipo.Text = tipo;
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idFoja"));
            dt.Columns.Add(new DataColumn("descripcionTipo"));
            dt.Columns.Add(new DataColumn("tipo"));
            dt.Columns.Add(new DataColumn("inscripcionFoja"));
            dt.Columns.Add(new DataColumn("inscripcionNumero"));
            dt.Columns.Add(new DataColumn("inscripcionAnio"));
            dt.Columns.Add(new DataColumn("observaciones"));
            dt.Columns.Add(new DataColumn("idSolicitud"));
            dt.Columns.Add(new DataColumn("fojaLetra"));

            var f = new hipotecaFoja {IdSolicitud= idSolicitud, CodigoTipo = tipo};

            var lista = new hipotecaFojaBC().GetFojas(f);

            foreach (var c in lista)
            {
                var dr = dt.NewRow();
                dr["idFoja"] = c.IdFoja;
                dr["descripcionTipo"] = c.TipoFoja.Valoralfanumerico;
                dr["tipo"] = c.TipoFoja.Codigoparametro;
                dr["inscripcionFoja"] = c.InscripcionFoja;
                dr["inscripcionNumero"] = c.InscripcionNumero;
                dr["inscripcionAnio"] = c.InscripcionAnio;
                dr["observaciones"] = c.Observacion;
                dr["idSolicitud"] = idSolicitud;
                dr["fojaLetra"] = c.InscripcionFojaLetra;
                dt.Rows.Add(dr);
            }
            Session["dt"+tipo] = dt;
            grFojas.DataSource = dt;
            grFojas.DataBind();
        }

        protected void grFojas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grFojas.EditIndex = e.NewEditIndex;
            BindData();
        }
        private void BindData()
        {
            grFojas.DataSource = Session["dt"+lblTipo.Text.Trim()];
            grFojas.DataBind();
        }
        public string AddFojas(hipotecaFoja h)
        {
           new hipotecaFojaBC().AddFojas(h);
           return "Foja Actualizada correctamente";
        }

        protected void grFojas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grFojas.EditIndex = -1;
            BindData();
        }

        protected void grFojas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the table from the session object.
            var dt = (DataTable)Session["dt"+lblTipo.Text.Trim()];

            //Update the values.

            var row = grFojas.Rows[e.RowIndex];
            var f = new hipotecaFoja();


            f.IdFoja = Convert.ToInt32(grFojas.DataKeys[e.RowIndex]["idFoja"]);
            f.IdSolicitud = Convert.ToInt32(grFojas.DataKeys[e.RowIndex]["idSolicitud"]);
            f.CodigoTipo = grFojas.DataKeys[e.RowIndex]["tipo"].ToString();


            f.InscripcionFoja = ((TextBox)(row.Cells[2].Controls[0])).Text;
            f.InscripcionFojaLetra = ((TextBox)(row.Cells[3].Controls[0])).Text;
            f.InscripcionNumero = ((TextBox)(row.Cells[4].Controls[0])).Text;
            f.InscripcionAnio = ((TextBox)(row.Cells[5].Controls[0])).Text;
            f.Observacion = ((TextBox)(row.Cells[6].Controls[0])).Text;  
            try
            {

                Mensaje(AddFojas(f));
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
            dt.Rows[row.DataItemIndex]["idFoja"] = f.IdFoja;
            dt.Rows[row.DataItemIndex]["idSolicitud"] = f.IdSolicitud;
            dt.Rows[row.DataItemIndex]["descripcionTipo"] = new ParametroBC().getparametro("FOJHI", f.CodigoTipo).Valoralfanumerico;
            dt.Rows[row.DataItemIndex]["tipo"] = f.CodigoTipo;
            dt.Rows[row.DataItemIndex]["inscripcionFoja"] = f.InscripcionFoja;
            dt.Rows[row.DataItemIndex]["inscripcionNumero"] = f.InscripcionNumero;
            dt.Rows[row.DataItemIndex]["inscripcionAnio"] = f.InscripcionAnio;
            dt.Rows[row.DataItemIndex]["observaciones"] = f.Observacion;
            dt.Rows[row.DataItemIndex]["fojaLetra"] = f.InscripcionFojaLetra;
            grFojas.EditIndex = -1;
            BindData();
        }

        public void DelFoja(hipotecaFoja f)
        {
            new hipotecaFojaBC().del_Fojas(f);  
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje, Page, updateGrilla);
        }

        protected void grFojas_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Eliminar") return;
            var index = Convert.ToInt32(e.CommandArgument);
            var f = new hipotecaFoja();

            f.IdSolicitud = Convert.ToInt32(grFojas.DataKeys[index]["idSolicitud"]);
            f.IdFoja = Convert.ToInt32(grFojas.DataKeys[index]["idFoja"]);
            f.CodigoTipo = grFojas.DataKeys[index]["tipo"].ToString().Trim();
               

            DelFoja(f);
            GetAllFojasbyTipo(Convert.ToInt32(f.IdSolicitud),f.CodigoTipo.Trim());   
            
            Mensaje("Foja eliminada correctamente");
        }
    }
}