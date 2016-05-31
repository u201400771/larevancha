using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTest
{
    [TestClass]
    public class TextDocumento
    {
        [TestMethod]
        public void CRUDTest()

        {
            string postdata = "{\"ruc\":\"123\",\"numero_documento\":\"123\",\"TIPO_DOCUMENTO\":\"123\",\"FECHA_EMISION\":\"23-02-1982\",\"FECHA_VENCIMIENTO\":\"23-02-1982\",\"MONEDA\":\"1\",\"GLOSA\":\"123\",\"IMPORTE\":\"12.0\",\"ESTADO\":\"1\"}";
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
            Assert.AreEqual("123", documentoCreado.tipo_documento);
            Assert.AreEqual("23-02-1982", documentoCreado.fecha_emision);
            Assert.AreEqual("23-02-1982", documentoCreado.fecha_vencimiento);
            Assert.AreEqual("1", documentoCreado.moneda);
            Assert.AreEqual("123", documentoCreado.glosa);
            Assert.AreEqual("12.0", documentoCreado.importe);
            Assert.AreEqual("1", documentoCreado.estado);




        }
    }
}
