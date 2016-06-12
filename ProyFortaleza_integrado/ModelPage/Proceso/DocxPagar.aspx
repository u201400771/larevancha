<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DocxPagar.aspx.cs" Inherits="Proceso_DocxPagar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
        <table width="100%">
            <tr>
                <td colspan="13">
                    <h1>Documentos por Pagar</h1>
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
                    <td>RUC:</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtRuc" runat="server" OnTextChanged="txtRUC_TextChanged" AutoPostBack="true" Width="170px"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
                <td colspan="2" class="auto-style1">Razón Social:</td>
                <td class="auto-style2"></td>
                <td colspan="2" class="auto-style1">
                    <asp:TextBox ID="txtRazSocial" runat="server" Width="291px"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>Tipo Documento:</td>
                <td style="width: 8px;"></td>
                <td>
                    <asp:DropDownList ID="ddlDocumento" runat="server" Width="170px"></asp:DropDownList>
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">N° Documento:</td>
                <td></td>
                <td colspan="2">
                    <asp:TextBox ID="txtNumDocumento" runat="server" Width="170px"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Fecha Emisión:</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtFecIni" runat="server" Width="130px"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ibtnEmision" runat="server" ImageUrl="~/Util/Calendar.gif" />
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">Fecha Vencimiento:</td>
                <td></td>
                <td colspan="2">
                    <asp:TextBox ID="txtFecFin" runat="server" Width="130px"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="ibtnVencimiento" runat="server" ImageUrl="~/Util/Calendar.gif" />
                </td>
                <td></td>
            </tr>
            
            <tr>
                <td>Moneda: </td>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="170px"></asp:DropDownList>
                </td>
                <td style="width: 10px;"></td>
                <td>Importe</td>
                <td style="width: 4px;"></td>
                <td colspan="5">
                    <asp:TextBox ID="txtRazon" runat="server" Width="170px"></asp:TextBox>
                </td>
                <td colspan="2"></td>
            </tr>
            
            <tr>
                <td>Glosa:</td>
                <td style="width: 4px;"></td>
                <td colspan="10">
                    <asp:TextBox ID="txtGlosa" runat="server" Width="653px"></asp:TextBox>
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

