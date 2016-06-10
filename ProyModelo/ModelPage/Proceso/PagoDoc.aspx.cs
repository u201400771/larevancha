using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proceso_PagoDoc : System.Web.UI.Page
{
    DataTable dtDocumentos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();

            DataTable dtBanco = new DataTable();
            dtBanco.Columns.Add("IdBanco");
            dtBanco.Columns.Add("DesBanco");

            DataRow drBanco;
            drBanco = dtBanco.NewRow(); drBanco["IdBanco"] = 0; drBanco["DesBanco"] = "Seleccione..."; dtBanco.Rows.Add(drBanco);
            drBanco = dtBanco.NewRow(); drBanco["IdBanco"] = 1; drBanco["DesBanco"] = "BCP"; dtBanco.Rows.Add(drBanco);
            drBanco = dtBanco.NewRow(); drBanco["IdBanco"] = 2; drBanco["DesBanco"] = "BBVA Banco Continental"; dtBanco.Rows.Add(drBanco);
            drBanco = dtBanco.NewRow(); drBanco["IdBanco"] = 3; drBanco["DesBanco"] = "Scotiabank"; dtBanco.Rows.Add(drBanco);

            ddlBanco.DataSource = dtBanco;
            ddlBanco.DataTextField = "DesBanco";
            ddlBanco.DataValueField = "IdBanco";
            ddlBanco.DataBind();

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

            dtDocumentos.Columns.Add("Check");
            dtDocumentos.Columns.Add("TipoDoc");
            dtDocumentos.Columns.Add("NroDoc");
            dtDocumentos.Columns.Add("Glosa");
            dtDocumentos.Columns.Add("FecEmision");
            dtDocumentos.Columns.Add("FecVcto");
            dtDocumentos.Columns.Add("Moneda");
            dtDocumentos.Columns.Add("Importe");

            grdDocumentos.DataSource = dtDocumentos;
            grdDocumentos.DataBind();
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        lblNroCheque.Text = "001 - 000001";
        lblEstado.Text = "Girado";
    }

    protected void txtRUC_TextChanged(object sender, EventArgs e)
    {
        if (txtRUC.Text.Length == 11)
        {
            txtRazon.Text = "BUENA VISTA SAC";
        }
        else
        {
            txtRazon.Text = "";
        }
    }
    
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        dtDocumentos.Rows.Clear();
        dtDocumentos.Columns.Add("Check");
        dtDocumentos.Columns.Add("TipoDoc");
        dtDocumentos.Columns.Add("NroDoc");
        dtDocumentos.Columns.Add("Glosa");
        dtDocumentos.Columns.Add("FecEmision");
        dtDocumentos.Columns.Add("FecVcto");
        dtDocumentos.Columns.Add("Moneda");
        dtDocumentos.Columns.Add("Importe");

        DataRow drDocumentos;
        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["TipoDoc"] = "Factura";
        drDocumentos["NroDoc"] = "00023";
        drDocumentos["Glosa"] = "Pago de Servicios";
        drDocumentos["FecEmision"] = "04/03/2016";
        drDocumentos["FecVcto"] = "04/05/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "3400.00";
        dtDocumentos.Rows.Add(drDocumentos);

        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["TipoDoc"] = "Factura";
        drDocumentos["NroDoc"] = "00014";
        drDocumentos["Glosa"] = "Impuestos y otros conceptos";
        drDocumentos["FecEmision"] = "17/04/2016";
        drDocumentos["FecVcto"] = "01/05/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "3400.00";
        dtDocumentos.Rows.Add(drDocumentos);

        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["TipoDoc"] = "Recibo Honorarios Profesionales";
        drDocumentos["NroDoc"] = "1423";
        drDocumentos["Glosa"] = "Mensualidad";
        drDocumentos["FecEmision"] = "04/03/2016";
        drDocumentos["FecVcto"] = "30/04/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "2700.00";
        dtDocumentos.Rows.Add(drDocumentos);

        grdDocumentos.DataSource = dtDocumentos;
        grdDocumentos.DataBind();

        txtTotal.Text = "9500.00";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se grabó correctamente";
    }
}