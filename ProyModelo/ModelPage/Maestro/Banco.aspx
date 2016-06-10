<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Banco.aspx.cs" Inherits="Maestro_Banco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="frame">
         <table>
             <tr>
                 <td>
                     <table width="100%">
             <tr>
                <td colspan="10">
                    <h1>Maestro Bancos</h1>
                </td>
            </tr>
             <tr>
                                  <td>Filtro de búsqueda:</td>
                 <td> <asp:TextBox ID="txtBuscador" runat="server" > </asp:TextBox> 
                    <asp:Button ID="btBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                  </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>Código:</td>
                <td>
                    <asp:TextBox ID="txtIdBanco" runat="server" ></asp:TextBox>
                </td>
             </tr>
              <tr>
                         <td>Nombre:</td>
                    
              
                <td><asp:TextBox ID="txtNombre" runat="server" Width="400px" ></asp:TextBox></td>
              
             </tr>
             <tr>
                 <td colspan ="2">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" Enabled="False" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="False" />
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
                         <tr>
                             <td colspan ="7" align="center">
                                 <asp:GridView ID="gvResultados" OnRowCommand="gvResultados_RowCommand" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="gvResultados_SelectedIndexChanged" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
                                         <asp:BoundField DataField="CODIGO_BANCO" HeaderText="Código" />
                                         <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" />
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
                 </td>
                
             </tr>
         </table>
        
      
        
    </div>
</asp:Content>

