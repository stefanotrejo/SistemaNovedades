<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AgenteConsulta.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                            <hr class="hr-line-dashed" />
                            <%--  RADIO IN LINE --%>
                            <div class="form-group">
                                <label class="control-label col-md-2">Buscar Agente por:</label>
                                <div class="col-md-6">
                                    <asp:RadioButton ID="RadioDni" runat="server" Text="DNI" AutoPostBack="True" OnCheckedChanged="RadioDni_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    <asp:RadioButton ID="RadioApellidoyNombre" runat="server" Text="Apellido y Nombre" AutoPostBack="True" OnCheckedChanged="RadioApellidoyNombre_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    <asp:RadioButton ID="RadioNumeroControl" runat="server" Text="Numero de Control" AutoPostBack="True" OnCheckedChanged="RadioNumeroControl_CheckedChanged"></asp:RadioButton>



                                    <%--<asp:RadioButton ID="RadioCuil" runat="server" Text="CUIL" AutoPostBack="True" OnCheckedChanged="RadioCuil_CheckedChanged"></asp:RadioButton>--%>
                                </div>
                            </div>

                            <%-- //////////////////////////////--%>
                            <div class="form-group">
                                <%--<div class="col-md-3 col-md-offset-2">--%>
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <%-- <asp:TextBox ID="txtAgeNroControl" type="number" step="1" min="0" class="form-control" placeholder="Ingrese Nº de Control o Cuil" required runat="server"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtAgeNroControl" class="form-control" placeholder="Ingrese DNI, Nombre o Nº de Control" required runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Año:</label>
                                <label class="control-label col-md-1">Mes:</label>
                                <label class="control-label col-md-2">Año:</label>
                                <label class="control-label col-md-1">Mes:</label>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Periodo de Liq. Desde:
                                </label>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="MenuRaizListaAnioDesde" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px" OnSelectedIndexChanged="MenuRaizListaAnioDesde_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="MenuRaizListaMesDesde" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-1">
                                    Hasta:
                                </label>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="MenuRaizListaAnioHasta" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px" OnSelectedIndexChanged="MenuRaizListaAnioHasta_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="MenuRaizListaMesHasta" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <!–OBTENER AGENTE POR NUMERO DE CONTROL –>
                                    <asp:Button ID="btnConsultar1" class="btn btn-w-m btn-primary" runat="server" Text="Consultar" OnClick="btnConsultar_Click" Style="height: 36px" />
                                </div>
                            </div>
                    </div>


                    <%-- CARGOS DEL AGENTE --%>

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="ibox-title">
                                <h5>Cargos del Agente |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                            </div>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>                                     
                                    Cargando informacion...
                                </ProgressTemplate>
                            </asp:UpdateProgress>                            
                            <div class="ibox-content">
                                <div class="table-responsive">
                                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">

                                        <PagerStyle
                                            Height="30px"
                                            VerticalAlign="Bottom"
                                            HorizontalAlign="Center" Font-Size="Medium" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="Periodo">
                                                <ItemTemplate>
                                                    <%--<asp:HyperLink ForeColor="Black" ID="Liquidacion" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," + DataBinder.Eval(Container.DataItem,"Periodo").ToString() %>' Text='<%# Eval("Periodo") %>' />--%>
                                                    <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="HyperLink1" runat="server" 
                                                        NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "," + txtAgeNroControl.Text + "," + GlobalesAgenteConsulta.tipoOp + "," + GlobalesAgenteConsulta.indexOp + "," + GlobalesAgenteConsulta.FechaAux1 + "," + GlobalesAgenteConsulta.FechaAux2 %>' Text='<%# Eval("Periodo") %>' />
                                                    <%-- <asp:LinkButton ForeColor="Black" ID="linkGoSomewhere" runat="server" Click="Grilla_Click" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Nº de Control">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="HyperLink1" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "," + txtAgeNroControl.Text + "," + GlobalesAgenteConsulta.tipoOp + "," + GlobalesAgenteConsulta.indexOp + "," + GlobalesAgenteConsulta.FechaAux1 + "," + GlobalesAgenteConsulta.FechaAux2 %>' Text='<%# Eval("Numero de Control") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cuil">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="Id" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "," + txtAgeNroControl.Text + "," + GlobalesAgenteConsulta.tipoOp + "," + GlobalesAgenteConsulta.indexOp + "," + GlobalesAgenteConsulta.FechaAux1 + "," + GlobalesAgenteConsulta.FechaAux2 %>' Text='<%# Eval("Cuil") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <%-- <asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() %>' Text='<%# Eval("Nombre") %>' />--%>
                                                    <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="Nombre" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "," + txtAgeNroControl.Text + "," + GlobalesAgenteConsulta.tipoOp + "," + GlobalesAgenteConsulta.indexOp + "," + GlobalesAgenteConsulta.FechaAux1 + "," + GlobalesAgenteConsulta.FechaAux2 %>' Text='<%# Eval("Nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Organismo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="EsAdministrador" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "," + txtAgeNroControl.Text + "," + GlobalesAgenteConsulta.tipoOp + "," + GlobalesAgenteConsulta.indexOp + "," + GlobalesAgenteConsulta.FechaAux1 + "," + GlobalesAgenteConsulta.FechaAux2 %>' Text='<%# Eval("Lugar de Pago") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cargo">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="Activo" runat="server" NavigateUrl='<%# "AgenteDetalle.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() + "," +  DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "," + txtAgeNroControl.Text + "," + GlobalesAgenteConsulta.tipoOp + "," + GlobalesAgenteConsulta.indexOp + "," + GlobalesAgenteConsulta.FechaAux1 + "," + GlobalesAgenteConsulta.FechaAux2 %>' Text='<%# Eval("Cargo") %>' />
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
                            <%--<div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <!–GENERAR LISTADO –>
                                    <asp:Button ID="btnListar" class="btn btn-w-m btn-primary" runat="server" Text="Listar" OnClick="btnListar_Click" Style="height: 36px" />
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>

            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
