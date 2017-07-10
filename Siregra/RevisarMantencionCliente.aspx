<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisarMantencionCliente.aspx.cs" Inherits="Siregra.RevisarMantencionCliente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label runat="server" Font-Size="Larger" Font-Italic="true">Lista Diaria de respuestos utilizados</asp:Label>
    <hr />
    <asp:Table ID="Table1" runat="server" Width="800px">
        <asp:TableRow runat="server">
            <asp:TableCell Width="100px"><asp:Label runat="server" Text="Rut: "></asp:Label></asp:TableCell>
            <asp:TableCell Width="100px">
                <asp:TextBox runat="server" ID="txtClienteRut" placeholder="Rut"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="100px">
                <asp:Label runat="server" Text="Patente: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <asp:TextBox runat="server" ID="txtPatente" placeholder="Patente"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <asp:Button runat="server" ID="btnBuscarMantencion" Text="Buscar" OnClick="btnBuscarMantencion_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
            <hr />
            <table runat="server" style="width:50%">
                <tr>
                    <td runat="server" style="width:50%">
                        <asp:Label runat="server" Text="Paquete Utilizado: "></asp:Label>
                    </td>
                    <td runat="server" style="width:50%">
                        <asp:Label runat="server" ID="txtNombrePaquete"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td runat="server" style="width: 50%">
                        <asp:Label runat="server" Text="Descripción: "></asp:Label>
                    </td>
                    <td runat="server" style="width: 50%">
                        <asp:Label runat="server" ID="txtDescripcionPaquete"></asp:Label>
                    </td>
                </tr>
           </table>
        <hr />
                    <table runat="server" style="width:100%">
                <tr>
                    <td runat="server" style="width:50%">
                        <asp:Label runat="server" Text="Preosupuesto aproximado proxima mantención: "></asp:Label>
                    </td>
                    <td runat="server" style="width:50%">
                        <asp:Label runat="server" ID="lblNextPay"></asp:Label>
                    </td>
                </tr>
           </table>
            <hr />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell runat="server">
                        <asp:GridView runat="server" ID="gridListaRepuestosUtilizados" Width="700px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                             BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" 
                            AutoGenerateColumns="False" CaptionAlign="Bottom" >
        <Columns>
            <asp:BoundField DataField="nombreRepuesto" HeaderText="Nombre Repuesto"/>
            <asp:BoundField DataField="precioRepuesto" HeaderText="Precio"/>
            <asp:BoundField DataField="cantidad" HeaderText="Cantidad"/>
        </Columns>
        <AlternatingRowStyle Wrap="true" />
        <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView> 
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
    </form>
</body>
</html>
