<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="ListaRepuestosUtilizados.aspx.cs" Inherits="Siregra.ListaRepuestosUtilizados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MainCSS.css" />
      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <script>
        function show() {
            document.write("<head runat='server'></head>");
        }
    </script>
    <table style="width:800px; " runat="server">
        <tr>
            <td style="width:200px"></td>
            <td style="width:400px">
                <asp:label runat="server" text="Listado de productos utilizados" Font-Bold="True" Font-Size="14pt"></asp:label>
            </td>
            <td style="width:200px"></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upd">
        <ContentTemplate>
        <asp:Label runat="server" Font-Size="Larger" Font-Italic="true">Lista Diaria de respuestos utilizados</asp:Label>
    <hr />
    <asp:Table ID="Table1" runat="server" Width="800px">
        <asp:TableRow runat="server">
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell runat="server" Width="100px">
                <asp:Button ID="btnGenerarListaRepuestosUtilizados" runat="server" OnClick="btnGenerarListaRepuestosUtilizados_Click" Text="Generar Informe" BorderStyle="Ridge"/>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <hr />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell runat="server">
                        <asp:GridView runat="server" ID="gridListaRepuestosUtilizados" Width="700px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                             BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" 
                            AutoGenerateColumns="False" CaptionAlign="Bottom" >
        <Columns>
            <asp:BoundField DataField="marcaRepuesto" HeaderText="Marca Repuesto"/>
            <asp:BoundField DataField="modeloRepuesto" HeaderText="Modelo"/>
            <asp:BoundField DataField="cantidadUtilizados"  HeaderText="Cantidad utilizado/os"/>
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
            <%--POPUP MENSAJE--%>
            <asp:Button ID="btnAuxMensaje" Style="display: none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeMensaje" runat="server"
                TargetControlID="btnAuxMensaje" OkControlID="btnAuxMensaje"
                PopupControlID="panMensaje">
            </cc1:ModalPopupExtender>
            <div id="panMensaje" class="popupMensajePanelClassCuota" runat="server" style="display: none">
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderMensaje">
                        <asp:Table ID="Table4" runat="server" CssClass="t_tabla1">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>
                                    <div style="font-family: Arial">
                                        <asp:Literal ID="Literal2" runat="server" Text="Siregra"></asp:Literal>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                    <hr width="100%" />
                    <%--CUERPO DEL POPUP--%>
                    <div class="popupBodyCuota">
                        <table style="width: 450px; margin: 6px;">
                            <tr>
                                <td style="text-align: center; vertical-align: middle; height: 100px">
                                    <br />
                                    <asp:Label ID="lblMensaje" Style="margin: 0" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align: center; vertical-align: middle">
                                        <asp:Button ID="btnAceptarMensaje" runat="server" CssClass="t_boton" Text="Aceptar" Width="105px" OnClick="btnAceptarMensaje_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            </ContentTemplate> 
        </asp:UpdatePanel>
</asp:Content>
