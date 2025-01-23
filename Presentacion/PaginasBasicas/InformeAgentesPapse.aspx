<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformeAgentesPapse.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                            <div class="form-group">
                                <label class="control-label col-md-3">Año:</label>
                                <label class="control-label col-md-1">Mes:</label>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Periodo:
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
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblClaseDesde" CssClass="control-label col-md-2" runat="server" Text="Clase desde:" Visible="false"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtClaseDesde" Visible="false" class="form-control" placeholder="Ingrese clase desde ej:1925"
                                        runat="server" type="number" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblClaseHasta" Visible="false" CssClass="control-label col-md-2" runat="server" Text="Clase hasta:"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtClaseHasta" Visible="false" class="form-control" placeholder="Ingrese clase hasta ej:1964"
                                        runat="server" type="number" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblAntiguedadDesde" Visible="false" CssClass="control-label col-md-2" runat="server" Text="Antiguedad desde:"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAntiguedadDesde" Visible="false" class="form-control" placeholder="Ingrese años de ant. desde"
                                        runat="server" type="number" MaxLength="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblAntiguedadHasta" Visible="false" CssClass="control-label col-md-2" runat="server" Text="Antiguedad hasta:"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAntiguedadHasta" Visible="false" class="form-control" placeholder="Ingrese años de ant. hasta"
                                        runat="server" type="number" MaxLength="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblSexo" Visible="false" CssClass="control-label col-md-2" runat="server" Text="Sexo:"></asp:Label>
                                <div class="col-md-3">
                                    <asp:RadioButtonList ID="radioSexo" Visible="false" runat="server">
                                        <asp:ListItem>M</asp:ListItem>
                                        <asp:ListItem>F</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:Button ID="btnGenerarListado" class="btn btn-w-m btn-primary" runat="server" Text="Generar listado"
                                        OnClick="btnGenerarListado_Click" Style="height: 36px" Enabled="false" />
                                </div>
                            </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
