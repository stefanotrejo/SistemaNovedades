<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="MenuRegistracion.aspx.cs" Inherits="MenuRegistracion" %>

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
                    
                        <div class="form-group"><label class="control-label col-md-2"> Nombre</label><div class="col-md-6">
                        <asp:TextBox ID="menNombre" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Menu</label><div class="col-md-6">
                        <asp:DropDownList ID="menIdPadre" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Orden</label><div class="col-md-6">
                        <asp:TextBox ID="menOrden" type="number" step="1" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Url</label><div class="col-md-6">
                        <asp:TextBox ID="menUrl" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Icono</label><div class="col-md-6">
                        <asp:TextBox ID="menIcono" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Es Menu</label><div class="col-md-6">
                        <asp:CheckBox ID="menEsMenu" runat="server" Checked="False" Enabled="true"></asp:CheckBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Activo</label><div class="col-md-6">
                        <asp:CheckBox ID="menActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox></div></div>
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