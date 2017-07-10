<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Siregra.LoginPage" %>

<!DOCTYPE html>
<html >
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
         <asp:TextBox runat="server" CssClass="form-control" placeholder="Email" ID="UserEmail"></asp:TextBox>
       <i class="fa fa-user"></i>
     </div>
     <div class="form-group log-status">
       <asp:TextBox runat="server" CssClass="form-control" placeholder="Contraseña" ID="UserPassword" TextMode="Password"></asp:TextBox>
       <i class="fa fa-lock"></i>
     </div>
              <asp:Label runat="server" ID="invalidCredentials" Text="Credenciales inválidas!" ForeColor="Red" Font-Size="Medium" Visible="false"></asp:Label>
      <a class="link" href="OlvideContraseña.aspx">Olvidó su contraseña?</a>
              <asp:Button runat="server" ID="btnLogin" CssClass="log-btn"  Text="Login" OnClick="btnLogin_Click"/>
              <br />
              <br />
              <br />
              <asp:LinkButton runat="server" Text="VER DETALLE DE MANTENCIÓN" ForeColor="Red" PostBackUrl="~/RevisarMantencionCliente.aspx"></asp:LinkButton>
   </div>
        <script src="js/index1.js"></script>
      </form>
  </body>
</html>
