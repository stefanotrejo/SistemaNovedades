<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cuCarpeta.ascx.cs" Inherits="cuCarpeta" %>
<asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
<div class="col-lg-4">
    <div class="ibox float-e-margins">
        <div class="ibox-title">
            <asp:TextBox ID="dcaNombre" type="text" class="form-control" runat="server" placeholder="Nombre de Carpeta"></asp:TextBox>
        </div>
        <div class="ibox-content">
            <div>
                <asp:Label ID="lblDocumentos" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="ibox-content">
            <asp:Button ID="btnNuevoDocumento" class="btn btn-w-m btn-success" runat="server"
                Text="Agregar Documento" OnClick="btnNuevoDocumento_Click" />
            <asp:Button ID="btEliminarCarpeta" class="btn btn-w-m btn-danger" runat="server"
                Text="Eliminar Carpeta" OnClick="btEliminarCarpeta_Click" />
            <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar"
                OnClick="btnAceptar_Click" Visible="False" />
            <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
                OnClick="btnCancelar_Click" Visible="False" />
        </div>
    </div>
</div>
