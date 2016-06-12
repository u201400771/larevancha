using MensajeriaRest.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MensajeriaRest
{
    
    [ServiceContract]
    public interface IMensajes
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Mensajes", ResponseFormat = WebMessageFormat.Json)]
        List<Mensaje> ListarMensaje();
    }
}
