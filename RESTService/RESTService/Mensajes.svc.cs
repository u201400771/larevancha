using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTService
{
    public class Mensajes : IMensajes
    {
        public string ObtenerSaludo()
        {

            HttpWebRequest req = WebRequest.Create("http://localhost:9550/MensageHora.svc/ObtenerHora") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            int horasola = int.Parse(reader.ReadToEnd());
            
            if (horasola < 12)
                return "Buenos dias son las " + horasola.ToString();
            else if (horasola < 19)
                return "Buenas tardes son las " + horasola.ToString(); 
                else return "Buenas noches son las " + horasola.ToString();
        }

    }
}
