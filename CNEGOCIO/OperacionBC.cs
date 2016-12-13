using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Xml;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
	public class OperacionBC
	{
        
        public Operacion validaNumOperacionBanco(int numBanco, int numFactura)
        {
            Operacion mOperacion = new OperacionDAC().validaNumOperacionBanco(numBanco, numFactura);
            return mOperacion;
        }

        public string del_impuesto_verde(Int32 id_solicitud, string usrname)
		{
            string add = new OperacionDAC().del_impuesto_verde(id_solicitud, usrname);
			return add;
		}

        public void crear_garantia_prohibicion(Int32 id_solicitud)
        {
            new OperacionDAC().crear_garantias(id_solicitud);
           
        }

        public void AvanzarVs(int idSolicitud)
        {   //metodo provisorio para avanzar la busqueda de una página caida en infocar
            new OperacionDAC().AvanzarVs(idSolicitud);
        }

        public Int32 reiniciar_operacion_infoauto(int id_solicitud)
		{
            int add = new OperacionDAC().reiniciar_operacion_infoauto(id_solicitud);
			return add;
		}
        public List<Operacion> getoperacionfacxmlHIP(Int32 id_solicitud)
        {
            List<Operacion> mOperacion = new OperacionDAC().getOperacionesbyoperfacxmlHIP(id_solicitud);
            return mOperacion;
        }


        public Int32 add_operacion_habilitar(Int32 id_solicitud)
		{
			Int32 add = new OperacionDAC().add_operacion_habilitar(id_solicitud);
			return add;
		}

		public List<Operacion> getOperaciones(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, Int32 ultimo_estado, 
            string cuenta_usuario, Int32 id_familia, string estado_proceso, Int32 semaforo,string chassis,string motor,double rut_para)
		{
			List<Operacion> loperacion = new OperacionDAC().getOperaciones(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, ultimo_estado, 
                cuenta_usuario, id_familia, estado_proceso, semaforo,chassis,motor,rut_para);
			return loperacion;
		}

		public List<Operacion> sp_r_getOperacionesejecutivo(Int32 id_sucursal,
												Int32 numero_operacion,
												Int32 rut_adquiriente,
												string desde,
												string hasta,
												string cuenta_usuario,String numero_cliente)
		{
			List<Operacion> loperacion = new OperacionDAC().sp_r_getOperacionesejecutivo(id_sucursal,numero_operacion,rut_adquiriente,desde,hasta,cuenta_usuario,numero_cliente);
			return loperacion;
		}

        public List<Operacion> getOperacionescarpeta(Int32 id_sucursal,
                                                Int32 numero_operacion,
                                                Int32 rut_adquiriente,
                                                string desde,
                                                string hasta,
                                                string cuenta_usuario, int numero_cliente)
        {
            List<Operacion> loperacion = new OperacionDAC().getOperacionescarpeta(id_sucursal, numero_operacion, rut_adquiriente, desde, hasta, cuenta_usuario, numero_cliente);
            return loperacion;
        }

        public List<Operacion> getOperacionesTAG(Int32 id_sucursal,
                                            Int32 numero_operacion,
                                            Int32 rut_adquiriente,
                                            string desde,
                                            string hasta,
                                            string cuenta_usuario, Int32 numero_cliente, Int16 id_cliente)
        {
            List<Operacion> loperacion = new OperacionDAC().getOperacionesTAG(id_sucursal, numero_operacion, rut_adquiriente, desde, hasta, cuenta_usuario, numero_cliente,id_cliente);
            return loperacion;
        }


        public List<Operacion> getOpercarpEjecCliente(Int32 id_sucursal,
                                                Int32 numero_operacion,
                                                Int32 rut_adquiriente,
                                                string desde,
                                                string hasta,
                                                string cuenta_usuario, Int32 numero_cliente)
        {
            List<Operacion> loperacion = new OperacionDAC().getOpercarpEjecCliente(id_sucursal, numero_operacion, rut_adquiriente, desde, hasta, cuenta_usuario, numero_cliente);
            return loperacion;
        }

      

		public List<OperacionPeru> getOperacionesPeru(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, string rut_adquiriente, string numero_factura, string numero_cliente, string patente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario, Int32 id_familia)
		{
			List<OperacionPeru> loperacion = new OperacionDAC().getOperacionesPeru(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, ultimo_estado, cuenta_usuario, id_familia);
			return loperacion;
		}

		public List<Operacion> getOperacionesbynomina(Int32 id_nomina, Int32 folio, string cuenta_usuario)
		{
			List<Operacion> loperacion = new OperacionDAC().getOperacionesbynomina(id_nomina, folio, cuenta_usuario);
			return loperacion;
		}

        public List<Operacion> getOperacionesbynominaExpress(Int32 id_nomina, Int32 folio, string cuenta_usuario)
        {
            List<Operacion> loperacion = new OperacionDAC().getOperacionesbynominaExpress(id_nomina, folio, cuenta_usuario);
            return loperacion;
        }

        public List<Operacion> getOperacionesbynominagasto(Int32 id_nomina, Int32 folio, string cuenta_usuario)
        {
            List<Operacion> loperacion = new OperacionDAC().getOperacionesbynominagasto(id_nomina, folio, cuenta_usuario);
            return loperacion;
        }

        public Int32 add_operacion(Int32 id_solicitud, Int16 id_cliente, string tipo_operacion, string cuenta_usuario, Int32 id_referencia, string n_interno, Int32 id_sucursal, Int32 n_factura , string observacion = "")
		//public Int32 add_operacion(Int32 id_solicitud, Int16 id_cliente, string tipo_operacion, string cuenta_usuario, Int32 id_referencia, string proceso_AGP)
		{
			//Int32 add = new OperacionDAC().add_operacion(id_solicitud, id_cliente, tipo_operacion, cuenta_usuario, id_referencia, proceso_AGP);
			Int32 add = new OperacionDAC().add_operacion(id_solicitud, id_cliente, tipo_operacion, cuenta_usuario, id_referencia,n_interno,id_sucursal,n_factura,observacion);

            //if (add != 0)
            //{
            //    this.add_XML_NAV_DIMENSION(add); 
            //}
            
            return add;
		}

        public Int32 actualiza_producto(Int32 id_solicitud, string tipo_operacion, string cuenta_usuario, string financiera)
        //public Int32 add_operacion(Int32 id_solicitud, Int16 id_cliente, string tipo_operacion, string cuenta_usuario, Int32 id_referencia, string proceso_AGP)
        {
            Int32 add = new OperacionDAC().actualiza_producto(id_solicitud, tipo_operacion, cuenta_usuario,financiera);
                return add;

        }

        private void add_XML_NAV_DIMENSION(Int32 id_solicitud)
        {


            MemoryStream m = new MemoryStream();

            XmlTextWriter xml = new XmlTextWriter(m, System.Text.Encoding.UTF8);
            
            	try
				{
            
            xml.Formatting = Formatting.Indented;
            xml.Namespaces = true;
            xml.WriteStartDocument(false);
            xml.WriteStartElement("Root");
            xml.WriteStartElement("DimensionValue");
            xml.WriteElementString("No", id_solicitud.ToString().Trim());
            xml.WriteElementString("CodigoDimension", "OPERACION");
            xml.WriteElementString("Codigo", id_solicitud.ToString().Trim()  );
            xml.WriteEndElement();

            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();

            m.Position = 0;
            string r = new StreamReader(m).ReadToEnd();

            xml.Close();
            m.Close();


            string strPath = System.Configuration.ConfigurationManager.AppSettings["DIMENSION"];


            string path = strPath + id_solicitud + "_" + DateTime.Now.ToString("dd-MM-yy") + ".xml";
            XmlDataDocument xmDoc = new XmlDataDocument();
            xmDoc.LoadXml(r);
            xmDoc.Save(path);
                }
                catch (Exception ex)
                {
                    return;
                }
        
        }

		public string del_operacion(Int32 id_solicitud,string usuario)
		{
			string add = new OperacionDAC().del_peracion(id_solicitud,usuario);
			return add;
		}

		public List<Control_gestion> getOperacionesbyCG(string tipo_operacion, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_deudor, string numero_cliente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario, string check_llamada)
		{
			List<Control_gestion> loperacion = new OperacionDAC().getOperacionesbyGestionControl(tipo_operacion, id_sucursal, id_cliente, numero_operacion, rut_deudor, numero_cliente, desde, hasta, ultimo_estado, cuenta_usuario, check_llamada);
			return loperacion;
		}

		public List<Transferencia> getOperacionesbyTR(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario)
		{
			List<Transferencia> loperacion = new OperacionDAC().getOperacionesTR(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, ultimo_estado, cuenta_usuario);
			return loperacion;
		}

		public List<Transferencia> getOperacionesbyStockVenta(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario)
		{
			List<Transferencia> loperacion = new OperacionDAC().getOperacionesSocktVenta(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, ultimo_estado, cuenta_usuario);
			return loperacion;
		}

		public Operacion getoperacion(Int32 id_solicitud)
		{
			Operacion mOperacion = new OperacionDAC().getOperacion(id_solicitud);
			return mOperacion;
		}

        public Operacion getoperacionfacxml(Int32 id_solicitud)
        {
            Operacion mOperacion = new OperacionDAC().getOperacionesbyoperfacxml(id_solicitud);
            return mOperacion;
        }

        public Operacion getOperacionCreacionNomina(Int32 id_solicitud, Int32 id_cliente,Int32 id_familia)
        {
            Operacion mOperacion = new OperacionDAC().getOperacionCreacionNomina(id_solicitud, id_cliente, id_familia);
            return mOperacion;
        }
        public Operacion getCruceFactura(Int32 factura, Int32 id_cliente, Int32 id_familia)
        {
            Operacion mOperacion = new OperacionDAC().getCruceFactura(factura, id_cliente, id_familia);
            return mOperacion;
        }


		public List<Operacion> getOperacionesfacturacion(Int32 folio, string desde, string hasta, Int32 id_familia, Int32 id_nomina, string id_factura, Int32 factura_agp)
		{
			List<Operacion> loperacion = new OperacionDAC().getOperacionesfacturacion(folio, desde, hasta, id_familia, id_nomina, id_factura, factura_agp);
			return loperacion;
		}

		public List<Operacion> getOperacionesGA(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, string cuenta_usuario)
		{
			return new OperacionDAC().getOperacionesGA(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, cuenta_usuario);
		}

		public List<Operacion> getOperacionesGA_Pendientes(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, string cuenta_usuario)
		{
			return new OperacionDAC().getOperacionesGA_Pendientes(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, cuenta_usuario);
		}

		public List<Transferencia> getOperacionesVenta(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, Int32 rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario)
		{
			List<Transferencia> loperacion = new OperacionDAC().getOperacionesVenta(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, ultimo_estado, cuenta_usuario);
			return loperacion;
		}

		public List<Operacion> getOperaciones_patente(string tipo_operacion, Int16 id_modulo, Int16 id_sucursal, Int16 id_cliente, Int32 numero_operacion, double rut_adquiriente, Int32 numero_factura, string numero_cliente, string patente, string desde, string hasta, Int32 ultimo_estado, string cuenta_usuario, Int32 id_familia)
		{
			List<Operacion> loperacion = new OperacionDAC().getOperaciones_patente(tipo_operacion, id_modulo, id_sucursal, id_cliente, numero_operacion, rut_adquiriente, numero_factura, numero_cliente, patente, desde, hasta, ultimo_estado, cuenta_usuario, id_familia);
			return loperacion;
		}

		public List<Operacion> getOperacionesParaNomina(int id_nomina, int id_cliente, DateTime desde, DateTime hasta, string cuenta_usuario)
		{
			return new OperacionDAC().getOperacionesParaNomina(id_nomina, id_cliente, desde, hasta, cuenta_usuario);
		}

		public List<OperacionPeru> getOperacionesfacturacionPeru(Int32 folio, string desde, string hasta, Int32 id_familia, Int32 id_nomina, string id_factura, Int32 factura_agp)
		{
			List<OperacionPeru> loperacion = new OperacionDAC().getOperacionesfacturacionPeru(folio, desde, hasta, id_familia, id_nomina, id_factura, factura_agp);
			return loperacion;
		}

		public List<Operacion> getCreditosBCA()
		{
			return new OperacionDAC().getOperacionesBCA();
		}

         public List<Operacion> Operacionesnomina_desde_hasta(Int32 id_familia, Int32 id_cliente, string desde, string hasta)
        {
            List<Operacion> loperacion = new OperacionDAC().Operacionesnomina_desde_hasta(id_familia, id_cliente, desde, hasta);
            return loperacion;
        }

        public List<Operacion> get_ChequeInventario()
        {
            return new OperacionDAC().get_ChequeInventario();
        }

        
        public Int32 Actualizar_ChequeInventario(Int32 folio, Int32 id_inventario,Int32 id_nomina)
        {
            Int32 add = new OperacionDAC().Actualizar_ChequeInventario(folio, id_inventario, id_nomina);
            return add;
        }


        public List<Operacion> getOperacionesbynominaExpressacum(Int32 id_nomina, Int32 folio, string cuenta_usuario)
        {
            List<Operacion> loperacion = new OperacionDAC().getOperacionesbynominaExpressacum(id_nomina, folio, cuenta_usuario);
            return loperacion;
        }


	}

	
}