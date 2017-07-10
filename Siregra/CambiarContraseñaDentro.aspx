<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="CambiarContraseñaDentro.aspx.cs" Inherits="Siregra.CambiarContraseñaDentro" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <link rel="stylesheet" type="text/css" href="css/MainCSS.css" />
    <script lang="javascript">
        function show() {
            document.write("<head runat='server'></head>");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upanel" runat="server">
        <ContentTemplate>
            <div runat="server" style="width: 100%; height: 100%">
                <div runat="server" style="position: relative; width: 60%; margin-left: 30%; margin-right: 20%; margin-top: 10%">
                    <hr />
                    <div>
                        <asp:Label runat="server" Text="Contraseña Actual"></asp:Label><asp:Label runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:TextBox runat="server" ID="txtActualContraseña" Width="300px" TextMode="Password"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:Label runat="server" Text="Nueva Contraseña"></asp:Label><asp:Label runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:TextBox runat="server" ID="txtNuevaContraseña" Width="300px" TextMode="Password"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:Label runat="server" Text="Repetir Contraseña"></asp:Label><asp:Label runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:TextBox runat="server" ID="txtRepetirContraseña" Width="300px" TextMode="Password"></asp:TextBox>
                    </div>
                    <br />
                    <asp:Button runat="server" ID="btnCambiarContraseña" Text="Cambiar Contraseña" OnClick="btnCambiarContraseña_Click" />
                    <hr />
                </div>
            </div>
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
