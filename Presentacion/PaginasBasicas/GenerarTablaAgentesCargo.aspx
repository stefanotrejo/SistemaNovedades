<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerarTablaAgentesCargo.aspx.cs" Inherits="PaginasPrueba_GenerarTablaAgentesCargo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <!--  <h4>Select a file to upload:</h4>
       
        <asp:FileUpload id="FileUpload1"                 
            runat="server">
        </asp:FileUpload>

        <div>
            <asp:Button ID="btnPrueba" runat="server" Text="Prueba" OnClick="btnPrueba_Click" />
        </div>
            
        <br/><br/>

        <div>
            <asp:Label ID="lblArchivoLiquidacion" runat="server" Text="" Visible="true" color="red"></asp:Label>
        </div>
             
        <hr />      

              -->

        <div>
            <asp:CheckBox ID="validarPeriodo" Checked="true" runat="server" Text="Validar periodo" />
        </div>
        <br />
        <br />

        <br />
        <div>
            <asp:Button ID="Button2" runat="server" Text="Importar PRE" OnClick="Button2_Click" />
        </div>
        <br />
        <br />

        <div>
            <asp:Button ID="Button1" runat="server" Text="Importar Liquidacion" OnClick="btnImportar_Click_2" />
        </div>
        <br />
        <br />

        <div>
            <asp:TextBox ID="txtFechaLiquidacion" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="lblFechaLiquidacion" runat="server" Text="Ingrese mes y año de Liquidacion" Visible="true" color="red"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnCasoUno" runat="server" Text="Caso 1" OnClick="btnCasoUno_Click" />
        </div>

        <br />
        <br />

        <div>
            <asp:Button ID="btnCasoDos" runat="server" Text="Caso 2" OnClick="btnCasoDos_Click" />
        </div>

        <br />
        <br />

        <div>
            <asp:Button ID="btnCasoCuatro" runat="server" Text="Calcular Nuevo Total Haberes" OnClick="btnCasoCuatro_Click" />
        </div>

        <br />
        <br />

        <div>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" color="red"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Label ID="lblFechaHoraInicio" runat="server" Text="Label" Visible="true" color="red"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Label ID="lblFechaHoraFin" runat="server" Text="Label" Visible="false" color="red"></asp:Label>
        </div>

        <br />
        <asp:Button ID="btnImportarPersonal" runat="server" Text="Importar Archivo Personal" OnClick="btnImportarPersonal_Click" />
        <br />
        <br />
        <asp:Button ID="btnExportarDbf" runat="server" Text="Exportar DBF" OnClick="btnExportarDbf_Click" />
        <br />
        <br />
        <asp:Button ID="btn_generar_arch_ext_doc" runat="server" Text="Generar Archivos Ext Doc" OnClick="btn_generar_arch_ext_doc_Click" />

        <br />
        <br />
        <asp:TextBox ID="txt_concepto" Text="Concepto Pagos Eventuales" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_importar_pagos_eventuales" runat="server" Text="Importar pagos eventuales" OnClick="btn_importar_pagos_eventuales_Click" />

    </form>



</body>
</html>
