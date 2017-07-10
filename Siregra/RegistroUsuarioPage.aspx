<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarioPage.aspx.cs" Inherits="Siregra.RegistroUsuarioPage" Async="true" %>
<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link rel="stylesheet" type="text/css" href="css/MainCSS.css" />
<script lang="javascript">
function show()
{
document.write("<head runat='server'></head>");
}
</script>

        <style>
        .txtHide
        {
            visibility:hidden;          
        }
        .ids
        {
            display:none;
        }
    </style>
        <script type="text/javascript">
        function renameRutAndProcess(obj) {
            var rut = obj.value;
            if (!/\./.test(rut)) {
                var nuevo = "";
                for (var i = 0; i < rut.length; i++) {
                    if (i == 1 || i == 4) {
                        nuevo += rut[i] + '.';
                    } else if (i == (rut.length - 1)) {
                        nuevo += '-' + rut[i];
                    } else {
                        nuevo += rut[i];
                    }
                }
                obj.value = nuevo;
            }
        }

        function textbox_number_onkeypress(e) {

            if (window.event) {
                code = e.keyCode;
            } else {
                code = e.which;
            };
            if (code >= 48 && code <= 57) {
                return true;
            }

            if (code == 107 || code == 46 || code == 45) {
                return true;
            }

            event.preventDefault();
            return false;
        }

        function textbox_email_onkeypress(e) {

            if (window.event) {
                code = e.keyCode;
            } else {
                code = e.which;
            };
            if (code >= 64 && code <= 90) {
                return true;
            }

            if (code >= 97 && code <= 122) {
                return true;
            }

            if (code >= 48 && code <= 57) {
                return true;
            }

            if (code == 45 || code == 42 || code == 95 || code == 94 || code == 46 || code == 38) {
                return true;
            }

            event.preventDefault();
            return false;
        }

        function textbox_letter_onkeypress(e) {

            if (window.event) {
                code = e.keyCode;
            } else {
                code = e.which;
            };
            if (code >= 65 && code <= 90) {
                return true;
            }

            if (code >= 97 && code <= 122) {
                return true;
            }

            if (code >= 160 && code <= 163) {
                return true;

            }

            if (code == 225 || code == 233 || code == 237 || code == 243 || code == 250) {
                return true;
            }

            if (code == 38 || code == 39 || code == 32 || code == 130 || code == 164 || code == 241) {
                return true;
            }
            event.preventDefault();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="upd">
        <ContentTemplate>
        <asp:Label runat="server" Font-Size="Larger" Font-Italic="true">Registro de Usuarios</asp:Label>
    <hr />
    <asp:Label runat="server" ID="userId" CssClass="txtHide"></asp:Label>
    <asp:Table ID="Table1" runat="server" Width="800px">
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="100px"><asp:Label runat="server">Perfil</asp:Label></asp:TableCell>
            <asp:TableCell Width="200px">
                <asp:DropDownList ID="ddlPerfil" runat="server">
                </asp:DropDownList>
            </asp:TableCell >
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="100px"><asp:Label runat="server">Rut: </asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRutPersona" runat="server" onkeyPress="return textbox_number_onkeypress(event);" onblur="renameRutAndProcess(this);"></asp:TextBox></asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="200px">
            <asp:TableCell></asp:TableCell>
            <asp:TableCell Width="100px"><asp:Label runat="server">Nombre: </asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNombrePersona" runat="server" onkeyPress="return textbox_letter_onkeypress(event);"></asp:TextBox></asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="100px"><asp:Label runat="server">Apellido: </asp:Label></asp:TableCell>
            <asp:TableCell> <asp:TextBox ID="txtApellidoPersona" runat="server" onkeyPress="return textbox_letter_onkeypress(event);"></asp:TextBox></asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="100px"><asp:Label runat="server">Email: </asp:Label></asp:TableCell>
            <asp:TableCell> <asp:TextBox ID="txtEmailPersona" runat="server" onkeyPress="return textbox_email_onkeypress(event);"></asp:TextBox></asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell runat="server" Width="100px">
                <asp:Button ID="btnRegistrarUsuario" runat="server" Text="Guardar" BorderStyle="Ridge" OnClick="btnRegistrarUsuario_Click" />
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <hr />
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell>
                        <asp:GridView ID="gridUsuariosRegistrados" runat="server" Width="700px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                             BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" 
                            AutoGenerateColumns="False" CaptionAlign="Bottom" OnSelectedIndexChanged="gridUsuariosRegistrados_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="idUsuario" HeaderText="Id" ItemStyle-CssClass="ids" HeaderStyle-CssClass="ids" ControlStyle-CssClass="txtHide"/>
            <asp:BoundField DataField="RutUsuario" HeaderText="Rut"/>
            <asp:BoundField DataField="NombreUsuario"  HeaderText="Nombre Usuario"/>
            <asp:BoundField DataField="ApellidoUsuario"  HeaderText="Apellido Usuario"/>
            <asp:BoundField DataField="EmailUsuario"  HeaderText="Email Usuario"/>
            <asp:BoundField DataField="PerfilUsuario"  HeaderText="Perfil"/>
            <asp:BoundField DataField="PerfilUsuarioId" HeaderText="Perfil Id" ItemStyle-CssClass="ids" HeaderStyle-CssClass="ids" ControlStyle-CssClass="txtHide"/>
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
