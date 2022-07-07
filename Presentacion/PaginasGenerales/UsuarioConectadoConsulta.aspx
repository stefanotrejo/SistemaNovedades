<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="UsuarioConectadoConsulta.aspx.cs" Inherits="UsuarioConectadoConsulta" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server" Text="Exportar a Excel" OnClick="btnExportarAExcel_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    

    <div class="row">
	    <div class="col-sm-12">
            <div class="ibox-title"><h5>Listado | <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5></div>
		    <div class="ibox-content">
                <div class="table-responsive"><asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
	                AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
	                PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
	                <Columns>
		                
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Id" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Usuario" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Usuario") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FechaHoraUltimaConexion">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="FechaHoraUltimaConexion" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("FechaHoraUltimaConexion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Guid">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Guid" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Guid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IpPublica">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="IpPublica" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("IpPublica") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Desconectar">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Desconectar" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Desconectar") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:HyperLink ForeColor="Black" ID="Activo" runat="server" NavigateUrl='<%# "UsuarioConectadoRegistracion.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>' Text='<%# Eval("Activo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
		                <asp:TemplateField HeaderText="">
			                <ItemTemplate>
				                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click" ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
				                <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
					                OnClick="btnEliminarAceptar_Click" />
				                <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
					                OnClick="btnEliminarCancelar_Click" />
			                </ItemTemplate>
		                </asp:TemplateField>
	                </Columns>
	                <FooterStyle HorizontalAlign="Left" />
	                <HeaderStyle HorizontalAlign="Left" />
	                <PagerSettings Position="Top" />
	                <PagerStyle HorizontalAlign="Left" />
                </asp:GridView></div>
		    </div>
	    </div>
    </div>
</asp:Content>