<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="PagosEventualesConsulta.aspx.cs" Inherits="ParametroConsultaCustom" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-sm-12">
            <div class="ibox-content m-b-sm border-bottom">
                <asp:Button ID="btnNuevo" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server"
                    Text="Generar Archivo .Txt" OnClick="btnExportarTxt_Click" style="height: 36px"/>  

                <%--Informes Tesoreria y Contaduria--%>                              
                  <asp:Button ID="btnTesoreria" class="btn btn-w-m btn-success" runat="server"
                    Text="Informe Tesoreria" OnClick="btnInformeTesoreria_Click" style="height: 36px"/>  
                  <asp:Button ID="btnContaduria" class="btn btn-w-m btn-success" runat="server"
                    Text="Informe Contaduria" OnClick="btnInformeContaduria_Click" style="height: 36px"/>  
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12" style="left: 0px; top: 0px">                                      
            <div class="ibox-content">
                <h5>Seleccione la fecha de los pagos eventuales:
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h5>
                <div class="form-inline">
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:DropDownList ID="MenuRaizLista" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                    Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="MenuRaizLista_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">


        <div class="col-sm-12">
            <div class="ibox-content m-b-sm border-bottom">
                <asp:Button ID="Button1" class="btn btn-w-m btn-success" runat="server" Text="Buscar" Visible="true"
                    OnClick="btnAplicar_Click" />
                <%--<asp:Button ID="Button2" class="btn btn-w-m btn-success" runat="server" Text="Mostrar Historial Fechas" Visible="true"
                    OnClick="btnTraerTodos_Click" />--%>
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
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ageApellidoNombre" runat="server" NavigateUrl='<%# "ParametroRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"ageApellidoNombre").ToString() %>'
                                        Text='<%# Eval("ageApellidoNombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CUIT">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ageDNI" runat="server" NavigateUrl='<%# "ParametroRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"ageCuit").ToString() %>'
                                        Text='<%# Eval("ageDNI") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lugar de Pago">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="lpaNombre" runat="server" NavigateUrl='<%# "ParametroRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"lpaNombre").ToString() %>'
                                        Text='<%# Eval("lpaNombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Importe">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="pevImporte" runat="server" NavigateUrl='<%# "ParametroRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"pevImporteTotal").ToString() %>'
                                        Text='<%# Eval("pevImporteTotal") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Numero de Control">
                                <ItemTemplate>
                                    <asp:HyperLink ForeColor="Black" ID="ageNroControl" runat="server" NavigateUrl='<%# "ParametroRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"ageNroControl").ToString() %>'
                                        Text='<%# Eval("ageNroControl") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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
