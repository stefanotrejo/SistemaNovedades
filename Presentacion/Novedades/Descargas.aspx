<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master"
    AutoEventWireup="true" CodeFile="Descargas.aspx.cs" Inherits="PaginasBasicas_Inicio" %>

<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="col-sm-12">
        <div class="ibox-content">
            <fieldset class="form-horizontal">
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
            </fieldset>
             <br />                    
                    <asp:LinkButton ID="btnVolver" runat="server" class="btn btn-w-m btn-primary m-b" OnClick="btnVolver_Click">
                                      <i class="fa fa-long-arrow-left"></i> Volver</asp:LinkButton>
        </div>
    </div>

</asp:Content>
