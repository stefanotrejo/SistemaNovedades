<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="GrillaPaginaMaestra.aspx.cs" Inherits="PaginasPrueba_GrillaPaginaMaestra" %>

<%@ MasterType TypeName="PaginasBasicas_Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="Server">
    <div class="row">
        <div class="col-sm-8">
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="True"
                        PageSize="120" AllowPaging="False">
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla1" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="True"
                        PageSize="120" AllowPaging="False">
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <hr class="hr-line-dashed" />
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:GridView ID="Grilla2" runat="server" GridLines="None" CssClass="table table-striped"
                        AutoGenerateColumns="True"
                        PageSize="120" AllowPaging="False">
                        <FooterStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <PagerSettings Position="Top" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

