using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTService
{
    [ServiceContract]
    public interface IMensajes
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string ObtenerSaludo();



        }
}
