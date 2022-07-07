<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="Prueba1.aspx.cs" Inherits="UsuarioRegistracion" %>

<%@ Register Src="../Controles/Particulares/cuFecha.ascx" TagName="cuFecha" TagPrefix="tpDatePicker" %>
<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">                
                <div class="form-group">
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                </div>                
            </div>
                       
            <div class="row" style="margin-top:5px">
                <div class="col-sm-12">
                    <div class="ibox-title">                        
                        <h3>                            
                            <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label>
                        </h3>                                                
                    </div>
                    
                    <label>Descarga de Archivos de No Presentismo</label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            OnRowCommand="GridView1_RowCommand" BackColor="White"
            BorderColor="#CC9966" BorderStyle="None"
            BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:TemplateField HeaderText="Archivo" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server"
                            CausesValidation="False"
                            CommandArgument='<%# Eval("Archivo") %>'
                            CommandName="Download" Text='<%# Eval("Archivo") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Tamaño" HeaderText="Tamaño en Bytes" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo de Archivo" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True"
                ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099"
                HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True"
                ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
                                        
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
