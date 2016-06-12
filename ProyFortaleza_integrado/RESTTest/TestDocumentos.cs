using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace RESTTest
{
    [TestClass]
    public class TestDocumentos
    {
        [TestMethod]
        public void TestCrearDocumentos()
        {
            string postdata = "{\"ruc\":\"20100130201\",\"numero_documento\":\"F1110000081\",\"tipo_documento\":\"FAC\",\"fecha_emision\":\"01-01-2016\",\"fecha_vencimiento\":\"01-01-2016\",\"moneda\":\"SOL\",\"glosa\":\"HOLA\",\"importe\":\"1400\",\"estado\":\"EMI\"}";
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
            Documento documentoCreado = js.Deserialize<Documento>(postdata);
            Assert.AreEqual("20100130201", documentoCreado.ruc);
            Assert.AreEqual("F1110000001", documentoCreado.numero_documento);
            Assert.AreEqual("FAC", documentoCreado.tipo_documento);
            Assert.AreEqual("01-01-2016", documentoCreado.fecha_emision);
            Assert.AreEqual("01-01-2016", documentoCreado.fecha_vencimiento);
            Assert.AreEqual("SOL", documentoCreado.moneda);
            Assert.AreEqual("HOLA", documentoCreado.glosa);
            Assert.AreEqual(1400, documentoCreado.importe);
            Assert.AreEqual("EMI", documentoCreado.estado);

        }

        [TestMethod]
        public void TestCrearClienteException()
        {
            string postdata = "{\"ruc\":\"20100130211\",\"numero_documento\":\"F1110000061\",\"tipo_documento\":\"FAC\",\"fecha_emision\":\"01-01-2016\",\"fecha_vencimiento\":\"01-01-2016\",\"moneda\":\"SOL\",\"glosa\":\"HOLA\",\"importe\":\"1400\",\"estado\":\"EMI\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string documentoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Documento documentoCreado = js.Deserialize<Documento>(postdata);
                Assert.AreEqual("20100130201", documentoCreado.ruc);
                Assert.AreEqual("F1110000001", documentoCreado.numero_documento);
                Assert.AreEqual("FAC", documentoCreado.tipo_documento);
                Assert.AreEqual("01-01-2016", documentoCreado.fecha_emision);
                Assert.AreEqual("01-01-2016", documentoCreado.fecha_vencimiento);
                Assert.AreEqual("SOL", documentoCreado.moneda);
                Assert.AreEqual("HOLA", documentoCreado.glosa);
                Assert.AreEqual(1400, documentoCreado.importe);
                Assert.AreEqual("EMI", documentoCreado.estado);
            }
            catch (WebException w)
            {
                HttpStatusCode code = ((HttpWebResponse)w.Response).StatusCode;
                String mensaje = ((HttpWebResponse)w.Response).StatusDescription;
                StreamReader sr = new StreamReader(w.Response.GetResponseStream());
                string error = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensajeException = js.Deserialize<string>(error);
                Assert.AreEqual("El cliente con codigo F1110000001 ya existe", mensajeException);

            }


        }

        [TestMethod]
        public void TestObtenerDocumento()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.
                Create("http://localhost:1951/Documentos.svc/Documentos/F1110000001");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string documentoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Documento documentoObtenido = js2.Deserialize<Documento>(documentoJson2);
            Assert.AreEqual("20100130201", documentoObtenido.ruc);
            Assert.AreEqual("F1110000001", documentoObtenido.numero_documento);
            Assert.AreEqual("FAC", documentoObtenido.tipo_documento);
            Assert.AreEqual("01-01-2016", documentoObtenido.fecha_emision);
            Assert.AreEqual("01-01-2016", documentoObtenido.fecha_vencimiento);
            Assert.AreEqual("SOL", documentoObtenido.moneda);
            Assert.AreEqual("HOLA", documentoObtenido.glosa);
            Assert.AreEqual(1400, documentoObtenido.importe);
            Assert.AreEqual("EMI", documentoObtenido.estado);

        }

        [TestMethod]
        public void TestEliminarDocumento()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos/F1110000001");
            req.Method = "DELETE";
            try
            {
                req.GetResponse();

                HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos/F1110000001");
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string documentoJson2 = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Documento documentoObtenido = js2.Deserialize<Documento>(documentoJson2);
                Assert.AreEqual(null, documentoObtenido);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("El documento ya se encuentra pagado", mensaje);
            }
        }

        [TestMethod]
        public void TestEliminarExceptionGiradoPagado()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos/F1110000002");
            req.Method = "DELETE";
            try
            {
                req.GetResponse();
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("El documento ya se encuentra pagado", mensaje);
            }
        }

        [TestMethod]
        public void TestModificarDocumento()
        {
            string postdata = "{\"ruc\":\"20100130201\",\"numero_documento\":\"F1110000001\",\"tipo_documento\":\"FAC\",\"fecha_emision\":\"01-01-2016\",\"fecha_vencimiento\":\"31-01-2016\",\"moneda\":\"SOL\",\"glosa\":\"HOLA\",\"importe\":\"1500\",\"estado\":\"EMI\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length); 
            var res = (HttpWebResponse)req.GetResponse(); 
            StreamReader reader = new StreamReader(res.GetResponseStream()); 
            string documentoJson = reader.ReadToEnd(); 
            JavaScriptSerializer js = new JavaScriptSerializer(); 
            Documento documentoModificado = js.Deserialize<Documento>(documentoJson); 
            Assert.AreEqual("20100130201", documentoModificado.ruc);
            Assert.AreEqual("F1110000001", documentoModificado.numero_documento);
            Assert.AreEqual("FAC", documentoModificado.tipo_documento);
            Assert.AreEqual("01-01-2016", documentoModificado.fecha_emision);
            Assert.AreEqual("31-01-2016", documentoModificado.fecha_vencimiento);
            Assert.AreEqual("SOL", documentoModificado.moneda);
            Assert.AreEqual("HOLA", documentoModificado.glosa); 
            Assert.AreEqual(1500, documentoModificado.importe);
            Assert.AreEqual("EMI", documentoModificado.estado); 
        }

        
    }
}

