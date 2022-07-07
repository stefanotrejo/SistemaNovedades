<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CU_SubirArchivo.ascx.cs"
    Inherits="Controles_Particulares_CU_SubirArchivo" %>
<div>
    <table width="50%" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                <asp:FileUpload ID="fup" runat="server" />
                <asp:Button ID="btnSubirArchivo" runat="server" Text="Subir Archivo" OnClick="btnSubirArchivo_Click" />
            </td>
        </tr>
    </table>
</div>
<asp:Label ID="lblCarpeta" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lblArchivoNombre" runat="server" Text="" Visible="false"></asp:Label>
