<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminFolder/Admin.Master" AutoEventWireup="true" CodeBehind="RegistroPaqueteMantencionPage.aspx.cs" Inherits="Siregra.RegistroPaqueteMantencionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <link rel="stylesheet" type="text/css" href="css/MainCSS.css" />
        <script lang="javascript">
     function show()
        {
            document.write("<head runat='server'></head>");
        }
    </script>
    <style>
        .hidder1
        {
            visibility:hidden;
        }
        .hidder2
        {
            display:none;
        }
    </style>
 <script lang="JavaScript" type="text/javascript"> 
  function numbersonly(e)
  {
    var unicode=e.charCode? e.charCode : e.keyCode
    if (unicode!=8 && unicode!=44)
    {
      if (unicode<48||unicode>57)
      { return false}   
    }  
  }  
</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" Font-Size="Larger" Font-Italic="true">Registro de Paquete de Mantención</asp:Label>
    <hr />
    <asp:Table ID="Table1" runat="server" Width="800px">
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="200px"><asp:Label runat="server">Nombre Paquete: </asp:Label></asp:TableCell>
            <asp:TableCell Width="200px">
                <asp:TextBox ID="txtNombrePaquete" runat="server" Width="200px" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="200px"><asp:Label runat="server">Descripcion:   </asp:Label></asp:TableCell>
            <asp:TableCell>
                <textarea id="txtDescripcion" style="width: 200px" runat="server"></textarea>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="100px"><asp:Label runat="server">Duracion en dias: </asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlDuracionDias" runat="server">
                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    <asp:ListItem Value="1">1 dias</asp:ListItem>
                    <asp:ListItem Value="2">2 dias</asp:ListItem>
                    <asp:ListItem Value="3">3 dias</asp:ListItem>
                    <asp:ListItem Value="4">4 dias</asp:ListItem>
                    <asp:ListItem Value="5">5 dias</asp:ListItem>
                    <asp:ListItem Value="6">6 dias</asp:ListItem>
                    <asp:ListItem Value="7">7 dias</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblCostoTotal" runat="server" Text="Costo $:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtCostoTotal" runat="server" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Text="Repuestos Originales"></asp:Label><asp:RadioButton ID="rbOriginales" runat="server" GroupName="rbGroup1" OnCheckedChanged="rbOriginales_CheckedChanged" AutoPostBack="true" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Text="Repuestos Alternativos"></asp:Label>
                <asp:RadioButton ID="rbAlternativos" runat="server" GroupName="rbGroup1" OnCheckedChanged="rbAlternativos_CheckedChanged" AutoPostBack="true" />
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><br /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="150px">
                <asp:Label runat="server">Productos originales: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList Width="200px" ID="ddlProductosOriginales" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Text="Cantidad " ID="lblCantidadOriginal"></asp:Label>
                <asp:TextBox runat="server" ID="txtCantidadOriginales" Width="30px" onkeypress="return numbersonly(event);"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAgregarProductoOriginal" runat="server" Text="Agregar" OnClick="btnAgregarProductoOriginal_Click"/>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="200px"></asp:TableCell>
            <asp:TableCell Width="150px">
                <asp:Label runat="server">Productos alternativos: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList Width="200px" ID="ddlProductosAlternativos" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Text="Cantidad " ID="lblCantidadAlternativos"></asp:Label>
                <asp:TextBox runat="server" ID="txtCantidadAlternativos" Width="30px" onkeypress="return numbersonly(event);"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAgregarProductoAlternativo" runat="server" Text="Agregar" OnClick="btnAgregarProductoAlternativo_Click"/>
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <hr />
    <asp:GridView ID="gridRepuestosAgregados" runat="server" Width="437px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Bottom" >
        <Columns>
            <asp:BoundField DataField="ProductoNombre" HeaderText="Producto"/>
            <asp:BoundField DataField="Costo"  HeaderText="Costo x Producto"/>
            <asp:BoundField DataField="Cantidad"  HeaderText="Cantidad"/>
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
    <asp:Table runat="server">
     <asp:TableRow>
            <asp:TableCell Width="65px"></asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCrearPaquete" runat="server" Text="Crear Paquete" OnClick="btnCrearPaquete_Click" Width="300px" />
            </asp:TableCell>
            <asp:TableCell Width="200px"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <hr />
    <br />
        <asp:GridView ID="gridPaquetesRegistrados" runat="server" Width="437px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowCustomPaging="True" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Bottom" >
        <Columns>
            <asp:BoundField DataField="PaqueteMantencionId" HeaderText="Paquete Id" ItemStyle-CssClass="hidder2" HeaderStyle-CssClass="hidder2" ControlStyle-CssClass="hidder1"/>
            <asp:BoundField DataField="NombrePaqueteMantencion"  HeaderText="Nombre Paquete"/>
            <asp:BoundField DataField="CostoTotal"  HeaderText="Costo Total"/>
            <asp:BoundField DataField="DuracionDias"  HeaderText="Duracion Dias"/>
            <asp:BoundField DataField="Descripcion"  HeaderText="Descripción"/>
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
                                        <asp:Button ID="btnAceptarMensaje" runat="server" CssClass="t_boton" Text="Aceptar" Width="105px" OnClick="btnAceptarMensaje_Click"/>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
</asp:Content>
