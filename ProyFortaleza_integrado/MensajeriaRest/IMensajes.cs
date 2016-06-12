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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMensajes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMensajes
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Mensajes", ResponseFormat = WebMessageFormat.Json)]
        List<Mensaje> ListarMensaje();
    }
}
