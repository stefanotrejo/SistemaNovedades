<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="PaginasBasicas_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Liquidación de Sueldos</title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link rel="shortcut icon" href="../Imagenes/logo3.png" />
    <style type="text/css">
        .nuevoEstilo1
        {
            color: #FFFFFF;
        }
        .nuevoEstilo2
        {
            color: #FFFFFF;
        }
        .nuevoEstilo3
        {
            color: #FFFFFF;
            font-weight: 700;
        }
        .nuevoEstilo4
        {
            color: #FFFFFF;
        }
        .nuevoEstilo5
        {
            color: #FFFFFF;
        }
        .nuevoEstilo6
        {
            color: #FFFFFF;
        }
        .style1
        {
            color: #FFFFFF;
            font-size: 11pt;
            font-weight: 700;
        }
    </style>
</head>
<body class="gray-bg" background="../Imagenes/FondoPrincipal.jpg">
    <form id="form1" runat="server">
         <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>
                <h1 class="logo-name">
                    <asp:Image ID="ima" runat="server" ImageUrl="../Imagenes/logo.png" Height="150" Width="300" />
                </h1>
            </div>
            <p class="style1">
                Bienvenido a
                <asp:Label ID="lblClienteNombre" runat="server" Text=""></asp:Label><br />
                Ingreso al sistema. v1.2.2</p>
            <div class="form-group">
                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario"
                    required=""></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtClave" runat="server" type="password" class="form-control" placeholder="Clave"
                    required=""></asp:TextBox>
            </div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-primary block full-width m-b"
                OnClick="btnIngresar_Click" />
            <div>
                <asp:Label ID="lblUsuarioNoValido" runat="server" Text="Usuario y/o Clave no validos"
                    Visible="False" CssClass="nuevoEstilo3"></asp:Label></div>
            <%--<div>
                <asp:HyperLink ID="hliRecuperarClave" runat="server" Target="_blank" Font-Bold="True"
                    NavigateUrl="~/PaginasBasicas/RecuperarClave.aspx" ForeColor="White">Recuperar Clave</asp:HyperLink>
            </div>--%>
            <br />
            <div style="color: white">Refrescar Navegador Chrome: Ctrl + F5</div>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script type="text/javascript" src="../js/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
