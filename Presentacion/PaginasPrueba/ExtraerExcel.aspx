<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtraerExcel.aspx.cs" Inherits="PaginasPrueba_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
            <asp:Button ID="btnImportarExcel" runat="server" Text="Importar" OnClick="Button1_Click" />           
        </div>
        <br /> <br />
          <div>
            <asp:Label ID="lblCeldaLeida" runat="server" Text="Label" Visible="false" color="red"></asp:Label>
        </div>
      
    </div>
    </form>
</body>
</html>
