<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="UsuarioConsultaCustom.aspx.cs" Inherits="UsuarioConsultaCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content m-b-sm border-bottom">
                <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo"
                    OnClick="btnNuevo_Click" />
                <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server"
                    Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" />
                <asp:Button ID="btnVolver" class="btn btn-w-m btn-danger" runat="server" Text="Volver"
                    OnClick="btnVolver_Click" Visible="false" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:TextBox ID="Nombre" type="text" class="form-control m-b" runat="server" AutoPostBack="true" placeholder="Nombre"
                            OnTextChanged="btnAplicar_Click"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Apellido" type="text" class="form-control m-b" runat="server" AutoPostBack="true" placeholder="Apellido"
                            OnTextChanged="btnAplicar_Click"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Usuario" type="text" class="form-control m-b" runat="server" AutoPostBack="true" placeholder="Usuario"
                            OnTextChanged="btnAplicar_Click"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="Perfil" runat="server" class="form-control m-b" Enabled="true"
                            AutoPostBack="true" OnSelectedIndexChanged="btnAplicar_Click">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAplicar" class="btn btn-w-m btn-info m-b" runat="server" Text="Aplicar" Width="100%"
                            OnClick="btnAplicar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-title">
                <h5>Listado |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
            </div>
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" CssClass="table table-striped" runat="server" GridLines="None"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Apellido" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Apellido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NombreIngreso">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="NombreIngreso" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("NombreIngreso") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Email" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Email") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Perfil">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Perfil" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Perfil") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "UsuarioRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Activo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                    <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False" OnClick="btnEliminarAceptar_Click" />
                                    <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False" OnClick="btnEliminarCancelar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField CommandName="BlanquearClave" HeaderText="" Text="BlanquearClave" />
                        </Columns>
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
