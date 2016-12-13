using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO {
	public class DocumentosBC {

        public Documentos getDocumentosbyID(Int16 id_tipo)
        {

            Documentos mdoc = new DocumentosDAC().getDocumentosbyID(id_tipo);
            return mdoc;   
        }
        public List<Documentos> GetDocumentosbyOrdenTrabajo(int idOt)
        {
            return new DocumentosDAC().GetDocumentosbyOrdenTrabajo(idOt);
        }

	    public List<Documentos> getallDocumentos() {
            List<Documentos> lDocumentos = new DocumentosDAC().getAllDocumentos();
			return lDocumentos;
		}

		public List<Documentos> getDocumentosByProductos(string codigo,Int32 id_documento) {
			List<Documentos> lDocumentos = new DocumentosDAC().getDocumentosbyProducto(codigo,id_documento);
			return lDocumentos;
		}

		public List<Documentos> getDocumentosAsociadosProducto(string codigo) {
			List<Documentos> lDocumentos = new DocumentosDAC().getDocumentosAsociadosProducto(codigo);
			return lDocumentos;
		}

		public List<Documentos> getDocumentos(string tipo) {
			List<Documentos> lDocumentos = new DocumentosDAC().getDocumentos(tipo);
			return lDocumentos;
		}

		public string add_documentos(string nombre) {
			string add = new DocumentosDAC().add_documentos(nombre);
			return add;
		}

		public string add_documento_check(string codigo, Int32 id_documento) {
			string add = new DocumentosDAC().add_documento_check(codigo, id_documento);
			return add;
		}

		public string del_documento_check(string codigo, Int32 id_documento) {
			string del = new DocumentosDAC().del_documento_check(codigo, id_documento);
			return del;
		}

		public string upd_documento_publico(Int32 id_documento, Boolean publico) {
			return new DocumentosDAC().upd_documento_publico(id_documento, publico);
		}
	}
}