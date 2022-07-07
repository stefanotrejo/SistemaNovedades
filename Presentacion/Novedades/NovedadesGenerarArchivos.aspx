<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="NovedadesGenerarArchivos.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Liquidacion:
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="selectLiquidaciones" runat="server" class="form-control" data-placeholder="Seleccione una opcion"
                                        Enabled="true" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-8">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">
                                </label>
                                <div class="col-md-10">
                                    <asp:Button ID="btnExportarAExcel" class="btn btn-w-m btn-success" runat="server"
                                        Text="Generar No Presentismo" OnClick="btnGenerarNoPresentismo_Click" Style="height: 36px" />
                                    <asp:Button ID="btnGenerarMultasSuspensiones" class="btn btn-w-m btn-success" runat="server"
                                        Text="Generar Multas y Suspensiones" OnClick="btnGenerarMultasSuspensiones_Click" Style="height: 36px" />
                                </div>                                
                                <!--<div class="col-md-8">
                                </div> -->
                            </div>


                            <%-- //////////////////////////////--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
