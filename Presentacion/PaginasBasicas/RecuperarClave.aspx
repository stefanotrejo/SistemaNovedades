<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecuperarClave.aspx.cs" Inherits="RecuperarClave" %>

<%@ Register Assembly="GoogleReCaptcha" Namespace="GoogleReCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Liquidación de Sueldos</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link rel="shortcut icon" href="../Imagenes/logo3.png" />
</head>
<body class="gray-bg" background="../Imagenes/FondoPrincipal.jpg">
    <form id="form1" runat="server">
    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <h1 class="logo-name">
                <asp:Image ID="ima" runat="server" ImageUrl="../Imagenes/logo.png" Height="150" Width="300" />
            </h1>
        </div>
        <p style="color: white; font-weight: bold;">
            Recuperar Clave</p>
        <div class="form-group">
            <asp:TextBox ID="Usuario" type="text" class="form-control" placeholder="Ingrese Usuario (*)"
                runat="server" ValidationGroup="Enviar" required></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="EmailRecuperacion" type="email" class="form-control" placeholder="Ingrese email de recuperacion (*)"
                runat="server" ValidationGroup="Enviar" required></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </div>
        <div class="form-group">
            <asp:Button ID="btnEnviarEmail" runat="server" Text="Enviar email de recuperacion"
                class="btn btn-primary block full-width m-b" Visible="true" OnClick="btnEnviarEmail_Click"
                ValidationGroup="Enviar" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblMensajeResultado" runat="server" ForeColor="White"></asp:Label>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script type="text/javascript" src="../js/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
