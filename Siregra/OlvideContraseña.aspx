<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvideContraseña.aspx.cs" Inherits="Siregra.OlvideContraseña" %>

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
              <div>
                  <asp:Label runat="server" Font-Bold="true" Text="Escriba su correo, enviaremos un email para proceder al cambio de su contraseña, gracias."></asp:Label>
              </div>
              <hr />
     <div runat="server" class="form-group ">
         <asp:TextBox runat="server" CssClass="form-control" placeholder="Email" ID="ForgotPasswordUserEmail"></asp:TextBox>
       <i class="fa fa-user"></i>
     </div>
              <asp:Button runat="server" ID="btnSendEmail" CssClass="log-btn"  Text="Enviar" OnClick="btnSendEmail_Click"/>
              <hr />
              <asp:Button runat="server" ID="btnCancel" CssClass="log-btn"  Text="Cancelar" OnClick="btnCancel_Click"/>
   </div>
        <script src="js/index1.js"></script>
      </form>
  </body>
</html>
