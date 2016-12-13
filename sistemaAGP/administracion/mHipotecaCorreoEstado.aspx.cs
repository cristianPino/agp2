using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.administracion
{
    public partial class mHipotecaCorreoEstado : System.Web.UI.Page
    {
        protected int IdCliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdCliente = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"]));
            if(IsPostBack)return;
            FuncionGlobal.combofamilia_producto(dlFamilia);
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dlFamilia.SelectedValue!="0")
            {
                 GetAll();
            }
        }

        public void GetAll()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigoEstado"));
            dt.Columns.Add(new DataColumn("estadoNombre"));
            dt.Columns.Add(new DataColumn("checkEjecutivoH", typeof(bool)));
            dt.Columns.Add(new DataColumn("checkVendedorH", typeof(bool)));
            dt.Columns.Add(new DataColumn("checkCompradorH", typeof(bool)));
            dt.Columns.Add(new DataColumn("checkUsuarios", typeof(bool)));
            dt.Columns.Add(new DataColumn("checkLista", typeof(bool)));
            dt.Columns.Add(new DataColumn("idFormatoCorreo"));
            dt.Columns.Add(new DataColumn("lista"));

            foreach (var h in new HipotecaCorreoBC().GetHipotecaCorreos(IdCliente,Convert.ToInt32(dlFamilia.SelectedValue)))
            {
                var dr = dt.NewRow();
                dr["codigoEstado"] = h.IdCodigoEstado;
                dr["estadoNombre"] = h.DescripcionEstado;
                dr["checkEjecutivoH"] = h.CorreoEjecutivoHipotecario;
                dr["checkVendedorH"] = h.CorreoVendedorHipotecario;
                dr["checkCompradorH"] = h.CorreoCompradorHipotecario;
                dr["checkUsuarios"] = h.CorreoUsuariosOperacion;
                dr["checkLista"] = h.CorreoListaCorreo;
                dr["idFormatoCorreo"] = h.IdFormatoCorreo;
                dr["lista"] = h.Lista;
                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();  

        }

        private void Upt()
        {
            var conteo = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var row = gr_dato.Rows[i];
                var chkEjecutivo = (CheckBox)gr_dato.Rows[i].FindControl("chkEjecutivo");
                var chkVendedor = (CheckBox)gr_dato.Rows[i].FindControl("chkVendedor");
                var chkComprador = (CheckBox)gr_dato.Rows[i].FindControl("chkComprador");
                var chkUsuarios = (CheckBox)gr_dato.Rows[i].FindControl("chkUsuarios");
                var chkLista = (CheckBox)gr_dato.Rows[i].FindControl("chkLista");
                var txtListaCorreo = (TextBox)gr_dato.Rows[i].FindControl("txtListaCorreo");
                var idEstado = Convert.ToInt32(gr_dato.DataKeys[row.RowIndex].Values[0]);
                var dlFormatoCorreo = (DropDownList)gr_dato.Rows[i].FindControl("dlFormatoCorreo");

                var hi = new HipotecaCorreo();
                hi.IdCliente = IdCliente;
                hi.IdCodigoEstado = idEstado;
                hi.CorreoEjecutivoHipotecario = chkEjecutivo.Checked;
                hi.CorreoCompradorHipotecario = chkComprador.Checked;
                hi.CorreoVendedorHipotecario = chkVendedor.Checked;
                hi.CorreoUsuariosOperacion = chkUsuarios.Checked;
                hi.CorreoListaCorreo = chkLista.Checked;
                hi.Lista = txtListaCorreo.Text;
                hi.IdFormatoCorreo = Convert.ToInt32(dlFormatoCorreo.SelectedValue);
               
                if(chkEjecutivo.Checked||chkVendedor.Checked||chkComprador.Checked||chkUsuarios.Checked||chkLista.Checked)
                {
                    if (hi.IdFormatoCorreo != 0) { new HipotecaCorreoBC().UptCorreos(hi);
                        conteo += 1;
                    }  
                }
                else
                {
                    new HipotecaCorreoBC().DelCorreos(hi);
                }   
            }  
     
            Mensaje("Se han realizado "+conteo+" cambios.");
        }

        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var dlFormatoCorreo = (DropDownList)e.Row.FindControl("dlFormatoCorreo");
            
            var dt = new DataTable();
            dt.Columns.Add("IdFormatoCorreo");
            dt.Columns.Add("Descripcion");
            var dr = dt.NewRow();
            dr["IdFormatoCorreo"] = 0;
            dr["Descripcion"] = "Seleccionar...";
            dt.Rows.Add(dr);

            //Actividad por prod_cliente
            var lista = new FormatoCorreoBC().GetFortmatoCorreos();
            foreach (var f in lista)
            {
                dr = dt.NewRow();
                dr["IdFormatoCorreo"] = f.IdFormatoCorreo;
                dr["Descripcion"] = f.Descripción;
                dt.Rows.Add(dr);

            }

            var seleccion = gr_dato.DataKeys[e.Row.RowIndex]["idFormatoCorreo"].ToString();

            dlFormatoCorreo.DataSource = dt;
            dlFormatoCorreo.DataTextField = "Descripcion";
            dlFormatoCorreo.DataValueField = "IdFormatoCorreo";
            dlFormatoCorreo.SelectedValue = seleccion;
            dlFormatoCorreo.DataBind();
          }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Upt();
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje,Page,upt1);
        }


    }
}