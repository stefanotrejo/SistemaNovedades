<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="DescargaExtDocentePrincipal.aspx.cs" Inherits="LiquidacionExtensionDocente" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">                
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
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
                                <label class="control-label col-md-2">Traer todas las Liquidaciones:</label>
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
                                        <asp:BoundField DataField="id" HeaderText="Id" />
                                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="mes_referencia" HeaderText="Mes" />
                                        <asp:BoundField DataField="anio_referencia" HeaderText="Año" />
                                        <asp:BoundField DataField="etapa" HeaderText="Etapa" />
                                        <asp:BoundField DataField="fechaInicio" HeaderText="Fecha inicio" />
                                        <asp:BoundField DataField="fechaCierre" HeaderText="Fecha cierre" />
                                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                                        <asp:ButtonField CommandName="Seleccionar" HeaderText="Seleccionar" Text="Seleccionar"  />  
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
