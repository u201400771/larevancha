using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTest
{
    [TestClass]
    public class TextDocumeto
    {
        [TestMethod]
        public void CRUDTest()
        {

            string postdata = "{\"ruc\":\"123\",\"nombre\":\"123\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string documentoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Documento documentoCreado = js.Deserialize<Documento>(documentoJson);
            Assert.AreEqual("123", documentoCreado.ruc);
            Assert.AreEqual("123", documentoCreado.numero_documento);




        }
    }
}
