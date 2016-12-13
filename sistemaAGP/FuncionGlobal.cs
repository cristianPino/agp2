using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Script;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.WSPeru;

namespace sistemaAGP {

    public static class Constantes 
    {
        public const string IMAGEN_ASIGNAR = "~/imagenes/sistema/static/hipotecario/asignar.png";
        public const string IMAGEN_CAMBIO_ESTADO = "~/imagenes/sistema/static/hipotecario/workflow.png";
        public const string IMAGEN_ELIMINAR_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/delete_morado.png";
        public const string IMAGEN_ASIGNAR_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/asignar_morado.png";
        public const string IMAGEN_CAMBIO_ESTADO_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/workflow_morado.png";
        public const string IMAGEN_COMENTARIO = "~/imagenes/sistema/static/hipotecario/note.png";
        public const string IMAGEN_COMENTARIO_NO_HABILITADO = "~/imagenes/sistema/static/hipotecario/note_morado.png";
        public const string IMAGEN_SEMAFORO_VERDE = "~/imagenes/sistema/static/verde.png";
        public const string IMAGEN_SEMAFORO_ROJO = "~/imagenes/sistema/static/rojo.png";
        public const string IMAGEN_SEMAFORO_AMARILLO = "~/imagenes/sistema/static/amarillo.png";
        public const string IMAGEN_BIENVENIDO = "~/imagenes/sistema/static/bienvenido.png";
        public const string IMAGEN_BANDERA_FINISH = "~/imagenes/sistema/static/hipotecario/finish.jpg";
        public const string IMAGEN_KEY_HABILITAR_ACTIVO = @"~/imagenes/sistema/static/hipotecario/key.png";
        public const string IMAGEN_KEY_HABILITAR_DESACTIVO = @"~/imagenes/sistema/static/hipotecario/key_morado.png";
        public const string IMAGEN_CONTRATO_ACTIVO = @"~/imagenes/sistema/static/hipotecario/contrato_blanco.png";
        public const string IMAGEN_CONTRATO_DESACTIVO = @"~/imagenes/sistema/static/hipotecario/contrato_negro.png";
        public const string IMAGEN_INGRESO_ACTIVO = @"~/imagenes/sistema/static/hipotecario/nube_blanca_34.png";
        public const string IMAGEN_INGRESO_DESACTIVO = @"~/imagenes/sistema/static/hipotecario/nube_negra_34.png";
        public const string IMAGEN_SUBIR_DOCUMENTO_ACTIVO = @"~/imagenes/sistema/static/hipotecario/upload_doc_azul_32.png";
        public const string IMAGEN_SUBIR_DOCUMENTO_DESACTIVO = @"~/imagenes/sistema/static/hipotecario/upload_doc_gris_32.png";
        public const string IMAGEN_ELIMINAR_DOCUMENTO_ACTIVO_ROJO = @"~/imagenes/sistema/static/hipotecario/delete_doc_rojo_32.png";
        public const string IMAGEN_ELIMINAR_DOCUMENTO_ACTIVO_AZUL = @"~/imagenes/sistema/static/hipotecario/delete_doc_azul_32.png";
        public const string IMAGEN_ELIMINAR_DOCUMENTO_DESACTIVO = @"~/imagenes/sistema/static/hipotecario/delete_doc_gris_32.png";

        public const string SP_RESUMEN_INGRESADOR = "get_resumen_incidencia_ingresador";
        public const string SP_RESUMEN_EJECUTIVO = "get_resumen_incidencia_ejecutivo";
        public const string SP_RESUMEN_SUPERVISOR = "get_resumen_incidencia_supervisor";
    }

    public static class Enums
    {
        public enum TiposMensajes
        {
            Error,
            Correcto,
            Informacion,
            Bienvenido
        }
        public enum TipoAcciones
        {
            Eliminar,
            CambiarEstado,
            CambiarProducto
        }

        public enum TipoVistaResumen
        {
            Ingresador = 1,
            Ejecutivo = 2,
            Supervisor = 3
        }

        public enum TipoCliente
        {
            BICE = 14,
            BK = 58,
            PORCHE = 89
        }

    }


	public static class FuncionGlobal {

        public static string SaludosHorario()
        {
            Int32 hora = DateTime.Now.Hour;
            if (hora < 12)
            {
                return "Buenos días";
            }
            if (hora < 19)
            {
                return "Buenas Tardes";
            }
            if (hora < 24)
            {
                return "Buenas Noches";
            }
            return "Hola";
        }

        public static void BienesByNumeroCliente(DropDownList combobox, string numero_cliente, string tipo_operacion)
        {


            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));

            combobox.DataSource = new BienesNumeroClienteBC().GetBienesByNumeroCliente(numero_cliente, tipo_operacion);
            combobox.DataValueField = "bien";
            combobox.DataTextField = "detalle";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

        public static void ComboFormaPago(DropDownList combobox, string tipoparametro)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Forma de pago", "0"));

            //solo credito y contado
            IOrderedEnumerable<Parametro> lParametro = from p in new ParametroBC().GetParametroByTipoParametro(tipoparametro)
                                                       where p.Codigoparametro == "1" || p.Codigoparametro == "2"
                                                       orderby p.Orden ascending
                                                       select p;


            combobox.DataSource = lParametro;
            combobox.DataValueField = "codigoparametro";
            combobox.DataTextField = "valoralfanumerico";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void ComboUsuariosbyGrupo(DropDownList combobox, string grupo)
        {   //nuevo combo clientes que pueden comprar certiicados
            var dt = new DataTable();
            dt.Columns.Add("cuenta_usuario");
            dt.Columns.Add("nombre");
            var dr = dt.NewRow();
            dr["cuenta_usuario"] = 0;
            dr["nombre"] = "Usuarios...";
            dt.Rows.Add(dr);


            DataTable dtDatos = new OrdenTrabajoBC().GetUsuariosByGrupos(grupo);
            foreach (DataRow x in dtDatos.Rows)
            {
                dr = dt.NewRow();
                dr["nombre"] = Convert.ToString(x["nombre"]).ToUpper();
                dr["cuenta_usuario"] = Convert.ToString(x["cuenta_usuario"]);
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "nombre";
            combobox.DataValueField = "cuenta_usuario";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void ComboUsuariosGrupo(DropDownList combobox, bool jefe, bool todo, string grupo, string cuentaUsuario)
        {   //nuevo combo clientes que pueden comprar certiicados
            var dt = new DataTable();
            dt.Columns.Add("value");
            dt.Columns.Add("text");
            var dr = dt.NewRow();


            DataTable dtDatos = new OrdenTrabajoBC().GetUsuariosGrupos(jefe, todo, grupo, cuentaUsuario);

            if (dtDatos.Rows.Count > 0)
            {
                dr["value"] = 0;
                dr["text"] = "Todos los usuarios";
                dt.Rows.Add(dr);
            }
            else
            {
                dr["value"] = 0;
                dr["text"] = "Sin usuarios";
                dt.Rows.Add(dr);
            }

            foreach (DataRow x in dtDatos.Rows)
            {
                dr = dt.NewRow();
                dr["value"] = Convert.ToString(x["cuenta_usuario"]);
                dr["text"] = Convert.ToString(x["nombre"]);
                dt.Rows.Add(dr);
            }

            combobox.DataSource = dt;
            combobox.DataTextField = "text";
            combobox.DataValueField = "value";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void ComboGruposUsuarios(DropDownList combobox, string cuentaUsuario)
        {
            var tabla = new OrdenTrabajoBC().GetGrupoByUsuario(cuentaUsuario);
            var dr = tabla.NewRow();

            if (tabla.Rows.Count > 0)
            {
                dr["CodigoParametro"] = 0;
                dr["ValorAlfanumerico"] = "Mis grupos";
                tabla.Rows.Add(dr);

                combobox.DataSource = tabla;
                combobox.DataTextField = "ValorAlfanumerico";
                combobox.DataValueField = "CodigoParametro";
                combobox.DataBind();
                combobox.SelectedValue = "0";
            }
            else
            {
                dr["CodigoParametro"] = -1;
                dr["ValorAlfanumerico"] = "No tengo grupo";
                tabla.Rows.Add(dr);

                combobox.DataSource = tabla;
                combobox.DataTextField = "ValorAlfanumerico";
                combobox.DataValueField = "CodigoParametro";
                combobox.DataBind();
                combobox.SelectedIndex = 0;
            }


        }


        public static int ConvierteTextoANumero(string palabra)
        {   //Cpino 23/12/2015
            //Toma una cadena de caracteres y devuelve solo el valor númerico que traiga 
            try
            {
                return Convert.ToInt32(Regex.Replace(palabra, @"[^0-9]", string.Empty));
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public static string DevuelveSoloLetras(string palabra)
        {   //Cpino 23/12/2015
            //Toma una cadena de caracteres y devuelve solo el valor númerico que traiga 
            try
            {
                return Convert.ToString(Regex.Replace(palabra, @"[^a-zA-Z \-]|(  )|(\-\-)|(^\s*$)", string.Empty));
            }
            catch (Exception)
            {

                return String.Empty;
            }

        }

        public static void ComboUsuarioGrupo(DropDownList combobox, bool jefe, string usuario)
        {   //nuevo combo clientes que pueden comprar certiicados
            var dt = new DataTable();
            dt.Columns.Add("value");
            dt.Columns.Add("text");
            var dr = dt.NewRow();
            dr["value"] = 0;
            dr["text"] = "Seleccionar";
            dt.Rows.Add(dr);

            DataTable dtDatos = new IncidenciaBC().GetIncidenciasUsuariosPorGrupo(jefe, usuario);
            foreach (DataRow x in dtDatos.Rows)
            {
                dr = dt.NewRow();
                dr["value"] = Convert.ToString(x["cuenta_usuario"]);
                dr["text"] = Convert.ToString(x["nombre"]) + " CARGA: " + Convert.ToString(x["carga"]);
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "text";
            combobox.DataValueField = "value";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void ComboEstadosIncidencia(DropDownList combobox, string tipo )
        {   //nuevo combo clientes que pueden comprar certiicados
            var dt = new DataTable();
            dt.Columns.Add("value");
            dt.Columns.Add("text");
            var dr = dt.NewRow();
            dr["value"] = 0;
            dr["text"] = "Todos los estados";
            dt.Rows.Add(dr);
            DataTable dtDatos = new DataTable();
            switch (tipo.Trim().ToLowerInvariant())
            {
                case "todo":
                    dtDatos = new IncidenciaBC().GetIncidenciasEstado();
                    break;
                case "manual":
                    var resManu = from r in new IncidenciaBC().GetIncidenciasEstado().AsEnumerable() where r.Field<bool>("manual") == true select r;
                    dtDatos = resManu.CopyToDataTable<DataRow>();
                    break;
                case "automatico":
                    var resAutom = from r in new IncidenciaBC().GetIncidenciasEstado().AsEnumerable() where r.Field<bool>("manual") == false select r;
                    dtDatos = resAutom.CopyToDataTable<DataRow>();
                    break;
                default:
                    dtDatos = new IncidenciaBC().GetIncidenciasEstado();
                    break;
            }


            foreach (DataRow x in dtDatos.Rows)
            {
                dr = dt.NewRow();
                dr["value"] = Convert.ToString(x["id_estado"]);
                dr["text"] = Convert.ToString(x["descripcion"]);
                dt.Rows.Add(dr);
            }

            combobox.DataSource = dt;
            combobox.DataTextField = "text";
            combobox.DataValueField = "value";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void CombosucursalbyclienteCombobox(DropDownList combobox, Int16 idCliente)
        {
            SucursalCliente msucursal = new SucursalCliente();
            msucursal.Id_sucursal = 0;
            msucursal.Nombre = "Seleccionar";
            List<SucursalCliente> lsucursal = new SucursalclienteBC().GetSucursalbyclienteCombobox(idCliente);
            lsucursal.Add(msucursal);
            combobox.DataSource = lsucursal;
            combobox.DataValueField = "id_sucursal";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }




        public static void ComboChecklist(DropDownList combobox, int tipo)
        {   //nuevo combo clientes que pueden comprar certiicados
            var dt = new DataTable();
            dt.Columns.Add("idcheckilist");
            dt.Columns.Add("descripcion");
            var dr = dt.NewRow();
            dr["idcheckilist"] = 0;
            dr["descripcion"] = "Documentos";
            dt.Rows.Add(dr);

            var lista = new ChecklistBC().GetCecklistbyTipo(tipo);
            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["idcheckilist"] = Convert.ToInt32(x.IdChecklist);
                dr["descripcion"] = x.Descripcion;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "descripcion";
            combobox.DataValueField = "idcheckilist";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }


        public static void ComboClientesCertificados(DropDownList combobox)
        {   //nuevo combo clientes que pueden comprar certiicados
            var dt = new DataTable();
            dt.Columns.Add("Id_solicitud");
            dt.Columns.Add("Propietario_nombre");
            var dr = dt.NewRow();
            dr["Id_solicitud"] = 0;
            dr["Propietario_nombre"] = "Seleccionar";
            dt.Rows.Add(dr);

            var lista = new InfoAutoBC().GetClienteCertificados();
            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["Id_solicitud"] = Convert.ToInt32(x.Id_solicitud);
                dr["Propietario_nombre"] = x.Propietario_nombre;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "Propietario_nombre";
            combobox.DataValueField = "Id_solicitud";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        //nuevo 01/10/2014 cpino
        public static void ComboFamilia(DropDownList combobox)
        {
            var f = new Familia_Producto();
            f.Id_familia = 0;
            f.Descripcion = "Seleccionar";
            var lista = new Familia_productoBC().getallFamilia_producto();
            lista.Add(f);
            combobox.DataSource = lista;
            combobox.DataValueField = "id_familia";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void combonominabyfamiliafactura(DropDownList combobox, int id_familia)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));
            combobox.DataSource = from n in new TipoNominaBC().getTipoNominaByIdFamiliafactura(id_familia)
                                  orderby n.Descripcion ascending
                                  select n;
            combobox.DataValueField = "id_nomina";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

        public static void Combogasto(DropDownList combobox, Int16 id_fam)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccion", "0"));
            combobox.DataSource = from e in new GastosComunesBC().getallGastosComunes(id_fam)
                                  orderby e.Id_familia

                                  select new
                                  {
                                      codigo_estado = e.Id_familia,
                                      descripcion = e.Descripcion.ToUpper().Trim()
                                  };
            combobox.DataValueField = "codigo_estado";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

        public static void combousuariobyperfil(DropDownList combobox, string codigoperfil)
        {
            Usuario musuario = new Usuario();
            musuario.UserName = "0";
            musuario.Nombre = "Seleccionar";
            List<Usuario> lusuario = new UsuarioBC().getusuariobyperfil(codigoperfil);
            lusuario.Add(musuario);
            combobox.DataSource = lusuario;
            combobox.DataValueField = "userName";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

		public static void combotipoformapago(DropDownList combobox)
		{
			combobox.Items.Clear();
			ListItem item = new ListItem("Seleccionar", "0");
			item.Selected = true;
			combobox.Items.Add(item);
			foreach (TipoFormaPago fp in new TipoFormaPagoBC().GetTipoFormaPagoTodos())
				combobox.Items.Add(new ListItem(fp.Descripcion, fp.Id_FormaPago.ToString()));
		}

		public static void combotipoclasificacionvehicular(DropDownList combobox)
		{
			combobox.Items.Clear();
			ListItem item = new ListItem("Seleccionar", "0");
			item.Selected = true;
			combobox.Items.Add(item);
			foreach (TipoClasificacionVehicular cls in new TipoClasificacionVehicularBC().GetTipoClasificacionVehicularTodas())
				combobox.Items.Add(new ListItem(cls.Descripcion, cls.Id_categoria.ToString()));
		}

		public static void combotipomoneda(DropDownList combobox)
		{
			combobox.Items.Clear();
			ListItem item = new ListItem("Seleccionar", "0");
			item.Selected = true;
			combobox.Items.Add(item);
			foreach (TipoMoneda mon in new TipoMonedaBC().GetTipoMonedaTodas())
				combobox.Items.Add(new ListItem(mon.Nombre, mon.Cod_moneda));
		}

		public static void combotipomonedasimbolo(DropDownList combobox)
		{
			combobox.Items.Clear();
			ListItem item = new ListItem("Seleccionar", "0");
			item.Selected = true;
			combobox.Items.Add(item);
			foreach (TipoMoneda mon in new TipoMonedaBC().GetTipoMonedaTodas())
				combobox.Items.Add(new ListItem(mon.Simbolo, mon.Cod_moneda));
		}

        public static string NumeroConFormato(string value)
        {
            return Convert.ToInt64(value.Replace(".", "")).ToString("#,##0", System.Globalization.CultureInfo.CreateSpecificCulture("es-CL"));
        }

        public static string NumeroSinFormato(string value)
        {
            return value.Replace(".", "");
        }

		public static void comboTipoSolicitudRC(DropDownList combobox, string tipo_operacion)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("codigo");
			dt.Columns.Add("descripcion");
			DataRow dr = dt.NewRow();
			dr["codigo"] = 0;
			dr["descripcion"] = "Seleccionar";
			dt.Rows.Add(dr);
			//List<TipoSolicitudRCProducto> lsolic = new TipoSolicitudRCBC().getTipoSolicitudRC_by_TipoOperacion(tipo_operacion);
			List<TipoSolicitudRCProducto> lsolic = new TipoSolicitudRCProductoBC().getTipoSolicitudRC_by_TipoOperacion(tipo_operacion);
			foreach (TipoSolicitudRCProducto msolic in lsolic)
			{
				dr = dt.NewRow();
				dr["codigo"] = msolic.CodSolicRC;
				dr["descripcion"] = msolic.DescSolicRC;
				dt.Rows.Add(dr);
			}
			combobox.DataSource = dt;
			combobox.DataTextField = "descripcion";
			combobox.DataValueField = "codigo";
			combobox.DataBind();
			combobox.SelectedValue = "0";
		}

		public static void comboOficinaRC(DropDownList combobox, int id_region)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("codigo");
			dt.Columns.Add("descripcion");
			DataRow dr = dt.NewRow();
			dr["codigo"] = 0;
			dr["descripcion"] = "Seleccionar";
			dt.Rows.Add(dr);
			List<OficinaRC> loficinas = new OficinaRCBC().get_OficinasRC(id_region);
			foreach (OficinaRC moficina in loficinas)
			{
				dr = dt.NewRow();
				dr["codigo"] = moficina.Codigo_oficina_rc;
				dr["descripcion"] = moficina.Descripcion_oficina_rc;
				dt.Rows.Add(dr);
			}
			combobox.DataSource = dt;
			combobox.DataTextField = "descripcion";
			combobox.DataValueField = "codigo";
			combobox.DataBind();
			combobox.SelectedValue = "0";
		}

		public static bool formatoPatente(string patente) {
            string pattern = @"^[a-zA-Z]{2}[0-9]{4}|[b-dB-D,f-hF-H,j-lJ-L,pP,r-tR-T,v-zV-Z]{4}[0-9]{2}|[b-dB-D,f-hF-H,j-lJ-L,pP,r-tR-T,v-zV-Z]{3}[0-9]{3}$";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(patente);
			return match.Success;
		}

		public static string digitoVerificadorPatente(string patente) {
			string rut = "";
			char[] ppu = patente.ToUpper().ToCharArray();
			if (!formatoPatente(patente)) return "";
			if ((65 <= ppu[0] && ppu[0] <= 90) &&
				(65 <= ppu[1] && ppu[1] <= 90) &&
				(48 <= ppu[2] && ppu[2] <= 57) &&
				(48 <= ppu[3] && ppu[3] <= 57) &&
				(48 <= ppu[4] && ppu[4] <= 57) &&
				(48 <= ppu[5] && ppu[5] <= 57)) {
				rut = "";
				switch (patente.ToUpper().Substring(0, 2)) {
					case "AA": rut = "1" + patente.Substring(2, 4); break;
					case "BA": rut = "2" + patente.Substring(2, 4); break;
					case "CA": rut = "3" + patente.Substring(2, 4); break;
					case "EA": rut = "4" + patente.Substring(2, 4); break;
					case "FA": rut = "5" + patente.Substring(2, 4); break;
					case "GA": rut = "6" + patente.Substring(2, 4); break;
					case "HA": rut = "7" + patente.Substring(2, 4); break;
					case "AB": rut = "8" + patente.Substring(2, 4); break;
					case "CB": rut = "9" + patente.Substring(2, 4); break;
					case "EB": rut = "10" + patente.Substring(2, 4); break;
					case "FB": rut = "11" + patente.Substring(2, 4); break;
					case "GB": rut = "12" + patente.Substring(2, 4); break;
					case "HB": rut = "13" + patente.Substring(2, 4); break;
					case "AC": rut = "14" + patente.Substring(2, 4); break;
					case "BC": rut = "15" + patente.Substring(2, 4); break;
					case "EC": rut = "16" + patente.Substring(2, 4); break;
					case "FC": rut = "17" + patente.Substring(2, 4); break;
					case "GC": rut = "18" + patente.Substring(2, 4); break;
					case "HC": rut = "19" + patente.Substring(2, 4); break;
					case "BD": rut = "20" + patente.Substring(2, 4); break;
					case "ED": rut = "21" + patente.Substring(2, 4); break;
					case "FD": rut = "22" + patente.Substring(2, 4); break;
					case "GD": rut = "23" + patente.Substring(2, 4); break;
					case "HD": rut = "24" + patente.Substring(2, 4); break;
					case "AE": rut = "25" + patente.Substring(2, 4); break;
					case "BE": rut = "26" + patente.Substring(2, 4); break;
					case "CE": rut = "27" + patente.Substring(2, 4); break;
					case "EE": rut = "28" + patente.Substring(2, 4); break;
					case "FE": rut = "29" + patente.Substring(2, 4); break;
					case "GE": rut = "30" + patente.Substring(2, 4); break;
					case "HE": rut = "31" + patente.Substring(2, 4); break;
					case "AF": rut = "32" + patente.Substring(2, 4); break;
					case "BF": rut = "33" + patente.Substring(2, 4); break;
					case "CF": rut = "34" + patente.Substring(2, 4); break;
					case "EF": rut = "35" + patente.Substring(2, 4); break;
					case "FF": rut = "36" + patente.Substring(2, 4); break;
					case "GF": rut = "37" + patente.Substring(2, 4); break;
					case "HF": rut = "38" + patente.Substring(2, 4); break;
					case "AG": rut = "39" + patente.Substring(2, 4); break;
					case "BG": rut = "40" + patente.Substring(2, 4); break;
					case "CG": rut = "41" + patente.Substring(2, 4); break;
					case "EG": rut = "42" + patente.Substring(2, 4); break;
					case "FG": rut = "43" + patente.Substring(2, 4); break;
					case "HG": rut = "44" + patente.Substring(2, 4); break;
					case "AH": rut = "45" + patente.Substring(2, 4); break;
					case "BH": rut = "46" + patente.Substring(2, 4); break;
					case "CH": rut = "47" + patente.Substring(2, 4); break;
					case "EH": rut = "48" + patente.Substring(2, 4); break;
					case "FH": rut = "49" + patente.Substring(2, 4); break;
					case "GH": rut = "50" + patente.Substring(2, 4); break;
					case "HH": rut = "51" + patente.Substring(2, 4); break;
					case "AJ": rut = "52" + patente.Substring(2, 4); break;
					case "BJ": rut = "53" + patente.Substring(2, 4); break;
					case "CJ": rut = "54" + patente.Substring(2, 4); break;
					case "EJ": rut = "55" + patente.Substring(2, 4); break;
					case "FJ": rut = "56" + patente.Substring(2, 4); break;
					case "GJ": rut = "57" + patente.Substring(2, 4); break;
					case "HJ": rut = "58" + patente.Substring(2, 4); break;
					case "BK": rut = "59" + patente.Substring(2, 4); break;
					case "CK": rut = "60" + patente.Substring(2, 4); break;
					case "EK": rut = "61" + patente.Substring(2, 4); break;
					case "FK": rut = "62" + patente.Substring(2, 4); break;
					case "GK": rut = "63" + patente.Substring(2, 4); break;
					case "HK": rut = "64" + patente.Substring(2, 4); break;
					case "AL": rut = "65" + patente.Substring(2, 4); break;
					case "BL": rut = "66" + patente.Substring(2, 4); break;
					case "CL": rut = "67" + patente.Substring(2, 4); break;
					case "EL": rut = "68" + patente.Substring(2, 4); break;
					case "FL": rut = "69" + patente.Substring(2, 4); break;
					case "GL": rut = "70" + patente.Substring(2, 4); break;
					case "HL": rut = "71" + patente.Substring(2, 4); break;
					case "AN": rut = "72" + patente.Substring(2, 4); break;
					case "BN": rut = "73" + patente.Substring(2, 4); break;
					case "CN": rut = "74" + patente.Substring(2, 4); break;
					case "EN": rut = "75" + patente.Substring(2, 4); break;
					case "FN": rut = "76" + patente.Substring(2, 4); break;
					case "GN": rut = "77" + patente.Substring(2, 4); break;
					case "HN": rut = "78" + patente.Substring(2, 4); break;
					case "AP": rut = "79" + patente.Substring(2, 4); break;
					case "BP": rut = "80" + patente.Substring(2, 4); break;
					case "CP": rut = "81" + patente.Substring(2, 4); break;
					case "EP": rut = "82" + patente.Substring(2, 4); break;
					case "FP": rut = "83" + patente.Substring(2, 4); break;
					case "GP": rut = "84" + patente.Substring(2, 4); break;
					case "HP": rut = "85" + patente.Substring(2, 4); break;
					case "AR": rut = "86" + patente.Substring(2, 4); break;
					case "BR": rut = "87" + patente.Substring(2, 4); break;
					case "CR": rut = "88" + patente.Substring(2, 4); break;
					case "ER": rut = "89" + patente.Substring(2, 4); break;
					case "FR": rut = "90" + patente.Substring(2, 4); break;
					case "GR": rut = "91" + patente.Substring(2, 4); break;
					case "HR": rut = "92" + patente.Substring(2, 4); break;
					case "AS": rut = "93" + patente.Substring(2, 4); break;
					case "BS": rut = "94" + patente.Substring(2, 4); break;
					case "CS": rut = "95" + patente.Substring(2, 4); break;
					case "ES": rut = "96" + patente.Substring(2, 4); break;
					case "FS": rut = "97" + patente.Substring(2, 4); break;
					case "GS": rut = "98" + patente.Substring(2, 4); break;
					case "HS": rut = "99" + patente.Substring(2, 4); break;
					case "AT": rut = "100" + patente.Substring(2, 4); break;
					case "BT": rut = "101" + patente.Substring(2, 4); break;
					case "CT": rut = "102" + patente.Substring(2, 4); break;
					case "ET": rut = "103" + patente.Substring(2, 4); break;
					case "FT": rut = "104" + patente.Substring(2, 4); break;
					case "GT": rut = "105" + patente.Substring(2, 4); break;
					case "HT": rut = "106" + patente.Substring(2, 4); break;
					case "AU": rut = "107" + patente.Substring(2, 4); break;
					case "BU": rut = "108" + patente.Substring(2, 4); break;
					case "CU": rut = "109" + patente.Substring(2, 4); break;
					case "EU": rut = "110" + patente.Substring(2, 4); break;
					case "FU": rut = "111" + patente.Substring(2, 4); break;
					case "GU": rut = "112" + patente.Substring(2, 4); break;
					case "HU": rut = "113" + patente.Substring(2, 4); break;
					case "AV": rut = "114" + patente.Substring(2, 4); break;
					case "BV": rut = "115" + patente.Substring(2, 4); break;
					case "CV": rut = "116" + patente.Substring(2, 4); break;
					case "EV": rut = "117" + patente.Substring(2, 4); break;
					case "FV": rut = "118" + patente.Substring(2, 4); break;
					case "GV": rut = "119" + patente.Substring(2, 4); break;
					case "HV": rut = "120" + patente.Substring(2, 4); break;
					case "AX": rut = "121" + patente.Substring(2, 4); break;
					case "BX": rut = "122" + patente.Substring(2, 4); break;
					case "CX": rut = "123" + patente.Substring(2, 4); break;
					case "EX": rut = "124" + patente.Substring(2, 4); break;
					case "FX": rut = "125" + patente.Substring(2, 4); break;
					case "GX": rut = "126" + patente.Substring(2, 4); break;
					case "HX": rut = "127" + patente.Substring(2, 4); break;
					case "BY": rut = "128" + patente.Substring(2, 4); break;
					case "CY": rut = "129" + patente.Substring(2, 4); break;
					case "EY": rut = "130" + patente.Substring(2, 4); break;
					case "FY": rut = "131" + patente.Substring(2, 4); break;
					case "GY": rut = "132" + patente.Substring(2, 4); break;
					case "HY": rut = "133" + patente.Substring(2, 4); break;
					case "AZ": rut = "134" + patente.Substring(2, 4); break;
					case "BZ": rut = "135" + patente.Substring(2, 4); break;
					case "CZ": rut = "136" + patente.Substring(2, 4); break;
					case "EZ": rut = "137" + patente.Substring(2, 4); break;
					case "FZ": rut = "138" + patente.Substring(2, 4); break;
					case "GZ": rut = "139" + patente.Substring(2, 4); break;
					case "DA": rut = "140" + patente.Substring(2, 4); break;
					case "DB": rut = "141" + patente.Substring(2, 4); break;
					case "DD": rut = "142" + patente.Substring(2, 4); break;
					case "DE": rut = "143" + patente.Substring(2, 4); break;
					case "DF": rut = "144" + patente.Substring(2, 4); break;
					case "DG": rut = "145" + patente.Substring(2, 4); break;
					case "DH": rut = "146" + patente.Substring(2, 4); break;
					case "DI": rut = "147" + patente.Substring(2, 4); break;
					case "DJ": rut = "148" + patente.Substring(2, 4); break;
					case "DK": rut = "149" + patente.Substring(2, 4); break;
					case "DL": rut = "150" + patente.Substring(2, 4); break;
					case "DN": rut = "151" + patente.Substring(2, 4); break;
					case "DP": rut = "152" + patente.Substring(2, 4); break;
					case "DR": rut = "153" + patente.Substring(2, 4); break;
					case "DS": rut = "154" + patente.Substring(2, 4); break;
					case "DT": rut = "155" + patente.Substring(2, 4); break;
					case "DU": rut = "156" + patente.Substring(2, 4); break;
					case "DV": rut = "157" + patente.Substring(2, 4); break;
					case "DX": rut = "158" + patente.Substring(2, 4); break;
					case "DY": rut = "159" + patente.Substring(2, 4); break;
					case "DZ": rut = "160" + patente.Substring(2, 4); break;
					case "KA": rut = "161" + patente.Substring(2, 4); break;
					case "KB": rut = "162" + patente.Substring(2, 4); break;
					case "KC": rut = "163" + patente.Substring(2, 4); break;
					case "KD": rut = "164" + patente.Substring(2, 4); break;
					case "KE": rut = "165" + patente.Substring(2, 4); break;
					case "KF": rut = "166" + patente.Substring(2, 4); break;
					case "KG": rut = "167" + patente.Substring(2, 4); break;
					case "KH": rut = "168" + patente.Substring(2, 4); break;
					case "KJ": rut = "169" + patente.Substring(2, 4); break;
					case "KK": rut = "170" + patente.Substring(2, 4); break;
					case "KL": rut = "171" + patente.Substring(2, 4); break;
					case "KN": rut = "172" + patente.Substring(2, 4); break;
					case "KP": rut = "173" + patente.Substring(2, 4); break;
					case "KR": rut = "174" + patente.Substring(2, 4); break;
					case "KS": rut = "175" + patente.Substring(2, 4); break;
					case "KT": rut = "176" + patente.Substring(2, 4); break;
					case "KU": rut = "177" + patente.Substring(2, 4); break;
					case "KV": rut = "178" + patente.Substring(2, 4); break;
					case "KX": rut = "179" + patente.Substring(2, 4); break;
					case "KY": rut = "180" + patente.Substring(2, 4); break;
					case "KZ": rut = "181" + patente.Substring(2, 4); break;
					case "LA": rut = "182" + patente.Substring(2, 4); break;
					case "LB": rut = "183" + patente.Substring(2, 4); break;
					case "LC": rut = "184" + patente.Substring(2, 4); break;
					case "LD": rut = "185" + patente.Substring(2, 4); break;
					case "LE": rut = "186" + patente.Substring(2, 4); break;
					case "LF": rut = "187" + patente.Substring(2, 4); break;
					case "LG": rut = "188" + patente.Substring(2, 4); break;
					case "LH": rut = "189" + patente.Substring(2, 4); break;
					case "LJ": rut = "190" + patente.Substring(2, 4); break;
					case "LK": rut = "191" + patente.Substring(2, 4); break;
					case "LL": rut = "192" + patente.Substring(2, 4); break;
					case "LN": rut = "193" + patente.Substring(2, 4); break;
					case "LP": rut = "194" + patente.Substring(2, 4); break;
					case "LR": rut = "195" + patente.Substring(2, 4); break;
					case "LS": rut = "196" + patente.Substring(2, 4); break;
					case "LT": rut = "197" + patente.Substring(2, 4); break;
					case "LU": rut = "198" + patente.Substring(2, 4); break;
					case "LV": rut = "199" + patente.Substring(2, 4); break;
					case "LX": rut = "200" + patente.Substring(2, 4); break;
					case "LY": rut = "201" + patente.Substring(2, 4); break;
					case "LZ": rut = "202" + patente.Substring(2, 4); break;
					case "NA": rut = "203" + patente.Substring(2, 4); break;
					case "NB": rut = "204" + patente.Substring(2, 4); break;
					case "NC": rut = "205" + patente.Substring(2, 4); break;
					case "ND": rut = "206" + patente.Substring(2, 4); break;
					case "NE": rut = "207" + patente.Substring(2, 4); break;
					case "NF": rut = "208" + patente.Substring(2, 4); break;
					case "NG": rut = "209" + patente.Substring(2, 4); break;
					case "NH": rut = "210" + patente.Substring(2, 4); break;
					case "NJ": rut = "211" + patente.Substring(2, 4); break;
					case "NK": rut = "212" + patente.Substring(2, 4); break;
					case "NL": rut = "213" + patente.Substring(2, 4); break;
					case "NN": rut = "214" + patente.Substring(2, 4); break;
					case "NP": rut = "215" + patente.Substring(2, 4); break;
					case "NR": rut = "216" + patente.Substring(2, 4); break;
					case "NS": rut = "217" + patente.Substring(2, 4); break;
					case "NT": rut = "218" + patente.Substring(2, 4); break;
					case "NU": rut = "219" + patente.Substring(2, 4); break;
					case "NV": rut = "220" + patente.Substring(2, 4); break;
					case "NY": rut = "221" + patente.Substring(2, 4); break;
					case "NZ": rut = "222" + patente.Substring(2, 4); break;
					case "PA": rut = "223" + patente.Substring(2, 4); break;
					case "PB": rut = "224" + patente.Substring(2, 4); break;
					case "PC": rut = "225" + patente.Substring(2, 4); break;
					case "PD": rut = "226" + patente.Substring(2, 4); break;
					case "PE": rut = "227" + patente.Substring(2, 4); break;
					case "PF": rut = "228" + patente.Substring(2, 4); break;
					case "PG": rut = "229" + patente.Substring(2, 4); break;
					case "PH": rut = "230" + patente.Substring(2, 4); break;
					case "PJ": rut = "231" + patente.Substring(2, 4); break;
					case "PK": rut = "232" + patente.Substring(2, 4); break;
					case "PL": rut = "233" + patente.Substring(2, 4); break;
					case "PN": rut = "234" + patente.Substring(2, 4); break;
					case "PP": rut = "235" + patente.Substring(2, 4); break;
					case "PS": rut = "236" + patente.Substring(2, 4); break;
					case "PT": rut = "237" + patente.Substring(2, 4); break;
					case "PU": rut = "238" + patente.Substring(2, 4); break;
					case "PV": rut = "239" + patente.Substring(2, 4); break;
					case "PX": rut = "240" + patente.Substring(2, 4); break;
					case "PY": rut = "241" + patente.Substring(2, 4); break;
					case "PZ": rut = "242" + patente.Substring(2, 4); break;
					case "NX": rut = "243" + patente.Substring(2, 4); break;
					case "RA": rut = "244" + patente.Substring(2, 4); break;
					case "RB": rut = "245" + patente.Substring(2, 4); break;
					case "RC": rut = "246" + patente.Substring(2, 4); break;
					case "RD": rut = "247" + patente.Substring(2, 4); break;
					case "RE": rut = "248" + patente.Substring(2, 4); break;
					case "RF": rut = "249" + patente.Substring(2, 4); break;
					case "RG": rut = "250" + patente.Substring(2, 4); break;
					case "RH": rut = "251" + patente.Substring(2, 4); break;
					case "RJ": rut = "252" + patente.Substring(2, 4); break;
					case "RK": rut = "253" + patente.Substring(2, 4); break;
					case "RL": rut = "254" + patente.Substring(2, 4); break;
					case "RN": rut = "255" + patente.Substring(2, 4); break;
					case "RP": rut = "256" + patente.Substring(2, 4); break;
					case "RR": rut = "257" + patente.Substring(2, 4); break;
					case "RS": rut = "258" + patente.Substring(2, 4); break;
					case "RT": rut = "259" + patente.Substring(2, 4); break;
					case "RU": rut = "260" + patente.Substring(2, 4); break;
					case "RV": rut = "261" + patente.Substring(2, 4); break;
					case "RX": rut = "262" + patente.Substring(2, 4); break;
					case "RY": rut = "263" + patente.Substring(2, 4); break;
					case "RZ": rut = "264" + patente.Substring(2, 4); break;
					case "HZ": rut = "265" + patente.Substring(2, 4); break;
					case "SA": rut = "266" + patente.Substring(2, 4); break;
					case "SB": rut = "267" + patente.Substring(2, 4); break;
					case "SC": rut = "268" + patente.Substring(2, 4); break;
					case "SD": rut = "269" + patente.Substring(2, 4); break;
					case "SE": rut = "270" + patente.Substring(2, 4); break;
					case "SF": rut = "271" + patente.Substring(2, 4); break;
					case "SG": rut = "272" + patente.Substring(2, 4); break;
					case "SH": rut = "273" + patente.Substring(2, 4); break;
					case "SJ": rut = "274" + patente.Substring(2, 4); break;
					case "SK": rut = "275" + patente.Substring(2, 4); break;
					case "SL": rut = "276" + patente.Substring(2, 4); break;
					case "SN": rut = "277" + patente.Substring(2, 4); break;
					case "SP": rut = "278" + patente.Substring(2, 4); break;
					case "SR": rut = "279" + patente.Substring(2, 4); break;
					case "SS": rut = "280" + patente.Substring(2, 4); break;
					case "ST": rut = "281" + patente.Substring(2, 4); break;
					case "SU": rut = "282" + patente.Substring(2, 4); break;
					case "SV": rut = "283" + patente.Substring(2, 4); break;
					case "SX": rut = "284" + patente.Substring(2, 4); break;
					case "SY": rut = "285" + patente.Substring(2, 4); break;
					case "SZ": rut = "286" + patente.Substring(2, 4); break;
					case "TA": rut = "287" + patente.Substring(2, 4); break;
					case "TB": rut = "288" + patente.Substring(2, 4); break;
					case "TC": rut = "289" + patente.Substring(2, 4); break;
					case "TD": rut = "290" + patente.Substring(2, 4); break;
					case "TE": rut = "291" + patente.Substring(2, 4); break;
					case "TF": rut = "292" + patente.Substring(2, 4); break;
					case "TG": rut = "293" + patente.Substring(2, 4); break;
					case "TH": rut = "294" + patente.Substring(2, 4); break;
					case "TJ": rut = "295" + patente.Substring(2, 4); break;
					case "TK": rut = "296" + patente.Substring(2, 4); break;
					case "TL": rut = "297" + patente.Substring(2, 4); break;
					case "TN": rut = "298" + patente.Substring(2, 4); break;
					case "TP": rut = "299" + patente.Substring(2, 4); break;
					case "TR": rut = "300" + patente.Substring(2, 4); break;
					case "TS": rut = "301" + patente.Substring(2, 4); break;
					case "TT": rut = "302" + patente.Substring(2, 4); break;
					case "TU": rut = "303" + patente.Substring(2, 4); break;
					case "TV": rut = "304" + patente.Substring(2, 4); break;
					case "TX": rut = "305" + patente.Substring(2, 4); break;
					case "TY": rut = "306" + patente.Substring(2, 4); break;
					case "TZ": rut = "307" + patente.Substring(2, 4); break;
					case "UA": rut = "308" + patente.Substring(2, 4); break;
					case "UB": rut = "309" + patente.Substring(2, 4); break;
					case "UC": rut = "310" + patente.Substring(2, 4); break;
					case "UD": rut = "311" + patente.Substring(2, 4); break;
					case "UE": rut = "312" + patente.Substring(2, 4); break;
					case "UF": rut = "313" + patente.Substring(2, 4); break;
					case "UG": rut = "314" + patente.Substring(2, 4); break;
					case "UH": rut = "315" + patente.Substring(2, 4); break;
					case "UJ": rut = "316" + patente.Substring(2, 4); break;
					case "UK": rut = "317" + patente.Substring(2, 4); break;
					case "UL": rut = "318" + patente.Substring(2, 4); break;
					case "UN": rut = "319" + patente.Substring(2, 4); break;
					case "UP": rut = "320" + patente.Substring(2, 4); break;
					case "UR": rut = "321" + patente.Substring(2, 4); break;
					case "US": rut = "322" + patente.Substring(2, 4); break;
					case "UT": rut = "323" + patente.Substring(2, 4); break;
					case "UU": rut = "324" + patente.Substring(2, 4); break;
					case "UV": rut = "325" + patente.Substring(2, 4); break;
					case "UX": rut = "326" + patente.Substring(2, 4); break;
					case "UY": rut = "327" + patente.Substring(2, 4); break;
					case "UZ": rut = "328" + patente.Substring(2, 4); break;
					case "VA": rut = "329" + patente.Substring(2, 4); break;
					case "VB": rut = "330" + patente.Substring(2, 4); break;
					case "VC": rut = "331" + patente.Substring(2, 4); break;
					case "VD": rut = "332" + patente.Substring(2, 4); break;
					case "VE": rut = "333" + patente.Substring(2, 4); break;
					case "VF": rut = "334" + patente.Substring(2, 4); break;
					case "VG": rut = "335" + patente.Substring(2, 4); break;
					case "VH": rut = "336" + patente.Substring(2, 4); break;
					case "VJ": rut = "337" + patente.Substring(2, 4); break;
					case "VK": rut = "338" + patente.Substring(2, 4); break;
					case "VL": rut = "339" + patente.Substring(2, 4); break;
					case "VN": rut = "340" + patente.Substring(2, 4); break;
					case "VP": rut = "341" + patente.Substring(2, 4); break;
					case "VR": rut = "342" + patente.Substring(2, 4); break;
					case "VS": rut = "343" + patente.Substring(2, 4); break;
					case "VT": rut = "344" + patente.Substring(2, 4); break;
					case "VU": rut = "345" + patente.Substring(2, 4); break;
					case "VV": rut = "346" + patente.Substring(2, 4); break;
					case "VX": rut = "347" + patente.Substring(2, 4); break;
					case "VY": rut = "348" + patente.Substring(2, 4); break;
					case "VZ": rut = "349" + patente.Substring(2, 4); break;
					case "XA": rut = "350" + patente.Substring(2, 4); break;
					case "XB": rut = "351" + patente.Substring(2, 4); break;
					case "XC": rut = "352" + patente.Substring(2, 4); break;
					case "XD": rut = "353" + patente.Substring(2, 4); break;
					case "XE": rut = "354" + patente.Substring(2, 4); break;
					case "XF": rut = "355" + patente.Substring(2, 4); break;
					case "XG": rut = "356" + patente.Substring(2, 4); break;
					case "XH": rut = "357" + patente.Substring(2, 4); break;
					case "XJ": rut = "358" + patente.Substring(2, 4); break;
					case "XK": rut = "359" + patente.Substring(2, 4); break;
					case "XL": rut = "360" + patente.Substring(2, 4); break;
					case "XM": rut = "361" + patente.Substring(2, 4); break;
					case "XN": rut = "362" + patente.Substring(2, 4); break;
					case "XP": rut = "363" + patente.Substring(2, 4); break;
					case "XQ": rut = "364" + patente.Substring(2, 4); break;
					case "XR": rut = "365" + patente.Substring(2, 4); break;
					case "XS": rut = "366" + patente.Substring(2, 4); break;
					case "XT": rut = "367" + patente.Substring(2, 4); break;
					case "XU": rut = "368" + patente.Substring(2, 4); break;
					case "XV": rut = "369" + patente.Substring(2, 4); break;
					case "XX": rut = "370" + patente.Substring(2, 4); break;
					case "XY": rut = "371" + patente.Substring(2, 4); break;
					case "XZ": rut = "372" + patente.Substring(2, 4); break;
					case "YA": rut = "373" + patente.Substring(2, 4); break;
					case "YB": rut = "374" + patente.Substring(2, 4); break;
					case "JA": rut = "375" + patente.Substring(2, 4); break;
					case "JB": rut = "376" + patente.Substring(2, 4); break;
					case "JC": rut = "377" + patente.Substring(2, 4); break;
					case "JD": rut = "378" + patente.Substring(2, 4); break;
					case "JE": rut = "379" + patente.Substring(2, 4); break;
					case "YC": rut = "380" + patente.Substring(2, 4); break;
					case "YD": rut = "381" + patente.Substring(2, 4); break;
					case "YE": rut = "382" + patente.Substring(2, 4); break;
					case "YF": rut = "383" + patente.Substring(2, 4); break;
					case "YG": rut = "384" + patente.Substring(2, 4); break;
					case "YH": rut = "385" + patente.Substring(2, 4); break;
					case "YJ": rut = "386" + patente.Substring(2, 4); break;
					case "YK": rut = "387" + patente.Substring(2, 4); break;
					case "YL": rut = "388" + patente.Substring(2, 4); break;
					case "YN": rut = "389" + patente.Substring(2, 4); break;
					case "YP": rut = "390" + patente.Substring(2, 4); break;
					case "YR": rut = "391" + patente.Substring(2, 4); break;
					case "YS": rut = "392" + patente.Substring(2, 4); break;
					case "YT": rut = "393" + patente.Substring(2, 4); break;
					case "YU": rut = "394" + patente.Substring(2, 4); break;
					case "YV": rut = "395" + patente.Substring(2, 4); break;
					case "YX": rut = "396" + patente.Substring(2, 4); break;
					case "YY": rut = "397" + patente.Substring(2, 4); break;
					case "YZ": rut = "398" + patente.Substring(2, 4); break;
					case "ZA": rut = "399" + patente.Substring(2, 4); break;
					case "ZB": rut = "400" + patente.Substring(2, 4); break;
					case "ZC": rut = "401" + patente.Substring(2, 4); break;
					case "ZD": rut = "402" + patente.Substring(2, 4); break;
					case "ZE": rut = "403" + patente.Substring(2, 4); break;
					case "ZF": rut = "404" + patente.Substring(2, 4); break;
					case "ZG": rut = "405" + patente.Substring(2, 4); break;
					case "ZH": rut = "406" + patente.Substring(2, 4); break;
					case "ZI": rut = "407" + patente.Substring(2, 4); break;
					case "ZJ": rut = "408" + patente.Substring(2, 4); break;
					case "ZK": rut = "409" + patente.Substring(2, 4); break;
					case "ZL": rut = "410" + patente.Substring(2, 4); break;
					case "JF": rut = "411" + patente.Substring(2, 4); break;
					case "JG": rut = "412" + patente.Substring(2, 4); break;
					case "JH": rut = "413" + patente.Substring(2, 4); break;
					case "ZN": rut = "414" + patente.Substring(2, 4); break;
					case "ZP": rut = "415" + patente.Substring(2, 4); break;
					case "ZR": rut = "416" + patente.Substring(2, 4); break;
					case "ZS": rut = "417" + patente.Substring(2, 4); break;
					case "ZT": rut = "418" + patente.Substring(2, 4); break;
					case "ZU": rut = "419" + patente.Substring(2, 4); break;
					case "ZV": rut = "420" + patente.Substring(2, 4); break;
					case "ZX": rut = "421" + patente.Substring(2, 4); break;
					case "ZY": rut = "422" + patente.Substring(2, 4); break;
					case "ZZ": rut = "423" + patente.Substring(2, 4); break;
					case "JL": rut = "424" + patente.Substring(2, 4); break;
					case "JN": rut = "425" + patente.Substring(2, 4); break;
					case "JO": rut = "426" + patente.Substring(2, 4); break;
					case "JP": rut = "427" + patente.Substring(2, 4); break;
					case "JR": rut = "428" + patente.Substring(2, 4); break;
					case "JS": rut = "429" + patente.Substring(2, 4); break;
					case "WA": rut = "430" + patente.Substring(2, 4); break;
					case "WB": rut = "431" + patente.Substring(2, 4); break;
					case "WC": rut = "432" + patente.Substring(2, 4); break;
					case "WD": rut = "433" + patente.Substring(2, 4); break;
					case "WE": rut = "434" + patente.Substring(2, 4); break;
					case "WF": rut = "435" + patente.Substring(2, 4); break;
					case "WG": rut = "436" + patente.Substring(2, 4); break;
					case "WH": rut = "437" + patente.Substring(2, 4); break;
					case "WJ": rut = "438" + patente.Substring(2, 4); break;
					case "WK": rut = "439" + patente.Substring(2, 4); break;
					case "WL": rut = "440" + patente.Substring(2, 4); break;
					case "WN": rut = "441" + patente.Substring(2, 4); break;
					case "WP": rut = "442" + patente.Substring(2, 4); break;
					case "WR": rut = "443" + patente.Substring(2, 4); break;
					case "WS": rut = "444" + patente.Substring(2, 4); break;
					case "WT": rut = "445" + patente.Substring(2, 4); break;
					case "WU": rut = "446" + patente.Substring(2, 4); break;
					case "JJ": rut = "447" + patente.Substring(2, 4); break;
					case "JK": rut = "448" + patente.Substring(2, 4); break;
					case "WV": rut = "449" + patente.Substring(2, 4); break;
					case "WW": rut = "450" + patente.Substring(2, 4); break;
					case "WX": rut = "451" + patente.Substring(2, 4); break;
					case "WY": rut = "452" + patente.Substring(2, 4); break;
					case "WZ": rut = "453" + patente.Substring(2, 4); break;
					case "ZW": rut = "454" + patente.Substring(2, 4); break;
					case "YW": rut = "455" + patente.Substring(2, 4); break;
					case "XW": rut = "456" + patente.Substring(2, 4); break;
					case "UW": rut = "457" + patente.Substring(2, 4); break;
					case "TW": rut = "458" + patente.Substring(2, 4); break;
					case "SW": rut = "459" + patente.Substring(2, 4); break;
					case "RW": rut = "460" + patente.Substring(2, 4); break;
					case "PW": rut = "461" + patente.Substring(2, 4); break;
					case "NW": rut = "462" + patente.Substring(2, 4); break;
					case "LW": rut = "463" + patente.Substring(2, 4); break;
					case "KW": rut = "464" + patente.Substring(2, 4); break;
					case "MZ": rut = "465" + patente.Substring(2, 4); break;
					case "MY": rut = "466" + patente.Substring(2, 4); break;
					case "MX": rut = "467" + patente.Substring(2, 4); break;
					case "MV": rut = "468" + patente.Substring(2, 4); break;
					case "MU": rut = "469" + patente.Substring(2, 4); break;
					case "MT": rut = "470" + patente.Substring(2, 4); break;
					case "MS": rut = "471" + patente.Substring(2, 4); break;
					case "JT": rut = "472" + patente.Substring(2, 4); break;
					case "JU": rut = "473" + patente.Substring(2, 4); break;
					case "JV": rut = "474" + patente.Substring(2, 4); break;
					case "JW": rut = "475" + patente.Substring(2, 4); break;
					case "JX": rut = "476" + patente.Substring(2, 4); break;
					case "JY": rut = "477" + patente.Substring(2, 4); break;
					case "JZ": rut = "478" + patente.Substring(2, 4); break;
					default: rut += ""; break;
				}
			} 
            else if ((65 <= ppu[0] && ppu[0] <= 90) &&
				(65 <= ppu[1] && ppu[1] <= 90) &&
				(65 <= ppu[2] && ppu[2] <= 90) &&
				(48 <= ppu[3] && ppu[3] <= 90) &&
				(48 <= ppu[4] && ppu[4] <= 57) &&
				(48 <= ppu[5] && ppu[5] <= 57)) {
				rut = "";
				for (int i = 0; i < 4; i++) {
					switch (patente.ToUpper().Substring(i, 1)) {
						case "B": rut += "1"; break;
						case "C": rut += "2"; break;
						case "D": rut += "3"; break;
						case "F": rut += "4"; break;
						case "G": rut += "5"; break;
						case "H": rut += "6"; break;
						case "J": rut += "7"; break;
						case "K": rut += "8"; break;
						case "L": rut += "9"; break;
						case "P": rut += "0"; break;
						case "R": rut += "2"; break;
						case "S": rut += "3"; break;
						case "T": rut += "4"; break;
						case "V": rut += "5"; break;
						case "W": rut += "6"; break;
						case "X": rut += "7"; break;
						case "Y": rut += "8"; break;
						case "Z": rut += "9"; break;
						default: rut += ""; break;
					}
				}
                int aux;
                bool esPatentenueva = int.TryParse(patente.Substring(3, 3), out aux);
                if (esPatentenueva)
                {
                    rut += patente.Substring(3, 3);
                }
                else
                {
                    rut += patente.Substring(4, 2);
                }

			} else {
				return "";
			}
			return digitoVerificador(rut);
		}

		public static string digitoVerificador(string strRut) {
			int rut;
			int Digito;
			int Contador;
			int Multiplo;
			int Acumulador;
			string RutDigito;
			if (strRut == "") {
				return "";
			}
			rut = Convert.ToInt32(strRut);
			Contador = 2;
			Acumulador = 0;
			while (rut != 0) {
				Multiplo = (rut % 10) * Contador;
				Acumulador = Acumulador + Multiplo;
				rut = rut / 10;
				Contador = Contador + 1;
				if (Contador == 8) {
					Contador = 2;
				}
			}
			Digito = 11 - (Acumulador % 11);
			RutDigito = Digito.ToString().Trim();
			if (Digito == 10) {
				RutDigito = "K";
			}
			if (Digito == 11) {
				RutDigito = "0";
			}
			return (RutDigito); 
		}

		public static void alerta(string strmensaje, System.Web.UI.Page pPagina) {
			string strAlerta = "<script language=\"javascript\">window.alert (\"" + strmensaje + "\");</script>";
			//pPagina.RegisterStartupScript("mensaje", strAlerta);
			pPagina.ClientScript.RegisterClientScriptBlock(pPagina.GetType(), "mensaje", strAlerta);
		}

		public static void alerta_updatepanel(string strmensaje, System.Web.UI.Page pPagina, UpdatePanel up) {
			string strAlerta = "alert('" + strmensaje + "');";
			//ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
			ScriptManager.RegisterStartupScript(up, up.GetType(), "", strAlerta, true);
		}

        public static void confirmacion_updatepanel(string strmensaje, System.Web.UI.Page pPagina, UpdatePanel up)
        {
            string strAlerta = "Confirm('" + strmensaje + "');";
            //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(up, up.GetType(), "Confirm", strAlerta, false);


        }

		public static void alerta_direccion(string strmensaje, System.Web.UI.Page pPagina) {
			string strAlerta = "<script language=\"javascript\">window.alert(\"" + strmensaje + "\" ); window.location='home.aspx';</script>";
			//pPagina.RegisterStartupScript("crea_operacion", strAlerta);
			pPagina.ClientScript.RegisterClientScriptBlock(pPagina.GetType(), "mensaje", strAlerta);
		}

		public static void limpia_formulario(System.Web.UI.Page pPagina) {
			//Limpiar de manera rapida
			foreach (Control c in pPagina.Controls) {
				if (c is TextBox) {
					((TextBox)c).Text = "";
				}
			}
		}

		public static void combopais(DropDownList combobox) {
			Pais mpais = new Pais();
			mpais.Codigo = "sel";
			mpais.Nombre = "Seleccionar";
			List<Pais> lPais = new PaisBC().getallpais("TODO");
			lPais.Add(mpais);
			combobox.DataSource = lPais;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "sel";
			return;
		}

		public static void comboregion(DropDownList combobox, string codigo_pais) {
			Region mregion = new Region();
			mregion.Id_region = 0;
			mregion.Nombre = "Seleccionar";
			List<Region> lRegion = new RegionBC().getregionbypais(codigo_pais);
			lRegion.Add(mregion);
			combobox.DataSource = lRegion;
			combobox.DataValueField = "id_region";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combociudad(DropDownList combobox, Int16 id_region) {
			Ciudad mciudad = new Ciudad();
			mciudad.Id_Ciudad = 0;
			mciudad.Nombre = "Seleccionar";
			List<Ciudad> lCiudad = new CiudadBC().getCiudadbyregion(id_region);
			lCiudad.Add(mciudad);
			combobox.DataSource = lCiudad;
			combobox.DataValueField = "id_ciudad";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combocomuna(DropDownList combobox, Int16 id_ciudad) {
			Comuna mcomuna = new Comuna();
			mcomuna.Id_Comuna = 0;
			mcomuna.Nombre = "Seleccionar";
			List<Comuna> lComuna = new ComunaBC().getComunabyciudad(id_ciudad);
			lComuna.Add(mcomuna);
			combobox.DataSource = lComuna;
			combobox.DataValueField = "id_comuna";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void comboparametro(DropDownList combobox, string tipoparametro) {


           combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));

            
            IOrderedEnumerable<Parametro> lParametro = from p in new ParametroBC().GetParametroByTipoParametro(tipoparametro)
											   orderby p.Orden ascending
											   select p;
			
     


            combobox.DataSource = lParametro;
			combobox.DataValueField = "codigoparametro";
			combobox.DataTextField = "valoralfanumerico";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void listaparametro(RadioButtonList list, string tipoparametro)
		{
			list.DataSource = new ParametroBC().GetParametroByTipoParametro(tipoparametro);
			list.DataValueField = "codigoparametro";
			list.DataTextField = "valoralfanumerico";
			list.DataBind();
			list.SelectedValue = "0";
		}

		public static void combomodulo(DropDownList combobox, Int16 id_cliente) {
			//ModuloCliente mcliente = new ModuloCliente();
			//mcliente.Id_modulo = 0;
			//mcliente.Nombre = "Seleccionar";
			//List<ModuloCliente> lModulo = new ModuloclienteBC().getmoduloclientebycliente(id_cliente);
			//lModulo.Add(mcliente);
			//combobox.DataSource = lModulo;
			//combobox.DataValueField = "id_modulo";
			//combobox.DataTextField = "nombre";
			//combobox.DataBind();
			//combobox.SelectedValue = "0";

			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));

			combobox.DataSource = from m in new ModuloclienteBC().getmoduloclientebycliente(id_cliente)
								  orderby m.Nombre
								  select m;
			combobox.DataValueField = "id_modulo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combomodulobyusuario(DropDownList combobox, string cuenta_usuario, Int16 id_cliente) {
			//ModuloCliente mcliente = new ModuloCliente();
			//mcliente.Id_modulo = 0;
			//mcliente.Nombre = "Seleccionar";
			//List<ModuloCliente> lModulo = new ModuloclienteBC().getmoduloclientebyusuario(cuenta_usuario, id_cliente);
			//lModulo.Add(mcliente);
			//combobox.DataSource = lModulo;
			//combobox.DataValueField = "id_modulo";
			//combobox.DataTextField = "nombre";
			//combobox.DataBind();
			//combobox.SelectedValue = "0";

			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));

			combobox.DataSource = from m in new ModuloclienteBC().getmoduloclientebyusuario(cuenta_usuario, id_cliente)
								  orderby m.Nombre
								  select m;
			combobox.DataValueField = "id_modulo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";

			return;
		}

		public static void combonominabyfamilia(DropDownList combobox, int id_familia)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			combobox.DataSource = from n in new TipoNominaBC().getTipoNominaByIdFamilia(id_familia)
								 
								  select n;
			combobox.DataValueField = "id_nomina";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combosucursalbyclienteandUsuario(DropDownList combobox, Int16 id_cliente, string usuario) {
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));

			IOrderedEnumerable<SucursalCliente> lsucursal = from suc in new SucursalclienteBC().getSucursalByClienteAndUsuario(id_cliente, usuario)
															orderby suc.Nombre ascending
															select suc;
			combobox.DataSource = lsucursal;
			combobox.DataValueField = "id_sucursal";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			//combobox.SelectedValue = "0";
			return;
		}

		public static void combosucursalbyclienteandUsuarioconces(DropDownList combobox, Int16 id_cliente, string usuario, string conces)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));

			IOrderedEnumerable<SucursalCliente> lsucursal = from suc in new SucursalclienteBC().getSucursalByClienteAndUsuarioconces(id_cliente, usuario, conces)
															orderby suc.Nombre ascending
															select suc;
			combobox.DataSource = lsucursal;
			combobox.DataValueField = "id_sucursal";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			//combobox.SelectedValue = "0";
			return;
		}



		public static void combosucursalbymodulo(DropDownList combobox, short id_modulo)
		{
			//getSucursalbymodulo
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			combobox.DataSource = from suc in new SucursalclienteBC().getSucursalbymodulo(id_modulo)
								  orderby suc.Nombre ascending
								  select suc;
			combobox.DataValueField = "id_sucursal";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void comboconcesionario(DropDownList combobox, short id_cliente)
		{
			ClienteConce mclienteconcesionaria = new ClienteConce();
			mclienteconcesionaria.Codigo_concesionaria = "0";
			mclienteconcesionaria.Nombre = "Seleccionar";
			List<ClienteConce> lClienteconcesionaria = new ClienteconcesionarioBC().getclienteconcesionario(id_cliente);
			lClienteconcesionaria.Add(mclienteconcesionaria);
			combobox.DataSource = lClienteconcesionaria;
			combobox.DataValueField = "codigo_concesionaria";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		
		}



		public static void combotipooperacion(DropDownList combobox) {
			TipoOperacion mtipo = new TipoOperacion();
			mtipo.Codigo = "0";
			mtipo.Operacion = "Seleccionar";
			List<TipoOperacion> lTipooperacion = new TipooperacionBC().getallTipooperacion();
			lTipooperacion.Add(mtipo);
			combobox.DataSource = lTipooperacion;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "operacion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void comboTipoOperacionCliente(DropDownList combobox, short id_cliente)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			combobox.DataSource = from o in new TipooperacionBC().getTipo_OperacionByCliente(id_cliente, "TRUE")
								  orderby o.Operacion ascending
								  select o;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "operacion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combocliente(DropDownList combobox) {
			DataTable dt = new DataTable();
			System.Data.DataRow dr;
			dt.Columns.Add(new DataColumn("id_cliente"));
			dt.Columns.Add(new DataColumn("nombre"));
			dr = dt.NewRow();
			dr["id_cliente"] = "0";
			dr["nombre"] = "Seleccionar";
			dt.Rows.Add(dr);
			IOrderedEnumerable<Cliente> lcliente = from c in new ClienteBC().getclientes()
												   orderby c.Persona.Nombre ascending, c.Persona.Apellido_paterno ascending, c.Persona.Apellido_materno ascending
												   select c;
			foreach (Cliente mcliente in lcliente)
			{
				dr = dt.NewRow();
				dr["id_cliente"] = mcliente.Id_cliente;
				dr["nombre"] = mcliente.Persona.Nombre;
				dt.Rows.Add(dr);
			}
			combobox.DataSource = dt;
			combobox.DataValueField = "id_cliente";
			combobox.DataTextField = "Nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void comboperfil(DropDownList combobox) {
			Perfil mperfil = new Perfil();
			mperfil.Codigoperfil = "0";
			mperfil.Descripcion = "Seleccionar";
			List<Perfil> lPerfil = new PerfilBC().getperfiles();
			lPerfil.Add(mperfil);
			combobox.DataSource = lPerfil;
			combobox.DataValueField = "codigoperfil";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";

			return;
		}

        public static void combogrupo(DropDownList combobox)
        {
            Grupo mgrupo = new Grupo();
            mgrupo.Id_grupo = 0;
            mgrupo.Descripcion = "Seleccionar";
            List<Grupo> lgrupo = new GrupoBC().getallgrupo();
            lgrupo.Add(mgrupo);
            combobox.DataSource = lgrupo;
            combobox.DataValueField = "id_grupo";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

		public static void combotipovehiculo(DropDownList combobox) {
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			IOrderedEnumerable<Tipovehiculo> ltipo = from v in new TipovehiculoBC().getallTipovehiculo()
													 orderby v.Nombre ascending
													 select v;
			combobox.DataSource = ltipo;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combotipocarroceria(DropDownList combobox)
		{
			combobox.Items.Clear();
			//combobox.AppendDataBoundItems = true;
			ListItem item = new ListItem("Seleccionar", "0");
			item.Selected = true;
			combobox.Items.Add(item);

			foreach (TipoCarroceria car in new TipoCarroceriaBC().GetTipoCarroceriaTodos())
				combobox.Items.Add(new ListItem(car.Descripcion, car.Cod_tipo_carroceria.ToString()));

			//combobox.DataSource = new TipoCarroceriaBC().GetTipoCarroceriaTodos();
			//combobox.DataValueField = "cod_tipo_carroceria";
			//combobox.DataTextField = "descripcion";
			//combobox.DataBind();
		}

		public static void combomarcavehiculo(DropDownList combobox) {
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			IOrderedEnumerable<Marcavehiculo> lmarca = from m in new MarcavehiculoBC().getallMarcavehiculo()
													   orderby m.Nombre ascending
													   select m;
			combobox.DataSource = lmarca;
			combobox.DataValueField = "id_marca";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

        public static void comboModelovehiculo(DropDownList combobox, Int16 id_marca)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));
            IOrderedEnumerable<ModeloVehiculo> lmarca = from m in new ModelovehiculoBC().getallModelovehiculo(id_marca,"")
                                                       orderby m.Nombre ascending
                                                       select m;
            combobox.DataSource = lmarca;
            combobox.DataValueField = "id_modelo";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

		public static void comboModelovehiculoexterno(DropDownList combobox, Int16 id_marca)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			IOrderedEnumerable<ModeloVehiculo> lmarca = from m in new ModelovehiculoBC().getallModelovehiculoexterno(id_marca)
														orderby m.Nombre ascending
														select m;
			combobox.DataSource = lmarca;
			combobox.DataValueField = "id_modelo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}


		public static void combomodelovehiculo(DropDownList combobox, Int16 id_marca, string tipo_vehiculo) {
			ModeloVehiculo mmodelo = new ModeloVehiculo();
			mmodelo.Id_Modelo = 0;
			mmodelo.Nombre = "Seleccionar";
			List<ModeloVehiculo> lmodelo = new ModelovehiculoBC().getallModelovehiculo(id_marca, tipo_vehiculo);
			lmodelo.Add(mmodelo);
			combobox.DataSource = lmodelo;
			combobox.DataValueField = "id_modelo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combosucursalbycliente(DropDownList combobox, Int16 id_cliente) {
			SucursalCliente msucursal = new SucursalCliente();
			msucursal.Id_sucursal = 0;
			msucursal.Nombre = "Seleccionar";
			List<SucursalCliente> lsucursal = new SucursalclienteBC().getSucursalbycliente(id_cliente);
			lsucursal.Add(msucursal);
			combobox.DataSource = lsucursal;
			combobox.DataValueField = "id_sucursal";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combobanco(DropDownList combobox,Int32 id_cliente) {
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
            combobox.DataSource = from b in new BancofinancieraBC().getallbancofinanciera("TODO", id_cliente)
								  orderby b.Nombre ascending
								  select b;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combobancofinanciera(DropDownList combobox)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from b in new BancofinancieraBC().getallbancoallfinanciera()
								  orderby b.Nombre ascending
								  select b;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}


		public static void combobancofinancieraconces(DropDownList combobox)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from b in new BancofinancieraBC().getallbancoallfinancieraconces()
								  orderby b.Nombre ascending
								  select b;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}


        public static void comboFinancieraCliente(DropDownList combobox, Int32 id_cliente)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccion", "0"));
            combobox.DataSource = from b in new BancofinancieraBC().getFinancieraCliente(id_cliente)
                                  orderby b.Nombre ascending
                                  select b;
            combobox.DataValueField = "codigo";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

		public static void comboFinancieraClientefinanciera2(DropDownList combobox, int id_clientef)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from b in new BancofinancieraBC().getallbancoallfinancieracliente(id_clientef)
								  orderby b.Nombre ascending
								  select b;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			//combobox.SelectedValue = "0";
			return;
		}

		public static void comboFinancieraClientefinanciera(DropDownList combobox, int id_clientef)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from b in new BancofinancieraBC().getallbancoallfinancieracliente2(id_clientef)
								  orderby b.Nombre ascending
								  select b;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			//combobox.SelectedValue = "0";
			return;
		}




      


		public static void combopoliza(DropDownList combobox) {
			DistribuidorPoliza mpoliza = new DistribuidorPoliza();
			mpoliza.Codigo = "0";
			mpoliza.Nombre = "Seleccionar";
			List<DistribuidorPoliza> lpoliza = new DistribuidorpolizaBC().getalldistribuidorpoliza("TODO");
			lpoliza.Add(mpoliza);
			combobox.DataSource = lpoliza;
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combocuenta(string codigo_banco, DropDownList combobox) {
			List<CuentaBanco> lcuenta = new CuentabancoBC().getcuentabancobybanco(codigo_banco);
			CuentaBanco mcuenta = new CuentaBanco();
			mcuenta.Id_cuenta_banco = 0;
			mcuenta.Numero_cuenta = "Seleccionar";
			lcuenta.Add(mcuenta);
			combobox.DataSource = lcuenta;
			combobox.DataValueField = "id_cuenta_banco";
			combobox.DataTextField = "numero_cuenta";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void comboclientesbyusuario(string cuenta_usuario, DropDownList combobox) {
			DataTable dt = new DataTable();
			System.Data.DataRow dr;
			dt.Columns.Add(new DataColumn("id_cliente"));
			dt.Columns.Add(new DataColumn("nombre"));
			dr = dt.NewRow();
			dr["id_cliente"] = "0";
			dr["nombre"] = "Seleccionar";
			dt.Rows.Add(dr);
			IOrderedEnumerable<Cliente> lcliente = from c in new ClienteBC().getUsuariocliente(cuenta_usuario)
												   orderby c.Persona.Nombre ascending, c.Persona.Apellido_paterno ascending, c.Persona.Apellido_materno ascending
												   select c;
			foreach (Cliente mcliente in lcliente)
			{
				dr = dt.NewRow();
				dr["id_cliente"] = mcliente.Id_cliente;
				dr["nombre"] = mcliente.Persona.Nombre;
				dt.Rows.Add(dr);
			}
			combobox.DataSource = dt;
			combobox.DataValueField = "id_cliente";
			combobox.DataTextField = "Nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

        public static void combofamiliabyusuario(string cuenta_usuario, DropDownList combobox)
        {
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from c in new Familia_productoBC().getFamiliaProductoByUsuario(cuenta_usuario)
								  orderby c.Id_familia ascending, c.Descripcion ascending
								  select c;
            combobox.DataValueField = "id_familia";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

		public static void comboestado(DropDownList combobox, string tipo)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from e in new EstadotipooperacionBC().getEstadoByTipooperacion(tipo)
								  orderby e.Orden
								  select new
								  {
									  codigo_estado = e.Codigo_estado,
									  descripcion = e.Descripcion.ToUpper().Trim()
								  };
			combobox.DataValueField = "codigo_estado";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void comboEstadoByFamilia(DropDownList combobox, int id_familia)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from e in new EstadotipooperacionBC().getEstadoByFamilia(id_familia)
								  orderby e.Orden
								  select new
								  {
									  codigo_estado = e.Codigo_estado,
									  descripcion = e.Descripcion.ToUpper().Trim()
								  };
			combobox.DataValueField = "codigo_estado";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combofamilia_by_cliente_usuario(Int16 id_cliente, string cuenta_usuario, DropDownList combobox)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from c in new Familia_productoBC().getFamilia_by_cliente_usuario(id_cliente, cuenta_usuario)
								  orderby c.Id_familia ascending, c.Descripcion ascending 
								  select c;
			combobox.DataValueField = "id_familia";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}


		public static Int32 suma_textogrilla(GridView gr_dato, string control_texto) {
			Int32 suma;
			suma = 0;
			for (int i = 0; i < gr_dato.Rows.Count; i++) {
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				if (chk.Checked == true) {
					TextBox txt = (TextBox)gr_dato.Rows[i].FindControl(control_texto);
					suma = suma + Convert.ToInt32(txt.Text.ToString());
				}
			}
			return suma;
		}

		public static double suma_textogrilla_double(GridView gr_dato, string control_texto)
		{
			double suma;
			suma = 0;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				if (chk.Checked == true)
				{
					TextBox txt = (TextBox)gr_dato.Rows[i].FindControl(control_texto);
					string num = txt.Text.Replace("_", "");
					if (num.Trim() == "") num = "0";
					suma = suma + Convert.ToDouble(num);
				}
			}
			return suma;
		}

		public static void calcula_subtotal_grilla(GridView gr_dato, string control_valor, string control_cantidad, string control_resultado)
		{
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				TextBox valor = (TextBox)gr_dato.Rows[i].FindControl(control_valor);
				TextBox cantidad = (TextBox)gr_dato.Rows[i].FindControl(control_cantidad);
				TextBox stotal = (TextBox)gr_dato.Rows[i].FindControl(control_resultado);
				string val = valor.Text.Replace("_", "");
				string can = cantidad.Text.Replace("_", "");
				if (val.Trim() == "") val = "0";
				if (can.Trim() == "") can = "0";
				stotal.Text = string.Format("{0:N2}", Convert.ToDouble(val) * Convert.ToDouble(can));
			}
		}

		public static void marca_check(GridView gr_dato) {
			for (int i = 0; i < gr_dato.Rows.Count; i++)
				((CheckBox)gr_dato.Rows[i].FindControl("chk")).Checked = ((CheckBox)gr_dato.HeaderRow.FindControl("checkall")).Checked;
		}

		public static void pagina_reporte(System.Web.UI.Page pPagina) {
			string strMensaje = "window.open('reportes/reporte_prueba.aspx' );";
			ScriptManager.RegisterClientScriptBlock(pPagina, pPagina.GetType(), "pagina_reporte", strMensaje, true);
		}

		public static string FuctionEncriptar(string User) {
			string[] sepcar = { "&" };
			string codigosenc = "adoek4nksa87&epplGJuM32J6&dehd4a93u2db&mdo4Gd2h3Epg&d5k4GCDFAdMH&5k47CDF%dMHj&fuSMuRkgf2$k&n5k43CDF8dMH&hush32rf9hd8&pplGJuM32J6o&kush39rf9hd8&ush34rf9hd8q&mpplGJuM32J6&cush30rf9hd8&3uSMuRkgf2lk&Aush3erf9hd8&suSMuRkgf2dk&luSMuRkgf26k&tpplGJuM32J6&dehd4a93u2d2&udoek4nksa87&iuSMuRkgf2$k&ush3krf9hd8x&pdehd4a93u2d&yuSMuRkgf2ck&5k4cCDFxdMHr&5k4zCDFxdMHz&CuSMuRkgf2yk&applGJuM32J6&uSMuRkgf2ykJ&e5k4yCDFydMH&vdehd4a93u2d&dehd4a93u2do&w5k4oCDFodMH&Bdoek4nksa87&Eush3orf9hd8&fDded4a93u2d&N5k4oCDFqdMH&F5k4qCDFqdMH&u5k4vCDFvdMH&pplGJuM32J6H&pplGJuM32J61&doek4nksa87I&uSMuRkgf21kG&KuSMuRkgf21k&Wdehd4a93u2d&Mdoek4nksa87&75k45CDF5dMH&ush35rf9hd85&dehd4a93u2d0&PpplGJuM32J6&dehd4a93u2dL&SuSMuRkgf25k&XpplGJ7M32J6&TpplGJEM32J6&U5k47CDF7dMH&pplGJuM32J66&Yush38rf9hd8&Rush38rf9hd8&Vdoek4nksa87&Ode3d4a93u2d&huSMuRkgf23k&Z5k43CDF%dMH&dehd4a93u2dM&8us333rf9hd8&9uSMuRkgf23k&idehd4a93u2d&1pplGJuM32J6&uSMuRkgf2Gk5&doek4nksa873&9doek4nksa87&dehd4a93u2d4";
			string catacteres = "a&b&c&d&e&f&g&h&i&j&k&l&m&n&ñ&o&p&q&r&s&t&u&v&w&x&y&z&1&2&3&4&5&6&7&8&9&0&:&+&*&-&A&B&C&D&E&F&G&H&I&J&K&L&M&N&Ñ&O&P&Q&R&S&T&U&V&W&X&Y&Z&á&é&í&ó";
			string userfinal = string.Empty;
			string[] Datadesencritp = catacteres.Split(sepcar, StringSplitOptions.RemoveEmptyEntries);
			string[] Dataencritp = codigosenc.Split(sepcar, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < User.Length; i++) {
				Int16 aux = 0;
				foreach (string datastring in Datadesencritp) {
					if (User.Substring(i, 1) == datastring) {
						userfinal = userfinal + Dataencritp[aux];
					}
					aux++;
				}
			}
			return userfinal;
		}

        public static string FuctionDesEncriptar(string User)
        {
            string[] sepcar = { "&" };
            string codigosenc = "adoek4nksa87&epplGJuM32J6&dehd4a93u2db&mdo4Gd2h3Epg&d5k4GCDFAdMH&5k47CDF%dMHj&fuSMuRkgf2$k&n5k43CDF8dMH&hush32rf9hd8&pplGJuM32J6o&kush39rf9hd8&ush34rf9hd8q&mpplGJuM32J6&cush30rf9hd8&3uSMuRkgf2lk&Aush3erf9hd8&suSMuRkgf2dk&luSMuRkgf26k&tpplGJuM32J6&dehd4a93u2d2&udoek4nksa87&iuSMuRkgf2$k&ush3krf9hd8x&pdehd4a93u2d&yuSMuRkgf2ck&5k4cCDFxdMHr&5k4zCDFxdMHz&CuSMuRkgf2yk&applGJuM32J6&uSMuRkgf2ykJ&e5k4yCDFydMH&vdehd4a93u2d&dehd4a93u2do&w5k4oCDFodMH&Bdoek4nksa87&Eush3orf9hd8&fDded4a93u2d&N5k4oCDFqdMH&F5k4qCDFqdMH&u5k4vCDFvdMH&pplGJuM32J6H&pplGJuM32J61&doek4nksa87I&uSMuRkgf21kG&KuSMuRkgf21k&Wdehd4a93u2d&Mdoek4nksa87&75k45CDF5dMH&ush35rf9hd85&dehd4a93u2d0&PpplGJuM32J6&dehd4a93u2dL&SuSMuRkgf25k&XpplGJ7M32J6&TpplGJEM32J6&U5k47CDF7dMH&pplGJuM32J66&Yush38rf9hd8&Rush38rf9hd8&Vdoek4nksa87&Ode3d4a93u2d&huSMuRkgf23k&Z5k43CDF%dMH&dehd4a93u2dM&8us333rf9hd8&9uSMuRkgf23k&idehd4a93u2d&1pplGJuM32J6&uSMuRkgf2Gk5&doek4nksa873&9doek4nksa87&dehd4a93u2d4";
            string catacteres = "a&b&c&d&e&f&g&h&i&j&k&l&m&n&ñ&o&p&q&r&s&t&u&v&w&x&y&z&1&2&3&4&5&6&7&8&9&0&:&+&*&-&A&B&C&D&E&F&G&H&I&J&K&L&M&N&Ñ&O&P&Q&R&S&T&U&V&W&X&Y&Z&á&é&í&ó";
            string userfinal = string.Empty;
            string[] Datadesencritp = catacteres.Split(sepcar, StringSplitOptions.RemoveEmptyEntries);
            string[] Dataencritp = codigosenc.Split(sepcar, StringSplitOptions.RemoveEmptyEntries);
            int y = 12;
            int x = 0;
            string encriptado;
            for (int i = 11; i < User.Length; )
            {
                Int16 aux = 0;
                foreach (string datastring in Dataencritp)
                {
                    encriptado = User.Substring(x, y);
                    if (encriptado == datastring)
                    {
                        userfinal = userfinal + Datadesencritp[aux];
                    }
                    aux++;
                }
                i = i + 11;
                x = x + 12;
            }
            return userfinal;
        }

		public static string CifrarTexto(string texto)
		{
			string key = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

			byte[] textoPlano = System.Text.UTF8Encoding.UTF8.GetBytes(texto);
			System.Security.Cryptography.MD5CryptoServiceProvider hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

			byte[] keyArray = hashmd5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(key));
			hashmd5.Clear();

			System.Security.Cryptography.TripleDESCryptoServiceProvider tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
			tdes.Key = keyArray;
			tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
			tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

			System.Security.Cryptography.ICryptoTransform cTransform = tdes.CreateEncryptor();

			byte[] criptograma = cTransform.TransformFinalBlock(textoPlano, 0, textoPlano.Length);

			tdes.Clear();

			return Convert.ToBase64String(criptograma, 0, criptograma.Length);
		}

		public static string DescifrarTexto(string texto)
		{
			string key = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

			byte[] criptograma = Convert.FromBase64String(texto);
			System.Security.Cryptography.MD5CryptoServiceProvider hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

			byte[] keyArray = hashmd5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(key));
			hashmd5.Clear();

			System.Security.Cryptography.TripleDESCryptoServiceProvider tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

			tdes.Key = keyArray;
			tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
			tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

			System.Security.Cryptography.ICryptoTransform cTransform = tdes.CreateDecryptor();

			byte[] resultArray = cTransform.TransformFinalBlock(criptograma, 0, criptograma.Length);

			tdes.Clear();
			
			return System.Text.UTF8Encoding.UTF8.GetString(resultArray);
		}

		public static void BuscarTextoCombo(DropDownList combo, string texto) {
			if (combo.Items.FindByText(texto) != null) {
				combo.SelectedItem.Selected = false;
				combo.Items.FindByText(texto).Selected = true;
			}
		}

		public static void BuscarValueCombo(DropDownList combo, string value) {
			if (combo.Items.FindByValue(value) != null) {
				combo.SelectedItem.Selected = false;
				combo.Items.FindByValue(value).Selected = true;
			}
		}

		public static void combofamilia_producto(DropDownList combobox)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			combobox.DataSource = from f in new Familia_productoBC().getallFamilia_producto()
								  orderby f.Descripcion
								  select new
								  {
									  id_familia = f.Id_familia,
									  descripcion = f.Descripcion.ToUpper().Trim()
								  };
			combobox.DataValueField = "id_familia";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}


        public static void combofamilia_cliente(DropDownList combobox, Int16 id_cliente)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));
            combobox.DataSource = from f in new Familia_productoBC().getallFamilia_cliente(id_cliente)
                                  orderby f.Descripcion
                                  select new
                                  {
                                      id_familia = f.Id_familia,
                                      descripcion = f.Descripcion.ToUpper().Trim()
                                  };
            combobox.DataValueField = "id_familia";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }



		public static void combocapitales(DropDownList combobox)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			IOrderedEnumerable<Region> lregion = from r in new RegionBC().getregionbypais("CH")
												 orderby r.Capital ascending
												 select r;
			combobox.DataSource = lregion;
			combobox.DataValueField = "id_region";
			combobox.DataTextField = "capital";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combocomunabycapitales(DropDownList combobox, Int16 id_region)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0"));
			IOrderedEnumerable<Comuna> lcomuna = from c in new ComunaBC().getComunabyregion(id_region)
												 orderby c.Nombre ascending
												 select c;
			combobox.DataSource = lcomuna;
			combobox.DataValueField = "id_comuna";
			combobox.DataTextField = "nombre";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void actualizar_bancos()
		{
			System.Net.ServicePointManager.Expect100Continue = false;
			ServiceIntegracionClient ws = new ServiceIntegracionClient();
			ws.Open();

			var lbancos = from s in ws.ListaBancos(ws.Encriptar(ConfigurationManager.AppSettings["wsperu_user"]), ws.Encriptar(ConfigurationManager.AppSettings["wsperu_pswd"])).ToList<string>()
						  orderby s ascending
						  select s;
			foreach (string banco in lbancos)
			{
				var query = (from b in new BancofinancieraBC().getallbancofinanciera("TODO",1)
							 where b.Nombre.Trim().ToUpper() == banco.Trim().ToUpper()
							 select b).FirstOrDefault();
				if (query == null)
				{
					new BancofinancieraBC().add_bancofinanciera_automatica(banco);
				}
			}
			ws.Close();
		}

		public static void comboTipoNominaByFamilia(DropDownList combobox, int id_familia)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0", true));
			combobox.DataSource = new TipoNominaBC().getTipoNominaByIdFamilia(id_familia);
			combobox.DataTextField = "Descripcion";
			combobox.DataValueField = "Id_nomina";
			combobox.DataBind();
		}
        public static void comboTipoNominagastoByFamilia(DropDownList combobox, int id_familia)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0", true));
            combobox.DataSource = new TipoNominaBC().getTipoNominagastoByIdFamilia(id_familia);
            combobox.DataTextField = "Descripcion";
            combobox.DataValueField = "Id_nomina";
            combobox.DataBind();
        }

		public static void Sleep(int value)
		{
			long t = DateTime.Now.Ticks;
			long s = value * 10000000;
			while (DateTime.Now.Ticks - t < s) { }
		}
		public static void comboProductobyfamilia(DropDownList combobox, Int16 id_familia)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccionar", "0", true));
			combobox.DataSource = new Familia_productoBC().getproductobyfamilia(id_familia);
			combobox.DataValueField = "codigo";
			combobox.DataTextField = "operacion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static void combohoras(DropDownList combobox)
		{
			Agenda musuario = new Agenda();

			musuario.Hora_firma = "0";
			List<Agenda> lusuario = new AgendaBC().gethoras();
			lusuario.Add(musuario);
			combobox.DataSource = lusuario;
			combobox.DataValueField = "hora_firma";
			combobox.DataTextField = "hora_firma";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}

		public static string CifrarSQL(string valor)
		{
			try
			{
				string resultado = "";
				using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString))
				{
					cnn.Open();
					using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_cifrar_texto(@valor)", cnn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@valor", valor);
						SqlDataReader dr = cmd.ExecuteReader();
						if (dr.Read())
							resultado = dr[0].ToString();
						dr.Close();
					}
					cnn.Close();
				}
				return resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static string DescifrarSQL(string valor)
		{
			try
			{
				string resultado = "";
				using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString))
				{
					cnn.Open();
					using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_descifrar_texto(@valor)", cnn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@valor", valor);
						SqlDataReader dr = cmd.ExecuteReader();
						if (dr.Read())
							resultado = dr[0].ToString();
						dr.Close();
					}
					cnn.Close();
				}
				return resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        public static void combousuariobyCliente(DropDownList combobox, Int16 id_cliente)
        {
            Usuario musuario = new Usuario();
            musuario.UserName = "0";
            musuario.Nombre = "Seleccionar";
            List<Usuario> lusuario = new UsuarioBC().GetUsuariobycliente(id_cliente);
            lusuario.Add(musuario);
            combobox.DataSource = lusuario;
            combobox.DataValueField = "userName";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }
        public static void comboTasadorbyCliente(DropDownList combobox, Int16 id_cliente)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("userName");
            dt.Columns.Add("nombre");
            DataRow dr = dt.NewRow();
            dr["userName"] = 0;
            dr["nombre"] = "Seleccionar";
            dt.Rows.Add(dr);
            List<Tasador> lusuario = new TasadorBC().getUsuarios_Tasador(id_cliente, "true");
            foreach (Tasador moficina in lusuario)
            {
                dr = dt.NewRow();
                dr["userName"] = moficina.Usu_tasador.UserName;
                dr["nombre"] = moficina.Usu_tasador.Nombre;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "nombre";
            combobox.DataValueField = "userName";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void comboctacte(DropDownList combobox, string cuenta)
        {
            combobox.Items.Clear();
            ListItem item = new ListItem("Seleccionar", "0");
            item.Selected = true;
            combobox.Items.Add(item);
            foreach (CuentaBanco fp in new CuentabancoBC().getcuentabancobybanco(cuenta))
                combobox.Items.Add(new ListItem(fp.Numero_cuenta, fp.Id_cuenta_banco.ToString()));
        }


        public static string CreaRelleno(Int32 cantidad, string relleno)
        {
            string x = "";
            while (cantidad >= 1)
            {
                x = x + relleno;
                cantidad--;
            }
            return x;
        }


        public static void combochequeinventario(DropDownList combobox)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));
            combobox.DataSource = from lope in new OperacionBC().get_ChequeInventario()
                                  orderby lope.Num_cheque ascending
                                  select lope;
            combobox.DataValueField = "id_inventario";
            combobox.DataTextField = "num_cheque";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }


        public static void combousuariobynivel(DropDownList combobox, string codigoperfil)
        {
            Usuario musuario = new Usuario();
            musuario.UserName = "0";
            musuario.Nombre = "Seleccionar";
            List<Usuario> lusuario = new UsuarioBC().getusuariobynivel(codigoperfil);
            lusuario.Add(musuario);
            combobox.DataSource = lusuario;
            combobox.DataValueField = "userName";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }


		public static void ComboTipoOperaciongasto(DropDownList combobox, Int16 id_fam)
		{
			combobox.Items.Clear();
			combobox.AppendDataBoundItems = true;
			combobox.Items.Add(new ListItem("Seleccion", "0"));
			combobox.DataSource = from e in new GastosComunesBC().getallGastosComunes(id_fam)
								  orderby e.Id_familia

								  select new
								  {
									  codigo_estado = e.Id_familia,
									  descripcion = e.Descripcion.ToUpper().Trim()
								  };
			combobox.DataValueField = "codigo_estado";
			combobox.DataTextField = "descripcion";
			combobox.DataBind();
			combobox.SelectedValue = "0";
			return;
		}


        public static void ComboEjecutivosHipotecario(int idSucursal, DropDownList combobox)
        {
            var lista = new EjecutivoHipotecarioBC().GetEjecutivoHipotecaBySucursal(idSucursal);
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_ejecutivo"));
            dt.Columns.Add(new DataColumn("nombre"));
            DataRow dr = dt.NewRow();
            dr["id_ejecutivo"] = "0";
            dr["nombre"] = "Seleccionar..";
            dt.Rows.Add(dr);

            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["id_ejecutivo"] = x.IdEjecutivo;
                dr["nombre"] = x.Nombre + " " + x.Apepat + " " + x.Apemat;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataValueField = "id_ejecutivo";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }


        public static void GetHipotecaTipoSubProducto(DropDownList combobox, int idCliente)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Descripcion");
            var dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "Seleccione...";
            dt.Rows.Add(dr);

            var h = new HipotecaTipoSubProducto { IdCliente = idCliente };
            //Actividad por prod_cliente
            var lista = new HipotecaTipoSubProductoBC().GetAll(h);
            foreach (var d in lista)
            {
                dr = dt.NewRow();
                dr["Id"] = d.Id;
                dr["Descripcion"] = d.Descripcion;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "Descripcion";
            combobox.DataValueField = "Id";
            combobox.DataBind();
            combobox.SelectedValue = "0";

        }



        public static void ComboProductosByFamiliaClienteUsuario(DropDownList combobox, int idFamilia, Int16 idCliente, string cuentaUsuario)
        {   //nuevo 27/11/2014 cpino
            var f = new TipoOperacion { Codigo = "0", Operacion = "Seleccionar" };
            var lista = new TipooperacionBC().GetProductosByFamiliaClienteUsuario(idCliente, cuentaUsuario, idFamilia);
            lista.Add(f);
            combobox.DataSource = lista;
            combobox.DataValueField = "codigo";
            combobox.DataTextField = "operacion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }


        public static void CombofamiliabyusuarioInfocarCav(string cuenta_usuario, DropDownList combobox)
        {
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccion", "0"));
            combobox.DataSource = from c in new Familia_productoBC().getFamiliaProductoByUsuario(cuenta_usuario)
                                  where c.Id_familia == 21 || c.Id_familia == 8
                                  orderby c.Id_familia ascending, c.Descripcion ascending
                                  select c;
            combobox.DataValueField = "id_familia";
            combobox.DataTextField = "descripcion";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

        //09/12/2014 transforma los numeros de un texto a letras
        public static string NumerosALetras(string texto)
        {
            var conteo = texto.Length;
            var lugarCaracter = 0;
            var nuevoTexto = "";
            var estoyConcatenandoNumeros = false;
            var numeroConcatenado = "";
            while (lugarCaracter < conteo)
            {
                var caracter = texto.Substring(lugarCaracter, 1);

                int i = 0;
                string n = caracter;
                bool result = int.TryParse(n, out i);

                if (result)
                {
                    numeroConcatenado = numeroConcatenado + caracter;
                    estoyConcatenandoNumeros = true;
                }
                else
                {
                    if (estoyConcatenandoNumeros)
                    {
                        nuevoTexto = nuevoTexto + ConvertidorNumeroLetra(Convert.ToInt64(numeroConcatenado));
                        numeroConcatenado = "";
                    }
                    estoyConcatenandoNumeros = false;
                    nuevoTexto = nuevoTexto + caracter;
                }

                lugarCaracter++;
            }
            return nuevoTexto;
        }

        public static string ConvertidorNumeroLetra(Int64 value)
        {
            var terna = 1;
            var retorno = "";

            var numeroEntero = value;

            while (numeroEntero > 0)
            {
                var numeroConvertido = "";
                var lUnidades = numeroEntero % 10;
                numeroEntero = numeroEntero / 10;
                var lDecenas = numeroEntero % 10;
                numeroEntero = numeroEntero / 10;
                var lCentenas = numeroEntero % 10;
                numeroEntero = numeroEntero / 10;

                switch (lUnidades)
                {
                    case 1:
                        numeroConvertido = terna == 1 ? "UNO" + numeroConvertido : "UN" + numeroConvertido;
                        break;
                    case 2:
                        numeroConvertido = "DOS" + numeroConvertido;
                        break;
                    case 3:
                        numeroConvertido = "TRES" + numeroConvertido;
                        break;
                    case 4:
                        numeroConvertido = "CUATRO" + numeroConvertido;
                        break;
                    case 5:
                        numeroConvertido = "CINCO" + numeroConvertido;
                        break;
                    case 6:
                        numeroConvertido = "SEIS" + numeroConvertido;
                        break;
                    case 7:
                        numeroConvertido = "SIETE" + numeroConvertido;
                        break;
                    case 8:
                        numeroConvertido = "OCHO" + numeroConvertido;
                        break;
                    case 9:
                        numeroConvertido = "NUEVE" + numeroConvertido;
                        break;
                }

                switch (lDecenas)
                {
                    case 1:
                        switch (lUnidades)
                        {
                            case 0:
                                numeroConvertido = "DIEZ ";
                                break;
                            case 1:
                                numeroConvertido = "ONCE ";
                                break;
                            case 2:
                                numeroConvertido = "DOCE ";
                                break;
                            case 3:
                                numeroConvertido = "TRECE ";
                                break;
                            case 4:
                                numeroConvertido = "CATORCE ";
                                break;
                            case 5:
                                numeroConvertido = "QUINCE ";
                                break;
                            default:
                                numeroConvertido = "DIECI" + numeroConvertido;
                                break;
                        }
                        break;
                    case 2:
                        numeroConvertido = lUnidades == 0 ? "VEINTE " + numeroConvertido : "VEINTI" + numeroConvertido;
                        break;
                    case 3:
                        numeroConvertido = lUnidades == 0 ? "TREINTA " + numeroConvertido : "TREINTA Y " + numeroConvertido;
                        break;
                    case 4:
                        numeroConvertido = lUnidades == 0 ? "CUARENTA " + numeroConvertido : "CUARENTA Y " + numeroConvertido;
                        break;
                    case 5:
                        numeroConvertido = lUnidades == 0 ? "CINCUENTA " + numeroConvertido : "CINCUENTA Y " + numeroConvertido;
                        break;
                    case 6:
                        numeroConvertido = lUnidades == 0 ? "SESENTA " + numeroConvertido : "SESENTA Y " + numeroConvertido;
                        break;
                    case 7:
                        numeroConvertido = lUnidades == 0 ? "SETENTA " + numeroConvertido : "SETENTA Y" + numeroConvertido;
                        break;
                    case 8:
                        numeroConvertido = lUnidades == 0 ? "OCHENTA " + numeroConvertido : "OCHENTA Y " + numeroConvertido;
                        break;
                    case 9:
                        numeroConvertido = lUnidades == 0 ? "NOVENTA " + numeroConvertido : "NOVENTA Y " + numeroConvertido;
                        break;
                }

                switch (lCentenas)
                {
                    case 1:
                        numeroConvertido = lUnidades == 0 && lDecenas == 0 ? "CIEN " + numeroConvertido : "CIENTO " + numeroConvertido;
                        break;
                    case 2:
                        numeroConvertido = "DOSCIENTOS " + numeroConvertido;
                        break;
                    case 3:
                        numeroConvertido = "TRESCIENTOS " + numeroConvertido;
                        break;
                    case 4:
                        numeroConvertido = "CUATROCIENTOS " + numeroConvertido;
                        break;
                    case 5:
                        numeroConvertido = "QUINIENTOS " + numeroConvertido;
                        break;
                    case 6:
                        numeroConvertido = "SEISCIENTOS " + numeroConvertido;
                        break;
                    case 7:
                        numeroConvertido = "SETECIENTOS " + numeroConvertido;
                        break;
                    case 8:
                        numeroConvertido = "OCHOCIENTOS " + numeroConvertido;
                        break;
                    case 9:
                        numeroConvertido = "NOVECIENTOS " + numeroConvertido;
                        break;
                }

                switch (terna)
                {
                    case 1:
                        break;
                    case 2:
                        numeroConvertido = lUnidades + lDecenas + lCentenas != 0 ? numeroConvertido + " MIL " : numeroConvertido;
                        break;
                    case 3:
                        if ((lUnidades + lDecenas + lCentenas != 0) && lUnidades == 1 && lDecenas == 0 && lCentenas == 0)
                        {
                            numeroConvertido = numeroConvertido + " MILLON ";
                        }
                        else if ((lUnidades + lDecenas + lCentenas != 0) && !(lUnidades == 1 && lDecenas == 0 && lCentenas == 0))
                        {
                            numeroConvertido = numeroConvertido + " MILLONES ";
                        }
                        break;
                    case 4:
                        numeroConvertido = lUnidades + lDecenas + lCentenas != 0 ? numeroConvertido + " MIL MILLONES " : numeroConvertido;
                        break;
                    default:
                        numeroConvertido = "";
                        break;
                }

                retorno = numeroConvertido + retorno;
                terna++;
            }

            if (terna == 1)
            {
                retorno = "CERO";
            }

            return retorno;

        }


        public static void ComboTitulosHipotecaInsertos(DropDownList combobox)
        {   //nuevo 05/12/2014 cpino  hipotecario
            var dt = new DataTable();
            dt.Columns.Add("idInsertoTitulo");
            dt.Columns.Add("descripcion");
            var dr = dt.NewRow();
            dr["idInsertoTitulo"] = 0;
            dr["descripcion"] = "Seleccionar";
            dt.Rows.Add(dr);

            var lista = new HipotecaInsertoTituloBC().GetAllInsertoTitulo();
            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["idInsertoTitulo"] = Convert.ToInt32(x.IdInsertoTitulo);
                dr["descripcion"] = x.Descripcion;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "descripcion";
            combobox.DataValueField = "idInsertoTitulo";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }
        public static void ComboBeneficiariosSubsidioHipoteca(DropDownList combobox, int idsolicitud)
        {   //nuevo 01/12/2014 cpino  hipotecario
            var dt = new DataTable();
            dt.Columns.Add("rut");
            dt.Columns.Add("nombre");
            var dr = dt.NewRow();
            dr["rut"] = 0;
            dr["nombre"] = "Seleccionar";
            dt.Rows.Add(dr);

            var lista = new HipotecarioBC().GetBeneficiariosSubsidio(idsolicitud);
            foreach (var per in lista)
            {
                dr = dt.NewRow();
                dr["rut"] = Convert.ToInt32(per.Rut);
                dr["nombre"] = per.Nombre + " " + per.Apellido_paterno + " " + per.Apellido_materno;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "nombre";
            combobox.DataValueField = "rut";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }



        public static void UpdateTipoOperacionOrdenTrabajo(string tipoOperacion, int idOrdenTrabajo, int idSolicitud)
        {   //nuevo combo actividadOrdenTrabajo 30/03/2015
            new OrdenTrabajoBC().UpdateProductoOrdenTrabajo(idOrdenTrabajo, tipoOperacion, idSolicitud);
        }

        public static void ComboActividadOrdenTrabajoByUsuario(DropDownList combobox, string cuentaUsuario)
        {   //nuevo combo actividadOrdenTrabajo 23/03/2015
            var dt = new DataTable();
            dt.Columns.Add("IdActividad");
            dt.Columns.Add("descripcion");
            var dr = dt.NewRow();
            dr["IdActividad"] = 0;
            dr["descripcion"] = "Todas las Actividades";
            dt.Rows.Add(dr);

            var lista = new ActividadOrdenTrabajoBC().GetActividadesOtByUsuario(cuentaUsuario);
            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["IdActividad"] = Convert.ToInt32(x.IdActividad);
                dr["descripcion"] = x.Descripcion;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "descripcion";
            combobox.DataValueField = "IdActividad";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }

        public static void ComboUsuariosByActividad(DropDownList combobox, int idActividad, int all)
        {   //nuevo combo usuarioActividadOrdenTrabajo 30/03/2015  ALL=0 todos los usuarios siguientes, All=1 top(1);
            var dt = new DataTable();
            dt.Columns.Add("cuenta_usuario");
            dt.Columns.Add("nombre");
            var dr = dt.NewRow();
            dr["cuenta_usuario"] = 0;
            dr["nombre"] = "Asignar a";
            dt.Rows.Add(dr);

            var lista = new OrdenTrabajoActividadLogBC().GetCargTrabajoUsuariosByActividadOt(new OrdenTrabajoActividadLog { ActividadDeOrdenTrabajo = new ActividadDeOrdenTrabajo { IdActividad = idActividad } }, "0", all);

            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["cuenta_usuario"] = x.Usuario.UserName.Trim().ToUpper();
                dr["nombre"] = x.Usuario.Nombre.Trim() + " CARGA TRABAJO (" + x.CargaTrabajo + ")";
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "nombre";
            combobox.DataValueField = "cuenta_usuario";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }


        public static void combosucursalbyclienteShort(DropDownList combobox, Int16 id_cliente)
        {
            SucursalCliente msucursal = new SucursalCliente();
            msucursal.Id_sucursal = 0;
            msucursal.Nombre = "Seleccionar";
            List<SucursalCliente> lsucursal = new SucursalclienteBC().GetSucursalbyclienteShort(id_cliente);
            lsucursal.Add(msucursal);
            combobox.DataSource = lsucursal;
            combobox.DataValueField = "id_sucursal";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }

        public static void comboclientehip(DropDownList combobox)
        {
            DataTable dt = new DataTable();
            System.Data.DataRow dr;
            dt.Columns.Add(new DataColumn("id_cliente"));
            dt.Columns.Add(new DataColumn("nombre"));
            dr = dt.NewRow();
            dr["id_cliente"] = "0";
            dr["nombre"] = "Seleccionar";
            dt.Rows.Add(dr);
            IOrderedEnumerable<Cliente> lcliente = from c in new ClienteBC().getclienteship()
                                                   orderby c.Persona.Nombre ascending, c.Persona.Apellido_paterno ascending, c.Persona.Apellido_materno ascending
                                                   select c;
            foreach (Cliente mcliente in lcliente)
            {
                dr = dt.NewRow();
                dr["id_cliente"] = mcliente.Id_cliente;
                dr["nombre"] = mcliente.Persona.Nombre;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataValueField = "id_cliente";
            combobox.DataTextField = "Nombre";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }


        public static void comboCodigo_TAGactivos(DropDownList combobox,Int32 id_solicitud)
        {
            DataTable dt = new DataTable();
            System.Data.DataRow dr;
            dt.Columns.Add(new DataColumn("id_tag"));
            dt.Columns.Add(new DataColumn("Codigo"));
            dr = dt.NewRow();
            dr["id_tag"] = "0";
            dr["Codigo"] = "Seleccionar";
            dt.Rows.Add(dr);
            List<Codigo_TAG> lcodigo = new Codigo_TAGBC().GetCodigosActivos(id_solicitud);
                                                   
                                               
            foreach (Codigo_TAG mcodigo in lcodigo)
            {
                dr = dt.NewRow();
                dr["id_tag"] = mcodigo.Id_tag;
                dr["codigo"] = mcodigo.Codigo;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataValueField = "id_tag";
            combobox.DataTextField = "codigo";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }
        public static void comboCodigo_TAG(DropDownList combobox)
        {
            DataTable dt = new DataTable();
            System.Data.DataRow dr;
            dt.Columns.Add(new DataColumn("id_tag"));
            dt.Columns.Add(new DataColumn("Codigo"));
            dr = dt.NewRow();
            dr["id_tag"] = "0";
            dr["Codigo"] = "Seleccionar";
            dt.Rows.Add(dr);
            List<Codigo_TAG> lcodigo = new Codigo_TAGBC().GetCodigos();


            foreach (Codigo_TAG mcodigo in lcodigo)
            {
                dr = dt.NewRow();
                dr["id_tag"] = mcodigo.Id_tag;
                dr["codigo"] = mcodigo.Codigo;
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataValueField = "id_tag";
            combobox.DataTextField = "codigo";
            combobox.DataBind();
            combobox.SelectedValue = "0";
            return;
        }




        public static void ComboUsuarioEstado(DropDownList combobox, string usuario, int familia)
        {   //nuevo combo Estados por usuario tbl_usuario_estado
            var dt = new DataTable();
            dt.Columns.Add("codigo_Estado");
            dt.Columns.Add("descripcion");
            var dr = dt.NewRow();
            dr["codigo_Estado"] = 0;
            dr["descripcion"] = "Mis Estados";
            dt.Rows.Add(dr);

            var lista = from d in new UsuarioEstadoBC().get_all(usuario, familia) where d.Pertenece select d;
            foreach (var x in lista)
            {
                dr = dt.NewRow();
                dr["codigo_Estado"] = x.CodigoEstado;
                dr["descripcion"] = x.NombreEstado.ToUpper();
                dt.Rows.Add(dr);
            }
            combobox.DataSource = dt;
            combobox.DataTextField = "descripcion";
            combobox.DataValueField = "codigo_Estado";
            combobox.DataBind();
            combobox.SelectedValue = "0";
        }


        public static void combosucursalbyclienteandUsuarioShort(DropDownList combobox, Int16 id_cliente, string usuario)
        {   //nuevo 6/5/2015
            combobox.Items.Clear();
            combobox.AppendDataBoundItems = true;
            combobox.Items.Add(new ListItem("Seleccionar", "0"));

            IOrderedEnumerable<SucursalCliente> lsucursal = from suc in new SucursalclienteBC().GetSucursalByClienteAndUsuarioShort(id_cliente, usuario)
                                                            orderby suc.Nombre ascending
                                                            select suc;
            combobox.DataSource = lsucursal;
            combobox.DataValueField = "id_sucursal";
            combobox.DataTextField = "nombre";
            combobox.DataBind();
            //combobox.SelectedValue = "0";
            return;
        }




	}
}