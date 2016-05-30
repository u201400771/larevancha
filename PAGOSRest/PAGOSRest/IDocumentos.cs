using PAGOSRest.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PAGOSRest
{
    [ServiceContract]
    public interface IDocumentos
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Documentos", ResponseFormat = WebMessageFormat.Json)]
        Documento CrearDocumento(Documento documentoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Documentos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Documento ObtenerDocumento(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Documentos", ResponseFormat = WebMessageFormat.Json)]
        Documento ModificarDocumento(Documento documentoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Documentos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarDocumento(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Documentos", ResponseFormat = WebMessageFormat.Json)]
        List<Documento> ListarADocumentos();
    }
}
