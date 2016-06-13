/****************IMPLEMENTACION DE WS SOA*************************/
/************** Pantalla Provedor Proveedor.aspx.cs ****************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Maestro_Proveedor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listarPersona();
            listarProveedor();
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
        }
        lblMensaje.Text = "";
    }

    private void listarPersona()
    {
        DataTable dtPersona = new DataTable();
        dtPersona.Columns.Add("IdPersona");
        dtPersona.Columns.Add("DesPersona");

        DataRow drPersona;
        drPersona = dtPersona.NewRow(); drPersona["IdPersona"] = 0; drPersona["DesPersona"] = "Seleccione..."; dtPersona.Rows.Add(drPersona);
        drPersona = dtPersona.NewRow(); drPersona["IdPersona"] = 1; drPersona["DesPersona"] = "Natural"; dtPersona.Rows.Add(drPersona);
        drPersona = dtPersona.NewRow(); drPersona["IdPersona"] = 2; drPersona["DesPersona"] = "Juridica"; dtPersona.Rows.Add(drPersona);

        ddlPersona.DataSource = dtPersona;
        ddlPersona.DataTextField = "DesPersona";
        ddlPersona.DataValueField = "IdPersona";
        ddlPersona.DataBind();
    }
    protected void ibtnRuc_Click(object sender, ImageClickEventArgs e)
    {
        CargarGrilla();       
    }

    private void CargarGrilla()
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        List<ServiceReference1.Proveedor> objs = client.ListarProveedores();
        gvResultados.DataSource = objs;
        gvResultados.DataBind(); 
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        txtIdRuc.Text = "";
        txtRazSocial.Text = "";
        txtDireccion.Text = "";
        txtMail.Text = "";
        txtTelefono.Text = "";
        ddlPersona.SelectedValue= "0";
        btnGrabar.Enabled = true;
        txtIdRuc.Enabled = true;

        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();        

    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        ServiceReference1.Proveedor obj = new ServiceReference1.Proveedor();
        obj.RazonSocial = txtRazSocial.Text;
        obj.Ruc = txtIdRuc.Text;
        obj.Email = txtMail.Text;
        obj.Telefono = txtTelefono.Text ;
        obj.Tipo = obtenerTipo(ddlPersona.SelectedValue.ToString());
        obj.Direccion = txtDireccion.Text;
        ServiceReference1.Proveedor obj2 = new ServiceReference1.Proveedor();
        obj2 = client.ModificarProveedor(obj);
        if (obj2.Equals(null)) lblMensaje.Text = "Error Actualizar Proveedor";
        if (!obj2.Equals(null)) lblMensaje.Text = "Proveedor Actualizado";
        CargarGrilla();

    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        ServiceReference1.Proveedor obj = new ServiceReference1.Proveedor();
        obj.Email = txtMail.Text;
        obj.RazonSocial = txtRazSocial.Text;
        obj.Ruc = txtIdRuc.Text;
        obj.Telefono = txtTelefono.Text;
        obj.Tipo = obtenerTipo(ddlPersona.SelectedValue.ToString());
        obj.Direccion = txtDireccion.Text;

        lblMensaje.Text = client.CrearProveedorString(obj);
        //ServiceReference1.Proveedor objProv = new ServiceReference1.Proveedor();
        //objProv = client.CrearProveedor(obj);
        
        CargarGrilla();        
    }

    private string obtenerTipo(string idTipo)
    {
        if (idTipo.Equals("1")) return "Natural";
        else if (idTipo.Equals("2")) return "Juridica";
        else if (idTipo.Substring(0,1).Equals("N")) return "1";
        else if (idTipo.Substring(0,1).Equals("J")) return "2";
        else return "0";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se eliminó correctamente";
    }
    protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            btnEditar.Enabled = true;
            txtIdRuc.Enabled = false;
            ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
            int index = Convert.ToInt32(e.CommandArgument);
            string codigo = gvResultados.Rows[index].Cells[2].Text;

            ServiceReference1.Proveedor obj=  client.ObtenerProveedor(codigo);
            
            txtRazSocial.Text = obj.RazonSocial;
            txtIdRuc.Text = obj.Ruc;
            txtMail.Text = obj.Email;
            txtTelefono.Text = obj.Telefono;
            txtDireccion.Text = obj.Direccion;
            ddlPersona.SelectedValue = obtenerTipo(obj.Tipo);

            btnGrabar.Enabled = true;

        }
        else if (e.CommandName == "Eliminar")
        {

            ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
            int index = Convert.ToInt32(e.CommandArgument);
            string codigo = gvResultados.Rows[index].Cells[2].Text;

            ServiceReference1.Proveedor obj = client.ObtenerProveedor(codigo);
            int val = client.EliminarProveedor(codigo);
            if (val.Equals(1)) { lblMensaje.Text = "No se pudo eliminar"; }
            else if (val.Equals(0)) { lblMensaje.Text = "Se eliminó correctamente"; }
            else lblMensaje.Text = "Se eliminó correctamente";

            CargarGrilla();

        }
    }
    protected void ibtnRuc_Click(object sender, EventArgs e)
    {
        listarProveedor();
    }

    private void listarProveedor()
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        List<ServiceReference1.Proveedor> objs = client.ListarProveedores();
        gvResultados.DataSource = objs;
        gvResultados.DataBind();
    }
}

/**************** WCFServices / Proveedores.svc.cs********************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Errores;
using WCFServices.Persistencia;

namespace WCFServices
{
    public class Proveedores : IProveedores
    {
        private ProveedorDAO proveedorDAO = new ProveedorDAO();
        private DocumentoDAO documentoDAO = new DocumentoDAO();
        public Proveedor CrearProveedor(Proveedor proveedorACrear)
        {
            if (proveedorDAO.Obtener(proveedorACrear.Ruc) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El proveedor ya existe"
                    }, new FaultReason("Error al intentar creación"));
            }
            return proveedorDAO.Crear(proveedorACrear);            
        }
        public string CrearProveedorString(Proveedor proveedorACrear)
        {
            string  mensaje= "";
            if (proveedorDAO.Obtener(proveedorACrear.Ruc) != null)
            {
                mensaje= "El proveedor ya existe";
            }
            else
            { 
                proveedorDAO.Crear(proveedorACrear);
                mensaje= "El proveedor fue agreagado";
            }
            return mensaje;
        }


        public Proveedor ObtenerProveedor(string ruc)
        {
            return proveedorDAO.Obtener(ruc);
        }

        public Proveedor ModificarProveedor(Proveedor proveedorAModificar)
        {
            return proveedorDAO.Modificar(proveedorAModificar);
        }
        

        public int EliminarProveedor(string ruc)
        {
            return proveedorDAO.Eliminar(ruc);
        }
        
        public List<Proveedor> ListarProveedores()
        {
            return proveedorDAO.Listar();
        }

        public List<Documento> ListarDocumentos(string fecFin, string fecIni, string tipoDocumento, string moneda, string estado)
        {
            return documentoDAO.ListarDocumentos(fecFin, fecIni, tipoDocumento, moneda, estado);
        }
    }
}
/********************* WCFServices / ProveedorDAO.cs *******************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServices.Dominio;

namespace WCFServices.Persistencia
{
    public class ProveedorDAO
    {
        private string CadenaConexion = "Data Source=HN060851\\SQLEXPRESS;Initial Catalog=TRABAJO_DSD;Integrated Security=SSPI;";

        public Proveedor Crear(Proveedor proveedorACrear)
        {
            Proveedor proveedorCreado = null;
            string sql = "INSERT INTO tbl_Proveedor VALUES (@Ruc,@Tipo,@Razon,@Telefono,@EMail,@Direccion)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Ruc", proveedorACrear.Ruc));
                    comando.Parameters.Add(new SqlParameter("@Tipo", proveedorACrear.Tipo));
                    comando.Parameters.Add(new SqlParameter("@Razon", proveedorACrear.RazonSocial));
                    comando.Parameters.Add(new SqlParameter("@Telefono", proveedorACrear.Telefono));
                    comando.Parameters.Add(new SqlParameter("@EMail", proveedorACrear.Email));
                    comando.Parameters.Add(new SqlParameter("@Direccion", proveedorACrear.Direccion));
                    comando.ExecuteNonQuery();
                }
            }
            proveedorCreado = Obtener(proveedorACrear.Ruc);
            return proveedorCreado;
        }

        public Proveedor Obtener(string ruc)
        {
            Proveedor proveedorEncontrado = null;
            string sql = "SELECT * FROM tbl_Proveedor WHERE RUC = @Ruc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Ruc", ruc));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            proveedorEncontrado = new Proveedor()
                            {
                                Ruc = (string)resultado["RUC"],
                                Tipo = (string)resultado["TIPO"],
                                RazonSocial = (string)resultado["RAZON_SOCIAL"],
                                Telefono = (string)resultado["TELEFONO"],
                                Email = (string)resultado["EMAIL"],
                                Direccion = (string)resultado["DIRECCION"]
                            };
                        }
                    }
                }
            }
            return proveedorEncontrado;
        }

        public Proveedor Modificar(Proveedor proveedorAModificar)
        {
            Proveedor proveedorModificado = null;
            string sql = "UPDATE tbl_Proveedor SET TIPO=@Tipo,RAZON_SOCIAL=@Razon,TELEFONO=@Telefono,EMAIL=@EMail, DIRECCION=@Direccion WHERE RUC=@Ruc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Tipo", proveedorAModificar.Tipo));
                    comando.Parameters.Add(new SqlParameter("@Razon", proveedorAModificar.RazonSocial));
                    comando.Parameters.Add(new SqlParameter("@Telefono", proveedorAModificar.Telefono));
                    comando.Parameters.Add(new SqlParameter("@EMail", proveedorAModificar.Email));
                    comando.Parameters.Add(new SqlParameter("@Ruc", proveedorAModificar.Ruc));
                    comando.Parameters.Add(new SqlParameter("@Direccion", proveedorAModificar.Direccion));
                    comando.ExecuteNonQuery();
                    proveedorModificado = Obtener(proveedorAModificar.Ruc);
                }
            }            
            return proveedorModificado;
        }

        public int Eliminar(string ruc)
        {
            int r = 1;
            string sql = "DELETE FROM tbl_Proveedor WHERE RUC = @Ruc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Ruc", ruc));
                    comando.ExecuteNonQuery();
                }
                r = 0;
            }
            return r;
        }

        public List<Proveedor> Listar()
        {
            List<Proveedor> proveedoresEncontrados = new List<Proveedor>();
            Proveedor proveedorEncontrado = null;
            string sql = "SELECT Pr.*, Tp.dscTipoPersona   FROM tbl_Proveedor Pr left join TIPO_PERSONA Tp on Pr.tipo = Tp.codTipoPersona";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            proveedorEncontrado = new Proveedor()
                            {
                                Ruc = (string)resultado["RUC"],
                                Tipo = (string)resultado["TIPO"],
                                RazonSocial = (string)resultado["RAZON_SOCIAL"],
                                Telefono = (string)resultado["TELEFONO"],
                                Email = (string)resultado["EMAIL"],
                                Direccion = (string)resultado["DIRECCION"]
                            };
                            proveedoresEncontrados.Add(proveedorEncontrado);
                        }
                    }
                }
            }
            return proveedoresEncontrados;
        }
    }
}
/***************** WCFServicesTest / UniTest1.cs *************************/
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
                Email = "sac@altavistasac.com.pe",
                Direccion = "av. aviacion 370"
            });
            Assert.AreEqual("20453423411", proveedorCreado.Ruc);
            Assert.AreEqual("Jurídica", proveedorCreado.Tipo);
            Assert.AreEqual("Altavista SAC", proveedorCreado.RazonSocial);
            Assert.AreEqual("934253642", proveedorCreado.Telefono);
            Assert.AreEqual("sac@altavistasac.com.pe", proveedorCreado.Email);
            Assert.AreEqual("av. aviacion 370", proveedorCreado.Direccion);
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
                    Email = "sac@altavistasac.com.pe",
                    Direccion = "av. aviacion 370"
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
            Assert.AreEqual("av. aviacion 370", proveedorEncontrado.Direccion);
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
                Email = "sap@altavistasac.com",
                Direccion = "av. aviacion 370"
            });
            Assert.AreEqual("20453423411", proveedoModificado.Ruc);
            Assert.AreEqual("Jurídica", proveedoModificado.Tipo);
            Assert.AreEqual("Altavista SAC", proveedoModificado.RazonSocial);
            Assert.AreEqual("5323423", proveedoModificado.Telefono);
            Assert.AreEqual("sap@altavistasac.com", proveedoModificado.Email);
            Assert.AreEqual("av. aviacion 370", proveedoModificado.Direccion);
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
            Assert.AreEqual("av. aviacion 370", proveedorEncontrado[0].Direccion);
            Assert.AreEqual("20453423411", proveedorEncontrado[1].Ruc);
            Assert.AreEqual("Jurídica", proveedorEncontrado[1].Tipo);
            Assert.AreEqual("Altavista SAC", proveedorEncontrado[1].RazonSocial);
            Assert.AreEqual("5323423", proveedorEncontrado[1].Telefono);
            Assert.AreEqual("sap@altavistasac.com", proveedorEncontrado[1].Email);
            Assert.AreEqual("av. aviacion 370", proveedorEncontrado[1].Direccion);
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

        [TestMethod]
        public void Test7ListarDocumentos()
        {
            ProveedoresWS.ProveedoresClient proxy = new ProveedoresWS.ProveedoresClient();
            ProveedoresWS.Documento[] documentoEncontrado = proxy.ListarDocumentos("2016-01-01","2016-01-01","FAC","EMI","SOL");
            Assert.AreEqual("20100274621", documentoEncontrado[0].tipo_documento);
            Assert.AreEqual("F1230000001", documentoEncontrado[0].numero_documento);
            Assert.AreEqual("FAC", documentoEncontrado[0].glosa);
            Assert.AreEqual("2016-01-01", documentoEncontrado[0].fecha_emision);
            Assert.AreEqual("2016-01-01", documentoEncontrado[0].fecha_vencimiento);
            Assert.AreEqual("SOL", documentoEncontrado[0].moneda);
            Assert.AreEqual("CARRO", documentoEncontrado[0].importe);
            Assert.AreEqual("1000.00", documentoEncontrado[0].estado);

            Assert.AreEqual("20100130201", documentoEncontrado[1].tipo_documento);
            Assert.AreEqual("F1110000001", documentoEncontrado[1].numero_documento);
            Assert.AreEqual("FAC", documentoEncontrado[1].glosa);
            Assert.AreEqual("2016-01-01", documentoEncontrado[1].fecha_emision);
            Assert.AreEqual("2016-01-01", documentoEncontrado[1].fecha_vencimiento);
            Assert.AreEqual("SOL", documentoEncontrado[1].moneda);
            Assert.AreEqual("HOLA", documentoEncontrado[1].importe);
            Assert.AreEqual("1400.00", documentoEncontrado[1].estado);
        }
    }
}

