﻿using System;
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
        obj.Tipo = ddlPersona.SelectedValue.ToString();
        client.ModificarProveedor(obj);

    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        ServiceReference1.Proveedor obj = new ServiceReference1.Proveedor();
        obj.Email = txtMail.Text;
        obj.RazonSocial = txtRazSocial.Text;
        obj.Ruc = txtIdRuc.Text;
        obj.Telefono = txtTelefono.Text;
        obj.Tipo = ddlPersona.SelectedValue.ToString();
        client.CrearProveedor(obj);



        lblMensaje.Text = "Se grabó correctamente";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se eliminó correctamente";
    }
    protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
            int index = Convert.ToInt32(e.CommandArgument);
            string codigo = gvResultados.Rows[index].Cells[2].Text;

           ServiceReference1.Proveedor obj=      client.ObtenerProveedor(codigo);
            
            txtRazSocial.Text = obj.RazonSocial;
            txtIdRuc.Text = obj.Ruc;
            txtMail.Text = obj.Email;
            txtTelefono.Text = obj.Telefono;

            

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

        }
    }
    protected void ibtnRuc_Click(object sender, EventArgs e)
    {
        ServiceReference1.ProveedoresClient client = new ServiceReference1.ProveedoresClient();
        List<ServiceReference1.Proveedor> objs = client.ListarProveedores();
        gvResultados.DataSource = objs;
        gvResultados.DataBind();
    }
}