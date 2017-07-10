<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Siregra.CambiarContraseña" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Siregra Login</title>
    <link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'>

    <link rel="stylesheet" href="css/style1.css">
</head>
<body>
    <form id="formLogin" runat="server">
        <div runat="server" class="login-form">
            <h1>Siregra</h1>
            <div runat="server" class="form-group ">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Código" ID="PasswordCode"></asp:TextBox>
                <hr />
                <asp:Button runat="server" ID="btnCheckCode" CssClass="log-btn" Text="Verificar" OnClick="btnCheckCode_Click"/>
            </div>
            <div runat="server" id="divPassword" visible="false">
                <div runat="server" class="form-group ">
                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Nueva Contraseña" ID="newPassword" TextMode="Password"></asp:TextBox>
                    <i class="fa fa-lock"></i>
                </div>
                <div class="form-group log-status">
                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Repetir Contraseña" ID="repeatPassword" TextMode="Password"></asp:TextBox>
                    <i class="fa fa-lock"></i>
                </div>        
            <asp:Button runat="server" ID="btnCambiar" CssClass="log-btn" Text="Cambiar Contraseña" OnClick="btnCambiar_Click"/>
            <hr />
            <asp:Button runat="server" ID="btnCancelar" CssClass="log-btn" Text="Cancelar" OnClick="btnCancelar_Click"/>
                </div>
        </div>
        <script src="js/index1.js"></script>
    </form>
</body>
</html>
