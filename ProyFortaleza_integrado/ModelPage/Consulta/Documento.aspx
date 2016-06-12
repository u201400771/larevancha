<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Documento.aspx.cs" Inherits="Consulta_Documento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
        <table width="100%">
            <tr>
                <td colspan="8">
                    <h1>Documentos por Pagar</h1>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>Ruc Proveedor</td>
                <td style="width: 4px;">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlRuc" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td style="width: 4px;">&nbsp;</td>
                <td>Estado:</td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlEstado" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Fecha Inicio:</td>
                <td style="width: 4px;"></td>
                <td>
                    <asp:TextBox ID="txtFechaIni" runat="server"></asp:TextBox>
                &nbsp;<asp:ImageButton ID="ibtnEmision" runat="server" ImageUrl="~/Util/Calendar.gif" />
                </td>
                <td style="width: 4px;"></td>
                <td>Fecha Fin:</td>
                <td></td>
                <td>
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
                <td>Moneda:</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            
            <tr>
                <td>Num.Documento:</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtNumDocumento" runat="server"></asp:TextBox>
                </td>
                <td style="width: 15px;"></td>
                <td>Glosa:</td>
                <td style="width: 4px;"></td>
                <td colspan="2">
                    <asp:TextBox ID="txtGlosa" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>Importe: </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                </td>
                <td style="width: 15px;">&nbsp;</td>
                <td>&nbsp;</td>
                <td style="width: 4px;">&nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" style="height: 10px;"></td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" Visible="False" />
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Guardar" OnClick="btnGrabar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnEditar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMensaje0" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                     <asp:GridView ID="gvResultados" OnRowCommand="gvResultados_RowCommand" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                                     <AlternatingRowStyle BackColor="#CCCCCC" />
                                     <Columns>
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <asp:ImageButton   ID="ImageButton2" CommandName="Editar" runat="server" ImageUrl="~/Imagenes/edit.png" Width="18px" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <asp:ImageButton   ID="ImageButton1" CommandName="Eliminar" runat="server" Height="16px" ImageUrl="~/Imagenes/delete.png"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField DataField="RUC" HeaderText="Ruc" />
                                         <asp:BoundField DataField=" NUMERO_DOCUMENTO" HeaderText="Num. Documento" />
                                         <asp:BoundField DataField="TIPO_DOCUMENTO" HeaderText="Tipo Documento" />
                                         <asp:BoundField DataField="FECHA_EMISION" HeaderText="Fec. Emision" />
                                         <asp:BoundField DataField="FECHA_VENCIMIENTO" HeaderText="Fec. Vencimiento" />
                                         <asp:BoundField DataField="MONEDA" HeaderText="Moneda" />
                                         <asp:BoundField DataField="GLOSA" HeaderText="Glosa" />
                                         <asp:BoundField DataField="IMPORTE" HeaderText="Importe" />
                                         <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                                     </Columns>
                                     <FooterStyle BackColor="#CCCCCC" />
                                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                     <SortedAscendingHeaderStyle BackColor="#808080" />
                                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                     <SortedDescendingHeaderStyle BackColor="#383838" />
                                 </asp:GridView>

                </td>
            </tr>
            <tr>
                <td colspan="8" style="height: 5px;"></td>
            </tr>
            
            <tr>
                <td colspan="8" style="height: 5px;"></td>
            </tr>
           
            <tr>
                <td colspan="8" style="text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
