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
            string postdata = "{\"ruc\":\"20100130201\",\"numero_documento\":\"F1110000001\",\"tipo_documento\":\"FAC\",\"fecha_emision\":\"01-01-2016\",\"fecha_vencimiento\":\"01-01-2016\"\"moneda\":\"SOL\",\"glosa\":\"HOLA\",\"importe\":\"1400\",\"estado\":\"EMI\"}";
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
            string postdata = "{\"codigo\":\"111111\",\"nombre\":\"JUAN\",\"direccion\":\"CUZCO\"}";
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
                Assert.AreEqual("111111", documentoCreado.ruc);
                Assert.AreEqual("JUAN", documentoCreado.numero_documento);
                Assert.AreEqual("CUZCO", documentoCreado.tipo_documento);
            }
            catch (WebException w)
            {
                HttpStatusCode code = ((HttpWebResponse)w.Response).StatusCode;
                String mensaje = ((HttpWebResponse)w.Response).StatusDescription;
                StreamReader sr = new StreamReader(w.Response.GetResponseStream());
                string error = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensajeException = js.Deserialize<string>(error);
                Assert.AreEqual("El cliente con codigo 111111 ya existe", mensajeException);

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
            Assert.AreEqual("20515995197", documentoObtenido.ruc);
            Assert.AreEqual("F1110000001", documentoObtenido.numero_documento);
            Assert.AreEqual("FAC", documentoObtenido.tipo_documento);
            Assert.AreEqual("05/05/2016 05:00:00 a.m.", documentoObtenido.fecha_emision.ToString());
            Assert.AreEqual("05/05/2016 05:00:00 a.m.", documentoObtenido.fecha_vencimiento.ToString());
            Assert.AreEqual("SOL", documentoObtenido.moneda);
            Assert.AreEqual("LUZ", documentoObtenido.glosa);
            Assert.AreEqual(1000, documentoObtenido.importe);
            Assert.AreEqual("EMI", documentoObtenido.estado);

        }

        [TestMethod]
        public void TestModificarCliente()
        {
            string postdata = "{\"codigo\":\"111111\",\"nombre\":\"HHHHHH\",\"direccion\":\"LIMA\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.
                Create("http://localhost:1951/Clientes.svc/Clientes");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string clienteJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Documento documentoModificado = js.Deserialize<Documento>(clienteJson);
            Assert.AreEqual("111111", documentoModificado.ruc);
            Assert.AreEqual("HHHHHH", documentoModificado.numero_documento);
            Assert.AreEqual("LIMA", documentoModificado.tipo_documento);
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
                string proveedorJson2 = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Documento documentoObtenido = js2.Deserialize<Documento>(proveedorJson2);
                Assert.AreEqual("", documentoObtenido.ruc);
                Assert.AreEqual("", documentoObtenido.numero_documento);
                Assert.AreEqual("", documentoObtenido.tipo_documento);
                Assert.AreEqual("", documentoObtenido.fecha_emision);
                Assert.AreEqual("", documentoObtenido.fecha_vencimiento);
                Assert.AreEqual("", documentoObtenido.moneda);
                Assert.AreEqual("", documentoObtenido.glosa);
                Assert.AreEqual("", documentoObtenido.importe);
                Assert.AreEqual("", documentoObtenido.estado);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Documento no encontrado", mensaje);
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
    }
}

