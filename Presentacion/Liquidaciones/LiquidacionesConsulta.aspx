<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="LiquidacionesConsulta.aspx.cs" Inherits="UsuarioRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
   <!-- <div class="row">
        <div class="col-sm-12">
        <div class="pull-right">                    
                <asp:Button ID="Button1" class="btn btn-w-m btn-warning" runat="server" Text="Nuevo" />
                <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server"
                    Text="Exportar a Excel" />
                <asp:Button ID="btnVolver" class="btn btn-w-m btn-danger" runat="server" Text="Volver"
                    Visible="false" />
            </div>
            </div>       
    </div> -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">                
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-sm-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <h3>Liquidacion</h3>
                            <hr class="hr-line-dashed" />

                            <div class="form-group">
                                <label class="control-label col-md-1">Liq Id:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtLiqId" type="text" class="form-control" runat="server" Width="100px"
                                        ReadOnly></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">

                                <label class="control-label col-md-1">Mes:</label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtMes" type="text" class="form-control" runat="server" Width="100px"
                                        ReadOnly></asp:TextBox>
                                </div>

                                <label class="control-label col-md-1">Año:</label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtAnio" type="text" class="form-control" runat="server" Width="100px" ReadOnly></asp:TextBox>
                                </div>

                                <label class="control-label col-md-1">Etapa:</label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEtapa" type="text" class="form-control" runat="server" Width="120px" ReadOnly></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group row">
                                <label class="control-label col-md-1">Inicio:</label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtFechaInicio" type="text" class="form-control" runat="server" Width="100px" ReadOnly></asp:TextBox>
                                </div>

                                <label class="control-label col-md-1">Cierre:</label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtFechaCierre" type="text" class="form-control" runat="server" Width="100px" ReadOnly></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-1">Estado:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtEstado" type="text" class="form-control" runat="server" Width="100px" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Button ID="btnNuevo" class="btn btn-w-m btn-primary" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                                    <asp:Button ID="btnModificar" class="btn btn-w-m btn-primary" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                                    <asp:Button ID="btnEliminar" class="btn btn-w-m btn-primary" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                                    <asp:Button ID="btnAbrir" class="btn btn-w-m btn-danger" runat="server" Text="Abrir" OnClick="btnAbrirr_Click" />
                                    <asp:Button ID="btnCerrarPersonal" class="btn btn-w-m btn-danger" runat="server" Text="Cerrar para Personal " OnClick="btnCerrarPersonal_Click" />
                                    <asp:Button ID="btnCerrar" class="btn btn-w-m btn-danger" runat="server" Text="Cerrar" OnClick="btnCerrar_Click" />                                </div>
                                <asp:Button ID="btnGenerarArchivos" class="btn btn-w-m btn-danger" runat="server" Text="Generar Archivos" OnClick="btnGenerarArchivos_Click" />
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
           
            <div class="row" style="margin-top:5px">
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <h3>Filtros</h3>
                            <hr class="hr-line-dashed" />
                            <div class="form-group">
                                <label class="control-label col-md-3">Año:</label>
                                <label class="control-label col-md-1">Mes:</label>
                                <label class="control-label col-md-1">Etapa:</label>
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
                                        <asp:ListItem Value="01">1</asp:ListItem>
                                        <asp:ListItem Value="02">2</asp:ListItem>
                                        <asp:ListItem Value="03">3</asp:ListItem>
                                        <asp:ListItem Value="04">4</asp:ListItem>
                                        <asp:ListItem Value="05">5</asp:ListItem>
                                        <asp:ListItem Value="06">6</asp:ListItem>
                                        <asp:ListItem Value="07">7</asp:ListItem>
                                        <asp:ListItem Value="08">8</asp:ListItem>
                                        <asp:ListItem Value="09">9</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="comboEtapa" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px">
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Traer todas las Etapas:</label>
                                <asp:CheckBox ID="chkObtenerTodos" runat="server" AutoPostBack="false" Checked="true" />
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:Button ID="btnConsultar" class="btn btn-w-m btn-primary" runat="server" Text="Buscar" OnClick="btnConsultar_Click" Style="height: 36px" />
                                </div>
                            </div>
                    </div>
                </div>
            </div>

            <div class="row" style="margin-top:5px">
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

                    <%--<div class="ibox-content">--%>
                    <%--<div class="col-lg-12">--%>
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <div class="table-responsive">
                                <asp:GridView ID="Grilla" runat="server" AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound"
                                    OnRowCommand="Grilla_RowCommand" CssClass="table table-striped" data-page-size="30"
                                    data-filter="#filter" PageSize="30">
                                    <Columns>
                                        <asp:BoundField DataField="liqId" HeaderText="Id" />
                                        <asp:BoundField DataField="liqDescripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="liqMes" HeaderText="Mes" />
                                        <asp:BoundField DataField="liqAnio" HeaderText="Año" />
                                        <asp:BoundField DataField="liqEtapa" HeaderText="Etapa" />
                                        <asp:BoundField DataField="liqFechaInicio" HeaderText="Fecha inicio" />
                                        <asp:BoundField DataField="liqFechaCierre" HeaderText="Fecha cierre" />
                                        <asp:BoundField DataField="liqEstado" HeaderText="Estado" />
                                        <asp:ButtonField CommandName="Seleccionar" HeaderText="Seleccionar" Text="Seleccionar"  />

                                        <%--  <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbuEliminar" runat="server" OnClick="lbuEliminar_Click"
                                                    ToolTip="Elimina de forma permanente el registro seleccionado">X</asp:LinkButton>
                                                <asp:Button ID="btnEliminarAceptar" runat="server" Text="Si" Visible="False"
                                                    OnClick="btnEliminarAceptar_Click" />
                                                <asp:Button ID="btnEliminarCancelar" runat="server" Text="No" Visible="False"
                                                    OnClick="btnEliminarCancelar_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
