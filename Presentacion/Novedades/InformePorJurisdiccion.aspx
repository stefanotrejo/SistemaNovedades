<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="InformePorJurisdiccion.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                                                      
                            <div class="col-sm-12">
                                   <label class="control-label col-md-2">
                                    Jurisdiccion:
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="selectJurisdiccion" runat="server" class="form-control" data-placeholder="Seleccione una opcion"
                                        Enabled="true" AutoPostBack="True" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                           
                            <div class="col-sm-12" style="margin-top:20px">
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button ID="btnConsultar" class="btn btn-w-m btn-primary" runat="server" Text="Consultar"
                                        OnClick="btnConsultar_Click" />
                                </div>
                            </div>
                                                       
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
