<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="NovedadesConsultaExtDocente.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                <div class="col-md-12">
                    <%--<div class="ibox-content">--%>
                    <div class="ibox-content m-b-sm border-bottom h5">
                        <asp:Label ID="lblLiquidacion" class="control-label col-md-4 m-b" runat="server" Text="Liquidacion: " Font-Bold></asp:Label>
                        <asp:Label ID="lblEtapa" class="control-label col-md-4 m-b" runat="server" Text="Etapa: " Font-Bold></asp:Label>
                        <asp:LinkButton ID="btnListar" runat="server" class="btn btn-w-m btn-primary m-b;" OnClick="btnListar_Click">
                                      <i class="fa fa-print"></i> Novedades Cargadas</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-w-m btn-primary m-b;" OnClick="btnListarPorUsuario_Click">
                                      <i class="fa fa-print"></i> Novedades Por Usuario</asp:LinkButton>
                        <asp:LinkButton ID="btnGenerarArchivo" runat="server" class="btn btn-w-m btn-primary m-b;" OnClick="btnGenerarArchivo_Click">
                                      <i class="fa fa-download"></i>Generar Archivos</asp:LinkButton>
                        <asp:LinkButton ID="btnDescargarArchivos" runat="server" class="btn btn-w-m btn-primary m-b;" OnClick="btnDescargarArchivos_Click">
                                      <i class="fa fa-download"></i>Descargar Archivos</asp:LinkButton>
                    </div>
                    <div class="ibox-content m-b-sm border-bottom h5">
                        <asp:Label ID="lblFechaCierreTitulo" class="control-label col-md-2 m-b" runat="server" Text="Fecha de Cierre: " Font-Bold></asp:Label>
                        <asp:Label ID="lblFechaCierre" class="control-label col-md-8 m-b" runat="server" Text="" Font-Bold></asp:Label>
                        </div>
                </div>
                <div class="col-md-12">
                    
                    </div>

                <div class="col-md-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <%--  RADIO IN LINE --%>
                            <div class="form-group">
                                <label class="control-label col-md-2">Buscar Agente por:</label>
                                <div class="col-md-6">
                                    <asp:RadioButton ID="RadioDni" runat="server" Text="DNI o CUIL" AutoPostBack="True" OnCheckedChanged="RadioDni_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    <asp:RadioButton ID="RadioApellidoyNombre" runat="server" Text="Apellido y Nombre" AutoPostBack="True" OnCheckedChanged="RadioApellidoyNombre_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    <asp:RadioButton ID="RadioNumeroControl" runat="server" Text="Numero de Control" AutoPostBack="True" OnCheckedChanged="RadioNumeroControl_CheckedChanged"></asp:RadioButton>
                                </div>
                            </div>
                            <%-- FIN RADIO IN LINE --%>
                          
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgeNroControl" class="form-control" placeholder="Ingrese DNI, Nombre o Nº de Control" required runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2"></label>
                                <asp:CheckBox ID="checkObtenerTodos" runat="server" AutoPostBack="true" Checked="true" Width="20px" OnCheckedChanged="checkObtenerTodos_CheckedChanged" />
                                <!--<label>Buscar en Todas las Jurisdicciones</label>-->
                                <asp:Label ID="lblJurisdiccion" runat="server" Text="Buscar en Todas las Jurisdicciones" Font-Bold></asp:Label>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="selectJurisdiccion" runat="server" class="form-control" data-placeholder="Seleccione una opcion"
                                        Enabled="true" AutoPostBack="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-8">
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button ID="btnConsultar1" class="btn btn-w-m btn-primary" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                                </div>
                            </div>
                    </div>
                </div>

                <!--</div>-->


                <%-- CARGOS DEL AGENTE --%>

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
                                            <asp:HyperLink
                                                ForeColor="Black"
                                                Font-Size="Small"
                                                ID="HyperLink1"
                                                runat="server"
                                                NavigateUrl='<%# "NovedadesNuevo.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() 
                                                            + "&periodo=" + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "&textBox=" 
                                                            + txtAgeNroControl.Text 
                                                            + "&radioSeleccionado=" + Session["radioSeleccionado"].ToString()
                                                            + "&pageIndex=" + Session["pageIndex"].ToString()
                                                            + "&agrupamiento=" + DataBinder.Eval(Container.DataItem,"agru").ToString() %>'
                                                Text='<%# Eval("Periodo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nº de Control">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="HyperLink1" runat="server"
                                                NavigateUrl='<%# "NovedadesNuevo.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() 
                                                            + "&periodo=" + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "&textBox=" 
                                                            + txtAgeNroControl.Text 
                                                            + "&radioSeleccionado=" + Session["radioSeleccionado"].ToString()
                                                            + "&pageIndex=" + GlobalesNovedadesConsulta.pageIndex
                                                             + "&agrupamiento=" + DataBinder.Eval(Container.DataItem,"agru").ToString() %>'
                                                Text='<%# Eval("Numero de Control") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cuil">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="Id" runat="server"
                                                NavigateUrl='<%# "NovedadesNuevo.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() 
                                                            + "&periodo=" + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "&textBox=" 
                                                            + txtAgeNroControl.Text 
                                                            + "&radioSeleccionado=" + Session["radioSeleccionado"].ToString()
                                                            + "&pageIndex=" + GlobalesNovedadesConsulta.pageIndex
                                                             + "&agrupamiento=" + DataBinder.Eval(Container.DataItem,"agru").ToString() %>'
                                                Text='<%# Eval("Cuil")
                                                              %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="Nombre" runat="server"
                                                NavigateUrl='<%# "NovedadesNuevo.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() 
                                                            + "&periodo=" + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "&textBox=" 
                                                            + txtAgeNroControl.Text 
                                                            + "&radioSeleccionado=" + Session["radioSeleccionado"].ToString()
                                                            + "&pageIndex=" + GlobalesNovedadesConsulta.pageIndex
                                                             + "&agrupamiento=" + DataBinder.Eval(Container.DataItem,"agru").ToString() %>'
                                                Text='<%# Eval("Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Organismo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="EsAdministrador" runat="server"
                                                NavigateUrl='<%# "NovedadesNuevo.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() 
                                                            + "&periodo=" + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "&textBox=" 
                                                            + txtAgeNroControl.Text 
                                                            + "&radioSeleccionado=" + Session["radioSeleccionado"].ToString()
                                                            + "&pageIndex=" + GlobalesNovedadesConsulta.pageIndex
                                                             + "&agrupamiento=" + DataBinder.Eval(Container.DataItem,"agru").ToString() %>'
                                                Text='<%# Eval("Lugar de Pago") 
                                                        %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cargo">
                                        <ItemTemplate>
                                            <asp:HyperLink ForeColor="Black" Font-Size="Small" ID="Activo" runat="server"
                                                NavigateUrl='<%# "NovedadesNuevo.aspx?Id=" + DataBinder.Eval(Container.DataItem,"NuevoAgeId1").ToString() 
                                                            + "&periodo=" + DataBinder.Eval(Container.DataItem,"Periodo").ToString() + "&textBox=" 
                                                            + txtAgeNroControl.Text 
                                                            + "&radioSeleccionado=" + Session["radioSeleccionado"].ToString()
                                                            + "&pageIndex=" + GlobalesNovedadesConsulta.pageIndex
                                                             + "&agrupamiento=" + DataBinder.Eval(Container.DataItem,"agru").ToString()%>'
                                                Text='<%# Eval("Cargo") %>' />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
