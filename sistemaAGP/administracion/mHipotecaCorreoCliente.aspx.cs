using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;

namespace sistemaAGP.administracion
{
    public partial class mHipotecaCorreoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            GetClientes();
        }

        public void GetClientes()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idCliente"));
            dt.Columns.Add(new DataColumn("clienteNombre"));
            dt.Columns.Add(new DataColumn("url_correoCliente"));

            foreach (var c in new ClienteBC().Get_clientesAgp_hipoteca())
            {
                var dr = dt.NewRow();
                dr["idCliente"] = c.Id_cliente;
                dr["clienteNombre"] = c.Persona.Nombre;
                dr["url_correoCliente"] = "../administracion/mHipotecaCorreoEstado.aspx?id_cliente="+FuncionGlobal.FuctionEncriptar(c.Id_cliente.ToString(CultureInfo.InvariantCulture));
                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}