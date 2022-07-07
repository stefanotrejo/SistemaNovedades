<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="PaginasBasicas_Inicio" %>

<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="col-sm-12">
        <div class="ibox-content">
            <fieldset class="form-horizontal">
                <asp:Label ID="lblMenu" runat="server" Text=""></asp:Label>
            </fieldset>
        </div>
    </div>
</asp:Content>
