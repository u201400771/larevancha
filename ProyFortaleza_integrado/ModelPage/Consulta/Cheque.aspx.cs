using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consulta_Cheque : System.Web.UI.Page
{
    DataTable dtDocumentos = new DataTable();
    DataTable dtDetalle = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtFechaIni.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        dtDocumentos.Rows.Clear();
        dtDocumentos.Columns.Add("Check");
        dtDocumentos.Columns.Add("NroCheque");
        dtDocumentos.Columns.Add("Banco");
        dtDocumentos.Columns.Add("Fecha");
        dtDocumentos.Columns.Add("Moneda");
        dtDocumentos.Columns.Add("Importe");
        dtDocumentos.Columns.Add("Estado");
        dtDocumentos.Columns.Add("Detalle");
        

        DataRow drDocumentos;
        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["NroCheque"] = "001-00023";
        drDocumentos["Banco"] = "Scotiabank";
        drDocumentos["Fecha"] = "04/03/2016";
        drDocumentos["Moneda"] = "S/.";
        drDocumentos["Importe"] = "3400.00";
        drDocumentos["Estado"] = "Girado";
        drDocumentos["Detalle"] = "Detalle";
        dtDocumentos.Rows.Add(drDocumentos);

        drDocumentos = dtDocumentos.NewRow();
        drDocumentos["NroCheque"] = "001-00014";
        drDocumentos["Banco"] = "BCP";
        drDocumentos["Fecha"] = "17/03/2016";
        drDocumentos["Moneda"] = "$";
        drDocumentos["Importe"] = "200.00";
        drDocumentos["Estado"] = "Firmado";
        drDocumentos["Detalle"] = "Detalle";
        dtDocumentos.Rows.Add(drDocumentos);

        grdDocumentos.DataSource = dtDocumentos;
        grdDocumentos.DataBind();

        lblDetalle.Text = "Detalle de Cheque";

        dtDetalle.Rows.Clear();
        dtDetalle.Columns.Add("Check");
        dtDetalle.Columns.Add("TipoDoc");
        dtDetalle.Columns.Add("NroDoc");
        dtDetalle.Columns.Add("Glosa");
        dtDetalle.Columns.Add("FecEmision");
        dtDetalle.Columns.Add("FecVcto");
        dtDetalle.Columns.Add("Moneda");
        dtDetalle.Columns.Add("Importe");


        DataRow drDetalle;
        drDetalle = dtDetalle.NewRow();
        drDetalle["TipoDoc"] = "Factura";
        drDetalle["NroDoc"] = "00023";
        drDetalle["Glosa"] = "Pago de Servicios";
        drDetalle["FecEmision"] = "04/03/2016";
        drDetalle["FecVcto"] = "04/05/2016";
        drDetalle["Moneda"] = "S/.";
        drDetalle["Importe"] = "3400.00";
        dtDetalle.Rows.Add(drDetalle);

        drDetalle = dtDetalle.NewRow();
        drDetalle["TipoDoc"] = "Factura";
        drDetalle["NroDoc"] = "00014";
        drDetalle["Glosa"] = "Impuestos y otros conceptos";
        drDetalle["FecEmision"] = "17/04/2016";
        drDetalle["FecVcto"] = "01/05/2016";
        drDetalle["Moneda"] = "S/.";
        drDetalle["Importe"] = "3400.00";
        dtDetalle.Rows.Add(drDetalle);

        drDetalle = dtDetalle.NewRow();
        drDetalle["TipoDoc"] = "Recibo Honorarios Profesionales";
        drDetalle["NroDoc"] = "1423";
        drDetalle["Glosa"] = "Mensualidad";
        drDetalle["FecEmision"] = "04/03/2016";
        drDetalle["FecVcto"] = "30/04/2016";
        drDetalle["Moneda"] = "S/.";
        drDetalle["Importe"] = "2700.00";
        dtDetalle.Rows.Add(drDetalle);

        grdDetalle.DataSource = dtDetalle;
        grdDetalle.DataBind();

    }
    protected void btnFirmar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se realizó Firma del documento";
    }
}