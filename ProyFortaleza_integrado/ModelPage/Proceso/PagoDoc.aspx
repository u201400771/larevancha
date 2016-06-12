<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PagoDoc.aspx.cs" Inherits="Proceso_PagoDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 4px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
        <table width="100%">
            <tr>
                <td colspan="13">
                    <h1>Pago de Documentos</h1>
                </td>
            </tr>
            <tr>
                <td colspan="13" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                </td>
                <td style="width: 4px;"></td>
                <td>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                </td>
                <td colspan="10"></td>
            </tr>
            <tr>
                <td colspan="13" style="height: 10px;"></td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style1"></td>
                <td class="auto-style2"></td>
                <td colspan="2" class="auto-style1">Fecha</td>
                <td class="auto-style2"></td>
                <td colspan="2" class="auto-style1">
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>Banco</td>
                <td style="width: 4px;"></td>
                <td>
                    <asp:DropDownList ID="ddlBanco" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">N° Cheque</td>
                <td></td>
                <td colspan="2">
                    <asp:Label ID="lblNroCheque" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Moneda</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlMoneda" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">Estado</td>
                <td></td>
                <td colspan="2">
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            
            <tr>
                <td>Proveedor</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtRUC" runat="server" OnTextChanged="txtRUC_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td style="width: 15px;"></td>
                <td>Razón Social</td>
                <td style="width: 4px;"></td>
                <td colspan="5">
                    <asp:TextBox ID="txtRazon" runat="server"></asp:TextBox>
                </td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="13" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Text="+" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnQuitar" runat="server" Text="-" />
                </td>
                <td colspan="12"></td>
            </tr>
            <tr>
                <td colspan="13">
                    <asp:GridView ID="grdDocumentos" runat="server"></asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="13" style="height: 5px;"></td>
            </tr>
            <tr>
                <td colspan="8"></td>
                <td colspan="2">Monto Total</td>
                <td style="width: 4px;"></td>
                <td colspan="2">
                    <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="13" style="height: 5px;"></td>
            </tr>
            <tr>
                <td colspan="13" style="text-align: center;">
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" Width="200px" />
                </td>
            </tr>
            <tr>
                <td colspan="13" style="text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

