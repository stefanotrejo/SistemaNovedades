<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AyudaRegistracionCustom.aspx.cs" Inherits="AyudaRegistracionCustom" %>

<%@ Register TagPrefix="cc1" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content">
                <fieldset class="form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-md-2">Nombre</label><div class="col-md-6">
                            <asp:Label ID="ayuPaginaNombre" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Descripcion</label><div class="col-md-6">
                            <div align="center">
                                <cc1:HtmlEditor ID="ayuDescripcion" runat="server" Visible="true" Height="200px" Width="800px" class="form-control m-b" BorderStyle="None" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
