<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AgenteConceptos.aspx.cs" Inherits="UsuarioRegistracion" %>

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



                    <%-- CARGOS DEL AGENTE --%>

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="ibox-title">
                                <h5>Cargos del Agente |
                    <asp:Label ID="lblCantidadRegistros" runat="server" Text=""></asp:Label></h5>
                            </div>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    Cargando informacion...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div class="ibox-content">
                                <div class="table-responsive">
                                    <asp:GridView ID="Grilla" runat="server" GridLines="None" CssClass="table table-striped"
                                        AutoGenerateColumns="False" OnRowDataBound="Grilla_RowDataBound" OnRowCommand="Grilla_RowCommand"
                                        PageSize="12" AllowPaging="True" OnPageIndexChanging="Grilla_PageIndexChanging">

                                        <PagerStyle
                                            Height="30px"
                                            VerticalAlign="Bottom"
                                            HorizontalAlign="Center" Font-Size="Medium" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Codigo de Concepto">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="Codigo" runat="server" Text='<%# Eval("Codigo") %>'  />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Descripcion">
                                                <ItemTemplate>
                                                    <asp:HyperLink ForeColor="Black" ID="Codigo" runat="server" Text='<%# Eval("Nombre") %>'  />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Importe">
                                                <ItemTemplate>
                                                    <%--<asp:HyperLink ForeColor="Black" ID="Nombre" runat="server" NavigateUrl='<%# "ParametroRegistracionCustom.aspx?Id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'
                                        Text='<%# Eval("Nombre") %>' />--%>
                                                    <asp:HyperLink ForeColor="Black" ID="Importe" runat="server" Text='<%# Eval("Importe") %>'  />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                            
                                        </Columns>
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <PagerSettings Position="Top" />
                                        <PagerStyle HorizontalAlign="Left" />
                                    </asp:GridView>
                                </div>
                            </div>

                            <div class="col-sm-12">
                            <div class="form-group">
                                <div class="col-md-12 col-md-offset-0" style="left: 0px; top: 0px">
                                    <!–TEXTO DE CONCEPTOS QUE SE MUESTRAN –>
                                    <h4>
                    <asp:Label ID="Label1" runat="server" Text="* Se incluyen conceptos con código 002 al 601, código 626, 746 y 747."></asp:Label></h4>
                                </div>
                            </div>
                                </div>

                            <div class="col-sm-12">
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-0" style="left: 0px; top: 0px">
                                    <!–GENERAR LISTADO –>
                                    <asp:Button ID="btnListar" class="btn btn-w-m btn-primary" runat="server" Text="Listar" Style="height: 36px" />
                                </div>
                            </div>
                                </div>
                            
                         <div class="col-sm-12">
                        <div class="form-group">
                            <br />
                            <div class="col-md-2 col-md-offset-0">
                                <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Volver" OnClick="btnAceptar1_Click"/>
                            </div>
                        </div>      
                        </div>                                          
                        </div>
                    </div>
                </div>

            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
