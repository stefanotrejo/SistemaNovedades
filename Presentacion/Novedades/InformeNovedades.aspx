<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformeNovedades.aspx.cs" Inherits="UsuarioRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <asp:TextBox ID="txt" class="form-control" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtIndex" class="form-control" Visible="false" runat="server"></asp:TextBox>
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">

                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Año:
                                </label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="listaAnios" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px" OnSelectedIndexChanged="MenuRaizListaAnioDesde_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Mes:
                                </label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="listaMeses" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px" OnSelectedIndexChanged="listaMeses_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Liquidacion:
                                </label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="listaLiquidaciones" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="340px" OnSelectedIndexChanged="listaLiquidaciones_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:Button ID="btnGenerarListado" class="btn btn-w-m btn-primary" runat="server" Text="Generar listado"
                                        OnClick="btnGenerarListado_Click" Style="height: 36px" Enabled="true" />
                                </div>
                            </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
