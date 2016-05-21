using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace RestTests
{
    [TestClass]
    public class MensajesTest
    {
        [TestMethod]
        public void ObtenerSaludoTest()
        {
            HttpWebRequest req = WebRequest.Create("http://localhost:9550/Mensajes.svc/ObtenerSaludo") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string saludo = reader.ReadToEnd();
            int hora = DateTime.Now.Hour;
            if (hora < 12)
                Assert.AreEqual(saludo, "\"Buenos dias\"");
            else if (hora <19)
                Assert.AreEqual(saludo, "\"Buenas tardes\"");
            else
                Assert.AreEqual(saludo, "\"Buenas noches\"");
        }

    }
}

