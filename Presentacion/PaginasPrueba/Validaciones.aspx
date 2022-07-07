<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validaciones.aspx.cs" Inherits="PaginasPrueba_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" required placeholder="requerido"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Aceptar" />
        <asp:Button ID="Button2" runat="server" Text="Cancelar" formnovalidate="formnovalidate" /> <br /> <br />
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Entero" type="number" step="1"></asp:TextBox><br /> <br />
         <asp:TextBox ID="TextBox3" runat="server" placeholder="Decimal" type="number" step="0.1"></asp:TextBox><br /> <br />
         <asp:TextBox ID="TextBox4" runat="server" ToolTip="Mes de eventual" placeholder="Valor comprendido entre 1 y 12" type="number" step="1" min="1" Max="12" Width="300px"></asp:TextBox> <br /><br /> 
          <asp:TextBox ID="TextBox5" runat="server" placeholder="Solo letras" type="text" Width="300px" pattern="[A-Za-z]+" ></asp:TextBox> <br /><br />
        <asp:TextBox ID="TextBox6" runat="server" placeholder="Largo de texto entre 5 y 9 caracteres" type="text" Width="300px" minlength="5" maxlength="9" ></asp:TextBox> <br /><br />
        <asp:TextBox ID="TextBox7" runat="server" placeholder="Validar Email" type="email" Width="300px"></asp:TextBox> <br /><br />
        <asp:TextBox ID="TextBox8" runat="server" placeholder="anteponer http://" type="url" Width="300px"></asp:TextBox> <br /><br />
        <asp:TextBox ID="TextBox9" runat="server" placeholder="Validar fecha" type="date" Width="300px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
