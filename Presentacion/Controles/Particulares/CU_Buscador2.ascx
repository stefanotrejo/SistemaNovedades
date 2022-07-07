<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CU_Buscador2.ascx.cs"
    Inherits="Controles_Particulares_CU_Buscador2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="atk" %>
<style type="text/css">
    .AutoExtender {
        font-weight: normal;
        border: solid 1px #AAAAAA;
        line-height: 20px;
        padding: 10px;
        background-color: White;
        margin-left: 0px;
        list-style-type:none;
    }

    .AutoExtenderList {
        border-bottom: dotted 1px #AAAAAA;
        cursor: pointer;
        color: gray;
        list-style-type:none;
    }

    .AutoExtenderHighlight {
        color: White;
        background-color: #AAAAAA;
        cursor: pointer;
        list-style-type:none;
    }

    #divwidth {
        width: 800px !important;
    }

        #divwidth div {
            width: 800px !important;
        }
</style>

<asp:TextBox ID="txt" runat="server" MaxLength="50" Enabled="true" class="form-control m-b"
    placeholder="[Sin asignar]" Text="" AutoPostBack="True" OnTextChanged="txt_TextChanged"
    onFocus="this.select();" onClick="this.select();"></asp:TextBox>

<atk:AutoCompleteExtender ID="ace" runat="server" Enabled="true" EnableCaching="true"
    MinimumPrefixLength="2" TargetControlID="txt" ServiceMethod="ObtenerLista" ServicePath="Buscador2.asmx"
    ContextKey="" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
    CompletionSetCount="20" FirstRowSelected="True" />
<asp:Label ID="lblSelectedValue" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lblSelectedText" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lblSql" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lblMensajeNoEncontrado" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lblpueId" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="lblusuId" runat="server" Text="" Visible="false"></asp:Label>
