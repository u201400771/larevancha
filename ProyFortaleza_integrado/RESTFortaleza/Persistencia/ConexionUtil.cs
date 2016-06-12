using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTFortaleza.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return "Data Source=HN060851\\SQLEXPRESS;Initial Catalog=TRABAJO_DSD;Integrated Security=SSPI;";
            }
        }

        public static string CadenaClientes
        {
            get
            {
                return "Data Source=HN060851\\SQLEXPRESS;Initial Catalog=TRABAJO_DSD;Integrated Security=SSPI;";
            }
        }
    }
}

/*
/*


 [TestMethod]
        public void TestModificarProducto()
        {
            // Prueba de modificacion de producto via HTTP PUT
            string postdata = "{\"Co_Producto\":\"1\",\"No_Producto\":\"TV LCD 40 PULG.\",\"Ss_Precio\":\"2699.99\",\"Qt_Stock\":\"250\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:32641/Productos.svc/Productos");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Producto productoModificado = js.Deserialize<Producto>(productoJson);
            Assert.AreEqual("TV LCD 40 PULG.", productoModificado.No_Producto);
            Assert.AreEqual(2699.99m, productoModificado.Ss_Precio);
            Assert.AreEqual(250, productoModificado.Qt_Stock);
        }
 
        [TestMethod]
        public void TestEliminarProducto()
        {
            // Prueba de eliminacion de producto via HTTP GET
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:32641/Productos.svc/Productos/2");
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
 
            // Prueba de obtencion de producto via HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:32641/Productos.svc/Productos/2");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string productoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Producto productoEliminado = js2.Deserialize<Producto>(productoJson2);
            Assert.IsNull(productoEliminado);
        }
 
        [TestMethod]
        public void TestListarProductos()
        {
            // Prueba de obtencion de producto via HTTP LIST
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:32641/Productos.svc/Productos");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string productosJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Producto> productosObtenidos = js.Deserialize<List<Producto>>(productosJson);
            Assert.AreEqual(2, productosObtenidos.Count);
        }
*/
