<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="PagosEventualesNuevo.aspx.cs" Inherits="UsuarioRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-12">
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <hr class="hr-line-dashed" />
                            <div class="form-group">
                                <label class="control-label col-md-2">Buscar Agente por:</label>
                                <div class="col-md-6">
                                    <asp:RadioButton ID="RadioNumeroControl" runat="server" Text="Numero de Control" AutoPostBack="True" OnCheckedChanged="RadioNumeroControl_CheckedChanged"></asp:RadioButton>
                                    &nbsp; &nbsp;
                                    <asp:RadioButton ID="RadioCuil" runat="server" Text="CUIL" AutoPostBack="True" OnCheckedChanged="RadioCuil_CheckedChanged"></asp:RadioButton>
                                </div>
                            </div>                            
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgeNroControl" required type="number" step="1" min="0" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2">                                    
                                    <asp:Button ID="btnConsultar1" class="btn btn-w-m btn-primary" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                                </div>
                            </div>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    Cargando informacion...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            &nbsp; &nbsp;
                            <div class="form-group">
                                <label class="control-label col-md-2">Nombre y Apellido</label><div class="col-md-6">
                                    <asp:TextBox ID="txtAgeApellidoNombre" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Cuil</label><div class="col-md-6">
                                    <asp:TextBox ID="txtAgeCuit" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Codigo de Lugar de Pago</label><div class="col-md-6">
                                    <asp:TextBox ID="txtAgeLugarPagoCodigo" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button ID="btnConsultarLugarPago" class="btn btn-w-m btn-primary" runat="server" Text="Consultar Lugar Pago" Visible="false" OnClick="BtnConsultarLugarPago_Click" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Lugar de Pago</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAgeLugarPago" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-2" style="left: 0px; top: 0px">
                                    <asp:CheckBox ID="CheckBoxAcumulado" runat="server" OnCheckedChanged="CheckBoxAcumulado_CheckedChanged" Text="Pago Acumulado" AutoPostBack="True" />
                                </div>
                            </div>
                            <%--  DROP IN LINE --%>
                            <div class="form-group">
                                <label class="control-label col-md-2">Periodo</label>
                                <div class="col-sm-6" style="left: 0px; top: 0px">
                                    <div class="ibox-content">
                                        <div class="form-inline">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="DropDownListMesDesde" runat="server" class="form-control"
                                                            Enabled="true" AutoPostBack="True" Width="210px" AppendDataBoundItems="true">
                                                            <asp:ListItem Value="0">Seleccione mes desde...</asp:ListItem>
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
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TxtBoxAnioDesde" type="number" step="1" min="0" class="form-control" runat="server" placeholder="Ingrese año desde..."></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="DropDownListMesHasta" runat="server" class="form-control"
                                                            Enabled="true" AutoPostBack="True" Width="210px" AppendDataBoundItems="true" Visible="False">
                                                            <asp:ListItem Value="0">Seleccione mes hasta...</asp:ListItem>
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
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    <div class="form-group">
                                                        <asp:TextBox ID="TxtBoxAnioHasta" type="number" step="1" min="0" class="form-control" runat="server" Visible="False" placeholder="Ingrese año hasta..."></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>                            
                            <div class="form-group">
                                <label class="control-label col-md-2">Importe</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAgeImporte" type="number" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Concepto</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtConcepto" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group">
                                    <br />
                                    <div class="col-md-4 col-md-offset-0">
                                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                        
                                    </div>
                                </div>
                            </div>
                            
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <br />
                                    <div class="col-md-4 col-md-offset-0">                                        
                                        <asp:Button ID="btnGenerar" class="btn btn-w-m btn-primary" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
                                    </div>
                                </div>
                            </div>
                        </label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
