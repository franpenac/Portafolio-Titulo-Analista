<%@ Page Title="" Language="C#" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="RegistroAlternativos.aspx.cs" Inherits="Siregra.RegistroAlternativos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <table style="width:800px; " runat="server">
        <tr>
            <td style="width:200px"></td>
            <td style="width:400px">
                <asp:label runat="server" text="Registro de repuesto alternativo" Font-Bold="True" Font-Size="14pt"></asp:label>
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
                <asp:label runat="server" text="Registro de repuesto alternativo" Font-Bold="True" Font-Size="14pt"></asp:label>
                <hr />
            </td>
            
            <td style="width:200px"></td>
        </tr>
    </table>

        <table style="width:800px; " runat="server">
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;</td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label1" runat="server" Text="Nombre modelo"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlModelo" runat="server" Height="17px" Width="124px">
                </asp:DropDownList>
            </td>
            <td style="width:200px"></td>
        </tr>
            <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
            <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label8" runat="server" Text="Costo"></asp:Label>
                </td>
            <td style="width:200px">
                <asp:TextBox ID="txbCosto" runat="server"></asp:TextBox>
                </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Eliminar Taller"></asp:Label>
                </td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlEliminar" runat="server" Width="160px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label2" runat="server" Text="Proveedor"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlProveedor" runat="server" Height="16px" Width="122px">
                </asp:DropDownList>
            </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            </td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label5" runat="server" Text="Tipo de repuesto"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlTipoProducto" runat="server" Height="20px" Width="120px">
                </asp:DropDownList>
            </td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="Modificar Taller"></asp:Label>
            </td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlModificar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModificar_SelectedIndexChanged" Width="158px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label3" runat="server" Text="Marca"></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlMarca" runat="server" Height="19px" Width="121px">
                </asp:DropDownList>
            </td>
            <td style="width:200px"></td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:Label ID="Label7" runat="server" Text="Alternativo de: "></asp:Label>
            </td>
            <td style="width:200px">
                <asp:DropDownList ID="ddlTipoRecapado" runat="server" Height="16px" Width="122px">
                </asp:DropDownList>
            </td>
            <td style="width:200px"></td>
        </tr>
        <tr style="height:25px; ">
            <td style="width:200px"></td>
            <td style="width:200px">&nbsp;</td>
            <td style="width:200px">&nbsp;</td>
            <td style="width:200px"></td>
        </tr>
        <tr>
            <td style="width:200px"></td>
            <td style="width:200px">
                <asp:button runat="server" text="Guardar" ID="btnGuardar" />
            </td>
            <td style="width:200px">
                <asp:button runat="server" text="Nuevo" ID="btnNuevo" />
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
                    <asp:gridview runat="server" Width="250px">
                    </asp:gridview>
                </td>
                <td style="width:200px"></td>
            </tr>
        </table>
    
         </div>
        
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
