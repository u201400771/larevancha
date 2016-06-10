<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Documento.aspx.cs" Inherits="Consulta_Documento" %>

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
                <td>Tipo Documento:</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlDocumento" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td style="width: 4px;"></td>
                <td colspan="2">Moneda:</td>
                <td></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            
            <tr>
                <td>Estado:</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlEstado" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td style="width: 15px;"></td>
                <td>&nbsp;</td>
                <td style="width: 4px;"></td>
                <td colspan="5">
                    &nbsp;</td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="13" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
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
                <td colspan="13" style="height: 5px;"></td>
            </tr>
           
            <tr>
                <td colspan="13" style="text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
