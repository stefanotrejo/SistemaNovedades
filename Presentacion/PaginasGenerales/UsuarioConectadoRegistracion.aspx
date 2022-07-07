<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="UsuarioConectadoRegistracion.aspx.cs" Inherits="UsuarioConectadoRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="form-group">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnAceptar" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnCancelar" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

	    <div class="col-sm-12">
		    <div class="ibox-content">
			    <fieldset class="form-horizontal">				   
                    
                        <div class="form-group"><label class="control-label col-md-2"> Usuario</label><div class="col-md-6">
                        <asp:DropDownList ID="usuId" runat="server" class="form-control m-b" Enabled="true"></asp:DropDownList></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Fecha Hora Ultima Conexion</label><div class="col-md-6">
                        <tpDatePicker:cuFecha ID="ucoFechaHoraUltimaConexion" runat="server" Enabled="true" AllowType="False" /></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Guid</label><div class="col-md-6">
                        <asp:TextBox ID="ucoGuid" Height="100px" TextMode="MultiLine" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Ip Publica</label><div class="col-md-6">
                        <asp:TextBox ID="ucoIpPublica" type="text" class="form-control" runat="server"></asp:TextBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Desconectar</label><div class="col-md-6">
                        <asp:CheckBox ID="ucoDesconectar" runat="server" Checked="False" Enabled="true"></asp:CheckBox></div></div>
                        <div class="form-group"><label class="control-label col-md-2"> Activo</label><div class="col-md-6">
                        <asp:CheckBox ID="ucoActivo" runat="server" Checked="True" Enabled="true"></asp:CheckBox></div></div>
                    <hr class="hr-line-dashed" />
                </fieldset>
            </div>
        </div>

        <div class="col-sm-12" >
            <div class="ibox-content" >
                <div class="form-inline" >
                    <div class="form-group" >
                        <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" Width="100%" />
                    </div>
                    <div class="form-group" >
                        <asp:Button ID="btnCancelar1" class="btn btn-w-m btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Width="100%" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>