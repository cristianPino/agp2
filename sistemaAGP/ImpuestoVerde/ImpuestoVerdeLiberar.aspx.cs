using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP.ImpuestoVerde
{
    public partial class ImpuestoVerdeLiberar : System.Web.UI.Page
    {
        private Usuario musuaper;

        protected void Page_Load(object sender, EventArgs e)
        {
            musuaper = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
        }

        protected void bt_graba_movimiento_Click(object sender, EventArgs e)
        {
            var idSolicitud = Convert.ToInt32(txt_operacion.Text);

            var op = new OperacionBC().getoperacion(idSolicitud);

            if (op.Id_solicitud == 0)
            {
                FuncionGlobal.alerta("El nùmero ingresado no existe", Page);
                return;
            }

            if (op.tipo_operacion_.Trim().ToUpper() == "IP" 
                || op.tipo_operacion_.Trim().ToUpper() == "PI" 
                || op.tipo_operacion_.Trim().ToUpper() == "PITAG" 
                || op.tipo_operacion_.Trim().ToUpper() == "TFPI" 
                || op.tipo_operacion_.Trim().ToUpper() == "IPTAG"
                || op.tipo_operacion_.Trim().ToUpper() == "SIMP"
                || op.tipo_operacion_.Trim().ToUpper() == "IPSTG"
                )
            {
                if (musuaper.UserName.Trim() != "153636613" && musuaper.UserName.Trim() != "141548085" && musuaper.UserName.Trim() != "116333627"
                    && musuaper.UserName.Trim() != "15678754k")
                {
                    if (op.usuarioImpuestoVerde.Trim() != musuaper.UserName.Trim())
                    {
                        FuncionGlobal.alerta("No tiene el permiso para liberar esta operación.", Page);
                        return;
                    }
                }

                new OperacionBC().del_impuesto_verde(idSolicitud, (string)(Session["usrname"]));
                FuncionGlobal.alerta("La operacion ha sido leberada", Page);
            }
            else
            {
                FuncionGlobal.alerta("Esta operación no considera pago impuesto verde.", Page);
                return;
            }
        }
    }
}