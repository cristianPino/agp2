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
    public partial class mOrdenTrabajo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            FuncionGlobal.comboparametro(dlCopiaPerfil, "PROT");
            FuncionGlobal.ComboUsuariosbyGrupo(dlCopiaUsuario, "0");
            FuncionGlobal.comboparametro(dlTipoBusqueda, "TIBUOT");

            Mensajes(string.Format("{0}, este es el administrador de pretickets", FuncionGlobal.SaludosHorario()), 4);
        }

        public void Mensajes(string mensaje, int tipo)
        {
            Master.LblInfo.Text = mensaje;

            switch (tipo)
            {
                case 1:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/verde.png";
                    break;
                case 2:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/warning.png";
                    break;
                case 3:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/rojo.png";
                    break;
                case 4:
                    Master.ImeInfo.ImageUrl = "/imagenes/sistema/static/bienvenido.png";
                    break;
            }
        }


        protected void ibBuscar_Click(object sender, ImageClickEventArgs e)
        {
            pnelConfiguracion.Visible = false;
            lblUsuarioNombre.Text = string.Empty;

            var cuentaUsuario = txtCuentaUsuario.Value.Trim();
            if (cuentaUsuario == string.Empty)
            {
                Mensajes("Ups! no ha ingresado una cuenta de usuario", 2);
                return;
            }

            Usuario usuario = GetUsuario(cuentaUsuario);

            if (usuario.UserName != null)
            {
                pnelConfiguracion.Visible = true;
                lblUsuarioNombre.Text = usuario.Nombre.ToUpper().Trim();
                GetPermisosEspeciales(usuario.UserName);
                GetActividades(usuario.UserName);
                GetGrupo(usuario.UserName);
                Mensajes( string.Format("¡Bien! Ahora estás viendo las configuraciones de {0}",usuario.Nombre.ToUpper()), 1);
            }
            else
            {
                Mensajes("Rayos! el usuario no existe", 2);
            }

        }


        private Usuario GetUsuario(string cuentaUsuario)
        {
            var usuario = new UsuarioBC().GetUsuario(cuentaUsuario);
            return usuario;

        }

        private void GetPermisosEspeciales(string cuentaUsuario)
        {
            var dt = new OrdenTrabajoBC().GetPermisosEspeciales(cuentaUsuario);

            //LIMPIAR
            dlTipoBusqueda.SelectedValue = "0";
            ckbAgregarMenu.Checked = false;
            ckPermisoAsignar.Checked = false;
            ckPermisoEliminar.Checked = false;
            ckPermisoGarantia.Checked = false;
            ckPermisoPrimera.Checked = false;

            if (dt.Rows.Count > 0)
            {
                dlTipoBusqueda.SelectedValue = Convert.ToString(dt.Rows[0]["tipo_busqueda"]);
                ckbAgregarMenu.Checked = Convert.ToBoolean(dt.Rows[0]["menu"]);
                ckPermisoAsignar.Checked = Convert.ToBoolean(dt.Rows[0]["permiso_asignar"]);
                ckPermisoEliminar.Checked = Convert.ToBoolean(dt.Rows[0]["permiso_eliminar"]);
                ckPermisoGarantia.Checked = Convert.ToBoolean(dt.Rows[0]["permiso_agregar_garantia"]);
                ckPermisoPrimera.Checked = Convert.ToBoolean(dt.Rows[0]["permiso_masivo_factura"]);
            }

        }

        private void GetActividades(string cuentaUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_actividad_orden_trabajo"));
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("existe", typeof(bool)));
            dt.Columns.Add(new DataColumn("solo_lectura", typeof(bool)));

            var dta = new OrdenTrabajoBC().GetActividadesUsuario(cuentaUsuario);

            foreach (DataRow dra in dta.Rows)
            {
                var dr = dt.NewRow();
                dr["id_actividad_orden_trabajo"] = dra["id_actividad_orden_trabajo"].ToString();
                dr["descripcion"] = dra["descripcion"].ToString();
                dr["existe"] = Convert.ToBoolean(dra["existe"]);
                dr["solo_lectura"] = Convert.ToBoolean(dra["solo_lectura"]);
                dt.Rows.Add(dr);
            }

            grActividades.DataSource = dt;
            grActividades.DataBind();
        }

        private void GetGrupo(string cuentaUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo_grupo"));
            dt.Columns.Add(new DataColumn("grupo"));
            dt.Columns.Add(new DataColumn("jefe", typeof(bool)));
            dt.Columns.Add(new DataColumn("observador", typeof(bool)));
            dt.Columns.Add(new DataColumn("activo", typeof(bool)));
            var dta = new OrdenTrabajoBC().GetGruposUsuario(cuentaUsuario);

            foreach (DataRow dra in dta.Rows)
            {
                var dr = dt.NewRow();
                dr["codigo_grupo"] = dra["codigo_grupo"].ToString();
                dr["grupo"] = dra["grupo"].ToString();
                dr["jefe"] = Convert.ToBoolean(dra["jefe"]);
                dr["observador"] = Convert.ToBoolean(dra["observador"]);
                dr["activo"] = Convert.ToBoolean(dra["activo"]);
                dt.Rows.Add(dr);
            }

            grGrupo.DataSource = dt;
            grGrupo.DataBind();
        }

        protected void rbCopiaPerfil_CheckedChanged(object sender, EventArgs e)
        {
            dlCopiaUsuario.Enabled = false;
            dlCopiaPerfil.Enabled = true;
            tab_opciones.Enabled = false;
        }

        protected void rbCopiarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            dlCopiaUsuario.Enabled = true;
            dlCopiaPerfil.Enabled = false;
            tab_opciones.Enabled = false;
        }

        protected void rbCopiarPersonalizar_CheckedChanged(object sender, EventArgs e)
        {
            dlCopiaUsuario.Enabled = false;
            dlCopiaPerfil.Enabled = false;
            tab_opciones.Enabled = true;
        }


        private void GuardarCopiaPerfil(string cuentaUsuario, string perfil)
        {
            new OrdenTrabajoBC().GuardarPorPerfil(cuentaUsuario, perfil);
        }

        private void GuardarCopiaUsuario(string cuentaUsuario, string usuarioCopia)
        {
            new OrdenTrabajoBC().GuardarPorUsuario(cuentaUsuario, usuarioCopia);
        }

        protected void ibGuardar_Click(object sender, ImageClickEventArgs e)
        {
            var cuentaUsuario = txtCuentaUsuario.Value.Trim();
            if (cuentaUsuario == string.Empty)
            {
                pnelConfiguracion.Visible = false;
                return;
            }
            Usuario usuario = GetUsuario(cuentaUsuario);

            if (usuario.UserName != null)
            {
                pnelConfiguracion.Visible = true;
                lblUsuarioNombre.Text = usuario.Nombre.ToUpper().Trim();

                if (rbCopiaPerfil.Checked && dlCopiaPerfil.SelectedValue.Trim() != "0")
                {
                    GuardarCopiaPerfil(usuario.UserName, dlCopiaPerfil.SelectedValue.Trim());
                }
                else if (rbCopiarUsuario.Checked && dlCopiaUsuario.SelectedValue.Trim() != "0")
                {
                    GuardarCopiaUsuario(usuario.UserName, dlCopiaUsuario.SelectedValue.Trim());
                }
                else if (rbCopiarPersonalizar.Checked && dlTipoBusqueda.SelectedValue.Trim() != "0")
                {
                    GuardarPersonalizado(usuario.UserName);
                }
                else
                {
                    FuncionGlobal.alerta("mmmm... al parecer falta seleccionar un dato", Page);
                    return;
                }

                GetPermisosEspeciales(usuario.UserName);
                GetActividades(usuario.UserName);
                GetGrupo(usuario.UserName);

                FuncionGlobal.alerta(string.Format("¡Bien hecho! El usuario {0} fué actualizado correctamente", usuario.Nombre.ToUpper()), Page);
            }
        }

        private void GuardarPersonalizado(string cuentaUsuario)
        {
            try
            {

                #region PERMISOS Y BUSQUEDAS 
                var tipoBusqueda = Convert.ToInt32(dlTipoBusqueda.SelectedValue);
                bool asignar = ckPermisoAsignar.Checked;
                bool eliminar = ckPermisoEliminar.Checked;
                bool garantia = ckPermisoGarantia.Checked;
                bool primera = ckPermisoPrimera.Checked;

                //AQUI GUARDA PERMISOS Y BUSQUEDA
                new OrdenTrabajoBC().AddBusquedaUsuario(cuentaUsuario, tipoBusqueda, eliminar, asignar, garantia, primera);
                #endregion

                #region ACTIVIDADES
                //ELIMINA-AGREGA-ACTUALIZA
                AddActividades(cuentaUsuario);

                #endregion

                #region GRUPOS
                AddGrupo(cuentaUsuario);
                #endregion
            }
            catch (Exception ex)
            {
                Mensajes("Rayos!, Se predujo el siguiente error: " + ex.Message, 3);
            }

        }

        private void AddActividades(string usuario)
        {
            try
            {
                GridViewRow row;

                for (int i = 0; i < grActividades.Rows.Count; i++)
                {

                    row = grActividades.Rows[i];
                    CheckBox chkActividadVer = (CheckBox)grActividades.Rows[i].FindControl("chkActividadVer");
                    CheckBox chkActividadLectura = (CheckBox)grActividades.Rows[i].FindControl("chkActividadLectura");
                    int idActividad = Convert.ToInt32(grActividades.DataKeys[i]["id_actividad_orden_trabajo"]);

                    if (chkActividadVer.Checked == true)
                    {
                        //AGREGA O ACTUALIZA
                        new OrdenTrabajoBC().GuardarActividadUsuario(usuario, idActividad, chkActividadLectura.Checked);
                    }
                    else
                    {
                        //ELIMINA
                        new OrdenTrabajoBC().DelActividadUsuario(usuario, idActividad);
                    }

                }
            }
            catch (Exception ex)
            {
                Mensajes("Rayos!, Se predujo el siguiente error: " + ex.Message, 3);
            }


        }


        private void AddGrupo(string usuario)
        {
            try
            {
                GridViewRow row;

                for (int i = 0; i < grGrupo.Rows.Count; i++)
                {
                    row = grActividades.Rows[i];
                    CheckBox chkjefe = (CheckBox)grGrupo.Rows[i].FindControl("chkJefe");
                    CheckBox chkobservador = (CheckBox)grGrupo.Rows[i].FindControl("chkObservador");
                    CheckBox chkActivo = (CheckBox)grGrupo.Rows[i].FindControl("chkActivo");
                    int codigoGrupo = Convert.ToInt32(grGrupo.DataKeys[i]["codigo_grupo"]);

                    //AGREGA O ACTUALIZA
                    new OrdenTrabajoBC().AddGrupoUsuario(usuario, codigoGrupo, chkjefe.Checked, chkobservador.Checked, chkActivo.Checked);

                }
            }
            catch (Exception ex)
            {
                Mensajes("Rayos!, Se predujo el siguiente error: " + ex.Message, 3);
            }

        }


    }
}