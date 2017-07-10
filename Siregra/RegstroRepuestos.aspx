<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="RegstroRepuestos.aspx.cs" Inherits="Siregra.RegstroRepuestos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <link rel="stylesheet" type="text/css" href="css/MainCSS.css" />
        <script language="javascript">
     function show()
        {
            document.write("<head runat='server'></head>");
        }
    </script>
    <table style="width:800px; " runat="server">
        <tr>
            <td style="width:200px"></td>
            <td style="width:400px">
                <asp:label runat="server" text="Registro de repuesto" Font-Bold="True" Font-Size="14pt"></asp:label>
            </td>
            <td style="width:200px"></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel id="upMain" runat="server">
    <ContentTemplate>
    
    <table style="width:800px; " runat="server">
        <tr>
            <td style="width:200px"></td>
            <td style="width:400px">
                <asp:label runat="server" text="Registro de repuesto utilizados" Font-Bold="True" Font-Size="14pt"></asp:label>
                <hr />
            </td>
            
            <td style="width:200px"></td>
        </tr>
    </table>

        <table style="width:800px; " runat="server">
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label1" runat="server" Text="Patente"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:TextBox ID="txtPatente" runat="server"></asp:TextBox>
            </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:button runat="server" text="Buscar" ID="btnBuscar" OnClick="btnGuardar_Click" />
            </td>
            <td style="width:200px">
                <asp:button runat="server" text="Nuevo" ID="btnNuevo" OnClick="btnNuevo_Click" />
            </td>
            <td style="width:200px"></td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
    </table>

    <div id="Botones" runat="server">
        <table style="width:800px" runat="server">
            <tr>
                <td style="width:200px"></td>
                <td style="width:400px">
                    <asp:gridview  ID="gvAlternativo" runat="server" Width="437px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" CaptionAlign="Bottom">
                            <AlternatingRowStyle Wrap="True" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:gridview>
                </td>
                    <td style="width:400px">
                        <asp:gridview  ID="gvOriginal" runat="server" Width="437px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" CaptionAlign="Bottom">
                            <AlternatingRowStyle Wrap="True" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:gridview>
            </td>
                <td style="width:200px"></td>
            </tr>
        </table>
    
         </div>
        <%--POPUP MENSAJE--%>
            <asp:Button ID="btnAuxMensaje" style="display: none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeMensaje" runat="server" 
                TargetControlID="btnAuxMensaje" OkControlID="btnAuxMensaje"
                PopupControlID="panMensaje">
            </cc1:ModalPopupExtender>
            <div id="panMensaje" class="popupMensajePanelClassCuota" runat="server" style="display:none">
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
                    <hr width="100%"/>
                    <%--CUERPO DEL POPUP--%>
                    <div class="popupBodyCuota">
                        <table style="width:450px; margin: 6px;">
                            <tr>
                                <td style="text-align: center; vertical-align:middle; height:100px">
                                    <br /><asp:Label ID="lblMensaje" style="margin:0" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align: center;vertical-align:middle">
                                        <asp:Button ID="btnAceptarMensaje" runat="server" CssClass="t_boton" Text="Aceptar" Width="105px" OnClick="btnAceptarMensaje_Click" PostBackUrl="~/RegstroRepuestos.aspx" />
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
