<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="MenuRegistracionCustom.aspx.cs" Inherits="MenuRegistracionCustom" %>

<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="upaObs" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:DropDownList ID="MenuRaizLista" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                    Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="MenuRaizLista_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtTituloMenuRaiz" class="form-control" runat="server" placeholder="Titulo menu raiz"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtOrdenMenuRaiz" class="form-control" runat="server" placeholder="Orden menu raiz"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnEliminarMenuRaiz" class="btn btn-w-m btn-danger" runat="server"
                                    Text="Eliminar" OnClick="btnEliminarMenuRaiz_Click" Width="100%" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnAceptarMenuRaiz"
                                    class="btn btn-w-m btn-success" runat="server" Text="Grabar" ValidationGroup="AceptarMenuRaiz"
                                    OnClick="btnAceptarMenuRaiz_Click" Width="100%" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:TextBox ID="txtTituloMenuSecundario" class="form-control" runat="server" placeholder="Nombre Menu Secundario"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtURLMenuSecundario" class="form-control" runat="server" placeholder="URL Menu Secundario"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnNuevoMenuSecundario" class="btn btn-w-m btn-warning" runat="server"
                                    Text="Nuevo" ValidationGroup="AceptarMenuSecundario" OnClick="btnNuevoMenuSecundario_Click" Width="100%" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnAceptarMenuSecundario" class="btn btn-w-m btn-success" runat="server"
                                    Text="Actualizar" ValidationGroup="AceptarMenuSecundario" OnClick="btnAceptarMenuSecundario_Click" Width="100%" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <div class="table-responsive">
                                <asp:GridView ID="Grilla" runat="server" AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound"
                                    OnRowCommand="Grilla_RowCommand" CssClass="table table-striped" data-page-size="30"
                                    data-filter="#filter" PageSize="30">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Url" HeaderText="Url" />
                                        <asp:BoundField DataField="Activo" HeaderText="Activo" />
                                        <asp:ButtonField CommandName="Quitar" HeaderText="Quitar" Text="Quitar" />
                                        <asp:ButtonField CommandName="Seleccionar" HeaderText="Seleccionar" Text="Seleccionar" />
                                        <asp:ButtonField CommandName="ActivarInactivar" HeaderText="" Text="Activar/Inactivar" />
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
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblmenIdSecundario" runat="server" Text="" Visible="false"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
