<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="NovedadesNuevo.aspx.cs" Inherits="UsuarioRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <%--<div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>--%>
                <div class="col-sm-12">
                    <div class="ibox-title">
                        <h2>Agente
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </h2>
                    </div>
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <%--GRUPO 1--%>
                            <div class="form-group">

                                <%--1-A--%>
                                <label class="control-label col-md-1">
                                    Cuil
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtAgeCuit" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--1-B--%>
                                <label class="control-label col-md-2">Apellido y Nombre</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeApellidoNombre" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--1-C--%>
                                <label class="control-label col-md-1">Control</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeNroControl" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%--GRUPO 1--%>
                            </div>


                            <%-- SEGUNDO GRUPO --%>
                            <div class="form-group">
                                <%--2-A--%>
                                <label class="control-label col-md-1">
                                    Planta
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtAgePlanta" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--2-B--%>

                                <label class="control-label col-md-2">
                                    Organismo
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeLugarPago" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--2-C--%>
                                <asp:Label runat="server" ID="lblEscuela" Font-Bold="true" class="control-label col-md-1">Escuela</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeEscuela" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%-- SEGUNDO GRUPO --%>
                            </div>
                    </div>
                    <!-- <br />
                    <div class="form-group">
                        <%--<asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>--%>
                    </div> -->

                    <%--ALTA DE NOVEDADES--%>

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="ibox-title">
                                <h2>Carga de Novedad</h2>
                            </div>

                            <div class="ibox-content">

                                <div class="form-inline">
                                    <div class="col-md-3">
                                        <h4>Concepto</h4>
                                    </div>
                                    <div class="col-md-2">
                                        <h4>Cantidad Dias/Min</h4>
                                    </div>
                                    <div class="col-md-4">
                                        <h4>Fecha</h4>
                                    </div>
                                </div>

                                <div class="form-inline">

                                    <div class="form-group">
                                        <asp:DropDownList ID="ComboConceptos" runat="server" class="form-control m-b" Enabled="true"
                                            AutoPostBack="true" Width="320px" OnSelectedIndexChanged="ComboConceptos_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtDiasMin" type="number" class="form-control m-b" runat="server"
                                            AutoPostBack="true" step="1" min="1" Max="60" Width="150px"
                                            placeholder="Dias/Min"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtFecha" type="date" class="form-control m-b" runat="server"
                                            AutoPostBack="false" placeholder="fecha"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-w-m btn-primary m-b" OnClick="btnAgregarNovedad_Click">
                                      <i class="fa fa-plus"></i> Agregar</asp:LinkButton>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="margin-top: 10px">
                        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                    </div>
                    <%--FIN ALTA DE NOVEDADES--%>

                    <%--TABLA NOVEDADES REGISTRADAS--%>

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="ibox-title">
                                <h2>
                                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h2>
                            </div>
                            <div class="ibox-content">
                                <div class="table-responsive">
                                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Codigo Novedad">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="ncoCod" runat="server"
                                                        Text='<%# Eval("ncoCod") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="ncoNombre" runat="server"
                                                        Text='<%# Eval("ncoNombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cant. Dias/Minutos">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="ncoNombre" runat="server"
                                                        Text='<%# Eval("ninCantidad") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Fecha">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="ncoNombre" runat="server"
                                                        Text='<%# Eval("ninFechaDesde") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Cargado por">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="usuNombre" runat="server"
                                                        Text='<%# Eval("usuNombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Actualizado por">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="usuActualiza" runat="server"
                                                        Text='<%# Eval("usuActualiza") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Modificar">
                                                <ItemTemplate>
                                                    <asp:HyperLink
                                                        ForeColor="White" Font-Size="Small" ID="Activo" runat="server"
                                                        ToolTip="Modificar o Eliminar el registro seleccionado"
                                                        class="btn btn-w-m btn-danger"
                                                        NavigateUrl='<%# "NovedadesModificar.aspx?Id=" + 
                                                            DataBinder.Eval(Container.DataItem,"ninId").ToString()
                                                              +"&agru=" + Session["agrupamiento"] 
                                                              + "&fechaLiquidacion=" + Session["fechaLiquidacion"] %>'>                                                        
                                                         <i class="fa fa-pencil"></i>                                                        
                                                        Modificar
                                                    </asp:HyperLink>
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
                        <%--Fin tabla--%>
                    </div>


                    <br />
                    <!--<asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Finalizar" OnClick="btnAceptar_Click" />                    -->
                    <asp:LinkButton ID="btnListar" runat="server" class="btn btn-w-m btn-primary m-b" OnClick="btnAceptar_Click">
                                      <i class="fa fa-long-arrow-left"></i> Volver</asp:LinkButton>
                    </label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
