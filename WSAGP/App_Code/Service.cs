using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script;
using System.Web.Script.Services;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP.servicios_web
{

    [System.Web.Services.WebService(Namespace = "http://localhost/servicios_web/")]
    [System.Web.Services.WebServiceBinding(Namespace = "http://localhost/servicios_web/")]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]


    public class Service : System.Web.Services.WebService
    {

        public Service ()

        { }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public Matriz_Escritura getMatrizEscritura(int tipo, Int16 id_cliente)
        {
            return new Matriz_EscrituraBC().getmatrizbycod(tipo, id_cliente);
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] getListaModelosVehiculos(string prefixText, int count)
        {
            return new DatosvehiculoBC().getListaModelosVehiculos(prefixText).ToArray();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] getListaColoresVehiculos(string prefixText, int count)
        {
            return new DatosvehiculoBC().getListaColoresVehiculos(prefixText).ToArray();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] getListaSolicitantes(string prefixText, int count, string contextKey)
        {
            return (from u in new UsuarioBC().GetUsuariobycliente(Convert.ToInt32(contextKey))
                    orderby u.Nombre ascending
                    select u.Nombre.ToUpper()).ToArray();
        }

        [System.Web.Services.WebMethod()]
        public string getListadoRegiones()
        {
            List<Region> lRegiones = new RegionBC().getregionbypais("CH");
            MemoryStream m = new MemoryStream();
            XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
            w.Formatting = Formatting.Indented;
            w.Namespaces = true;
            w.WriteStartDocument(false);
            w.WriteStartElement("regiones");
            foreach (Region mRegion in lRegiones)
            {
                w.WriteStartElement("region");
                w.WriteElementString("codigo", mRegion.Id_region.ToString());
                w.WriteElementString("descripcion", mRegion.Nombre.ToUpper());
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            m.Position = 0;
            string r = new StreamReader(m).ReadToEnd();
            w.Close();
            m.Close();
            return r;
        }

        [System.Web.Services.WebMethod()]
        public string getListadoCiudades(short region)
        {
            List<Ciudad> lCiudades = new CiudadBC().getCiudadbyregion(region);
            MemoryStream m = new MemoryStream();
            XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
            w.Formatting = Formatting.Indented;
            w.Namespaces = true;
            w.WriteStartDocument(false);
            w.WriteStartElement("ciudades");
            foreach (Ciudad mCiudad in lCiudades)
            {
                w.WriteStartElement("ciudad");
                w.WriteElementString("codigo", mCiudad.Id_Ciudad.ToString());
                w.WriteElementString("descripcion", mCiudad.Nombre.ToUpper());
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            m.Position = 0;
            string r = new StreamReader(m).ReadToEnd();
            w.Close();
            m.Close();
            return r;
        }

        [System.Web.Services.WebMethod()]
        public string getListadoComunas(short ciudad)
        {
            List<Comuna> lComunas = new ComunaBC().getComunabyciudad(ciudad);
            MemoryStream m = new MemoryStream();
            XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
            w.Formatting = Formatting.Indented;
            w.Namespaces = true;
            w.WriteStartDocument(false);
            w.WriteStartElement("comunas");
            foreach (Comuna mComuna in lComunas)
            {
                w.WriteStartElement("comuna");
                w.WriteElementString("codigo", mComuna.Id_Comuna.ToString());
                w.WriteElementString("nombre", mComuna.Nombre.ToUpper());
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            m.Position = 0;
            string r = new StreamReader(m).ReadToEnd();
            w.Close();
            m.Close();
            return r;
        }

        [System.Web.Services.WebMethod()]
        public string Encriptar(string texto)
        {
            return FuncionGlobal.FuctionEncriptar(texto);
        }

        [System.Web.Services.WebMethod()]
        public string Desencriptar(string texto)
        {
            return FuncionGlobal.FuctionDesEncriptar(texto);
        }

        [System.Web.Services.WebMethod()]
        public string act_valor_patente(string user, string pswd, string patente, string valor)
        //public string getInformacionPermiso(string user, string pswd, string rut, string patente)
        {
            if (ValidarUsuario(user, pswd))
            {
                try
                {
                    string add = new OperacionXMLBC().act_patente_valor(FuncionGlobal.FuctionDesEncriptar(patente), Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(valor)));
                    return "";

                }
                catch (Exception ex)
                {
                    MemoryStream m = new MemoryStream();
                    XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                    w.Formatting = Formatting.Indented;
                    w.Namespaces = true;
                    w.WriteStartDocument(false);
                    w.WriteStartElement("operacion");
                    w.WriteStartElement("error");
                    w.WriteElementString("descripcion", ex.Message);
                    w.WriteEndElement();
                    w.WriteEndElement();
                    w.WriteEndDocument();
                    w.Flush();
                    m.Position = 0;
                    string r = new StreamReader(m).ReadToEnd();
                    w.Close();
                    m.Close();
                    return r;
                }
            }
            else
            {
                MemoryStream m = new MemoryStream();
                XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                w.Formatting = Formatting.Indented;
                w.Namespaces = true;
                w.WriteStartDocument(false);
                w.WriteStartElement("operacion");
                w.WriteStartElement("error");
                w.WriteElementString("descripcion", "Usuario o clave incorrectos");
                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();
                m.Position = 0;
                string r = new StreamReader(m).ReadToEnd();
                w.Close();
                m.Close();
                return r;
            }

        }

        [System.Web.Services.WebMethod()]
        public string act_valor_motor(string user, string pswd, string motor, string valor)
        //public string getInformacionPermiso(string user, string pswd, string rut, string patente)
        {
            if (ValidarUsuario(user, pswd))
            {
                try
                {
                    string add = new OperacionXMLBC().act_motor_valor(FuncionGlobal.FuctionDesEncriptar(motor), Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(valor)));
                    return add;

                }
                catch (Exception ex)
                {
                    MemoryStream m = new MemoryStream();
                    XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                    w.Formatting = Formatting.Indented;
                    w.Namespaces = true;
                    w.WriteStartDocument(false);
                    w.WriteStartElement("operacion");
                    w.WriteStartElement("error");
                    w.WriteElementString("descripcion", ex.Message);
                    w.WriteEndElement();
                    w.WriteEndElement();
                    w.WriteEndDocument();
                    w.Flush();
                    m.Position = 0;
                    string r = new StreamReader(m).ReadToEnd();
                    w.Close();
                    m.Close();
                    return r;
                }
            }
            else
            {
                MemoryStream m = new MemoryStream();
                XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                w.Formatting = Formatting.Indented;
                w.Namespaces = true;
                w.WriteStartDocument(false);
                w.WriteStartElement("operacion");
                w.WriteStartElement("error");
                w.WriteElementString("descripcion", "Usuario o clave incorrectos");
                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();
                m.Position = 0;
                string r = new StreamReader(m).ReadToEnd();
                w.Close();
                m.Close();
                return r;
            }

        }


        [System.Web.Services.WebMethod()]
        public PermisoCirculacion getInformacionPermisoXML(string user, string pswd, string patente)
        //public PermisoCirculacion getInformacionPermisoXML(string user, string pswd, string rut, string patente)
        {
            if (ValidarUsuario(user, pswd))
            {
                try
                {
                    //OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML(Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(rut)), FuncionGlobal.FuctionDesEncriptar(patente));
                    OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML_Por_Patente(FuncionGlobal.FuctionDesEncriptar(patente));
                    if (mOperacion != null)
                    {
                        PermisoCirculacion pc = new PermisoCirculacion();
                        pc.idOperacion = mOperacion.Id_solicitud;
                        //Datos Vehiculo
                        pc.datosVehiculo.patenteVeh = mOperacion.Vehiculo.Patente.ToUpper().Trim();
                        pc.datosVehiculo.dvPatenteVeh = mOperacion.Vehiculo.Dv.ToUpper().Trim();
                        pc.datosVehiculo.codigoMarca = mOperacion.Vehiculo.Marca.Id_marca;
                        pc.datosVehiculo.descripMarca = mOperacion.Vehiculo.Marca.Nombre.ToUpper().Trim();
                        pc.datosVehiculo.codigoTipoVeh = mOperacion.Vehiculo.Tipo_vehiculo.Codigo.Trim();
                        pc.datosVehiculo.descripTipoVeh = mOperacion.Vehiculo.Tipo_vehiculo.Nombre.ToUpper().Trim();
                        pc.datosVehiculo.modeloVeh = mOperacion.Vehiculo.Modelo.ToUpper().Trim();
                        pc.datosVehiculo.colorVeh = mOperacion.Vehiculo.Color.ToUpper().Trim();
                        pc.datosVehiculo.anioVeh = mOperacion.Vehiculo.Ano;
                        pc.datosVehiculo.chasisVeh = mOperacion.Vehiculo.Chassis;
                        pc.datosVehiculo.motorVeh = mOperacion.Vehiculo.Motor;
                        pc.datosVehiculo.vinVeh = mOperacion.Vehiculo.Vin;
                        pc.datosVehiculo.serieVeh = mOperacion.Vehiculo.Serie;
                        pc.datosVehiculo.combustibleVeh = mOperacion.Vehiculo.Combustible.ToUpper().Trim();
                        pc.datosVehiculo.cilindrajeVeh = mOperacion.Vehiculo.Cilindraje.ToUpper().Trim();
                        pc.datosVehiculo.pesoBrutoVeh = mOperacion.Vehiculo.Pesobruto;
                        pc.datosVehiculo.pesoCargaVeh = mOperacion.Vehiculo.Carga;
                        pc.datosVehiculo.numPuertaVeh = mOperacion.Vehiculo.Npuerta;
                        pc.datosVehiculo.numAsientoVeh = mOperacion.Vehiculo.Nasiento;
                        //Datos Factura
                        pc.datosFactura.numFactura = mOperacion.NumFactura;
                        pc.datosFactura.fecFactura = mOperacion.FechaFactura.ToShortDateString();
                        pc.datosFactura.netoFactura = mOperacion.NetoFactura;
                        //Datos Adquirente
                        pc.datosAdquirente.rutAdquirente = Convert.ToInt32(mOperacion.Adquirente.Rut);
                        pc.datosAdquirente.dvAdquirente = mOperacion.Adquirente.Dv.ToUpper().Trim();
                        pc.datosAdquirente.nombreAdquirente = mOperacion.Adquirente.Nombre.ToUpper().Trim();
                        pc.datosAdquirente.paternoAdquirente = mOperacion.Adquirente.Apellido_paterno.ToUpper().Trim();
                        pc.datosAdquirente.maternoAdquirente = mOperacion.Adquirente.Apellido_materno.ToUpper().Trim();
                        pc.datosAdquirente.sexoAdquierente = mOperacion.Adquirente.Sexo.ToUpper().Trim();
                        pc.datosAdquirente.tipoPersonaAdquirente = mOperacion.Adquirente.Tipo_persona.ToUpper().Trim();
                        pc.datosAdquirente.nacionalidadAdquirente = mOperacion.Adquirente.Nacionalidad.ToUpper().Trim();
                        pc.datosAdquirente.profesionAdquirente = mOperacion.Adquirente.Profesion.ToUpper().Trim();
                        pc.datosAdquirente.estadoCivilAdquirente = mOperacion.Adquirente.Estado_civil.ToUpper().Trim();
                        Telefonos telefono = new TelefonoBC().getTelefonoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        if (telefono != null)
                        {
                            pc.datosAdquirente.telefonoAdquirente = telefono.Numero.ToString();
                            pc.datosAdquirente.celularAdquirente = "";
                        }
                        else
                        {

                            pc.datosAdquirente.telefonoAdquirente = "0";
                            pc.datosAdquirente.telefonoAdquirente = "";


                        }



                        telefono = null;


                        Correo correo = new CorreoBC().getCorreoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        if (correo != null)
                        {
                            pc.datosAdquirente.emailAdquirente = correo.Correo1;
                        }
                        else
                        {
                            pc.datosAdquirente.emailAdquirente = "sin correo";

                        }

                        correo = null;



                        Direcciones direccion = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        if (direccion.Direccion != null)
                        {
                            pc.datosAdquirente.direccionAdquirente = direccion.Direccion.ToUpper().Trim();
                            pc.datosAdquirente.numeroAdquirente = direccion.Numero.ToUpper().Trim();
                            pc.datosAdquirente.deptoAdquirente = direccion.Complemento.ToUpper().Trim();
                            pc.datosAdquirente.codigoComuna = direccion.Comuna.Id_Comuna;
                            pc.datosAdquirente.descripComuna = direccion.Comuna.Nombre.ToUpper().Trim();
                            pc.datosAdquirente.codigoCiudad = direccion.Comuna.Ciudad.Id_Ciudad;
                            pc.datosAdquirente.descripCiudad = direccion.Comuna.Ciudad.Nombre.ToUpper().Trim();
                            pc.datosAdquirente.codigoRegion = direccion.Comuna.Ciudad.Region.Id_region;
                            pc.datosAdquirente.descripRegion = direccion.Comuna.Ciudad.Region.Nombre.ToUpper().Trim();
                        }
                        else
                        {
                            pc.datosAdquirente.direccionAdquirente = null;
                            pc.datosAdquirente.numeroAdquirente = null;
                            pc.datosAdquirente.deptoAdquirente = null;
                            pc.datosAdquirente.codigoComuna = 0;
                            pc.datosAdquirente.descripComuna = null;
                            pc.datosAdquirente.codigoCiudad = 0;
                            pc.datosAdquirente.descripCiudad = null;
                            pc.datosAdquirente.codigoRegion = 0;
                            pc.datosAdquirente.descripRegion = null;
                        }
                        direccion = null;
                        mOperacion = null;
                        return pc;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        [System.Web.Services.WebMethod()]
        public string getInformacionPermiso(string user, string pswd, string patente)
        //public string getInformacionPermiso(string user, string pswd, string rut, string patente)
        {
            if (ValidarUsuario(user, pswd))
            {
                try
                {
                    //OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML(Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(rut)), FuncionGlobal.FuctionDesEncriptar(patente));
                    OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML_Por_Patente(FuncionGlobal.FuctionDesEncriptar(patente));
                    if (mOperacion != null)
                    {
                        MemoryStream m = new MemoryStream();
                        XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                        w.Formatting = Formatting.Indented;
                        w.Namespaces = true;
                        w.WriteStartDocument(false);
                        w.WriteStartElement("operacion");
                        w.WriteStartElement("datosVehiculo");
                        w.WriteElementString("patenteVeh", mOperacion.Vehiculo.Patente.ToUpper());
                        w.WriteElementString("dvPatenteVeh", mOperacion.Vehiculo.Dv.ToUpper());
                        w.WriteElementString("codigoMarca", mOperacion.Vehiculo.Marca.Id_marca.ToString());
                        w.WriteElementString("descripMarca", mOperacion.Vehiculo.Marca.Nombre.ToUpper());
                        w.WriteElementString("codigoTipoVeh", mOperacion.Vehiculo.Tipo_vehiculo.Codigo);
                        w.WriteElementString("descripTipoVeh", mOperacion.Vehiculo.Tipo_vehiculo.Nombre.ToUpper());
                        w.WriteElementString("modeloVeh", mOperacion.Vehiculo.Modelo.ToUpper());
                        w.WriteElementString("colorVeh", mOperacion.Vehiculo.Color.ToUpper());
                        w.WriteElementString("anioVeh", mOperacion.Vehiculo.Ano.ToString());
                        w.WriteElementString("chasisVeh", mOperacion.Vehiculo.Chassis);
                        w.WriteElementString("motorVeh", mOperacion.Vehiculo.Motor);
                        w.WriteElementString("vinVeh", mOperacion.Vehiculo.Vin);
                        w.WriteElementString("serieVeh", mOperacion.Vehiculo.Serie);
                        w.WriteElementString("combustibleVeh", mOperacion.Vehiculo.Combustible.ToUpper());
                        w.WriteElementString("cilindrajeVeh", mOperacion.Vehiculo.Cilindraje.ToUpper());
                        w.WriteElementString("pesoBrutoVeh", mOperacion.Vehiculo.Pesobruto.ToString());
                        w.WriteElementString("pesoCargaVeh", mOperacion.Vehiculo.Carga.ToString());
                        w.WriteElementString("numPuertaVeh", mOperacion.Vehiculo.Npuerta.ToString());
                        w.WriteElementString("numAsientoVeh", mOperacion.Vehiculo.Nasiento.ToString());
                        w.WriteEndElement();
                        w.WriteStartElement("datosFactura");
                        w.WriteElementString("numFactura", mOperacion.NumFactura.ToString());
                        w.WriteElementString("fecFactura", mOperacion.FechaFactura.ToShortDateString());
                        w.WriteElementString("netoFactura", mOperacion.NetoFactura.ToString());
                        w.WriteEndElement();
                        w.WriteStartElement("datosAdquirente");
                        w.WriteElementString("rutAdquirente", mOperacion.Adquirente.Rut.ToString());
                        w.WriteElementString("dvAdquirente", mOperacion.Adquirente.Dv.ToUpper());
                        w.WriteElementString("nombreAdquirente", mOperacion.Adquirente.Nombre.ToUpper());
                        w.WriteElementString("paternoAdquirente", mOperacion.Adquirente.Apellido_paterno.ToUpper());
                        w.WriteElementString("maternoAdquirente", mOperacion.Adquirente.Apellido_materno.ToUpper());
                        w.WriteElementString("sexoAdquierente", mOperacion.Adquirente.Sexo.ToUpper());
                        w.WriteElementString("tipoPersonaAdquirente", mOperacion.Adquirente.Tipo_persona.ToUpper());
                        w.WriteElementString("nacionalidadAdquirente", mOperacion.Adquirente.Nacionalidad.ToUpper());
                        w.WriteElementString("profesionAdquirente", mOperacion.Adquirente.Profesion.ToUpper());
                        w.WriteElementString("estadoCivilAdquirente", mOperacion.Adquirente.Estado_civil.ToUpper());

                        //w.WriteElementString("telefonoAdquirente", mOperacion.Adquirente.Telefono.ToUpper());
                        Telefonos telefono = new TelefonoBC().getTelefonoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));

                        if (telefono != null)
                        {
                            w.WriteElementString("telefonoAdquirente", telefono.Numero.ToString());
                            //w.WriteElementString("celularAdquirente", mOperacion.Adquirente.Celular.ToUpper());
                            w.WriteElementString("celularAdquirente", "");
                        }
                        telefono = null;

                        //w.WriteElementString("emailAdquirente", mOperacion.Adquirente.Correo.ToUpper());

                        Correo correo = new CorreoBC().getCorreoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));

                        if (correo != null)
                        {
                            w.WriteElementString("emailAdquirente", correo.Correo1.ToString());
                        }
                        correo = null;
                        //w.WriteElementString("direccionAdquirente", mOperacion.Adquirente.Direccion.ToUpper());
                        //w.WriteElementString("numeroAdquirente", mOperacion.Adquirente.Numero.ToUpper());
                        //w.WriteElementString("deptoAdquirente", mOperacion.Adquirente.Depto.ToUpper());
                        //w.WriteElementString("codigoComuna", mOperacion.Adquirente.Comuna.Id_Comuna.ToString());
                        //w.WriteElementString("descripComuna", mOperacion.Adquirente.Comuna.Nombre.ToUpper());
                        //w.WriteElementString("codigoCiudad", mOperacion.Adquirente.Comuna.Ciudad.Id_Ciudad.ToString());
                        //w.WriteElementString("descripCiudad", mOperacion.Adquirente.Comuna.Ciudad.Nombre.ToUpper());
                        //w.WriteElementString("codigoRegion", mOperacion.Adquirente.Comuna.Ciudad.Region.Id_region.ToString());
                        //w.WriteElementString("descripRegion", mOperacion.Adquirente.Comuna.Ciudad.Region.Nombre.ToUpper());

                        Direcciones direccion = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));

                        if (direccion != null)
                        {
                            w.WriteElementString("direccionAdquirente", direccion.Direccion.ToUpper());
                            w.WriteElementString("numeroAdquirente", direccion.Numero.ToUpper());
                            w.WriteElementString("deptoAdquirente", direccion.Complemento.ToUpper());
                            w.WriteElementString("codigoComuna", direccion.Comuna.Id_Comuna.ToString());
                            w.WriteElementString("descripComuna", direccion.Comuna.Nombre.ToUpper());
                            w.WriteElementString("codigoCiudad", direccion.Comuna.Ciudad.Id_Ciudad.ToString());
                            w.WriteElementString("descripCiudad", direccion.Comuna.Ciudad.Nombre.ToUpper());
                            w.WriteElementString("codigoRegion", direccion.Comuna.Ciudad.Region.Id_region.ToString());
                            w.WriteElementString("descripRegion", direccion.Comuna.Ciudad.Region.Nombre.ToUpper());
                        }
                        direccion = null;
                        w.WriteEndElement();
                        w.WriteEndElement();
                        w.WriteEndDocument();
                        w.Flush();
                        m.Position = 0;
                        string r = new StreamReader(m).ReadToEnd();
                        w.Close();
                        m.Close();
                        return r;
                    }
                    else
                    {
                        MemoryStream m = new MemoryStream();
                        XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                        w.Formatting = Formatting.Indented;
                        w.Namespaces = true;
                        w.WriteStartDocument(false);
                        w.WriteStartElement("operacion");
                        w.WriteStartElement("error");
                        w.WriteElementString("descripcion", "No se encontró la patente buscada");
                        w.WriteEndElement();
                        w.WriteEndElement();
                        w.WriteEndDocument();
                        w.Flush();
                        m.Position = 0;
                        string r = new StreamReader(m).ReadToEnd();
                        w.Close();
                        m.Close();
                        return r;
                    }
                }
                catch (Exception ex)
                {
                    MemoryStream m = new MemoryStream();
                    XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                    w.Formatting = Formatting.Indented;
                    w.Namespaces = true;
                    w.WriteStartDocument(false);
                    w.WriteStartElement("operacion");
                    w.WriteStartElement("error");
                    w.WriteElementString("descripcion", ex.Message);
                    w.WriteEndElement();
                    w.WriteEndElement();
                    w.WriteEndDocument();
                    w.Flush();
                    m.Position = 0;
                    string r = new StreamReader(m).ReadToEnd();
                    w.Close();
                    m.Close();
                    return r;
                }
            }
            else
            {
                MemoryStream m = new MemoryStream();
                XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                w.Formatting = Formatting.Indented;
                w.Namespaces = true;
                w.WriteStartDocument(false);
                w.WriteStartElement("operacion");
                w.WriteStartElement("error");
                w.WriteElementString("descripcion", "Usuario o clave incorrectos");
                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();
                m.Position = 0;
                string r = new StreamReader(m).ReadToEnd();
                w.Close();
                m.Close();
                return r;
            }
        }

        [System.Web.Services.WebMethod()]
        public PermisoCirculacion getInformacionMotorPermisoXML(string user, string pswd, string motor)
        //public PermisoCirculacion getInformacionPermisoXML(string user, string pswd, string rut, string patente)
        {
            if (ValidarUsuario(user, pswd))
            {
                try
                {
                    //OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML(Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(rut)), FuncionGlobal.FuctionDesEncriptar(patente));
                    OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML_Por_motor(FuncionGlobal.FuctionDesEncriptar(motor));
                    if (mOperacion != null)
                    {
                        PermisoCirculacion pc = new PermisoCirculacion();
                        pc.idOperacion = mOperacion.Id_solicitud;
                        //Datos Vehiculo
                        pc.datosVehiculo.patenteVeh = mOperacion.Vehiculo.Patente.ToUpper().Trim();
                        pc.datosVehiculo.dvPatenteVeh = mOperacion.Vehiculo.Dv.ToUpper().Trim();
                        pc.datosVehiculo.codigoMarca = mOperacion.Vehiculo.Marca.Id_marca;
                        pc.datosVehiculo.descripMarca = mOperacion.Vehiculo.Marca.Nombre.ToUpper().Trim();
                        pc.datosVehiculo.codigoTipoVeh = mOperacion.Vehiculo.Tipo_vehiculo.Codigo.Trim();
                        pc.datosVehiculo.descripTipoVeh = mOperacion.Vehiculo.Tipo_vehiculo.Nombre.ToUpper().Trim();
                        pc.datosVehiculo.modeloVeh = mOperacion.Vehiculo.Modelo.ToUpper().Trim();
                        pc.datosVehiculo.colorVeh = mOperacion.Vehiculo.Color.ToUpper().Trim();
                        pc.datosVehiculo.anioVeh = mOperacion.Vehiculo.Ano;
                        pc.datosVehiculo.chasisVeh = mOperacion.Vehiculo.Chassis;
                        pc.datosVehiculo.motorVeh = mOperacion.Vehiculo.Motor;
                        pc.datosVehiculo.vinVeh = mOperacion.Vehiculo.Vin;
                        pc.datosVehiculo.serieVeh = mOperacion.Vehiculo.Serie;
                        pc.datosVehiculo.combustibleVeh = mOperacion.Vehiculo.Combustible.ToUpper().Trim();
                        pc.datosVehiculo.cilindrajeVeh = mOperacion.Vehiculo.Cilindraje.ToUpper().Trim();
                        pc.datosVehiculo.pesoBrutoVeh = mOperacion.Vehiculo.Pesobruto;
                        pc.datosVehiculo.pesoCargaVeh = mOperacion.Vehiculo.Carga;
                        pc.datosVehiculo.numPuertaVeh = mOperacion.Vehiculo.Npuerta;
                        pc.datosVehiculo.numAsientoVeh = mOperacion.Vehiculo.Nasiento;
                        //Datos Factura
                        pc.datosFactura.numFactura = mOperacion.NumFactura;
                        pc.datosFactura.fecFactura = mOperacion.FechaFactura.ToShortDateString();
                        pc.datosFactura.netoFactura = mOperacion.NetoFactura;
                        //Datos Adquirente
                        pc.datosAdquirente.rutAdquirente = Convert.ToInt32(mOperacion.Adquirente.Rut);
                        pc.datosAdquirente.dvAdquirente = mOperacion.Adquirente.Dv.ToUpper().Trim();
                        pc.datosAdquirente.nombreAdquirente = mOperacion.Adquirente.Nombre.ToUpper().Trim();
                        pc.datosAdquirente.paternoAdquirente = mOperacion.Adquirente.Apellido_paterno.ToUpper().Trim();
                        pc.datosAdquirente.maternoAdquirente = mOperacion.Adquirente.Apellido_materno.ToUpper().Trim();
                        pc.datosAdquirente.sexoAdquierente = mOperacion.Adquirente.Sexo.ToUpper().Trim();
                        pc.datosAdquirente.tipoPersonaAdquirente = mOperacion.Adquirente.Tipo_persona.ToUpper().Trim();
                        pc.datosAdquirente.nacionalidadAdquirente = mOperacion.Adquirente.Nacionalidad.ToUpper().Trim();
                        pc.datosAdquirente.profesionAdquirente = mOperacion.Adquirente.Profesion.ToUpper().Trim();
                        pc.datosAdquirente.estadoCivilAdquirente = mOperacion.Adquirente.Estado_civil.ToUpper().Trim();
                        Telefonos telefono = new TelefonoBC().getTelefonoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        pc.datosAdquirente.telefonoAdquirente = telefono.Numero.ToString();
                        pc.datosAdquirente.celularAdquirente = "";
                        telefono = null;
                        Correo correo = new CorreoBC().getCorreoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        pc.datosAdquirente.emailAdquirente = correo.Correo1;
                        correo = null;
                        Direcciones direccion = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        if (direccion.Direccion != null)
                        {
                            pc.datosAdquirente.direccionAdquirente = direccion.Direccion.ToUpper().Trim();
                            pc.datosAdquirente.numeroAdquirente = direccion.Numero.ToUpper().Trim();
                            pc.datosAdquirente.deptoAdquirente = direccion.Complemento.ToUpper().Trim();
                            pc.datosAdquirente.codigoComuna = direccion.Comuna.Id_Comuna;
                            pc.datosAdquirente.descripComuna = direccion.Comuna.Nombre.ToUpper().Trim();
                            pc.datosAdquirente.codigoCiudad = direccion.Comuna.Ciudad.Id_Ciudad;
                            pc.datosAdquirente.descripCiudad = direccion.Comuna.Ciudad.Nombre.ToUpper().Trim();
                            pc.datosAdquirente.codigoRegion = direccion.Comuna.Ciudad.Region.Id_region;
                            pc.datosAdquirente.descripRegion = direccion.Comuna.Ciudad.Region.Nombre.ToUpper().Trim();
                        }
                        else
                        {
                            pc.datosAdquirente.direccionAdquirente = null;
                            pc.datosAdquirente.numeroAdquirente = null;
                            pc.datosAdquirente.deptoAdquirente = null;
                            pc.datosAdquirente.codigoComuna = 0;
                            pc.datosAdquirente.descripComuna = null;
                            pc.datosAdquirente.codigoCiudad = 0;
                            pc.datosAdquirente.descripCiudad = null;
                            pc.datosAdquirente.codigoRegion = 0;
                            pc.datosAdquirente.descripRegion = null;
                        }
                        direccion = null;
                        mOperacion = null;
                        return pc;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        [System.Web.Services.WebMethod()]
        public string getInformacionMotorPermiso(string user, string pswd, string motor)
        //public string getInformacionPermiso(string user, string pswd, string rut, string patente)
        {
            if (ValidarUsuario(user, pswd))
            {
                try
                {
                    //OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML(Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(rut)), FuncionGlobal.FuctionDesEncriptar(patente));
                    OperacionXML mOperacion = new OperacionXMLBC().getOperacionXML_Por_motor(motor);
                    if (mOperacion.Adquirente != null)
                    {
                        MemoryStream m = new MemoryStream();
                        XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                        w.Formatting = Formatting.Indented;
                        w.Namespaces = true;
                        w.WriteStartDocument(false);
                        w.WriteStartElement("operacion");
                        w.WriteStartElement("datosVehiculo");
                        w.WriteElementString("patenteVeh", mOperacion.Vehiculo.Patente.ToUpper());
                        w.WriteElementString("dvPatenteVeh", mOperacion.Vehiculo.Dv.ToUpper());
                        w.WriteElementString("codigoMarca", mOperacion.Vehiculo.Marca.Id_marca.ToString());
                        w.WriteElementString("descripMarca", mOperacion.Vehiculo.Marca.Nombre.ToUpper());
                        w.WriteElementString("codigoTipoVeh", mOperacion.Vehiculo.Tipo_vehiculo.Codigo);
                        w.WriteElementString("descripTipoVeh", mOperacion.Vehiculo.Tipo_vehiculo.Nombre.ToUpper());
                        w.WriteElementString("modeloVeh", mOperacion.Vehiculo.Modelo.ToUpper());
                        w.WriteElementString("colorVeh", mOperacion.Vehiculo.Color.ToUpper());
                        w.WriteElementString("anioVeh", mOperacion.Vehiculo.Ano.ToString());
                        w.WriteElementString("chasisVeh", mOperacion.Vehiculo.Chassis);
                        w.WriteElementString("motorVeh", mOperacion.Vehiculo.Motor);
                        w.WriteElementString("vinVeh", mOperacion.Vehiculo.Vin);
                        w.WriteElementString("serieVeh", mOperacion.Vehiculo.Serie);
                        w.WriteElementString("combustibleVeh", mOperacion.Vehiculo.Combustible.ToUpper());
                        w.WriteElementString("cilindrajeVeh", mOperacion.Vehiculo.Cilindraje.ToUpper());
                        w.WriteElementString("pesoBrutoVeh", mOperacion.Vehiculo.Pesobruto.ToString());
                        w.WriteElementString("pesoCargaVeh", mOperacion.Vehiculo.Carga.ToString());
                        w.WriteElementString("numPuertaVeh", mOperacion.Vehiculo.Npuerta.ToString());
                        w.WriteElementString("numAsientoVeh", mOperacion.Vehiculo.Nasiento.ToString());
                        w.WriteEndElement();
                        w.WriteStartElement("datosFactura");
                        w.WriteElementString("numFactura", mOperacion.NumFactura.ToString());
                        w.WriteElementString("fecFactura", mOperacion.FechaFactura.ToShortDateString());
                        w.WriteElementString("netoFactura", mOperacion.NetoFactura.ToString());
                        w.WriteEndElement();
                        w.WriteStartElement("datosAdquirente");
                        w.WriteElementString("rutAdquirente", mOperacion.Adquirente.Rut.ToString());
                        w.WriteElementString("dvAdquirente", mOperacion.Adquirente.Dv.ToUpper());
                        w.WriteElementString("nombreAdquirente", mOperacion.Adquirente.Nombre.ToUpper());
                        w.WriteElementString("paternoAdquirente", mOperacion.Adquirente.Apellido_paterno.ToUpper());
                        w.WriteElementString("maternoAdquirente", mOperacion.Adquirente.Apellido_materno.ToUpper());
                        w.WriteElementString("sexoAdquierente", mOperacion.Adquirente.Sexo.ToUpper());
                        w.WriteElementString("tipoPersonaAdquirente", mOperacion.Adquirente.Tipo_persona.ToUpper());
                        w.WriteElementString("nacionalidadAdquirente", mOperacion.Adquirente.Nacionalidad.ToUpper());
                        w.WriteElementString("profesionAdquirente", mOperacion.Adquirente.Profesion.ToUpper());
                        w.WriteElementString("estadoCivilAdquirente", mOperacion.Adquirente.Estado_civil.ToUpper());

                        //w.WriteElementString("telefonoAdquirente", mOperacion.Adquirente.Telefono.ToUpper());
                        Telefonos telefono = new TelefonoBC().getTelefonoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        string telf = "";
                        if (telefono != null)
                        {
                            telf = telefono.Numero.ToString();
                        }
                        w.WriteElementString("telefonoAdquirente", telf);
                        //w.WriteElementString("celularAdquirente", mOperacion.Adquirente.Celular.ToUpper());
                        w.WriteElementString("celularAdquirente", "");

                        //w.WriteElementString("emailAdquirente", mOperacion.Adquirente.Correo.ToUpper());
                        Correo correo = new CorreoBC().getCorreoPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));

                        string correo1 = "";
                        if (correo != null)
                        {
                            correo1 = correo.Correo1.ToString();
                        }
                        w.WriteElementString("emailAdquirente", correo1);

                        //w.WriteElementString("direccionAdquirente", mOperacion.Adquirente.Direccion.ToUpper());
                        //w.WriteElementString("numeroAdquirente", mOperacion.Adquirente.Numero.ToUpper());
                        //w.WriteElementString("deptoAdquirente", mOperacion.Adquirente.Depto.ToUpper());
                        //w.WriteElementString("codigoComuna", mOperacion.Adquirente.Comuna.Id_Comuna.ToString());
                        //w.WriteElementString("descripComuna", mOperacion.Adquirente.Comuna.Nombre.ToUpper());
                        //w.WriteElementString("codigoCiudad", mOperacion.Adquirente.Comuna.Ciudad.Id_Ciudad.ToString());
                        //w.WriteElementString("descripCiudad", mOperacion.Adquirente.Comuna.Ciudad.Nombre.ToUpper());
                        //w.WriteElementString("codigoRegion", mOperacion.Adquirente.Comuna.Ciudad.Region.Id_region.ToString());
                        //w.WriteElementString("descripRegion", mOperacion.Adquirente.Comuna.Ciudad.Region.Nombre.ToUpper());
                        Direcciones direccion = new DireccionesBC().getDireccionPorDefecto(Convert.ToInt32(mOperacion.Adquirente.Rut));
                        w.WriteElementString("direccionAdquirente", direccion.Direccion.ToUpper());
                        w.WriteElementString("numeroAdquirente", direccion.Numero.ToUpper());
                        w.WriteElementString("deptoAdquirente", direccion.Complemento.ToUpper());
                        w.WriteElementString("codigoComuna", direccion.Comuna.Id_Comuna.ToString());
                        w.WriteElementString("descripComuna", direccion.Comuna.Nombre.ToUpper());
                        w.WriteElementString("codigoCiudad", direccion.Comuna.Ciudad.Id_Ciudad.ToString());
                        w.WriteElementString("descripCiudad", direccion.Comuna.Ciudad.Nombre.ToUpper());
                        w.WriteElementString("codigoRegion", direccion.Comuna.Ciudad.Region.Id_region.ToString());
                        w.WriteElementString("descripRegion", direccion.Comuna.Ciudad.Region.Nombre.ToUpper());

                        w.WriteEndElement();
                        w.WriteEndElement();
                        w.WriteEndDocument();
                        w.Flush();
                        m.Position = 0;
                        string r = new StreamReader(m).ReadToEnd();
                        w.Close();
                        m.Close();
                        return r;
                    }
                    else
                    {
                        MemoryStream m = new MemoryStream();
                        XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                        w.Formatting = Formatting.Indented;
                        w.Namespaces = true;
                        w.WriteStartDocument(false);
                        w.WriteStartElement("operacion");
                        w.WriteStartElement("error");
                        w.WriteElementString("descripcion", "No se encontró la patente buscada");
                        w.WriteEndElement();
                        w.WriteEndElement();
                        w.WriteEndDocument();
                        w.Flush();
                        m.Position = 0;
                        string r = new StreamReader(m).ReadToEnd();
                        w.Close();
                        m.Close();
                        return r;
                    }
                }
                catch (Exception ex)
                {
                    MemoryStream m = new MemoryStream();
                    XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                    w.Formatting = Formatting.Indented;
                    w.Namespaces = true;
                    w.WriteStartDocument(false);
                    w.WriteStartElement("operacion");
                    w.WriteStartElement("error");
                    w.WriteElementString("descripcion", ex.Message);
                    w.WriteEndElement();
                    w.WriteEndElement();
                    w.WriteEndDocument();
                    w.Flush();
                    m.Position = 0;
                    string r = new StreamReader(m).ReadToEnd();
                    w.Close();
                    m.Close();
                    return r;
                }
            }
            else
            {
                MemoryStream m = new MemoryStream();
                XmlTextWriter w = new XmlTextWriter(m, Encoding.UTF8);
                w.Formatting = Formatting.Indented;
                w.Namespaces = true;
                w.WriteStartDocument(false);
                w.WriteStartElement("operacion");
                w.WriteStartElement("error");
                w.WriteElementString("descripcion", "Usuario o clave incorrectos");
                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();
                m.Position = 0;
                string r = new StreamReader(m).ReadToEnd();
                w.Close();
                m.Close();
                return r;
            }
        }




        [System.Web.Services.WebMethod()]
        public string CifrarTDES(string texto)
        {
            return FuncionGlobal.CifrarTexto(texto);
        }

        [System.Web.Services.WebMethod()]
        public InfoGastos GetInfoGastos(string user, string pswd, string rut, string chasis)
        {
            if (ValidarUsuarioTDES(user, pswd))
            {
                try
                {
                    InfoGastos info = new InfoGastos();

                    using (SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString))
                    {
                        cnn.Open();

                        SqlCommand cmd = new SqlCommand("sp_r_ws_by_rut_chasis", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rut_cliente", Convert.ToDouble(FuncionGlobal.DescifrarTexto(rut)));
                        cmd.Parameters.AddWithValue("@chassis", FuncionGlobal.DescifrarTexto(chasis));

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            info.Patente = dr["patente"].ToString();
                            info.ValorRegistroCivil = Convert.ToDouble(dr["registro"]);
                            info.ValorSOAP = Convert.ToDouble(dr["soap"]);
                            info.ValorPermisoCirculacion = Convert.ToDouble(dr["permiso"]);
                            info.ValorTramite = Convert.ToDouble(dr["tramite"]);
                            info.ValorOtros = Convert.ToDouble(dr["otros"]);
                        }
                        dr.Close();
                        cnn.Close();
                    }

                    return info;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        private bool ValidarUsuario(string user, string pswd)
        {
            try
            {
                string x = System.Configuration.ConfigurationManager.AppSettings["wsagp_user"];
                string y = FuncionGlobal.FuctionDesEncriptar(user);
                if ((x == y) && (System.Configuration.ConfigurationManager.AppSettings["wsagp_pswd"] == FuncionGlobal.FuctionDesEncriptar(pswd)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarUsuarioTDES(string user, string pswd)
        {
            try
            {
                if ((System.Configuration.ConfigurationManager.AppSettings["wsagp_user"] == FuncionGlobal.DescifrarTexto(user)) && (System.Configuration.ConfigurationManager.AppSettings["wsagp_pswd"] == FuncionGlobal.DescifrarTexto(pswd)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class InfoGastos
    {
        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }

        private double valorRegistroCivil;

        public double ValorRegistroCivil
        {
            get { return valorRegistroCivil; }
            set { valorRegistroCivil = value; }
        }

        private double valorSOAP;

        public double ValorSOAP
        {
            get { return valorSOAP; }
            set { valorSOAP = value; }
        }

        private double valorPermisoCirculacion;

        public double ValorPermisoCirculacion
        {
            get { return valorPermisoCirculacion; }
            set { valorPermisoCirculacion = value; }
        }

        private double valorTramite;

        public double ValorTramite
        {
            get { return valorTramite; }
            set { valorTramite = value; }
        }

        private double valorOtros;

        public double ValorOtros
        {
            get { return valorOtros; }
            set { valorOtros = value; }
        }
    }

    public class PermisoCirculacion
    {
        private double _idOperacion;

        public double idOperacion
        {
            get { return _idOperacion; }
            set { _idOperacion = value; }
        }

        private DatosVehiculoPC _datosVehiculo;

        public DatosVehiculoPC datosVehiculo
        {
            get { return _datosVehiculo; }
            set { _datosVehiculo = value; }
        }

        private DatosFacturaPC _datosFactura;

        public DatosFacturaPC datosFactura
        {
            get { return _datosFactura; }
            set { _datosFactura = value; }
        }

        private DatosAdquirentePC _datosAdquirente;

        public DatosAdquirentePC datosAdquirente
        {
            get { return _datosAdquirente; }
            set { _datosAdquirente = value; }
        }

        public PermisoCirculacion()
        {
            this._datosVehiculo = new DatosVehiculoPC();
            this._datosFactura = new DatosFacturaPC();
            this._datosAdquirente = new DatosAdquirentePC();
        }
    }

    public class DatosVehiculoPC
    {
        private string _patenteVeh;

        public string patenteVeh
        {
            get { return _patenteVeh; }
            set { _patenteVeh = value; }
        }

        private string _dvPatenteVeh;

        public string dvPatenteVeh
        {
            get { return _dvPatenteVeh; }
            set { _dvPatenteVeh = value; }
        }

        private int _codigoMarca;

        public int codigoMarca
        {
            get { return _codigoMarca; }
            set { _codigoMarca = value; }
        }

        private string _descripMarca;

        public string descripMarca
        {
            get { return _descripMarca; }
            set { _descripMarca = value; }
        }

        private string _codigoTipoVeh;

        public string codigoTipoVeh
        {
            get { return _codigoTipoVeh; }
            set { _codigoTipoVeh = value; }
        }

        private string _descripTipoVeh;

        public string descripTipoVeh
        {
            get { return _descripTipoVeh; }
            set { _descripTipoVeh = value; }
        }

        private string _modeloVeh;

        public string modeloVeh
        {
            get { return _modeloVeh; }
            set { _modeloVeh = value; }
        }

        private string _colorVeh;

        public string colorVeh
        {
            get { return _colorVeh; }
            set { _colorVeh = value; }
        }

        private int _anioVeh;

        public int anioVeh
        {
            get { return _anioVeh; }
            set { _anioVeh = value; }
        }

        private string _chasisVeh;

        public string chasisVeh
        {
            get { return _chasisVeh; }
            set { _chasisVeh = value; }
        }

        private string _motorVeh;

        public string motorVeh
        {
            get { return _motorVeh; }
            set { _motorVeh = value; }
        }

        private string _vinVeh;

        public string vinVeh
        {
            get { return _vinVeh; }
            set { _vinVeh = value; }
        }

        private string _serieVeh;

        public string serieVeh
        {
            get { return _serieVeh; }
            set { _serieVeh = value; }
        }

        private string _combustibleVeh;

        public string combustibleVeh
        {
            get { return _combustibleVeh; }
            set { _combustibleVeh = value; }
        }

        private string _cilindrajeVeh;

        public string cilindrajeVeh
        {
            get { return _cilindrajeVeh; }
            set { _cilindrajeVeh = value; }
        }

        private double _pesoBrutoVeh;

        public double pesoBrutoVeh
        {
            get { return _pesoBrutoVeh; }
            set { _pesoBrutoVeh = value; }
        }

        private double _pesoCargaVeh;

        public double pesoCargaVeh
        {
            get { return _pesoCargaVeh; }
            set { _pesoCargaVeh = value; }
        }

        private int _numPuertaVeh;

        public int numPuertaVeh
        {
            get { return _numPuertaVeh; }
            set { _numPuertaVeh = value; }
        }

        private int _numAsientoVeh;

        public int numAsientoVeh
        {
            get { return _numAsientoVeh; }
            set { _numAsientoVeh = value; }
        }
    }

    public class DatosFacturaPC
    {
        private long _numFactura;

        public long numFactura
        {
            get { return _numFactura; }
            set { _numFactura = value; }
        }

        private string _fecFactura;

        public string fecFactura
        {
            get { return _fecFactura; }
            set { _fecFactura = value; }
        }

        private double _netoFactura;

        public double netoFactura
        {
            get { return _netoFactura; }
            set { _netoFactura = value; }
        }
    }

    public class DatosAdquirentePC
    {
        private int _rutAdquirente;

        public int rutAdquirente
        {
            get { return _rutAdquirente; }
            set { _rutAdquirente = value; }
        }

        private string _dvAdquirente;

        public string dvAdquirente
        {
            get { return _dvAdquirente; }
            set { _dvAdquirente = value; }
        }

        private string _nombreAdquirente;

        public string nombreAdquirente
        {
            get { return _nombreAdquirente; }
            set { _nombreAdquirente = value; }
        }

        private string _paternoAdquirente;

        public string paternoAdquirente
        {
            get { return _paternoAdquirente; }
            set { _paternoAdquirente = value; }
        }

        private string _maternoAdquirente;

        public string maternoAdquirente
        {
            get { return _maternoAdquirente; }
            set { _maternoAdquirente = value; }
        }

        private string _sexoAdquierente;

        public string sexoAdquierente
        {
            get { return _sexoAdquierente; }
            set { _sexoAdquierente = value; }
        }

        private string _tipoPersonaAdquirente;

        public string tipoPersonaAdquirente
        {
            get { return _tipoPersonaAdquirente; }
            set { _tipoPersonaAdquirente = value; }
        }

        private string _nacionalidadAdquirente;

        public string nacionalidadAdquirente
        {
            get { return _nacionalidadAdquirente; }
            set { _nacionalidadAdquirente = value; }
        }

        private string _profesionAdquirente;

        public string profesionAdquirente
        {
            get { return _profesionAdquirente; }
            set { _profesionAdquirente = value; }
        }

        private string _estadoCivilAdquirente;

        public string estadoCivilAdquirente
        {
            get { return _estadoCivilAdquirente; }
            set { _estadoCivilAdquirente = value; }
        }

        private string _direccionAdquirente;

        public string direccionAdquirente
        {
            get { return _direccionAdquirente; }
            set { _direccionAdquirente = value; }
        }

        private string _numeroAdquirente;

        public string numeroAdquirente
        {
            get { return _numeroAdquirente; }
            set { _numeroAdquirente = value; }
        }

        private string _deptoAdquirente;

        public string deptoAdquirente
        {
            get { return _deptoAdquirente; }
            set { _deptoAdquirente = value; }
        }

        private int _codigoComuna;

        public int codigoComuna
        {
            get { return _codigoComuna; }
            set { _codigoComuna = value; }
        }

        private string _descripComuna;

        public string descripComuna
        {
            get { return _descripComuna; }
            set { _descripComuna = value; }
        }

        private int _codigoCiudad;

        public int codigoCiudad
        {
            get { return _codigoCiudad; }
            set { _codigoCiudad = value; }
        }

        private string _descripCiudad;

        public string descripCiudad
        {
            get { return _descripCiudad; }
            set { _descripCiudad = value; }
        }

        private int _codigoRegion;

        public int codigoRegion
        {
            get { return _codigoRegion; }
            set { _codigoRegion = value; }
        }

        private string _descripRegion;

        public string descripRegion
        {
            get { return _descripRegion; }
            set { _descripRegion = value; }
        }

        private string _telefonoAdquirente;

        public string telefonoAdquirente
        {
            get { return _telefonoAdquirente; }
            set { _telefonoAdquirente = value; }
        }

        private string _celularAdquirente;

        public string celularAdquirente
        {
            get { return _celularAdquirente; }
            set { _celularAdquirente = value; }
        }

        private string _emailAdquirente;

        public string emailAdquirente
        {
            get { return _emailAdquirente; }
            set { _emailAdquirente = value; }
        }
    }
}