//Desarrollado por Oscar Fabian
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CrearProveedorOk()
        {
            ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
            ProveedoresWS.Proveedor proveedorCreado = proxy.CrearProveedor(new ProveedoresWS.Proveedor()
            {
                Ruc = "20453423411",
                Tipo = "Jurídica",
                RazonSocial = "Altavista SAC",
                Telefono = "934253642",
                Email = "sac@altavistasac.com.pe"
            });
            Assert.AreEqual("20453423411", proveedorCreado.Ruc);
            Assert.AreEqual("Jurídica", proveedorCreado.Tipo);
            Assert.AreEqual("Altavista SAC", proveedorCreado.RazonSocial);
            Assert.AreEqual("934253642", proveedorCreado.Telefono);
            Assert.AreEqual("sac@altavistasac.com.pe", proveedorCreado.Email);
        }

        [TestMethod]
        public void Test2CrearProveedorRepetido()
        {
            ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
            try
            {
                ProveedoresWS.Proveedor proveedorCreado = proxy.CrearProveedor(new ProveedoresWS.Proveedor()
                {
                    Ruc = "20100130201",
                    Tipo = "Jurídica",
                    RazonSocial = "Altavista SAC",
                    Telefono = "934253642",
                    Email = "sac@altavistasac.com.pe"
                });
            }
            catch (FaultException<ProveedoresWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El proveedor ya existe");
            }
        }
        [TestMethod]
        public void Test3ObtenerProveedorOk()
        {
            ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
            ProveedoresWS.Proveedor proveedorEncontrado = proxy.ObtenerProveedor("20453423411");
            Assert.AreEqual("20453423411", proveedorEncontrado.Ruc);
            Assert.AreEqual("Jurídica", proveedorEncontrado.Tipo);
            Assert.AreEqual("Altavista SAC", proveedorEncontrado.RazonSocial);
            Assert.AreEqual("934253642", proveedorEncontrado.Telefono);
            Assert.AreEqual("sac@altavistasac.com.pe", proveedorEncontrado.Email);
        }
        [TestMethod]
        public void Test4ModificarProveedorOk()
        {
            ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
            ProveedoresWS.Proveedor proveedoModificado = proxy.ModificarProveedor(new ProveedoresWS.Proveedor()
            {
                Ruc = "20453423411",
                Tipo = "Jurídica",
                RazonSocial = "Altavista SAC",
                Telefono = "5323423",
                Email = "sap@altavistasac.com"
            });
            Assert.AreEqual("20453423411", proveedoModificado.Ruc);
            Assert.AreEqual("Jurídica", proveedoModificado.Tipo);
            Assert.AreEqual("Altavista SAC", proveedoModificado.RazonSocial);
            Assert.AreEqual("5323423", proveedoModificado.Telefono);
            Assert.AreEqual("sap@altavistasac.com", proveedoModificado.Email);
        }
        [TestMethod]
        public void Test5ListarProveedorOk()
        {
            ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
            ProveedoresWS.Proveedor[] proveedorEncontrado = proxy.ListarProveedores();
            Assert.AreEqual("10450963041", proveedorEncontrado[0].Ruc);
            Assert.AreEqual("Natural", proveedorEncontrado[0].Tipo);
            Assert.AreEqual("Oscar Fabián", proveedorEncontrado[0].RazonSocial);
            Assert.AreEqual("966392383", proveedorEncontrado[0].Telefono);
            Assert.AreEqual("oscare.fabiang@gmail.com", proveedorEncontrado[0].Email);
            Assert.AreEqual("20453423411", proveedorEncontrado[1].Ruc);
            Assert.AreEqual("Jurídica", proveedorEncontrado[1].Tipo);
            Assert.AreEqual("Altavista SAC", proveedorEncontrado[1].RazonSocial);
            Assert.AreEqual("5323423", proveedorEncontrado[1].Telefono);
            Assert.AreEqual("sap@altavistasac.com", proveedorEncontrado[1].Email);
        }
        
        [TestMethod]
        public void Test6EliminarProveedorOk()
        {
            try
            {
                ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
                proxy.EliminarProveedor("20453423411");
                ProveedoresWS.Proveedor proveedorEncontrado = proxy.ObtenerProveedor("20453423411");
            }
            catch (FaultException<ProveedoresWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El proveedor ya existe");
            }
        }
    }
}
