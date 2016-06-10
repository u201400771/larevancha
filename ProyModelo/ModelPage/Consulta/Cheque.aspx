<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cheque.aspx.cs" Inherits="Consulta_Cheque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
        <table width="100%">
            <tr>
                <td colspan="13">
                    <h1>Consulta de Cheques</h1>
                </td>
            </tr>
            <tr>
                <td colspan="13" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>Fecha Inicio:</td>
                <td style="width: 4px;"></td>
                <td>
                    <asp:TextBox ID="txtFechaIni" runat="server"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ibtnEmision" runat="server" ImageUrl="~/Util/Calendar.gif" />
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">Fecha Fin:</td>
                <td></td>
                <td colspan="2">
                    <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ibtnEmision0" runat="server" ImageUrl="~/Util/Calendar.gif" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Proveedor:</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtProveedor" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">&nbsp;</td>
                <td></td>
                <td colspan="2">
                    &nbsp;</td>
                <td></td>
            </tr>
            
            
            <tr>
                <td colspan="13" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFirmar" runat="server" Text="Firmar" OnClick="btnFirmar_Click" />
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
                <td colspan="13" style="height: 5px;">
                    <asp:Label ID="lblDetalle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td colspan="13" style="height: 5px;">
                    <asp:GridView ID="grdDetalle" runat="server"></asp:GridView>
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

