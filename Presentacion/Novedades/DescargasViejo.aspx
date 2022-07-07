<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DescargasViejo.aspx.cs" Inherits="Novedades_Descargas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <label>Descarga de Archivos de No Presentismo</label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            OnRowCommand="GridView1_RowCommand" BackColor="White"
            BorderColor="#CC9966" BorderStyle="None"
            BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:TemplateField HeaderText="Archivo" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server"
                            CausesValidation="False"
                            CommandArgument='<%# Eval("Archivo") %>'
                            CommandName="Download" Text='<%# Eval("Archivo") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Tamaño" HeaderText="Tamaño en Bytes" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo de Archivo" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True"
                ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099"
                HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True"
                ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
    </form>
</body>
</html>
