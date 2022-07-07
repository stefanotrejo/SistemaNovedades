<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="Permisos" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="upaObs" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-12" style="left: 0px; top: 0px; margin-top: 0px">
                    <div class="ibox-content">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:DropDownList ID="perId" runat="server" class="form-control m-b"
                                    Enabled="true" AutoPostBack="True"
                                    OnSelectedIndexChanged="perId_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="menId" runat="server" class="form-control m-b"
                                    Enabled="true" AutoPostBack="True"
                                    OnSelectedIndexChanged="menId_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:GridView ID="GrillaPermiso" runat="server" AutoGenerateColumns="False" OnRowDataBound="GrillaPermiso_RowDataBound"
                                OnRowCommand="GrillaPermiso_RowCommand" AllowPaging="True" OnPageIndexChanging="GrillaPermiso_PageIndexChanging"
                                CssClass="table table-striped" data-page-size="200" data-filter="#filter"
                                PageSize="12">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="Menu" HeaderText="Menu" />
                                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                                    <asp:ButtonField CommandName="Quitar" HeaderText="Quitar" Text="Quitar" />
                                </Columns>
                                <PagerSettings Position="Top" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
