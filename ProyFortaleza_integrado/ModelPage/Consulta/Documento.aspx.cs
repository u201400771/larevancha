using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using System.Text;

public partial class Consulta_Documento : System.Web.UI.Page
{
    DataTable dtDocumentos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarDatos();
            CargarRuc();
            cargarGrilla();
            btnGrabar.Enabled = false;
            btnModificar.Enabled = false;
        }
    }

    private void CargarRuc()
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        List<ServiceReference1.Proveedor> objs = client.ListarProveedores();

        ddlRuc.DataTextField = "ruc";
        ddlRuc.DataValueField = "ruc";
        ddlRuc.DataSource = objs;
        ddlRuc.DataBind(); 
    }

    private void cargarGrilla()
    {
        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:1951/Documentos.svc/Documentos");
        req2.Method = "GET";
        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
        StreamReader reader2 = new StreamReader(res2.GetResponseStream());
        string documentoJson2 = reader2.ReadToEnd();
        JavaScriptSerializer js2 = new JavaScriptSerializer();
        List<Documento> documentoObtenido = js2.Deserialize<List<Documento>>(documentoJson2);


        gvResultados.DataSource = documentoObtenido;
        gvResultados.DataBind(); 
    }

    private void cargarDatos()
    {
        txtFechaFin.Text = DateTime.Now.ToShortDateString();
        txtFechaIni.Text = DateTime.Now.ToShortDateString();

        DataTable dtMoneda = new DataTable();
        dtMoneda.Columns.Add("IdMoneda");
        dtMoneda.Columns.Add("DesMoneda");
        DataRow drMoneda;
        drMoneda = dtMoneda.NewRow(); drMoneda["IdMoneda"] = "0"; drMoneda["DesMoneda"] = "Seleccione..."; dtMoneda.Rows.Add(drMoneda);
        drMoneda = dtMoneda.NewRow(); drMoneda["IdMoneda"] = "SOL"; drMoneda["DesMoneda"] = "SOL"; dtMoneda.Rows.Add(drMoneda);
        drMoneda = dtMoneda.NewRow(); drMoneda["IdMoneda"] = "DOL"; drMoneda["DesMoneda"] = "DOL"; dtMoneda.Rows.Add(drMoneda);
        ddlMoneda.DataSource = dtMoneda;
        ddlMoneda.DataTextField = "DesMoneda";
        ddlMoneda.DataValueField = "IdMoneda";
        ddlMoneda.DataBind();

        DataTable dtTipoDocumento = new DataTable();
        dtTipoDocumento.Columns.Add("IdDocumento");
        dtTipoDocumento.Columns.Add("DesDocumento");
        DataRow drDocumento;
        drDocumento = dtTipoDocumento.NewRow(); drDocumento["IdDocumento"] = "0"; drDocumento["DesDocumento"] = "Seleccione..."; dtTipoDocumento.Rows.Add(drDocumento);
        drDocumento = dtTipoDocumento.NewRow(); drDocumento["IdDocumento"] = "FAC"; drDocumento["DesDocumento"] = "FAC"; dtTipoDocumento.Rows.Add(drDocumento);
        drDocumento = dtTipoDocumento.NewRow(); drDocumento["IdDocumento"] = "RECIBO"; drDocumento["DesDocumento"] = "RECIBO"; dtTipoDocumento.Rows.Add(drDocumento);
        ddlDocumento.DataSource = dtTipoDocumento;
        ddlDocumento.DataTextField = "DesDocumento";
        ddlDocumento.DataValueField = "IdDocumento";
        ddlDocumento.DataBind();

        DataTable dtEstado = new DataTable();
        dtEstado.Columns.Add("IdEstado");
        dtEstado.Columns.Add("DesEstado");
        DataRow drEstado;
        drEstado = dtEstado.NewRow(); drEstado["IdEstado"] = "0"; drEstado["DesEstado"] = "Seleccione..."; dtEstado.Rows.Add(drEstado);
        drEstado = dtEstado.NewRow(); drEstado["IdEstado"] = "EMITIDO"; drEstado["DesEstado"] = "Emitido"; dtEstado.Rows.Add(drEstado);
        drEstado = dtEstado.NewRow(); drEstado["IdEstado"] = "COBRADO"; drEstado["DesEstado"] = "Cobrado"; dtEstado.Rows.Add(drEstado);
        ddlEstado.DataSource = dtEstado;
        ddlEstado.DataTextField = "DesEstado";
        ddlEstado.DataValueField = "IdEstado";
        ddlEstado.DataBind();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        cargarGrilla();
    }
    protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            btnModificar.Enabled = true;
            ddlRuc.Enabled = false;
            ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
            int index = Convert.ToInt32(e.CommandArgument);
            string codigo = gvResultados.Rows[index].Cells[2].Text;

            ServiceReference1.Proveedor obj = client.ObtenerProveedor(codigo);
            string url = "http://localhost:1951/Documentos.svc/Documentos/" + txtNumDocumento.Text;

            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(url);
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string documentoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Documento documentoObtenido = js2.Deserialize<Documento>(documentoJson2);
            ddlRuc.SelectedValue = documentoObtenido.ruc;
            ddlMoneda.SelectedValue = documentoObtenido.moneda;
            ddlEstado.SelectedValue = documentoObtenido.estado;
            ddlDocumento.SelectedValue = documentoObtenido.tipo_documento;
            txtImporte.Text = documentoObtenido.importe.ToString();
            txtFechaFin.Text = documentoObtenido.fecha_vencimiento;
            txtFechaIni.Text = documentoObtenido.fecha_emision;
            txtGlosa.Text = documentoObtenido.glosa;
            txtNumDocumento.Text = documentoObtenido.numero_documento;
            

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

            cargarGrilla();

        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        btnGrabar.Enabled = true;
        ddlEstado.SelectedValue = "0";
        txtFechaFin.Text = "";
        txtFechaIni.Text = "";
        ddlMoneda.SelectedValue = "0";
        ddlDocumento.SelectedValue = "0";
        ddlEstado.SelectedValue = "0";
        txtNumDocumento.Text = "";
        txtGlosa.Text = "";
        txtImporte.Text = "";

    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        string postdata = "{\"ruc\":\""+ddlRuc.SelectedValue.ToString()+"\",\"numero_documento\":\""+txtNumDocumento.Text+"\",\"tipo_documento\":\""+ddlDocumento.SelectedValue.ToString()+"\",\"fecha_emision\":\""+txtFechaIni.Text+"\",\"fecha_vencimiento\":\""+txtFechaFin.Text+"\",\"moneda\":\""+ddlMoneda.SelectedValue.ToString()+"\",\"glosa\":\""+txtGlosa.Text+"\",\"importe\":\""+txtImporte.Text+"\",\"estado\":\""+ddlEstado.SelectedValue.ToString()+"\"}";
        //string postdata = "{\"ruc\":\"20100130201\",\"numero_documento\":\"F1110000001\",\"tipo_documento\":\"FAC\",\"fecha_emision\":\"01-01-2016\",\"fecha_vencimiento\":\"01-01-2016\",\"moneda\":\"SOL\",\"glosa\":\"HOLA\",\"importe\":\"1400\",\"estado\":\"EMI\"}";
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
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        string postdata = "{\"ruc\":\"" + ddlRuc.SelectedValue.ToString() + "\",\"numero_documento\":\"" + txtNumDocumento.Text + "\",\"tipo_documento\":\"" + ddlDocumento.SelectedValue.ToString() + "\",\"fecha_emision\":\"" + txtFechaIni.Text + "\",\"fecha_vencimiento\":\"" + txtFechaFin.Text + "\",\"moneda\":\"" + ddlMoneda.SelectedValue.ToString() + "\",\"glosa\":\"" + txtGlosa.Text + "\",\"importe\":\"" + txtImporte.Text + "\",\"estado\":\"" + ddlEstado.SelectedValue.ToString() + "\"}";
        //string postdata = "{\"ruc\":\"20100130201\",\"numero_documento\":\"F1110000001\",\"tipo_documento\":\"FAC\",\"fecha_emision\":\"01-01-2016\",\"fecha_vencimiento\":\"31-01-2016\",\"moneda\":\"SOL\",\"glosa\":\"HOLA\",\"importe\":\"1500\",\"estado\":\"EMI\"}";
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
    }
}