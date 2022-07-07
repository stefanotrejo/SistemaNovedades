    <%@ Page Title="" Language="C#" MasterPageFile="~/PaginasBasicas/Principal.master" AutoEventWireup="true" CodeFile="AgenteDetalle.aspx.cs" Inherits="UsuarioRegistracion" %>

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
                    <div class="ibox-title">

                        <h5>Cargos del Agente |
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </h5>
                        

                    </div>
                    <div class="ibox-content">
                        <fieldset class="form-horizontal">
                            <%-- <hr class="hr-line-dashed" />--%>
                            <%-- DATOS DEL AGENTE --%>
                            <div class="form-group">
                                <%-- <div class="form-inline">--%>

                                <%--1-A--%>
                                <label class="control-label col-md-1">
                                    Cuil
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtAgeCuit" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--1-B--%>
                                <label class="control-label col-md-2">Apellido y Nombre</label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtAgeApellidoNombre" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--1-C--%>
                                <label class="control-label col-md-1">Fecha nacimiento</label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtFehaNac" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--1-C--%>
                                <%--<label class="control-label col-md-1">Organismo</label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                <%-- <asp:TextBox ID="txtAgeLugarPago" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>
                            </div>

                            <%-- SEGUNDO GRUPO --%>
                            <div class="form-group">
                                <%--<div class="form-inline">--%>
                                <%--2-A--%>

                                <label class="control-label col-md-1">
                                    Juris.
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtJurisdiccion" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--<label class="control-label col-md-1">Escuela</label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                <%--<asp:TextBox ID="txtAgeEscuela" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                  <%--2-B--%>

                                <label class="control-label col-md-2">
                                    Organismo
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeLugarPago" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>



                                <%--  <label class="control-label col-md-2">
                                    Planta
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgePlanta" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <%--2-C--%>
                                <%--<label class="control-label col-md-1">Cargo</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeCargo" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-1">Escuela</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeEscuela" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>


                            <%-- TECER GRUPO --%>
                            <div class="form-group">

                                <%--3-A--%>
                                <%--<label class="control-label col-md-1">Fecha de Ingreso</label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                <%--<asp:TextBox ID="txtAgeFechaIngreso" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-1">
                                    Planta
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtAgePlanta" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--3-B--%>
                                <%--<label class="control-label col-md-2">
                                    Antiguedad reconocida
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAntiguedadReconocida" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-2">
                                    Control
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeNroControl" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--3-C--%>
                                <%-- <label class="control-label col-md-1">Antiguedad</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeAntiguedad" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-1">Cargo</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeCargo" Height="70px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%-- </div>--%>
                            </div>

                            <%-- CUARTO GRUPO --%>
                            <div class="form-group">
                                <%--<div class="form-inline">--%>
                                <%--4-A--%>
                                <%--<label class="control-label col-md-1">Periodo</label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                <%--<asp:TextBox ID="txtAgePeriodo" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-1">Fecha ingreso</label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtAgeFechaIngreso" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>



                                <%--4-B--%>
                                <%-- <label class="control-label col-md-2">
                                    Dias / Obligaciones trabajadas
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeDiasTrabajados" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-2">
                                    Antiguedad reconocida
                                </label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAntiguedadReconocida" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--4-C--%>
                                <%-- <label class="control-label col-md-1">Sit. de Revista</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeSituacionRevista" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <label class="control-label col-md-1">Antiguedad</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeAntiguedad" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%-- </div>--%>
                            </div>

                            <%-- QUINTO GRUPO --%>
                            <div class="form-group">
                                <%-- <div class="form-inline">--%>
                                <%--<label class="control-label col-md-1">Haber</label>--%>
                                <%--5-A--%>

                                <%-- <asp:Label runat="server" ID="lblHaber" Font-Bold="true" class="control-label col-md-1">Haber</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgeHaber" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <asp:Label runat="server" ID="Label5" Font-Bold="true" class="control-label col-md-1">Periodo</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgePeriodo" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--5-B--%>
                                <%--  <asp:Label runat="server" ID="lblSalarioFamiliar" Font-Bold="true" class="control-label col-md-2">Salario Familiar</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeSalarioFamiliar" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <asp:Label runat="server" ID="Label6" Font-Bold="true" class="control-label col-md-2">Dias/Oblig. trabajadas</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeDiasTrabajados" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--5-C--%>
                                <%-- <asp:Label runat="server" ID="lblDescuentos" Font-Bold="true" class="control-label col-md-1">Descuentos</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeDescuentos" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <asp:Label runat="server" ID="Label7" Font-Bold="true" class="control-label col-md-1">Situacion revista</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeSituacionRevista" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>

                            <%-- SEXTO GRUPO - DIRECTOR --%>
                            <div class="form-group">
                                <%--6-A--%>
                                <%-- <asp:Label runat="server" ID="lblLiquido" Font-Bold="true" class="control-label col-md-1">Liquido</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgeLiquido" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <asp:Label runat="server" ID="lblHaber" Font-Bold="true" class="control-label col-md-1">Haber</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtAgeHaber" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--6-B--%>
                                <%-- <asp:Label runat="server" ID="lblTotalSinCargosAlHaber" Font-Bold="true" class="control-label col-md-2">Total sin cargos al Haber</asp:Label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtTotalSinCargo" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <asp:Label runat="server" ID="lblSalarioFamiliar" Font-Bold="true" class="control-label col-md-2">Salario Familiar</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeSalarioFamiliar" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                                <%--6-C--%>
                                <%--<asp:Label runat="server" ID="lblRemuneracionOit" Font-Bold="true" class="control-label col-md-1">Remun. OIT</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtRemuneracionOIT" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                <asp:Label runat="server" ID="lblLiquido" Font-Bold="true" class="control-label col-md-1">Liquido</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAgeLiquido" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                            </div>

                            <%-- SEPTIMO GRUPO - D.G. PERSONAL --%>
                            <div class="form-group">
                                <%--7-A--%>
                                <asp:Label runat="server" ID="lblAsistenciaPerfecta" Font-Bold="true" class="control-label col-md-1">Asist. Perfecta</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtAsistenciaPerfecta" Height="40px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%--7-B--%>
                                <asp:Label runat="server" ID="lblRiesgoVida" Font-Bold="true" class="control-label col-md-2">Riesgo de vida</asp:Label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtRiesgoVida" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%--7-C--%>
                                <asp:Label runat="server" ID="lblJurRetActivo" Font-Bold="true" class="control-label col-md-1">Jub/Ret Activo</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtJubRetActivo" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%-- </div>--%>
                            </div>

                            <%-- OCTAVO GRUPO - UERT  --%>
                            <div class="form-group">
                                <%--8-A--%>
                                <asp:Label runat="server" ID="lblDescuentos" Font-Bold="true" class="control-label col-md-1">Desctos.</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtAgeDescuentos" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--8-B--%>
                                <asp:Label runat="server" ID="lblTotalSinCargosAlHaber" Font-Bold="true" class="control-label col-md-2">Tot. s/cgos. al Haber</asp:Label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <%--<div class="col-md-6">--%>
                                    <asp:TextBox ID="txtTotalSinCargo" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>

                                <%--8-C--%>
                                <asp:Label runat="server" ID="lblRemuneracionOit" Font-Bold="true" class="control-label col-md-1">Rem. OIT</asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtRemuneracionOIT" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>
                                <%-- </div>--%>
                            </div>

                            <%-- NOVENO GRUPO --%>
                            <div class="form-group">
                                <%--9-A--%>
                                   <asp:Label runat="server" ID="lblDiasNoTrabajados" Font-Bold="true" class="control-label col-md-1">Dias/Oblig. No trabajadas</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtDiasNoTrabajados" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>


                               <%-- <asp:Label runat="server" ID="lblPercibeFonid" Font-Bold="true" class="control-label col-md-1">Percibe fondos Nacion</asp:Label>
                                <div class="col-md-2" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtPercibeFonid" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                 <%--9-B--%>
                             <%--   <asp:Label runat="server" ID="lblFonid" Font-Bold="true" class="control-label col-md-2">Fonid</asp:Label>
                                <div class="col-md-3" style="left: 0px; top: 0px">
                                    <asp:TextBox ID="txtFonid" Height="50px" TextMode="MultiLine" type="text" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                </div>--%>

                                 <%--9-C--%>
                            </div>

                             <div class="form-group">
                                 <%--Boton de conceptos--%>
                                 <div class="col-md-2 col-md-offset-1">
                                <asp:Button ID="btnConceptos" class="btn btn-w-m btn-danger" runat="server" Text="Ver Conceptos" OnClick="btnConceptos_Click"/>                                     
                            </div>
                                 </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <br />
                            <div class="ibox-title">
                                <h5>Pagina:
                    <asp:Label ID="lblPaginaActual" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblPaginaFin" runat="server"></asp:Label>
                                </h5>
                            </div>
                            <div class="col-md-2 col-md-offset-0">
                                <asp:Button ID="btnAnterior" class="btn btn-w-m btn-danger" runat="server" Text="Anterior" OnClick="btnAnterior_Click" />
                            </div>
                            <div class="col-md-1 col-md-offset-0">
                                <asp:Button ID="btnSiguiente" class="btn btn-w-m btn-danger" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" />
                            </div>
                        </div>
                    </div>
                    
                     <div class="col-sm-12">
                        <div class="form-group">
                            <br />
                          <div class="col-md-2 col-md-offset-0">
                                    <!–GENERAR LISTADO –>
                                    <asp:Button ID="btnListar" class="btn btn-w-m btn-danger" runat="server" Text="Listar" OnClick="btnListar_Click" Style="height: 36px" />
                                </div>

                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group">
                            <br />
                            <div class="col-md-2 col-md-offset-0">
                                <asp:Button ID="btnAceptar1" class="btn btn-w-m btn-primary" runat="server" Text="Volver" OnClick="btnAceptar_Click" />
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
