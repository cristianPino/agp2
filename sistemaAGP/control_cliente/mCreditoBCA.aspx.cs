using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;

namespace sistemaAGP.control_cliente
{
    public partial class mCreditoBCA : System.Web.UI.Page
    {

        //private string IdSol;
        private string NCredito;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Pagar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdResultado.Rows)
            {
                Label lblOpr = (Label)row.Cells[4].FindControl("id_solicitud");
                Label lblCli = (Label)row.Cells[5].FindControl("rutCliente");
                NCredito = row.Cells[0].Text;

                CheckBox cb = (CheckBox)row.Cells[3].FindControl("ChkPago");
                if (cb != null && cb.Checked)
                {

                   // string agBCA = new EstadooperacionBC().add_Estadooperacion(convert
                }
            }

        }

        protected void grdResultado_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox CheckBoxpago = (CheckBox)e.Row.Cells[0].FindControl("ChkPago");
                CheckBoxpago.ToolTip = "Seleccione";

                if (e.Row.Cells[1].Text != "PG")
                {
                    CheckBoxpago.Checked = true;
                    CheckBoxpago.Enabled = false;
                }

            }
        }

        


    }
}