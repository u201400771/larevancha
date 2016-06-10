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
            DataTable dtPersona = new DataTable();
            dtPersona.Columns.Add("IdPersona");
            dtPersona.Columns.Add("DesPersona");

            DataRow drPersona;
            drPersona = dtPersona.NewRow(); drPersona["IdPersona"] = 0; drPersona["DesPersona"] = "Seleccione..."; dtPersona.Rows.Add(drPersona);
            drPersona = dtPersona.NewRow(); drPersona["IdPersona"] = 1; drPersona["DesPersona"] = "Natural"; dtPersona.Rows.Add(drPersona);
            drPersona = dtPersona.NewRow(); drPersona["IdPersona"] = 2; drPersona["DesPersona"] = "Jurídicas"; dtPersona.Rows.Add(drPersona);

            ddlPersona.DataSource = dtPersona;
            ddlPersona.DataTextField = "DesPersona";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataBind();
        }
        lblMensaje.Text = "";
    }
    protected void ibtnRuc_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        txtIdRuc.Text = "";
        txtRazSocial.Text = "";
        txtDireccion.Text = "";
        txtMail.Text = "";
        txtTelefono.Text = "";
        ddlPersona.SelectedValue= "0";
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