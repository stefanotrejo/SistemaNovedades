<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="PagosEventualesOrigenReclamo.aspx.cs" Inherits="ParametroConsultaCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Button ID="btnNuevoMenuSecundario" class="btn btn-w-m btn-warning" runat="server"
                            Text="Nuevo GEDO" ValidationGroup="AceptarMenuSecundario" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:TextBox ID="Nombre" type="text" class="form-control" runat="server" placeholder="Buscar por Nombre"
                            AutoPostBack="True" OnTextChanged="Nombre_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info" runat="server" Text="Aplicar" Width="100%" Visible="true"
                            OnClick="btnAplicar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="margin-top: 5px">
        <div class="col-sm-12">
            <div class="ibox-title">
                <!--<h3>Resultados</h3>-->
                <h3>
                    <!--<asp:Label ID="Label1" runat="server" Text="Resultados - "></asp:Label>-->
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label>
                </h3>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    Cargando informacion...
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div class="ibox float-e-margins">
                <div class="ibox-content">
                    <div class="table-responsive">
                        <asp:GridView ID="Grilla" runat="server" AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound"
                            OnRowCommand="Grilla_RowCommand" CssClass="table table-striped" data-page-size="30"
                            data-filter="#filter" PageSize="30">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:ButtonField CommandName="Actualizar" HeaderText="Actualizar GEDO" Text="Actualizar" />
                                <asp:ButtonField CommandName="Cargar Pagos" HeaderText="Cargar Pagos" Text="Cargar" />
                            </Columns>
                            <FooterStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <PagerSettings Position="Top" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
