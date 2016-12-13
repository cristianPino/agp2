using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.analisis_vehiculo;

namespace sistemaAGP.OrdenTrabajo
{
    public partial class Inicio : Page
    {
        public string IMAGEN_ELIMINAR;
        public string IMAGEN_ASIGNAR;
        public string IMAGEN_ELIMINAR_NO_HABILITADO;
        public string IMAGEN_ASIGNAR_NO_HABILITADO;

        public string IMAGEN_GARANTIA;
        public string IMAGEN_FACTURA;
        public string IMAGEN_GARANTIA_NO_HABILITADO;
        public string IMAGEN_FACTURA_NO_HABILITADO;

        public bool PuedeAsignar;
        public bool PuedeEliminar;
        public bool IngresaGarantia;
        public bool IngresaFactura;

        public  Inicio()
        {
            IMAGEN_ELIMINAR = "~/imagenes/sistema/static/hipotecario/delete.png";
            IMAGEN_ASIGNAR = "~/imagenes/sistema/static/hipotecario/asignar.png";
            IMAGEN_ELIMINAR_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/delete_morado.png";
            IMAGEN_ASIGNAR_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/asignar_morado.png";

            IMAGEN_GARANTIA = "~/imagenes/sistema/static/hipotecario/new_celeste.png";
            IMAGEN_FACTURA = "~/imagenes/sistema/static/hipotecario/upload_celeste.png";
            IMAGEN_GARANTIA_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/new_oscuro.png";
            IMAGEN_FACTURA_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/upload-oscuro.png";

            PuedeAsignar = false;
            PuedeEliminar = false;
            IngresaGarantia = false;
            IngresaFactura = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            usuarioSesion.Value = Session["usrname"].ToString();
            LlenaGrafico();          
            FuncionGlobal.ComboActividadOrdenTrabajoByUsuario(dlActividad, usuarioSesion.Value);
            FuncionGlobal.ComboGruposUsuarios(dlGrupo, usuarioSesion.Value);
            FuncionGlobal.comboclientesbyusuario(Convert.ToString(Session["usrname"]),dlCliente);
            dlCliente.Items[0].Text = "Mi(s) cliente(es)";
            Permisos();
            txtDesde.Text = DateTime.Today.ToShortDateString();
            txtHasta.Text = DateTime.Today.ToShortDateString();
            Mensajes("Hola, este es tu panel de control.", 4);

        }

        private void Permisos()
        {
            var dt = new OrdenTrabajoBC().PermisosOrdenTrabajo(Convert.ToString(Session["usrname"]));

            if (dt.Rows.Count > 0)
            {
                PuedeAsignar = Convert.ToBoolean(dt.Rows[0]["permiso_asignar"]);
                PuedeEliminar = Convert.ToBoolean(dt.Rows[0]["permiso_eliminar"]);
                IngresaFactura = Convert.ToBoolean(dt.Rows[0]["permiso_masivo_factura"]);
                IngresaGarantia = Convert.ToBoolean(dt.Rows[0]["permiso_agregar_garantia"]);

                ibAsignar.Enabled = PuedeAsignar;
                ibBaja.Enabled = PuedeEliminar;
                link_garantia.HRef = IngresaGarantia ? "modal/IngresoGarantias.aspx" : "";
                link_factura.HRef = IngresaFactura ? "modal/Carga_factura.aspx" : "";
               
                ibAsignar.ImageUrl = PuedeAsignar ? IMAGEN_ASIGNAR : IMAGEN_ASIGNAR_NO_HABILITADO;
                ibBaja.ImageUrl = PuedeEliminar ? IMAGEN_ELIMINAR : IMAGEN_ELIMINAR_NO_HABILITADO;
                imgFactura.ImageUrl = IngresaFactura ? IMAGEN_FACTURA : IMAGEN_FACTURA_NO_HABILITADO;
                imgGarantia.ImageUrl = IngresaGarantia ? IMAGEN_GARANTIA : IMAGEN_GARANTIA_NO_HABILITADO;
            }
            else
            {
                ibAsignar.Enabled = false;
                ibBaja.Enabled = false;
                link_factura.HRef = string.Empty;
                link_garantia.HRef = string.Empty;
                ibAsignar.ImageUrl = IMAGEN_ASIGNAR_NO_HABILITADO;
                ibBaja.ImageUrl = IMAGEN_ELIMINAR_NO_HABILITADO;
                imgFactura.ImageUrl = IMAGEN_FACTURA_NO_HABILITADO;
                imgGarantia.ImageUrl = IMAGEN_GARANTIA_NO_HABILITADO;

            }
            

        }

        protected void ibAsignar_Click(object sender, ImageClickEventArgs e)
        {
            ComboboxAsignar();
            mpe_asignar.Show();
        }


        public void LlenaGrafico()
        {
            var dt = new OrdenTrabajoActividadLogBC().GetGrafico(usuarioSesion.Value);
            foreach (DataRow dtRow in dt.Rows)
            {
                double a1 = Convert.ToInt32(dtRow["ESPERANDO COMPLETAR FACTURA"].ToString().Trim());
                double a2 = Convert.ToInt32(dtRow["ESPERANDO ASIGNACION"].ToString().Trim());
                double a3 = Convert.ToInt32(dtRow["ESPERANDO INGRESO AGP"].ToString().Trim());
                double a4 = Convert.ToInt32(dtRow["INGRESADA"].ToString().Trim());
                double a5 = Convert.ToInt32(dtRow["CON REPARO"].ToString().Trim());
                double a6 = Convert.ToInt32(dtRow["DE BAJA"].ToString().Trim());
                double total = a1 + a2 + a3 + a4 + a5 + a6;

                lblTotalOp.Text = total.ToString(CultureInfo.InvariantCulture);
                lblEsperaFactura.Text = a1.ToString(CultureInfo.InvariantCulture);
                lblAsignacion.Text = a2.ToString(CultureInfo.InvariantCulture);
                lblIngreso.Text = a3.ToString(CultureInfo.InvariantCulture);
                lblIngresadas.Text = a4.ToString(CultureInfo.InvariantCulture);
                lblReparo.Text = a5.ToString(CultureInfo.InvariantCulture);
                lblBaja.Text = a6.ToString(CultureInfo.InvariantCulture);

                lblEsperaFacturaprom.Text = Math.Round(((a1 / total) * 100), 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblAsignacionprom.Text = Math.Round(((a2 / total * 100)), 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblIngresoprom.Text = Math.Round(((a3 / total * 100)), 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblIngresadasprom.Text = Math.Round(((a4 / total * 100)), 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblReparoProm.Text = Math.Round(((a5 / total * 100)), 2).ToString(CultureInfo.InvariantCulture) + "%";
                lblBajaprom.Text = Math.Round(((a6 / total * 100)), 2).ToString(CultureInfo.InvariantCulture) + "%";

            }
        }

        public DataTable GetOperaciones(string numeroOt)
        {
            var dt = new DataTable();
            try
            {
               
                var lista = new OrdenTrabajoActividadLogBC().GetOrdenTrabajoLogbyUsuario(new OrdenTrabajoActividadLog()
                                                                                            {
                                                                                                Usuario = new Usuario { UserName = Session["usrname"].ToString() },
                                                                                                OrdenTrabajo = new CENTIDAD.OrdenTrabajo { NumeroOrden = numeroOt },
                                                                                                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = Convert.ToInt32(dlActividad.SelectedValue) }
                                                                                            }, 
                                                        (string.Format("{0:yyyyMMdd}",
                                                        Convert.ToDateTime(txtDesde.Text.Trim()))),
                                                        (string.Format("{0:yyyyMMdd}",
                                                        Convert.ToDateTime(txtHasta.Text.Trim()))),
                                                        dlUsuario.SelectedValue.Trim() == string.Empty? "0" : dlUsuario.SelectedValue.Trim() ,
                                                        dlGrupo.SelectedValue.Trim(),
                                                        Convert.ToInt32(dlCliente.SelectedValue)
                                                        );


                dt.TableName = "ordenes";
                dt.Columns.Add(new DataColumn("avanza"));
                dt.Columns.Add(new DataColumn("idOrden"));
                dt.Columns.Add(new DataColumn("urlHitos"));
                dt.Columns.Add(new DataColumn("urlCarpeta"));
                dt.Columns.Add(new DataColumn("numeroOrden"));
                dt.Columns.Add(new DataColumn("numeroFactura"));
                dt.Columns.Add(new DataColumn("forma_pago"));
                dt.Columns.Add(new DataColumn("sucursal"));
                dt.Columns.Add(new DataColumn("cliente"));
                dt.Columns.Add(new DataColumn("ejecutivoIngreso"));
                dt.Columns.Add(new DataColumn("cuenta_usuario_ingreso"));
                dt.Columns.Add(new DataColumn("fechaIngreso"));
                dt.Columns.Add(new DataColumn("idActividad"));
                dt.Columns.Add(new DataColumn("nombreActividad"));
                dt.Columns.Add(new DataColumn("urlActividades"));
                dt.Columns.Add(new DataColumn("horasActividad"));
                dt.Columns.Add(new DataColumn("semaforo")); 
                dt.Columns.Add(new DataColumn("sla"));
                dt.Columns.Add(new DataColumn("urlSemaforo"));
                dt.Columns.Add(new DataColumn("urlTareas"));
                dt.Columns.Add(new DataColumn("fechaInicio"));
                dt.Columns.Add(new DataColumn("idFlujo"));
                dt.Columns.Add(new DataColumn("usuarioActual"));
                dt.Columns.Add(new DataColumn("urlSupervisor"));
                dt.Columns.Add(new DataColumn("id_solicitud"));
                dt.Columns.Add(new DataColumn("estado_agp"));
                dt.Columns.Add(new DataColumn("patente"));
                dt.Columns.Add(new DataColumn("usuario_ejecutivo"));
                var columns = new DataColumn[1];
                //columns[0] = dt.Columns["idOrden"];
                //dt.PrimaryKey = columns;
               

                foreach (var ot in lista)
                {
                    var IdOrdenTrabajoActividadLogEncriptado = FuncionGlobal.FuctionEncriptar(ot.IdOrdenTrabajoActividadLog.ToString());
                    var IdOrdenEncriptado= FuncionGlobal.FuctionEncriptar(ot.OrdenTrabajo.IdOrden.ToString(CultureInfo.InvariantCulture));
                    var dr = dt.NewRow();

                    dr["idFlujo"] = ot.IdOrdenTrabajoActividadLog;
                    dr["id_solicitud"] = ot.OrdenTrabajo.IdSolicitud;
                    dr["numeroFactura"] = ot.OrdenTrabajo.NumeroFactura;
                    dr["forma_pago"] = ot.OrdenTrabajo.FormaPago;
                    if (ot.OrdenTrabajo.IdSolicitud != 0)
                    {
                        var estadoAgp = new EstadooperacionBC().getUltimoEstadoByIdoperacion(ot.OrdenTrabajo.IdSolicitud);
                        dr["nombreActividad"] = ot.ActividadDeOrdenTrabajo.Descripcion + " - "+ estadoAgp.Estado_operacion.Descripcion.ToUpper();
                        dr["estado_agp"] = estadoAgp.Estado_operacion.Descripcion.ToUpper();
                    }
                    else
                    {
                        dr["nombreActividad"] = ot.ActividadDeOrdenTrabajo.Descripcion;
                        dr["estado_agp"] = "SIN ESTADO";
                    }
                    dr["idOrden"] = ot.OrdenTrabajo.IdOrden;
                    dr["cliente"] = ot.OrdenTrabajo.ClienteNombre.ToUpper().Trim();
                    dr["idActividad"] = ot.ActividadDeOrdenTrabajo.IdActividad;
                    dr["urlCarpeta"] = "~/digitalizacion/documentos.aspx?idOrdenTrabajo=" + IdOrdenEncriptado;
                    dr["numeroOrden"] = ot.OrdenTrabajo.NumeroOrden + "  " + ot.OrdenTrabajo.VinCorto;

                    string usuarioSucursal = string.Empty;
                    if (ot.OrdenTrabajo.IdSucursal != 0)
                    {
                        var dtUsuario = new OrdenTrabajoBC().GetUsuariosBySucursal(ot.OrdenTrabajo.IdSucursal);

                        if (dtUsuario.Rows.Count > 0)
                        {
                            usuarioSucursal = Convert.ToString(dtUsuario.Rows[0]["nombre"]).ToUpper().Trim();
                        }
                    }

                    dr["usuario_ejecutivo"] = usuarioSucursal == string.Empty? "Sin definir": usuarioSucursal;
                    //dr["sucursal"] = ot.OrdenTrabajo.SucursalNombre.ToUpper().Trim();
                   
                    //dr["sucursal"] = "Sin info.";
                    dr["ejecutivoIngreso"] = ot.OrdenTrabajo.UsuarioIngresoNombre.ToUpper().Trim();
                    dr["cuenta_usuario_ingreso"] = ot.OrdenTrabajo.UsuarioIngresoCuenta.Trim();
                    dr["sla"] = ot.ActividadDeOrdenTrabajo.Sla;
                    dr["fechaIngreso"] = ot.OrdenTrabajo.FechaIngreso;
                    dr["patente"] = ot.OrdenTrabajo.Patente.ToUpper();

                    dr["urlActividades"] = "dato";
                    dr["horasActividad"] = ot.HorasActividad;
                    dr["fechaInicio"] = ot.FechaInicio;
                    dr["usuarioActual"] = ot.UsuarioActualNombre.ToUpper().Trim();
                    var horas = ot.HorasActividad;
                    var sla = ot.ActividadDeOrdenTrabajo.Sla;

                    if (horas < (sla / 2))
                    {
                        dr["semaforo"] = "~/imagenes/sistema/static/verde.png";

                    }
                    else if (horas >= (sla / 2) && horas < sla)
                    {
                        dr["semaforo"] = "~/imagenes/sistema/static/amarillo.png";

                    }
                    else if (horas >= sla)
                    {
                        dr["semaforo"] = "~/imagenes/sistema/static/rojo.png";
                    }
                    // si la actividad es ingresada no tiene Sla y semaforo es verde.
                    if (ot.ActividadDeOrdenTrabajo.IdActividad == 4) //4 = operacion ingresada
                    {
                        dr["sla"] = 0;
                        dr["horasActividad"] = 0;
                        dr["semaforo"] = "~/imagenes/sistema/static/hipotecario/finish.jpg";
                    }


                    dr["urlSemaforo"] = "modal/Flujo.aspx" + "?idOrdenTrabajoActividad=" + IdOrdenTrabajoActividadLogEncriptado;
                    dr["urlTareas"] = ot.ActividadDeOrdenTrabajo.Url.Trim() + "?idOrdenTrabajoActividad=" + IdOrdenTrabajoActividadLogEncriptado;
                    dr["urlTareas"] = dr["urlTareas"] + "&id_orden_trabajo=" + IdOrdenEncriptado;
                    var avanza =
                        new OrdenTrabajoActividadLogBC().GetOrdenTrabajoAnterior(new OrdenTrabajoActividadLog { OrdenTrabajo = new CENTIDAD.OrdenTrabajo { IdOrden = ot.OrdenTrabajo.IdOrden } }).Avanza;

                    //dr["avanza"] = avanza == 2 ? "../imagenes/sistema/static/urgente.png" : "";
                    //var dd =
                    //new OrdenTrabajoRevisionBC().GetOrdenTrabajoRevision(new OrdenTrabajoRevision { IdOrdenTrabajo = ot.OrdenTrabajo.IdOrden });
                    //if (dd.IntentosRevision <= 0 && dd.IdOrdenTrabajo != 0)
                    //{
                    //    dr["avanza"] = "~/imagenes/sistema/static/hipotecario/soloLecturaGrande.png";
                    //    if (PuedeAsignar)
                    //    {
                    //        dr["urlSupervisor"] = "modal/Supervision.aspx?idOrdenTrabajo=" + FuncionGlobal.FuctionEncriptar(ot.OrdenTrabajo.IdOrden.ToString(CultureInfo.InvariantCulture)); ;
                    //    }
                    //}

                    //var listas = new OrdenTrabajoBC().GetordenTrabajoProducto(ot.OrdenTrabajo.IdOrden);
                    //var listaOk = from x in new OrdenTrabajoBC().GetordenTrabajoProducto(ot.OrdenTrabajo.IdOrden) where x.Ok select x;

                    //var final = listaOk as List<OrdenTrabajoTipoOperacion> ?? listaOk.ToList();
                    //var listaFinal = final.Count() == 1 ? final : listas;
                    //var todoOk = listaFinal.Count(otr => otr.Ok);


                    //if (todoOk > 0 && ot.ActividadDeOrdenTrabajo.IdActividad == 3)
                    //{
                    //    TerminarOrdenTrabajo(ot.OrdenTrabajo.IdOrden);
                    //}
                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                Mensajes(ex.Message, 3);
            }
            return dt;
        }

        public void TerminarOrdenTrabajo(int idOrden)
        {
            new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
            {
                OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                {
                    CuentaUsuario = Session["usrname"].ToString()
                    ,
                    IdOrden = idOrden
                },
                ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 4 }, //4treminada
                Avanza = 1,
                IdOrdenTrabajoActividadLog = 0
            });
        }


        public void LlenaGrid(DataTable dt)
        {
            gr_dato.DataSource = dt;
            gr_dato.DataBind();

        }




        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var check = (CheckBox)e.Row.FindControl("chk");
                var codigoActividad = Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());
                if (codigoActividad == 4 || codigoActividad == 5)
                {
                    check.Checked = false;
                    check.Visible = false;
                }
            }
        }


        public int Asignar()
        {
            var correctas = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var id = Convert.ToInt32(gr_dato.DataKeys[i].Values["idOrden"]);
                var idOtLog = Convert.ToInt32(gr_dato.DataKeys[i].Values["idFlujo"]);
                var usuarioDestino = Convert.ToString(gr_dato.DataKeys[i].Values["cuenta_usuario_ingreso"]);

                if (!chk.Checked) continue;
                new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                {
                    OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                    {
                        CuentaUsuario = dlUsuarios.SelectedValue
                        ,
                        IdOrden = Convert.ToInt32(id)
                    },
                    ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 3 },
                    Avanza = 1,
                    IdOrdenTrabajoActividadLog = idOtLog
                });

                NuevoMensaje(txtComentarioAccion.Value.Trim(), id, usuarioDestino);
                correctas++;
            }
            return correctas;
        }


        public void NuevoMensaje(string comentario, int idOrdenTrabajo, string usuarioDestino)
        {
            var mensaje = new MensajeOrdenTrabajo
            {
                Mensaje = comentario,
                IdOrdenTrabajo = idOrdenTrabajo,
                IdUsuario = Convert.ToString(Session["usrname"])
            };
            try
            {
                var idMensaje = new MensajeOrdenTrabajoBC().AddMensaje(mensaje);
                new MensajeOrdenTrabajoBC().AddMensajeaDestinatarios(idMensaje, usuarioDestino, "NO");
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta(ex.Message, Page);
            }

        }        


        public int Eliminar()
        {
            var correctas = 0;
            for (var i = 0; i < gr_dato.Rows.Count; i++)
            {
                var chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                var id = Convert.ToInt32(gr_dato.DataKeys[i].Values["idOrden"]);
                var idOtLog = Convert.ToInt32(gr_dato.DataKeys[i].Values["idFlujo"]);
                var usuarioDestino = Convert.ToString(gr_dato.DataKeys[i].Values["cuenta_usuario_ingreso"]);


                if (!chk.Checked) continue;
                new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
                {
                    OrdenTrabajo = new CENTIDAD.OrdenTrabajo
                    {
                        CuentaUsuario = Convert.ToString(Session["usrname"])
                        ,
                        IdOrden = Convert.ToInt32(id)
                    },
                    ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 5 },
                    Avanza = 1,
                    IdOrdenTrabajoActividadLog = idOtLog
                });

                NuevoMensaje(txtBajaComentario.Value.Trim(), id, usuarioDestino);
                correctas++;
            }
            return correctas;
        }

        public void ComboboxAsignar()
        {
            FuncionGlobal.ComboUsuariosByActividad(dlUsuarios, 3, 1);
        }

        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(upd, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            var op = txtBuscar.Value.Trim() == "" ? "0" : txtBuscar.Value.Trim();
            var dt = GetOperaciones(op);
            LlenaGrid(dt);
            LlenaGrafico();
            Mensajes($"Se han encontrado {dt.Rows.Count} filas", 1 );
        }


        protected void btnPruebaAg_Click(object sender, EventArgs e)
        {
            //    AddOrdenTrabajo(1);
        }

        //public void AddOrdenTrabajo(int siguienteActividad)
        //{
        //    //metodo prueba el insert asicronico desde el webservice //borrar en produccion
        //  var id =  new OrdenTrabajoBC().AddOrdenTrabajoWebservice(new CENTIDAD.OrdenTrabajo
        //        {
        //            Activo = true,
        //            VinCorto = "179578",
        //            CuentaUsuario = "wsag",
        //            NumeroOrden = txtPruebaAg.Text.Trim(),
        //            NumeroFactura = "12000",
        //            RutAdquiriente = "17000000" ,
        //            DvAdquiriente = "7",
        //            NombreAdquiriente = "Juanito"    ,
        //            ApematAdquiriente = "Soto",
        //            ApepatAdquiriente = "Perez",
        //            FacturaNeto = "1000",
        //            FechaFactura = "2015/05/03",
        //            VehiculoModelo = "Vesta 5",
        //            VehiculoAnio = "2014",
        //            VehiculoMarca = "144",
        //            VehiculoCilindrada = "25666",
        //            VehiculoPuertas = 4,
        //            VehiculoAsientos = 5,
        //            VehiculoPesoBruto = 2500,
        //            VehiculoCarga = 200,
        //            VehiculoCombustible = "BEN",
        //            VehiculoColor = "Rojo"  ,
        //            VehiculoMotor = "XDDDSDFDSFDF" ,
        //            VehiculoVin = "fdfff",
        //            VehiculoChasis = "ddddd",
        //            UrlFactura = @"http://pruebaswindte1412.acepta.com/v01/DEBFB26FD8D6D69019C1987064656BE7911642AE?k=5675eac53d0fd037674c93757d8ec5fd"  


        //        });

        //    if(id<0)
        //    {
        //        Mensajes("No existe coincidencia",3);
        //        return;
        //    }

        //    var lista = new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = 1 } });
        //    var siguienteUsuario = "";
        //    foreach (var usu in lista)
        //    {
        //        siguienteUsuario = usu.Usuario.UserName;
        //    }

        //    var logExiste =
        //        new OrdenTrabajoActividadLogBC().GetLastOrdenTrabajoLogbyid(new OrdenTrabajoActividadLog { OrdenTrabajo = new CENTIDAD.OrdenTrabajo { IdOrden = id } });


        //    if (logExiste.IdOrdenTrabajoActividadLog != 0)
        //    {
        //        siguienteActividad = siguienteActividad + 1;  
        //    }
        //    else
        //    {
        //        siguienteUsuario = "wsag";
        //    }

        //    new OrdenTrabajoActividadLogBC().AddOrdenTrabajoLog(new OrdenTrabajoActividadLog
        //    {
        //        OrdenTrabajo = new CENTIDAD.OrdenTrabajo
        //        {
        //            CuentaUsuario = siguienteUsuario
        //            ,
        //            IdOrden = id
        //        },
        //        ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = siguienteActividad },
        //        Avanza = 1,
        //        IdOrdenTrabajoActividadLog = 0
        //    });

        //    Mensajes("Nueva solicitud ingresada", 1);


        //}

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



        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            var op = txtBuscar.Value.Trim() == "" ? "0" : txtBuscar.Value.Trim();
            var dt = GetOperaciones(op);

            if (dt == null)
            {
                FuncionGlobal.alerta_updatepanel("Debe hacer una busqueda anteriormente para exportar.", Page, upd);
                return;
            }
            //creo el informe y obtengo su nombre
            var informe = new MatrizExcelBC().GetReportePreticket(Session["usrname"].ToString(), dt);

            //llamo al informe para ser abierto o guardado.
            var strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + informe.Trim() + "');";
            ScriptManager.RegisterStartupScript(this.upd, upd.GetType(), "", strAlerta, true);


        }

        protected void bt_dar_baja_Click(object sender, EventArgs e)
        {
            var eliminados = Eliminar();

            gr_dato.DataSource = null;
            gr_dato.DataBind();
            LlenaGrafico();

            Mensajes("Se han eliminado " + eliminados + " Ordenes de pedido.", 1);
        }

        protected void bt_asignar_Click(object sender, EventArgs e)
        {
            if (dlUsuarios.SelectedValue == "0")
            {
                Mensajes("Hey!, Selecciona un usuario", 3);
                return;
            }
            var asignadas = Asignar();     
                  
            gr_dato.DataSource = null;
            gr_dato.DataBind();
            LlenaGrafico();

            Mensajes("Se han asignado " + asignadas + " Ordenes de pedido a " + dlUsuarios.SelectedItem.Text.ToUpper(), 1);
        }

        protected void ibBaja_Click(object sender, ImageClickEventArgs e)
        {
            mpe_baja.Show();
        }

        protected void dlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlGrupo.SelectedValue != "-1")
            {

                if (dlGrupo.SelectedItem.Text.ToLower().Contains("jefe"))
                {
                    //TODOS LOS USUARIOS QUE NO SON JEFES DEL GRUPO
                    FuncionGlobal.ComboUsuariosGrupo(dlUsuario, jefe: false, todo: false, grupo: Convert.ToString(dlGrupo.SelectedValue),cuentaUsuario:Convert.ToString(Session["usrname"]));
                }
                else if (dlGrupo.SelectedValue == "0")
                {
                    //TODOS LOS USUARIOS DE TODOS LOS GRUPOS
                    FuncionGlobal.ComboUsuariosGrupo(dlUsuario, jefe: false, todo: true, grupo: Convert.ToString(dlGrupo.SelectedValue), cuentaUsuario: Convert.ToString(Session["usrname"]));
                }
                else if (dlGrupo.SelectedValue != "0" && !dlGrupo.SelectedItem.Text.ToLower().Contains("jefe"))
                {
                    //SOLO EL MISMO USUARIO
                    FuncionGlobal.ComboUsuariosGrupo(dlUsuario, jefe: false, todo: false, grupo: Convert.ToString(dlGrupo.SelectedValue), cuentaUsuario: Convert.ToString(Session["usrname"]));
                }        
            }
            
        }
    }
}