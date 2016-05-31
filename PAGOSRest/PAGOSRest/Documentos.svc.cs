using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PAGOSRest.Dominio;
using PAGOSRest.Persistencia;
using System.ServiceModel.Web;
using System.Net;

namespace PAGOSRest
{
    public class Documentos : IDocumentos
    {
        private DocumentoDAO dao = new DocumentoDAO();

        public Documento CrearDocumento(Documento documentoACrear)
        {

            Documento DocumentoObtenido = dao.Obtener(documentoACrear.numero_documento);

            if (DocumentoObtenido != null)
            {
                throw new WebFaultException<string>(
                    "El cliente con codigo " + documentoACrear.numero_documento + " ya existe", HttpStatusCode.InternalServerError);
            }
            return dao.Crear(documentoACrear);
        }

        public Documento ObtenerDocumento(string ruc)
        {
            return dao.Obtener(ruc);
        }

        public Documento ModificarDocumento(Documento documentoAModificar)
        {
            return dao.Modificar(documentoAModificar);
        }

        public void EliminarDocumento(string numero_documento)
        {
            Documento documentoEncontrado = null;
            documentoEncontrado = ObtenerDocumento(numero_documento);

            if (documentoEncontrado.estado == "PAG")
            {
                throw new WebFaultException<string>("El documento ya se encuentra pagado", HttpStatusCode.NotImplemented);
            }

            dao.Eliminar(numero_documento);
        }

        public List<Documento> ListarADocumentos()
        {
            return dao.listar();
        }

    }
}
