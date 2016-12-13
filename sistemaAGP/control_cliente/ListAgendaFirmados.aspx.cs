using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;

namespace sistemaAGP.control_cliente
{
    public partial class ListAgendaFirmados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargagrillacredito()
        {
          

            List<MasterBCA> msc = new MasterBCABC().getListMasterBCAall();

            DataTable dtcra = new DataTable();
            dtcra.Columns.Add("idSolicitud", typeof(string));
            dtcra.Columns.Add("ninterno", typeof(string));
            dtcra.Columns.Add("id_Ope", typeof(string));

            foreach (MasterBCA item in msc)
            {
                if (item.Id_credito != 0)
                {
                    DataRow rowcr;
                    rowcr = dtcra.Rows.Add();
                    rowcr["idSolicitud"] = item.Id_solicitud;
                    rowcr["ninterno"] = item.Id_interno;
                    rowcr["id_Ope"] = item.Id_credito;
                }
            }
            this.grdnewcredit.DataSource = dtcra;
            this.grdnewcredit.DataBind();
        }
    }
}