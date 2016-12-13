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
    public partial class mUsuarioEstado : System.Web.UI.Page
    {
        public string CuentaUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            CuentaUsuario = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"]);
            
            if(IsPostBack)return;
            FuncionGlobal.ComboFamilia(dlFamilia); 
        }

        public void GetAll()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigoEstado"));
            dt.Columns.Add(new DataColumn("estadoNombre"));
            dt.Columns.Add(new DataColumn("checkSoloLectura", typeof(bool)));
            dt.Columns.Add(new DataColumn("checkExiste", typeof(bool)));
           

            foreach (var h in new UsuarioEstadoBC().get_all(CuentaUsuario,Convert.ToInt32(dlFamilia.SelectedValue)))
            {
                var dr = dt.NewRow();
                dr["codigoEstado"] = h.CodigoEstado;
                dr["estadoNombre"] = h.NombreEstado;
                dr["checkSoloLectura"] = h.SoloLectura;
                dr["checkExiste"] = h.Pertenece;
                
                dt.Rows.Add(dr);
            }
            gr_dato.DataSource = dt;
            gr_dato.DataBind();  
            
        }

        protected void dlFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAll();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
               Add();
        }

        public void Add()
        {
            var conteo = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var row = gr_dato.Rows[i];

                var chkSoloLectura = (CheckBox)gr_dato.Rows[i].FindControl("chkSoloLectura");
                var chkExiste = (CheckBox)gr_dato.Rows[i].FindControl("chkExiste");
                var idEstado = Convert.ToInt32(gr_dato.DataKeys[row.RowIndex].Values[0]);


                if (chkExiste.Checked)
                {   
                    new UsuarioEstadoBC().Upt(CuentaUsuario,idEstado,Convert.ToByte(chkSoloLectura.Checked?1:0));
                        conteo += 1;
                }
                else
                {
                    new UsuarioEstadoBC().Del(CuentaUsuario,idEstado);
                }
            }

            Mensaje("Se han realizado " + conteo + " cambios.");
        }

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje, Page, Upt);
        }
    }
}