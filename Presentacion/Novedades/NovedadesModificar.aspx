<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="NovedadesModificar.aspx.cs" Inherits="PerfilRegistracion" %>

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

                    <!-- <div class="form-group">
                        <div class="col-md-4 col-md-offset-0">
                            
                            <asp:LinkButton ID="btnActualizar" runat="server" class="btn btn-w-m btn-primary" OnClick="btnActualizar_Click">
                                      <i class="fa fa-refresh"></i> Actualizar</asp:LinkButton>
                              <asp:LinkButton ID="btnEliminar" runat="server" class="btn btn-w-m btn-danger" OnClick="btnEliminar_Click">
                                      <i class="fa fa-trash"></i> Eliminar</asp:LinkButton>                            
                            <asp:Button ID="btnVolver" class="btn btn-w-m btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

                        </div>
                    </div> 
                    <hr class="hr-line-dashed" /> -->

                    <div class="form-group">
                        <label class="control-label col-md-2">Concepto</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ComboConceptos" runat="server" class="form-control m-b" Enabled="false"
                                AutoPostBack="true" Width="320px" OnSelectedIndexChanged="ComboConceptos_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Cantidad Dias/Min</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDiasMin" type="number" class="form-control m-b" runat="server" AutoPostBack="false"
                                placeholder="Dias/Min"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Fecha</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtFecha" type="date" class="form-control m-b" runat="server"
                                AutoPostBack="false" placeholder="fecha"></asp:TextBox>
                        </div>
                    </div>

                    <hr class="hr-line-dashed" />
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-w-m btn-primary" OnClick="btnActualizar_Click">
                                      <i class="fa fa-refresh"></i> Actualizar</asp:LinkButton>
                            <asp:Button ID="Button1" class="btn btn-w-m btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                              <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-w-m btn-danger" OnClick="btnEliminar_Click">
                                      <i class="fa fa-trash"></i> Eliminar</asp:LinkButton>                            
                        </div>

                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    </div>    
</asp:Content>
