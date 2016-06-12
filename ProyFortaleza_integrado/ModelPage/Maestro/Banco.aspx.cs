using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Maestro_Banco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
    }
   
    protected void ibtnBanco_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        txtIdBanco.Text = "";
        txtNombre.Text = "";
        btnGrabar.Enabled = true;
        btnActualizar.Enabled = false;
        

    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {


        BE.MAESTRO_BANCOS obj = new BE.MAESTRO_BANCOS();
        obj.CODIGO_BANCO = txtIdBanco.Text;
        obj.DESCRIPCION = txtNombre.Text;
      string  result = new BLBanco().actualizar_Banco(obj);
        lblMensaje.Text = "Se grabó correctamente";
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {


        BE.MAESTRO_BANCOS obj = new BE.MAESTRO_BANCOS();
        obj.CODIGO_BANCO = txtIdBanco.Text;
        obj.DESCRIPCION = txtNombre.Text;
        string result = "";
        result = new BLBanco().grabar_Banco(obj);
     
        lblMensaje.Text = "Se grabó correctamente";
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Se eliminó correctamente";
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

     List<BE.MAESTRO_BANCOS> bancos =
         new BLBanco().listar_Bancos(txtBuscador.Text);

     gvResultados.DataSource = bancos;
     gvResultados.DataBind();


         




        //string vtn = "window.open('Proveedor.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }
    protected void gvResultados_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
           if(e.CommandName=="Editar")
           {
               int index = Convert.ToInt32(e.CommandArgument);
               string codigo = gvResultados.Rows[index].Cells[2].Text;
               BE.MAESTRO_BANCOS obj = new BLBanco().traer_banco(codigo);
               txtIdBanco.Text = obj.CODIGO_BANCO;
               txtNombre.Text = obj.DESCRIPCION;
               btnGrabar.Enabled = true;
               txtIdBanco.Enabled = false;
               btnActualizar.Enabled = true;
               btnGrabar.Enabled = false;

           }
           else if (e.CommandName == "Eliminar")
           {

                int index = Convert.ToInt32(e.CommandArgument);
                string codigo = gvResultados.Rows[index].Cells[2].Text;
                int result = new BLBanco().eliminar_banco(codigo);
                btnNuevo.Enabled = false;
                btnGrabar.Enabled = true;
           }
    }
}
