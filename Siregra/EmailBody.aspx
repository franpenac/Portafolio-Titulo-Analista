<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailBody.aspx.cs" Inherits="Siregra.EmailBody" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="color: gray; font-weight: bold; font-family: 'Times New Roman', Times, serif">Email para confirmación y cambio de contraseña para Siregra</h2>
            <br />
            <div>
                <div>
                    <p>Ingrese el codigo bajo a este link en la siguiente página para proceder a cambio de contraseña: </p>
                    <a href="#WEB_SITE/CambiarContraseña.aspx">Cambiar contraseña</a>
                    <br />
                    <br />
                    <label style="text-decoration:underline; text-decoration:solid; font-size:20px">#CODE</label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
