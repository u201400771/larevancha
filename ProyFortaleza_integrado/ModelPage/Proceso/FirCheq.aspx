<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirCheq.aspx.cs" Inherits="Proceso_FirCheq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
        <table width="100%">
            <tr>
                <td>
                    <h1>Firmar Cheques</h1>
                </td>
            </tr>
            <tr>
                <td style="height: 10px;"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnFirmar" runat="server" Text="Firmar Cheques" OnClick="btnFirmar_Click" />
                </td>
            </tr>
            <tr>
                <td class="errmsg">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px;"></td>
            </tr>
        </table>
    </div>
</asp:Content>

