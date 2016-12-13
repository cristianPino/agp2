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
    public partial class mDocumentoCambioEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            FuncionGlobal.combocliente(dlClientes);
        }


        public void GetAll(int idFamilia, int idCliente)
        {
            
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idDocumento"));
            dt.Columns.Add(new DataColumn("idCliente"));
            dt.Columns.Add(new DataColumn("idFamilia"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("codigoSiguienteEstado")); 

            var lista = new DocumentoCambioEstadoBC().GetAllDocumentosCambioEstado(idFamilia, idCliente);
            gr_documentos.Visible = true;
            foreach (var doc in lista)
            {
                var dr = dt.NewRow();
                dr["idDocumento"] = doc.IdDocumento;
                dr["idCliente"] = doc.IdCliente;
                dr["idFamilia"] = doc.IdFamilia;
                dr["nombre"] = doc.NombreDocumento;
                dr["codigoSiguienteEstado"] = doc.SiguienteCodigoEstado;
                dt.Rows.Add(dr);
            }
            gr_documentos.DataSource = dt;
            gr_documentos.DataBind();
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAll(Convert.ToInt32(dlFamilia.SelectedValue),Convert.ToInt32(dlClientes.SelectedValue));
        }

        protected void dlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combofamilia_cliente(dlFamilia,Convert.ToInt16(dlClientes.SelectedValue));
            gr_documentos.Visible = false;
        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var dlEstados = (DropDownList)e.Row.FindControl("dlEstados");    
            FuncionGlobal.comboEstadoByFamilia(dlEstados,Convert.ToInt32(dlFamilia.SelectedValue));
            dlEstados.SelectedValue = gr_documentos.DataKeys[e.Row.RowIndex]["codigoSiguienteEstado"].ToString();
        }
        protected void updateP_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(updateP, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        private void Upt()
        {
            var conteo = 0;
            for (var i = 0; i < gr_documentos.Rows.Count; i++)
            {
                var row = gr_documentos.Rows[i];

                var idFamilia = Convert.ToInt32(dlFamilia.SelectedValue);
                var idCliente = Convert.ToInt32(dlClientes.SelectedValue);
                var idDocumento = Convert.ToInt32(gr_documentos.DataKeys[row.RowIndex].Values[0]);
                var dlSiguienteEstado = (DropDownList)gr_documentos.Rows[i].FindControl("dlEstados");

                var doc = new DocumentoCambioEstado
                    {
                        IdDocumento = idDocumento,
                        IdCliente = idCliente,
                        IdFamilia = idFamilia,
                        SiguienteCodigoEstado = Convert.ToInt32(dlSiguienteEstado.SelectedValue)
                    };

                if (dlSiguienteEstado.SelectedValue!="0")
                {
                    new DocumentoCambioEstadoBC().AddDocumentosCambioEstado(doc);
                    conteo += 1; 
                }
                else
                {
                    new DocumentoCambioEstadoBC().DelDocumentosCambioEstado(doc);
                }
            }

            Mensaje("Existen " + conteo + " Documentos que cambian estado.");
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje,Page,updateP);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
              Upt();
        }

    }
}