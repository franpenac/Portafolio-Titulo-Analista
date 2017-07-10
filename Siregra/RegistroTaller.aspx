<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="RegistroTaller.aspx.cs" Inherits="Siregra.RegistroTaller" %>



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
                <asp:label runat="server" text="Registro de taller" Font-Bold="True" Font-Size="14pt"></asp:label>
            </td>
            <td style="width:200px"></td>
        </tr>
    </table>
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upanel" runat="server">
        <ContentTemplate>
            <table style="width:800px; " runat="server">
                <tr>
                    <td style="width:400px">
                        <asp:label runat="server" text="Registro de taller" Font-Bold="True" Font-Size="14pt"></asp:label>
                        <hr />
                    </td>
                </tr>
            </table>
    
    <table style="width:600px; " runat="server">
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;</td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Nombre Taller"></asp:Label> 
            </td>
            <td style="width:200px" >
                <asp:TextBox ID="txbNombreTaller" runat="server" Width="158px"></asp:TextBox>
            </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Eliminar Taller"></asp:Label>
            </td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlEliminar" runat="server" Width="160px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:200px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="Label2" runat="server" Text="Region"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlRegion" runat="server" Width="168px" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            </td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="width:200px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="Label3" runat="server" Text="Comuna"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlComuna" runat="server" Height="20px" Width="169px">
                </asp:DropDownList>
            </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Modificar Taller"></asp:Label>
            </td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlModificar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModificar_SelectedIndexChanged" Width="158px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:200px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:TextBox ID="txtDireccion" runat="server" Height="18px" Width="158px"></asp:TextBox>
            </td>
            <td style="width:200px"></td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button runat="server" text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" />
            </td>
            <td style="width:200px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button runat="server" text="Nuevo" ID="btnNuevo" OnClick="btnNuevo_Click" />
            </td>
            <td style="width:200px"></td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
    </table>
    <table style="width:800px" runat="server">
        <tr>
            <td style="width:400px">
                <asp:gridview  ID="gvMostrar" runat="server" Width="437px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" CaptionAlign="Bottom">
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
                                        <asp:Button ID="btnAceptarMensaje" runat="server" CssClass="t_boton" Text="Aceptar" Width="105px" OnClick="btnAceptarMensaje_Click" PostBackUrl="~/RegistroTaller.aspx" />
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
