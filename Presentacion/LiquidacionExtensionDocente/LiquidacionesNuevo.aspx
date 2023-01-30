<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="LiquidacionesNuevo.aspx.cs" Inherits="LiquidacionExtensionDocenteAlta" %>

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
                        <label class="control-label col-md-2">Mes de Archivo de Entrada</label><div class="col-md-6">
                            <asp:DropDownList ID="comboMesLiquidacion" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                Enabled="true" AutoPostBack="true" Width="140px" OnSelectedIndexChanged="comboMesLiquidacion_SelectedIndexChanged">
                                <asp:ListItem Value="Febrero">Enero</asp:ListItem>
                                <asp:ListItem Value="Marzo">Febrero</asp:ListItem>
                                <asp:ListItem Value="Abril">Marzo</asp:ListItem>
                                <asp:ListItem Value="Mayo">Abril</asp:ListItem>
                                <asp:ListItem Value="Junio">Mayo</asp:ListItem>
                                <asp:ListItem Value="Julio">Junio</asp:ListItem>
                                <asp:ListItem Value="Agosto">Julio</asp:ListItem>
                                <asp:ListItem Value="Septiembre">Agosto</asp:ListItem>
                                <asp:ListItem Value="Octubre">Septiembre</asp:ListItem>
                                <asp:ListItem Value="Noviembre">Octubre</asp:ListItem>
                                <asp:ListItem Value="Diciembre">Noviembre</asp:ListItem>
                                <asp:ListItem Value="Enero">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Año de Archivo de Entrada</label><div class="col-md-6">
                            <asp:TextBox ID="txtAnio" AutoPostBack="true" type="text" class="form-control" runat="server" Width="70px" required OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Etapa</label>
                        <div class="col-md-6">
                            <%--<asp:TextBox ID="txtEtapa" type="text" class="form-control" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="comboEtapa" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                Enabled="true" AutoPostBack="true" Width="80px" OnSelectedIndexChanged="comboEtapa_SelectedIndexChanged">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>                                
                            </asp:DropDownList>
                        </div>
                    </div>
                       <div class="form-group">
                        <label class="control-label col-md-2">Estado</label><div class="col-md-6">
                            <asp:TextBox ID="txtEstado" type="text" class="form-control" runat="server" Width="70px" required></asp:TextBox>
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

                        <div class="form-group">
                        <label class="control-label col-md-2">Fecha Cierre:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtFechaCierre" type="date" class="form-control m-b" runat="server"
                                AutoPostBack="false" placeholder="Fecha de Cierre"></asp:TextBox>
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
