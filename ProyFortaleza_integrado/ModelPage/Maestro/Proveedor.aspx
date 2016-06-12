<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Proveedor.aspx.cs" Inherits="Maestro_Proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
         <table width="100%">
             <tr>
                <td colspan="10">
                    <h1>Maestro Proveedor</h1>
                </td>
            </tr>
             <tr>
                 <td>RUC:</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtIdRuc" runat="server"></asp:TextBox>
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
                 <td>Dirección:</td>
                <td></td>
                <td colspan ="5">
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
                 <td colspan ="2">&nbsp;</td>
                 <td colspan ="5">
                    &nbsp;<asp:Button ID="ibtnRuc" runat="server" Text="Buscar" OnClick="ibtnRuc_Click" Visible="False" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGrabar" runat="server" Text="Guardar" OnClick="btnGrabar_Click" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEditar" runat="server" Text="Modificar" OnClick="btnEditar_Click" />
                </td>
             </tr>
             <tr>
                <td colspan="6" style="text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
             <tr>
                 <td colspan="7"  align="center">


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
                                         <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                                         <asp:BoundField DataField="RAZONSOCIAL" HeaderText="Razón Social" />
                                         <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />
                                         <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                                         <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
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
         </table>
    </div>
</asp:Content>

