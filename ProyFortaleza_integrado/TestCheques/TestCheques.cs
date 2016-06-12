using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTest
{

    [TestClass]
    public class TestCheques
    {

        [TestMethod]
        public void CrearCheques()
        {

            string postdata = "{\"NUMERO_CHEQUE\":\"550\",\"RUC\":\"2123456789\",\"CODIGO_BANCO\":\"BVA\",\"FECHA_EMISION\":\"01-01-2016\",\"MONEDA\":\"SOL\",\"IMPORTE_TOTAL\":\"200.00\",\"ESTADO\":\"GIR\",\"TIPO_DOCUMENTO\":\"FAC\",\"NUMERO_DOCUMENTO\":\"001-9999\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:55017/Cheques.svc/Cheques");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string documentoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cheque chequeCreado = js.Deserialize<Cheque>(postdata);
            Assert.AreEqual("550", chequeCreado.NUMERO_CHEQUE);
            Assert.AreEqual("2123456789", chequeCreado.RUC);
            Assert.AreEqual("BVA", chequeCreado.CODIGO_BANCO);
            Assert.AreEqual("01-01-2016", chequeCreado.FECHA_EMISION);
            Assert.AreEqual("SOL", chequeCreado.MONEDA);
            Assert.AreEqual("200.00", chequeCreado.IMPORTE_TOTAL.ToString());
            Assert.AreEqual("GIR", chequeCreado.ESTADO);
            Assert.AreEqual("FAC", chequeCreado.TIPO_DOCUMENTO);
            Assert.AreEqual("001-9999", chequeCreado.NUMERO_DOCUMENTO);
        }

        [TestMethod]
        public void TestObtenerCheque()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.
                Create("http://localhost:55017/Cheques.svc/Cheques/100");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string documentoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Cheque chequeObtenido = js2.Deserialize<Cheque>(documentoJson2);
            Assert.AreEqual("100", chequeObtenido.NUMERO_CHEQUE);
            Assert.AreEqual("20100130201", chequeObtenido.RUC);
            Assert.AreEqual("BCP", chequeObtenido.CODIGO_BANCO);
            Assert.AreEqual("2016-05-05", chequeObtenido.FECHA_EMISION);
            Assert.AreEqual("SOL", chequeObtenido.MONEDA);
            Assert.AreEqual("100.00", chequeObtenido.IMPORTE_TOTAL.ToString());
            Assert.AreEqual("GIR", chequeObtenido.ESTADO);
        }

        [TestMethod]
        public void TestEliminarCheque()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:55017/Cheques.svc/ChequesE/900");
            req.Method = "DELETE";
            try
            {
                req.GetResponse();

                HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:55017/Cheques.svc/Cheques/900");
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string documentoJson2 = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Cheque chequeObtenido = js2.Deserialize<Cheque>(documentoJson2);
                Assert.AreEqual(null, chequeObtenido);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("El cheque no existe", mensaje);
            }
        }

        [TestMethod]
        public void TestModificarCheque()
        {
            string postdata = "{\"NUMERO_CHEQUE\":\"400\",\"RUC\":\"2999999999\",\"CODIGO_BANCO\":\"BVA\",\"FECHA_EMISION\":\"01-01-2016\",\"MONEDA\":\"USD\",\"IMPORTE_TOTAL\":\"300.00\",\"ESTADO\":\"GIR\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:55017/Cheques.svc/Cheques");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string documentoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cheque chequeModificado = js.Deserialize<Cheque>(documentoJson);
            Assert.AreEqual("400", chequeModificado.NUMERO_CHEQUE);
            Assert.AreEqual("2999999999", chequeModificado.RUC);
            Assert.AreEqual("BVA", chequeModificado.CODIGO_BANCO);
            Assert.AreEqual("01-01-2016", chequeModificado.FECHA_EMISION);
            Assert.AreEqual("USD", chequeModificado.MONEDA);
            Assert.AreEqual("300.00", chequeModificado.IMPORTE_TOTAL.ToString());
            Assert.AreEqual("GIR", chequeModificado.ESTADO);
        }


    }
}
