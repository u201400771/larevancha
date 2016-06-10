using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proceso_DocxPagar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            txtFecIni.Text = DateTime.Now.ToShortDateString();
            txtFecFin.Text = DateTime.Now.ToShortDateString();

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

           
        }
    }
    protected void txtRUC_TextChanged(object sender, EventArgs e)
    {
        txtRazSocial.Text = "Buena Vista SAC";
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        txtFecIni.Text = DateTime.Now.ToShortDateString();
        txtFecFin.Text = DateTime.Now.ToShortDateString();
        txtGlosa.Text = "";
        txtNumDocumento.Text = "";
        txtRazon.Text = "";
        txtRuc.Text = "";
        txtRazSocial.Text = "";
        
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se grabó correctamente";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se eliminó correctamente";
    }
}