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
                                    <%--
                                    <asp:RadioButton ID="RadioDni" runat="server" Text="DNI o CUIL" AutoPostBack="True" OnCheckedChanged="RadioDni_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    <asp:RadioButton ID="RadioApellidoyNombre" runat="server" Text="Apellido y Nombre" AutoPostBack="True" OnCheckedChanged="RadioApellidoyNombre_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    --%>
                                    <asp:RadioButton ID="RadioNumeroControl" runat="server" Text="Numero de Control" AutoPostBack="True" OnCheckedChanged="RadioNumeroControl_CheckedChanged"></asp:RadioButton>
                                </div>
                            </div>
                            <%-- FIN RADIO IN LINE --%>

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgeNroControl" class="form-control" placeholder="Ingrese Nº de Control" required runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button ID="btnConsultar1" class="btn btn-w-m btn-primary" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                                </div>
                            </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">

                            <div class="form-group">
                                <label class="control-label col-md-2">Nombre y Apellido</label><div class="col-md-6">
                                    <asp:TextBox ID="txtNombre" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Cuil</label><div class="col-md-6">
                                    <asp:TextBox ID="txtCuil" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Lugar de Pago</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtLugarPago" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Cargo</label><div class="col-md-6">
                                    <asp:TextBox ID="txtCargo" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>

                <div class="col-sm-12">
                    <div class="form-group">
                        <br />
                        <div class="col-md-4 col-md-offset-0">
                            <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Grabar" OnClick="btnAceptar_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
