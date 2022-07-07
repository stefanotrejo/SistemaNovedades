<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="UsuariosConectados.aspx.cs" Inherits="UsuariosConectados" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Timer ID="tim" runat="server" OnTick="tim_Tick" Interval="10000" Enabled="true" />
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="ibox-title">
                            <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                        </div>
                        <div class="ibox-content">
                            <div class="table-responsive">
                                <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                                    AutoGenerateColumns="True" OnRowDataBound="Grilla_RowDataBound"
                                    PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <PagerSettings Position="Top" />
                                    <PagerStyle HorizontalAlign="Left" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
