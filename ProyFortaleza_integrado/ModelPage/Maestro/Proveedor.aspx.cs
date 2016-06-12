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