using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consulta_Documento : System.Web.UI.Page
{
    DataTable dtDocumentos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
            txtFechaIni.Text = DateTime.Now.ToShortDateString();

            DataTable dtMoneda = new DataTable();
            dtMoneda.Columns.Add("IdMoneda");
            dtMoneda.Columns.Add("DesMoneda");
            DataRow drMoneda;
            drMoneda = dtMoneda.NewRow(); drMoneda["IdMoneda"] = 0; drMoneda["DesMoneda"] = "Seleccione..."; dtMoneda.Rows.Add(drMoneda);
            drMoneda = dtMoneda.NewRow(); drMoneda["IdMoneda"] = 1; drMoneda["DesMoneda"] = "Soles (S/.)"; dtMoneda.Rows.Add(drMoneda);
            drMoneda = dtMoneda.NewRow(); drMoneda["IdMoneda"] = 2; drMoneda["DesMoneda"] = "Dólares ($)"; dtMoneda.Rows.Add(drMoneda);
            ddlMoneda.DataSource = dtMoneda;
            ddlMoneda.DataTextField = "DesMoneda";
            ddlMoneda.DataValueField = "IdMoneda";
            ddlMoneda.DataBind();

            DataTable dtTipoDocumento = new DataTable();
            dtTipoDocumento.Columns.Add("IdDocumento");
            dtTipoDocumento.Columns.Add("DesDocumento");
            DataRow drDocumento;
            drDocumento = dtTipoDocumento.NewRow(); drDocumento["IdDocumento"] = 0; drDocumento["DesDocumento"] = "Seleccione..."; dtTipoDocumento.Rows.Add(drDocumento);
            drDocumento = dtTipoDocumento.NewRow(); drDocumento["IdDocumento"] = 1; drDocumento["DesDocumento"] = "Factura"; dtTipoDocumento.Rows.Add(drDocumento);
            drDocumento = dtTipoDocumento.NewRow(); drDocumento["IdDocumento"] = 1; drDocumento["DesDocumento"] = "Recibo por Honorarios"; dtTipoDocumento.Rows.Add(drDocumento);
            ddlDocumento.DataSource = dtTipoDocumento;
            ddlDocumento.DataTextField = "DesDocumento";
            ddlDocumento.DataValueField = "IdDocumento";
            ddlDocumento.DataBind();

            DataTable dtEstado = new DataTable();
            dtEstado.Columns.Add("IdEstado");
            dtEstado.Columns.Add("DesEstado");
            DataRow drEstado;
            drEstado = dtEstado.NewRow(); drEstado["IdEstado"] = 0; drEstado["DesEstado"] = "Seleccione..."; dtEstado.Rows.Add(drEstado);
            drEstado = dtEstado.NewRow(); drEstado["IdEstado"] = 1; drEstado["DesEstado"] = "Girado"; dtEstado.Rows.Add(drEstado);
            drEstado = dtEstado.NewRow(); drEstado["IdEstado"] = 2; drEstado["DesEstado"] = "Cobrado"; dtEstado.Rows.Add(drEstado);
            ddlEstado.DataSource = dtEstado;
            ddlEstado.DataTextField = "DesEstado";
            ddlEstado.DataValueField = "IdEstado";
            ddlEstado.DataBind();
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        dtDocumentos.Rows.Clear();        
        dtDocumentos.Columns.Add("TipoDoc");
        dtDocumentos.Columns.Add("NroDoc");
        dtDocumentos.Columns.Add("Glosa");
        dtDocumentos.Columns.Add("FecEmision");
        dtDocumentos.Columns.Add("FecVcto");
        dtDocumentos.Columns.Add("Moneda");
        dtDocumentos.Columns.Add("Importe");
        dtDocumentos.Columns.Add("Estado");

        DataRow drDocumentos;
        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["TipoDoc"] = "Factura";
        drDocumentos["NroDoc"] = "00023";
        drDocumentos["Glosa"] = "Pago de Servicios";
        drDocumentos["FecEmision"] = "04/03/2016";
        drDocumentos["FecVcto"] = "04/05/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "3400.00";
        drDocumentos["Estado"] = "Cobrado";
        dtDocumentos.Rows.Add(drDocumentos);

        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["TipoDoc"] = "Factura";
        drDocumentos["NroDoc"] = "00014";
        drDocumentos["Glosa"] = "Impuestos y otros conceptos";
        drDocumentos["FecEmision"] = "17/04/2016";
        drDocumentos["FecVcto"] = "01/05/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "3400.00";
        drDocumentos["Estado"] = "Cobrado";
        dtDocumentos.Rows.Add(drDocumentos);

        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["TipoDoc"] = "Recibo Honorarios Profesionales";
        drDocumentos["NroDoc"] = "1423";
        drDocumentos["Glosa"] = "Mensualidad";
        drDocumentos["FecEmision"] = "04/03/2016";
        drDocumentos["FecVcto"] = "30/04/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "2700.00";
        drDocumentos["Estado"] = "Cobrado";
        dtDocumentos.Rows.Add(drDocumentos);

        grdDocumentos.DataSource = dtDocumentos;
        grdDocumentos.DataBind();
    }
}