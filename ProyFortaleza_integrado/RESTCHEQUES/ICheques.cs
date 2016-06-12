using RESTCHEQUES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTCHEQUES
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICheques" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICheques
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Cheques", ResponseFormat = WebMessageFormat.Json)]
        Cheque CrearCheque(Cheque documentoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Cheques/{NUMERO_CHEQUE}", ResponseFormat = WebMessageFormat.Json)]
        Cheque ObtenerCheque(string NUMERO_CHEQUE);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Cheques", ResponseFormat = WebMessageFormat.Json)]
        Cheque ModificarCheque(Cheque chequeAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "ChequesE/{NUMERO_CHEQUE}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCheque(string NUMERO_CHEQUE);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Cheques", ResponseFormat = WebMessageFormat.Json)]
        List<Cheque> ListarACheques();
    }
}
