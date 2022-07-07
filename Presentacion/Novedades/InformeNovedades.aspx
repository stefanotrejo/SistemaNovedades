<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformeNovedades.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                                    Año:
                                </label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="MenuRaizListaAnioDesde" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px" OnSelectedIndexChanged="MenuRaizListaAnioDesde_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                               <div class="form-group">
                                <label class="control-label col-md-2">
                                    Mes:
                                </label>
                                <div class="col-md-3">
                                   <asp:DropDownList ID="MenuRaizListaMesDesde" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                              

                                <div class="form-group">
                                <label class="control-label col-md-2">
                                    Liquidacion:
                                </label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="comboLiquidaciones" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                             

             <!--                                                                    
                            <div class="form-group">
                                <label class="control-label col-md-3">Año:</label>
                                <label class="control-label col-md-1">Mes:</label>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">
                                    Periodo:
                                </label>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="MenuRaizListaAnioDesde2" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px" OnSelectedIndexChanged="MenuRaizListaAnioDesde_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="MenuRaizListaMesDesde2" runat="server" class="form-control" data-placeholder="[Nuevo...]"
                                        Enabled="true" AutoPostBack="True" Width="80px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            -->

                              <div class="form-group">
                                <label class="control-label col-md-2">Mostrar todos</label>                                
                                <asp:CheckBox ID="checkMostrarTodos" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="checkMostrarTodos_CheckedChanged" />                                
                            </div>

                             <div class="form-group">
                                <label class="control-label col-md-2">
                                    Cod. de lugar de pago:
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtCodigoLugarPago" class="form-control" placeholder="Ingrese codigo de lugar de pago"
                                        required runat="server" type="number" MaxLength="5"></asp:TextBox>                                    
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
