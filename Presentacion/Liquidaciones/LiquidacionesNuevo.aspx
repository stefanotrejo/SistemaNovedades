<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="LiquidacionesNuevo.aspx.cs" Inherits="PerfilRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-12">
            <div class="ibox-content">
                <fieldset class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-0">
                            <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                            <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />

                    <div class="form-group">
                        <label class="control-label col-md-2">Mes</label><div class="col-md-6">
                            <asp:DropDownList ID="comboMesLiquidacion" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                Enabled="true" AutoPostBack="false" Width="140px">
                                <asp:ListItem Value="1">Enero</asp:ListItem>
                                <asp:ListItem Value="2">Febrero</asp:ListItem>
                                <asp:ListItem Value="3">Marzo</asp:ListItem>
                                <asp:ListItem Value="4">Abril</asp:ListItem>
                                <asp:ListItem Value="5">Mayo</asp:ListItem>
                                <asp:ListItem Value="6">Junio</asp:ListItem>
                                <asp:ListItem Value="7">Julio</asp:ListItem>
                                <asp:ListItem Value="8">Agosto</asp:ListItem>
                                <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Año</label><div class="col-md-6">
                            <asp:TextBox ID="txtAnio" type="text" class="form-control" runat="server" Width="70px" required></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Etapa</label>
                        <div class="col-md-6">
                            <%--<asp:TextBox ID="txtEtapa" type="text" class="form-control" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="comboEtapa" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                Enabled="true" AutoPostBack="false" Width="80px">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Descripcion</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDescripcion"  type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Fecha inicio</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtFechaInicio" type="date" class="form-control m-b" runat="server"
                                AutoPostBack="false" placeholder="fecha"></asp:TextBox>
                        </div>
                    </div>
                    <hr class="hr-line-dashed" />
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-0">
                            <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                            <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
