<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BuscarBanco.aspx.cs" Inherits="Maestro_Proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
         <table width="100%">
             <tr>
                <td colspan="10">
                    <h1>Buscar Banco</h1>
                </td>
            </tr>
             <tr>
                 <td>RUC:</td>  
                <td></td>
                <td>
                    <asp:TextBox ID="txtIdRuc" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="ibtnRuc" runat="server" ImageUrl="~/Util/icono-lupa.jpg" OnClick="ibtnRuc_Click" />
                </td>
                 <td></td>
                 <td>Tipo Persona:</td>
                 <td></td>
                 <td>
                     <asp:DropDownList ID="ddlPersona" runat="server" Height="16px" Width="153px"></asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td>Razón Social:</td>
                <td></td>
                <td colspan ="5">
                    <asp:TextBox ID="txtRazSocial" runat="server" Width="80%"></asp:TextBox>
                </td>
             </tr>
             <tr>
                 <td class="auto-style1">Dirección:</td>
                <td class="auto-style1"></td>
                <td colspan ="5" class="auto-style1">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="80%"></asp:TextBox>
                </td>
             </tr>
             <tr>
                 <td>Teléfono:</td>
                <td></td>
                <td colspan ="5">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="50%"></asp:TextBox>
                </td>
             </tr>
             <tr>
                 <td>E-mail:</td>
                <td></td>
                <td colspan ="5">
                    <asp:TextBox ID="txtMail" runat="server" Width="80%"></asp:TextBox>
                </td>
             </tr>
             <tr>
                 <td colspan ="2"></td>
                 <td colspan ="5">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                </td>
             </tr>
             <tr>
                <td colspan="6" style="text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
         </table>
    </div>
</asp:Content>

