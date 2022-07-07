<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="UsuarioRegistracionCustom.aspx.cs" Inherits="UsuarioRegistracionCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">
                <fieldset class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-0">
                            <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar"
                                OnClick="btnAceptar_Click" />
                            <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar"
                                OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />
                    <div class="form-group">
                        <label class="control-label col-md-2">
                            Apellido</label><div class="col-md-6">
                                <asp:TextBox ID="usuApellido" Height="50px" TextMode="MultiLine" type="text" class="form-control"
                                    runat="server"></asp:TextBox></div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                            Nombre</label><div class="col-md-6">
                                <asp:TextBox ID="usuNombre" Height="50px" TextMode="MultiLine" type="text" class="form-control"
                                    runat="server"></asp:TextBox></div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                            Nombre Ingreso</label><div class="col-md-6">
                                <asp:TextBox ID="usuNombreIngreso" type="text" class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                            Email</label><div class="col-md-6">
                                <asp:TextBox ID="usuEmail" Height="50px" TextMode="MultiLine" type="text" class="form-control"
                                    runat="server"></asp:TextBox></div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                            Perfil</label><div class="col-md-6">
                                <asp:DropDownList ID="perId" runat="server" class="form-control m-b" Enabled="true">
                                </asp:DropDownList>
                            </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">
                            Activo</label><div class="col-md-6">
                                <asp:CheckBox ID="usuActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox></div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
